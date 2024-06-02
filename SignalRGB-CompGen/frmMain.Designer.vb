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
        Label8 = New Label()
        numLedCount = New NumericUpDown()
        lblCursorLocation = New Label()
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
        SplitContainer1 = New SplitContainer()
        Timer1 = New Timer(components)
        RightPanel.SuspendLayout()
        CType(numLedCount, ComponentModel.ISupportInitialize).BeginInit()
        CType(pbImage, ComponentModel.ISupportInitialize).BeginInit()
        CType(numHeight, ComponentModel.ISupportInitialize).BeginInit()
        CType(numWidth, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' RightPanel
        ' 
        RightPanel.BorderStyle = BorderStyle.FixedSingle
        RightPanel.Controls.Add(Label8)
        RightPanel.Controls.Add(numLedCount)
        RightPanel.Controls.Add(lblCursorLocation)
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
        RightPanel.Size = New Size(218, 491)
        RightPanel.TabIndex = 0
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
        ' numLedCount
        ' 
        numLedCount.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numLedCount.Location = New Point(75, 201)
        numLedCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        numLedCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numLedCount.Name = "numLedCount"
        numLedCount.Size = New Size(130, 23)
        numLedCount.TabIndex = 7
        numLedCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblCursorLocation
        ' 
        lblCursorLocation.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblCursorLocation.Location = New Point(3, 460)
        lblCursorLocation.Name = "lblCursorLocation"
        lblCursorLocation.Size = New Size(210, 21)
        lblCursorLocation.TabIndex = 15
        lblCursorLocation.Text = "LED Position: 0, 0"
        lblCursorLocation.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label7.BorderStyle = BorderStyle.Fixed3D
        Label7.Location = New Point(3, 231)
        Label7.Name = "Label7"
        Label7.Size = New Size(210, 2)
        Label7.TabIndex = 14
        ' 
        ' pbImage
        ' 
        pbImage.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pbImage.BorderStyle = BorderStyle.FixedSingle
        pbImage.Image = CType(resources.GetObject("pbImage.Image"), Image)
        pbImage.Location = New Point(3, 236)
        pbImage.Name = "pbImage"
        pbImage.Size = New Size(210, 210)
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
        cmbType.Size = New Size(130, 23)
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
        txtProduct.Size = New Size(130, 23)
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
        txtBrand.Size = New Size(130, 23)
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
        txtName.Size = New Size(130, 23)
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
        numHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.Size = New Size(130, 23)
        numHeight.TabIndex = 6
        numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        numWidth.Location = New Point(75, 143)
        numWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.Size = New Size(130, 23)
        numWidth.TabIndex = 5
        numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {tsmiFile, tsmiHelp})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(216, 24)
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
        tsmiHelp.Name = "tsmiHelp"
        tsmiHelp.Size = New Size(24, 20)
        tsmiHelp.Text = "?"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(RightPanel)
        SplitContainer1.Size = New Size(804, 491)
        SplitContainer1.SplitterDistance = 582
        SplitContainer1.TabIndex = 3
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(804, 491)
        Controls.Add(SplitContainer1)
        MainMenuStrip = MenuStrip1
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Untitled - Nollie SignalRGB Custom Component Editor"
        RightPanel.ResumeLayout(False)
        RightPanel.PerformLayout()
        CType(numLedCount, ComponentModel.ISupportInitialize).EndInit()
        CType(pbImage, ComponentModel.ISupportInitialize).EndInit()
        CType(numHeight, ComponentModel.ISupportInitialize).EndInit()
        CType(numWidth, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
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
    Friend WithEvents lblCursorLocation As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tsmiNew As ToolStripMenuItem
    Friend WithEvents tsmiOpen As ToolStripMenuItem
    Friend WithEvents tsmiSave As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsmiHelp As ToolStripMenuItem
    Friend WithEvents tsmiSaveAs As ToolStripMenuItem
    Friend WithEvents Label8 As Label
    Friend WithEvents numLedCount As NumericUpDown

End Class
