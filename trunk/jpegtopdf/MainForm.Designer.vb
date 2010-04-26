<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.FileList = New System.Windows.Forms.CheckedListBox
        Me.cmdConvert = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.picPreview = New System.Windows.Forms.PictureBox
        Me.lblheight = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.pbar = New System.Windows.Forms.ProgressBar
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FileList
        '
        Me.FileList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FileList.BackColor = System.Drawing.Color.White
        Me.FileList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileList.FormattingEnabled = True
        Me.FileList.Location = New System.Drawing.Point(12, 36)
        Me.FileList.Name = "FileList"
        Me.FileList.Size = New System.Drawing.Size(304, 317)
        Me.FileList.TabIndex = 0
        '
        'cmdConvert
        '
        Me.cmdConvert.Location = New System.Drawing.Point(223, 9)
        Me.cmdConvert.Name = "cmdConvert"
        Me.cmdConvert.Size = New System.Drawing.Size(93, 23)
        Me.cmdConvert.TabIndex = 1
        Me.cmdConvert.Text = "Convert To PDF"
        Me.cmdConvert.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Location = New System.Drawing.Point(138, 9)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(79, 23)
        Me.cmdLoad.TabIndex = 2
        Me.cmdLoad.Text = "Load Images"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'picPreview
        '
        Me.picPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picPreview.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.picPreview.Location = New System.Drawing.Point(7, 11)
        Me.picPreview.Name = "picPreview"
        Me.picPreview.Size = New System.Drawing.Size(60, 60)
        Me.picPreview.TabIndex = 0
        Me.picPreview.TabStop = False
        '
        'lblheight
        '
        Me.lblheight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblheight.Location = New System.Drawing.Point(72, 12)
        Me.lblheight.Name = "lblheight"
        Me.lblheight.Size = New System.Drawing.Size(39, 13)
        Me.lblheight.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.picPreview)
        Me.GroupBox1.Controls.Add(Me.lblheight)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 354)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(157, 77)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 13)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(120, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "Check/Uncheck All"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'pbar
        '
        Me.pbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbar.Location = New System.Drawing.Point(175, 360)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(141, 23)
        Me.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbar.TabIndex = 8
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 433)
        Me.Controls.Add(Me.pbar)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdConvert)
        Me.Controls.Add(Me.FileList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "JpgToPDF"
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FileList As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdConvert As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lblheight As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar

End Class
