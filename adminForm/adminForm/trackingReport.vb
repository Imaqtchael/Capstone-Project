Imports MySql.Data.MySqlClient
Public Class trackingReport
    'Creating a string that will be used in guestLog form
    Public selectedGuest As String

    Dim eventName As String
    Dim guestsID As String

    'Loading the data and putting them into DataGridView1
    Private Sub trackingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        'Get what is the current event
        Dim practiceDate As New Date(2022, 10, 28)
        Dim practiceDateString As String = practiceDate.ToString("d")

        Dim query2 As String = $"SELECT name, guests_id FROM events WHERE date='{practiceDateString}'"
        Dim adpt2 As New MySqlDataAdapter(query2, con)
        Dim ds2 As New DataSet()

        adpt2.Fill(ds2)

        If ds2.Tables(0).Rows.Count = 0 Then
            Return
        End If

        eventName = ds2.Tables(0).Rows(0)(0).ToString()
        guestsID = ds2.Tables(0).Rows(0)(1).ToString()

        Label1.Text = eventName
        Label2.Text = practiceDateString

        Dim query As String = $"SELECT name, logs FROM guest WHERE logs<>'' AND guest_id={guestsID}"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        'Creating another table that we will manipulate to contain
        'the right number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()
        realDataSet.Tables.Add(realDataTable)

        adpt.Fill(ds)

        'Displaying the number of 'IN' attendees
        Label5.Text = ds.Tables(0).Rows.Count

        'Getting the total number of attendes
        Dim query1 As String = $"SELECT name FROM guest WHERE guest_id={guestsID}"
        Dim adpt1 As New MySqlDataAdapter(query1, con)
        Dim ds1 As New DataSet()

        adpt1.Fill(ds1)

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

    End Sub

    'A sub for CellDoubleClick where we will show all of the logs of the selected guest
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Timer1.Enabled = False
        Dim row As DataGridViewRow = DataGridView1.CurrentRow

        Dim guest = row.Cells(0).Value.ToString()
        selectedGuest = guest
        guestLog.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim adapter As MySqlDataAdapter
        Dim ds As New DataSet()

        adapter = New MySqlDataAdapter($"SELECT name, logs FROM guest WHERE logs<>'' AND name LIKE '%{TextBox1.Text}%'", con)
        adapter.Fill(ds)

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
End Class