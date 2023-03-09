Public Class analyticsReport
    Private Sub analyticsReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshForm()
    End Sub

    Public Sub RefreshForm()
        'For events
        Dim allEvents = login.eventCollection
        Dim allGuests = login.guestCollection
        Dim allEventsCount As Integer = allEvents.Count
        Dim VIPEventsCount As Integer = allEvents.Where(Function(currentEvent) currentEvent.Type = "VIP MEETING").Count()
        Dim BirthdayEventsCount As Integer = allEvents.Where(Function(currentEvent) currentEvent.Type = "BIRTHDAY").Count()
        Dim WeddingEventsCount As Integer = allEvents.Where(Function(currentEvent) currentEvent.Type = "WEDDING").Count()
        Dim events = allEvents.Where(Function(currentEvent) currentEvent.Registered = 2)
        Dim allGuestsCount As Integer = 0
        Dim attendeesCount As Integer = 0

        For i As Integer = 0 To events.Count - 1
            allGuestsCount += allGuests.Where(Function(guest) guest.GuestID = events(i).GuestsID).Count()
            attendeesCount += allGuests.Where(Function(guest) guest.GuestID = events(i).GuestsID And guest.Logs <> "").Count()
        Next

        OverallBookedLabel.Text = allEventsCount
        EventCountLabel.Text = events.Count
        GuestCountLabel.Text = allGuestsCount

        EventsChart.Series("Event Count").Points.Clear()


        Dim listOfMonths(7) As String

        For i As Integer = 7 To 0 Step -1
            listOfMonths(7 - i) = Date.Now.AddMonths(-i).ToString("MMMM yyyy")
        Next

        For i As Integer = 0 To 7
            Dim currentMonthName As String = listOfMonths(i)
            Dim currentEventCount As Integer = allEvents.Where(Function(currentEvent) Convert.ToDateTime(currentEvent.Date).ToString("MMMM yyyy") = currentMonthName).Count
            EventsChart.Series("Event Count").Points.AddXY(currentMonthName, currentEventCount)
        Next

        GuestsChart.Series("Guest Attending Percentage").Points.Clear()
        EventChart.Series("Events").Points.Clear()

        GuestsChart.Series("Guest Attending Percentage").Points.AddXY("Attended", attendeesCount)
        GuestsChart.Series("Guest Attending Percentage").Points.AddXY("Did not attend", allGuestsCount - attendeesCount)
        If VIPEventsCount > 0 Then
            EventChart.Series("Events").Points.AddXY("VIP METTINGS", VIPEventsCount / allEventsCount)
        End If
        If BirthdayEventsCount > 0 Then
            EventChart.Series("Events").Points.AddXY("BIRTHDAYS", BirthdayEventsCount / allEventsCount)
        End If
        If WeddingEventsCount > 0 Then
            EventChart.Series("Events").Points.AddXY("WEDDINGS", WeddingEventsCount / allGuestsCount)
        End If

    End Sub
End Class