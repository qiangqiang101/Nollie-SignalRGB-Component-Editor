Imports Newtonsoft.Json

Public Class CustomJsonConverter
    Inherits JsonConverter(Of Point)

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Point, serializer As JsonSerializer)
        writer.WriteRawValue($"[{value.X}, {value.Y}]")
        writer.Formatting = Formatting.Indented
    End Sub

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Point, hasExistingValue As Boolean, serializer As JsonSerializer) As Point
        Throw New NotImplementedException
    End Function

    Private reserved As Integer = Integer.MinValue

End Class
