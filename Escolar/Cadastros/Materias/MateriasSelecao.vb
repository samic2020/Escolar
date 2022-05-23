Imports MySql.Data.MySqlClient

Public Class MateriasSelecao
    Private dbMain As [Db] = New Db
    Private _idMateria As Integer = -1
    Private _nmMateria As String = Nothing
    Private _hsMes As String = Nothing

    Public ReadOnly Property idMateria As Integer
        Get
            Return _idMateria
        End Get
    End Property

    Public ReadOnly Property nmMateria As String
        Get
            Return _nmMateria
        End Get
    End Property

    Public ReadOnly Property hsMes As String
        Get
            Return _hsMes
        End Get
    End Property

    Private Sub DataGridViewMaterias_Scroll(sender As Object, e As ScrollEventArgs) Handles DataGridViewMaterias.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then VScrollBarMaterias.Value = e.NewValue
    End Sub

    Private Sub VScrollBarMaterias_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarMaterias.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then DataGridViewMaterias.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub MateriasSelecao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulaDGVMaterias()
        DataGridViewMaterias.Focus()
    End Sub

    Private Sub PopulaDGVMaterias()
        Dim sql As String = "SELECT id, materia, hrsmes FROM `materias` ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        Dim datatable As New DataTable("Materias")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("materia", GetType(String))
        datatable.Columns.Add("hrsmes", GetType(String))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewMaterias
            .DataSource = ""
            .DataSource = datatable

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

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "Materia"
            .Columns(1).Width = 150
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "HrsMes"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True
        End With

        VScrollBarMaterias.Maximum = DataGridViewMaterias.RowCount
        VScrollBarMaterias.LargeChange = DataGridViewMaterias.DisplayedRowCount(True)
        VScrollBarMaterias.SmallChange = 1

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If DataGridViewMaterias.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            DataGridViewMaterias.Focus()
            Return
        End If

        _idMateria = DataGridViewMaterias.SelectedRows.Item(0).Cells(0).Value
        _nmMateria = DataGridViewMaterias.SelectedRows.Item(0).Cells(1).Value
        _hsMes = DataGridViewMaterias.SelectedRows.Item(0).Cells(2).Value
        Dispose()
    End Sub
End Class