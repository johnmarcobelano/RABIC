Imports MySql.Data.MySqlClient

Public Class Form5
    Public SelectedScheduleId As Integer = -1
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub btnSubmit_Click_1(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If SelectedScheduleId <= 0 Then
            MessageBox.Show("No schedule selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not Session.IsLoggedIn OrElse Session.Role.ToLower() <> "professor" Then
            MessageBox.Show("You must be logged in as a Professor to request a slot.", "Unauthorized", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim purpose = txtPurpose.Text.Trim()
        If purpose = "" Then
            MessageBox.Show("Please enter purpose.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTimeSlot.SelectedIndex = -1 Then
            MessageBox.Show("Please select a time slot.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedDate As Date = dtpDate.Value.Date
        Dim selectedTime As String = cmbTimeSlot.SelectedItem.ToString()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String = "INSERT INTO requests (schedule_id, professor_user_id, purpose, date_requested, time_slot, status) 
                                     VALUES (@sid, @prof, @purpose, @date, @time, 'Pending')"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@sid", SelectedScheduleId)
                    cmd.Parameters.AddWithValue("@prof", Session.UserId)
                    cmd.Parameters.AddWithValue("@purpose", purpose)
                    cmd.Parameters.AddWithValue("@date", selectedDate)
                    cmd.Parameters.AddWithValue("@time", selectedTime)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
