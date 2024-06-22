Imports System.Runtime.InteropServices

Public Enum GetWindow_Cmd
    GW_HWNDFIRST = 0
    GW_HWNDLAST = 1
    GW_HWNDNEXT = 2
    GW_HWNDPREV = 3
    GW_OWNER = 4
    GW_CHILD = 5
    GW_ENABLEDPOPUP = 6
End Enum

Public Enum HitTestValues
    HTERROR = -2
    HTTRANSPARENT = -1
    HTNOWHERE = 0
    HTCLIENT = 1
    HTCAPTION = 2
    HTSYSMENU = 3
    HTGROWBOX = 4
    HTMENU = 5
    HTHSCROLL = 6
    HTVSCROLL = 7
    HTMINBUTTON = 8
    HTMAXBUTTON = 9
    HTLEFT = 10
    HTRIGHT = 11
    HTTOP = 12
    HTTOPLEFT = 13
    HTTOPRIGHT = 14
    HTBOTTOM = 15
    HTBOTTOMLEFT = 16
    HTBOTTOMRIGHT = 17
    HTBORDER = 18
    HTOBJECT = 19
    HTCLOSE = 20
    HTHELP = 21
End Enum

Public Enum WindowMessages
    WM_NULL = &H0
    WM_CREATE = &H1
    WM_DESTROY = &H2
    WM_MOVE = &H3
    WM_SIZE = &H5
    WM_ACTIVATE = &H6
    WM_SETFOCUS = &H7
    WM_KILLFOCUS = &H8
    WM_ENABLE = &HA
    WM_SETREDRAW = &HB
    WM_SETTEXT = &HC
    WM_GETTEXT = &HD
    WM_GETTEXTLENGTH = &HE
    WM_PAINT = &HF
    WM_CLOSE = &H10
    WM_QUIT = &H12
    WM_ERASEBKGND = &H14
    WM_SYSCOLORCHANGE = &H15
    WM_SHOWWINDOW = &H18
    WM_ACTIVATEAPP = &H1C
    WM_SETCURSOR = &H20
    WM_MOUSEACTIVATE = &H21
    WM_GETMINMAXINFO = &H24
    WM_WINDOWPOSCHANGING = &H46
    WM_WINDOWPOSCHANGED = &H47
    WM_CONTEXTMENU = &H7B
    WM_STYLECHANGING = &H7C
    WM_STYLECHANGED = &H7D
    WM_DISPLAYCHANGE = &H7E
    WM_GETICON = &H7F
    WM_SETICON = &H80
    WM_NCCREATE = &H81
    WM_NCDESTROY = &H82
    WM_NCCALCSIZE = &H83
    WM_NCHITTEST = &H84
    WM_NCPAINT = &H85
    WM_NCACTIVATE = &H86
    WM_GETDLGCODE = &H87
    WM_SYNCPAINT = &H88
    WM_NCMOUSEMOVE = &HA0
    WM_NCLBUTTONDOWN = &HA1
    WM_NCLBUTTONUP = &HA2
    WM_NCLBUTTONDBLCLK = &HA3
    WM_NCRBUTTONDOWN = &HA4
    WM_NCRBUTTONUP = &HA5
    WM_NCRBUTTONDBLCLK = &HA6
    WM_NCMBUTTONDOWN = &HA7
    WM_NCMBUTTONUP = &HA8
    WM_NCMBUTTONDBLCLK = &HA9
    WM_KEYDOWN = &H100
    WM_KEYUP = &H101
    WM_CHAR = &H102
    WM_SYSCOMMAND = &H112
    WM_INITMENU = &H116
    WM_INITMENUPOPUP = &H117
    WM_MENUSELECT = &H11F
    WM_MENUCHAR = &H120
    WM_ENTERIDLE = &H121
    WM_MENURBUTTONUP = &H122
    WM_MENUDRAG = &H123
    WM_MENUGETOBJECT = &H124
    WM_UNINITMENUPOPUP = &H125
    WM_MENUCOMMAND = &H126
    WM_CHANGEUISTATE = &H127
    WM_UPDATEUISTATE = &H128
    WM_QUERYUISTATE = &H129
    WM_MOUSEFIRST = &H200
    WM_MOUSEMOVE = &H200
    WM_LBUTTONDOWN = &H201
    WM_LBUTTONUP = &H202
    WM_LBUTTONDBLCLK = &H203
    WM_RBUTTONDOWN = &H204
    WM_RBUTTONUP = &H205
    WM_RBUTTONDBLCLK = &H206
    WM_MBUTTONDOWN = &H207
    WM_MBUTTONUP = &H208
    WM_MBUTTONDBLCLK = &H209
    WM_MOUSEWHEEL = &H20A
    WM_MOUSELAST = &H20D
    WM_PARENTNOTIFY = &H210
    WM_ENTERMENULOOP = &H211
    WM_EXITMENULOOP = &H212
    WM_NEXTMENU = &H213
    WM_SIZING = &H214
    WM_CAPTURECHANGED = &H215
    WM_MOVING = &H216
    WM_ENTERSIZEMOVE = &H231
    WM_EXITSIZEMOVE = &H232
    WM_MOUSELEAVE = &H2A3
    WM_MOUSEHOVER = &H2A1
    WM_NCMOUSEHOVER = &H2A0
    WM_NCMOUSELEAVE = &H2A2
    WM_MDIACTIVATE = &H222
    WM_HSCROLL = &H114
    WM_VSCROLL = &H115
    WM_SYSMENU = &H313
    WM_PRINT = &H317
    WM_PRINTCLIENT = &H318
End Enum

Public Enum SystemCommands
    SC_SIZE = &HF000
    SC_MOVE = &HF010
    SC_MINIMIZE = &HF020
    SC_MAXIMIZE = &HF030
    SC_MAXIMIZE2 = &HF032
    SC_NEXTWINDOW = &HF040
    SC_PREVWINDOW = &HF050
    SC_CLOSE = &HF060
    SC_VSCROLL = &HF070
    SC_HSCROLL = &HF080
    SC_MOUSEMENU = &HF090
    SC_KEYMENU = &HF100
    SC_ARRANGE = &HF110
    SC_RESTORE = &HF120
    SC_RESTORE2 = &HF122
    SC_TASKLIST = &HF130
    SC_SCREENSAVE = &HF140
    SC_HOTKEY = &HF150
    SC_DEFAULT = &HF160
    SC_MONITORPOWER = &HF170
    SC_CONTEXTHELP = &HF180
    SC_SEPARATOR = &HF00F
End Enum

<StructLayout(LayoutKind.Sequential)>
Public Structure RECT
    Public left As Integer
    Public top As Integer
    Public right As Integer
    Public bottom As Integer

    Public Sub New(ByVal left As Integer, ByVal top As Integer, ByVal right As Integer, ByVal bottom As Integer)
        Me.left = left
        Me.top = top
        Me.right = right
        Me.bottom = bottom
    End Sub

    Public Shared Function FromXYWH(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As RECT
        Return New RECT(x, y, x + width, y + height)
    End Function
End Structure

<StructLayout(LayoutKind.Sequential)>
Friend Structure WINDOWPOS
    Friend hwnd As IntPtr
    Friend hWndInsertAfter As IntPtr
    Friend x As Integer
    Friend y As Integer
    Friend cx As Integer
    Friend cy As Integer
    Friend flags As UInteger
End Structure

<StructLayout(LayoutKind.Sequential)>
Public Structure POINTS
    Public X As Short
    Public Y As Short
End Structure

<Flags>
Public Enum WindowStyle
    WS_OVERLAPPED = &H0
    WS_POPUP = -2147483648
    WS_CHILD = &H40000000
    WS_MINIMIZE = &H20000000
    WS_VISIBLE = &H10000000
    WS_DISABLED = &H8000000
    WS_CLIPSIBLINGS = &H4000000
    WS_CLIPCHILDREN = &H2000000
    WS_MAXIMIZE = &H1000000
    WS_CAPTION = &HC00000
    WS_BORDER = &H800000
    WS_DLGFRAME = &H400000
    WS_VSCROLL = &H200000
    WS_HSCROLL = &H100000
    WS_SYSMENU = &H80000
    WS_THICKFRAME = &H40000
    WS_GROUP = &H20000
    WS_TABSTOP = &H10000
    WS_MINIMIZEBOX = &H20000
    WS_MAXIMIZEBOX = &H10000
    WS_TILED = WS_OVERLAPPED
    WS_ICONIC = WS_MINIMIZE
    WS_SIZEBOX = WS_THICKFRAME
    WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW
    WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED Or WS_CAPTION Or WS_SYSMENU Or WS_THICKFRAME Or WS_MINIMIZEBOX Or WS_MAXIMIZEBOX)
    WS_POPUPWINDOW = (WS_POPUP Or WS_BORDER Or WS_SYSMENU)
    WS_CHILDWINDOW = (WS_CHILD)
End Enum

<StructLayout(LayoutKind.Sequential)>
Public Structure NativeMessage
    Public handle As IntPtr
    Public msg As UInteger
    Public wParam As IntPtr
    Public lParam As IntPtr
    Public time As UInteger
    Public p As System.Drawing.Point
End Structure

<StructLayout(LayoutKind.Sequential)>
Public Structure APPBARDATA
    Public cbSize As Integer
    Public hWnd As IntPtr
    Public uCallbackMessage As UInteger
    Public uEdge As UInteger
    Public rc As RECT
    Public lParam As Integer
End Structure

Module NativeMethods
    <DllImport("user32.dll")>
    Function ReleaseCapture() As Boolean
    End Function
    <DllImport("user32.dll")>
    Function SetCapture(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Function GetCapture() As IntPtr
    End Function
    <DllImport("user32.dll")>
    Function SetForegroundWindow(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True)>
    Function SetActiveWindow(ByVal hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Function SendMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wparam As Integer, ByVal lparam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Function PostMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wparam As Integer, ByVal lparam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Function TrackPopupMenuEx(ByVal hmenu As IntPtr, ByVal fuFlags As UInteger, ByVal x As Integer, ByVal y As Integer, ByVal hwnd As IntPtr, ByVal lptpm As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Function SendMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wparam As Integer, ByVal pos As POINTS) As Integer
    End Function
    <DllImport("user32.dll")>
    Function PostMessage(ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
    End Function
    <DllImport("user32.dll")>
    Function PostMessage(ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wparam As Integer, ByVal pos As POINTS) As Integer
    End Function
    <DllImport("user32.dll")>
    Function SetWindowRgn(ByVal hWnd As IntPtr, ByVal hRgn As IntPtr, ByVal bRedraw As Boolean) As Integer
    End Function
    <DllImport("user32.dll")>
    Function IsWindowVisible(ByVal hWnd As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean

    End Function
    <DllImport("gdi32.dll")>
    Function CreateRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Function GetWindowRgn(ByVal hWnd As IntPtr, ByVal hRgn As IntPtr) As Integer
    End Function

    <DllImport("gdi32.dll")>
    Function GetRgnBox(ByVal hrgn As IntPtr, <Out> ByRef lprc As RECT) As Integer
    End Function

    <DllImport("user32.dll")>
    Function GetWindowLong(ByVal hWnd As IntPtr, ByVal Offset As Int32) As Int32
    End Function

    <DllImport("user32.dll")>
    Function GetSystemMetrics(ByVal smIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal className As String, ByVal windowTitle As String) As IntPtr
    End Function

    <DllImport("shell32.dll")>
    Function SHAppBarMessage(ByVal dwMessage As UInteger, <[In]> ByRef pData As APPBARDATA) As Integer
    End Function
    <DllImport("gdi32.dll")>
    Function DeleteObject(ByVal hObj As IntPtr) As Boolean
    End Function

End Module

Module NativeConstants
    Public Const SM_CXSIZEFRAME As Integer = 32
    Public Const SM_CYSIZEFRAME As Integer = 33
    Public Const SM_CXPADDEDBORDER As Integer = 92
    Public Const GWL_ID As Integer = (-12)
    Public Const GWL_STYLE As Integer = (-16)
    Public Const GWL_EXSTYLE As Integer = (-20)
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const WM_NCRBUTTONUP As Integer = &HA5
    Public Const TPM_LEFTBUTTON As UInteger = &H0
    Public Const TPM_RIGHTBUTTON As UInteger = &H2
    Public Const TPM_RETURNCMD As UInteger = &H100
    Public ReadOnly [TRUE] As IntPtr = New IntPtr(1)
    Public ReadOnly [FALSE] As IntPtr = New IntPtr(0)
    Public Const ABM_GETSTATE As UInteger = &H4
    Public Const ABS_AUTOHIDE As Integer = &H1
End Module
