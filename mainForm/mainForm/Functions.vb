Imports MySql.Data.MySqlClient
Module Functions
    Public str As String = "server=localhost; uid=root; pwd=; database=capstone"
    Public connection As New MySqlConnection(str)

    Public Sub showThis(ByVal toShow As Label, ByVal toHide As Label, ByVal toHide1 As Label)
        toShow.Visible = True
        toHide.Visible = False
        toHide1.Visible = False
    End Sub
End Module