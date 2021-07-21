Public Class Administrator
    Private Sub Administrator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'EstudioDataSet.students' Puede moverla o quitarla según sea necesario.
        Me.StudentsTableAdapter.Fill(Me.EstudioDataSet.students)

    End Sub
End Class