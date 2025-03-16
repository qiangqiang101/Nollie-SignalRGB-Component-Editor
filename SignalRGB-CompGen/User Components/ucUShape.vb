Public Class ucUShape

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
        Component.AddUShape(CInt(numAmountX.Value), CInt(numAmountY.Value), CInt(numAmountZ.Value), LEDPos,
                                CType(cmbOrder.SelectedValue, eLShapeOrder), CInt(numSpacing.Value), cbRoundedCorners.Checked)
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .UShapeOrder = CType(cmbOrder.SelectedValue, eUShapeOrder)
            .UShapeX = CInt(numAmountX.Value)
            .UShapeY = CInt(numAmountY.Value)
            .UShapeZ = CInt(numAmountZ.Value)
            .Spacing = CInt(numSpacing.Value)
            .RoundedCorners = cbRoundedCorners.Checked
            .AddGeneratedObject(Translation.Localization.UShape, Component.LedCount - CInt(numAmountX.Value + numAmountY.Value + numAmountZ.Value) - 1, CInt(numAmountX.Value + numAmountY.Value + numAmountZ.Value))
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucUShape_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbOrder
            .DataSource = UShapeDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        'Load from temporary memory
        cmbOrder.SelectedValue = UserMemory.UShapeOrder
        numAmountX.Value = UserMemory.UShapeX
        numAmountY.Value = UserMemory.UShapeY
        numAmountZ.Value = UserMemory.UShapeZ
        numSpacing.Value = UserMemory.Spacing
        cbRoundedCorners.Checked = UserMemory.RoundedCorners
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.LShape
        ParentForm.Text = loc.LShape
        lblOrder.Value1 = loc.Order
        btnOK.Text = loc.Confirm
        lblSpacing.Value1 = loc.Spacing
        lblRoundedCorners.Value1 = loc.RoundedCorners

        Select Case UserMemory.UShapeOrder
            Case eUShapeOrder.DownRightUp
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.RightAmount
                lblZ.Value1 = loc.UpAmount
            Case eUShapeOrder.DownLeftUp
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.LeftAmount
                lblZ.Value1 = loc.UpAmount
            Case eUShapeOrder.UpRightDown
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.RightAmount
                lblZ.Value1 = loc.DownAmount
            Case eUShapeOrder.UpLeftDown
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.LeftAmount
                lblZ.Value1 = loc.DownAmount
            Case eUShapeOrder.RightDownLeft
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.DownAmount
                lblZ.Value1 = loc.LeftAmount
            Case eUShapeOrder.RightUpLeft
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.UpAmount
                lblZ.Value1 = loc.LeftAmount
            Case eUShapeOrder.LeftDownRight
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.DownAmount
                lblZ.Value1 = loc.RightAmount
            Case eUShapeOrder.LeftUpRight
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.UpAmount
                lblZ.Value1 = loc.RightAmount
        End Select
    End Sub

    Private Sub cmbOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrder.SelectedIndexChanged
        Dim loc = Translation.Localization
        Try
            Dim selectedItem As eUShapeOrder = DirectCast([Enum].Parse(GetType(eUShapeOrder), cmbOrder.SelectedValue.ToString), eUShapeOrder)

            Select Case selectedItem
                Case eUShapeOrder.DownRightUp
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.RightAmount
                    lblZ.Value1 = loc.UpAmount
                Case eUShapeOrder.DownLeftUp
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.LeftAmount
                    lblZ.Value1 = loc.UpAmount
                Case eUShapeOrder.UpRightDown
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.RightAmount
                    lblZ.Value1 = loc.DownAmount
                Case eUShapeOrder.UpLeftDown
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.LeftAmount
                    lblZ.Value1 = loc.DownAmount
                Case eUShapeOrder.RightDownLeft
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.DownAmount
                    lblZ.Value1 = loc.LeftAmount
                Case eUShapeOrder.RightUpLeft
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.UpAmount
                    lblZ.Value1 = loc.LeftAmount
                Case eUShapeOrder.LeftDownRight
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.DownAmount
                    lblZ.Value1 = loc.RightAmount
                Case eUShapeOrder.LeftUpRight
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.UpAmount
                    lblZ.Value1 = loc.RightAmount
            End Select
        Catch ex As Exception
            'shut up
        End Try
    End Sub

    Private Sub numAmount_ValueChanged(sender As Object, e As EventArgs) Handles numAmountX.ValueChanged, numAmountX.TextChanged,
        numAmountY.ValueChanged, numAmountY.TextChanged, numAmountZ.ValueChanged, numAmountZ.TextChanged
        Dim max As Integer = Math.Floor((MaximumLED / 3) / 3)
        If CInt(numAmountX.Value + numAmountY.Value + numAmountZ.Value) > MaximumLED Then
            numAmountX.Value = max
            numAmountY.Value = max
            numAmountZ.Value = max
        End If
    End Sub

End Class
