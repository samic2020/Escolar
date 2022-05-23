Imports MySql.Data.MySqlClient

Public Class Pisico
    Private dbMain As [Db] = New Db

    Private _idAluno As Integer = -1

    WriteOnly Property idAluno As Integer
        Set(ByVal value As Integer)
            _idAluno = value
        End Set
    End Property

    Private Sub Pisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LerPsicos(_idAluno)
    End Sub

    Private Sub LerPsicos(id As Integer)
        Dim sql As String = "SELECT * FROM `alunos_pisico` WHERE `idaluno` = @idaluno ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@idaluno", id})})
        Dim datatable As New DataTable("Comportamentos")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("idAluno", GetType(Integer))
        datatable.Columns.Add("pisico", GetType(String))
        datatable.Columns.Add("datahora", GetType(DateTime))
        datatable.Columns.Add("responsavel", GetType(String))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        Comportamentos(datatable)
    End Sub

    Private Sub Comportamentos(table As DataTable)
        With PsicoLista
            .DataSource = ""
            .DataSource = table

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False
            .RowHeadersWidth = 25
            .MultiSelect = False
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 60
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "idAluno"
            .Columns(1).Width = 60
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = False

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "Comportamento"
            .Columns(2).Width = 300
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "DataHora"
            .Columns(3).Width = 100
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).HeaderText = "Responsavel"
            .Columns(4).Width = 270
            .Columns(4).ReadOnly = True
        End With
    End Sub

End Class