Imports System.Threading

Public Class registerGuests
    Dim setRFIDQuery As String = ""
    Dim eventCollection As IEnumerable(Of MyEvent)
    Dim selectedEventID As Integer
    Dim RFIDS As New ArrayList
    Private Sub registerGuests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        setRFIDQuery = ""

        eventCollection = login.eventCollection.Where(Function(currentEvent) currentEvent.Registered = 0 And currentEvent.IsPaid = True)

        If Not eventCollection.Any Then
            MessageBox.Show("All events are currently registered")
            login.RefreshTimer.Start()
            GoButton.Enabled = True
            Me.Close()
        End If

        EventComboBox.Items.Clear()

        For i As Integer = 0 To eventCollection.Count - 1
            EventComboBox.Items.Add(eventCollection(i).Name)
        Next
    End Sub

    Private Async Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If

        GoButton.Enabled = False

        Dim guestsCollection = login.guestCollection.Where(Function(guest) guest.GuestID = selectedEventID)

        If Not guestsCollection.Any Then
            Return
        End If

        For i As Integer = 0 To guestsCollection.Count - 1
            Dim name As String = guestsCollection(i).Name
            Dim id As String = guestsCollection(i).ID

            GuestTextBox.Text = name
            RFIDTextBox.Select()

            Await WaitForRFID(id)
        Next

        Dim updateRegisteredEvent As String = $"{setRFIDQuery}UPDATE events SET registered=1 WHERE guests_id={selectedEventID}"
        Dim updateSuccess = Await Task.Run(Function() executeNonQuery(updateRegisteredEvent, remoteConnection))

        If updateSuccess Then
            MessageBox.Show("Guest's RFID set successfully!")
        End If

        GoButton.Enabled = True

        login.refreshAllForms()
        Await Task.Delay(2000)
        registerGuests_Load(Nothing, Nothing)
    End Sub

    Private Async Function WaitForRFID(id As Integer) As Task
        While True
            If RFIDTextBox.Text.Length = 10 Then
                Dim rfid As String = RFIDTextBox.Text

                If login.guestCollection.Where(Function(guest) guest.RFID = rfid).Any Or RFIDS.Contains(rfid) Then
                    MessageBox.Show("This rfid has already been used!")
                    RFIDTextBox.Clear()
                Else
                    setRFIDQuery += $"UPDATE guest SET rfid='{rfid}' WHERE id={id};"
                    RFIDS.Add(rfid)
                    GuestTextBox.Clear()
                    RFIDTextBox.Clear()
                    Exit While
                End If
            End If

            Await Task.Delay(500)
        End While
    End Function

    Private Sub EventComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles EventComboBox.SelectionChangeCommitted
        GoButton.Enabled = True
        selectedEventID = eventCollection(EventComboBox.SelectedIndex).GuestsID
    End Sub

    Private Sub registerGuests_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        EventComboBox.Text = ""
        GuestTextBox.Clear()
        RFIDTextBox.Clear()
    End Sub
End Class