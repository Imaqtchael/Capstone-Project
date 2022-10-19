Imports MySql.Data.MySqlClient

Public Class guestLog
    'Loading data on form load
    Private Sub guestLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Getting the selected guest by the admin from trackingreport form
        Label1.Text = trackingReport.selectedGuest

        Dim query As String = $"SELECT logs FROM guest WHERE name='{trackingReport.selectedGuest}'"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        'Creating another Dataset 
        'Which we will manipulate to have the number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()

        realDataSet.Tables.Add(realDataTable)

        adpt.Fill(ds)

        Dim logs As String() = Split(ds.Tables(0).Rows(0)(0).ToString(), ", ")
        MessageBox.Show(ds.Tables(0).Rows(0)(0).ToString())

        'Adding two columns because we want Time in and Time out
        addColumns(2, realDataTable)

        'Initially did this to fix the bug for the odd number of logs
        'Realized later that a try/catch on the for loop does it better

        'Dim fixer As Boolean = ds.Tables(0).Rows.Count Mod 2


        For i As Integer = 0 To logs.Length - 1 Step 2
            Dim tryrow As DataRow
            tryrow = realDataSet.Tables(0).NewRow

            tryrow(0) = logs(i)

            Try
                tryrow(1) = logs(i + 1)
            Catch ex As Exception

            End Try

            realDataSet.Tables(0).Rows.Add(tryrow)
        Next

        'If fixer Then
        '    Dim tryrow As DataRow
        '    tryrow = realDataSet.Tables(0).NewRow

        '    tryrow(0) = logs(logs.Length - 1)

        '    realDataSet.Tables(0).Rows.Add(tryrow)
        'End If

        DataGridView1.DataSource = realDataSet.Tables(0)

    End Sub

    Private Sub guestLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        trackingReport.Timer1.Enabled = True
    End Sub
End Class