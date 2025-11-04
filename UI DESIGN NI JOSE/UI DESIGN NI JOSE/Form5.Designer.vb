<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbRoom = New System.Windows.Forms.ComboBox()
        Me.cmbTimeSlot = New System.Windows.Forms.ComboBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtPurpose = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.btnRequest = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(424, 37)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Room Scheduling Request"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 49)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Room:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 49)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(16, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(184, 49)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Time Slot:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(16, 405)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 49)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Purpose:"
        '
        'cmbRoom
        '
        Me.cmbRoom.BackColor = System.Drawing.Color.DimGray
        Me.cmbRoom.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRoom.ForeColor = System.Drawing.Color.Silver
        Me.cmbRoom.FormattingEnabled = True
        Me.cmbRoom.Location = New System.Drawing.Point(22, 145)
        Me.cmbRoom.Name = "cmbRoom"
        Me.cmbRoom.Size = New System.Drawing.Size(427, 41)
        Me.cmbRoom.TabIndex = 9
        '
        'cmbTimeSlot
        '
        Me.cmbTimeSlot.BackColor = System.Drawing.Color.DimGray
        Me.cmbTimeSlot.Font = New System.Drawing.Font("Arial Rounded MT Bold", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTimeSlot.ForeColor = System.Drawing.Color.Silver
        Me.cmbTimeSlot.FormattingEnabled = True
        Me.cmbTimeSlot.Location = New System.Drawing.Point(22, 354)
        Me.cmbTimeSlot.Name = "cmbTimeSlot"
        Me.cmbTimeSlot.Size = New System.Drawing.Size(427, 41)
        Me.cmbTimeSlot.TabIndex = 10
        '
        'dtpDate
        '
        Me.dtpDate.CalendarForeColor = System.Drawing.Color.Silver
        Me.dtpDate.CalendarMonthBackground = System.Drawing.Color.DimGray
        Me.dtpDate.CalendarTitleBackColor = System.Drawing.Color.DimGray
        Me.dtpDate.CalendarTitleForeColor = System.Drawing.Color.Silver
        Me.dtpDate.CalendarTrailingForeColor = System.Drawing.Color.DimGray
        Me.dtpDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Location = New System.Drawing.Point(22, 245)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(427, 30)
        Me.dtpDate.TabIndex = 11
        '
        'txtPurpose
        '
        Me.txtPurpose.BackColor = System.Drawing.Color.DimGray
        Me.txtPurpose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurpose.ForeColor = System.Drawing.Color.Silver
        Me.txtPurpose.Location = New System.Drawing.Point(22, 455)
        Me.txtPurpose.Multiline = True
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(427, 126)
        Me.txtPurpose.TabIndex = 12
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'btnRequest
        '
        Me.btnRequest.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRequest.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequest.ForeColor = System.Drawing.Color.White
        Me.btnRequest.Location = New System.Drawing.Point(22, 615)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(212, 78)
        Me.btnRequest.TabIndex = 14
        Me.btnRequest.Text = "SUBMIT REQUEST"
        Me.btnRequest.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.MidnightBlue
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(240, 615)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(212, 78)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(462, 711)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRequest)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.cmbTimeSlot)
        Me.Controls.Add(Me.cmbRoom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbRoom As ComboBox
    Friend WithEvents cmbTimeSlot As ComboBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents txtPurpose As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btnRequest As Button
    Friend WithEvents btnCancel As Button
End Class
