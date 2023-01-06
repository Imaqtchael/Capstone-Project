Public Class registerGuests
    Dim setRFIDQuery As String = ""
    Private Async Sub registerGuests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        home.Enabled = False
        Me.TopMost = True

        setRFIDQuery = ""

        Dim query As String = "SELECT name FROM events WHERE registered=0 AND ispaid=1"
        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("All events are currently registered")
            home.Enabled = True
            Me.Close()
        End If


        ComboBox1.Items.Clear()

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(i)(0))
        Next
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False

        Dim query As String = $"SELECT guest.id, guest.name FROM events INNER JOIN guest ON events.guests_id=guest.guest_id WHERE events.name='{ComboBox1.Text.Replace("'", "\'")}'"
        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim name As String = ds.Tables(0).Rows(i)(1)
            Dim id As String = ds.Tables(0).Rows(i)(0)

            TextBox1.Text = name
            TextBox2.Select()

            Await WaitForRFID(id)
        Next

        Dim updateRegisteredEvent As String = $"{setRFIDQuery}UPDATE events SET registered=1 WHERE name='{ComboBox1.Text.Replace("'", "\'")}'"

        Dim updateSuccess = Await Task.Run(Function() executeNonQuery(updateRegisteredEvent, remoteConnection))

        If updateSuccess Then
            MessageBox.Show("Guest's RFID set successfully!")
        End If

        registerGuests_Load(Nothing, Nothing)
    End Sub

    Private Async Function WaitForRFID(id As Integer) As Task
        While True
            If TextBox2.Text.Length = 10 Then
                Dim rfid As String = TextBox2.Text

                setRFIDQuery += $"UPDATE guest SET rfid='{rfid}' WHERE id={id};"

                TextBox1.Clear()
                TextBox2.Clear()

                Exit While
            End If

            Await Task.Delay(500)
        End While
    End Function

    Private Sub registerGuests_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ComboBox1.Text = ""

        TextBox1.Clear()
        TextBox2.Clear()

        home.Enabled = True
    End Sub
End Class