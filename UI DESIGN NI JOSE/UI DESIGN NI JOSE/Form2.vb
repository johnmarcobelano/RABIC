Imports MySql.Data.MySqlClient

Public Class Form2
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure roles available
        If cmbRole.Items.Count = 0 Then
            cmbRole.Items.AddRange(New String() {"Admin", "Student", "Professor"})
        End If
    End Sub

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        If txtUsername.Text.Trim() = "" OrElse txtPassword.Text = "" OrElse cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Please fill out all fields including role!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim username = txtUsername.Text.Trim()
        Dim password = txtPassword.Text
        Dim role = cmbRole.SelectedItem.ToString()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                ' check duplicate
                Using checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE username=@u", conn)
                    checkCmd.Parameters.AddWithValue("@u", username)
                    Dim count = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Username already exists!", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                Using ins As New MySqlCommand("INSERT INTO users (username, password, role) VALUES (@u,@p,@r)", conn)
                    ins.Parameters.AddWithValue("@u", username)
                    ins.Parameters.AddWithValue("@p", password)
                    ins.Parameters.AddWithValue("@r", role)
                    ins.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Return to login
            Dim loginForm As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
            If loginForm Is Nothing Then
                loginForm = New Form1()
            End If
            loginForm.Show()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Cancel and return to Login?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim loginForm As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
            If loginForm Is Nothing Then
                loginForm = New Form1()
            End If
            loginForm.Show()
            Me.Close()
        End If
    End Sub
End Class
