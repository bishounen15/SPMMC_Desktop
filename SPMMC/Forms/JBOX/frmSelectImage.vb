Public Class frmSelectImage
    Public Dir As String
    Dim img As Image

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
        If lstImage.SelectedItems.Count > 0 Then
            If MsgBox("All other images will be deleted from the source folder." & Environment.NewLine & Environment.NewLine &
                      "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Else
            MsgBox("You have not selected an image yet.")
        End If
    End Sub

    Private Sub lstImage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstImage.SelectedIndexChanged
        If Not img Is Nothing Then img.Dispose()
        img = Image.FromFile(Dir & "\" & lstImage.SelectedItem)
        picPreview.Image = img
    End Sub

    Private Sub frmSelectImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not img Is Nothing Then img.Dispose()
    End Sub
End Class