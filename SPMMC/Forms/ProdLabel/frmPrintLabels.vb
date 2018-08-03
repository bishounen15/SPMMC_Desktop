Public Class frmPrintLabels
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
    Dim mySerial As String
    Dim serialStart As Integer
    Dim serialReset As Integer
    Dim myProduct As String

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

    Private Sub frmPrintLabels_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlProdType.Top = pnlSerial.Top
        pnlProdType.Visible = False

        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            tscboPrinters.Items.Add(printer)
        Next printer

        tscboPrinters.Text = DefaultPrinterName()
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        pnlProdType.Visible = (sender.SelectedIndex = 2)
        pnlSerial.Visible = Not (sender.SelectedIndex = 2)
        init = False

        If cboCust.SelectedIndex >= 0 Then
            GenerateSerial(mySerial)
        End If
    End Sub

    Private Sub cboCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCust.SelectedIndexChanged
        Dim sql As String = "SELECT PRODCODE, SERIALFORMAT, SERIALSTART, SERIALRESET FROM cus01 WHERE CUSCODE = " & ENQ(sender.Text.ToString.ToUpper)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        numQty.Value = 1

        If dt.Rows.Count > 0 Then
            mySerial = dt.Rows(0)("SERIALFORMAT").ToString.Trim
            myProduct = dt.Rows(0)("PRODCODE").ToString.Trim
            serialStart = dt.Rows(0)("SERIALSTART").ToString.Trim
            serialReset = dt.Rows(0)("SERIALRESET").ToString.Trim

            GenerateSerial(mySerial)
        End If
    End Sub

    Private Sub GenerateSerial(ByVal SerialFormat As String)
        If init Then Exit Sub
        Dim retval As String = String.Empty

        Dim myFormat As String = SerialFormat

        Dim myCode As String = GetCode(myFormat, "Y")
        If myCode <> String.Empty Then
            Dim myYear As String = Format(Now.Date, Mid(myCode, 2, myCode.Length - 2).ToLower)
            myFormat = myFormat.Replace(myCode, myYear)
        End If

        myCode = GetCode(myFormat, "M")
        If myCode <> String.Empty Then
            Dim myMonth As String = Format(Now.Date, Mid(myCode, 2, myCode.Length - 2))
            myFormat = myFormat.Replace(myCode, myMonth)
        End If

        myCode = GetCode(myFormat, "W")
        If myCode <> String.Empty Then
            Dim myWeek As Integer = DatePart(DateInterval.WeekOfYear, Now.Date, FirstDayOfWeek.Monday)
            Dim myWk As String = String.Empty

            If myWeek < 10 Then
                myWk = "0" & myWeek
            Else
                myWk = myWeek
            End If

            myFormat = myFormat.Replace(myCode, myWk)
        End If

        myCode = GetCode(myFormat, "L")
        If myCode <> String.Empty Then
            myFormat = myFormat.Replace(myCode, cboProdLine.SelectedIndex + 1)
        End If

        myCode = GetCode(myFormat, "R")
        If myCode <> String.Empty Then
            myFormat = myFormat.Replace(myCode, GetCellType)
        End If

        myCode = GetCode(myFormat, "S")
        If myCode <> String.Empty Then
            Dim Prefix As String = Mid(myFormat, 1, serialReset)
            Dim nextSerial As String = GetLastSerial(cboCust.Text.ToUpper, cboType.SelectedIndex + 1, Prefix, myCode.Length - 2)
            retval = myFormat.Replace(myCode, nextSerial)
        End If

        txtSerialStart.Text = retval
        GetEndSerial(numQty)
    End Sub

    Private Function GetLastSerial(ByVal Customer As String, ByVal LabelType As String, ByVal Prefix As Integer, ByVal serialDigit As Integer) As String
        Dim sql As String = "SELECT SUBSTRING(SERIALNO,LENGTH(SERIALNO)-" & serialDigit - 1 & ",LENGTH(SERIALNO)) AS SERIALNO FROM lbl02 WHERE LBLTYPE = " & LabelType & " AND CUSTOMER = " & ENQ(Customer) & " AND SERIALNO LIKE '" & Prefix & "%' ORDER BY SERIALNO DESC LIMIT 1"
        Dim retval As String = String.Empty

        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Dim serialNo As String = Val(dt.Rows(0)(0)) + 1
            retval = Space(serialDigit - CStr(serialNo).Trim.Length).Replace(" ", "0") & serialNo
        Else
            retval = Space(serialDigit - CStr(serialStart).Trim.Length).Replace(" ", "0") & serialStart
        End If

        Return retval
    End Function

    Private Function GetCode(ByVal myFormat As String, ByVal myCode As String) As String
        Dim six, eix As Integer
        Dim retval As String = String.Empty

        If myFormat.IndexOf("[" & myCode) >= 0 Then
            six = myFormat.IndexOf("[" & myCode) + 1
            eix = myFormat.IndexOf(myCode & "]") + 3
            retval = Mid(myFormat, six, eix - six)
        End If

        Return retval
    End Function

    Private Function GetCellCount() As String
        Dim retval As String = String.Empty

        For Each c As Object In pnlCellCount.Controls
            If TypeOf c Is RadioButton Then
                If c.checked Then
                    retval = Mid(c.Text, 1, 2)
                    Exit For
                End If
            End If
        Next

        Return retval
    End Function

    Private Function GetCellType() As String
        Dim retval As String = String.Empty

        For Each c As Object In pnlCellType.Controls
            If TypeOf c Is RadioButton Then
                If c.checked Then
                    retval = c.Tag.ToString
                    Exit For
                End If
            End If
        Next

        Return retval
    End Function

    Private Sub cboProdLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdLine.SelectedIndexChanged
        GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        GenerateSerial(mySerial)
    End Sub

    Private Sub numQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        GetEndSerial(sender)
    End Sub

    Private Sub GetEndSerial(ByVal sender As Object)
        If init Then Exit Sub
        Dim myCode As String = GetCode(mySerial, "S")
        If myCode <> String.Empty Then
            Dim serialprefix As String = Mid(txtSerialStart.Text, 1, txtSerialStart.Text.Length - (myCode.Length - 2))
            Dim startSerial As String = Mid(txtSerialStart.Text, txtSerialStart.Text.Length - (myCode.Length - 3), myCode.Length - 2)
            Dim serialcount As Integer = Val(startSerial)

            For i As Integer = 1 To sender.Value - 1
                serialcount += 1
            Next

            txtSerialEnd.Text = serialprefix & Space((myCode.Length - 2) - CStr(serialcount).Trim.Length).Replace(" ", "0") & serialcount
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If cboType.SelectedIndex < 0 Then
            MsgBox("Please select a Label Type.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If cboCust.SelectedIndex < 0 Then
            MsgBox("Please select a Customer.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If cboProdLine.SelectedIndex < 0 Then
            MsgBox("Please select a Production Line.", MsgBoxStyle.Information)
            Exit Sub
        End If

        GetEndSerial(numQty)

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

        Dim sql As String = "SELECT LBLCNO FROM lbl01 WHERE LBLTYPE = " & cboType.SelectedIndex + 1 & " ORDER BY LBLCNO DESC LIMIT 1"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)
        Dim LBLCNO As String = String.Empty

        If dt.Rows.Count > 0 Then
            LBLCNO = dt.Rows(0)(0).ToString
        Else
            LBLCNO = pfx & "-00000"
        End If

        Dim myCNO As Integer = Val(Mid(LBLCNO, 5, 5)) + 1
        Dim CNO As String = pfx & "-" & Space(5 - CStr(myCNO).Length).Replace(" ", "0") & myCNO

        sql = "INSERT INTO lbl01 (LBLCNO,TRXDATE,PRODDATE,UIDTRANS,LBLTYPE) VALUES (" & ENQ(CNO) & ",now(),curdate()," & ENQ(ACTIVEUSER) & "," & cboType.SelectedIndex + 1 & ")"
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg = "Success" Then
            Dim myCode As String = GetCode(mySerial, "S")
            If myCode <> String.Empty Then
                Dim serialprefix As String = Mid(txtSerialStart.Text, 1, txtSerialStart.Text.Length - (myCode.Length - 2))
                Dim startSerial As String = Mid(txtSerialStart.Text, txtSerialStart.Text.Length - (myCode.Length - 3), myCode.Length - 2)
                Dim endSerial As String = Mid(txtSerialEnd.Text, txtSerialEnd.Text.Length - (myCode.Length - 3), myCode.Length - 2)
                Dim currentSerial As String = String.Empty

                For i As Integer = Val(startSerial) To Val(endSerial)
                    currentSerial = serialprefix & Space((myCode.Length - 2) - CStr(i).Trim.Length).Replace(" ", "0") & i
                    sql = "INSERT INTO lbl02 (LBLCNO,SERIALNO,LBLTYPE,CELLCOUNT,CELLCOLOR,CUSTOMER,PRODLINE,ORDERNO,COLOR) VALUES (" & ENQ(CNO) & "," & ENQ(currentSerial) & "," & cboType.SelectedIndex + 1 & "," & ENQ(GetCellCount) & "," & ENQ(GetCellType) & "," & ENQ(cboCust.Text.ToUpper) & "," & ENQ(cboProdLine.SelectedIndex + 1) & ",'','')"
                    msg = ExecuteNonQuery("MYSQL", sql)

                    If msg <> "Success" Then
                        MsgBox(msg, MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                'PreviewLabel(cboCust.Text.ToUpper, lbl, CNO)
                PrintLabels(cboCust.Text.ToUpper, lbl, CNO)

                numQty.Value = 1
                GenerateSerial(mySerial)
            End If
        End If
    End Sub

    Private Sub PreviewLabel(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String)
        Dim btApp As New BarTender.Application
        Dim btFormat As BarTender.Format

        btApp.VisibleWindows = BarTender.BtVisibleWindows.btInteractiveDialogs
        btFormat = New BarTender.Format
        btFormat = btApp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & LabelType & ".btw", False, "")
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
        btFormat = btapp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & LabelType & ".btw", False, "")
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        btFormat.PrintSetup.Printer = tscboPrinters.Text

        btFormat.PrintOut()
        btapp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub CancelPrint(ByVal ControlNo As String)
        Dim sql As String = "DELETE FROM lbl02 WHERE LBLCNO = " & ENQ(ControlNo)
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg = "Success" Then
            sql = "DELETE FROM lbl01 WHERE LBLCNO = " & ENQ(ControlNo)
            msg = ExecuteNonQuery("MYSQL", sql)

            If msg <> "Success" Then
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
        Else
            MsgBox(msg, MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub numQty_LostFocus(sender As Object, e As EventArgs) Handles numQty.LostFocus
        GetEndSerial(sender)
    End Sub

    Private Sub frmPrintLabels_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not defprint = String.Empty Then
            SetDefaultPrinter(defprint.Trim, "", "")
        End If
    End Sub
End Class