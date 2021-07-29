Public Class StudentRegister

    Private Sub Quiz_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Application.OpenForms.Count = 1 Then
            Application.Exit()
        Else
            StudentsMenu.Show()
        End If
    End Sub

    Private Sub Save()
        If CheckRepassword() <> True Then
            MessageDialog.ShowWarning("Las contraseñas no coinciden")
            Return
        End If

        Dim dao = New StudentDao()

        Dim obj As New Student With {
            .Code = TextBoxCode.Text,
            .FirstName = TextBoxFirstName.Text,
            .LastName = TextBoxLastName.Text,
            .Email = TextBoxEmail.Text,
            .Cellphone = TextBoxCellphone.Text,
            .Password = TextBoxPassword.Text
        }

        If dao.Create(obj) Then
            ClearForm()
            MessageDialog.ShowSuccess("Se ha registrado correctamente")
            Me.Hide()
            StudentsMenu.Show()
        End If
    End Sub

    Private Sub ClearForm()
        TextBoxCode.Text = ""
        TextBoxFirstName.Text = ""
        TextBoxLastName.Text = ""
        TextBoxEmail.Text = ""
        TextBoxCellphone.Text = ""
        TextBoxPassword.Text = ""
        TextBoxRePassword.Text = ""
    End Sub

    Private Function CheckRepassword()
        Dim password As String = TextBoxPassword.Text
        Dim rePassword As String = TextBoxRePassword.Text

        Return password.Equals(rePassword)
    End Function

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Hide()
        StudentsMenu.Show()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Save()
    End Sub
End Class