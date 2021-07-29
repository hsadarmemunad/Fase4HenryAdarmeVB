<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonStudents = New System.Windows.Forms.Button()
        Me.ButtonAdmin = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonStudents
        '
        Me.ButtonStudents.Location = New System.Drawing.Point(95, 61)
        Me.ButtonStudents.Name = "ButtonStudents"
        Me.ButtonStudents.Size = New System.Drawing.Size(119, 39)
        Me.ButtonStudents.TabIndex = 0
        Me.ButtonStudents.Text = "Estudiantes"
        Me.ButtonStudents.UseVisualStyleBackColor = True
        '
        'ButtonAdmin
        '
        Me.ButtonAdmin.Location = New System.Drawing.Point(95, 137)
        Me.ButtonAdmin.Name = "ButtonAdmin"
        Me.ButtonAdmin.Size = New System.Drawing.Size(119, 39)
        Me.ButtonAdmin.TabIndex = 1
        Me.ButtonAdmin.Text = "Administrador"
        Me.ButtonAdmin.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 239)
        Me.Controls.Add(Me.ButtonAdmin)
        Me.Controls.Add(Me.ButtonStudents)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menú de aplicación"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButtonStudents As Button
    Friend WithEvents ButtonAdmin As Button
End Class
