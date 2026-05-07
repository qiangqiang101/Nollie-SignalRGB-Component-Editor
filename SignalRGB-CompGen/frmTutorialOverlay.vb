Imports System.Drawing.Drawing2D

Public Class frmTutorialOverlay

    Private _targetControl As Control
    Private _instructionText As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Location = frmMain.Location
        Me.Size = frmMain.Size
    End Sub

    Public Sub HighlightControl(target As Control, message As String)
        _targetControl = target
        _instructionText = message

        Dim screenRect = target.RectangleToScreen(target.ClientRectangle)
        Dim localPoint = Me.PointToClient(screenRect.Location)
        Dim localRect = New Rectangle(localPoint.X, localPoint.Y, screenRect.Width, screenRect.Height)
        Dim fullRegion As New Region(New Rectangle(0, 0, Me.Width, Me.Height))

        Dim margin As Integer = 10
        Dim holeRect = New Rectangle(localRect.X - margin, localRect.Y - margin, localRect.Width + (margin * 2), localRect.Height + (margin * 2))

        Using path As GraphicsPath = GetRoundedRect(holeRect, 10) ' 10 is the corner radius
            fullRegion.Exclude(path)
        End Using

        Me.Region = fullRegion

        Me.Invalidate()
    End Sub

    Private Function GetRoundedRect(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim diameter As Integer = radius * 2

        ' Top Left Arc
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)
        ' Top Right Arc
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)
        ' Bottom Right Arc
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)
        ' Bottom Left Arc
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)

        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If _targetControl IsNot Nothing Then
            Dim g = e.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim screenRect = _targetControl.RectangleToScreen(_targetControl.ClientRectangle)
            Dim localPoint = Me.PointToClient(screenRect.Location)

            Dim maxWidth As Integer = 280
            Dim sz = g.MeasureString(_instructionText, font, maxWidth)

            Dim bubbleW As Integer = CInt(sz.Width + 24)
            Dim bubbleH As Integer = CInt(sz.Height + 24)
            Dim idealX As Integer = localPoint.X

            If idealX + bubbleW > Me.Width - 10 Then
                idealX = Me.Width - bubbleW - 10
            End If

            If idealX < 10 Then idealX = 10

            Dim idealY As Integer = localPoint.Y + screenRect.Height + 20
            If idealY + bubbleH > Me.Height - 10 Then
                idealY = localPoint.Y - bubbleH - 20
            End If

            Dim bubbleRect As New Rectangle(idealX, idealY, bubbleW, bubbleH)

            ' Draw Bubble
            Using b As New SolidBrush(Color.FromArgb(45, 45, 45))
                Using path As GraphicsPath = GetRoundedRect(bubbleRect, 12)
                    g.FillPath(b, path)
                    g.DrawPath(New Pen(Color.FromArgb(205, 150, 0), 1), path) ' Orange border
                End Using
            End Using

            ' Draw Text
            Dim textRect As New RectangleF(bubbleRect.X + 12, bubbleRect.Y + 12, sz.Width, sz.Height)
            Using sb2 As New SolidBrush(ForeColor)
                g.DrawString(_instructionText, Font, sb2, textRect)
            End Using

        End If
    End Sub

End Class