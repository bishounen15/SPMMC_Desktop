Public Class frmPreviewMulti
    Dim sec As Integer
    Public serial As String
    Public CamNo As Integer

    Private Sub frmPreviewMulti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMsg.Text = "RESCAN THE SERIAL NUMBER [" & serial & "] TO CONFIRM IMAGE. PRESS ESC KEY TO CANCEL"
        txtSerial.Focus()
    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If serial = sender.Text.Trim Then
                Me.Close()
                Me.DialogResult = DialogResult.OK
            Else
                lblMsg.Text = "SERIAL NUMBER MUST BE [" & serial & "]. PLEASE TRY AGAIN. PRESS ESC KEY TO CANCEL"
                lblMsg.ForeColor = Color.Red
                sender.Clear
            End If
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.Close()
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub frmPreview_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub txtSerial_LostFocus(sender As Object, e As EventArgs) Handles txtSerial.LostFocus
        sender.Focus
    End Sub
End Class