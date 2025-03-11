Public Class ucLShape

    Public Property MaximumLED() As Integer
    Public Property Component() As ucComponent
    Public Property LEDPos() As Point

    Public Sub New(maxled As Integer, parent As ucComponent, pos As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MaximumLED = maxled
        Component = parent
        LEDPos = pos
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Component.AddLShape(CInt(numAmount.Value), LEDPos, CType(cmbOrder.SelectedValue, eLShapeOrder),
                            CInt(numBendAfter.Value), CInt(numSpacing.Value), cbRoundedCorners.Checked)
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .LEDAmount = CInt(numAmount.Value)
            .LShapeOrder = CType(cmbOrder.SelectedValue, eLShapeOrder)
            .BendAfter = CInt(numBendAfter.Value)
            .Spacing = CInt(numSpacing.Value)
            .RoundedCorners = cbRoundedCorners.Checked
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucLShape_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbOrder
            .DataSource = LShapeDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        'Load from temporary memory
        numAmount.Value = UserMemory.LEDAmount
        cmbOrder.SelectedValue = UserMemory.LShapeOrder
        numBendAfter.Value = UserMemory.BendAfter
        numSpacing.Value = UserMemory.Spacing
        cbRoundedCorners.Checked = UserMemory.RoundedCorners
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.LShape
        ParentForm.Text = loc.LShape
        lblNumOfLeds.Value1 = loc.NumberOfLEDs
        lblOrder.Value1 = loc.Order
        lblBend.Value1 = loc.BendAfter
        btnOK.Text = loc.Confirm
        lblSpacing.Value1 = loc.Spacing
        lblRoundedCorners.Value1 = loc.RoundedCorners
    End Sub

    Private Sub numAmount_ValueChanged(sender As Object, e As EventArgs) Handles numAmount.ValueChanged, numAmount.TextChanged
        If CInt(numAmount.Value) > MaximumLED Then numAmount.Value = MaximumLED
        numBendAfter.Maximum = numAmount.Value
    End Sub

End Class
