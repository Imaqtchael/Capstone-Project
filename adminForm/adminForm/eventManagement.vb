Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class eventManagement
    Dim loadDone As Boolean = False

    Public editOrAddEvent, editEvent As String

    Dim selectedRow As Integer = 0

    'Showing data on DataGridView on form load
    Public Sub eventManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim eventsTable = home.allTabDataSet.Tables(2)
        DataGridView1.Rows.Clear()
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


        For i As Integer = 0 To eventsTable.Rows.Count - 1
            Dim eventName As String = eventsTable.Rows(i)(0)
            Dim eventType As String = eventsTable.Rows(i)(1)
            Dim eventDate As String = eventsTable.Rows(i)(2)

            DataGridView1.Rows.Add(eventName, eventType, eventDate, "VIEW GUESTS", "EDIT", "DELETE")
        Next

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count - 1 >= selectedRow Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer1.Enabled = False
        eventManagementEditORAddEvent.Show()
        eventManagement_Load(Nothing, Nothing)
        Timer1.Enabled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Timer1.Enabled = False

        DataGridView1.Rows.Clear()
        If TextBox1.Text.Length = 0 Then
            Timer1.Enabled = True
            eventManagement_Load(Nothing, Nothing)
            Return
        End If

        'Dim query1 As String = $"SELECT name, type, date FROM events WHERE name LIKE '%{TextBox1.Text}%'"
        'Dim ds As DataSet = Await Task.Run(Function() getData(query1))

        Dim events = home.allTabDataSet.Tables(2).AsEnumerable.Select(Function(eve) New With {
                                .name = eve.Field(Of String)("name"),
                                .type = eve.Field(Of String)("type"),
                                .date = eve.Field(Of String)("date")
                            }).Where(Function(eve) eve.name.ToUpper.Contains(TextBox1.Text.ToUpper))

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

        If e.ColumnIndex = 3 Then
            showThis(home.Button2, home.Panel1, guestManagement)
            changeColor(home.Button2, home.Button1, home.Button3, home.Button4)
            guestManagement.TextBox1.Text = selectedEvent
        ElseIf e.ColumnIndex = 4 Then
            editOrAddEvent = "edit"
            editEvent = selectedEvent

            Timer1.Enabled = False
            eventManagementEditORAddEvent.Show()
            eventManagement_Load(Nothing, Nothing)
            Timer1.Enabled = True
        ElseIf e.ColumnIndex = 5 Then
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedEvent} in the database??", MsgBoxStyle.YesNo)
            home.Timer1.Enabled = False
            If confirm = MsgBoxResult.Yes Then
                'Dim guestsID As DataSet = Await Task.Run(Function() getData($"SELECT guests_id FROM events WHERE name='{selectedEvent}'"))
                'Dim id As String = guestsID.Tables(0).Rows(0)(0)

                Dim id = home.allTabDataSet.Tables(2).AsEnumerable.Select(Function(eve) New With {
                                .name = eve.Field(Of String)("name"),
                                .guests_id = eve.Field(Of Integer)("guests_id")
                            }).Where(Function(eve) eve.name = selectedEvent).First

                Dim query2 As String = $"DELETE FROM events WHERE name='{selectedEvent}'"
                Dim query3 As String = $"DELETE FROM guest WHERE guest_id={id.guests_id}"
                Await Task.Run(Function() executeNonQuery($"{query2}; {query3}", remoteConnection))

                eventManagement_Load(Nothing, Nothing)
                guestManagement.guestManagement_Load(Nothing, Nothing)
            End If
            home.refreshAllForms()
            home.Timer1.Enabled = True
        End If
    End Sub
End Class