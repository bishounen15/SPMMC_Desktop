Public Class frmELPath
    Private Sub frmELPath_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            txtEL1Dump.Text = .el1_path
            txtEL2Dump.Text = .el2_path
            txtJBOXDump.Text = .jbox_path
            txtEL2MC.Text = .el2_mc
            txtDest.Text = .dest_path
            txtContainerNo.Text = .cont_no
        End With
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        btnApply.PerformClick()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        With My.Settings
            .el1_path = txtEL1Dump.Text
            .el2_path = txtEL2Dump.Text
            .jbox_path = txtJBOXDump.Text
            .el2_mc = txtEL2MC.Text
            .dest_path = txtDest.Text
            .cont_no = txtContainerNo.Text

            .Save()
        End With
    End Sub

    Private Sub btnEL1Dump_Click(sender As Object, e As EventArgs) Handles btnEL1Dump.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtEL1Dump.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnEL2Dump_Click(sender As Object, e As EventArgs) Handles btnEL2Dump.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtEL2Dump.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnJBOXDump_Click(sender As Object, e As EventArgs) Handles btnJBOXDump.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtJBOXDump.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub btnEL2MC_Click(sender As Object, e As EventArgs) Handles btnEL2MC.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtEL2MC.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDest.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            txtDest.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
End Class