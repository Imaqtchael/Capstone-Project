Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Thread
Imports MySql.Data.MySqlClient
Imports System.Net.WebClient
Imports System.Net

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

        downloadRemoteDBToLocal()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        updateRemoteDB()
        deleteLocalDB()
        downloadRemoteDBToLocal()
    End Sub

    Private Sub downloadRemoteDBToLocal()
        'Download the remote database
        Dim remoteURI = "https://event-venue.website/includes/downloadSQL.php"
        Dim fileName = "D:\Downloads\local_copy.sql" 'change this in your code

        Dim client As New WebClient()

        client.DownloadFile(remoteURI, fileName)

        'Create a blank database in localhost
        Dim connectionString = "server=localhost;uid=root;pwd="
        Dim connection = New MySqlConnection(connectionString)

        Dim createDB = "CREATE DATABASE local_copy"
        Dim testCommand = New MySqlCommand(createDB, connection)

        connection.Open()
        testCommand.ExecuteNonQuery()
        connection.Close()

        'Insert the data from the download remote database
        'to the blank database in localhost and add an
        ''edited' field on each table. This 'edited' field
        'will tell us later on what fields are edited locally
        connectionString = "server=localhost;uid=root;pwd=;database=local_copy"
        connection.ConnectionString = connectionString
        Dim sqlFile = "D:\Downloads\local_copy.sql"
        Dim createEditedField = "ALTER TABLE `admin` ADD `edited` BOOLEAN NOT NULL AFTER `status`;ALTER TABLE `events` ADD `edited` BOOLEAN NOT NULL AFTER `booker`;ALTER TABLE `guest` ADD `edited` BOOLEAN NOT NULL AFTER `type`;"
        Dim sqlText = $"{File.ReadAllText(sqlFile)}{Environment.NewLine}{createEditedField}"

        Dim sqlCommand = New MySqlCommand(sqlText, connection)

        connection.Open()
        sqlCommand.ExecuteNonQuery()
        connection.Close()
    End Sub

    Private Sub deleteLocalDB()
        Dim connectionString = "server=localhost;uid=root;pwd="
        Dim connection = New MySqlConnection(connectionString)

        Dim deleteDB = "DROP DATABASE local_copy"
        Dim testCommand = New MySqlCommand(deleteDB, connection)

        connection.Open()
        testCommand.ExecuteNonQuery()
        connection.Close()

    End Sub
    Private Sub updateRemoteDB()
        Dim dataTables() As String = {"admin", "events", "guest"}

        Dim localConnectionString = $"server=localhost;uid=root;pwd=;database=local_copy"
        Dim localConnection = New MySqlConnection(localConnectionString)

        Dim getEditedTables = $"SELECT * FROM admin WHERE edited=true;SELECT * FROM events WHERE edited=true;SELECT * FROM guest WHERE edited=true"
        Dim adapter As New MySqlDataAdapter(getEditedTables, localConnection)
        Dim editedTables As New DataSet()
        adapter.Fill(editedTables)

        Dim remoteConnectionString = $"server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
        Dim remoteConnection = New MySqlConnection(remoteConnectionString)
        Dim updateQuery As String = ""

        'Loop through the dataTables
        For i As Integer = 0 To dataTables.Length - 1


            'Loop through the edited localDataTables
            For j As Integer = 0 To editedTables.Tables(i).Rows.Count - 1
                If dataTables(i) = "admin" Then
                    Dim id = editedTables.Tables(0).Rows(j)(0)
                    Dim username = editedTables.Tables(0).Rows(j)(1)
                    Dim password = editedTables.Tables(0).Rows(j)(2)
                    Dim fullname = editedTables.Tables(0).Rows(j)(3)
                    Dim address = editedTables.Tables(0).Rows(j)(4)
                    Dim contact = editedTables.Tables(0).Rows(j)(5)
                    Dim email = editedTables.Tables(0).Rows(j)(6)
                    Dim role = editedTables.Tables(0).Rows(j)(7)

                    updateQuery += $"UPDATE admin SET username='{username}', password='{password}', fullname='{fullname}', address='{address}', contact='{contact}', email='{email}', role='{role}' WHERE id={id};"
                ElseIf dataTables(i) = "events" Then
                    Dim guests_id = editedTables.Tables(1).Rows(j)(0)
                    Dim registered = editedTables.Tables(1).Rows(j)(1)
                    Dim name = editedTables.Tables(1).Rows(j)(2)
                    Dim event_date = editedTables.Tables(1).Rows(j)(3)
                    Dim event_time = editedTables.Tables(1).Rows(j)(4)
                    Dim type = editedTables.Tables(1).Rows(j)(5)
                    Dim ispaid = editedTables.Tables(1).Rows(j)(6)
                    Dim booker = editedTables.Tables(1).Rows(j)(7)

                    updateQuery += $"UPDATE events SET registered='{registered}', name='{name}', date='{event_date}', time='{event_time}', type='{type}', ispaid='{ispaid}', booker='{booker}' WHERE guests_id={guests_id};"
                ElseIf dataTables(i) = "guest" Then
                    Dim id = editedTables.Tables(2).Rows(j)(0)
                    Dim guest_id = editedTables.Tables(2).Rows(j)(1)
                    Dim logs = editedTables.Tables(2).Rows(j)(2)
                    Dim rfid = editedTables.Tables(2).Rows(j)(3)
                    Dim name = editedTables.Tables(2).Rows(j)(4)
                    Dim address = editedTables.Tables(2).Rows(j)(5)
                    Dim email = editedTables.Tables(2).Rows(j)(6)
                    Dim number = editedTables.Tables(2).Rows(j)(7)

                    updateQuery += $"UPDATE guest SET guest_id='{guest_id}', logs='{logs}', rfid='{rfid}', name='{name}', address='{address}', email='{email}', number='{number}' WHERE id={id};"
                End If

            Next
        Next

        'Leave if there's no changes from the database
        If updateQuery.Length = 0 Then
            Return
        End If

        Dim remoteCommand As MySqlCommand
        remoteConnection.Open()
        remoteCommand = remoteConnection.CreateCommand()
        remoteCommand.CommandText = updateQuery
        remoteCommand.ExecuteNonQuery()
        remoteConnection.Close()
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
