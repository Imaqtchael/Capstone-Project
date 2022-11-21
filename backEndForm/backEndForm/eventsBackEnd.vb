Imports System.Threading
Imports MySql.Data.MySqlClient
Public Class eventsBackEnd
    Dim status As String = "SEARCHING"

    Dim searchingMessage As String = "SEARCHING..."
    Dim searchingCounter As Integer = 9

    Dim sendingMessage As String = "SENDING MESSAGES AND EMAILS..."
    Dim sendingCounter As Integer = 27

    Dim guestsID As String
    Dim table As New DataSet
    Dim eventName As String
    Dim eventDetails As String() = {"", ""}

    Dim smsEngine As New SMSCOMMS("COM3")

    Private Async Sub eventsBackEnd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Return
        Dim query As String = $"SELECT guests_id, name, date, time FROM events WHERE date = '10/28/22')"
        Dim adpt As New MySqlDataAdapter(query, con)
        Dim ds As New DataSet()

        adpt.Fill(ds)

        If ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("here")
            Return
        End If

        status = "SENDING"

        eventName = ds.Tables(0).Rows(0)(1)
        eventDetails(0) = ds.Tables(0).Rows(0)(2)
        eventDetails(1) = ds.Tables(0).Rows(0)(3)

        guestsID = ds.Tables(0).Rows(0)(0)

        Dim query1 As String = $"SELECT email, number, name FROM guest WHERE guest_id={guestsID}"
        Dim adpt1 As New MySqlDataAdapter(query1, con)

        adpt1.Fill(table)
        Await Task.Run(Sub()
                           For i As Integer = 0 To table.Tables(0).Rows.Count - 1
                               Dim receiverEmail As String = table.Tables(0).Rows(i)(0)
                               Dim receiverNumber As String = table.Tables(0).Rows(i)(1)
                               Dim name As String = table.Tables(0).Rows(i)(2)

                               Me.Invoke(Sub()
                                             TextBox1.Text += $"Sending email to {name}...   "
                                         End Sub)

                               sendEmail(eventName, eventDetails, "mjbrcns51@gmail.com", "tkzoblulgmuleflh", receiverEmail)



                               smsEngine.Open()
                               smsEngine.SendSMS(eventName, eventDetails, receiverNumber)
                               Thread.Sleep(2000)

                               Me.Invoke(Sub()
                                             TextBox1.Text += $"Done!{Environment.NewLine}"
                                         End Sub)
                           Next
                       End Sub)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If status = "SEARCHING" Then
            If searchingCounter = 13 Then
                searchingCounter = 9
            End If
            statusLabel.Text = searchingMessage.Substring(0, searchingCounter)
            searchingCounter += 1
        Else
            If sendingCounter = 31 Then
                sendingCounter = 27
            End If
            statusLabel.Text = sendingMessage.Substring(0, sendingCounter)
            sendingCounter += 1
        End If
    End Sub
End Class