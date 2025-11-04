Public Class Form6
    Private actionMenu As ContextMenuStrip
    Private selectedRowIndex As Integer = -1

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup dgvPending
        With dgvPending
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns.Clear()

            .Columns.Add("Professor", "Professor")
            .Columns.Add("Room", "Room")
            .Columns.Add("Date", "Date")
            .Columns.Add("Time", "Time")
            .Columns.Add("Purpose", "Purpose")

            Dim btnAction As New DataGridViewButtonColumn()
            btnAction.HeaderText = "Action"
            btnAction.Text = "Action"
            btnAction.UseColumnTextForButtonValue = True
            .Columns.Add(btnAction)
        End With

        AddHandler dgvPending.CellContentClick, AddressOf dgvPending_CellContentClick
        AddHandler dgvPending.RowsAdded, AddressOf dgvPending_RowsAdded

        ' Context menu for Action button
        actionMenu = New ContextMenuStrip()
        actionMenu.Items.Add("Approve")
        actionMenu.Items.Add("Reject")
        AddHandler actionMenu.ItemClicked, AddressOf actionMenu_ItemClicked
    End Sub

    ' Method to allow Form5 to send requests
    Public Sub AddPendingRequest(professor As String, room As String, [date] As String, time As String, purpose As String)
        Dim rowIndex = dgvPending.Rows.Add(professor, room, [date], time, purpose)
        dgvPending.Rows(rowIndex).DefaultCellStyle.BackColor = Color.LightYellow
    End Sub

    ' Highlight Pending rows
    Private Sub dgvPending_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs)
        For i As Integer = e.RowIndex To e.RowIndex + e.RowCount - 1
            dgvPending.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow
        Next
    End Sub

    ' Handle Action button click in Pending Requests
    Private Sub dgvPending_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex < 0 Then Return
        If TypeOf dgvPending.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            selectedRowIndex = e.RowIndex
            Dim rect As Rectangle = dgvPending.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True)
            actionMenu.Show(dgvPending, rect.Left, rect.Bottom)
        End If
    End Sub

    ' Handle context menu clicks
    Private Sub actionMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        If selectedRowIndex < 0 Then Return
        Dim row = dgvPending.Rows(selectedRowIndex)
        Dim professor As String = row.Cells("Professor").Value.ToString()
        Dim room As String = row.Cells("Room").Value.ToString()
        Dim [date] As String = row.Cells("Date").Value.ToString()
        Dim time As String = row.Cells("Time").Value.ToString()

        Select Case e.ClickedItem.Text
            Case "Approve"
                ' Add to approved schedule (assuming you have dgvSchedule)
                dgvSchedule.Rows.Add(room, [date], time, professor, "F2F")
                dgvPending.Rows.RemoveAt(selectedRowIndex)
                MessageBox.Show($"Request approved for {professor} in room {room}.")
            Case "Reject"
                row.DefaultCellStyle.BackColor = Color.LightCoral
                Application.DoEvents()
                Threading.Thread.Sleep(300)
                dgvPending.Rows.RemoveAt(selectedRowIndex)
                MessageBox.Show($"Request rejected for {professor}.")
        End Select

        selectedRowIndex = -1
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim loginForm As Form1 = Application.OpenForms.OfType(Of Form1)().FirstOrDefault()

        If loginForm Is Nothing Then
            loginForm = New Form1()
        End If

        ' Clear login fields
        loginForm.txtUsername.Clear()
        loginForm.txtPassword.Clear()

        loginForm.Show()
        Me.Close()
    End Sub


End Class
