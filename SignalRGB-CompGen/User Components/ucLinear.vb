Public Class ucLinear

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
        Component.AddLeds(CInt(numAmount.Value), LEDPos, CType(cmbDirection.SelectedValue, eDirection))
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .LEDAmount = CInt(numAmount.Value)
            .Direction = CType(cmbDirection.SelectedValue, eDirection)
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucLinear_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbDirection
            .DataSource = DirectionDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        'Load from temporary memory
        numAmount.Value = UserMemory.LEDAmount
        cmbDirection.SelectedValue = UserMemory.Direction
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Linear
        ParentForm.Text = loc.Linear
        lblNumOfLeds.Value1 = loc.NumberOfLEDs
        lblDirection.Value1 = loc.Direction
        btnOK.Text = loc.Confirm
    End Sub

    Private Sub numAmount_TextChanged(sender As Object, e As EventArgs) Handles numAmount.TextChanged, numAmount.ValueChanged
        Dim IsNumber As Boolean = IsNumeric(numAmount.Text)

        If IsNumber Then
            If CInt(numAmount.Text) > MaximumLED Then numAmount.Text = MaximumLED
        End If
    End Sub

End Class
