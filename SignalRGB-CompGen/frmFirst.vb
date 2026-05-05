Imports System.IO
Imports Svg

Public Class frmFirst
    Private Sub frmFirst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateLanguageButtons()
        Translate()
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Language
        NsTheme1.Text = Text
        btnContinue.Text = loc.Confirm
    End Sub

    Private Sub CreateLanguageButtons()
        Dim langDir = New DirectoryInfo("languages")
        Dim files = langDir.GetFiles("*.json")

        For Each file In files
            Dim lang = New MyLanguage().Load(file.FullName)

            Dim btn As New NSImgRadioButton()
            With btn
                .Text = lang.LanguageName
                .Size = New Size(180, 90)
                .Tag = lang.LanguageID
                .Padding = New Padding(3, 3, 3, 3)
                .ImageOnTop = True
                Dim svg = SvgDocument.Open(Path.Combine("languages", lang.LanguageID & ".svg"))
                .BackgroundImage = svg.Draw()
                .Checked = lang.LanguageID = Setting.Language
                AddHandler .Click, AddressOf LanguageButton_Click
            End With
            flpChooseLanguage.Controls.Add(btn)
        Next
    End Sub

    Private Sub LanguageButton_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, NSImgRadioButton)
        Dim selectedLangID = CStr(btn.Tag)
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Try
            Dim selLang = flpChooseLanguage.Controls.OfType(Of NSImgRadioButton)().FirstOrDefault(Function(x) x.Checked)

            Dim sett As New MySettings()
            With sett
                .Language = selLang.Tag
            End With
            sett.Save(SettingFile)
            Setting = sett

            frmMain.Translate(True)

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class