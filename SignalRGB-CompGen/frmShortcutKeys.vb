Public Class frmShortcutKeys

    Private Sub Translate()
        Dim loc = Translation.Localization

        Text = loc.Controls
        NsTheme1.Text = Text
        btnContinue.Text = loc.Confirm

        lblDelete.Text = loc.CtrlDelete
        lblDeleteHold.Text = loc.CtrlDeleteHold
        lblLeftArrow.Text = loc.CtrlLeft
        lblRightArrow.Text = loc.CtrlRight
        lblUpArrow.Text = loc.CtrlUp
        lblDownArrow.Text = loc.CtrlDown
        lblCopy.Text = loc.CtrlCopy
        lblPaste.Text = loc.CtrlPaste
        lblHideShow.Text = loc.CtrlHide
        lblMouse1.Text = loc.CtrlMouse1
        lblMouse2.Text = loc.CtrlMouse2
        lblMouse3.Text = loc.CtrlMouse3
        lblMouseScroll.Text = loc.CtrlMouseScroll
    End Sub

    Private Sub frmShortcutKeys_Load(sender As Object, e As EventArgs) Handles Me.Load
        Translate()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Me.Close()
    End Sub
End Class