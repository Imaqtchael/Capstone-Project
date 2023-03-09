Imports System.Runtime.InteropServices
Public Class guestManagementAddGuest
    Dim guestID, eventDate As String

    Dim eventCollection As IEnumerable(Of MyEvent)

    Public Sub RefreshComboBox()
        Me.CenterToScreen()
        SaveButton.Enabled = True
        eventCollection = login.eventCollection.Where(Function(currentEvent) Convert.ToDateTime(currentEvent.Date) >= Date.Now.Date)

        EventComboBox.Items.Clear()

        For i As Integer = 0 To eventCollection.Count - 1
            EventComboBox.Items.Add(eventCollection(i).Name)
        Next
    End Sub

    Private Sub guestManagementAddGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Dim confirm As MsgBoxResult = MsgBox("Are you sure about all of the infromations?", MsgBoxStyle.YesNo)

        If confirm = MsgBoxResult.Yes Then
            If Not haveInternetConnection() Then
                MessageBox.Show("Internet not detected!")
                Return
            End If
            Dim insertQuery = $"INSERT INTO guest(guest_id, rfid, name, address, email, number, type) VALUES({guestID}, '{RFIDTextBox.Text}', '{NameTextBox.Text}', '{AddressTextBox.Text}', '{EmailTextBox.Text}', '{ContactTextBox.Text}', 'GUEST')"
            Dim insertSuccess = Await Task.Run(Function() executeNonQuery(insertQuery, remoteConnection))
            If insertSuccess Then
                NameTextBox.Clear()
                AddressTextBox.Clear()
                ContactTextBox.Clear()
                EmailTextBox.Clear()
                DateTextBox.Clear()
                EventComboBox.Text = ""
                MessageBox.Show("Guest added succesfully!")
            End If
        Else
            SaveButton.Enabled = True
            Return
        End If

        RFIDTextBox.Clear()
        SaveButton.Enabled = True

        login.refreshAllForms()
    End Sub

    Private Sub EventComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EventComboBox.SelectedIndexChanged
        guestID = eventCollection(EventComboBox.SelectedIndex).GuestsID.ToString()
        eventDate = eventCollection(EventComboBox.SelectedIndex).Date

        DateTextBox.Text = eventDate
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class