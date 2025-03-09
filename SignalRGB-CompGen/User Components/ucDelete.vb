Public Class ucDelete

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
        Dim lastNthLeds = Component.LEDs.OrderByDescending(Function(x) x.MappingIndex).Take(numAmount.Value)
        For Each led In lastNthLeds
            Component.RemoveLed(led)
            Component.Invalidate()
        Next

        'Save to temporary memory
        With UserMemory
            .LEDAmount = CInt(numAmount.Value)
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        Text = Translation.Localization.RemoveLastLEDs
        ParentForm.Text = Text

        'Load from temporary memory
        numAmount.Value = UserMemory.LEDAmount
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        lblNumOfLeds.Value1 = loc.NumberOfLEDs
        btnOK.Text = loc.Confirm
    End Sub

    Private Sub numAmount_TextChanged(sender As Object, e As EventArgs) Handles numAmount.TextChanged, numAmount.ValueChanged
        Dim IsNumber As Boolean = IsNumeric(numAmount.Text)

        If IsNumber Then
            If CInt(numAmount.Text) > MaximumLED Then numAmount.Text = MaximumLED
        End If
    End Sub

End Class
