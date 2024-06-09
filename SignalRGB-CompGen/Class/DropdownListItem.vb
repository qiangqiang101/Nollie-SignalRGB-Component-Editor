Public Class DropdownListItem(Of T)

    Private _text As String
    Private _value As T

    Public ReadOnly Property Text() As String
        Get
            Return _text
        End Get
    End Property

    Public ReadOnly Property Value() As T
        Get
            Return _value
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _text
    End Function

    Public Sub New(ByVal text_ As String, ByVal value_ As T)
        _text = text_
        _value = value_
    End Sub

End Class
