Imports System.Threading
Imports System.IO.Ports
Imports System.IO
Public Class login
    Public allTabDataSet As DataSet
    Public userCollection As IEnumerable(Of MyUser)
    Public eventCollection As IEnumerable(Of MyEvent)
    Public guestCollection As IEnumerable(Of MyGuest)
    Public md5Collection As IEnumerable(Of MyMD5)
    Public temporaryGuestCollection As IEnumerable(Of MyTemporaryCopy)

    Public currentUser(1) As String

    'Just clearing the admin user credentials and uncheck the 'remember me' checkbox
    'Hiding the login form and showing the home form if it is previously used else
    'create an object with it and show it
    Public Sub showHome()
        UsernameTextBox.Clear()
        PasswordTextBox.Clear()
        RememberMeCheckBox.Checked = False
        Me.Hide()

        With home
            .TrackingReportButton.Enabled = True
            If Not currentUser(1) = "EVENT MANAGER" Then
                .UserManagementButton.Enabled = False
                .GuestManagementButton.Enabled = False
                .EventManagementButton.Enabled = False
                .AnalyticsButton.Enabled = False
            Else
                .UserManagementButton.Enabled = True
                .GuestManagementButton.Enabled = True
                .EventManagementButton.Enabled = True
                .AnalyticsButton.Enabled = True
            End If
            .Show()
        End With
    End Sub

    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        If Not haveInternetConnection() Then
            MessageBox.Show("Cannot connect to internet. Program will close")
            Me.Close()
        End If

        allTabDataSet = Await Task.Run(Function() getAllData())
        userCollection = allTabDataSet.Tables(0).AsEnumerable.Select(Function(user) New MyUser With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .Username = user.Field(Of String)("username"),
                                                                         .Password = user.Field(Of String)("password"),
                                                                         .Fullname = user.Field(Of String)("fullname"),
                                                                         .Address = user.Field(Of String)("address"),
                                                                         .Contact = user.Field(Of String)("contact"),
                                                                         .Email = user.Field(Of String)("email"),
                                                                         .Role = user.Field(Of String)("role"),
                                                                         .Status = user.Field(Of String)("status")})

        eventCollection = allTabDataSet.Tables(1).AsEnumerable.Select(Function(user) New MyEvent With {
                                                                         .GuestsID = user.Field(Of Integer)("guests_id"),
                                                                         .Registered = user.Field(Of Integer)("registered"),
                                                                         .Name = user.Field(Of String)("name"),
                                                                         .Date = user.Field(Of String)("date"),
                                                                         .Time = user.Field(Of String)("time"),
                                                                         .Type = user.Field(Of String)("type"),
                                                                         .IsPaid = user.Field(Of Boolean)("ispaid"),
                                                                         .Booker = user.Field(Of String)("booker")})

        guestCollection = allTabDataSet.Tables(2).AsEnumerable.Select(Function(user) New MyGuest With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .GuestID = user.Field(Of Integer)("guest_id"),
                                                                         .Logs = user.Field(Of String)("logs"),
                                                                         .RFID = user.Field(Of String)("rfid"),
                                                                         .Name = user.Field(Of String)("name"),
                                                                         .Address = user.Field(Of String)("address"),
                                                                         .Email = user.Field(Of String)("email"),
                                                                         .Number = user.Field(Of String)("number"),
                                                                         .Type = user.Field(Of String)("type")})

        md5Collection = allTabDataSet.Tables(3).AsEnumerable.Select(Function(user) New MyMD5 With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .Hash = user.Field(Of String)("hash"),
                                                                         .EventName = user.Field(Of String)("event_name")})

        temporaryGuestCollection = allTabDataSet.Tables(4).AsEnumerable.Select(Function(user) New MyTemporaryCopy With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .EventName = user.Field(Of String)("event_name"),
                                                                         .GuestJSON = user.Field(Of String)("guest_json")})

        LoginButton.Enabled = True

        If SerialPort.GetPortNames.Length = 0 Then
            MessageBox.Show("GSM Module is not detected")
        End If

        Dim rememberedUserText As String = $"{defaultDirectory}\REMEMBERED.txt"
        If Not System.IO.Directory.Exists(defaultDirectory) Then
            System.IO.Directory.CreateDirectory(defaultDirectory)
            File.Create(rememberedUserText).Dispose()
        End If

        If My.Computer.FileSystem.ReadAllText(rememberedUserText).Length < 1 Then
            Return
        End If

        currentUser = Split(My.Computer.FileSystem.ReadAllText(rememberedUserText), ", ")
        If currentUser.Length > 0 Then
            showHome()
        End If
    End Sub

    Private Async Sub EventCheckerTimer_Tick(sender As Object, e As EventArgs) Handles CheckTimer.Tick
        Dim dateNow As String = Now.ToString("MM/dd/yyyy")

        Dim eventCount As Integer = eventCollection.Where(Function(currentEvent) currentEvent.Date = dateNow And currentEvent.Registered = 1).Count()

        If eventCount = 0 Then
            Return
        End If

        CheckTimer.Stop()
        StopCheckTimer.Start()

        Dim eventNow As MyEvent = eventCollection.Where(Function(currentEvent) currentEvent.Date = dateNow And currentEvent.Registered = 1).First()

        Dim guestsID As String = eventNow.GuestsID
        Dim eventName As String = eventNow.Name
        Dim eventDate As String = eventNow.Date
        Dim eventTime As String = eventNow.Time

        Dim eventNowGuests As IEnumerable(Of MyGuest) = guestCollection.Where(Function(guest) guest.GuestID = guestsID)

        Dim COMMPORT As String
        Dim smsEngine As SMSCOMMS
        If SerialPort.GetPortNames.Length = 0 Then
            MessageBox.Show("GSM Module is not detected, messages won't be sent")
        Else
            COMMPORT = SerialPort.GetPortNames(0)
            smsEngine = New SMSCOMMS(COMMPORT)
            smsEngine.Open()
        End If

        Await Task.Run(Sub()
                           For i As Integer = 0 To eventNowGuests.Count - 1
                               Dim receiverEmail As String = eventNowGuests(i).Email
                               Dim receiverNumber As String = eventNowGuests(i).Number
                               Dim name As String = eventNowGuests(i).Name

                               Dim emailSubject As String = "no reply"
                               Dim emailBody As String = $"<div style='background-color: #252e42; width: 70%; padding: 10px 50px; border-radius: 5px'><center> <h1 style='color: white; background-color: #31394d; padding: 10px; border-radius: 5px'> Event Venue Online Booking </h1></center> <p style='color: white; font-size: 18px;'>Dear our beloved guest, </p><p style='color: white; font-size: 14px;'>Just a reminder for the upcoming {eventName} on {eventDate} {eventTime}. Don't forget to bring your <b>RFID WRISTBAND</b>. See you! </p></div>"

                               sendEmail(emailSubject, emailBody, "management@event-venue.website", "@Capstone0330", receiverEmail, True)

                               If smsEngine IsNot Nothing Then
                                   smsEngine.SendSMS(eventName, eventDate, eventTime, receiverNumber)
                                   Thread.Sleep(5000)
                               End If

                           Next
                       End Sub)
        If smsEngine IsNot Nothing Then
            smsEngine.Close()
        End If

        RefreshTimer.Stop()
        Dim updateQuery As String = $"UPDATE events SET registered=2 WHERE guests_id={guestsID}"
        Await Task.Run(Sub() executeNonQuery(updateQuery, remoteConnection))

        Await Task.Delay(1000)
        refreshAllForms()
        RefreshTimer.Start()
    End Sub

    Private Sub StopCheckTimer_Tick(sender As Object, e As EventArgs) Handles StopCheckTimer.Tick
        CheckTimer.Start()
        StopCheckTimer.Stop()
    End Sub

    Public Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles RefreshTimer.Tick
        refreshAllForms()
    End Sub

    Public Async Sub refreshAllForms()
        If Not haveInternetConnection() Then
            Return
        End If
        allTabDataSet = Await Task.Run(Function() getAllData())

        If allTabDataSet Is Nothing Then
            Return
        End If

        userCollection = allTabDataSet.Tables(0).AsEnumerable.Select(Function(user) New MyUser With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .Username = user.Field(Of String)("username"),
                                                                         .Password = user.Field(Of String)("password"),
                                                                         .Fullname = user.Field(Of String)("fullname"),
                                                                         .Address = user.Field(Of String)("address"),
                                                                         .Contact = user.Field(Of String)("contact"),
                                                                         .Email = user.Field(Of String)("email"),
                                                                         .Role = user.Field(Of String)("role"),
                                                                         .Status = user.Field(Of String)("status")})

        eventCollection = allTabDataSet.Tables(1).AsEnumerable.Select(Function(user) New MyEvent With {
                                                                         .GuestsID = user.Field(Of Integer)("guests_id"),
                                                                         .Registered = user.Field(Of Integer)("registered"),
                                                                         .Name = user.Field(Of String)("name"),
                                                                         .Date = user.Field(Of String)("date"),
                                                                         .Time = user.Field(Of String)("time"),
                                                                         .Type = user.Field(Of String)("type"),
                                                                         .IsPaid = user.Field(Of Boolean)("ispaid"),
                                                                         .Booker = user.Field(Of String)("booker")})

        guestCollection = allTabDataSet.Tables(2).AsEnumerable.Select(Function(user) New MyGuest With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .GuestID = user.Field(Of Integer)("guest_id"),
                                                                         .Logs = user.Field(Of String)("logs"),
                                                                         .RFID = user.Field(Of String)("rfid"),
                                                                         .Name = user.Field(Of String)("name"),
                                                                         .Address = user.Field(Of String)("address"),
                                                                         .Email = user.Field(Of String)("email"),
                                                                         .Number = user.Field(Of String)("number"),
                                                                         .Type = user.Field(Of String)("type")})

        md5Collection = allTabDataSet.Tables(3).AsEnumerable.Select(Function(user) New MyMD5 With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .Hash = user.Field(Of String)("hash"),
                                                                         .EventName = user.Field(Of String)("event_name")})

        temporaryGuestCollection = allTabDataSet.Tables(4).AsEnumerable.Select(Function(user) New MyTemporaryCopy With {
                                                                         .ID = user.Field(Of Integer)("id"),
                                                                         .EventName = user.Field(Of String)("event_name"),
                                                                         .GuestJSON = user.Field(Of String)("guest_json")})

        If trackingReport IsNot Nothing And trackingReport.GuestSearchTextBox.Text.Length = 0 Then
            trackingReport.trackingReport_Load(Nothing, Nothing)
        End If

        If guestManagement IsNot Nothing And guestManagement.GuestSearchTextBox.Text.Length = 0 Then
            guestManagement.guestManagement_Load(Nothing, Nothing)
        End If

        If eventManagement IsNot Nothing And eventManagement.SearchTextBox.Text.Length = 0 And (eventManagement.TypeComboBox.Text = "ALL EVENTS" Or eventManagement.TypeComboBox.Text = "") Then
            eventManagement.eventManagement_Load(Nothing, Nothing)
        End If
        If userManagement IsNot Nothing Then
            userManagement.userManagement_Load(Nothing, Nothing)
        End If
        If Not analyticsReport Is Nothing Then
            analyticsReport.RefreshForm()
        End If
    End Sub

    'Login the admin if the credentials are correct, and check if they
    'preferred to be remembered
    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        LoginButton.Enabled = False

        For i As Integer = 0 To userCollection.Count - 1
            Dim username As String = userCollection(i).Username
            Dim password As String = userCollection(i).Password
            Dim status As String = userCollection(i).Status

            If UsernameTextBox.Text = username And PasswordTextBox.Text = password Then

                If status = "INACTIVE" Then
                    MessageBox.Show("This account is inactive")
                    LoginButton.Enabled = True
                    Return
                End If

                currentUser(0) = userCollection(i).Fullname
                currentUser(1) = userCollection(i).Role

                Dim rememberedUserText As String = $"{defaultDirectory}\REMEMBERED.txt"
                If RememberMeCheckBox.Checked = True Then
                    My.Computer.FileSystem.WriteAllText(rememberedUserText, $"{currentUser(0)}, {currentUser(1)}", False)
                End If

                showHome()

                LoginButton.Enabled = True
                Return
            End If
        Next
        MessageBox.Show($"Wrong username or password")
        LoginButton.Enabled = True
    End Sub
End Class