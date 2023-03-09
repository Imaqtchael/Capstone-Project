Public Class eventManagement
    Dim loadDone As Boolean = False

    Public editOrAddEvent, editEvent As String
    Dim eventCollection As IEnumerable(Of MyEvent)


    'Showing data on DataGridView on form load
    Public Sub eventManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        eventCollection = login.eventCollection

        EventDataGridView.Rows.Clear()

        If Not eventCollection.Any Then
            Return
        End If

        'Customize DataGridView1 rows on form load
        If Not loadDone Then
            EventDataGridView.Columns.AddRange(New DataGridViewColumn(3) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            EventDataGridView.Columns.AddRange(New DataGridViewColumn(2) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            EventDataGridView.Columns(4).Width = 150
            EventDataGridView.Columns(4).DefaultCellStyle.BackColor = Color.Gray
            EventDataGridView.Columns(5).Width = 150
            EventDataGridView.Columns(5).DefaultCellStyle.BackColor = Color.DodgerBlue
            EventDataGridView.Columns(6).Width = 150
            EventDataGridView.Columns(6).DefaultCellStyle.BackColor = Color.Red

            loadDone = True
        End If

        For i As Integer = 0 To eventCollection.Count - 1
            Dim eventName As String = eventCollection(i).Name
            Dim eventType As String = eventCollection(i).Type
            Dim eventDate As String = eventCollection(i).Date
            Dim eventPaid As Boolean = eventCollection(i).IsPaid

            EventDataGridView.Rows.Add(eventName, eventType, eventDate, eventPaid, "VIEW GUESTS", "EDIT", "DELETE")
        Next
    End Sub

    Private Async Sub AddEventButton_Click(sender As Object, e As EventArgs) Handles AddEventButton.Click
        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If
        login.RefreshTimer.Stop()
        With eventManagementEditORAddEvent
            .transactionType = "ADD"
            .selectedEventGuestsID = ""
            .EventDateTimePicker.Enabled = True
            .EventDateTimePicker.MinDate = Date.Now.ToString("d")
            .PaidCheckBox.Checked = True
            .ShowDialog()
        End With
        Await Task.Delay(1000)
        login.RefreshTimer.Start()
    End Sub

    Private Async Sub RegisterGuestButton_Click(sender As Object, e As EventArgs) Handles RegisterGuestButton.Click
        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If
        login.RefreshTimer.Stop()
        registerGuests.ShowDialog()
        Await Task.Delay(1000)
        login.RefreshTimer.Start()
    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        If SearchTextBox.Text.Length > 0 Then
            Dim searchingFor As String = SearchTextBox.Text.ToLower()
            For Each row As DataGridViewRow In EventDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If

                If Not row.Cells(0).Value.ToString.ToLower.Contains(searchingFor) Then
                    row.Visible = False
                End If
            Next
        Else
            For Each row As DataGridViewRow In EventDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If
            Next
        End If
    End Sub

    Private Sub TypeComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles TypeComboBox.SelectedValueChanged
        Dim currentValue As String = TypeComboBox.Text
        For i As Integer = 0 To EventDataGridView.Rows.Count - 1
            EventDataGridView.Rows(i).Visible = True
            If TypeComboBox.Text = "ALL EVENTS" Then
                Continue For
            End If
            Dim currentRowEvent As MyEvent = eventCollection(i)
            Dim currentRowEventDate As Date = Convert.ToDateTime(currentRowEvent.Date).Date
            Dim currentDate As Date = Date.Now.Date
            Dim finished = currentRowEvent.Registered = 2 And currentRowEventDate < currentDate
            If currentValue = "FINISHED EVENTS" And Not finished Then
                EventDataGridView.Rows(i).Visible = False
            ElseIf currentValue = "UNFINISHED EVENTS" And finished Then
                EventDataGridView.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Async Sub EventDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles EventDataGridView.CellContentClick
        Dim selectedEvent As String = EventDataGridView.Rows(e.RowIndex).Cells(0).Value
        Dim selectedEventIndex As Integer = e.RowIndex

        'Show the geusts of the cliked event
        If e.ColumnIndex = 4 Then
            showThis(home.ControlView, guestManagement)
            changeColor(home.GuestManagementButton, home.TrackingReportButton, home.EventManagementButton, home.UserManagementButton, home.AnalyticsButton)
            guestManagement.GuestSearchTextBox.Text = selectedEvent
        ElseIf e.ColumnIndex = 5 Then
            login.RefreshTimer.Stop()
            Dim selectedEventObject As MyEvent = login.eventCollection(selectedEventIndex)
            Dim selectedGuestObject As MyGuest = login.guestCollection.Where(Function(guest) guest.Type = "BOOKER" And guest.GuestID = selectedEventObject.GuestsID).First()
            With eventManagementEditORAddEvent
                .transactionType = "EDIT"
                .selectedEventGuestsID = selectedEventObject.GuestsID.ToString()
                .selectedBookerID = selectedGuestObject.ID
                .EditOrAddLabel.Text = "EDIT EVENT"
                .EventNameTextBox.Text = selectedEventObject.Name
                .EventDateTimePicker.Enabled = True
                If Convert.ToDateTime(selectedEventObject.Date) <= Date.Now Then
                    .EventDateTimePicker.Enabled = False
                    .EventDateTimePicker.MinDate = Convert.ToDateTime(selectedEventObject.Date)
                    .EventDateTimePicker.Value = Convert.ToDateTime(selectedEventObject.Date)
                Else
                    .EventDateTimePicker.Value = Convert.ToDateTime(selectedEventObject.Date)
                    .EventDateTimePicker.MinDate = Date.Now.ToString("d")
                End If
                .TypeComboBox.Text = selectedEventObject.Type
                .TimeTextBox.Text = selectedEventObject.Time
                If selectedEventObject.IsPaid Then
                    .PaidCheckBox.Checked = True
                    .beforePaid = True
                Else
                    .NotPaidCheckBox.Checked = True
                    .beforePaid = False
                End If
                .BookerNameTextBox.Text = selectedGuestObject.Name
                .AddressTextBox.Text = selectedGuestObject.Address
                .BookerContactTextBox.Text = selectedGuestObject.Number
                .EmailTextBox.Text = selectedGuestObject.Email
                .RFIDTextBox.Text = selectedGuestObject.RFID
                .SaveButton.BackColor = Color.DodgerBlue
                .SaveButton.Enabled = True
                .ShowDialog()
            End With
            Await Task.Delay(1000)
            login.RefreshTimer.Start()
        ElseIf e.ColumnIndex = 6 Then 'Delete an event and it's guest after the user confirms it
            login.RefreshTimer.Stop()
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedEvent} in the database??", MsgBoxStyle.YesNo)
            If confirm = MsgBoxResult.Yes Then
                Dim selectedEventObject As MyEvent = login.eventCollection(selectedEventIndex)

                If Not haveInternetConnection() Then
                    MessageBox.Show("Internet not detected!")
                    Return
                End If
                Dim deleteEventQuery As String = $"DELETE FROM events WHERE guests_id={selectedEventObject.GuestsID}"
                Dim deleteGuestQuery As String = $"DELETE FROM guest WHERE guest_id={selectedEventObject.GuestsID}; DELETE FROM temporary_guest_copy WHERE event_name='{selectedEvent.Replace("'", "\'")}'; DELETE FROM md5 WHERE event_name='{selectedEvent.Replace("'", "\'")}';"

                Await Task.Run(Function() executeNonQuery($"{deleteEventQuery}; {deleteGuestQuery}", remoteConnection))
                login.refreshAllForms()
            End If
            Await Task.Delay(1000)
            login.RefreshTimer.Start()
        End If
    End Sub
End Class