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
            If value < Minimum Then value = Minimum
            If value > Maximum Then value = Maximum
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

Class NSListView
    Inherits Control

    Public Class NSListViewItem
        Public Property Text() As String
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Property SubItems() As List(Of NSListViewSubItem)
        Public Property Tag() As Object

        Protected UniqueId As Guid

        Public Sub New()
            UniqueId = Guid.NewGuid()
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is NSListViewItem Then
                Return ((CType(obj, NSListViewItem)).UniqueId = UniqueId)
            End If

            Return False
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function
    End Class

    Public Class NSListViewSubItem
        Public Property Text() As String

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Public Class NSListViewColumnHeader
        Public Property Text() As String
        Public Property Width() As Integer

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private _Items As List(Of NSListViewItem) = New List(Of NSListViewItem)()

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property Items() As NSListViewItem()
        Get
            Return _Items.ToArray()
        End Get
        Set(ByVal value As NSListViewItem())
            _Items = New List(Of NSListViewItem)(value)
            InvalidateScroll()
        End Set
    End Property

    Private _SelectedItems As List(Of NSListViewItem) = New List(Of NSListViewItem)()

    Public Event SelectedItemsChanged(sender As Object, e As EventArgs)

    Public ReadOnly Property SelectedItems As NSListViewItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Private _Columns As List(Of NSListViewColumnHeader) = New List(Of NSListViewColumnHeader)()

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    Public Property Columns() As NSListViewColumnHeader()
        Get
            Return _Columns.ToArray()
        End Get
        Set(ByVal value As NSListViewColumnHeader())
            _Columns = New List(Of NSListViewColumnHeader)(value)
            InvalidateColumns()
        End Set
    End Property

    Private _MultiSelect As Boolean = True

    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
                RaiseEvent SelectedItemsChanged(Me, New EventArgs())
            End If

            Invalidate()
        End Set
    End Property

    Private ItemHeight As Integer = 24

    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            ItemHeight = Convert.ToInt32(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6

            If VS IsNot Nothing Then
                VS.SmallChange = ItemHeight
                VS.LargeChange = ItemHeight
            End If

            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

    Public Sub AddItem(ByVal text As String, ParamArray subItems As String())
        Dim Items As List(Of NSListViewSubItem) = New List(Of NSListViewSubItem)()

        For Each I As String In subItems
            Dim SubItem As NSListViewSubItem = New NSListViewSubItem()
            SubItem.Text = I
            Items.Add(SubItem)
        Next

        Dim Item As NSListViewItem = New NSListViewItem()
        Item.Text = text
        Item.SubItems = Items
        _Items.Add(Item)
        InvalidateScroll()
    End Sub

    Public Sub AddItem(item As NSListViewItem)
        _Items.Add(item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItemAt(ByVal index As Integer)
        _Items.RemoveAt(index)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItem(ByVal item As NSListViewItem)
        _Items.Remove(item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItems(ByVal items As NSListViewItem())
        For Each I As NSListViewItem In items
            _Items.Remove(I)
        Next

        InvalidateScroll()
    End Sub

    Public Sub Clear()
        _Items.Clear()

        InvalidateScroll()
    End Sub

    Private VS As NSVScrollBar

    Public Sub New()
        SetStyle(CType(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)
        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))
        B1 = New SolidBrush(Color.FromArgb(62, 62, 62))
        B2 = New SolidBrush(Color.FromArgb(65, 65, 65))
        B3 = New SolidBrush(Color.FromArgb(47, 47, 47))
        B4 = New SolidBrush(Color.FromArgb(50, 50, 50))
        VS = New NSVScrollBar()
        VS.SmallChange = ItemHeight
        VS.LargeChange = ItemHeight
        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)
        InvalidateLayout()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(ByVal sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VS.Maximum = (_Items.Count * ItemHeight)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width - 1, 1)
        VS.Size = New Size(18, Height - 2)
        Invalidate()
    End Sub

    Private ColumnOffsets As Integer()

    Private Sub InvalidateColumns()
        Dim Width As Integer = 3
        ColumnOffsets = New Integer(_Columns.Count - 1) {}

        For I As Integer = 0 To _Columns.Count - 1
            ColumnOffsets(I) = Width
            Width += Columns(I).Width
        Next

        Invalidate()
    End Sub

    Private Sub VS_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        Focus()

        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            Dim Offset As Integer = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))
            Dim Index As Integer = ((e.Y + Offset - ItemHeight) / ItemHeight)
            If Index > _Items.Count - 1 Then Index = -1

            If Not (Index = -1) Then

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then

                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                        RaiseEvent SelectedItemsChanged(Me, New EventArgs())
                    Else
                        _SelectedItems.Add(_Items(Index))
                        RaiseEvent SelectedItemsChanged(Me, New EventArgs())
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                    RaiseEvent SelectedItemsChanged(Me, New EventArgs())
                End If
            End If

            Invalidate()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Private P1 As Pen
    Private P2 As Pen
    Private P3 As Pen
    Private B1 As SolidBrush
    Private B2 As SolidBrush
    Private B3 As SolidBrush
    Private B4 As SolidBrush
    Private GB1 As LinearGradientBrush
    Private G As Graphics

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
        G.Clear(BackColor)
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim H As Single = 0
        G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3)
        Dim R1 As Rectangle = Nothing
        Dim CI As NSListViewItem = Nothing
        Dim Offset As Integer = Convert.ToInt32(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))
        Dim StartIndex As Integer = 0

        If Offset = 0 Then
            StartIndex = 0
        Else
            StartIndex = (Offset / ItemHeight)
        End If

        Dim EndIndex As Integer = Math.Min(StartIndex + (Height / ItemHeight), _Items.Count - 1)

        For I As Integer = StartIndex To EndIndex
            CI = Items(I)
            R1 = New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1)
            H = G.MeasureString(CI.Text, Font).Height
            Y = R1.Y + Convert.ToInt32((ItemHeight / 2) - (H / 2))

            If _SelectedItems.Contains(CI) Then

                If I Mod 2 = 0 Then
                    G.FillRectangle(B1, R1)
                Else
                    G.FillRectangle(B2, R1)
                End If
            Else

                If I Mod 2 = 0 Then
                    G.FillRectangle(B3, R1)
                Else
                    G.FillRectangle(B4, R1)
                End If
            End If

            G.DrawLine(P2, 0, R1.Bottom, Width, R1.Bottom)

            If Columns.Length > 0 Then
                R1.Width = Columns(0).Width
                G.SetClip(R1)
            End If

            G.DrawString(CI.Text, Font, Brushes.Black, 10, Y + 1)
            G.DrawString(CI.Text, Font, Brushes.White, 9, Y)

            If CI.SubItems IsNot Nothing Then

                For I2 As Integer = 0 To Math.Min(CI.SubItems.Count, _Columns.Count) - 1
                    X = ColumnOffsets(I2 + 1) + 4
                    R1.X = X
                    R1.Width = Columns(I2).Width
                    G.SetClip(R1)
                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.Black, X + 1, Y + 1)
                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.White, X, Y)
                Next
            End If

            G.ResetClip()
        Next

        R1 = New Rectangle(0, 0, Width, ItemHeight)
        GB1 = New LinearGradientBrush(R1, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.FillRectangle(GB1, R1)
        G.DrawRectangle(P3, 1, 1, Width - 22, ItemHeight - 2)
        Dim LH As Integer = Math.Min(VS.Maximum + ItemHeight - Offset, Height)
        Dim CC As NSListViewColumnHeader = Nothing

        For I As Integer = 0 To _Columns.Count - 1
            CC = Columns(I)
            H = G.MeasureString(CC.Text, Font).Height
            Y = Convert.ToInt32((ItemHeight / 2) - (H / 2))
            X = ColumnOffsets(I)
            G.DrawString(CC.Text, Font, Brushes.Black, X + 1, Y + 1)
            G.DrawString(CC.Text, Font, Brushes.White, X, Y)
            G.DrawLine(P2, X - 3, 0, X - 3, LH)
            G.DrawLine(P3, X - 2, 0, X - 2, ItemHeight)
        Next

        G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1)
        G.DrawLine(P2, 0, ItemHeight, Width, ItemHeight)
        G.DrawLine(P2, VS.Location.X - 1, 0, VS.Location.X - 1, Height)
    End Sub

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines / 120) * (ItemHeight / 2))
        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value
        MyBase.OnMouseWheel(e)
    End Sub

End Class
