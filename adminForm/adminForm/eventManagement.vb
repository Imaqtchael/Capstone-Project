Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class eventManagement
    Dim loadDone As Boolean = False
    Dim query As String = "SELECT name, type, date, guests_id FROM events"

    Public editOrAddEvent, editEvent As String

    Dim selectedRow As Integer = 0

    'Showing data on DataGridView on form load
    Public Sub eventManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        DataGridView1.Rows.Clear()

        Dim ds As DataSet = getData(query)

        If ds.Tables(0).Rows.Count = 0 Then
            Return
        End If

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

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim eventName As String = ds.Tables(0).Rows(i)(0)
            Dim eventType As String = ds.Tables(0).Rows(i)(1)
            Dim eventDate As String = ds.Tables(0).Rows(i)(2)

            DataGridView1.Rows.Add(eventName, eventType, eventDate, "VIEW GUESTS", "EDIT", "DELETE")
        Next

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count > 0 Then
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

        Dim query1 As String = $"SELECT name, type, date FROM events WHERE name LIKE '%{TextBox1.Text}%'"
        Dim ds As DataSet = getData(query1)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim eventName As String = ds.Tables(0).Rows(i)(0)
            Dim eventType As String = ds.Tables(0).Rows(i)(1)
            Dim eventDate As String = ds.Tables(0).Rows(i)(2)

            DataGridView1.Rows.Add(eventName, eventType, eventDate, "VIEW GUESTS", "EDIT", "DELETE")
        Next
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
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

            If confirm = MsgBoxResult.Yes Then
                Dim guestsID As DataSet = getData($"SELECT guests_id FROM events WHERE name='{selectedEvent}'")
                Dim id As String = guestsID.Tables(0).Rows(0)(0)

                Dim query2 As String = $"DELETE FROM events WHERE name='{selectedEvent}'"
                Dim query3 As String = $"DELETE FROM guest WHERE guest_id={id}"
                executeNonQuery($"{query2}; {query3}")
                eventManagement_Load(Nothing, Nothing)

                guestManagement.guestManagement_Load(Nothing, Nothing)
            End If
        End If
    End Sub
End Class