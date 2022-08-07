Imports MySql.Data.MySqlClient
Public Class loginForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        registerForm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox2.Enabled = False
            Return
        End If
        Dim user As String = TextBox1.Text
        Dim query As String = $"SELECT name FROM admin WHERE name LIKE '%{user}%'"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataset As New DataSet()
        adapter.Fill(dataset)

        Dim count As Integer = dataset.Tables(0).Rows.Count

        If count <= 1 Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Button1.Enabled = False
        End If

        Dim user As String = TextBox1.Text
        Dim query As String = $"SELECT name, password FROM admin WHERE name LIKE '%{user}%'"
        Dim adapter As New MySqlDataAdapter(query, connection)
        Dim dataset As New DataSet()
        adapter.Fill(dataset)

        Dim Tpassword = dataset.Tables(0).Rows(0)(1)

        If TextBox2.Text = Tpassword Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub loginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        registerForm.ShowDialog()
        Me.Close()
    End Sub
End Class
