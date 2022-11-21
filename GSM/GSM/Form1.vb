Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim sp As SerialPort = New SerialPort()
        'sp.PortName = "COM3"
        'sp.Open()
        'sp.WriteLine($"AT+CMGF=1 {Environment.NewLine()}")
        'Thread.Sleep(100)
        'sp.WriteLine($"AT+CSMP? {Environment.NewLine()}")
        'Thread.Sleep(100)

        'Dim response = sp.ReadExisting()
        'MessageBox.Show(response)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim sp As SerialPort = New SerialPort()
        'sp.PortName = "COM3"
        'sp.Open()
        'sp.WriteLine($"AT {Environment.NewLine()}")
        'Thread.Sleep(100)
        'sp.WriteLine($"AT+CMGF=1 {Environment.NewLine()}")
        'Thread.Sleep(100)
        'sp.WriteLine($"AT+CSCA=""09170000130"" {Environment.NewLine()}")
        'Thread.Sleep(100)
        ''sp.WriteLine($"AT+CSCS=""GSM""{Environment.NewLine()}")
        ''Thread.Sleep(100)
        'sp.WriteLine($"AT+CMGS=""{TextBox1.Text}"" {Environment.NewLine()}")
        'Thread.Sleep(100)
        'sp.WriteLine($"{TextBox2.Text}{Environment.NewLine}")
        'Thread.Sleep(100)
        'Dim bytes(26) As Byte
        'sp.Write(bytes, 0, 1)
        'Thread.Sleep(100)

        'Dim response = sp.ReadExisting()
        'MessageBox.Show(response)

        'If response.Contains("ERROR") Then
        '    MessageBox.Show("Failed")
        'Else
        '    MessageBox.Show("Success")
        'End If

        'sp.Close()

        Dim smsEngine As New SMSCOMMS("COM3")

        smsEngine.Open()
        smsEngine.SendSMS()

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
    Public Function SendSMS() As Boolean
        If SMSPort.IsOpen = True Then
            'sending AT commands
            SMSPort.WriteLine("AT")
            Thread.Sleep(100)
            SMSPort.WriteLine("AT+CMGF=1" & vbCrLf) 'set command message format to text mode(1)
            Thread.Sleep(100)
            SMSPort.WriteLine("AT+CSCA=""09170000130""" & vbCrLf) 'set service center address (which varies for service providers (idea, airtel))
            Thread.Sleep(100)
            SMSPort.WriteLine($"AT+CMGS=""09366296799""" & vbCrLf) ' enter the mobile number whom you want to send the SMS
            _ContSMS = False
            Thread.Sleep(100)
            SMSPort.WriteLine("HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE HERE" & vbCrLf & Chr(26)) 'SMS sending
            Thread.Sleep(100)
            Dim response = SMSPort.ReadExisting()
            MessageBox.Show(response)
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
