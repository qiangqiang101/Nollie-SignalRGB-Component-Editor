Imports System.ComponentModel
Imports System.Drawing.Drawing2D

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
    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        Cursor = Cursors.IBeam

        Base = New NumericUpDown
        Base.Font = Font
        Base.Value = Text
        Base.Maximum = _Maximum
        Base.Minimum = _Minimum
        Base.InterceptArrowKeys = _InterceptArrowKeys
        Base.ReadOnly = _ReadOnly
        Base.ThousandsSeparator = _ThousandsSeparator
        Base.DecimalPlaces = _DecimalPlaces

        Base.ForeColor = Color.White
        Base.BackColor = Color.FromArgb(50, 50, 50)

        Base.BorderStyle = BorderStyle.None
        Base.Controls(0).Hide()

        Base.Location = New Point(5, 3)
        Base.Width = Width - 14
        Base.Height = Height - 14

        AddHandler Base.ValueChanged, AddressOf OnBaseValueChanged

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(55, 55, 55))
    End Sub

    Private GP1, GP2 As GraphicsPath

    Private P1, P2 As Pen
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

        G.DrawPath(P2, GP1)
        G.DrawPath(P1, GP2)
    End Sub

    Private Sub OnBaseValueChanged(ByVal s As Object, ByVal e As EventArgs)
        Value = Base.Value

        RaiseEvent ValueChanged(s, e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Base.Location = New Point(5, 3)

        Base.Width = Width - 10
        Base.Height = Height - 10

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