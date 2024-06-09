<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        lblLanguage = New Label()
        cmbLanguage = New ComboBox()
        cbShiftLedPosition = New CheckBox()
        btnSave = New Button()
        cbConsole = New CheckBox()
        SuspendLayout()
        ' 
        ' lblLanguage
        ' 
        lblLanguage.AutoSize = True
        lblLanguage.Location = New Point(12, 15)
        lblLanguage.Name = "lblLanguage"
        lblLanguage.Size = New Size(59, 15)
        lblLanguage.TabIndex = 1
        lblLanguage.Text = "Language"
        ' 
        ' cmbLanguage
        ' 
        cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList
        cmbLanguage.FormattingEnabled = True
        cmbLanguage.Location = New Point(125, 12)
        cmbLanguage.Name = "cmbLanguage"
        cmbLanguage.Size = New Size(247, 23)
        cmbLanguage.TabIndex = 1
        ' 
        ' cbShiftLedPosition
        ' 
        cbShiftLedPosition.AutoSize = True
        cbShiftLedPosition.Location = New Point(12, 41)
        cbShiftLedPosition.Name = "cbShiftLedPosition"
        cbShiftLedPosition.Size = New Size(188, 19)
        cbShiftLedPosition.TabIndex = 3
        cbShiftLedPosition.Text = "Shift Displaying LED index by 1"
        cbShiftLedPosition.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(297, 92)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(75, 23)
        btnSave.TabIndex = 5
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' cbConsole
        ' 
        cbConsole.AutoSize = True
        cbConsole.Location = New Point(12, 66)
        cbConsole.Name = "cbConsole"
        cbConsole.Size = New Size(69, 19)
        cbConsole.TabIndex = 4
        cbConsole.Text = "Console"
        cbConsole.UseVisualStyleBackColor = True
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 127)
        Controls.Add(cbConsole)
        Controls.Add(btnSave)
        Controls.Add(cbShiftLedPosition)
        Controls.Add(cmbLanguage)
        Controls.Add(lblLanguage)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblLanguage As Label
    Friend WithEvents cmbLanguage As ComboBox
    Friend WithEvents cbShiftLedPosition As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents cbConsole As CheckBox
End Class
