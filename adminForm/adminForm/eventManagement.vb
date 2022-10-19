Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class eventManagement
    'Showing data on DataGridView on form load
    Private Sub eventManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT name, type, date FROM events"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        Dim var = DataGridView1.DisplayedRowCount(False)

        'Attempting to change the alternating cell color of DataGridView
        'realized later that this can be done with the DataGridView property

        'With DataGridView1
        '    For i As Integer = 0 To .DisplayedRowCount(False) - 1
        '        If i Mod 2 = 0 Then
        '            .Rows(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
        '        Else
        '            .Rows(i).DefaultCellStyle.BackColor = Color.White
        '        End If
        '    Next
        'End With

        'Dim checker As Integer = 1

        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    If checker Mod 2 = 0 Then
        '        row.DefaultCellStyle.BackColor = Color.White
        '    Else
        '        row.DefaultCellStyle.BackColor = Color.WhiteSmoke
        '    End If
        '    checker += 1
        'Next
    End Sub
End Class