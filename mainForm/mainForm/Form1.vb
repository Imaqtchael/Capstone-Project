Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form1
    'Array of RFID's
    Dim arr As String()
    'Array of Attendees
    Dim attendees As String()

    'Current RFID
    Dim rfid As String = ""

    'Strings that wil be used in the home screen
    Dim welcomeText1 As String = "We're GLAD You're Here!"
    Dim sorryText1 As String = "Sorry your RFID is not registered for this event"

    'Boolean that will be used to check if the 
    'user is in the list or not
    Dim welcome As Boolean

    'Integer that will be used to show the text
    'using the timer
    Dim counter As Integer = 0
    'Get all the

    Dim currentText As String() = {}
    Dim backUpCurrentText As String() = {}

    'Dim currDate As String = Date.Now.ToString("d")
    Dim guestsID As String
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim currdate As String = Date.Now.ToString("MM/dd/yyyy")
        Dim eventsQuery As String = $"SELECT guests_id FROM events WHERE date='{currdate}'"
        Dim eventsTable As DataSet = Await Task.Run(Function() getData(eventsQuery))

        If Not eventsTable.Tables(0).Rows.Count > 0 Then
            Return
        End If

        guestsID = eventsTable.Tables(0).Rows(0)(0)

        SettingsButton_Click(Nothing, Nothing)
        RefreshTimer.Enabled = True

        Dim query As String = $"SELECT * FROM guest WHERE guest_id={guestsID}"
        Dim dataset As DataSet = Await Task.Run(Function() getData(query))
        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
        'MessageBox.Show(String.Join(" ", arr))
        Panel1.Select()
    End Sub

    Private Async Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        'Getting all the attendees
        Dim query As String = $"SELECT * FROM guest WHERE guest_id={guestsID}"

        Dim dataset As DataSet = Await Task.Run(Function() getData(query))

        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        attendees = (From myRow In dataset.Tables(0).AsEnumerable
                     Select myRow.Field(Of String)("name")).ToArray
        Panel1.Select()
    End Sub

    Private Sub Panel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Panel1.KeyPress
        'If the rfid has now a 10 character check if it is in the list of attendees
        If rfid.Length = 10 Then

            'Stop the timer until the checking and updating is done
            RefreshTimer.Enabled = False

            If arr.Contains(rfid) Then
                RefreshTimer.Stop()
                'Reset the Labels
                welcome = True
                WelcomeLabel.Text = ""

                'Start the displaying of text
                WelcomeTimer.Start()

                'Get the time for the logs
                Dim time As String = Date.Now

                'Get the attendee based on the rfid that has been read
                Dim attendeeIndex As Integer = Array.IndexOf(arr, rfid)
                Dim attendee As String = attendees(attendeeIndex)

                'Get the log of the attendee
                Dim Aadapter As MySqlDataAdapter
                Dim Ads As New DataSet
                Aadapter = New MySqlDataAdapter($"SELECT logs FROM guest WHERE name='{attendee}' AND guest_id={guestsID}", remoteConnection)
                Aadapter.Fill(Ads)

                'A boolean to determine if we will INSERT OR UPDATE
                Dim willUpdate As Integer = Ads.Tables(0).Rows(0)(0).ToString().Length

                'If there is a row present for the attendee then just UPDATE
                'that row, else INSERT log for that attendee
                If willUpdate > 0 Then
                    Dim log As String = Ads.Tables(0).Rows(0)(0).ToString()
                    Dim updateLog As String

                    updateLog = $"{log}, {time}"

                    executeNonQuery($"UPDATE guest SET logs='{updateLog}' WHERE name='{attendee}' AND guest_id={guestsID}")
                Else
                    executeNonQuery($"UPDATE guest SET logs='{time}' WHERE name='{attendee}' AND guest_id={guestsID}")
                End If
                RefreshTimer.Start()
                'Else show "you are not welcome"
            Else
                welcome = False
                WelcomeLabel.Text = ""
                WelcomeTimer.Start()
            End If

            'Reset the RFID whether it is in the list of attendees or not
            rfid = ""

            'Enable the stopped timer
            RefreshTimer.Enabled = True
        Else
            'If it has less than 10 characters, just add the
            'scanned character to rfid variable
            rfid += e.KeyChar

        End If
    End Sub

    'A timer that will help us transition our displayed texts
    Private Sub WelcomeTimer_Tick(sender As Object, e As EventArgs) Handles WelcomeTimer.Tick
        If welcome Then
            If counter <> welcomeText1.Length Then
                Try
                    WelcomeLabel.Text += welcomeText1(counter)
                    WelcomeLabel.ForeColor = Color.White

                Catch ex As Exception

                End Try
                counter += 1
            Else
                counter = 0
                WelcomeTimer.Stop()
            End If
        Else
            If counter <> sorryText1.Length Then
                Try
                    WelcomeLabel.Text += sorryText1(counter)
                    WelcomeLabel.ForeColor = Color.Red

                Catch ex As Exception

                End Try
                counter += 1
            Else
                counter = 0
                WelcomeTimer.Stop()
            End If
        End If
    End Sub

    Private Sub SettingsButton_Click(sender As Object, e As EventArgs) Handles SettingsButton.Click
        If currentText.Length <> 0 Then
            currentText = Split(InputBox($"CHANGE EVENT TEXT TO: {Environment.NewLine}1. Event Text{Environment.NewLine}2. Event Name{Environment.NewLine}SEPARATED BY COMMA", "Change Event Texts", Join(currentText, ", ")), ", ")
        Else
            currentText = Split(InputBox($"CHANGE EVENT TEXT TO: {Environment.NewLine}1. Event Text{Environment.NewLine}2. Event Name{Environment.NewLine}SEPARATED BY COMMA", "Change Event Texts"), ", ")
        End If

        If currentText.Length <> 2 Then
            If currentText.Length = 1 And backUpCurrentText.Length <> 1 Then
                currentText = backUpCurrentText
            End If
            MessageBox.Show("Please separate the text with comma with space: "", """)
            Return
        End If

        backUpCurrentText = currentText

        EventIntroLabel.Text = currentText(0)
        EventLabel.Text = currentText(1)
        DateLabel.Text = Date.Now.ToString("MMMM dd, yyyy")

        Dim file As New OpenFileDialog

        file.Multiselect = False
        file.RestoreDirectory = True
        file.Title = "Pick a Background"

        If file.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Dim path As String = file.FileName

            Panel1.BackgroundImage = Image.FromFile(path)
        End If
    End Sub

    Private Sub Panel1_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel1.MouseClick
        Panel1.Select()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
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
