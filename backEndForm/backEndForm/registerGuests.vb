Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class registerGuests
    Private Sub registerGuests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT name FROM events WHERE registered=False"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        adpt.Fill(ds)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(0)(0))
        Next
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String = $"SELECT guest.id, guest.name FROM events INNER JOIN guest ON events.guests_id=guest.guest_id WHERE events.name='{ComboBox1.Text}'"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        adpt.Fill(ds)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim name As String = ds.Tables(0).Rows(i)(1)
            Dim id As String = ds.Tables(0).Rows(i)(0)

            TextBox1.Text += name
            TextBox2.Select()
            Dim rfid As String
            Await Task.Run(Sub()
                               Dim complete As Boolean = False
                               While Not complete
                                   If TextBox2.Text.Length = 9 Then
                                       complete = True
                                       rfid = TextBox2.Text

                                   End If
                               End While
                               Return
                           End Sub)
            TextBox1.Clear()
            TextBox2.Clear()
            con.Open()
            Dim cmd As MySqlCommand
            cmd = con.CreateCommand()
            cmd.CommandText = $"UPDATE guest SET rfid='{rfid}' WHERE id={id}"
            cmd.ExecuteNonQuery()
            con.Close()

        Next

        con.Open()
        Dim cmd1 As MySqlCommand
        cmd1 = con.CreateCommand()
        cmd1.CommandText = $"UPDATE events SET registered=True WHERE name='{ComboBox1.Text}'"
        cmd1.ExecuteNonQuery()
        con.Close()

        registerGuests_Load(Nothing, Nothing)
    End Sub

End Class