Imports System.Drawing.Imaging
Imports System.Net.Mime.MediaTypeNames

Public Class frmImport

    Public Property VisualMap() As OpenRGBVMap

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If frmMain.ucCompoment IsNot Nothing Then
            frmMain.Controls.Remove(frmMain.ucCompoment)
            frmMain.ucCompoment.Dispose()
        End If
        frmMain.FileName = Nothing
        frmMain.Text = String.Format(Translation.Localization.Title, Translation.Localization.Untitled)
        frmMain.NsTheme1.Text = frmMain.Text

        Dim zone = VisualMap.ctrl_zones.Find(Function(x) x.controller.location = cmbDevice.SelectedValue)
        Dim newComp As New Component()
        With newComp
            .Brand = zone.controller.vendor
            .DisplayName = zone.controller.name
            .Width = If(zone.settings.custom_shape.HasValue, zone.settings.custom_shape.Value.w, 0)
            .Height = If(zone.settings.custom_shape.HasValue, zone.settings.custom_shape.Value.h, 0)
            Dim mapping As New List(Of Integer)
            Dim names As New List(Of String)
            Dim coords As New List(Of Integer())
            If zone.settings.custom_shape.HasValue Then
                For Each ledPos In zone.settings.custom_shape.Value.led_positions
                    names.Add(ledPos.led_num)
                    mapping.Add(ledPos.led_num)
                    coords.Add({ledPos.x, ledPos.y})
                Next
            End If
            .LedCoordinates = coords
            .LedCount = coords.Count
            .LedMapping = mapping.ToArray
            .LedNames = names.ToArray
            .ProductName = zone.controller.name
            .Type = "custom"
            .Image = My.Resources._1.ImageToBase64
            .ImageUrl = ""
        End With
        frmMain.Component = newComp

        Dim LEDs As New List(Of Led)
        For i = 0 To newComp.LedCoordinates.Count - 1
            Dim name = newComp.LedNames(i)
            Dim index = newComp.LedMapping(i)
            Dim point = newComp.LedCoordinates(i)
            LEDs.Add(New Led(index, name, New Point(point(0), point(1))))
        Next

        frmMain.ucCompoment = New ucComponent With {._Width = newComp.Width, ._Height = newComp.Height, .BorderStyle = BorderStyle.None,
            .Size = New Size(newComp.Width * 50 + frmMain.ucCompoment.Margin.All, frmMain.Component.Height * 50 + frmMain.ucCompoment.Margin.All), .LEDs = LEDs,
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
        frmMain.SplitContainer1.Panel1.Controls.Add(frmMain.ucCompoment)
        frmMain.ucCompoment.Location = New Point(frmMain.SplitContainer1.Panel1.Width / 2 - frmMain.ucCompoment.Width / 2, frmMain.SplitContainer1.Panel1.Height / 2 - frmMain.ucCompoment.Height / 2)
        frmMain.ucCompoment.BringToFront()
        frmMain.mouseHandler = New MouseHandler(frmMain.ucCompoment, MouseButtons.Middle)

        frmMain.txtBrand.Text = newComp.Brand
        frmMain.txtProduct.Text = newComp.ProductName
        frmMain.txtName.Text = newComp.DisplayName
        frmMain.numWidth.Value = newComp.Width
        frmMain.numHeight.Value = newComp.Height
        frmMain.txtLedCount.Text = newComp.LedCount
        frmMain.cmbType.SelectedValue = newComp.Type.ToLower
        frmMain.pbImage.Image = newComp.ToImage
        frmMain.txtWebImageUrl.Text = newComp.ImageUrl

        Text = String.Format(Translation.Localization.Title, frmMain.FileName)
        NsTheme1.Text = Text
        Close()
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.ImportOpenRGBVisualMap
        NsTheme1.Text = loc.ImportOpenRGBVisualMap
        lblFileName.Value1 = loc.FileName
        lblDevice.Value1 = loc.Device
        lblLocation.Value1 = loc.Location
        btnOK.Text = loc.Confirm
    End Sub

    Private Sub cmbDevice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDevice.SelectedIndexChanged
        txtLocation.Text = cmbDevice.SelectedValue
    End Sub

    Private Sub frmImport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()

        txtLocation.Text = cmbDevice.SelectedValue
    End Sub
End Class