Public Class StudentsMenu

    Private Sub Quiz_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Application.OpenForms.Count = 1 Then
            Application.Exit()
        End If
    End Sub
    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click
        Dim frm As New StudentRegister()
        frm.Show()

        Me.Hide()
    End Sub

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        Dim dao = New StudentDao()
        Dim email As String = TextBoxEmail.Text.Trim()
        Dim password As String = TextBoxPassword.Text.Trim()
        Dim student As Student = dao.FirstByEmail(email)

        If student Is Nothing Then
            MessageDialog.ShowWarning("Datos de usuario o contraseña in correctos")
        End If

        If student IsNot Nothing Then
            If String.Equals(student.Password, password) = False Then
                MessageDialog.ShowWarning("Datos de usuario o contraseña in correctos")
            End If
        End If

    End Sub
End Class