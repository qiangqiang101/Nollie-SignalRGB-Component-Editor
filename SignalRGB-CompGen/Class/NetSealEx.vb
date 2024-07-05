Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

<DefaultEvent("ValueChanged")>
Class NSNumericUpDown
    Inherits Control

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If Base IsNot Nothing Then Base.TextAlign = value
        End Set
    End Property

    Private _Minimum As Decimal = 0
    Property Minimum() As Decimal
        Get
            If Base IsNot Nothing Then
                Return Base.Minimum
            Else
                Return _Minimum
            End If
        End Get
        Set(value As Decimal)
            _Minimum = value
            If Base IsNot Nothing Then Base.Minimum = value
        End Set
    End Property

    Private _Maximum As Decimal = 100
    Property Maximum As Decimal
        Get
            If Base IsNot Nothing Then
                Return Base.Maximum
            Else
                Return _Maximum
            End If
        End Get
        Set(value As Decimal)
            _Maximum = value
            If Base IsNot Nothing Then Base.Maximum = value
        End Set
    End Property

    Private _ReadOnly As Boolean
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If Base IsNot Nothing Then Base.ReadOnly = value
        End Set
    End Property

    Private _ThousandsSeparator As Boolean = False
    Property ThousandsSeparator() As Boolean
        Get
            If Base IsNot Nothing Then
                Return Base.ThousandsSeparator
            Else
                Return _ThousandsSeparator
            End If
        End Get
        Set(ByVal value As Boolean)
            _ThousandsSeparator = value
            If Base IsNot Nothing Then Base.ThousandsSeparator = value
        End Set
    End Property

    Private _InterceptArrowKeys As Boolean = True
    Property InterceptArrowKeys() As Boolean
        Get
            If Base IsNot Nothing Then
                Return Base.InterceptArrowKeys
            Else
                Return _InterceptArrowKeys
            End If
        End Get
        Set(ByVal value As Boolean)
            _InterceptArrowKeys = value
            If Base IsNot Nothing Then Base.InterceptArrowKeys = value
        End Set
    End Property

    <Bindable(False), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)>
    Public Overrides Property Text As String
        Get
            If Base IsNot Nothing Then
                Return Base.Text
            Else
                If _ThousandsSeparator Then
                    Return Value.ToString("F2")
                Else
                    Return Value.ToString
                End If
            End If
        End Get
        Set(value As String)
        End Set
    End Property

    Private _DecimalPlaces As Integer = 0
    Property DecimalPlaces() As Integer
        Get
            If Base IsNot Nothing Then
                Return Base.DecimalPlaces
            Else
                Return _DecimalPlaces
            End If
        End Get
        Set(value As Integer)
            _DecimalPlaces = value
            If Base IsNot Nothing Then Base.DecimalPlaces = value
        End Set
    End Property

    Public Property Value As Decimal
        Get
            If Base IsNot Nothing Then
                Return Base.Value
            Else
                Return 0D
            End If
        End Get
        Set(ByVal value As Decimal)
            If Base IsNot Nothing Then Base.Value = value
        End Set
    End Property

    Private _Increment As Integer = 1
    Property Increment() As Integer
        Get
            If Base IsNot Nothing Then
                Return Base.Increment
            Else
                Return _Increment
            End If
        End Get
        Set(value As Integer)
            _Increment = value
            If Base IsNot Nothing Then Base.Increment = value
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
            End If
        End Set
    End Property

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        If Not Controls.Contains(Base) Then
            Controls.Add(Base)
        End If

        MyBase.OnHandleCreated(e)
    End Sub

    Private Base As NumericUpDown
    Private NsUp, NsDown As NSButton, ButtonSize As New Size(18, (Height / 2) - 2)
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        Cursor = Cursors.IBeam

        Base = New NumericUpDown
        With Base
            .Font = Font
            .Value = Text
            .Maximum = _Maximum
            .Minimum = _Minimum
            .InterceptArrowKeys = _InterceptArrowKeys
            .ReadOnly = _ReadOnly
            .ThousandsSeparator = _ThousandsSeparator
            .DecimalPlaces = _DecimalPlaces

            .ForeColor = Color.White
            .BackColor = Color.FromArgb(50, 50, 50)

            .BorderStyle = BorderStyle.None
            .Controls(0).Hide()

            .Location = New Point(5, 3)
            .Width = Width - 14
            .Height = Height - 14

            AddHandler .ValueChanged, AddressOf OnBaseValueChanged
        End With

        NsUp = New NSButton
        With NsUp
            .Font = New Font("Marlett", 6.0F)
            .Text = "t"
            .Anchor = AnchorStyles.Top And AnchorStyles.Right
            .Size = ButtonSize
            .Location = New Point(Width - (ButtonSize.Width + 1), 2)
            .Cursor = Cursors.Arrow

            AddHandler .Click, AddressOf NsUpButtonClicked
        End With
        Me.Controls.Add(NsUp)

        NsDown = New NSButton
        With NsDown
            .Font = New Font("Marlett", 6.0F)
            .Text = "u"
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Right
            .Size = ButtonSize
            .Location = New Point(Width - (ButtonSize.Width + 1), ButtonSize.Height + 2)
            .Cursor = Cursors.Arrow

            AddHandler .Click, AddressOf NsDownButtonClicked
        End With
        Me.Controls.Add(NsDown)

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
        PF = New Pen(Color.FromArgb(205, 150, 0))
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private P1, P2, PF As Pen
    Private PB1 As PathGradientBrush

    Public Event ValueChanged As EventHandler

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

    Private Sub OnBaseValueChanged(ByVal s As Object, ByVal e As EventArgs)
        Value = Base.Value

        RaiseEvent ValueChanged(s, e)
    End Sub

    Private Sub NsUpButtonClicked(ByVal s As Object, ByVal e As EventArgs)
        If Not Base.Value >= Base.Maximum Then
            Base.Value += Increment
        End If
    End Sub

    Private Sub NsDownButtonClicked(ByVal s As Object, ByVal e As EventArgs)
        If Not Base.Value <= Base.Minimum Then
            Base.Value -= Increment
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Base.Location = New Point(5, 3)
        Base.Width = Width - 10
        Base.Height = Height - 10

        ButtonSize = New Size(20, (Height / 2) - 2)

        NsUp.Size = ButtonSize
        NsUp.Location = New Point(Width - (ButtonSize.Width + 1), 2)

        NsDown.Size = ButtonSize
        NsDown.Location = New Point(Width - (ButtonSize.Width + 1), ButtonSize.Height + 2)

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

Class NSMenuStrip
    Inherits MenuStrip

    Sub New()
        Renderer = New ToolStripProfessionalRenderer(New NSColorTable())
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        MyBase.OnPaint(e)
    End Sub

End Class

Class NSComboBoxColorPicker
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

        Items.AddRange(New Object() {Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.Aquamarine, Color.Azure, Color.Beige, Color.Bisque, Color.Black, Color.BlanchedAlmond, Color.Blue,
                       Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Cornsilk, Color.Crimson,
                       Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange,
                       Color.DarkOrchid, Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray, Color.DarkTurquoise, Color.DarkViolet, Color.DeepPink,
                       Color.DeepSkyBlue, Color.DimGray, Color.DodgerBlue, Color.Firebrick, Color.FloralWhite, Color.ForestGreen, Color.Fuchsia, Color.Gainsboro, Color.GhostWhite, Color.Gold,
                       Color.Goldenrod, Color.Gray, Color.Green, Color.GreenYellow, Color.Honeydew, Color.HotPink, Color.IndianRed, Color.Indigo, Color.Ivory, Color.Khaki, Color.Lavender,
                       Color.LavenderBlush, Color.LawnGreen, Color.LemonChiffon, Color.LightBlue, Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGreen, Color.LightGray,
                       Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.Lime, Color.LimeGreen,
                       Color.Linen, Color.Magenta, Color.Maroon, Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, Color.MediumSlateBlue,
                       Color.MediumSpringGreen, Color.MediumTurquoise, Color.MediumVioletRed, Color.MidnightBlue, Color.MintCream, Color.MistyRose, Color.Moccasin, Color.NavajoWhite, Color.Navy,
                       Color.OldLace, Color.Olive, Color.OliveDrab, Color.Orange, Color.OrangeRed, Color.Orchid, Color.PaleGoldenrod, Color.PaleGreen, Color.PaleTurquoise, Color.PaleVioletRed,
                       Color.PapayaWhip, Color.PeachPuff, Color.Peru, Color.Pink, Color.Plum, Color.PowderBlue, Color.Purple, Color.RebeccaPurple, Color.Red, Color.RosyBrown, Color.RoyalBlue,
                       Color.SaddleBrown, Color.Salmon, Color.SandyBrown, Color.SeaGreen, Color.SeaShell, Color.Sienna, Color.Silver, Color.SkyBlue, Color.SlateBlue, Color.SlateGray, Color.Snow,
                       Color.SpringGreen, Color.SteelBlue, Color.Tan, Color.Teal, Color.Thistle, Color.Tomato, Color.Turquoise, Color.Violet, Color.Wheat, Color.White, Color.WhiteSmoke,
                       Color.Yellow, Color.YellowGreen})
        MaxDropDownItems = 20
        IntegralHeight = False
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private SZ1 As SizeF
    Private PT1, PT2 As PointF
    Private RT1 As Rectangle

    Private P1, P2, P3, P4, PF As Pen
    Private B1, B2 As SolidBrush

    Private GB1 As LinearGradientBrush
    Private SF1 = New StringFormat()


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


        SF1.LineAlignment = StringAlignment.Near Or StringAlignment.Center

        RT1 = New Rectangle(6, 4, 30, Height - 8)
        PT2 = New PointF(RT1.Width + 8, Height \ 2 - SZ1.Height / 2)
        Using sb As New SolidBrush(Color.FromName(Text))
            e.Graphics.FillRectangle(sb, RT1)
            Using pen As New Pen(Brushes.Black)
                e.Graphics.DrawRectangle(pen, RT1)
            End Using
            G.DrawString(Text, Font, Brushes.Black, PT2.X + 1, PT2.Y + 1)
            G.DrawString(Text, Font, Brushes.White, PT2)
        End Using

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

        If e.Index >= 0 Then
            Dim rect1 = New Rectangle(e.Bounds.Left + 6, e.Bounds.Top + 2, 30, e.Bounds.Height - 4)
            Dim rect2 = Rectangle.FromLTRB(rect1.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom)
            Using sb As New SolidBrush(CType(Items(e.Index), Color))
                e.Graphics.FillRectangle(sb, rect1)
                Using pen As New Pen(Brushes.Black)
                    e.Graphics.DrawRectangle(pen, rect1)
                End Using
                e.Graphics.DrawString(GetItemText(Items(e.Index)), e.Font, Brushes.White, rect2, SF1)
            End Using
        End If
    End Sub

End Class