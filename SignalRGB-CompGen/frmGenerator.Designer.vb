<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenerator))
        rbHorizontal = New RadioButton()
        gbOne = New GroupBox()
        Label1 = New Label()
        numLedCount = New NumericUpDown()
        rbVertical = New RadioButton()
        rbCircle = New RadioButton()
        rbDoubleCircle = New RadioButton()
        rbLShaped = New RadioButton()
        rbUShaped = New RadioButton()
        rbRectangle = New RadioButton()
        rbMatrix = New RadioButton()
        Label2 = New Label()
        gbLShaped = New GroupBox()
        gbUShaped = New GroupBox()
        NumericUpDown1 = New NumericUpDown()
        Label3 = New Label()
        NumericUpDown2 = New NumericUpDown()
        Label4 = New Label()
        NumericUpDown3 = New NumericUpDown()
        Label5 = New Label()
        GroupBox1 = New GroupBox()
        NumericUpDown4 = New NumericUpDown()
        Label6 = New Label()
        NumericUpDown5 = New NumericUpDown()
        Label7 = New Label()
        NumericUpDown6 = New NumericUpDown()
        Label8 = New Label()
        GroupBox2 = New GroupBox()
        NumericUpDown7 = New NumericUpDown()
        Label9 = New Label()
        Label10 = New Label()
        NumericUpDown9 = New NumericUpDown()
        Label11 = New Label()
        ComboBox1 = New ComboBox()
        CheckBox1 = New CheckBox()
        GroupBox3 = New GroupBox()
        NumericUpDown8 = New NumericUpDown()
        Label12 = New Label()
        gbOne.SuspendLayout()
        CType(numLedCount, ComponentModel.ISupportInitialize).BeginInit()
        gbLShaped.SuspendLayout()
        gbUShaped.SuspendLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).BeginInit()
        CType(NumericUpDown9, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox3.SuspendLayout()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' rbHorizontal
        ' 
        rbHorizontal.Appearance = Appearance.Button
        rbHorizontal.BackgroundImageLayout = ImageLayout.None
        rbHorizontal.Checked = True
        rbHorizontal.Image = My.Resources.Resources.led_strip_horizontal
        rbHorizontal.Location = New Point(85, 51)
        rbHorizontal.Name = "rbHorizontal"
        rbHorizontal.Size = New Size(120, 36)
        rbHorizontal.TabIndex = 0
        rbHorizontal.TabStop = True
        rbHorizontal.Text = "Horizontal"
        rbHorizontal.TextAlign = ContentAlignment.MiddleRight
        rbHorizontal.TextImageRelation = TextImageRelation.ImageBeforeText
        rbHorizontal.UseVisualStyleBackColor = True
        ' 
        ' gbOne
        ' 
        gbOne.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        gbOne.Controls.Add(Label2)
        gbOne.Controls.Add(rbMatrix)
        gbOne.Controls.Add(numLedCount)
        gbOne.Controls.Add(Label1)
        gbOne.Controls.Add(rbRectangle)
        gbOne.Controls.Add(rbHorizontal)
        gbOne.Controls.Add(rbUShaped)
        gbOne.Controls.Add(rbVertical)
        gbOne.Controls.Add(rbLShaped)
        gbOne.Controls.Add(rbCircle)
        gbOne.Controls.Add(rbDoubleCircle)
        gbOne.Location = New Point(12, 12)
        gbOne.Name = "gbOne"
        gbOne.Size = New Size(760, 137)
        gbOne.TabIndex = 2
        gbOne.TabStop = False
        gbOne.Text = "Choose LED count of your LED Strip"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(6, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(61, 15)
        Label1.TabIndex = 1
        Label1.Text = "LED count"
        ' 
        ' numLedCount
        ' 
        numLedCount.Location = New Point(85, 22)
        numLedCount.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        numLedCount.Name = "numLedCount"
        numLedCount.Size = New Size(157, 23)
        numLedCount.TabIndex = 2
        ' 
        ' rbVertical
        ' 
        rbVertical.Appearance = Appearance.Button
        rbVertical.BackgroundImageLayout = ImageLayout.None
        rbVertical.Image = My.Resources.Resources.led_strip_vertical
        rbVertical.Location = New Point(211, 51)
        rbVertical.Name = "rbVertical"
        rbVertical.Size = New Size(120, 36)
        rbVertical.TabIndex = 3
        rbVertical.Text = "Vertical"
        rbVertical.TextAlign = ContentAlignment.MiddleRight
        rbVertical.TextImageRelation = TextImageRelation.ImageBeforeText
        rbVertical.UseVisualStyleBackColor = True
        ' 
        ' rbCircle
        ' 
        rbCircle.Appearance = Appearance.Button
        rbCircle.BackgroundImageLayout = ImageLayout.None
        rbCircle.Image = My.Resources.Resources.circle_outline_custom
        rbCircle.Location = New Point(337, 51)
        rbCircle.Name = "rbCircle"
        rbCircle.Size = New Size(120, 36)
        rbCircle.TabIndex = 4
        rbCircle.Text = "Circle"
        rbCircle.TextAlign = ContentAlignment.MiddleRight
        rbCircle.TextImageRelation = TextImageRelation.ImageBeforeText
        rbCircle.UseVisualStyleBackColor = True
        ' 
        ' rbDoubleCircle
        ' 
        rbDoubleCircle.Appearance = Appearance.Button
        rbDoubleCircle.BackgroundImageLayout = ImageLayout.None
        rbDoubleCircle.Image = My.Resources.Resources.circle_double_custom
        rbDoubleCircle.Location = New Point(463, 51)
        rbDoubleCircle.Name = "rbDoubleCircle"
        rbDoubleCircle.Size = New Size(120, 36)
        rbDoubleCircle.TabIndex = 5
        rbDoubleCircle.Text = "Double Circle"
        rbDoubleCircle.TextAlign = ContentAlignment.MiddleRight
        rbDoubleCircle.TextImageRelation = TextImageRelation.ImageBeforeText
        rbDoubleCircle.UseVisualStyleBackColor = True
        ' 
        ' rbLShaped
        ' 
        rbLShaped.Appearance = Appearance.Button
        rbLShaped.BackgroundImageLayout = ImageLayout.None
        rbLShaped.Image = My.Resources.Resources.size_l_custom
        rbLShaped.Location = New Point(85, 93)
        rbLShaped.Name = "rbLShaped"
        rbLShaped.Size = New Size(120, 36)
        rbLShaped.TabIndex = 6
        rbLShaped.Text = "L-Shaped"
        rbLShaped.TextAlign = ContentAlignment.MiddleRight
        rbLShaped.TextImageRelation = TextImageRelation.ImageBeforeText
        rbLShaped.UseVisualStyleBackColor = True
        ' 
        ' rbUShaped
        ' 
        rbUShaped.Appearance = Appearance.Button
        rbUShaped.BackgroundImageLayout = ImageLayout.None
        rbUShaped.Image = My.Resources.Resources.alpha_u_custom
        rbUShaped.Location = New Point(211, 93)
        rbUShaped.Name = "rbUShaped"
        rbUShaped.Size = New Size(120, 36)
        rbUShaped.TabIndex = 7
        rbUShaped.Text = "U-Shaped"
        rbUShaped.TextAlign = ContentAlignment.MiddleRight
        rbUShaped.TextImageRelation = TextImageRelation.ImageBeforeText
        rbUShaped.UseVisualStyleBackColor = True
        ' 
        ' rbRectangle
        ' 
        rbRectangle.Appearance = Appearance.Button
        rbRectangle.BackgroundImageLayout = ImageLayout.None
        rbRectangle.Image = My.Resources.Resources.rectangle_outline_custom
        rbRectangle.Location = New Point(337, 93)
        rbRectangle.Name = "rbRectangle"
        rbRectangle.Size = New Size(120, 36)
        rbRectangle.TabIndex = 8
        rbRectangle.Text = "Rectangle"
        rbRectangle.TextAlign = ContentAlignment.MiddleRight
        rbRectangle.TextImageRelation = TextImageRelation.ImageBeforeText
        rbRectangle.UseVisualStyleBackColor = True
        ' 
        ' rbMatrix
        ' 
        rbMatrix.Appearance = Appearance.Button
        rbMatrix.BackgroundImageLayout = ImageLayout.None
        rbMatrix.Image = My.Resources.Resources.grid_custom
        rbMatrix.Location = New Point(463, 93)
        rbMatrix.Name = "rbMatrix"
        rbMatrix.Size = New Size(120, 36)
        rbMatrix.TabIndex = 9
        rbMatrix.Text = "Matrix"
        rbMatrix.TextAlign = ContentAlignment.MiddleRight
        rbMatrix.TextImageRelation = TextImageRelation.ImageBeforeText
        rbMatrix.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 62)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 15)
        Label2.TabIndex = 10
        Label2.Text = "Shape"
        ' 
        ' gbLShaped
        ' 
        gbLShaped.Controls.Add(NumericUpDown1)
        gbLShaped.Controls.Add(Label3)
        gbLShaped.Location = New Point(12, 155)
        gbLShaped.Name = "gbLShaped"
        gbLShaped.Size = New Size(377, 53)
        gbLShaped.TabIndex = 3
        gbLShaped.TabStop = False
        gbLShaped.Text = "L-Shaped"
        ' 
        ' gbUShaped
        ' 
        gbUShaped.Controls.Add(NumericUpDown3)
        gbUShaped.Controls.Add(Label5)
        gbUShaped.Controls.Add(NumericUpDown2)
        gbUShaped.Controls.Add(Label4)
        gbUShaped.Location = New Point(395, 155)
        gbUShaped.Name = "gbUShaped"
        gbUShaped.Size = New Size(377, 53)
        gbUShaped.TabIndex = 4
        gbUShaped.TabStop = False
        gbUShaped.Text = "U-Shaped"
        ' 
        ' NumericUpDown1
        ' 
        NumericUpDown1.Location = New Point(88, 22)
        NumericUpDown1.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.Size = New Size(95, 23)
        NumericUpDown1.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Image = My.Resources.Resources.arrow_right_bottom_custom
        Label3.ImageAlign = ContentAlignment.MiddleLeft
        Label3.Location = New Point(6, 24)
        Label3.Name = "Label3"
        Label3.Size = New Size(76, 15)
        Label3.TabIndex = 3
        Label3.Text = "     Bend after"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NumericUpDown2
        ' 
        NumericUpDown2.Location = New Point(88, 22)
        NumericUpDown2.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown2.Name = "NumericUpDown2"
        NumericUpDown2.Size = New Size(95, 23)
        NumericUpDown2.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Image = My.Resources.Resources.arrow_right_bottom_custom
        Label4.ImageAlign = ContentAlignment.MiddleLeft
        Label4.Location = New Point(6, 24)
        Label4.Name = "Label4"
        Label4.Size = New Size(76, 15)
        Label4.TabIndex = 5
        Label4.Text = "     Bend after"
        Label4.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NumericUpDown3
        ' 
        NumericUpDown3.Location = New Point(276, 22)
        NumericUpDown3.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown3.Name = "NumericUpDown3"
        NumericUpDown3.Size = New Size(95, 23)
        NumericUpDown3.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Image = My.Resources.Resources.arrow_up_right_custom
        Label5.ImageAlign = ContentAlignment.MiddleLeft
        Label5.Location = New Point(194, 24)
        Label5.Name = "Label5"
        Label5.Size = New Size(76, 15)
        Label5.TabIndex = 7
        Label5.Text = "     Bend after"
        Label5.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(NumericUpDown6)
        GroupBox1.Controls.Add(Label8)
        GroupBox1.Controls.Add(NumericUpDown4)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(NumericUpDown5)
        GroupBox1.Controls.Add(Label7)
        GroupBox1.Location = New Point(12, 214)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(377, 82)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        GroupBox1.Text = "Rectangle"
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Location = New Point(276, 22)
        NumericUpDown4.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(95, 23)
        NumericUpDown4.TabIndex = 12
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Image = My.Resources.Resources.arrow_up_right_custom
        Label6.ImageAlign = ContentAlignment.MiddleLeft
        Label6.Location = New Point(194, 24)
        Label6.Name = "Label6"
        Label6.Size = New Size(76, 15)
        Label6.TabIndex = 11
        Label6.Text = "     Bend after"
        Label6.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NumericUpDown5
        ' 
        NumericUpDown5.Location = New Point(88, 22)
        NumericUpDown5.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown5.Name = "NumericUpDown5"
        NumericUpDown5.Size = New Size(95, 23)
        NumericUpDown5.TabIndex = 10
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Image = My.Resources.Resources.arrow_right_bottom_custom
        Label7.ImageAlign = ContentAlignment.MiddleLeft
        Label7.Location = New Point(6, 24)
        Label7.Name = "Label7"
        Label7.Size = New Size(76, 15)
        Label7.TabIndex = 9
        Label7.Text = "     Bend after"
        Label7.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NumericUpDown6
        ' 
        NumericUpDown6.Location = New Point(88, 51)
        NumericUpDown6.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown6.Name = "NumericUpDown6"
        NumericUpDown6.Size = New Size(95, 23)
        NumericUpDown6.TabIndex = 14
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Image = My.Resources.Resources.arrow_left_top_custom
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(6, 53)
        Label8.Name = "Label8"
        Label8.Size = New Size(76, 15)
        Label8.TabIndex = 13
        Label8.Text = "     Bend after"
        Label8.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(CheckBox1)
        GroupBox2.Controls.Add(ComboBox1)
        GroupBox2.Controls.Add(NumericUpDown7)
        GroupBox2.Controls.Add(Label9)
        GroupBox2.Controls.Add(Label10)
        GroupBox2.Controls.Add(NumericUpDown9)
        GroupBox2.Controls.Add(Label11)
        GroupBox2.Location = New Point(395, 214)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(377, 82)
        GroupBox2.TabIndex = 6
        GroupBox2.TabStop = False
        GroupBox2.Text = "Matrix"
        ' 
        ' NumericUpDown7
        ' 
        NumericUpDown7.Location = New Point(88, 51)
        NumericUpDown7.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown7.Name = "NumericUpDown7"
        NumericUpDown7.Size = New Size(95, 23)
        NumericUpDown7.TabIndex = 14
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Image = My.Resources.Resources.land_rows_vertical_custom
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(6, 53)
        Label9.Name = "Label9"
        Label9.Size = New Size(70, 15)
        Label9.TabIndex = 13
        Label9.Text = "     Columns"
        Label9.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Image = My.Resources.Resources.sign_direction_custom
        Label10.ImageAlign = ContentAlignment.MiddleLeft
        Label10.Location = New Point(194, 24)
        Label10.Name = "Label10"
        Label10.Size = New Size(68, 15)
        Label10.TabIndex = 11
        Label10.Text = "     LED flow"
        Label10.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NumericUpDown9
        ' 
        NumericUpDown9.Location = New Point(88, 22)
        NumericUpDown9.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown9.Name = "NumericUpDown9"
        NumericUpDown9.Size = New Size(95, 23)
        NumericUpDown9.TabIndex = 10
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Image = My.Resources.Resources.land_rows_horizontal_custom
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(6, 24)
        Label11.Name = "Label11"
        Label11.Size = New Size(50, 15)
        Label11.TabIndex = 9
        Label11.Text = "     Rows"
        Label11.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' ComboBox1
        ' 
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(276, 22)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(95, 23)
        ComboBox1.TabIndex = 15
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(194, 52)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(82, 19)
        CheckBox1.TabIndex = 16
        CheckBox1.Text = "Serpentine"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(NumericUpDown8)
        GroupBox3.Controls.Add(Label12)
        GroupBox3.Location = New Point(12, 302)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(377, 53)
        GroupBox3.TabIndex = 7
        GroupBox3.TabStop = False
        GroupBox3.Text = "Circle"
        ' 
        ' NumericUpDown8
        ' 
        NumericUpDown8.Location = New Point(88, 22)
        NumericUpDown8.Maximum = New Decimal(New Integer() {2000, 0, 0, 0})
        NumericUpDown8.Name = "NumericUpDown8"
        NumericUpDown8.Size = New Size(95, 23)
        NumericUpDown8.TabIndex = 4
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.ImageAlign = ContentAlignment.MiddleLeft
        Label12.Location = New Point(6, 24)
        Label12.Name = "Label12"
        Label12.Size = New Size(65, 15)
        Label12.TabIndex = 3
        Label12.Text = "Inner circle"
        Label12.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' frmGenerator
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(784, 561)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Controls.Add(gbUShaped)
        Controls.Add(gbLShaped)
        Controls.Add(gbOne)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmGenerator"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Shape Generator"
        gbOne.ResumeLayout(False)
        gbOne.PerformLayout()
        CType(numLedCount, ComponentModel.ISupportInitialize).EndInit()
        gbLShaped.ResumeLayout(False)
        gbLShaped.PerformLayout()
        gbUShaped.ResumeLayout(False)
        gbUShaped.PerformLayout()
        CType(NumericUpDown1, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown2, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown6, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        CType(NumericUpDown7, ComponentModel.ISupportInitialize).EndInit()
        CType(NumericUpDown9, ComponentModel.ISupportInitialize).EndInit()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(NumericUpDown8, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents rbHorizontal As RadioButton
    Friend WithEvents gbOne As GroupBox
    Friend WithEvents numLedCount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents rbVertical As RadioButton
    Friend WithEvents rbCircle As RadioButton
    Friend WithEvents rbDoubleCircle As RadioButton
    Friend WithEvents rbUShaped As RadioButton
    Friend WithEvents rbLShaped As RadioButton
    Friend WithEvents rbRectangle As RadioButton
    Friend WithEvents rbMatrix As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents gbLShaped As GroupBox
    Friend WithEvents gbUShaped As GroupBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents NumericUpDown3 As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents NumericUpDown7 As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NumericUpDown9 As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents NumericUpDown8 As NumericUpDown
    Friend WithEvents Label12 As Label
End Class
