Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form1
    'Array of RFID's
    Dim arr As String()
    'Array of Attendees
    Dim attendees As String()

    'Current RFID
    Dim rfid As String = ""

    'Strings that wil be used in the home screen
    Dim welcomeText1 As String = "We're GLAD You're Here!"
    Dim sorryText1 As String = "Sorry your RFID is not registered!"

    'Boolean that will be used to check if the 
    'user is in the list or not
    Dim welcome As Boolean

    'Integer that will be used to show the text
    'using the timer
    Dim counter As Integer = 0
    'Get all the

    Dim currentText As String() = {}
    Dim backUpCurrentText As String() = {}

    'Dim currDate As String = Date.Now.ToString("d")
    Dim currdate As String = Date.Now.ToString("MM/dd/yyyy")
    Dim dateQuery As String = $"SELECT guests_id FROM events WHERE date='{currdate}'"
    Dim dateDS As DataSet
    Dim guestsID As String
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'apacheMySQLRun()

        ''Create a local copy of the data from remote database
        'Await Task.Run(Sub() downloadRemoteDB("local_copy_guest"))
        'Await Task.Run(Sub() refreshLocalDB("local_copy_guest"))

        dateDS = Await Task.Run(Function() getData(dateQuery))
        If Not dateDS.Tables(0).Rows.Count > 0 Then
            Return
        End If

        guestsID = dateDS.Tables(0).Rows(0)(0)

        Button1_Click(Nothing, Nothing)
        Timer2.Enabled = True

        Dim query As String = $"SELECT * FROM guest WHERE guest_id={guestsID}"
        Dim dataset As DataSet = Await Task.Run(Function() getData(query))
        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
        'MessageBox.Show(String.Join(" ", arr))
        Panel1.Select()
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

    Private Sub downloadRemoteDB(ByVal DBName As String)
        'Download the remote database
        Dim remoteURI = "https://event-venue.website/includes/downloadGuestSQL.php"
        Dim fileName = $"..\..\..\SQL\{DBName}.sql" 'change this in your code

        Dim client As New WebClient()

        client.DownloadFile(remoteURI, fileName)

    End Sub

    'Recreate the local database with the downloaded data from the remote database
    Private Sub refreshLocalDB(ByVal DBName As String)

        'Create a blank database in localhost
        Dim connectionString = "server=localhost;uid=root;pwd="
        Dim connection = New MySqlConnection(connectionString)

        Dim dropLocalCopy = "DROP DATABASE IF EXISTS local_copy_guest;"
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
        Dim createEditedField = "ALTER TABLE `events` ADD `edited` INT NOT NULL DEFAULT '0' AFTER `booker`;ALTER TABLE `guest` ADD `edited` INT NOT NULL DEFAULT '0' AFTER `type`;"
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

        Dim deleteDB = "DROP DATABASE local_copy_guest"
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
        Dim dataTables() As String = {"events", "guest"}

        Dim localConnectionString = $"server=localhost;uid=root;pwd=;database=local_copy_guest"
        Dim localConnection = New MySqlConnection(localConnectionString)

        Dim getEditedTables = $"SELECT * FROM events WHERE edited<>0;SELECT * FROM guest WHERE edited<>0"
        Dim adapter As New MySqlDataAdapter(getEditedTables, localConnection)
        Dim editedTables As New DataSet()
        adapter.Fill(editedTables)

        Dim remoteConnectionString = $"server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
        Dim remoteConnection = New MySqlConnection(remoteConnectionString)
        Dim updateQuery As String = ""

        If editedTables.Tables(0).Rows.Count + editedTables.Tables(1).Rows.Count = 0 Then
            Return
        End If

        'Loop through the dataTables
        For i As Integer = 0 To dataTables.Length - 1


            'Loop through the edited localDataTables
            For j As Integer = 0 To editedTables.Tables(i).Rows.Count - 1
                If dataTables(i) = "events" Then
                    Dim guests_id = editedTables.Tables(0).Rows(j)(0)
                    Dim registered = editedTables.Tables(0).Rows(j)(1)
                    Dim name = editedTables.Tables(0).Rows(j)(2).ToString().Replace("'", "\'")
                    Dim event_date = editedTables.Tables(0).Rows(j)(3)
                    Dim event_time = editedTables.Tables(0).Rows(j)(4)
                    Dim type = editedTables.Tables(0).Rows(j)(5)
                    Dim ispaid = editedTables.Tables(0).Rows(j)(6)
                    Dim booker = editedTables.Tables(0).Rows(j)(7)
                    Dim editORInsert = Integer.Parse(editedTables.Tables(0).Rows(j)(8))

                    If editORInsert = 1 Then
                        updateQuery += $"UPDATE events SET registered={registered}, name='{name}', date='{event_date}', time='{event_time}', type='{type}', ispaid={ispaid}, booker='{booker}' WHERE guests_id={guests_id};"
                    ElseIf editORInsert = 2 Then
                        updateQuery += $"INSERT INTO events(registered, name, date, time, type, ispaid, booker) VALUES({registered}, '{name}', '{event_date}', '{event_time}', '{type}', {ispaid}, '{booker}');"
                    End If

                ElseIf dataTables(i) = "guest" Then
                    Dim id = editedTables.Tables(1).Rows(j)(0)
                    Dim guest_id = editedTables.Tables(1).Rows(j)(1)
                    Dim logs = editedTables.Tables(1).Rows(j)(2)
                    Dim rfid = editedTables.Tables(1).Rows(j)(3)
                    Dim name = editedTables.Tables(1).Rows(j)(4)
                    Dim address = editedTables.Tables(1).Rows(j)(5)
                    Dim email = editedTables.Tables(1).Rows(j)(6)
                    Dim number = editedTables.Tables(1).Rows(j)(7)
                    Dim type = editedTables.Tables(1).Rows(j)(8)
                    Dim editORInsert = Integer.Parse(editedTables.Tables(1).Rows(j)(9))

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

    Private Async Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Await Task.Run(Sub() updateRemoteDB())
        'Await Task.Run(Sub() downloadRemoteDB("local_copy_guest"))
        'Await Task.Run(Sub() refreshLocalDB("local_copy_guest"))

        'Getting all the attendees
        Dim query As String = $"SELECT * FROM guest WHERE guest_id={guestsID}"

        Dim dataset As DataSet = Await Task.Run(Function() getData(query))

        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
        Panel1.Select()
    End Sub

    'Private Async Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    '    Await Task.Run(Sub() updateRemoteDB())
    '    Await Task.Run(Sub() deleteLocalDB())
    'End Sub

    Private Sub Panel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Panel1.KeyPress
        'If the rfid has now a 10 character check if it is in the list of attendees
        If rfid.Length = 10 Then

            'Stop the timer until the checking and updating is done
            Timer2.Enabled = False

            If arr.Contains(rfid) Then
                Timer2.Stop()
                'Reset the Labels
                welcome = True
                Label2.Text = ""

                'Start the displaying of text
                Timer1.Start()

                'Get the time for the logs
                Dim time As String = Date.Now

                'Get the attendee based on the rfid that has been read
                Dim attendeeIndex As Integer = Array.IndexOf(arr, rfid)
                Dim attendee As String = attendees(attendeeIndex)

                'Get the log of the attendee
                Dim Aadapter As MySqlDataAdapter
                Dim Ads As New DataSet
                Aadapter = New MySqlDataAdapter($"SELECT logs FROM guest WHERE name='{attendee}' AND guest_id={guestsID}", remoteConnection)
                Aadapter.Fill(Ads)

                'A boolean to determine if we will INSERT OR UPDATE
                Dim willUpdate As Integer = Ads.Tables(0).Rows(0)(0).ToString().Length

                'If there is a row present for the attendee then just UPDATE
                'that row, else INSERT log for that attendee
                If willUpdate > 0 Then
                    Dim log As String = Ads.Tables(0).Rows(0)(0).ToString()
                    Dim updateLog As String

                    updateLog = $"{log}, {time}"

                    executeNonQuery($"UPDATE guest SET logs='{updateLog}' WHERE name='{attendee}' AND guest_id={guestsID}")
                Else
                    executeNonQuery($"UPDATE guest SET logs='{time}' WHERE name='{attendee}' AND guest_id={guestsID}")
                End If
                Timer2.Start()
                'Else show "you are not welcome"
            Else
                welcome = False
                Label2.Text = ""
                Timer1.Start()
            End If

            'Reset the RFID whether it is in the list of attendees or not
            rfid = ""

            'Enable the stopped timer
            Timer2.Enabled = True
        Else
            'If it has less than 10 characters, just add the
            'scanned character to rfid variable
            rfid += e.KeyChar

        End If
    End Sub

    'A timer that will help us transition our displayed texts
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If welcome Then
            If counter <> welcomeText1.Length Then
                Try
                    Label2.Text += welcomeText1(counter)
                    Label2.ForeColor = Color.White

                Catch ex As Exception

                End Try
                counter += 1
            Else
                counter = 0
                Timer1.Stop()
            End If
        Else
            If counter <> sorryText1.Length Then
                Try
                    Label2.Text += sorryText1(counter)
                    Label2.ForeColor = Color.Red

                Catch ex As Exception

                End Try
                counter += 1
            Else
                counter = 0
                Timer1.Stop()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentText.Length <> 0 Then
            currentText = Split(InputBox($"CHANGE EVENT TEXT TO: {Environment.NewLine}1. Event Text{Environment.NewLine}2. Event Name{Environment.NewLine}3. Event Date{Environment.NewLine}SEPARATED BY COMMA", "Change Event Texts", Join(currentText, ", ")), ", ")
        Else
            currentText = Split(InputBox($"CHANGE EVENT TEXT TO: {Environment.NewLine}1. Event Text{Environment.NewLine}2. Event Name{Environment.NewLine}3. Event Date{Environment.NewLine}SEPARATED BY COMMA", "Change Event Texts"), ", ")
        End If

        If currentText.Length <> 4 Then
            If currentText.Length = 1 And backUpCurrentText.Length <> 1 Then
                currentText = backUpCurrentText
            End If
            MessageBox.Show("Please separate the text with comma with space: "", """)
            Return
        End If

        backUpCurrentText = currentText

        Label5.Text = currentText(0)
        Label3.Text = currentText(1)
        Label4.Text = $"{currentText(2)}, {currentText(3)}"

        Dim file As New OpenFileDialog

        file.Multiselect = False
        file.RestoreDirectory = True
        file.Title = "Pick a Background"

        If file.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Dim path As String = file.FileName

            Panel1.BackgroundImage = Image.FromFile(path)
        End If
    End Sub


    'Casting Shadow to the Form
    Private Const CS_DROPSHADOW As Integer = 131072
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    'Enables the user to drag the form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class
