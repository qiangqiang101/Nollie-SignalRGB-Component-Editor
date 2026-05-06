Imports System.Drawing.Drawing2D

Public Class frmTutorialOverlay

    Private _targetControl As Control
    Private _instructionText As String

    Public Sub HighlightControl(target As Control, instruction As String)
        _targetControl = target
        _instructionText = instruction

        Dim rect = target.RectangleToScreen(target.ClientRectangle)
        Dim fullRegion As New Region(New Rectangle(0, 0, Me.Width, Me.Height))
        Dim path As New GraphicsPath()
        Dim margin As Integer = 5
        Dim holeRect As New Rectangle(rect.X - margin, rect.Y - margin, rect.Width + (margin * 2), rect.Height + (margin * 2))
        path.AddEllipse(holeRect)
        fullRegion.Exclude(path)
        Me.Region = fullRegion

        Me.Invalidate()
    End Sub

    Private Sub frmTutorialOverlay_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If _targetControl IsNot Nothing Then
            Dim rect = _targetControl.RectangleToScreen(_targetControl.ClientRectangle)
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim textPos As New Point(rect.X, rect.Y + rect.Height + 20)
            Dim textSize = g.MeasureString(_instructionText, Font)

            g.FillRoundedRectangle(Brushes.White, New Rectangle(textPos.X, textPos.Y, CInt(textSize.Width + 10), CInt(textSize.Height + 10)), 5)
            g.DrawString(_instructionText, Font, Brushes.Black, textPos.X + 5, textPos.Y + 5)
        End If
    End Sub

End Class