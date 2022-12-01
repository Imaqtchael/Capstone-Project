Imports System.IO
Public Class login
    Dim role As String

    'Checking if there are admin user that has previously logged in
    'and just continue to the home form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        role = My.Computer.FileSystem.ReadAllText("..\..\..\REMEMBERED.txt")
        If role.Length > 0 Then
            showHome()
        End If
    End Sub

    'Login the admin if the credentials are correct, and check if they
    'preferred to be remembered
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Dim ds As DataSet = Await Task.Run(Function() getData("SELECT username, password, role FROM admin"))

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            Dim username As String = ds.Tables(0).Rows(i)(0)
            Dim password As String = ds.Tables(0).Rows(i)(1)
            If TextBox1.Text = username And TextBox2.Text = password Then
                role = ds.Tables(0).Rows(i)(2)
                If CheckBox1.Checked = True Then
                    My.Computer.FileSystem.WriteAllText(
                "..\..\..\REMEMBERED.txt", role, False)
                End If
                showHome()
                Button1.Enabled = True
                Return
            End If
        Next
        MessageBox.Show("Wrong username or password")
        Button1.Enabled = True

    End Sub

    'Just clearing the admin user credentials and uncheck the 'remember me' checkbox
    'Hiding the login form and showing the home form if it is previously used else
    'create an object with it and show it
    Private Sub showHome()
        TextBox1.Clear()
        TextBox2.Clear()
        CheckBox1.Checked = False
        Me.Hide()
        If home Is Nothing Then
            If Not role = "EVENT MANAGER" Then
                home.Button4.Enabled = False
                home.Button2.Enabled = False
                home.Button3.Enabled = False
            End If
            home.ShowDialog()
        Else
            If Not role = "EVENT MANAGER" Then
                home.Button4.Enabled = False
                home.Button2.Enabled = False
                home.Button3.Enabled = False
            End If
            home.Show()
        End If
    End Sub
End Class
