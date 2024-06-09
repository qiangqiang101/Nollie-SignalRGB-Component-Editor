Imports System.Reflection.Metadata.Ecma335

Public Class Led

    Public Property Index() As Integer?
    Public Property MappingIndex() As Integer
    Public Property LedName() As String
    Public Property LedCoordinates() As Point

    Public Sub New(mindex As Integer, name As String, coord As Point)
        MappingIndex = mindex
        LedName = name
        LedCoordinates = coord
    End Sub

    Public Shared Operator =(a As Led, b As Led) As Boolean
        Return a Is b
    End Operator

    Public Shared Operator <>(a As Led, b As Led) As Boolean
        Return a IsNot b
    End Operator

End Class
