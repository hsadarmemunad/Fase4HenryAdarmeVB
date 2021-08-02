Public Class Quiz
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMinutes(3)
    Private Answers As Integer = 0

    Private Sub Quiz_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        If Application.OpenForms.Count = 1 Then
            Application.Exit()
        End If
        UnSelectAnswers()
        StudyTopics.Show()
    End Sub

    Private Sub Quiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UnSelectAnswers()

        Timer1.Interval = 500
        TargetDT = DateTime.Now.Add(CountDownFrom)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        If ts.TotalMilliseconds > 0 Then
            LabelTimer.Text = ts.ToString("mm\:ss")
        Else
            LabelTimer.Text = "00:00"
            Timer1.Stop()
            ButtonEnd.Enabled = False

            Dim dialogResult As DialogResult
            dialogResult = MessageBox.Show("Tiempo superado", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            If dialogResult = DialogResult.OK Then
                StudyTopics.Show()
            End If
        End If
    End Sub

    Private Sub Check()

        Answers = 0

        If RadioAsk1AnsA.Checked Or RadioAsk1AnsB.Checked Or RadioAsk1AnsC.Checked Then
            Answers += 1
        End If

        If RadioAsk2AnsA.Checked Or RadioAsk2AnsB.Checked Or RadioAsk2AnsC.Checked Then
            Answers += 1
        End If

        If RadioAsk3AnsA.Checked Or RadioAsk3AnsB.Checked Or RadioAsk3AnsC.Checked Then
            Answers += 1
        End If

        If RadioAsk4AnsA.Checked Or RadioAsk4AnsB.Checked Or RadioAsk4AnsC.Checked Then
            Answers += 1
        End If

        If RadioAsk5AnsA.Checked Or RadioAsk5AnsB.Checked Or RadioAsk5AnsC.Checked Then
            Answers += 1
        End If

    End Sub

    Private Sub Rate()
        Check()

        If Answers < 5 Then
            MessageBox.Show("Debe responder todas las preguntas", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim score As Integer
        score = 0

        If RadioAsk1AnsB.Checked Then
            score += 1
        End If

        If RadioAsk2AnsC.Checked Then
            score += 1
        End If

        If RadioAsk3AnsB.Checked Then
            score += 1
        End If

        If RadioAsk4AnsA.Checked Then
            score += 1
        End If

        If RadioAsk5AnsA.Checked Then
            score += 1
        End If

        UnSelectAnswers()

        If score = 5 Then
            MessageBox.Show("Felicitaciones prueba superada", "Felicitaciones",
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            StudyTopics.Show()
            Me.Hide()
        Else
            Dim dialogResult As DialogResult

            dialogResult = MessageBox.Show("Debe repetir la prueba", "Advertencia",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            If dialogResult = DialogResult.OK Then
                StudyTopics.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub UnSelectAnswers()
        RadioAsk1AnsA.Checked = False
        RadioAsk1AnsB.Checked = False
        RadioAsk1AnsC.Checked = False

        RadioAsk2AnsA.Checked = False
        RadioAsk2AnsB.Checked = False
        RadioAsk2AnsC.Checked = False

        RadioAsk3AnsA.Checked = False
        RadioAsk3AnsB.Checked = False
        RadioAsk3AnsC.Checked = False

        RadioAsk4AnsA.Checked = False
        RadioAsk4AnsB.Checked = False
        RadioAsk4AnsC.Checked = False

        RadioAsk5AnsA.Checked = False
        RadioAsk5AnsB.Checked = False
        RadioAsk5AnsC.Checked = False
    End Sub


    Private Sub ButtonEnd_Click(sender As Object, e As EventArgs) Handles ButtonEnd.Click
        Rate()
    End Sub
End Class