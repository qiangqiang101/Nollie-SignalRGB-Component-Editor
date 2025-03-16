Public Class ucRectangle

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
        Component.AddRectangle(CInt(numAmountW.Value), CInt(numAmountX.Value), CInt(numAmountY.Value), CInt(numAmountZ.Value), LEDPos,
                               CType(cmbOrder.SelectedValue, eRectOrder), CInt(numSpacing.Value), cbRoundedCorners.Checked)
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .RectOrder = CType(cmbOrder.SelectedValue, eRectOrder)
            .RectW = CInt(numAmountW.Value)
            .RectX = CInt(numAmountX.Value)
            .RectY = CInt(numAmountY.Value)
            .RectZ = CInt(numAmountZ.Value)
            .Spacing = CInt(numSpacing.Value)
            .RoundedCorners = cbRoundedCorners.Checked
            .AddGeneratedObject(Translation.Localization.Rectangle, Component.LedCount - CInt(numAmountW.Value + numAmountX.Value + numAmountY.Value + numAmountZ.Value) - 1, CInt(numAmountW.Value + numAmountX.Value + numAmountY.Value + numAmountZ.Value))
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucRectangle_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbOrder
            .DataSource = RectangleDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        'Load from temporary memory
        cmbOrder.SelectedValue = UserMemory.RectOrder
        numAmountW.Value = UserMemory.RectW
        numAmountX.Value = UserMemory.RectX
        numAmountY.Value = UserMemory.RectY
        numAmountZ.Value = UserMemory.RectZ
        numSpacing.Value = UserMemory.Spacing
        cbRoundedCorners.Checked = UserMemory.RoundedCorners
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Rectangle
        ParentForm.Text = loc.Rectangle
        lblOrder.Value1 = loc.Order
        btnOK.Text = loc.Confirm
        lblSpacing.Value1 = loc.Spacing
        lblRoundedCorners.Value1 = loc.RoundedCorners

        Select Case UserMemory.RectOrder
            Case eRectOrder.DownRightUpLeft
                lblW.Value1 = loc.DownAmount
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.UpAmount
                lblZ.Value1 = loc.LeftAmount
            Case eRectOrder.DownLeftUpRight
                lblW.Value1 = loc.DownAmount
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.UpAmount
                lblZ.Value1 = loc.RightAmount
            Case eRectOrder.UpRightDownLeft
                lblW.Value1 = loc.UpAmount
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.DownAmount
                lblZ.Value1 = loc.LeftAmount
            Case eRectOrder.UpLeftDownRight
                lblW.Value1 = loc.UpAmount
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.DownAmount
                lblZ.Value1 = loc.RightAmount
            Case eRectOrder.RightDownLeftUp
                lblW.Value1 = loc.RightAmount
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.LeftAmount
                lblZ.Value1 = loc.UpAmount
            Case eRectOrder.RightUpLeftDown
                lblW.Value1 = loc.RightAmount
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.LeftAmount
                lblZ.Value1 = loc.DownAmount
            Case eRectOrder.LeftDownRightUp
                lblW.Value1 = loc.LeftAmount
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.RightAmount
                lblZ.Value1 = loc.UpAmount
            Case eRectOrder.LeftUpRightDown
                lblW.Value1 = loc.LeftAmount
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.RightAmount
                lblZ.Value1 = loc.DownAmount
        End Select
    End Sub

    Private Sub cmbOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrder.SelectedIndexChanged
        Dim loc = Translation.Localization

        Try
            Dim selectedItem As eRectOrder = DirectCast([Enum].Parse(GetType(eRectOrder), cmbOrder.SelectedValue.ToString), eRectOrder)

            Select Case selectedItem
                Case eRectOrder.DownRightUpLeft
                    lblW.Value1 = loc.DownAmount
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.UpAmount
                    lblZ.Value1 = loc.LeftAmount
                Case eRectOrder.DownLeftUpRight
                    lblW.Value1 = loc.DownAmount
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.UpAmount
                    lblZ.Value1 = loc.RightAmount
                Case eRectOrder.UpRightDownLeft
                    lblW.Value1 = loc.UpAmount
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.DownAmount
                    lblZ.Value1 = loc.LeftAmount
                Case eRectOrder.UpLeftDownRight
                    lblW.Value1 = loc.UpAmount
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.DownAmount
                    lblZ.Value1 = loc.RightAmount
                Case eRectOrder.RightDownLeftUp
                    lblW.Value1 = loc.RightAmount
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.LeftAmount
                    lblZ.Value1 = loc.UpAmount
                Case eRectOrder.RightUpLeftDown
                    lblW.Value1 = loc.RightAmount
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.LeftAmount
                    lblZ.Value1 = loc.DownAmount
                Case eRectOrder.LeftDownRightUp
                    lblW.Value1 = loc.LeftAmount
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.RightAmount
                    lblZ.Value1 = loc.UpAmount
                Case eRectOrder.LeftUpRightDown
                    lblW.Value1 = loc.LeftAmount
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.RightAmount
                    lblZ.Value1 = loc.DownAmount
            End Select
        Catch ex As Exception
            'shut up
        End Try
    End Sub

    Private Sub numAmount_ValueChanged(sender As Object, e As EventArgs) Handles numAmountX.ValueChanged, numAmountX.TextChanged,
        numAmountY.ValueChanged, numAmountY.TextChanged, numAmountZ.ValueChanged, numAmountZ.TextChanged, numAmountW.ValueChanged, numAmountW.TextChanged
        Dim max As Integer = Math.Floor(((MaximumLED / 3) / 3) / 3)
        If CInt(numAmountW.Value + numAmountX.Value + numAmountY.Value + numAmountZ.Value) > MaximumLED Then
            numAmountW.Value = max
            numAmountX.Value = max
            numAmountY.Value = max
            numAmountZ.Value = max
        End If
    End Sub

End Class
