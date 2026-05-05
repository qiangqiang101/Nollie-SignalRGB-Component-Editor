<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirst
    Inherits FormEx

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFirst))
        NsTheme1 = New NSTheme()
        btnContinue = New NSButton()
        btnClose = New NSControlButton()
        flpChooseLanguage = New FlowLayoutPanel()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(btnContinue)
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Controls.Add(flpChooseLanguage)
        NsTheme1.Customization = ""
        NsTheme1.Dock = DockStyle.Fill
        NsTheme1.Font = New Font("Segoe UI", 9F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = False
        NsTheme1.Size = New Size(754, 461)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 0
        NsTheme1.Text = "Choose Language"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' btnContinue
        ' 
        btnContinue.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnContinue.Location = New Point(667, 426)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(75, 23)
        btnContinue.TabIndex = 1
        btnContinue.Text = "Continue"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(731, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 2
        btnClose.Text = "NsControlButton1"
        ' 
        ' flpChooseLanguage
        ' 
        flpChooseLanguage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        flpChooseLanguage.Location = New Point(12, 36)
        flpChooseLanguage.Name = "flpChooseLanguage"
        flpChooseLanguage.Size = New Size(730, 384)
        flpChooseLanguage.TabIndex = 0
        ' 
        ' frmFirst
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(754, 461)
        ControlBox = False
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        Name = "frmFirst"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Choose Language"
        TopMost = True
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents flpChooseLanguage As FlowLayoutPanel
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents btnContinue As NSButton
End Class
