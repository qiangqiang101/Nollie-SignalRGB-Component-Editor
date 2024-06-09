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
        lblNumOfLeds = New Label()
        btnOK = New Button()
        cmbDirection = New ComboBox()
        lblDirection = New Label()
        CType(numAmount, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' numAmount
        ' 
        numAmount.Location = New Point(128, 12)
        numAmount.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        numAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numAmount.Name = "numAmount"
        numAmount.Size = New Size(144, 23)
        numAmount.TabIndex = 0
        numAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' lblNumOfLeds
        ' 
        lblNumOfLeds.AutoSize = True
        lblNumOfLeds.Location = New Point(12, 14)
        lblNumOfLeds.Name = "lblNumOfLeds"
        lblNumOfLeds.Size = New Size(93, 15)
        lblNumOfLeds.TabIndex = 1
        lblNumOfLeds.Text = "Number of LEDs"
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
        ' lblDirection
        ' 
        lblDirection.AutoSize = True
        lblDirection.Location = New Point(12, 44)
        lblDirection.Name = "lblDirection"
        lblDirection.Size = New Size(55, 15)
        lblDirection.TabIndex = 4
        lblDirection.Text = "Direction"
        ' 
        ' frmMulti
        ' 
        AcceptButton = btnOK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(284, 105)
        Controls.Add(lblDirection)
        Controls.Add(cmbDirection)
        Controls.Add(btnOK)
        Controls.Add(lblNumOfLeds)
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
    Friend WithEvents lblNumOfLeds As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents cmbDirection As ComboBox
    Friend WithEvents lblDirection As Label
End Class
