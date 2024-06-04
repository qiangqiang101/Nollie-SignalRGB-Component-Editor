Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices

Module Helper

    Public TypeDropdownList As New List(Of DropdownListItem(Of String)) From {
        New DropdownListItem(Of String)("AIO", "aio"), New DropdownListItem(Of String)("Cable", "cable"), New DropdownListItem(Of String)("Case", "case"),
        New DropdownListItem(Of String)("Chair", "chair"), New DropdownListItem(Of String)("Fan", "fan"), New DropdownListItem(Of String)("Custom", "custom")}

    <Extension>
    Public Function StringToBase64(text As String) As String
        If text = Nothing Then Return text

        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text)
        Return Convert.ToBase64String(plainTextBytes)
    End Function

    <Extension>
    Public Function Base64ToString(base64 As String) As String
        If base64 = Nothing Then Return base64

        Try
            Dim base64Bytes = Convert.FromBase64String(base64)
            Return Text.Encoding.UTF8.GetString(base64Bytes)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function Base64ToImage(Image As String) As Image
        Try
            If Image = Nothing Then
                Return Nothing
            Else
                Dim b64 As String = Image.Replace(" ", "+")
                Dim bite() As Byte = Convert.FromBase64String(b64)
                Dim stream As New MemoryStream(bite)
                Return Drawing.Image.FromStream(stream)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ImageToBase64(img As Image, Optional forceFormat As ImageFormat = Nothing, Optional formatting As Base64FormattingOptions = Base64FormattingOptions.InsertLineBreaks) As String
        Try
            If img IsNot Nothing Then
                If forceFormat Is Nothing Then forceFormat = img.RawFormat
                Dim stream As New MemoryStream
                img.Save(stream, forceFormat)
                Return Convert.ToBase64String(stream.ToArray, formatting)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ToPoint(pointf As PointF) As Point
        Return New Point(CInt(pointf.X), CInt(pointf.Y))
    End Function

    <Extension>
    Public Sub DrawRoundedRectangle(graphics As Graphics, pen As Pen, bounds As Rectangle, radius As Integer)
        If graphics Is Nothing Then
            Throw New ArgumentNullException("graphics")
        End If
        If pen Is Nothing Then
            Throw New ArgumentNullException("prush")
        End If

        Using path As GraphicsPath = RoundedRect(bounds, radius)
            graphics.DrawPath(pen, path)
        End Using
    End Sub

    <Extension>
    Public Sub FillRoundedRectangle(graphics As Graphics, brush As Brush, bounds As Rectangle, radius As Integer)
        If graphics Is Nothing Then
            Throw New ArgumentNullException("graphics")
        End If
        If brush Is Nothing Then
            Throw New ArgumentNullException("brush")
        End If

        Using path As GraphicsPath = RoundedRect(bounds, radius)
            graphics.FillPath(brush, path)
        End Using
    End Sub

    Private Function RoundedRect(bounds As Rectangle, radius As Integer) As GraphicsPath
        Dim diameter As Integer = radius * 2
        Dim size As Size = New Size(diameter, diameter)
        Dim arc As Rectangle = New Rectangle(bounds.Location, size)
        Dim path As GraphicsPath = New GraphicsPath

        If (radius = 0) Then
            path.AddRectangle(bounds)
            Return path
        End If

        'top left arc
        path.AddArc(arc, 180, 90)

        'top right arc
        arc.X = bounds.Right - diameter
        path.AddArc(arc, 270, 90)

        'bottom right arc
        arc.Y = bounds.Bottom - diameter
        path.AddArc(arc, 0, 90)

        'bottom left arc
        arc.X = bounds.Left
        path.AddArc(arc, 90, 90)

        path.CloseFigure()
        Return path
    End Function

End Module
