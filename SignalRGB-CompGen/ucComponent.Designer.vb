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
        ContextMenuStrip1 = New ContextMenuStrip(components)
        tsmiAddLed = New ToolStripMenuItem()
        tsmiAddLeds = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiRemoveLed = New ToolStripMenuItem()
        tsmiRemoveLastLEDs = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {tsmiAddLed, tsmiAddLeds, ToolStripSeparator1, tsmiRemoveLed, tsmiRemoveLastLEDs})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(167, 98)
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
        ' ucComponent
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Margin = New Padding(100)
        MinimumSize = New Size(250, 250)
        Name = "ucComponent"
        Size = New Size(250, 250)
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsmiAddLed As ToolStripMenuItem
    Friend WithEvents tsmiAddLeds As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiRemoveLed As ToolStripMenuItem
    Friend WithEvents tsmiRemoveLastLEDs As ToolStripMenuItem

End Class
