Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports Microsoft.Win32.SafeHandles
Imports Newtonsoft.Json

Public Class frmMain

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
                .Size = New Size(Component.Width * 50 + ucCompoment.Margin.All, Component.Height * 50 + ucCompoment.Margin.All), .LEDs = LEDs,
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

            Text = String.Format(Translation.Localization.Title, FileName)
            NsTheme1.Text = Text
        End If
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

        ucCompoment = New ucComponent With {.LEDs = New List(Of Led), ._Width = 5, ._Height = 5, .BorderStyle = BorderStyle.None, .Location = New Point(0, 0),
            .Size = New Size(350, 350), .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        ucCompoment.Location = New Point((SplitContainer1.Panel1.Width / 2) - (ucCompoment.Width / 2), (SplitContainer1.Panel1.Height / 2) - (ucCompoment.Height / 2))
        ucCompoment.BringToFront()
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)
    End Sub

    Private Sub Translate()
        If File.Exists($"{Setting.Language}.json") Then
            Translation = New MyLanguage().Load($"{Setting.Language}.json")
            Dim loc = Translation.Localization

            DirectionDropdownList.Clear()
            DirectionDropdownList.AddRange({
                                           New DropdownListItem(Of eDirection)(loc.Top, eDirection.Top), New DropdownListItem(Of eDirection)(loc.Right, eDirection.Right),
                                           New DropdownListItem(Of eDirection)(loc.Bottom, eDirection.Bottom), New DropdownListItem(Of eDirection)(loc.Left, eDirection.Left)
                                           })
            TypeDropdownList.Clear()
            TypeDropdownList.AddRange({
                                      New DropdownListItem(Of String)(loc.AIO, "aio"), New DropdownListItem(Of String)(loc.Cable, "cable"), New DropdownListItem(Of String)(loc.Case, "case"),
                                      New DropdownListItem(Of String)(loc.Chair, "chair"), New DropdownListItem(Of String)(loc.Fan, "fan"), New DropdownListItem(Of String)(loc.Custom, "custom"),
                                      New DropdownListItem(Of String)(loc.Strip, "strip"), New DropdownListItem(Of String)(loc.WaterBlock, "water block"), New DropdownListItem(Of String)(loc.Tower, "tower"),
                                      New DropdownListItem(Of String)(loc.Heatsink, "heatsink"), New DropdownListItem(Of String)(loc.Desk, "desk")})

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

            lblName.Value1 = loc.Name
            lblVendor.Value1 = loc.Vendor
            lblProduct.Value1 = loc.Product
            lblType.Value1 = loc.Type
            lblWidth.Value1 = loc.Width
            lblHeight.Value1 = loc.Height
            lblLedCount.Value1 = loc.LEDCount
            btnChangeImage.Text = loc.SelectImage
            nslblPosition.Value1 = loc.Position
            nslblPosition.Value2 = "0, 0"
            gbImage.Title = loc.ComponentImage
            gbControls.Title = loc.Controls
            btnAutoResize.Text = loc.AutoResize
            lblWebImage.Value1 = loc.ImageURL
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
        numWidth.Value = 5
        numHeight.Value = 5
        txtLedCount.Text = 0
        cmbType.SelectedIndex = 0
        pbImage.Image = My.Resources._1
        txtWebImageUrl.Clear

        ucCompoment = New ucComponent With {.LEDs = New List(Of Led), ._Width = 5, ._Height = 5, .BorderStyle = BorderStyle.None,
            .Size = New Size(350, 350), .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right,
            .ForeColor = Color.White}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        ucCompoment.Location = New Point(SplitContainer1.Panel1.Width / 2 - ucCompoment.Width / 2, SplitContainer1.Panel1.Height / 2 - ucCompoment.Height / 2)
        ucCompoment.BringToFront()
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)
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
        Process.Start(New ProcessStartInfo With {.FileName = "https://nolliergb.cn/products/nollie32-argb-kontroler-5-v3pin-argb-interfejs-obsluguje-signalrgb-openrgb", .UseShellExecute = True})
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
                    .Size = New Size((Component.Width * 50) + ucCompoment.Margin.All, (Component.Height * 50) + ucCompoment.Margin.All), .LEDs = LEDs,
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

    Private Sub tsmiORGBVMap_Click(sender As Object, e As EventArgs) Handles tsmiORGBVMap.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .DefaultExt = ""
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\OpenRGB\plugins\settings\virtual-controllers"
            .Filter = "All files|*.*"
            .Title = Translation.Localization.SelectComponentFile
            .Multiselect = False
        End With
        If ofd.ShowDialog <> DialogResult.Cancel Then
            Try
                Dim vmap As OpenRGBVMap = New OpenRGBVMap().Load(ofd.FileName)
                Dim fimp As New frmImport()
                With fimp
                    Dim deviceDDL As New List(Of DropdownListItem(Of String))
                    For Each zone In vmap.ctrl_zones
                        deviceDDL.Add(New DropdownListItem(Of String)(zone.controller.name, zone.controller.location))
                    Next

                    With .cmbDevice
                        .DataSource = deviceDDL
                        .DisplayMember = "Text"
                        .ValueMember = "Value"
                        .SelectedIndex = 0
                    End With

                    .txtFileName.Text = ofd.FileName
                    .VisualMap = vmap
                End With
                fimp.Show()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub
End Class
