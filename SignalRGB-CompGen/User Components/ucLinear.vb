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
        Component.AddLeds(CInt(numAmount.Value), LEDPos, CType(cmbDirection.SelectedValue, eDirection), CInt(numSpacing.Value))
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .LEDAmount = CInt(numAmount.Value)
            .Direction = CType(cmbDirection.SelectedValue, eDirection)
            .Spacing = CInt(numSpacing.Value)
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
        numSpacing.Value = UserMemory.Spacing
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Linear
        ParentForm.Text = loc.Linear
        lblNumOfLeds.Value1 = loc.NumberOfLEDs
        lblDirection.Value1 = loc.Direction
        btnOK.Text = loc.Confirm
        lblSpacing.Value1 = loc.Spacing
    End Sub

    Private Sub numAmount_TextChanged(sender As Object, e As EventArgs) Handles numAmount.TextChanged, numAmount.ValueChanged
        If CInt(numAmount.Value) > MaximumLED Then numAmount.Value = MaximumLED
    End Sub

End Class
