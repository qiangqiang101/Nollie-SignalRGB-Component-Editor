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
    Public GeneratedObjects As List(Of GeneratedObject)

    Public Function LastGeneratedObject() As GeneratedObject
        If GeneratedObjects.Count = 0 Then
            Return Nothing
        Else
            Return GeneratedObjects.OrderByDescending(Function(x) x.TimeStamp).First()
        End If
    End Function

    Public Sub AddGeneratedObject(name As String, start As Integer, value As Integer)
        Dim go As New GeneratedObject(name, start, value)
        GeneratedObjects.Add(go)
        frmMain.AddGeneratedObjectToListview(go)
        Console.WriteLine($"Name: {name}, Start Index: {start}, Amount: {value}")
    End Sub

    Public Sub RemoveLastGeneratedObject()
        If GeneratedObjects.Count <> 0 Then
            frmMain.RemoveLastGeneratedObjectFromListview(LastGeneratedObject)
            GeneratedObjects.Remove(LastGeneratedObject)
        End If
    End Sub

    Public Sub ClearAllGeneratedObjects()
        If GeneratedObjects.Count <> 0 Then
            frmMain.lvObjects.Clear()
            GeneratedObjects.Clear()
        End If
    End Sub

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
        GeneratedObjects = New List(Of GeneratedObject)
    End Sub

End Class

Public Class GeneratedObject

    Public Name As String
    Public StartIndex As Integer
    Public LEDs As Integer
    Public TimeStamp As Long

    Public Sub New(name As String, start As Integer, leds As Integer)
        Me.Name = name
        StartIndex = start
        Me.LEDs = leds
        TimeStamp = Now.Ticks
    End Sub

    Public Sub New()
        Name = Nothing
        StartIndex = 0
        LEDs = 0
        TimeStamp = Now.Ticks
    End Sub

    Public Shared Operator =(a As GeneratedObject, b As GeneratedObject) As Boolean
        Return a Is b
    End Operator

    Public Shared Operator <>(a As GeneratedObject, b As GeneratedObject) As Boolean
        Return a IsNot b
    End Operator

End Class