Imports MySql.Data.MySqlClient

Public Class Form4
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDepartments()
        SetupScheduleGrid()
        If cmbDepartment.Items.Count > 0 Then cmbDepartment.SelectedIndex = 0
    End Sub

    Private Sub LoadDepartments()
        cmbDepartment.Items.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT department_name FROM departments ORDER BY department_name", conn)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            cmbDepartment.Items.Add(rdr("department_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading departments: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupScheduleGrid()
        dgvSchedule.Columns.Clear()
        ' Hidden schedule_id column
        Dim colId As New DataGridViewTextBoxColumn()
        colId.Name = "schedule_id"
        colId.Visible = False
        dgvSchedule.Columns.Add(colId)

        dgvSchedule.Columns.Add("Room", "Room")
        dgvSchedule.Columns.Add("Date", "Date")
        dgvSchedule.Columns.Add("Time", "Time")
        dgvSchedule.Columns.Add("Purpose", "Purpose")

        Dim btnRequest As New DataGridViewButtonColumn()
        btnRequest.HeaderText = "Request"
        btnRequest.Name = "RequestBtn"
        btnRequest.Text = "Request"
        btnRequest.UseColumnTextForButtonValue = True
        dgvSchedule.Columns.Add(btnRequest)
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepartment.SelectedIndexChanged
        LoadSchedule(cmbDepartment.SelectedItem.ToString())
    End Sub

    Private Sub LoadSchedule(deptName As String)
        dgvSchedule.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String =
                    "SELECT rs.schedule_id, rs.room, rs.date, rs.time, rs.purpose
                     FROM room_schedule rs
                     JOIN departments d ON rs.department_id = d.department_id
                     WHERE d.department_name = @dept"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@dept", deptName)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            dgvSchedule.Rows.Add(rdr("schedule_id"),
                                                 rdr("room").ToString(),
                                                 rdr("date").ToString(),
                                                 rdr("time").ToString(),
                                                 rdr("purpose").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading schedule: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvSchedule_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSchedule.CellContentClick
        If e.RowIndex < 0 Then Return
        If dgvSchedule.Columns(e.ColumnIndex).Name <> "RequestBtn" Then Return

        Dim scheduleId As Integer = Convert.ToInt32(dgvSchedule.Rows(e.RowIndex).Cells("schedule_id").Value)
        Dim requestForm As New Form5()
        requestForm.SelectedScheduleId = scheduleId
        requestForm.txtPurpose.Text = dgvSchedule.Rows(e.RowIndex).Cells("Purpose").Value.ToString()
        requestForm.cmbRoom.Text = dgvSchedule.Rows(e.RowIndex).Cells("Room").Value.ToString()
        requestForm.cmbTimeSlot.Text = dgvSchedule.Rows(e.RowIndex).Cells("Time").Value.ToString()

        If requestForm.ShowDialog() = DialogResult.OK Then
            ' optional: show confirmation
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit and return to Login?",
                       "Exit Confirmation",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.Yes Then

            'Find existing Form1 instance or create new one
            Dim loginForm As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()
            If loginForm Is Nothing Then
                loginForm = New Form1()
            End If

            loginForm.Show()
            Me.Hide() 'Use Hide to avoid issues if used multiple times
        End If
    End Sub
End Class
