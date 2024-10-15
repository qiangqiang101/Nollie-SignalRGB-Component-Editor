Imports Newtonsoft.Json

Public Class MySettings

    Public Language As String = "en-US"
    Public ShiftIndex As Boolean = False
    Public Debug As Boolean = False

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
    Public ControlMsg As String = "Mouse Controls: {0}Left Click: Select LED/Move LED{0}Left Double Click: Add LED{0}Middle Click: Move Map{0}Scroll: Zoom{0}Right Click: Show Menu{0}{0}Keyboard Controls: {0}Spacebar: Add LED on Mouse Position{0}Delete: Remove last LED{0}Arrow keys: Move LEDs"
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
    Public AddLEDs As String = "Add LEDs"
    Public RemoveLastLED As String = "Remove last LED"
    Public RemoveLastLEDs As String = "Remove last LEDs"

    Public NumberOfLEDs As String = "Number of LEDs"
    Public Direction As String = "Direction"
    Public Confirm As String = "Confirm"
    Public Top As String = "Top"
    Public Right As String = "Right"
    Public Bottom As String = "Bottom"
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

End Class