Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles
Imports Newtonsoft.Json

Public Class frmMain

    Dim FileName As String = Nothing
    Dim Component As New Component()
    Dim ucCompoment As ucComponent = Nothing
    Dim mouseHandler As MouseHandler = Nothing

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ucCompoment IsNot Nothing Then lblCursorLocation.Text = $"LED Position: {ucCompoment.MousePos.X}, {ucCompoment.MousePos.Y}"
    End Sub

    Private Sub tsmiOpen_Click(sender As Object, e As EventArgs) Handles tsmiOpen.Click
        Dim ofd As New OpenFileDialog()
        With ofd
            .DefaultExt = "json"
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WhirlwindFX\Components"
            .Filter = "Json file|*.json|All files|*.*"
            .Title = "Select component file..."
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            If ucCompoment IsNot Nothing Then
                Controls.Remove(ucCompoment)
                ucCompoment.Dispose()
            End If
            FileName = ofd.FileName
            Component = Component.Load(FileName)

            ucCompoment = New ucComponent With {.LedCoordinates = Component.LedCoordinates, .LedMapping = Component.LedMapping, .LedNames = Component.LedNames, .LedCount = Component.LedCount,
                ._Width = Component.Width, ._Height = Component.Height, .BorderStyle = BorderStyle.FixedSingle, .Location = New Point(0, 0), .Size = SplitContainer1.Panel1.Size}
            SplitContainer1.Panel1.Controls.Add(ucCompoment)
            mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Right)

            txtBrand.Text = Component.Brand
            txtProduct.Text = Component.ProductName
            txtName.Text = Component.DisplayName
            numWidth.Value = Component.Width
            numHeight.Value = Component.Height
            numLedCount.Value = Component.LedCount
            cmbType.SelectedValue = Component.Type
            pbImage.Image = Component.ToImage

            Text = $"{FileName} - Nollie SignalRGB Custom Component Editor"
        End If
    End Sub

    Private Sub tsmiSave_Click(sender As Object, e As EventArgs) Handles tsmiSave.Click
        Dim comp As New Component()
        With comp
            .Brand = txtBrand.Text
            .DisplayName = txtName.Text
            .Height = numHeight.Value
            .Image = pbImage.Image.ImageToBase64()
            Dim ainta As Integer() = {0, 1}, aintb As Integer() = {2, 3}, aintc As Integer() = {4, 5}
            .LedCoordinates = New List(Of Integer()) From {ainta, aintb, aintc}
            .LedCount = 3
            .LedMapping = {0, 1, 2}
            .LedNames = {"Led0", "Led1", "Led2"}
            .ProductName = txtProduct.Text
            .Type = cmbType.SelectedItem
            .Width = numWidth.Value
        End With
        Console.Write(comp.Serialize)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        AllocConsole()
        DoubleBuffered = True

        With cmbType
            .DataSource = TypeDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        ucCompoment = New ucComponent With {.LedCoordinates = Component.LedCoordinates, .LedMapping = Component.LedMapping, .LedNames = Component.LedNames, .LedCount = Component.LedCount,
            ._Width = Component.Width, ._Height = Component.Height, .BorderStyle = BorderStyle.FixedSingle, .Location = New Point(0, 0), .Size = SplitContainer1.Panel1.Size}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Right)
    End Sub

    Private Sub numWidth_ValueChanged(sender As Object, e As EventArgs) Handles numWidth.ValueChanged
        If ucCompoment IsNot Nothing Then
            ucCompoment._Width = numWidth.Value
        End If
    End Sub

    Private Sub numHeight_ValueChanged(sender As Object, e As EventArgs) Handles numHeight.ValueChanged
        If ucCompoment IsNot Nothing Then
            ucCompoment._Height = numHeight.Value
        End If
    End Sub

    Private Sub numLedCount_ValueChanged(sender As Object, e As EventArgs) Handles numLedCount.ValueChanged
        If ucCompoment IsNot Nothing Then
            ucCompoment.LedCount = numLedCount.Value
        End If
    End Sub

    <DllImport("kernel32.dll")>
    Public Shared Function AllocConsole() As Boolean
    End Function

End Class
