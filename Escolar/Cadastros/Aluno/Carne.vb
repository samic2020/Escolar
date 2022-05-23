Imports MySql.Data.MySqlClient

Public Class Carne
    Private dbMain As [Db] = New Db
    Private match As DataGridViewCell()
    Private pos As Integer
    Private first As Boolean = True

    Private Sub Carne_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulaDGVAlunos(NumericUpDownAno.Value)
        first = False
    End Sub

    Private Sub LabelClear_Click(sender As Object, e As EventArgs) Handles LabelClear.Click
        pos = -1
        LabelClear.Enabled = False
        LabelPrevious.Enabled = False
        LabelNext.Enabled = False

        TextBoxBuscar.Text = ""
        TextBoxBuscar.Focus()
    End Sub

    Private Sub TextBoxBuscar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBuscar.TextChanged
        If TextBoxBuscar.Text.Length = 0 Then
            pos = -1
            match = Nothing
            DataGridViewAlunos.Refresh()
            LabelClear.Enabled = False
            Exit Sub
        End If

        LabelClear.Enabled = True
        match = (From row As DataGridViewRow In DataGridViewAlunos.Rows From cell As DataGridViewCell In row.Cells Select cell Where CStr(cell.FormattedValue).Contains(TextBoxBuscar.Text.ToUpper.Trim)).ToArray()

        If match.Length > 0 Then
            pos = 0
            DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
            DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex

            If match.Length = 1 Then
                LabelNext.Enabled = False
                LabelPrevious.Enabled = False
            Else
                LabelNext.Enabled = True
                LabelPrevious.Enabled = False
            End If
        End If

        If match.Length <= 0 Then
            pos = -1
            LabelNext.Enabled = False
            LabelPrevious.Enabled = False
        End If

    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub PopulaDGVAlunos(ano As Integer)
        Dim sql As String = "SELECT al.`id` id, al.`matricula` matricula, al.`nome` nome FROM `alunos` al, `turmas_alunos` ta WHERE ta.`idaluno` = al.`id` and ta.`ano` = @ano;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@ano", ano})})
        Dim datatable As New DataTable("AlunosAno")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("matricula", GetType(String))
        datatable.Columns.Add("nome", GetType(String))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewAlunos
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
            .Columns(1).HeaderText = "matricula"
            .Columns(1).Width = 80
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "nome"
            .Columns(2).Width = 280
            .Columns(2).ReadOnly = True
        End With

    End Sub

    Private Sub NumericUpDownAno_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownAno.ValueChanged
        If Not first Then PopulaDGVAlunos(NumericUpDownAno.Value)
    End Sub

    Private Sub LabelPrevious_Click(sender As Object, e As EventArgs) Handles LabelPrevious.Click
        pos -= 1
        LabelNext.Enabled = True
        LabelPrevious.Enabled = True
        If pos <= 0 Then
            pos = 0
            LabelPrevious.Enabled = False
            LabelNext.Enabled = True
        End If
        DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub

    Private Sub LabelNext_Click(sender As Object, e As EventArgs) Handles LabelNext.Click
        pos += 1
        LabelNext.Enabled = True
        LabelPrevious.Enabled = True
        If pos >= match.Length - 1 Then
            pos = match.Length - 1
            LabelPrevious.Enabled = True
            LabelNext.Enabled = False
        End If
        DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub
End Class