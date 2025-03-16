<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDelete
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
        btnOK = New NSButton()
        lblObjects = New NSLabel()
        cmbHistory = New NSComboBox()
        SuspendLayout()
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(194, 62)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 2
        btnOK.Text = "Confirm"
        ' 
        ' lblObjects
        ' 
        lblObjects.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        lblObjects.Font = New Font("Segoe UI", 9F)
        lblObjects.Location = New Point(3, 3)
        lblObjects.Name = "lblObjects"
        lblObjects.Size = New Size(99, 24)
        lblObjects.TabIndex = 22
        lblObjects.Text = "Direction"
        lblObjects.Value1 = "Objects"
        lblObjects.Value2 = ""
        ' 
        ' cmbHistory
        ' 
        cmbHistory.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        cmbHistory.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        cmbHistory.DrawMode = DrawMode.OwnerDrawFixed
        cmbHistory.DropDownStyle = ComboBoxStyle.DropDownList
        cmbHistory.ForeColor = Color.White
        cmbHistory.FormattingEnabled = True
        cmbHistory.Location = New Point(108, 3)
        cmbHistory.Name = "cmbHistory"
        cmbHistory.Size = New Size(161, 24)
        cmbHistory.TabIndex = 0
        ' 
        ' ucDelete
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        Controls.Add(lblObjects)
        Controls.Add(cmbHistory)
        Controls.Add(btnOK)
        ForeColor = Color.White
        Name = "ucDelete"
        Size = New Size(272, 88)
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnOK As NSButton
    Friend WithEvents lblObjects As NSLabel
    Friend WithEvents cmbHistory As NSComboBox

End Class
