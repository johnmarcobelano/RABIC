Imports MySql.Data.MySqlClient

Public Class Form6
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        LoadRequests()
    End Sub

    Private Sub SetupGrid()
        dgvRequests.Columns.Clear()
        ' hidden request id
        Dim colRequestId As New DataGridViewTextBoxColumn()
        colRequestId.Name = "request_id"
        colRequestId.Visible = False
        dgvRequests.Columns.Add(colRequestId)

        dgvRequests.Columns.Add("Room", "Room")
        dgvRequests.Columns.Add("Date", "Date")
        dgvRequests.Columns.Add("Time", "Time")
        dgvRequests.Columns.Add("Professor", "Professor")
        dgvRequests.Columns.Add("Purpose", "Purpose")

        Dim colReqDate As New DataGridViewTextBoxColumn()
        colReqDate.Name = "RequestDate"
        dgvRequests.Columns.Add(colReqDate)

        Dim colStatus As New DataGridViewTextBoxColumn()
        colStatus.Name = "Status"
        dgvRequests.Columns.Add(colStatus)

        Dim btnApprove As New DataGridViewButtonColumn()
        btnApprove.HeaderText = "Approve"
        btnApprove.Name = "ApproveBtn"
        btnApprove.Text = "Approve"
        btnApprove.UseColumnTextForButtonValue = True
        dgvRequests.Columns.Add(btnApprove)

        Dim btnReject As New DataGridViewButtonColumn()
        btnReject.HeaderText = "Reject"
        btnReject.Name = "RejectBtn"
        btnReject.Text = "Reject"
        btnReject.UseColumnTextForButtonValue = True
        dgvRequests.Columns.Add(btnReject)
    End Sub

    Public Sub LoadRequests()
        dgvRequests.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String =
                    "SELECT r.request_id, rs.room, rs.date, rs.time, u.username AS professor_username, r.purpose, r.request_date, r.status
                     FROM requests r
                     JOIN room_schedule rs ON r.schedule_id = rs.schedule_id
                     JOIN users u ON r.professor_user_id = u.user_id
                     ORDER BY r.request_date DESC"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            dgvRequests.Rows.Add(
                                rdr("request_id"),
                                rdr("room").ToString(),
                                rdr("date").ToString(),
                                rdr("time").ToString(),
                                rdr("professor_username").ToString(),
                                rdr("purpose").ToString(),
                                Convert.ToDateTime(rdr("request_date")).ToString("yyyy-MM-dd HH:mm"),
                                rdr("status").ToString()
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Load error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRequests_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequests.CellContentClick
        If e.RowIndex < 0 Then Return
        Dim colName = dgvRequests.Columns(e.ColumnIndex).Name
        If colName <> "ApproveBtn" AndAlso colName <> "RejectBtn" Then Return

        Dim requestId As Integer = Convert.ToInt32(dgvRequests.Rows(e.RowIndex).Cells("request_id").Value)
        Dim newStatus As String = If(colName = "ApproveBtn", "Approved", "Rejected")

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE requests SET status=@s WHERE request_id=@rid", conn)
                    cmd.Parameters.AddWithValue("@s", newStatus)
                    cmd.Parameters.AddWithValue("@rid", requestId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Request " & newStatus & ".", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequests()
        Catch ex As Exception
            MessageBox.Show("Error updating request: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
