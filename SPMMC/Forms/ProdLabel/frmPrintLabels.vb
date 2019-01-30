﻿Imports System.IO

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

    Dim btapp As BarTender.Application

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
        btapp = New BarTender.Application

        pnlProdType.Top = pnlSerial.Top
        pnlProdType.Visible = False

        InitNumText(txtTop)
        InitNumText(txtLeft)

        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            tscboPrinters.Items.Add(printer)
        Next printer

        tscboPrinters.Text = DefaultPrinterName()

        Dim d() As String = Directory.GetDirectories(Application.StartupPath & "\Label Templates")
        cboCust.Items.Clear()

        For Each folder In d
            cboCust.Items.Add(Mid(folder.ToString, folder.ToString.LastIndexOf("\") + 2, folder.ToString.Length))
        Next

        LoadLists()
        cboCell.Items.Clear()
        ProductionDate()
    End Sub

    Private Sub ProductionDate()
        txtProdDate.Text = Format(DateAdd(DateInterval.Day, If(Format(Now, "HH:mm") < "06:00", -1, 0), Now.Date), "yyyy-MM-dd")
    End Sub

    Private Sub LoadLists()
        FillComboBox(cboProdLine, "SELECT LINDESC FROM lin01 ORDER BY LINCODE",, "MYSQL")
        FillComboBox(cboModel, "SELECT PRODTYPE FROM typ00 WHERE ACTIVE = 1 ORDER BY PRODTYPE",, "MYSQL")
        If cboModel.Items.Count = 1 Then cboModel.SelectedIndex = 0
    End Sub

    Private Sub cboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboType.SelectedIndexChanged
        pnlProdType.Visible = (sender.SelectedIndex = 2)
        pnlSerial.Visible = Not (sender.SelectedIndex = 2)
        init = False

        If cboCust.SelectedIndex >= 0 Then
            GenerateSerial(mySerial)
        End If

        GetMargin(cboCust.Text.ToUpper.Trim, cboType.SelectedIndex + 1, txtTop, txtLeft)
    End Sub

    Private Sub cboCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCust.SelectedIndexChanged
        Dim sql As String = "SELECT PRODCODE, SERIALFORMAT, SERIALSTART, SERIALRESET FROM cus01 WHERE CUSCODE = " & ENQ(sender.Text.ToString.ToUpper)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        numQty.Value = 1

        If dt.Rows.Count > 0 Then
            'mySerial = dt.Rows(0)("SERIALFORMAT").ToString.Trim
            myProduct = dt.Rows(0)("PRODCODE").ToString.Trim
            serialStart = dt.Rows(0)("SERIALSTART").ToString.Trim
            serialReset = dt.Rows(0)("SERIALRESET").ToString.Trim

            GenerateSerial(mySerial)

            FillComboBox(cboCell, "SELECT CELLTYPE FROM cel00 WHERE CUSTOMER = " & ENQ(sender.Text.ToString) & " ORDER BY CELLTYPE",, "MYSQL")
            cboCell.Visible = (cboCell.Items.Count > 0)
        End If
        GetMargin(cboCust.Text.ToUpper.Trim, cboType.SelectedIndex + 1, txtTop, txtLeft)
    End Sub

    Private Sub GenerateSerial(ByVal SerialFormat As String)
        If init Then Exit Sub
        Dim retval As String = String.Empty

        Dim myFormat As String = SerialFormat
        Dim ProdDate As Date = Date.ParseExact(txtProdDate.Text.Trim, "yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        Dim myCode As String = GetCode(myFormat, "Y")
        If myCode <> String.Empty Then
            Dim myYear As String = Format(ProdDate, Mid(myCode, 2, myCode.Length - 2).ToLower)
            myFormat = myFormat.Replace(myCode, myYear)
        End If

        myCode = GetCode(myFormat, "M")
        If myCode <> String.Empty Then
            Dim myMonth As String = Format(ProdDate, Mid(myCode, 2, myCode.Length - 2))
            myFormat = myFormat.Replace(myCode, myMonth)
        End If

        myCode = GetCode(myFormat, "D")
        If myCode <> String.Empty Then
            Dim myDay As String = Format(ProdDate, "dd")
            myFormat = myFormat.Replace(myCode, myDay)
        End If

        myCode = GetCode(myFormat, "C")
        If myCode <> String.Empty Then
            Dim cellCount As String = GetCellCount()
            myFormat = myFormat.Replace(myCode, cellCount)
        End If

        myCode = GetCode(myFormat, "W")
        If myCode <> String.Empty Then
            Dim myWeek As Integer = DatePart(DateInterval.WeekOfYear, ProdDate, FirstDayOfWeek.Monday)
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

        If cboCell.Text <> "" Then
            myCode = GetCode(myFormat, "T")
            If myCode <> String.Empty Then
                Dim sText As String = String.Empty

                If cboCell.Text Like "*-*" Then
                    Dim s() As String = cboCell.Text.Trim.Split("-")
                    sText = s(0)
                Else
                    sText = cboCell.Text.Trim
                End If

                myFormat = myFormat.Replace(myCode, sText)
            End If
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

    Private Function GetLastSerial(ByVal Customer As String, ByVal LabelType As String, ByVal Prefix As String, ByVal serialDigit As Integer) As String
        Dim sText As String = String.Empty

        If cboCell.Text Like "*-*" Then
            Dim s() As String = cboCell.Text.Trim.Split("-")
            sText = s(0)
        Else
            sText = cboCell.Text.Trim
        End If

        Dim sql As String = "SELECT SUBSTRING(SERIALNO,LENGTH(SERIALNO)-" & serialDigit - 1 & ",LENGTH(SERIALNO)) AS SERIALNO " &
                            "FROM lbl02 WHERE LBLTYPE = " & LabelType & " AND CUSTOMER = " & ENQ(Customer) & " AND " &
                            "SERIALNO LIKE '" & Prefix & "%' " & If(cboCell.Visible, " AND SERIALNO LIKE '%" & sText & "%' AND PRODLINE = " & ENQ(cboProdLine.SelectedIndex + 1) & " AND CELLCOLOR = " & ENQ(GetCellType()) & " ", "") &
                            " ORDER BY SERIALNO DESC LIMIT 1"

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

    Private Sub SetCellCount(ByVal CellCount As String)
        For Each c As Object In pnlCellCount.Controls
            If TypeOf c Is RadioButton Then
                If Mid(c.Text, 1, 2) = CellCount Then
                    c.checked = True
                    Exit For
                End If
            End If
        Next
    End Sub

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

    Private Sub SetCellType(ByVal CellType As String)
        For Each c As Object In pnlCellType.Controls
            If TypeOf c Is RadioButton Then
                If CellType = c.Tag.ToString Then
                    c.checked = True
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub cboProdLine_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProdLine.SelectedIndexChanged
        If Not mySerial Is Nothing Then GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If sender.checked Then GenerateSerial(mySerial)
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

        If cboModel.SelectedIndex < 0 Then
            MsgBox("Please select a Model.", MsgBoxStyle.Information)
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

        If cboCell.Visible Then
            If cboCell.SelectedIndex < 0 Then
                MsgBox("Fill-up all the required fields.", MsgBoxStyle.Information)
                Exit Sub
            End If
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

        'Dim f As New frmBusbarExtras
        'If pfx = "BUS" Then
        '    With f
        '        .cust = cboCust.Text
        '        If .ShowDialog <> DialogResult.Cancel Then

        '        Else
        '            Exit Sub
        '        End If
        '    End With
        'End If

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
                    sql = "INSERT INTO lbl02 (LBLCNO,SERIALNO,LBLTYPE,CELLCOUNT,CELLCOLOR,CUSTOMER,PRODLINE,ORDERNO,COLOR,PRODTYPE" & If(cboCell.Visible, ",CTYPE", "") & ") VALUES " &
                          "(" & ENQ(CNO) & "," & ENQ(currentSerial) & "," & cboType.SelectedIndex + 1 & "," & ENQ(GetCellCount) & "," & ENQ(GetCellType) & "," & ENQ(cboCust.Text.ToUpper) &
                          "," & ENQ(cboProdLine.SelectedIndex + 1) & ",'',''," & ENQ(cboModel.Text) & If(cboCell.Visible, "," & ENQ(cboCell.Text), "") & ")"

                    msg = ExecuteNonQuery("MYSQL", sql)

                    If msg <> "Success" Then
                        MsgBox(msg, MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                Next

                'PreviewLabel(cboCust.Text.ToUpper, lbl, CNO)
                PrintLabels(cboCust.Text.ToUpper, lbl, CNO)
                SaveMargin(cboCust.Text.ToUpper, cboType.SelectedIndex + 1, NSV(txtTop.Text, True), NSV(txtLeft.Text, True))

                numQty.Value = 1
                GenerateSerial(mySerial)
            End If
        End If
    End Sub

    Private Sub PreviewLabel(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String)
        Dim btFormat As BarTender.Format

        btapp.VisibleWindows = BarTender.BtVisibleWindows.btInteractiveDialogs
        btFormat = New BarTender.Format
        btFormat = btApp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & LabelType & ".btw", False, "")
        btFormat.PrintSetup.Printer = tscboPrinters.Text
        btFormat.PageSetup.MarginTop = txtTop.Text
        btFormat.PageSetup.MarginLeft = txtLeft.Text
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        Dim bd As DialogResult = btFormat.PrintPreview.ShowDialog()

        If bd = 2 Then
            CancelPrint(ControlNo)
        End If

        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub

    Private Sub PrintLabels(ByVal Customer As String, ByVal LabelType As String, ByVal ControlNo As String)
        Dim btFormat As BarTender.Format

        btFormat = btapp.Formats.Open(Application.StartupPath & "\Label Templates\" & Customer & "\" & LabelType & ".btw", False, "")
        btFormat.Databases.QueryPrompts.GetQueryPrompt("ControlNo").Value = ControlNo
        btFormat.PrintSetup.Printer = tscboPrinters.Text
        btFormat.PageSetup.MarginTop = txtTop.Text
        btFormat.PageSetup.MarginLeft = txtLeft.Text

        btFormat.PrintOut()

        btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges)
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

    Private Sub cboCell_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCell.SelectedIndexChanged
        GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If sender.checked Then GenerateSerial(mySerial)
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If sender.checked Then GenerateSerial(mySerial)
    End Sub

    Private Sub cboModel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboModel.SelectedIndexChanged
        Dim sql As String = "SELECT * FROM typ00 WHERE PRODTYPE = " & ENQ(sender.Text.Trim)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Dim model As DataRow = dt.Rows(0)
            mySerial = model("SERIALFORMAT").ToString.Trim
            cboCust.Text = model("CUSTOMER")
            If cboCell.Visible Then cboCell.Text = model("CTYPE")
            SetCellCount(model("CELLCOUNT"))
            SetCellType(model("CELLCOLOR"))
        End If
    End Sub

    Private Sub frmPrintLabels_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        btapp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges)
    End Sub
End Class