Imports MySql.Data.MySqlClient

Public Class guestManagement
    Dim loadDone As Boolean = False
    Public selectedGuest As String
    Dim selectedRow As Integer = 0

    Public Async Sub guestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        'Dim query As String = $"SELECT guests_id, name, date FROM events"
        'Dim ds As DataSet = home.allTabDataSet
        Dim guestsTable = home.allTabDataSet.Tables(1)

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

        Dim eventGuestsIDSL As String() = Split(eventGuestsIDS, ", ")
        Dim eventListsL As String() = Split(eventLists, ", ")
        Dim eventDatesL As String() = Split(eventDates, ", ")

        DataGridView1.Rows.Clear()

        'Creating another table that we will manipulate to contain
        'the right number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()
        realDataSet.Tables.Add(realDataTable)

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
        DataGridView1.Rows.Clear()

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

            Dim guests = home.allTabDataSet.Tables(4).AsEnumerable.Select(Function(guest) New With {
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
        If DataGridView1.Rows.Count > 0 Then
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
        If TextBox1.Text.Length > 0 Then
            Timer1.Enabled = False
        Else
            Timer1.Enabled = True
            guestManagement_Load(Nothing, Nothing)
        End If

        DataGridView1.Rows.Clear()

        'Dim query As String = $"SELECT guests_id, name, date FROM events WHERE name LIKE '%{TextBox1.Text}%'"
        'Dim ds As DataSet = Await Task.Run(Function() getData(query))

        Dim events = home.allTabDataSet.Tables(1).AsEnumerable.Select(Function(eve) New With {
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

            Dim guests = home.allTabDataSet.Tables(4).AsEnumerable.Select(Function(guest) New With {
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
        Timer1.Enabled = False
        guestManagementAddGuest.Show()
        Timer1.Enabled = True
        guestManagement_Load(Nothing, Nothing)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        selectedGuest = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        selectedRow = e.RowIndex
        If e.ColumnIndex = 4 Then
            Timer1.Enabled = False
            guestManagementEditGuest.Show()
            Timer1.Enabled = True
            guestManagement_Load(Nothing, Nothing)
        ElseIf e.ColumnIndex = 5 Then
            Timer1.Enabled = False

            If DataGridView1.Rows(e.RowIndex).Cells(3).Value = "BOOKER" Then
                MessageBox.Show("Cannot delete a booker")
                Return
            End If
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedGuest} in the database??", MsgBoxStyle.YesNo)

            If confirm = MsgBoxResult.Yes Then
                Dim query2 As String = $"DELETE FROM guest WHERE name='{selectedGuest}'"
                executeNonQuery(query2, remoteConnection)
            Else
                Return
            End If
            Timer1.Enabled = True
            guestManagement_Load(Nothing, Nothing)
        End If
    End Sub
End Class