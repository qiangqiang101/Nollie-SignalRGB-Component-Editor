Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports Newtonsoft.Json

Public Class ucComponent

    Private timerTicks As Integer = 0

    Public LEDs As New List(Of Led)

    Public Event LEDsChanged(sender As Object, e As EventArgs)

    Public numRows As Integer = 0
    Public numCols As Integer = 0

    Public SelectedItems As New List(Of Led)
    Private SelectionStart As Point = Point.Empty
    Private SelectionEnd As Point = Point.Empty
    Private IsSelecting As Boolean = False
    Private DragOffset As New List(Of PointF)

    Private DragStartGrid As Point = Point.Empty
    Private IsDragging As Boolean = False
    Private IsPlaceLedDragging As Boolean = False
    Private PixelFont As Font = Font
    Private PixelRect As RectangleF

    Private ImageBounds As New RectangleF(10, 10, 100, 100)
    Private IsResizing As Boolean = False
    Private IsDraggingImage As Boolean = False
    Private Const ResizeMargin As Integer = 5 ' How close to the edge to trigger resize
    Private ImageDragOffset As New PointF(0, 0)
    Private ActiveEdge As eResizeEdge = eResizeEdge.None
    Private LastControlSize As Size = Size.Empty

    Private _bgImg As Image = Nothing
    Public Property BgImg() As Image
        Get
            Return _bgImg
        End Get
        Set(value As Image)
            _bgImg = value
            Invalidate()
        End Set
    End Property
    Public ReadOnly Property LedCount() As Integer
        Get
            Return LEDs.Count
        End Get
    End Property
    Public ReadOnly Property VmapLedCount() As Integer
        Get
            Return LEDs.Where(Function(x) Not x.Hidden).Count()
        End Get
    End Property
    Public ReadOnly Property VmapZLedCount() As Integer
        Get
            Return LEDs.Where(Function(x) x.Hidden).Count()
        End Get
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
            For Each lc In LEDs
                points.Add(lc.LedCoordinates)
            Next

            Return points
        End Get
    End Property

    Public Sub AddLed(index As Integer, mindex As Integer, name As String, point As Point)
        LEDs.Add(New Led(mindex, name, point) With {.Index = index})

        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Function AddLeds(_leds As Integer, _pos As Point, Optional direction As eDirection = eDirection.Right,
                            Optional spacing As Integer = 0, Optional updatefont As Boolean = True) As Point
        Dim result As Point = Point.Empty
        If LedCount = 0 Then
            For i As Integer = 0 To _leds - 1
                Dim index = i
                Dim name = $"Led{i + 1}"
                Dim pos = GetNextPointFrom(_pos, i, direction, spacing * i)
                AddLed(index, index, name, pos)
                If i = _leds - 1 Then result = pos
            Next i
        Else
            Dim lastLed As Led = LEDs.Last
            For i As Integer = 0 To _leds - 1
                Dim index = If(lastLed.Index.HasValue, lastLed.Index.Value + i + 1, lastLed.MappingIndex + i + 1)
                Dim name = $"Led{index + 1}"
                Dim pos = GetNextPointFrom(_pos, i, direction, spacing * i)
                AddLed(index, index, name, pos)
                If i = _leds - 1 Then result = pos
            Next i
        End If

        If updatefont Then PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)

        Return result
    End Function

    Public Sub AddRectangle(g1 As Integer, g2 As Integer, g3 As Integer, g4 As Integer, _pos As Point, order As eRectOrder, spacing As Integer, rounded As Boolean)
        Select Case order
            Case eRectOrder.DownRightUpLeft
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.DownRight, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.RightUp, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.UpLeft, spacing, rounded)
            Case eRectOrder.DownLeftUpRight
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.DownLeft, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.LeftUp, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.UpRight, spacing, rounded)
            Case eRectOrder.UpRightDownLeft
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.UpRight, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.RightDown, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.DownLeft, spacing, rounded)
            Case eRectOrder.UpLeftDownRight
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.UpLeft, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.LeftDown, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.DownRight, spacing, rounded)
            Case eRectOrder.RightDownLeftUp
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.RightDown, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.DownLeft, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.LeftUp, spacing, rounded)
            Case eRectOrder.RightUpLeftDown
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.RightUp, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.UpLeft, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.LeftDown, spacing, rounded)
            Case eRectOrder.LeftDownRightUp
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.LeftDown, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.DownRight, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.RightUp, spacing, rounded)
            Case eRectOrder.LeftUpRightDown
                Dim pos1 = AddLShape(g1, g2, _pos, eLShapeOrder.LeftUp, spacing, rounded)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.UpRight, spacing)
                AddLShape(g3, g4, pos2, eLShapeOrder.RightDown, spacing, rounded)
        End Select
    End Sub

    Public Sub AddUShape(g1 As Integer, g2 As Integer, g3 As Integer, _pos As Point, order As eUShapeOrder, spacing As Integer, rounded As Boolean)
        Select Case order
            Case eUShapeOrder.DownRightUp
                Dim pos1 = AddLeds(g1, _pos, eDirection.Down, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.DownRight, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Right, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Right, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.RightUp, spacing)
                AddLeds(g3, pos4, eDirection.Up, spacing, False)
            Case eUShapeOrder.DownLeftUp
                Dim pos1 = AddLeds(g1, _pos, eDirection.Down, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.DownLeft, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Left, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Left, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.LeftUp, spacing)
                AddLeds(g3, pos4, eDirection.Up, spacing, False)
            Case eUShapeOrder.UpRightDown
                Dim pos1 = AddLeds(g1, _pos, eDirection.Up, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.UpRight, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Right, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Right, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.RightDown, spacing)
                AddLeds(g3, pos4, eDirection.Down, spacing, False)
            Case eUShapeOrder.UpLeftDown
                Dim pos1 = AddLeds(g1, _pos, eDirection.Up, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.UpLeft, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Left, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Left, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.LeftDown, spacing)
                AddLeds(g3, pos4, eDirection.Down, spacing, False)
            Case eUShapeOrder.RightDownLeft
                Dim pos1 = AddLeds(g1, _pos, eDirection.Right, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.RightDown, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Down, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Down, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.DownLeft, spacing)
                AddLeds(g3, pos4, eDirection.Left, spacing, False)
            Case eUShapeOrder.RightUpLeft
                Dim pos1 = AddLeds(g1, _pos, eDirection.Right, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.RightUp, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Up, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Up, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.UpLeft, spacing)
                AddLeds(g3, pos4, eDirection.Left, spacing, False)
            Case eUShapeOrder.LeftDownRight
                Dim pos1 = AddLeds(g1, _pos, eDirection.Left, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.LeftDown, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Down, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Down, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.DownRight, spacing)
                AddLeds(g3, pos4, eDirection.Right, spacing, False)
            Case eUShapeOrder.LeftUpRight
                Dim pos1 = AddLeds(g1, _pos, eDirection.Left, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, eLShapeOrder.LeftUp, spacing)
                Dim pos3 = AddLeds(g2, pos2, eDirection.Up, spacing, False)
                Dim pos4 = GetNextPointFrom(pos3, 1, eDirection.Up, spacing)
                If rounded Then pos4 = GetNextPointFrom(pos3, 1, eLShapeOrder.UpRight, spacing)
                AddLeds(g3, pos4, eDirection.Right, spacing, False)
        End Select

        PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)
    End Sub

    Public Function AddLShape(g1 As Integer, g2 As Integer, _pos As Point, order As eLShapeOrder, spacing As Integer, rounded As Boolean) As Point
        Dim result As Point = Point.Empty

        Select Case order
            Case eLShapeOrder.DownRight
                Dim pos1 = AddLeds(g1, _pos, eDirection.Down, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Right, spacing, False)
            Case eLShapeOrder.DownLeft
                Dim pos1 = AddLeds(g1, _pos, eDirection.Down, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Left, spacing, False)
            Case eLShapeOrder.UpRight
                Dim pos1 = AddLeds(g1, _pos, eDirection.Up, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Right, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Right, spacing, False)
            Case eLShapeOrder.UpLeft
                Dim pos1 = AddLeds(g1, _pos, eDirection.Up, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Left, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Left, spacing, False)
            Case eLShapeOrder.RightDown
                Dim pos1 = AddLeds(g1, _pos, eDirection.Right, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Down, spacing, False)
            Case eLShapeOrder.RightUp
                Dim pos1 = AddLeds(g1, _pos, eDirection.Right, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Up, spacing, False)
            Case eLShapeOrder.LeftDown
                Dim pos1 = AddLeds(g1, _pos, eDirection.Left, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Down, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Down, spacing, False)
            Case eLShapeOrder.LeftUp
                Dim pos1 = AddLeds(g1, _pos, eDirection.Left, spacing, False)
                Dim pos2 = GetNextPointFrom(pos1, 1, eDirection.Up, spacing)
                If rounded Then pos2 = GetNextPointFrom(pos1, 1, order, spacing)
                result = AddLeds(g2, pos2, eDirection.Up, spacing, False)
        End Select

        PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)

        Return result
    End Function

    Public Sub AddMatrix(_pos As Point, order As eMatrixOrder, serpentine As Boolean, _size As Size, spacing As Integer)
        Dim offset = spacing + 1

        Select Case order
            Case eMatrixOrder.HorizontalTopLeft
                If serpentine Then
                    For h As Integer = 0 To _size.Height - 1
                        If h Mod 2 = 0 Then
                            AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                        Else
                            AddLeds(_size.Width, New Point(((_pos.X + _size.Width) - 1) * offset, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                        End If
                    Next
                Else
                    For h As Integer = 0 To _size.Height - 1
                        AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                    Next
                End If
            Case eMatrixOrder.HorizontalTopRight
                If serpentine Then
                    For h As Integer = 0 To _size.Height - 1
                        If h Mod 2 = 0 Then
                            AddLeds(_size.Width, New Point(((_pos.X + _size.Width) - 1) * offset, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                        Else
                            AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                        End If
                    Next
                Else
                    For h As Integer = 0 To _size.Height - 1
                        AddLeds(_size.Width, New Point((_pos.X + _size.Width) - 1, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                    Next
                End If
            Case eMatrixOrder.HorizontalBottomLeft
                If serpentine Then
                    Dim i As Integer = 0

                    For h As Integer = _size.Height - 1 To 0 Step -1
                        If i Mod 2 = 0 Then
                            AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                        Else
                            AddLeds(_size.Width, New Point(((_pos.X + _size.Width) - 1) * offset, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                        End If
                        i += 1
                    Next
                Else
                    For h As Integer = _size.Height - 1 To 0 Step -1
                        AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                    Next
                End If
            Case eMatrixOrder.HorizontalBottomRight
                If serpentine Then
                    Dim i As Integer = 0

                    For h As Integer = _size.Height - 1 To 0 Step -1
                        If i Mod 2 = 0 Then
                            AddLeds(_size.Width, New Point(((_pos.X + _size.Width) - 1) * offset, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                        Else
                            AddLeds(_size.Width, New Point(_pos.X, _pos.Y + (h * offset)), eDirection.Right, spacing, False)
                        End If
                        i += 1
                    Next
                Else
                    For h As Integer = _size.Height - 1 To 0 Step -1
                        AddLeds(_size.Width, New Point((_pos.X + _size.Width) - 1, _pos.Y + (h * offset)), eDirection.Left, spacing, False)
                    Next
                End If
            Case eMatrixOrder.VerticalTopLeft
                If serpentine Then
                    For w As Integer = 0 To _size.Width - 1
                        If w Mod 2 = 0 Then
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                        Else
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), ((_pos.Y + _size.Height) - 1) * offset), eDirection.Up, spacing, False)
                        End If
                    Next
                Else
                    For w As Integer = 0 To _size.Width - 1
                        AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                    Next
                End If
            Case eMatrixOrder.VerticalTopRight
                If serpentine Then
                    Dim i As Integer = 0

                    For w As Integer = _size.Width - 1 To 0 Step -1
                        If i Mod 2 = 0 Then
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                        Else
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), ((_pos.Y + _size.Height) - 1) * offset), eDirection.Up, spacing, False)
                        End If
                        i += 1
                    Next
                Else
                    For w As Integer = _size.Width - 1 To 0 Step -1
                        AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                    Next
                End If
            Case eMatrixOrder.VerticalBottomLeft
                If serpentine Then
                    For w As Integer = 0 To _size.Width - 1
                        If w Mod 2 = 0 Then
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), ((_pos.Y + _size.Height) - 1) * offset), eDirection.Up, spacing, False)
                        Else
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                        End If
                    Next
                Else
                    For w As Integer = 0 To _size.Width - 1
                        AddLeds(_size.Height, New Point(_pos.X + (w * offset), (_pos.Y + _size.Height) - 1), eDirection.Up, spacing, False)
                    Next
                End If
            Case eMatrixOrder.VerticalBottomRight
                If serpentine Then
                    Dim i As Integer = 0

                    For w As Integer = _size.Width - 1 To 0 Step -1
                        If i Mod 2 = 0 Then
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), ((_pos.Y + _size.Height) - 1) * offset), eDirection.Up, spacing, False)
                        Else
                            AddLeds(_size.Height, New Point(_pos.X + (w * offset), _pos.Y), eDirection.Down, spacing, False)
                        End If
                        i += 1
                    Next
                Else
                    For w As Integer = _size.Width - 1 To 0 Step -1
                        AddLeds(_size.Height, New Point(_pos.X + (w * offset), (_pos.Y + _size.Height) - 1), eDirection.Up, spacing, False)
                    Next
                End If
        End Select

        PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)
    End Sub

    Private Function GetNextPointFrom(pos As Point, offset As Integer, order As eLShapeOrder, Optional spacing As Integer = 0) As Point
        Select Case order
            Case eLShapeOrder.DownRight
                Return New Point(pos.X + offset + spacing, pos.Y + offset + spacing)
            Case eLShapeOrder.DownLeft
                Return New Point(pos.X - offset - spacing, pos.Y + offset + spacing)
            Case eLShapeOrder.UpRight
                Return New Point(pos.X + offset + spacing, pos.Y - offset - spacing)
            Case eLShapeOrder.UpLeft
                Return New Point(pos.X - offset - spacing, pos.Y - offset - spacing)
            Case eLShapeOrder.RightDown
                Return New Point(pos.X + offset + spacing, pos.Y + offset + spacing)
            Case eLShapeOrder.RightUp
                Return New Point(pos.X + offset + spacing, pos.Y - offset - spacing)
            Case eLShapeOrder.LeftDown
                Return New Point(pos.X - offset - spacing, pos.Y + offset + spacing)
            Case eLShapeOrder.LeftUp
                Return New Point(pos.X - offset - spacing, pos.Y - offset - spacing)
        End Select
    End Function

    Private Function GetNextPointFrom(pos As Point, offset As Integer, direction As eDirection, Optional spacing As Integer = 0) As Point
        Select Case direction
            Case eDirection.Up
                Return New Point(pos.X, pos.Y - offset - spacing)
            Case eDirection.Right
                Return New Point(pos.X + offset + spacing, pos.Y)
            Case eDirection.Down
                Return New Point(pos.X, pos.Y + offset + spacing)
            Case eDirection.Left
                Return New Point(pos.X - offset - spacing, pos.Y)
        End Select
    End Function

    Public Function ItemOnHover() As Led
        Return LEDs.FirstOrDefault(Function(x) x.LedCoordinates = _ledPos)
    End Function

    Public Sub RemoveLed(led As Led)
        LEDs.Remove(led)
        If SelectedItems.Contains(led) Then SelectedItems.Remove(led)
        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Sub RemoveLeds()
        LEDs.RemoveAll(Function(x) x.Index.HasValue)
        SelectedItems.Clear()
        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        LastControlSize = Me.Size
        DoubleBuffered = True

        Translate()
    End Sub

    Private Sub PrepareGraphics(g As Graphics)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.CompositingQuality = CompositingQuality.HighSpeed
        g.InterpolationMode = InterpolationMode.Low
        g.PixelOffsetMode = PixelOffsetMode.HighSpeed
    End Sub

    Private Sub ucComponent_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        PrepareGraphics(g)
        g.Clear(BackColor)
        Dim sf As StringFormat = New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.FitBlackBox}

        Dim rectSize As New SizeF((Width - (Margin.Left + Margin.Right)) / _Width, (Height - (Margin.Top + Margin.Bottom)) / _Height)
        If rectSize.Width > rectSize.Height Then rectSize.Width = rectSize.Height Else rectSize.Height = rectSize.Width

        If BgImg IsNot Nothing Then
            g.DrawImage(BgImg, ImageBounds)

            If frmMain.rbToolResizeGI.Checked Then
                If IsResizing OrElse ImageBounds.Contains(PointToClient(MousePosition)) Then
                    Using pen As New Pen(Color.FromArgb(205, 150, 0), 1.0F)
                        g.DrawRectangle(pen, Rectangle.Round(ImageBounds))
                    End Using

                    Dim h As Integer = 8 ' Size of the corner square
                    Dim halfH As Integer = h / 2

                    ' Define the 4 corner rectangles
                    Dim corners As RectangleF() = {
                        New RectangleF(ImageBounds.X - halfH, ImageBounds.Y - halfH, h, h), ' Top-Left
                        New RectangleF(ImageBounds.Right - halfH, ImageBounds.Y - halfH, h, h), ' Top-Right
                        New RectangleF(ImageBounds.X - halfH, ImageBounds.Bottom - halfH, h, h), ' Bottom-Left
                        New RectangleF(ImageBounds.Right - halfH, ImageBounds.Bottom - halfH, h, h) ' Bottom-Right
                    }

                    ' Draw each handle
                    For Each rect In corners
                        ' Fill with white and draw a black border for visibility on any background[cite: 3]
                        g.FillRectangle(Brushes.White, rect)
                        g.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height)
                    Next

                    ' Optional: Draw a dashed border around the whole image to show it is "Active"[cite: 3]
                    Using p As New Pen(Color.White, 1.0F)
                        p.DashStyle = DashStyle.Dash
                        g.DrawRectangle(p, Rectangle.Round(ImageBounds))
                    End Using
                End If
            End If
        End If

        numRows = _Height
        numCols = _Width

        For row As Integer = 0 To numCols - 1
            For col As Integer = 0 To numRows - 1
                Dim x As Single = (rectSize.Width * row) + Margin.Left
                Dim y As Single = (rectSize.Height * col) + Margin.Top
                Dim p As Single = 3.0F
                Dim r As New RectangleF(x + p, y + p, rectSize.Width - p, rectSize.Height - p)

                Dim renderRect As New RectangleF(x, y, rectSize.Width, rectSize.Height)
                PixelRect = renderRect

                If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                    _ledPos = New Point(row, col)
                End If

                If LedCoordinatesPoints.Contains(New Point(row, col)) Then
                    Dim led = LEDs.Find(Function(xy) xy.LedCoordinates.X = row And xy.LedCoordinates.Y = col)
                    Dim displayIndex = If(Setting.ShiftIndex, led.MappingIndex + 1, led.MappingIndex)
                    Dim isSelected As Boolean = SelectedItems.Contains(led)

                    If isSelected Then
                        ' DRAW SELECTED STATE (Blue highlight)
                        Using sb2 As New SolidBrush(Color.LightBlue)
                            g.FillRoundedRectangle(sb2, r.ToRect, 7)
                        End Using
                        Using sb2 As New SolidBrush(Color.Blue)
                            g.DrawString(displayIndex.ToString(), PixelFont, sb2, renderRect, sf)
                        End Using
                    ElseIf renderRect.Contains(PointToClient(Control.MousePosition)) Then
                        ' DRAW HOVER STATE (Yellow/Gold highlight)
                        Using sb2 As New SolidBrush(Color.FromArgb(240, 220, 160))
                            g.FillRoundedRectangle(sb2, r.ToRect, 7)
                        End Using
                        Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                            g.DrawString(displayIndex.ToString(), PixelFont, sb2, renderRect, sf)
                        End Using
                    Else

                        If led.Hidden Then
                            ' DRAW HIDDEN STATE (Silver)
                            Using sb2 As New SolidBrush(Color.FromArgb(112, 111, 109))
                                g.FillRoundedRectangle(sb2, r.ToRect, 7)
                            End Using
                        Else
                            ' DRAW DEFAULT STATE (Standard Orange)
                            Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                                g.FillRoundedRectangle(sb2, r.ToRect, 7)
                            End Using
                        End If

                        Using sb2 As New SolidBrush(ForeColor)
                            g.DrawString(displayIndex.ToString(), PixelFont, sb2, renderRect, sf)
                        End Using
                    End If
                End If

                Using pen As New Pen(Color.FromArgb(35, 35, 35), 1.0F)
                    g.DrawRoundedRectangle(pen, r.ToRect, 7)
                End Using
            Next
        Next

        If IsSelecting Then
            Dim selRect = GetSelectionRect()
            Using sb As New SolidBrush(Color.FromArgb(50, Color.LightBlue))
                g.FillRectangle(sb, selRect)
                g.DrawRectangle(Pens.DodgerBlue, selRect)
            End Using
        End If

        If IsDragging Then
            Dim rectSizeW As Single = (Width - (Margin.Left + Margin.Right)) / _Width
            Dim rectSizeH As Single = (Height - (Margin.Top + Margin.Bottom)) / _Height
            If rectSizeW > rectSizeH Then rectSizeW = rectSizeH Else rectSizeH = rectSizeW

            Dim cursor = PointToClient(Control.MousePosition)

            For i As Integer = 0 To SelectedItems.Count - 1
                Dim led = SelectedItems(i)
                Dim offset = DragOffset(i)

                Dim x As Single = cursor.X - offset.X
                Dim y As Single = cursor.Y - offset.Y
                Dim p As Single = 3.0F
                Dim dr As New RectangleF(x + p, y + p, rectSizeW - p, rectSizeH - p)
                Dim renderRect As New RectangleF(x, y, rectSizeW, rectSizeH)

                Dim displayIndex = If(Setting.ShiftIndex, led.MappingIndex + 1, led.MappingIndex)

                Using sb As New SolidBrush(Color.FromArgb(125, Color.LightBlue))
                    g.FillRoundedRectangle(sb, dr.ToRect, 7)
                End Using

                Using sb2 As New SolidBrush(Color.Blue)
                    g.DrawString(displayIndex.ToString(), PixelFont, Brushes.Black, New RectangleF(dr.X + 1, dr.Y + 1, dr.Width, dr.Height), sf)
                    g.DrawString(displayIndex.ToString(), PixelFont, sb2, renderRect, sf)
                End Using

                Using pen As New Pen(Color.White, 1.0F)
                    g.DrawRoundedRectangle(pen, dr.ToRect, 7)
                End Using
            Next
        End If

        If ItemOnHover() <> Nothing Then
            Dim itm = ItemOnHover()
            Dim info = String.Format(Translation.Localization.LEDInfo, vbCrLf, itm.MappingIndex, itm.LedName, itm.LedCoordinates.X, itm.LedCoordinates.Y)
            Dim infoSize = TextRenderer.MeasureText(g, info, Font)
            Dim cursor = PointToClient(Control.MousePosition)
            Using sb As New SolidBrush(Color.FromArgb(45, 45, 45))
                Dim rect As Rectangle
                If itm.LedCoordinates.X >= (numCols - 2) AndAlso itm.LedCoordinates.Y >= (numRows - 2) Then
                    rect = New Rectangle(cursor.X - infoSize.Width - 30, cursor.Y - infoSize.Height - 30, infoSize.Width + 15, infoSize.Height + 15)
                ElseIf itm.LedCoordinates.X >= (numCols - 2) Then
                    rect = New Rectangle(cursor.X - infoSize.Width - 30, cursor.Y, infoSize.Width + 15, infoSize.Height + 15)
                ElseIf itm.LedCoordinates.Y >= (numRows - 2) Then
                    rect = New Rectangle(cursor.X, cursor.Y - infoSize.Height - 30, infoSize.Width + 15, infoSize.Height + 15)
                Else
                    rect = New Rectangle(cursor.X + 10, cursor.Y, infoSize.Width + 15, infoSize.Height + 15)
                End If
                g.FillRoundedRectangle(sb, rect, 7)
                Using sb2 As New SolidBrush(ForeColor)
                    Dim srect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width, rect.Height)
                    g.DrawString(info, Font, Brushes.Black, srect, sf)
                    g.DrawString(info, Font, sb2, rect, sf)
                End Using
                Using pen As New Pen(Color.Black, 1.0F)
                    g.DrawRoundedRectangle(pen, rect, 10)
                End Using
            End Using
        End If
    End Sub

    Private Function GetSelectionRect() As Rectangle
        Dim x = Math.Min(SelectionStart.X, SelectionEnd.X)
        Dim y = Math.Min(SelectionStart.Y, SelectionEnd.Y)
        Dim w = Math.Abs(SelectionStart.X - SelectionEnd.X)
        Dim h = Math.Abs(SelectionStart.Y - SelectionEnd.Y)
        Return New Rectangle(x, y, w, h)
    End Function

    Private Sub ucComponent_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Invalidate()
    End Sub

    Private Sub ucComponent_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Dim oldWidth As Integer = Me.Width
        Dim oldHeight As Integer = Me.Height

        If e.Delta > 0 Then
            Width += 100
            Height += 100
        Else
            If Width > 100 And Height > 100 Then
                Width -= 100
                Height -= 100
            End If
        End If

        Dim ratioX As Single = Me.Width / oldWidth
        Dim ratioY As Single = Me.Height / oldHeight

        ImageBounds = New RectangleF(
            ImageBounds.X * ratioX,
            ImageBounds.Y * ratioY,
            ImageBounds.Width * ratioX,
            ImageBounds.Height * ratioY
        )

        PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)
        Invalidate()
    End Sub

    Private Sub ucComponent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If frmMain.rbToolResizeGI.Checked Then
            Dim h As Integer = 10
            Dim rect = ImageBounds

            If New RectangleF(rect.X, rect.Y, h, h).Contains(e.Location) OrElse ActiveEdge = eResizeEdge.TopLeft Then
                Me.Cursor = Cursors.SizeNWSE
            ElseIf New RectangleF(rect.Right - h, rect.Y, h, h).Contains(e.Location) OrElse ActiveEdge = eResizeEdge.TopRight Then
                Me.Cursor = Cursors.SizeNESW
            ElseIf New RectangleF(rect.X, rect.Bottom - h, h, h).Contains(e.Location) OrElse ActiveEdge = eResizeEdge.BottomLeft Then
                Me.Cursor = Cursors.SizeNESW
            ElseIf New RectangleF(rect.Right - h, rect.Bottom - h, h, h).Contains(e.Location) OrElse ActiveEdge = eResizeEdge.BottomRight Then
                Me.Cursor = Cursors.SizeNWSE
            ElseIf rect.Contains(e.Location) OrElse IsDraggingImage Then
                Me.Cursor = Cursors.SizeAll
            Else
                Me.Cursor = Cursors.Default
            End If
        End If

        Select Case True
            Case frmMain.rbToolSelect.Checked
                If IsSelecting Then
                    SelectionEnd = e.Location

                    If (ModifierKeys And Keys.Control) <> Keys.Control Then
                        SelectedItems.Clear()
                    End If

                    Dim selRect = GetSelectionRect()
                    Dim rectSizeW As Single = (Width - (Margin.Left + Margin.Right)) / _Width
                    Dim rectSizeH As Single = (Height - (Margin.Top + Margin.Bottom)) / _Height
                    If rectSizeW > rectSizeH Then rectSizeW = rectSizeH Else rectSizeH = rectSizeW

                    For Each led In LEDs
                        Dim lx As Single = (rectSizeW * led.LedCoordinates.X) + Margin.Left
                        Dim ly As Single = (rectSizeH * led.LedCoordinates.Y) + Margin.Top
                        Dim lRect = New RectangleF(lx, ly, rectSizeW, rectSizeH)

                        If selRect.IntersectsWith(lRect.ToRect) Then
                            If Not SelectedItems.Contains(led) Then SelectedItems.Add(led)
                        End If
                    Next
                End If

            Case frmMain.rbToolPlaceLED.Checked
                If IsPlaceLedDragging Then
                    Dim hovered = ItemOnHover()
                    If hovered Is Nothing Then
                        AddLeds(1, _ledPos)
                        Invalidate()
                    End If
                End If

            Case frmMain.rbToolResizeGI.Checked
                If ActiveEdge <> eResizeEdge.None Then
                    Dim newX = ImageBounds.X
                    Dim newY = ImageBounds.Y
                    Dim newW = ImageBounds.Width
                    Dim newH = ImageBounds.Height

                    Select Case ActiveEdge
                        Case eResizeEdge.TopLeft
                            newX = e.X
                            newY = e.Y
                            newW = ImageBounds.Right - e.X
                            newH = ImageBounds.Bottom - e.Y
                        Case eResizeEdge.TopRight
                            newY = e.Y
                            newW = e.X - ImageBounds.X
                            newH = ImageBounds.Bottom - e.Y
                        Case eResizeEdge.BottomLeft
                            newX = e.X
                            newW = ImageBounds.Right - e.X
                            newH = e.Y - ImageBounds.Y
                        Case eResizeEdge.BottomRight
                            newW = e.X - ImageBounds.X
                            newH = e.Y - ImageBounds.Y
                    End Select

                    If newW > 20 Then
                        ImageBounds.X = newX
                        ImageBounds.Width = newW
                    End If
                    If newH > 20 Then
                        ImageBounds.Y = newY
                        ImageBounds.Height = newH
                    End If

                ElseIf IsDraggingImage Then
                    ImageBounds.X = e.X - ImageDragOffset.X
                    ImageBounds.Y = e.Y - ImageDragOffset.Y
                End If
                Invalidate()
        End Select

        Invalidate()
    End Sub

    Private Sub ucComponent_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        If IsSelecting Or IsDragging Then Return

        Select Case e.Button
            Case MouseButtons.Right
                NsContextMenu1.Show(MousePosition)
                NsContextMenu1.Tag = _ledPos
            Case MouseButtons.Left
                Select Case True
                    Case frmMain.rbToolSelect.Checked
                        Dim hovered = ItemOnHover()

                        If (ModifierKeys And Keys.Control) <> Keys.Control Then
                            SelectedItems.Clear()
                        End If

                        If hovered IsNot Nothing Then
                            SelectedItems.Add(hovered)
                        End If
                        Invalidate()
                    Case frmMain.rbToolPlaceLED.Checked
                        If IsPlaceLedDragging Then
                            Dim hovered = ItemOnHover()
                            If hovered Is Nothing Then
                                AddLeds(1, _ledPos)
                                Invalidate()
                            End If
                        End If
                End Select
        End Select
    End Sub

    Private Sub ucComponent_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                Select Case True
                    Case frmMain.rbToolSelect.Checked
                        Dim hovered = ItemOnHover()
                        If hovered IsNot Nothing Then
                            If Not SelectedItems.Contains(hovered) Then
                                If (ModifierKeys And Keys.Control) <> Keys.Control Then SelectedItems.Clear()
                                SelectedItems.Add(hovered)
                            End If

                            IsDragging = True
                            DragStartGrid = _ledPos
                            DragOffset.Clear()

                            Dim rectSizeW As Single = (Width - (Margin.Left + Margin.Right)) / _Width
                            Dim rectSizeH As Single = (Height - (Margin.Top + Margin.Bottom)) / _Height

                            If rectSizeW > rectSizeH Then rectSizeW = rectSizeH Else rectSizeH = rectSizeW

                            For Each led In SelectedItems
                                Dim ledScreenX As Single = (rectSizeW * led.LedCoordinates.X) + Margin.Left
                                Dim ledScreenY As Single = (rectSizeH * led.LedCoordinates.Y) + Margin.Top

                                DragOffset.Add(New PointF(e.X - ledScreenX, e.Y - ledScreenY))
                            Next
                        Else
                            If (ModifierKeys And Keys.Control) <> Keys.Control Then
                                SelectedItems.Clear()
                            End If

                            IsSelecting = True
                            SelectionStart = e.Location
                            SelectionEnd = e.Location
                        End If
                        Invalidate()

                    Case frmMain.rbToolPlaceLED.Checked
                        IsPlaceLedDragging = True

                    Case frmMain.rbToolResizeGI.Checked
                        Dim h As Integer = 10 ' Handle size
                        Dim rect = ImageBounds

                        If New RectangleF(rect.X, rect.Y, h, h).Contains(e.Location) Then
                            ActiveEdge = eResizeEdge.TopLeft
                        ElseIf New RectangleF(rect.Right - h, rect.Y, h, h).Contains(e.Location) Then
                            ActiveEdge = eResizeEdge.TopRight
                        ElseIf New RectangleF(rect.X, rect.Bottom - h, h, h).Contains(e.Location) Then
                            ActiveEdge = eResizeEdge.BottomLeft
                        ElseIf New RectangleF(rect.Right - h, rect.Bottom - h, h, h).Contains(e.Location) Then
                            ActiveEdge = eResizeEdge.BottomRight
                        ElseIf rect.Contains(e.Location) Then
                            IsDraggingImage = True
                            ImageDragOffset = New PointF(e.X - rect.X, e.Y - rect.Y)
                        End If
                        Invalidate()
                End Select
        End Select
    End Sub

    Private Sub ucComponent_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Select Case True
            Case frmMain.rbToolSelect.Checked
                If IsSelecting Then
                    IsSelecting = False
                ElseIf IsDragging Then
                    IsDragging = False

                    Dim deltaX As Integer = _ledPos.X - DragStartGrid.X
                    Dim deltaY As Integer = _ledPos.Y - DragStartGrid.Y

                    If deltaX <> 0 OrElse deltaY <> 0 Then
                        For Each led In SelectedItems
                            led.LedCoordinates = New Point(led.LedCoordinates.X + deltaX, led.LedCoordinates.Y + deltaY)
                        Next
                        RaiseEvent LEDsChanged(Me, New EventArgs())
                    End If
                End If
                Invalidate()
            Case frmMain.rbToolPlaceLED.Checked
                IsPlaceLedDragging = False
            Case frmMain.rbToolResizeGI.Checked
                IsResizing = False
                IsDraggingImage = False
                ActiveEdge = eResizeEdge.None
        End Select
    End Sub

    Private Sub ucComponent_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete
                If LedCount <> 0 Then
                    timerTicks += 1
                End If
        End Select
    End Sub

    Private Sub ucComponent_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Modifiers = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.C
                    Copy()
                Case Keys.V
                    Paste(_ledPos)
                Case Keys.H
                    SetLEDsHidden()
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Delete
                    If LedCount <> 0 Then
                        If timerTicks > 30 Then
                            RemoveLeds()
                            Invalidate()
                        Else
                            LEDs.RemoveAt(LedCount - 1)
                            Invalidate()
                        End If
                        timerTicks = 0
                    End If
                Case Keys.Left
                    MoveLeft()
                Case Keys.Right
                    MoveRight()
                Case Keys.Up
                    MoveUp()
                Case Keys.Down
                    MoveDown()
            End Select
        End If
    End Sub

    Private Sub tsmiLinear_Click(sender As Object, e As EventArgs) Handles tsmiLinear.Click
        Dim max = (numRows * numCols) - LedCount
        Dim fmt As New frmMulti(eMode.AddLinear, max, Me, NsContextMenu1.Tag)
        fmt.Show()
    End Sub

    Private Sub tsmiMatrix_Click(sender As Object, e As EventArgs) Handles tsmiMatrix.Click
        Dim max = (numRows * numCols) - LedCount
        Dim fmt As New frmMulti(eMode.AddMatrix, max, Me, NsContextMenu1.Tag)
        fmt.Show()
    End Sub

    Private Sub tsmiLShape_Click(sender As Object, e As EventArgs) Handles tsmiLShape.Click
        Dim max = (numRows * numCols) - LedCount
        Dim fmt As New frmMulti(eMode.AddLShape, max, Me, NsContextMenu1.Tag)
        fmt.Show()
    End Sub

    Private Sub tsmiUShape_Click(sender As Object, e As EventArgs) Handles tsmiUShape.Click
        Dim max = (numRows * numCols) - LedCount
        Dim fmt As New frmMulti(eMode.AddUShape, max, Me, NsContextMenu1.Tag)
        fmt.Show()
    End Sub

    Private Sub tsmiRectangle_Click(sender As Object, e As EventArgs) Handles tsmiRectangle.Click
        Dim max = (numRows * numCols) - LedCount
        Dim fmt As New frmMulti(eMode.AddRectangle, max, Me, NsContextMenu1.Tag)
        fmt.Show()
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        tsmiEditLED.Text = loc.EditLED
        tsmiRemoveLed.Text = loc.RemoveLastObject
        tsmiAutoResize.Text = loc.AutoResize
        tsmiInsertBgImage.Text = loc.InsertGuideImage

        tsmiGenerate.Text = loc.Generate
        tsmiLinear.Text = loc.Linear
        tsmiMatrix.Text = loc.Matrix
        tsmiLShape.Text = loc.LShape
        tsmiUShape.Text = loc.UShape
        tsmiRectangle.Text = loc.Rectangle

        ' Added 02/05/2026
        tsmiInsertBgImage.Text = loc.InsertGuideImage
        tsmiRotateLeft.Text = loc.RotateCounterclockwise
        tsmiRotateRight.Text = loc.RotateClockwise
        tsmiHideLEDs.Text = loc.HideLEDs
        tsmiCopy.Text = loc.Copy
        tsmiPaste.Text = loc.Paste
    End Sub

    Public Sub MoveUp()
        For i As Integer = 0 To LedCount - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y - 1)
            LEDs(i).LedCoordinates = newPos
        Next

        Invalidate()
    End Sub

    Public Sub MoveDown()
        For i As Integer = 0 To LedCount - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y + 1)
            LEDs(i).LedCoordinates = newPos
        Next

        Invalidate()
    End Sub

    Public Sub MoveLeft()
        For i As Integer = 0 To LedCount - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X - 1, led.LedCoordinates.Y)
            LEDs(i).LedCoordinates = newPos
        Next

        Invalidate()
    End Sub

    Public Sub MoveRight()
        For i As Integer = 0 To LedCount - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X + 1, led.LedCoordinates.Y)
            LEDs(i).LedCoordinates = newPos
        Next

        Invalidate()
    End Sub

    Public Sub AutoResize()
        If LedCount <> 0 Then
            Dim leftest = LEDs.MinBy(Function(x) x.LedCoordinates.X)
            If leftest.LedCoordinates.X < 0 Then
                Do While leftest.LedCoordinates.X < 0
                    MoveRight()
                Loop
            Else
                Do While leftest.LedCoordinates.X > 0
                    MoveLeft()
                Loop
            End If

            Dim topest = LEDs.MinBy(Function(x) x.LedCoordinates.Y)
            If topest.LedCoordinates.Y < 0 Then
                Do While topest.LedCoordinates.Y < 0
                    MoveDown()
                Loop
            Else
                Do While topest.LedCoordinates.Y > 0
                    MoveUp()
                Loop
            End If

            Dim rightest = LEDs.MaxBy(Function(x) Math.Abs(x.LedCoordinates.X + _Width))
            _Width = rightest.LedCoordinates.X + 1

            Dim bottomest = LEDs.MaxBy(Function(x) Math.Abs(x.LedCoordinates.Y + _Height))
            _Height = bottomest.LedCoordinates.Y + 1

            Invalidate()

            frmMain.numHeight.Value = _Height
            frmMain.numWidth.Value = _Width
        End If
    End Sub

    Public Sub EditLED(_pos As Point)
        Dim item As Led = SelectedItems.FirstOrDefault(Function(x) x.LedCoordinates = _pos)
        If item = Nothing Then item = ItemOnHover()

        If item <> Nothing Then
            Dim fmt As New frmMulti(eMode.Edit, Me, item)
            fmt.Show()
        End If
    End Sub

    Private Sub tsmiAutoResize_Click(sender As Object, e As EventArgs) Handles tsmiAutoResize.Click
        AutoResize()
    End Sub

    Private Sub tsmiEditLED_Click(sender As Object, e As EventArgs) Handles tsmiEditLED.Click
        EditLED(CType(NsContextMenu1.Tag, Point))
    End Sub

    Private Sub tsmiRemoveLed_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLed.Click
        LEDs.RemoveAt(LedCount - 1)
        Invalidate()
    End Sub

    Private Sub tsmiInsertBgImage_Click(sender As Object, e As EventArgs) Handles tsmiInsertBgImage.Click
        Dim ofd As New OpenFileDialog
        With ofd
            Dim codecs = ImageCodecInfo.GetImageEncoders
            Dim sep = String.Empty
            For Each c In codecs
                Dim codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim
                .Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension)
                sep = "|"
            Next c
            .Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*")
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            .Title = Translation.Localization.SelectImageFile
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            _bgImg = Image.FromFile(ofd.FileName)
        End If
    End Sub

    Public Sub RotateLEDsClockwise()
        If LEDs.Count = 0 Then Return

        If SelectedItems.Any() Then
            Dim oldWidth As Integer = _Width
            Dim oldHeight As Integer = _Height

            For Each led In SelectedItems
                Dim oldX = led.LedCoordinates.X
                Dim oldY = led.LedCoordinates.Y
                led.LedCoordinates = New Point((oldHeight - 1) - oldY, oldX)
            Next

            _Width = oldHeight
            _Height = oldWidth

            frmMain.numWidth.Value = _Width
            frmMain.numHeight.Value = _Height

            RaiseEvent LEDsChanged(Me, New EventArgs())
            Invalidate()
        Else
            Dim oldWidth As Integer = _Width
            Dim oldHeight As Integer = _Height

            For Each led In LEDs
                Dim oldX = led.LedCoordinates.X
                Dim oldY = led.LedCoordinates.Y
                led.LedCoordinates = New Point((oldHeight - 1) - oldY, oldX)
            Next

            _Width = oldHeight
            _Height = oldWidth

            frmMain.numWidth.Value = _Width
            frmMain.numHeight.Value = _Height

            RaiseEvent LEDsChanged(Me, New EventArgs())
            Invalidate()
        End If
    End Sub

    Public Sub RotateLEDsCounterClockwise()
        If LEDs.Count = 0 Then Return

        If SelectedItems.Any() Then
            Dim oldWidth As Integer = _Width
            Dim oldHeight As Integer = _Height

            For Each led In SelectedItems
                Dim oldX = led.LedCoordinates.X
                Dim oldY = led.LedCoordinates.Y
                led.LedCoordinates = New Point(oldY, (oldWidth - 1) - oldX)
            Next

            _Width = oldHeight
            _Height = oldWidth

            frmMain.numWidth.Value = _Width
            frmMain.numHeight.Value = _Height

            RaiseEvent LEDsChanged(Me, New EventArgs())
            Invalidate()
        Else
            Dim oldWidth As Integer = _Width
            Dim oldHeight As Integer = _Height

            For Each led In LEDs
                Dim oldX = led.LedCoordinates.X
                Dim oldY = led.LedCoordinates.Y
                led.LedCoordinates = New Point(oldY, (oldWidth - 1) - oldX)
            Next

            _Width = oldHeight
            _Height = oldWidth

            frmMain.numWidth.Value = _Width
            frmMain.numHeight.Value = _Height

            RaiseEvent LEDsChanged(Me, New EventArgs())
            Invalidate()
        End If
    End Sub

    Public Sub FlipLEDsHorizontal()
        If LEDs.Count = 0 Then Return
        If SelectedItems.Any() Then
            For Each led In SelectedItems
                led.LedCoordinates = New Point((_Width - 1) - led.LedCoordinates.X, led.LedCoordinates.Y)
            Next
            Invalidate()
        Else
            For Each led In LEDs
                led.LedCoordinates = New Point((_Width - 1) - led.LedCoordinates.X, led.LedCoordinates.Y)
            Next
            Invalidate()
        End If
    End Sub

    Public Sub flipLEDsVertical()
        If LEDs.Count = 0 Then Return
        If SelectedItems.Any() Then
            For Each led In SelectedItems
                led.LedCoordinates = New Point(led.LedCoordinates.X, (_Height - 1) - led.LedCoordinates.Y)
            Next
            Invalidate()
        Else
            For Each led In LEDs
                led.LedCoordinates = New Point(led.LedCoordinates.X, (_Height - 1) - led.LedCoordinates.Y)
            Next
            Invalidate()
        End If
    End Sub

    Public Sub SetLEDsHidden()
        If LEDs.Count = 0 Then Return

        If SelectedItems.Any() Then
            For Each led In SelectedItems
                led.Hidden = Not led.Hidden
            Next
            Invalidate()
        Else
            For Each led In LEDs
                led.Hidden = Not led.Hidden
            Next
            Invalidate()
        End If
    End Sub

    Public Sub Copy()
        Dim selectedLeds = SelectedItems
        If selectedLeds.Count > 0 Then
            Dim jsonExport As String = JsonConvert.SerializeObject(selectedLeds, Formatting.Indented)
            Clipboard.SetData("Component_LEDs", jsonExport)
        End If
    End Sub

    Public Sub Paste(position As Point)
        If Clipboard.ContainsData("Component_LEDs") Then
            Dim jsonImport As String = Clipboard.GetData("Component_LEDs").ToString()
            Try
                Dim importedLeds As List(Of Led) = JsonConvert.DeserializeObject(Of List(Of Led))(jsonImport)
                SelectedItems.Clear()

                For Each led In importedLeds
                    Dim offsetX As Integer = position.X - importedLeds(0).LedCoordinates.X
                    Dim offsetY As Integer = position.Y - importedLeds(0).LedCoordinates.Y
                    Dim coordinates = New Point(led.LedCoordinates.X + offsetX, led.LedCoordinates.Y + offsetY)
                    AddLeds(1, coordinates)
                Next
                SelectedItems = LEDs.Skip(LedCount - importedLeds.Count).Take(importedLeds.Count).ToList()
                Invalidate()
            Catch ex As Exception
                MsgBox("Failed to paste LEDs: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub tsmiCopy_Click(sender As Object, e As EventArgs) Handles tsmiCopy.Click
        Copy()
    End Sub

    Private Sub tsmiPaste_Click(sender As Object, e As EventArgs) Handles tsmiPaste.Click
        Paste(CType(NsContextMenu1.Tag, Point))
    End Sub

    Private Sub tsmiHideLEDs_Click(sender As Object, e As EventArgs) Handles tsmiHideLEDs.Click
        SetLEDsHidden()
    End Sub

    Private Sub tsmiRotateLeft_Click(sender As Object, e As EventArgs) Handles tsmiRotateLeft.Click
        RotateLEDsCounterClockwise()
    End Sub

    Private Sub tsmiRotateRight_Click(sender As Object, e As EventArgs) Handles tsmiRotateRight.Click
        RotateLEDsClockwise()
    End Sub

    Private Sub tsmiFlipHorizontal_Click(sender As Object, e As EventArgs) Handles tsmiFlipHorizontal.Click
        FlipLEDsHorizontal()
    End Sub

    Private Sub tsmiFlipVertical_Click(sender As Object, e As EventArgs) Handles tsmiFlipVertical.Click
        flipLEDsVertical()
    End Sub
End Class