Imports System.Threading
Imports System.IO.Ports
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class login
    Public allTabDataSet As DataSet
    Public currentUser(1) As String

    'Checking if there are admin user that has previously logged in
    'and just continue to the home form
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Create a local copy of the data from remote database
        'Await Task.Run(Sub() downloadRemoteDB("local_copy"))
        'Await Task.Run(Sub() refreshLocalDB("local_copy"))

        'Dim checkFirst = Await Task.Run(Function() getAllData())
        'While checkFirst Is Nothing
        '    checkFirst = Await Task.Run(Function() getAllData())
        'End While
        'allTabDataSet = checkFirst

        allTabDataSet = Await Task.Run(Function() getAllData())

        Button1.Enabled = True

        If My.Computer.FileSystem.ReadAllText("..\..\..\REMEMBERED.txt").Length < 1 Then
            Return
        End If

        currentUser = Split(My.Computer.FileSystem.ReadAllText("..\..\..\REMEMBERED.txt"), ", ")
        If currentUser.Length > 0 Then
            showHome()
        End If
    End Sub

    'Check the current date, if there is an event in the current date
    'send an sms message and email to the booker of the event
    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim dateNow = Now.ToString("MM/dd/yyyy")

        Dim eventQuery As String = $"SELECT guests_id, name, date, time FROM events WHERE Date='{dateNow}' AND registered=1 AND ispaid=1"
        Dim eventDataSet As DataSet = Await Task.Run(Function() getData(eventQuery))

        If eventDataSet.Tables(0).Rows.Count = 0 Then
            Return
        End If

        Timer1.Stop()
        Timer1.Enabled = False
        Timer2.Enabled = True

        Dim guestsID As String = eventDataSet.Tables(0).Rows(0)(0)
        Dim eventName As String = eventDataSet.Tables(0).Rows(0)(1)
        Dim eventDate As String = eventDataSet.Tables(0).Rows(0)(2)
        Dim eventTime As String = eventDataSet.Tables(0).Rows(0)(3)

        Dim guestQuery As String = $"SELECT email, number, name FROM guest WHERE guest_id={guestsID}"
        Dim guestDataSet As DataSet = Await Task.Run(Function() getData(guestQuery))

        'Dim numbers As String = ""

        Dim smsEngine As New SMSCOMMS("COM13")
        smsEngine.Open()

        Await Task.Run(Sub()
                           For i As Integer = 0 To guestDataSet.Tables(0).Rows.Count - 1
                               Dim receiverEmail As String = guestDataSet.Tables(0).Rows(i)(0)
                               Dim receiverNumber As String = guestDataSet.Tables(0).Rows(i)(1)
                               Dim name As String = guestDataSet.Tables(0).Rows(i)(2)
                               Dim emailSubject As String = "no reply"
                               Dim emailBody As String = $"<div style='background-color: #252e42; width: 70%; padding: 10px 50px; border-radius: 5px'><center> <h1 style='color: white; background-color: #31394d; padding: 10px; border-radius: 5px'> Event Venue Online Booking </h1></center> <p style='color: white; font-size: 18px;'>Dear our beloved guest, </p><p style='color: white; font-size: 14px;'>Just a reminder for the upcoming {eventName} on {eventDate} {eventTime}. Don't forget to bring your <b>RFID WRISTBAND</b>. See you! </p></div>"

                               sendEmail(emailSubject, emailBody, "van@event-venue.website", "@Capstone0330", receiverEmail, True)


                               smsEngine.SendSMS(eventName, eventDate, eventTime, receiverNumber)
                               Thread.Sleep(8000)


                               'Thread.Sleep(5000)
                               'SendSMS("COM12", eventName, eventDate, eventTime, receiverNumber)

                               'numbers += $"{receiverNumber},"

                           Next
                       End Sub)
        'numbers = numbers.Substring(0, numbers.Length - 1)

        'sendMessage($"Just a reminder for the upcoming {eventName} on {eventDate} {eventTime}. Don't forget to bring your RFID WRISTBAND. See you!", numbers)
        smsEngine.Close()

        Dim updateQuery As String = $"UPDATE events SET registered=2 WHERE guests_id={guestsID}"
        Await Task.Run(Sub() executeNonQuery(updateQuery, remoteConnection))
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer1.Enabled = True
        Timer1.Start()
        Timer2.Stop()
        Timer2.Enabled = False
    End Sub

    Public Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        refreshAllForms()
    End Sub

    Public Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Timer4.Enabled = False
    End Sub

    Sub apacheMySQLRun()
        Dim apacheRunning As Boolean = (Process.GetProcessesByName("httpd").Length > 0)
        Dim mysqlRunning As Boolean = (Process.GetProcessesByName("mysqld").Length > 0)

        If Not (apacheRunning And mysqlRunning) Then
            Shell("C:\xampp\apache\bin\httpd.exe", AppWinStyle.Hide)

            ' Wait for the Apache server to start
            Thread.Sleep(5000)

            ' Start the MySQL server
            Shell("C:\xampp\mysql\bin\mysqld.exe", AppWinStyle.Hide)
        End If
    End Sub

    Public Async Sub refreshAllForms()
        'If Timer4.Enabled Then
        '    Return
        'End If

        'Await Task.Run(Sub() updateRemoteDB())
        'Await Task.Run(Sub() downloadRemoteDB("local_copy"))
        'Await Task.Run(Sub() refreshLocalDB("local_copy"))

        'Dim checkFirst = Await Task.Run(Function() getAllData())
        'While checkFirst Is Nothing
        '    checkFirst = Await Task.Run(Function() getAllData())
        'End While
        'allTabDataSet = checkFirst

        allTabDataSet = Await Task.Run(Function() getAllData())

        If Not trackingReport Is Nothing Then
            trackingReport.trackingReport_Load(Nothing, Nothing)
        End If

        If Not guestManagement Is Nothing Then
            guestManagement.guestManagement_Load(Nothing, Nothing)
        End If

        If Not eventManagement Is Nothing Then
            eventManagement.eventManagement_Load(Nothing, Nothing)
        End If
        If Not userManagement Is Nothing Then
            userManagement.userManagement_Load(Nothing, Nothing)
        End If
        'Timer4.Enabled = True
    End Sub

    'Login the admin if the credentials are correct, and check if they
    'preferred to be remembered
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Dim query As String = "SELECT username, password, role, fullname, status FROM admin"
        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        'While ds Is Nothing
        '    ds = Await Task.Run(Function() getData("SELECT username, password, role, fullname, status FROM admin"))
        'End While

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim username As String = ds.Tables(0).Rows(i)(0)
            Dim password As String = ds.Tables(0).Rows(i)(1)
            Dim status As String = ds.Tables(0).Rows(i)(4)
            If TextBox1.Text = username And TextBox2.Text = password Then

                If status = "INACTIVE" Then
                    MessageBox.Show("This account is inactive")
                    Button1.Enabled = True
                    Return
                End If

                currentUser(1) = ds.Tables(0).Rows(i)(2)
                currentUser(0) = ds.Tables(0).Rows(i)(3)

                If CheckBox1.Checked = True Then
                    My.Computer.FileSystem.WriteAllText(
                "..\..\..\REMEMBERED.txt", $"{currentUser(0)}, {ds.Tables(0).Rows(i)(2)}", False)
                End If

                showHome()

                Button1.Enabled = True
                Return
            End If
        Next
        MessageBox.Show($"Wrong username or password")
        Button1.Enabled = True

    End Sub

    'Just clearing the admin user credentials and uncheck the 'remember me' checkbox
    'Hiding the login form and showing the home form if it is previously used else
    'create an object with it and show it
    Private Sub showHome()
        TextBox1.Clear()
        TextBox2.Clear()
        CheckBox1.Checked = False
        Me.Hide()
        If home Is Nothing Then
            home.ShowDialog()
        Else
            If Not currentUser(1) = "EVENT MANAGER" Then
                home.Button4.Enabled = False
                home.Button2.Enabled = False
                home.Button3.Enabled = False
            Else
                home.Button4.Enabled = True
                home.Button2.Enabled = True
                home.Button3.Enabled = True
            End If
            home.Show()
        End If
    End Sub

    Sub sendMessage(ByVal message As String, ByVal numbers As String)
        ' Open a serial port connection to the GSM module
        Using serialPort As New SerialPort("COM11", 9600, Parity.None, 8, StopBits.One)
            serialPort.Open()

            ' Set the recipients for the SMS message
            serialPort.WriteLine($"AT+CMGS=""{numbers}""")

            ' Wait for a response from the GSM module
            Dim response As String = serialPort.ReadLine()
            If response <> "> " Then
                MessageBox.Show("Unable to connect to GSM module")
                Return
            End If

            ' Enter the message text
            serialPort.WriteLine(message)

            ' Send the SMS message
            serialPort.Write(Chr(26))

            ' Wait for a response from the GSM module
            response = serialPort.ReadLine()
            If Not response.StartsWith("+CMGS") Then
                ' An error occurred, handle it here
                ' ...
                MessageBox.Show("Unable to send message")
            End If
        End Using

    End Sub

    Private Sub downloadRemoteDB(ByVal DBName As String)
        'Download the remote database
        Dim remoteURI = "https://event-venue.website/includes/downloadSQL.php"
        Dim fileName = $"..\..\..\SQL\{DBName}.sql" 'change this in your code

        Dim client As New WebClient()

        client.DownloadFile(remoteURI, fileName)

    End Sub

    'Recreate the local database with the downloaded data from the remote database
    Private Sub refreshLocalDB(ByVal DBName As String)

        'Create a blank database in localhost
        Dim connectionString = "server=localhost;uid=root;pwd="
        Dim connection = New MySqlConnection(connectionString)

        Dim dropLocalCopy = "DROP DATABASE IF EXISTS local_copy;"
        Dim createDB = $"{dropLocalCopy}CREATE DATABASE {DBName}"
        Dim testCommand = New MySqlCommand(createDB, connection)

        Dim locallyConnected = False
        While Not locallyConnected
            Try
                connection.Open()
                testCommand.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception

            End Try
            connection.Close()
            locallyConnected = True
        End While


        'Insert the data from the download remote database
        'to the blank database in localhost and add an
        ''edited' field on each table. This 'edited' field
        'will tell us later on what fields are edited locally
        connectionString = $"server=localhost;uid=root;pwd=;database={DBName}"
        connection.ConnectionString = connectionString
        Dim sqlFile = $"..\..\..\SQL\{DBName}.sql"
        Dim createEditedField = "ALTER TABLE `admin` ADD `edited` INT NOT NULL DEFAULT '0' AFTER `status`;ALTER TABLE `events` ADD `edited` INT NOT NULL DEFAULT '0' AFTER `booker`;ALTER TABLE `guest` ADD `edited` INT NOT NULL DEFAULT '0' AFTER `type`;"
        Dim sqlText = $"{File.ReadAllText(sqlFile)}{Environment.NewLine}{createEditedField}"

        Dim sqlCommand = New MySqlCommand(sqlText, connection)

        Dim remotelyConnected = False
        While Not remotelyConnected
            Try
                connection.Open()
                sqlCommand.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception

            End Try
            remotelyConnected = True
        End While
    End Sub

    'Delete local database, especially used with closing the form
    Private Sub deleteLocalDB()
        Dim connectionString = "server=localhost;uid=root;pwd="
        Dim connection = New MySqlConnection(connectionString)

        Dim deleteDB = "DROP DATABASE local_copy"
        Dim testCommand = New MySqlCommand(deleteDB, connection)

        Dim locallyConnected = False
        While Not locallyConnected
            Try
                connection.Open()
                testCommand.ExecuteNonQuery()
                connection.Close()
            Catch ex As Exception

            End Try
            locallyConnected = True
        End While
    End Sub

    'Update the remote database with the values from the local database
    Private Sub updateRemoteDB()
        Dim dataTables() As String = {"admin", "events", "guest"}

        Dim localConnectionString = $"server=localhost;uid=root;pwd=;database=local_copy"
        Dim localConnection = New MySqlConnection(localConnectionString)

        Dim getEditedTables = $"SELECT * FROM admin WHERE edited<>0;SELECT * FROM events WHERE edited<>0;SELECT * FROM guest WHERE edited<>0"
        Dim adapter As New MySqlDataAdapter(getEditedTables, localConnection)
        Dim editedTables As New DataSet()
        adapter.Fill(editedTables)

        Dim remoteConnectionString = $"server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
        Dim remoteConnection = New MySqlConnection(remoteConnectionString)
        Dim updateQuery As String = ""

        If editedTables.Tables(0).Rows.Count + editedTables.Tables(1).Rows.Count + editedTables.Tables(2).Rows.Count = 0 Then
            Return
        End If

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
                    Dim editORInsert = Integer.Parse(editedTables.Tables(0).Rows(j)(9))

                    If editORInsert = 1 Then
                        updateQuery += $"UPDATE admin SET username='{username}', password='{password}', fullname='{fullname}', address='{address}', contact='{contact}', email='{email}', role='{role}' WHERE id={id};"
                    ElseIf editORInsert = 2 Then
                        updateQuery += $"INSERT INTO admin(username, password, fullname, address, contact, email, role) VALUES('{username}', '{password}', '{fullname}', '{address}', '{contact}', '{email}', '{role}');"
                    End If

                ElseIf dataTables(i) = "events" Then
                    Dim guests_id = editedTables.Tables(1).Rows(j)(0)
                    Dim registered = editedTables.Tables(1).Rows(j)(1)
                    Dim name = editedTables.Tables(1).Rows(j)(2).ToString().Replace("'", "\'")
                    Dim event_date = editedTables.Tables(1).Rows(j)(3)
                    Dim event_time = editedTables.Tables(1).Rows(j)(4)
                    Dim type = editedTables.Tables(1).Rows(j)(5)
                    Dim ispaid = editedTables.Tables(1).Rows(j)(6)
                    Dim booker = editedTables.Tables(1).Rows(j)(7)
                    Dim editORInsert = Integer.Parse(editedTables.Tables(1).Rows(j)(8))

                    If editORInsert = 1 Then
                        updateQuery += $"UPDATE events SET registered={registered}, name='{name}', date='{event_date}', time='{event_time}', type='{type}', ispaid={ispaid}, booker='{booker}' WHERE guests_id={guests_id};"
                    ElseIf editORInsert = 2 Then
                        updateQuery += $"INSERT INTO events(registered, name, date, time, type, ispaid, booker) VALUES({registered}, '{name}', '{event_date}', '{event_time}', '{type}', {ispaid}, '{booker}');"
                    End If

                ElseIf dataTables(i) = "guest" Then
                    Dim id = editedTables.Tables(2).Rows(j)(0)
                    Dim guest_id = editedTables.Tables(2).Rows(j)(1)
                    Dim logs = editedTables.Tables(2).Rows(j)(2)
                    Dim rfid = editedTables.Tables(2).Rows(j)(3)
                    Dim name = editedTables.Tables(2).Rows(j)(4)
                    Dim address = editedTables.Tables(2).Rows(j)(5)
                    Dim email = editedTables.Tables(2).Rows(j)(6)
                    Dim number = editedTables.Tables(2).Rows(j)(7)
                    Dim type = editedTables.Tables(2).Rows(j)(8)
                    Dim editORInsert = Integer.Parse(editedTables.Tables(2).Rows(j)(9))

                    If editORInsert = 1 Then
                        updateQuery += $"UPDATE guest SET guest_id={guest_id}, logs='{logs}', rfid='{rfid}', name='{name}', address='{address}', email='{email}', number='{number}' WHERE id={id};"
                    ElseIf editORInsert = 2 Then
                        updateQuery += $"INSERT INTO guest(guest_id, logs, rfid, name, address, email, number, type) VALUES({guest_id}, '{logs}', '{rfid}', '{name}', '{address}', '{email}', '{number}', '{type}');"
                    End If

                End If

            Next
        Next

        Dim remoteCommand As MySqlCommand

        Dim remotelyConnected = False
        While Not remotelyConnected
            Try
                remoteConnection.Open()
                remoteCommand = remoteConnection.CreateCommand()
                remoteCommand.CommandText = updateQuery
                remoteCommand.ExecuteNonQuery()
                remoteConnection.Close()
                remotelyConnected = True
            Catch ex As Exception

            End Try
        End While

    End Sub

    Private Async Sub login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Await Task.Run(Sub() updateRemoteDB())
        Await Task.Run(Sub() deleteLocalDB())
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

