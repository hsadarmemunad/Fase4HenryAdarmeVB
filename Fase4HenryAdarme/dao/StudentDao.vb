Imports System.Data.SqlClient

Public Class StudentDao
	Property ConnString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|estudio.mdf;Integrated Security=True;Connect Timeout=30"
	Property StudentId As Int64

	Public Function Create(ByVal student As Student) As Boolean
		Dim query = "INSERT INTO Students (Code,LastName,FirstName,Email,Cellphone,Password) VALUES (@Code,@LastName,@FirstName,@Email,@Cellphone,@Password)"
		Try

			'1. Initialize the SqlConnection string
			Using con = New SqlConnection(ConnString)
				'2. Initialize the SqlCommand
				Using cmd = New SqlCommand(query, con)
					'3. Create Command Parameter to avoid sql injection
					cmd.Parameters.Add(New SqlParameter("@Code", student.Code))
					cmd.Parameters.Add(New SqlParameter("@FirstName", student.FirstName))
					cmd.Parameters.Add(New SqlParameter("@LastName", student.LastName))
					cmd.Parameters.Add(New SqlParameter("@Email", student.Email))
					cmd.Parameters.Add(New SqlParameter("@Cellphone", student.Cellphone))
					cmd.Parameters.Add(New SqlParameter("@Password", student.Password))
					'4. open the connection
					con.Open()
					'Execute non query to insert data
					Dim rows As Integer = cmd.ExecuteNonQuery()
					Return True ' if successfully save in database
				End Using
			End Using

		Catch ex As Exception
			Throw ex
		End Try
	End Function

	Public Function FirstByEmail(email As String) As Student
		Dim student As Student

		Dim query = "SELECT * FROM Students WHERE Email=@Email" ' WHERE Email=@Email

		'1. Initialize the SqlConnection string
		Using con = New SqlConnection(ConnString)
			'2. Initialize the SqlCommand
			Using cmd = New SqlCommand(query, con)
				'3. Create Command Parameter to avoid sql injection
				cmd.Parameters.Add(New SqlParameter("@Email", email))
				'4. open the connection
				con.Open()
				'4. Execute the data reader
				Using reader = cmd.ExecuteReader()

					'If reader.Read() Then 'this will read only one column
					If reader.HasRows Then 'check if there is rows to read
						While reader.Read()
							student = New Student With {
								.Id = Convert.ToInt32(reader("Id").ToString()),
								.Code = reader("Code").ToString().Trim(),
								.LastName = reader("LastName").ToString().Trim(),
								.FirstName = reader("FirstName").ToString().Trim(),
								.Email = reader("Email").ToString().Trim(),
								.Cellphone = reader("Cellphone").ToString().Trim(),
								.Password = reader("Password").ToString().Trim()
							}

							Return student
						End While
					End If
				End Using
			End Using
		End Using

		Return Nothing
	End Function
End Class

Public Class Student
	Property Id As Int16
	Property Code As String
	Property FirstName As String
	Property LastName As String
	Property Email As String
	Property Cellphone As String
	Property Password As String

End Class
