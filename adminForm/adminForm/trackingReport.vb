Imports System.Globalization
Imports System.Windows.Forms.Design

Public Class trackingReport
    Public eventName As String
    Public guestsID As Integer
    Dim eventDate As String

    Dim selectedEventIndex As Integer = 0

    Dim loadDone As Boolean = False

    'Refresh the DataGridView1 for a given event
    Private Sub refreshDataGridView(ByVal eventIndex As Integer)
        EventsComboBox.Enabled = False
        EventsComboBox.Items.Clear()

        TrackingDataGridView.Rows.Clear()
        DateLabel.Text = ""
        GuestInLabel.Text = ""
        GuestOutLabel.Text = ""
        EventsComboBox.Text = ""

        Dim dateNow As String = Date.Now.ToString("MM/dd/yyyy")

        Dim eventCollection As IEnumerable(Of MyEvent) = login.eventCollection.Where(Function(currentEvent) Date.ParseExact(currentEvent.Date, "MM/dd/yyyy", CultureInfo.InvariantCulture) <= Date.ParseExact(dateNow, "MM/dd/yyyy", CultureInfo.InvariantCulture) And currentEvent.Registered = 2)

        If eventCollection.Count = 0 Then
            Return
        End If

        eventName = eventCollection(eventIndex).Name
        guestsID = eventCollection(eventIndex).GuestsID
        eventDate = eventCollection(eventIndex).Date

        For i As Integer = 0 To eventCollection.Count - 1
            EventsComboBox.Items.Add(eventCollection(i).Name)
        Next

        Dim guestCollection As IEnumerable(Of MyGuest) = login.guestCollection.Where(Function(guest) guest.Logs.Length <> 0 And guest.GuestID = guestsID)
        Dim guestCount As Integer = guestCollection.Where(Function(guest) guest.GuestID = guestsID).Count

        EventsComboBox.Text = eventName
        DateLabel.Text = eventDate
        GuestInLabel.Text = guestCollection.Count
        GuestOutLabel.Text = guestCount

        If Not loadDone Then
            TrackingDataGridView.Columns.AddRange(New DataGridViewColumn(3) _
                                    {New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn(),
                                     New DataGridViewTextBoxColumn()})
            loadDone = True
        End If

        TrackingDataGridView.Rows.Clear()

        For i As Integer = 0 To guestCollection.Count - 1

            Dim logs As String() = Split(guestCollection(i).Logs, ", ")
            Dim name As String = guestCollection(i).Name
            Dim firstTimeInDate As String = Split(logs(0), " ")(0)
            Dim lastTimeIn
            Dim lastTimeOut

            If Not isIn(logs) Then
                lastTimeIn = $"{Split(logs(logs.Length - 2), " ")(1)} {Split(logs(logs.Length - 2), " ")(2)}"
                lastTimeOut = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
            Else
                lastTimeIn = $"{Split(logs(logs.Length - 1), " ")(1)} {Split(logs(logs.Length - 1), " ")(2)}"
                lastTimeOut = ""
            End If
            TrackingDataGridView.Rows.Add(name, firstTimeInDate, lastTimeIn, lastTimeOut)
        Next
        EventsComboBox.Enabled = True
    End Sub

    Public Sub trackingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshDataGridView(selectedEventIndex)
    End Sub

    Private Sub GuestSearchTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GuestSearchTextBox.KeyPress
        If GuestSearchTextBox.Text.Length > 0 Then
            Dim searchingFor As String = GuestSearchTextBox.Text.ToLower()
            'Dim currentCurrencyManager As CurrencyManager = CType(BindingContext(TrackingDataGridView.DataSource), CurrencyManager)
            'currentCurrencyManager.SuspendBinding()
            For Each row As DataGridViewRow In TrackingDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If

                If Not row.Cells(0).Value.ToString.ToLower.Contains(searchingFor) Then
                    row.Visible = False
                End If
            Next
            'currentCurrencyManager.ResumeBinding()
        Else
            'Dim currentCurrencyManager As CurrencyManager = CType(BindingContext(TrackingDataGridView.DataSource), CurrencyManager)
            'currentCurrencyManager.SuspendBinding()
            For Each row As DataGridViewRow In TrackingDataGridView.Rows
                If row.Visible = False Then
                    row.Visible = True
                End If
            Next
            'currentCurrencyManager.ResumeBinding()
        End If
    End Sub

    Private Sub EventsComboBox_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles EventsComboBox.SelectionChangeCommitted
        selectedEventIndex = EventsComboBox.SelectedIndex
        GuestSearchTextBox.Clear()
        refreshDataGridView(selectedEventIndex)
    End Sub

    Private Sub TrackingDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles TrackingDataGridView.CellDoubleClick
        Dim row As DataGridViewRow = TrackingDataGridView.CurrentRow
        Dim guestName = row.Cells(0).Value.ToString()
        Dim selectedGuest As MyGuest = login.guestCollection.Where(Function(guest) guest.Name = guestName And guest.GuestID = guestsID).First()
        Dim selectedGuestLogs As String() = Split(selectedGuest.Logs, ", ")

        Dim realDataTable As New DataTable()
        addColumns(2, realDataTable)

        For i As Integer = 0 To selectedGuestLogs.Length - 1 Step 2
            Dim tryrow As DataRow
            tryrow = realDataTable.NewRow

            tryrow(0) = selectedGuestLogs(i)

            Try
                tryrow(1) = selectedGuestLogs(i + 1)
            Catch ex As Exception

            End Try

            realDataTable.Rows.Add(tryrow)
        Next

        With trackingReportGuestLog
            .NameLabel.Text = guestName
            .LogsDataGridView.DataSource = realDataTable
            .ShowDialog()
        End With
    End Sub
End Class