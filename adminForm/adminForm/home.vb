Imports System.Net
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class home
    Public allTabDataSet As DataSet
    Dim counter As Integer
    Private Async Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Button5.Click
        'Create a local copy of the data from remote database
        Await Task.Run(Sub() downloadRemoteDB("local_copy"))
        Await Task.Run(Sub() refreshLocalDB("local_copy"))

        Dim checkFirst = Await Task.Run(Function() getAllData())
        While checkFirst Is Nothing
            checkFirst = Await Task.Run(Function() getAllData())
        End While
        allTabDataSet = checkFirst
        Button1.Enabled = True

        If login.currentUser(1) = "EVENT MANAGER" Then
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
        End If
        'Show the trackingreport form and changing the 
        'trackingreport buttont to white on form load
        showThis(sender, Panel1, trackingReport)
        changeColor(Button1, Button2, Button3, Button4)

    End Sub

    Public Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        refreshAllForms()
    End Sub

    Public Async Sub refreshAllForms()
        Await Task.Run(Sub() updateRemoteDB())
        Await Task.Run(Sub() downloadRemoteDB("local_copy"))
        Await Task.Run(Sub() refreshLocalDB("local_copy"))

        Dim checkFirst = Await Task.Run(Function() getAllData())
        While checkFirst Is Nothing
            checkFirst = Await Task.Run(Function() getAllData())
        End While
        allTabDataSet = checkFirst

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
    End Sub


    'Changing the clicked button to white and other button to whitesmoke
    Private Sub showForm(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        If sender Is Button1 Then
            showThis(Button1, Panel1, trackingReport)
            changeColor(Button1, Button2, Button3, Button4)
        ElseIf sender Is Button2 Then
            showThis(Button2, Panel1, guestManagement)
            changeColor(Button2, Button1, Button3, Button4)
        ElseIf sender Is Button3 Then
            showThis(Button3, Panel1, eventManagement)
            changeColor(Button3, Button1, Button2, Button4)
        ElseIf sender Is Button4 Then
            showThis(Button4, Panel1, userManagement)
            changeColor(Button4, Button1, Button2, Button3)
        End If
    End Sub

    'Loggin out the admin user and removing him in the REMEBERED.txt
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        deleteLocalDB()
        My.Computer.FileSystem.WriteAllText(
            "..\..\..\REMEMBERED.txt", "", False)
        Me.Hide()

        'If the login form is previously used we will just show it
        'or create it as an object and show it
        If login Is Nothing Then
            login.ShowDialog()
        Else
            login.Show()
        End If
        showThis(sender, Panel1, trackingReport)
        changeColor(Button1, Button2, Button3, Button4)
        Me.Close()
    End Sub

    Private Sub performAll()
        downloadRemoteDB("local_copy")
        refreshLocalDB("local_copy")
    End Sub

    Private Sub downloadRemoteDB(ByVal DBName As String)
        'Download the remote database
        Dim remoteURI = "https://event-venue.website/includes/downloadSQL.php"
        Dim fileName = $"D:\Downloads\{DBName}.sql" 'change this in your code

        Dim client As New WebClient()

        client.DownloadFile(remoteURI, fileName)
    End Sub

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
        Dim sqlFile = $"D:\Downloads\{DBName}.sql"
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
                    Dim name = editedTables.Tables(1).Rows(j)(2)
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
                    Dim editORInsert = Integer.Parse(editedTables.Tables(2).Rows(j)(9))

                    If editORInsert = 1 Then
                        updateQuery += $"UPDATE guest SET guest_id={guest_id}, logs='{logs}', rfid='{rfid}', name='{name}', address='{address}', email='{email}', number='{number}' WHERE id={id};"
                    ElseIf editORInsert = 2 Then
                        updateQuery += $"INSERT INTO guest(guest_id, logs, rfid, name, address, email, number) VALUES({guest_id}, '{logs}', '{rfid}', '{name}', '{address}', '{email}', '{number}');"
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
            Catch ex As Exception

            End Try
            remotelyConnected = True
        End While
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel2.MouseDown, Button5.MouseDown, Button5.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class