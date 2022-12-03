Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient

Public Class guestManagementEditGuest
    Dim query As String = $"SELECT guest_id, name, address, number, email, rfid, id FROM guest WHERE name='{guestManagement.selectedGuestName}' AND guest_id={guestManagement.selectedGuestEventID}"
    Dim ds As New DataSet()

    Dim eventsTable As DataTable

    Dim guestID, eventDate As String

    Dim loadDone As Boolean = False
    Dim id As String

    Private Sub guestManagementEditGuest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ds = getData(query)
        id = ds.Tables(0).Rows(0)(6)

        If ds.Tables(0).Rows.Count < 1 Then
            Return
        End If

        eventsTable = home.allTabDataSet.Tables(1)

        'Dim guestID As String = ds.Tables(0).Rows(0)(0)

        'Dim query1 As String = $"SELECT name, date FROM events WHERE guests_id='{guestID}'"
        'Dim ds1 As DataSet = getData(query1)

        Dim guestEvent = eventsTable.AsEnumerable.Select(Function(eve) New With {
                                .name = eve.Field(Of String)("name"),
                                .date = eve.Field(Of String)("date"),
                                .guests_id = eve.Field(Of Integer)("guests_id")
                            }).Where(Function(eve) eve.guests_id = guestManagement.selectedGuestEventID)

        TextBox1.Text = ds.Tables(0).Rows(0)(1)
        TextBox2.Text = ds.Tables(0).Rows(0)(2)
        TextBox3.Text = ds.Tables(0).Rows(0)(3)
        TextBox4.Text = ds.Tables(0).Rows(0)(4)
        TextBox5.Text = guestEvent(0).date
        TextBox7.Text = ds.Tables(0).Rows(0)(5)

        For i As Integer = 0 To eventsTable.Rows.Count - 1
            ComboBox1.Items.Add(eventsTable.Rows(i)(1))
        Next

        ComboBox1.Text = guestEvent(0).name
        loadDone = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If sender.Text.Length = 0 Or Not loadDone Then
            Return
        End If
        TextBox5.Text = eventsTable.Rows(ComboBox1.SelectedIndex)(2)
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

        Dim guestID As DataSet = getData($"SELECT guests_id FROM events WHERE name='{ComboBox1.Text}'")

        Dim localquery = $"UPDATE guest SET guest_id={guestID.Tables(0).Rows(0)(0)}, rfid='{TextBox7.Text}', name='{TextBox1.Text}', address='{TextBox2.Text}', email='{TextBox4.Text}', number='{TextBox3.Text}' WHERE id={id}"
        executeNonQuery(localquery, localConnection)

        MessageBox.Show("Guest Information updated successfully!")

        guestManagement.guestManagement_Load(Nothing, Nothing)
        Me.Close()
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