Public Class frmMulti

    Public Property Mode() As eMode
    Public Property MaximumLED() As Integer
    Public Property Component() As ucComponent
    Public Property LEDPos() As Point

    Public Sub New(_mode As eMode, maxled As Integer, parent As ucComponent, pos As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Mode = _mode
        MaximumLED = maxled
        Component = parent
        LEDPos = pos
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Mode = eMode.Add Then
            Component.AddLeds(numAmount.Value, LEDPos, CType(cmbDirection.SelectedValue, eDirection))
            Component.Invalidate()
        Else
            Dim lastNthLeds = Component.LEDs.OrderByDescending(Function(x) x.MappingIndex).Take(numAmount.Value)
            For Each led In lastNthLeds
                Component.RemoveLed(led)
                Component.Invalidate()
            Next
        End If
        Close()
    End Sub

    Private Sub frmMulti_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbDirection
            .DataSource = DirectionDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        numAmount.Maximum = MaximumLED
        If Mode = eMode.Add Then
            Text = Translation.Localization.AddLEDs
        Else
            Text = Translation.Localization.RemoveLastLEDs
            lblDirection.Visible = False
            cmbDirection.Visible = False
        End If
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        lblNumOfLeds.Text = loc.NumberOfLEDs
        lblDirection.Text = loc.Direction
        btnOK.Text = loc.Confirm
    End Sub
End Class