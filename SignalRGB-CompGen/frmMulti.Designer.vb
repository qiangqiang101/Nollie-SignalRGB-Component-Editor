<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMulti
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMulti))
        numAmount = New NumericUpDown()
        Label1 = New Label()
        btnOK = New Button()
        cmbDirection = New ComboBox()
        Label2 = New Label()
        CType(numAmount, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' numAmount
        ' 
        numAmount.Location = New Point(128, 12)
        numAmount.Name = "numAmount"
        numAmount.Size = New Size(144, 23)
        numAmount.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 15)
        Label1.TabIndex = 1
        Label1.Text = "Number of LEDs"
        ' 
        ' btnOK
        ' 
        btnOK.Location = New Point(197, 70)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 2
        btnOK.Text = "Confirm"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' cmbDirection
        ' 
        cmbDirection.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDirection.FormattingEnabled = True
        cmbDirection.Location = New Point(128, 41)
        cmbDirection.Name = "cmbDirection"
        cmbDirection.Size = New Size(144, 23)
        cmbDirection.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 44)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 4
        Label2.Text = "Direction"
        ' 
        ' frmMulti
        ' 
        AcceptButton = btnOK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 105)
        Controls.Add(Label2)
        Controls.Add(cmbDirection)
        Controls.Add(btnOK)
        Controls.Add(Label1)
        Controls.Add(numAmount)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmMulti"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        CType(numAmount, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents numAmount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents cmbDirection As ComboBox
    Friend WithEvents Label2 As Label
End Class
