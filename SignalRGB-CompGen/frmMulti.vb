Public Class frmMulti

    Public Property Mode() As eMode
    Public Property MaximumLED() As Integer
    Public Property Component() As ucComponent
    Public Property LEDPos() As Point

    'for Edit
    Public Property SelectedItem() As Led

    Public Sub New(_mode As eMode, maxled As Integer, parent As ucComponent, pos As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Mode = _mode
        MaximumLED = maxled
        Component = parent
        LEDPos = pos
    End Sub

    Public Sub New(_mode As eMode, parent As ucComponent, selected As Led)
        InitializeComponent()

        Mode = _mode
        Component = parent
        SelectedItem = selected
    End Sub

    Private Sub frmMulti_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Mode
            Case eMode.AddLinear
                Text = Translation.Localization.Linear
                NsTheme1.Text = Text

                Dim linear As New ucLinear(MaximumLED, Component, LEDPos)
                pUserControl.Controls.Add(linear)
                linear.Dock = DockStyle.Fill
            Case eMode.AddMatrix
                Text = Translation.Localization.Matrix
                NsTheme1.Text = Text

                Dim matrix As New ucMatrix(MaximumLED, Component, LEDPos)
                pUserControl.Controls.Add(matrix)
                matrix.Dock = DockStyle.Fill
            Case eMode.AddLShape
                Text = Translation.Localization.LShape
                NsTheme1.Text = Text

                Dim lshape As New ucLShape(MaximumLED, Component, LEDPos)
                pUserControl.Controls.Add(lshape)
                lshape.Dock = DockStyle.Fill
            Case eMode.AddUShape
                Text = Translation.Localization.UShape
                NsTheme1.Text = Text

                'todo
            Case eMode.AddRectangle
                Text = Translation.Localization.Rectangle
                NsTheme1.Text = Text

                'todo
            Case eMode.Edit
                Text = Translation.Localization.EditLED
                NsTheme1.Text = Text

                Dim edit As New ucEdit(Component, SelectedItem)
                pUserControl.Controls.Add(edit)

                edit.Dock = DockStyle.Fill
            Case eMode.Remove
                Text = Translation.Localization.RemoveLastLEDs
                NsTheme1.Text = Text

                Dim delete As New ucDelete(MaximumLED, Component, LEDPos)
                pUserControl.Controls.Add(delete)
                delete.Dock = DockStyle.Fill
        End Select
    End Sub

End Class