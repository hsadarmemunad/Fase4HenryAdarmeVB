Friend NotInheritable Class MessageDialog
    ''' <summary>
    ''' Prevent instantiation.
    ''' </summary>
    Private Sub New()

    End Sub

    Friend Shared Sub ShowWarning(message As String)

        MessageBox.Show(message, "Advertencia",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Friend Shared Sub ShowSuccess(message As String)

        MessageBox.Show(message, "Éxito",
            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Friend Shared Function ShowConfirm(message As String) As DialogResult

        Return MessageBox.Show(message, "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function

End Class
