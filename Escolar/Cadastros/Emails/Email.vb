Public Class EMail
    Private semail As String = Nothing
    Public ReadOnly Property getEmail() As String
        Get
            Return semail
        End Get
    End Property

    Private Sub EMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txbemail.Text = ""
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If Not ValidateEmail(txbemail.Text) Then
            txbemail.Focus()
            Exit Sub
        End If
        semail = txbemail.Text
        Dispose()
    End Sub

    Private Sub txbemail_KeyUp(sender As Object, e As KeyEventArgs) Handles txbemail.KeyUp
        If e.KeyCode = Keys.Return Then
            btnSalvar.Focus()
            Exit Sub
        End If

        If e.KeyCode = Keys.Escape Then
            Dispose()
        End If
    End Sub

    Private Sub txbemail_KeyDown(sender As Object, e As KeyEventArgs) Handles txbemail.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub
End Class