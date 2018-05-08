Public Class frmComments
    Public SerialNo, Locn As String

    Private Sub frmComments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT A.*, B.USERNAME FROM cmt01 A INNER JOIN sys01 B ON A.UIDCOMMENT = B.USERID WHERE A.SERIALNO = " & ENQ(SerialNo) & " AND A.STATION = " & ENQ(Locn) & " ORDER BY A.ROWID DESC"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Dim HFont As New Font("Calibri", 9, FontStyle.Italic)
            Dim CFont As New Font("Calibri", 9, FontStyle.Regular)

            rtRemarks.Clear()

            For Each dr As DataRow In dt.Rows
                Dim cmtDate As Date = dr("CMTDATE")
                Dim comment As String = dr("COMMENTS").ToString
                Dim userid As String = dr("USERNAME").ToString

                rtRemarks.SelectionFont = HFont
                rtRemarks.AppendText("Posted by " & userid & " on " & FormatDateTime(cmtDate, DateFormat.LongDate) & " at " & FormatDateTime(cmtDate, DateFormat.LongTime) & Environment.NewLine)

                rtRemarks.SelectionFont = CFont
                rtRemarks.AppendText(comment & Environment.NewLine & Environment.NewLine)
            Next
        End If
    End Sub
End Class