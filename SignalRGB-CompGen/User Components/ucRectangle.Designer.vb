﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucRectangle
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
        lblY = New NSLabel()
        numAmountY = New NSNumericUpDown()
        lblRoundedCorners = New NSLabel()
        cbRoundedCorners = New NSOnOffBox()
        lblSpacing = New NSLabel()
        numSpacing = New NSNumericUpDown()
        lblX = New NSLabel()
        numAmountX = New NSNumericUpDown()
        lblOrder = New NSLabel()
        cmbOrder = New NSComboBox()
        lblW = New NSLabel()
        btnOK = New NSButton()
        numAmountW = New NSNumericUpDown()
        lblZ = New NSLabel()
        numAmountZ = New NSNumericUpDown()
        SuspendLayout()
        ' 
        ' lblY
        ' 
        lblY.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblY.Font = New Font("Segoe UI", 9F)
        lblY.Location = New Point(3, 93)
        lblY.Name = "lblY"
        lblY.Size = New Size(99, 24)
        lblY.TabIndex = 54
        lblY.Text = "Bend after"
        lblY.Value1 = "Y"
        lblY.Value2 = ""
        ' 
        ' numAmountY
        ' 
        numAmountY.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmountY.DecimalPlaces = 0
        numAmountY.Increment = 1
        numAmountY.InterceptArrowKeys = True
        numAmountY.Location = New Point(108, 93)
        numAmountY.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmountY.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmountY.Name = "numAmountY"
        numAmountY.ReadOnly = False
        numAmountY.Size = New Size(161, 24)
        numAmountY.TabIndex = 3
        numAmountY.TextAlign = HorizontalAlignment.Right
        numAmountY.ThousandsSeparator = False
        numAmountY.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblRoundedCorners
        ' 
        lblRoundedCorners.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblRoundedCorners.Font = New Font("Segoe UI", 9F)
        lblRoundedCorners.Location = New Point(3, 183)
        lblRoundedCorners.Name = "lblRoundedCorners"
        lblRoundedCorners.Size = New Size(99, 24)
        lblRoundedCorners.TabIndex = 53
        lblRoundedCorners.Text = "Spacing"
        lblRoundedCorners.Value1 = "Rounded Corners"
        lblRoundedCorners.Value2 = ""
        ' 
        ' cbRoundedCorners
        ' 
        cbRoundedCorners.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cbRoundedCorners.Checked = False
        cbRoundedCorners.Location = New Point(108, 183)
        cbRoundedCorners.MaximumSize = New Size(56, 24)
        cbRoundedCorners.MinimumSize = New Size(56, 24)
        cbRoundedCorners.Name = "cbRoundedCorners"
        cbRoundedCorners.Size = New Size(56, 24)
        cbRoundedCorners.TabIndex = 6
        cbRoundedCorners.Text = "NsOnOffBox1"
        ' 
        ' lblSpacing
        ' 
        lblSpacing.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblSpacing.Font = New Font("Segoe UI", 9F)
        lblSpacing.Location = New Point(3, 153)
        lblSpacing.Name = "lblSpacing"
        lblSpacing.Size = New Size(99, 24)
        lblSpacing.TabIndex = 52
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
        numSpacing.Location = New Point(108, 153)
        numSpacing.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        numSpacing.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        numSpacing.Name = "numSpacing"
        numSpacing.ReadOnly = False
        numSpacing.Size = New Size(161, 24)
        numSpacing.TabIndex = 5
        numSpacing.TextAlign = HorizontalAlignment.Right
        numSpacing.ThousandsSeparator = False
        numSpacing.Value = New Decimal(New Integer() {0, 0, 0, 0})
        ' 
        ' lblX
        ' 
        lblX.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblX.Font = New Font("Segoe UI", 9F)
        lblX.Location = New Point(3, 63)
        lblX.Name = "lblX"
        lblX.Size = New Size(99, 24)
        lblX.TabIndex = 51
        lblX.Text = "Bend after"
        lblX.Value1 = "X"
        lblX.Value2 = ""
        ' 
        ' numAmountX
        ' 
        numAmountX.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmountX.DecimalPlaces = 0
        numAmountX.Increment = 1
        numAmountX.InterceptArrowKeys = True
        numAmountX.Location = New Point(108, 63)
        numAmountX.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmountX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmountX.Name = "numAmountX"
        numAmountX.ReadOnly = False
        numAmountX.Size = New Size(161, 24)
        numAmountX.TabIndex = 2
        numAmountX.TextAlign = HorizontalAlignment.Right
        numAmountX.ThousandsSeparator = False
        numAmountX.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblOrder
        ' 
        lblOrder.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblOrder.Font = New Font("Segoe UI", 9F)
        lblOrder.Location = New Point(3, 3)
        lblOrder.Name = "lblOrder"
        lblOrder.Size = New Size(99, 24)
        lblOrder.TabIndex = 50
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
        cmbOrder.Location = New Point(108, 3)
        cmbOrder.Name = "cmbOrder"
        cmbOrder.Size = New Size(161, 24)
        cmbOrder.TabIndex = 0
        ' 
        ' lblW
        ' 
        lblW.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblW.Font = New Font("Segoe UI", 9F)
        lblW.Location = New Point(3, 33)
        lblW.Name = "lblW"
        lblW.Size = New Size(99, 24)
        lblW.TabIndex = 49
        lblW.Text = "Number of LEDs"
        lblW.Value1 = "W"
        lblW.Value2 = ""
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 216)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 7
        btnOK.Text = "Confirm"
        ' 
        ' numAmountW
        ' 
        numAmountW.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmountW.DecimalPlaces = 0
        numAmountW.Increment = 1
        numAmountW.InterceptArrowKeys = True
        numAmountW.Location = New Point(108, 33)
        numAmountW.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmountW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmountW.Name = "numAmountW"
        numAmountW.ReadOnly = False
        numAmountW.Size = New Size(161, 24)
        numAmountW.TabIndex = 1
        numAmountW.TextAlign = HorizontalAlignment.Right
        numAmountW.ThousandsSeparator = False
        numAmountW.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblZ
        ' 
        lblZ.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblZ.Font = New Font("Segoe UI", 9F)
        lblZ.Location = New Point(3, 123)
        lblZ.Name = "lblZ"
        lblZ.Size = New Size(99, 24)
        lblZ.TabIndex = 56
        lblZ.Text = "Bend after"
        lblZ.Value1 = "Z"
        lblZ.Value2 = ""
        ' 
        ' numAmountZ
        ' 
        numAmountZ.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        numAmountZ.DecimalPlaces = 0
        numAmountZ.Increment = 1
        numAmountZ.InterceptArrowKeys = True
        numAmountZ.Location = New Point(108, 123)
        numAmountZ.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmountZ.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmountZ.Name = "numAmountZ"
        numAmountZ.ReadOnly = False
        numAmountZ.Size = New Size(161, 24)
        numAmountZ.TabIndex = 4
        numAmountZ.TextAlign = HorizontalAlignment.Right
        numAmountZ.ThousandsSeparator = False
        numAmountZ.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' ucRectangle
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(lblZ)
        Controls.Add(numAmountZ)
        Controls.Add(lblY)
        Controls.Add(numAmountY)
        Controls.Add(lblRoundedCorners)
        Controls.Add(cbRoundedCorners)
        Controls.Add(lblSpacing)
        Controls.Add(numSpacing)
        Controls.Add(lblX)
        Controls.Add(numAmountX)
        Controls.Add(lblOrder)
        Controls.Add(cmbOrder)
        Controls.Add(lblW)
        Controls.Add(btnOK)
        Controls.Add(numAmountW)
        ForeColor = Color.White
        Name = "ucRectangle"
        Size = New Size(272, 242)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblY As NSLabel
    Friend WithEvents numAmountY As NSNumericUpDown
    Friend WithEvents lblRoundedCorners As NSLabel
    Friend WithEvents cbRoundedCorners As NSOnOffBox
    Friend WithEvents lblSpacing As NSLabel
    Friend WithEvents numSpacing As NSNumericUpDown
    Friend WithEvents lblX As NSLabel
    Friend WithEvents numAmountX As NSNumericUpDown
    Friend WithEvents lblOrder As NSLabel
    Friend WithEvents cmbOrder As NSComboBox
    Friend WithEvents lblW As NSLabel
    Friend WithEvents btnOK As NSButton
    Friend WithEvents numAmountW As NSNumericUpDown
    Friend WithEvents lblZ As NSLabel
    Friend WithEvents numAmountZ As NSNumericUpDown

End Class
