Imports System.Security.Cryptography.Pkcs

Public Class ucComponent

    Public Property LedCoordinates() As List(Of Integer())
    Public Property LedMapping() As Integer()
    Public Property LedNames() As String()
    Private _ledCount As Integer = 0
    Public Property LedCount() As Integer
        Get
            Return _ledCount
        End Get
        Set(value As Integer)
            _ledCount = value
            Invalidate()
        End Set
    End Property
    Private __width As Integer = 0
    Public Property _Width() As Integer
        Get
            Return __width
        End Get
        Set(value As Integer)
            __width = value
            Invalidate()
        End Set
    End Property
    Private __height As Integer = 0
    Public Property _Height() As Integer
        Get
            Return __height
        End Get
        Set(value As Integer)
            __height = value
            Invalidate()
        End Set
    End Property

    Private _ledPos As Point = Point.Empty
    Public ReadOnly Property MousePos() As Point
        Get
            Return _ledPos
        End Get
    End Property

    Private ReadOnly Property LedCoordinatesPoints() As List(Of Point)
        Get
            Dim points As New List(Of Point)
            For Each lc In LedCoordinates
                Dim point As New Point(lc(0), lc(1))
                points.Add(point)
            Next

            For i As Integer = 0 To points.Count - 1
                Dim name As String = LedNames(i)
                Dim index As Integer = LedMapping(i)
                Dim point As Point = points(i)
                LEDs.Add(New Led(index, name, point))
            Next

            Return points
        End Get
    End Property


    Private LEDs As New List(Of Led)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        DoubleBuffered = True
    End Sub

    'Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim MyCreateParams As CreateParams = MyBase.CreateParams
    '        MyCreateParams.ExStyle = MyCreateParams.ExStyle Or &H80
    '        Return MyCreateParams
    '    End Get
    'End Property

    Private Sub PrepareGraphics(g As Graphics)
        g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
        g.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
        g.InterpolationMode = Drawing2D.InterpolationMode.Low
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
    End Sub

    Private Sub ucComponent_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        PrepareGraphics(g)
        g.Clear(BackColor)
        Dim sf As StringFormat = New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.FitBlackBox}

        If LedCount >= 1 Then
            Dim rectSize As New SizeF(Width / _Width, Height / _Height)
            If rectSize.Width > rectSize.Height Then rectSize.Width = rectSize.Height Else rectSize.Height = rectSize.Width

            Dim matrix(_Width - 1, _Height - 1) As Integer
            Dim count As Integer = 0
            For row As Integer = 0 To matrix.GetUpperBound(0)
                For col As Integer = 0 To matrix.GetUpperBound(1)

                    Using sb As New SolidBrush(Color.LightGray)
                        Dim numRows = matrix.GetUpperBound(1) + 1
                        Dim numCols = matrix.GetUpperBound(0) + 1

                        Dim x As Single = rectSize.Width * row
                        Dim y As Single = rectSize.Height * col
                        Dim w As Single = rectSize.Width
                        Dim h As Single = rectSize.Height
                        Dim p As Single = 3.0F
                        Dim r As New RectangleF(x + p, y + p, w - p, h - p)
                        Dim index As Integer = col * numCols + row

                        Dim approximatelySize As New Size((numCols * rectSize.Width) + (p * 3), (numRows * rectSize.Height) + (p * 3))
                        If Width > approximatelySize.Width Then Width = approximatelySize.Width
                        If Height > approximatelySize.Height Then Height = approximatelySize.Height

                        Dim renderRect As New RectangleF(x, y, rectSize.Width, rectSize.Height)
                        If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                            _ledPos = New Point(row, col)
                        End If

                        If LedCoordinatesPoints.Contains(New Point(row, col)) Then
                            Dim ledIndex As Integer = LedMapping(LedCoordinatesPoints.FindIndex(Function(xy) xy.X = row AndAlso xy.Y = col))
                            Dim led As Led = LEDs.Find(Function(z) z.MappingIndex = ledIndex)
                            led.Index = ledIndex
                            If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                                Using sb2 As New SolidBrush(Color.LightGreen)
                                    g.FillRectangle(sb2, r)
                                End Using
                                Using sb2 As New SolidBrush(Color.Green)
                                    g.DrawString(ledIndex, Font, sb2, renderRect, sf)
                                End Using
                            Else
                                Using sb2 As New SolidBrush(Color.Green)
                                    g.FillRectangle(sb2, r)
                                End Using
                                Using sb2 As New SolidBrush(Color.Black)
                                    g.DrawString(ledIndex, Font, sb2, renderRect, sf)
                                End Using
                            End If
                        Else
                            g.FillRectangle(sb, r)
                            '    Using sb2 As New SolidBrush(Color.White)
                            '        g.DrawString(index, Font, sb2, renderRect, sf)
                            '    End Using
                        End If

                        Using pen As New Pen(Color.Black, 1.0F)
                            g.DrawRectangle(pen, r)
                        End Using
                    End Using
                    count += 1
                    If count >= LedCount Then count = 0
                Next
            Next
        End If
    End Sub

    Private Sub ucComponent_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub ucComponent_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Invalidate()
    End Sub

    Private Sub ucComponent_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            Width += 100
            Height += 100
        Else
            Width -= 100
            Height -= 100
        End If
    End Sub

    Private Sub ucComponent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Invalidate()
    End Sub
End Class
