Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geodatabase
Imports System.Windows.Forms

Public Class s1_frmNetworkLayers

#Region "globals"

    'list of Network Dataset names/index positions
    Dim m_NWlayers As ArrayList

    'list of units for 'Cost' type attributes in the chosen network dataset
    Dim m_costFieldUnitsCar As ArrayList = New ArrayList
    Dim m_costFieldUnitsBus As ArrayList = New ArrayList

#End Region

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

    Private Sub btn1Next_Click(sender As System.Object, e As System.EventArgs) Handles btn1Next.Click

        Dim list_item As layerItem

        'store NW dataset layer indices and details of the impedance/cost fields in configObj
        list_item = m_NWlayers(cboNWdatasetCar.SelectedIndex)
        configObj.NWlayerindexCar = list_item.position
        configObj.NWimpedanceCar = cboCostFieldCar.Text


        'store FCA threshold sizes in configObj
        Try
            configObj.NWdefCutOffCar = Convert.ToDouble(fcaSizeCar.Text)
        Catch ex As Exception
            MessageBox.Show("Unable to read an FCA dimension setting as a valid numeric input" & Environment.NewLine _
                                            & ex.Message, "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        'store FCA scaling factor in configObj
        Try
            configObj.NWscale = Convert.ToDouble(cbofcaScale.Text)
        Catch ex As Exception
            MessageBox.Show("*ERROR* in scaling factor")
            Return
        End Try

        'display next form
        Dim p_s2frmDemandDetails As New s2_frmSupplyDetails(configObj)
        p_s2frmDemandDetails.Location = Me.Location
        p_s2frmDemandDetails.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "formLoad configuration"

    Private Sub s1_frmNetworkLayer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'get la ist of all NetWork Dataset names and index positions
        m_NWlayers = fcaUtilities.getNWLayers()

        'issue warning if no Network Data layer available
        If m_NWlayers.Count < 2 Then
            MessageBox.Show("**Error** - Must have a Network Datasets present to use this tool", "**ERROR**", _
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboNWdatasetCar.SelectedIndex = -1
            btn1Next.Enabled = False
            Return
        End If

        'populate dropdowns with Network Dataset names
        For Each NWlayer As layerItem In m_NWlayers
            cboNWdatasetCar.Items.Add(NWlayer.title)
        Next
        cboNWdatasetCar.SelectedIndex = 0
        grpImpedance.Enabled = True
        btn1Next.Enabled = True

    End Sub

#End Region

#Region "display list of Cost fields for a selected NW layer"

    Private Sub cboNWdatasetCar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) _
        Handles cboNWdatasetCar.SelectedIndexChanged

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDoc.FocusMap

        Dim pLayer As ILayer = Nothing
        Dim pNWLayer As INetworkLayer = Nothing
        Dim pNWdataset As INetworkDataset = Nothing
        Dim pNWattribute As INetworkAttribute = Nothing
        Dim selectedNWlayer As layerItem = Nothing

        'store the layer index position for the selected CAR network layer
        selectedNWlayer = m_NWlayers(cboNWdatasetCar.SelectedIndex)
        configObj.NWlayerindexCar = selectedNWlayer.position

        'track from layer -> to network layer -> to network dataset
        pLayer = pMap.Layer(configObj.NWlayerindexCar)
        pNWLayer = pLayer
        pNWdataset = pNWLayer.NetworkDataset

        'get Cost attribute fields for the CAR network, and display in drop-down-list
        'also store a parallel list of the cost attribute units in m_costFieldUnitsCar
        cboCostFieldCar.Items.Clear()
        m_costFieldUnitsCar.Clear()
        Try
            For i As Integer = 0 To pNWdataset.AttributeCount - 1
                pNWattribute = pNWdataset.Attribute(i)
                If pNWattribute.UsageType = esriNetworkAttributeUsageType.esriNAUTCost Then
                    cboCostFieldCar.Items.Add(pNWattribute.Name)
                    m_costFieldUnitsCar.Add(pNWattribute.Units.ToString)
                End If
            Next
            If pNWdataset.AttributeCount > 0 Then
                'set the initial Cost field as the first listed item
                cboCostFieldCar.SelectedIndex = 0
                lblCarUnits.Visible = True
                grpFCAdimensions.Enabled = True
            Else
                'or if no cost field present, issue a warning message and prevent any further progress
                MessageBox.Show("**Error** - no Cost field in selected Mode 1 Network Dataset", _
                                                "**ERROR**", MessageBoxButtons.OK, MessageBoxIcon.Error)
                btn1Next.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Codeblock1 Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'display CAR cost field units
    Private Sub cboCostFieldCar_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) _
        Handles cboCostFieldCar.SelectedIndexChanged

        Dim str() As String = Split(m_costFieldUnitsCar(cboCostFieldCar.SelectedIndex), "esriNAU")
        lblCarUnits.Text = str(1)

    End Sub

#End Region


End Class