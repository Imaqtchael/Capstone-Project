Imports MySql.Data.MySqlClient
Module Functions
    Public str As String = "server=localhost; uid=root; pwd=; database=capstone"
    Public connection As New MySqlConnection(str)

    Public Sub showThis(ByVal toShow As String, Optional ByVal name As String = "", Optional ByVal eventName As String = "", Optional ByVal counter As Integer = 0)
        'If toShow = "Welcome" Then
        '    Dim text = $"Welcome to {eventName} {name}"
        '    Dim time As TimeSpan = New TimeSpan(0, 0, 1)

        '    Form1.Label1.Text = ""

        '    For i As Integer = 0 To text.Length - 1
        '        Form1.Label1.Text += text(i)
        '        Thread.Sleep(time)
        '    Next
        'ElseIf toShow = "Not Registered" Then
        '    Dim text = "Sorry your RFID is not registered! Please contact the Manager of the event..."
        '    Dim time As TimeSpan = New TimeSpan(0, 0, 0.8)

        '    Form1.Label1.Text = ""

        '    For i As Integer = 0 To text.Length - 1
        '        Form1.Label1.Text += text(i)
        '        Thread.Sleep(time)
        '    Next
        'End If

        If toShow = "Welcome" Then
            Dim text = $"Welcome to {eventName} {name}"

            Form1.Label1.Text = ""

            For i As Integer = 0 To text.Length - 1
                Form1.Label1.Text += text(i)
            Next
        ElseIf toShow = "Not Registered" Then
            Dim text = "Sorry your RFID is not registered! Please contact the Manager of the event..."
            Dim time As TimeSpan = New TimeSpan(0, 0, 0.8)

            Form1.Label1.Text = ""

            For i As Integer = 0 To text.Length - 1
                Form1.Label1.Text += text(i)
            Next
        End If
    End Sub
End Module