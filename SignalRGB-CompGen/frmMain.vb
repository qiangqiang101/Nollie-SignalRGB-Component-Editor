﻿Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports Microsoft.Win32.SafeHandles
Imports Newtonsoft.Json
Imports SignalRGB_CompGen.NSListView

Public Class frmMain

    Private MarginAll As Integer = 100
    Public FileName As String = Nothing
    Public Component As New Component()
    Public WithEvents ucCompoment As ucComponent = Nothing
    Public mouseHandler As MouseHandler = Nothing

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ucCompoment IsNot Nothing Then
            nslblPosition.Value1 = Translation.Localization.Position
            nslblPosition.Value2 = $"{ucCompoment.MousePos.X}, {ucCompoment.MousePos.Y}"
        End If
    End Sub

    Private Sub tsmiOpen_Click(sender As Object, e As EventArgs) Handles tsmiOpen.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .DefaultExt = "json"
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WhirlwindFX\Components"
            .Filter = "Json file|*.JSON|All files|*.*"
            .Title = Translation.Localization.SelectComponentFile
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            If ucCompoment IsNot Nothing Then
                Controls.Remove(ucCompoment)
                ucCompoment.Dispose()
            End If
            FileName = ofd.FileName
            Component = Component.Load(FileName)

            Dim LEDs As New List(Of Led)
            For i = 0 To Component.LedCoordinates.Count - 1
                Dim name = Component.LedNames(i)
                Dim index = Component.LedMapping(i)
                Dim point = Component.LedCoordinates(i)
                LEDs.Add(New Led(index, name, New Point(point(0), point(1))))
            Next

            ucCompoment = New ucComponent With {._Width = Component.Width, ._Height = Component.Height, .BorderStyle = BorderStyle.None,
                .Size = New Size(Component.Width * 50 + MarginAll, Component.Height * 50 + MarginAll), .LEDs = LEDs,
                .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
            SplitContainer1.Panel1.Controls.Add(ucCompoment)
            ucCompoment.Location = New Point(SplitContainer1.Panel1.Width / 2 - ucCompoment.Width / 2, SplitContainer1.Panel1.Height / 2 - ucCompoment.Height / 2)
            ucCompoment.BringToFront()
            mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)

            txtBrand.Text = Component.Brand
            txtProduct.Text = Component.ProductName
            txtName.Text = Component.DisplayName
            numWidth.Value = Component.Width
            numHeight.Value = Component.Height
            txtLedCount.Text = Component.LedCount
            cmbType.SelectedValue = Component.Type.ToLower
            pbImage.Image = Component.ToImage
            txtWebImageUrl.Text = Component.ImageUrl

            UserMemory.ClearAllGeneratedObjects()
            UserMemory.AddGeneratedObject(Component.DisplayName, -1, ucCompoment.LedCount)

            Text = String.Format(Translation.Localization.Title, FileName)
            NsTheme1.Text = Text
        End If
    End Sub

    Public Sub AddGeneratedObjectToListview([object] As GeneratedObject)
        Dim subitems As List(Of NSListViewSubItem) = New List(Of NSListViewSubItem)()

        Dim startIndex = If(Setting.ShiftIndex, [object].StartIndex + 2, [object].StartIndex + 1)
        Dim endIndex = If(Setting.ShiftIndex, [object].StartIndex + [object].LEDs + 1, [object].StartIndex + [object].LEDs)

        Dim subitem As New NSListViewSubItem() With {.Text = $"{If([object].LEDs = 1, startIndex, $"{startIndex} - {endIndex}")}"} '[object].LEDs
        subitems.Add(subitem)

        Dim lvi As New NSListViewItem()
        With lvi
            .Text = [object].Name
            .SubItems = subitems
            .Tag = [object]
        End With
        lvObjects.AddItem(lvi)
    End Sub

    Public Sub RemoveLastGeneratedObjectFromListview([object] As GeneratedObject)
        Dim lvi = lvObjects.Items.SingleOrDefault(Function(x) x.Tag = [object])
        If lvi IsNot Nothing Then lvObjects.RemoveItem(lvi)
    End Sub

    Private Sub Save(file As String)
        If ucCompoment IsNot Nothing Then
            Dim ledCoords As New List(Of Integer())
            Dim mapping As New List(Of Integer)
            Dim names As New List(Of String)

            For Each led In ucCompoment.LEDs
                Dim ledcoord = {led.LedCoordinates.X, led.LedCoordinates.Y}
                ledCoords.Add(ledcoord)
                mapping.Add(led.MappingIndex)
                names.Add(led.LedName)
            Next

            Dim comp As New Component()
            With comp
                .Brand = txtBrand.Text
                .DisplayName = txtName.Text
                .Width = numWidth.Value
                .Height = numHeight.Value
                .LedCoordinates = ledCoords
                .LedCount = ucCompoment.LedCount
                .LedMapping = mapping.ToArray
                .LedNames = names.ToArray
                .ProductName = txtProduct.Text
                .Type = cmbType.SelectedValue
                .Image = pbImage.Image.ImageToBase64()
                .ImageUrl = txtWebImageUrl.Text
            End With
            comp.Save(file)
        End If
    End Sub

    Private Sub tsmiSave_Click(sender As Object, e As EventArgs) Handles tsmiSave.Click
        If FileName = Nothing Then
            tsmiSaveAs.PerformClick()
        Else
            Save(FileName)
        End If
    End Sub

    Private Sub tsmiSaveAs_Click(sender As Object, e As EventArgs) Handles tsmiSaveAs.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .DefaultExt = "json"
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WhirlwindFX\Components"
            .Filter = "Json file|*.JSON|All files|*.*"
            .Title = Translation.Localization.SaveComponentFileAs
        End With
        If sfd.ShowDialog <> DialogResult.Cancel Then
            Save(sfd.FileName)
            FileName = sfd.FileName
            Text = String.Format(Translation.Localization.Title, FileName)
            NsTheme1.Text = Text
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        DoubleBuffered = True

        If File.Exists(SettingFile) Then Setting = New MySettings().Load(SettingFile)
        Translate()
        If Setting.Debug Then AllocConsole()

        With cmbType
            .DataSource = TypeDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedIndex = 0
        End With

        numWidth.Value = Setting.DefaultSize.Width
        numHeight.Value = Setting.DefaultSize.Height

        ucCompoment = New ucComponent With {.LEDs = New List(Of Led), ._Width = Setting.DefaultSize.Width, ._Height = Setting.DefaultSize.Height,
            .BorderStyle = BorderStyle.None, .Location = New Point(0, 0), .Size = New Size(Setting.DefaultSize.Width * 50 + MarginAll, Setting.DefaultSize.Width * 50 + MarginAll),
            .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        ucCompoment.Location = New Point((SplitContainer1.Panel1.Width / 2) - (ucCompoment.Width / 2), (SplitContainer1.Panel1.Height / 2) - (ucCompoment.Height / 2))
        ucCompoment.BringToFront()
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)
    End Sub

    Private Sub Translate()
        If File.Exists($"languages\{Setting.Language}.json") Then
            Translation = New MyLanguage().Load($"languages\{Setting.Language}.json")
            Dim loc = Translation.Localization

            DirectionDropdownList.AddRange({New DropdownListItem(Of eDirection)(loc.Up, eDirection.Up), New DropdownListItem(Of eDirection)(loc.Right, eDirection.Right),
                                           New DropdownListItem(Of eDirection)(loc.Down, eDirection.Down), New DropdownListItem(Of eDirection)(loc.Left, eDirection.Left)})
            TypeDropdownList.AddRange({New DropdownListItem(Of String)(loc.AIO, "aio"), New DropdownListItem(Of String)(loc.Cable, "cable"),
                                      New DropdownListItem(Of String)(loc.Case, "case"), New DropdownListItem(Of String)(loc.Chair, "chair"),
                                      New DropdownListItem(Of String)(loc.Fan, "fan"), New DropdownListItem(Of String)(loc.Custom, "custom"),
                                      New DropdownListItem(Of String)(loc.Strip, "strip"), New DropdownListItem(Of String)(loc.WaterBlock, "water block"),
                                      New DropdownListItem(Of String)(loc.Tower, "tower"), New DropdownListItem(Of String)(loc.Heatsink, "heatsink"),
                                      New DropdownListItem(Of String)(loc.Desk, "desk")})
            MatrixDropdownList.AddRange({New DropdownListItem(Of eMatrixOrder)(loc.HorizontalTopLeft, eMatrixOrder.HorizontalTopLeft),
                                        New DropdownListItem(Of eMatrixOrder)(loc.HorizontalTopRight, eMatrixOrder.HorizontalTopRight),
                                        New DropdownListItem(Of eMatrixOrder)(loc.HorizontalBottomLeft, eMatrixOrder.HorizontalBottomLeft),
                                        New DropdownListItem(Of eMatrixOrder)(loc.HorizontalBottomRight, eMatrixOrder.HorizontalBottomRight),
                                        New DropdownListItem(Of eMatrixOrder)(loc.VerticalTopLeft, eMatrixOrder.VerticalTopLeft),
                                        New DropdownListItem(Of eMatrixOrder)(loc.VerticalTopRight, eMatrixOrder.VerticalTopRight),
                                        New DropdownListItem(Of eMatrixOrder)(loc.VerticalBottomLeft, eMatrixOrder.VerticalBottomLeft),
                                        New DropdownListItem(Of eMatrixOrder)(loc.VerticalBottomRight, eMatrixOrder.VerticalBottomRight)})
            LShapeDropdownList.AddRange({New DropdownListItem(Of eLShapeOrder)(loc.DownRight, eLShapeOrder.DownRight),
                                        New DropdownListItem(Of eLShapeOrder)(loc.DownLeft, eLShapeOrder.DownLeft),
                                        New DropdownListItem(Of eLShapeOrder)(loc.UpRight, eLShapeOrder.UpRight),
                                        New DropdownListItem(Of eLShapeOrder)(loc.UpLeft, eLShapeOrder.UpLeft),
                                        New DropdownListItem(Of eLShapeOrder)(loc.RightDown, eLShapeOrder.RightDown),
                                        New DropdownListItem(Of eLShapeOrder)(loc.RightUp, eLShapeOrder.RightUp),
                                        New DropdownListItem(Of eLShapeOrder)(loc.LeftDown, eLShapeOrder.LeftDown),
                                        New DropdownListItem(Of eLShapeOrder)(loc.LeftUp, eLShapeOrder.LeftUp)})
            UShapeDropdownList.AddRange({New DropdownListItem(Of eUShapeOrder)(loc.DownRightUp, eUShapeOrder.DownRightUp),
                                        New DropdownListItem(Of eUShapeOrder)(loc.DownLeftUp, eUShapeOrder.DownLeftUp),
                                        New DropdownListItem(Of eUShapeOrder)(loc.UpRightDown, eUShapeOrder.UpRightDown),
                                        New DropdownListItem(Of eUShapeOrder)(loc.UpLeftDown, eUShapeOrder.UpLeftDown),
                                        New DropdownListItem(Of eUShapeOrder)(loc.RightDownLeft, eUShapeOrder.RightDownLeft),
                                        New DropdownListItem(Of eUShapeOrder)(loc.RightUpLeft, eUShapeOrder.RightUpLeft),
                                        New DropdownListItem(Of eUShapeOrder)(loc.LeftDownRight, eUShapeOrder.LeftDownRight),
                                        New DropdownListItem(Of eUShapeOrder)(loc.LeftUpRight, eUShapeOrder.LeftUpRight)})
            RectangleDropdownList.AddRange({New DropdownListItem(Of eRectOrder)(loc.DownRightUpLeft, eRectOrder.DownRightUpLeft),
                                          New DropdownListItem(Of eRectOrder)(loc.DownLeftUpRight, eRectOrder.DownLeftUpRight),
                                          New DropdownListItem(Of eRectOrder)(loc.UpRightDownLeft, eRectOrder.UpRightDownLeft),
                                          New DropdownListItem(Of eRectOrder)(loc.UpLeftDownRight, eRectOrder.UpLeftDownRight),
                                          New DropdownListItem(Of eRectOrder)(loc.RightDownLeftUp, eRectOrder.RightDownLeftUp),
                                          New DropdownListItem(Of eRectOrder)(loc.RightUpLeftDown, eRectOrder.RightUpLeftDown),
                                          New DropdownListItem(Of eRectOrder)(loc.LeftDownRightUp, eRectOrder.LeftDownRightUp),
                                          New DropdownListItem(Of eRectOrder)(loc.LeftUpRightDown, eRectOrder.LeftUpRightDown)})

            Text = String.Format(loc.Title, loc.Untitled)
            NsTheme1.Text = Text

            tsmiFile.Text = loc.File
            tsmiNew.Text = loc.[New]
            tsmiOpen.Text = loc.Open
            tsmiSave.Text = loc.Save
            tsmiSaveAs.Text = loc.SaveAs
            tsmiExit.Text = loc.Exit
            tsmiSettings.Text = loc.Settings
            tsmiHelp.Text = loc.Help
            tsmiControls.Text = loc.Controls
            tsmiSRGB.Text = loc.VisitSignalRGB
            tsmiNollie.Text = loc.VisitNollie
            tsmiMentaL.Text = loc.VisitMentaL
            tsmiBuy.Text = loc.BuyNollie
            tsmiImport.Text = loc.ImportOpenRGBVisualMap

            lblName.Value1 = loc.Name
            lblVendor.Value1 = loc.Vendor
            lblProduct.Value1 = loc.Product
            lblType.Value1 = loc.Type
            lblSize.Value1 = loc.Size
            lblLedCount.Value1 = loc.LEDCount
            btnChangeImage.Text = loc.SelectImage
            nslblPosition.Value1 = loc.Position
            nslblPosition.Value2 = "0, 0"
            gbImage.Title = loc.ComponentImage
            gbControls.Title = loc.Controls
            btnAutoResize.Text = loc.AutoResize
            lblWebImage.Value1 = loc.ImageURL

            gbObjects.Title = loc.Objects
            lvObjects.Columns(0).Text = loc.Name
            lvObjects.Columns(1).Text = loc.Index
        End If
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

    Private Sub ucCompoment_LEDsChanged(sender As Object, e As EventArgs) Handles ucCompoment.LEDsChanged
        txtLedCount.Text = ucCompoment.LedCount
    End Sub

    <DllImport("kernel32.dll")>
    Public Shared Function AllocConsole() As Boolean
    End Function

    Private Sub tsmiExit_Click(sender As Object, e As EventArgs) Handles tsmiExit.Click
        Close()
    End Sub

    Private Sub btnChangeImage_Click(sender As Object, e As EventArgs) Handles btnChangeImage.Click
        Dim ofd As New OpenFileDialog
        With ofd
            Dim codecs = ImageCodecInfo.GetImageEncoders
            Dim sep = String.Empty
            For Each c In codecs
                Dim codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim
                .Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension)
                sep = "|"
            Next c
            .Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*")
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            .Title = Translation.Localization.SelectImageFile
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            pbImage.Image = Image.FromFile(ofd.FileName)
        End If
    End Sub

    Private Sub tsmiNew_Click(sender As Object, e As EventArgs) Handles tsmiNew.Click
        If ucCompoment IsNot Nothing Then
            Controls.Remove(ucCompoment)
            ucCompoment.Dispose()
        End If
        FileName = Nothing
        Text = String.Format(Translation.Localization.Title, Translation.Localization.Untitled)
        NsTheme1.Text = Text

        txtBrand.Clear
        txtProduct.Clear
        txtName.Clear
        numWidth.Value = Setting.DefaultSize.Width
        numHeight.Value = Setting.DefaultSize.Height
        txtLedCount.Text = 0
        cmbType.SelectedIndex = 0
        pbImage.Image = My.Resources._1
        txtWebImageUrl.Clear

        ucCompoment = New ucComponent With {.LEDs = New List(Of Led), ._Width = Setting.DefaultSize.Width, ._Height = Setting.DefaultSize.Height, .ForeColor = Color.White,
            .BorderStyle = BorderStyle.None, .Size = New Size(Setting.DefaultSize.Width * 50 + MarginAll, Setting.DefaultSize.Width * 50 + MarginAll), .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        ucCompoment.Location = New Point(SplitContainer1.Panel1.Width / 2 - ucCompoment.Width / 2, SplitContainer1.Panel1.Height / 2 - ucCompoment.Height / 2)
        ucCompoment.BringToFront()
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)

        UserMemory.ClearAllGeneratedObjects()
    End Sub

    Private Sub tsmiControls_Click(sender As Object, e As EventArgs) Handles tsmiControls.Click
        MsgBox(String.Format(Translation.Localization.ControlMsg, vbCrLf), MsgBoxStyle.Information, Translation.Localization.Controls)
    End Sub

    Private Sub tsmiNollie_Click(sender As Object, e As EventArgs) Handles tsmiNollie.Click
        Process.Start(New ProcessStartInfo With {.FileName = "https://nolliergb.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiSRGB_Click(sender As Object, e As EventArgs) Handles tsmiSRGB.Click
        Process.Start(New ProcessStartInfo With {.FileName = "https://signalrgb.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiMentaL_Click(sender As Object, e As EventArgs) Handles tsmiMentaL.Click
        Process.Start(New ProcessStartInfo With {.FileName = "https://imnotmental.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiBuy_Click(sender As Object, e As EventArgs) Handles tsmiBuy.Click
        Process.Start(New ProcessStartInfo With {.FileName = "https://nolliergb.com/our_products/nollie-32/", .UseShellExecute = True})
    End Sub

    Private Sub frmMain_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim files As String() = e.Data.GetData(DataFormats.FileDrop)
        Dim firstFile = files.FirstOrDefault

        If firstFile <> Nothing Then
            If Path.GetExtension(files.FirstOrDefault).ToLower() = ".json" Then
                If ucCompoment IsNot Nothing Then
                    Controls.Remove(ucCompoment)
                    ucCompoment.Dispose()
                End If
                FileName = firstFile
                Component = Component.Load(FileName)

                Dim LEDs As New List(Of Led)
                For i As Integer = 0 To Component.LedCoordinates.Count - 1
                    Dim name As String = Component.LedNames(i)
                    Dim index As Integer = Component.LedMapping(i)
                    Dim point As Integer() = Component.LedCoordinates(i)
                    LEDs.Add(New Led(index, name, New Point(point(0), point(1))))
                Next

                ucCompoment = New ucComponent With {._Width = Component.Width, ._Height = Component.Height, .BorderStyle = BorderStyle.None,
                    .Size = New Size((Component.Width * 50) + MarginAll, (Component.Height * 50) + MarginAll), .LEDs = LEDs,
                    .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
                SplitContainer1.Panel1.Controls.Add(ucCompoment)
                ucCompoment.Location = New Point((SplitContainer1.Panel1.Width / 2) - (ucCompoment.Width / 2), (SplitContainer1.Panel1.Height / 2) - (ucCompoment.Height / 2))
                ucCompoment.BringToFront()
                mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)

                txtBrand.Text = Component.Brand
                txtProduct.Text = Component.ProductName
                txtName.Text = Component.DisplayName
                numWidth.Value = Component.Width
                numHeight.Value = Component.Height
                txtLedCount.Text = Component.LedCount
                cmbType.SelectedValue = Component.Type.ToLower
                pbImage.Image = Component.ToImage
                txtWebImageUrl.Text = Component.ImageUrl

                UserMemory.ClearAllGeneratedObjects()
                UserMemory.AddGeneratedObject(Component.DisplayName, -1, ucCompoment.LedCount)

                Text = String.Format(Translation.Localization.Title, FileName)
                NsTheme1.Text = Text
            End If
        End If

    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub tsmiSettings_Click(sender As Object, e As EventArgs) Handles tsmiSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.MoveUp()
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.MoveDown()
        End If
    End Sub

    Private Sub btnLeft_Click(sender As Object, e As EventArgs) Handles btnLeft.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.MoveLeft()
        End If
    End Sub

    Private Sub btnRight_Click(sender As Object, e As EventArgs) Handles btnRight.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.MoveRight()
        End If
    End Sub

    Private Sub btnAutoResize_Click(sender As Object, e As EventArgs) Handles btnAutoResize.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.AutoResize()
        End If
    End Sub

    Private Sub tsmiImport_Click(sender As Object, e As EventArgs) Handles tsmiImport.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .DefaultExt = ""
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\OpenRGB\plugins\settings\virtual-controllers"
            .Filter = "All files|*.*"
            .Title = Translation.Localization.SelectOpenRGBVisualMapFile
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            Try
                Dim vmap As OpenRGBVMap = New OpenRGBVMap().Load(ofd.FileName)
                Dim fimp As New frmImport()
                With fimp
                    .VisualMap = vmap
                    Dim deviceDDL As New List(Of DropdownListItem(Of zone_identifier))
                    For Each zone In vmap.ctrl_zones
                        Dim isRGBController = vmap.ctrl_zones.Where(Function(x) x.controller.name = zone.controller.name).Count > 1
                        Dim zoneName As String = If(zone.custom_zone_name <> Nothing, zone.custom_zone_name, If(isRGBController, $"{zone.controller.name} - {Translation.Localization.Zone} {zone.zone_idx + 1}", zone.controller.name))
                        deviceDDL.Add(New DropdownListItem(Of zone_identifier)(zoneName, New zone_identifier(zoneName, zone.controller.location, zone.zone_idx)))
                    Next

                    With .cmbDevice
                        .DataSource = deviceDDL
                        .DisplayMember = "Text"
                        .ValueMember = "Value"
                        .SelectedIndex = 0
                    End With

                    .txtFileName.Text = ofd.FileName
                End With
                fimp.Show()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub lvObjects_SelectedItemsChanged(sender As Object, e As EventArgs) Handles lvObjects.SelectedItemsChanged
        Dim selecteditem = lvObjects.SelectedItems.First
        If selecteditem Is Nothing Then
            ucCompoment.SelectedObject = Nothing
        Else
            Dim selectedObject = CType(selecteditem.Tag, GeneratedObject)
            ucCompoment.SelectedObject = selectedObject
        End If
        ucCompoment.Focus()
    End Sub
End Class
