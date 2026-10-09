Namespace OpenRGB

    Public Class OpenRGBConf
        Public Property controllers() As Controller
        Public Property profile_name As String
        Public Property profile_version As Integer
    End Class

    Public Class Controller
        Public Property active_mode As Integer
        Public Property colors() As Integer
        Public Property configuration As Object
        Public Property description As String
        Public Property display_name As String
        Public Property flags As Integer
        Public Property leds() As Led
        Public Property location As String
        Public Property modes() As Mode
        Public Property name As String
        Public Property serial As String
        Public Property type As eDeviceType
        Public Property vendor As String
        Public Property version As String
        Public Property zones() As Zone
    End Class

    Public Class Led
        Public Property name As String
    End Class

    Public Class Mode
        Public Property brightness As Integer
        Public Property brightness_max As Integer
        Public Property brightness_min As Integer
        Public Property color_mode As Integer
        Public Property colors_max As Integer
        Public Property colors_min As Integer
        Public Property direction As Integer
        Public Property flags As Integer
        Public Property name As String
        Public Property speed As Integer
        Public Property speed_max As Integer
        Public Property speed_min As Integer
        Public Property colors() As Integer
    End Class

    Public Class Zone
        Public Property display_name As String
        Public Property flags As Integer
        Public Property leds_count As Integer
        Public Property leds_max As Integer
        Public Property leds_min As Integer
        Public Property matrix_map As Matrix_Map
        Public Property name As String
        Public Property segments() As Segment
        Public Property type As eZoneType
    End Class

    Public Class Matrix_Map
        Public Property height As Integer
        Public Property width As Integer
        Public Property map() As Long
    End Class

    Public Class Segment
        Public Property flags As Integer
        Public Property leds_count As Integer
        Public Property matrix_map As Matrix_Map
        Public Property name As String
        Public Property start_idx As Integer
        Public Property type As eZoneType
    End Class

    Public Enum eDeviceType
        DEVICE_TYPE_MOTHERBOARD
        DEVICE_TYPE_DRAM
        DEVICE_TYPE_GPU
        DEVICE_TYPE_COOLER
        DEVICE_TYPE_LEDSTRIP
        DEVICE_TYPE_KEYBOARD
        DEVICE_TYPE_MOUSE
        DEVICE_TYPE_MOUSEMAT
        DEVICE_TYPE_HEADSET
        DEVICE_TYPE_HEADSETSTAND
        DEVICE_TYPE_GAMEPAD
        DEVICE_TYPE_LIGHT
        DEVICE_TYPE_SPEAKER
        DEVICE_TYPE_VIRTUAL
        DEVICE_TYPE_STORAGE
        DEVICE_TYPE_CASE
        DEVICE_TYPE_MICROPHONE
        DEVICE_TYPE_ACCESSORY
        DEVICE_TYPE_KEYPAD
        DEVICE_TYPE_LAPTOP
        DEVICE_TYPE_MONITOR
        DEVICE_TYPE_UNKNOWN
    End Enum

    Public Enum eZoneType
        ZONE_TYPE_SINGLE
        ZONE_TYPE_LINEAR
        ZONE_TYPE_MATRIX
        ZONE_TYPE_LINEAR_LOOP
        ZONE_TYPE_MATRIX_LOOP_X
        ZONE_TYPE_MATRIX_LOOP_Y
        ZONE_TYPE_SEGMENTED
    End Enum

End Namespace