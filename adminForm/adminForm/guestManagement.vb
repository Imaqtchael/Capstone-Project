Imports MySql.Data.MySqlClient

Public Class guestManagement
    Private Sub guestManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        Dim query As String = $"SELECT logs FROM sample_logs WHERE attendee='{trackingReport.selectedGuest}'"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        'Creating another table that we will manipulate to contain
        'the right number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()
        realDataSet.Tables.Add(realDataTable)

        adpt.Fill(ds)
    End Sub
End Class