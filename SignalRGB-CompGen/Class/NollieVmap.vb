Imports Newtonsoft.Json

Public Class NollieVmap

    Public Property DisplayName As String
    Public Property Type As String
    Public Property version As Integer
    Public Property fx_ch_led_num As Integer
    Public Property fx_ch_zled_num As Integer
    Public Property led_index As Integer()
    Public Property Component As Component2

    Public Shared Function Load(filename As String) As NollieVmap
        Try
            Return JsonConvert.DeserializeObject(Of NollieVmap)(IO.File.ReadAllText(filename))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return New NollieVmap() With {.Type = "Custom"}
        End Try
    End Function

    Public Sub Save(filename As String)
        IO.File.WriteAllText(filename, Serialize)
    End Sub

    Public Function Serialize() As String
        Return JsonConvert.SerializeObject(Me, Formatting.Indented)
    End Function

End Class

Public Class Component2
    Inherits Component

    Public Property ZLedMapping As Integer()

End Class