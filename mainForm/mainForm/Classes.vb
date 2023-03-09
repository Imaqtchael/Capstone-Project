Public Module Classes
    Public Class MyEvent
        Property GuestsID As Integer
        Property Registered As Integer
        Property Name As String
        Property [Date] As String
        Property Time As String
        Property Type As String
        Property IsPaid As Boolean
        Property Booker As String
        Sub New()

        End Sub
    End Class

    Public Class MyGuest
        Property ID As Integer
        Property GuestID As Integer
        Property Logs As String
        Property RFID As String
        Property Name As String
        Property Address As String
        Property Email As String
        Property Number As String
        Property Type As String
        Sub New()

        End Sub
    End Class
End Module
