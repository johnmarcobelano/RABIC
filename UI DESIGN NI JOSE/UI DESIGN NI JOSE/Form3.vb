Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Add items to the ComboBox
        ComboBox1.Items.Add("Bachelor of Science in Information Technology")
        ComboBox1.Items.Add("Other Course") ' You can add more options
        ComboBox1.SelectedIndex = -1 ' No selection initially

        ' Setup DataGridView columns
        DataGridView1.ColumnCount = 7
        DataGridView1.Columns(1).Name = "Subject"
        DataGridView1.Columns(2).Name = "Professor"
        DataGridView1.Columns(3).Name = "Date"
        DataGridView1.Columns(4).Name = "Time"
        DataGridView1.Columns(5).Name = "Room"
        DataGridView1.Columns(6).Name = "Status"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Clear existing rows
        DataGridView1.Rows.Clear()

        ' Check if the selected course is IT
        If ComboBox1.SelectedItem.ToString() = "Bachelor of Science in Information Technology" Then
            ' Add the IT Elective 2 row
            Dim row As String() = {
                "IT Elective 2",
                "ALAMO, NINO FRANCISCO CALZADA",
                "SAT",
                "2:30 - 4:00",
                "202",
                "F2F"
            }
            DataGridView1.Rows.Add(row)
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
