Imports System.Numerics

Public Class Memory

    Public Direction As eDirection
    Public LEDAmount As Integer
    Public MatrixOrder As eMatrixOrder
    Public MatrixSerpentine As Boolean
    Public MatrixSize As Size
    Public LShapeOrder As eLShapeOrder
    Public UShapeOrder As eUShapeOrder
    Public BendAfter As Integer
    Public UShapeX As Integer
    Public UShapeY As Integer
    Public UShapeZ As Integer
    Public Spacing As Integer
    Public RoundedCorners As Boolean

    Public Sub New()
        Direction = eDirection.Up
        LEDAmount = 1
        MatrixOrder = eMatrixOrder.HorizontalTopLeft
        MatrixSerpentine = False
        MatrixSize = New Size(1, 1)
        LShapeOrder = eLShapeOrder.DownRight
        UShapeOrder = eUShapeOrder.DownRightUp
        BendAfter = 1
        UShapeX = 1
        UShapeY = 1
        UShapeZ = 1
        Spacing = 0
        RoundedCorners = False
    End Sub

End Class
