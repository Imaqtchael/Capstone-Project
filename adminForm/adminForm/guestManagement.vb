Public Class guestManagement
    Dim loadDone As Boolean = False

    Public selectedGuestName As String
    Public selectedGuestEventID As String

    Dim eventGuestsIDSL As String()
    Dim eventListsL As String()

    Dim guests As IEnumerable(Of MyGuest)

    Public Sub guestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshDataGridView()
    End Sub

    Public Sub RefreshDataGridView()
        GuestsDataGridView.Rows.Clear()

        Dim eventCollection As IEnumerable(Of MyEvent) = login.eventCollection

        If Not eventCollection.Any Then
            Return
        End If

        Dim eventGuestsIDS As String = ""
        Dim eventLists As String = ""
        Dim eventDates As String = ""

        For i As Integer = 0 To eventCollection.Count - 1
            If eventGuestsIDS.Length = 0 Then
                eventGuestsIDS = eventCollection(i).GuestsID
                eventLists = eventCollection(i).Name
                eventDates = eventCollection(i).Date
            Else
                eventGuestsIDS += $", {eventCollection(i).GuestsID}"
                eventLists += $", {eventCollection(i).Name}"
                eventDates += $", {eventCollection(i).Date}"
            End If
        Next

        eventGuestsIDSL = Split(eventGuestsIDS, ", ")
        eventListsL = Split(eventLists, ", ")
        Dim eventDatesL As String() = Split(eventDates, ", ")

        If Not loadDone Then
            GuestsDataGridView.Columns.AddRange(New DataGridViewColumn(3) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            GuestsDataGridView.Columns(3).Width = 150

            GuestsDataGridView.Columns.AddRange(New DataGridViewColumn(1) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            GuestsDataGridView.Columns(4).Width = 150
            GuestsDataGridView.Columns(4).DefaultCellStyle.BackColor = Color.DodgerBlue
            GuestsDataGridView.Columns(5).Width = 150
            GuestsDataGridView.Columns(5).DefaultCellStyle.BackColor = Color.Red

            loadDone = True
        End If

        For i As Integer = 0 To eventGuestsIDSL.Length - 1
            guests = login.guestCollection.Where(Function(guest) guest.GuestID = eventGuestsIDSL(i))

            For j As Integer = 0 To guests.Count - 1
                GuestsDataGridView.Rows.Add(guests(j).Name, eventListsL(i), eventDatesL(i), guests(j).Type, "EDIT", "DELETE")
            Next
        Next
    End Sub

    Private Sub GuestSearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles GuestSearchTextBox.TextChanged
        If GuestSearchTextBox.Text.Length > 0 Then
            Dim searchingFor As String = GuestSearchTextBox.Text.ToLower()

            For Each row As DataGridViewRow In GuestsDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If

                If Not row.Cells(1).Value.ToString.ToLower.Contains(searchingFor) Then
                    row.Visible = False
                End If
            Next
        Else
            For Each row As DataGridViewRow In GuestsDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If
            Next
        End If

    End Sub

    Private Async Sub AddGuestButton_Click(sender As Object, e As EventArgs) Handles AddGuestButton.Click
        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If
        login.RefreshTimer.Stop()
        With guestManagementAddGuest
            .RefreshComboBox()
            .ShowDialog()
        End With
        Await Task.Delay(1000)
        login.RefreshTimer.Start()
    End Sub

    Private Async Sub GuestsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GuestsDataGridView.CellContentClick
        selectedGuestName = GuestsDataGridView.Rows(e.RowIndex).Cells(0).Value
        selectedGuestEventID = eventGuestsIDSL(Array.IndexOf(eventListsL, GuestsDataGridView.Rows(e.RowIndex).Cells(1).Value))
        Dim selectedGuest As MyGuest = login.guestCollection.Where(Function(guest) guest.Name = selectedGuestName And guest.GuestID.ToString() = selectedGuestEventID).First()

        If e.ColumnIndex = 4 Then
            login.RefreshTimer.Stop()

            With guestManagementEditGuest
                .RefreshComboBox()
                .NameTextBox.Text = selectedGuest.Name
                .AddressTextBox.Text = selectedGuest.Address
                .ContactTextBox.Text = selectedGuest.Number
                .EmailTextBox.Text = selectedGuest.Email
                .RFIDTextBox.Text = selectedGuest.RFID
                .EventComboBox.Enabled = True
                If GuestsDataGridView.Rows(e.RowIndex).Cells(3).Value = "BOOKER" Then
                    .EventComboBox.Enabled = False
                End If
                .guestID = selectedGuest.ID.ToString()
                .guestEventId = selectedGuest.GuestID
                .ShowDialog()
            End With
            Await Task.Delay(1000)
            login.RefreshTimer.Start()
        ElseIf e.ColumnIndex = 5 Then
            login.RefreshTimer.Stop()

            If GuestsDataGridView.Rows(e.RowIndex).Cells(3).Value = "BOOKER" Then
                MessageBox.Show("Cannot delete a booker")
                Return
            End If

            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedGuestName} for event {GuestsDataGridView.Rows(e.RowIndex).Cells(1).Value} in the database??", MsgBoxStyle.YesNo)

            If confirm = MsgBoxResult.Yes Then
                If Not haveInternetConnection() Then
                    MessageBox.Show("Internet not detected!")
                    Return
                End If
                Dim deleteQuery As String = $"DELETE FROM guest WHERE id={selectedGuest.ID} AND type='GUEST'"
                Await Task.Run(Function() executeNonQuery(deleteQuery, remoteConnection))
                login.refreshAllForms()
            End If
            Await Task.Delay(1000)
            login.RefreshTimer.Start()
        End If
    End Sub
End Class