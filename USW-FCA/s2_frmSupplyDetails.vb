Imports System.Windows.Forms
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase

Public Class s2_frmSupplyDetails

#Region "formControl"

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

    Private Sub btn2Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn2Prev.Click

        'reset supply details to thier initial defaults
        configObj.SupplyLayerIndexCar = -1
        configObj.SupplyVolumeFieldCar = -1

        'redisplay the previous form
        Dim p_s1frmNetworkLayer As New s1_frmNetworkLayers(configObj)
        p_s1frmNetworkLayer.Location = Me.Location
        p_s1frmNetworkLayer.Show()
        Me.Dispose()

    End Sub

    Private Sub btn2Next_Click(sender As System.Object, e As System.EventArgs) Handles btn2Next.Click

        Dim list_item As layerItem

        'store the supply points layer's map index in the configObj
        list_item = m_Pointlayers1(cboSupplyPointsLayerCar.SelectedIndex)
        configObj.SupplyLayerIndexCar = list_item.position

        'store the supply volume field index in the configObj
        If chkSupplyFieldCar.Checked Then
            list_item = m_Fieldlist(cboSupplyVolumeFieldCar.SelectedIndex)
            configObj.SupplyVolumeFieldCar = list_item.position
        Else
            configObj.SupplyVolumeFieldCar = -1
        End If

        'store the demand points layer's map index in the configObj
        list_item = m_Pointlayers2(cboDemandPointsLayerCar.SelectedIndex)
        configObj.DemandLayerIndexCar = list_item.position

        'store the demand volume field index in the configObj
        list_item = m_fieldlistCar(cboDemandFieldCar.SelectedIndex)
        configObj.DemandVolumeFieldCar = list_item.position

        'store the demand layer Extra Field index in the configObj
        configObj.DemandExtraField = cboDemandIDField.SelectedIndex

        'display the next form
        Dim p_s4frmDemandDetails As New s4_frmParameters(configObj)
        p_s4frmDemandDetails.Location = Me.Location
        p_s4frmDemandDetails.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "globals"

    'List of point-data layer names and their layer index positions
    Dim m_Pointlayers1 As List(Of layerItem)
    Dim m_Pointlayers2 As List(Of layerItem)

    'List of field names that could be used as a supply volume
    Dim m_Fieldlist As List(Of layerItem)

    'List of field names that could be used as a demand volume
    Dim m_fieldlistCar As List(Of layerItem)
    Dim m_fieldlistXID As List(Of layerItem)

    'Flag to prevent the field names warning on initial form load
    Dim first As Boolean = True
    Dim firstCar As Boolean = True

#End Region

#Region "formLoad configuration"

    Private Sub s2_frmSupplyDetails_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get a list of all point layers in the current map
        m_Pointlayers1 = fcaUtilities.getPointlayers(-1)

        If m_Pointlayers1.Count > 0 Then
            'populate the layer selection dropdowns with this list
            For Each list_item As layerItem In m_Pointlayers1
                cboSupplyPointsLayerCar.Items.Add(list_item.title)
            Next
            'set selected items as the first item
            cboSupplyPointsLayerCar.SelectedIndex = 0
            btn2Next.Enabled = True
        Else
            'if no point data layers were present, issue a warning message
            MessageBox.Show("**Error** - there are no map layers containing point objects", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn2Next.Enabled = False
        End If

        'get a list of point layers in the current map (excluding the supply points)
        m_Pointlayers2 = fcaUtilities.getPointlayers(configObj.SupplyLayerIndexCar)

        If m_Pointlayers2.Count > 0 Then
            'populate the layer selection dropdowns with this list
            For Each list_item As layerItem In m_Pointlayers2
                cboDemandPointsLayerCar.Items.Add(list_item.title)
            Next
            'set selected item as the first item
            cboDemandPointsLayerCar.SelectedIndex = 0
            btn2Next.Enabled = True
        Else
            'if no point data layers were present, issue a warning message
            MessageBox.Show("**Error** - there are no further map layers containing point objects", _
                                            "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btn2Next.Enabled = False

        End If

    End Sub

#End Region

#Region "user selects supply points layer"

    Private Sub cboSupplyPointsLayerCar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) _
        Handles cboSupplyPointsLayerCar.SelectedIndexChanged

        'set supply volume option to off
        chkSupplyFieldCar.Checked = False

    End Sub

#End Region

#Region "a supply volume field is requested"

    Private Sub chkSupplyFieldCar_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSupplyFieldCar.CheckedChanged

        If chkSupplyFieldCar.Checked Then

            'get list of field names in the supply point layer that might be a supply volume
            Dim layer_item As layerItem = m_Pointlayers1(cboSupplyPointsLayerCar.SelectedIndex)
            m_Fieldlist = fcaUtilities.getDatafields2(layer_item.position)

            If m_Fieldlist.Count > 0 Then
                'populate the dropdown with the field names
                cboSupplyVolumeFieldCar.Items.Clear()
                For Each field_item As layerItem In m_Fieldlist
                    cboSupplyVolumeFieldCar.Items.Add(field_item.title)
                Next
                'set the field selection initially to the first item
                cboSupplyVolumeFieldCar.SelectedIndex = 0
            Else
                'if no suitable fields are available, issue a warning message
                chkSupplyFieldCar.Checked = False
                If Not first Then
                    MessageBox.Show("Selected supply layer has no numeric fields" & Environment.NewLine _
                                                             & "     but one is needed for the supply volume information", _
                                                                 "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                first = False
            End If

        Else
            'if deactivated, clear the dropdown list of field names
            cboSupplyVolumeFieldCar.Items.Clear()
            cboSupplyVolumeFieldCar.ResetText()
            cboSupplyVolumeFieldCar.SelectedIndex = -1
        End If

        'activate/deactive the on-screen controls in response to user selection
        cboSupplyVolumeFieldCar.Enabled = chkSupplyFieldCar.Checked

    End Sub

#End Region

    Private Sub cboDemandPointsLayerCar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) _
        Handles cboDemandPointsLayerCar.SelectedIndexChanged

        'get list of field names in the demand point layer that might be a demand volume
        Dim layer_item As layerItem = m_Pointlayers2(cboDemandPointsLayerCar.SelectedIndex)
        m_fieldlistCar = fcaUtilities.getDatafields2(layer_item.position)

        If m_fieldlistCar.Count > 0 Then
            'populate the dropdown with the field names
            cboDemandFieldCar.Items.Clear()
            For Each field_item As layerItem In m_fieldlistCar
                cboDemandFieldCar.Items.Add(field_item.title)
            Next
            'set the field selection initially to the first item
            cboDemandFieldCar.SelectedIndex = 0
            btn2Next.Enabled = True
        Else
            'if no suitable fields are available, issue a warning message
            If Not firstCar Then
                MessageBox.Show("Selected demand layer has no numeric fields" & Environment.NewLine _
                                               & "     but one is needed for the demand volume information", _
                                                   "**Information**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btn2Next.Enabled = False
            End If
            firstCar = False
        End If

        'get list of all field names in the demand point layer 
        m_fieldlistXID = fcaUtilities.getDatafields3(layer_item.position)

        If m_fieldlistXID.Count > 0 Then
            'populate the dropdown with the field names
            cboDemandIDField.Items.Clear()
            For Each field_item As layerItem In m_fieldlistXID
                cboDemandIDField.Items.Add(field_item.title)
            Next
            'set the field selection initially to the first item
            cboDemandIDField.SelectedIndex = 0
        End If

    End Sub
End Class