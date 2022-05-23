Imports MySql.Data.MySqlClient

Public Class Materias
    Private dbMain As [Db] = New Db

    Private Sub VScrollBarMaterias_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBarMaterias.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then DataGridViewMaterias.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub DataGridViewMaterias_Scroll(sender As Object, e As ScrollEventArgs) Handles DataGridViewMaterias.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then VScrollBarMaterias.Value = e.NewValue
    End Sub

    Private Sub Materias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl As Controles = New Controles(Nothing)
        ctrl.FormataHora(txbHoras, "000\:00")

        PopulaDGVMaterias()
        EnableControles(False)
        DataGridViewMaterias.Focus()
    End Sub

    Private Sub EnableControles(value As Boolean)
        txbMateria.Text = ""
        txbMateria.Enabled = value

        txbHoras.Text = "00:00"
        txbHoras.Enabled = value

        matBtnOk.Enabled = value

        DataGridViewMaterias.Enabled = Not value
        VScrollBarMaterias.Enabled = Not value
        btnMatAdc.Enabled = Not value
        btnMatDel.Enabled = Not value
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

    Private Sub btnMatAdc_Click(sender As Object, e As EventArgs) Handles btnMatAdc.Click
        EnableControles(True)
        txbMateria.Focus()
    End Sub

    Private Sub matBtnOk_Click(sender As Object, e As EventArgs) Handles matBtnOk.Click
        '// Grava dados
        Dim insertSQL As String = "INSERT INTO `materias`(`materia`,`hrsmes`) VALUES (@materia, @hrsmes);"
        Dim param As Object()() = {({"@materia", txbMateria.Text.Trim}), ({"@hrsmes", txbHoras.Text.Trim})}
        dbMain.ExecuteCmd(insertSQL, param)

        PopulaDGVMaterias()
        EnableControles(False)
        DataGridViewMaterias.Focus()
    End Sub

    Private Sub btnMatDel_Click(sender As Object, e As EventArgs) Handles btnMatDel.Click
        If DataGridViewMaterias.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            DataGridViewMaterias.Focus()
            Return
        End If

        If MsgBox("Exclui esta Matéria?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
        Dim idmateria As Integer = DataGridViewMaterias.SelectedRows.Item(0).Cells(0).Value
        Dim deleteSQL As String = "DELETE FROM `materias` WHERE id = @id;"
        dbMain.ExecuteCmd(deleteSQL, {({"@id", idmateria})})

        '// Deletea Materias de Turmas x Materias
        deleteSQL = "DELETE FROM `turmas_materias` WHERE idmaterias = @idmaterias"
        dbMain.ExecuteCmd(deleteSQL, {({"@idmaterias", idmateria})})

        DataGridViewMaterias.Rows.RemoveAt(DataGridViewMaterias.SelectedRows(0).Index)
        PopulaDGVMaterias()
        DataGridViewMaterias.Focus()
    End Sub
End Class