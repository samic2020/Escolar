Imports MySql.Data.MySqlClient

Public Class Pesquisar
    Private dbMain As [Db] = New Db
    Private source1 As New BindingSource()

    Public Enum PesquisarEm
        Clientes
        Fornecedores
        Produtos
        Usuarios
    End Enum

    Private tipoPesquisa As PesquisarEm = PesquisarEm.Clientes
    Public WriteOnly Property PesquisarPor() As PesquisarEm
        Set(value As PesquisarEm)
            tipoPesquisa = value
        End Set
    End Property

    Private gCodigo As String = Nothing
    Public ReadOnly Property getCodigo() As String
        Get
            Return gCodigo
        End Get
    End Property

    Private Sub Pesquisar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If tipoPesquisa = PesquisarEm.Clientes Then
            PesquisarAluno()
        ElseIf tipoPesquisa = PesquisarEm.Fornecedores Then
            PesquisarFornecedor()
        ElseIf tipoPesquisa = PesquisarEm.Produtos Then
            PesquisarProdutos()
        Else
            PesquisarUsuarios()
        End If

        TextBoxPesquisar.Focus()
    End Sub

    Private Sub PesquisarAluno()
        Dim datatable As New DataTable("Clientela")
        datatable.Columns.Add("Codigo", GetType(String))
        datatable.Columns.Add("Matricula", GetType(String))
        datatable.Columns.Add("Nome", GetType(String))
        datatable.Columns.Add("Cpf", GetType(String))
        datatable.Columns.Add("Pai", GetType(String))
        datatable.Columns.Add("Mae", GetType(String))

        Dim vSql As String = "SELECT id AS Codigo, matricula AS matricula, nome AS nome, cpf AS Cpf, pai_nome AS pai, mae_nome AS mae FROM `alunos` ORDER BY id"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(uFile)
        dbMain.CloseAll(conn, uFile)
        EntradaGridViewAlunos(datatable)
    End Sub

    Private Sub EntradaGridViewAlunos(table As DataTable)
        DataGridViewPesquisar.DataSource = ""
        DataGridViewPesquisar.DataSource = table
        source1.DataSource = table

        DataGridViewPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewPesquisar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewPesquisar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewPesquisar.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridViewPesquisar.GridColor = Color.Black
        DataGridViewPesquisar.RowHeadersVisible = False
        DataGridViewPesquisar.RowHeadersWidth = 25
        DataGridViewPesquisar.MultiSelect = True
        DataGridViewPesquisar.RowsDefaultCellStyle.BackColor = Color.White
        DataGridViewPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

        DataGridViewPesquisar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewPesquisar.Columns(0).HeaderText = "Codigo"
        DataGridViewPesquisar.Columns(0).Width = 60
        DataGridViewPesquisar.Columns(0).ReadOnly = True

        DataGridViewPesquisar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(1).HeaderText = "Matricula"
        DataGridViewPesquisar.Columns(1).Width = 60
        DataGridViewPesquisar.Columns(1).ReadOnly = True

        DataGridViewPesquisar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(2).HeaderText = "Nome"
        DataGridViewPesquisar.Columns(2).Width = 300
        DataGridViewPesquisar.Columns(2).ReadOnly = True

        DataGridViewPesquisar.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(3).HeaderText = "CPF"
        DataGridViewPesquisar.Columns(3).Width = 150
        DataGridViewPesquisar.Columns(3).ReadOnly = True

        DataGridViewPesquisar.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(4).HeaderText = "Pai"
        DataGridViewPesquisar.Columns(4).Width = 200
        DataGridViewPesquisar.Columns(4).ReadOnly = True

        DataGridViewPesquisar.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(5).HeaderText = "Mae"
        DataGridViewPesquisar.Columns(5).Width = 200
        DataGridViewPesquisar.Columns(5).ReadOnly = True

    End Sub

    Private Sub PesquisarFornecedor()
        Dim datatable As New DataTable("Fornecedores")
        Dim vSql As String = "SELECT for_cod, for_nome, for_fanta, for_cnpj FROM cadfor ORDER BY for_cod"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(uFile)
        uFile.Close()
        conn.Close()
        EntradaGridViewFornecedor(datatable)
    End Sub

    Private Sub EntradaGridViewFornecedor(table As DataTable)
        DataGridViewPesquisar.DataSource = ""
        DataGridViewPesquisar.DataSource = table
        source1.DataSource = table

        DataGridViewPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewPesquisar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewPesquisar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewPesquisar.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridViewPesquisar.GridColor = Color.Black
        DataGridViewPesquisar.RowHeadersVisible = False
        DataGridViewPesquisar.RowHeadersWidth = 25
        DataGridViewPesquisar.MultiSelect = True
        DataGridViewPesquisar.RowsDefaultCellStyle.BackColor = Color.White
        DataGridViewPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

        DataGridViewPesquisar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewPesquisar.Columns(0).HeaderText = "Codigo"
        DataGridViewPesquisar.Columns(0).Width = 60
        DataGridViewPesquisar.Columns(0).ReadOnly = True

        DataGridViewPesquisar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(1).HeaderText = "Razao"
        DataGridViewPesquisar.Columns(1).Width = 300
        DataGridViewPesquisar.Columns(1).ReadOnly = True

        DataGridViewPesquisar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(2).HeaderText = "Fantasia"
        DataGridViewPesquisar.Columns(2).Width = 300
        DataGridViewPesquisar.Columns(2).ReadOnly = True

        DataGridViewPesquisar.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(3).HeaderText = "CNPJ/CPF"
        DataGridViewPesquisar.Columns(3).Width = 150
        DataGridViewPesquisar.Columns(3).ReadOnly = True
    End Sub

    Private Sub PesquisarProdutos()
        Dim datatable As New DataTable("Produtos")
        Dim vSql As String = "SELECT p_cod, p_desc, p_cdbar FROM cadprod ORDER BY p_cod"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(uFile)
        uFile.Close()
        conn.Close()
        EntradaGridViewProdutos(datatable)
    End Sub

    Private Sub EntradaGridViewProdutos(table As DataTable)
        DataGridViewPesquisar.DataSource = ""
        DataGridViewPesquisar.DataSource = table
        source1.DataSource = table

        DataGridViewPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewPesquisar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewPesquisar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewPesquisar.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridViewPesquisar.GridColor = Color.Black
        DataGridViewPesquisar.RowHeadersVisible = False
        DataGridViewPesquisar.RowHeadersWidth = 25
        DataGridViewPesquisar.MultiSelect = True
        DataGridViewPesquisar.RowsDefaultCellStyle.BackColor = Color.White
        DataGridViewPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

        DataGridViewPesquisar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewPesquisar.Columns(0).HeaderText = "Codigo"
        DataGridViewPesquisar.Columns(0).Width = 60
        DataGridViewPesquisar.Columns(0).ReadOnly = True

        DataGridViewPesquisar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(1).HeaderText = "Descricao"
        DataGridViewPesquisar.Columns(1).Width = 300
        DataGridViewPesquisar.Columns(1).ReadOnly = True

        DataGridViewPesquisar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(2).HeaderText = "Barras"
        DataGridViewPesquisar.Columns(2).Width = 150
        DataGridViewPesquisar.Columns(2).ReadOnly = True
        DataGridViewPesquisar.Columns(2).Visible = False
    End Sub

    Private Sub PesquisarUsuarios()
        Dim datatable As New DataTable("Usuarios")
        Dim vSql As String = "SELECT f_cod, f_nome, usuario FROM cadfun ORDER BY f_cod"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(uFile)
        uFile.Close()
        conn.Close()
        EntradaGridViewUsuarios(datatable)
    End Sub

    Private Sub EntradaGridViewUsuarios(table As DataTable)
        DataGridViewPesquisar.DataSource = ""
        DataGridViewPesquisar.DataSource = table
        source1.DataSource = table

        DataGridViewPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridViewPesquisar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        DataGridViewPesquisar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewPesquisar.CellBorderStyle = DataGridViewCellBorderStyle.Single
        DataGridViewPesquisar.GridColor = Color.Black
        DataGridViewPesquisar.RowHeadersVisible = False
        DataGridViewPesquisar.RowHeadersWidth = 25
        DataGridViewPesquisar.MultiSelect = True
        DataGridViewPesquisar.RowsDefaultCellStyle.BackColor = Color.White
        DataGridViewPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

        DataGridViewPesquisar.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewPesquisar.Columns(0).HeaderText = "Codigo"
        DataGridViewPesquisar.Columns(0).Width = 60
        DataGridViewPesquisar.Columns(0).ReadOnly = True

        DataGridViewPesquisar.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(1).HeaderText = "Nome"
        DataGridViewPesquisar.Columns(1).Width = 300
        DataGridViewPesquisar.Columns(1).ReadOnly = True

        DataGridViewPesquisar.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewPesquisar.Columns(2).HeaderText = "Usuario"
        DataGridViewPesquisar.Columns(2).Width = 150
        DataGridViewPesquisar.Columns(2).ReadOnly = True
    End Sub

    Private Sub TextBoxPesquisar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPesquisar.TextChanged
        If TextBoxPesquisar.Text.Trim = "" Then
            source1.Filter = Nothing
            DataGridViewPesquisar.Refresh()
            Exit Sub
        End If
        Dim filtro As String = Nothing
        If tipoPesquisa = PesquisarEm.Clientes Then
            filtro = "Codigo+Matricula+Nome+Cpf+Pai+Mae like '%" & TextBoxPesquisar.Text.Trim & "%'"
        ElseIf tipoPesquisa = PesquisarEm.Fornecedores Then
            filtro = "for_cod like '%" & TextBoxPesquisar.Text.Trim & "' OR for_nome like '%" & TextBoxPesquisar.Text.Trim.ToUpper &
                     "%' OR for_fanta = '%" & TextBoxPesquisar.Text.Trim & "%' OR for_cnpj like '" & TextBoxPesquisar.Text.Trim & "%'"
        ElseIf tipoPesquisa = PesquisarEm.Produtos Then
            filtro = "p_cod like '%" & TextBoxPesquisar.Text.Trim & "' OR p_desc like '%" & TextBoxPesquisar.Text.Trim &
                     "%' OR p_cdbar like '%" & TextBoxPesquisar.Text.Trim & "%'"
        Else
            filtro = "f_cod like '%" & TextBoxPesquisar.Text.Trim & "' OR f_nome like '%" & TextBoxPesquisar.Text.Trim &
                     "%' OR usuario like '" & TextBoxPesquisar.Text.Trim & "%'"
        End If
        source1.Filter = filtro
        DataGridViewPesquisar.Refresh()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        TextBoxPesquisar.Text = ""
        TextBoxPesquisar.Focus()
    End Sub

    Private Sub DataGridViewPesquisar_DoubleClick(sender As Object, e As EventArgs) Handles DataGridViewPesquisar.DoubleClick
        If DataGridViewPesquisar.Rows.Count <= 0 Then Return
        gCodigo = DataGridViewPesquisar.SelectedRows.Item(0).Cells.Item(0).Value.ToString
        Dispose()
    End Sub

    Private Sub TextBoxPesquisar_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBoxPesquisar.KeyUp
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If TextBoxPesquisar.Text.Trim <> "" Then
                DataGridViewPesquisar.Focus()
            Else
                TextBoxPesquisar.Focus()
            End If
        End If
    End Sub

    Private Sub TextBoxPesquisar_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxPesquisar.KeyDown
        If e.KeyCode = Keys.KeyCode.Return Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub DataGridViewPesquisar_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridViewPesquisar.KeyUp
        If e.KeyCode = Keys.KeyCode.Return Then
            If DataGridViewPesquisar.Rows.Count <= 0 Then Return
            If DataGridViewPesquisar.SelectedRows.Count = 0 Then Return
            gCodigo = DataGridViewPesquisar.SelectedRows.Item(0).Cells.Item(0).Value.ToString
            Dispose()
        End If
        If e.KeyCode = Keys.KeyCode.Escape Then
            TextBoxPesquisar.Focus()
        End If
    End Sub

    Private Sub DataGridViewPesquisar_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewPesquisar.KeyDown
        If e.KeyCode = Keys.KeyCode.Return Then
            e.SuppressKeyPress = True
        End If
    End Sub
End Class