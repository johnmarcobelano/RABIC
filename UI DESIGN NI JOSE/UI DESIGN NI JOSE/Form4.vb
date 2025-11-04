Public Class Form4
    ' Example data source
    Private ScheduleList As New List(Of ScheduleItem) From {
        New ScheduleItem("202", "Sat", "2:30 - 4:00", "Lecture", "Bachelor of Science in Information Technology"),
        New ScheduleItem("101", "Mon", "9:00 - 10:30", "Lab", "Bachelor of Science in Computer Science"),
        New ScheduleItem("305", "Wed", "1:00 - 3:00", "Seminar", "Bachelor of Science in Business Administration"),
        New ScheduleItem("202", "Fri", "10:00 - 11:30", "Lecture", "Bachelor of Science in Information Technology"),
        New ScheduleItem("405", "Tue", "2:00 - 4:00", "Project", "Bachelor of Science in Industrial Engineering")
    }

    Private Sub ProfessorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill ComboBox with programs/majors
        cmbDepartment.Items.AddRange(New String() {
            "Bachelor of Science in Psychology",
            "Bachelor of Science in Accountancy",
            "Bachelor of Science in Customs Administration",
            "Bachelor of Science in Business Administration",
            "Major in Marketing Management",
            "Major in Financial Management",
            "Major in Human Resource Development Management",
            "Bachelor of Science in Criminology",
            "Bachelor of Science in Computer Science",
            "Bachelor of Science in Information Technology",
            "Bachelor of Elementary Education",
            "Bachelor of Secondary Education",
            "Major in English",
            "Major in Filipino",
            "Major in Mathematics",
            "Bachelor of Technical Vocational for Teacher Education",
            "Major in Automotive Technology",
            "Major in Computer Programming",
            "Major in Food Service Management",
            "Major in Electronics Technology",
            "Major in Welding and Fabrication",
            "Bachelor of Science in Industrial Engineering",
            "Bachelor of Science in Computer Engineering"
        })

        cmbDepartment.SelectedIndex = 0 ' default selection

        ' Initialize DataGridView columns
        dgvSchedule.ColumnCount = 4
        dgvSchedule.Columns(0).Name = "Room"
        dgvSchedule.Columns(1).Name = "Date"
        dgvSchedule.Columns(2).Name = "Time"
        dgvSchedule.Columns(3).Name = "Purpose"

        ' Add Request button column
        Dim btnRequest As New DataGridViewButtonColumn()
        btnRequest.HeaderText = "Request"
        btnRequest.Text = "Request"
        btnRequest.UseColumnTextForButtonValue = True
        dgvSchedule.Columns.Add(btnRequest)

        ' Display schedules for default department
        FilterSchedule(cmbDepartment.SelectedItem.ToString())
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        FilterSchedule(cmbDepartment.SelectedItem.ToString())
    End Sub

    Private Sub FilterSchedule(department As String)
        dgvSchedule.Rows.Clear()
        For Each item In ScheduleList
            If item.Department = department Then
                dgvSchedule.Rows.Add(item.Room, item.Date, item.Time, item.Purpose)
            End If
        Next
    End Sub

    ' Handle Request button click in DataGridView
    Private Sub dgvSchedule_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSchedule.CellContentClick
        If e.RowIndex < 0 Then Return
        If TypeOf dgvSchedule.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            ' Open Form5
            Dim requestForm As New Form5()

            ' Link to running Form6
            requestForm.MainForm = Application.OpenForms.OfType(Of Form6)().FirstOrDefault()

            ' Pre-fill Form5 with selected schedule info
            requestForm.cmbRoom.SelectedItem = dgvSchedule.Rows(e.RowIndex).Cells("Room").Value.ToString()
            requestForm.cmbTimeSlot.SelectedItem = dgvSchedule.Rows(e.RowIndex).Cells("Time").Value.ToString()
            requestForm.txtPurpose.Text = dgvSchedule.Rows(e.RowIndex).Cells("Purpose").Value.ToString()

            requestForm.ShowDialog()
        End If
    End Sub
End Class

' Class to hold schedule items
Public Class ScheduleItem
    Public Property Room As String
    Public Property [Date] As String
    Public Property Time As String
    Public Property Purpose As String
    Public Property Department As String

    Public Sub New(room As String, [date] As String, time As String, purpose As String, department As String)
        Me.Room = room
        Me.Date = [date]
        Me.Time = time
        Me.Purpose = purpose
        Me.Department = department
    End Sub
End Class
