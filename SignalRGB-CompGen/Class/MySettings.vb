﻿Imports Newtonsoft.Json

Public Class MySettings

    Public Language As String = "en-US"
    Public ShiftIndex As Boolean = False
    Public Debug As Boolean = False
    Public DefaultSize As Size = New Size(5, 5)

    Public Function Load(filename As String) As MySettings
        Return JsonConvert.DeserializeObject(Of MySettings)(IO.File.ReadAllText(filename))
    End Function

    Public Sub Save(filename As String)
        IO.File.WriteAllText(filename, JsonConvert.SerializeObject(Me, Formatting.Indented))
    End Sub

End Class

Public Class MyLanguage

    Public LanguageName As String = "English"
    Public LanguageID As String = "en-US"
    Public Localization As New Localization()

    Public Function Load(filename As String) As MyLanguage
        Return JsonConvert.DeserializeObject(Of MyLanguage)(IO.File.ReadAllText(filename))
    End Function

    Public Sub Save(filename As String)
        IO.File.WriteAllText(filename, JsonConvert.SerializeObject(Me, Formatting.Indented))
    End Sub

End Class

Public Class Localization

    Public Untitled As String = "Untitled"
    Public Title As String = "{0} - Nollie x SignalRGB Custom Component Editor"

    Public File As String = "File"
    Public [New] As String = "New"
    Public Open As String = "Open.."
    Public SelectComponentFile As String = "Select component file.."
    Public Save As String = "Save"
    Public SaveAs As String = "Save As..."
    Public ImportOpenRGBVisualMap As String = "Import OpenRGB Visual Map"
    Public SelectOpenRGBVisualMapFile As String = "Select OpenRGB Visual Map file.."
    Public SaveComponentFileAs As String = "Save component file as..."
    Public [Exit] As String = "Exit"
    Public Settings As String = "Settings"
    Public Help As String = "Help"
    Public Controls As String = "Controls"
    Public ControlMsg As String = "Mouse Controls: {0}Left Click: Select LED/Move LED{0}Left Double Click: Add LED{0}Middle Click: Move Map{0}Scroll: Zoom{0}Right Click: Show Menu{0}{0}Keyboard Controls: {0}Spacebar: Add LED on Mouse Position{0}Delete Tap: Remove last Object{0}Delete Hold: Remove All Objects{0}Arrow keys: Move All Object{0}Shift + Arrow keys: Move Selected Objects"
    Public VisitSignalRGB As String = "Visit SignalRGB Website"
    Public VisitNollie As String = "Visit Nollie Website"
    Public VisitMentaL As String = "Visit I'm Not MentaL Website"
    Public BuyNollie As String = "Buy Nollie32"

    Public Name As String = "Name"
    Public Vendor As String = "Vendor"
    Public Product As String = "Product"
    Public Type As String = "Type"
    Public AIO As String = "AIO"
    Public Cable As String = "Cable"
    Public [Case] As String = "Case"
    Public Chair As String = "Chair"
    Public Fan As String = "Fan"
    Public Custom As String = "Custom"
    Public Strip As String = "Strip"
    Public WaterBlock As String = "Water Block"
    Public Tower As String = "Tower"
    Public Heatsink As String = "Heatsink"
    Public Desk As String = "Desk"
    Public Width As String = "Width"
    Public Height As String = "Height"
    Public LEDCount As String = "LED Count"
    Public SelectImage As String = "Select Image"
    Public SelectImageFile As String = "Select image file.."
    Public Position As String = "Position:"
    Public ComponentImage As String = "Component Image"
    Public ImageURL As String = "Image URL"

    Public LEDInfo As String = "Index: {1}{0}Name: {2}{0}Position: {3}, {4}"
    Public AddLED As String = "Add LED"
    Public RemoveLastLED As String = "Remove last LED"
    Public RemoveLastLEDs As String = "Remove last LEDs"

    Public NumberOfLEDs As String = "Number of LEDs"
    Public Direction As String = "Direction"
    Public Confirm As String = "Confirm"
    Public Up As String = "Up"
    Public Right As String = "Right"
    Public Down As String = "Down"
    Public Left As String = "Left"

    Public Language As String = "Language"
    Public ShiftDisplayingLEDIndex As String = "Shift Displaying LED index by 1"
    Public Console As String = "Console"
    Public SettingSaveMsg As String = "Some setting changes will not take effect until you restart SignalRGB Custom Component Editor."

    Public AutoResize As String = "AutoResize"

    Public EditLED As String = "Edit LED"
    Public LEDName As String = "LED Name"
    Public LEDCoordinates As String = "LED Coordinates"

    Public FileName As String = "File Name"
    Public Device As String = "Device"
    Public Location As String = "Location"
    Public Zone As String = "Zone"

    'Added on 09/03/2025
    Public Size As String = "Size"
    Public Order As String = "Order"
    Public Serpentine As String = "Serpentine"
    Public HorizontalTopLeft As String = "Horizontal Top Left"
    Public HorizontalTopRight As String = "Horizontal Top Right"
    Public HorizontalBottomLeft As String = "Horizontal Bottom Left"
    Public HorizontalBottomRight As String = "Horizontal Bottom Right"
    Public VerticalTopLeft As String = "Vertical Top Left"
    Public VerticalTopRight As String = "Vertical Top Right"
    Public VerticalBottomLeft As String = "Vertical Bottom Left"
    Public VerticalBottomRight As String = "Vertical Bottom Right"
    Public Generate As String = "Generate"
    Public Matrix As String = "Matrix"
    Public Linear As String = "Linear"

    'Added on 13/03/2025
    Public DefaultSize As String = "Default Size"
    Public Spacing As String = "Spacing"
    Public LShape As String = "L-Shape"
    Public UShape As String = "U-Shape"
    Public Rectangle As String = "Rectangle"
    Public BendAfter As String = "Bend after"
    Public DownRight As String = "Down and Right"
    Public DownLeft As String = "Down and Left"
    Public UpRight As String = "Up and Right"
    Public UpLeft As String = "Up and Left"
    Public RightDown As String = "Right and Down"
    Public RightUp As String = "Right and Up"
    Public LeftDown As String = "Left and Down"
    Public LeftUp As String = "Left and Up"
    Public RoundedCorners As String = "Rounded Corners"
    Public Oops As String = "Oops!"
    Public InvalidLEDAmount As String = "Invalid LED Amount."
    Public DownRightUp As String = "Down, Right and Up"
    Public DownLeftUp As String = "Down, Left and Up"
    Public UpRightDown As String = "Up, Right and Down"
    Public UpLeftDown As String = "Up, Left and Down"
    Public RightDownLeft As String = "Right, Down and Left"
    Public RightUpLeft As String = "Right, Up and Left"
    Public LeftDownRight As String = "Left, Down and Right"
    Public LeftUpRight As String = "Left, Up and Right"
    Public DownAmount As String = "Downwards LED Amount"
    Public UpAmount As String = "Upwards LED Amount"
    Public LeftAmount As String = "Leftwards LED Amount"
    Public RightAmount As String = "Rightwards LED Amount"

    'Added on 17/03/2025
    Public Objects As String = "Objects"
    Public Index As String = "Index"
    Public AllObjects As String = "All Objects"
    Public LastObject As String = "Last Object: {0}"
    Public [Single] As String = "Single"
    Public RemoveLastObject As String = "Remove Last Object"
    Public Removezz As String = "Remove.."
    Public DownRightUpLeft As String = "Down, Right, Up and Left"
    Public DownLeftUpRight As String = "Down, Left, Up and Right"
    Public UpRightDownLeft As String = "Up, Right, Down and Left"
    Public UpLeftDownRight As String = "Up, Left, Down and Right"
    Public RightDownLeftUp As String = "Right, Down, Left and Up"
    Public RightUpLeftDown As String = "Right, Up, Left and Down"
    Public LeftDownRightUp As String = "Left, Down, Right and Up"
    Public LeftUpRightDown As String = "Left, Up, Right and Down"

End Class