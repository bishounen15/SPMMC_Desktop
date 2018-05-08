Imports System.Data.Sql
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Math
Imports System.Runtime.InteropServices                 ' required imports

Module modData
    Dim CnStr As String = GenConn("192.168.128.7", "spmmc01", "password@01", "spmmc00")
    Public FILE_NAME As String = Application.StartupPath & "\" & Application.ProductName & ".ini"
    Dim fs As FileStream

    Public Const CurrDate As String = "CAST(CAST(MONTH(GETDATE()) AS VARCHAR) + '/' + CAST(DAY(GETDATE()) AS VARCHAR) + '/' + " &
                                      "CAST(YEAR(GETDATE()) AS VARCHAR) AS DATETIME)"

    Public Const serverIP As String = "192.168.128.7"
    Public Const uid As String = "spmmc01"
    Public Const pwd As String = "password@01"
    Public Const dbs As String = "spmmc00"
    Public Const eng As String = "MYSQL"

    Public gvServer, gvUserid, gvPassword, gvInitCatalog As String
    Public gvServer2, gvUserid2, gvPassword2, gvInitCatalog2 As String
    Public gvServergp, gvUseridgp, gvPasswordgp, gvInitCataloggp As String
    Public gvServerOldgp, gvUseridOldgp, gvPasswordOldgp, gvInitCatalogOldgp As String

    Public SERVERSMTP, USERSMTP, PASSSMTP, LINKSERVER, DESTLINK, ITGROUP, FADGROUP, PURCHGROUP, MAINTGROUP, CLASSID, GENDESC, ITEMLOC, BACKDOOR As String
    Public PRIMARYLOC, SECONDARYLOC, PRIMSCRIPTSLOC, SECSCRIPTSLOC, SCRIPTSLOC As String
    Public Dept, UEmail, SEmail As String

#Region "   System Globals"
    'System Global Variables Goes Here
    Public LOCALIP As String
    Public ACTIVEUSER As String
    Public ACTIVEUSERNAME As String

    Public LastMonth As Boolean
    Public BatchDays, CurrMonth As Integer
#End Region

#Region "   Database Related"
    Function SQLNonQuery(ByVal DBEngine As String, ByVal sql As String) As Boolean
        Dim msg As String = ExecuteNonQuery(DBEngine, sql)
        If msg <> "Success" Then
            MsgBox(msg, MsgBoxStyle.Critical)
            Return False
        Else
            Return True
        End If
    End Function

    Sub EnumSQLInstances(ByRef oCbo As ComboBox)
        ' Retrieve the enumerator instance and then the data.
        Dim instance As SqlDataSourceEnumerator =
         SqlDataSourceEnumerator.Instance
        Dim table As System.Data.DataTable = instance.GetDataSources()

        ' Display the contents of the table.
        oCbo.Items.Clear()

        For Each row As DataRow In table.Rows
            oCbo.Items.Add(row(0).ToString.Trim & If(row(1).ToString.Trim <> "", "\" & row(1).ToString.Trim, ""))
        Next
    End Sub

    Function CheckConn(ByVal DBEngine As String, Optional ByVal ConnStr As String = "") As Boolean
        Dim retval As Boolean

        Dim cn

        If DBEngine = "MYSQL" Then
            cn = New MySqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
        Else
            cn = New SqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
        End If

        Try
            cn.Open()
            cn.Close()
            retval = True
        Catch ex As Exception
            retval = False
        Finally
            cn.Dispose()
        End Try

        Return retval
    End Function

    Function ExecQuery(ByVal DBEngine As String, ByVal sQuery As String, Optional ByVal ConnStr As String = "") As Object
        Dim cn
        Dim cmd

        If DBEngine = "MYSQL" Then
            cn = New MySqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
            cmd = New MySqlCommand(sQuery, cn)
        Else
            cn = New SqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
            cmd = New SqlCommand(sQuery, cn)
        End If

        cmd.CommandTimeout = 0

        Dim da

        If DBEngine = "MYSQL" Then
            da = New MySqlDataAdapter(cmd)
        Else
            da = New SqlDataAdapter(cmd)
        End If

        Dim dt As New DataTable

        Try
            cn.Open()
            da.Fill(dt)

            Return dt

            cn.Close()
        Catch ex As Exception
            Dim errStr As String = "An error occured while executing query: " & vbCrLf & vbCrLf &
                                   ex.Message & vbCrLf & vbCrLf &
                                   "Please contact IT Group to fix this error."
            Throw New Exception(errStr)
        Finally
            cn.Dispose()
        End Try
    End Function

    Function GetQuery(ByVal ScrFile As String) As String
        Dim sQry As String = String.Empty

        Dim objStreamReader As StreamReader
        Dim strLine As String

TryAgain:
        Dim sFile As String = SCRIPTSLOC & "\" & ScrFile & ".sqf"

        If File.Exists(sFile) Then
            Try
                'Pass the file path and the file name to the StreamReader constructor.
                objStreamReader = New StreamReader(sFile)

                Do
                    strLine = objStreamReader.ReadLine()
                    If strLine <> String.Empty Then
                        sQry += IIf(sQry = String.Empty, "", " ") & strLine
                    Else
                        Exit Do
                    End If
                Loop Until strLine Is Nothing

                'Close the file.
                objStreamReader.Close()
            Catch ex As Exception
                If SCRIPTSLOC = PRIMSCRIPTSLOC Then
                    SCRIPTSLOC = SECSCRIPTSLOC
                    GoTo TryAgain
                Else
                    Throw New Exception(ex.Message)
                End If
            End Try
        Else
            If SCRIPTSLOC = PRIMSCRIPTSLOC Then
                SCRIPTSLOC = SECSCRIPTSLOC
                GoTo TryAgain
            Else
                MsgBox("Both Primary and Secondary File Locations are unavailable. Please contact IT Department.", MsgBoxStyle.Critical)
            End If
        End If

        Return sQry
    End Function

    Function ExecuteNonQuery(ByVal DBEngine As String, ByVal sQuery As String, Optional ByVal ConnStr As String = "") As String
        Dim cn
        Dim cmd

        If DBEngine = "MYSQL" Then
            cn = New MySqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
            cmd = New MySqlCommand(sQuery, cn)
        Else
            cn = New SqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
            cmd = New SqlCommand(sQuery, cn)
        End If

        cmd.CommandTimeout = 0

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return "Success"
        Catch ex As Exception
            Dim errStr As String = "An error occured while executing non-query script: " & vbCrLf & vbCrLf &
                                   ex.Message & vbCrLf & vbCrLf &
                                   "Please contact IT Group to fix this error."
            Throw New Exception(errStr)
        Finally
            cn.Dispose()
        End Try
    End Function

    Function DataCheck(ByVal sQuery As String, Optional ByVal ConnStr As String = "") As Object
        Dim cn As New MySqlConnection(IIf(ConnStr = "", CnStr, ConnStr))
        Dim da As New MySqlDataAdapter(sQuery, cn)
        Dim dt As New DataTable

        Try
            cn.Open()
            da.Fill(dt)

            Return dt.Rows.Count > 0

            cn.Close()
        Catch ex As Exception
            Dim errStr As String = "An error occured while executing query: " & vbCrLf & vbCrLf &
                                   ex.Message & vbCrLf & vbCrLf &
                                   "Please contact IT Group to fix this error."
            Throw New Exception(errStr)
        Finally
            cn.Dispose()
        End Try
    End Function
#End Region

#Region "   File Related"
    Sub GetFilePath()
        Dim objStreamReader As StreamReader
        Dim strLine As String
        Dim token() As String
        Dim i As Integer

        If File.Exists(FILE_NAME) Then
            Try
                'Pass the file path and the file name to the StreamReader constructor.
                objStreamReader = New StreamReader(FILE_NAME)
                LOCALIP = GetLocalIP(True)

                Do
                    strLine = objStreamReader.ReadLine()
                    If strLine <> String.Empty Then
                        If strLine.IndexOf("PrimaryLocation=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                PRIMARYLOC += token(i)
                            Next

                            Dim cls As New clsSecure
                            Dim mb As Byte() = Convert.FromBase64String(PRIMARYLOC &
                                               Space(token.Length - 2).Replace(" ", "="))

                            PRIMARYLOC = cls.Decrypt(mb)
                        End If
                    Else
                        Exit Do
                    End If
                Loop Until strLine Is Nothing

                Dim FP As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

                FP = Mid(FP, 1, FP.LastIndexOf("\")) & "\SMP_APPDATA"

                If Not Directory.Exists(FP) Then
                    Directory.CreateDirectory(FP)
                End If

                FP &= "\" & Application.ProductName

                Dim PRIMPATH As String = PRIMARYLOC & "\" & Application.ProductName

                SECSCRIPTSLOC = Mid(FP, 1, FP.LastIndexOf("\")) & "\" & Application.ProductName & "\System Scripts"
                SECONDARYLOC = Mid(FP, 1, FP.LastIndexOf("\")) & "\" & Application.ProductName & "\" & Application.ProductName & ".ini"
                PRIMSCRIPTSLOC = PRIMARYLOC & "\" & Application.ProductName & "\System Scripts"
                PRIMARYLOC &= "\" & Application.ProductName & "\" & Application.ProductName & ".ini"
                SCRIPTSLOC = PRIMSCRIPTSLOC

                Try
                    My.Computer.FileSystem.CopyDirectory(PRIMPATH, FP, True)
                Catch ex As Exception
                    MsgBox("Unable to copy settings from Primary Storage. Secondary storage now activated.", MsgBoxStyle.Information)
                End Try

                'Close the file.
                objStreamReader.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Sub ReadFromFile()
        Dim objStreamReader As StreamReader
        Dim strLine As String
        Dim token() As String
        Dim i As Integer
        Dim IsPrimary As Boolean = True
        Dim FP As String = PRIMARYLOC

CheckAgain:
        If File.Exists(FP) Then
            Try
                'Pass the file path and the file name to the StreamReader constructor.
                objStreamReader = New StreamReader(FP)
                LOCALIP = GetLocalIP(True)

                Do
                    strLine = objStreamReader.ReadLine()
                    If strLine <> String.Empty Then
                        If strLine.IndexOf("server=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvServer += token(i)
                            Next
                        ElseIf strLine.IndexOf("userid=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvUserid += token(i)
                            Next
                        ElseIf strLine.IndexOf("password=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvPassword += token(i)
                            Next

                            Dim cls As New clsSecure
                            Dim mb As Byte() = Convert.FromBase64String(gvPassword &
                                               Space(token.Length - 2).Replace(" ", "="))

                            gvPassword = cls.Decrypt(mb)
                        ElseIf strLine.IndexOf("initialcatalog=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvInitCatalog += token(i)
                            Next
                        ElseIf strLine.IndexOf("serversec=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvServer2 += token(i)
                            Next
                        ElseIf strLine.IndexOf("useridsec=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvUserid2 += token(i)
                            Next
                        ElseIf strLine.IndexOf("passwordsec=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvPassword2 += token(i)
                            Next

                            Dim cls As New clsSecure
                            Dim mb As Byte() = Convert.FromBase64String(gvPassword2 &
                                               Space(token.Length - 2).Replace(" ", "="))

                            gvPassword2 = cls.Decrypt(mb)
                        ElseIf strLine.IndexOf("initialcatalogsec=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                gvInitCatalog2 += token(i)
                            Next
                        ElseIf strLine.IndexOf("SMTP=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                SERVERSMTP += token(i)
                            Next
                        ElseIf strLine.IndexOf("SMTPUSER=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                USERSMTP += token(i)
                            Next
                        ElseIf strLine.IndexOf("SMTPPASS=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                PASSSMTP += token(i)
                            Next
                        ElseIf strLine.IndexOf("LinkServer=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                LINKSERVER += token(i)
                            Next
                        ElseIf strLine.IndexOf("DestLink=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                DESTLINK += token(i)
                            Next
                        ElseIf strLine.IndexOf("ITGROUP=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                ITGROUP += token(i)
                            Next
                        ElseIf strLine.IndexOf("FADGROUP=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                FADGROUP += token(i)
                            Next
                        ElseIf strLine.IndexOf("PURCHGROUP=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                PURCHGROUP += token(i)
                            Next
                        ElseIf strLine.IndexOf("MAINTGROUP=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                MAINTGROUP += token(i)
                            Next
                        ElseIf strLine.IndexOf("CLASSID=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                CLASSID += token(i)
                            Next
                        ElseIf strLine.IndexOf("GENDESC=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                GENDESC += token(i)
                            Next
                        ElseIf strLine.IndexOf("ITEMLOC=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                ITEMLOC += token(i)
                            Next
                        ElseIf strLine.IndexOf("BackDoor=") >= 0 Then
                            token = strLine.Split("=")
                            For i = 1 To token.Length - 1
                                BACKDOOR += token(i)
                            Next

                            Dim cls As New clsSecure
                            Dim mb As Byte() = Convert.FromBase64String(BACKDOOR &
                                               Space(token.Length - 2).Replace(" ", "="))

                            BACKDOOR = cls.Decrypt(mb)
                        End If
                    Else
                        Exit Do
                    End If
                Loop Until strLine Is Nothing

                'Close the file.
                objStreamReader.Close()

                CnStr = "Data Source=" & gvServer & ";Persist Security Info=True;" &
                        "User ID=" & gvUserid & ";Password=" & gvPassword & ";Initial Catalog=" & gvInitCatalog
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            If IsPrimary Then
                FP = SECONDARYLOC
                IsPrimary = Not IsPrimary
                GoTo CheckAgain
            Else
                MsgBox("Both Primary and Secondary File Locations are unavailable. Please contact IT Department.", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Sub CreateINI(ByVal fname As String)
        Dim cls As New clsSecure

        fs = New FileStream(fname, FileMode.Create)
        fs.Close()

        WriteToFile(fname, "[Source Database Setup]")
        WriteToFile(fname, "server=" & gvServer)
        WriteToFile(fname, "userid=" & gvUserid)
        WriteToFile(fname, "password=" & cls.Encrypt(gvPassword))
        WriteToFile(fname, "initialcatalog=" & gvInitCatalog)
        WriteToFile(fname, "[Destination Database Setup]")
        WriteToFile(fname, "serversec=" & gvServer2)
        WriteToFile(fname, "useridsec=" & gvUserid2)
        WriteToFile(fname, "passwordsec=" & cls.Encrypt(gvPassword2))
        WriteToFile(fname, "initialcatalogsec=" & gvInitCatalog2)
        WriteToFile(fname, "[GP Settings]")
        WriteToFile(fname, "CLASSID=" & CLASSID)
        WriteToFile(fname, "GENDESC=" & GENDESC)
        WriteToFile(fname, "ITEMLOC=" & ITEMLOC)
        WriteToFile(fname, "[Email Setup]")
        WriteToFile(fname, "SMTP=" & SERVERSMTP)
        WriteToFile(fname, "SMTPUSER=" & USERSMTP)
        WriteToFile(fname, "SMTPPASS=" & PASSSMTP)
        WriteToFile(fname, "ITGROUP=" & ITGROUP)
        WriteToFile(fname, "FADGROUP=" & FADGROUP)
        'WriteToFile(fname, "PURCHGROUP=" & PURCHGROUP)
        'WriteToFile(fname, "MAINTGROUP=" & MAINTGROUP)
        WriteToFile(fname, "[System Defaults]")
        WriteToFile(fname, "LinkServer=" & LINKSERVER)
        WriteToFile(fname, "DestLink=" & DESTLINK)
        WriteToFile(fname, "BackDoor=" & cls.Encrypt(BACKDOOR))

    End Sub

    Sub WriteToFile(ByVal location As Object, ByVal StringToWrite As String)
        Dim objStreamWriter As StreamWriter

        Try
            'Pass the file path and the file name to the StreamWriter constructor.
            objStreamWriter = File.AppendText(location)

            'Write a line of text.
            objStreamWriter.WriteLine(StringToWrite)

            'Close the file.
            objStreamWriter.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ContentType(ByVal FileExtension As String) As String
        Dim d As New Dictionary(Of String, String)
        'Images'
        d.Add(".bmp", "image/bmp")
        d.Add(".gif", "image/gif")
        d.Add(".jpeg", "image/jpeg")
        d.Add(".jpg", "image/jpeg")
        d.Add(".png", "image/png")
        d.Add(".tif", "image/tiff")
        d.Add(".tiff", "image/tiff")
        'Documents'
        d.Add(".doc", "application/msword")
        d.Add(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
        d.Add(".pdf", "application/pdf")
        'Slideshows'
        d.Add(".ppt", "application/vnd.ms-powerpoint")
        d.Add(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")
        'Data'
        d.Add(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        d.Add(".xls", "application/vnd.ms-excel")
        d.Add(".csv", "text/csv")
        d.Add(".xml", "text/xml")
        d.Add(".txt", "text/plain")
        'Compressed Folders'
        d.Add(".rar", "application/x-rar-compressed")
        d.Add(".zip", "application/zip")
        'Audio'
        d.Add(".ogg", "application/ogg")
        d.Add(".mp3", "audio/mpeg")
        d.Add(".wma", "audio/x-ms-wma")
        d.Add(".wav", "audio/x-wav")
        'Video'
        d.Add(".wmv", "audio/x-ms-wmv")
        d.Add(".swf", "application/x-shockwave-flash")
        d.Add(".avi", "video/avi")
        d.Add(".mp4", "video/mp4")
        d.Add(".mpeg", "video/mpeg")
        d.Add(".mpg", "video/mpeg")
        d.Add(".qt", "video/quicktime")
        Return d(FileExtension)
    End Function
#End Region

#Region "   String Related"
    Function ENQ(ByVal oStr As String) As String
        Return "'" & Replace(oStr.Trim, "'", "''") & "'"
    End Function

    Function NSV(ByVal oStr As String, Optional ByVal ToNumber As Boolean = False) As String
        Return IIf(ToNumber, "", "'") & Replace(oStr.Trim, ",", "") & IIf(ToNumber, "", "'")
    End Function
#End Region

#Region "   Universal Form Events"
    Public Sub Numeric_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        Else
            If e.KeyChar = "." Then
                If Val(sender.Tag) = 0 Then
                    e.Handled = True
                Else
                    If sender.Text.IndexOf(".") > -1 Then
                        e.Handled = True
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub Numeric_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not sender.ReadOnly Then sender.Text = NSV(sender.Text, True)
    End Sub

    Public Sub Numeric_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not sender.ReadOnly Then
            sender.Text = FormatNumber(IIf(IsNumeric(sender.Text), sender.Text, 0), Val(sender.Tag))
        End If
    End Sub
#End Region

#Region "   Populate Lists"
    Public Sub FillComboBox(ByRef oCbo As ComboBox, ByVal SQL As String, Optional ByVal StrConn As String = "", Optional ByVal DBEngine As String = "MSSQL")
        Try
            Dim dt As DataTable = ExecQuery(DBEngine, SQL, StrConn)

            oCbo.Items.Clear()

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    oCbo.Items.Add(dr(0).ToString.Trim)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub FillListBox(ByRef oList As ListBox, ByVal SQL As String, Optional ByVal StrConn As String = "")
        Try
            Dim dt As DataTable = ExecQuery(SQL, StrConn)

            oList.Items.Clear()

            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    oList.Items.Add(dr(0).ToString.Trim)
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub FillListView(ByRef oLView As ListView, ByVal SQL As String, Optional ByVal StrConn As String = "", Optional ByVal DecPlaces As Integer = 0, Optional ByVal DateTimeAsString As Boolean = False, Optional ByVal DBEngine As String = "MSSQL")
        Try
            Dim dt As DataTable
            dt = ExecQuery(DBEngine, SQL, StrConn)

            Dim str(dt.Columns.Count) As String

            oLView.Items.Clear()

            Dim m As Integer

            For Each oCol As DataColumn In dt.Columns
                m = Ceiling(oCol.ColumnName.Trim.Length / 10)
                If m = 0 Then m = 1
                oLView.Columns.Add(oCol.ColumnName.Trim, 70 * m, HorizontalAlignment.Left)
            Next

            Dim rr As DataRow
            For Each rr In dt.Rows
                For col As Integer = 0 To dt.Columns.Count - 1
                    If IsNumeric(rr(col)) Then
                        str(col) = FormatNumber(rr(col), DecPlaces)
                    ElseIf IsDate(rr(col)) And col > 0 Then
                        If DateTimeAsString Then
                            str(col) = rr(col).ToString.Trim
                        Else
                            If DateValue(rr(col)) = CDate("1/1/1900") Then
                                str(col) = FormatDateTime(rr(col), DateFormat.ShortTime)
                            Else
                                str(col) = FormatDateTime(rr(col), DateFormat.ShortDate)
                            End If
                        End If
                    Else
                        str(col) = rr(col).ToString.Trim

                        If rr(col).ToString.Trim Like "<*>" Then
                            str(col) = Mid(str(col), 2, Len(str(col)) - 2)
                        End If
                    End If
                Next

                Dim ii As New ListViewItem(str)

                oLView.Items.Add(ii)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#Region "   System Events"
    Function IsValidEmailFormat(ByVal s As String) As Boolean
        Try
            Dim a As New System.Net.Mail.MailAddress(s)
        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function GenConn(ByVal Server As String, ByVal UserID As String, ByVal Password As String, Optional ByVal InitCatalog As String = "") As String
        Return "Data Source=" & Server & ";Persist Security Info=True;" &
               "User ID=" & UserID & ";Password=" & Password & If(InitCatalog <> "", ";Initial Catalog=" & InitCatalog, "")
    End Function

    Public Sub InitNumText(ByRef oTextBox As TextBox)
        AddHandler oTextBox.KeyPress, AddressOf Numeric_KeyPress
        AddHandler oTextBox.LostFocus, AddressOf Numeric_LostFocus
        AddHandler oTextBox.GotFocus, AddressOf Numeric_GotFocus
    End Sub

    Public Function GetLocalIP(ByVal IPV4 As Boolean) As String
        'Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName)
        Dim ip As String = String.Empty
        For i = 0 To System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList.Length - 1
            If IPV4 Then
                If System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList(i).ToString() Like "*.*" Then
                    ip = System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList(i).ToString()
                    Exit For
                End If
            Else
                If Not (System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList(i).ToString() Like "*.*") Then
                    ip = System.Net.Dns.GetHostEntry(My.Computer.Name).AddressList(i).ToString()
                    Exit For
                End If
            End If
        Next
        Return ip
        'h.AddressList.GetValue(0).ToString.Trim
    End Function

    Public Function GetControlNumber(ByVal TableName As String, ByVal FieldName As String, ByVal DefaultControl As String, Optional ByVal Increment As Boolean = False) As String
        Dim sql As String = GetQuery("Control Number")

        sql = sql.Replace("<?TableName>", TableName)
        sql = sql.Replace("<?FieldName>", FieldName)
        sql = sql.Replace("<?DefaultControl>", ENQ(DefaultControl))

        Dim dt As Object = ExecQuery("", sql)

        If TypeOf dt Is DataTable Then
            Dim RetControl As String

            Dim controlno As String = dt.Rows(0)(0).ToString.Trim

            If Increment Then
                Dim contrlval As Integer = Val(controlno) + 1
                Dim contrllen As Integer = controlno.Length
                Dim vallen As Integer = CStr(contrlval).Trim.Length

                RetControl = controlno.Substring(0, contrllen - vallen) & CStr(contrlval).Trim
            Else
                RetControl = controlno
            End If

            Return RetControl
        Else
            Return "Err: " & dt
        End If
    End Function

    Public Function BatchDate(Optional ByVal EOM As Boolean = False, Optional ByVal SubDay As Integer = 0, Optional ByVal PIPre As String = "-") As String
        Dim vDate As Date = Now.Date.AddDays(-SubDay)

        If PIPre = "M" Or PIPre = "I" Or PIPre = "A" Then
            If vDate.Month <> CurrMonth Then
                vDate = DateAdd(DateInterval.Month, 1, DateSerial(vDate.Year, CurrMonth, 1)).AddDays(-1)

                If vDate > Now.Date Then
                    vDate = DateSerial(vDate.Year - 1, vDate.Month, vDate.Day)
                End If
            End If
        End If

        Dim m As Integer = vDate.Month
        Dim y As Integer = vDate.Year
        Dim d As Integer = IIf(EOM, DateSerial(y, m, 1).AddMonths(1).AddDays(-1).Day, vDate.Day)

        Dim mStr As String = Replace(Space(2 - CStr(m).Trim.Length) & m, " ", "0")
        Dim dStr As String = Replace(Space(2 - CStr(d).Trim.Length) & d, " ", "0")

        Return y & mStr & dStr
    End Function

    Public Function CheckFiscalPeriod(ByVal CurrentYear As Integer, ByVal PeriodID As Integer, ByVal GPModule As String) As Boolean
        Dim retval As Boolean = False
        Try
            Dim sql As String = GetQuery("Check Fiscal Period")

            sql = sql.Replace("<?Year>", NSV(CurrentYear))
            sql = sql.Replace("<?Period>", NSV(PeriodID))

            Dim dt As DataTable = ExecQuery(sql, GenConn(True, "SMPIC", True))

            If dt.Rows.Count > 0 Then
                retval = Not CBool(dt.Rows(0)(GPModule))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return retval
    End Function

    Public Function ExportToExcel(ByVal sql As String, ByVal ExportFileName As String, Optional DBEngine As String = "MYSQL", Optional ByVal ConnStr As String = "", Optional ByVal FilePath As String = "") As String
        Dim i As Integer = 0

        Dim oExcel As Object
        Dim oBook As Object
        Dim oSheet As Object
        Dim eFileName As String = String.Empty

        Dim dt As Object = ExecQuery(DBEngine, sql, ConnStr)

        If TypeOf dt Is DataTable Then
            If dt.Rows.Count > 0 Then
                oExcel = CreateObject("Excel.Application")
                oBook = oExcel.Workbooks.Add
                oSheet = oBook.Worksheets(1)

                For Each oCol As DataColumn In dt.Columns
                    oSheet.Cells(1, i + 1) = oCol.ColumnName
                    oSheet.Cells(1, i + 1).Font.Bold = True
                    i = i + 1
                Next

                Dim ri As Integer = 2

                For Each oRow As DataRow In dt.Rows
                    For i = 0 To dt.Columns.Count - 1
                        oSheet.Cells(ri, i + 1).Value = oRow(i)
                    Next

                    ri += 1
                Next

                eFileName = ExportFileName.Trim & " " & Format(Now, "yyyyMMdd-hhmmss") & ".xlsx"

                oBook.SaveAs(If(FilePath.Trim = "", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), FilePath) & "\" & eFileName)
                'oBook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\DB Monitoring\" & Format(Now.Date, "yyyyMMdd") & "\DB Monitoring " & Format(Now, "yyyyMMddhhmmss") & ".xls")
                oBook.Close()
                oExcel.Quit()

                System.Runtime.InteropServices.Marshal.ReleaseComObject(oSheet)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel)

                oSheet = Nothing
                oBook = Nothing
                oExcel = Nothing

                'MsgBox("Export Complete.", MsgBoxStyle.Information)
                'Process.Start("explorer.exe", Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            Else
                MsgBox("There are no records to be Exported.", MsgBoxStyle.Information)
            End If
        Else
            MsgBox(dt, MsgBoxStyle.Critical)
        End If

        Return eFileName
    End Function
#End Region

#Region "   Input Box"
    Public intInputBoxCancel As Integer                    ' public variable

    Public Function StrPtr(ByVal obj As Object) As Integer
        Dim Handle As GCHandle = GCHandle.Alloc(obj, GCHandleType.Pinned)
        Dim intReturn As Integer = Handle.AddrOfPinnedObject.ToInt32
        Handle.Free()
        Return intReturn
    End Function
#End Region

End Module
