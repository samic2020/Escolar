Imports MySql.Data.MySqlClient

Public Class sgSenha
    Private dbMain As [Db] = New Db
    Private Retorno As Boolean = False

    Public ReadOnly Property getPodeAbrir() As Boolean
        Get
            Return Retorno
        End Get
    End Property

    Private Sub btEntre_Click(sender As Object, e As EventArgs) Handles btEntre.Click
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim selectSQL As String = "SELECT usuario, senha, f_funcao, f_cod, master, atalhos FROM cadfun WHERE usuario = @usuario AND senha = @senha AND Upper(Trim(f_funcao)) LIKE '%GERENTE%'"
        Dim tcadfun As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@usuario", usuario.Text.Trim}), ({"@senha", Senha.Text.Trim})})
        Retorno = tcadfun.HasRows
        dbMain.CloseAll(conn, tcadfun)
        Dispose()
    End Sub

    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Retorno = False
        Dispose()
    End Sub

    Private Sub usuario_KeyUp(sender As Object, e As KeyEventArgs) Handles usuario.KeyUp
        If e.KeyCode = Keys.Escape Then
            Retorno = False
            Dispose()
        End If
        If e.KeyCode = Keys.Return And Trim(usuario.Text) <> "" Then
            Senha.Text = ""
            Senha.Enabled = True
            Senha.Focus()
        End If
    End Sub

    Private Sub usuario_GotFocus(sender As Object, e As EventArgs) Handles usuario.GotFocus
        Senha.Text = ""
        Senha.Enabled = False
    End Sub

    Private Sub usuario_KeyDown(sender As Object, e As KeyEventArgs) Handles usuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub senha_KeyUp(sender As Object, e As KeyEventArgs) Handles Senha.KeyUp
        If e.KeyCode = Keys.Escape Then
            usuario.Focus()
        End If
        If e.KeyCode = Keys.Return And Trim(usuario.Text) <> "" Then
            '// Logar no usuário
            btEntre.Enabled = True
            btEntre.Focus()
        End If
    End Sub

    Private Sub senha_KeyDown(sender As Object, e As KeyEventArgs) Handles Senha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub
End Class