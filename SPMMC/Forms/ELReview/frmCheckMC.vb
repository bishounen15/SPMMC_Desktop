Public Class frmCheckMC
    Public serialno As String

    Private Sub frmCheckMC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Label1.Text.Replace("<?serial>", serialno)
    End Sub

    Private Sub btnYES_Click(sender As Object, e As EventArgs) Handles btnYES.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNO_Click(sender As Object, e As EventArgs) Handles btnNO.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class