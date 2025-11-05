Imports MySql.Data.MySqlClient

Public Class Form1
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username = txtUsername.Text.Trim()
        Dim password = txtPassword.Text ' plain text for now

        If username = "" OrElse password = "" Then
            MessageBox.Show("Enter username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "SELECT user_id, username, role FROM users WHERE username=@u AND password=@p LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.Parameters.AddWithValue("@p", password)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Session.UserId = Convert.ToInt32(reader("user_id"))
                            Session.Username = reader("username").ToString()
                            Session.Role = reader("role").ToString()

                            Select Case Session.Role.ToLower()
                                Case "admin"
                                    Dim f6 As New Form6()
                                    f6.Show()
                                    Me.Hide()
                                Case "student"
                                    Dim f3 As New Form3()
                                    f3.Show()
                                    Me.Hide()
                                Case "professor"
                                    Dim f4 As New Form4()
                                    f4.Show()
                                    Me.Hide()
                                Case Else
                                    MessageBox.Show("Unknown role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End Select
                        Else
                            MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtPassword.Clear()
                            txtUsername.Focus()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkCreateAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCreateAccount.LinkClicked
        Dim f2 As New Form2()
        f2.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Exit program?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
