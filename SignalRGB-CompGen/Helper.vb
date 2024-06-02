Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices

Module Helper

    Public TypeDropdownList As New List(Of DropdownListItem(Of String)) From {
        New DropdownListItem(Of String)("AIO", "aio"), New DropdownListItem(Of String)("Cable", "cable"), New DropdownListItem(Of String)("Case", "case"),
        New DropdownListItem(Of String)("Chair", "chair"), New DropdownListItem(Of String)("Fan", "fan"), New DropdownListItem(Of String)("Custom", "custom")}

    <Extension>
    Public Function StringToBase64(text As String) As String
        If text = Nothing Then Return text

        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text)
        Return Convert.ToBase64String(plainTextBytes)
    End Function

    <Extension>
    Public Function Base64ToString(base64 As String) As String
        If base64 = Nothing Then Return base64

        Try
            Dim base64Bytes = Convert.FromBase64String(base64)
            Return Text.Encoding.UTF8.GetString(base64Bytes)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function Base64ToImage(Image As String) As Image
        Try
            If Image = Nothing Then
                Return Nothing
            Else
                Dim b64 As String = Image.Replace(" ", "+")
                Dim bite() As Byte = Convert.FromBase64String(b64)
                Dim stream As New MemoryStream(bite)
                Return Drawing.Image.FromStream(stream)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ImageToBase64(img As Image, Optional forceFormat As ImageFormat = Nothing, Optional formatting As Base64FormattingOptions = Base64FormattingOptions.InsertLineBreaks) As String
        Try
            If img IsNot Nothing Then
                If forceFormat Is Nothing Then forceFormat = img.RawFormat
                Dim stream As New MemoryStream
                img.Save(stream, forceFormat)
                Return Convert.ToBase64String(stream.ToArray, formatting)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
