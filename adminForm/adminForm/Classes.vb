Imports System.IO.Ports
Imports System.Threading

Public Module Classes
    Public Class MyUser
        Property ID As Integer
        Property Username As String
        Property Password As String
        Property Fullname As String
        Property Address As String
        Property Contact As String
        Property Email As String
        Property Role As String
        Property Status As String
        Sub New()

        End Sub
    End Class

    Public Class MyEvent
        Property GuestsID As Integer
        Property Registered As Integer
        Property Name As String
        Property [Date] As String
        Property Time As String
        Property Type As String
        Property IsPaid As Boolean
        Property Booker As String
        Sub New()

        End Sub
    End Class

    Public Class MyGuest
        Property ID As Integer
        Property GuestID As Integer
        Property Logs As String
        Property RFID As String
        Property Name As String
        Property Address As String
        Property Email As String
        Property Number As String
        Property Type As String
        Sub New()

        End Sub
    End Class

    Public Class MyMD5
        Property ID As Integer
        Property Hash As String
        Property EventName As String
        Sub New()

        End Sub
    End Class

    Public Class MyTemporaryCopy
        Property ID As Integer
        Property EventName As String
        Property GuestJSON As String
        Sub New()

        End Sub
    End Class

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
                .BaudRate = 115200
                .Parity = Parity.None
                .ReadBufferSize = 1024
                .WriteTimeout = 1024
                .WriteBufferSize = 1024
                .DataBits = 8
                .StopBits = StopBits.One
                .Handshake = Handshake.None
                .DtrEnable = True
                .RtsEnable = True
                .NewLine = vbCrLf
            End With
        End Sub
        Public Sub SendSMS(ByVal eventName As String, ByVal eventDate As String, ByVal eventTime As String, ByVal receiver As String)
            If SMSPort.IsOpen = True Then
                'sending AT commands
                SMSPort.Write("AT&F" & vbCrLf)
                Thread.Sleep(200)
                SMSPort.Write("AT+CSCS=""GSM""" & vbCrLf)
                Thread.Sleep(200)
                SMSPort.Write("AT+CMGF=1" & vbCrLf) 'set command message format to text mode(1)
                Thread.Sleep(200)
                SMSPort.Write("AT+CSCA=""09170000130""" & vbCrLf) 'set service center address (which varies for service providers (idea, airtel))
                Thread.Sleep(200)
                SMSPort.Write($"AT+CMGS=""{receiver}""" & vbCrLf) ' enter the mobile number whom you want to send the SMS
                _ContSMS = False
                Thread.Sleep(200)
                SMSPort.Write($"Just a reminder for the upcoming {eventName} on {eventDate} {eventTime}. Don't forget to bring your RFID WRISTBAND. See you!" & vbCrLf & Chr(26)) 'SMS sending
                Thread.Sleep(200)
            End If
        End Sub

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
End Module
