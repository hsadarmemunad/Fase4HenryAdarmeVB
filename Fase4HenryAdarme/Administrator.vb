Public Class Administrator

    Private obj As Student
    Private Sub Administrator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'EstudioDataSet.students' Puede moverla o quitarla según sea necesario.
        Me.StudentsTableAdapter.Fill(Me.EstudioDataSet.students)

    End Sub

    Private Sub Save()

        If CheckRepassword() <> True Then
            MessageDialog.ShowWarning("Las contraseñas no coinciden")
            Return
        End If

        If Me.obj IsNot Nothing AndAlso Me.obj.Id > 0 Then
            Me.UpdateStudent()
        Else
            Me.Create()
        End If

        ClearForm()
        Me.StudentsTableAdapter.Fill(Me.EstudioDataSet.students)
    End Sub

    Private Sub Create()
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
            MessageDialog.ShowSuccess("Se ha registrado correctamente")
        End If
    End Sub

    Private Sub UpdateStudent()
        Dim dao = New StudentDao()

        Me.obj.Code = TextBoxCode.Text
        Me.obj.FirstName = TextBoxFirstName.Text
        Me.obj.LastName = TextBoxLastName.Text
        Me.obj.Email = TextBoxEmail.Text
        Me.obj.Cellphone = TextBoxCellphone.Text
        Me.obj.Password = TextBoxPassword.Text

        If dao.Update(obj) Then
            MessageDialog.ShowSuccess("Se ha actualizado correctamente")
        End If
    End Sub

    Private Sub DeleteStudent()
        If MessageDialog.ShowConfirm("¿Está seguro de eliminar el estudiante?") <> DialogResult.No Then
            Dim dao = New StudentDao()
            dao.Delete(obj)
            Me.StudentsTableAdapter.Fill(Me.EstudioDataSet.students)
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

        Me.obj = Nothing
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Me.Save()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim id As Integer = DataGridView1.Item(0, e.RowIndex).Value

        Dim dao = New StudentDao()

        Me.obj = dao.First(id)

        If obj IsNot Nothing Then
            TextBoxCode.Text = obj.Code
            TextBoxFirstName.Text = obj.FirstName
            TextBoxLastName.Text = obj.LastName
            TextBoxEmail.Text = obj.Email
            TextBoxCellphone.Text = obj.Cellphone
            TextBoxPassword.Text = obj.Password
            TextBoxRePassword.Text = obj.Password
        End If
    End Sub

    Private Sub Administrator_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.Count = 1 Then
            Application.Exit()
        End If

        Form1.Show()
    End Sub

    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        DeleteStudent()
    End Sub

    Private Function CheckRepassword()
        Dim password As String = TextBoxPassword.Text
        Dim rePassword As String = TextBoxRePassword.Text

        Return password.Equals(rePassword)
    End Function

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        ClearForm()
    End Sub
End Class