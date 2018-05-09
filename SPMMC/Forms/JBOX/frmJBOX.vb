Imports System.IO

Public Class frmJBOX
    Dim img_path As String
    Dim Dir As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Pictures\Camera Roll"
    Dim NetDir As String = "\\192.168.128.8\ops-meeting\JBOX Automation"
    Dim temp_path As String = Application.StartupPath & "\JBOX Temp"
    Dim img As Image

    Dim srcloc As String

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProcessImage()
        If img_path <> String.Empty Then
            Dim CurrDate As Date = Now

            Dim sql As String = "SELECT MESCNO FROM mes01 WHERE MESCNO LIKE '" & Format(CurrDate, "yyyyMM") & "%' ORDER BY MESCNO DESC LIMIT 1"
            Dim cno As Integer = 0

            Dim dt As DataTable = ExecQuery("MYSQL", sql)

            If dt.Rows.Count > 0 Then
                cno = CInt(Mid(dt.Rows(0)(0).ToString.Trim, 7, 6)) + 1
            Else
                cno += 1
            End If

            Dim mesno As String = Format(CurrDate, "yyyyMM") & Space(6 - CStr(cno).Trim.Length).Replace(" ", "0") & cno

            sql = "INSERT INTO mes01 (MESCNO,LOCNCODE,SERIALNO,MODCLASS,SNOSTAT,REMARKS,TRXDATE,TRXUID) VALUES (" &
                  ENQ(mesno) & "," &
                  ENQ("JBOX") & "," &
                  ENQ(txtSerial.Text) & "," &
                  ENQ(txtModClass.Text) & "," &
                  GetStatusID(txtStatus.Text) & "," &
                  ENQ(txtRemarks.Text) & "," &
                  "now()," &
                  ENQ(ACTIVEUSER) & ")"

            Dim msg As String = ExecuteNonQuery("MYSQL", sql)

            If msg = "Success" Then
                img.Dispose()
                PictureBox1.Image = Nothing
                Timer1.Enabled = True

                Dim file_sfx As String = "_" & Format(CurrDate, "yyyyMMdd") & "_" & Format(CurrDate, "HHmmss") & "_JBOX"

                My.Computer.FileSystem.RenameFile(img_path, txtSerial.Text.Trim & file_sfx & ".jpg")
                My.Computer.FileSystem.DeleteFile(temp_path & "\temp.jpg")

                Dim dirname As String = Format(CurrDate, "yyyyMMdd")

                If Not Directory.Exists(NetDir & "\" & dirname) Then
                    Directory.CreateDirectory(NetDir & "\" & dirname)
                End If

                File.Copy(Dir & "\" & txtSerial.Text.Trim & file_sfx & ".jpg",
                          NetDir & "\" & dirname & "\" & txtSerial.Text.Trim & file_sfx & ".jpg", True)

                lblSuccess.Text = "JBOX TRNSACTION COMPLETED FOR SERIAL NUMBER " & txtSerial.Text.Trim
                lblSuccess.Visible = True

                ClearForm(True)
            Else
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Dir As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Pictures\Camera Roll"

        If Directory.Exists(Dir) Then
            Dim FileLocation As DirectoryInfo = New DirectoryInfo(Dir)
            Dim fi As FileInfo() = FileLocation.GetFiles("WIN*.jpg")
            img_path = String.Empty

            For Each f As FileInfo In fi
                img_path = Dir & "\" & f.ToString

                If Not Directory.Exists(temp_path) Then
                    Directory.CreateDirectory(temp_path)
                End If

                File.Copy(img_path, temp_path & "\temp.jpg", True)

                Exit For
            Next

            If img_path <> String.Empty Then
                img = Image.FromFile(temp_path & "\temp.jpg")
                PictureBox1.Image = img
                Timer1.Enabled = False

                If Me.MdiParent.WindowState <> 0 Then
                    Me.MdiParent.WindowState = FormWindowState.Maximized
                ElseIf Not Me.Focused Then
                    'Me.Activate()
                End If

                Me.MdiParent.Activate()
            End If
        End If
    End Sub

    Private Sub frmJBOX_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT B.SRCLOC FROM lts02 A INNER JOIN rou01 B ON A.STNID = B.STNID WHERE A.STNCODE = 'JBOX'"
        Dim sl As DataTable = ExecQuery("MYSQL", Sql)

        If sl.Rows.Count > 0 Then
            srcloc = sl.Rows(0)(0).ToString.Trim
        End If

        Timer1.Enabled = True
        txtSerial.Focus()
    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lblSuccess.Visible = False

            Dim serialno As String = sender.Text.Trim
            Dim sql As String = "SELECT A.CUSTOMER, CONCAT(A.CELLCOUNT,A.CELLCOLOR) AS CELLTYPE, B.LOCNCODE, B.SNOSTAT, B.MODCLASS, B.REMARKS " &
                                "FROM lbl02 A LEFT JOIN mes_ftd B ON A.SERIALNO = B.SERIALNO AND A.LBLTYPE = 1 " &
                                "WHERE A.SERIALNO = " & ENQ(serialno)

            Dim dt As DataTable = ExecQuery("MYSQL", sql)

            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)

                txtCustomer.Text = dr("CUSTOMER").ToString.Trim
                txtCellInfo.Text = dr("CELLTYPE").ToString.Trim
                txtPrevLoc.Text = dr("LOCNCODE").ToString.Trim
                txtStatus.Text = If(IsDBNull(dr("SNOSTAT")), "", GetStatus(dr("SNOSTAT")))
                txtModClass.Text = dr("MODCLASS").ToString.Trim
                txtRemarks.Text = dr("REMARKS").ToString.Trim

                Dim route_check As Boolean = False

                If srcloc = txtPrevLoc.Text.Trim Then
                    route_check = True
                End If

                If Not route_check Then
                    MsgBox("Serial Number [" & txtSerial.Text.Trim & "] should come from location [" & srcloc & "]." & Environment.NewLine & Environment.NewLine &
                           "Last Scanned Location is [" & txtPrevLoc.Text & "].")
                    ClearForm(True)
                Else
                    If PictureBox1.Image Is Nothing Then
                        MsgBox("No Image Captured. Please use the Camera App to Capture Image.")
                        ClearForm(True)
                    Else
                        'btnCapture.PerformClick()
                        ProcessImage()
                    End If
                End If
            Else
                MsgBox("Serial Number [" & txtSerial.Text.Trim & "] does not exist in the system." & Environment.NewLine & Environment.NewLine &
                       "Please try scanning the serial again.")
                ClearForm(True)
            End If
        End If
    End Sub

    Private Sub ClearForm(Optional ByVal ClearSerial As Boolean = False)
        If ClearSerial Then txtSerial.Clear()
        txtCustomer.Clear()
        txtCellInfo.Clear()
        txtPrevLoc.Clear()
        txtStatus.Clear()
        txtModClass.Clear()
        txtRemarks.Clear()
    End Sub

    Private Sub txtSerial_LostFocus(sender As Object, e As EventArgs) Handles txtSerial.LostFocus
        sender.Focus
    End Sub

    Private Function GetStatus(ByVal StatusID As Integer) As String
        Select Case StatusID
            Case 0
                Return "Good"
            Case 1
                Return "MRB"
            Case 2
                Return "Scrap"
            Case Else
                Return "Undefined"
        End Select
    End Function

    Private Function GetStatusID(ByVal Status As String) As Integer
        Select Case Status
            Case "Good"
                Return 0
            Case "MRB"
                Return 1
            Case "Scrap"
                Return 2
            Case Else
                Return -1
        End Select
    End Function
End Class