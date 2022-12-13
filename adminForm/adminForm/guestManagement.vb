Public Class guestManagement
    Dim loadDone As Boolean = False

    Public selectedGuestName As String
    Public selectedGuestEventID As String

    Dim selectedRow As Integer = 0

    Dim eventGuestsIDSL As String()
    Dim eventListsL As String()

    Public Async Sub guestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim query As String = $"SELECT guests_id, name, date FROM events"
        'Dim ds As DataSet = home.allTabDataSet
        Dim guestsTable = login.allTabDataSet.Tables(1)

        DataGridView1.Rows.Clear()

        If guestsTable.Rows.Count = 0 Then
            Return
        End If

        Dim eventGuestsIDS As String = ""
        Dim eventLists As String = ""
        Dim eventDates As String = ""

        For i As Integer = 0 To guestsTable.Rows.Count - 1
            If eventGuestsIDS.Length = 0 Then
                eventGuestsIDS = guestsTable.Rows(i)(0)
                eventLists = guestsTable.Rows(i)(1)
                eventDates = guestsTable.Rows(i)(2)
            Else
                eventGuestsIDS += $", {guestsTable.Rows(i)(0)}"
                eventLists += $", {guestsTable.Rows(i)(1)}"
                eventDates += $", {guestsTable.Rows(i)(2)}"
            End If
        Next

        eventGuestsIDSL = Split(eventGuestsIDS, ", ")
        eventListsL = Split(eventLists, ", ")
        Dim eventDatesL As String() = Split(eventDates, ", ")

        If Not loadDone Then
            DataGridView1.Columns.AddRange(New DataGridViewColumn(3) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            DataGridView1.Columns(3).Width = 150

            DataGridView1.Columns.AddRange(New DataGridViewColumn(1) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.DodgerBlue
            DataGridView1.Columns(5).Width = 150
            DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.Red
        End If

        loadDone = True


        'If home.allTabDataSet Is Nothing Then
        '    MessageBox.Show("nothing")
        'End If

        'Parallel.For(0, eventGuestsIDSL.Length,
        '             Async Sub(i As Integer)
        '                 'Dim query1 As String = $"SELECT name, type FROM guest WHERE guest_id='{eventGuestsIDSL(i)}'"
        '                 'Dim ds1 As DataSet = Await Task.Run(Function() getData(query1))

        '                 Dim guests = Await Task.Run(Function() home.allTabDataSet.Tables(4).AsEnumerable.Select(Function(guest) New With {
        '                        .name = guest.Field(Of String)("name"),
        '                        .type = guest.Field(Of String)("type"),
        '                        .guest_id = guest.Field(Of Integer)("guest_id")
        '                    }).Where(Function(guest) guest.guest_id = eventGuestsIDSL(i)))

        '                 For j As Integer = 0 To guests.Count - 1
        '                     Me.Invoke(Sub()
        '                                   DataGridView1.Rows.Add(guests(j).name, eventListsL(i), eventDatesL(i), guests(j).type, "EDIT", "DELETE")
        '                               End Sub)
        '                 Next
        '             End Sub)

        For i As Integer = 0 To eventGuestsIDSL.Length - 1
            'Dim tryrow As DataRow
            'tryrow = realDataSet.Tables(0).NewRow

            'tryrow(0) = ds.Tables(0).Rows(i)(0)
            'tryrow(1) = trackingReport.eventName
            'tryrow(2) = practiceDateString

            'Dim query1 As String = $"SELECT name, type FROM guest WHERE guest_id='{eventGuestsIDSL(i)}'"
            'Dim ds1 As DataSet = Await Task.Run(Function() getData(query1))
            Dim guests = login.allTabDataSet.Tables(4).AsEnumerable.Select(Function(guest) New With {
                                .name = guest.Field(Of String)("name"),
                                .type = guest.Field(Of String)("type"),
                                .guest_id = guest.Field(Of Integer)("guest_id")
                            }).Where(Function(guest) guest.guest_id = eventGuestsIDSL(i))

            For j As Integer = 0 To guests.Count - 1
                DataGridView1.Rows.Add(guests(j).name, eventListsL(i), eventDatesL(i), guests(j).type, "EDIT", "DELETE")
            Next

            'realDataSet.Tables(0).Rows.Add(tryrow)
        Next

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count - 1 >= selectedRow Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If

    End Sub

    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    '    If TextBox1.Text.Length > 0 Then
    '        Timer1.Enabled = False
    '    Else
    '        Timer1.Enabled = True
    '        guestManagement_Load(Nothing, Nothing)
    '    End If
    'End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        DataGridView1.Rows.Clear()
        If TextBox1.Text.Length > 0 Then
            login.Timer3.Stop()
        Else
            login.Timer3.Start()
            guestManagement_Load(Nothing, Nothing)
            Return
        End If



        'Dim query As String = $"SELECT guests_id, name, date FROM events WHERE name LIKE '%{TextBox1.Text}%'"
        'Dim ds As DataSet = Await Task.Run(Function() getData(query))

        Dim events = login.allTabDataSet.Tables(1).AsEnumerable.Select(Function(eve) New With {
                                .guests_id = eve.Field(Of Integer)("guests_id"),
                                .name = eve.Field(Of String)("name"),
                                .date = eve.Field(Of String)("date")
                            }).Where(Function(eve) eve.name.ToUpper.Contains(TextBox1.Text.ToUpper))

        If events.Count < 1 Then
            Return
        End If

        For i As Integer = 0 To events.Count - 1
            Dim guestID As String = events(i).guests_id.ToString()
            Dim eventName As String = events(i).name
            Dim eventDate As String = events(i).date

            'Dim query1 As String = $"SELECT name, type FROM guest WHERE guest_id='{guestID}'"
            'Dim ds1 As DataSet = Await Task.Run(Function() getData(query1))

            Dim guests = login.allTabDataSet.Tables(4).AsEnumerable.Select(Function(guest) New With {
                                .name = guest.Field(Of String)("name"),
                                .type = guest.Field(Of String)("type"),
                                .guest_id = guest.Field(Of Integer)("guest_id")
                            }).Where(Function(guest) guest.guest_id = guestID)


            For j As Integer = 0 To guests.Count - 1
                DataGridView1.Rows.Add(guests(j).name, eventName, eventDate, guests(j).type, "EDIT", "DELETE")
            Next
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login.Timer3.Stop()
        guestManagementAddGuest.ShowDialog()
        login.refreshAllForms()
        login.Timer3.Start()
    End Sub

    Private Async Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        selectedGuestName = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        selectedGuestEventID = eventGuestsIDSL(Array.IndexOf(eventListsL, DataGridView1.Rows(e.RowIndex).Cells(1).Value))
        selectedRow = e.RowIndex
        If e.ColumnIndex = 4 Then
            login.Timer3.Stop()
            guestManagementEditGuest.ShowDialog()
            login.refreshAllForms()
            login.Timer3.Start()
        ElseIf e.ColumnIndex = 5 Then
            If DataGridView1.Rows(e.RowIndex).Cells(3).Value = "BOOKER" Then
                MessageBox.Show("Cannot delete a booker")
                Return
            End If
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedGuestName} for event {DataGridView1.Rows(e.RowIndex).Cells(1).Value} in the database??", MsgBoxStyle.YesNo)

            If confirm = MsgBoxResult.Yes Then
                Dim query2 As String = $"DELETE FROM guest WHERE name='{selectedGuestName}' AND guest_id={selectedGuestEventID}"
                login.Timer3.Stop()
                Await Task.Run(Function() executeNonQuery(query2, remoteConnection))
                login.refreshAllForms()
                login.Timer3.Start()
            Else
                Return
            End If
        End If
    End Sub
End Class