Imports System.Text.Json.Nodes
Imports Newtonsoft.Json

Public Structure Component

    Public Brand As String
    Public ProductName As String
    Public DisplayName As String
    Public Type As String
    Public Width As Integer
    Public Height As Integer
    Public Image As String
    Public LedCoordinates As List(Of Integer())
    Public LedCount As Integer
    Public LedMapping As Integer()
    Public LedNames As String()

    Public Function ToImage() As Image
        Return Image.Base64ToImage()
    End Function

    Public Function Load(filename As String) As Component
        Return JsonConvert.DeserializeObject(Of Component)(IO.File.ReadAllText(filename))
    End Function

    Public Sub Save(filename As String)
        IO.File.WriteAllText(filename, Serialize)
    End Sub

    Public Function Serialize() As String
        Return JsonConvert.SerializeObject(Me, Formatting.Indented, New CustomJsonConverter)
    End Function

End Structure