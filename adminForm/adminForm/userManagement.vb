
Imports MySql.Data.MySqlClient

Public Class userManagement
    Dim loadDone As Boolean = False
    Public editORAdd As String
    Public selectedUser As String
    Dim selectedRow As Integer = 0
    Private Sub userManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        Dim query As String = $"SELECT fullname, role, status FROM admin"
        Dim ds As DataSet = getData(query)

        DataGridView1.Rows.Clear()

        If ds.Tables(0).Rows.Count = 0 Then
            Return
        End If

        If Not loadDone Then
            DataGridView1.Columns.AddRange(New DataGridViewColumn(2) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            DataGridView1.Columns.AddRange(New DataGridViewColumn(1) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.DodgerBlue
            DataGridView1.Columns(4).Width = 150
            DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.Red
        End If

        loadDone = True

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim name As String = ds.Tables(0).Rows(i)(0)
            Dim role As String = ds.Tables(0).Rows(i)(1)
            Dim status As String = ds.Tables(0).Rows(i)(2)
            DataGridView1.Rows.Add(name, role, status, "EDIT", "DELETE")
        Next

        DataGridView1.ClearSelection()
        If DataGridView1.Rows.Count < 0 Then
            DataGridView1.Rows(selectedRow).Selected = True
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        userManagementAddOREditUser.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        selectedUser = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        selectedRow = e.RowIndex
        Dim role As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        If e.ColumnIndex = 3 Then
            Timer1.Enabled = False
            editORAdd = "edit"
            userManagementAddOREditUser.Show()
            Timer1.Enabled = True
        ElseIf e.ColumnIndex = 4 Then
            Timer1.Enabled = False

            If role = "Event Coordinator" Then
                MessageBox.Show("Cannot delete an Event Coordinator")
                Return
            End If

            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedUser} in the database??", MsgBoxStyle.YesNo)

            If confirm = MsgBoxResult.Yes Then
                Dim query2 As String = $"DELETE FROM admin WHERE fullname='{selectedUser}'"
                executeNonQuery(query2)
            Else
                Return
            End If
            Timer1.Enabled = True
            userManagement_Load(Nothing, Nothing)
        End If
    End Sub
End Class