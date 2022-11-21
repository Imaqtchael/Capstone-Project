Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Public Class guestManagementAddGuest
    Dim query As String = $"SELECT guests_id, name, date FROM events"
    Dim ds As New DataSet()
    Dim guestID, eventDate As String
    Dim loadDone As Boolean = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            Return
        End If

        If TextBox7.Text.Length <> 10 Then
            MessageBox.Show("Invalid RFID")
            Return
        End If

        Dim confirm As MsgBoxResult = MsgBox("Are you sure about all of the infromations?", MsgBoxStyle.YesNo)
        Dim completed As Boolean = True

        If confirm = MsgBoxResult.Yes Then
            Dim localQuery = $"INSERT INTO guest(guest_id, rfid, name, address, email, number, type) VALUES({guestID}, '{TextBox7.Text}', '{TextBox1.Text}', '{TextBox2.Text}', '{TextBox4.Text}', '{TextBox3.Text}', 'guest')"
            completed = executeNonQuery(localQuery)
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

    Private Sub guestManagementAddGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Timer1.Tick
        ds = getData(query)

        If Not loadDone Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ComboBox1.Items.Add(ds.Tables(0).Rows(i)(1))
            Next
        End If

        loadDone = True
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        sender.DroppedDown = True
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If sender.Text.Length = 0 Then
            Return
        End If
        guestID = ds.Tables(0).Rows(ComboBox1.SelectedIndex)(0)
        eventDate = ds.Tables(0).Rows(ComboBox1.SelectedIndex)(2)

        TextBox5.Text = eventDate
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        guestManagement.guestManagement_Load(Nothing, Nothing)
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