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

End Class
