Public Class frmRPRemarks
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtRemarks.Text.Trim <> "" Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Remarks is required when reprinting labels.", vbInformation)
        End If
    End Sub
End Class