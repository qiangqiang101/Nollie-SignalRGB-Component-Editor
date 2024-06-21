<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits FormEx

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        RightPanel = New Panel()
        flpMenuStrip = New FlowLayoutPanel()
        btnFile = New NSButton()
        btnSettings = New NSButton()
        btnHelp = New NSButton()
        nslblPosition = New NSLabel()
        gbImage = New NSGroupBox()
        pbImage = New PictureBox()
        btnChangeImage = New NSButton()
        NsSeperator1 = New NSSeperator()
        txtLedCount = New NSTextBox()
        lblLedCount = New NSLabel()
        lblType = New NSLabel()
        cmbType = New NSComboBox()
        lblProduct = New NSLabel()
        txtProduct = New NSTextBox()
        lblVendor = New NSLabel()
        txtBrand = New NSTextBox()
        lblName = New NSLabel()
        txtName = New NSTextBox()
        lblHeight = New NSLabel()
        lblWidth = New NSLabel()
        numHeight = New NSNumericUpDown()
        numWidth = New NSNumericUpDown()
        cmFile = New NSContextMenu()
        tsmiNew = New ToolStripMenuItem()
        tsmiOpen = New ToolStripMenuItem()
        tsmiSave = New ToolStripMenuItem()
        tsmiSaveAs = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiExit = New ToolStripMenuItem()
        tsmiControls = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiSRGB = New ToolStripMenuItem()
        tsmiNollie = New ToolStripMenuItem()
        tsmiMentaL = New ToolStripMenuItem()
        tsmiBuy = New ToolStripMenuItem()
        SplitContainer1 = New SplitContainer()
        Timer1 = New Timer(components)
        NsTheme1 = New NSTheme()
        btnMin = New NSControlButton()
        btnMax = New NSControlButton()
        btnClose = New NSControlButton()
        cmHelp = New NSContextMenu()
        RightPanel.SuspendLayout()
        flpMenuStrip.SuspendLayout()
        gbImage.SuspendLayout()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        cmFile.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        NsTheme1.SuspendLayout()
        cmHelp.SuspendLayout()
        SuspendLayout()
        ' 
        ' RightPanel
        ' 
        RightPanel.Controls.Add(flpMenuStrip)
        RightPanel.Controls.Add(nslblPosition)
        RightPanel.Controls.Add(gbImage)
        RightPanel.Controls.Add(NsSeperator1)
        RightPanel.Controls.Add(txtLedCount)
        RightPanel.Controls.Add(lblLedCount)
        RightPanel.Controls.Add(lblType)
        RightPanel.Controls.Add(cmbType)
        RightPanel.Controls.Add(lblProduct)
        RightPanel.Controls.Add(txtProduct)
        RightPanel.Controls.Add(lblVendor)
        RightPanel.Controls.Add(txtBrand)
        RightPanel.Controls.Add(lblName)
        RightPanel.Controls.Add(txtName)
        RightPanel.Controls.Add(lblHeight)
        RightPanel.Controls.Add(lblWidth)
        RightPanel.Controls.Add(numHeight)
        RightPanel.Controls.Add(numWidth)
        RightPanel.Dock = DockStyle.Fill
        RightPanel.Location = New Point(0, 0)
        RightPanel.Name = "RightPanel"
        RightPanel.Padding = New Padding(3)
        RightPanel.Size = New Size(269, 687)
        RightPanel.TabIndex = 0
        ' 
        ' flpMenuStrip
        ' 
        flpMenuStrip.Controls.Add(btnFile)
        flpMenuStrip.Controls.Add(btnSettings)
        flpMenuStrip.Controls.Add(btnHelp)
        flpMenuStrip.Dock = DockStyle.Top
        flpMenuStrip.Location = New Point(3, 3)
        flpMenuStrip.Name = "flpMenuStrip"
        flpMenuStrip.Size = New Size(263, 28)
        flpMenuStrip.TabIndex = 0
        ' 
        ' btnFile
        ' 
        btnFile.Location = New Point(3, 3)
        btnFile.Name = "btnFile"
        btnFile.Size = New Size(32, 23)
        btnFile.TabIndex = 0
        btnFile.Text = "File"
        ' 
        ' btnSettings
        ' 
        btnSettings.Location = New Point(41, 3)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(55, 23)
        btnSettings.TabIndex = 1
        btnSettings.Text = "Settings"
        ' 
        ' btnHelp
        ' 
        btnHelp.Location = New Point(102, 3)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(38, 23)
        btnHelp.TabIndex = 2
        btnHelp.Text = "Help"
        ' 
        ' nslblPosition
        ' 
        nslblPosition.Dock = DockStyle.Bottom
        nslblPosition.Font = New Font("Segoe UI", 9F)
        nslblPosition.Location = New Point(3, 661)
        nslblPosition.Name = "nslblPosition"
        nslblPosition.Size = New Size(263, 23)
        nslblPosition.TabIndex = 21
        nslblPosition.Text = "NsLabel1"
        nslblPosition.Value1 = "Position: 0, 0"
        nslblPosition.Value2 = ""
        ' 
        ' gbImage
        ' 
        gbImage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        gbImage.Controls.Add(pbImage)
        gbImage.Controls.Add(btnChangeImage)
        gbImage.DrawSeperator = True
        gbImage.Location = New Point(6, 260)
        gbImage.Name = "gbImage"
        gbImage.Padding = New Padding(3, 31, 3, 3)
        gbImage.Size = New Size(257, 312)
        gbImage.SubTitle = ""
        gbImage.TabIndex = 8
        gbImage.Title = "Component Image"
        ' 
        ' pbImage
        ' 
        pbImage.Dock = DockStyle.Fill
        pbImage.Image = My.Resources.Resources._1
        pbImage.Location = New Point(3, 31)
        pbImage.Name = "pbImage"
        pbImage.Size = New Size(251, 255)
        pbImage.SizeMode = PictureBoxSizeMode.Zoom
        pbImage.TabIndex = 13
        pbImage.TabStop = False
        ' 
        ' btnChangeImage
        ' 
        btnChangeImage.Dock = DockStyle.Bottom
        btnChangeImage.Location = New Point(3, 286)
        btnChangeImage.Name = "btnChangeImage"
        btnChangeImage.Size = New Size(251, 23)
        btnChangeImage.TabIndex = 1
        btnChangeImage.Text = "Select Image"
        ' 
        ' NsSeperator1
        ' 
        NsSeperator1.Location = New Point(5, 242)
        NsSeperator1.Name = "NsSeperator1"
        NsSeperator1.Size = New Size(261, 11)
        NsSeperator1.TabIndex = 19
        NsSeperator1.Text = "NsSeperator1"
        ' 
        ' txtLedCount
        ' 
        txtLedCount.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLedCount.Location = New Point(86, 215)
        txtLedCount.MaxLength = 32767
        txtLedCount.Multiline = False
        txtLedCount.Name = "txtLedCount"
        txtLedCount.ReadOnly = True
        txtLedCount.Size = New Size(177, 24)
        txtLedCount.TabIndex = 7
        txtLedCount.Text = "0"
        txtLedCount.TextAlign = HorizontalAlignment.Right
        txtLedCount.UseSystemPasswordChar = False
        ' 
        ' lblLedCount
        ' 
        lblLedCount.Font = New Font("Segoe UI", 9F)
        lblLedCount.ForeColor = Color.White
        lblLedCount.Location = New Point(6, 215)
        lblLedCount.Name = "lblLedCount"
        lblLedCount.Size = New Size(74, 24)
        lblLedCount.TabIndex = 17
        lblLedCount.Text = "LED Count"
        lblLedCount.Value1 = "LED Count"
        lblLedCount.Value2 = ""
        ' 
        ' lblType
        ' 
        lblType.Font = New Font("Segoe UI", 9F)
        lblType.ForeColor = Color.White
        lblType.Location = New Point(6, 125)
        lblType.Name = "lblType"
        lblType.Size = New Size(74, 24)
        lblType.TabIndex = 12
        lblType.Text = "Type"
        lblType.Value1 = "Type"
        lblType.Value2 = ""
        ' 
        ' cmbType
        ' 
        cmbType.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cmbType.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbType.DrawMode = DrawMode.OwnerDrawFixed
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbType.ForeColor = Color.White
        cmbType.FormattingEnabled = True
        cmbType.Location = New Point(86, 125)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(177, 24)
        cmbType.TabIndex = 4
        ' 
        ' lblProduct
        ' 
        lblProduct.Font = New Font("Segoe UI", 9F)
        lblProduct.ForeColor = Color.White
        lblProduct.Location = New Point(6, 95)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(74, 24)
        lblProduct.TabIndex = 10
        lblProduct.Text = "Product"
        lblProduct.Value1 = "Product"
        lblProduct.Value2 = ""
        ' 
        ' txtProduct
        ' 
        txtProduct.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtProduct.Location = New Point(86, 95)
        txtProduct.MaxLength = 32767
        txtProduct.Multiline = False
        txtProduct.Name = "txtProduct"
        txtProduct.ReadOnly = False
        txtProduct.Size = New Size(177, 24)
        txtProduct.TabIndex = 3
        txtProduct.TextAlign = HorizontalAlignment.Left
        txtProduct.UseSystemPasswordChar = False
        ' 
        ' lblVendor
        ' 
        lblVendor.Font = New Font("Segoe UI", 9F)
        lblVendor.ForeColor = Color.White
        lblVendor.Location = New Point(6, 65)
        lblVendor.Name = "lblVendor"
        lblVendor.Size = New Size(74, 24)
        lblVendor.TabIndex = 8
        lblVendor.Text = "Vendor"
        lblVendor.Value1 = "Brand"
        lblVendor.Value2 = ""
        ' 
        ' txtBrand
        ' 
        txtBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBrand.Location = New Point(86, 65)
        txtBrand.MaxLength = 32767
        txtBrand.Multiline = False
        txtBrand.Name = "txtBrand"
        txtBrand.ReadOnly = False
        txtBrand.Size = New Size(177, 24)
        txtBrand.TabIndex = 2
        txtBrand.TextAlign = HorizontalAlignment.Left
        txtBrand.UseSystemPasswordChar = False
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 9F)
        lblName.ForeColor = Color.White
        lblName.Location = New Point(6, 35)
        lblName.Name = "lblName"
        lblName.Size = New Size(74, 24)
        lblName.TabIndex = 6
        lblName.Text = "Name"
        lblName.Value1 = "Name"
        lblName.Value2 = ""
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtName.Location = New Point(86, 35)
        txtName.MaxLength = 32767
        txtName.Multiline = False
        txtName.Name = "txtName"
        txtName.ReadOnly = False
        txtName.Size = New Size(177, 24)
        txtName.TabIndex = 1
        txtName.TextAlign = HorizontalAlignment.Left
        txtName.UseSystemPasswordChar = False
        ' 
        ' lblHeight
        ' 
        lblHeight.Font = New Font("Segoe UI", 9F)
        lblHeight.ForeColor = Color.White
        lblHeight.Location = New Point(6, 185)
        lblHeight.Name = "lblHeight"
        lblHeight.Size = New Size(74, 24)
        lblHeight.TabIndex = 4
        lblHeight.Text = "Height"
        lblHeight.Value1 = "Height"
        lblHeight.Value2 = ""
        ' 
        ' lblWidth
        ' 
        lblWidth.Font = New Font("Segoe UI", 9F)
        lblWidth.ForeColor = Color.White
        lblWidth.Location = New Point(6, 155)
        lblWidth.Name = "lblWidth"
        lblWidth.Size = New Size(74, 24)
        lblWidth.TabIndex = 3
        lblWidth.Text = "Width"
        lblWidth.Value1 = "Width"
        lblWidth.Value2 = ""
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numHeight.DecimalPlaces = 0
        numHeight.Increment = 1
        numHeight.InterceptArrowKeys = True
        numHeight.Location = New Point(86, 185)
        numHeight.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.ReadOnly = False
        numHeight.Size = New Size(177, 24)
        numHeight.TabIndex = 6
        numHeight.TextAlign = HorizontalAlignment.Right
        numHeight.ThousandsSeparator = False
        numHeight.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numWidth.DecimalPlaces = 0
        numWidth.Increment = 1
        numWidth.InterceptArrowKeys = True
        numWidth.Location = New Point(86, 155)
        numWidth.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.ReadOnly = False
        numWidth.Size = New Size(177, 24)
        numWidth.TabIndex = 5
        numWidth.TextAlign = HorizontalAlignment.Right
        numWidth.ThousandsSeparator = False
        numWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' cmFile
        ' 
        cmFile.ForeColor = Color.White
        cmFile.Items.AddRange(New ToolStripItem() {tsmiNew, tsmiOpen, tsmiSave, tsmiSaveAs, ToolStripSeparator1, tsmiExit})
        cmFile.Name = "NsContextMenu1"
        cmFile.Size = New Size(187, 120)
        ' 
        ' tsmiNew
        ' 
        tsmiNew.Name = "tsmiNew"
        tsmiNew.ShortcutKeys = Keys.Control Or Keys.N
        tsmiNew.Size = New Size(186, 22)
        tsmiNew.Text = "New"
        ' 
        ' tsmiOpen
        ' 
        tsmiOpen.Name = "tsmiOpen"
        tsmiOpen.ShortcutKeys = Keys.Control Or Keys.O
        tsmiOpen.Size = New Size(186, 22)
        tsmiOpen.Text = "Open..."
        ' 
        ' tsmiSave
        ' 
        tsmiSave.Name = "tsmiSave"
        tsmiSave.ShortcutKeys = Keys.Control Or Keys.S
        tsmiSave.Size = New Size(186, 22)
        tsmiSave.Text = "Save"
        ' 
        ' tsmiSaveAs
        ' 
        tsmiSaveAs.Name = "tsmiSaveAs"
        tsmiSaveAs.ShortcutKeys = Keys.Control Or Keys.Alt Or Keys.S
        tsmiSaveAs.Size = New Size(186, 22)
        tsmiSaveAs.Text = "Save As..."
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(183, 6)
        ' 
        ' tsmiExit
        ' 
        tsmiExit.Name = "tsmiExit"
        tsmiExit.ShortcutKeys = Keys.Alt Or Keys.F4
        tsmiExit.Size = New Size(186, 22)
        tsmiExit.Text = "Exit"
        ' 
        ' tsmiControls
        ' 
        tsmiControls.Name = "tsmiControls"
        tsmiControls.ShortcutKeys = Keys.F1
        tsmiControls.Size = New Size(227, 22)
        tsmiControls.Text = "Controls"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(224, 6)
        ' 
        ' tsmiSRGB
        ' 
        tsmiSRGB.Name = "tsmiSRGB"
        tsmiSRGB.Size = New Size(227, 22)
        tsmiSRGB.Text = "Visit SignalRGB Website"
        ' 
        ' tsmiNollie
        ' 
        tsmiNollie.Name = "tsmiNollie"
        tsmiNollie.Size = New Size(227, 22)
        tsmiNollie.Text = "Visit Nollie Website"
        ' 
        ' tsmiMentaL
        ' 
        tsmiMentaL.Name = "tsmiMentaL"
        tsmiMentaL.Size = New Size(227, 22)
        tsmiMentaL.Text = "Visit I'm Not MentaL Website"
        ' 
        ' tsmiBuy
        ' 
        tsmiBuy.Name = "tsmiBuy"
        tsmiBuy.Size = New Size(227, 22)
        tsmiBuy.Text = "Buy Nollie32"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(6, 36)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        SplitContainer1.Panel1.ForeColor = Color.White
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(RightPanel)
        SplitContainer1.Size = New Size(996, 687)
        SplitContainer1.SplitterDistance = 723
        SplitContainer1.TabIndex = 3
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.Sizable
        NsTheme1.Controls.Add(btnMin)
        NsTheme1.Controls.Add(btnMax)
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Controls.Add(SplitContainer1)
        NsTheme1.Customization = ""
        NsTheme1.Dock = DockStyle.Fill
        NsTheme1.Font = New Font("Segoe UI", 9F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.MinimumSize = New Size(1000, 700)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = True
        NsTheme1.Size = New Size(1008, 729)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 4
        NsTheme1.Text = "Untitled - Nollie x SignalRGB Custom Component Editor"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' btnMin
        ' 
        btnMin.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnMin.ControlButton = NSControlButton.Button.Minimize
        btnMin.Location = New Point(949, 5)
        btnMin.Margin = New Padding(0)
        btnMin.MaximumSize = New Size(18, 20)
        btnMin.MinimumSize = New Size(18, 20)
        btnMin.Name = "btnMin"
        btnMin.Size = New Size(18, 20)
        btnMin.TabIndex = 6
        btnMin.Text = "NsControlButton3"
        ' 
        ' btnMax
        ' 
        btnMax.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnMax.ControlButton = NSControlButton.Button.MaximizeRestore
        btnMax.Location = New Point(967, 5)
        btnMax.Margin = New Padding(0)
        btnMax.MaximumSize = New Size(18, 20)
        btnMax.MinimumSize = New Size(18, 20)
        btnMax.Name = "btnMax"
        btnMax.Size = New Size(18, 20)
        btnMax.TabIndex = 5
        btnMax.Text = "NsControlButton2"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(985, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 4
        btnClose.Text = "NsControlButton1"
        ' 
        ' cmHelp
        ' 
        cmHelp.ForeColor = Color.White
        cmHelp.Items.AddRange(New ToolStripItem() {tsmiControls, ToolStripSeparator2, tsmiSRGB, tsmiNollie, tsmiMentaL, tsmiBuy})
        cmHelp.Name = "cmHelp"
        cmHelp.Size = New Size(228, 120)
        ' 
        ' frmMain
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        ControlBox = False
        Controls.Add(NsTheme1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        MinimumSize = New Size(1000, 700)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Untitled - Nollie x SignalRGB Custom Component Editor"
        RightPanel.ResumeLayout(False)
        flpMenuStrip.ResumeLayout(False)
        gbImage.ResumeLayout(False)
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        cmFile.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        NsTheme1.ResumeLayout(False)
        cmHelp.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents RightPanel As Panel
    Friend WithEvents numWidth As NSNumericUpDown
    Friend WithEvents lblName As NSLabel
    Friend WithEvents txtName As NSTextBox
    Friend WithEvents lblHeight As NSLabel
    Friend WithEvents lblWidth As NSLabel
    Friend WithEvents numHeight As NSNumericUpDown
    Friend WithEvents lblType As NSLabel
    Friend WithEvents cmbType As NSComboBox
    Friend WithEvents lblProduct As NSLabel
    Friend WithEvents txtProduct As NSTextBox
    Friend WithEvents lblVendor As NSLabel
    Friend WithEvents txtBrand As NSTextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents pbImage As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiOpen As ToolStripMenuItem
    Friend WithEvents tsmiSave As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiExit As ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As ToolStripMenuItem
    Friend WithEvents lblLedCount As NSLabel
    Friend WithEvents txtLedCount As NSTextBox
    Friend WithEvents btnChangeImage As NSButton
    Friend WithEvents tsmiControls As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiSRGB As ToolStripMenuItem
    Friend WithEvents tsmiNollie As ToolStripMenuItem
    Friend WithEvents tsmiMentaL As ToolStripMenuItem
    Friend WithEvents tsmiBuy As ToolStripMenuItem
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents btnMin As NSControlButton
    Friend WithEvents btnMax As NSControlButton
    Friend WithEvents NsSeperator1 As NSSeperator
    Friend WithEvents gbImage As NSGroupBox
    Friend WithEvents nslblPosition As NSLabel
    Friend WithEvents btnFile As NSButton
    Friend WithEvents cmFile As NSContextMenu
    Friend WithEvents btnSettings As NSButton
    Friend WithEvents cmHelp As NSContextMenu
    Friend WithEvents btnHelp As NSButton
    Friend WithEvents flpMenuStrip As FlowLayoutPanel

End Class
