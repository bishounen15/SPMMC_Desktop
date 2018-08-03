Public Class frmReprint
    Private Sub frmReprint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            tscboPrinters.Items.Add(printer)
        Next printer

        tscboPrinters.Text = frmPrintLabels.DefaultPrinterName
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If lvSerials.Items.Count > 0 Then
            Dim pfx, lbl As String

            Select Case cboType.SelectedIndex
                Case 0
                    pfx = "BUS"
                    lbl = "Busbar"
                Case 1
                    pfx = "FRM"
                    lbl = "Frame"
                Case 2
                    pfx = "PRD"
                    lbl = "Product"
                Case Else
                    pfx = "-"
                    lbl = "-"
            End Select

            Dim f As New frmRPRemarks
            Dim remarks As String = String.Empty

            With f
                If f.ShowDialog = DialogResult.OK Then
                    remarks = f.txtRemarks.Text
                Else
                    Exit Sub
                End If
            End With

            Dim sql As String = "SELECT LBLCNO FROM rlb01 WHERE LBLTYPE = " & cboType.SelectedIndex + 1 & " ORDER BY LBLCNO DESC LIMIT 1"
            Dim dt As DataTable = ExecQuery("MYSQL", sql)
            Dim LBLCNO As String = String.Empty

            If dt.Rows.Count > 0 Then
                LBLCNO = dt.Rows(0)(0).ToString
            Else
                LBLCNO = pfx & "-00000"
            End If

            Dim myCNO As Integer = Val(Mid(LBLCNO, 5, 5)) + 1
            Dim CNO As String = pfx & "-" & Space(5 - CStr(myCNO).Length).Replace(" ", "0") & myCNO

            sql = "INSERT INTO rlb01 (LBLCNO,TRXDATE,PRODDATE,UIDTRANS,LBLTYPE,REMARKS) VALUES (" & ENQ(CNO) & ",now(),curdate()," & ENQ(ACTIVEUSER) & "," & cboType.SelectedIndex + 1 & "," & ENQ(remarks) & ")"
            Dim msg As String = ExecuteNonQuery("MYSQL", sql)

            If msg = "Success" Then
                For Each li As ListViewItem In lvSerials.Items
                    sql = "INSERT INTO rlb02 (LBLCNO,SERIALNO,LBLTYPE) VALUES (" & ENQ(CNO) & "," & ENQ(li.Text) & "," & cboType.SelectedIndex + 1 & ")"
                    msg = ExecuteNonQuery("MYSQL", sql)

                    If msg <> "Success" Then
                        MsgBox(msg, MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                'PreviewLabel(cboCust.Text.ToUpper, lbl, CNO)
                PrintLabels(cboCust.Text.ToUpper, lbl, CNO)

            End If
        Else
            MsgBox("Serial List is empty.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub PreviewLabel(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String)
        Dim btApp As New BarTender.Application
        Dim btFormat As BarTender.Format

        btApp.VisibleWindows = BarTender.BtVisibleWindows.btInteractiveDialogs
        btFormat = New BarTender.Format
        btFormat = btApp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\Re" & LabelType & ".btw", False, "")
        btFormat.PrintSetup.Printer = tscboPrinters.Text
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        Dim bd As DialogResult = btFormat.PrintPreview.ShowDialog()

        If bd = 2 Then
            CancelPrint(ControlNo)
        End If

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub PrintLabels(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String)
        Dim btapp As BarTender.Application
        Dim btFormat As BarTender.Format

        btapp = New BarTender.Application
        btFormat = btapp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\Re" & LabelType & ".btw", False, "")
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        btFormat.PrintSetup.Printer = tscboPrinters.Text

        btFormat.PrintOut()
        btapp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub CancelPrint(ByVal ControlNo As String)
        Dim sql As String = "DELETE FROM rlb02 WHERE LBLCNO = " & ENQ(ControlNo)
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg = "Success" Then
            sql = "DELETE FROM rlb01 WHERE LBLCNO = " & ENQ(ControlNo)
            msg = ExecuteNonQuery("MYSQL", sql)

            If msg <> "Success" Then
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
        Else
            MsgBox(msg, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cboType.Text = "" Or cboCust.Text = "" Then
            MsgBox("Label Type / Customer is a required field.", MsgBoxStyle.Information)
        Else
            If txtSerial.Text.Trim <> "" Then
                Dim sql As String = "SELECT SERIALNO, CONCAT(CELLCOUNT,'C-',CASE CELLCOLOR WHEN 'P' THEN 'POLY' WHEN 'E' THEN 'MONO PERC' ELSE 'MONO' END) AS MODFORMAT FROM lbl02 WHERE LBLTYPE = " & (cboType.SelectedIndex + 1) & " AND CUSTOMER = " & ENQ(cboCust.Text.ToUpper.Trim) & " AND SERIALNO = " & ENQ(txtSerial.Text)
                Dim dt As DataTable = ExecQuery("MYSQL", sql)

                If dt.Rows.Count > 0 Then
                    Dim itemfound As ListViewItem = lvSerials.FindItemWithText(txtSerial.Text)

                    If (itemfound Is Nothing) Then
                        Dim str(2) As String

                        str(0) = dt.Rows(0)(0).ToString
                        str(1) = dt.Rows(0)(1).ToString

                        Dim li As New ListViewItem(str)
                        lvSerials.Items.Add(li)

                        lblCount.Text = If(lvSerials.Items.Count > 0, FormatNumber(lvSerials.Items.Count, 0), "-")
                    Else
                        MsgBox("The serial number " & txtSerial.Text & " is already in the serial list.", MsgBoxStyle.Information)
                    End If

                    txtSerial.Clear()
                Else
                    MsgBox("The serial number " & txtSerial.Text & " does not exist for the selected paramaters.", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        lvSerials.Items.Clear()
        lblCount.Text = If(lvSerials.Items.Count > 0, FormatNumber(lvSerials.Items.Count, 0), "-")
        If sender.SelectedIndex = 1 Then
            LoadTrans()
        Else
            txtSerial.Clear()
        End If
    End Sub

    Private Sub LoadTrans()
        Dim sql As String = "SELECT DISTINCT LBLCNO FROM lbl02 WHERE LBLTYPE = " & (cboType.SelectedIndex + 1) & " AND CUSTOMER = " & ENQ(cboCust.Text.ToUpper.Trim) & " ORDER BY LBLCNO DESC"
        FillComboBox(cboTrans, sql,, "MYSQL")
        cboTrans.MaxDropDownItems = 10
    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub cboTrans_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrans.SelectedIndexChanged
        Dim sql As String = "SELECT SERIALNO, CONCAT(CELLCOUNT,'C-',CASE CELLCOLOR WHEN 'P' THEN 'POLY' WHEN 'E' THEN 'MONO PERC' ELSE 'MONO' END) AS MODFORMAT FROM lbl02 WHERE LBLCNO LIKE '" & cboTrans.Text.Trim & "%' ORDER BY ROWID"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        lvSerials.Items.Clear()

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim str(2) As String

                str(0) = dr(0).ToString
                str(1) = dr(1).ToString

                Dim li As New ListViewItem(str)
                lvSerials.Items.Add(li)
            Next

            lblCount.Text = If(lvSerials.Items.Count > 0, FormatNumber(lvSerials.Items.Count, 0), "-")
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            LoadTrans()
        End If
    End Sub

    Private Sub cboCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCust.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            LoadTrans()
        End If
    End Sub
End Class