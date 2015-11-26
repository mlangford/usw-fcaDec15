Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geoprocessing
Imports ESRI.ArcGIS.NetworkAnalyst
Imports ESRI.ArcGIS.esriSystem                      'this assembly is needed to use IVARIANTARRAY

Public Class s5_frmResults

#Region "form controls"

    Private m_configObj As configParams

    'Handles passing of the configObject through the forms
    Public Property configObj() As configParams
        Get
            Return m_configObj
        End Get
        Set(ByVal value As configParams)
            m_configObj = value
        End Set
    End Property

    Public Sub New(ByRef cObject As configParams)
        MyBase.New()
        'sets class level variable to the passed user object  
        configObj = cObject
        InitializeComponent()
    End Sub

#End Region

#Region "Compute multi-mode accessibility scores"

    Private Sub btnExecute_Click(sender As System.Object, e As System.EventArgs) Handles btnExecute.Click

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim pLayer As ILayer = Nothing
        Dim pNALayer As INALayer = Nothing
        Dim pNWLayer As INetworkLayer = Nothing
        Dim pNWdataset As INetworkDataset = Nothing

        Dim pNAContextCarCF As INAContext = Nothing   'network analysis context objects
        Dim pNAContextCarOD As INAContext = Nothing

        Dim inputFL As IFeatureLayer = Nothing
        Dim inputFC As IFeatureClass = Nothing
        Dim pDisplayTable As IDisplayTable = Nothing

        'creates a Geoprocessor tool and a parameters arrray
        Dim gp As IGeoProcessor2 = New GeoProcessor
        Dim params As IVariantArray = New VarArrayClass

        btnExecute.Enabled = False

        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(0)   'set TOC to the "Contents View" tab
        lstOutput.Items.Add("Computation feedback...")


        '#############  CF solving ##############


        'track from layer -> to network layer -> to network dataset
        pLayer = pMap.Layer(configObj.NWlayerindexCar)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset

        'set NAContext as a ClosestFacility solver for CAR network dataset
        pNAContextCarCF = fcaNAcreateClosestsolver(pNWdataset)

        Label2.Text = "...loading closest facility data"
        System.Windows.Forms.Application.DoEvents()

        'create and configure the Network Analyst layer
        pNALayer = pNAContextCarCF.Solver.CreateLayer(pNAContextCarCF)
        pLayer = pNALayer
        pLayer.Name = "m1FCA_" + pNAContextCarCF.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1) 'move it to the bottom of the TOC

        'load the 'Facilities' (i.e. supply points) from the selected Feature layer

        'cast to IDisplayTable to access the fields in a joined table
        pLayer = pMap.Layer(configObj.SupplyLayerIndexCar)
        pDisplayTable = pLayer
        Dim loadString As String = fcaUtilities.getNALoadString(pDisplayTable)

        'fill parameters for CF tool, then load the points
        params.Add(pNALayer)
        params.Add("Facilities")
        params.Add(pDisplayTable)
        params.Add(loadString)
        gp.Execute("AddLocations_na", params, Nothing)

        'load the 'Incidents' (ie demand points) from the selected Feature Layer

        'cast to IDisplayTable to access the fields in a joined table
        pLayer = pMap.Layer(configObj.DemandLayerIndexCar)
        pDisplayTable = pLayer
        loadString = fcaUtilities.getNALoadString(pDisplayTable)

        'clear previous parameters
        params.RemoveAll()

        'fill parameters for CF tool, then load the points
        params.Add(pNALayer)
        params.Add("Incidents")
        params.Add(pDisplayTable)
        params.Add(loadString)
        gp.Execute("AddLocations_na", params, Nothing)

        'solve the network analyst CF problem
        Label2.Text = "solving Mode 1 closest facility analysis..."
        System.Windows.Forms.Application.DoEvents()
        fcaNAsetClosestsolver1(pNAContextCarCF, configObj)

        Try

            Dim gpMessagesCarCF As IGPMessages = New GPMessages
            Dim isPartial = pNAContextCarCF.Solver.Solve(pNAContextCarCF, gpMessagesCarCF, Nothing)  'Solve !!
            If isPartial Then
                lstOutput.Items.Add("Mode 1: Network Analyst reports that a partial CF solution was found")
            Else
                lstOutput.Items.Add("Mode 1: Network Analyst reports that a full CF solution was found")
            End If
            'display returned messages
            If Not gpMessagesCarCF Is Nothing Then
                For i As Integer = 0 To gpMessagesCarCF.Count - 1
                    Select Case gpMessagesCarCF.GetMessage(i).Type
                        Case esriGPMessageType.esriGPMessageTypeError
                            lstOutput.Items.Add("Error: " + gpMessagesCarCF.GetMessage(i).ErrorCode.ToString() + " " + gpMessagesCarCF.GetMessage(i).Description)
                        Case esriGPMessageType.esriGPMessageTypeWarning
                            lstOutput.Items.Add("Warning: " + gpMessagesCarCF.GetMessage(i).Description)
                        Case Else
                            lstOutput.Items.Add("Information: " + gpMessagesCarCF.GetMessage(i).Description)
                    End Select
                Next
            End If

        Catch ex As Exception
            lstOutput.Items.Add("")
            lstOutput.Items.Add("Network Analyst reports error message: ")
            lstOutput.Items.Add(ex.Message)
        End Try

        '############# OD solving ##############

        'track from layer -> to network layer -> to network dataset
        pLayer = pMap.Layer(configObj.NWlayerindexCar)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset
        'set NAContext as an OD matrix solver
        pNAContextCarOD = fcaNAcreateODsolver(pNWdataset)

        Label2.Text = "...loading Mode 1 OD matrix data"
        System.Windows.Forms.Application.DoEvents()

        'create and configure the Network Analyst layer
        pNALayer = pNAContextCarOD.Solver.CreateLayer(pNAContextCarOD)
        pLayer = pNALayer
        pLayer.Name = "m1FCA_" + pNAContextCarOD.Solver.DisplayName
        pMap.AddLayer(pLayer)
        pNALayer.Expanded = False
        pMap.MoveLayer(pLayer, pMap.LayerCount - 1) 'move it to the bottom of ToC

        'load the 'Origins' (ie supply points) from the selected Feature Layer

        pLayer = pMap.Layer(configObj.SupplyLayerIndexCar)
        pDisplayTable = pLayer
        loadString = fcaUtilities.getNALoadString(pDisplayTable)

        'clear previous parameters
        params.RemoveAll()

        'fill parameters for OD tool, then load the points
        params.Add(pNALayer)
        params.Add("Origins")
        params.Add(pDisplayTable)
        params.Add(loadString)
        gp.Execute("AddLocations_na", params, Nothing)

        'load the 'Destinations'  (ie demand points) from the selected Feature Layer

        pLayer = pMap.Layer(configObj.DemandLayerIndexCar)
        pDisplayTable = pLayer
        loadString = fcaUtilities.getNALoadString(pDisplayTable)

        'clear previous parameters
        params.RemoveAll()

        'fill parameters for OD tool, then load the points
        params.Add(pNALayer)
        params.Add("Destinations")
        params.Add(pDisplayTable)
        params.Add(loadString)
        gp.Execute("AddLocations_na", params, Nothing)

        'solve the network analyst OD Matrix problem
        Label2.Text = "solving Mode 1 OD matrix analysis..."
        System.Windows.Forms.Application.DoEvents()
        fcaNAsetODsolver1(pNAContextCarOD, configObj)

        Try

            Dim gpMessagesCarOD As IGPMessages = New GPMessages
            Dim isPartial As Boolean = pNAContextCarOD.Solver.Solve(pNAContextCarOD, gpMessagesCarOD, Nothing)
            If isPartial Then
                lstOutput.Items.Add("Mode 1: Network Analyst reports that a partial OD solution was found")
            Else
                lstOutput.Items.Add("Mode 1: Network Analyst reports that a full OD solution was found")
            End If
            'display returned messages
            If Not gpMessagesCarOD Is Nothing Then
                For i As Integer = 0 To gpMessagesCarOD.Count - 1
                    Select Case gpMessagesCarOD.GetMessage(i).Type
                        Case esriGPMessageType.esriGPMessageTypeError
                            lstOutput.Items.Add("Error: " + gpMessagesCarOD.GetMessage(i).ErrorCode.ToString() + " " + gpMessagesCarOD.GetMessage(i).Description)
                        Case esriGPMessageType.esriGPMessageTypeWarning
                            lstOutput.Items.Add("Warning: " + gpMessagesCarOD.GetMessage(i).Description)
                        Case Else
                            lstOutput.Items.Add("Information: " + gpMessagesCarOD.GetMessage(i).Description)
                    End Select
                Next
            End If

        Catch ex As Exception
            lstOutput.Items.Add("")
            lstOutput.Items.Add("Network Analyst error message: ")
            lstOutput.Items.Add(ex.Message)
        End Try

        '** compute accessibility scores **

        Dim pDataset As IDataset = Nothing
        Dim pOutputTable As ITable = Nothing
        Dim pTable As ITable = Nothing
        Dim pTableCollection As ITableCollection = Nothing

        'pointers for field construction
        Dim pFieldSetEdit As IFieldsEdit = New Fields
        Dim pNewField As IField
        Dim pNewFieldEdit As IFieldEdit2
        Dim pOldField As IField

        'track from feature layer -> to feature class -> to dataset 
        inputFL = pMap.Layer(configObj.DemandLayerIndexCar)
        inputFC = inputFL.FeatureClass
        pDataset = inputFC

        'construct a name for the physical (dbf) output file... 

        'find a name for the table
        Dim dbfName As String = configObj.Filename
        If configObj.Filename = "" Then
            Dim runNum As Integer = 0
            Dim tmp As decayType = configObj.filter
            Dim tmpNm As String = pDataset.BrowseName  'sets initial name as Demand Layer name
            tmpNm = tmpNm.Replace(" ", "")                      'remove spaces
            tmpNm = tmpNm.Substring(0, 8)                      'truncate to 8 characters
            tmpNm += "_" & tmp.ToString
            tmpNm += "_" & configObj.NWdefCutOffCar.ToString
            dbfName = tmpNm & "_" & runNum.ToString & ".dbf"
            Do Until Not My.Computer.FileSystem.FileExists(configObj.ResultsLocation & "\" & dbfName)
                runNum += 1        'if name is already used, keep increasing the version number
                dbfName = tmpNm & "_" & runNum.ToString & ".dbf"
            Loop
        End If

        Try
            'create fields required in the output table
            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "OID"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeOID
            pNewFieldEdit.Length_2 = 8
            pFieldSetEdit.AddField(pNewField)

            'get Extra ID field from the Demand points attribute table
            pDisplayTable = inputFL
            pTable = pDisplayTable.DisplayTable
            pOldField = pTable.Fields.Field(configObj.DemandExtraField)
            'copy across the Extra ID field specifications
            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = pOldField.Name
            If pOldField.Type = esriFieldType.esriFieldTypeOID Then
                pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger
            Else
                pNewFieldEdit.Type_2 = pOldField.Type
            End If
            pNewFieldEdit.Length_2 = pOldField.Length
            pNewFieldEdit.Scale_2 = pOldField.Scale
            pNewFieldEdit.Precision_2 = pOldField.Precision
            pNewFieldEdit.AliasName_2 = pOldField.AliasName
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "DemandID"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger
            pNewFieldEdit.Length_2 = 8
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "m1_SupID"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger
            pNewFieldEdit.Length_2 = 8
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "m1_Dist"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewFieldEdit.Length_2 = 14
            pNewFieldEdit.DefaultValue_2 = 0.0
            pNewFieldEdit.Precision_2 = 12
            pNewFieldEdit.Scale_2 = 4
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "m1_Choice"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewFieldEdit.Length_2 = 14
            pNewFieldEdit.DefaultValue_2 = 0.0
            pNewFieldEdit.Precision_2 = 12
            pNewFieldEdit.Scale_2 = 0
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "m1_AveD"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewFieldEdit.Length_2 = 14
            pNewFieldEdit.DefaultValue_2 = 0.0
            pNewFieldEdit.Precision_2 = 12
            pNewFieldEdit.Scale_2 = 4
            pFieldSetEdit.AddField(pNewField)

            pNewField = New Field
            pNewFieldEdit = pNewField
            pNewFieldEdit.Name_2 = "m1_mmfca"
            pNewFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle
            pNewFieldEdit.Length_2 = 14
            pNewFieldEdit.DefaultValue_2 = 0.0
            pNewFieldEdit.Precision_2 = 12
            pNewFieldEdit.Scale_2 = 8
            pFieldSetEdit.AddField(pNewField)

            'create a shapefile workspace factory in the user selected folder
            Dim pWSFactory As IWorkspaceFactory = New ShapefileWorkspaceFactory
            Dim pFWS As IFeatureWorkspace = pWSFactory.OpenFromFile(configObj.ResultsLocation, My.ArcMap.Application.hWnd)
            pOutputTable = pFWS.CreateTable(dbfName, pFieldSetEdit, Nothing, Nothing, "")   'create output (dbf) file

            pTableCollection = pMap                          'create pointer to tables collection
            pTableCollection.AddTable(pOutputTable) ' add table to current map
            pMxDoc.UpdateContents()

        Catch ex As Exception
            lstOutput.Items.Add("Error: Unable to create result table " & dbfName)
            lstOutput.Items.Add(ex.Message)
            Exit Sub

        End Try

        '#### Extract the Closest ID and Distance metricss ####'
        Label2.Text = "computing closest facility metrics"
        System.Windows.Forms.Application.DoEvents()

        'used to store index position of Incident, Facility, Impedance and Name fields
        Dim idxCARincident, idxCARfacility, idxCARimpedance, idxCARname As Integer
        Dim impedanceCAR As String = "Total_" & configObj.NWimpedanceCar
        'used to manipulate the Name field value
        Dim nameStr, numbers() As String

        'create dictionaries for associated supplyIDs and network distances
        Dim supplyIDsCAR As New Dictionary(Of Integer, String)
        Dim distancesCAR As New Dictionary(Of Integer, Double)

        'connect to CAR CF results table
        Dim pCFtable As ITable = pNAContextCarCF.NAClasses.ItemByName("CFRoutes")
        If pCFtable Is Nothing Then
            lstOutput.Items.Add("Error: Unable to access the CF Routes table")
            Exit Sub
        End If
        'create a cursor to access this table
        Dim pCFCursor As ICursor = pCFtable.Search(Nothing, True)
        Dim pCFRow As IRow = pCFCursor.NextRow

        'get index positions of the fields of interest
        If Not pCFRow Is Nothing Then
            idxCARincident = pCFRow.Fields.FindField("IncidentID")
            idxCARfacility = pCFRow.Fields.FindField("FacilityID")
            idxCARname = pCFRow.Fields.FindField("Name")
            idxCARimpedance = pCFRow.Fields.FindField(impedanceCAR)
        End If

        'loop through each row
        Do Until pCFRow Is Nothing

            'swap Incident ID and FacilityID values to maintain proper data matching continuity...
            nameStr = pCFRow.Value(idxCARname)             'access the Name value
            numbers = nameStr.Split("-")                             'split two IDs apart
            pCFRow.Value(idxCARincident) = numbers(0)      'replace IncidentID with demand point OID
            pCFRow.Value(idxCARfacility) = numbers(1)        'replace FacilityID with supply point OID 
            pCFRow.Store()                                                 'write values back to table

            'record Supply ID for each Demand ID in the dictionary
            supplyIDsCAR.Add(numbers(0), numbers(1))
            'record Distance for each DemandID in the dictionary
            distancesCAR.Add(numbers(0), pCFRow.Value(idxCARimpedance))

            pCFRow = pCFCursor.NextRow
        Loop

        'traverse Demand layer table, copying results into the output table
        Dim pFcursor As IFeatureCursor = inputFC.Search(Nothing, True)
        Dim pFeature As IFeature = pFcursor.NextFeature()

        Dim pResultRow As IRowBuffer = pOutputTable.CreateRowBuffer
        Dim pInCursor As ICursor = pOutputTable.Insert(True)

        Try

            Do Until pFeature Is Nothing

                pResultRow.Value(1) = pFeature.Value(configObj.DemandExtraField) 'copy ExtraID value
                pResultRow.Value(2) = pFeature.OID                                               'copy demand point OID

                If supplyIDsCAR.ContainsKey(pFeature.OID) Then
                    'YES: a supply point was found during CAR CF analysis
                    pResultRow.Value(3) = supplyIDsCAR.Item(pFeature.OID)             'copy supply point OID
                    pResultRow.Value(4) = distancesCAR.Item(pFeature.OID)              'copy supply point distance
                Else
                    'NO: enter values that indicate no supply point found
                    pResultRow.Value(3) = -1
                    pResultRow.Value(4) = -1
                End If

                pInCursor.InsertRow(pResultRow)
                pFeature = pFcursor.NextFeature()
            Loop
            pInCursor.Flush()

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

        'release resources
        If Not pCFCursor Is Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pCFCursor)
        End If
        If Not pFcursor Is Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pFcursor)
        End If
        If Not pInCursor Is Nothing Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pInCursor)
        End If
        supplyIDsCAR = Nothing
        distancesCAR = Nothing

        '#### FCA Step1 compute demand totals on each supply point ####'

        Label2.Text = "computing FCA step 1...'"
        System.Windows.Forms.Application.DoEvents()

        Dim pCursor As ICursor
        Dim pRow As IRow

        'create a dictionary of all demand point volumes
        Dim lookup1 As New Dictionary(Of Integer, Double)

        inputFL = pMap.Layer(configObj.DemandLayerIndexCar)
        pDisplayTable = inputFL
        pTable = pDisplayTable.DisplayTable
        pCursor = pTable.Search(Nothing, False)
        pRow = pCursor.NextRow
        Do Until pRow Is Nothing
            lookup1.Add(pRow.OID, Convert.ToDouble(pRow.Value(configObj.DemandVolumeFieldCar)))
            pRow = pCursor.NextRow
        Loop

        'connect to the OD-matrix results table
        Dim pODcarTable As ITable = pNAContextCarOD.NAClasses.ItemByName("ODLines")
        If pODcarTable Is Nothing Then
            lstOutput.Items.Add("Error: unable to access the OD table")
            Exit Sub
        End If
        'create a cursor to access this table
        pCursor = pODcarTable.Search(Nothing, True)
        pRow = pCursor.NextRow

        Dim supplyID, demandID As Integer
        Dim demandValue, ntwkDist As Double

        'dictionary for step 1 (total demand volume for each supply point)
        Dim demandCarTotals As New Dictionary(Of Integer, Double)

        'get index positions of the fields of interest
        Dim idxOriginID, idxDestinationID As Integer
        If Not pRow Is Nothing Then
            idxOriginID = pRow.Fields.FindField("OriginID")
            idxDestinationID = pRow.Fields.FindField("DestinationID")
            idxCARname = pRow.Fields.FindField("Name")
            idxCARimpedance = pRow.Fields.FindField("Total_" & configObj.NWimpedanceCar)
        End If

        Try

            'loop through each row of the OD table   
            Do Until pRow Is Nothing

                'swap OriginID and DestinationID values to maintain proper data matching continuity...
                nameStr = pRow.Value(idxCARname)             'access the Name value
                numbers = nameStr.Split("-")                         'split two IDS apart
                supplyID = numbers(0)
                demandID = numbers(1)
                pRow.Value(idxOriginID) = supplyID              'replace OriginID with supply point OID
                pRow.Value(idxDestinationID) = demandID    'replace DestinationID with demand point OID 
                pRow.Store()                                                 'write values back to OD table

                ntwkDist = pRow.Value(idxCARimpedance)

                'use demand ID to lookup the demand value, and scale it
                lookup1.TryGetValue(demandID, demandValue)
                demandValue = dist_weighted1(demandValue, ntwkDist, configObj)

                'check if this supply point exists in the dictionary
                If demandCarTotals.ContainsKey(supplyID) Then
                    'YES: add current demand volume to current total
                    demandCarTotals.Item(supplyID) += demandValue
                Else
                    'NO: add a new dictionary entry with intial volume
                    demandCarTotals.Add(supplyID, demandValue)
                End If

                pRow = pCursor.NextRow
            Loop

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try

    
        '#### FCA Step2 compute supply totals on each demand point ####'

        Label2.Text = "computing FCA step 2...'"
        System.Windows.Forms.Application.DoEvents()

        'create a dictionary of all CAR supply point volumes
        Dim lookup3 As New Dictionary(Of Integer, Double)

        If configObj.SupplyVolumeFieldCar <> -1 Then
            inputFL = pMap.Layer(configObj.SupplyLayerIndexCar)
            pDisplayTable = inputFL
            pTable = pDisplayTable.DisplayTable
            pCursor = pTable.Search(Nothing, False)
            pRow = pCursor.NextRow
            Do Until pRow Is Nothing
                lookup3.Add(pRow.OID, Convert.ToDouble(pRow.Value(configObj.SupplyVolumeFieldCar)))
                pRow = pCursor.NextRow
            Loop
        End If

        'connect to the OD-matrix results table
        pODcarTable = pNAContextCarOD.NAClasses.ItemByName("ODLines")
        'create a cursor to access this table
        pCursor = pODcarTable.Search(Nothing, True)
        pRow = pCursor.NextRow

        Dim supplyValue, availabilityScore As Double

        'dictionary for step 2 (total step1 scores for each demand point)
        Dim supplyCarTotals As New Dictionary(Of Integer, destObj)

        'get index positions of the fields of interest
        If Not pRow Is Nothing Then
            idxOriginID = pRow.Fields.FindField("OriginID")
            idxDestinationID = pRow.Fields.FindField("DestinationID")
            idxCARname = pRow.Fields.FindField("Name")
            idxCARimpedance = pRow.Fields.FindField("Total_" & configObj.NWimpedanceCar)
        End If

        Try

            'loop through each row of the OD table   
            Do Until pRow Is Nothing

                'extract supply and demand OIDs, and the network distance between them
                nameStr = pRow.Value(idxCARname)
                numbers = nameStr.Split("-")
                supplyID = numbers(0)
                demandID = numbers(1)

                ntwkDist = pRow.Value(idxCARimpedance)

                'use supply ID to lookup the supply value, and scale it
                If configObj.SupplyVolumeFieldCar <> -1 Then
                    lookup3.TryGetValue(supplyID, supplyValue)
                Else
                    supplyValue = 1
                End If

                availabilityScore = supplyValue * configObj.NWscale / demandCarTotals(supplyID)
                availabilityScore = dist_weighted1(availabilityScore, ntwkDist, configObj)

                'check if this demand point already exists in the dictionary
                If supplyCarTotals.ContainsKey(demandID) Then
                    'YES: update supply volume to current totals
                    supplyCarTotals.Item(demandID).count += 1.0                          'total supply points
                    supplyCarTotals.Item(demandID).sumdist += ntwkDist               'total supply distance
                    supplyCarTotals.Item(demandID).twostep += availabilityScore     'total step1 scores
                Else
                    'NO: add a new dictionary entry using these values
                    Dim newObj As New destObj
                    newObj.count = 1.0
                    newObj.sumdist = ntwkDist
                    newObj.twostep = availabilityScore
                    supplyCarTotals.Add(demandID, newObj)
                End If

                pRow = pCursor.NextRow()
            Loop

            'release resources
            If Not pCursor Is Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pCursor)
            End If
            lookup1 = Nothing
            lookup3 = Nothing

        Catch ex As Exception
            Windows.Forms.MessageBox.Show(ex.Message)
        End Try


        'record accessibility metrics in results table
        Label2.Text = "...writing results to output table"
        System.Windows.Forms.Application.DoEvents()

        'Create an update cursor on the results table
        pCursor = pOutputTable.Update(Nothing, True)
        Dim pOTrow As IRow = pCursor.NextRow()

        'loop through each row, and update metric values
        Do Until pOTrow Is Nothing
            demandID = pOTrow.Value(2)
            If supplyCarTotals.ContainsKey(demandID) Then
                pOTrow.Value(5) = supplyCarTotals.Item(demandID).count
                pOTrow.Value(6) = supplyCarTotals.Item(demandID).sumdist / supplyCarTotals.Item(demandID).count
                pOTrow.Value(7) = supplyCarTotals.Item(demandID).twostep
            End If
            pCursor.UpdateRow(pOTrow)
            pOTrow = pCursor.NextRow()
        Loop

        Label2.Text = "FCA computation finished" & Environment.NewLine _
                                  & "results stored in dbf file..." & Environment.NewLine _
                                  & dbfName + Environment.NewLine

        System.Runtime.InteropServices.Marshal.ReleaseComObject(pOutputTable)

        pMxDoc.CurrentContentsView = pMxDoc.ContentsView(1)
        chkTidyUp.Visible = True
        btnClose.Enabled = True

    End Sub

#End Region

#Region "remove the working layers"

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click

        If chkTidyUp.Checked Then
            Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
            Dim pMap As IMap = pMxDoc.FocusMap
            Dim pLayer As INALayer = Nothing
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
            pLayer = pMap.Layer(pMap.LayerCount - 1)
            If Not pLayer Is Nothing Then
                pMap.DeleteLayer(pLayer)
            End If
        End If

        Me.Dispose()

    End Sub

#End Region

End Class