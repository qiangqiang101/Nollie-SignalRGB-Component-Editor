Imports System.Net.Http.Headers
Imports Newtonsoft.Json

Public Structure OpenRGBVMap

    Public ctrl_zones As List(Of ctrl_zones)
    Public grid_settings As grid_settings

    Public Function Load(filename As String) As OpenRGBVMap
        Return JsonConvert.DeserializeObject(Of OpenRGBVMap)(IO.File.ReadAllText(filename))
    End Function

End Structure

Public Structure ctrl_zones

    Public controller As _controller
    Public custom_zone_name As String
    Public settings As _settings
    Public zone_idx As Integer

End Structure

Public Structure _controller

    Public location As String
    Public name As String
    Public serial As String
    Public vendor As String

End Structure

Public Structure _settings

    Public custom_shape As custom_shape?
    Public led_spacing As Integer
    Public reverse As Boolean
    Public shape As Integer
    Public x As Long
    Public y As Long

End Structure

Public Structure custom_shape

    Public h As Integer
    Public led_positions As List(Of led_positions)
    Public w As Integer

End Structure

Public Structure led_positions

    Public led_num As Integer
    Public x As Integer
    Public y As Integer

End Structure

Public Structure grid_settings

    Public auto_load As Boolean
    Public auto_register As Boolean
    Public grid_size As Integer
    Public w As Integer
    Public h As Integer
    Public show_bounds As Boolean
    Public show_grid As Boolean
    Public unregister_members As Boolean

End Structure
