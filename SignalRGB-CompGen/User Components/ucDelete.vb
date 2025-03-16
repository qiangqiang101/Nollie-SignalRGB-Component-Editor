Public Class ucDelete

    Public Property MaximumLED() As Integer
    Public Property Component() As ucComponent
    Public Property LEDPos() As Point

    Private DeleteAmount As Integer = 0

    Public Sub New(maxled As Integer, parent As ucComponent, pos As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MaximumLED = maxled
        Component = parent
        LEDPos = pos
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim lastNthLeds = Component.LEDs.OrderByDescending(Function(x) x.MappingIndex).Take(DeleteAmount)
        For Each led In lastNthLeds
            Component.RemoveLed(led)
            Component.Invalidate()
        Next

        'Save to temporary memory
        With UserMemory
            If cmbHistory.SelectedValue.ToString = "1" Then
                .RemoveLastGeneratedObject()
            Else
                .ClearAllGeneratedObjects()
            End If
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucDelete_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        Text = Translation.Localization.RemoveLastLEDs
        ParentForm.Text = Text

        Dim DeleteDropdownList As New List(Of DropdownListItem(Of Integer))
        If UserMemory.GeneratedObjects.Count <> 0 Then DeleteDropdownList.Add(New DropdownListItem(Of Integer)(String.Format(Translation.Localization.LastObject, UserMemory.LastGeneratedObject.Name), 1))
        DeleteDropdownList.Add(New DropdownListItem(Of Integer)(Translation.Localization.AllObjects, 2))

        With cmbHistory
            .DataSource = DeleteDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        lblObjects.Value1 = loc.Objects
        btnOK.Text = loc.Confirm
    End Sub

    Private Sub cmbHistory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHistory.SelectedIndexChanged
        Try
            Dim selectedItem As Integer = CInt(cmbHistory.SelectedValue.ToString)

            Select Case selectedItem
                Case 1
                    DeleteAmount = UserMemory.LastGeneratedObject.LEDs
                Case 2
                    DeleteAmount = MaximumLED
            End Select
        Catch ex As Exception
            'shut up
        End Try
    End Sub
End Class
