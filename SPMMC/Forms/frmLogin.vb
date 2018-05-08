Public Class frmLogin
    Public UserName As String

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUserID.Text.Trim = String.Empty Or txtPassword.Text.Trim = String.Empty Then
            MsgBox("User ID / Password should not be BLANK.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim sql As String = "SELECT MD5(" & ENQ(txtPassword.Text) & "), PASSWORD, USERNAME FROM sys01 WHERE USERID = " & ENQ(txtUserID.Text)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            If dr(0) = dr(1) Then
                ACTIVEUSERNAME = dr(2)
                ACTIVEUSER = txtUserID.Text
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MsgBox("Your password is incorrect.", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("User ID does not exists.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
        End If
    End Sub
End Class