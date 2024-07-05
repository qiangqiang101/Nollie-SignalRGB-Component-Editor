Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Imports System.Diagnostics.Eventing.Reader

'IMPORTANT:
'Please leave these comments in place as they help protect intellectual rights and allow
'developers to determine the version of the theme they are using. The preffered method
'of distributing this theme is through the Nimoru Software home page at nimoru.com.

'Name: Net Seal Theme
'Created: 4/15/2013
'Version: 1.0.0.0 beta
'Site: http://nimoru.com/

'This work is licensed under a Creative Commons Attribution 3.0 Unported License.
'To view a copy of this license, please visit http://creativecommons.org/licenses/by/3.0/

'Copyright © 2013 Nimoru Software

Module ThemeModule

    Friend G As Graphics

    Sub New()
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

    Friend Function MeasureString(text As String, font As Font, width As Integer) As SizeF
        Return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic)
    End Function

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Friend Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Friend Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

End Module

Class NSTheme
    Inherits ThemeContainer154

    Private _AccentOffset As Integer = 42
    Public Property AccentOffset() As Integer
        Get
            Return _AccentOffset
        End Get
        Set(ByVal value As Integer)
            _AccentOffset = value
            Invalidate()
        End Set
    End Property

    Sub New()
        Header = 30
        BackColor = Color.FromArgb(50, 50, 50)

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(60, 60, 60))

        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
    End Sub

    Protected Overrides Sub ColorHook()

    End Sub

    Private R1 As Rectangle

    Private P1, P2 As Pen
    Private B1 As SolidBrush

    Private Pad As Integer

    Protected Overrides Sub PaintHook()
        G.Clear(BackColor)
        DrawBorders(P2, 1)

        G.DrawLine(P1, 0, 26, Width, 26)
        G.DrawLine(P2, 0, 25, Width, 25)

        Pad = Math.Max(Measure().Width + 20, 80)
        R1 = New Rectangle(Pad, 17, Width - (Pad * 2) + _AccentOffset, 8)

        G.DrawRectangle(P2, R1)
        G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height)

        G.DrawLine(P1, 0, 29, Width, 29)
        G.DrawLine(P2, 0, 30, Width, 30)

        DrawText(Brushes.Black, HorizontalAlignment.Left, 8, 1)
        DrawText(Brushes.White, HorizontalAlignment.Left, 7, 0)

        G.FillRectangle(B1, 0, 27, Width, 2)
        DrawBorders(Pens.Black)
    End Sub

End Class

Class NSButton
    Inherits Control

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        PF = New Pen(Color.FromArgb(205, 150, 0))
    End Sub

    Private IsMouseDown As Boolean

    Private GP1, GP2 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P1, P2, PF As Pen

    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        If IsMouseDown Then
            PB1 = New PathGradientBrush(GP1)
            PB1.CenterColor = Color.FromArgb(60, 60, 60)
            PB1.SurroundColors = {Color.FromArgb(55, 55, 55)}
            PB1.FocusScales = New PointF(0.8F, 0.5F)

            G.FillPath(PB1, GP1)

            G.DrawPath(PF, GP1)
        Else
            GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
            G.FillPath(GB1, GP1)

            G.DrawPath(P1, GP1)
        End If


        G.DrawPath(P2, GP2)

        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(5, Height \ 2 - SZ1.Height / 2)

        If IsMouseDown Then
            PT1.X += 1.0F
            PT1.Y += 1.0F
        End If

        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        IsMouseDown = True
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        IsMouseDown = False
        Invalidate()
    End Sub

End Class

Class NSProgressBar
    Inherits Control

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            Invalidate()
        End Set
    End Property

    Private Sub Increment(ByVal amount As Integer)
        Value += amount
    End Sub

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        B1 = New SolidBrush(Color.FromArgb(200, 160, 0))
    End Sub

    Private GP1, GP2, GP3 As GraphicsPath

    Private R1, R2 As Rectangle

    Private P1, P2 As Pen
    Private B1 As SolidBrush
    Private GB1, GB2 As LinearGradientBrush

    Private I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        R1 = New Rectangle(0, 2, Width - 1, Height - 1)
        GB1 = New LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0F)

        G.SetClip(GP1)
        G.FillRectangle(GB1, R1)

        I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 3))

        If I1 > 1 Then
            GP3 = CreateRound(1, 1, I1, Height - 3, 7)

            R2 = New Rectangle(1, 1, I1, Height - 3)
            GB2 = New LinearGradientBrush(R2, Color.FromArgb(205, 150, 0), Color.FromArgb(150, 110, 0), 90.0F)

            G.FillPath(GB2, GP3)
            G.DrawPath(P1, GP3)

            G.SetClip(GP3)
            G.SmoothingMode = SmoothingMode.None

            G.FillRectangle(B1, R2.X, R2.Y + 1, R2.Width, R2.Height \ 2)

            G.SmoothingMode = SmoothingMode.AntiAlias
            G.ResetClip()
        End If

        G.DrawPath(P2, GP1)
        G.DrawPath(P1, GP2)
    End Sub

End Class

Class NSLabel
    Inherits Control

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)

        B1 = New SolidBrush(Color.FromArgb(205, 150, 0))
    End Sub

    Private _Value1 As String = "NET"
    Public Property Value1() As String
        Get
            Return _Value1
        End Get
        Set(ByVal value As String)
            _Value1 = value
            Invalidate()
        End Set
    End Property

    Private _Value2 As String = "SEAL"
    Public Property Value2() As String
        Get
            Return _Value2
        End Get
        Set(ByVal value As String)
            _Value2 = value
            Invalidate()
        End Set
    End Property

    Private B1 As SolidBrush

    Private PT1, PT2 As PointF
    Private SZ1, SZ2 As SizeF

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)

        SZ1 = G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic)
        SZ2 = G.MeasureString(Value2, Font, Width, StringFormat.GenericTypographic)

        PT1 = New PointF(0, Height \ 2 - SZ1.Height / 2)
        PT2 = New PointF(SZ1.Width + 1, Height \ 2 - SZ1.Height / 2)

        G.DrawString(Value1, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Value1, Font, Brushes.White, PT1)

        G.DrawString(Value2, Font, Brushes.Black, PT2.X + 1, PT2.Y + 1)
        G.DrawString(Value2, Font, B1, PT2)
    End Sub

End Class

<DefaultEvent("TextChanged")>
Class NSTextBox
    Inherits Control

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If Base IsNot Nothing Then
                Base.TextAlign = value
            End If
        End Set
    End Property

    Private _MaxLength As Integer = 32767
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If Base IsNot Nothing Then
                Base.MaxLength = value
            End If
        End Set
    End Property

    Private _ReadOnly As Boolean
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If Base IsNot Nothing Then
                Base.ReadOnly = value
            End If
        End Set
    End Property

    Private _UseSystemPasswordChar As Boolean
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If Base IsNot Nothing Then
                Base.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    Private _Multiline As Boolean
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If Base IsNot Nothing Then
                Base.Multiline = value

                If value Then
                    Base.Height = Height - 11
                Else
                    Height = Base.Height + 11
                End If
            End If
        End Set
    End Property

    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If Base IsNot Nothing Then
                Base.Text = value
            End If
        End Set
    End Property

    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If Base IsNot Nothing Then
                Base.Font = value
                Base.Location = New Point(5, 5)
                Base.Width = Width - 8

                If Not _Multiline Then
                    Height = Base.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        If Not Controls.Contains(Base) Then
            Controls.Add(Base)
        End If

        MyBase.OnHandleCreated(e)
    End Sub

    Private Base As TextBox
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        Cursor = Cursors.IBeam

        Base = New TextBox
        Base.Font = Font
        Base.Text = Text
        Base.MaxLength = _MaxLength
        Base.Multiline = _Multiline
        Base.ReadOnly = _ReadOnly
        Base.UseSystemPasswordChar = _UseSystemPasswordChar

        Base.ForeColor = Color.White
        Base.BackColor = Color.FromArgb(50, 50, 50)

        Base.BorderStyle = BorderStyle.None

        Base.Location = New Point(5, 5)
        Base.Width = Width - 14

        If _Multiline Then
            Base.Height = Height - 11
        Else
            Height = Base.Height + 11
        End If

        AddHandler Base.TextChanged, AddressOf OnBaseTextChanged
        AddHandler Base.KeyDown, AddressOf OnBaseKeyDown

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        PF = New Pen(Color.FromArgb(205, 150, 0))
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private P1, P2, PF As Pen
    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.9F, 0.5F)

        G.FillPath(PB1, GP1)

        If Base.Focused Then
            G.DrawPath(PF, GP1)
        Else
            G.DrawPath(P2, GP1)
        End If
        G.DrawPath(P1, GP2)
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = Base.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            Base.SelectAll()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Base.Location = New Point(5, 5)

        Base.Width = Width - 10
        Base.Height = Height - 11

        MyBase.OnResize(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Base.Focus()
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnEnter(e As EventArgs)
        Base.Focus()
        Invalidate()
        MyBase.OnEnter(e)
    End Sub

    Protected Overrides Sub OnLeave(e As EventArgs)
        Invalidate()
        MyBase.OnLeave(e)
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class NSCheckBox
    Inherits Control

    Event CheckedChanged(sender As Object)

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P11 = New Pen(Color.FromArgb(55, 55, 55))
        P22 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.Black, 2.0F)
        P4 = New Pen(Color.White, 2.0F)
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)

            Invalidate()
        End Set
    End Property

    Private GP1, GP2 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P11, P22, P3, P4 As Pen

    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 2, Height - 5, Height - 5, 5)
        GP2 = CreateRound(1, 3, Height - 7, Height - 7, 5)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)

        G.FillPath(PB1, GP1)
        G.DrawPath(P11, GP1)
        G.DrawPath(P22, GP2)

        If _Checked Then
            G.DrawLine(P3, 5, Height - 9, 8, Height - 7)
            G.DrawLine(P3, 7, Height - 7, Height - 8, 7)

            G.DrawLine(P4, 4, Height - 10, 7, Height - 8)
            G.DrawLine(P4, 6, Height - 8, Height - 9, 6)
        End If

        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)

        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = Not Checked
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class NSRadioButton
    Inherits Control

    Event CheckedChanged(sender As Object)

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value

            If _Checked Then
                InvalidateParent()
            End If

            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property

    Private Sub InvalidateParent()
        If Parent Is Nothing Then Return

        For Each C As Control In Parent.Controls
            If Not (C Is Me) AndAlso (TypeOf C Is NSRadioButton) Then
                DirectCast(C, NSRadioButton).Checked = False
            End If
        Next
    End Sub

    Private GP1 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P1, P2 As Pen

    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = New GraphicsPath
        GP1.AddEllipse(0, 2, Height - 5, Height - 5)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)

        G.FillPath(PB1, GP1)

        G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5)
        G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7)

        If _Checked Then
            G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15)
            G.FillEllipse(Brushes.White, 5, 7, Height - 15, Height - 15)
        End If

        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(Height - 3, Height \ 2 - SZ1.Height / 2)

        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = True
        MyBase.OnMouseDown(e)
    End Sub

End Class

Class NSComboBox
    Inherits ComboBox

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        DrawMode = DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList

        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.White, 2.0F)
        P3 = New Pen(Brushes.Black, 2.0F)
        P4 = New Pen(Color.FromArgb(65, 65, 65))
        PF = New Pen(Color.FromArgb(205, 150, 0))

        B1 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B2 = New SolidBrush(Color.FromArgb(55, 55, 55))
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P1, P2, P3, P4, PF As Pen
    Private B1, B2 As SolidBrush

    Private GB1 As LinearGradientBrush

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.SetClip(GP1)
        G.FillRectangle(GB1, ClientRectangle)
        G.ResetClip()

        If Focused Then
            G.DrawPath(PF, GP1)
        Else
            G.DrawPath(P1, GP1)
        End If
        G.DrawPath(P4, GP2)

        SZ1 = G.MeasureString(Text, Font)
        PT1 = New PointF(5, Height \ 2 - SZ1.Height / 2)

        G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(Text, Font, Brushes.White, PT1)

        G.DrawLine(P3, Width - 15, 10, Width - 11, 13)
        G.DrawLine(P3, Width - 7, 10, Width - 11, 13)
        G.DrawLine(Pens.Black, Width - 11, 13, Width - 11, 14)

        G.DrawLine(P2, Width - 16, 9, Width - 12, 12)
        G.DrawLine(P2, Width - 8, 9, Width - 12, 12)
        G.DrawLine(Pens.White, Width - 12, 12, Width - 12, 13)

        If Focused Then
            G.DrawLine(PF, Width - 22, 0, Width - 22, Height)
        Else
            G.DrawLine(P1, Width - 22, 0, Width - 22, Height)
        End If
        G.DrawLine(P4, Width - 23, 1, Width - 23, Height - 2)
        G.DrawLine(P4, Width - 21, 1, Width - 21, Height - 2)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            e.Graphics.FillRectangle(B1, e.Bounds)
        Else
            e.Graphics.FillRectangle(B2, e.Bounds)
        End If

        If Not e.Index = -1 Then
            e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, Brushes.White, e.Bounds)
        End If
    End Sub

End Class

Class NSTabControl
    Inherits TabControl

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        SizeMode = TabSizeMode.Fixed
        Alignment = TabAlignment.Left
        ItemSize = New Size(28, 115)

        DrawMode = TabDrawMode.OwnerDrawFixed

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(45, 45, 45), 2)

        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))
        B3 = New SolidBrush(Color.FromArgb(205, 150, 0))
        B4 = New SolidBrush(Color.FromArgb(65, 65, 65))

        SF1 = New StringFormat()
        SF1.LineAlignment = StringAlignment.Center
    End Sub

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            e.Control.BackColor = Color.FromArgb(50, 50, 50)
        End If

        MyBase.OnControlAdded(e)
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private R1, R2 As Rectangle

    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4 As SolidBrush

    Private PB1 As PathGradientBrush

    Private TP1 As TabPage
    Private SF1 As StringFormat

    Private Offset As Integer
    Private ItemHeight As Integer

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(Color.FromArgb(50, 50, 50))
        G.SmoothingMode = SmoothingMode.AntiAlias

        ItemHeight = ItemSize.Height + 2

        GP1 = CreateRound(0, 0, ItemHeight + 3, Height - 1, 7)
        GP2 = CreateRound(1, 1, ItemHeight + 3, Height - 3, 7)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.8F, 0.95F)

        G.FillPath(PB1, GP1)

        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)

        For I As Integer = 0 To TabCount - 1
            R1 = GetTabRect(I)
            R1.Y += 2
            R1.Height -= 3
            R1.Width += 1
            R1.X -= 1

            TP1 = TabPages(I)
            Offset = 0

            If SelectedIndex = I Then
                G.FillRectangle(B1, R1)

                For J As Integer = 0 To 1
                    G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9)

                    G.SmoothingMode = SmoothingMode.None
                    G.FillRectangle(B3, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.AntiAlias

                    Offset += 5
                Next

                G.DrawRectangle(P3, R1.X + 1, R1.Y - 1, R1.Width, R1.Height + 2)
                G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2)
                G.DrawRectangle(P2, R1)
            Else
                For J As Integer = 0 To 1
                    G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9)

                    G.SmoothingMode = SmoothingMode.None
                    G.FillRectangle(B4, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9)
                    G.SmoothingMode = SmoothingMode.AntiAlias

                    Offset += 5
                Next
            End If

            R1.X += 5 + Offset

            R2 = R1
            R2.Y += 1
            R2.X += 1

            G.DrawString(TP1.Text, Font, Brushes.Black, R2, SF1)
            G.DrawString(TP1.Text, Font, Brushes.White, R1, SF1)
        Next

        GP3 = CreateRound(ItemHeight, 0, Width - ItemHeight - 1, Height - 1, 7)
        GP4 = CreateRound(ItemHeight + 1, 1, Width - ItemHeight - 3, Height - 3, 7)

        G.DrawPath(P2, GP3)
        G.DrawPath(P1, GP4)
    End Sub

End Class

<DefaultEvent("CheckedChanged")>
Class NSOnOffBox
    Inherits Control

    Event CheckedChanged(sender As Object)

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))

        B1 = New SolidBrush(Color.FromArgb(35, 35, 35))
        B2 = New SolidBrush(Color.FromArgb(85, 85, 85))
        B3 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B4 = New SolidBrush(Color.FromArgb(205, 150, 0))
        B5 = New SolidBrush(Color.FromArgb(40, 40, 40))

        SF1 = New StringFormat()
        SF1.LineAlignment = StringAlignment.Center
        SF1.Alignment = StringAlignment.Near

        SF2 = New StringFormat()
        SF2.LineAlignment = StringAlignment.Center
        SF2.Alignment = StringAlignment.Far

        Size = New Size(56, 24)
        MinimumSize = Size
        MaximumSize = Size
    End Sub

    Private _Checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            RaiseEvent CheckedChanged(Me)

            Invalidate()
        End Set
    End Property

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, PF As Pen
    Private B1, B2, B3, B4, B5 As SolidBrush

    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush

    Private R1, R2, R3 As Rectangle
    Private SF1, SF2 As StringFormat

    Private Offset As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.3F, 0.3F)

        G.FillPath(PB1, GP1)
        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)

        R1 = New Rectangle(5, 0, Width - 10, Height + 2)
        R2 = New Rectangle(6, 1, Width - 10, Height + 2)

        R3 = New Rectangle(1, 1, (Width \ 2) - 1, Height - 3)

        If _Checked Then
            G.DrawString("On", Font, Brushes.Black, R2, SF1)
            G.DrawString("On", Font, Brushes.White, R1, SF1)

            R3.X += (Width \ 2) - 1
        Else
            G.DrawString("Off", Font, B1, R2, SF2)
            G.DrawString("Off", Font, B2, R1, SF2)
        End If

        GP3 = CreateRound(R3, 7)
        GP4 = CreateRound(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2, 7)

        GB1 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)

        G.FillPath(GB1, GP3)
        G.DrawPath(P2, GP3)
        G.DrawPath(P3, GP4)

        Offset = R3.X + (R3.Width \ 2) - 3

        For I As Integer = 0 To 1
            If _Checked Then
                G.FillRectangle(B1, Offset + (I * 5), 7, 2, Height - 14)
            Else
                G.FillRectangle(B3, Offset + (I * 5), 7, 2, Height - 14)
            End If

            G.SmoothingMode = SmoothingMode.None

            If _Checked Then
                G.FillRectangle(B4, Offset + (I * 5), 7, 2, Height - 14)
            Else
                G.FillRectangle(B5, Offset + (I * 5), 7, 2, Height - 14)
            End If

            G.SmoothingMode = SmoothingMode.AntiAlias
        Next
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Checked = Not Checked
        MyBase.OnMouseDown(e)
    End Sub

End Class

Class NSControlButton
    Inherits Control

    Enum Button As Byte
        None = 0
        Minimize = 1
        MaximizeRestore = 2
        Close = 3
    End Enum

    Private _ControlButton As Button = Button.Close
    Public Property ControlButton() As Button
        Get
            Return _ControlButton
        End Get
        Set(ByVal value As Button)
            _ControlButton = value
            Invalidate()
        End Set
    End Property

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Width = 18
        Height = 20

        MinimumSize = Size
        MaximumSize = Size

        Margin = New Padding(0)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)

        Select Case _ControlButton
            Case Button.Minimize
                DrawMinimize(3, 10)
            Case Button.MaximizeRestore
                If FindForm().WindowState = FormWindowState.Normal Then
                    DrawMaximize(3, 5)
                Else
                    DrawRestore(3, 4)
                End If
            Case Button.Close
                DrawClose(4, 5)
        End Select
    End Sub

    Private Sub DrawMinimize(ByVal x As Integer, ByVal y As Integer)
        G.FillRectangle(Brushes.White, x, y, 12, 5)
        G.DrawRectangle(Pens.Black, x, y, 11, 4)
    End Sub

    Private Sub DrawMaximize(ByVal x As Integer, ByVal y As Integer)
        G.DrawRectangle(New Pen(Color.White, 2), x + 2, y + 2, 8, 6)
        G.DrawRectangle(Pens.Black, x, y, 11, 9)
        G.DrawRectangle(Pens.Black, x + 3, y + 3, 5, 3)
    End Sub

    Private Sub DrawRestore(ByVal x As Integer, ByVal y As Integer)
        G.FillRectangle(Brushes.White, x + 3, y + 1, 8, 4)
        G.FillRectangle(Brushes.White, x + 7, y + 5, 4, 4)
        G.DrawRectangle(Pens.Black, x + 2, y + 0, 9, 9)

        G.FillRectangle(Brushes.White, x + 1, y + 3, 2, 6)
        G.FillRectangle(Brushes.White, x + 1, y + 9, 8, 2)
        G.DrawRectangle(Pens.Black, x, y + 2, 9, 9)
        G.DrawRectangle(Pens.Black, x + 3, y + 5, 3, 3)
    End Sub

    Private ClosePath As GraphicsPath
    Private Sub DrawClose(ByVal x As Integer, ByVal y As Integer)
        If ClosePath Is Nothing Then
            ClosePath = New GraphicsPath
            ClosePath.AddLine(x + 1, y, x + 3, y)
            ClosePath.AddLine(x + 5, y + 2, x + 7, y)
            ClosePath.AddLine(x + 9, y, x + 10, y + 1)
            ClosePath.AddLine(x + 7, y + 4, x + 7, y + 5)
            ClosePath.AddLine(x + 10, y + 8, x + 9, y + 9)
            ClosePath.AddLine(x + 7, y + 9, x + 5, y + 7)
            ClosePath.AddLine(x + 3, y + 9, x + 1, y + 9)
            ClosePath.AddLine(x + 0, y + 8, x + 3, y + 5)
            ClosePath.AddLine(x + 3, y + 4, x + 0, y + 1)
        End If

        G.FillPath(Brushes.White, ClosePath)
        G.DrawPath(Pens.Black, ClosePath)
    End Sub

    Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then

            Dim F As Form = FindForm()

            Select Case _ControlButton
                Case Button.Minimize
                    F.WindowState = FormWindowState.Minimized
                Case Button.MaximizeRestore
                    If F.WindowState = FormWindowState.Normal Then
                        F.WindowState = FormWindowState.Maximized
                    Else
                        F.WindowState = FormWindowState.Normal
                    End If
                Case Button.Close
                    F.Close()
            End Select

        End If

        Invalidate()
        MyBase.OnMouseClick(e)
    End Sub

End Class

Class NSGroupBox
    Inherits ContainerControl

    Private _DrawSeperator As Boolean
    Public Property DrawSeperator() As Boolean
        Get
            Return _DrawSeperator
        End Get
        Set(ByVal value As Boolean)
            _DrawSeperator = value
            Invalidate()
        End Set
    End Property

    Private _Title As String = "GroupBox"
    Public Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal value As String)
            _Title = value
            Invalidate()
        End Set
    End Property

    Private _SubTitle As String = "Details"
    Public Property SubTitle() As String
        Get
            Return _SubTitle
        End Get
        Set(ByVal value As String)
            _SubTitle = value
            Invalidate()
        End Set
    End Property

    Private _TitleFont As Font
    Private _SubTitleFont As Font

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        _TitleFont = New Font("Segoe UI", 9.0F)
        _SubTitleFont = New Font("Segoe UI", 9.0F)

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))

        B1 = New SolidBrush(Color.FromArgb(205, 150, 0))
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private PT1 As PointF
    Private SZ1, SZ2 As SizeF

    Private P1, P2 As Pen
    Private B1 As SolidBrush

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)

        SZ1 = G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic)
        SZ2 = G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic)

        G.DrawString(_Title, _TitleFont, Brushes.Black, 6, 6)
        G.DrawString(_Title, _TitleFont, B1, 5, 5)

        PT1 = New PointF(6.0F, SZ1.Height + 4.0F)

        G.DrawString(_SubTitle, _SubTitleFont, Brushes.Black, PT1.X + 1, PT1.Y + 1)
        G.DrawString(_SubTitle, _SubTitleFont, Brushes.White, PT1.X, PT1.Y)

        If _DrawSeperator Then
            Dim Y As Integer = CInt(PT1.Y + SZ2.Height) + 8

            G.DrawLine(P1, 4, Y, Width - 5, Y)
            G.DrawLine(P2, 4, Y + 1, Width - 5, Y + 1)
        End If
    End Sub

End Class

Class NSSeperator
    Inherits Control

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Height = 10

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
    End Sub

    Private P1, P2 As Pen

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)

        G.DrawLine(P1, 0, 5, Width, 5)
        G.DrawLine(P2, 0, 6, Width, 6)
    End Sub

End Class

<DefaultEvent("Scroll")>
Class NSTrackBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property

    Private _Maximum As Integer = 10
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            Invalidate()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Height = 17

        P1 = New Pen(Color.FromArgb(150, 110, 0), 2)
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        P3 = New Pen(Color.FromArgb(35, 35, 35))
        P4 = New Pen(Color.FromArgb(65, 65, 65))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private R1, R2, R3 As Rectangle
    Private I1 As Integer

    Private P1, P2, P3, P4 As Pen

    Private GB1, GB2, GB3 As LinearGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 5, Width - 1, 10, 5)
        GP2 = CreateRound(1, 6, Width - 3, 8, 5)

        R1 = New Rectangle(0, 7, Width - 1, 5)
        GB1 = New LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0F)

        I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
        R2 = New Rectangle(I1, 0, 10, 20)

        G.SetClip(GP2)
        G.FillRectangle(GB1, R1)

        R3 = New Rectangle(1, 7, R2.X + R2.Width - 2, 8)
        GB2 = New LinearGradientBrush(R3, Color.FromArgb(205, 150, 0), Color.FromArgb(150, 110, 0), 90.0F)

        G.SmoothingMode = SmoothingMode.None
        G.FillRectangle(GB2, R3)
        G.SmoothingMode = SmoothingMode.AntiAlias

        For I As Integer = 0 To R3.Width - 15 Step 5
            G.DrawLine(P1, I, 0, I + 15, Height)
        Next

        G.ResetClip()

        G.DrawPath(P2, GP1)
        G.DrawPath(P3, GP2)

        GP3 = CreateRound(R2, 5)
        GP4 = CreateRound(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2, 5)
        GB3 = New LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)

        G.FillPath(GB3, GP3)
        G.DrawPath(P3, GP3)
        G.DrawPath(P4, GP4)
    End Sub

    Private TrackDown As Boolean
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            I1 = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            R2 = New Rectangle(I1, 0, 10, 20)

            TrackDown = R2.Contains(e.Location)
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If TrackDown AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
            Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        TrackDown = False
        MyBase.OnMouseUp(e)
    End Sub

End Class

<DefaultEvent("ValueChanged")>
Class NSRandomPool
    Inherits Control

    Event ValueChanged(ByVal sender As Object)

    Private _Value As New StringBuilder
    ReadOnly Property Value() As String
        Get
            Return _Value.ToString()
        End Get
    End Property

    Private _FullValue As String
    ReadOnly Property FullValue() As String
        Get
            Return BitConverter.ToString(Table).Replace("-", "")
        End Get
    End Property

    Private RNG As New Random()

    Private ItemSize As Integer = 9
    Private DrawSize As Integer = 8

    Private WA As Rectangle

    Private RowSize As Integer
    Private ColumnSize As Integer

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))

        B1 = New SolidBrush(Color.FromArgb(30, 30, 30))
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        UpdateTable()
        MyBase.OnHandleCreated(e)
    End Sub

    Private Table As Byte()
    Private Sub UpdateTable()
        WA = New Rectangle(5, 5, Width - 10, Height - 10)

        RowSize = WA.Width \ ItemSize
        ColumnSize = WA.Height \ ItemSize

        WA.Width = RowSize * ItemSize
        WA.Height = ColumnSize * ItemSize

        WA.X = (Width \ 2) - (WA.Width \ 2)
        WA.Y = (Height \ 2) - (WA.Height \ 2)

        Table = New Byte((RowSize * ColumnSize) - 1) {}

        For I As Integer = 0 To Table.Length - 1
            Table(I) = CByte(RNG.Next(100))
        Next

        Invalidate()
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        UpdateTable()
    End Sub

    Private Index1 As Integer = -1
    Private Index2 As Integer

    Private InvertColors As Boolean

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        HandleDraw(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        HandleDraw(e)
        MyBase.OnMouseDown(e)
    End Sub

    Private Sub HandleDraw(e As MouseEventArgs)
        If e.Button = MouseButtons.Left OrElse e.Button = MouseButtons.Right Then
            If Not WA.Contains(e.Location) Then Return

            InvertColors = (e.Button = MouseButtons.Right)

            Index1 = GetIndex(e.X, e.Y)
            If Index1 = Index2 Then Return

            Dim L As Boolean = Not (Index1 Mod RowSize = 0)
            Dim R As Boolean = Not (Index1 Mod RowSize = (RowSize - 1))

            Randomize(Index1 - RowSize)
            If L Then Randomize(Index1 - 1)
            Randomize(Index1)
            If R Then Randomize(Index1 + 1)
            Randomize(Index1 + RowSize)

            _Value.Append(Table(Index1).ToString("X"))
            If _Value.Length > 32 Then _Value.Remove(0, 2)

            RaiseEvent ValueChanged(Me)

            Index2 = Index1
            Invalidate()
        End If
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private P1, P2 As Pen
    Private B1, B2 As SolidBrush

    Private PB1 As PathGradientBrush

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        GP1 = CreateRound(0, 0, Width - 1, Height - 1, 7)
        GP2 = CreateRound(1, 1, Width - 3, Height - 3, 7)

        PB1 = New PathGradientBrush(GP1)
        PB1.CenterColor = Color.FromArgb(50, 50, 50)
        PB1.SurroundColors = {Color.FromArgb(45, 45, 45)}
        PB1.FocusScales = New PointF(0.9F, 0.5F)

        G.FillPath(PB1, GP1)

        G.DrawPath(P1, GP1)
        G.DrawPath(P2, GP2)

        G.SmoothingMode = SmoothingMode.None

        For I As Integer = 0 To Table.Length - 1
            Dim C As Integer = Math.Max(Table(I), 75)

            Dim X As Integer = ((I Mod RowSize) * ItemSize) + WA.X
            Dim Y As Integer = ((I \ RowSize) * ItemSize) + WA.Y

            B2 = New SolidBrush(Color.FromArgb(C, C, C))

            G.FillRectangle(B1, X + 1, Y + 1, DrawSize, DrawSize)
            G.FillRectangle(B2, X, Y, DrawSize, DrawSize)

            B2.Dispose()
        Next

    End Sub

    Private Function GetIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        Return (((y - WA.Y) \ ItemSize) * RowSize) + ((x - WA.X) \ ItemSize)
    End Function

    Private Sub Randomize(ByVal index As Integer)
        If index > -1 AndAlso index < Table.Length Then
            If InvertColors Then
                Table(index) = CByte(RNG.Next(100))
            Else
                Table(index) = CByte(RNG.Next(100, 256))
            End If
        End If
    End Sub

End Class

Class NSKeyboard
    Inherits Control

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Const LowerKeys As String = "1234567890-=qwertyuiop[]asdfghjkl\;'zxcvbnm,./`"
    Const UpperKeys As String = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:""ZXCVBNM<>?~"

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Font = New Font("Segoe UI", 9.0F)

        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)

        MinimumSize = New Size(386, 162)
        MaximumSize = New Size(386, 162)

        Lower = LowerKeys.ToCharArray()
        Upper = UpperKeys.ToCharArray()

        PrepareCache()

        P1 = New Pen(Color.FromArgb(45, 45, 45))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(35, 35, 35))

        B1 = New SolidBrush(Color.FromArgb(100, 100, 100))
    End Sub

    Private _Target As Control
    Public Property Target() As Control
        Get
            Return _Target
        End Get
        Set(ByVal value As Control)
            _Target = value
        End Set
    End Property

    Private Shift As Boolean

    Private Pressed As Integer = -1
    Private Buttons As Rectangle()

    Private Lower As Char()
    Private Upper As Char()
    Private Other As String() = {"Shift", "Space", "Back"}

    Private UpperCache As PointF()
    Private LowerCache As PointF()

    Private Sub PrepareCache()
        Buttons = New Rectangle(50) {}
        UpperCache = New PointF(Upper.Length - 1) {}
        LowerCache = New PointF(Lower.Length - 1) {}

        Dim I As Integer

        Dim S As SizeF
        Dim R As Rectangle

        For Y As Integer = 0 To 3
            For X As Integer = 0 To 11
                I = (Y * 12) + X
                R = New Rectangle(X * 32, Y * 32, 32, 32)

                Buttons(I) = R

                If Not I = 47 AndAlso Not Char.IsLetter(Upper(I)) Then
                    S = TextGraphics.MeasureString(Upper(I), Font)
                    UpperCache(I) = New PointF(R.X + (R.Width \ 2 - S.Width / 2), R.Y + R.Height - S.Height - 2)

                    S = TextGraphics.MeasureString(Lower(I), Font)
                    LowerCache(I) = New PointF(R.X + (R.Width \ 2 - S.Width / 2), R.Y + R.Height - S.Height - 2)
                End If
            Next
        Next

        Buttons(48) = New Rectangle(0, 4 * 32, 2 * 32, 32)
        Buttons(49) = New Rectangle(Buttons(48).Right, 4 * 32, 8 * 32, 32)
        Buttons(50) = New Rectangle(Buttons(49).Right, 4 * 32, 2 * 32, 32)
    End Sub

    Private GP1 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1 As PointF

    Private P1, P2, P3 As Pen
    Private B1 As SolidBrush

    Private PB1 As PathGradientBrush
    Private GB1 As LinearGradientBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)

        Dim R As Rectangle

        Dim Offset As Integer
        G.DrawRectangle(P1, 0, 0, (12 * 32) + 1, (5 * 32) + 1)

        For I As Integer = 0 To Buttons.Length - 1
            R = Buttons(I)

            Offset = 0
            If I = Pressed Then
                Offset = 1

                GP1 = New GraphicsPath()
                GP1.AddRectangle(R)

                PB1 = New PathGradientBrush(GP1)
                PB1.CenterColor = Color.FromArgb(60, 60, 60)
                PB1.SurroundColors = {Color.FromArgb(55, 55, 55)}
                PB1.FocusScales = New PointF(0.8F, 0.5F)

                G.FillPath(PB1, GP1)
            Else
                GB1 = New LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
                G.FillRectangle(GB1, R)
            End If

            Select Case I
                Case 48, 49, 50
                    SZ1 = G.MeasureString(Other(I - 48), Font)
                    G.DrawString(Other(I - 48), Font, Brushes.Black, R.X + (R.Width \ 2 - SZ1.Width / 2) + Offset + 1, R.Y + (R.Height \ 2 - SZ1.Height / 2) + Offset + 1)
                    G.DrawString(Other(I - 48), Font, Brushes.White, R.X + (R.Width \ 2 - SZ1.Width / 2) + Offset, R.Y + (R.Height \ 2 - SZ1.Height / 2) + Offset)
                Case 47
                    DrawArrow(Color.Black, R.X + Offset + 1, R.Y + Offset + 1)
                    DrawArrow(Color.White, R.X + Offset, R.Y + Offset)
                Case Else
                    If Shift Then
                        G.DrawString(Upper(I), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1)
                        G.DrawString(Upper(I), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset)

                        If Not Char.IsLetter(Lower(I)) Then
                            PT1 = LowerCache(I)
                            G.DrawString(Lower(I), Font, B1, PT1.X + Offset, PT1.Y + Offset)
                        End If
                    Else
                        G.DrawString(Lower(I), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1)
                        G.DrawString(Lower(I), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset)

                        If Not Char.IsLetter(Upper(I)) Then
                            PT1 = UpperCache(I)
                            G.DrawString(Upper(I), Font, B1, PT1.X + Offset, PT1.Y + Offset)
                        End If
                    End If
            End Select

            G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2)
            G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height)

            If I = Pressed Then
                G.DrawLine(P1, R.X, R.Y, R.Right, R.Y)
                G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom)
            End If
        Next
    End Sub

    Private Sub DrawArrow(color As Color, rx As Integer, ry As Integer)
        Dim R As New Rectangle(rx + 8, ry + 8, 16, 16)
        G.SmoothingMode = SmoothingMode.AntiAlias

        Dim P As New Pen(color, 1)
        Dim C As New AdjustableArrowCap(3, 2)
        P.CustomEndCap = C

        G.DrawArc(P, R, 0.0F, 290.0F)

        P.Dispose()
        C.Dispose()
        G.SmoothingMode = SmoothingMode.None
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim Index As Integer = ((e.Y \ 32) * 12) + (e.X \ 32)

        If Index > 47 Then
            For I As Integer = 48 To Buttons.Length - 1
                If Buttons(I).Contains(e.X, e.Y) Then
                    Pressed = I
                    Exit For
                End If
            Next
        Else
            Pressed = Index
        End If

        HandleKey()
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        Pressed = -1
        Invalidate()
    End Sub

    Private Sub HandleKey()
        If _Target Is Nothing Then Return
        If Pressed = -1 Then Return

        Select Case Pressed
            Case 47
                _Target.Text = String.Empty
            Case 48
                Shift = Not Shift
            Case 49
                _Target.Text &= " "
            Case 50
                If Not _Target.Text.Length = 0 Then
                    _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1)
                End If
            Case Else
                If Shift Then
                    _Target.Text &= Upper(Pressed)
                Else
                    _Target.Text &= Lower(Pressed)
                End If
        End Select
    End Sub

End Class

<DefaultEvent("SelectedIndexChanged")>
Class NSPaginator
    Inherits Control

    Public Event SelectedIndexChanged(sender As Object, e As EventArgs)

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Size = New Size(202, 26)

        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)

        InvalidateItems()

        B1 = New SolidBrush(Color.FromArgb(50, 50, 50))
        B2 = New SolidBrush(Color.FromArgb(55, 55, 55))

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        P3 = New Pen(Color.FromArgb(65, 65, 65))
    End Sub

    Private _SelectedIndex As Integer
    Public Property SelectedIndex() As Integer
        Get
            Return _SelectedIndex
        End Get
        Set(ByVal value As Integer)
            _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0)
            Invalidate()
        End Set
    End Property

    Private _NumberOfPages As Integer
    Public Property NumberOfPages() As Integer
        Get
            Return _NumberOfPages
        End Get
        Set(ByVal value As Integer)
            _NumberOfPages = value
            _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0)
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property MaximumIndex As Integer
        Get
            Return NumberOfPages - 1
        End Get
    End Property

    Private ItemWidth As Integer

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            MyBase.Font = value

            InvalidateItems()
            Invalidate()
        End Set
    End Property

    Private Sub InvalidateItems()
        Dim S As Size = TextGraphics.MeasureString("000 ..", Font).ToSize()
        ItemWidth = S.Width + 10
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private R1 As Rectangle

    Private SZ1 As Size
    Private PT1 As Point

    Private P1, P2, P3 As Pen
    Private B1, B2 As SolidBrush

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        G.Clear(BackColor)
        G.SmoothingMode = SmoothingMode.AntiAlias

        Dim LeftEllipse, RightEllipse As Boolean

        If _SelectedIndex < 4 Then
            For I As Integer = 0 To Math.Min(MaximumIndex, 4)
                RightEllipse = (I = 4) AndAlso (MaximumIndex > 4)
                DrawBox(I * ItemWidth, I, False, RightEllipse)
            Next
        ElseIf _SelectedIndex > 3 AndAlso _SelectedIndex < (MaximumIndex - 3) Then
            For I As Integer = 0 To 4
                LeftEllipse = (I = 0)
                RightEllipse = (I = 4)
                DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse)
            Next
        Else
            For I As Integer = 0 To 4
                LeftEllipse = (I = 0) AndAlso (MaximumIndex > 4)
                DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, False)
            Next
        End If
    End Sub

    Private Sub DrawBox(x As Integer, index As Integer, leftEllipse As Boolean, rightEllipse As Boolean)
        R1 = New Rectangle(x, 0, ItemWidth - 4, Height - 1)

        GP1 = CreateRound(R1, 7)
        GP2 = CreateRound(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2, 7)

        Dim T As String = CStr(index + 1)

        If leftEllipse Then T = ".. " & T
        If rightEllipse Then T = T & " .."

        SZ1 = G.MeasureString(T, Font).ToSize()
        PT1 = New Point(R1.X + (R1.Width \ 2 - SZ1.Width \ 2), R1.Y + (R1.Height \ 2 - SZ1.Height \ 2))

        If index = _SelectedIndex Then
            G.FillPath(B1, GP1)

            Dim F As New Font(Font, FontStyle.Underline)
            G.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1)
            G.DrawString(T, F, Brushes.White, PT1)
            F.Dispose()

            G.DrawPath(P1, GP2)
            G.DrawPath(P2, GP1)
        Else
            G.FillPath(B2, GP1)

            G.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1)
            G.DrawString(T, Font, Brushes.White, PT1)

            G.DrawPath(P3, GP2)
            G.DrawPath(P1, GP1)
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim NewIndex As Integer
            Dim OldIndex As Integer = _SelectedIndex

            If _SelectedIndex < 4 Then
                NewIndex = (e.X \ ItemWidth)
            ElseIf _SelectedIndex > 3 AndAlso _SelectedIndex < (MaximumIndex - 3) Then
                NewIndex = (e.X \ ItemWidth)

                Select Case NewIndex
                    Case 2
                        NewIndex = OldIndex
                    Case Is < 2
                        NewIndex = OldIndex - (2 - NewIndex)
                    Case Is > 2
                        NewIndex = OldIndex + (NewIndex - 2)
                End Select
            Else
                NewIndex = MaximumIndex - (4 - (e.X \ ItemWidth))
            End If

            If (NewIndex < _NumberOfPages) AndAlso (Not NewIndex = OldIndex) Then
                SelectedIndex = NewIndex
                RaiseEvent SelectedIndexChanged(Me, Nothing)
            End If
        End If

        MyBase.OnMouseDown(e)
    End Sub

End Class

<DefaultEvent("Scroll")>
Class NSVScrollBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Width = 18

        B1 = New SolidBrush(Color.FromArgb(55, 55, 55))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(55, 55, 55))
        P4 = New Pen(Color.FromArgb(40, 40, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)

        GP1 = DrawArrow(4, 6, False)
        GP2 = DrawArrow(5, 7, False)

        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)

        GP3 = DrawArrow(4, Height - 11, True)
        GP4 = DrawArrow(5, Height - 10, True)

        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)

        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim Y As Integer
            Dim LY As Integer = Thumb.Y + (Thumb.Height \ 2) - 3

            For I As Integer = 0 To 2
                Y = LY + (I * 3)

                G.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y)
                G.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1)
            Next
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 9
        Dim H As Integer = 5

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 0, Width, ButtonSize)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(1, 0, Width - 3, ThumbSize)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class

<DefaultEvent("Scroll")>
Class NSHScrollBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private LSA As Rectangle
    Private RSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Height = 18

        B1 = New SolidBrush(Color.FromArgb(55, 55, 55))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(55, 55, 55))
        P4 = New Pen(Color.FromArgb(40, 40, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)

        GP1 = DrawArrow(6, 4, False)
        GP2 = DrawArrow(7, 5, False)

        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)

        GP3 = DrawArrow(Width - 11, 4, True)
        GP4 = DrawArrow(Width - 10, 5, True)

        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)

        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim X As Integer
            Dim LX As Integer = Thumb.X + (Thumb.Width \ 2) - 3

            For I As Integer = 0 To 2
                X = LX + (I * 3)

                G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5)
                G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5)
            Next
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 5
        Dim H As Integer = 9

        If flip Then
            GP.AddLine(x, y + 1, x, y + H + 1)
            GP.AddLine(x, y + H, x + W - 1, y + W)
        Else
            GP.AddLine(x + W, y, x + W, y + H)
            GP.AddLine(x + W, y + H, x + 1, y + W)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        LSA = New Rectangle(0, 0, ButtonSize, Height)
        RSA = New Rectangle(Width - ButtonSize, 0, ButtonSize, Height)
        Shaft = New Rectangle(LSA.Right + 1, 0, Width - (ButtonSize * 2) - 1, Height)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Width)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(0, 1, ThumbSize, Height - 3)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.X = CInt(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left AndAlso ShowThumb Then
            If LSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf RSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    Return
                Else
                    If e.X < Thumb.X Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.X - LSA.Width - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Width - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class

Class NSContextMenu
    Inherits ContextMenuStrip

    Sub New()
        Renderer = New ToolStripProfessionalRenderer(New NSColorTable())
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)
    End Sub

End Class

Class NSColorTable
    Inherits ProfessionalColorTable

    Private BackColor As Color = Color.FromArgb(55, 55, 55)

    Public Overrides ReadOnly Property ButtonSelectedBorder() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckPressedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property CheckSelectedBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuBorder() As Color
        Get
            Return Color.FromArgb(25, 25, 25)
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemBorder() As Color
        Get
            Return BackColor
        End Get
    End Property

    Public Overrides ReadOnly Property MenuItemSelected() As Color
        Get
            Return Color.FromArgb(65, 65, 65)
        End Get
    End Property

    Public Overrides ReadOnly Property SeparatorDark() As Color
        Get
            Return Color.FromArgb(35, 35, 35)
        End Get
    End Property

    Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
        Get
            Return BackColor
        End Get
    End Property

End Class