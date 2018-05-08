Imports System.Net
Imports System.Net.Mail

' This class requires System.Web as reference

Public Class clsEmail
    Public ErrStr, Sender, Recipient, CC, BCC, Subject, MsgBody, SMTPServer As String
    Public SMTPUser, SMTPPassword As String
    Public Priority As System.Net.Mail.MailPriority
    Public EMailFormat As MailFormat

    Dim oMsg As System.Net.Mail.MailMessage

    Enum EMailStatus
        Sent = 0
        Failed = 1
    End Enum

    Enum MailFormat
        Text = 0
        Html = 1
    End Enum

    Public Sub New(Optional ByVal oSender As String = "", Optional ByVal oRecipient As String = "", _
    Optional ByVal oCC As String = "", Optional ByVal oBCC As String = "", Optional ByVal oSubject As String = "", _
    Optional ByVal oBody As String = "", Optional ByVal oSMTPServer As String = "", _
    Optional ByVal oPriority As System.Net.Mail.MailPriority = System.Net.Mail.MailPriority.Normal, Optional ByVal oEmailFormat As MailFormat = MailFormat.Text, _
    Optional ByVal oUser As String = "", Optional ByVal oPass As String = "")
        Sender = oSender
        Recipient = oRecipient
        CC = oCC
        BCC = oBCC
        Subject = oSubject
        MsgBody = oBody
        SMTPServer = oSMTPServer
        Priority = oPriority
        EMailFormat = oEmailFormat
        SMTPUser = oUser
        SMTPPassword = oPass
    End Sub

    Public Function AddAttachement(ByVal FileName As String) As EMailStatus
        ErrStr = ""

        Try
            Dim attachedfile As New System.Net.Mail.Attachment(FileName)
            oMsg.Attachments.Add(attachedfile)

            Return EMailStatus.Sent
        Catch ex As Exception
            ErrStr = "An error occured while adding attachment:" & Environment.NewLine & Environment.NewLine & _
                     ex.Message & Environment.NewLine & Environment.NewLine & _
                     "Please contact IT Group to fix the error."

            Return EMailStatus.Failed
        End Try
    End Function

    Public Function InitMail() As EMailStatus
        ErrStr = ""

        Try
            oMsg = New System.Net.Mail.MailMessage
            Dim details As String = String.Empty
            oMsg.From = New MailAddress(Sender)

            If Recipient Like "*;*" Then
                Dim rcp() As String = Recipient.Split(";")

                For Each rc As String In rcp
                    If rc.Trim <> "" Then oMsg.To.Add(New MailAddress(rc))
                Next
            Else
                oMsg.To.Add(New MailAddress(Recipient))
            End If

            If CC.Trim <> "" Then
                If CC Like "*;*" Then
                    Dim vccs() As String = CC.Split(";")

                    For Each vcc As String In vccs
                        If vcc.Trim <> "" Then oMsg.CC.Add(New MailAddress(vcc))
                    Next
                Else
                    oMsg.CC.Add(New MailAddress(CC))
                End If
            End If

            If BCC.Trim <> "" Then
                If BCC Like "*;*" Then
                    Dim vbccs() As String = BCC.Split(";")

                    For Each vbcc As String In vbccs
                        If vbcc.Trim <> "" Then oMsg.Bcc.Add(New MailAddress(vbcc))
                    Next
                Else
                    oMsg.Bcc.Add(New MailAddress(BCC))
                End If
            End If

            'If CC.Trim <> "" Then oMsg.CC.Add(New MailAddress(CC))
            'If BCC.Trim <> "" Then oMsg.Bcc.Add(New MailAddress(BCC))
            oMsg.Subject = Subject
            oMsg.Priority = Priority
            oMsg.IsBodyHtml = CBool(EMailFormat)
            oMsg.Body = MsgBody

            'SmtpMail.SmtpServer = SMTPServer
            'SmtpMail.Send(oMsg)

            Return EMailStatus.Sent
        Catch ex As Exception
            ErrStr = "An error occured while initializing email:" & Environment.NewLine & Environment.NewLine & _
                     ex.Message & Environment.NewLine & Environment.NewLine & _
                     "Please contact IT Group to fix the error."

            Return EMailStatus.Failed
        End Try
    End Function

    Public Function Send() As EMailStatus
        ErrStr = ""

        Try
            Dim emailClient As New SmtpClient(SMTPServer)

            If SMTPUser.Trim = "" Then
                emailClient.UseDefaultCredentials = False
            Else
                emailClient.Credentials = New NetworkCredential(SMTPUser, SMTPPassword)
                emailClient.Timeout = 20000
            End If

            emailClient.Send(oMsg)

            oMsg = Nothing

            Return EMailStatus.Sent
        Catch ex As Exception
            ErrStr = "An error occured while sending email:" & Environment.NewLine & Environment.NewLine & _
                     ex.Message & Environment.NewLine & Environment.NewLine & _
                     "Please contact IT Group to fix the error."

            Return EMailStatus.Failed
        End Try
    End Function
End Class
