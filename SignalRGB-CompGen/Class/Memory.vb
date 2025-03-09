Public Class Memory

    Public Direction As eDirection
    Public LEDAmount As Integer
    Public MatrixOrder As eMatrixOrder
    Public MatrixSerpentine As Boolean
    Public MatrixSize As Size

    Public Sub New()
        Direction = eDirection.Up
        LEDAmount = 1
        MatrixOrder = eMatrixOrder.HorizontalTopLeft
        MatrixSerpentine = False
        MatrixSize = New Size(1, 1)
    End Sub

End Class
