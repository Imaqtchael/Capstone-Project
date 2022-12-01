Imports System.Runtime.InteropServices
Imports System.Security.Cryptography

Public Class home
    Public allTabDataSet As DataSet
    Private Async Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load, Button5.Click
        allTabDataSet = Await Task.Run(Function() getAllData())
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

        'Show the trackingreport form and changing the 
        'trackingreport buttont to white on form load
        showThis(sender, Panel1, trackingReport)
        changeColor(Button1, Button2, Button3, Button4)

    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        allTabDataSet = Await Task.Run(Function() getAllData())
    End Sub

    'Changing the clicked button to white and other button to whitesmoke
    Private Sub showForm(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click
        If sender Is Button1 Then
            showThis(Button1, Panel1, trackingReport)
            changeColor(Button1, Button2, Button3, Button4)
        ElseIf sender Is Button2 Then
            showThis(Button2, Panel1, guestManagement)
            changeColor(Button2, Button1, Button3, Button4)
        ElseIf sender Is Button3 Then
            showThis(Button3, Panel1, eventManagement)
            changeColor(Button3, Button1, Button2, Button4)
        ElseIf sender Is Button4 Then
            showThis(Button4, Panel1, userManagement)
            changeColor(Button4, Button1, Button2, Button3)
        End If
    End Sub

    'Loggin out the admin user and removing him in the REMEBERED.txt
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        My.Computer.FileSystem.WriteAllText(
            "..\..\..\REMEMBERED.txt", "", False)
        Me.Hide()

        'If the login form is previously used we will just show it
        'or create it as an object and show it
        If login Is Nothing Then
            login.ShowDialog()
        Else
            login.Show()
        End If
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Panel2.MouseDown, Button5.MouseDown, Button5.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class