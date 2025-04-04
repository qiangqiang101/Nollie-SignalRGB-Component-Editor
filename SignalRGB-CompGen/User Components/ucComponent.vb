﻿Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Security.Cryptography.Pkcs
Imports Windows.Win32.System

Public Class ucComponent

    Private timerTicks As Integer = 0

    Public LEDs As New List(Of Led)

    Public Event LEDsChanged(sender As Object, e As EventArgs)

    Public numRows As Integer = 0
    Public numCols As Integer = 0

    Public ReadOnly Property LedCount() As Integer
        Get
            Return LEDs.Count
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
    Private IsDragging As Boolean = False

    Private PixelFont As Font = Font
    Private PixelRect As RectangleF

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

    Public SelectedItem As Led = Nothing
    Public SelectedObject As GeneratedObject = Nothing

    Public Sub RemoveLed(led As Led)
        LEDs.Remove(led)
        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Sub RemoveLeds()
        LEDs.RemoveAll(Function(x) x.Index.HasValue)
        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Sub RemoveLastObject()
        If UserMemory.LastGeneratedObject <> Nothing Then
            Dim lastNthLeds = LEDs.OrderByDescending(Function(x) x.MappingIndex).Take(UserMemory.LastGeneratedObject.LEDs)
            For Each led In lastNthLeds
                RemoveLed(led)
                Invalidate()
            Next

            'Save to temporary memory
            With UserMemory
                .RemoveLastGeneratedObject()
            End With
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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

        Dim matrix(_Width - 1, _Height - 1) As Integer
        Dim count As Integer = 0

        Dim dragRect As RectangleF = Nothing
        For row As Integer = 0 To matrix.GetUpperBound(0)
            For col As Integer = 0 To matrix.GetUpperBound(1)

                Using sb As New SolidBrush(Color.FromArgb(55, 55, 55))
                    numRows = matrix.GetUpperBound(1) + 1
                    numCols = matrix.GetUpperBound(0) + 1

                    Dim x As Single = (rectSize.Width * row) + Margin.Left
                    Dim y As Single = (rectSize.Height * col) + Margin.Top
                    Dim w As Single = rectSize.Width
                    Dim h As Single = rectSize.Height
                    Dim p As Single = 3.0F
                    Dim r As New RectangleF(x + p, y + p, w - p, h - p)
                    Dim index As Integer = col * numCols + row

                    Dim approximatelySize As New Size((numCols * rectSize.Width) + (p * 3) + Margin.Left + Margin.Right, (numRows * rectSize.Height) + (p * 3) + Margin.Top + Margin.Bottom)
                    If Width > approximatelySize.Width Then Width = approximatelySize.Width + (Margin.Right)
                    If Height > approximatelySize.Height Then Height = approximatelySize.Height + (Margin.Bottom)

                    Dim renderRect As New RectangleF(x, y, rectSize.Width, rectSize.Height)
                    PixelRect = renderRect
                    If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                        _ledPos = New Point(row, col)
                    End If

                    If LedCoordinatesPoints.Contains(New Point(row, col)) Then
                        Dim led = LEDs.Find(Function(xy) xy.LedCoordinates.X = row And xy.LedCoordinates.Y = col)
                        Dim displayIndex = If(Setting.ShiftIndex, led.MappingIndex + 1, led.MappingIndex)

                        'Update LED Index if it has no value.
                        If Not led.Index.HasValue Then
                            Dim idx = LEDs.IndexOf(led)
                            led.Index = led.MappingIndex
                            LEDs(idx) = led
                        End If

                        If led = SelectedItem Then
                            dragRect = r
                            Using sb2 As New SolidBrush(Color.LightBlue)
                                'g.FillRectangle(sb2, r)
                                g.FillRoundedRectangle(sb2, r.ToRect, 7)
                            End Using
                            Using sb2 As New SolidBrush(Color.Blue)
                                Dim srect = New RectangleF(renderRect.X + 1, renderRect.Y + 1, renderRect.Width, renderRect.Height)
                                Dim text As String = displayIndex
                                g.DrawString(text, PixelFont, Brushes.Black, srect, sf)
                                g.DrawString(text, PixelFont, sb2, renderRect, sf)
                            End Using
                        Else
                            If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                                Using sb2 As New SolidBrush(Color.FromArgb(240, 220, 160))
                                    'g.FillRectangle(sb2, r)
                                    g.FillRoundedRectangle(sb2, r.ToRect, 7)
                                End Using
                                Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                                    Dim srect = New RectangleF(renderRect.X + 1, renderRect.Y + 1, renderRect.Width, renderRect.Height)
                                    Dim text As String = displayIndex
                                    g.DrawString(text, PixelFont, Brushes.Black, srect, sf)
                                    g.DrawString(text, PixelFont, sb2, renderRect, sf)
                                End Using
                            Else
                                Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                                    'g.FillRectangle(sb2, r)
                                    g.FillRoundedRectangle(sb2, r.ToRect, 7)
                                End Using
                                Using sb2 As New SolidBrush(ForeColor)
                                    Dim srect = New RectangleF(renderRect.X + 1, renderRect.Y + 1, renderRect.Width, renderRect.Height)
                                    Dim text As String = displayIndex
                                    g.DrawString(text, PixelFont, Brushes.Black, srect, sf)
                                    g.DrawString(text, PixelFont, sb2, renderRect, sf)
                                End Using
                            End If
                        End If
                    Else
                        'g.FillRectangle(sb, r)
                        g.FillRoundedRectangle(sb, r.ToRect, 7)
                    End If

                    Using pen As New Pen(Color.FromArgb(35, 35, 35), 1.0F)
                        'g.DrawRectangle(pen, r)
                        g.DrawRoundedRectangle(pen, r.ToRect, 7)
                    End Using
                End Using
                count += 1
                If count >= LedCount Then count = 0
            Next
        Next

        If IsDragging Then
            'If led = SelectedItem Then
            Dim cursor = PointToClient(Control.MousePosition)
            Dim dr As New RectangleF(cursor.X - dragRect.Width / 2, cursor.Y - dragRect.Height / 2, dragRect.Width, dragRect.Height)
            Using sb As New SolidBrush(Color.FromArgb(125, Color.LightBlue))
                'g.FillRectangle(sb, dr)
                g.FillRoundedRectangle(sb, dr.ToRect, 7)
            End Using
            Using sb2 As New SolidBrush(Color.Blue)
                Dim srect = New RectangleF(dr.X + 1, dr.Y + 1, dr.Width, dr.Height)
                Dim text As String = If(Setting.ShiftIndex, SelectedItem.Index + 1, SelectedItem.Index)
                g.DrawString(text, PixelFont, Brushes.Black, srect, sf)
                g.DrawString(text, PixelFont, sb2, dr, sf)
            End Using
            Using pen As New Pen(Color.White, 1.0F)
                'g.DrawRectangle(pen, dr)
                g.DrawRoundedRectangle(pen, dr.ToRect, 7)
            End Using
            'End If
        End If

        'drawing the bubble on hover
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

        PixelFont = New Font(Font.FontFamily, GetFontSizeMatch("9999", Font, PixelRect.Size.ToSize), Font.Style)
    End Sub

    Private Sub ucComponent_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Invalidate()
    End Sub

    Private Sub ucComponent_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Select Case e.Button
            Case MouseButtons.Right
                NsContextMenu1.Show(MousePosition)
                NsContextMenu1.Tag = _ledPos
            Case MouseButtons.Left
                If Not IsDragging Then SelectedItem = ItemOnHover()
        End Select
    End Sub

    Private Sub ucComponent_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        Select Case e.Button
            Case MouseButtons.Left
                If SelectedItem = Nothing Then
                    AddLeds(1, _ledPos)
                    UserMemory.AddGeneratedObject(Translation.Localization.Single, LedCount - 2, 1)
                    Invalidate()
                End If
        End Select
    End Sub

    Private Sub ucComponent_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Select Case e.Button
            Case MouseButtons.Left
                If ItemOnHover() <> Nothing Then
                    IsDragging = True
                    SelectedItem = ItemOnHover()
                End If
        End Select
    End Sub

    Private Sub ucComponent_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Select Case e.Button
            Case MouseButtons.Left
                IsDragging = False
                If SelectedItem <> Nothing Then
                    Dim idx = LEDs.IndexOf(SelectedItem)
                    SelectedItem.LedCoordinates = _ledPos
                    LEDs(idx) = SelectedItem
                End If
        End Select
    End Sub

    Private Sub tsmiAddLed_Click(sender As Object, e As EventArgs) Handles tsmiAddLed.Click
        AddLeds(1, CType(NsContextMenu1.Tag, Point))
        UserMemory.AddGeneratedObject(Translation.Localization.Single, LedCount - 2, 1)
        Invalidate()
    End Sub

    Private Sub tsmiRemoveLed_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLed.Click
        RemoveLastObject()
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
        If e.Modifiers = Keys.Shift Then
            Select Case e.KeyCode
                Case Keys.Left
                    MoveLeft(SelectedObject)
                Case Keys.Right
                    MoveRight(SelectedObject)
                Case Keys.Up
                    MoveUp(SelectedObject)
                Case Keys.Down
                    MoveDown(SelectedObject)
            End Select
        Else
            Select Case e.KeyCode
                Case Keys.Delete
                    If LedCount <> 0 Then
                        If timerTicks > 30 Then
                            RemoveLeds()
                            UserMemory.ClearAllGeneratedObjects()
                            Invalidate()
                        Else
                            RemoveLastObject()
                        End If
                        timerTicks = 0
                    End If
                Case Keys.Space
                    AddLeds(1, _ledPos)
                    UserMemory.AddGeneratedObject(Translation.Localization.Single, LedCount - 2, 1)
                    Invalidate()
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

    Private Sub tsmiRemoveLastLEDs_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLastLEDs.Click
        If LedCount <> 0 Then
            Dim fmt As New frmMulti(eMode.Remove, LedCount, Me, CType(NsContextMenu1.Tag, Point))
            fmt.Show()
        End If
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        tsmiAddLed.Text = loc.AddLED
        tsmiEditLED.Text = loc.EditLED
        tsmiRemoveLed.Text = loc.RemoveLastObject
        tsmiRemoveLastLEDs.Text = loc.Removezz
        tsmiAutoResize.Text = loc.AutoResize

        tsmiGenerate.Text = loc.Generate
        tsmiLinear.Text = loc.Linear
        tsmiMatrix.Text = loc.Matrix
        tsmiLShape.Text = loc.LShape
        tsmiUShape.Text = loc.UShape
        tsmiRectangle.Text = loc.Rectangle
    End Sub

    Public Sub MoveUp(Optional [object] As GeneratedObject = Nothing)
        If [object] = Nothing Then
            For i As Integer = 0 To LedCount - 1
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y - 1)
                LEDs(i).LedCoordinates = newPos
            Next
        Else
            For i As Integer = [object].StartIndex + 1 To ([object].StartIndex + [object].LEDs)
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y - 1)
                LEDs(i).LedCoordinates = newPos
            Next
        End If

        Invalidate()
    End Sub

    Public Sub MoveDown(Optional [object] As GeneratedObject = Nothing)
        If [object] = Nothing Then
            For i As Integer = 0 To LedCount - 1
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y + 1)
                LEDs(i).LedCoordinates = newPos
            Next
        Else
            For i As Integer = [object].StartIndex + 1 To ([object].StartIndex + [object].LEDs)
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y + 1)
                LEDs(i).LedCoordinates = newPos
            Next
        End If

        Invalidate()
    End Sub

    Public Sub MoveLeft(Optional [object] As GeneratedObject = Nothing)
        If [object] = Nothing Then
            For i As Integer = 0 To LedCount - 1
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X - 1, led.LedCoordinates.Y)
                LEDs(i).LedCoordinates = newPos
            Next
        Else
            For i As Integer = [object].StartIndex + 1 To ([object].StartIndex + [object].LEDs)
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X - 1, led.LedCoordinates.Y)
                LEDs(i).LedCoordinates = newPos
            Next
        End If

        Invalidate()
    End Sub

    Public Sub MoveRight(Optional [object] As GeneratedObject = Nothing)
        If [object] = Nothing Then
            For i As Integer = 0 To LedCount - 1
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X + 1, led.LedCoordinates.Y)
                LEDs(i).LedCoordinates = newPos
            Next
        Else
            For i As Integer = [object].StartIndex + 1 To ([object].StartIndex + [object].LEDs)
                Dim led = LEDs(i)
                Dim newPos As New Point(led.LedCoordinates.X + 1, led.LedCoordinates.Y)
                LEDs(i).LedCoordinates = newPos
            Next
        End If

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
        Dim item As Led = SelectedItem
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

End Class
