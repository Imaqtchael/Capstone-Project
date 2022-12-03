Imports System.Numerics
Imports MySql.Data.MySqlClient

Module Functions
    'Declaring DB-related variables
    Public remoteConnectionString As String = "server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
    Public remoteConnection As New MySqlConnection(remoteConnectionString)

    Public localConnectionString As String = "server=localhost; uid=root; pwd=; database=local_copy"
    Public localConnection As New MySqlConnection(localConnectionString)

    'Assorted Variables
    'Get what is the current event
    Public practiceDate As New Date(2022, 11, 20)
    Public practiceDateString As String = practiceDate.ToString("d")

    'Assorted Functions
    Public Sub addColumns(ByVal numberOfColumns As Integer, ByVal dataTable As DataTable)
        Dim column As DataColumn
        For i As Integer = 0 To numberOfColumns - 1
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = $"{i}"
            dataTable.Columns.Add(column)
        Next
    End Sub

    'Execute a query
    Public Function executeNonQuery(ByVal query As String, ByRef connection As MySqlConnection) As Boolean
        Dim isComplete As Boolean = True
        Dim command As MySqlCommand

        Try
            connection.Open()
            command = connection.CreateCommand()
            command.CommandText = query
            command.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message())
            isComplete = False
        End Try
        connection.Close()
        Return isComplete
    End Function

    Public Function getAllData() As DataSet
        Dim executed = False
        While Not executed
            Try
                Dim trackingReportQuery = "SELECT name, guests_id, date FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')<=date_format(curdate(), '%Y/%m/%d') ORDER BY date DESC;"
                Dim guestManagementQuery = "SELECT guests_id, name, date FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')>=date_format(curdate(), '%Y/%m/%d');"
                Dim eventManagementQuery = "SELECT name, type, date, guests_id FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')>=date_format(curdate(), '%Y/%m/%d');"
                Dim userManagementQuery = "SELECT fullname, role, status FROM admin;"
                Dim guestQuery = "SELECT name, type, guest_id FROM guest;"

                Dim allQuery As String = $"{trackingReportQuery} {guestManagementQuery} {eventManagementQuery} {userManagementQuery} {guestQuery}"
                Dim newConnection As MySqlConnection
                Dim allDataSet As New DataSet()

                If localConnection.State = ConnectionState.Closed Then
                    newConnection = localConnection.Clone()
                    Dim allDataAdapter As New MySqlDataAdapter(allQuery, newConnection)
                    allDataAdapter.Fill(allDataSet)
                Else
                    Dim allDataAdapter As New MySqlDataAdapter(allQuery, localConnection)
                    allDataAdapter.Fill(allDataSet)
                End If

                executed = True
                Return allDataSet
            Catch ex As Exception

            End Try
        End While
    End Function

    Public Function getData(ByVal query As String) As DataSet
        'Dim adpt As New MySqlDataAdapter(query, con)
        'Dim ds As New DataSet()
        'adpt.Fill(ds)
        Dim executed = False
        While Not executed
            Try
                Dim newConnection As MySqlConnection
                Dim dataSet As New DataSet()

                If localConnection.State = ConnectionState.Closed Then
                    newConnection = localConnection.Clone()
                    Dim adapter As New MySqlDataAdapter(query, newConnection)
                    adapter.Fill(dataSet)
                Else
                    Dim adapter As New MySqlDataAdapter(query, localConnection)
                    adapter.Fill(dataSet)
                End If

                executed = True
                Return dataSet
            Catch ex As Exception

            End Try
        End While

    End Function

    'Home Functions
    Public Sub changeColor(ByVal tochange As Button, ByVal stay1 As Button, ByVal stay2 As Button, ByVal stay3 As Button)
        tochange.BackColor = Color.White
        stay1.BackColor = Color.WhiteSmoke
        stay2.BackColor = Color.WhiteSmoke
        stay3.BackColor = Color.WhiteSmoke
    End Sub

    Public Sub showThis(ByVal sender As Object, ByVal container As Panel, ByVal toShow As Form)
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
        eventManagementEditORAddEvent.TextBox1.Clear()
        eventManagementEditORAddEvent.TextBox2.Clear()
        eventManagementEditORAddEvent.TextBox3.Clear()
        eventManagementEditORAddEvent.TextBox4.Clear()
        eventManagementEditORAddEvent.TextBox5.Clear()
        eventManagementEditORAddEvent.TextBox6.Clear()
        eventManagementEditORAddEvent.TextBox7.Clear()
        eventManagementEditORAddEvent.ComboBox1.Text = ""
    End Sub

End Module
