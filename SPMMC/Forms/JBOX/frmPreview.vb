Public Class frmPreview
    Dim sec As Integer
    Public serial As String

    Private Sub frmPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'sec = 0
        'Timer1.Enabled = True
        txtSerial.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'sec += 1
        'If sec = 3 Then Me.Close()
    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If serial = sender.Text.Trim Then
                Me.Close()
                Me.DialogResult = DialogResult.OK
            Else
                lblMsg.Text = "INCORRECT SERIAL NUMBER. PLEASE TRY AGAIN. PRESS ESC KEY TO CANCEL"
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