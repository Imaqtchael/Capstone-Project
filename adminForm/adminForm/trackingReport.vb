Public Class trackingReport
    'Creating a string that will be used in guestLog form
    Public selectedGuest As String

    'Create strings for labels
    Public eventName As String
    Public guestsID As String
    Dim eventDate As String

    Dim selectedRow As Integer = 0

    Dim loadDone As Boolean = False

    'Loading the data and putting them into DataGridView1
    Private Sub trackingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        Dim Events As String = $"SELECT name, guests_id, date FROM events WHERE date_format(str_to_date(date, '%m/%d/%Y'), '%Y/%m/%d')<=date_format(curdate(), '%Y/%m/%d') ORDER BY date DESC"
        Dim EventsDS As DataSet = getData(Events)

        If EventsDS.Tables(0).Rows.Count = 0 Then
            Return
        End If

        If Not loadDone Then
            For i As Integer = 0 To EventsDS.Tables(0).Rows.Count - 1
                ComboBox1.Items.Add(EventsDS.Tables(0).Rows(i)(0))
            Next
            loadDone = True
        End If

        If EventsDS.Tables(0).Rows.Count > 0 Then
            eventName = EventsDS.Tables(0).Rows(0)(0).ToString
            guestsID = EventsDS.Tables(0).Rows(0)(1).ToString()
            eventDate = EventsDS.Tables(0).Rows(0)(2).ToString()
        End If


        ComboBox1.Text = eventName
        Label2.Text = eventDate

        Dim query As String = $"SELECT name, logs FROM guest WHERE logs<>'' AND guest_id={guestsID}"
        Dim ds As DataSet = getData(query)

        'Creating another table that we will manipulate to contain
        'the right number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()
        realDataSet.Tables.Add(realDataTable)


        'Displaying the number of 'IN' attendees
        Label5.Text = ds.Tables(0).Rows.Count

        'Getting the total number of attendes
        Dim query1 As String = $"SELECT name FROM guest WHERE guest_id={guestsID}"
        Dim ds1 As DataSet = getData(query1)

        Label7.Text = ds1.Tables(0).Rows.Count

        'Creating 4 columns for our realDataTable
        addColumns(4, realDataTable)

        'Looping for all the attendee's logs and putting their
        'data on the DataGridView1
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim tryrow As DataRow
            tryrow = realDataSet.Tables(0).NewRow

            tryrow(0) = ds.Tables(0).Rows(i)(0)

            Dim logs As String() = Split(ds.Tables(0).Rows(i)(1).ToString(), ", ")
            Dim firstTimeInDate As String = Split(logs(0), " ")(0)
            Dim lastTimeIn
            Dim lastTimeOut

            If Not isIn(logs) Then
                lastTimeIn = $"{Split(logs(logs.Length - 2), " ")(1)} {Split(logs(logs.Length - 2), " ")(2)}"
                lastTimeOut = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
            Else
                lastTimeIn = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
                lastTimeOut = ""
            End If

            tryrow(1) = firstTimeInDate
            tryrow(2) = lastTimeIn
            tryrow(3) = lastTimeOut

            realDataSet.Tables(0).Rows.Add(tryrow)

        Next

        DataGridView1.DataSource = realDataSet.Tables(0)

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If
    End Sub

    'A sub for CellDoubleClick where we will show all of the logs of the selected guest
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Timer1.Enabled = False
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Dim guest = row.Cells(0).Value.ToString()
        selectedGuest = guest
        trackingReportGuestLog.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim query As String = $"SELECT name, logs FROM guest WHERE logs<>'' AND name LIKE '%{TextBox1.Text}%' AND guest_id='{guestsID}'"
        Dim ds As DataSet = getData(query)

        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()
        realDataSet.Tables.Add(realDataTable)

        addColumns(4, realDataTable)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim tryrow As DataRow
            tryrow = realDataSet.Tables(0).NewRow

            tryrow(0) = ds.Tables(0).Rows(i)(0)

            Dim logs As String() = Split(ds.Tables(0).Rows(i)(1).ToString(), ", ")
            Dim firstTimeInDate As String = Split(logs(0), " ")(0)
            Dim lastTimeIn
            Dim lastTimeOut

            If Not isIn(logs) Then
                lastTimeIn = $"{Split(logs(logs.Length - 2), " ")(1)} {Split(logs(logs.Length - 2), " ")(2)}"
                lastTimeOut = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
            Else
                lastTimeIn = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
                lastTimeOut = ""
            End If

            tryrow(1) = firstTimeInDate
            tryrow(2) = lastTimeIn
            tryrow(3) = lastTimeOut

            realDataSet.Tables(0).Rows.Add(tryrow)

        Next

        DataGridView1.DataSource = realDataSet.Tables(0)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        selectedRow = e.RowIndex
    End Sub

    Private Sub ComboBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles ComboBox1.MouseDown
        ComboBox1.DroppedDown = True
    End Sub
End Class