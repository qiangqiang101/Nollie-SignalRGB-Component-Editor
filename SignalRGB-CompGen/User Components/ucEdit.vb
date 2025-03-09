Public Class ucEdit

    Public Property Component() As ucComponent
    Public Property SelectedItem() As Led

    Public Sub New(parent As ucComponent, selected As Led)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Component = parent
        SelectedItem = selected
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim idx = Component.LEDs.IndexOf(SelectedItem)
        With SelectedItem
            .LedCoordinates = New Point(numX.Value, numY.Value)
            .LedName = txtName.Text
        End With
        Component.LEDs(idx) = SelectedItem
        Component.Invalidate()
        ParentForm.Close()
    End Sub

    Private Sub ucEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        txtName.Text = SelectedItem.LedName
        numX.Value = SelectedItem.LedCoordinates.X
        numY.Value = SelectedItem.LedCoordinates.Y
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.EditLED
        lblName.Value1 = loc.LEDName
        lblCoordinates.Value1 = loc.LEDCoordinates
        btnOK.Text = loc.Confirm
    End Sub

End Class
