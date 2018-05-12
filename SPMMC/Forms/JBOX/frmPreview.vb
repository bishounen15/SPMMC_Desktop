Public Class frmPreview
    Dim sec As Integer

    Private Sub frmPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sec = 0
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sec += 1
        If sec = 3 Then Me.Close()
    End Sub
End Class