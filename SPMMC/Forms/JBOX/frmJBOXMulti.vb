Imports System.ComponentModel
Imports System.IO
Imports AForge.Video.DirectShow

Public Class frmJBOXMulti
    Public CamNo As Integer
    Dim CAMERA1, CAMERA2, CAMERA3 As VideoCaptureDevice
    Dim bmp1, bmp2, bmp3 As Bitmap
    Dim p1 As PictureBox

    Dim img_path As String
    Dim Dir As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\Pictures\Camera Roll"
    Dim NetDir As String = "\\192.168.128.8\ops-meeting\JBOX Automation"
    Dim temp_path As String = Application.StartupPath & "\JBOX Temp"
    Dim img As Image

    Dim srcloc As String
    Dim prodline As String
    Dim lot_sql As String
    Dim prodtype As String
    Dim d As frmLot

    Private Sub iCapture1(sender As Object, eventArgs As AForge.Video.NewFrameEventArgs)
        bmp1 = DirectCast(eventArgs.Frame.Clone, Bitmap)
        PictureBox1.Image = DirectCast(eventArgs.Frame.Clone, Bitmap)
    End Sub

    Private Sub iCapture2(sender As Object, eventArgs As AForge.Video.NewFrameEventArgs)
        bmp2 = DirectCast(eventArgs.Frame.Clone, Bitmap)
        PictureBox2.Image = DirectCast(eventArgs.Frame.Clone, Bitmap)
    End Sub

    Private Sub iCapture3(sender As Object, eventArgs As AForge.Video.NewFrameEventArgs)
        bmp3 = DirectCast(eventArgs.Frame.Clone, Bitmap)
        PictureBox3.Image = DirectCast(eventArgs.Frame.Clone, Bitmap)
    End Sub

    Private Sub frmJBOXMulti_Load(sender As Object, e As EventArgs) Handles Me.Load
        chkCapture.Visible = (ACTIVEUSER.ToLower = "sysadmin")

        Dim sql As String = "SELECT B.SRCLOC FROM lts02 A INNER JOIN rou01 B ON A.STNID = B.STNID WHERE A.STNCODE = 'JBOX'"
        Dim sl As DataTable = ExecQuery("MYSQL", sql)

        If sl.Rows.Count > 0 Then
            srcloc = sl.Rows(0)(0).ToString.Trim
        End If

        txtSerial.Focus()

        Dim cameras1 As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras1.ShowDialog = DialogResult.OK Then
            CAMERA1 = cameras1.VideoDevice
            AddHandler CAMERA1.NewFrame, New AForge.Video.NewFrameEventHandler(AddressOf iCapture1)
            CAMERA1.Start()
        Else
            ' Me.Close()
        End If

        Dim cameras2 As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
        If cameras2.ShowDialog = DialogResult.OK Then
            CAMERA2 = cameras2.VideoDevice
            AddHandler CAMERA2.NewFrame, New AForge.Video.NewFrameEventHandler(AddressOf iCapture2)
            CAMERA2.Start()
        Else
            ' Me.Close()
        End If

        If CamNo = 3 Then
            Dim cameras3 As VideoCaptureDeviceForm = New VideoCaptureDeviceForm
            If cameras3.ShowDialog = DialogResult.OK Then
                CAMERA3 = cameras3.VideoDevice
                AddHandler CAMERA3.NewFrame, New AForge.Video.NewFrameEventHandler(AddressOf iCapture3)
                CAMERA3.Start()
            Else
                ' Me.Close()
            End If
        Else
            PictureBox3.Visible = False
        End If
    End Sub

    Private Sub frmJBOXMulti_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not CAMERA1 Is Nothing Then CAMERA1.Stop()
        If Not CAMERA2 Is Nothing Then CAMERA2.Stop()
        If CamNo = 3 Then
            If Not CAMERA3 Is Nothing Then CAMERA3.Stop()
        End If
    End Sub

    Private Sub ProcessImage(pic As PictureBox, pic2 As PictureBox, pic3 As PictureBox)
        If Not pic.Image Is Nothing Then
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

            'sql = "INSERT INTO mes01 (MESCNO,LOCNCODE,SERIALNO,MODCLASS,SNOSTAT,REMARKS,TRXDATE,TRXUID" & If(prodline <> String.Empty, ",PRODLINE", "") & ") VALUES (" &
            '      ENQ(mesno) & "," &
            '      ENQ("JBOX") & "," &
            '      ENQ(txtSerial.Text) & "," &
            '      ENQ(txtModClass.Text) & "," &
            '      GetStatusID(txtStatus.Text) & "," &
            '      ENQ(txtRemarks.Text) & "," &
            '      "now()," &
            '      ENQ(ACTIVEUSER) & If(prodline <> String.Empty, "," & ENQ(prodline), "") & ")"

            sql = "INSERT INTO mes01 (MESCNO,LOCNCODE,SERIALNO,MODCLASS,SNOSTAT,REMARKS,TRXDATE,TRXUID" & If(prodline <> String.Empty, ",PRODLINE", "") & ") VALUES (" &
                  ENQ(mesno) & "," &
                  ENQ("FRAMING") & "," &
                  ENQ(txtSerial.Text) & "," &
                  ENQ(txtModClass.Text) & "," &
                  GetStatusID(txtStatus.Text) & "," &
                  ENQ(txtRemarks.Text) & "," &
                  "now()," &
                  ENQ(ACTIVEUSER) & If(prodline <> String.Empty, "," & ENQ(prodline), "") & "),(" &
                  ENQ(mesno) & "," &
                  ENQ("JBOX") & "," &
                  ENQ(txtSerial.Text) & "," &
                  ENQ(txtModClass.Text) & "," &
                  GetStatusID(txtStatus.Text) & "," &
                  ENQ(txtRemarks.Text) & "," &
                  "now()," &
                  ENQ(ACTIVEUSER) & If(prodline <> String.Empty, "," & ENQ(prodline), "") & "),(" &
                  ENQ(mesno) & "," &
                  ENQ("CURING") & "," &
                  ENQ(txtSerial.Text) & "," &
                  ENQ(txtModClass.Text) & "," &
                  GetStatusID(txtStatus.Text) & "," &
                  ENQ(txtRemarks.Text) & "," &
                  "now()," &
                  ENQ(ACTIVEUSER) & If(prodline <> String.Empty, "," & ENQ(prodline), "") & ")"

            Dim msg As String = ExecuteNonQuery("MYSQL", sql)
            Dim images As PictureBox() = If(CamNo = 3, {pic, pic2, pic3}, {pic, pic2})

            If msg = "Success" Then
                If lot_sql <> String.Empty Then
                    msg = ExecuteNonQuery("MYSQL", "INSERT INTO mes02 (SERIALNO,LOCNCODE,INFOTYPE,FIELDNAME,FIELDVALUE,created_at,updated_at) VALUES " & lot_sql)
                    If msg <> "Success" Then
                        MsgBox(msg, MsgBoxStyle.Critical)
                    End If
                End If

                If chkCapture.Checked Then
                    Dim file_sfx As String = "_" & Format(CurrDate, "yyyyMMdd") & "_" & Format(CurrDate, "HHmmss") & "_JBOX"
                    Dim cam As Integer = 1

                    For Each img As PictureBox In images
                        p1 = New PictureBox

                        p1.Image = img.Image
                        If p1.Image Is Nothing Then
                            MsgBox("The camera is not running. Please start the camera first.")
                        Else
                            p1.Image.Save(Dir & "\" & txtSerial.Text.Trim & file_sfx & cam & ".jpg", Imaging.ImageFormat.Jpeg)
                        End If

                        cam += 1
                    Next

                    p1 = New PictureBox

                    If CamNo = 3 Then
                        p1.Image = CombineImages(pic.Image, pic2.Image, pic3.Image)
                    Else
                        p1.Image = CombineImages2(pic.Image, pic2.Image)
                    End If

                    p1.Image.Save(Dir & "\" & txtSerial.Text.Trim & file_sfx & ".jpg", Imaging.ImageFormat.Jpeg)

                    Dim dirname As String = Format(CurrDate, "yyyyMMdd")

                    If Not Directory.Exists(NetDir & "\" & dirname) Then
                        Directory.CreateDirectory(NetDir & "\" & dirname)
                    End If

                    If My.Settings.active_server = "Prod" Then
                        File.Copy(Dir & "\" & txtSerial.Text.Trim & file_sfx & ".jpg",
                              NetDir & "\" & dirname & "\" & txtSerial.Text.Trim & file_sfx & ".jpg", True)
                    End If
                End If

                lblSuccess.Text = "JBOX TRANSACTION COMPLETED FOR SERIAL NUMBER " & txtSerial.Text.Trim
                lblSuccess.Visible = True

                'Dim f As New frmPreview
                'f.PictureBox1.Image = PictureBox2.Image
                'f.ShowDialog()

                ClearForm(True)
            Else
                MsgBox(msg, MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Public Function CombineImages(ByVal img1 As Image, ByVal img2 As Image, ByVal img3 As Image) As Image
        Dim bmp As New Bitmap(Math.Max(Math.Max(img1.Width, img2.Width), img3.Width), img1.Height + img2.Height + img3.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.DrawImage(img1, 0, 0, img1.Width, img1.Height)
        g.DrawString("JBOX1", New Font("Calibri", 20), Brushes.Black, New PointF(0, 0))

        g.DrawImage(img2, 0, img1.Height, img2.Width, img2.Height)
        g.DrawString("JBOX2", New Font("Calibri", 20), Brushes.Black, New PointF(0, img1.Height))

        If CamNo = 3 Then
            g.DrawImage(img3, 0, img1.Height + img2.Height, img3.Width, img3.Height)
            g.DrawString("JBOX3", New Font("Calibri", 20), Brushes.Black, New PointF(0, img1.Height + img2.Height))
        End If

        g.Dispose()

        Return bmp
    End Function

    Public Function CombineImages2(ByVal img1 As Image, ByVal img2 As Image) As Image
        Dim bmp As New Bitmap(Math.Max(img1.Width, img2.Width), img1.Height + img2.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)

        g.DrawImage(img1, 0, 0, img1.Width, img1.Height)
        g.DrawString("JBOX1", New Font("Calibri", 20), Brushes.Black, New PointF(0, 0))

        g.DrawImage(img2, 0, img1.Height, img2.Width, img2.Height)
        g.DrawString("JBOX2", New Font("Calibri", 20), Brushes.Black, New PointF(0, img1.Height))

        g.Dispose()

        Return bmp
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p1 As New PictureBox
        Dim ig(3) As Image

        If File.Exists("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX1.jpg") Then ig(0) = Image.FromFile("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX1.jpg")
        If File.Exists("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX2.jpg") Then ig(1) = Image.FromFile("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX2.jpg")
        If File.Exists("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX3.jpg") Then ig(2) = Image.FromFile("C:\Users\crnevalga\Pictures\1947B2A4PZ36277_20191122_140556_JBOX3.jpg")

        p1.Image = CombineImages(ig(0), ig(1), ig(2))
        p1.Image.Save("C:\Users\crnevalga\Pictures\Stiched Image.jpg", Imaging.ImageFormat.Jpeg)
    End Sub

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

    Private Sub ClearForm(Optional ByVal ClearSerial As Boolean = False)
        If ClearSerial Then txtSerial.Clear()
        txtCustomer.Clear()
        txtCellInfo.Clear()
        txtPrevLoc.Clear()
        txtStatus.Clear()
        txtModClass.Clear()
        txtRemarks.Clear()
    End Sub

    Private Sub txtSerial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerial.KeyPress
        If Asc(e.KeyChar) = 13 Then
            lblSuccess.Visible = False

            Dim serialno As String = sender.Text.Trim
            Dim sql As String = "SELECT A.CUSTOMER, CONCAT(A.CELLCOUNT,A.CELLCOLOR) AS CELLTYPE, B.LOCNCODE, B.SNOSTAT, B.MODCLASS, B.REMARKS, A.PRODTYPE " &
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
                prodtype = dr("PRODTYPE").ToString.Trim

                Dim route_check As Boolean = False

                If srcloc = txtPrevLoc.Text.Trim Then
                    route_check = True
                End If

                If Not route_check Then
                    MsgBox("Serial Number [" & txtSerial.Text.Trim & "] should come from location [" & srcloc & "]." & Environment.NewLine & Environment.NewLine &
                           "Last Scanned Location is [" & txtPrevLoc.Text & "].")
                    ClearForm(True)
                Else
                    If PictureBox1.Image Is Nothing Or PictureBox2.Image Is Nothing Or (PictureBox3.Image Is Nothing And CamNo = 3) Then
                        MsgBox("No Image Captured. Please use the Camera App to Capture Image.")
                        ClearForm(True)
                    Else
                        'btnCapture.PerformClick()
                        If d Is Nothing Then d = New frmLot

                        With d
                            d.sno = sender.Text
                            d.prodtype = prodtype
                            If .ShowDialog = DialogResult.Cancel Then
                                Exit Sub
                            End If
                            lot_sql = d.sql
                        End With

                        Dim f As New frmPreviewMulti
                        With f
                            .serial = serialno
                            .PictureBox1.Image = PictureBox1.Image
                            .PictureBox2.Image = PictureBox2.Image
                            If CamNo = 3 Then .PictureBox3.Image = PictureBox3.Image

                            If .ShowDialog = DialogResult.OK Then
                                ProcessImage(.PictureBox1, .PictureBox2, .PictureBox3)
                            Else
                                ClearForm(True)
                            End If
                        End With
                    End If
                End If
            Else
                MsgBox("Serial Number [" & txtSerial.Text.Trim & "] does not exist in the system." & Environment.NewLine & Environment.NewLine &
                       "Please try scanning the serial again.")
                ClearForm(True)
            End If
        End If
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
End Class