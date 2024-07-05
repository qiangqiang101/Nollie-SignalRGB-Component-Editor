<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEdit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEdit))
        NsTheme1 = New NSTheme()
        numY = New NSNumericUpDown()
        numX = New NSNumericUpDown()
        txtName = New NSTextBox()
        lblName = New NSLabel()
        lblCoordinates = New NSLabel()
        btnOK = New NSButton()
        btnClose = New NSControlButton()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(numY)
        NsTheme1.Controls.Add(numX)
        NsTheme1.Controls.Add(txtName)
        NsTheme1.Controls.Add(lblName)
        NsTheme1.Controls.Add(lblCoordinates)
        NsTheme1.Controls.Add(btnOK)
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Customization = ""
        NsTheme1.Dock = DockStyle.Fill
        NsTheme1.Font = New Font("Segoe UI", 9F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = True
        NsTheme1.Size = New Size(284, 135)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 0
        NsTheme1.Text = "Edit LED"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' numY
        ' 
        numY.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numY.DecimalPlaces = 0
        numY.Increment = 1
        numY.InterceptArrowKeys = True
        numY.Location = New Point(194, 66)
        numY.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numY.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numY.Name = "numY"
        numY.ReadOnly = False
        numY.Size = New Size(78, 24)
        numY.TabIndex = 3
        numY.TextAlign = HorizontalAlignment.Right
        numY.ThousandsSeparator = False
        numY.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' numX
        ' 
        numX.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numX.DecimalPlaces = 0
        numX.Increment = 1
        numX.InterceptArrowKeys = True
        numX.Location = New Point(111, 66)
        numX.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numX.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numX.Name = "numX"
        numX.ReadOnly = False
        numX.Size = New Size(78, 24)
        numX.TabIndex = 2
        numX.TextAlign = HorizontalAlignment.Right
        numX.ThousandsSeparator = False
        numX.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtName.Location = New Point(111, 36)
        txtName.MaxLength = 32767
        txtName.Multiline = False
        txtName.Name = "txtName"
        txtName.ReadOnly = False
        txtName.Size = New Size(161, 24)
        txtName.TabIndex = 1
        txtName.TextAlign = HorizontalAlignment.Left
        txtName.UseSystemPasswordChar = False
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 9F)
        lblName.Location = New Point(12, 36)
        lblName.Name = "lblName"
        lblName.Size = New Size(93, 24)
        lblName.TabIndex = 7
        lblName.Value1 = "LED Name"
        lblName.Value2 = ""
        ' 
        ' lblCoordinates
        ' 
        lblCoordinates.Font = New Font("Segoe UI", 9F)
        lblCoordinates.Location = New Point(12, 66)
        lblCoordinates.Name = "lblCoordinates"
        lblCoordinates.Size = New Size(93, 24)
        lblCoordinates.TabIndex = 9
        lblCoordinates.Text = "Direction"
        lblCoordinates.Value1 = "LED Coordinates"
        lblCoordinates.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(197, 100)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 4
        btnOK.Text = "Confirm"
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
        btnClose.TabIndex = 0
        btnClose.Text = "NsControlButton1"
        ' 
        ' frmEdit
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 135)
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmEdit"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Edit LED"
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents lblName As NSLabel
    Friend WithEvents lblCoordinates As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents txtName As NSTextBox
    Friend WithEvents numY As NSNumericUpDown
    Friend WithEvents numX As NSNumericUpDown
End Class
