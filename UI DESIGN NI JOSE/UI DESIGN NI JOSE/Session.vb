
' Session.vb
Public Module Session
    Public Property UserId As Integer = -1
    Public Property Username As String = ""
    Public Property Role As String = ""
    Public ReadOnly Property IsLoggedIn As Boolean
        Get
            Return UserId > 0
        End Get
    End Property

    Public Sub Clear()
        UserId = -1
        Username = ""
        Role = ""
    End Sub
End Module

