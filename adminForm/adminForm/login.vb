Imports System.IO
Public Class login
    'Login the admin if the credentials are correct, and check if they
    'preferred to be remembered
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "admin" And TextBox2.Text = "admin" Then
            If CheckBox1.Checked = True Then
                My.Computer.FileSystem.WriteAllText(
            "D:\Programming\Capstone\adminForm\adminForm\REMEMBERED.txt", "True", False)
            End If
            showHome()
        End If
    End Sub

    'Checking if there are admin user that has previously logged in
    'and just continue to the home form
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim hasRememberedUser As Boolean = Boolean.Parse(My.Computer.FileSystem.ReadAllText("D:\Programming\Capstone\adminForm\adminForm\REMEMBERED.txt"))
        If hasRememberedUser Then
            showHome()
        End If
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
            home.ShowDialog()
        Else
            home.Show()
        End If
    End Sub
End Class
