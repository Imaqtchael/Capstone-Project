
Imports System.Runtime.InteropServices

Public Class userManagementAddOREditUser
    Dim ds As DataSet
    Private Sub userManagementAddOREditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        home.Enabled = False
        Me.TopMost = True

        If userManagement.editORAdd = "edit" Then
            Label1.Text = "EDIT USER"
            ds = getData($"SELECT username, password, fullname, address, contact, email, role, id FROM admin WHERE fullname='{userManagement.selectedUser}'")

            TextBox1.Text = ds.Tables(0).Rows(0)(2)
            TextBox2.Text = ds.Tables(0).Rows(0)(0)
            TextBox3.Text = ds.Tables(0).Rows(0)(1)
            TextBox4.Text = ds.Tables(0).Rows(0)(3)
            TextBox5.Text = ds.Tables(0).Rows(0)(4)
            ComboBox1.Text = ds.Tables(0).Rows(0)(6)
            TextBox7.Text = ds.Tables(0).Rows(0)(5)
        End If
    End Sub
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            Return
        End If
        Button1.Enabled = False
        If userManagement.editORAdd = "edit" Then
            Dim selectedUserID As String = ds.Tables(0).Rows(0)(7)
            Dim query2 As String = $"UPDATE admin SET fullname='{TextBox1.Text}', username='{TextBox2.Text}', password='{TextBox3.Text}', address='{TextBox4.Text}', contact='{TextBox5.Text}', email='{TextBox7.Text}', role='{ComboBox1.Text}', edited=1 WHERE id='{selectedUserID}'"
            Dim userSuccess As Boolean = executeNonQuery(query2, localConnection)


            If userSuccess Then
                userManagement.editORAdd = ""
                login.refreshAllForms()
                Button1.Enabled = True
                home.Enabled = True
                Me.Close()
            End If
            Return
        End If

        Dim query As String = $"INSERT INTO admin(username, password, fullname, address, contact, email, role, edited) VALUES('{TextBox2.Text}', '{TextBox3.Text}', '{TextBox1.Text}', '{TextBox4.Text}', '{TextBox5.Text}', '{TextBox7.Text}', '{ComboBox1.Text}', 2)"
        Dim insertSuccess As Boolean = Await Task.Run(Function() executeNonQuery(query, localConnection))


        If insertSuccess Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = ""
            TextBox7.Clear()

            userManagement.editORAdd = ""
        End If
        Button1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        userManagement.editORAdd = ""
        Button1.Enabled = True
        home.Enabled = True
        Me.Close()
    End Sub


    'Casting Shadow to the Form
    Private Const CS_DROPSHADOW As Integer = 131072
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_DROPSHADOW
            Return cp
        End Get
    End Property

    'Enables the user to drag the form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

End Class