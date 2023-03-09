Imports Org.BouncyCastle.Crypto.Tls

Public Class userManagement
    Dim loadDone As Boolean = False
    Public editORAdd As String
    Dim userCollection As IEnumerable(Of MyUser)
    Public Sub userManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userCollection = login.userCollection
        UsersDataGridView.Rows.Clear()

        If Not userCollection.Any Then
            Return
        End If

        If Not loadDone Then
            UsersDataGridView.Columns.AddRange(New DataGridViewColumn(2) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})

            UsersDataGridView.Columns.AddRange(New DataGridViewColumn(1) _
                                        {New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat},
                                         New DataGridViewButtonColumn() With
                                        {.FlatStyle = FlatStyle.Flat}})

            UsersDataGridView.Columns(3).Width = 150
            UsersDataGridView.Columns(3).DefaultCellStyle.BackColor = Color.DodgerBlue
            UsersDataGridView.Columns(4).Width = 150
            UsersDataGridView.Columns(4).DefaultCellStyle.BackColor = Color.Red

            loadDone = True
        End If

        For i As Integer = 0 To userCollection.Count - 1
            Dim name As String = userCollection(i).Fullname
            Dim role As String = userCollection(i).Role
            Dim status As String = userCollection(i).Status
            If name = "ADMIN ADMIN" Then
                Continue For
            End If

            UsersDataGridView.Rows.Add(name, role, status, "EDIT", "DELETE")
        Next
    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles AddUserButton.Click
        If Not haveInternetConnection() Then
            MessageBox.Show("Internet not detected!")
            Return
        End If

        login.RefreshTimer.Stop()
        With userManagementAddOREditUser
            .transactionType = "ADD"
            .ShowDialog()
        End With
        Await Task.Delay(1000)
        login.RefreshTimer.Start()
    End Sub

    Private Async Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles UsersDataGridView.CellContentClick
        If e.ColumnIndex = 3 Then
            login.RefreshTimer.Stop()
            Dim selectedUser = userCollection(e.RowIndex + 1)
            With userManagementAddOREditUser
                .transactionType = "EDIT"
                .selectedUserID = selectedUser.ID.ToString()
                .EditOrAddLabel.Text = "EDIT USER"
                .FullNameTextBox.Text = selectedUser.Fullname
                .UserNameTextBox.Text = selectedUser.Username
                .PasswordTextBox.Text = selectedUser.Password
                .AddressTextBox.Text = selectedUser.Address
                .ContactTextBox.Text = selectedUser.Contact
                .RoleComboBox.Text = selectedUser.Role
                .StatusComboBox.Text = selectedUser.Status
                .EmailTextBox.Text = selectedUser.Email
                .ShowDialog()
            End With
            Await Task.Delay(1000)
            login.RefreshTimer.Start()
        ElseIf e.ColumnIndex = 4 Then
            Dim selectedUser = userCollection(e.RowIndex + 1)
            Dim confirm As MsgBoxResult = MsgBox($"Are you sure you want to DELETE {selectedUser.Fullname} in the database??", MsgBoxStyle.YesNo)

            If confirm = MsgBoxResult.Yes Then
                If Not haveInternetConnection() Then
                    MessageBox.Show("Internet not detected!")
                    Return
                End If
                login.RefreshTimer.Stop()
                Dim deleteQuery As String = $"DELETE FROM admin WHERE id={selectedUser.ID}"
                Await Task.Run(Function() executeNonQuery(deleteQuery, remoteConnection))
                Await Task.Delay(1000)
                login.RefreshTimer.Start()
            Else
                Return
            End If
        End If
    End Sub
End Class