Imports System.Runtime.InteropServices

Public Class FormEx
    Inherits Form

    Public Sub DecorationMouseDown(ByVal hit As HitTestValues, ByVal p As Point)
        NativeMethods.ReleaseCapture()
        Dim pt = New POINTS With {
            .X = CShort(p.X),
            .Y = CShort(p.Y)
        }
        NativeMethods.SendMessage(Handle, CInt(WindowMessages.WM_NCLBUTTONDOWN), CInt(hit), pt)
    End Sub

    Public Sub DecorationMouseDown(ByVal hit As HitTestValues)
        DecorationMouseDown(hit, MousePosition)
    End Sub

    Public Sub DecorationMouseUp(ByVal hit As HitTestValues, ByVal p As Point)
        NativeMethods.ReleaseCapture()
        Dim pt = New POINTS With {
            .X = CShort(p.X),
            .Y = CShort(p.Y)
        }
        NativeMethods.SendMessage(Handle, CInt(WindowMessages.WM_NCLBUTTONUP), CInt(hit), pt)
    End Sub

    Public Sub DecorationMouseUp(ByVal hit As HitTestValues)
        DecorationMouseUp(hit, MousePosition)
    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)
        If Not DesignMode Then SetWindowRegion(Handle, 0, 0, Width, Height)
    End Sub

    Protected Sub ShowSystemMenu(ByVal buttons As MouseButtons)
        ShowSystemMenu(buttons, MousePosition)
    End Sub

    Protected Shared Function MakeLong(lowPart As Short, highPart As Short) As Integer
        Return CInt(CUShort(lowPart) Or CUInt(highPart << 16))
    End Function

    Protected Sub ShowSystemMenu(ByVal buttons As MouseButtons, ByVal pos As Point)
        NativeMethods.SendMessage(Handle, CInt(WindowMessages.WM_SYSMENU), 0, MakeLong(CShort(pos.X), CShort(pos.Y)))
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If DesignMode Then
            MyBase.WndProc(m)
            Return
        End If

        Select Case m.Msg
            Case CInt(WindowMessages.WM_NCCALCSIZE)
                WmNCCalcSize(m)
                Exit Select
            Case CInt(WindowMessages.WM_NCPAINT)
                WmNCPaint(m)
                Exit Select
            Case CInt(WindowMessages.WM_NCACTIVATE)
                WmNCActivate(m)
                Exit Select
            Case CInt(WindowMessages.WM_SETTEXT)
                WmSetText(m)
                Exit Select
            Case CInt(WindowMessages.WM_WINDOWPOSCHANGED)
                WmWindowPosChanged(m)
                Exit Select
            Case 174
                Exit Select
            Case Else
                MyBase.WndProc(m)
                Exit Select
        End Select
    End Sub

    Private Sub SetWindowRegion(ByVal hwnd As IntPtr, ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
        Dim rgn = NativeMethods.CreateRectRgn(0, 0, 0, 0)
        Dim hrg = New HandleRef(CObj(Me), rgn)
        Dim r = NativeMethods.GetWindowRgn(hwnd, hrg.Handle)
        Dim box As RECT
        NativeMethods.GetRgnBox(hrg.Handle, box)

        If box.left <> left OrElse box.top <> top OrElse box.right <> right OrElse box.bottom <> bottom Then
            Dim hr = New HandleRef(CObj(Me), NativeMethods.CreateRectRgn(left, top, right, bottom))
            NativeMethods.SetWindowRgn(hwnd, hr.Handle, NativeMethods.IsWindowVisible(hwnd))
        End If

        NativeMethods.DeleteObject(rgn)
    End Sub

    Public ReadOnly Property MinMaxState As FormWindowState
        Get
            Dim s = NativeMethods.GetWindowLong(Handle, NativeConstants.GWL_STYLE)
            Dim max = (s And CInt(WindowStyle.WS_MAXIMIZE)) > 0
            If max Then Return FormWindowState.Maximized
            Dim min = (s And CInt(WindowStyle.WS_MINIMIZE)) > 0
            If min Then Return FormWindowState.Minimized
            Return FormWindowState.Normal
        End Get
    End Property

    Private Sub WmWindowPosChanged(ByRef m As Message)
        DefWndProc(m)
        UpdateBounds()
        Dim pos = CType(Marshal.PtrToStructure(m.LParam, GetType(WINDOWPOS)), WINDOWPOS)
        SetWindowRegion(m.HWnd, 0, 0, pos.cx, pos.cy)
        m.Result = NativeConstants.[TRUE]
    End Sub

    Private Sub WmNCCalcSize(ByRef m As Message)
        Dim r = CType(Marshal.PtrToStructure(m.LParam, GetType(RECT)), RECT)
        Dim max = MinMaxState = FormWindowState.Maximized

        If max Then
            Dim x = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXSIZEFRAME)
            Dim y = NativeMethods.GetSystemMetrics(NativeConstants.SM_CYSIZEFRAME)
            Dim p = NativeMethods.GetSystemMetrics(NativeConstants.SM_CXPADDEDBORDER)
            Dim w = x + p
            Dim h = y + p
            r.left += w
            r.top += h
            r.right -= w
            r.bottom -= h
            Dim appBarData = New APPBARDATA()
            appBarData.cbSize = Marshal.SizeOf(GetType(APPBARDATA))
            Dim autohide = (NativeMethods.SHAppBarMessage(NativeConstants.ABM_GETSTATE, appBarData) And NativeConstants.ABS_AUTOHIDE) <> 0
            If autohide Then r.bottom -= 1
            Marshal.StructureToPtr(r, m.LParam, True)
        End If

        m.Result = IntPtr.Zero
    End Sub

    Private Sub WmNCPaint(ByRef msg As Message)
        msg.Result = NativeConstants.[TRUE]
    End Sub

    Private Sub WmSetText(ByRef msg As Message)
        DefWndProc(msg)
    End Sub

    Private Sub WmNCActivate(ByRef msg As Message)
        Dim active As Boolean = (msg.WParam = NativeConstants.[TRUE])

        If MinMaxState = FormWindowState.Minimized Then
            DefWndProc(msg)
        Else
            msg.Result = NativeConstants.[TRUE]
        End If
    End Sub

End Class
