Public Class frmSelectTemplate
    Public customer As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cboTemplate.Text <> "" Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Please select a template before proceeding.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmSelectTemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBox(cboTemplate, "SELECT TMPCODE FROM lbt00 WHERE CUSTOMER = " & ENQ(customer) & " ORDER BY TMPCODE",, "MYSQL")
    End Sub
End Class