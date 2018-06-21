Namespace Automation

    Public Class SmtpDetails
        Private _smtpServer As String
        Public Property SmtpServer() As String
            Get
                Return _smtpServer
            End Get
            Set(ByVal value As String)
                _smtpServer = value
            End Set
        End Property

        Private _smtpUserName As String
        Public Property SmtpUserName() As String
            Get
                Return _smtpUserName
            End Get
            Set(ByVal value As String)
                _smtpUserName = value
            End Set
        End Property

        Private _smtpPassword As String
        Public Property SmtpPassword() As String
            Get
                Return _smtpPassword
            End Get
            Set(ByVal value As String)
                _smtpPassword = value
            End Set
        End Property

        Private _smtpUseCredentials As Boolean
        Public Property SmtpUseCredentials() As Boolean
            Get
                Return _smtpUseCredentials
            End Get
            Set(ByVal value As Boolean)
                _smtpUseCredentials = value
            End Set
        End Property

        Public Sub New()
            _smtpServer = ""
            _smtpUserName = ""
            _smtpPassword = ""
            _smtpUseCredentials = False
        End Sub

    End Class

    Public Class Email
        Private _sender As String
        Public Property Sender() As String
            Get
                Return _sender
            End Get
            Set(ByVal value As String)
                _sender = value
            End Set
        End Property

        Private _recipients As Net.Mail.MailAddressCollection
        Public Property Recipients() As Net.Mail.MailAddressCollection
            Get
                Return _recipients
            End Get
            Set(ByVal value As Net.Mail.MailAddressCollection)
                _recipients = value
            End Set
        End Property

        Private _cc As Net.Mail.MailAddressCollection
        Public Property CC() As Net.Mail.MailAddressCollection
            Get
                Return _cc
            End Get
            Set(ByVal value As Net.Mail.MailAddressCollection)
                _cc = value
            End Set
        End Property

        Private _bcc As Net.Mail.MailAddressCollection
        Public Property BCC() As Net.Mail.MailAddressCollection
            Get
                Return _bcc
            End Get
            Set(ByVal value As Net.Mail.MailAddressCollection)
                _bcc = value
            End Set
        End Property

        Private _subject As String
        Public Property Subject() As String
            Get
                Return _subject
            End Get
            Set(ByVal value As String)
                _subject = value
            End Set
        End Property

        Private _priority As Net.Mail.MailPriority
        Public Property Priority() As String
            Get
                Return _priority
            End Get
            Set(ByVal value As String)
                _priority = value
            End Set
        End Property


        Private _body As String
        Public Property Body() As String
            Get
                Return _body
            End Get
            Set(ByVal value As String)
                _body = value
            End Set
        End Property

        Private _isBodyHtml As Boolean
        Public Property IsBodyHtml() As String
            Get
                Return _isBodyHtml
            End Get
            Set(ByVal value As String)
                _isBodyHtml = value
            End Set
        End Property

        Public Sub New()
            _recipients = New Net.Mail.MailAddressCollection
            _cc = New Net.Mail.MailAddressCollection
            _bcc = New Net.Mail.MailAddressCollection
        End Sub

        Public Sub SendEmail(ByVal smtpDetails As SmtpDetails)
            Dim smtpClient As New System.Net.Mail.SmtpClient
            Dim mail As New System.Net.Mail.MailMessage
            Try
                mail.From = New Net.Mail.MailAddress(_sender)
                For Each address As Net.Mail.MailAddress In _recipients
                    mail.To.Add(address)
                Next
                For Each ccAddress As Net.Mail.MailAddress In _cc
                    mail.CC.Add(ccAddress)
                Next
                For Each bccAddress As Net.Mail.MailAddress In _bcc
                    mail.Bcc.Add(bccAddress)
                Next

                mail.Subject = _subject
                mail.Priority = _priority
                mail.Body = _body
                mail.IsBodyHtml = _isBodyHtml

                If smtpDetails.SmtpUseCredentials Then
                    smtpClient.UseDefaultCredentials = True
                    smtpClient.Credentials = New System.Net.NetworkCredential(smtpDetails.SmtpUserName, smtpDetails.SmtpPassword)
                End If

                smtpClient.Host = smtpDetails.SmtpServer
                smtpClient.Send(mail)

            Catch ex As Exception
                Throw
            Finally
                mail.Dispose()
                smtpClient.Dispose()
            End Try
        End Sub

    End Class

End Namespace
