Imports MySql.Data.MySqlClient

Public Class CriaEventos
    Private dbMain As [Db] = New Db
    Private match As DataGridViewCell()
    Private pos As Integer
    Private bNew As Boolean = False
    Private bAlt As Boolean = False

    Private Sub CriaEventos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim c As New Controles({})
        c.FormataNumero(eValor, 2)
        c.FormataNumero(eParcelas, 0)

        Dim registros As Integer = ReadEvents()
        eBtnIncluir.Enabled = True
        eBtnAlterar.Enabled = registros > 0
        eBtnExcluir.Enabled = registros > 0
        eBtnGravar.Enabled = False
        eBtnCancelar.Enabled = True

        ClearScreen()

        eBtnClear.Enabled = True
        eBtnPrevious.Enabled = False
        eBtnNext.Enabled = False
        ePesquisa.Text = ""

        Application.DoEvents()
        ePesquisa.Focus()
    End Sub

    Private Sub ClearScreen()
        eId.Text = ""
        eDesc.Text = ""
        eMes.Checked = True
        eAno.Checked = False
        eInicio.ResetText()
        eTermino.ResetText()
        eValor.Text = "0,00"
        eDividido.Checked = False
        eParcelas.Text = "0"
    End Sub

    Private Function ReadEvents() As Integer
        Dim selectSQL As String = "SELECT `id`, `descricao`, `mesano`, `inicio`, `termino`, `valor`, `dividido`, `parcelas` FROM `eventos` ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL)

        Dim datatable As New DataTable("eventos")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("descricao", GetType(String))
        datatable.Columns.Add("mesano", GetType(Boolean))
        datatable.Columns.Add("inicio", GetType(Date))
        datatable.Columns.Add("termino", GetType(Date))
        datatable.Columns.Add("valor", GetType(Decimal))
        datatable.Columns.Add("dividido", GetType(Boolean))
        datatable.Columns.Add("parcelas", GetType(Integer))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewEventos
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
            .ScrollBars = ScrollBars.None

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 30
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = True

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "descricao"
            .Columns(1).Width = 400
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderText = "mesano"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True
            .Columns(2).Visible = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "inicio"
            .Columns(3).Width = 80
            .Columns(3).DefaultCellStyle.Format = "dd-MM-yyyy"
            .Columns(3).ReadOnly = True
            .Columns(3).Visible = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).HeaderText = "termino"
            .Columns(4).Width = 80
            .Columns(4).DefaultCellStyle.Format = "dd-MM-yyyy"
            .Columns(4).ReadOnly = True
            .Columns(4).Visible = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "valor"
            .Columns(5).Width = 80
            .Columns(5).DefaultCellStyle.Format = "#,##0.00"
            .Columns(5).ReadOnly = True
            .Columns(5).Visible = True

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).HeaderText = "dividido"
            .Columns(6).Width = 80
            .Columns(6).ReadOnly = True
            .Columns(6).Visible = True

            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).HeaderText = "parcelas"
            .Columns(7).Width = 80
            .Columns(7).DefaultCellStyle.Format = "##00"
            .Columns(7).ReadOnly = True
            .Columns(7).Visible = True
        End With
        Return DataGridViewEventos.Rows.Count
    End Function

    Private Sub ePesquisa_TextChanged(sender As Object, e As EventArgs) Handles ePesquisa.TextChanged
        If ePesquisa.Text.Length > 0 Then
            match = (From row As DataGridViewRow In Me.DataGridViewEventos.Rows From cell As DataGridViewCell In row.Cells Select cell Where CStr(cell.FormattedValue.ToString.ToUpper).Contains(Me.ePesquisa.Text.ToUpper.Trim)).ToArray()
        Else
            match = {}
        End If

        If match.Length > 0 Then
            pos = 0
            DataGridViewEventos.Rows(match(0).RowIndex).Selected = True
            DataGridViewEventos.FirstDisplayedScrollingRowIndex = match(0).RowIndex
            ePesquisa.ForeColor = Color.Green
            If match.Length = 1 Then
                eBtnNext.Enabled = False
                eBtnPrevious.Enabled = False
            Else
                eBtnNext.Enabled = True
                eBtnPrevious.Enabled = False
            End If
        ElseIf match.Length <= 0 Then
            pos = -1
            ePesquisa.ForeColor = Color.DarkRed
            eBtnNext.Enabled = False
            eBtnPrevious.Enabled = False
        End If
    End Sub

    Private Sub eBtnClear_Click(sender As Object, e As EventArgs) Handles eBtnClear.Click
        ePesquisa.Text = ""
        ePesquisa.Focus()
    End Sub

    Private Sub eBtnPrevious_Click(sender As Object, e As EventArgs) Handles eBtnPrevious.Click
        pos -= 1
        eBtnNext.Enabled = True
        eBtnPrevious.Enabled = True
        If pos <= 0 Then
            pos = 0
            eBtnPrevious.Enabled = False
            eBtnNext.Enabled = True
        End If
        DataGridViewEventos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewEventos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub

    Private Sub eBtnNext_Click(sender As Object, e As EventArgs) Handles eBtnNext.Click
        pos += 1
        eBtnNext.Enabled = True
        eBtnPrevious.Enabled = True
        If pos >= match.Length - 1 Then
            pos = match.Length - 1
            eBtnPrevious.Enabled = True
            eBtnNext.Enabled = False
        End If
        DataGridViewEventos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewEventos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub

    Private Sub eBtnIncluir_Click(sender As Object, e As EventArgs) Handles eBtnIncluir.Click
        bNew = True
        bAlt = False

        DataGridViewEventos.Enabled = False

        eBtnIncluir.Enabled = False
        eBtnAlterar.Enabled = False
        eBtnExcluir.Enabled = False
        eBtnGravar.Enabled = True
        eBtnCancelar.Enabled = True

        ClearScreen()
        eDesc.Focus()
    End Sub

    Private Sub eBtnAlterar_Click(sender As Object, e As EventArgs) Handles eBtnAlterar.Click
        bNew = False
        bAlt = True

        DataGridViewEventos.Enabled = False

        eBtnIncluir.Enabled = False
        eBtnAlterar.Enabled = False
        eBtnExcluir.Enabled = False
        eBtnGravar.Enabled = True
        eBtnCancelar.Enabled = True

        eDesc.Focus()
    End Sub

    Private Sub eBtnExcluir_Click(sender As Object, e As EventArgs) Handles eBtnExcluir.Click
        If MsgBox("Excluir este lançamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return

        '// Excluir do banco de dados eventos
        '// Excluir do financeiro
        MsgBox("Não implantado ainda!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
    End Sub

    Private Sub eBtnGravar_Click(sender As Object, e As EventArgs) Handles eBtnGravar.Click
        Dim stringSQL As String
        Dim param As Object()()
        If bNew Then
            stringSQL = "INSERT INTO `eventos`(`descricao`,`mesano`,`inicio`,`termino`,`valor`,`dividido`,`parcelas`) VALUES " +
                    "(@descricao,@mesano,@inicio,@termino,@valor,@dividido,@parcelas);"
            param = New Object()() {
                    ({"@descricao", eDesc.Text.Trim}),
                    ({"@mesano", If(eMes.Checked, True, False)}),
                    ({"@inicio", If(eMes.Checked, eInicio.Value, DBNull.Value)}),
                    ({"@termino", If(eMes.Checked, eTermino.Value, DBNull.Value)}),
                    ({"@valor", CDec(eValor.Text.Trim)}),
                    ({"dividido", If(eMes.Checked, eDividido.Checked, False)}),
                    ({"@parcelas", If(eMes.Checked, Integer.Parse(eParcelas.Text), 0)})
                }
        Else
            stringSQL = "UPDATE `eventos` SET `descricao` = @descricao, `mesano` = @mesano, `inicio` = @inicio, `termino` = @termino, " +
                    "`valor` = @valor, `dividido` = @dividido, `parcelas` = @parcelas WHERE `id` = @id;"
            param = New Object()() {
                    ({"@descricao", eDesc.Text.Trim}),
                    ({"@mesano", If(eMes.Checked, True, False)}),
                    ({"@inicio", If(eMes.Checked, eInicio.Value, DBNull.Value)}),
                    ({"@termino", If(eMes.Checked, eTermino.Value, DBNull.Value)}),
                    ({"@valor", CDec(eValor.Text.Trim)}),
                    ({"dividido", If(eMes.Checked, eDividido.Checked, False)}),
                    ({"@parcelas", If(eMes.Checked, Integer.Parse(eParcelas.Text), 0)}),
                    ({"@id", Integer.Parse(eId.Text)})
                }
        End If
        If dbMain.ExecuteCmd(stringSQL, param) Then
            MsgBox("Registro Gravado com Sucesso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
        Else
            MsgBox("Problema ao Gravar Registro." + vbNewLine + "Tente Novamente!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
            Return
        End If

        bNew = False
        bAlt = False

        Dim registros As Integer = ReadEvents()
        eBtnIncluir.Enabled = True
        eBtnAlterar.Enabled = registros > 0
        eBtnExcluir.Enabled = registros > 0
        eBtnGravar.Enabled = False
        eBtnCancelar.Enabled = True

        DataGridViewEventos.Enabled = True
    End Sub

    Private Sub eBtnCancelar_Click(sender As Object, e As EventArgs) Handles eBtnCancelar.Click
        If bNew Or bAlt Then
            If MsgBox("Voce perderar os dados lançados. Continua?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
            bNew = False
            bAlt = False

            Dim registros As Integer = ReadEvents()
            eBtnIncluir.Enabled = True
            eBtnAlterar.Enabled = registros > 0
            eBtnExcluir.Enabled = registros > 0
            eBtnGravar.Enabled = False
            eBtnCancelar.Enabled = True

            DataGridViewEventos.Enabled = True
            Return
        End If
        Dispose()
    End Sub

    Private Sub DataGridViewEventos_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewEventos.SelectionChanged
        Dim sel As DataGridViewSelectedRowCollection = DataGridViewEventos.SelectedRows()
        If sel.Count = 0 Then Return
        eId.Text = sel.Item(0).Cells(0).Value
        eDesc.Text = sel.Item(0).Cells(1).Value.ToString
        eMes.Checked = sel.Item(0).Cells(2).Value
        eAno.Checked = Not sel.Item(0).Cells(2).Value
        Try
            eInicio.Value = sel.Item(0).Cells(3).Value
        Catch ex As Exception
        End Try
        Try
            eTermino.Value = sel.Item(0).Cells(4).Value
        Catch ex As Exception
        End Try
        eValor.Text = sel.Item(0).Cells(5).Value
        eDividido.Checked = sel.Item(0).Cells(6).Value
        eParcelas.Text = sel.Item(0).Cells(7).Value
    End Sub

    Private Sub eMes_CheckedChanged(sender As Object, e As EventArgs) Handles eMes.CheckedChanged
        eInicio.Enabled = True
        eTermino.Enabled = True
        eDividido.Enabled = True
        eParcelas.Enabled = True
    End Sub

    Private Sub eAno_CheckedChanged(sender As Object, e As EventArgs) Handles eAno.CheckedChanged
        eInicio.Enabled = False
        eTermino.Enabled = False
        eDividido.Enabled = False
        eParcelas.Enabled = False
    End Sub
End Class