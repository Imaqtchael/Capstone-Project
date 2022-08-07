Imports MySql.Data.MySqlClient
Public Class registerForm
    Dim query As String = "SELECT * FROM sample_attendees"
    Dim adapter As New MySqlDataAdapter(query, connection)
    Dim dataset As New DataSet()
    Dim counter As Integer = 0
    Private Sub registerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adapter.Fill(dataset)

        Dim id As String = dataset.Tables(0).Rows(counter)(0)
        counter += 1
        TextBox1.Text = id
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text.Length = 10 Then
            Try
                connection.Open()
                Dim command As MySqlCommand
                Dim id As String = TextBox1.Text
                Dim rfid As String = TextBox2.Text
                command = connection.CreateCommand()
                command.CommandText = $"UPDATE sample_attendees SET rfid='{rfid}' WHERE id='{id}'"
                If command.ExecuteNonQuery() = 1 And counter < dataset.Tables(0).Rows.Count Then
                    TextBox1.Text = dataset.Tables(0).Rows(counter)(0)
                    counter += 1
                    TextBox2.Clear()
                    Label3.Text = ""
                ElseIf counter = dataset.Tables(0).Rows.Count Then
                    TextBox2.ReadOnly = True
                    Label4.Text = "Done!"
                End If
            Catch ex As MySql.Data.MySqlClient.MySqlException
                Label3.Text = "That RFID is already used! Please use different RFID..."
                TextBox2.Clear()
            Finally
                connection.Close()
            End Try

        End If
    End Sub
End Class