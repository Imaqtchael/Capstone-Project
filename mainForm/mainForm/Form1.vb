Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
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

    Dim loadDone As Boolean = False

    'Dim currDate As String = Date.Now.ToString("d")

    Dim currdate As String = Date.Now.ToString("MM/dd/yyyy")
    Dim dateQuery As String = $"SELECT guests_id FROM events WHERE date='{currDate}'"
    Dim dateDS As DataSet
    Dim guestsID As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer2.Tick
        If Not loadDone Then
            Timer2.Enabled = False
            Button1_Click(Nothing, Nothing)
            Timer2.Enabled = True
            loadDone = True
            dateDS = getData(dateQuery)
            If dateDS.Tables(0).Rows.Count > 0 Then
                guestsID = dateDS.Tables(0).Rows(0)(0)
            End If
        End If

        'Getting all the attendees
        Dim query As String = $"SELECT * FROM guest WHERE guest_id={guestsID}"
        Dim dataset As DataSet = getData(query)
        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
        Panel1.Select()
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Panel1.KeyPress
        'If the rfid has now a 10 character check if it is in the list of attendees
        If rfid.Length = 10 Then

            'Stop the timer until the checking and updating is done
            Timer2.Enabled = False

            If arr.Contains(rfid) Then

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
                Aadapter = New MySqlDataAdapter($"SELECT logs FROM guest WHERE name='{attendee}'", connection)
                Aadapter.Fill(Ads)

                'A boolean to determine if we will INSERT OR UPDATE
                Dim willUpdate As Integer = Ads.Tables(0).Rows(0)(0).ToString().Length

                'If there is a row present for the attendee then just UPDATE
                'that row, else INSERT log for that attendee
                If willUpdate > 0 Then
                    Dim log As String = Ads.Tables(0).Rows(0)(0).ToString()
                    Dim updateLog As String

                    updateLog = $"{log}, {time}"

                    Dim cmd As MySqlCommand
                    connection.Open()
                    Try
                        cmd = connection.CreateCommand()
                        cmd.CommandText = $"UPDATE guest SET logs='{updateLog}' WHERE name='{attendee}'"
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
                        cmd.CommandText = $"UPDATE guest SET logs='{time}' WHERE name='{attendee}'"
                        cmd.ExecuteNonQuery()
                        connection.Close()
                    Catch ex As Exception

                    End Try
                    connection.Close()
                End If

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
