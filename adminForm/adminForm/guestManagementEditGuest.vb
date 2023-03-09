Imports System.Runtime.InteropServices

Public Class guestManagementEditGuest
    Public guestID As String
    Public guestEventId As String
    Dim eventCollection As IEnumerable(Of MyEvent)

    Public Sub RefreshComboBox()
        Me.CenterToScreen()

        eventCollection = login.eventCollection.Where(Function(currentEvent) Convert.ToDateTime(currentEvent.Date) >= Date.Now.Date)

        Dim guestEvent As MyEvent = login.eventCollection.Where(Function(currentEvent) currentEvent.GuestsID = Integer.Parse(guestManagement.selectedGuestEventID)).First()
        If Convert.ToDateTime(guestEvent.Date) < Date.Now Then
            EventComboBox.Enabled = False
            EventComboBox.Items.Add(guestEvent.Name)
            EventComboBox.Text = guestEvent.Name
            DateTextBox.Text = guestEvent.Date
            Return
        End If

        EventComboBox.Items.Clear()

        For i As Integer = 0 To eventCollection.Count - 1
            EventComboBox.Items.Add(eventCollection(i).Name)
        Next
        EventComboBox.Text = guestEvent.Name
        DateTextBox.Text = guestEvent.Date
    End Sub

    Private Sub guestManagementEditGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshComboBox()
    End Sub

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveButton.Enabled = False
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0 And txt.Name <> RFIDTextBox.Name
            Select txt.Name

        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            SaveButton.Enabled = True
            Return
        End If

        If RFIDTextBox.Text.Length > 0 And RFIDTextBox.Text.Length <> 10 Then
            MessageBox.Show("Invalid RFID")
            SaveButton.Enabled = True
            Return
        End If

        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If

        Dim updateQuery = $"UPDATE guest SET guest_id={guestEventId}, rfid='{RFIDTextBox.Text}', name='{NameTextBox.Text}', address='{AddressTextBox.Text}', email='{EmailTextBox.Text}', number='{ContactTextBox.Text}' WHERE id={guestID}"
        Dim updateSuccess = Await Task.Run(Function() executeNonQuery(updateQuery, remoteConnection))

        If updateSuccess Then
            MessageBox.Show("Guest Information updated successfully!")

            SaveButton.Enabled = True
            login.refreshAllForms()
            Me.Close()
        End If
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        NameTextBox.Clear()
        AddressTextBox.Clear()
        ContactTextBox.Clear()
        EmailTextBox.Clear()
        DateTextBox.Clear()
        RFIDTextBox.Clear()

        EventComboBox.Text = ""

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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub RFIDTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles RFIDTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim rfid As String = RFIDTextBox.Text
            Dim sameRFIDCount = login.guestCollection.Where(Function(guest) guest.RFID = rfid)

            If sameRFIDCount.Any Then
                RFIDTextBox.Text = ""
                MessageBox.Show("RFID is has already been used!")
            End If
        End If
    End Sub

    Private Sub EventComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles EventComboBox.SelectionChangeCommitted
        DateTextBox.Text = eventCollection(EventComboBox.SelectedIndex).Date
        guestEventId = eventCollection(EventComboBox.SelectedIndex).GuestsID.ToString()
    End Sub
End Class