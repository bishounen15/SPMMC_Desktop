Public Class frmLot
    Public sno As String
    Public sql As String
    Public prodtype As String

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        sql = String.Empty
        Dim dt As DataTable
        Dim s, m As String
        m = String.Empty

        For i As Integer = 1 To 5
            If Me.GroupBox1.Controls("lot" & i).Text.Trim = "" And Me.GroupBox1.Controls("lot" & i).Enabled Then
                sql = String.Empty
                Exit For
            End If

            If Me.GroupBox1.Controls("lot" & i).Enabled And Me.GroupBox1.Controls("caption" & i).Text.Trim <> "JBOX" Then
                s = "SELECT * FROM mat01 WHERE LOTNUMBER = " & ENQ(Me.GroupBox1.Controls("lot" & i).Text.Trim)
                dt = ExecQuery("MYSQL", s)

                If dt.Rows.Count = 0 Then
                    m = Me.GroupBox1.Controls("caption" & i).Text.Trim & " [" & Me.GroupBox1.Controls("lot" & i).Text.Trim & "] does not exists."
                    sql = String.Empty
                    Exit For
                End If
            End If

            If Me.GroupBox1.Controls("lot" & i).Enabled Then
                sql &= If(sql = String.Empty, "", ",") & "(" &
                   ENQ(sno) & "," &
                   ENQ(Me.GroupBox1.Controls("caption" & i).Tag) & ",'LOT'," &
                   ENQ(Me.GroupBox1.Controls("caption" & i).Text) & "," & ENQ(Me.GroupBox1.Controls("lot" & i).Text) & ",now(),now())"
            End If
        Next

        If sql = String.Empty Then
            MsgBox(If(m = String.Empty, "All lot numbers are required.", m), MsgBoxStyle.Information)
        Else
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub lot1_GotFocus(sender As Object, e As EventArgs) Handles lot1.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub lot2_GotFocus(sender As Object, e As EventArgs) Handles lot2.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub lot3_GotFocus(sender As Object, e As EventArgs) Handles lot3.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub lot4_GotFocus(sender As Object, e As EventArgs) Handles lot4.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub lot5_GotFocus(sender As Object, e As EventArgs) Handles lot5.GotFocus
        sender.SelectAll()
    End Sub

    Private Sub lot1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lot1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lot2.Focus()
        End If
    End Sub

    Private Sub lot2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lot2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lot3.Focus()
        End If
    End Sub

    Private Sub lot3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lot3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lot4.Focus()
        End If
    End Sub

    Private Sub lot4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lot4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lot5.Focus()
        End If
    End Sub

    Private Sub frmLot_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String = String.Empty
        Dim loc, fld As String
        Dim dt As DataTable

        For i As Integer = 1 To 5
            loc = Me.GroupBox1.Controls("caption" & i).Tag.ToString.Trim()
            fld = Me.GroupBox1.Controls("caption" & i).Text.Trim()
            sql = "SELECT * FROM set02 WHERE LOCNCODE = " & ENQ(loc) & " AND FIELDNAME = " & ENQ(fld) & " AND PRODTYPE = " & ENQ(prodtype)

            dt = ExecQuery("MYSQL", sql)

            Me.GroupBox1.Controls("lot" & i).Enabled = (dt.Rows.Count > 0)
        Next
    End Sub
End Class