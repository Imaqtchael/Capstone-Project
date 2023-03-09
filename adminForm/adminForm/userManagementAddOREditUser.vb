Imports System.Runtime.InteropServices

Public Class userManagementAddOREditUser
    Public transactionType As String
    Public selectedUserID As String
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveButton.Enabled = False
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            SaveButton.Enabled = True
            Return
        End If

        If transactionType = "EDIT" Then
            If Not haveInternetConnection() Then
                MessageBox.Show("Internet not detected!")
                Return
            End If
            Dim updateQuery As String = $"UPDATE admin SET fullname='{FullNameTextBox.Text}', username='{UserNameTextBox.Text}', password='{PasswordTextBox.Text}', address='{AddressTextBox.Text}', contact='{ContactTextBox.Text}', email='{EmailTextBox.Text}', role='{RoleComboBox.Text}', status='{StatusComboBox.Text}' WHERE id='{selectedUserID}'"
            Dim updateSuccess As Boolean = Await Task.Run(Function() executeNonQuery(updateQuery, remoteConnection))

            If updateSuccess Then
                MessageBox.Show("User info updated successfully!")
                FullNameTextBox.Clear()
                UserNameTextBox.Clear()
                PasswordTextBox.Clear()
                AddressTextBox.Clear()
                ContactTextBox.Clear()
                RoleComboBox.Text = ""
                StatusComboBox.Text = ""
                EmailTextBox.Clear()
                userManagement.editORAdd = ""

                login.refreshAllForms()
                SaveButton.Enabled = True
                Me.Close()
            End If
            SaveButton.Enabled = True
            Return

        Else
            If Not haveInternetConnection() Then
                MessageBox.Show("Internet not detected!")
                Return
            End If
            Dim insertQuery As String = $"INSERT INTO admin(username, password, fullname, address, contact, email, role, status) VALUES('{UserNameTextBox.Text}', '{PasswordTextBox.Text}', '{FullNameTextBox.Text}', '{AddressTextBox.Text}', '{ContactTextBox.Text}', '{EmailTextBox.Text}', '{RoleComboBox.Text}', '{StatusComboBox.Text}')"
            Dim insertSuccess As Boolean = Await Task.Run(Function() executeNonQuery(insertQuery, remoteConnection))

            If insertSuccess Then
                MessageBox.Show("User added successfully!")
                FullNameTextBox.Clear()
                UserNameTextBox.Clear()
                PasswordTextBox.Clear()
                AddressTextBox.Clear()
                ContactTextBox.Clear()
                RoleComboBox.Text = ""
                StatusComboBox.Text = ""
                EmailTextBox.Clear()
                userManagement.editORAdd = ""
                login.refreshAllForms()
            End If
            SaveButton.Enabled = True
        End If
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        FullNameTextBox.Clear()
        UserNameTextBox.Clear()
        PasswordTextBox.Clear()
        AddressTextBox.Clear()
        ContactTextBox.Clear()
        EmailTextBox.Clear()

        RoleComboBox.Text = ""
        StatusComboBox.Text = ""

        transactionType = ""
        SaveButton.Enabled = True
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel1.MouseDown, EditOrAddLabel.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub userManagementAddOREditUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class