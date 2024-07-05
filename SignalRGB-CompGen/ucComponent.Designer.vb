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
        tsmiAddLed = New ToolStripMenuItem()
        tsmiAddLeds = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiRemoveLed = New ToolStripMenuItem()
        tsmiRemoveLastLEDs = New ToolStripMenuItem()
        NsContextMenu1 = New NSContextMenu()
        tsmiEditLED = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiAutoResize = New ToolStripMenuItem()
        NsContextMenu1.SuspendLayout()
        SuspendLayout()
        ' 
        ' tsmiAddLed
        ' 
        tsmiAddLed.Name = "tsmiAddLed"
        tsmiAddLed.Size = New Size(166, 22)
        tsmiAddLed.Text = "Add LED"
        ' 
        ' tsmiAddLeds
        ' 
        tsmiAddLeds.Name = "tsmiAddLeds"
        tsmiAddLeds.Size = New Size(166, 22)
        tsmiAddLeds.Text = "Add LEDs"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(163, 6)
        ' 
        ' tsmiRemoveLed
        ' 
        tsmiRemoveLed.Name = "tsmiRemoveLed"
        tsmiRemoveLed.Size = New Size(166, 22)
        tsmiRemoveLed.Text = "Remove last LED"
        ' 
        ' tsmiRemoveLastLEDs
        ' 
        tsmiRemoveLastLEDs.Name = "tsmiRemoveLastLEDs"
        tsmiRemoveLastLEDs.Size = New Size(166, 22)
        tsmiRemoveLastLEDs.Text = "Remove last LEDs"
        ' 
        ' NsContextMenu1
        ' 
        NsContextMenu1.ForeColor = Color.White
        NsContextMenu1.Items.AddRange(New ToolStripItem() {tsmiAddLed, tsmiEditLED, tsmiAddLeds, ToolStripSeparator1, tsmiRemoveLed, tsmiRemoveLastLEDs, ToolStripSeparator2, tsmiAutoResize})
        NsContextMenu1.Name = "NsContextMenu1"
        NsContextMenu1.Size = New Size(167, 148)
        ' 
        ' tsmiEditLED
        ' 
        tsmiEditLED.Name = "tsmiEditLED"
        tsmiEditLED.Size = New Size(166, 22)
        tsmiEditLED.Text = "Edit LED"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(163, 6)
        ' 
        ' tsmiAutoResize
        ' 
        tsmiAutoResize.Name = "tsmiAutoResize"
        tsmiAutoResize.Size = New Size(166, 22)
        tsmiAutoResize.Text = "Auto Resize"
        ' 
        ' ucComponent
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Margin = New Padding(100)
        MinimumSize = New Size(250, 250)
        Name = "ucComponent"
        Size = New Size(250, 250)
        NsContextMenu1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents tsmiAddLed As ToolStripMenuItem
    Friend WithEvents tsmiAddLeds As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiRemoveLed As ToolStripMenuItem
    Friend WithEvents tsmiRemoveLastLEDs As ToolStripMenuItem
    Friend WithEvents NsContextMenu1 As NSContextMenu
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiAutoResize As ToolStripMenuItem
    Friend WithEvents tsmiEditLED As ToolStripMenuItem

End Class
