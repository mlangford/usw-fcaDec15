<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s2_frmSupplyDetails
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkSupplyFieldCar = New System.Windows.Forms.CheckBox()
        Me.cboSupplyVolumeFieldCar = New System.Windows.Forms.ComboBox()
        Me.cboSupplyPointsLayerCar = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.btn2Prev = New System.Windows.Forms.Button()
        Me.btn2Next = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboDemandIDField = New System.Windows.Forms.ComboBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.cboDemandFieldCar = New System.Windows.Forms.ComboBox()
        Me.cboDemandPointsLayerCar = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(8, 46)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(385, 48)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Layer containing the supply point locations:"
        '
        'chkSupplyFieldCar
        '
        Me.chkSupplyFieldCar.AutoSize = True
        Me.chkSupplyFieldCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSupplyFieldCar.Location = New System.Drawing.Point(433, 98)
        Me.chkSupplyFieldCar.Margin = New System.Windows.Forms.Padding(4)
        Me.chkSupplyFieldCar.Name = "chkSupplyFieldCar"
        Me.chkSupplyFieldCar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSupplyFieldCar.Size = New System.Drawing.Size(456, 44)
        Me.chkSupplyFieldCar.TabIndex = 29
        Me.chkSupplyFieldCar.Text = "check to select a field in this layer as the supply capacity" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " (if unselected, a " & _
    "default supply volume = 1 is utilised)"
        Me.chkSupplyFieldCar.UseVisualStyleBackColor = True
        '
        'cboSupplyVolumeFieldCar
        '
        Me.cboSupplyVolumeFieldCar.Enabled = False
        Me.cboSupplyVolumeFieldCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSupplyVolumeFieldCar.FormattingEnabled = True
        Me.cboSupplyVolumeFieldCar.Location = New System.Drawing.Point(433, 150)
        Me.cboSupplyVolumeFieldCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSupplyVolumeFieldCar.Name = "cboSupplyVolumeFieldCar"
        Me.cboSupplyVolumeFieldCar.Size = New System.Drawing.Size(292, 33)
        Me.cboSupplyVolumeFieldCar.TabIndex = 26
        '
        'cboSupplyPointsLayerCar
        '
        Me.cboSupplyPointsLayerCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSupplyPointsLayerCar.FormattingEnabled = True
        Me.cboSupplyPointsLayerCar.Location = New System.Drawing.Point(433, 46)
        Me.cboSupplyPointsLayerCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboSupplyPointsLayerCar.Name = "cboSupplyPointsLayerCar"
        Me.cboSupplyPointsLayerCar.Size = New System.Drawing.Size(585, 33)
        Me.cboSupplyPointsLayerCar.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.chkSupplyFieldCar)
        Me.GroupBox2.Controls.Add(Me.cboSupplyVolumeFieldCar)
        Me.GroupBox2.Controls.Add(Me.cboSupplyPointsLayerCar)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1088, 228)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "service SUPPLY details:"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(9, 150)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(385, 51)
        Me.TextBox3.TabIndex = 33
        Me.TextBox3.Text = "Attribute field holding service supply volume :"
        '
        'btn2Prev
        '
        Me.btn2Prev.Image = Global.USW_FCA.My.Resources.Resources.prevB
        Me.btn2Prev.Location = New System.Drawing.Point(9, 585)
        Me.btn2Prev.Margin = New System.Windows.Forms.Padding(4)
        Me.btn2Prev.Name = "btn2Prev"
        Me.btn2Prev.Size = New System.Drawing.Size(69, 64)
        Me.btn2Prev.TabIndex = 14
        Me.btn2Prev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn2Prev.UseVisualStyleBackColor = True
        '
        'btn2Next
        '
        Me.btn2Next.Image = Global.USW_FCA.My.Resources.Resources.nextB
        Me.btn2Next.Location = New System.Drawing.Point(1028, 585)
        Me.btn2Next.Margin = New System.Windows.Forms.Padding(4)
        Me.btn2Next.Name = "btn2Next"
        Me.btn2Next.Size = New System.Drawing.Size(69, 64)
        Me.btn2Next.TabIndex = 13
        Me.btn2Next.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDemandIDField)
        Me.GroupBox3.Controls.Add(Me.TextBox5)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TextBox6)
        Me.GroupBox3.Controls.Add(Me.cboDemandFieldCar)
        Me.GroupBox3.Controls.Add(Me.cboDemandPointsLayerCar)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(9, 269)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1088, 281)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "service DEMAND details:"
        '
        'cboDemandIDField
        '
        Me.cboDemandIDField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDemandIDField.FormattingEnabled = True
        Me.cboDemandIDField.Location = New System.Drawing.Point(434, 207)
        Me.cboDemandIDField.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandIDField.Name = "cboDemandIDField"
        Me.cboDemandIDField.Size = New System.Drawing.Size(292, 33)
        Me.cboDemandIDField.TabIndex = 38
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(9, 207)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(385, 51)
        Me.TextBox5.TabIndex = 37
        Me.TextBox5.Text = "Select a field from the Demand Points layer to be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "copied across to the results t" & _
    "able for data linking"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(8, 122)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(385, 51)
        Me.TextBox2.TabIndex = 32
        Me.TextBox2.Text = "Attribute field holding service demand volume :"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(8, 46)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(385, 48)
        Me.TextBox6.TabIndex = 5
        Me.TextBox6.Text = "Layer containing the demand point locations:"
        '
        'cboDemandFieldCar
        '
        Me.cboDemandFieldCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDemandFieldCar.FormattingEnabled = True
        Me.cboDemandFieldCar.Location = New System.Drawing.Point(433, 122)
        Me.cboDemandFieldCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandFieldCar.Name = "cboDemandFieldCar"
        Me.cboDemandFieldCar.Size = New System.Drawing.Size(292, 33)
        Me.cboDemandFieldCar.TabIndex = 26
        '
        'cboDemandPointsLayerCar
        '
        Me.cboDemandPointsLayerCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDemandPointsLayerCar.FormattingEnabled = True
        Me.cboDemandPointsLayerCar.Location = New System.Drawing.Point(433, 46)
        Me.cboDemandPointsLayerCar.Margin = New System.Windows.Forms.Padding(4)
        Me.cboDemandPointsLayerCar.Name = "cboDemandPointsLayerCar"
        Me.cboDemandPointsLayerCar.Size = New System.Drawing.Size(585, 33)
        Me.cboDemandPointsLayerCar.TabIndex = 0
        '
        's2_frmSupplyDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1104, 662)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btn2Prev)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btn2Next)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "s2_frmSupplyDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Supply and Demand Details"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btn2Prev As System.Windows.Forms.Button
    Friend WithEvents chkSupplyFieldCar As System.Windows.Forms.CheckBox
    Friend WithEvents cboSupplyVolumeFieldCar As System.Windows.Forms.ComboBox
    Friend WithEvents cboSupplyPointsLayerCar As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btn2Next As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDemandIDField As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents cboDemandFieldCar As System.Windows.Forms.ComboBox
    Friend WithEvents cboDemandPointsLayerCar As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
End Class
