Imports System.Net.Mail
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.IO.Ports

Module Functions
    'Declaring DB-related variables
    Public str As String = "server=localhost; uid=root; pwd=; database=real_capstone"
    Public con As New MySqlConnection(str)

    Dim smsEngine As New SMSCOMMS("COM3")

    'Home Functions
    Public Sub changeColor(ByVal tochange As Button, ByVal stay1 As Button)
        tochange.BackColor = Color.White
        stay1.BackColor = Color.WhiteSmoke
    End Sub

    Public Sub showThis(ByVal sender As Object, ByVal container As Panel, ByVal toShow As Form)
        With toShow
            .TopLevel = False
            container.Controls.Add(toShow)
            .BringToFront()
            .Show()
        End With
    End Sub

    'Events Backend Functions
    Sub sendEmail(ByVal eventName As String, ByVal eventDetails As String(), ByVal sender As String, ByVal pass As String, ByVal receiver As String)
        Try
            Dim server As New SmtpClient
            Dim mail As New System.Net.Mail.MailMessage()
            server.UseDefaultCredentials = False
            server.Credentials = New Net.NetworkCredential(sender, pass)
            server.Port = 587
            server.EnableSsl = True
            server.Host = "smtp.gmail.com"

            mail = New System.Net.Mail.MailMessage()
            mail.From = New MailAddress(sender)
            mail.To.Add(receiver)
            mail.Subject = $"REMINDER FOR THE UPCOMING {eventName}"
            mail.IsBodyHtml = False
            mail.Body = $"We are here to remind you for the upcoming {eventName} on {eventDetails(0)} {eventDetails(1)}. Don't forget to bring your RFID WRISTBAND. See you!"
            server.Send(mail)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Public Sub sendEmailAndMessagesAsync(ByVal eventName As String, ByVal eventDetails As String(), ByVal table As DataSet)
        Thread.Sleep(5000)
        For i As Integer = 0 To table.Tables(0).Rows.Count - 1
            Dim receiverEmail As String = table.Tables(0).Rows(i)(0)
            Dim receiverNumber As String = table.Tables(0).Rows(i)(1)
            Dim name As String = table.Tables(0).Rows(i)(2)



            eventsBackEnd.Invoke(Sub()
                                     eventsBackEnd.TextBox1.Text += $"Sending email to {name}...   "
                                 End Sub)

            sendEmail(eventName, eventDetails, "mjbrcns51@gmail.com", "tkzoblulgmuleflh", receiverEmail)

            smsEngine.Open()
            smsEngine.SendSMS(eventName, eventDetails, receiverNumber)


            eventsBackEnd.Invoke(Sub()
                                     eventsBackEnd.TextBox1.Text += $"Done!{Environment.NewLine}"
                                 End Sub)
        Next
    End Sub
End Module

Public Class SMSCOMMS
    Private WithEvents SMSPort As SerialPort
    Private SMSThread As Thread
    Private ReadThread As Thread
    Shared _Continue As Boolean = False
    Shared _ContSMS As Boolean = False
    Private _Wait As Boolean = False
    Shared _ReadPort As Boolean = False
    Public Event Sending(ByVal Done As Boolean)
    Public Event DataReceived(ByVal Message As String)

    Public Sub New(ByRef COMMPORT As String)
        'initialize all values
        SMSPort = New SerialPort
        With SMSPort
            .PortName = COMMPORT
            .BaudRate = 9600
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
        End With
    End Sub
    Public Function SendSMS(ByVal eventName As String, ByVal eventDetails As String(), ByVal receiver As String) As Boolean
        If SMSPort.IsOpen = True Then
            'sending AT commands
            SMSPort.WriteLine("AT")
            Thread.Sleep(100)
            SMSPort.WriteLine("AT+CMGF=1" & vbCrLf) 'set command message format to text mode(1)
            Thread.Sleep(100)
            SMSPort.WriteLine("AT+CSCA=""09170000130""" & vbCrLf) 'set service center address (which varies for service providers (idea, airtel))
            Thread.Sleep(100)
            SMSPort.WriteLine($"AT+CMGS=""{receiver}""" & vbCrLf) ' enter the mobile number whom you want to send the SMS
            _ContSMS = False
            Thread.Sleep(100)
            SMSPort.WriteLine($"We are here to remind you for the upcoming {eventName} on {eventDetails(0)} {eventDetails(1)}. Don't forget to bring your RFID WRISTBAND. See you!" & vbCrLf & Chr(26)) 'SMS sending
            Thread.Sleep(100)
            SMSPort.Close()
        End If
    End Function

    Public Sub Open()
        If Not (SMSPort.IsOpen = True) Then
            SMSPort.Open()
        End If
    End Sub

    Public Sub Close()
        If SMSPort.IsOpen = True Then
            SMSPort.Close()
        End If
    End Sub
End Class
