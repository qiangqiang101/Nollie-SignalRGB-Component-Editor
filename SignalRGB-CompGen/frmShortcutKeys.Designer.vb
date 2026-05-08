<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShortcutKeys
    Inherits FormEx

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShortcutKeys))
        NsTheme1 = New NSTheme()
        lblHideShow = New NSImgLabel2()
        lblPaste = New NSImgLabel2()
        lblCopy = New NSImgLabel2()
        lblDownArrow = New NSImgLabel()
        lblUpArrow = New NSImgLabel()
        lblRightArrow = New NSImgLabel()
        lblLeftArrow = New NSImgLabel()
        lblDeleteHold = New NSImgLabel()
        lblDelete = New NSImgLabel()
        lblMouseScroll = New NSImgLabel()
        lblMouse3 = New NSImgLabel()
        lblMouse2 = New NSImgLabel()
        lblMouse1 = New NSImgLabel()
        btnContinue = New NSButton()
        btnClose = New NSControlButton()
        NsTheme1.SuspendLayout()
        SuspendLayout()
        ' 
        ' NsTheme1
        ' 
        NsTheme1.AccentOffset = 42
        NsTheme1.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        NsTheme1.BorderStyle = FormBorderStyle.FixedSingle
        NsTheme1.Controls.Add(lblHideShow)
        NsTheme1.Controls.Add(lblPaste)
        NsTheme1.Controls.Add(lblCopy)
        NsTheme1.Controls.Add(lblDownArrow)
        NsTheme1.Controls.Add(lblUpArrow)
        NsTheme1.Controls.Add(lblRightArrow)
        NsTheme1.Controls.Add(lblLeftArrow)
        NsTheme1.Controls.Add(lblDeleteHold)
        NsTheme1.Controls.Add(lblDelete)
        NsTheme1.Controls.Add(lblMouseScroll)
        NsTheme1.Controls.Add(lblMouse3)
        NsTheme1.Controls.Add(lblMouse2)
        NsTheme1.Controls.Add(lblMouse1)
        NsTheme1.Controls.Add(btnContinue)
        NsTheme1.Controls.Add(btnClose)
        NsTheme1.Customization = ""
        NsTheme1.Dock = DockStyle.Fill
        NsTheme1.Font = New Font("Segoe UI", 9F)
        NsTheme1.Image = Nothing
        NsTheme1.Location = New Point(0, 0)
        NsTheme1.Movable = True
        NsTheme1.Name = "NsTheme1"
        NsTheme1.NoRounding = False
        NsTheme1.Padding = New Padding(3, 33, 3, 3)
        NsTheme1.Sizable = False
        NsTheme1.Size = New Size(730, 450)
        NsTheme1.SmartBounds = True
        NsTheme1.StartPosition = FormStartPosition.CenterScreen
        NsTheme1.TabIndex = 0
        NsTheme1.Text = "Shortcut Keys"
        NsTheme1.TransparencyKey = Color.Empty
        NsTheme1.Transparent = False
        ' 
        ' lblHideShow
        ' 
        lblHideShow.BackgroundImage = My.Resources.Resources.ctrl_white
        lblHideShow.ImageOnTop = False
        lblHideShow.Location = New Point(12, 364)
        lblHideShow.Name = "lblHideShow"
        lblHideShow.Padding = New Padding(0, 5, 0, 5)
        lblHideShow.SecondaryImage = My.Resources.Resources.h_white
        lblHideShow.Size = New Size(350, 35)
        lblHideShow.TabIndex = 17
        lblHideShow.Text = "Ctrl + H - Show/Hide Selected LEDs"
        lblHideShow.TextAlign = NSImgLabel2.Alignment.Left
        ' 
        ' lblPaste
        ' 
        lblPaste.BackgroundImage = My.Resources.Resources.ctrl_white
        lblPaste.ImageOnTop = False
        lblPaste.Location = New Point(12, 323)
        lblPaste.Name = "lblPaste"
        lblPaste.Padding = New Padding(0, 5, 0, 5)
        lblPaste.SecondaryImage = My.Resources.Resources.v_white
        lblPaste.Size = New Size(350, 35)
        lblPaste.TabIndex = 16
        lblPaste.Text = "Ctrl + V - Paste Selected LEDs"
        lblPaste.TextAlign = NSImgLabel2.Alignment.Left
        ' 
        ' lblCopy
        ' 
        lblCopy.BackgroundImage = My.Resources.Resources.ctrl_white
        lblCopy.ImageOnTop = False
        lblCopy.Location = New Point(12, 282)
        lblCopy.Name = "lblCopy"
        lblCopy.Padding = New Padding(0, 5, 0, 5)
        lblCopy.SecondaryImage = My.Resources.Resources.c_white
        lblCopy.Size = New Size(350, 35)
        lblCopy.TabIndex = 15
        lblCopy.Text = "Ctrl + C - Copy Selected LEDs"
        lblCopy.TextAlign = NSImgLabel2.Alignment.Left
        ' 
        ' lblDownArrow
        ' 
        lblDownArrow.BackgroundImage = My.Resources.Resources.arrow_down_white
        lblDownArrow.Font = New Font("Segoe UI", 10F)
        lblDownArrow.ImageOnTop = False
        lblDownArrow.Location = New Point(12, 241)
        lblDownArrow.Name = "lblDownArrow"
        lblDownArrow.Padding = New Padding(0, 5, 0, 5)
        lblDownArrow.Size = New Size(350, 35)
        lblDownArrow.TabIndex = 14
        lblDownArrow.Text = "Down Arrow - Move Selected/All LEDs Down"
        lblDownArrow.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblUpArrow
        ' 
        lblUpArrow.BackgroundImage = My.Resources.Resources.arrow_up_white
        lblUpArrow.Font = New Font("Segoe UI", 10F)
        lblUpArrow.ImageOnTop = False
        lblUpArrow.Location = New Point(12, 200)
        lblUpArrow.Name = "lblUpArrow"
        lblUpArrow.Padding = New Padding(0, 5, 0, 5)
        lblUpArrow.Size = New Size(350, 35)
        lblUpArrow.TabIndex = 13
        lblUpArrow.Text = "Up Arrow - Move Selected/All LEDs Up"
        lblUpArrow.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblRightArrow
        ' 
        lblRightArrow.BackgroundImage = My.Resources.Resources.arrow_right_white
        lblRightArrow.Font = New Font("Segoe UI", 10F)
        lblRightArrow.ImageOnTop = False
        lblRightArrow.Location = New Point(12, 159)
        lblRightArrow.Name = "lblRightArrow"
        lblRightArrow.Padding = New Padding(0, 5, 0, 5)
        lblRightArrow.Size = New Size(350, 35)
        lblRightArrow.TabIndex = 12
        lblRightArrow.Text = "Right Arrow - Move Selected/All LEDs Right"
        lblRightArrow.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblLeftArrow
        ' 
        lblLeftArrow.BackgroundImage = My.Resources.Resources.arrow_left_white
        lblLeftArrow.Font = New Font("Segoe UI", 10F)
        lblLeftArrow.ImageOnTop = False
        lblLeftArrow.Location = New Point(12, 118)
        lblLeftArrow.Name = "lblLeftArrow"
        lblLeftArrow.Padding = New Padding(0, 5, 0, 5)
        lblLeftArrow.Size = New Size(350, 35)
        lblLeftArrow.TabIndex = 11
        lblLeftArrow.Text = "Left Arrow - Move Selected/All LEDs Left"
        lblLeftArrow.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblDeleteHold
        ' 
        lblDeleteHold.BackgroundImage = My.Resources.Resources.delete_white
        lblDeleteHold.Font = New Font("Segoe UI", 10F)
        lblDeleteHold.ImageOnTop = False
        lblDeleteHold.Location = New Point(12, 77)
        lblDeleteHold.Name = "lblDeleteHold"
        lblDeleteHold.Padding = New Padding(0, 5, 0, 5)
        lblDeleteHold.Size = New Size(350, 35)
        lblDeleteHold.TabIndex = 10
        lblDeleteHold.Text = "Hold Delete - Remove all LEDs"
        lblDeleteHold.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblDelete
        ' 
        lblDelete.BackgroundImage = My.Resources.Resources.delete_white
        lblDelete.Font = New Font("Segoe UI", 10F)
        lblDelete.ImageOnTop = False
        lblDelete.Location = New Point(12, 36)
        lblDelete.Name = "lblDelete"
        lblDelete.Padding = New Padding(0, 5, 0, 5)
        lblDelete.Size = New Size(350, 35)
        lblDelete.TabIndex = 9
        lblDelete.Text = "Delete - Remove Last LED"
        lblDelete.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblMouseScroll
        ' 
        lblMouseScroll.BackgroundImage = My.Resources.Resources.ScrollDown_White
        lblMouseScroll.Font = New Font("Segoe UI", 10F)
        lblMouseScroll.ImageOnTop = False
        lblMouseScroll.Location = New Point(368, 159)
        lblMouseScroll.Name = "lblMouseScroll"
        lblMouseScroll.Size = New Size(350, 35)
        lblMouseScroll.TabIndex = 8
        lblMouseScroll.Text = "Mouse Scroll wheel - Zoom in and out"
        lblMouseScroll.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblMouse3
        ' 
        lblMouse3.BackgroundImage = My.Resources.Resources.MiddleClick_White
        lblMouse3.Font = New Font("Segoe UI", 10F)
        lblMouse3.ImageOnTop = False
        lblMouse3.Location = New Point(368, 118)
        lblMouse3.Name = "lblMouse3"
        lblMouse3.Size = New Size(350, 35)
        lblMouse3.TabIndex = 7
        lblMouse3.Text = "Middle Mouse Button - Move Component"
        lblMouse3.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblMouse2
        ' 
        lblMouse2.BackgroundImage = My.Resources.Resources.RightClick_White
        lblMouse2.Font = New Font("Segoe UI", 10F)
        lblMouse2.ImageOnTop = False
        lblMouse2.Location = New Point(368, 77)
        lblMouse2.Name = "lblMouse2"
        lblMouse2.Size = New Size(350, 35)
        lblMouse2.TabIndex = 6
        lblMouse2.Text = "Right Mouse Button - Open Context Menu"
        lblMouse2.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' lblMouse1
        ' 
        lblMouse1.BackgroundImage = My.Resources.Resources.LeftClick_White
        lblMouse1.Font = New Font("Segoe UI", 10F)
        lblMouse1.ImageOnTop = False
        lblMouse1.Location = New Point(368, 36)
        lblMouse1.Name = "lblMouse1"
        lblMouse1.Size = New Size(350, 35)
        lblMouse1.TabIndex = 5
        lblMouse1.Text = "Left Mouse Button - Place or Select LEDs"
        lblMouse1.TextAlign = NSImgLabel.Alignment.Left
        ' 
        ' btnContinue
        ' 
        btnContinue.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnContinue.Location = New Point(643, 415)
        btnContinue.Name = "btnContinue"
        btnContinue.Size = New Size(75, 23)
        btnContinue.TabIndex = 4
        btnContinue.Text = "Continue"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.ControlButton = NSControlButton.Button.Close
        btnClose.Location = New Point(707, 5)
        btnClose.Margin = New Padding(0)
        btnClose.MaximumSize = New Size(18, 20)
        btnClose.MinimumSize = New Size(18, 20)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(18, 20)
        btnClose.TabIndex = 3
        btnClose.Text = "NsControlButton1"
        ' 
        ' frmShortcutKeys
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(730, 450)
        ControlBox = False
        Controls.Add(NsTheme1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Location = New Point(0, 0)
        Name = "frmShortcutKeys"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Shortcut Keys"
        TopMost = True
        NsTheme1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents NsTheme1 As NSTheme
    Friend WithEvents btnClose As NSControlButton
    Friend WithEvents btnContinue As NSButton
    Friend WithEvents lblMouse1 As NSImgLabel
    Friend WithEvents lblMouseScroll As NSImgLabel
    Friend WithEvents lblMouse3 As NSImgLabel
    Friend WithEvents lblMouse2 As NSImgLabel
    Friend WithEvents lblLeftArrow As NSImgLabel
    Friend WithEvents lblDeleteHold As NSImgLabel
    Friend WithEvents lblDelete As NSImgLabel
    Friend WithEvents lblDownArrow As NSImgLabel
    Friend WithEvents lblUpArrow As NSImgLabel
    Friend WithEvents lblRightArrow As NSImgLabel
    Friend WithEvents lblCopy As NSImgLabel2
    Friend WithEvents lblHideShow As NSImgLabel2
    Friend WithEvents lblPaste As NSImgLabel2
End Class
