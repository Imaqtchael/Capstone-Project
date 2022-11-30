Imports MySql.Data.MySqlClient

Public Class guestManagement
    Dim loadDone As Boolean = False
    Public selectedGuest As String
    Dim selectedRow As Integer = 0

    Public Async Sub guestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick


        Dim query As String = $"SELECT guests_id, name, date FROM events"
        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        If ds.Tables(0).Rows.Count = 0 Then
            Return
        End If

        Dim eventGuestsIDS As String = ""
        Dim eventLists As String = ""
        Dim eventDates As String = ""

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If eventGuestsIDS.Length = 0 Then
                eventGuestsIDS = ds.Tables(0).Rows(i)(0)
                eventLists = ds.Tables(0).Rows(i)(1)
                eventDates = ds.Tables(0).Rows(i)(2)
            Else
                eventGuestsIDS += $", {ds.Tables(0).Rows(i)(0)}"
                eventLists += $", {ds.Tables(0).Rows(i)(1)}"
                eventDates += $", {ds.Tables(0).Rows(i)(2)}"
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

        For i As Integer = 0 To eventGuestsIDSL.Length - 1
            'Dim tryrow As DataRow
            'tryrow = realDataSet.Tables(0).NewRow

            'tryrow(0) = ds.Tables(0).Rows(i)(0)
            'tryrow(1) = trackingReport.eventName
            'tryrow(2) = practiceDateString

            Dim query1 As String = $"SELECT name, type FROM guest WHERE guest_id='{eventGuestsIDSL(i)}'"
            Dim ds1 As DataSet = await task.Run(Function() getData(query1))

            For j As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(ds1.Tables(0).Rows(j)(0), eventListsL(i), eventDatesL(i), ds1.Tables(0).Rows(j)(1), "EDIT", "DELETE")
            Next

            'realDataSet.Tables(0).Rows.Add(tryrow)
        Next

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If

    End Sub

    Private Async Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 0 Then
            Timer1.Enabled = False
        Else
            Timer1.Enabled = True
        End If

        DataGridView1.Rows.Clear()

        Dim query As String = $"SELECT guests_id, name, date FROM events WHERE name LIKE '%{TextBox1.Text}%'"
        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        If ds.Tables(0).Rows.Count < 1 Then
            Return
        End If

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim guestID As String = ds.Tables(0).Rows(i)(0).ToString()
            Dim eventName As String = ds.Tables(0).Rows(i)(1).ToString()
            Dim eventDate As String = ds.Tables(0).Rows(i)(2).ToString()

            Dim query1 As String = $"SELECT name, type FROM guest WHERE guest_id='{guestID}'"
            Dim ds1 As DataSet = Await Task.Run(Function() getData(query1))


            For j As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                DataGridView1.Rows.Add(ds1.Tables(0).Rows(j)(0), eventName, eventDate, ds1.Tables(0).Rows(j)(1), "EDIT", "DELETE")
            Next

            ds1.Tables.Clear()
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
                executeNonQuery(query2)
            Else
                Return
            End If
            con.Close()
            Timer1.Enabled = True
            guestManagement_Load(Nothing, Nothing)
        End If
    End Sub
End Class