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
        gbTools = New NSGroupBox()
        rbToolResizeGI = New NSImgRadioButton()
        rbToolPlaceLED = New NSImgRadioButton()
        rbToolSelect = New NSImgRadioButton()
        txtWebImageUrl = New NSTextBox()
        lblWebImage = New NSLabel()
        tlpImageControls = New TableLayoutPanel()
        gbImage = New NSGroupBox()
        tlpImage = New TableLayoutPanel()
        btnChangeImage = New NSButton()
        pbImage = New PictureBox()
        gbControls = New NSGroupBox()
        tlpControls = New TableLayoutPanel()
        btnAutoResize = New NSButton()
        btnFlipUpDown = New NSImgButton()
        btnFlipLeftRight = New NSImgButton()
        btnHideLed = New NSImgButton()
        btnRotateLeft = New NSImgButton()
        btnUp = New NSImgButton()
        btnLeft = New NSImgButton()
        btnRight = New NSImgButton()
        btnDown = New NSImgButton()
        btnRotateRight = New NSImgButton()
        msMainMenu = New NSMenuStrip()
        tsmiFile = New ToolStripMenuItem()
        tsmiNew = New ToolStripMenuItem()
        tsmiOpen = New ToolStripMenuItem()
        tsmiSave = New ToolStripMenuItem()
        tsmiSaveSRGB = New ToolStripMenuItem()
        tsmiSaveNRGB = New ToolStripMenuItem()
        tsmiSaveAs = New ToolStripMenuItem()
        tsmiSaveAsSRGB = New ToolStripMenuItem()
        tsmiSaveAsNRGB = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        tsmiImport = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiExit = New ToolStripMenuItem()
        tsmiSettings = New ToolStripMenuItem()
        tsmiHelp = New ToolStripMenuItem()
        tsmiSRGB = New ToolStripMenuItem()
        tsmiNollie = New ToolStripMenuItem()
        tsmiMentaL = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
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
        gbTools.SuspendLayout()
        tlpImageControls.SuspendLayout()
        gbImage.SuspendLayout()
        tlpImage.SuspendLayout()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        gbControls.SuspendLayout()
        tlpControls.SuspendLayout()
        msMainMenu.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RightPanel
        ' 
        RightPanel.Controls.Add(gbTools)
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
        RightPanel.Size = New Size(312, 663)
        RightPanel.TabIndex = 0
        ' 
        ' gbTools
        ' 
        gbTools.Controls.Add(rbToolResizeGI)
        gbTools.Controls.Add(rbToolPlaceLED)
        gbTools.Controls.Add(rbToolSelect)
        gbTools.DrawSeperator = True
        gbTools.Location = New Point(6, 479)
        gbTools.Name = "gbTools"
        gbTools.Padding = New Padding(3, 31, 3, 3)
        gbTools.Size = New Size(300, 144)
        gbTools.SubTitle = ""
        gbTools.TabIndex = 10
        gbTools.Text = "NsGroupBox1"
        gbTools.Title = "Tools"
        ' 
        ' rbToolResizeGI
        ' 
        rbToolResizeGI.BackgroundImage = My.Resources.Resources.image_area_custom
        rbToolResizeGI.Checked = False
        rbToolResizeGI.Location = New Point(6, 106)
        rbToolResizeGI.Name = "rbToolResizeGI"
        rbToolResizeGI.Padding = New Padding(3)
        rbToolResizeGI.Size = New Size(288, 30)
        rbToolResizeGI.TabIndex = 2
        rbToolResizeGI.Text = "Resize Guide Image"
        ' 
        ' rbToolPlaceLED
        ' 
        rbToolPlaceLED.BackgroundImage = My.Resources.Resources.led_variant_outline_custom
        rbToolPlaceLED.Checked = False
        rbToolPlaceLED.Location = New Point(6, 70)
        rbToolPlaceLED.Name = "rbToolPlaceLED"
        rbToolPlaceLED.Padding = New Padding(3)
        rbToolPlaceLED.Size = New Size(288, 30)
        rbToolPlaceLED.TabIndex = 1
        rbToolPlaceLED.Text = "Place LED Tool"
        ' 
        ' rbToolSelect
        ' 
        rbToolSelect.BackgroundImage = My.Resources.Resources.selection_drag_custom
        rbToolSelect.Checked = True
        rbToolSelect.Location = New Point(6, 34)
        rbToolSelect.Name = "rbToolSelect"
        rbToolSelect.Padding = New Padding(3)
        rbToolSelect.Size = New Size(288, 30)
        rbToolSelect.TabIndex = 0
        rbToolSelect.Text = "Select Tool"
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
        lblWebImage.Font = New Font("Segoe UI", 9.0F)
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
        tlpImageControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpImageControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpImageControls.Controls.Add(gbImage, 0, 0)
        tlpImageControls.Controls.Add(gbControls, 1, 0)
        tlpImageControls.Location = New Point(3, 257)
        tlpImageControls.Name = "tlpImageControls"
        tlpImageControls.RowCount = 1
        tlpImageControls.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
        tlpImageControls.Size = New Size(306, 216)
        tlpImageControls.TabIndex = 9
        ' 
        ' gbImage
        ' 
        gbImage.Controls.Add(tlpImage)
        gbImage.Dock = DockStyle.Fill
        gbImage.DrawSeperator = True
        gbImage.Location = New Point(3, 3)
        gbImage.Name = "gbImage"
        gbImage.Padding = New Padding(3, 31, 3, 3)
        gbImage.Size = New Size(147, 210)
        gbImage.SubTitle = ""
        gbImage.TabIndex = 0
        gbImage.Title = "Component Image"
        ' 
        ' tlpImage
        ' 
        tlpImage.ColumnCount = 1
        tlpImage.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpImage.Controls.Add(btnChangeImage, 0, 1)
        tlpImage.Controls.Add(pbImage, 0, 0)
        tlpImage.Dock = DockStyle.Fill
        tlpImage.Location = New Point(3, 31)
        tlpImage.Name = "tlpImage"
        tlpImage.RowCount = 2
        tlpImage.RowStyles.Add(New RowStyle(SizeType.Percent, 81.0F))
        tlpImage.RowStyles.Add(New RowStyle(SizeType.Percent, 19.0F))
        tlpImage.Size = New Size(141, 176)
        tlpImage.TabIndex = 0
        ' 
        ' btnChangeImage
        ' 
        btnChangeImage.Dock = DockStyle.Fill
        btnChangeImage.Location = New Point(3, 145)
        btnChangeImage.Name = "btnChangeImage"
        btnChangeImage.Size = New Size(135, 28)
        btnChangeImage.TabIndex = 0
        btnChangeImage.Text = "Select Image"
        ' 
        ' pbImage
        ' 
        pbImage.Dock = DockStyle.Fill
        pbImage.Image = My.Resources.Resources._1
        pbImage.Location = New Point(3, 3)
        pbImage.Name = "pbImage"
        pbImage.Size = New Size(135, 136)
        pbImage.SizeMode = PictureBoxSizeMode.Zoom
        pbImage.TabIndex = 13
        pbImage.TabStop = False
        ' 
        ' gbControls
        ' 
        gbControls.Controls.Add(tlpControls)
        gbControls.Dock = DockStyle.Fill
        gbControls.DrawSeperator = True
        gbControls.Location = New Point(156, 3)
        gbControls.Name = "gbControls"
        gbControls.Padding = New Padding(3, 31, 3, 3)
        gbControls.Size = New Size(147, 210)
        gbControls.SubTitle = ""
        gbControls.TabIndex = 0
        gbControls.Title = "Controls"
        ' 
        ' tlpControls
        ' 
        tlpControls.ColumnCount = 3
        tlpControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlpControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlpControls.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.3333321F))
        tlpControls.Controls.Add(btnAutoResize, 0, 3)
        tlpControls.Controls.Add(btnFlipUpDown, 2, 2)
        tlpControls.Controls.Add(btnFlipLeftRight, 0, 2)
        tlpControls.Controls.Add(btnHideLed, 1, 1)
        tlpControls.Controls.Add(btnRotateLeft, 0, 0)
        tlpControls.Controls.Add(btnUp, 1, 0)
        tlpControls.Controls.Add(btnLeft, 0, 1)
        tlpControls.Controls.Add(btnRight, 2, 1)
        tlpControls.Controls.Add(btnDown, 1, 2)
        tlpControls.Controls.Add(btnRotateRight, 2, 0)
        tlpControls.Dock = DockStyle.Fill
        tlpControls.Location = New Point(3, 31)
        tlpControls.Name = "tlpControls"
        tlpControls.RowCount = 4
        tlpControls.RowStyles.Add(New RowStyle(SizeType.Percent, 27.0F))
        tlpControls.RowStyles.Add(New RowStyle(SizeType.Percent, 27.0F))
        tlpControls.RowStyles.Add(New RowStyle(SizeType.Percent, 27.0F))
        tlpControls.RowStyles.Add(New RowStyle(SizeType.Percent, 19.0F))
        tlpControls.Size = New Size(141, 176)
        tlpControls.TabIndex = 0
        ' 
        ' btnAutoResize
        ' 
        tlpControls.SetColumnSpan(btnAutoResize, 3)
        btnAutoResize.Dock = DockStyle.Fill
        btnAutoResize.Location = New Point(3, 144)
        btnAutoResize.Name = "btnAutoResize"
        btnAutoResize.Size = New Size(135, 29)
        btnAutoResize.TabIndex = 6
        btnAutoResize.Text = "Auto Resize"
        ' 
        ' btnFlipUpDown
        ' 
        btnFlipUpDown.BackgroundImage = My.Resources.Resources.flip_vertical_custom1
        btnFlipUpDown.Dock = DockStyle.Fill
        btnFlipUpDown.Font = New Font("Segoe UI", 21.0F)
        btnFlipUpDown.Location = New Point(97, 97)
        btnFlipUpDown.Name = "btnFlipUpDown"
        btnFlipUpDown.Padding = New Padding(10)
        btnFlipUpDown.Size = New Size(41, 41)
        btnFlipUpDown.TabIndex = 5
        btnFlipUpDown.Text = "↺"
        ' 
        ' btnFlipLeftRight
        ' 
        btnFlipLeftRight.BackgroundImage = My.Resources.Resources.flip_horizontal_custom1
        btnFlipLeftRight.Dock = DockStyle.Fill
        btnFlipLeftRight.Font = New Font("Segoe UI", 21.0F)
        btnFlipLeftRight.Location = New Point(3, 97)
        btnFlipLeftRight.Name = "btnFlipLeftRight"
        btnFlipLeftRight.Padding = New Padding(10)
        btnFlipLeftRight.Size = New Size(41, 41)
        btnFlipLeftRight.TabIndex = 4
        btnFlipLeftRight.Text = "↺"
        ' 
        ' btnHideLed
        ' 
        btnHideLed.BackgroundImage = My.Resources.Resources.eye_off_outline_custom
        btnHideLed.Dock = DockStyle.Fill
        btnHideLed.Font = New Font("Segoe UI", 26.0F)
        btnHideLed.Location = New Point(50, 50)
        btnHideLed.Name = "btnHideLed"
        btnHideLed.Padding = New Padding(10)
        btnHideLed.Size = New Size(41, 41)
        btnHideLed.TabIndex = 3
        btnHideLed.Text = "⊘"
        ' 
        ' btnRotateLeft
        ' 
        btnRotateLeft.BackgroundImage = My.Resources.Resources.rotate_left_custom
        btnRotateLeft.Dock = DockStyle.Fill
        btnRotateLeft.Font = New Font("Segoe UI", 21.0F)
        btnRotateLeft.Location = New Point(3, 3)
        btnRotateLeft.Name = "btnRotateLeft"
        btnRotateLeft.Padding = New Padding(10)
        btnRotateLeft.Size = New Size(41, 41)
        btnRotateLeft.TabIndex = 2
        btnRotateLeft.Text = "↺"
        ' 
        ' btnUp
        ' 
        btnUp.BackgroundImage = My.Resources.Resources.arrow_up_custom
        btnUp.Dock = DockStyle.Fill
        btnUp.Font = New Font("Marlett", 19.0F)
        btnUp.Location = New Point(50, 3)
        btnUp.Name = "btnUp"
        btnUp.Padding = New Padding(10)
        btnUp.Size = New Size(41, 41)
        btnUp.TabIndex = 0
        btnUp.Text = "5"
        ' 
        ' btnLeft
        ' 
        btnLeft.BackgroundImage = My.Resources.Resources.arrow_left_custom
        btnLeft.Dock = DockStyle.Fill
        btnLeft.Font = New Font("Marlett", 19.0F)
        btnLeft.Location = New Point(3, 50)
        btnLeft.Name = "btnLeft"
        btnLeft.Padding = New Padding(10)
        btnLeft.Size = New Size(41, 41)
        btnLeft.TabIndex = 0
        btnLeft.Text = "3"
        ' 
        ' btnRight
        ' 
        btnRight.BackgroundImage = My.Resources.Resources.arrow_right_custom
        btnRight.Dock = DockStyle.Fill
        btnRight.Font = New Font("Marlett", 19.0F)
        btnRight.Location = New Point(97, 50)
        btnRight.Name = "btnRight"
        btnRight.Padding = New Padding(10)
        btnRight.Size = New Size(41, 41)
        btnRight.TabIndex = 0
        btnRight.Text = "4"
        ' 
        ' btnDown
        ' 
        btnDown.BackgroundImage = My.Resources.Resources.arrow_down_custom
        btnDown.Dock = DockStyle.Fill
        btnDown.Font = New Font("Marlett", 19.0F)
        btnDown.Location = New Point(50, 97)
        btnDown.Name = "btnDown"
        btnDown.Padding = New Padding(10)
        btnDown.Size = New Size(41, 41)
        btnDown.TabIndex = 0
        btnDown.Text = "6"
        ' 
        ' btnRotateRight
        ' 
        btnRotateRight.BackgroundImage = My.Resources.Resources.rotate_right_custom
        btnRotateRight.Dock = DockStyle.Fill
        btnRotateRight.Font = New Font("Segoe UI", 21.0F)
        btnRotateRight.Location = New Point(97, 3)
        btnRotateRight.Name = "btnRotateRight"
        btnRotateRight.Padding = New Padding(10)
        btnRotateRight.Size = New Size(41, 41)
        btnRotateRight.TabIndex = 1
        btnRotateRight.Text = "↻"
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
        tsmiNew.Image = My.Resources.Resources.file_plus_outline_custom
        tsmiNew.Name = "tsmiNew"
        tsmiNew.Size = New Size(225, 22)
        tsmiNew.Text = "New"
        ' 
        ' tsmiOpen
        ' 
        tsmiOpen.ForeColor = Color.White
        tsmiOpen.Image = My.Resources.Resources.folder_open_outline_custom
        tsmiOpen.Name = "tsmiOpen"
        tsmiOpen.Size = New Size(225, 22)
        tsmiOpen.Text = "Open"
        ' 
        ' tsmiSave
        ' 
        tsmiSave.DropDownItems.AddRange(New ToolStripItem() {tsmiSaveSRGB, tsmiSaveNRGB})
        tsmiSave.ForeColor = Color.White
        tsmiSave.Image = My.Resources.Resources.content_save_outline_custom
        tsmiSave.Name = "tsmiSave"
        tsmiSave.Size = New Size(225, 22)
        tsmiSave.Text = "Save"
        ' 
        ' tsmiSaveSRGB
        ' 
        tsmiSaveSRGB.ForeColor = Color.White
        tsmiSaveSRGB.Name = "tsmiSaveSRGB"
        tsmiSaveSRGB.Size = New Size(195, 22)
        tsmiSaveSRGB.Text = "SignalRGB Component"
        ' 
        ' tsmiSaveNRGB
        ' 
        tsmiSaveNRGB.ForeColor = Color.White
        tsmiSaveNRGB.Name = "tsmiSaveNRGB"
        tsmiSaveNRGB.Size = New Size(195, 22)
        tsmiSaveNRGB.Text = "NollieRGB VMAP"
        ' 
        ' tsmiSaveAs
        ' 
        tsmiSaveAs.DropDownItems.AddRange(New ToolStripItem() {tsmiSaveAsSRGB, tsmiSaveAsNRGB})
        tsmiSaveAs.ForeColor = Color.White
        tsmiSaveAs.Image = My.Resources.Resources.content_save_move_outline_custom
        tsmiSaveAs.Name = "tsmiSaveAs"
        tsmiSaveAs.Size = New Size(225, 22)
        tsmiSaveAs.Text = "Save As.."
        ' 
        ' tsmiSaveAsSRGB
        ' 
        tsmiSaveAsSRGB.ForeColor = Color.White
        tsmiSaveAsSRGB.Name = "tsmiSaveAsSRGB"
        tsmiSaveAsSRGB.Size = New Size(195, 22)
        tsmiSaveAsSRGB.Text = "SignalRGB Component"
        ' 
        ' tsmiSaveAsNRGB
        ' 
        tsmiSaveAsNRGB.ForeColor = Color.White
        tsmiSaveAsNRGB.Name = "tsmiSaveAsNRGB"
        tsmiSaveAsNRGB.Size = New Size(195, 22)
        tsmiSaveAsNRGB.Text = "NollieRGB VMAP"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(222, 6)
        ' 
        ' tsmiImport
        ' 
        tsmiImport.ForeColor = Color.White
        tsmiImport.Image = My.Resources.Resources.openrgb_custom
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
        tsmiExit.Image = My.Resources.Resources.exit_to_app_custom
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
        tsmiHelp.DropDownItems.AddRange(New ToolStripItem() {tsmiSRGB, tsmiNollie, tsmiMentaL, ToolStripSeparator2, tsmiBuy})
        tsmiHelp.Name = "tsmiHelp"
        tsmiHelp.Size = New Size(44, 20)
        tsmiHelp.Text = "Help"
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
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.ForeColor = Color.White
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(224, 6)
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
        nslblPosition.Font = New Font("Segoe UI", 9.0F)
        nslblPosition.Location = New Point(3, 637)
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
        lblVendor.Font = New Font("Segoe UI", 9.0F)
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
        numWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
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
        numHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
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
        lblProduct.Font = New Font("Segoe UI", 9.0F)
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
        lblLedCount.Font = New Font("Segoe UI", 9.0F)
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
        lblName.Font = New Font("Segoe UI", 9.0F)
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
        lblSize.Font = New Font("Segoe UI", 9.0F)
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
        lblType.Font = New Font("Segoe UI", 9.0F)
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
        SplitContainer1.Size = New Size(996, 663)
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
        NsTheme1.Font = New Font("Segoe UI", 9.0F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.MinimumSize = New Size(1000, 700)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = True
        NsTheme1.Size = New Size(1008, 705)
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
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 705)
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
        gbTools.ResumeLayout(False)
        tlpImageControls.ResumeLayout(False)
        gbImage.ResumeLayout(False)
        tlpImage.ResumeLayout(False)
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        gbControls.ResumeLayout(False)
        tlpControls.ResumeLayout(False)
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
    Friend WithEvents tlpControls As TableLayoutPanel
    Friend WithEvents btnUp As NSImgButton
    Friend WithEvents btnLeft As NSImgButton
    Friend WithEvents btnRight As NSImgButton
    Friend WithEvents btnDown As NSImgButton
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
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiSRGB As ToolStripMenuItem
    Friend WithEvents tsmiNollie As ToolStripMenuItem
    Friend WithEvents tsmiMentaL As ToolStripMenuItem
    Friend WithEvents tsmiBuy As ToolStripMenuItem
    Friend WithEvents tlpImageControls As TableLayoutPanel
    Friend WithEvents txtWebImageUrl As NSTextBox
    Friend WithEvents lblWebImage As NSLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsmiImport As ToolStripMenuItem
    Friend WithEvents gbTools As NSGroupBox
    Friend WithEvents rbToolPlaceLED As NSImgRadioButton
    Friend WithEvents rbToolSelect As NSImgRadioButton
    Friend WithEvents rbToolResizeGI As NSImgRadioButton
    Friend WithEvents btnRotateRight As NSImgButton
    Friend WithEvents btnRotateLeft As NSImgButton
    Friend WithEvents btnHideLed As NSImgButton
    Friend WithEvents tsmiSaveSRGB As ToolStripMenuItem
    Friend WithEvents tsmiSaveNRGB As ToolStripMenuItem
    Friend WithEvents tsmiSaveAsSRGB As ToolStripMenuItem
    Friend WithEvents tsmiSaveAsNRGB As ToolStripMenuItem
    Friend WithEvents btnFlipLeftRight As NSImgButton
    Friend WithEvents btnFlipUpDown As NSImgButton
    Friend WithEvents btnAutoResize As NSButton
    Friend WithEvents tlpImage As TableLayoutPanel

End Class
