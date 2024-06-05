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
        tstxtAddLedQty = New ToolStripTextBox()
        ToolStripSeparator2 = New ToolStripSeparator()
        tsmiAddLedsConfirm = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        tsmiRemoveLed = New ToolStripMenuItem()
        RemoveLastLEDsToolStripMenuItem = New ToolStripMenuItem()
        tstxtRemoveLedQty = New ToolStripTextBox()
        ToolStripSeparator3 = New ToolStripSeparator()
        tsmiRemoveLedConfirm = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {tsmiAddLed, tsmiAddLeds, ToolStripSeparator1, tsmiRemoveLed, RemoveLastLEDsToolStripMenuItem})
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
        tsmiAddLeds.DropDownItems.AddRange(New ToolStripItem() {tstxtAddLedQty, ToolStripSeparator2, tsmiAddLedsConfirm})
        tsmiAddLeds.Name = "tsmiAddLeds"
        tsmiAddLeds.Size = New Size(166, 22)
        tsmiAddLeds.Text = "Add LEDs"
        ' 
        ' tstxtAddLedQty
        ' 
        tstxtAddLedQty.MaxLength = 2
        tstxtAddLedQty.Name = "tstxtAddLedQty"
        tstxtAddLedQty.Size = New Size(100, 23)
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(157, 6)
        ' 
        ' tsmiAddLedsConfirm
        ' 
        tsmiAddLedsConfirm.Name = "tsmiAddLedsConfirm"
        tsmiAddLedsConfirm.Size = New Size(160, 22)
        tsmiAddLedsConfirm.Text = "Confirm"
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
        ' RemoveLastLEDsToolStripMenuItem
        ' 
        RemoveLastLEDsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {tstxtRemoveLedQty, ToolStripSeparator3, tsmiRemoveLedConfirm})
        RemoveLastLEDsToolStripMenuItem.Name = "RemoveLastLEDsToolStripMenuItem"
        RemoveLastLEDsToolStripMenuItem.Size = New Size(166, 22)
        RemoveLastLEDsToolStripMenuItem.Text = "Remove last LEDs"
        ' 
        ' tstxtRemoveLedQty
        ' 
        tstxtRemoveLedQty.MaxLength = 2
        tstxtRemoveLedQty.Name = "tstxtRemoveLedQty"
        tstxtRemoveLedQty.Size = New Size(100, 23)
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(157, 6)
        ' 
        ' tsmiRemoveLedConfirm
        ' 
        tsmiRemoveLedConfirm.Name = "tsmiRemoveLedConfirm"
        tsmiRemoveLedConfirm.Size = New Size(160, 22)
        tsmiRemoveLedConfirm.Text = "Confirm"
        ' 
        ' ucComponent
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Margin = New Padding(100)
        Name = "ucComponent"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsmiAddLed As ToolStripMenuItem
    Friend WithEvents tsmiAddLeds As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsmiRemoveLed As ToolStripMenuItem
    Friend WithEvents tstxtAddLedQty As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsmiAddLedsConfirm As ToolStripMenuItem
    Friend WithEvents RemoveLastLEDsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tstxtRemoveLedQty As ToolStripTextBox
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsmiRemoveLedConfirm As ToolStripMenuItem

End Class
