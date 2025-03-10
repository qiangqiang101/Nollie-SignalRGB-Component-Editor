<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLShape
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
        lblNumOfLeds = New NSLabel()
        btnOK = New NSButton()
        numAmount = New NSNumericUpDown()
        lblOrder = New NSLabel()
        cmbOrder = New NSComboBox()
        lblBend = New NSLabel()
        numBendAfter = New NSNumericUpDown()
        SuspendLayout()
        ' 
        ' lblNumOfLeds
        ' 
        lblNumOfLeds.Font = New Font("Segoe UI", 9F)
        lblNumOfLeds.Location = New Point(3, 3)
        lblNumOfLeds.Name = "lblNumOfLeds"
        lblNumOfLeds.Size = New Size(93, 24)
        lblNumOfLeds.TabIndex = 13
        lblNumOfLeds.Text = "Number of LEDs"
        lblNumOfLeds.Value1 = "Number of LEDs"
        lblNumOfLeds.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 91)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 3
        btnOK.Text = "Confirm"
        ' 
        ' numAmount
        ' 
        numAmount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmount.DecimalPlaces = 0
        numAmount.Increment = 1
        numAmount.InterceptArrowKeys = True
        numAmount.Location = New Point(108, 3)
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
        ' lblOrder
        ' 
        lblOrder.Font = New Font("Segoe UI", 9F)
        lblOrder.Location = New Point(3, 33)
        lblOrder.Name = "lblOrder"
        lblOrder.Size = New Size(93, 24)
        lblOrder.TabIndex = 22
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
        cmbOrder.TabIndex = 1
        ' 
        ' lblBend
        ' 
        lblBend.Font = New Font("Segoe UI", 9F)
        lblBend.Location = New Point(3, 63)
        lblBend.Name = "lblBend"
        lblBend.Size = New Size(93, 24)
        lblBend.TabIndex = 24
        lblBend.Text = "Bend after"
        lblBend.Value1 = "Bend after"
        lblBend.Value2 = ""
        ' 
        ' numBendAfter
        ' 
        numBendAfter.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numBendAfter.DecimalPlaces = 0
        numBendAfter.Increment = 1
        numBendAfter.InterceptArrowKeys = True
        numBendAfter.Location = New Point(108, 63)
        numBendAfter.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numBendAfter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numBendAfter.Name = "numBendAfter"
        numBendAfter.ReadOnly = False
        numBendAfter.Size = New Size(161, 24)
        numBendAfter.TabIndex = 2
        numBendAfter.TextAlign = HorizontalAlignment.Right
        numBendAfter.ThousandsSeparator = False
        numBendAfter.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' ucLShape
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(lblBend)
        Controls.Add(numBendAfter)
        Controls.Add(lblOrder)
        Controls.Add(cmbOrder)
        Controls.Add(lblNumOfLeds)
        Controls.Add(btnOK)
        Controls.Add(numAmount)
        ForeColor = Color.White
        Name = "ucLShape"
        Size = New Size(272, 117)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblNumOfLeds As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents numAmount As NSNumericUpDown
    Friend WithEvents lblOrder As NSLabel
    Friend WithEvents cmbOrder As NSComboBox
    Friend WithEvents lblBend As NSLabel
    Friend WithEvents numBendAfter As NSNumericUpDown

End Class
