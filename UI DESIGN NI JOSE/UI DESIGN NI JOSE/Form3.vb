Imports MySql.Data.MySqlClient

Public Class Form3
    Private connectionString As String = "Server=localhost;User Id=root;Password=;Database=roomschedulingdb;"

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCourses()
        SetupGrid()
    End Sub

    Private Sub LoadCourses()
        ComboBox1.Items.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql = "SELECT course_name FROM courses ORDER BY course_name"
                Using cmd As New MySqlCommand(sql, conn)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            ComboBox1.Items.Add(rdr("course_name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading courses: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetupGrid()
        DataGridView1.Columns.Clear()
        DataGridView1.ColumnCount = 6
        DataGridView1.Columns(0).Name = "Subject"
        DataGridView1.Columns(1).Name = "Professor"
        DataGridView1.Columns(2).Name = "Date"
        DataGridView1.Columns(3).Name = "Time"
        DataGridView1.Columns(4).Name = "Room"
        DataGridView1.Columns(5).Name = "Status"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        LoadScheduleForCourse(ComboBox1.SelectedItem.ToString())
    End Sub

    Private Sub LoadScheduleForCourse(courseName As String)
        DataGridView1.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim sql As String =
                    "SELECT sb.subject_name, pr.professor_name, rs.date, rs.time, rs.room, rs.status
                     FROM room_schedule rs
                     JOIN subjects sb ON rs.subject_id = sb.subject_id
                     JOIN professors pr ON rs.professor_id = pr.professor_id
                     JOIN courses c ON rs.department_id = c.course_id OR rs.department_id = c.course_id
                     WHERE rs.department_id = (SELECT course_id FROM courses WHERE course_name = @c) 
                     OR (SELECT course_name FROM courses WHERE course_id = rs.department_id) = @c" ' fallback

                ' Simpler: use department_id matching courses table. If your schema differs adjust query.

                Using cmd As New MySqlCommand("SELECT s.subject_name, p.professor_name, rs.date, rs.time, rs.room, rs.status " &
                                             "FROM room_schedule rs " &
                                             "LEFT JOIN subjects s ON rs.subject_id = s.subject_id " &
                                             "LEFT JOIN professors p ON rs.professor_id = p.professor_id " &
                                             "WHERE rs.department_id = (SELECT course_id FROM courses WHERE course_name=@course)", conn)
                    cmd.Parameters.AddWithValue("@course", courseName)
                    Using rdr = cmd.ExecuteReader()
                        While rdr.Read()
                            DataGridView1.Rows.Add(
                                If(rdr.IsDBNull(0), "", rdr.GetString(0)),
                                If(rdr.IsDBNull(1), "", rdr.GetString(1)),
                                If(rdr.IsDBNull(2), "", rdr.GetString(2)),
                                If(rdr.IsDBNull(3), "", rdr.GetString(3)),
                                If(rdr.IsDBNull(4), "", rdr.GetString(4)),
                                If(rdr.IsDBNull(5), "", rdr.GetString(5))
                            )
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
