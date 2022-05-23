Imports MySql.Data.MySqlClient

Public Class Turmas
    Private dbMain As [Db] = New Db

    Private Sub Turmas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fields As Controles = New Controles(Nothing)
        fields.FormataNumero(tLotacao, 0)

        EnableControles(False)
        PopulaDGVTurmas()
        DataGridViewTurmas.Focus()
    End Sub

    Private Sub tCursos_Enter(sender As Object, e As EventArgs) Handles tCursos.Enter
        tSeries.Items.Clear()
        tSeries.Enabled = False

        tTurnos.Items.Clear()
        tTurnos.Enabled = False

        tTurma.Text = ""
        tTurma.Enabled = False

        tLotacao.Text = "0"
        tLotacao.Enabled = False
    End Sub

    Private Sub tCursos_KeyDown(sender As Object, e As KeyEventArgs) Handles tCursos.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tCursos_KeyUp(sender As Object, e As KeyEventArgs) Handles tCursos.KeyUp
        If e.KeyCode = Keys.Enter And tCursos.SelectedIndex > -1 Then
            tSeries.Items.AddRange(New ListasDiversas().Series(tCursos.SelectedIndex))
            tSeries.Enabled = True
            tSeries.Focus()
        End If
    End Sub

    Private Sub tSeries_Enter(sender As Object, e As EventArgs) Handles tSeries.Enter
        tTurnos.Items.Clear()
        tTurnos.Enabled = False

        tTurma.Text = ""
        tTurma.Enabled = False

        tLotacao.Text = "0"
        tLotacao.Enabled = False
    End Sub

    Private Sub tSeries_KeyDown(sender As Object, e As KeyEventArgs) Handles tSeries.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tSeries_KeyUp(sender As Object, e As KeyEventArgs) Handles tSeries.KeyUp
        If e.KeyCode = Keys.Enter And tSeries.SelectedIndex > -1 Then
            tTurnos.Items.AddRange(New ListasDiversas().Turnos())
            tTurnos.Enabled = True
            tTurnos.Focus()
        End If
    End Sub

    Private Sub tTurnos_Enter(sender As Object, e As EventArgs) Handles tTurnos.Enter
        tTurma.Text = ""
        tTurma.Enabled = False

        tLotacao.Text = "0"
        tLotacao.Enabled = False
    End Sub

    Private Sub tTurnos_KeyDown(sender As Object, e As KeyEventArgs) Handles tTurnos.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tTurnos_KeyUp(sender As Object, e As KeyEventArgs) Handles tTurnos.KeyUp
        If e.KeyCode = Keys.Enter And tTurnos.SelectedIndex > -1 Then
            tTurma.Text = ""
            tTurma.Enabled = True

            tLotacao.Text = "0"
            tLotacao.Enabled = True
            tTurma.Focus()
        End If
    End Sub

    Private Sub EnableControles(value As Boolean)
        tCursos.Text = ""
        tCursos.SelectedIndex = -1
        tCursos.Enabled = value

        tSeries.Text = ""
        tSeries.SelectedIndex = -1
        tSeries.Enabled = value

        tTurnos.Text = ""
        tTurnos.SelectedIndex = -1
        tTurnos.Enabled = value

        tTurma.Text = ""
        tTurma.Enabled = value

        tLotacao.Text = "0"
        tLotacao.Enabled = value

        tumBtnOk.Enabled = value

        DataGridViewTurmas.Enabled = Not value
        btnTurAdc.Enabled = Not value
        btnTurDel.Enabled = Not value

        DataGridViewMaterias.Enabled = Not value
        btnMatAdc.Enabled = Not value
        btnMatDel.Enabled = Not value

        btnMatUp.Enabled = Not value
        btnMatDown.Enabled = Not value
    End Sub

    Private Sub PopulaDGVTurmasMaterias(idturma As Integer)
        If idturma < 0 Then Return

        With DataGridViewMaterias
            .DataSource = Nothing

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
            .Columns.Clear()

            .Columns.Add("id", "id")
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 60
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns.Add("idturmas", "idturmas")
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "idturmas"
            .Columns(1).Width = 60
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = False

            .Columns.Add("idmaterias", "idmaterias")
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderText = "idmaterias"
            .Columns(2).Width = 60
            .Columns(2).ReadOnly = True
            .Columns(2).Visible = False

            .Columns.Add("ordem", "ordem")
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "ordem"
            .Columns(3).Width = 60
            .Columns(3).ReadOnly = True
            .Columns(3).Visible = False

            .Columns.Add("materia", "Materia")
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).HeaderText = "Materia"
            .Columns(4).Width = 150
            .Columns(4).ReadOnly = True

            .Columns.Add("hrsmes", "HrsMes")
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(5).HeaderText = "HrsMes"
            .Columns(5).Width = 80
            .Columns(5).ReadOnly = True
        End With

        With DataGridViewMaterias
            Dim sql As String = "SELECT * FROM `turmas_materias` WHERE idturmas = @idturmas ORDER BY `ordem`;"
            Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
            Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@idturmas", idturma})})

            Try
                While vrs.Read
                    .Rows.Add({vrs.GetInt32("id"), vrs.GetInt32("idturmas"), vrs.GetInt32("idmaterias"), vrs.GetInt32("ordem"), vrs.GetString("materia"), vrs.GetString("hrsmes")})
                End While
            Catch ex As Exception
            End Try
            dbMain.CloseAll(conn, vrs)
        End With
    End Sub

    Private Sub PopulaDGVTurmas()
        Dim sql As String = "SELECT `id`, `curso`, `serie`, `turno`, `turma`, `lotacao` FROM `turmas`;" '// ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        Dim datatable As New DataTable("turmas")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("curso", GetType(String))
        datatable.Columns.Add("serie", GetType(String))
        datatable.Columns.Add("turno", GetType(String))
        datatable.Columns.Add("turma", GetType(String))
        datatable.Columns.Add("lotacao", GetType(Integer))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewTurmas
            .DataSource = Nothing
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

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "curso"
            .Columns(1).Width = 80
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderText = "serie"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "turno"
            .Columns(3).Width = 80
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).HeaderText = "turma"
            .Columns(4).Width = 150
            .Columns(4).ReadOnly = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(5).HeaderText = "lotacao"
            .Columns(5).Width = 60
            .Columns(5).ReadOnly = True
        End With

        With DataGridViewMaterias
            .DataSource = ""
        End With
    End Sub

    Private Sub btnTurAdc_Click(sender As Object, e As EventArgs) Handles btnTurAdc.Click
        EnableControles(True)

        tCursos.Items.AddRange(New ListasDiversas().Cursos)
        tCursos.Enabled = True
        tCursos.Focus()
    End Sub

    Private Sub DataGridViewTurmas_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewTurmas.SelectionChanged
        Try
            PopulaDGVTurmasMaterias(Val(DataGridViewTurmas.SelectedRows.Item(0).Cells(0).Value))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tumBtnOk_Click(sender As Object, e As EventArgs) Handles tumBtnOk.Click
        '// Grava Turma
        Dim insertSQL As String = "INSERT INTO `turmas`(`curso`, `serie`, `turno`, `turma`, `lotacao`) VALUES (@curso, @serie, @turno, @turma, @lotacao);"
        Dim param As Object()() = {
            ({"@curso", tCursos.SelectedItem.ToString}),
            ({"@serie", tSeries.SelectedItem.ToString}),
            ({"@turno", tTurnos.SelectedItem.ToString}),
            ({"@turma", tTurma.Text.Trim}),
            ({"@lotacao", Val(tLotacao.Text.Trim)})
        }
        dbMain.ExecuteCmd(insertSQL, param)

        EnableControles(False)
        PopulaDGVTurmas()
        DataGridViewTurmas.Focus()
    End Sub

    Private Sub btnTurDel_Click(sender As Object, e As EventArgs) Handles btnTurDel.Click
        If DataGridViewTurmas.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Turma na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            DataGridViewTurmas.Focus()
            Return
        End If

        If MsgBox("Exclui esta Turma?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
        Dim idturma As Integer = DataGridViewTurmas.SelectedRows.Item(0).Cells(0).Value
        Dim deleteSQL As String = "DELETE FROM `turmas` WHERE id = @id;"
        dbMain.ExecuteCmd(deleteSQL, {({"@id", idturma})})

        '// Turmas x Materias
        deleteSQL = "DELETE FROM `turmas_materias` WHERE idturmas = @idturmas;"
        dbMain.ExecuteCmd(deleteSQL, {({"@idturmas", idturma})})

        DataGridViewTurmas.Rows.RemoveAt(DataGridViewTurmas.SelectedRows(0).Index)
        PopulaDGVTurmas()
        DataGridViewTurmas.Focus()
    End Sub

    Private Sub btnMatAdc_Click(sender As Object, e As EventArgs) Handles btnMatAdc.Click
        Dim selecao As MateriasSelecao = New MateriasSelecao
        selecao.ShowDialog()

        Dim idMateria As Integer = selecao.idMateria()

        If idMateria > -1 Then
            Dim idTurma As Integer = DataGridViewTurmas.SelectedRows(0).Cells(0).Value
            Dim ordem As Integer = DataGridViewTurmas.Rows.Count + 1
            Dim materia As String = selecao.nmMateria()
            Dim hrsmes As String = selecao.hsMes()

            Dim insertSQL As String = "INSERT INTO `turmas_materias`(`idturmas`, `idmaterias`, `ordem`, `materia`, `hrsmes`) VALUES (@idturmas, @idmaterias, @ordem, @materia, @hrsmes);"
            Dim param As Object()() = {
                ({"@idturmas", idTurma}),
                ({"@idmaterias", idMateria}),
                ({"@ordem", ordem}),
                ({"@materia", materia}),
                ({"@hrsmes", hrsmes})
            }
            dbMain.ExecuteCmd(insertSQL, param)

            PopulaDGVTurmasMaterias(idTurma)
        End If
    End Sub

    Private Sub btnMatDel_Click(sender As Object, e As EventArgs) Handles btnMatDel.Click
        If DataGridViewMaterias.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Materia na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            DataGridViewMaterias.Focus()
            Return
        End If

        If MsgBox("Exclui esta Materia?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
        Dim deleteSQL As String = "DELETE FROM `turmas_materias` WHERE id = @id;"
        dbMain.ExecuteCmd(deleteSQL, {({"@id", DataGridViewMaterias.SelectedRows.Item(0).Cells(0).Value})})

        DataGridViewMaterias.Rows.RemoveAt(DataGridViewMaterias.SelectedRows(0).Index)
        PopulaDGVTurmasMaterias(DataGridViewTurmas.SelectedRows(0).Cells(0).Value)
    End Sub

    Private Sub btnMatUp_Click(sender As Object, e As EventArgs) Handles btnMatUp.Click
        Try
            Dim totalRows As Integer = DataGridViewMaterias.Rows.Count
            Dim rowIndex As Integer = DataGridViewMaterias.SelectedCells(0).OwningRow.Index
            If rowIndex = 0 Then Return

            Dim selectedRow As Object = DataGridViewMaterias.SelectedRows()

            DataGridViewMaterias.Rows.RemoveAt(rowIndex)
            DataGridViewMaterias.Rows.Insert(rowIndex - 1, {
                                                             selectedRow(0).Cells(0).Value,
                                                             selectedRow(0).Cells(1).Value,
                                                             selectedRow(0).Cells(2).Value,
                                                             selectedRow(0).Cells(3).Value,
                                                             selectedRow(0).Cells(4).Value,
                                                             selectedRow(0).Cells(5).Value
                                                           }
                                             )
            DataGridViewMaterias.Update()

            DataGridViewMaterias.ClearSelection()
            DataGridViewMaterias.Rows(rowIndex - 1).Selected = True
        Catch
        End Try

        AjustaOrdem()
    End Sub

    Private Sub btnMatDown_Click(sender As Object, e As EventArgs) Handles btnMatDown.Click
        Try
            Dim totalRows As Integer = DataGridViewMaterias.Rows.Count
            Dim rowIndex As Integer = DataGridViewMaterias.SelectedCells(0).OwningRow.Index
            If rowIndex = totalRows - 1 Then Return

            Dim selectedRow As Object = DataGridViewMaterias.SelectedRows()

            DataGridViewMaterias.Rows.RemoveAt(rowIndex)
            DataGridViewMaterias.Rows.Insert(rowIndex + 1, {
                                                             selectedRow(0).Cells(0).Value,
                                                             selectedRow(0).Cells(1).Value,
                                                             selectedRow(0).Cells(2).Value,
                                                             selectedRow(0).Cells(3).Value,
                                                             selectedRow(0).Cells(4).Value,
                                                             selectedRow(0).Cells(5).Value
                                                           }
                                             )
            DataGridViewMaterias.Update()

            DataGridViewMaterias.ClearSelection()
            DataGridViewMaterias.Rows(rowIndex + 1).Selected = True
        Catch
        End Try

        AjustaOrdem()
    End Sub

    Private Sub AjustaOrdem()
        '// Acertar Ordem
        Dim ordem As Integer = 1
        For Each item As DataGridViewRow In DataGridViewMaterias.Rows
            Dim updateSQL As String = "UPDATE `turmas_materias` SET `ordem` = @ordem WHERE `id` = @id;"
            Dim param As Object()() = {({"@id", item.Cells(0).Value}), ({"@ordem", ordem})}
            dbMain.ExecuteCmd(updateSQL, param)
            ordem += 1
        Next
    End Sub
End Class