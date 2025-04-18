﻿Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Module Helper

    Public SettingFile As String = "settings.json"
    Public Setting As MySettings = New MySettings()
    Public TypeDropdownList As New List(Of DropdownListItem(Of String))
    Public DirectionDropdownList As New List(Of DropdownListItem(Of eDirection))
    Public LanguageDropdownList As New List(Of DropdownListItem(Of String))
    Public MatrixDropdownList As New List(Of DropdownListItem(Of eMatrixOrder))
    Public LShapeDropdownList As New List(Of DropdownListItem(Of eLShapeOrder))
    Public UShapeDropdownList As New List(Of DropdownListItem(Of eUShapeOrder))
    Public RectangleDropdownList As New List(Of DropdownListItem(Of eRectOrder))
    Public Translation As MyLanguage = New MyLanguage()
    Public UserMemory As New Memory()

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
    Public Function ImageToBase64(img As Image, Optional formatting As Base64FormattingOptions = Base64FormattingOptions.InsertLineBreaks) As String
        Try
            If img IsNot Nothing Then
                Dim stream As New MemoryStream
                img.Save(stream, ImageFormat.Png)
                Return Convert.ToBase64String(stream.ToArray, formatting)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    <Extension>
    Public Function ToPoint(pointf As PointF) As Point
        Return New Point(CInt(pointf.X), CInt(pointf.Y))
    End Function

    <Extension>
    Public Sub DrawRoundedRectangle(graphics As Graphics, pen As Pen, bounds As Rectangle, radius As Integer)
        If graphics Is Nothing Then
            Throw New ArgumentNullException("graphics")
        End If
        If pen Is Nothing Then
            Throw New ArgumentNullException("prush")
        End If

        Using path As GraphicsPath = RoundedRect(bounds, radius)
            graphics.DrawPath(pen, path)
        End Using
    End Sub

    <Extension>
    Public Sub FillRoundedRectangle(graphics As Graphics, brush As Brush, bounds As Rectangle, radius As Integer)
        If graphics Is Nothing Then
            Throw New ArgumentNullException("graphics")
        End If
        If brush Is Nothing Then
            Throw New ArgumentNullException("brush")
        End If

        Using path As GraphicsPath = RoundedRect(bounds, radius)
            graphics.FillPath(brush, path)
        End Using
    End Sub

    Private Function RoundedRect(bounds As Rectangle, radius As Integer) As GraphicsPath
        Dim diameter As Integer = radius * 2
        Dim size As Size = New Size(diameter, diameter)
        Dim arc As Rectangle = New Rectangle(bounds.Location, size)
        Dim path As GraphicsPath = New GraphicsPath

        If (radius = 0) Then
            path.AddRectangle(bounds)
            Return path
        End If

        'top left arc
        path.AddArc(arc, 180, 90)

        'top right arc
        arc.X = bounds.Right - diameter
        path.AddArc(arc, 270, 90)

        'bottom right arc
        arc.Y = bounds.Bottom - diameter
        path.AddArc(arc, 0, 90)

        'bottom left arc
        arc.X = bounds.Left
        path.AddArc(arc, 90, 90)

        path.CloseFigure()
        Return path
    End Function

    <DllImport("dwmapi.dll")>
    Private Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As Integer, ByRef attrValue As Boolean, ByVal attrSize As Integer) As Integer
    End Function

    <Extension>
    Public Function UseImmersiveDarkMode(ByVal handle As IntPtr, ByVal enabled As Boolean) As Boolean
        If IsWindows10OrGreater(17763) Then
            Dim attribute = DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1
            If IsWindows10OrGreater(18985) Then
                attribute = DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE
            End If

            Dim _useImmersiveDarkMode = If(enabled, 1, 0)
            Return DwmSetWindowAttribute(handle, CInt(attribute), _useImmersiveDarkMode, 4)
        End If
        Return False
    End Function

    Private Function IsWindows10OrGreater(ByVal Optional build As Integer = -1) As Boolean
        Return Environment.OSVersion.Version.Major >= 10 AndAlso Environment.OSVersion.Version.Build >= build
    End Function

    <Extension>
    Public Sub Clear(nstxt As NSTextBox)
        nstxt.Text = Nothing
    End Sub

    <Extension>
    Public Function ToRect(rectF As RectangleF) As Rectangle
        Return New Rectangle(CInt(Math.Ceiling(rectF.X)), CInt(Math.Ceiling(rectF.Y)), CInt(Math.Ceiling(rectF.Width)), CInt(Math.Ceiling(rectF.Height)))
    End Function

    Public Function GetFontSizeMatch(ByVal myText As String, ByVal myFont As Font, ByVal mySize As Size) As Single
        Dim fit As Boolean = False
        Dim curSize As Single
        Do Until fit
            curSize += 0.1F
            Dim fnt As Font = New Font(myFont.Name, curSize)
            Dim textSize As Size = TextRenderer.MeasureText(myText, fnt)
            If textSize.Height >= mySize.Height Or textSize.Width >= mySize.Width Or textSize.Height = 0 Or textSize.Width = 0 Then
                fit = True
                If textSize.Width > mySize.Width Then curSize -= 1.0F
                If textSize.Height > mySize.Height Then curSize -= 1.0F
            End If
        Loop
        If curSize <= 0.1F Then curSize = myFont.Size
        Return curSize
    End Function

End Module

Public Enum eMode
    AddLinear
    AddMatrix
    AddLShape
    AddUShape
    AddRectangle
    Edit
    Remove
End Enum

Public Enum eDirection
    Up
    Right
    Down
    Left
End Enum

Public Enum eMatrixOrder
    HorizontalTopLeft
    HorizontalTopRight
    HorizontalBottomLeft
    HorizontalBottomRight
    VerticalTopLeft
    VerticalTopRight
    VerticalBottomLeft
    VerticalBottomRight
End Enum

Public Enum DWMWINDOWATTRIBUTE
    DWMWA_ALLOW_NCPAINT = 4
    DWMWA_CAPTION_BUTTON_BOUNDS = 5
    DWMWA_FLIP3D_POLICY = 8
    DWMWA_FORCE_ICONIC_REPRESENTATION = 7
    DWMWA_LAST = 9
    DWMWA_NCRENDERING_ENABLED = 1
    DWMWA_NCRENDERING_POLICY = 2
    DWMWA_NONCLIENT_RTL_LAYOUT = 6
    DWMWA_TRANSITIONS_FORCEDISABLED = 3
    DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19
    DWMWA_USE_IMMERSIVE_DARK_MODE = 20
End Enum

Public Enum eLShapeOrder
    DownRight
    DownLeft
    UpRight
    UpLeft
    RightDown
    RightUp
    LeftDown
    LeftUp
End Enum

Public Enum eUShapeOrder
    DownRightUp
    DownLeftUp
    UpRightDown
    UpLeftDown
    RightDownLeft
    RightUpLeft
    LeftDownRight
    LeftUpRight
End Enum

Public Enum eRectOrder
    DownRightUpLeft
    DownLeftUpRight
    UpRightDownLeft
    UpLeftDownRight
    RightDownLeftUp
    RightUpLeftDown
    LeftDownRightUp
    LeftUpRightDown
End Enum