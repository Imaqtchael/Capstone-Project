Imports MySql.Data.MySqlClient
Public Class Form1
    Dim query As String = "SELECT * FROM sample_attendees"
    Dim adapter As New MySqlDataAdapter(query, connection)
    Dim dataset As New DataSet()
    Dim arr As String()
    Dim rfid As String = ""
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adapter.Fill(dataset)
        arr = (From myRow In dataset.Tables(0).AsEnumerable
               Select myRow.Field(Of String)("rfid")).ToArray
        For i As Integer = 0 To arr.Length - 1
            MsgBox(arr(i))
        Next
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If rfid.Length = 10 Then
            If arr.Contains(rfid) Then
                showThis(Label2, Label1, Label3)
            Else
                showThis(Label3, Label1, Label2)
            End If
            rfid = ""
        Else
            rfid += e.KeyChar
        End If
    End Sub
End Class
