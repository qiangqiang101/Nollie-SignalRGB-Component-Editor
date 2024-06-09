Public Class MouseHandler

    Dim Position As Point = Point.Empty

    Public WithEvents Trigger As Control
    Public Property Button() As MouseButtons

    Public Sub New(control As Control, _button As MouseButtons)
        Trigger = control
        Button = _button
    End Sub

    Private Sub Trigger_MouseMove(sender As Object, e As MouseEventArgs) Handles Trigger.MouseMove
        If e.Button = Button Then
            Trigger.Left = Trigger.Left + (e.X - Position.X)
            Trigger.Top = Trigger.Top + (e.Y - Position.Y)
        Else
            Position = New Point(e.X, e.Y)
        End If
    End Sub

End Class
