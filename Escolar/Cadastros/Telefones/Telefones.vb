Public Class Telefones
    Private telefone As String = Nothing

    Public ReadOnly Property getTelefone() As String
        Get
            Return telefone
        End Get
    End Property

    Private Sub Telefones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tel_ddd.Text = ""
        tel_numero.Text = ""
        tel_destino.Text = "" : tel_destino.SelectedIndex = -1

        Dim fields As Controles
        fields = New Controles(Nothing)
        fields.FormataTelephone(tel_numero)
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        If tel_ddd.Text = "" Then
            tel_ddd.Focus()
            Exit Sub
        End If
        If tel_numero.Text.Replace("-", "").Trim = "" Then
            tel_numero.Focus()
            Exit Sub
        End If
        If tel_destino.Text = "" Then
            tel_destino.Focus()
            Exit Sub
        End If
        telefone = "(" & tel_ddd.Text & ")" & tel_numero.Text & " " & tel_destino.Text
        Dispose()
    End Sub

    Private Sub tel_ddd_KeyUp(sender As Object, e As KeyEventArgs) Handles tel_ddd.KeyUp
        If e.KeyCode = Keys.Return Then
            tel_numero.Focus()
        End If
    End Sub

    Private Sub tel_ddd_KeyDown(sender As Object, e As KeyEventArgs) Handles tel_ddd.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub tel_numero_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            tel_destino.Focus()
        End If
    End Sub

    Private Sub tel_numero_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub tel_destino_KeyUp(sender As Object, e As KeyEventArgs) Handles tel_destino.KeyUp
        If e.KeyCode = Keys.Return Then
            btnSalvar.Focus()
        End If
    End Sub

    Private Sub tel_destino_KeyDown(sender As Object, e As KeyEventArgs) Handles tel_destino.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub
End Class