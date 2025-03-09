﻿Public Class ucMatrix

    Public Property MaximumLED() As Integer
    Public Property Component() As ucComponent
    Public Property LEDPos() As Point

    Public Sub New(maxled As Integer, parent As ucComponent, pos As Point)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        MaximumLED = maxled
        Component = parent
        LEDPos = pos
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Component.AddMatrix(LEDPos, CType(cmbOrder.SelectedValue, eMatrixOrder), cbSerpentine.Checked, New Size(numWidth.Value, numHeight.Value))
        Component.Invalidate()

        'Save to temporary memory
        With UserMemory
            .MatrixOrder = CType(cmbOrder.SelectedValue, eMatrixOrder)
            .MatrixSerpentine = cbSerpentine.Checked
            .MatrixSize = New Size(numWidth.Value, numHeight.Value)
        End With

        ParentForm.Close()
    End Sub

    Private Sub ucMatrix_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        With cmbOrder
            .DataSource = MatrixDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        'load from temporary memory
        cmbOrder.SelectedValue = UserMemory.MatrixOrder
        cbSerpentine.Checked = UserMemory.MatrixSerpentine
        numWidth.Value = UserMemory.MatrixSize.Width
        numHeight.Value = UserMemory.MatrixSize.Height
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Matrix
        ParentForm.Text = loc.Matrix
        lblOrder.Value1 = loc.Order
        lblSize.Value1 = loc.Size
        cbSerpentine.Text = loc.Serpentine
        btnOK.Text = loc.Confirm
    End Sub

End Class
