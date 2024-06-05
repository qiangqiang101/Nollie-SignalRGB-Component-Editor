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

    Public Sub AddLeds(quantities As Integer)
        If LEDs.Count = 0 Then
            For i As Integer = 0 To quantities - 1
                Dim index = i
                Dim name = $"Led{i + 1}"
                Dim pos = GetNextPointFrom(_ledPos, i)
                AddLed(index, index, name, pos)
            Next
        Else
            Dim lastLed As Led = LEDs.Last
            For i As Integer = 0 To quantities - 1
                Dim index = If(lastLed.Index.HasValue, lastLed.Index.Value + i + 1, lastLed.MappingIndex + i + 1)
                Dim mindex = lastLed.MappingIndex + i + 1
                Dim name = $"Led{mindex + i + 1}"
                Dim pos = GetNextPointFrom(_ledPos, i)
                AddLed(index, index, name, pos)
            Next
        End If
    End Sub

    Private Function GetNextPointFrom(pos As Point, offset As Integer) As Point
        If pos.X >= numCols AndAlso pos.Y >= numRows Then
            Return Point.Empty
        Else
            If pos.X >= numCols Then
                Return New Point(pos.X, pos.Y + offset)
            Else
                Return New Point(pos.X + offset, pos.Y)
            End If
        End If
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

        Dim rectSize As New SizeF((Width - (Margin.Left + Margin.Right)) / _Width, (Height - (Margin.Top + Margin.Bottom)) / _Height)
        If rectSize.Width > rectSize.Height Then rectSize.Width = rectSize.Height Else rectSize.Height = rectSize.Width

        Dim matrix(_Width - 1, _Height - 1) As Integer
        Dim count As Integer = 0

        Dim dragRect As RectangleF = Nothing
        For row As Integer = 0 To matrix.GetUpperBound(0)
            For col As Integer = 0 To matrix.GetUpperBound(1)

                Using sb As New SolidBrush(Color.LightGray)
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
                                g.FillRectangle(sb2, r)
                            End Using
                            Using sb2 As New SolidBrush(Color.Blue)
                                g.DrawString(ledIndex, Font, sb2, renderRect, sf)
                            End Using
                        Else
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
                        End If
                    Else
                        g.FillRectangle(sb, r)
                        'Using sb2 As New SolidBrush(Color.White)
                        '    g.DrawString(index, Font, sb2, renderRect, sf)
                        'End Using
                    End If

                    Using pen As New Pen(Color.Black, 1.0F)
                        g.DrawRectangle(pen, r)
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
                g.FillRectangle(sb, dr)
            End Using
            Using sb2 As New SolidBrush(Color.Blue)
                g.DrawString(SelectedItem.Index, Font, sb2, dr, sf)
            End Using
            Using pen As New Pen(Color.White, 1.0F)
                g.DrawRectangle(pen, dr)
            End Using
            'End If
        End If

        If ItemOnHover() <> Nothing Then
            Dim itm = ItemOnHover()
            Dim info = $"Index: {itm.MappingIndex}{vbCrLf}Name: {itm.LedName}{vbCrLf}Position: {itm.LedCoordinates.X}, {itm.LedCoordinates.Y}"
            Dim infoSize = TextRenderer.MeasureText(g, info, Font)
            Dim cursor = PointToClient(Control.MousePosition)
            Using sb As New SolidBrush(Color.LightGoldenrodYellow)
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
                g.FillRoundedRectangle(sb, rect, 10)
                Using sb2 As New SolidBrush(ForeColor)
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
                ContextMenuStrip1.Show(MousePosition)
            Case MouseButtons.Left
                If Not IsDragging Then SelectedItem = ItemOnHover()
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
        AddLeds(1)
        Invalidate()
    End Sub

    Private Sub ToolStripTextBox_TextChanged(sender As Object, e As EventArgs) Handles tstxtAddLedQty.TextChanged, tstxtRemoveLedQty.TextChanged
        If Not IsNumeric(tstxtAddLedQty.Text) Then
            CType(sender, ToolStripTextBox).Clear()
        End If
    End Sub

    Private Sub tsmiAddLedsConfirm_Click(sender As Object, e As EventArgs) Handles tsmiAddLedsConfirm.Click
        If IsNumeric(tstxtAddLedQty.Text) Then
            AddLeds(CInt(tstxtAddLedQty.Text))
            Invalidate()
        End If
    End Sub

    Private Sub tsmiRemoveLed_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLed.Click
        If LEDs.Count <> 0 Then
            RemoveLed(LEDs.Last)
            Invalidate()
        End If
    End Sub

    Private Sub tsmiRemoveLedConfirm_Click(sender As Object, e As EventArgs) Handles tsmiRemoveLedConfirm.Click
        If IsNumeric(tstxtRemoveLedQty.Text) Then
            Dim lastNthLeds = LEDs.OrderByDescending(Function(x) x.MappingIndex).Take(CInt(tstxtRemoveLedQty.Text))
            For Each led In lastNthLeds
                RemoveLed(led)
                Invalidate()
            Next
        End If
    End Sub

    Private Sub ucComponent_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Delete Then
            If LEDs.Count <> 0 Then
                RemoveLed(LEDs.Last)
                Invalidate()
            End If
        ElseIf e.KeyCode = Keys.Space Then
            AddLeds(1)
            Invalidate()
        End If
    End Sub

End Class
