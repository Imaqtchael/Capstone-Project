Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class eventManagement
    Dim loadDone As Boolean = False

    Public editOrAddEvent, editEvent As String

    Dim selectedRow As Integer = 0

    'Showing data on DataGridView on form load
    Public Sub eventManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get the refreshed table from home form
        Dim eventsTable = login.allTabDataSet.Tables(2)

        'Clear the data that may be in the datagridview1
        DataGridView1.Rows.Clear()

        'Do nothing if there is no data that will be displayed
        If eventsTable.Rows.Count = 0 Then
            Return
        End If

        'Customize DataGridView1 rows on form load
        If Not loadDone Then
            DataGridView1.Columns.AddRange(New DataGridViewColumn(2) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            DataGridView1.Columns.AddRange(New DataGridViewColumn(2) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.Gray
            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.DodgerBlue
            DataGridView1.Columns(5).Width = 150
            DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.Red
        End If
        loadDone = True

        'Add the data from the eventsTable to the customized DataGridView
        For i As Integer = 0 To eventsTable.Rows.Count - 1
            Dim eventName As String = eventsTable.Rows(i)(0)
            Dim eventType As String = eventsTable.Rows(i)(1)
            Dim eventDate As String = eventsTable.Rows(i)(2)

            DataGridView1.Rows.Add(eventName, eventType, eventDate, "VIEW GUESTS", "EDIT", "DELETE")
        Next

        'Reselect a previously selected row, if there is one
        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count - 1 >= selectedRow Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        login.Timer3.Stop()
        eventManagementEditORAddEvent.ShowDialog()
        login.refreshAllForms()
        login.Timer3.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        login.Timer3.Stop()
        registerGuests.ShowDialog()
        login.refreshAllForms()
        login.Timer3.Start()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'If there is no user input, then reload the form
        login.Timer3.Stop()
        DataGridView1.Rows.Clear()
        If TextBox1.Text.Length = 0 Then
            login.Timer3.Start()
            eventManagement_Load(Nothing, Nothing)
            Return
        End If

        'Get an eventTable where the event name contains the text in textbox
        Dim events = login.allTabDataSet.Tables(2).AsEnumerable.Select(Function(eve) New With {
                                .name = eve.Field(Of String)("name"),
                                .type = eve.Field(Of String)("type"),
                                .date = eve.Field(Of String)("date")
                            }).Where(Function(eve) eve.name.ToUpper.Contains(TextBox1.Text.ToUpper))

        'Display all the events that contains the string input of the user
        For i As Integer = 0 To events.Count - 1
            Dim eventName As String = events(i).name
            Dim eventType As String = events(i).type
            Dim eventDate As String = events(i).date

            DataGridView1.Rows.Add(eventName, eventType, eventDate, "VIEW GUESTS", "EDIT", "DELETE")
        Next
    End Sub

    Private Async Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim selectedEvent As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        selectedRow = e.RowIndex

        'Show the geusts of the cliked event
        If e.ColumnIndex = 3 Then
            showThis(home.Button2, home.Panel1, guestManagement)
            changeColor(home.Button2, home.Button1, home.Button3, home.Button4)
            guestManagement.TextBox1.Text = selectedEvent
        ElseIf e.ColumnIndex = 4 Then 'Edit the selected event
            editOrAddEvent = "edit"
            editEvent = selectedEvent

            login.Timer3.Stop()
            eventManagementEditORAddEvent.ShowDialog()
            login.refreshAllForms()
            login.Timer3.Start()
        ElseIf e.ColumnIndex = 5 Then 'Delete an event and it's guest after the user confirms it
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedEvent} in the database??", MsgBoxStyle.YesNo)
            If confirm = MsgBoxResult.Yes Then
                Dim id = login.allTabDataSet.Tables(2).AsEnumerable.Select(Function(eve) New With {
                                .name = eve.Field(Of String)("name"),
                                .guests_id = eve.Field(Of Integer)("guests_id")
                            }).Where(Function(eve) eve.name = selectedEvent).First

                Dim query2 As String = $"DELETE FROM events WHERE name='{selectedEvent.Replace("'", "\'")}'"
                Dim query3 As String = $"DELETE FROM guest WHERE guest_id={id.guests_id}"

                login.Timer3.Stop()
                Await Task.Run(Function() executeNonQuery($"{query2}; {query3}", remoteConnection))
                login.refreshAllForms()
                login.Timer3.Start()
            End If
        End If
    End Sub
End Class