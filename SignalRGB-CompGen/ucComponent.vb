Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Security.Cryptography.Pkcs
Imports Windows.Win32.System

Public Class ucComponent

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

    Public Sub AddLed(index As Integer, mindex As Integer, name As String, point As Point)
        LEDs.Add(New Led(mindex, name, point) With {.Index = index})

        RaiseEvent LEDsChanged(Me, New EventArgs())
    End Sub

    Public Sub AddLeds(quantities As Integer, _pos As Point, Optional direction As eDirection = eDirection.Right)
        If LEDs.Count = 0 Then
            For i As Integer = 0 To quantities - 1
                Dim index = i
                Dim name = $"Led{i + 1}"
                Dim pos = GetNextPointFrom(_pos, i, direction)
                AddLed(index, index, name, pos)
            Next i
        Else
            Dim lastLed As Led = LEDs.Last
            For i As Integer = 0 To quantities - 1
                Dim index = If(lastLed.Index.HasValue, lastLed.Index.Value + i + 1, lastLed.MappingIndex + i + 1)
                Dim mindex = lastLed.MappingIndex + i + 1
                Dim name = $"Led{mindex + i + 1}"
                Dim pos = GetNextPointFrom(_pos, i, direction)
                AddLed(index, index, name, pos)
            Next i
        End If
    End Sub

    Private Function GetNextPointFrom(pos As Point, offset As Integer, Optional direction As eDirection = eDirection.Right) As Point
        Select Case direction
            Case eDirection.Top
                Dim newPos = New Point(pos.X, pos.Y - offset)
                If newPos.Y < 0 Then
                    Return New Point(newPos.X, 0)
                Else
                    Return newPos
                End If
            Case eDirection.Right
                Return New Point(pos.X + offset, pos.Y)
            Case eDirection.Bottom
                Return New Point(pos.X, pos.Y + offset)
            Case eDirection.Left
                Dim newPos = New Point(pos.X - offset, pos.Y)
                If newPos.X < 0 Then
                    Return New Point(0, newPos.Y)
                Else
                    Return newPos
                End If
        End Select
    End Function

    Public Function ItemOnHover() As Led
        Return LEDs.FirstOrDefault(Function(x) x.LedCoordinates = _ledPos)
    End Function

    Public SelectedItem As Led = Nothing

    Public Sub RemoveLed(led As Led)
        LEDs.Remove(led)
        RaiseEvent LEDsChanged(Me, New EventArgs())
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
                    If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                        _ledPos = New Point(row, col)
                    End If

                    If LedCoordinatesPoints.Contains(New Point(row, col)) Then
                        Dim ledIndex = LEDs.FindIndex(Function(xy) xy.LedCoordinates.X = row AndAlso xy.LedCoordinates.Y = col)
                        Dim led = LEDs.Find(Function(z) z.MappingIndex = ledIndex)
                        'Update LED Index if it has no value.
                        If Not led.Index.HasValue Then
                            Dim idx = LEDs.IndexOf(led)
                            led.Index = ledIndex
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
                                Dim text As String = If(Setting.ShiftIndex, ledIndex + 1, ledIndex)
                                Dim adjFont = GetAdjustedFont(g, text, Font, CInt(renderRect.Width), Font.Size, 1.0F, False)
                                g.DrawString(text, adjFont, Brushes.Black, srect, sf)
                                g.DrawString(text, adjFont, sb2, renderRect, sf)
                            End Using
                        Else
                            If renderRect.Contains(PointToClient(Control.MousePosition)) Then
                                Using sb2 As New SolidBrush(Color.FromArgb(240, 220, 160))
                                    'g.FillRectangle(sb2, r)
                                    g.FillRoundedRectangle(sb2, r.ToRect, 7)
                                End Using
                                Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                                    Dim srect = New RectangleF(renderRect.X + 1, renderRect.Y + 1, renderRect.Width, renderRect.Height)
                                    Dim text As String = If(Setting.ShiftIndex, ledIndex + 1, ledIndex)
                                    Dim adjFont = GetAdjustedFont(g, text, Font, CInt(renderRect.Width), Font.Size, 1.0F, False)
                                    g.DrawString(text, adjFont, Brushes.Black, srect, sf)
                                    g.DrawString(text, adjFont, sb2, renderRect, sf)
                                End Using
                            Else
                                Using sb2 As New SolidBrush(Color.FromArgb(205, 150, 0))
                                    'g.FillRectangle(sb2, r)
                                    g.FillRoundedRectangle(sb2, r.ToRect, 7)
                                End Using
                                Using sb2 As New SolidBrush(ForeColor)
                                    Dim srect = New RectangleF(renderRect.X + 1, renderRect.Y + 1, renderRect.Width, renderRect.Height)
                                    Dim text As String = If(Setting.ShiftIndex, ledIndex + 1, ledIndex)
                                    Dim adjFont = GetAdjustedFont(g, text, Font, CInt(renderRect.Width), Font.Size, 1.0F, False)
                                    g.DrawString(text, adjFont, Brushes.Black, srect, sf)
                                    g.DrawString(text, adjFont, sb2, renderRect, sf)
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
                Dim adjFont = GetAdjustedFont(g, text, Font, CInt(dr.Width), Font.Size, 1.0F, False)
                g.DrawString(text, adjFont, Brushes.Black, srect, sf)
                g.DrawString(text, adjFont, sb2, dr, sf)
            End Using
            Using pen As New Pen(Color.White, 1.0F)
                'g.DrawRectangle(pen, dr)
                g.DrawRoundedRectangle(pen, dr.ToRect, 7)
            End Using
            'End If
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
                If SelectedItem = Nothing Then AddLeds(1, _ledPos)
                Invalidate()
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
        Invalidate()
    End Sub

    Private Sub tsmiRemoveLed_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLed.Click
        If LEDs.Count <> 0 Then
            RemoveLed(LEDs.Last)
            Invalidate()
        End If
    End Sub

    Private Sub ucComponent_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Delete
                If LEDs.Count <> 0 Then
                    RemoveLed(LEDs.Last)
                    Invalidate()
                End If
            Case Keys.Space
                AddLeds(1, _ledPos)
                Invalidate()
            Case Keys.Left
                MoveLeft
            Case Keys.Right
                MoveRight()
            Case Keys.Up
                MoveUp()
            Case Keys.Down
                MoveDown()
        End Select
    End Sub

    Private Sub tsmiAddLeds_Click(sender As Object, e As EventArgs) Handles tsmiAddLeds.Click
        Dim max = numRows * numCols - LEDs.Count
        Dim fmt As New frmMulti(eMode.Add, max, Me, CType(NsContextMenu1.Tag, Point))
        fmt.Show()
    End Sub

    Private Sub tsmiRemoveLastLEDs_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLastLEDs.Click
        If LEDs.Count <> 0 Then
            Dim fmt As New frmMulti(eMode.Remove, LEDs.Count, Me, CType(NsContextMenu1.Tag, Point))
            fmt.Show()
        End If
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        tsmiAddLed.Text = loc.AddLED
        tsmiEditLED.Text = loc.EditLED
        tsmiAddLeds.Text = loc.AddLEDs
        tsmiRemoveLed.Text = loc.RemoveLastLED
        tsmiRemoveLastLEDs.Text = loc.RemoveLastLEDs
        tsmiAutoResize.Text = loc.AutoResize
    End Sub

    Private Function GetAdjustedFont(graphics As Graphics, graphicString As String, originalFont As Font, containerWidth As Integer, maxFontSize As Integer, minFontSize As Integer, smallestOnFail As Boolean) As Font
        Dim testFont As Font = Nothing

        For adjustedSize As Integer = maxFontSize To minFontSize
            testFont = New Font(originalFont.Name, adjustedSize, originalFont.Style)
            Dim adjustedSizeNew As SizeF = G.MeasureString(graphicString, testFont)

            If containerWidth > Convert.ToInt32(adjustedSizeNew.Width) Then
                Return testFont
            End If
        Next

        If smallestOnFail Then
            Return testFont
        Else
            Return originalFont
        End If
    End Function

    Public Sub MoveUp()
        For i As Integer = 0 To LEDs.Count - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y - 1)
            LEDs(i).LedCoordinates = newPos
        Next
        Invalidate()
    End Sub

    Public Sub MoveDown()
        For i As Integer = 0 To LEDs.Count - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X, led.LedCoordinates.Y + 1)
            LEDs(i).LedCoordinates = newPos
        Next
        Invalidate()
    End Sub

    Public Sub MoveLeft()
        For i As Integer = 0 To LEDs.Count - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X - 1, led.LedCoordinates.Y)
            LEDs(i).LedCoordinates = newPos
        Next
        Invalidate()
    End Sub

    Public Sub MoveRight()
        For i As Integer = 0 To LEDs.Count - 1
            Dim led = LEDs(i)
            Dim newPos As New Point(led.LedCoordinates.X + 1, led.LedCoordinates.Y)
            LEDs(i).LedCoordinates = newPos
        Next
        Invalidate()
    End Sub

    Public Sub AutoResize()
        If LEDs.Count <> 0 Then
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
            Dim fed As New frmEdit(Me, item)
            fed.Show()
        End If
    End Sub

    Private Sub tsmiAutoResize_Click(sender As Object, e As EventArgs) Handles tsmiAutoResize.Click
        AutoResize()
    End Sub

    Private Sub tsmiEditLED_Click(sender As Object, e As EventArgs) Handles tsmiEditLED.Click
        EditLED(CType(NsContextMenu1.Tag, Point))
    End Sub
End Class
