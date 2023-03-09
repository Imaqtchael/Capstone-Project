Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Functions
    Public remoteConnectionString As String = "server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
    Public remoteConnection As New MySqlConnection(remoteConnectionString)
    Public defaultDirectory As String = $"{Application.StartupPath}\CreatedFolders"

    Public Sub addColumns(ByVal numberOfColumns As Integer, ByVal dataTable As DataTable)
        Dim column As DataColumn
        For i As Integer = 0 To numberOfColumns - 1
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = $"{i}"
            dataTable.Columns.Add(column)
        Next
    End Sub

    Public Function executeNonQuery(ByVal query As String, ByRef connection As MySqlConnection) As Boolean
        Dim isComplete As Boolean = True
        Dim command As MySqlCommand
        Dim newConnection As MySqlConnection

        Try
            If connection.State = ConnectionState.Open Then
                newConnection = connection.Clone()
                newConnection.Close()
                newConnection.Open()
                command = newConnection.CreateCommand()
                command.CommandText = query
                command.ExecuteNonQuery()
                newConnection.Close()
            Else
                connection.Open()
                command = connection.CreateCommand()
                command.CommandText = query
                command.ExecuteNonQuery()
            End If
        Catch e As MySqlException
            MessageBox.Show(e.Message())
            isComplete = False
        End Try
        connection.Close()
        Return isComplete
    End Function

    Public Function getAllData() As DataSet
        Try
            'Dim trackingReportQuery = "SET time_zone='+8:00'; SELECT name, guests_id, date FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')<=date_format(curdate(), '%Y/%m/%d') ORDER BY date DESC;"
            'Dim guestManagementQuery = "SELECT guests_id, name, date FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')>=date_format(curdate(), '%Y/%m/%d');"
            'Dim eventManagementQuery = "SELECT name, type, date, guests_id FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')>=date_format(curdate(), '%Y/%m/%d');"
            'Dim userManagementQuery = "SELECT fullname, role, status FROM admin;"
            'Dim guestQuery = "SELECT name, type, guest_id FROM guest;"

            Dim usersQuery = "SELECT id, username, password, fullname, address, contact, email, role, status FROM admin;"
            Dim eventsQuery = "SET time_zone='+8:00'; SELECT guests_id, registered, name, date, time, type, ispaid, booker FROM events ORDER BY date DESC;"
            Dim guestsQuery = "SELECT id, guest_id, logs, rfid, name, address, email, number, type FROM guest;"
            Dim md5Query = "SELECT id, hash, event_name FROM md5;"
            Dim guestCopyQuery = "SELECT id, event_name, guest_json FROM temporary_guest_copy;"

            'Dim allQuery As String = $"{trackingReportQuery} {guestManagementQuery} {eventManagementQuery} {userManagementQuery} {guestQuery}"
            Dim allQuery As String = $"{usersQuery} {eventsQuery} {guestsQuery} {md5Query} {guestCopyQuery}"
            Dim newConnection As MySqlConnection
            Dim allDataSet As New DataSet()

            If remoteConnection.State = ConnectionState.Open Then
                newConnection = remoteConnection.Clone()
                newConnection.Close()
                Dim allDataAdapter As New MySqlDataAdapter(allQuery, newConnection)
                allDataAdapter.Fill(allDataSet)
            Else
                Dim allDataAdapter As New MySqlDataAdapter(allQuery, remoteConnection)
                allDataAdapter.Fill(allDataSet)
            End If

            Return allDataSet
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Function

    Public Function getData(ByVal query As String) As DataSet
        Try
            Dim newConnection As MySqlConnection
            Dim dataSet As New DataSet()

            If remoteConnection.State = ConnectionState.Open Then
                newConnection = remoteConnection.Clone()
                newConnection.Close()
                Dim adapter As New MySqlDataAdapter(query, newConnection)
                adapter.Fill(dataSet)
            Else
                Dim adapter As New MySqlDataAdapter(query, remoteConnection)
                adapter.Fill(dataSet)
            End If
            Return dataSet
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
    End Function

    Sub sendEmail(ByVal subject As String, ByVal body As String, ByVal sender As String, ByVal pass As String, ByVal receiver As String, ByVal isHTML As Boolean)
        Try
            Dim server As New SmtpClient
            Dim mail As New System.Net.Mail.MailMessage()
            server.UseDefaultCredentials = False
            server.Credentials = New Net.NetworkCredential(sender, pass)
            server.Port = 587
            server.EnableSsl = True
            server.Host = "smtp.hostinger.com"

            mail = New System.Net.Mail.MailMessage()
            mail.From = New MailAddress(sender)
            mail.To.Add(receiver)
            mail.Subject = subject
            mail.Body = body
            mail.IsBodyHtml = isHTML
            server.Send(mail)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function haveInternetConnection() As Boolean
        Try
            Return My.Computer.Network.Ping("191.101.230.103")
        Catch
            Return False
        End Try
    End Function

    'Home Functions
    Public Sub changeColor(ByVal tochange As Button, ByVal stay1 As Button, ByVal stay2 As Button, ByVal stay3 As Button, ByVal stay4 As Button)
        tochange.BackColor = Color.White
        stay1.BackColor = Color.WhiteSmoke
        stay2.BackColor = Color.WhiteSmoke
        stay3.BackColor = Color.WhiteSmoke
        stay4.BackColor = Color.WhiteSmoke
    End Sub

    Public Sub showThis(ByVal container As Panel, ByVal toShow As Form)
        With toShow
            .TopLevel = False
            container.Controls.Add(toShow)
            .BringToFront()
            .Show()
        End With
    End Sub

    'Tracking Report Functions
    Public Function isIn(ByVal logs As String()) As Boolean
        Dim count As Integer = logs.Length

        Return count Mod 2
    End Function

    'Event Management Functions
    Public Sub clearAll()
        eventManagementEditORAddEvent.EventNameTextBox.Clear()
        eventManagementEditORAddEvent.AddressTextBox.Clear()
        eventManagementEditORAddEvent.BookerNameTextBox.Clear()
        eventManagementEditORAddEvent.BookerContactTextBox.Clear()
        eventManagementEditORAddEvent.EmailTextBox.Clear()
        eventManagementEditORAddEvent.RFIDTextBox.Clear()
        eventManagementEditORAddEvent.TimeTextBox.Clear()
        eventManagementEditORAddEvent.TypeComboBox.Text = ""
    End Sub

End Module
