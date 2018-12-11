Public Class frmBusbarExtras
    Public cust As String

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub tcExtras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcExtras.SelectedIndexChanged

    End Sub

    Private Sub txtField_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtField.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim msg As String = String.Empty
            InsertItem(sender.Text, msg)
            lblerr.Text = msg
            sender.Clear
        End If
    End Sub

    Sub InsertItem(ByVal FieldText As String, ByRef msg As String)
        Dim li As ListViewItem = Nothing
        Dim err_msg As String = String.Empty
        Dim lv As ListView = getListView(tcExtras.SelectedTab)
        Dim lb As Label = getLabel(tcExtras.SelectedTab)

        Select Case tcExtras.SelectedTab.Text
            Case "Cell Part Number"
                Dim dt As DataTable = ExecQuery("MYSQL", "SELECT B.ITMCODE, B.ITMDESC FROM cus01 A INNER JOIN itm01 B ON B.ITMDESC LIKE CONCAT('%',A.SHORTNAME,'%') WHERE A.CUSCODE = " & ENQ(cust) & " AND B.ITMCLASS = 'CELL' AND B.ITMCODE = " & ENQ(FieldText))
                If dt.Rows.Count > 0 Then
                    For Each itm As ListViewItem In lv.Items
                        If itm.Text.Trim = FieldText.Trim Then
                            err_msg = "Part Number [" & FieldText.Trim & "] is already selected."
                        End If
                    Next

                    If err_msg = String.Empty Then
                        Dim str(3) As String

                        str(0) = FieldText
                        str(1) = dt.Rows(0)(1)

                        Dim desc() As String = str(1).Split(",")

                        str(2) = desc(5).ToString.Trim

                        li = New ListViewItem(str)
                    End If
                Else
                    err_msg = "Part Number [" & FieldText.Trim & "] is not associated with Customer [" & cust.Trim & "]"
                End If
            Case "Cell Lot"
                For Each itm As ListViewItem In lv.Items
                    If itm.Text.Trim = FieldText.Trim Then
                        err_msg = "Lot Number [" & FieldText.Trim & "] is already selected."
                    End If
                Next

                If err_msg = String.Empty Then
                    Dim str(1) As String

                    str(0) = FieldText

                    li = New ListViewItem(str)
                End If
            Case Else

        End Select

        msg = err_msg
        If err_msg = String.Empty Then
            lv.Items.Add(li)
            lb.Text = FormatNumber(lv.Items.Count, 0)
        End If
    End Sub

    Function getListView(ByRef SelectedTab As TabPage) As ListView
        Dim lv As ListView = Nothing

        For Each c As Object In SelectedTab.Controls
            If TypeOf c Is ListView Then
                lv = c
                Exit For
            End If
        Next

        Return lv
    End Function

    Function getLabel(ByRef SelectedTab As TabPage) As Label
        Dim lb As Label = Nothing

        For Each c As Object In SelectedTab.Controls
            If TypeOf c Is Label And c.Name Like "*Count" Then
                lb = c
                Exit For
            End If
        Next

        Return lb
    End Function
End Class