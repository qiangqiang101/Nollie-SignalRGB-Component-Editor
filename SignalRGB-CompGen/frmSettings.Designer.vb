<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        lblLanguage = New NSLabel()
        cmbLanguage = New NSComboBox()
        cbShiftLedPosition = New NSCheckBox()
        btnSave = New NSButton()
        cbConsole = New NSCheckBox()
        NsTheme1 = New NSTheme()
        numWidth = New NSNumericUpDown()
        numHeight = New NSNumericUpDown()
        lblSize = New NSLabel()
        btnClose = New NSControlButton()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblLanguage
        ' 
        lblLanguage.Font = New Font("Segoe UI", 9F)
        lblLanguage.Location = New Point(12, 36)
        lblLanguage.Name = "lblLanguage"
        lblLanguage.Size = New Size(107, 24)
        lblLanguage.TabIndex = 1
        lblLanguage.Text = "Language"
        lblLanguage.Value1 = "Language"
        lblLanguage.Value2 = ""
        ' 
        ' cmbLanguage
        ' 
        cmbLanguage.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbLanguage.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbLanguage.DrawMode = DrawMode.OwnerDrawFixed
        cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLanguage.ForeColor = Color.White
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(125, 36)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(247, 24)
        cmbLanguage.TabIndex = 0
        ' 
        ' cbShiftLedPosition
        ' 
        cbShiftLedPosition.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cbShiftLedPosition.Checked = False
        cbShiftLedPosition.Location = New Point(12, 96)
        cbShiftLedPosition.Name = "cbShiftLedPosition"
        cbShiftLedPosition.Size = New Size(360, 19)
        cbShiftLedPosition.TabIndex = 3
        cbShiftLedPosition.Text = "Shift Displaying LED index by 1"
        ' 
        ' btnSave
        ' 
        btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSave.Location = New Point(297, 156)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 5
        btnSave.Text = "Save"
        ' 
        ' cbConsole
        ' 
        cbConsole.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cbConsole.Checked = False
        cbConsole.Location = New Point(12, 121)
        cbConsole.Name = "cbConsole"
        cbConsole.Size = New Size(360, 19)
        cbConsole.TabIndex = 4
        cbConsole.Text = "Console"
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(numWidth)
        NsTheme1.Controls.Add(numHeight)
        NsTheme1.Controls.Add(lblSize)
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Controls.Add(lblLanguage)
        NsTheme1.Controls.Add(cbShiftLedPosition)
        NsTheme1.Controls.Add(cbConsole)
        NsTheme1.Controls.Add(btnSave)
        NsTheme1.Controls.Add(cmbLanguage)
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
        NsTheme1.Size = New Size(384, 191)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 6
        NsTheme1.Text = "Settings"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numWidth.DecimalPlaces = 0
        numWidth.Increment = 1
        numWidth.InterceptArrowKeys = True
        numWidth.Location = New Point(125, 66)
        numWidth.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.ReadOnly = False
        numWidth.Size = New Size(120, 24)
        numWidth.TabIndex = 1
        numWidth.TextAlign = HorizontalAlignment.Right
        numWidth.ThousandsSeparator = False
        numWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numHeight.DecimalPlaces = 0
        numHeight.Increment = 1
        numHeight.InterceptArrowKeys = True
        numHeight.Location = New Point(252, 66)
        numHeight.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.ReadOnly = False
        numHeight.Size = New Size(120, 24)
        numHeight.TabIndex = 2
        numHeight.TextAlign = HorizontalAlignment.Right
        numHeight.ThousandsSeparator = False
        numHeight.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' lblSize
        ' 
        lblSize.Font = New Font("Segoe UI", 9F)
        lblSize.ForeColor = Color.White
        lblSize.Location = New Point(12, 66)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(107, 24)
        lblSize.TabIndex = 7
        lblSize.Text = "Size"
        lblSize.Value1 = "Default Size"
        lblSize.Value2 = ""
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(361, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 6
        btnClose.Text = "NsControlButton1"
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 191)
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        TopMost = True
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents lblLanguage As NSLabel
    Friend WithEvents cmbLanguage As NSComboBox
    Friend WithEvents cbShiftLedPosition As NSCheckBox
    Friend WithEvents btnSave As NSButton
    Friend WithEvents cbConsole As NSCheckBox
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents numWidth As NSNumericUpDown
    Friend WithEvents numHeight As NSNumericUpDown
    Friend WithEvents lblSize As NSLabel
End Class
