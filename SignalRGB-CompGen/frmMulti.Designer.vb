<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMulti
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMulti))
        numAmount = New NSNumericUpDown()
        lblNumOfLeds = New NSLabel()
        btnOK = New NSButton()
        cmbDirection = New NSComboBox()
        lblDirection = New NSLabel()
        NsTheme1 = New NSTheme()
        btnClose = New NSControlButton()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' numAmount
        ' 
        numAmount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmount.DecimalPlaces = 0
        numAmount.Increment = 1
        numAmount.InterceptArrowKeys = True
        numAmount.Location = New Point(111, 36)
        numAmount.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmount.Name = "numAmount"
        numAmount.ReadOnly = False
        numAmount.Size = New Size(161, 24)
        numAmount.TabIndex = 0
        numAmount.TextAlign = HorizontalAlignment.Right
        numAmount.ThousandsSeparator = False
        numAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblNumOfLeds
        ' 
        lblNumOfLeds.Font = New Font("Segoe UI", 9.0F)
        lblNumOfLeds.Location = New Point(12, 36)
        lblNumOfLeds.Name = "lblNumOfLeds"
        lblNumOfLeds.Size = New Size(93, 24)
        lblNumOfLeds.TabIndex = 1
        lblNumOfLeds.Text = "Number of LEDs"
        lblNumOfLeds.Value1 = "Number of LEDs"
        lblNumOfLeds.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(197, 100)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 2
        btnOK.Text = "Confirm"
        ' 
        ' cmbDirection
        ' 
        cmbDirection.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbDirection.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbDirection.DrawMode = DrawMode.OwnerDrawFixed
        cmbDirection.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDirection.ForeColor = Color.White
        cmbDirection.FormattingEnabled = True
        cmbDirection.Location = New Point(111, 66)
        cmbDirection.Name = "cmbDirection"
        cmbDirection.Size = New Size(161, 24)
        cmbDirection.TabIndex = 1
        ' 
        ' lblDirection
        ' 
        lblDirection.Font = New Font("Segoe UI", 9.0F)
        lblDirection.Location = New Point(12, 66)
        lblDirection.Name = "lblDirection"
        lblDirection.Size = New Size(55, 24)
        lblDirection.TabIndex = 4
        lblDirection.Text = "Direction"
        lblDirection.Value1 = "Direction"
        lblDirection.Value2 = ""
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Controls.Add(lblNumOfLeds)
        NsTheme1.Controls.Add(lblDirection)
        NsTheme1.Controls.Add(btnOK)
        NsTheme1.Controls.Add(cmbDirection)
        NsTheme1.Controls.Add(numAmount)
        NsTheme1.Customization = ""
        NsTheme1.Dock = DockStyle.Fill
        NsTheme1.Font = New Font("Segoe UI", 9.0F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = False
        NsTheme1.Size = New Size(284, 135)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 5
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(261, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 5
        btnClose.Text = "NsControlButton1"
        ' 
        ' frmMulti
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 135)
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMulti"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents numAmount As NSNumericUpDown
    Friend WithEvents lblNumOfLeds As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents cmbDirection As NSComboBox
    Friend WithEvents lblDirection As NSLabel
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
End Class
