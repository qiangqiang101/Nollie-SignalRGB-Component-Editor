Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Security.Policy
Imports Microsoft.Win32.SafeHandles
Imports Newtonsoft.Json

Public Class frmMain

    Dim FileName As String = Nothing
    Dim Component As New Component()
    Dim WithEvents ucCompoment As ucComponent = Nothing
    Dim mouseHandler As MouseHandler = Nothing

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ucCompoment IsNot Nothing Then
            nslblPosition.Value1 = Translation.Localization.Position
            nslblPosition.Value2 = $"{ucCompoment.MousePos.X}, {ucCompoment.MousePos.Y}"
        End If
    End Sub

    Private Sub tsmiOpen_Click(sender As Object, e As EventArgs) Handles tsmiOpen.Click
        Dim ofd As New OpenFileDialog()
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
            numWidth.Text = Component.Width
            numHeight.Text = Component.Height
            txtLedCount.Text = Component.LedCount
            cmbType.SelectedValue = Component.Type.ToLower
            pbImage.Image = Component.ToImage

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
                .Width = numWidth.Text
                .Height = numHeight.Text
                .LedCoordinates = ledCoords
                .LedCount = ucCompoment.LedCount
                .LedMapping = mapping.ToArray
                .LedNames = names.ToArray
                .ProductName = txtProduct.Text
                .Type = cmbType.SelectedValue
                .Image = pbImage.Image.ImageToBase64()
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
        Dim sfd As New SaveFileDialog()
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

            btnFile.Text = loc.File
            tsmiNew.Text = loc.[New]
            tsmiOpen.Text = loc.Open
            tsmiSave.Text = loc.Save
            tsmiSaveAs.Text = loc.SaveAs
            tsmiExit.Text = loc.Exit
            btnSettings.Text = loc.Settings
            btnHelp.Text = loc.Help
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
            btnFile.Width = loc.FileWidth
            btnSettings.Width = loc.SettingsWidth
            btnHelp.Width = loc.HelpWidth
        End If
    End Sub

    Private Sub numWidth_TextChanged(sender As Object, e As EventArgs) Handles numWidth.TextChanged
        If IsNumeric(numWidth.Text) AndAlso ucCompoment IsNot Nothing Then
            ucCompoment._Width = numWidth.Text
        End If
    End Sub

    Private Sub numHeight_TextChanged(sender As Object, e As EventArgs) Handles numHeight.TextChanged
        If IsNumeric(numHeight.Text) AndAlso ucCompoment IsNot Nothing Then
            ucCompoment._Height = numHeight.Text
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
        Dim ofd As New OpenFileDialog()
        With ofd
            Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
            Dim sep As String = String.Empty
            For Each c As ImageCodecInfo In codecs
                Dim codecName As String = c.CodecName.Substring(8).Replace("Codec", "Files").Trim()
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

        txtBrand.Clear()
        txtProduct.Clear()
        txtName.Clear()
        numWidth.Text = 5
        numHeight.Text = 5
        txtLedCount.Text = 0
        cmbType.SelectedIndex = 0
        pbImage.Image = My.Resources._1

        ucCompoment = New ucComponent With {.LEDs = New List(Of Led), ._Width = 5, ._Height = 5, .BorderStyle = BorderStyle.None,
            .Size = New Size(350, 350), .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right,
            .ForeColor = Color.White}
        SplitContainer1.Panel1.Controls.Add(ucCompoment)
        ucCompoment.Location = New Point((SplitContainer1.Panel1.Width / 2) - (ucCompoment.Width / 2), (SplitContainer1.Panel1.Height / 2) - (ucCompoment.Height / 2))
        ucCompoment.BringToFront()
        mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)
    End Sub

    Private Sub tsmiControls_Click(sender As Object, e As EventArgs) Handles tsmiControls.Click
        MsgBox(String.Format(Translation.Localization.ControlMsg, vbCrLf), MsgBoxStyle.Information, Translation.Localization.Controls)
    End Sub

    Private Sub tsmiNollie_Click(sender As Object, e As EventArgs) Handles tsmiNollie.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://nolliergb.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiSRGB_Click(sender As Object, e As EventArgs) Handles tsmiSRGB.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://signalrgb.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiMentaL_Click(sender As Object, e As EventArgs) Handles tsmiMentaL.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://imnotmental.com", .UseShellExecute = True})
    End Sub

    Private Sub tsmiBuy_Click(sender As Object, e As EventArgs) Handles tsmiBuy.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://nolliergb.cn/products/nollie32-argb-kontroler-5-v3pin-argb-interfejs-obsluguje-signalrgb-openrgb", .UseShellExecute = True})
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
                numWidth.Text = Component.Width
                numHeight.Text = Component.Height
                txtLedCount.Text = Component.LedCount
                cmbType.SelectedValue = Component.Type.ToLower
                pbImage.Image = Component.ToImage

                Text = String.Format(Translation.Localization.Title, FileName)
                NsTheme1.Text = Text
            End If
        End If

    End Sub

    Private Sub frmMain_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.Show()
    End Sub

    Private Sub btnFile_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        cmFile.Show(btnFile, New Point(0, btnFile.Height))
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        cmHelp.Show(btnHelp, New Point(0, btnHelp.Height))
    End Sub

    Private Sub NumericUpDown_KeyDown(sender As Object, e As KeyEventArgs) Handles numWidth.KeyDown, numHeight.KeyDown
        Dim tb As NSTextBox = sender
        Dim isDigits As Boolean = IsNumeric(tb.Text)
        Dim number As Integer
        If isDigits Then
            number = CInt(tb.Text)
        End If
        Select Case e.KeyCode
            Case Keys.Up
                number += 1
                tb.Text = number
            Case Keys.Down
                number -= 1
                tb.Text = number
        End Select
    End Sub
End Class
