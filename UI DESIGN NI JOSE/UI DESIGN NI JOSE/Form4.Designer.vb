<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvSchedule = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.btnRequest = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSchedule
        '
        Me.dgvSchedule.BackgroundColor = System.Drawing.Color.DimGray
        Me.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvSchedule.Location = New System.Drawing.Point(484, 114)
        Me.dgvSchedule.Name = "dgvSchedule"
        Me.dgvSchedule.RowHeadersWidth = 62
        Me.dgvSchedule.RowTemplate.Height = 28
        Me.dgvSchedule.Size = New System.Drawing.Size(742, 448)
        Me.dgvSchedule.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Room"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "Date"
        Me.Column2.MinimumWidth = 8
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Time"
        Me.Column3.MinimumWidth = 8
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Purpose"
        Me.Column4.MinimumWidth = 8
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 150
        '
        'cmbDepartment
        '
        Me.cmbDepartment.BackColor = System.Drawing.Color.DimGray
        Me.cmbDepartment.DropDownWidth = 310
        Me.cmbDepartment.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Items.AddRange(New Object() {"Bachelor of Science in Psychology", "Bachelor of Science in Accountancy", "Bachelor of Science in Customs Administration", "Bachelor of Science in Business Administration", "Major in Marketing Management", "Major in Financial Management", "Major in Financial Management", "Major in Human Resource Development Management", "Bachelor of Science in Criminology", "Bachelor of Science in Computer Science", "Bachelor of Science in Information Technology", "Bachelor of Elementary Education", "Bachelor of Secondary Education", "Major in English", "Major in Filipino", "Major in Mathematics", "Major in Mathematics", "Bachelor of Technical Vocational for Teacher Education", "Major in Automotive Technology", "Major in Computer Programming", "Major in Food Service Management", "Major in Electronics Technology", "Major in Welding and Fabrication", "Bachelor of Science in Industrial Engineering", "Bachelor of Science in Computer Engineering"})
        Me.cmbDepartment.Location = New System.Drawing.Point(12, 114)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(464, 36)
        Me.cmbDepartment.TabIndex = 8
        '
        'btnRequest
        '
        Me.btnRequest.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRequest.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!)
        Me.btnRequest.ForeColor = System.Drawing.Color.White
        Me.btnRequest.Location = New System.Drawing.Point(3, 332)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(476, 103)
        Me.btnRequest.TabIndex = 9
        Me.btnRequest.Text = "REQUEST"
        Me.btnRequest.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 20.25!)
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(3, 457)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(476, 103)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 26.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(2, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(569, 61)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "WELCOME Professor"
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1228, 563)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRequest)
        Me.Controls.Add(Me.cmbDepartment)
        Me.Controls.Add(Me.dgvSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        CType(Me.dgvSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSchedule As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents btnRequest As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
End Class
