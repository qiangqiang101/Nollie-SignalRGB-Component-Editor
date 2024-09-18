<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImport))
        NsTheme1 = New NSTheme()
        txtLocation = New NSTextBox()
        lblLocation = New NSLabel()
        txtFileName = New NSTextBox()
        lblFileName = New NSLabel()
        lblDevice = New NSLabel()
        btnOK = New NSButton()
        cmbDevice = New NSComboBox()
        btnClose = New NSControlButton()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(txtLocation)
        NsTheme1.Controls.Add(lblLocation)
        NsTheme1.Controls.Add(txtFileName)
        NsTheme1.Controls.Add(lblFileName)
        NsTheme1.Controls.Add(lblDevice)
        NsTheme1.Controls.Add(btnOK)
        NsTheme1.Controls.Add(cmbDevice)
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
        NsTheme1.Size = New Size(363, 161)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 0
        NsTheme1.Text = "Import OpenRGB Visual Map"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' txtLocation
        ' 
        txtLocation.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLocation.Location = New Point(89, 97)
        txtLocation.MaxLength = 32767
        txtLocation.Multiline = False
        txtLocation.Name = "txtLocation"
        txtLocation.ReadOnly = True
        txtLocation.Size = New Size(268, 24)
        txtLocation.TabIndex = 2
        txtLocation.TextAlign = HorizontalAlignment.Left
        txtLocation.UseSystemPasswordChar = False
        ' 
        ' lblLocation
        ' 
        lblLocation.Font = New Font("Segoe UI", 9F)
        lblLocation.Location = New Point(6, 97)
        lblLocation.Name = "lblLocation"
        lblLocation.Size = New Size(77, 24)
        lblLocation.TabIndex = 11
        lblLocation.Value1 = "Location"
        lblLocation.Value2 = ""
        ' 
        ' txtFileName
        ' 
        txtFileName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFileName.Location = New Point(89, 37)
        txtFileName.MaxLength = 32767
        txtFileName.Multiline = False
        txtFileName.Name = "txtFileName"
        txtFileName.ReadOnly = True
        txtFileName.Size = New Size(268, 24)
        txtFileName.TabIndex = 0
        txtFileName.TextAlign = HorizontalAlignment.Left
        txtFileName.UseSystemPasswordChar = False
        ' 
        ' lblFileName
        ' 
        lblFileName.Font = New Font("Segoe UI", 9F)
        lblFileName.Location = New Point(6, 37)
        lblFileName.Name = "lblFileName"
        lblFileName.Size = New Size(77, 24)
        lblFileName.TabIndex = 9
        lblFileName.Value1 = "File Name"
        lblFileName.Value2 = ""
        ' 
        ' lblDevice
        ' 
        lblDevice.Font = New Font("Segoe UI", 9F)
        lblDevice.Location = New Point(6, 67)
        lblDevice.Name = "lblDevice"
        lblDevice.Size = New Size(77, 24)
        lblDevice.TabIndex = 7
        lblDevice.Text = "Direction"
        lblDevice.Value1 = "Device"
        lblDevice.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(282, 126)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 5
        btnOK.Text = "Confirm"
        ' 
        ' cmbDevice
        ' 
        cmbDevice.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cmbDevice.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbDevice.DrawMode = DrawMode.OwnerDrawFixed
        cmbDevice.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDevice.ForeColor = Color.White
        cmbDevice.FormattingEnabled = True
        cmbDevice.Location = New Point(89, 67)
        cmbDevice.Name = "cmbDevice"
        cmbDevice.Size = New Size(268, 24)
        cmbDevice.TabIndex = 1
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(340, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 1
        btnClose.Text = "NsControlButton1"
        ' 
        ' frmImport
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(363, 161)
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmImport"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Import OpenRGB Visual Map"
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents lblDevice As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents cmbDevice As NSComboBox
    Friend WithEvents txtFileName As NSTextBox
    Friend WithEvents lblFileName As NSLabel
    Friend WithEvents txtLocation As NSTextBox
    Friend WithEvents lblLocation As NSLabel
End Class
