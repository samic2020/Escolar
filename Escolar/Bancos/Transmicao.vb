Imports MySql.Data.MySqlClient

Public Class Transmicao
    Private dbMain As [Db] = New Db

    Private Sub btGerRemessa_Click(sender As Object, e As EventArgs) Handles btGerRemessa.Click
        ListarTodos()
    End Sub

    Private Sub ListarTodos()
        Dim datatable As New DataTable("Remessa")
        Dim sql As String = "SELECT t.remessa REMESSA, t.dttrans DTTRANS, t.ntfiscal NFISCAL, t.data DTIMPRESSAO, t.nnumero NNUMERO, t.dtvenc VENCTO, c.cli_fanta AS NOME, t.valor VALOR, t.parcela,c.cli_cnpj FROM contas t INNER JOIN cadcli c ON c.cli_cod = t.cliente WHERE t.boleta = 1 AND not isnull(t.nnumero) AND t.tx = 1 AND remessa = @REMESSA ORDER BY t.ntfiscal, t.dtvenc"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, New Object()() {({"@REMESSA", cbxRemessa.SelectedItem(0).ToString})})
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)
        MontaGrid(datatable)
    End Sub

    Private Sub ListarNNumero()
        Dim datatable As New DataTable("Remessa")
        Dim sql As String = "SELECT t.remessa REMESSA, t.dttrans DTTRANS, t.ntfiscal NFISCAL, t.data DTIMPRESSAO, t.nnumero NNUMERO, t.dtvenc VENCTO, c.cli_fanta AS NOME, t.valor VALOR, t.parcela,c.cli_cnpj FROM contas t INNER JOIN cadcli c ON c.cli_cod = t.cliente WHERE t.boleta = 1 AND not isnull(t.nnumero) AND t.tx = 1 AND nnumero = @NNUMERO ORDER BY t.ntfiscal, t.dtvenc"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, New Object()() {({"@NNUMERO", nnumero.Text.Trim})})
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)
        MontaGrid(datatable)
    End Sub

    Private Sub TodasRemessas()
        Dim datatable As New DataTable("Remessas")
        Dim sql As String = "SELECT DISTINCT remessa from contas WHERE remessa != '000000' ORDER BY remessa"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        cbxRemessa.DataSource = datatable
        cbxRemessa.DisplayMember = "remessa"
        cbxRemessa.ValueMember = "remessa"
    End Sub

    Private Sub MontaGrid(datatable As DataTable)
        With Boletas
            .DataSource = Nothing
            .DataSource = datatable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False
            .RowHeadersWidth = 25
            .MultiSelect = True
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "Remessa"
            .Columns(0).Width = 80
            .Columns(0).ReadOnly = True

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "Dt.Transmição"
            .Columns(1).Width = 80
            .Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderText = "NFiscal"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "Dt.Impressão"
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).HeaderText = "NNUMERO"
            .Columns(4).Width = 110
            .Columns(4).DefaultCellStyle.Format = "#00"
            .Columns(4).ReadOnly = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).HeaderText = "Vencimento"
            .Columns(5).Width = 80
            .Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"
            .Columns(5).ReadOnly = True

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(6).HeaderText = "Nome"
            .Columns(6).Width = 250
            .Columns(6).ReadOnly = True

            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Valor"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Format = "#,##0.00"
            .Columns(7).ReadOnly = True

            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(8).HeaderText = "Parcela"
            .Columns(8).Width = 60
            .Columns(8).ReadOnly = True

            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "CPF/CNPJ"
            .Columns(9).Width = 110
            .Columns(9).ReadOnly = True
        End With
    End Sub

    Private Sub Transmicao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TodasRemessas()
    End Sub

    Private Sub btnVisualizarNNumero_Click(sender As Object, e As EventArgs) Handles btnVisualizarNNumero.Click
        ListarNNumero()
    End Sub
End Class