Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient

Public Class eventManagementEditORAddEvent
    Dim editEventGuestsID As String
    Dim selectedBookerID As String
    Dim loadDone As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Check for empty textboxes
        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            Return
        End If

        'UPDATE Database if the user is only editing
        If eventManagement.editOrAddEvent = "edit" Then
            Dim query As String = $"UPDATE events SET name='{TextBox1.Text}', date='{DateTimePicker1.Value.ToString("M/dd/yyyy")}', time='{TextBox7.Text}', type='{ComboBox1.Text}', booker='{TextBox3.Text}' WHERE guests_id={editEventGuestsID}"
            Dim eventSuccess As Boolean = executeNonQuery(query)

            query = $"UPDATE guest SET rfid='{TextBox6.Text}', name='{TextBox3.Text}', address='{TextBox2.Text}', email='{TextBox5.Text}', number='{TextBox4.Text}' WHERE id={selectedBookerID}"
            Dim guestSuccess As Boolean = executeNonQuery(query)

            If eventSuccess And guestSuccess Then
                eventManagement.editOrAddEvent = ""
                Me.Close()
            End If
            loadDone = False
            Return
        End If

        'INSERT values into Database if the user is adding
        Dim query1 = $"INSERT INTO events(name, date, time, type, booker) VALUES('{TextBox1.Text}', '{DateTimePicker1.Value.ToString("M/dd/yyyy")}', '{TextBox7.Text}', '{ComboBox1.Text}', '{TextBox3.Text}')"
        Dim eventSuccess1 As Boolean = executeNonQuery(query1)

        Dim query2 As String = $"SELECT guests_id FROM events WHERE name='{TextBox1.Text}'"
        Dim ds As DataSet = getData(query2)

        Dim query3 = $"INSERT INTO guest(guest_id, rfid, name, address, email, number, type) VALUES({ds.Tables(0).Rows(0)(0)}, '{TextBox6.Text}', '{TextBox3.Text}', '{TextBox2.Text}', '{TextBox5.Text}', '{TextBox4.Text}', 'booker')"
        Dim guestSuccess1 As Boolean = executeNonQuery(query3)

        If eventSuccess1 And guestSuccess1 Then
            clearAll()
            eventManagement.editOrAddEvent = ""
            loadDone = False
        End If
    End Sub

    Private Sub eventManagementEditORAddGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Adding values on form_load to the textboxes if the user is editing
        If eventManagement.editOrAddEvent = "edit" Then
            Label1.Text = "EDIT EVENT"

            Dim query As String = $"SELECT name, date, type, booker, guests_id, time FROM events WHERE name='{eventManagement.editEvent}'"
            Dim ds As DataSet = getData(query)

            Dim query1 As String = $"SELECT rfid, name, address, email, number, id FROM guest WHERE name='{ds.Tables(0).Rows(0)(3)}'"
            Dim ds1 As DataSet = getData(query1)

            TextBox1.Text = ds.Tables(0).Rows(0)(0)
            DateTimePicker1.Value = ds.Tables(0).Rows(0)(1)
            ComboBox1.Text = ds.Tables(0).Rows(0)(2)

            TextBox3.Text = ds1.Tables(0).Rows(0)(1)
            TextBox2.Text = ds1.Tables(0).Rows(0)(2)
            TextBox4.Text = ds1.Tables(0).Rows(0)(4)
            TextBox5.Text = ds1.Tables(0).Rows(0)(3)
            TextBox6.Text = ds1.Tables(0).Rows(0)(0)
            TextBox7.Text = ds.Tables(0).Rows(0)(5)

            editEventGuestsID = ds.Tables(0).Rows(0)(4)
            selectedBookerID = ds1.Tables(0).Rows(0)(5)

            Button1.BackColor = Color.DodgerBlue
            Button1.Enabled = True
        End If
        loadDone = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'Check if selected date is available

        Dim selectedDate As String = DateTimePicker1.Value.ToString("M/dd/yyyy")
        MessageBox.Show(selectedDate)
        Dim dateNow As Date = Date.Now
        If DateTimePicker1.Value < dateNow Then
            MessageBox.Show("Cannot select a date from the past or the date today!")
            Button1.Enabled = False
            Return
        Else
            Button1.Enabled = True
        End If

        Dim dateDT As DataSet = getData($"SELECT * FROM events WHERE date='{selectedDate}'")

        If dateDT.Tables(0).Rows.Count > 0 Then
            If loadDone Then
                MessageBox.Show("There is already an event booked for that date! Please pick another date...")
                Button1.BackColor = Color.Red
                Button1.Enabled = False
            End If
        Else
            Button1.BackColor = Color.DodgerBlue
            Button1.Enabled = True

        End If

    End Sub

    'For UI Management
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        eventManagement.editOrAddEvent = ""
        eventManagement.eventManagement_Load(Nothing, Nothing)
        guestManagement.guestManagement_Load(Nothing, Nothing)
        Me.Close()
    End Sub
    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        sender.DroppedDown = True
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