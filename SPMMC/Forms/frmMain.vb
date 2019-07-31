Public Class frmMain
    Dim UID, UserName As String

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ELImageReviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELImageReviewToolStripMenuItem.Click
        Dim f As New frmQAReview
        With f
            .UID = UID
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub GenerateLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateLabelsToolStripMenuItem.Click
        Dim f As New frmPrintLabels
        With f
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub CustomerOEMOBAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerOEMOBAToolStripMenuItem.Click
        MsgBox("This feature is unavailable as of the moment.", MsgBoxStyle.Information)
    End Sub

    Private Sub ReprintLabelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintLabelsToolStripMenuItem.Click
        Dim f As New frmReprint
        With f
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub JBOXTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JBOXTransactionToolStripMenuItem.Click
        Dim f As New frmJBOX
        With f
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub OnLineProductLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnLineProductLabelToolStripMenuItem.Click
        Dim f As New frmOnlineLabel
        With f
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ProductionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductionToolStripMenuItem.Click
        With My.Settings
            .active_server = sender.Text.ToString.Trim.Substring(0, 4)
            .Save()
            ToggleActiveServer()
        End With
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As New frmLogin
        Dim dres As DialogResult = f.ShowDialog

        If dres = DialogResult.Cancel Then
            Application.Exit()
        Else
            UID = ACTIVEUSER
            tslStatus.Text = "Welcome " & ACTIVEUSERNAME

            For Each c As Object In ApplicationsToolStripMenuItem.DropDownItems
                Dim myTag As String = String.Empty
                If Not c.Tag Is Nothing Then
                    myTag = c.Tag.ToString
                Else
                    myTag = ""
                End If

                Dim sql As String = String.Empty

                If TypeOf c Is ToolStripMenuItem And myTag <> "" Then
                    sql = "SELECT DISTINCT B.APPCODE FROM sys11 A INNER JOIN sys10 B ON A.APPID = B.APPID WHERE A.USERID = " & ENQ(UID) & " AND B.APPCODE = " & ENQ(myTag) & " AND DESAPP = 1"
                    Dim dt As DataTable = ExecQuery("MYSQL", sql)

                    c.Visible = (dt.Rows.Count > 0)
                End If

                SettingsToolStripMenuItem.Visible = (UID.ToUpper.Trim = "SYSADMIN")
                ToggleActiveServer()
            Next
        End If
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        With My.Settings
            .active_server = sender.Text.ToString.Trim.Substring(0, 4)
            .Save()
            ToggleActiveServer()
        End With
    End Sub

    Private Sub ToggleActiveServer()
        Me.Text = "Solar Philippines Module Manufacturing Corporation" & If(My.Settings.active_server = "Test", " - [TEST SERVER]", "")
        RefreshConnection()

        For Each mi As ToolStripMenuItem In ActiveServerToolStripMenuItem.DropDownItems
            If (mi.Text.Substring(0, 4) = My.Settings.active_server) Then
                mi.Font = New Font(mi.Font, FontStyle.Bold)
            Else
                mi.Font = New Font(mi.Font, FontStyle.Regular)
            End If
        Next
    End Sub
End Class
