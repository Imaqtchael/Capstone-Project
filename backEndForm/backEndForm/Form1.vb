Public Class Form1
    Private Sub changeForm(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click
        If sender Is Button1 Then
            showThis(sender, Panel1, eventsBackEnd)
            changeColor(Button1, Button2)
        Else
            showThis(sender, Panel1, registerGuests)
            changeColor(Button2, Button1)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showThis(Button1, Panel1, eventsBackEnd)
        changeColor(Button1, Button2)
    End Sub
End Class
