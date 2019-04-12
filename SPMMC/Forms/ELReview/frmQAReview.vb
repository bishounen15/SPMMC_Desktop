Imports System.Threading
Imports System.IO

Public Class frmQAReview
    Dim EL1_Path As String = My.Settings.el1_path
    Dim EL2_Path As String = My.Settings.el2_path
    Dim JBX_Path As String = My.Settings.jbox_path
    Dim MC_Path As String = My.Settings.el2_mc

    Dim check_init, check_mc As Boolean

    Dim dt As DataTable
    Dim StatMsg As String

    Dim EL1 As ListViewItem
    Dim EL2 As ListViewItem
    Dim JBX As ListViewItem

    Dim cix As Integer
    Dim Pallet_Count, EL1_Count, EL2_Count, JBOX_Count As Integer
    Dim EL1_Serial, EL2_Serial, JBOX_Serial As String
    Dim EL1_SNO, EL2_SNO, JBOX_SNO As String
    Dim PalletNumber As String

    Public UID As String
    Dim ULVL As Integer
    Dim OverrideStatus As Boolean

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPalletNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            OverrideStatus = False
            Dim PalletStatus As Integer = GetPalletStatus(sender.Text)
CheckPallet:
            If PalletStatus = 0 Then
                Try
                    check_init = False
                    check_mc = False
                    Pallet_Count = 0
                    EL1_Count = 0
                    EL2_Count = 0
                    JBOX_Count = 0

                    Me.Enabled = False
                    Me.ProgressBar1.Style = ProgressBarStyle.Marquee
                    Dim t As New Thread(AddressOf Me.LoadInfo)
                    t.Start()
                Catch ex As Exception
                    MsgBox("Error occured: " & ex.Message, MsgBoxStyle.Critical)
                End Try
            Else
                Dim msg As String = String.Empty

                Select Case PalletStatus
                    Case 1
                        msg = "PASSED"
                    Case -1
                        msg = "FAILED"
                    Case -2
                        msg = "NON EXISTING"
                    Case Else
                        msg = "-"
                End Select

                If ULVL = 0 Then
                    Dim dres As DialogResult = MsgBox("The selected pallet number [" & sender.Text & "] is tagged as " & msg & "." & Environment.NewLine & Environment.NewLine & "Do you want to override the Pallet Status?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

                    If dres = DialogResult.Yes Then
                        OverrideStatus = True
                        PalletStatus = 0
                        GoTo CheckPallet
                    Else
                        ClearList()
                    End If
                Else
                    MsgBox("The selected pallet number [" & sender.Text & "] is tagged as " & msg & ".", MsgBoxStyle.Information)
                    ClearList()
                End If
            End If
        End If
    End Sub

    Private Sub ClearList()
        ClearTable(dgvFTD)
        lvEL1.Items.Clear()
        pbEL1.Image = Nothing
        lvEL2.Items.Clear()
        lvJBOX.Items.Clear()
        pbEL2.Image = Nothing
        txtPalletNo.Enabled = True
        txtPalletNo.Clear()
        txtPalletNo.Focus()
        ToolStrip1.Enabled = False
    End Sub

    Private Sub ClearTable(ByVal DGV As DataGridView)
        Try
            Dim oldTable As DataTable = DGV.DataSource
            Dim emptyTable As DataTable = oldTable.Clone()
            DGV.DataSource = emptyTable
        Catch
        End Try
    End Sub

    Private Function GetPalletStatus(ByVal PalletNo As String) As Integer
        Dim sql As String = "SELECT PALLETSTAT FROM epl01 WHERE PALLETNO = " & ENQ(PalletNo)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return -2
        End If
    End Function

    Private Sub LoadInfo()
        StatMsg = "Loading Flash Test Data..."
        UpdateStatus()

        ClearLists()

        Dim sql As String = "SELECT A.SERIALNO, B.InspectionTime, B.Isc, B.Uoc, B.Impp, B.Umpp, B.Pmpp, B.ShuntResistance, B.FF, B.Bin, " &
                            "REPLACE(REPLACE(REPLACE(REPLACE(D.PRODCODE,'[P]',B.Bin),'[R]',E.CELLCOLOR),'[C]',E.CELLCOUNT),'[T]',E.CTYPE) AS MODELNAME, F.ITMCODE AS PARTNO " &
                            "FROM epl02 A INNER JOIN ftd_upd B ON A.SERIALNO = B.ModuleID INNER JOIN epl01 C ON A.PALLETNO = C.PALLETNO AND A.CARTONNO = C.CARTONNO " &
                            "INNER JOIN cus01 D ON C.CUSTOMER = D.CUSCODE INNER JOIN lbl02 E ON A.SERIALNO = E.SERIALNO AND D.CUSCODE = E.CUSTOMER AND E.LBLTYPE = 1 " &
                            "INNER JOIN itm01 F ON REPLACE(REPLACE(REPLACE(REPLACE(D.PRODCODE,'[P]',B.Bin),'[R]',E.CELLCOLOR),'[C]',E.CELLCOUNT),'[T]',E.CTYPE) = F.ITMDESC " &
                            "WHERE A.PALLETNO = " & ENQ(txtPalletNo.Text) & " ORDER BY A.ROWID"

        dt = ExecQuery("MYSQL", sql)
        LoadFTD()

        Dim strEL1(2) As String
        Dim strEL2(2) As String
        Dim strJBX(2) As String

        If dt.Rows.Count > 0 Then
            Pallet_Count = dt.Rows.Count

            For Each dr As DataRow In dt.Rows
                Dim QDir As String = GenerateQuarterDirectory(dr("InspectionTime")) '"\" & Year(dr("InspectionTime")) & "\Q" & ((Month(dr("InspectionTime")) - 1) \ 3 + 1) & "'" & Format(dr("InspectionTime"), "yy")
                Dim FirstTest As Date = GetFirstTestDate(dr("SERIALNO").ToString)

                strEL1(0) = dr("SERIALNO").ToString
                strEL1(1) = ScanDirectoriesEL1(EL1_Path, dr("SERIALNO").ToString, FirstTest)
                If strEL1(1).Trim <> String.Empty Then EL1_Count += 1

                strEL2(0) = dr("SERIALNO").ToString
                strEL2(1) = ScanDirectoriesEL2(EL2_Path & QDir, dr("SERIALNO").ToString, dr("InspectionTime"))

                If strEL2(1).Trim = String.Empty Then
                    If Not check_init Then
                        Dim f As New frmCheckMC
                        With f
                            .serialno = dr("SERIALNO").ToString

                            If .ShowDialog = DialogResult.Yes Then
                                check_mc = True
                            End If

                            check_init = True
                        End With
                    End If

                    If check_mc = True Then strEL2(1) = ScanDirectoriesMC(MC_Path, dr("SERIALNO").ToString, dr("InspectionTime"))
                End If

                If strEL2(1).Trim <> String.Empty Then EL2_Count += 1

                strJBX(0) = dr("SERIALNO").ToString
                strJBX(1) = ScanDirectoriesJBOX(JBX_Path, dr("SERIALNO").ToString)
                If strJBX(1).Trim <> String.Empty Then JBOX_Count += 1

                EL1 = New ListViewItem(strEL1)
                EL2 = New ListViewItem(strEL2)
                JBX = New ListViewItem(strJBX)

                LoadListItems()
            Next
        End If

        EndProcessing()
    End Sub

    Private Function GenerateQuarterDirectory(ByVal myDate As Date) As String
        Return "\" & Year(myDate) & "\Q" & ((Month(myDate) - 1) \ 3 + 1) & "'" & Format(myDate, "yy")
    End Function

    Private Function GetFirstTestDate(ByVal serialNo As String) As Date
        Dim sql As String = "SELECT InspectionTime FROM ftd_raw WHERE ModuleID = " & ENQ(serialNo) & " ORDER BY ROWID LIMIT 1"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)
        Dim retval As Date = Nothing

        If dt.Rows.Count > 0 Then
            retval = dt.Rows(0)(0)
        End If

        Return retval
    End Function

    Private Function ScanDirectoriesEL1(ByVal RootDir As String, ByVal SerialNo As String, ByVal FirstTest As Date) As String
        StatMsg = "Checking " & RootDir & " for " & SerialNo & " EL Images.."
        UpdateStatus()

        Dim retval As String = String.Empty

        Dim edate As Date = FirstTest
        Dim sdate As Date = DateAdd(DateInterval.Day, -10, edate)
        Dim Dir As String = String.Empty

        'For Each Dir As String In Directory.GetDirectories(RootDir)
        While sdate <= edate
            Dir = RootDir & "\" & GenerateQuarterDirectory(sdate) & "\" & Format(sdate, "yyMMdd")

            If Directory.Exists(Dir) Then
                Dim FileLocation As DirectoryInfo = New DirectoryInfo(Dir)
                Dim fi As FileInfo() = FileLocation.GetFiles(SerialNo & "*.jpg")

                For Each f As FileInfo In fi
                    'File.Copy(Dir & "\" & f.ToString, MyPath & "\" & dr(0).ToString.Trim & ".jpg", True)
                    retval = Dir & "\" & f.ToString
                Next

                StatMsg = "Checking " & Dir & " for " & SerialNo & " EL Images.."
                UpdateStatus()
                Dim newPath As String = ScanDirectoriesEL1(Dir, SerialNo, FirstTest)

                If newPath <> String.Empty Then retval = newPath
            End If

            sdate = DateAdd(DateInterval.Day, 1, sdate)
        End While
        'Next

        Return retval
    End Function

    Private Function ScanDirectoriesMC(ByVal RootDir As String, ByVal SerialNo As String, ByVal TestDate As Date) As String
        StatMsg = "Checking " & RootDir & " for " & SerialNo & " EL Images.."
        UpdateStatus()

        Dim retval As String = String.Empty

        Dim edate As Date = DateAdd(DateInterval.Day, 1, TestDate)
        Dim sdate As Date = DateAdd(DateInterval.Day, -1, TestDate)
        Dim Dir As String = String.Empty

        'For Each Dir As String In Directory.GetDirectories(RootDir)
        While sdate <= edate
            Dir = RootDir & "\" & Format(sdate, "yyMMdd")

            If Directory.Exists(Dir) Then
                Dim FileLocation As DirectoryInfo = New DirectoryInfo(Dir)
                Dim fi As FileInfo() = FileLocation.GetFiles(SerialNo & "*.jpg")

                For Each f As FileInfo In fi
                    'File.Copy(Dir & "\" & f.ToString, MyPath & "\" & dr(0).ToString.Trim & ".jpg", True)
                    retval = Dir & "\" & f.ToString
                Next

                StatMsg = "Checking " & Dir & " for " & SerialNo & " EL Images.."
                UpdateStatus()
                Dim newPath As String = ScanDirectoriesEL1(Dir, SerialNo, TestDate)

                If newPath <> String.Empty Then retval = newPath
            End If

            sdate = DateAdd(DateInterval.Day, 1, sdate)
        End While
        'Next

        Return retval
    End Function

    Private Function ScanDirectoriesJBOX(ByVal RootDir As String, ByVal SerialNo As String) As String
        StatMsg = "Checking " & RootDir & " for " & SerialNo & " JBOX Images.."
        UpdateStatus()

        Dim retval As String = String.Empty

        For Each Dir As String In Directory.GetDirectories(RootDir)
            If Directory.Exists(Dir) Then
                Dim FileLocation As DirectoryInfo = New DirectoryInfo(Dir)
                Dim fi As FileInfo() = FileLocation.GetFiles(SerialNo & "*.jpg")

                For Each f As FileInfo In fi
                    'File.Copy(Dir & "\" & f.ToString, MyPath & "\" & dr(0).ToString.Trim & ".jpg", True)
                    retval = Dir & "\" & f.ToString
                Next

                StatMsg = "Checking " & Dir & " for " & SerialNo & " JBOX Images.."
                UpdateStatus()
                Dim newPath As String = ScanDirectoriesJBOX(Dir, SerialNo)

                If newPath <> String.Empty Then retval = newPath
            End If
        Next

        Return retval
    End Function

    Private Function ScanDirectoriesEL2(ByVal RootDir As String, ByVal SerialNo As String, ByVal TestDate As Date) As String
        StatMsg = "Checking " & RootDir & " for " & SerialNo & " EL Images.."
        UpdateStatus()

        Dim retval As String = String.Empty
        'For Each Dir As String In Directory.GetDirectories(RootDir)
        Dim Dir As String = RootDir

        Dim sdate As Date = DateAdd(DateInterval.Day, -10, TestDate)
        Dim edate As Date = DateAdd(DateInterval.Day, 3, TestDate)
        Dim mydir As String = String.Empty

        While sdate <= edate
            mydir = Dir & "\" & Format(edate, "yyMMdd")
            If Directory.Exists(mydir) Then
                Dim FileLocation As DirectoryInfo = New DirectoryInfo(mydir)
                Dim fi As FileInfo() = FileLocation.GetFiles(SerialNo & "*.jpg")

                For Each f As FileInfo In fi
                    'File.Copy(Dir & "\" & f.ToString, MyPath & "\" & dr(0).ToString.Trim & ".jpg", True)
                    retval = mydir & "\" & f.ToString
                    Exit For
                Next

                If retval <> String.Empty Then Exit While
            End If

            edate = DateAdd(DateInterval.Day, -1, edate)
        End While

        StatMsg = "Checking " & Dir & " for " & SerialNo & " EL Images.."

        'UpdateStatus()
        'Dim newPath As String = ScanDirectoriesEL2(Dir, SerialNo)

        'If newPath <> String.Empty Then retval = newPath
        'Next
        Return retval
    End Function

    Private Sub UpdateStatus()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateStatus))
        Else
            lblStatus.Text = StatMsg
        End If
    End Sub

    Private Sub LoadListItems()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf LoadListItems))
        Else
            lvEL1.Items.Add(EL1)
            lvEL2.Items.Add(EL2)
            lvJBOX.Items.Add(JBX)
        End If
    End Sub

    Private Sub ClearLists()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf ClearLists))
        Else
            lvEL1.Items.Clear()
            lvEL2.Items.Clear()
        End If
    End Sub

    Private Function FindImage(ByVal CurrDir As String, ByVal SerialNo As String) As String
        Dim retval As String = String.Empty

        Return retval
    End Function

    Private Sub LoadFTD()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf LoadFTD))
        Else
            dgvFTD.DataSource = dt
            lblCount.Text = If(dt.Rows.Count > 0, dt.Rows.Count, "-")
        End If
    End Sub

    Private Sub EndProcessing()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndProcessing))
        Else
            lblStatus.Text = "Ready"
            Me.ProgressBar1.Style = ProgressBarStyle.Blocks
            Me.Enabled = True

            If dgvFTD.Rows.Count = 0 Then
                txtPalletNo.Clear()
            Else
                ToolStrip1.Enabled = True
                txtPalletNo.Enabled = False
            End If

            tcData.SelectedIndex = 0
            Me.Focus()
        End If
    End Sub

    Private Sub lvEL2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvEL2.SelectedIndexChanged
        If sender.SelectedItems.Count > 0 Then
            If sender.SelectedItems(0).SubItems(1).Text.trim <> "" Then
                pbEL2.Load(sender.SelectedItems(0).SubItems(1).Text)
            Else
                pbEL2.Image = Nothing
            End If
        Else
            pbEL2.Image = Nothing
        End If
    End Sub

    Private Sub lvEL1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvEL1.SelectedIndexChanged
        If sender.SelectedItems.Count > 0 Then
            If sender.SelectedItems(0).SubItems(1).Text.trim <> "" Then
                pbEL1.Load(sender.SelectedItems(0).SubItems(1).Text)
            Else
                pbEL1.Image = Nothing
            End If
        Else
            pbEL1.Image = Nothing
        End If
    End Sub

    Private Sub btnShow1_Click(sender As Object, e As EventArgs) Handles btnShow1.Click
        If lvEL1.SelectedItems.Count > 0 Then
            Dim objShell
            objShell = CreateObject("shell.application")
            objShell.ShellExecute(lvEL1.SelectedItems(0).SubItems(1).Text, "", "", "open", 1)
        End If
    End Sub

    Private Sub btnShow2_Click(sender As Object, e As EventArgs) Handles btnShow2.Click
        Dim img As ListView = Nothing

        If rbEL2.Checked Then img = lvEL2 Else img = lvJBOX

        If img.SelectedItems.Count > 0 Then
            Dim objShell
            objShell = CreateObject("shell.application")
            objShell.ShellExecute(img.SelectedItems(0).SubItems(1).Text, "", "", "open", 1)
        End If
    End Sub

    Private Sub lvEL1_DoubleClick(sender As Object, e As EventArgs) Handles lvEL1.DoubleClick
        btnShow1.PerformClick()
    End Sub

    Private Sub pbEL1_DoubleClick(sender As Object, e As EventArgs) Handles pbEL1.DoubleClick
        btnShow1.PerformClick()
    End Sub

    Private Sub lvEL2_DoubleClick(sender As Object, e As EventArgs) Handles lvEL2.DoubleClick
        btnShow2.PerformClick()
    End Sub

    Private Sub pbEL2_DoubleClick(sender As Object, e As EventArgs) Handles pbEL2.DoubleClick
        btnShow2.PerformClick()
    End Sub

    Private Sub PassedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PassedToolStripMenuItem.Click
        If dgvFTD.Rows.Count > 0 Then
            If Pallet_Count > EL1_Count Or Pallet_Count > EL2_Count Or Pallet_Count > JBOX_Count Then
                Dim count_msg As String = "Total Serials: " & vbTab & Pallet_Count & Environment.NewLine & Environment.NewLine &
                                          If(Pallet_Count > EL1_Count, "EL1 Images: " & vbTab & EL1_Count & " (" & Pallet_Count - EL1_Count & " not found on source folder)" & Environment.NewLine, "") &
                                          If(Pallet_Count > EL2_Count, "EL2 Images: " & vbTab & EL2_Count & " (" & Pallet_Count - EL2_Count & " not found on source folder)" & Environment.NewLine, "") &
                                          If(Pallet_Count > JBOX_Count, "JBOX Images: " & vbTab & JBOX_Count & " (" & Pallet_Count - JBOX_Count & " not found on source folder)" & Environment.NewLine, "")

                If MsgBox("The selected pallet [" & txtPalletNo.Text & "] has incomplete images: " & Environment.NewLine & Environment.NewLine & count_msg & Environment.NewLine &
                          "Do you want to continue with the transaction?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        Dim dres As DialogResult = MsgBox("Do you really want to tagged this pallet as PASSED?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
        Dim myRemarks As String = String.Empty

        If dres = DialogResult.Yes Then
            If OverrideStatus Then
                Dim f As New frmRemarks
                With f
                    f.Text = "PASSED Remarks for Pallet No. " & txtPalletNo.Text & " (Override Status)"
                    dres = .ShowDialog
                End With

                If dres = DialogResult.Cancel Then
                    Exit Sub
                Else
                    myRemarks = f.txtRemarks.Text
                End If
            End If

            Dim sql As String = "UPDATE epl01 SET PALLETSTAT = 1," & If(OverrideStatus, " REMARKS = " & ENQ(myRemarks) & ",", "") & " UIDSTATUS = " & ENQ(UID) & ", DTSTATUS = now() WHERE PALLETNO = " & ENQ(txtPalletNo.Text)
            Dim msg As String = ExecuteNonQuery("MYSQL", sql)

            If msg <> "Success" Then
                MsgBox(msg, MsgBoxStyle.Critical)
            Else
                Try
                    PalletNumber = txtPalletNo.Text.Trim
                    Me.Enabled = False
                    Me.ProgressBar1.Style = ProgressBarStyle.Marquee
                    Dim t As New Thread(AddressOf Me.CopyImages)
                    t.Start()
                Catch ex As Exception
                    MsgBox("Error occured: " & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        End If
    End Sub

    Private Sub CopyImages()
        Dim DestFolder As String = My.Settings.dest_path & "\ELREview_" & Format(Now, "yyyyMMdd")
        If Not Directory.Exists(DestFolder) Then Directory.CreateDirectory(DestFolder)
        DestFolder &= "\" & txtPalletNo.Text
        If Not Directory.Exists(DestFolder) Then Directory.CreateDirectory(DestFolder)
        If Not Directory.Exists(DestFolder & "\EL1") Then Directory.CreateDirectory(DestFolder & "\EL1")
        If Not Directory.Exists(DestFolder & "\EL2") Then Directory.CreateDirectory(DestFolder & "\EL2")
        If Not Directory.Exists(DestFolder & "\JBOX") Then Directory.CreateDirectory(DestFolder & "\JBOX")

        Dim sql As String = "SELECT A.SERIALNO, B.InspectionTime, B.Pmpp, B.Uoc, B.Isc, B.Umpp, B.Impp, B.ShuntResistance, B.FF, B.Bin, " &
                            "REPLACE(REPLACE(REPLACE(D.PRODCODE,'[P]',B.Bin),'[R]',E.CELLCOLOR),'[C]',E.CELLCOUNT) AS MODELNAME, F.ITMCODE AS PARTNO " &
                            "FROM epl02 A INNER JOIN ftd_upd B ON A.SERIALNO = B.ModuleID INNER JOIN epl01 C ON A.PALLETNO = C.PALLETNO AND A.CARTONNO = C.CARTONNO " &
                            "INNER JOIN cus01 D ON C.CUSTOMER = D.CUSCODE INNER JOIN lbl02 E ON A.SERIALNO = E.SERIALNO AND D.CUSCODE = E.CUSTOMER AND E.LBLTYPE = 1 " &
                            "INNER JOIN itm01 F ON REPLACE(REPLACE(REPLACE(D.PRODCODE,'[P]',B.Bin),'[R]',E.CELLCOLOR),'[C]',E.CELLCOUNT) = F.ITMDESC " &
                            "WHERE A.PALLETNO = " & ENQ(PalletNumber) & " ORDER BY A.ROWID"

        ExportToExcel(sql, "Flash Test Data",,, DestFolder)

        For i As Integer = 0 To lvEL1.Items.Count - 1
            cix = i
            SelectPath()

            StatMsg = "Copying EL Images for " & EL1_SNO & " on folder path " & DestFolder
            UpdateStatus()

            If EL1_Serial <> "" Then File.Copy(EL1_Serial, DestFolder & "\EL1\" & EL1_SNO & ".jpg", True)
            GetRemarks(EL1_SNO, "EL1", DestFolder & "\EL1\")

            If EL2_Serial <> "" Then File.Copy(EL2_Serial, DestFolder & "\EL2\" & EL2_SNO & ".jpg", True)
            If JBOX_Serial <> "" Then File.Copy(JBOX_Serial, DestFolder & "\JBOX\" & JBOX_SNO & ".jpg", True)
            GetRemarks(EL2_SNO, "EL2", DestFolder & "\EL2\")
        Next

        EndCopy()
    End Sub

    Private Sub GetRemarks(ByVal SerialNo As String, ByVal Locn As String, ByVal Dest As String)
        Dim sql As String = "SELECT A.*, B.USERNAME FROM cmt01 A INNER JOIN sys01 B ON A.UIDCOMMENT = B.USERID WHERE A.SERIALNO = " & ENQ(SerialNo) & " AND A.STATION = " & ENQ(Locn) & " ORDER BY A.ROWID DESC"
        Dim dt As DataTable = ExecQuery("MYSQL", sql)
        Dim remarks As String = String.Empty

        If dt.Rows.Count > 0 Then
            For Each dr As DataRow In dt.Rows
                Dim cmtDate As Date = dr("CMTDATE")
                Dim comment As String = dr("COMMENTS").ToString
                Dim userid As String = dr("USERNAME").ToString

                remarks &= "Posted by " & userid & " on " & FormatDateTime(cmtDate, DateFormat.LongDate) & " at " & FormatDateTime(cmtDate, DateFormat.LongTime) & Environment.NewLine & comment & Environment.NewLine & Environment.NewLine
            Next

            WriteToFile(Dest & SerialNo & ".txt", remarks)
        End If
    End Sub

    Private Sub SelectPath()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf SelectPath))
        Else
            EL1_Serial = lvEL1.Items(cix).SubItems(1).Text.Trim
            EL2_Serial = lvEL2.Items(cix).SubItems(1).Text.Trim
            JBOX_Serial = lvJBOX.Items(cix).SubItems(1).Text.Trim

            EL1_SNO = lvEL1.Items(cix).Text.Trim
            EL2_SNO = lvEL2.Items(cix).Text.Trim
            JBOX_SNO = lvJBOX.Items(cix).Text.Trim
        End If
    End Sub

    Private Sub EndCopy()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf EndCopy))
        Else
            lblStatus.Text = "Ready"
            Me.ProgressBar1.Style = ProgressBarStyle.Blocks
            Me.Enabled = True

            ClearList()

            tcData.SelectedIndex = 0
            Me.Focus()
        End If
    End Sub

    Private Sub FailedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FailedToolStripMenuItem.Click
        Dim dres As DialogResult = MsgBox("Do you really want to tagged this pallet as FAILED?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        If dres = DialogResult.Yes Then
            Dim f As New frmRemarks
            With f
                f.Text = "FAILED Remarks for Pallet No. " & txtPalletNo.Text
                dres = .ShowDialog
            End With

            If dres = DialogResult.OK Then
                Dim sql As String = "UPDATE epl01 SET PALLETSTAT = -1, REMARKS = " & ENQ(f.txtRemarks.Text) & ", UIDSTATUS = " & ENQ(UID) & ", DTSTATUS = now() WHERE PALLETNO = " & ENQ(txtPalletNo.Text)
                Dim msg As String = ExecuteNonQuery("MYSQL", sql)

                If msg <> "Success" Then
                    MsgBox(msg, MsgBoxStyle.Critical)
                Else
                    If OverrideStatus Then
                        If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ELREview\" & txtPalletNo.Text.Trim) Then
                            Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\ELREview\" & txtPalletNo.Text.Trim, True)
                        End If
                    End If
                    ClearList()
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim dres As DialogResult = MsgBox("This will cancel the current transaction. Do you want to continue?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        If dres = DialogResult.Yes Then
            ClearList()
        End If
    End Sub

    Private Sub txtPalletNo_LostFocus(sender As Object, e As EventArgs) Handles txtPalletNo.LostFocus
        sender.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmELPath

        With f
            If f.ShowDialog = DialogResult.OK Then
                EL1_Path = My.Settings.el1_path
                EL2_Path = My.Settings.el2_path
                JBX_Path = My.Settings.jbox_path
                MC_Path = My.Settings.el2_mc
            End If
        End With
    End Sub

    Private Sub btnRemarks1_Click(sender As Object, e As EventArgs) Handles btnRemarks1.Click
        If lvEL1.SelectedItems.Count = 0 Then
            MsgBox("Please select a serial number first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtRemarks1.Text.Trim = "" Then
            MsgBox("Please enter your remarks.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim sql As String = "INSERT INTO cmt01 (SERIALNO,STATION,COMMENTS,UIDCOMMENT) VALUES (" & ENQ(lvEL1.SelectedItems(0).Text) & ",'EL1'," & ENQ(txtRemarks1.Text) & "," & ENQ(UID) & ")"
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg <> "Success" Then MsgBox(msg, MsgBoxStyle.Critical) Else txtRemarks1.Clear()
    End Sub

    Private Sub btnRemarks2_Click(sender As Object, e As EventArgs) Handles btnRemarks2.Click
        Dim img As ListView = Nothing

        If rbEL2.Checked Then img = lvEL2 Else img = lvJBOX

        If img.SelectedItems.Count = 0 Then
            MsgBox("Please select a serial number first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtRemarks2.Text.Trim = "" Then
            MsgBox("Please enter your remarks.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim sql As String = "INSERT INTO cmt01 (SERIALNO,STATION,COMMENTS,UIDCOMMENT) VALUES (" & ENQ(img.SelectedItems(0).Text) & ",'EL2'," & ENQ(txtRemarks2.Text) & "," & ENQ(UID) & ")"
        Dim msg As String = ExecuteNonQuery("MYSQL", sql)

        If msg <> "Success" Then MsgBox(msg, MsgBoxStyle.Critical) Else txtRemarks2.Clear()
    End Sub

    Private Sub frmQAReview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT USERLVL FROM els00 WHERE USERID = " & ENQ(UID)
        Dim dt As DataTable = ExecQuery("MYSQL", sql)

        If dt.Rows.Count > 0 Then
            ULVL = dt.Rows(0)(0)
        Else
            MsgBox("Your User Level is not defined.", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub

    Private Sub rbEL2_CheckedChanged(sender As Object, e As EventArgs) Handles rbEL2.CheckedChanged
        lvEL2.Visible = sender.Checked
        lvJBOX.Visible = Not sender.Checked
    End Sub

    Private Sub lnkView1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkView1.LinkClicked
        If lvEL1.SelectedItems.Count = 0 Then
            MsgBox("Please select a serial number first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim f As New frmComments
        With f
            .Text = "User Comments for Serial Number " & lvEL1.SelectedItems(0).Text & " EL1 Image"
            .SerialNo = lvEL1.SelectedItems(0).Text
            .Locn = "EL1"
            .ShowDialog()
        End With
    End Sub

    Private Sub lnkView2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkView2.LinkClicked
        If lvEL2.SelectedItems.Count = 0 Then
            MsgBox("Please select a serial number first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim f As New frmComments
        With f
            .Text = "User Comments for Serial Number " & lvEL2.SelectedItems(0).Text & " EL2 Image"
            .SerialNo = lvEL2.SelectedItems(0).Text
            .Locn = "EL2"
            .ShowDialog()
        End With
    End Sub

    Private Sub lvJBOX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvJBOX.SelectedIndexChanged
        If sender.SelectedItems.Count > 0 Then
            If sender.SelectedItems(0).SubItems(1).Text.trim <> "" Then
                pbEL2.Load(sender.SelectedItems(0).SubItems(1).Text)
            Else
                pbEL2.Image = Nothing
            End If
        Else
            pbEL2.Image = Nothing
        End If
    End Sub

    Private Sub lvJBOX_DoubleClick(sender As Object, e As EventArgs) Handles lvJBOX.DoubleClick
        btnShow2.PerformClick()
    End Sub
End Class
