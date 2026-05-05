Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Policy
Imports Newtonsoft.Json.Linq

Public Class frmMain

    Private MarginAll As Integer = 100
    Public FileName As String = Nothing
    Public Component As New Component()
    Public VMAP As New NollieVmap()
    Public WithEvents ucCompoment As ucComponent = Nothing
    Public mouseHandler As MouseHandler = Nothing

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If File.Exists(SettingFile) Then
            Setting = New MySettings().Load(SettingFile)
        Else
            frmFirst.Show()
        End If
        Translate()
    End Sub

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
            Dim jsonContent = File.ReadAllText(ofd.FileName)
            Dim jsonObj As JObject = JObject.Parse(jsonContent)

            If jsonObj("fx_ch_led_num") IsNot Nothing Then
                ' It is a vmap file, we will convert it to component first before loading, and we will not keep the vmap data since this editor is mainly for editing component files, and the vmap import/export is just a secondary feature for compatibility with OpenRGB

                If ucCompoment IsNot Nothing Then
                    Controls.Remove(ucCompoment)
                    ucCompoment.Dispose()
                End If
                FileName = ofd.FileName
                VMAP = NollieVmap.Load(FileName)

                Dim LEDs As New List(Of Led)
                For i = 0 To VMAP.Component.LedCoordinates.Count - 1
                    Dim name = VMAP.Component.LedNames(i)
                    Dim index = VMAP.Component.LedMapping(i)
                    Dim point = VMAP.Component.LedCoordinates(i)
                    Dim hidden = VMAP.Component.ZLedMapping.Contains(index)
                    LEDs.Add(New Led(index, name, New Point(point(0), point(1))) With {.Hidden = hidden})
                Next

                ucCompoment = New ucComponent With {.Width = VMAP.Component.Width, .Height = VMAP.Component.Height, .BorderStyle = BorderStyle.None,
                    .Size = New Size(VMAP.Component.Width * 50 + MarginAll, VMAP.Component.Height * 50 + MarginAll), .LEDs = LEDs,
                    .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
                SplitContainer1.Panel1.Controls.Add(ucCompoment)
                ucCompoment.Location = New Point(SplitContainer1.Panel1.Width / 2 - ucCompoment.Width / 2, SplitContainer1.Panel1.Height / 2 - ucCompoment.Height / 2)
                ucCompoment.BringToFront()
                mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)

                txtBrand.Text = VMAP.Component.Brand
                txtProduct.Text = VMAP.Component.ProductName
                txtName.Text = VMAP.Component.DisplayName
                numWidth.Value = VMAP.Component.Width
                numHeight.Value = VMAP.Component.Height
                txtLedCount.Text = VMAP.Component.LedCount
                If VMAP.Component.Type = VMAP.Component.Type.ToLower() Then
                    Select Case VMAP.Component.Type
                        Case "aio"
                            cmbType.SelectedValue = "AIO"
                        Case "gpu"
                            cmbType.SelectedValue = "GPU"
                        Case Else
                            cmbType.SelectedValue = VMAP.Component.Type.CapitalizeFirstLetter(True)
                    End Select
                Else
                    cmbType.SelectedValue = VMAP.Component.Type
                End If
                pbImage.Image = VMAP.Component.ToImage
                txtWebImageUrl.Text = VMAP.Component.ImageUrl

                Text = String.Format(Translation.Localization.Title, FileName)
                NsTheme1.Text = Text

            ElseIf jsonObj("LedCount") IsNot Nothing Then
                ' It is a component file, we can load it directly

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
                If Component.Type = Component.Type.ToLower() Then
                    Select Case Component.Type
                        Case "aio"
                            cmbType.SelectedValue = "AIO"
                        Case "gpu"
                            cmbType.SelectedValue = "GPU"
                        Case Else
                            cmbType.SelectedValue = Component.Type.CapitalizeFirstLetter(True)
                    End Select
                Else
                    cmbType.SelectedValue = Component.Type
                End If
                pbImage.Image = Component.ToImage
                txtWebImageUrl.Text = Component.ImageUrl

                Text = String.Format(Translation.Localization.Title, FileName)
                NsTheme1.Text = Text
            Else
                MsgBox(Translation.Localization.InvalidFile, MsgBoxStyle.Critical, "Error")
                Return
            End If
        End If
    End Sub

    Private Sub SaveComponent(file As String)
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

    Private Sub SaveVMAP(file As String)
        If ucCompoment IsNot Nothing Then
            ' Create an instant of Component first to ensure backward compatibility with older versions of component files that don't have the necessary properties for vmap
            Dim ledCoords As New List(Of Integer())
            Dim mapping As New List(Of Integer)
            Dim zmapping As New List(Of Integer)
            Dim names As New List(Of String)

            For Each led In ucCompoment.LEDs
                Dim ledcoord = {led.LedCoordinates.X, led.LedCoordinates.Y}
                ledCoords.Add(ledcoord)
                mapping.Add(led.MappingIndex)
                If led.Hidden Then zmapping.Add(led.MappingIndex)
                names.Add(led.LedName)
            Next

            Dim comp As New Component2()
            With comp
                .Brand = txtBrand.Text
                .DisplayName = txtName.Text
                .Width = numWidth.Value
                .Height = numHeight.Value
                .LedCoordinates = ledCoords
                .LedCount = ucCompoment.LedCount
                .LedMapping = mapping.ToArray
                .ZLedMapping = zmapping.ToArray
                .LedNames = names.ToArray
                .ProductName = txtProduct.Text
                .Type = cmbType.SelectedValue
                .Image = pbImage.Image.ImageToBase64()
                .ImageUrl = txtWebImageUrl.Text
            End With

            ' Now we can create the vmap using the component instance, and we can be sure that even older component files without the necessary properties for vmap can still be loaded and converted to vmap as long as they have the basic properties like LedCoordinates, LedMapping, etc.
            Dim led_index As New List(Of Integer)
            Dim sortedLeds = ucCompoment.LEDs.Where(Function(x) Not x.Hidden).OrderBy(Function(l) l.LedCoordinates.Y).ThenBy(Function(l) l.LedCoordinates.X).ToList()
            Dim sortedZLeds = ucCompoment.LEDs.Where(Function(x) x.Hidden).OrderBy(Function(l) l.LedCoordinates.Y).ThenBy(Function(l) l.LedCoordinates.X).ToList()
            sortedLeds.AddRange(sortedZLeds)

            For Each led In sortedLeds
                led_index.Add(led.MappingIndex)
            Next

            Dim vmap As New NollieVmap()
            With vmap
                .DisplayName = txtName.Text
                .Type = cmbType.SelectedValue
                .version = 2
                .fx_ch_led_num = ucCompoment.VmapLedCount
                .fx_ch_zled_num = ucCompoment.VmapZLedCount
                .led_index = sortedLeds.Select(Function(x) x.MappingIndex).ToArray
                .Component = comp
            End With
            vmap.Save(file)
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        DoubleBuffered = True

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

    Public Sub Translate(Optional disposeOldData As Boolean = False)
        If File.Exists($"languages\{Setting.Language}.json") Then
            Translation = New MyLanguage().Load($"languages\{Setting.Language}.json")
            Dim loc = Translation.Localization

            If disposeOldData Then
                cmbType.DataSource = Nothing

                DirectionDropdownList.Clear()
                TypeDropdownList.Clear()
                MatrixDropdownList.Clear()
                LShapeDropdownList.Clear()
                UShapeDropdownList.Clear()
                RectangleDropdownList.Clear()
            End If

            DirectionDropdownList.AddRange({New DropdownListItem(Of eDirection)(loc.Up, eDirection.Up), New DropdownListItem(Of eDirection)(loc.Right, eDirection.Right),
                                           New DropdownListItem(Of eDirection)(loc.Down, eDirection.Down), New DropdownListItem(Of eDirection)(loc.Left, eDirection.Left)})
            TypeDropdownList.AddRange({New DropdownListItem(Of String)(loc.AIO, "AIO"), New DropdownListItem(Of String)(loc.Cable, "Cable"), New DropdownListItem(Of String)(loc.Case, "Case"),
                                      New DropdownListItem(Of String)(loc.Chair, "Chair"), New DropdownListItem(Of String)(loc.Cooler, "Cooler"), New DropdownListItem(Of String)(loc.Desk, "Desk"),
                                      New DropdownListItem(Of String)(loc.Fan, "Fan"), New DropdownListItem(Of String)(loc.GPU, "GPU"), New DropdownListItem(Of String)(loc.Heatsink, "Heatsink"),
                                      New DropdownListItem(Of String)(loc.MatrixPanel, "Matrix Panel"), New DropdownListItem(Of String)(loc.Memory, "Memory"), New DropdownListItem(Of String)(loc.Storage, "Storage"),
                                      New DropdownListItem(Of String)(loc.Strip, "Strip"), New DropdownListItem(Of String)(loc.Tower, "Tower"), New DropdownListItem(Of String)(loc.WaterBlock, "Water Block"),
                                      New DropdownListItem(Of String)(loc.Custom, "Custom")})
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

            If disposeOldData Then
                With cmbType
                    .DataSource = TypeDropdownList
                    .DisplayMember = "Text"
                    .ValueMember = "Value"
                    .SelectedIndex = 0
                End With
            End If

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

            ' Added 02/05/2026
            gbTools.Title = loc.Tools
            rbToolSelect.Text = loc.SelectTool
            rbToolPlaceLED.Text = loc.PlaceLEDTool
            rbToolResizeGI.Text = loc.ResizeGuideImage
            tsmiSaveSRGB.Text = loc.SignalRGBComponent
            tsmiSaveNRGB.Text = loc.NollieRGBVMAP
            tsmiSaveAsSRGB.Text = loc.SignalRGBComponent
            tsmiSaveAsNRGB.Text = loc.NollieRGBVMAP
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
    End Sub

    Private Sub tsmiControls_Click(sender As Object, e As EventArgs)
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
                Dim jsonContent = File.ReadAllText(firstFile)
                Dim jsonObj As JObject = JObject.Parse(jsonContent)

                If jsonObj("fx_ch_led_num") IsNot Nothing Then
                    ' It is a vmap file, we will convert it to component first before loading, and we will not keep the vmap data since this editor is mainly for editing component files, and the vmap import/export is just a secondary feature for compatibility with OpenRGB

                    If ucCompoment IsNot Nothing Then
                        Controls.Remove(ucCompoment)
                        ucCompoment.Dispose()
                    End If
                    FileName = firstFile
                    VMAP = NollieVmap.Load(FileName)

                    Dim LEDs As New List(Of Led)
                    For i = 0 To VMAP.Component.LedCoordinates.Count - 1
                        Dim name = VMAP.Component.LedNames(i)
                        Dim index = VMAP.Component.LedMapping(i)
                        Dim point = VMAP.Component.LedCoordinates(i)
                        Dim hidden = VMAP.Component.ZLedMapping.Contains(index)
                        LEDs.Add(New Led(index, name, New Point(point(0), point(1))) With {.Hidden = hidden})
                    Next

                    ucCompoment = New ucComponent With {.Width = VMAP.Component.Width, .Height = VMAP.Component.Height, .BorderStyle = BorderStyle.None,
                        .Size = New Size(VMAP.Component.Width * 50 + MarginAll, VMAP.Component.Height * 50 + MarginAll), .LEDs = LEDs,
                        .Anchor = AnchorStyles.Bottom And AnchorStyles.Left And AnchorStyles.Top And AnchorStyles.Right, .ForeColor = Color.White}
                    SplitContainer1.Panel1.Controls.Add(ucCompoment)
                    ucCompoment.Location = New Point(SplitContainer1.Panel1.Width / 2 - ucCompoment.Width / 2, SplitContainer1.Panel1.Height / 2 - ucCompoment.Height / 2)
                    ucCompoment.BringToFront()
                    mouseHandler = New MouseHandler(ucCompoment, MouseButtons.Middle)

                    txtBrand.Text = VMAP.Component.Brand
                    txtProduct.Text = VMAP.Component.ProductName
                    txtName.Text = VMAP.Component.DisplayName
                    numWidth.Value = VMAP.Component.Width
                    numHeight.Value = VMAP.Component.Height
                    txtLedCount.Text = VMAP.Component.LedCount
                    If VMAP.Component.Type = Component.Type.ToLower() Then
                        Select Case VMAP.Component.Type
                            Case "aio"
                                cmbType.SelectedValue = "AIO"
                            Case "gpu"
                                cmbType.SelectedValue = "GPU"
                            Case Else
                                cmbType.SelectedValue = VMAP.Component.Type.CapitalizeFirstLetter(True)
                        End Select
                    Else
                        cmbType.SelectedValue = VMAP.Component.Type
                    End If
                    pbImage.Image = VMAP.Component.ToImage
                    txtWebImageUrl.Text = VMAP.Component.ImageUrl

                    Text = String.Format(Translation.Localization.Title, FileName)
                    NsTheme1.Text = Text

                ElseIf jsonObj("LedCount") IsNot Nothing Then
                    ' It is a component file, we can load it directly

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
                    If Component.Type = Component.Type.ToLower() Then
                        Select Case Component.Type
                            Case "aio"
                                cmbType.SelectedValue = "AIO"
                            Case "gpu"
                                cmbType.SelectedValue = "GPU"
                            Case Else
                                cmbType.SelectedValue = Component.Type.CapitalizeFirstLetter(True)
                        End Select
                    Else
                        cmbType.SelectedValue = Component.Type
                    End If
                    pbImage.Image = Component.ToImage
                    txtWebImageUrl.Text = Component.ImageUrl

                    Text = String.Format(Translation.Localization.Title, FileName)
                    NsTheme1.Text = Text
                End If
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

    Private Sub btnRotateRight_Click(sender As Object, e As EventArgs) Handles btnRotateRight.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.RotateLEDsClockwise()
        End If
    End Sub

    Private Sub btnRotateLeft_Click(sender As Object, e As EventArgs) Handles btnRotateLeft.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.RotateLEDsCounterClockwise()
        End If
    End Sub

    Private Sub btnHideLed_Click(sender As Object, e As EventArgs) Handles btnHideLed.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.SetLEDsHidden()
        End If
    End Sub

    Private Sub tsmiSaveSRGB_Click(sender As Object, e As EventArgs) Handles tsmiSaveSRGB.Click
        If FileName = Nothing Then
            tsmiSaveAsSRGB.PerformClick()
        Else
            SaveComponent(FileName)
        End If
    End Sub

    Private Sub tsmiSaveNRGB_Click(sender As Object, e As EventArgs) Handles tsmiSaveNRGB.Click
        If FileName = Nothing Then
            tsmiSaveAsNRGB.PerformClick()
        Else
            SaveVMAP(FileName)
        End If
    End Sub

    Private Sub tsmiSaveAsSRGB_Click(sender As Object, e As EventArgs) Handles tsmiSaveAsSRGB.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .DefaultExt = "json"
            .InitialDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\WhirlwindFX\Components"
            .Filter = "Json file|*.JSON|All files|*.*"
            .Title = Translation.Localization.SaveComponentFileAs
        End With
        If sfd.ShowDialog <> DialogResult.Cancel Then
            SaveComponent(sfd.FileName)
            FileName = sfd.FileName
            Text = String.Format(Translation.Localization.Title, FileName)
            NsTheme1.Text = Text
        End If
    End Sub

    Private Sub tsmiSaveAsNRGB_Click(sender As Object, e As EventArgs) Handles tsmiSaveAsNRGB.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .DefaultExt = "json"
            .Filter = "Json file|*.JSON|All files|*.*"
            .Title = Translation.Localization.SaveVMAPFileAs
        End With
        If sfd.ShowDialog <> DialogResult.Cancel Then
            SaveVMAP(sfd.FileName)
            FileName = sfd.FileName
            Text = String.Format(Translation.Localization.Title, FileName)
            NsTheme1.Text = Text
        End If
    End Sub

    Private Sub btnFlipLeftRight_Click(sender As Object, e As EventArgs) Handles btnFlipLeftRight.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.FlipLEDsHorizontal()
        End If
    End Sub

    Private Sub btnFlipUpDown_Click(sender As Object, e As EventArgs) Handles btnFlipUpDown.Click
        If ucCompoment IsNot Nothing Then
            ucCompoment.flipLEDsVertical()
        End If
    End Sub
End Class
