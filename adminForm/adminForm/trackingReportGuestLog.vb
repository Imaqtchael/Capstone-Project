Imports System.Runtime.InteropServices
Imports MySql.Data.MySqlClient

Public Class trackingReportGuestLog
    'Loading data on form load
    Private Async Sub trackingReportGuestLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show(trackingReport.selectedGuest)
        'Disable the home form
        home.Enabled = False
        Me.TopMost = True

        'Getting the selected guest by the admin from trackingreport form
        Label1.Text = trackingReport.selectedGuest

        Dim query As String = $"SELECT logs FROM guest WHERE name='{trackingReport.selectedGuest}' AND guest_id={trackingReport.guestsID}"

        Dim ds As DataSet = Await Task.Run(Function() getData(query))

        'While ds Is Nothing
        '    ds = Await Task.Run(Function() getData(query))
        'End While

        'Creating another Dataset 
        'Which we will manipulate to have the number of column that we want
        Dim realDataSet As New DataSet()
        Dim realDataTable As New DataTable()

        realDataSet.Tables.Add(realDataTable)

        Dim logs As String() = Split(ds.Tables(0).Rows(0)(0).ToString(), ", ")

        'Adding two columns because we want Time in and Time out
        addColumns(2, realDataTable)

        'Initially did this to fix the bug for the odd number of logs
        'Realized later that a try/catch on the for loop does it better

        'Dim fixer As Boolean = ds.Tables(0).Rows.Count Mod 2


        For i As Integer = 0 To logs.Length - 1 Step 2
            Dim tryrow As DataRow
            tryrow = realDataSet.Tables(0).NewRow

            tryrow(0) = logs(i)

            Try
                tryrow(1) = logs(i + 1)
            Catch ex As Exception

            End Try

            realDataSet.Tables(0).Rows.Add(tryrow)
        Next

        'If fixer Then
        '    Dim tryrow As DataRow
        '    tryrow = realDataSet.Tables(0).NewRow

        '    tryrow(0) = logs(logs.Length - 1)

        '    realDataSet.Tables(0).Rows.Add(tryrow)
        'End If

        DataGridView1.DataSource = realDataSet.Tables(0)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        home.Enabled = True
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

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown, Label1.MouseDown
        ReleaseCapture()
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub
End Class