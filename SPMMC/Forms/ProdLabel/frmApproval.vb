Public Class frmApproval
    Private Sub frmApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Reprinting of Label requires approval from a Super User account." & Environment.NewLine & Environment.NewLine &
                      "Please enter the super user's login credentials below to authorize the reprinting of labels."
        txtUserID.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim sql As String = "SELECT A.USERID, A.USERNAME, CASE WHEN B.APPROVER IS NULL THEN 'No' ELSE 'Yes' END AS APPROVER FROM sys01 A LEFT JOIN lba00 B ON A.USERID = B.APPROVER WHERE B.APPROVER IS NOT NULL AND A.USERID = " & ENQ(txtUserID.Text) & " AND A.PASSWORD = MD5(" & ENQ(txtPassword.Text) & ")"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Your user id / password did not match.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnApprove.PerformClick()
        End If
    End Sub
End Class