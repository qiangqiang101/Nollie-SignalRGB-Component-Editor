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
        Component.AddLShape(CInt(numAmountX.Value), CInt(numAmountY.Value), LEDPos, CType(cmbOrder.SelectedValue, eLShapeOrder),
                            CInt(numSpacing.Value), cbRoundedCorners.Checked)
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .LShapeOrder = CType(cmbOrder.SelectedValue, eLShapeOrder)
            .LShapeX = CInt(numAmountX.Value)
            .LShapeY = CInt(numAmountY.Value)
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
        cmbOrder.SelectedValue = UserMemory.LShapeOrder
        numAmountX.Value = UserMemory.LShapeX
        numAmountY.Value = UserMemory.LShapeY
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

        Select Case UserMemory.LShapeOrder
            Case eLShapeOrder.DownRight
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.RightAmount
            Case eLShapeOrder.DownLeft
                lblX.Value1 = loc.DownAmount
                lblY.Value1 = loc.LeftAmount
            Case eLShapeOrder.UpRight
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.RightAmount
            Case eLShapeOrder.UpLeft
                lblX.Value1 = loc.UpAmount
                lblY.Value1 = loc.LeftAmount
            Case eLShapeOrder.RightDown
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.DownAmount
            Case eLShapeOrder.RightUp
                lblX.Value1 = loc.RightAmount
                lblY.Value1 = loc.UpAmount
            Case eLShapeOrder.LeftDown
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.DownAmount
            Case eLShapeOrder.LeftUp
                lblX.Value1 = loc.LeftAmount
                lblY.Value1 = loc.UpAmount
        End Select

    End Sub

    Private Sub cmbOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOrder.SelectedIndexChanged
        Dim loc = Translation.Localization
        Try
            Dim selectedItem As eLShapeOrder = DirectCast([Enum].Parse(GetType(eLShapeOrder), cmbOrder.SelectedValue.ToString), eLShapeOrder)

            Select Case selectedItem
                Case eLShapeOrder.DownRight
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.RightAmount
                Case eLShapeOrder.DownLeft
                    lblX.Value1 = loc.DownAmount
                    lblY.Value1 = loc.LeftAmount
                Case eLShapeOrder.UpRight
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.RightAmount
                Case eLShapeOrder.UpLeft
                    lblX.Value1 = loc.UpAmount
                    lblY.Value1 = loc.LeftAmount
                Case eLShapeOrder.RightDown
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.DownAmount
                Case eLShapeOrder.RightUp
                    lblX.Value1 = loc.RightAmount
                    lblY.Value1 = loc.UpAmount
                Case eLShapeOrder.LeftDown
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.DownAmount
                Case eLShapeOrder.LeftUp
                    lblX.Value1 = loc.LeftAmount
                    lblY.Value1 = loc.UpAmount
            End Select
        Catch ex As Exception
            'shut up
        End Try

    End Sub

    Private Sub numAmount_ValueChanged(sender As Object, e As EventArgs) Handles numAmountX.ValueChanged, numAmountX.TextChanged, numAmountY.ValueChanged, numAmountY.TextChanged
        Dim max As Integer = Math.Floor(MaximumLED / 3)
        If (CInt(numAmountX.Value) + CInt(numAmountY.Value)) > MaximumLED Then
            numAmountX.Value = max
            numAmountY.Value = max
        End If
    End Sub
End Class
