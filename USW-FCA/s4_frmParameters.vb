Public Class s4_frmParameters

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

    Private Sub btn4_Prev_Click(sender As System.Object, e As System.EventArgs) Handles btn4_Prev.Click

        'redisplay the previous form
        Dim p_s2frmSupplyDetails As New s2_frmSupplyDetails(configObj)
        p_s2frmSupplyDetails.Location = Me.Location
        p_s2frmSupplyDetails.Show()
        Me.Dispose()

    End Sub

    Private Sub btn4Next_Click(sender As System.Object, e As System.EventArgs) Handles btn4Next.Click

        'store FCA options in the configObj
        configObj.gaussian_bw = Convert.ToDouble(numUpDown1.Value)
        configObj.butterworth_bw = Convert.ToDouble(numUpDown3.Value)
        configObj.butterworth_pwr = Convert.ToDouble(numUpDown2.Value)
        configObj.ResultsLocation = txtResultsPath.Text

        If radSpecify.Checked Then
            configObj.Filename = txtFilename.Text & ".dbf"
        Else
            configObj.Filename = ""
        End If

        'display the next form
        Dim p_s5frmParameters As New s5_frmResults(configObj)
        p_s5frmParameters.Location = Me.Location
        p_s5frmParameters.Show()
        Me.Dispose()

    End Sub

#End Region

#Region "form load configuration"

    Private Sub s4_frmParameters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'display the MyDocuments folder as the initial output location
        txtResultsPath.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments

    End Sub

#End Region

#Region "select output folder"

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click

        'select a new folder location for the results table using a FolderBrowser dialog
        FolderBrowserDialog1.SelectedPath = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtResultsPath.Text = FolderBrowserDialog1.SelectedPath
        End If

    End Sub

#End Region

#Region "user selects FCA type"

    Private Sub optClassic_CheckedChanged(sender As System.Object, e As System.EventArgs) _
        Handles optClassic.CheckedChanged, optLinear.CheckedChanged, optGaussian.CheckedChanged, optButterworth.CheckedChanged

        pnlGauss.Enabled = False
        pnlButt.Enabled = False

        'display the appropriate diagram and store the selection in the configObj
        If optClassic.Checked Then
            pbDecayType.Image = My.Resources.Fig_None
            configObj.filter = decayType.Classic
        ElseIf optLinear.Checked Then
            pbDecayType.Image = My.Resources.Fig_Linear
            configObj.filter = decayType.Linear
        ElseIf optGaussian.Checked Then
            pbDecayType.Image = My.Resources.Fig_Gaussian
            configObj.filter = decayType.Gaussian
            pnlGauss.Enabled = True
        Else
            pbDecayType.Image = My.Resources.Fig_Butterworth
            configObj.filter = decayType.Butterworth
            pnlButt.Enabled = True
        End If

    End Sub

#End Region

#Region "user sets output filename"

    Private Sub radAuto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles radAuto.CheckedChanged
        If radSpecify.Checked Then
            txtFilename.Enabled = True
            radSpecify.ForeColor = Drawing.Color.FromArgb(0, 0, 0)
            radAuto.ForeColor = Drawing.Color.FromArgb(100, 100, 100)
        Else
            txtFilename.Enabled = False
            radSpecify.ForeColor = Drawing.Color.FromArgb(100, 100, 100)
            radAuto.ForeColor = Drawing.Color.FromArgb(0, 0, 0)
        End If

    End Sub

#End Region

End Class