<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLinear
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
        lblDirection = New NSLabel()
        btnOK = New NSButton()
        cmbDirection = New NSComboBox()
        numAmount = New NSNumericUpDown()
        SuspendLayout()
        ' 
        ' lblNumOfLeds
        ' 
        lblNumOfLeds.Font = New Font("Segoe UI", 9F)
        lblNumOfLeds.Location = New Point(3, 3)
        lblNumOfLeds.Name = "lblNumOfLeds"
        lblNumOfLeds.Size = New Size(93, 24)
        lblNumOfLeds.TabIndex = 6
        lblNumOfLeds.Text = "Number of LEDs"
        lblNumOfLeds.Value1 = "Number of LEDs"
        lblNumOfLeds.Value2 = ""
        ' 
        ' lblDirection
        ' 
        lblDirection.Font = New Font("Segoe UI", 9F)
        lblDirection.Location = New Point(3, 33)
        lblDirection.Name = "lblDirection"
        lblDirection.Size = New Size(93, 24)
        lblDirection.TabIndex = 9
        lblDirection.Text = "Direction"
        lblDirection.Value1 = "Direction"
        lblDirection.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 62)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 2
        btnOK.Text = "Confirm"
        ' 
        ' cmbDirection
        ' 
        cmbDirection.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbDirection.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbDirection.DrawMode = DrawMode.OwnerDrawFixed
        cmbDirection.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDirection.ForeColor = Color.White
        cmbDirection.FormattingEnabled = True
        cmbDirection.Location = New Point(108, 33)
        cmbDirection.Name = "cmbDirection"
        cmbDirection.Size = New Size(161, 24)
        cmbDirection.TabIndex = 1
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
        ' ucLinear
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(lblNumOfLeds)
        Controls.Add(lblDirection)
        Controls.Add(btnOK)
        Controls.Add(cmbDirection)
        Controls.Add(numAmount)
        ForeColor = Color.White
        Name = "ucLinear"
        Size = New Size(272, 88)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblNumOfLeds As NSLabel
    Friend WithEvents lblDirection As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents cmbDirection As NSComboBox
    Friend WithEvents numAmount As NSNumericUpDown

End Class
