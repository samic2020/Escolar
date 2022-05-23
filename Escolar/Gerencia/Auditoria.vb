Imports MySql.Data.MySqlClient

Public Class Auditoria
    Private dbMain As [Db] = New Db

    Private Sub Auditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _iniDate As DateTime = GetMinDate()
        Dim _fimDate As DateTime = GetMaxDate()

        dtpInicio.MinDate = _iniDate
        dtpInicio.MaxDate = _fimDate
        dtpInicio.Value = _iniDate

        dtpFinal.MinDate = _iniDate
        dtpFinal.MaxDate = _fimDate
        dtpFinal.Value = _fimDate

        '// Inicializa comboboxs
        FillUsuarios()
        FillModulos()
        FillOperacoes()

        cbxUsuarios.Focus()
    End Sub

    Private Sub FillUsuarios()
        Dim datatable As New DataTable("usuarios")
        Dim sql As String = "SELECT distinct Upper(usuario) usuario FROM cicle.auditor where trim(usuario) != '' order by Upper(usuario);"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql)
        datatable.Load(uFile)
        dbMain.CloseAll(conn, uFile)

        Dim _row As DataRow
        _row = datatable.NewRow
        _row(0) = "TODOS"
        datatable.Rows.InsertAt(_row, 0)

        cbxUsuarios.DataSource = Nothing

        cbxUsuarios.DataSource = datatable
        cbxUsuarios.DisplayMember = "usuario"
        cbxUsuarios.ValueMember = "usuario"
    End Sub

    Private Sub FillModulos()
        Dim datatable As New DataTable("modulos")
        Dim sql As String = "SELECT distinct Upper(modulo) modulo FROM cicle.auditor where trim(modulo) != '' order by Upper(modulo);"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql)
        datatable.Load(uFile)
        dbMain.CloseAll(conn, uFile)

        Dim _row As DataRow
        _row = datatable.NewRow
        _row(0) = "TODOS"
        datatable.Rows.InsertAt(_row, 0)

        cbxModulos.DataSource = Nothing

        cbxModulos.DataSource = datatable
        cbxModulos.DisplayMember = "modulo"
        cbxModulos.ValueMember = "modulo"
    End Sub

    Private Sub FillOperacoes()
        Dim datatable As New DataTable("operacoes")
        Dim sql As String = "SELECT distinct Upper(operacao) operacao FROM cicle.auditor where trim(operacao) != '' order by Upper(operacao);"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql)
        datatable.Load(uFile)
        dbMain.CloseAll(conn, uFile)

        Dim _row As DataRow
        _row = datatable.NewRow
        _row(0) = "TODOS"
        datatable.Rows.InsertAt(_row, 0)

        cbxOperacoes.DataSource = Nothing

        cbxOperacoes.DataSource = datatable
        cbxOperacoes.DisplayMember = "operacao"
        cbxOperacoes.ValueMember = "operacao"
    End Sub

    Private Function GetMinDate() As DateTime
        Dim retorno As DateTime = New DateTime(2000, 1, 1)
        Dim sql As String = "SELECT Min(datahora) datahora FROM cicle.auditor;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql)
        If uFile.HasRows Then
            uFile.Read()
            retorno = uFile.GetDateTime("datahora")
        End If
        dbMain.CloseAll(conn, uFile)
        Return retorno
    End Function

    Private Function GetMaxDate() As DateTime
        Dim retorno As DateTime = New DateTime(2090, 1, 1)
        Dim sql As String = "SELECT Max(datahora) datahora FROM cicle.auditor;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql)
        If uFile.HasRows Then
            uFile.Read()
            retorno = uFile.GetDateTime("datahora")
        End If
        dbMain.CloseAll(conn, uFile)
        Return retorno
    End Function

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Dim sql As String = "SELECT id, usuario, modulo, operacao, datahora, novo, velho FROM auditor WHERE (datahora >= @DATAINI AND datahora <= @DATAFIM)"
        Dim _Where As String = ""
        Dim param As Object()() = New Object()() {
                ({"@DATAINI", dtpInicio.Value}),
                ({"@DATAFIM", dtpFinal.Value})
        }

        If cbxUsuarios.SelectedIndex > 0 Then
            _Where = " AND Upper(Trim(usuario)) = @USUARIO"
            param = param.Append(New Object() {"@USUARIO", cbxUsuarios.SelectedItem("usuario").ToString}).ToArray
        End If

        If cbxModulos.SelectedIndex > 0 Then
            _Where &= " AND Upper(Trim(modulo)) = @MODULO"
            param = param.Append(New Object() {"@MODULO", cbxModulos.SelectedItem("modulo").ToString}).ToArray
        End If

        If cbxOperacoes.SelectedIndex > 0 Then
            _Where &= " AND Upper(Trim(operacao)) = @OPERACAO"
            param = param.Append(New Object() {"@OPERACAO", cbxOperacoes.SelectedItem("operacao").ToString}).ToArray
        End If

        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, sql + _Where, param)
        Dim datatable As New DataTable("operacoes")
        datatable.Load(uFile)
        dbMain.CloseAll(conn, uFile)

        With dgvEventos
            .DataSource = Nothing
            .DataSource = datatable
        End With
    End Sub
End Class