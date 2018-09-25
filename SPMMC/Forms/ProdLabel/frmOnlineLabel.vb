Public Class frmOnlineLabel
    Private Declare Function WriteProfileString Lib "kernel32" Alias "WriteProfileStringA" _
        (ByVal lpszSection As String, ByVal lpszKeyName As String,
        ByVal lpszString As String) As Long
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
         (ByVal hwnd As Long, ByVal wMsg As Long,
         ByVal wParam As Long, ByVal lparam As String) As Long
    Private Const HWND_BROADCAST As Long = &HFFFF&
    Private Const WM_WININICHANGE As Long = &H1A

    Dim defprint As String = String.Empty

    Dim init As Boolean = True
    Dim template As String = String.Empty
    Dim remember As Boolean = False

    Public Shared Function DefaultPrinterName() As String
        Dim oPS As New System.Drawing.Printing.PrinterSettings

        Try
            DefaultPrinterName = oPS.PrinterName
        Catch ex As System.Exception
            DefaultPrinterName = ""
        Finally
            oPS = Nothing
        End Try
    End Function

    Public Shared Sub SetDefaultPrinter(ByVal PrinterName As String,
        ByVal DriverName As String, ByVal PrinterPort As String)
        Dim DeviceLine As String

        'rebuild a valid device line string
        DeviceLine = PrinterName & "," & DriverName & "," & PrinterPort

        'Store the new printer information in the
        '[WINDOWS] section of the WIN.INI file for
        'the DEVICE= item
        Call WriteProfileString("windows", "Device", DeviceLine)

        'Cause all applications to reload the INI file
        Call SendMessage(HWND_BROADCAST, WM_WININICHANGE, 0, "windows")

    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If GetInfo(sender.Text) Then
                ToolStripButton1.PerformClick()
            End If
            sender.Clear()
        End If
    End Sub

    Function GetModelName(ByVal TemplateCode As String, ByVal Customer As String) As String
        Dim dt As DataTable = ExecQuery("MYSQL", "SELECT MODELNAME FROM lbt00 WHERE CUSTOMER = " & ENQ(Customer) & " AND TMPCODE = " & ENQ(TemplateCode))
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0).ToString.Trim
        Else
            Return String.Empty
        End If
    End Function

    Function GetInfo(ByVal SerialNo As String) As Boolean
        Dim sql As String = "SELECT A.SERIALNO, A.CELLCOUNT, A.CELLCOLOR, A.CUSTOMER, B.CUSDESC, " &
                            "REPLACE(REPLACE(REPLACE(B.PRODCODE,'[C]',A.CELLCOUNT),'[R]',CASE WHEN A.CELLCOLOR = 'E' AND A.CUSTOMER = 'GEN1' THEN 'M' ELSE A.CELLCOLOR END),'[P]',C.Bin) AS PRODCODE, " &
                            "C.Bin, D.VOC, D.VMPP, D.ISC, D.IMPP, D.DIMENSION " &
                            "FROM lbl02 A INNER JOIN cus01 B ON A.CUSTOMER = B.CUSCODE " &
                            "INNER JOIN ftd_upd C ON A.SERIALNO = C.ModuleID " &
                            "INNER JOIN fdd01 D ON A.CELLCOUNT = D.CCOUNT AND CASE A.CUSTOMER WHEN 'GEN1' THEN CASE A.CELLCOLOR WHEN 'E' THEN 'M' ELSE A.CELLCOLOR END ELSE A.CELLCOLOR END = D.CTYPE AND C.Bin = D.POWRATE " &
                            "WHERE A.SERIALNO = " & ENQ(SerialNo) & " AND A.LBLTYPE = 1"

        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Dim existing As Boolean = DataCheck("SELECT TMPCODE FROM lbt00 WHERE CUSTOMER = " & ENQ(dt.Rows(0)("CUSTOMER").ToString))
            Dim ModelName As String = String.Empty

            If existing And remember = False Then
                Dim f As New frmSelectTemplate

                With f
                    .customer = dt.Rows(0)("CUSTOMER").ToString
                    If .ShowDialog() = DialogResult.OK Then
                        remember = .chkRemember.Checked
                        lnkChoose.Visible = remember
                        template = .cboTemplate.Text
                        ModelName = GetModelName(template, dt.Rows(0)("CUSTOMER").ToString)

                        Dim cell_type As String = String.Empty
                        If dt.Rows(0)("CUSTOMER").ToString = "GEN1" And dt.Rows(0)("CELLCOLOR").ToString = "E" Then
                            cell_type = "M"
                        Else
                            cell_type = dt.Rows(0)("CELLCOLOR").ToString
                        End If

                        ModelName = ModelName.Replace("[R]", cell_type.Trim).Replace("[C]", dt.Rows(0)("CELLCOUNT")).Replace("[P]", dt.Rows(0)("Bin"))
                    Else
                        template = String.Empty
                        Return False
                        Exit Function
                    End If
                End With
            Else
                ModelName = dt.Rows(0)("PRODCODE").ToString
            End If

            txtSerialNo.Text = SerialNo
            txtCount.Text = dt.Rows(0)("CELLCOUNT").ToString
            txtType.Text = dt.Rows(0)("CELLCOLOR").ToString
            txtCustomer.Tag = dt.Rows(0)("CUSTOMER").ToString
            txtCustomer.Text = dt.Rows(0)("CUSDESC").ToString
            txtModel.Text = ModelName
            txtPower.Text = FormatNumber(dt.Rows(0)("Bin"), 0)
            txtVmpp.Text = FormatNumber(dt.Rows(0)("VMPP"), 1)
            txtImpp.Text = FormatNumber(dt.Rows(0)("IMPP"), 1)
            txtVoc.Text = FormatNumber(dt.Rows(0)("VOC"), 1)
            txtIsc.Text = FormatNumber(dt.Rows(0)("ISC"), 1)
            txtDimension.Text = dt.Rows(0)("DIMENSION").ToString
        Else
            ClearDetails()
        End If

        Return True
    End Function

    Sub ClearDetails()
        txtSerialNo.Clear()
        txtCount.Clear()
        txtType.Clear()
        txtCustomer.Clear()
        txtModel.Clear()
        txtPower.Clear()
        txtVmpp.Clear()
        txtImpp.Clear()
        txtVoc.Clear()
        txtIsc.Clear()
        txtDimension.Clear()
    End Sub

    Private Sub frmOnlineLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkPreview.Visible = (ACTIVEUSER.ToUpper.Trim = "SYSADMIN")

        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            tscboPrinters.Items.Add(printer)
        Next printer

        tscboPrinters.Text = DefaultPrinterName()
    End Sub

    Function SerialPrinted(ByVal SerialNo As String) As Boolean
        Dim sql As String = "SELECT SERIALNO FROM lbl02 WHERE LBLTYPE = 3 AND SERIALNO = " & ENQ(SerialNo)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        Return (dt.Rows.Count > 0)
    End Function

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If txtSerialNo.Text = "" Then
            MsgBox("You have not yet scanned a serial.", vbInformation)
            Exit Sub
        End If

        If Not SerialPrinted(txtSerialNo.Text) Then
            Dim pfx, lbl As String
            pfx = "PRD"
            lbl = "Product"

            Dim label_type As Integer = 3
            Dim prod_line As Integer = 1

            Dim sql As String = "SELECT LBLCNO FROM lbl01 WHERE LBLTYPE = " & label_type & " ORDER BY LBLCNO DESC LIMIT 1"
            Dim dt As DataTable = ExecQuery("MYSQL", sql)
            Dim LBLCNO As String = String.Empty

            If dt.Rows.Count > 0 Then
                LBLCNO = dt.Rows(0)(0).ToString
            Else
                LBLCNO = pfx & "-00000"
            End If

            Dim myCNO As Integer = Val(Mid(LBLCNO, 5, 5)) + 1
            Dim CNO As String = pfx & "-" & Space(5 - CStr(myCNO).Length).Replace(" ", "0") & myCNO

            sql = "INSERT INTO lbl01 (LBLCNO,TRXDATE,PRODDATE,UIDTRANS,LBLTYPE) VALUES (" & ENQ(CNO) & ",now(),curdate()," & ENQ(ACTIVEUSER) & "," & label_type & ")"
            Dim msg As String = ExecuteNonQuery("MYSQL", sql)

            If msg = "Success" Then
                Dim currentSerial As String = String.Empty

                currentSerial = txtSerialNo.Text
                sql = "INSERT INTO lbl02 (LBLCNO,SERIALNO,LBLTYPE,CELLCOUNT,CELLCOLOR,CUSTOMER,PRODLINE,ORDERNO,COLOR,TEMPLATE) VALUES (" & ENQ(CNO) & "," & ENQ(currentSerial) & "," & label_type & "," & ENQ(txtCount.Text) & "," & ENQ(txtType.Text) & "," & ENQ(txtCustomer.Tag.ToString) & "," & ENQ(prod_line) & ",'',''," & ENQ(template) & ")"
                msg = ExecuteNonQuery("MYSQL", sql)

                If msg <> "Success" Then
                    MsgBox(msg, MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If chkPreview.Checked Then
                    PreviewLabel(txtCustomer.Tag.ToString, lbl, CNO)
                Else
                    PrintLabels(txtCustomer.Tag.ToString, lbl, CNO)
                End If
            End If
        Else
            ReprintLabel()
        End If
    End Sub

    Private Sub PreviewLabel(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String, Optional Reprint As Boolean = False)
        Dim btApp As New BarTender.Application
        Dim btFormat As BarTender.Format

        btApp.VisibleWindows = BarTender.BtVisibleWindows.btInteractiveDialogs
        btFormat = New BarTender.Format
        btFormat = btApp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & If(Reprint, "Re", "") & LabelType & If(template = String.Empty, "", "-" & template.Trim) & ".btw", False, "")
        btFormat.PrintSetup.Printer = tscboPrinters.Text
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        Dim bd As DialogResult = btFormat.PrintPreview.ShowDialog()

        If bd = 2 Then
            CancelPrint(ControlNo, Reprint)
        End If

        btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub PrintLabels(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String, Optional Reprint As Boolean = False)
        Dim btapp As BarTender.Application
        Dim btFormat As BarTender.Format

        btapp = New BarTender.Application
        btFormat = btapp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & If(Reprint, "Re", "") & LabelType & If(template = String.Empty, "", "-" & template.Trim) & ".btw", False, "")
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        btFormat.PrintSetup.Printer = tscboPrinters.Text

        btFormat.PrintOut()
        btapp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub CancelPrint(ByVal ControlNo As String, ByVal Reprint As Boolean)
        Dim sql As String = "DELETE FROM " & If(Reprint, "rlb", "lbl") & "02 WHERE LBLCNO = " & ENQ(ControlNo)
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg = "Success" Then
            sql = "DELETE FROM " & If(Reprint, "rlb", "lbl") & "01 WHERE LBLCNO = " & ENQ(ControlNo)
            msg = ExecuteNonQuery("MYSQL", sql)

            If msg <> "Success" Then
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
        Else
            MsgBox(msg, MsgBoxStyle.Critical)
        End If
    End Sub

    Sub ReprintLabel()
        Dim pfx, lbl As String
        pfx = "PRD"
        lbl = "Product"

        Dim label_type As Integer = 3
        Dim prod_line As Integer = 1

        Dim f As New frmRPRemarks
        Dim remarks As String = String.Empty

        With f
            If f.ShowDialog = DialogResult.OK Then
                remarks = f.txtRemarks.Text
            Else
                ClearDetails()
                Exit Sub
            End If
        End With

        Dim sql As String = "SELECT LBLCNO FROM rlb01 WHERE LBLTYPE = " & label_type & " ORDER BY LBLCNO DESC LIMIT 1"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)
        Dim LBLCNO As String = String.Empty

        If dt.Rows.Count > 0 Then
            LBLCNO = dt.Rows(0)(0).ToString
        Else
            LBLCNO = pfx & "-00000"
        End If

        Dim myCNO As Integer = Val(Mid(LBLCNO, 5, 5)) + 1
        Dim CNO As String = pfx & "-" & Space(5 - CStr(myCNO).Length).Replace(" ", "0") & myCNO

        sql = "INSERT INTO rlb01 (LBLCNO,TRXDATE,PRODDATE,UIDTRANS,LBLTYPE,REMARKS) VALUES (" & ENQ(CNO) & ",now(),curdate()," & ENQ(ACTIVEUSER) & "," & label_type & "," & ENQ(remarks) & ")"
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg = "Success" Then
            sql = "INSERT INTO rlb02 (LBLCNO,SERIALNO,LBLTYPE) VALUES (" & ENQ(CNO) & "," & ENQ(txtSerialNo.Text) & "," & label_type & ")"
            msg = ExecuteNonQuery("MYSQL", sql)

                If msg <> "Success" Then
                    MsgBox(msg, MsgBoxStyle.Critical)
                    Exit Sub
                End If

            If chkPreview.Checked Then
                PreviewLabel(txtCustomer.Tag.ToString, lbl, CNO, True)
            Else
                PrintLabels(txtCustomer.Tag.ToString, lbl, CNO, True)
            End If
        End If
    End Sub

    Private Sub lnkChoose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkChoose.LinkClicked
        remember = False
        sender.visible = False
    End Sub
End Class