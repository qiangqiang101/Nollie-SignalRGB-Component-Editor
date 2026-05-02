<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucComponent
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiRemoveLed = New ToolStripMenuItem()
        NsContextMenu1 = New NSContextMenu()
        tsmiEditLED = New ToolStripMenuItem()
        tsmiGenerate = New ToolStripMenuItem()
        tsmiLinear = New ToolStripMenuItem()
        tsmiMatrix = New ToolStripMenuItem()
        tsmiLShape = New ToolStripMenuItem()
        tsmiUShape = New ToolStripMenuItem()
        tsmiRectangle = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiAutoResize = New ToolStripMenuItem()
        tsmiInsertBgImage = New ToolStripMenuItem()
        tsmiRotateLeft = New ToolStripMenuItem()
        tsmiRotateRight = New ToolStripMenuItem()
        tsmiFlipHorizontal = New ToolStripMenuItem()
        tsmiFlipVertical = New ToolStripMenuItem()
        tsmiHideLEDs = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        tsmiCopy = New ToolStripMenuItem()
        tsmiPaste = New ToolStripMenuItem()
        tPressHold = New Timer(components)
        NsContextMenu1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(207, 6)
        ' 
        ' tsmiRemoveLed
        ' 
        tsmiRemoveLed.Image = My.Resources.Resources.led_variant_outline_remove_custom
        tsmiRemoveLed.Name = "tsmiRemoveLed"
        tsmiRemoveLed.ShortcutKeys = Keys.Delete
        tsmiRemoveLed.Size = New Size(210, 22)
        tsmiRemoveLed.Text = "Remove last LED"
        ' 
        ' NsContextMenu1
        ' 
        NsContextMenu1.ForeColor = Color.White
        NsContextMenu1.Items.AddRange(New ToolStripItem() {tsmiEditLED, tsmiGenerate, ToolStripSeparator1, tsmiRemoveLed, ToolStripSeparator2, tsmiAutoResize, tsmiInsertBgImage, tsmiRotateLeft, tsmiRotateRight, tsmiFlipHorizontal, tsmiFlipVertical, tsmiHideLEDs, ToolStripSeparator3, tsmiCopy, tsmiPaste})
        NsContextMenu1.Name = "NsContextMenu1"
        NsContextMenu1.Size = New Size(211, 286)
        ' 
        ' tsmiEditLED
        ' 
        tsmiEditLED.Image = My.Resources.Resources.led_variant_outline_edit_custom
        tsmiEditLED.Name = "tsmiEditLED"
        tsmiEditLED.Size = New Size(210, 22)
        tsmiEditLED.Text = "Edit LED"
        ' 
        ' tsmiGenerate
        ' 
        tsmiGenerate.DropDownItems.AddRange(New ToolStripItem() {tsmiLinear, tsmiMatrix, tsmiLShape, tsmiUShape, tsmiRectangle})
        tsmiGenerate.Image = My.Resources.Resources.dots_horizontal_circle_outline_custom
        tsmiGenerate.Name = "tsmiGenerate"
        tsmiGenerate.Size = New Size(210, 22)
        tsmiGenerate.Text = "Generate.."
        ' 
        ' tsmiLinear
        ' 
        tsmiLinear.ForeColor = Color.White
        tsmiLinear.Image = My.Resources.Resources.dots_horizontal_custom
        tsmiLinear.Name = "tsmiLinear"
        tsmiLinear.Size = New Size(126, 22)
        tsmiLinear.Text = "Linear"
        ' 
        ' tsmiMatrix
        ' 
        tsmiMatrix.ForeColor = Color.White
        tsmiMatrix.Image = My.Resources.Resources.dots_grid_custom
        tsmiMatrix.Name = "tsmiMatrix"
        tsmiMatrix.Size = New Size(126, 22)
        tsmiMatrix.Text = "Matrix"
        ' 
        ' tsmiLShape
        ' 
        tsmiLShape.ForeColor = Color.White
        tsmiLShape.Image = My.Resources.Resources.dots_lshape_custom
        tsmiLShape.Name = "tsmiLShape"
        tsmiLShape.Size = New Size(126, 22)
        tsmiLShape.Text = "L Shape"
        ' 
        ' tsmiUShape
        ' 
        tsmiUShape.ForeColor = Color.White
        tsmiUShape.Image = My.Resources.Resources.dots_ushape_custom
        tsmiUShape.Name = "tsmiUShape"
        tsmiUShape.Size = New Size(126, 22)
        tsmiUShape.Text = "U Shape"
        ' 
        ' tsmiRectangle
        ' 
        tsmiRectangle.ForeColor = Color.White
        tsmiRectangle.Image = My.Resources.Resources.dots_square_custom
        tsmiRectangle.Name = "tsmiRectangle"
        tsmiRectangle.Size = New Size(126, 22)
        tsmiRectangle.Text = "Rectangle"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(207, 6)
        ' 
        ' tsmiAutoResize
        ' 
        tsmiAutoResize.Image = My.Resources.Resources.resize_custom
        tsmiAutoResize.Name = "tsmiAutoResize"
        tsmiAutoResize.Size = New Size(210, 22)
        tsmiAutoResize.Text = "Auto Resize"
        ' 
        ' tsmiInsertBgImage
        ' 
        tsmiInsertBgImage.Image = My.Resources.Resources.image_plus_outline_custom
        tsmiInsertBgImage.Name = "tsmiInsertBgImage"
        tsmiInsertBgImage.Size = New Size(210, 22)
        tsmiInsertBgImage.Text = "Insert Guide Image"
        ' 
        ' tsmiRotateLeft
        ' 
        tsmiRotateLeft.Image = My.Resources.Resources.rotate_left_custom
        tsmiRotateLeft.Name = "tsmiRotateLeft"
        tsmiRotateLeft.Size = New Size(210, 22)
        tsmiRotateLeft.Text = "Rotate Counter Clockwise"
        ' 
        ' tsmiRotateRight
        ' 
        tsmiRotateRight.Image = My.Resources.Resources.rotate_right_custom
        tsmiRotateRight.Name = "tsmiRotateRight"
        tsmiRotateRight.Size = New Size(210, 22)
        tsmiRotateRight.Text = "Rotate Clockwise"
        ' 
        ' tsmiFlipHorizontal
        ' 
        tsmiFlipHorizontal.Image = My.Resources.Resources.flip_horizontal_custom1
        tsmiFlipHorizontal.Name = "tsmiFlipHorizontal"
        tsmiFlipHorizontal.Size = New Size(210, 22)
        tsmiFlipHorizontal.Text = "Flip Horizontal"
        ' 
        ' tsmiFlipVertical
        ' 
        tsmiFlipVertical.Image = My.Resources.Resources.flip_vertical_custom1
        tsmiFlipVertical.Name = "tsmiFlipVertical"
        tsmiFlipVertical.Size = New Size(210, 22)
        tsmiFlipVertical.Text = "Flip Vertical"
        ' 
        ' tsmiHideLEDs
        ' 
        tsmiHideLEDs.Image = My.Resources.Resources.eye_off_outline_custom
        tsmiHideLEDs.Name = "tsmiHideLEDs"
        tsmiHideLEDs.ShortcutKeys = Keys.Control Or Keys.H
        tsmiHideLEDs.Size = New Size(210, 22)
        tsmiHideLEDs.Text = "Show/Hide LEDs"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(207, 6)
        ' 
        ' tsmiCopy
        ' 
        tsmiCopy.Image = My.Resources.Resources.content_copy_custom
        tsmiCopy.Name = "tsmiCopy"
        tsmiCopy.ShortcutKeys = Keys.Control Or Keys.C
        tsmiCopy.Size = New Size(210, 22)
        tsmiCopy.Text = "Copy"
        ' 
        ' tsmiPaste
        ' 
        tsmiPaste.Image = My.Resources.Resources.content_paste_custom
        tsmiPaste.Name = "tsmiPaste"
        tsmiPaste.ShortcutKeys = Keys.Control Or Keys.Z
        tsmiPaste.Size = New Size(210, 22)
        tsmiPaste.Text = "Paste"
        ' 
        ' tPressHold
        ' 
        tPressHold.Enabled = True
        tPressHold.Interval = 60
        ' 
        ' ucComponent
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Margin = New Padding(100)
        MinimumSize = New Size(250, 250)
        Name = "ucComponent"
        Size = New Size(250, 250)
        NsContextMenu1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiRemoveLed As ToolStripMenuItem
    Friend WithEvents NsContextMenu1 As NSContextMenu
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiAutoResize As ToolStripMenuItem
    Friend WithEvents tsmiEditLED As ToolStripMenuItem
    Friend WithEvents tsmiGenerate As ToolStripMenuItem
    Friend WithEvents tsmiLinear As ToolStripMenuItem
    Friend WithEvents tsmiMatrix As ToolStripMenuItem
    Friend WithEvents tsmiLShape As ToolStripMenuItem
    Friend WithEvents tsmiRectangle As ToolStripMenuItem
    Friend WithEvents tsmiUShape As ToolStripMenuItem
    Friend WithEvents tPressHold As Timer
    Friend WithEvents tsmiInsertBgImage As ToolStripMenuItem
    Friend WithEvents tsmiRotateLeft As ToolStripMenuItem
    Friend WithEvents tsmiRotateRight As ToolStripMenuItem
    Friend WithEvents tsmiHideLEDs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsmiCopy As ToolStripMenuItem
    Friend WithEvents tsmiPaste As ToolStripMenuItem
    Friend WithEvents tsmiFlipHorizontal As ToolStripMenuItem
    Friend WithEvents tsmiFlipVertical As ToolStripMenuItem

End Class
