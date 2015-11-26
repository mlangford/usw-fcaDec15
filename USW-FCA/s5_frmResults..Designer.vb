<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class s5_frmResults
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
        Dim Label8 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(s5_frmResults))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.chkTidyUp = New System.Windows.Forms.CheckBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Label8 = New System.Windows.Forms.Label()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(630, 499)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(311, 24)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "USW-FCA is ready to compute..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnExecute
        '
        Me.btnExecute.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnExecute.Image = Global.USW_FCA.My.Resources.Resources.compute
        Me.btnExecute.Location = New System.Drawing.Point(937, 585)
        Me.btnExecute.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(69, 64)
        Me.btnExecute.TabIndex = 61
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.ItemHeight = 16
        Me.lstOutput.Location = New System.Drawing.Point(630, 225)
        Me.lstOutput.Margin = New System.Windows.Forms.Padding(4)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(465, 260)
        Me.lstOutput.TabIndex = 60
        '
        'chkTidyUp
        '
        Me.chkTidyUp.AutoSize = True
        Me.chkTidyUp.Checked = True
        Me.chkTidyUp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTidyUp.Location = New System.Drawing.Point(634, 618)
        Me.chkTidyUp.Margin = New System.Windows.Forms.Padding(4)
        Me.chkTidyUp.Name = "chkTidyUp"
        Me.chkTidyUp.Size = New System.Drawing.Size(197, 21)
        Me.chkTidyUp.TabIndex = 59
        Me.chkTidyUp.Text = "Delete NA layers upon exit"
        Me.chkTidyUp.UseVisualStyleBackColor = True
        Me.chkTidyUp.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Enabled = False
        Me.btnClose.Image = Global.USW_FCA.My.Resources.Resources.finish
        Me.btnClose.Location = New System.Drawing.Point(1021, 585)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(69, 64)
        Me.btnClose.TabIndex = 58
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(205, Byte), Integer))
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.ForeColor = System.Drawing.SystemColors.ControlDark
        Label8.Location = New System.Drawing.Point(13, 502)
        Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(350, 46)
        Label8.TabIndex = 57
        Label8.Text = "Version: 15/11/15" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mitchel Langford / Richard Fry"
        '
        'PictureBox10
        '
        Me.PictureBox10.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox10.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(1104, 217)
        Me.PictureBox10.TabIndex = 56
        Me.PictureBox10.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 225)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(622, 260)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        '
        's5_frmResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1104, 668)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.chkTidyUp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.PictureBox10)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "s5_frmResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Computation Feedback and Results"
        Me.TopMost = True
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents chkTidyUp As System.Windows.Forms.CheckBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
