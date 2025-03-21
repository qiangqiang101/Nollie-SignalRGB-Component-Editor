﻿Imports System.ComponentModel
Imports System.IO
Imports System.Text.Json.Nodes
Imports Newtonsoft.Json

Public Structure Component

    Public ProductName As String
    Public DisplayName As String
    Public Brand As String
    Public Type As String
    Public LedCount As Integer
    Public Width As Integer
    Public Height As Integer
    Public LedMapping As Integer()
    Public LedCoordinates As List(Of Integer())
    Public LedNames As String()
    Public Image As String
    Public ImageUrl As String

    Public Function ToImage() As Image
        Return Image.Base64ToImage()
    End Function

    Public Function Load(filename As String) As Component
        Try
            Return JsonConvert.DeserializeObject(Of Component)(IO.File.ReadAllText(filename))
        Catch ex As Exception
            Try
                Dim componentF = JsonConvert.DeserializeObject(Of ComponentF)(IO.File.ReadAllText(filename))
                Dim newCoords As New List(Of Integer())
                For i As Integer = 0 To componentF.LedCoordinates.Count - 1
                    newCoords.Add({componentF.LedCoordinates(i)(0), componentF.LedCoordinates(i)(1)})
                Next
                Dim convert = New Component() With {.Brand = componentF.Brand, .ProductName = componentF.ProductName, .DisplayName = componentF.DisplayName,
                    .Type = componentF.Type, .Width = componentF.Width, .Height = componentF.Height, .Image = componentF.Image, .ImageUrl = componentF.ImageUrl,
                    .LedCoordinates = newCoords, .LedCount = componentF.LedCount, .LedMapping = componentF.LedMapping, .LedNames = componentF.LedNames}
                Return convert
            Catch ex2 As Exception
                MsgBox(ex2.Message, MsgBoxStyle.Critical, "Error")
                Return New Component() With {.LedCoordinates = New List(Of Integer()), .Type = "custom"}
            End Try
        End Try
    End Function

    Public Sub Save(filename As String)
        IO.File.WriteAllText(filename, Serialize)
    End Sub

    Public Function Serialize() As String
        Return JsonConvert.SerializeObject(Me, Formatting.Indented) ', New CustomJsonConverter
    End Function

End Structure

Public Structure ComponentF

    Public ProductName As String
    Public DisplayName As String
    Public Brand As String
    Public Type As String
    Public LedCount As Integer
    Public Width As Integer
    Public Height As Integer
    Public LedMapping As Integer()
    Public LedCoordinates As List(Of Single())
    Public LedNames As String()
    Public Image As String
    Public ImageUrl As String

End Structure