﻿Imports System.Configuration
Imports System.Drawing.Imaging
Imports System.IO

Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        ScanForLanguageFiles()
        Translate()

        With cmbLanguage
            .DataSource = LanguageDropdownList
            .DisplayMember = "Text"
            .ValueMember = "Value"
            .SelectedValue = Setting.Language
        End With

        cbShiftLedPosition.Checked = Setting.ShiftIndex
        cbConsole.Checked = Setting.Debug
        numWidth.Value = Setting.DefaultSize.Width
        numHeight.Value = Setting.DefaultSize.Height
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim sett As New MySettings()
            With sett
                .Language = cmbLanguage.SelectedValue
                .ShiftIndex = cbShiftLedPosition.Checked
                .Debug = cbConsole.Checked
                .DefaultSize = New Size(CInt(numWidth.Value), CInt(numHeight.Value))
            End With
            sett.Save(SettingFile)
            Setting = sett

            MsgBox(Translation.Localization.SettingSaveMsg, MsgBoxStyle.Information, Translation.Localization.Settings)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Settings
        NsTheme1.Text = Text

        lblLanguage.Value1 = loc.Language
        cbShiftLedPosition.Text = loc.ShiftDisplayingLEDIndex
        cbConsole.Text = loc.Console
        lblSize.Value1 = loc.DefaultSize
        btnSave.Text = loc.Save
    End Sub

    Private Sub ScanForLanguageFiles()
        Dim langDir = New DirectoryInfo("languages")
        Dim files = langDir.GetFiles("*.json")
        For Each file In files
            Dim lang = New MyLanguage().Load(file.FullName)
            LanguageDropdownList.Add(New DropdownListItem(Of String)(lang.LanguageName, lang.LanguageID))
        Next
    End Sub

End Class