Imports System.Runtime.InteropServices
Imports System.Text

Public Class eventManagementEditORAddEvent
    Public selectedEventGuestsID As String
    Public selectedBookerID As String

    Public beforePaid As Boolean = False

    Public transactionType As String

    Public Function getRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Private Sub EventDateTimePicker_CloseUp(sender As Object, e As EventArgs) Handles EventDateTimePicker.CloseUp
        Dim selectedDate As String = EventDateTimePicker.Value.ToString("MM/dd/yyyy")

        Dim checkDate As IEnumerable(Of MyEvent)

        If selectedEventGuestsID = "" Then
            checkDate = login.eventCollection.Where(Function(currentEvent) currentEvent.Date = selectedDate)
        Else
            checkDate = login.eventCollection.Where(Function(currentEvent) currentEvent.Date = selectedDate And currentEvent.GuestsID <> Integer.Parse(selectedEventGuestsID))
        End If

        If checkDate.Any Then
            MessageBox.Show("There is already an event booked for that date! Please pick another date...")
            SaveButton.BackColor = Color.Red
            SaveButton.Enabled = False
        Else
            SaveButton.BackColor = Color.DodgerBlue
            SaveButton.Enabled = True
        End If
    End Sub

    Private Async Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        SaveButton.Enabled = False

        Dim emptyTextBoxes =
            From txt In Me.Panel1.Controls.OfType(Of TextBox)()
            Where txt.Text.Length = 0 And txt.Name <> RFIDTextBox.Name
            Select txt.Name
        If emptyTextBoxes.Any Then
            MessageBox.Show("Please fill up all the fields")
            SaveButton.Enabled = True
            Return
        End If

        If RFIDTextBox.Text.Length > 0 And RFIDTextBox.Text.Length <> 10 Then
            MessageBox.Show("Invalid RFID")
            SaveButton.Enabled = True
            Return
        End If

        Dim md5Provider = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim randomNumber As Integer = getRandom(0, EventNameTextBox.Text.Length * 1000)
        Dim computeHash = System.Text.Encoding.UTF8.GetBytes(randomNumber.ToString())
        computeHash = md5Provider.ComputeHash(computeHash)
        Dim stringBuilder = New System.Text.StringBuilder()
        For Each var As Byte In computeHash
            stringBuilder.Append(var.ToString("x2").ToLower())
        Next

        'UPDATE Database if the user is only editing
        If transactionType = "EDIT" Then
            'Create and md5 hash for the event
            If Not haveInternetConnection() Then
                MessageBox.Show("Internet not detected!")
                Return
            End If
            Dim updateQuery As String = $"UPDATE events SET name='{EventNameTextBox.Text.Replace("'", "\'")}', date='{EventDateTimePicker.Value.ToString("MM/dd/yyyy")}', time='{TimeTextBox.Text}', type='{TypeComboBox.Text}', booker='{BookerNameTextBox.Text}', ispaid={PaidCheckBox.Checked} WHERE guests_id={selectedEventGuestsID}; UPDATE guest SET rfid='{RFIDTextBox.Text}', name='{BookerNameTextBox.Text}', address='{AddressTextBox.Text}', email='{EmailTextBox.Text}', number='{BookerContactTextBox.Text}' WHERE id={selectedBookerID}; INSERT INTO md5(hash, event_name) VALUES('{stringBuilder.ToString()}', '{EventNameTextBox.Text.Replace("'", "\'")}')"
            Dim updateSuccess As Boolean = Await Task.Run(Function() executeNonQuery(updateQuery, remoteConnection))


            If updateSuccess Then
                'Send an email to the event booker for newly paid events
                'where they can send the payment
                If PaidCheckBox.Checked And Not beforePaid Then
                    Dim eventName As String = EventNameTextBox.Text.Replace("'", "\'")
                    Dim emailSubject As String = $"Hello {BookerNameTextBox.Text}! Thank you for chossing us."
                    Dim emailBody As String = $"<div style='background-color: #252e42; width: 70%; padding: 10px 50px; border-radius: 5px'><center> <h1 style='color: white; background-color: #31394d; padding: 10px; border-radius: 5px'> Event Management Online Booking </h1></center> <p style='color: white; font-size: 18px;'>Dear our beloved guest, </p><p style='color: white; font-size: 14px;'>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </p> <br> <br> <center> <a href='https://event-venue.website/guest.php?eventName={stringBuilder.ToString()}' style='text-decoration: none; padding: 10px; background-color: dodgerblue; color: white; border-radius: 5px;' onMouseOver='this.style.background=""blue""' onMouseOut='this.style.background=""dodgerblue""'>CLICK HERE</a> <br> <br> <p style='color: white;'>Have a great day!</p> </center></div>"
                    'Dim emailBody As String = $"You can visit <a href=""event-venue.website/guest.php?eventName={TextBox1.Text.Replace("'", "\'")}"">event-venue.website/guest.php</a> to insert your guest."

                    Await Task.Run(Sub() sendEmail(emailSubject, emailBody, "management@event-venue.website", "@Capstone0330", EmailTextBox.Text, True))
                End If

                MessageBox.Show("Event updated succesfully!")

                transactionType = ""
                clearAll()
                login.refreshAllForms()
                SaveButton.Enabled = True
                Me.Close()
            End If

        Else
            If Not haveInternetConnection() Then
                MessageBox.Show("Internet not detected!")
                Return
            End If
            'Get the highest available value for event guests_id
            Dim query2 As String = $"SELECT `AUTO_INCREMENT` FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'u608197321_real_capstone' AND TABLE_NAME = 'events';"
            Dim ds As DataSet = Await Task.Run(Function() getData(query2))


            'INSERT values into Database if the user is adding
            Dim insertQuery = $"INSERT INTO events(name, date, time, type, booker, ispaid) VALUES('{EventNameTextBox.Text.Replace("'", "\'")}', '{EventDateTimePicker.Value.ToString("MM/dd/yyyy")}', '{TimeTextBox.Text}', '{TypeComboBox.Text}', '{BookerNameTextBox.Text}', {PaidCheckBox.Checked}); INSERT INTO guest(guest_id, rfid, name, address, email, number, type) VALUES({ds.Tables(0).Rows(0)(0)}, '{RFIDTextBox.Text}', '{BookerNameTextBox.Text}', '{AddressTextBox.Text}', '{EmailTextBox.Text}', '{BookerContactTextBox.Text}', 'BOOKER'); INSERT INTO temporary_guest_copy(event_name, guest_json) VALUES('{EventNameTextBox.Text.Replace("'", "\'")}', ''); INSERT INTO md5(hash, event_name) VALUES('{stringBuilder.ToString()}', '{EventNameTextBox.Text.Replace("'", "\'")}')"
            Dim insertSuccess As Boolean = Await Task.Run(Function() executeNonQuery(insertQuery, remoteConnection))

            'Dim query3 = $"INSERT INTO guest(guest_id, rfid, name, address, email, number, type, edited) VALUES({ds.Tables(0).Rows(0)(0)}, '{TextBox6.Text}', '{TextBox3.Text}', '{TextBox2.Text}', '{TextBox5.Text}', '{TextBox4.Text}', 'BOOKER', 2)"
            'Dim guestSuccess1 As Boolean = executeNonQuery(query3, localConnection)

            If insertSuccess Then
                Dim eventName As String = EventNameTextBox.Text.Replace("'", "\'")
                Dim emailSubject As String = $"Hello {BookerNameTextBox.Text}! Thank you for chossing us."
                Dim emailBody As String = $"<div style='background-color: #252e42; width: 70%; padding: 10px 50px; border-radius: 5px'><center> <h1 style='color: white; background-color: #31394d; padding: 10px; border-radius: 5px'> Event Management Online Booking </h1></center> <p style='color: white; font-size: 18px;'>Dear our beloved guest, </p><p style='color: white; font-size: 14px;'>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. </p> <br> <br> <center> <a href='https://event-venue.website/guest.php?eventName={stringBuilder.ToString()}' style='text-decoration: none; padding: 10px; background-color: dodgerblue; color: white; border-radius: 5px;' onMouseOver='this.style.background=""blue""' onMouseOut='this.style.background=""dodgerblue""'>CLICK HERE</a> <br> <br> <p style='color: white;'>Have a great day!</p> </center></div>"
                'Dim emailBody As String = $"You can visit <a href=""event-venue.website/guest.php?eventName={TextBox1.Text.Replace("'", "\'")}"">event-venue.website/guest.php</a> to insert your guest."

                Await Task.Run(Sub() sendEmail(emailSubject, emailBody, "management@event-venue.website", "@Capstone0330", EmailTextBox.Text, True))

                MessageBox.Show("Event added succesfully!")

                transactionType = ""
                clearAll()
                login.refreshAllForms()
                SaveButton.Enabled = True
            End If
        End If
    End Sub

    'Clear the editOrAddEvent property of eventManagement.
    'Refreshes eventManagement and guesManagement forms.
    'Close the form.
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        EventNameTextBox.Clear()
        AddressTextBox.Clear()
        BookerNameTextBox.Clear()
        BookerContactTextBox.Clear()
        EmailTextBox.Clear()
        RFIDTextBox.Clear()
        TimeTextBox.Clear()

        TypeComboBox.Text = ""

        transactionType = ""
        Me.Close()
    End Sub

    Private Sub PaidCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PaidCheckBox.CheckedChanged
        If PaidCheckBox.Checked = True Then
            NotPaidCheckBox.Checked = False
        Else
            NotPaidCheckBox.Checked = True
        End If
    End Sub

    Private Sub NotPaidCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles NotPaidCheckBox.CheckedChanged
        If NotPaidCheckBox.Checked = True Then
            PaidCheckBox.Checked = False
        Else
            PaidCheckBox.Checked = True
        End If
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, EditOrAddLabel.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub eventManagementEditORAddEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub
End Class