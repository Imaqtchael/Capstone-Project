Imports MySql.Data.MySqlClient
Module Functions
    Public remoteConnectionString As String = "server=191.101.230.103; uid=u608197321_van_; pwd=~C3qt^9kZ; database=u608197321_real_capstone"
    Public remoteConnection As New MySqlConnection(remoteConnectionString)

    Public Sub showThis(ByVal toShow As String, Optional ByVal name As String = "", Optional ByVal eventName As String = "", Optional ByVal counter As Integer = 0)
        If toShow = "Welcome" Then
            Dim text = $"Welcome to {eventName} {name}"

            Form1.Label1.Text = ""

            For i As Integer = 0 To text.Length - 1
                Form1.Label1.Text += text(i)
            Next
        ElseIf toShow = "Not Registered" Then
            Dim text = "Sorry your RFID is not registered! Please contact the Manager of the event..."

            Form1.Label1.Text = ""

            For i As Integer = 0 To text.Length - 1
                Form1.Label1.Text += text(i)
            Next
        End If
    End Sub

    Public Function executeNonQuery(ByVal query As String) As Boolean
        Dim complete As Boolean = True
        Dim cmd As MySqlCommand
        Try
            remoteConnection.Open()
            cmd = remoteConnection.CreateCommand()
            cmd.CommandText = query
            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message())
            complete = False
        End Try
        remoteConnection.Close()
        Return complete
    End Function

    Public Function getData(ByVal query As String) As DataSet
        Dim executed = False
        While Not executed
            Try
                Dim newConnection As MySqlConnection
                Dim dataSet As New DataSet()

                If remoteConnection.State = ConnectionState.Closed Then
                    newConnection = remoteConnection.Clone()
                    Dim adapter As New MySqlDataAdapter(query, newConnection)
                    adapter.Fill(dataSet)
                Else
                    Dim adapter As New MySqlDataAdapter(query, remoteConnection)
                    adapter.Fill(dataSet)
                End If

                executed = True
                Return dataSet
            Catch ex As Exception
                MessageBox.Show(ex.Message())
            End Try

        End While

    End Function
End Module