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
        cbSerpentine = New NSCheckBox()
        SuspendLayout()
        ' 
        ' numHeight
        ' 
        numHeight.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numHeight.DecimalPlaces = 0
        numHeight.Increment = 1
        numHeight.InterceptArrowKeys = True
        numHeight.Location = New Point(191, 3)
        numHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numHeight.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numHeight.Name = "numHeight"
        numHeight.ReadOnly = False
        numHeight.Size = New Size(78, 24)
        numHeight.TabIndex = 3
        numHeight.TextAlign = HorizontalAlignment.Right
        numHeight.ThousandsSeparator = False
        numHeight.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' numWidth
        ' 
        numWidth.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numWidth.DecimalPlaces = 0
        numWidth.Increment = 1
        numWidth.InterceptArrowKeys = True
        numWidth.Location = New Point(108, 3)
        numWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numWidth.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numWidth.Name = "numWidth"
        numWidth.ReadOnly = False
        numWidth.Size = New Size(78, 24)
        numWidth.TabIndex = 2
        numWidth.TextAlign = HorizontalAlignment.Right
        numWidth.ThousandsSeparator = False
        numWidth.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' lblSize
        ' 
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
        cmbOrder.TabIndex = 4
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 93)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 6
        btnOK.Text = "Confirm"
        ' 
        ' cbSerpentine
        ' 
        cbSerpentine.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cbSerpentine.Checked = False
        cbSerpentine.Location = New Point(108, 63)
        cbSerpentine.Name = "cbSerpentine"
        cbSerpentine.Size = New Size(161, 23)
        cbSerpentine.TabIndex = 5
        cbSerpentine.Text = "Serpentine"
        ' 
        ' ucMatrix
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(cbSerpentine)
        Controls.Add(btnOK)
        Controls.Add(lblOrder)
        Controls.Add(cmbOrder)
        Controls.Add(numHeight)
        Controls.Add(numWidth)
        Controls.Add(lblSize)
        ForeColor = Color.White
        Name = "ucMatrix"
        Size = New Size(272, 119)
        ResumeLayout(False)
    End Sub
    Friend WithEvents numHeight As NSNumericUpDown
    Friend WithEvents numWidth As NSNumericUpDown
    Friend WithEvents lblSize As NSLabel
    Friend WithEvents lblOrder As NSLabel
    Friend WithEvents cmbOrder As NSComboBox
    Friend WithEvents btnOK As NSButton
    Friend WithEvents cbSerpentine As NSCheckBox

End Class
