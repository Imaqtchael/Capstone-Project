Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class guestManagementAddGuest
    Dim guestID, eventDate As String
    Dim loadDone As Boolean = False

    Dim eventTable As DataTable

    Private Sub guestManagementAddGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        home.Enabled = False
        Me.TopMost = True

        Button1.Enabled = True
        eventTable = login.allTabDataSet.Tables(1)

        If Not loadDone Then
            For i As Integer = 0 To eventTable.Rows.Count - 1
                ComboBox1.Items.Add(eventTable.Rows(i)(1))
            Next
        End If

        loadDone = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0 And txt.Name <> TextBox7.Name
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            Return
        End If

        If TextBox7.Text.Length > 0 And TextBox7.Text.Length <> 10 Then
            MessageBox.Show("Invalid RFID")
            Return
        End If

        Dim confirm As MsgBoxResult = MsgBox("Are you sure about all of the infromations?", MsgBoxStyle.YesNo)
        Dim completed As Boolean = True

        If confirm = MsgBoxResult.Yes Then
            Dim localQuery = $"INSERT INTO guest(guest_id, rfid, name, address, email, number, type, edited) VALUES({guestID}, '{TextBox7.Text}', '{TextBox1.Text}', '{TextBox2.Text}', '{TextBox4.Text}', '{TextBox3.Text}', 'GUEST', 2)"
            completed = executeNonQuery(localQuery, localConnection)

        Else
            Return
        End If
        If completed Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = ""
        End If

        TextBox7.Clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        guestID = eventTable.Rows(ComboBox1.SelectedIndex)(0)
        eventDate = eventTable.Rows(ComboBox1.SelectedIndex)(2)

        TextBox5.Text = eventDate
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class