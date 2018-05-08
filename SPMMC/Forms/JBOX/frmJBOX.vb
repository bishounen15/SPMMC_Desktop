Imports Emgu.CV
Imports Emgu.CV.UI
Imports Emgu.CV.Structure

Public Class frmJBOX
    Dim takepic As ICapture

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim frame As New Mat
        frame = takepic.QueryFrame()
        Dim img As New Bitmap("", frame.Rows, frame.Cols)
        PictureBox1.Image = img
    End Sub
End Class