Public Class Form2


    Public Property Form1 As Object

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        ' Validate inputs
        If txtUsername.Text = "" Or txtPassword.Text = "" Or cmbRole.SelectedIndex = -1 Then
            MessageBox.Show("Please fill out all fields including role!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Simulate account creation
        MessageBox.Show("Account created successfully!" & vbCrLf &
                        "Username: " & txtUsername.Text & vbCrLf &
                        "Role: " & cmbRole.SelectedItem.ToString(),
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Return to login
        Form1.Show()
        Me.Hide()

        ' Clear fields
        txtUsername.Clear()
        txtPassword.Clear()
        cmbRole.SelectedIndex = -1
    End Sub

    Private Sub HideForm()
        Me.Hide()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel creating an account and go back to Login?",
                                                "Cancel Create Account",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question)

        If result = DialogResult.No Then
            Return ' Stay on this form
        End If

        ' ✅ If Yes: return to Form1 (Login Form)
        Dim loginForm As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()

        If loginForm Is Nothing Then
            loginForm = New Form1()
        End If

        loginForm.Show()
        loginForm.BringToFront()
        Me.Close()
    End Sub

End Class

