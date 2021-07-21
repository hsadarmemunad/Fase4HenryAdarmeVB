Public Class Form1
    Private Sub ButtonStudents_Click(sender As Object, e As EventArgs) Handles ButtonStudents.Click
        Dim frm As New StudentsMenu()
        frm.Show()

        Me.Hide()
    End Sub

    Private Sub ButtonAdmin_Click(sender As Object, e As EventArgs) Handles ButtonAdmin.Click
        Dim frm As New Administrator()
        frm.Show()

        Me.Hide()
    End Sub
End Class
