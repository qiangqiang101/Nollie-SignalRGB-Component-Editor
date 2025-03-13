<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucMatrix
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        numHeight = New NSNumericUpDown()
        numWidth = New NSNumericUpDown()
        lblSize = New NSLabel()
        lblOrder = New NSLabel()
        cmbOrder = New NSComboBox()
        btnOK = New NSButton()
        lblSpacing = New NSLabel()
        numSpacing = New NSNumericUpDown()
        lblSerpentine = New NSLabel()
        cbSerpentine = New NSOnOffBox()
        SuspendLayout()
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numHeight.DecimalPlaces = 0
        numHeight.Increment = 1
        numHeight.InterceptArrowKeys = True
        numHeight.Location = New Point(191, 3)
        numHeight.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        numHeight.Name = "numHeight"
        numHeight.ReadOnly = False
        numHeight.Size = New Size(78, 24)
        numHeight.TabIndex = 1
        numHeight.TextAlign = HorizontalAlignment.Right
        numHeight.ThousandsSeparator = False
        numHeight.Value = New Decimal(New Integer() {2, 0, 0, 0})
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numWidth.DecimalPlaces = 0
        numWidth.Increment = 1
        numWidth.InterceptArrowKeys = True
        numWidth.Location = New Point(108, 3)
        numWidth.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        numWidth.Name = "numWidth"
        numWidth.ReadOnly = False
        numWidth.Size = New Size(78, 24)
        numWidth.TabIndex = 0
        numWidth.TextAlign = HorizontalAlignment.Right
        numWidth.ThousandsSeparator = False
        numWidth.Value = New Decimal(New Integer() {2, 0, 0, 0})
        ' 
        ' lblSize
        ' 
        lblSize.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblSize.Font = New Font("Segoe UI", 9F)
        lblSize.Location = New Point(3, 3)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(93, 24)
        lblSize.TabIndex = 18
        lblSize.Text = "Direction"
        lblSize.Value1 = "Size"
        lblSize.Value2 = ""
        ' 
        ' lblOrder
        ' 
        lblOrder.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblOrder.Font = New Font("Segoe UI", 9F)
        lblOrder.Location = New Point(3, 33)
        lblOrder.Name = "lblOrder"
        lblOrder.Size = New Size(93, 24)
        lblOrder.TabIndex = 20
        lblOrder.Text = "Direction"
        lblOrder.Value1 = "Order"
        lblOrder.Value2 = ""
        ' 
        ' cmbOrder
        ' 
        cmbOrder.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbOrder.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbOrder.DrawMode = DrawMode.OwnerDrawFixed
        cmbOrder.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOrder.ForeColor = Color.White
        cmbOrder.FormattingEnabled = True
        cmbOrder.Location = New Point(108, 33)
        cmbOrder.Name = "cmbOrder"
        cmbOrder.Size = New Size(161, 24)
        cmbOrder.TabIndex = 2
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 123)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 5
        btnOK.Text = "Confirm"
        ' 
        ' lblSpacing
        ' 
        lblSpacing.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblSpacing.Font = New Font("Segoe UI", 9F)
        lblSpacing.Location = New Point(3, 63)
        lblSpacing.Name = "lblSpacing"
        lblSpacing.Size = New Size(93, 24)
        lblSpacing.TabIndex = 22
        lblSpacing.Text = "Spacing"
        lblSpacing.Value1 = "Spacing"
        lblSpacing.Value2 = ""
        ' 
        ' numSpacing
        ' 
        numSpacing.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numSpacing.DecimalPlaces = 0
        numSpacing.Increment = 1
        numSpacing.InterceptArrowKeys = True
        numSpacing.Location = New Point(108, 63)
        numSpacing.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        numSpacing.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        numSpacing.Name = "numSpacing"
        numSpacing.ReadOnly = False
        numSpacing.Size = New Size(161, 24)
        numSpacing.TabIndex = 3
        numSpacing.TextAlign = HorizontalAlignment.Right
        numSpacing.ThousandsSeparator = False
        numSpacing.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' lblSerpentine
        ' 
        lblSerpentine.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblSerpentine.Font = New Font("Segoe UI", 9F)
        lblSerpentine.Location = New Point(3, 93)
        lblSerpentine.Name = "lblSerpentine"
        lblSerpentine.Size = New Size(99, 24)
        lblSerpentine.TabIndex = 30
        lblSerpentine.Text = "Spacing"
        lblSerpentine.Value1 = "Serpentine"
        lblSerpentine.Value2 = ""
        ' 
        ' cbSerpentine
        ' 
        cbSerpentine.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cbSerpentine.Checked = False
        cbSerpentine.Location = New Point(108, 93)
        cbSerpentine.MaximumSize = New Size(56, 24)
        cbSerpentine.MinimumSize = New Size(56, 24)
        cbSerpentine.Name = "cbSerpentine"
        cbSerpentine.Size = New Size(56, 24)
        cbSerpentine.TabIndex = 4
        cbSerpentine.Text = "NsOnOffBox1"
        ' 
        ' ucMatrix
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(lblSerpentine)
        Controls.Add(cbSerpentine)
        Controls.Add(lblSpacing)
        Controls.Add(numSpacing)
        Controls.Add(btnOK)
        Controls.Add(lblOrder)
        Controls.Add(cmbOrder)
        Controls.Add(numHeight)
        Controls.Add(numWidth)
        Controls.Add(lblSize)
        ForeColor = Color.White
        Name = "ucMatrix"
        Size = New Size(272, 149)
        ResumeLayout(False)
    End Sub
    Friend WithEvents numHeight As NSNumericUpDown
    Friend WithEvents numWidth As NSNumericUpDown
    Friend WithEvents lblSize As NSLabel
    Friend WithEvents lblOrder As NSLabel
    Friend WithEvents cmbOrder As NSComboBox
    Friend WithEvents btnOK As NSButton
    Friend WithEvents lblSpacing As NSLabel
    Friend WithEvents numSpacing As NSNumericUpDown
    Friend WithEvents lblSerpentine As NSLabel
    Friend WithEvents cbSerpentine As NSOnOffBox

End Class
