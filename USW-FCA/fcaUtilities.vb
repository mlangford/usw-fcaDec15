Imports System.Text
Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Module fcaUtilities

#Region "getNWlayers"

    'Returns an arraylist with names & index positions of
    'all Network Dataset layers in the current focus map

    Function getNWLayers() As ArrayList


        Dim listNWlayers As New ArrayList
        Dim selectedNWlayer As layerItem

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            Dim pLayer As ILayer
            For i As Integer = 0 To pMap.LayerCount - 1
                pLayer = pMap.Layer(i)
                If TypeOf pLayer Is INetworkLayer Then
                    selectedNWlayer.position = i
                    selectedNWlayer.title = pLayer.Name
                    listNWlayers.Add(selectedNWlayer)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getNWLayers = listNWlayers

    End Function

#End Region

#Region "getPointlayers"

    'Returns list of layerItems carrying names & index
    'positions of all point data layers. if the omit parameter > 0,
    'the layer with this index value is ommitted from the list

    Function getPointlayers(omit As Integer) As List(Of layerItem)

        Dim list_point_layers As New List(Of layerItem)
        Dim list_item As layerItem

        Dim pLayer As ILayer = Nothing
        Dim PFLayer As IFeatureLayer = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            Dim layerCount As Integer = pMap.LayerCount


            For i As Integer = 0 To layerCount - 1
                pLayer = pMap.Layer(i)
                If TypeOf pLayer Is IGeoFeatureLayer Then
                    PFLayer = pLayer
                    If PFLayer.FeatureClass.ShapeType = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint Then
                        If omit <> i Then
                            list_item.title = pLayer.Name
                            list_item.position = i
                            list_point_layers.Add(list_item)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util2 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getPointlayers = list_point_layers

    End Function

#End Region

#Region "getDatafields"

    'Returns a list of layerItems carrying the names & index positions of all numeric
    'data attribute fields in the Feature Class located at the passed index position 

    Function getDatafields(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFClass As IFeatureClass = Nothing
        Dim fields As IFields = Nothing
        Dim field As IField = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)
            pFClass = pFLayer.FeatureClass
            fields = pFClass.Fields

            'cycle through each field to identify type
            'only add a field of data type: small int, int, single or double
            Dim list_item As layerItem
            For i As Integer = 0 To fields.FieldCount - 1
                field = fields.Field(i)
                If field.Type < 4 Then
                    list_item.title = field.Name
                    list_item.position = i
                    list_Fields.Add(list_item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock util3 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields = list_Fields

    End Function


    'Returns a list of layerItems carrying the name and index position of all numeric data
    'attribute fields in the Table of the Feature Class located at the passed index position 
    Function getDatafields2(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing
        Dim list_item As layerItem = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)

            '**Cast to ITable to access fields in a joined table
            Dim pDisplayTable As IDisplayTable = pFLayer
            Dim pTable As ITable = pDisplayTable.DisplayTable
            pFields = pTable.Fields

            'cycle through each field, identify type, and only
            'add fields of type: small int, int, single or double
            For i As Integer = 0 To pFields.FieldCount - 1
                pField = pFields.Field(i)
                If pField.Type < 4 Then
                    list_item.title = pField.Name
                    list_item.position = i
                    list_Fields.Add(list_item)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: getDatafields2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields2 = list_Fields

    End Function


    'Returns a list of layerItems carrying the name and index position of all attribute
    'fields in the Table of the Feature Class located at the passed index position
    Function getDatafields3(layerIndex As Integer) As List(Of layerItem)

        Dim list_Fields As New List(Of layerItem)

        Dim pFLayer As IFeatureLayer = Nothing
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing
        Dim list_item As layerItem = Nothing

        Try
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap

            pFLayer = pMap.Layer(layerIndex)

            '**Cast to ITable from IFeatureClass
            '     to access fields in a joined table
            Dim pDisplayTable As IDisplayTable = pFLayer
            Dim pTable As ITable = pDisplayTable.DisplayTable
            pFields = pTable.Fields

            'cycle through each field and add to list
            For i As Integer = 0 To pFields.FieldCount - 1
                pField = pFields.Field(i)
                list_item.title = pField.Name
                list_item.position = i
                list_Fields.Add(list_item)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error: getDatafields3", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        getDatafields3 = list_Fields

    End Function

#End Region

#Region "distance-decay scaling function"

    'Scales passed quantity by a distance-based weight using selected decay function 
    Public Function dist_weighted1(ByRef quantity As Double, ByRef distance As Double, m_configObj As configParams) As Double

        Dim cutoff As Double
        cutoff = m_configObj.NWdefCutOffCar

        If m_configObj.filter = decayType.Classic Then
            'No decay
            dist_weighted1 = quantity
        ElseIf m_configObj.filter = decayType.Linear Then
            'Linear decay 
            dist_weighted1 = quantity * (1.0# - (distance / cutoff))
        ElseIf m_configObj.filter = decayType.Gaussian Then
            'Gaussian decay                           
            dist_weighted1 = quantity * Math.Exp(-(distance ^ 2.0#) / ((cutoff * m_configObj.gaussian_bw / 100.0#) ^ 2.0#))
        ElseIf m_configObj.filter = decayType.Butterworth Then
            'Butterworth decay   
            Dim bw As Double = cutoff * m_configObj.butterworth_bw / 100.0#
            dist_weighted1 = quantity * 1.0# / (1.0# + ((distance / bw) ^ m_configObj.butterworth_pwr))
        End If

    End Function

#End Region

#Region "Build NA load string"

    'Returns a NA load string using the full names of any joined fields
    Function getNALoadString(displayTable As IDisplayTable) As String

        Dim builder As New StringBuilder

        Dim pTable As ITable = displayTable.DisplayTable
        Dim pFields As IFields = Nothing
        Dim pField As IField = Nothing

        'Build a string that identifies the field names of the network locations information

        pFields = pTable.Fields

        builder.Append("SourceID ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SourceID") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("SourceOID ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SourceOID") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("PosAlong ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("PosAlong") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("SideOfEdge ")
        For i As Integer = 0 To pFields.FieldCount - 1
            pField = pFields.Field(i)
            If pField.Name.Contains("SideOfEdge") Then
                builder.Append(pField.Name)
                builder.Append(" #; ")
                Exit For
            End If
        Next

        builder.Append("Name ")
        builder.Append(displayTable.DisplayTable.OIDFieldName)
        builder.Append("  #")

        getNALoadString = builder.ToString()

    End Function

#End Region

End Module

