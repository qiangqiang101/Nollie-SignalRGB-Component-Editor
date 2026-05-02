Imports System.Numerics

Public Class Memory

    Public Direction As eDirection
    Public LEDAmount As Integer
    Public MatrixOrder As eMatrixOrder
    Public MatrixSerpentine As Boolean
    Public MatrixSize As Size
    Public LShapeOrder As eLShapeOrder
    Public UShapeOrder As eUShapeOrder
    Public RectOrder As eRectOrder
    Public LShapeX As Integer
    Public LShapeY As Integer
    Public UShapeX As Integer
    Public UShapeY As Integer
    Public UShapeZ As Integer
    Public RectW As Integer
    Public RectX As Integer
    Public RectY As Integer
    Public RectZ As Integer
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
        RectOrder = eRectOrder.DownRightUpLeft
        LShapeX = 1
        LShapeY = 1
        UShapeX = 1
        UShapeY = 1
        UShapeZ = 1
        RectW = 1
        RectX = 1
        RectY = 1
        RectZ = 1
        Spacing = 0
        RoundedCorners = False
    End Sub

End Class