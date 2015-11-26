<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s1_frmNetworkLayers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(s1_frmNetworkLayers))
        Me.grpNetworklayer = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cboNWdatasetCar = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.fcaSizeCar = New System.Windows.Forms.TextBox()
        Me.lblCarUnits = New System.Windows.Forms.Label()
        Me.cboCostFieldCar = New System.Windows.Forms.ComboBox()
        Me.grpFCAdimensions = New System.Windows.Forms.GroupBox()
        Me.cbofcaScale = New System.Windows.Forms.ComboBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.grpImpedance = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn1Next = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.grpNetworklayer.SuspendLayout()
        Me.grpFCAdimensions.SuspendLayout()
        Me.grpImpedance.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpNetworklayer
        '
        Me.grpNetworklayer.Controls.Add(Me.TextBox1)
        Me.grpNetworklayer.Controls.Add(Me.cboNWdatasetCar)
        Me.grpNetworklayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNetworklayer.Location = New System.Drawing.Point(11, 196)
        Me.grpNetworklayer.Margin = New System.Windows.Forms.Padding(4)
        Me.grpNetworklayer.Name = "grpNetworklayer"
        Me.grpNetworklayer.Padding = New System.Windows.Forms.Padding(4)
        Me.grpNetworklayer.Size = New System.Drawing.Size(1087, 100)
        Me.grpNetworklayer.TabIndex = 26
        Me.grpNetworklayer.TabStop = False
        Me.grpNetworklayer.Text = "Select the Network Dataset layer to be used"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(8, 44)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(385, 29)
        Me.TextBox1.TabIndex = 18
        Me.TextBox1.Text = "Network dataset"
        '
        'cboNWdatasetCar
        '
        Me.cboNWdatasetCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNWdatasetCar.FormattingEnabled = True
        Me.cboNWdatasetCar.Location = New System.Drawing.Point(433, 44)
        Me.cboNWdatasetCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboNWdatasetCar.Name = "cboNWdatasetCar"
        Me.cboNWdatasetCar.Size = New System.Drawing.Size(428, 33)
        Me.cboNWdatasetCar.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Berlin Sans FB", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(358, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(467, 82)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Enhanced Two-Step Floating" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Catchment Area Scores "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(12, 49)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(385, 29)
        Me.TextBox5.TabIndex = 21
        Me.TextBox5.Text = "Floating catchment area threshold size"
        '
        'fcaSizeCar
        '
        Me.fcaSizeCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fcaSizeCar.Location = New System.Drawing.Point(437, 49)
        Me.fcaSizeCar.Margin = New System.Windows.Forms.Padding(4)
        Me.fcaSizeCar.Name = "fcaSizeCar"
        Me.fcaSizeCar.Size = New System.Drawing.Size(208, 30)
        Me.fcaSizeCar.TabIndex = 4
        Me.fcaSizeCar.Text = "5000"
        Me.fcaSizeCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCarUnits
        '
        Me.lblCarUnits.AutoSize = True
        Me.lblCarUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarUnits.Location = New System.Drawing.Point(657, 57)
        Me.lblCarUnits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCarUnits.Name = "lblCarUnits"
        Me.lblCarUnits.Size = New System.Drawing.Size(45, 20)
        Me.lblCarUnits.TabIndex = 22
        Me.lblCarUnits.Text = "units"
        Me.lblCarUnits.Visible = False
        '
        'cboCostFieldCar
        '
        Me.cboCostFieldCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCostFieldCar.FormattingEnabled = True
        Me.cboCostFieldCar.Location = New System.Drawing.Point(437, 42)
        Me.cboCostFieldCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCostFieldCar.Name = "cboCostFieldCar"
        Me.cboCostFieldCar.Size = New System.Drawing.Size(428, 33)
        Me.cboCostFieldCar.TabIndex = 22
        '
        'grpFCAdimensions
        '
        Me.grpFCAdimensions.Controls.Add(Me.cbofcaScale)
        Me.grpFCAdimensions.Controls.Add(Me.TextBox7)
        Me.grpFCAdimensions.Controls.Add(Me.lblCarUnits)
        Me.grpFCAdimensions.Controls.Add(Me.TextBox5)
        Me.grpFCAdimensions.Controls.Add(Me.fcaSizeCar)
        Me.grpFCAdimensions.Enabled = False
        Me.grpFCAdimensions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFCAdimensions.Location = New System.Drawing.Point(7, 422)
        Me.grpFCAdimensions.Margin = New System.Windows.Forms.Padding(4)
        Me.grpFCAdimensions.Name = "grpFCAdimensions"
        Me.grpFCAdimensions.Padding = New System.Windows.Forms.Padding(4)
        Me.grpFCAdimensions.Size = New System.Drawing.Size(1091, 123)
        Me.grpFCAdimensions.TabIndex = 28
        Me.grpFCAdimensions.TabStop = False
        Me.grpFCAdimensions.Text = "Specify the FCA catchment size, and set the FCA scores scaling factor"
        '
        'cbofcaScale
        '
        Me.cbofcaScale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofcaScale.FormattingEnabled = True
        Me.cbofcaScale.Items.AddRange(New Object() {"1", "10", "100", "1000", "10000"})
        Me.cbofcaScale.Location = New System.Drawing.Point(737, 49)
        Me.cbofcaScale.Margin = New System.Windows.Forms.Padding(4)
        Me.cbofcaScale.Name = "cbofcaScale"
        Me.cbofcaScale.Size = New System.Drawing.Size(75, 33)
        Me.cbofcaScale.TabIndex = 34
        Me.cbofcaScale.Text = "1"
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(820, 49)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(249, 53)
        Me.TextBox7.TabIndex = 33
        Me.TextBox7.Text = "scale multiplier for FCA scores" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(used to preserve precision)"
        '
        'grpImpedance
        '
        Me.grpImpedance.Controls.Add(Me.cboCostFieldCar)
        Me.grpImpedance.Controls.Add(Me.TextBox3)
        Me.grpImpedance.Enabled = False
        Me.grpImpedance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpImpedance.Location = New System.Drawing.Point(7, 305)
        Me.grpImpedance.Margin = New System.Windows.Forms.Padding(4)
        Me.grpImpedance.Name = "grpImpedance"
        Me.grpImpedance.Padding = New System.Windows.Forms.Padding(4)
        Me.grpImpedance.Size = New System.Drawing.Size(1091, 98)
        Me.grpImpedance.TabIndex = 29
        Me.grpImpedance.TabStop = False
        Me.grpImpedance.Text = "Specify the cost field for this Network Dataset layer"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(12, 42)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(7, 4, 4, 4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(385, 29)
        Me.TextBox3.TabIndex = 21
        Me.TextBox3.Text = "Network travel cost (impedance) field"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 609)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Version 15/11/15"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(880, 10)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(210, 210)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'btn1Next
        '
        Me.btn1Next.ForeColor = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btn1Next.Image = Global.USW_FCA.My.Resources.Resources.nextB
        Me.btn1Next.Location = New System.Drawing.Point(1028, 585)
        Me.btn1Next.Margin = New System.Windows.Forms.Padding(4)
        Me.btn1Next.Name = "btn1Next"
        Me.btn1Next.Size = New System.Drawing.Size(69, 64)
        Me.btn1Next.TabIndex = 27
        Me.btn1Next.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(19, 7)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(325, 102)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 34
        Me.PictureBox2.TabStop = False
        '
        's1_frmNetworkLayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1104, 662)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grpNetworklayer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn1Next)
        Me.Controls.Add(Me.grpFCAdimensions)
        Me.Controls.Add(Me.grpImpedance)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "s1_frmNetworkLayers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Network Details"
        Me.TopMost = True
        Me.grpNetworklayer.ResumeLayout(False)
        Me.grpNetworklayer.PerformLayout()
        Me.grpFCAdimensions.ResumeLayout(False)
        Me.grpFCAdimensions.PerformLayout()
        Me.grpImpedance.ResumeLayout(False)
        Me.grpImpedance.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpNetworklayer As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cboNWdatasetCar As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents fcaSizeCar As System.Windows.Forms.TextBox
    Friend WithEvents btn1Next As System.Windows.Forms.Button
    Friend WithEvents lblCarUnits As System.Windows.Forms.Label
    Friend WithEvents cboCostFieldCar As System.Windows.Forms.ComboBox
    Friend WithEvents grpFCAdimensions As System.Windows.Forms.GroupBox
    Friend WithEvents cbofcaScale As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents grpImpedance As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
