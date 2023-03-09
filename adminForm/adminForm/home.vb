Imports System.Net
Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Threading

Public Class home
    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        showThis(ControlView, trackingReport)
        changeColor(TrackingReportButton, GuestManagementButton, EventManagementButton, UserManagementButton, AnalyticsButton)
    End Sub

    Private Sub showForm(sender As Object, e As EventArgs) Handles TrackingReportButton.Click, GuestManagementButton.Click, EventManagementButton.Click, UserManagementButton.Click, AnalyticsButton.Click
        If sender Is TrackingReportButton Then
            showThis(ControlView, trackingReport)
            changeColor(TrackingReportButton, GuestManagementButton, EventManagementButton, UserManagementButton, AnalyticsButton)
        ElseIf sender Is GuestManagementButton Then
            showThis(ControlView, guestManagement)
            changeColor(GuestManagementButton, TrackingReportButton, EventManagementButton, UserManagementButton, AnalyticsButton)
        ElseIf sender Is EventManagementButton Then
            showThis(ControlView, eventManagement)
            changeColor(EventManagementButton, TrackingReportButton, GuestManagementButton, UserManagementButton, AnalyticsButton)
        ElseIf sender Is UserManagementButton Then
            showThis(ControlView, userManagement)
            changeColor(UserManagementButton, TrackingReportButton, GuestManagementButton, EventManagementButton, AnalyticsButton)
        ElseIf sender Is AnalyticsButton Then
            showThis(ControlView, analyticsReport)
            changeColor(AnalyticsButton, TrackingReportButton, GuestManagementButton, EventManagementButton, UserManagementButton)
        End If

        If Not trackingReport Is Nothing Then
            trackingReport.GuestSearchTextBox.Clear()
        End If

        If Not guestManagement Is Nothing Then
            guestManagement.GuestSearchTextBox.Clear()
        End If

        If Not eventManagement Is Nothing Then
            eventManagement.SearchTextBox.Clear()
        End If

    End Sub

    'Loggin out the admin user and removing him in the REMEBERED.txt
    Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        My.Computer.FileSystem.WriteAllText(
            $"{defaultDirectory}\REMEMBERED.txt", "", False)
        Me.Hide()

        login.Show()

        showThis(ControlView, trackingReport)
        changeColor(TrackingReportButton, GuestManagementButton, EventManagementButton, UserManagementButton, AnalyticsButton)
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        login.Close()
        Me.Close()
    End Sub


    'Casting Shadow to the Form
    Private Const CS_SHADOW As Integer = &H20000
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CS_SHADOW
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel2.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class