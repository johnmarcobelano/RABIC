Public Class Form5

    ' Sample Rooms and Time Slots
    Private Rooms As String() = {"Room 101", "Room 102", "Room 103", "Lab 1", "Lab 2"}
    Private TimeSlots As String() = {"8:00 - 9:30", "9:30 - 11:00", "11:00 - 12:30", "1:00 - 2:30", "2:30 - 4:00"}

    ' Reference to Form6 to send requests
    Public Property MainForm As Form6

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate ComboBoxes
        cmbRoom.Items.AddRange(Rooms)
        cmbTimeSlot.Items.AddRange(TimeSlots)

        ' Configure DateTimePicker
        dtpDate.Format = DateTimePickerFormat.Custom
        dtpDate.CustomFormat = "dddd, MMM dd"
        dtpDate.MinDate = DateTime.Now
        dtpDate.MaxDate = DateTime.Now.AddDays(6) ' Next 7 days
    End Sub

    Private Sub btnRequest_Click(sender As Object, e As EventArgs) Handles btnRequest.Click
        ' Validate inputs
        If cmbRoom.SelectedIndex = -1 Or cmbTimeSlot.SelectedIndex = -1 Or txtPurpose.Text = "" Then
            MessageBox.Show("Please fill out all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Send request to Form6
        If MainForm IsNot Nothing Then
            ' Replace "Professor Name Here" with actual user name if needed
            MainForm.AddPendingRequest("Professor Name Here", cmbRoom.SelectedItem.ToString(),
                                       dtpDate.Value.ToString("dddd, MMM dd"),
                                       cmbTimeSlot.SelectedItem.ToString(),
                                       txtPurpose.Text)
        End If

        MessageBox.Show("Request submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ' Go back to Form4 when cancel is clicked
        Dim profForm As Form4 = Application.OpenForms.OfType(Of Form4)().FirstOrDefault()

        If profForm Is Nothing Then
            profForm = New Form4()
            profForm.Show()
        Else
            profForm.Show()
            profForm.BringToFront()
        End If

        Me.Close()
    End Sub

End Class
