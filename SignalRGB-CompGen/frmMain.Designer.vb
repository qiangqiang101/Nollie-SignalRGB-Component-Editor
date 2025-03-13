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
        txtWebImageUrl = New NSTextBox()
        lblWebImage = New NSLabel()
        tlpImageControls = New TableLayoutPanel()
        gbImage = New NSGroupBox()
        pbImage = New PictureBox()
        btnChangeImage = New NSButton()
        gbControls = New NSGroupBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        btnUp = New NSButton()
        btnLeft = New NSButton()
        btnRight = New NSButton()
        btnDown = New NSButton()
        btnAutoResize = New NSButton()
        msMainMenu = New NSMenuStrip()
        tsmiFile = New ToolStripMenuItem()
        tsmiNew = New ToolStripMenuItem()
        tsmiOpen = New ToolStripMenuItem()
        tsmiSave = New ToolStripMenuItem()
        tsmiSaveAs = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        tsmiImport = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiExit = New ToolStripMenuItem()
        tsmiSettings = New ToolStripMenuItem()
        tsmiHelp = New ToolStripMenuItem()
        tsmiControls = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiSRGB = New ToolStripMenuItem()
        tsmiNollie = New ToolStripMenuItem()
        tsmiMentaL = New ToolStripMenuItem()
        tsmiBuy = New ToolStripMenuItem()
        nslblPosition = New NSLabel()
        NsSeperator1 = New NSSeperator()
        txtName = New NSTextBox()
        lblVendor = New NSLabel()
        numWidth = New NSNumericUpDown()
        txtProduct = New NSTextBox()
        txtLedCount = New NSTextBox()
        txtBrand = New NSTextBox()
        numHeight = New NSNumericUpDown()
        lblProduct = New NSLabel()
        lblLedCount = New NSLabel()
        lblName = New NSLabel()
        lblSize = New NSLabel()
        cmbType = New NSComboBox()
        lblType = New NSLabel()
        SplitContainer1 = New SplitContainer()
        Timer1 = New Timer(components)
        NsTheme1 = New NSTheme()
        btnMin = New NSControlButton()
        btnMax = New NSControlButton()
        btnClose = New NSControlButton()
        RightPanel.SuspendLayout()
        tlpImageControls.SuspendLayout()
        gbImage.SuspendLayout()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        gbControls.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        msMainMenu.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RightPanel
        ' 
        RightPanel.Controls.Add(txtWebImageUrl)
        RightPanel.Controls.Add(lblWebImage)
        RightPanel.Controls.Add(tlpImageControls)
        RightPanel.Controls.Add(msMainMenu)
        RightPanel.Controls.Add(nslblPosition)
        RightPanel.Controls.Add(NsSeperator1)
        RightPanel.Controls.Add(txtName)
        RightPanel.Controls.Add(lblVendor)
        RightPanel.Controls.Add(numWidth)
        RightPanel.Controls.Add(txtProduct)
        RightPanel.Controls.Add(txtLedCount)
        RightPanel.Controls.Add(txtBrand)
        RightPanel.Controls.Add(numHeight)
        RightPanel.Controls.Add(lblProduct)
        RightPanel.Controls.Add(lblLedCount)
        RightPanel.Controls.Add(lblName)
        RightPanel.Controls.Add(lblSize)
        RightPanel.Controls.Add(cmbType)
        RightPanel.Controls.Add(lblType)
        RightPanel.Dock = DockStyle.Fill
        RightPanel.Location = New Point(0, 0)
        RightPanel.Name = "RightPanel"
        RightPanel.Padding = New Padding(3)
        RightPanel.Size = New Size(312, 687)
        RightPanel.TabIndex = 0
        ' 
        ' txtWebImageUrl
        ' 
        txtWebImageUrl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtWebImageUrl.Location = New Point(86, 210)
        txtWebImageUrl.MaxLength = 32767
        txtWebImageUrl.Multiline = False
        txtWebImageUrl.Name = "txtWebImageUrl"
        txtWebImageUrl.ReadOnly = False
        txtWebImageUrl.Size = New Size(220, 24)
        txtWebImageUrl.TabIndex = 8
        txtWebImageUrl.TextAlign = HorizontalAlignment.Left
        txtWebImageUrl.UseSystemPasswordChar = False
        ' 
        ' lblWebImage
        ' 
        lblWebImage.Font = New Font("Segoe UI", 9F)
        lblWebImage.ForeColor = Color.White
        lblWebImage.Location = New Point(6, 210)
        lblWebImage.Name = "lblWebImage"
        lblWebImage.Size = New Size(74, 24)
        lblWebImage.TabIndex = 25
        lblWebImage.Text = "Web Image"
        lblWebImage.Value1 = "Image URL"
        lblWebImage.Value2 = ""
        ' 
        ' tlpImageControls
        ' 
        tlpImageControls.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tlpImageControls.ColumnCount = 2
        tlpImageControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpImageControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpImageControls.Controls.Add(gbImage, 0, 0)
        tlpImageControls.Controls.Add(gbControls, 1, 0)
        tlpImageControls.Location = New Point(6, 257)
        tlpImageControls.Name = "tlpImageControls"
        tlpImageControls.RowCount = 1
        tlpImageControls.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        tlpImageControls.Size = New Size(300, 201)
        tlpImageControls.TabIndex = 23
        ' 
        ' gbImage
        ' 
        gbImage.Controls.Add(pbImage)
        gbImage.Controls.Add(btnChangeImage)
        gbImage.Dock = DockStyle.Fill
        gbImage.DrawSeperator = True
        gbImage.Location = New Point(3, 3)
        gbImage.Name = "gbImage"
        gbImage.Padding = New Padding(3, 31, 3, 3)
        gbImage.Size = New Size(144, 195)
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
        pbImage.Size = New Size(138, 138)
        pbImage.SizeMode = PictureBoxSizeMode.Zoom
        pbImage.TabIndex = 13
        pbImage.TabStop = False
        ' 
        ' btnChangeImage
        ' 
        btnChangeImage.Dock = DockStyle.Bottom
        btnChangeImage.Location = New Point(3, 169)
        btnChangeImage.Name = "btnChangeImage"
        btnChangeImage.Size = New Size(138, 23)
        btnChangeImage.TabIndex = 1
        btnChangeImage.Text = "Select Image"
        ' 
        ' gbControls
        ' 
        gbControls.Controls.Add(TableLayoutPanel1)
        gbControls.Controls.Add(btnAutoResize)
        gbControls.Dock = DockStyle.Fill
        gbControls.DrawSeperator = True
        gbControls.Location = New Point(153, 3)
        gbControls.Name = "gbControls"
        gbControls.Padding = New Padding(3, 31, 3, 3)
        gbControls.Size = New Size(144, 195)
        gbControls.SubTitle = ""
        gbControls.TabIndex = 9
        gbControls.Title = "Controls"
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 3
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Controls.Add(btnUp, 1, 0)
        TableLayoutPanel1.Controls.Add(btnLeft, 0, 1)
        TableLayoutPanel1.Controls.Add(btnRight, 2, 1)
        TableLayoutPanel1.Controls.Add(btnDown, 1, 2)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(3, 31)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 3
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.3333321F))
        TableLayoutPanel1.Size = New Size(138, 138)
        TableLayoutPanel1.TabIndex = 0
        ' 
        ' btnUp
        ' 
        btnUp.Dock = DockStyle.Fill
        btnUp.Font = New Font("Marlett", 11F)
        btnUp.Location = New Point(49, 3)
        btnUp.Name = "btnUp"
        btnUp.Size = New Size(40, 40)
        btnUp.TabIndex = 0
        btnUp.Text = "5"
        ' 
        ' btnLeft
        ' 
        btnLeft.Dock = DockStyle.Fill
        btnLeft.Font = New Font("Marlett", 11F)
        btnLeft.Location = New Point(3, 49)
        btnLeft.Name = "btnLeft"
        btnLeft.Size = New Size(40, 40)
        btnLeft.TabIndex = 1
        btnLeft.Text = "3"
        ' 
        ' btnRight
        ' 
        btnRight.Dock = DockStyle.Fill
        btnRight.Font = New Font("Marlett", 11F)
        btnRight.Location = New Point(95, 49)
        btnRight.Name = "btnRight"
        btnRight.Size = New Size(40, 40)
        btnRight.TabIndex = 2
        btnRight.Text = "4"
        ' 
        ' btnDown
        ' 
        btnDown.Dock = DockStyle.Fill
        btnDown.Font = New Font("Marlett", 11F)
        btnDown.Location = New Point(49, 95)
        btnDown.Name = "btnDown"
        btnDown.Size = New Size(40, 40)
        btnDown.TabIndex = 3
        btnDown.Text = "6"
        ' 
        ' btnAutoResize
        ' 
        btnAutoResize.Dock = DockStyle.Bottom
        btnAutoResize.Location = New Point(3, 169)
        btnAutoResize.Name = "btnAutoResize"
        btnAutoResize.Size = New Size(138, 23)
        btnAutoResize.TabIndex = 2
        btnAutoResize.Text = "Auto Resize"
        ' 
        ' msMainMenu
        ' 
        msMainMenu.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        msMainMenu.ForeColor = Color.White
        msMainMenu.Items.AddRange(New ToolStripItem() {tsmiFile, tsmiSettings, tsmiHelp})
        msMainMenu.Location = New Point(3, 3)
        msMainMenu.Name = "msMainMenu"
        msMainMenu.Size = New Size(306, 24)
        msMainMenu.TabIndex = 22
        msMainMenu.Text = "NsMenuStrip1"
        ' 
        ' tsmiFile
        ' 
        tsmiFile.DropDownItems.AddRange(New ToolStripItem() {tsmiNew, tsmiOpen, tsmiSave, tsmiSaveAs, ToolStripSeparator3, tsmiImport, ToolStripSeparator1, tsmiExit})
        tsmiFile.Name = "tsmiFile"
        tsmiFile.Size = New Size(37, 20)
        tsmiFile.Text = "File"
        ' 
        ' tsmiNew
        ' 
        tsmiNew.ForeColor = Color.White
        tsmiNew.Name = "tsmiNew"
        tsmiNew.Size = New Size(225, 22)
        tsmiNew.Text = "New"
        ' 
        ' tsmiOpen
        ' 
        tsmiOpen.ForeColor = Color.White
        tsmiOpen.Name = "tsmiOpen"
        tsmiOpen.Size = New Size(225, 22)
        tsmiOpen.Text = "Open"
        ' 
        ' tsmiSave
        ' 
        tsmiSave.ForeColor = Color.White
        tsmiSave.Name = "tsmiSave"
        tsmiSave.Size = New Size(225, 22)
        tsmiSave.Text = "Save"
        ' 
        ' tsmiSaveAs
        ' 
        tsmiSaveAs.ForeColor = Color.White
        tsmiSaveAs.Name = "tsmiSaveAs"
        tsmiSaveAs.Size = New Size(225, 22)
        tsmiSaveAs.Text = "Save As.."
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(222, 6)
        ' 
        ' tsmiImport
        ' 
        tsmiImport.ForeColor = Color.White
        tsmiImport.Name = "tsmiImport"
        tsmiImport.Size = New Size(225, 22)
        tsmiImport.Text = "Import OpenRGB Visual Map"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.ForeColor = Color.White
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(222, 6)
        ' 
        ' tsmiExit
        ' 
        tsmiExit.ForeColor = Color.White
        tsmiExit.Name = "tsmiExit"
        tsmiExit.Size = New Size(225, 22)
        tsmiExit.Text = "Exit"
        ' 
        ' tsmiSettings
        ' 
        tsmiSettings.Name = "tsmiSettings"
        tsmiSettings.Size = New Size(61, 20)
        tsmiSettings.Text = "Settings"
        ' 
        ' tsmiHelp
        ' 
        tsmiHelp.DropDownItems.AddRange(New ToolStripItem() {tsmiControls, ToolStripSeparator2, tsmiSRGB, tsmiNollie, tsmiMentaL, tsmiBuy})
        tsmiHelp.Name = "tsmiHelp"
        tsmiHelp.Size = New Size(44, 20)
        tsmiHelp.Text = "Help"
        ' 
        ' tsmiControls
        ' 
        tsmiControls.ForeColor = Color.White
        tsmiControls.Name = "tsmiControls"
        tsmiControls.Size = New Size(227, 22)
        tsmiControls.Text = "Controls"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.ForeColor = Color.White
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(224, 6)
        ' 
        ' tsmiSRGB
        ' 
        tsmiSRGB.ForeColor = Color.White
        tsmiSRGB.Name = "tsmiSRGB"
        tsmiSRGB.Size = New Size(227, 22)
        tsmiSRGB.Text = "Visit SignalRGB Website"
        ' 
        ' tsmiNollie
        ' 
        tsmiNollie.ForeColor = Color.White
        tsmiNollie.Name = "tsmiNollie"
        tsmiNollie.Size = New Size(227, 22)
        tsmiNollie.Text = "Visit Nollie Website"
        ' 
        ' tsmiMentaL
        ' 
        tsmiMentaL.ForeColor = Color.White
        tsmiMentaL.Name = "tsmiMentaL"
        tsmiMentaL.Size = New Size(227, 22)
        tsmiMentaL.Text = "Visit I'm Not MentaL Website"
        ' 
        ' tsmiBuy
        ' 
        tsmiBuy.ForeColor = Color.White
        tsmiBuy.Name = "tsmiBuy"
        tsmiBuy.Size = New Size(227, 22)
        tsmiBuy.Text = "Buy Nollie32"
        ' 
        ' nslblPosition
        ' 
        nslblPosition.Dock = DockStyle.Bottom
        nslblPosition.Font = New Font("Segoe UI", 9F)
        nslblPosition.Location = New Point(3, 661)
        nslblPosition.Name = "nslblPosition"
        nslblPosition.Size = New Size(306, 23)
        nslblPosition.TabIndex = 21
        nslblPosition.Text = "NsLabel1"
        nslblPosition.Value1 = "Position: 0, 0"
        nslblPosition.Value2 = ""
        ' 
        ' NsSeperator1
        ' 
        NsSeperator1.Location = New Point(6, 240)
        NsSeperator1.Name = "NsSeperator1"
        NsSeperator1.Size = New Size(300, 11)
        NsSeperator1.TabIndex = 19
        NsSeperator1.Text = "NsSeperator1"
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtName.Location = New Point(86, 30)
        txtName.MaxLength = 32767
        txtName.Multiline = False
        txtName.Name = "txtName"
        txtName.ReadOnly = False
        txtName.Size = New Size(220, 24)
        txtName.TabIndex = 1
        txtName.TextAlign = HorizontalAlignment.Left
        txtName.UseSystemPasswordChar = False
        ' 
        ' lblVendor
        ' 
        lblVendor.Font = New Font("Segoe UI", 9F)
        lblVendor.ForeColor = Color.White
        lblVendor.Location = New Point(6, 60)
        lblVendor.Name = "lblVendor"
        lblVendor.Size = New Size(74, 24)
        lblVendor.TabIndex = 8
        lblVendor.Text = "Vendor"
        lblVendor.Value1 = "Brand"
        lblVendor.Value2 = ""
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numWidth.DecimalPlaces = 0
        numWidth.Increment = 1
        numWidth.InterceptArrowKeys = True
        numWidth.Location = New Point(86, 150)
        numWidth.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.ReadOnly = False
        numWidth.Size = New Size(107, 24)
        numWidth.TabIndex = 5
        numWidth.TextAlign = HorizontalAlignment.Right
        numWidth.ThousandsSeparator = False
        numWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' txtProduct
        ' 
        txtProduct.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtProduct.Location = New Point(86, 90)
        txtProduct.MaxLength = 32767
        txtProduct.Multiline = False
        txtProduct.Name = "txtProduct"
        txtProduct.ReadOnly = False
        txtProduct.Size = New Size(220, 24)
        txtProduct.TabIndex = 3
        txtProduct.TextAlign = HorizontalAlignment.Left
        txtProduct.UseSystemPasswordChar = False
        ' 
        ' txtLedCount
        ' 
        txtLedCount.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLedCount.Location = New Point(86, 180)
        txtLedCount.MaxLength = 32767
        txtLedCount.Multiline = False
        txtLedCount.Name = "txtLedCount"
        txtLedCount.ReadOnly = True
        txtLedCount.Size = New Size(220, 24)
        txtLedCount.TabIndex = 7
        txtLedCount.Text = "0"
        txtLedCount.TextAlign = HorizontalAlignment.Right
        txtLedCount.UseSystemPasswordChar = False
        ' 
        ' txtBrand
        ' 
        txtBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBrand.Location = New Point(86, 60)
        txtBrand.MaxLength = 32767
        txtBrand.Multiline = False
        txtBrand.Name = "txtBrand"
        txtBrand.ReadOnly = False
        txtBrand.Size = New Size(220, 24)
        txtBrand.TabIndex = 2
        txtBrand.TextAlign = HorizontalAlignment.Left
        txtBrand.UseSystemPasswordChar = False
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numHeight.DecimalPlaces = 0
        numHeight.Increment = 1
        numHeight.InterceptArrowKeys = True
        numHeight.Location = New Point(199, 150)
        numHeight.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.ReadOnly = False
        numHeight.Size = New Size(107, 24)
        numHeight.TabIndex = 6
        numHeight.TextAlign = HorizontalAlignment.Right
        numHeight.ThousandsSeparator = False
        numHeight.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' lblProduct
        ' 
        lblProduct.Font = New Font("Segoe UI", 9F)
        lblProduct.ForeColor = Color.White
        lblProduct.Location = New Point(6, 90)
        lblProduct.Name = "lblProduct"
        lblProduct.Size = New Size(74, 24)
        lblProduct.TabIndex = 10
        lblProduct.Text = "Product"
        lblProduct.Value1 = "Product"
        lblProduct.Value2 = ""
        ' 
        ' lblLedCount
        ' 
        lblLedCount.Font = New Font("Segoe UI", 9F)
        lblLedCount.ForeColor = Color.White
        lblLedCount.Location = New Point(6, 180)
        lblLedCount.Name = "lblLedCount"
        lblLedCount.Size = New Size(74, 24)
        lblLedCount.TabIndex = 17
        lblLedCount.Text = "LED Count"
        lblLedCount.Value1 = "LED Count"
        lblLedCount.Value2 = ""
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 9F)
        lblName.ForeColor = Color.White
        lblName.Location = New Point(6, 30)
        lblName.Name = "lblName"
        lblName.Size = New Size(74, 24)
        lblName.TabIndex = 6
        lblName.Text = "Name"
        lblName.Value1 = "Name"
        lblName.Value2 = ""
        ' 
        ' lblSize
        ' 
        lblSize.Font = New Font("Segoe UI", 9F)
        lblSize.ForeColor = Color.White
        lblSize.Location = New Point(6, 150)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(74, 24)
        lblSize.TabIndex = 3
        lblSize.Text = "Size"
        lblSize.Value1 = "Size"
        lblSize.Value2 = ""
        ' 
        ' cmbType
        ' 
        cmbType.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cmbType.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbType.DrawMode = DrawMode.OwnerDrawFixed
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbType.ForeColor = Color.White
        cmbType.FormattingEnabled = True
        cmbType.Location = New Point(86, 120)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(220, 24)
        cmbType.TabIndex = 4
        ' 
        ' lblType
        ' 
        lblType.Font = New Font("Segoe UI", 9F)
        lblType.ForeColor = Color.White
        lblType.Location = New Point(6, 120)
        lblType.Name = "lblType"
        lblType.Size = New Size(74, 24)
        lblType.TabIndex = 12
        lblType.Text = "Type"
        lblType.Value1 = "Type"
        lblType.Value2 = ""
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.IsSplitterFixed = True
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
        SplitContainer1.SplitterDistance = 680
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
        MainMenuStrip = msMainMenu
        MinimumSize = New Size(1000, 700)
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Untitled - Nollie x SignalRGB Custom Component Editor"
        WindowState = FormWindowState.Maximized
        RightPanel.ResumeLayout(False)
        RightPanel.PerformLayout()
        tlpImageControls.ResumeLayout(False)
        gbImage.ResumeLayout(False)
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        gbControls.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        msMainMenu.ResumeLayout(False)
        msMainMenu.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents RightPanel As Panel
    Friend WithEvents numWidth As NSNumericUpDown
    Friend WithEvents lblName As NSLabel
    Friend WithEvents txtName As NSTextBox
    Friend WithEvents lblHeight As NSLabel
    Friend WithEvents lblSize As NSLabel
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
    Friend WithEvents lblLedCount As NSLabel
    Friend WithEvents txtLedCount As NSTextBox
    Friend WithEvents btnChangeImage As NSButton
    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents btnMin As NSControlButton
    Friend WithEvents btnMax As NSControlButton
    Friend WithEvents NsSeperator1 As NSSeperator
    Friend WithEvents gbImage As NSGroupBox
    Friend WithEvents nslblPosition As NSLabel
    Friend WithEvents gbControls As NSGroupBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnUp As NSButton
    Friend WithEvents btnLeft As NSButton
    Friend WithEvents btnRight As NSButton
    Friend WithEvents btnDown As NSButton
    Friend WithEvents msMainMenu As NSMenuStrip
    Friend WithEvents tsmiFile As ToolStripMenuItem
    Friend WithEvents tsmiSettings As ToolStripMenuItem
    Friend WithEvents tsmiHelp As ToolStripMenuItem
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiOpen As ToolStripMenuItem
    Friend WithEvents tsmiSave As ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiExit As ToolStripMenuItem
    Friend WithEvents tsmiControls As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiSRGB As ToolStripMenuItem
    Friend WithEvents tsmiNollie As ToolStripMenuItem
    Friend WithEvents tsmiMentaL As ToolStripMenuItem
    Friend WithEvents tsmiBuy As ToolStripMenuItem
    Friend WithEvents tlpImageControls As TableLayoutPanel
    Friend WithEvents btnAutoResize As NSButton
    Friend WithEvents txtWebImageUrl As NSTextBox
    Friend WithEvents lblWebImage As NSLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsmiImport As ToolStripMenuItem

End Class
