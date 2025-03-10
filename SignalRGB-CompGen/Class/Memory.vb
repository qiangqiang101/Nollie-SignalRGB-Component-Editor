Public Class Memory

    Public Direction As eDirection
    Public LEDAmount As Integer
    Public MatrixOrder As eMatrixOrder
    Public MatrixSerpentine As Boolean
    Public MatrixSize As Size
    Public LShapeOrder As eLShapeOrder
    Public BendAfter As Integer
    Public BendAfter2 As Integer
    Public BendAfter3 As Integer

    Public Sub New()
        Direction = eDirection.Up
        LEDAmount = 1
        MatrixOrder = eMatrixOrder.HorizontalTopLeft
        MatrixSerpentine = False
        MatrixSize = New Size(1, 1)
        LShapeOrder = eLShapeOrder.DownRight
        BendAfter = 1
        BendAfter2 = 1
        BendAfter3 = 1
    End Sub

End Class
