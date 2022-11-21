Imports MySql.Data.MySqlClient
Module Functions
    Public str As String = "server=localhost; uid=root; pwd=; database=real_capstone"
    Public connection As New MySqlConnection(str)

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
            connection.Open()
            cmd = connection.CreateCommand()
            cmd.CommandText = query
            cmd.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message())
            complete = False
        End Try
        connection.Close()
        Return complete
    End Function

    Public Function getData(ByVal query As String) As DataSet
        Dim adpt As New MySqlDataAdapter(query, connection)
        Dim ds As New DataSet()
        adpt.Fill(ds)

        Return ds
    End Function
End Module