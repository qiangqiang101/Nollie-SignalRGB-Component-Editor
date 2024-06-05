<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

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
        btnChangeImage = New Button()
        txtLedCount = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        pbImage = New PictureBox()
        Label6 = New Label()
        cmbType = New ComboBox()
        Label5 = New Label()
        txtProduct = New TextBox()
        Label4 = New Label()
        txtBrand = New TextBox()
        Label3 = New Label()
        txtName = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        numHeight = New NumericUpDown()
        numWidth = New NumericUpDown()
        MenuStrip1 = New MenuStrip()
        tsmiFile = New ToolStripMenuItem()
        tsmiNew = New ToolStripMenuItem()
        tsmiOpen = New ToolStripMenuItem()
        tsmiSave = New ToolStripMenuItem()
        tsmiSaveAs = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        tsmiHelp = New ToolStripMenuItem()
        tsmiControls = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiSRGB = New ToolStripMenuItem()
        tsmiNollie = New ToolStripMenuItem()
        tsmiMentaL = New ToolStripMenuItem()
        tsmiBuy = New ToolStripMenuItem()
        SplitContainer1 = New SplitContainer()
        Timer1 = New Timer(components)
        StatusStrip1 = New StatusStrip()
        tsslPosition = New ToolStripStatusLabel()
        RightPanel.SuspendLayout()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        CType(numHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numWidth, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RightPanel
        ' 
        RightPanel.BorderStyle = BorderStyle.FixedSingle
        RightPanel.Controls.Add(StatusStrip1)
        RightPanel.Controls.Add(btnChangeImage)
        RightPanel.Controls.Add(txtLedCount)
        RightPanel.Controls.Add(Label8)
        RightPanel.Controls.Add(Label7)
        RightPanel.Controls.Add(pbImage)
        RightPanel.Controls.Add(Label6)
        RightPanel.Controls.Add(cmbType)
        RightPanel.Controls.Add(Label5)
        RightPanel.Controls.Add(txtProduct)
        RightPanel.Controls.Add(Label4)
        RightPanel.Controls.Add(txtBrand)
        RightPanel.Controls.Add(Label3)
        RightPanel.Controls.Add(txtName)
        RightPanel.Controls.Add(Label2)
        RightPanel.Controls.Add(Label1)
        RightPanel.Controls.Add(numHeight)
        RightPanel.Controls.Add(numWidth)
        RightPanel.Controls.Add(MenuStrip1)
        RightPanel.Dock = DockStyle.Fill
        RightPanel.Location = New Point(0, 0)
        RightPanel.Name = "RightPanel"
        RightPanel.Size = New Size(275, 729)
        RightPanel.TabIndex = 0
        ' 
        ' btnChangeImage
        ' 
        btnChangeImage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btnChangeImage.Location = New Point(3, 509)
        btnChangeImage.Name = "btnChangeImage"
        btnChangeImage.Size = New Size(267, 23)
        btnChangeImage.TabIndex = 8
        btnChangeImage.Text = "Select Image"
        btnChangeImage.UseVisualStyleBackColor = True
        ' 
        ' txtLedCount
        ' 
        txtLedCount.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtLedCount.Location = New Point(75, 201)
        txtLedCount.Name = "txtLedCount"
        txtLedCount.ReadOnly = True
        txtLedCount.Size = New Size(187, 23)
        txtLedCount.TabIndex = 7
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(3, 203)
        Label8.Name = "Label8"
        Label8.Size = New Size(63, 15)
        Label8.TabIndex = 17
        Label8.Text = "LED Count"
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label7.BorderStyle = BorderStyle.Fixed3D
        Label7.Location = New Point(3, 231)
        Label7.Name = "Label7"
        Label7.Size = New Size(267, 2)
        Label7.TabIndex = 14
        ' 
        ' pbImage
        ' 
        pbImage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pbImage.BorderStyle = BorderStyle.FixedSingle
        pbImage.Image = My.Resources.Resources._1
        pbImage.Location = New Point(3, 236)
        pbImage.Name = "pbImage"
        pbImage.Size = New Size(267, 267)
        pbImage.SizeMode = PictureBoxSizeMode.Zoom
        pbImage.TabIndex = 13
        pbImage.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(3, 117)
        Label6.Name = "Label6"
        Label6.Size = New Size(31, 15)
        Label6.TabIndex = 12
        Label6.Text = "Type"
        ' 
        ' cmbType
        ' 
        cmbType.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbType.FormattingEnabled = True
        cmbType.Location = New Point(75, 114)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(187, 23)
        cmbType.TabIndex = 4
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(3, 88)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 15)
        Label5.TabIndex = 10
        Label5.Text = "Product"
        ' 
        ' txtProduct
        ' 
        txtProduct.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtProduct.Location = New Point(75, 85)
        txtProduct.Name = "txtProduct"
        txtProduct.Size = New Size(187, 23)
        txtProduct.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(3, 59)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 8
        Label4.Text = "Vendor"
        ' 
        ' txtBrand
        ' 
        txtBrand.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBrand.Location = New Point(75, 56)
        txtBrand.Name = "txtBrand"
        txtBrand.Size = New Size(187, 23)
        txtBrand.TabIndex = 2
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(3, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(39, 15)
        Label3.TabIndex = 6
        Label3.Text = "Name"
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtName.Location = New Point(75, 27)
        txtName.Name = "txtName"
        txtName.Size = New Size(187, 23)
        txtName.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(3, 174)
        Label2.Name = "Label2"
        Label2.Size = New Size(43, 15)
        Label2.TabIndex = 4
        Label2.Text = "Height"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 145)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 3
        Label1.Text = "Width"
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numHeight.Location = New Point(75, 172)
        numHeight.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.Size = New Size(187, 23)
        numHeight.TabIndex = 6
        numHeight.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numWidth.Location = New Point(75, 143)
        numWidth.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.Size = New Size(187, 23)
        numWidth.TabIndex = 5
        numWidth.Value = New Decimal(New Integer() {5, 0, 0, 0})
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {tsmiFile, tsmiHelp})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(273, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' tsmiFile
        ' 
        tsmiFile.DropDownItems.AddRange(New ToolStripItem() {tsmiNew, tsmiOpen, tsmiSave, tsmiSaveAs, ToolStripSeparator1, ExitToolStripMenuItem})
        tsmiFile.Name = "tsmiFile"
        tsmiFile.Size = New Size(37, 20)
        tsmiFile.Text = "File"
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
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.ShortcutKeys = Keys.Alt Or Keys.F4
        ExitToolStripMenuItem.Size = New Size(186, 22)
        ExitToolStripMenuItem.Text = "Exit"
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
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackColor = SystemColors.ControlDark
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(RightPanel)
        SplitContainer1.Size = New Size(1008, 729)
        SplitContainer1.SplitterDistance = 729
        SplitContainer1.TabIndex = 3
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {tsslPosition})
        StatusStrip1.Location = New Point(0, 705)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(273, 22)
        StatusStrip1.TabIndex = 18
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' tsslPosition
        ' 
        tsslPosition.Name = "tsslPosition"
        tsslPosition.Size = New Size(74, 17)
        tsslPosition.Text = "Position: 0, 0"
        ' 
        ' frmMain
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1008, 729)
        Controls.Add(SplitContainer1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Untitled - Nollie x SignalRGB Custom Component Editor"
        RightPanel.ResumeLayout(False)
        RightPanel.PerformLayout()
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        CType(numHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(numWidth, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents RightPanel As Panel
    Friend WithEvents numWidth As NumericUpDown
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents tsmiFile As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents numHeight As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProduct As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBrand As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label7 As Label
    Friend WithEvents pbImage As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiOpen As ToolStripMenuItem
    Friend WithEvents tsmiSave As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsmiHelp As ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents txtLedCount As TextBox
    Friend WithEvents btnChangeImage As Button
    Friend WithEvents tsmiControls As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiSRGB As ToolStripMenuItem
    Friend WithEvents tsmiNollie As ToolStripMenuItem
    Friend WithEvents tsmiMentaL As ToolStripMenuItem
    Friend WithEvents tsmiBuy As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslPosition As ToolStripStatusLabel

End Class
