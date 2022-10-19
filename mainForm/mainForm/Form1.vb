Imports MySql.Data.MySqlClient
Public Class Form1
    'Array of RFID's
    Dim arr As String()
    'Array of Attendees
    Dim attendees As String()

    'Current RFID
    Dim rfid As String = ""

    'Strings that wil be used in the home screen
    Dim welcomeText As String = "WELCOME"
    Dim welcomeText1 As String = "We're GLAD You're Here!"
    Dim sorryText As String = "SORRY"
    Dim sorryText1 As String = "your RFID is not registered!"

    'Boolean that will be used to check if the 
    'user is in the list or not
    Dim welcome As Boolean

    'Integer that will be used to show the text
    'using the timer
    Dim counter As Integer = 0

    'Get all the
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer2.Tick
        'Getting al the attendees
        Dim query As String = "SELECT * FROM sample_attendees"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataset As New DataSet()

        adapter.Fill(dataset)
        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        'If the rfid has now a 10 character check if it is in the list of attendees
        If rfid.Length = 10 Then

            'Stop the timer until the checking and updating is done
            Timer2.Enabled = False

            If arr.Contains(rfid) Then

                'Reset the Labels
                welcome = True
                Label1.Text = ""
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
                Aadapter = New MySqlDataAdapter($"SELECT logs FROM sample_logs WHERE attendee='{attendee}'", connection)
                Aadapter.Fill(Ads)

                'A boolean to determine if we will INSERT OR DELETE
                Dim willUpdate As Boolean = Ads.Tables(0).Rows.Count

                'If there is a row present for the attendee then just UPDATE
                'that row, else INSERT log for that attendee
                If willUpdate Then
                    Dim log As String = Ads.Tables(0).Rows(0)(0).ToString()
                    Dim updateLog As String

                    updateLog = $"{log}, {time}"

                    Dim cmd As MySqlCommand
                    connection.Open()
                    Try
                        cmd = connection.CreateCommand()
                        cmd.CommandText = $"UPDATE sample_logs SET logs='{updateLog}' WHERE attendee='{attendee}'"
                        cmd.ExecuteNonQuery()
                        connection.Close()
                    Catch ex As Exception

                    End Try
                    connection.Close()
                Else
                    Dim cmd As MySqlCommand
                    connection.Open()
                    Try
                        cmd = connection.CreateCommand()
                        cmd.CommandText = $"INSERT INTO sample_logs(attendee, logs) VALUES('{attendee}', '{time}')"
                        cmd.ExecuteNonQuery()
                        connection.Close()
                    Catch ex As Exception

                    End Try
                    connection.Close()
                End If

                'Else show "you are not welcome"
            Else
                welcome = False
                Label1.Text = ""
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
                    Label1.Text += welcomeText(counter)

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
                    Label1.Text += sorryText(counter)

                Catch ex As Exception

                End Try
                counter += 1
            Else
                counter = 0
                Timer1.Stop()
            End If
        End If
    End Sub
End Class
