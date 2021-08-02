Public Class StudyTopics
    Private Sub StudyTopics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim html As String = "<html><head>"
        html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
        html &= "</head><body><div style='text-align=center;'><iframe width='560' height='315' src='https://www.youtube.com/embed/1H5PA-pFWo0' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe></div>"
        html &= "</body></html>"
        Me.WebBrowser1.DocumentText = html
    End Sub

    Private Sub StudyTopics_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If Application.OpenForms.Count = 1 Then
            Application.Exit()
        End If

        Form1.Show()
    End Sub

    Private Sub ButtonEvaluate_Click(sender As Object, e As EventArgs) Handles ButtonEvaluate.Click
        Dim dialogResult As DialogResult

        dialogResult = MessageBox.Show("Tiene 3 minutos para presentar la prueba ¿Desea Iniciar?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

        If dialogResult = DialogResult.Yes Then
            Quiz.Show()
            Me.Hide()
        End If
    End Sub
End Class