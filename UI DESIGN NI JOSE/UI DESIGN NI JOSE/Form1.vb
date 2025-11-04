Public Class Form1
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        ' Hard-coded login examples
        If username = "admin" And password = "admin123" Then
            MessageBox.Show("Welcome Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form6.Show()
            Me.Hide()

        ElseIf username = "student" And password = "stud123" Then
            MessageBox.Show("Welcome Student!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form3.Show()
            Me.Hide()

        ElseIf username = "professor" And password = "prof123" Then
            MessageBox.Show("Welcome Professor!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form4.Show()
            Me.Hide()

        Else
            MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtUsername.Focus()
        End If
    End Sub

    ' LinkLabel click opens CreateAccountForm
    Private Sub LinkCreateAccount_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCreateAccount.LinkClicked
        Form2.Show()
        Me.Hide()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?",
                                                "Exit Program",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        Else
            Application.Exit()
        End If
    End Sub

End Class
