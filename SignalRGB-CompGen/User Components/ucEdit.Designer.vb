<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEdit
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
        numY = New NSNumericUpDown()
        numX = New NSNumericUpDown()
        txtName = New NSTextBox()
        lblName = New NSLabel()
        lblCoordinates = New NSLabel()
        btnOK = New NSButton()
        SuspendLayout()
        ' 
        ' numY
        ' 
        numY.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numY.DecimalPlaces = 0
        numY.Increment = 1
        numY.InterceptArrowKeys = True
        numY.Location = New Point(191, 33)
        numY.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numY.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numY.Name = "numY"
        numY.ReadOnly = False
        numY.Size = New Size(78, 24)
        numY.TabIndex = 2
        numY.TextAlign = HorizontalAlignment.Right
        numY.ThousandsSeparator = False
        numY.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' numX
        ' 
        numX.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numX.DecimalPlaces = 0
        numX.Increment = 1
        numX.InterceptArrowKeys = True
        numX.Location = New Point(108, 33)
        numX.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        numX.Minimum = New Decimal(New Integer() {500, 0, 0, Integer.MinValue})
        numX.Name = "numX"
        numX.ReadOnly = False
        numX.Size = New Size(78, 24)
        numX.TabIndex = 1
        numX.TextAlign = HorizontalAlignment.Right
        numX.ThousandsSeparator = False
        numX.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' txtName
        ' 
        txtName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        txtName.Location = New Point(108, 3)
        txtName.MaxLength = 32767
        txtName.Multiline = False
        txtName.Name = "txtName"
        txtName.ReadOnly = False
        txtName.Size = New Size(161, 24)
        txtName.TabIndex = 0
        txtName.TextAlign = HorizontalAlignment.Left
        txtName.UseSystemPasswordChar = False
        ' 
        ' lblName
        ' 
        lblName.Font = New Font("Segoe UI", 9F)
        lblName.Location = New Point(3, 3)
        lblName.Name = "lblName"
        lblName.Size = New Size(93, 24)
        lblName.TabIndex = 14
        lblName.Value1 = "LED Name"
        lblName.Value2 = ""
        ' 
        ' lblCoordinates
        ' 
        lblCoordinates.Font = New Font("Segoe UI", 9F)
        lblCoordinates.Location = New Point(3, 33)
        lblCoordinates.Name = "lblCoordinates"
        lblCoordinates.Size = New Size(93, 24)
        lblCoordinates.TabIndex = 15
        lblCoordinates.Text = "Direction"
        lblCoordinates.Value1 = "LED Coordinates"
        lblCoordinates.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 61)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 3
        btnOK.Text = "Confirm"
        ' 
        ' ucEdit
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(numY)
        Controls.Add(numX)
        Controls.Add(txtName)
        Controls.Add(lblName)
        Controls.Add(lblCoordinates)
        Controls.Add(btnOK)
        ForeColor = Color.White
        Name = "ucEdit"
        Size = New Size(272, 87)
        ResumeLayout(False)
    End Sub

    Friend WithEvents numY As NSNumericUpDown
    Friend WithEvents numX As NSNumericUpDown
    Friend WithEvents txtName As NSTextBox
    Friend WithEvents lblName As NSLabel
    Friend WithEvents lblCoordinates As NSLabel
    Friend WithEvents btnOK As NSButton

End Class
