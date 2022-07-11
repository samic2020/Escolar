Imports MySql.Data.MySqlClient

Public Class Abertura
    Private dbMain As [Db] = New Db
    Private idTurma As Integer = -1
    Private idAluno As Integer = -1

    Public WriteOnly Property AlunoId As Integer
        Set(value As Integer)
            idAluno = value
        End Set
    End Property

    Private Sub Abertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnTurAdc.Enabled = False
        btnTurDel.Enabled = False

        tCursos.Items.AddRange(New ListasDiversas().Cursos)
        tCursos.Enabled = True
        tCursos.Focus()

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

        btnTurAdc.Enabled = False
        btnTurDel.Enabled = False

        btnAbrir.Enabled = False
        idTurma = -1
        DataGridViewTurma.DataSource = ""
    End Sub

    Private Sub tCursos_KeyUp(sender As Object, e As KeyEventArgs) Handles tCursos.KeyUp
        If e.KeyCode = Keys.Enter And tCursos.SelectedIndex > -1 Then
            tSeries.Items.AddRange(New ListasDiversas().Series(tCursos.SelectedIndex))
            tSeries.Enabled = True
            tSeries.Focus()
        End If
    End Sub

    Private Sub tCursos_KeyDown(sender As Object, e As KeyEventArgs) Handles tCursos.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tSeries_Enter(sender As Object, e As EventArgs) Handles tSeries.Enter
        tTurnos.Items.Clear()
        tTurnos.Enabled = False

        tTurma.Text = ""
        tTurma.Enabled = False

        tLotacao.Text = "0"
        tLotacao.Enabled = False

        btnTurAdc.Enabled = False
        btnTurDel.Enabled = False

        btnAbrir.Enabled = False
        idTurma = -1
        DataGridViewTurma.DataSource = ""
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

        btnTurAdc.Enabled = False
        btnTurDel.Enabled = False

        btnAbrir.Enabled = False
        idTurma = -1
        DataGridViewTurma.DataSource = ""
    End Sub

    Private Sub tTurnos_KeyDown(sender As Object, e As KeyEventArgs) Handles tTurnos.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tTurnos_KeyUp(sender As Object, e As KeyEventArgs) Handles tTurnos.KeyUp
        If e.KeyCode = Keys.Enter And tTurnos.SelectedIndex > -1 Then
            '// 
            tTurma.Text = ""
            tTurma.Enabled = True

            tLotacao.Text = "0"
            tLotacao.Enabled = True

            btnTurAdc.Enabled = False
            btnTurDel.Enabled = False

            btnAbrir.Enabled = False
            idTurma = -1
            DataGridViewTurma.DataSource = ""

            Dim selectSQL As String = "SELECT `id`, `turma`, `lotacao` FROM `turmas` WHERE curso = @curso AND serie = @serie AND turno = @turno LIMIT 1;"
            Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
            Dim param As Object()() = {
                    ({"@curso", tCursos.SelectedItem.ToString}),
                    ({"@serie", tSeries.SelectedItem.ToString}),
                    ({"@turno", tTurnos.SelectedItem.ToString})
                }
            Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, param)

            Try
                While vrs.Read
                    idTurma = vrs.GetInt32("id")
                    tTurma.Text = vrs.GetString("turma")
                    tLotacao.Text = vrs.GetInt32("lotacao").ToString

                    btnAbrir.Enabled = True
                End While
            Catch ex As Exception
            End Try
            dbMain.CloseAll(conn, vrs)

            tAno.Focus()
        End If
    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        TurmaList()
    End Sub

    Private Sub TurmaList()
        Dim podeLancar As Boolean = False
        If tAno.Value >= Year(New Date()) Then
            podeLancar = True
        End If
        Dim selectSQL As String = "SELECT ta.id as id, ta.idturma as idturma, ta.idaluno as idaluno, al.matricula as matricula, al.nome as aluno, YEAR(CURDATE()) - YEAR(al.dtnasc) as idade FROM `turmas_alunos` ta, `alunos` al WHERE ta.idaluno = al.id AND ta.idturma = @idturma AND ta.ano = @ano;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim param As Object()() = {
                    ({"@idturma", idTurma}),
                    ({"@ano", tAno.Value})
                }
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, param)

        Dim datatable As New DataTable("turma")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("idturma", GetType(Integer))
        datatable.Columns.Add("idaluno", GetType(Integer))
        datatable.Columns.Add("matricula", GetType(String))
        datatable.Columns.Add("aluno", GetType(String))
        datatable.Columns.Add("idade", GetType(Integer))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewTurma
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
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "idturma"
            .Columns(1).Width = 30
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = False

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "idaluno"
            .Columns(2).Width = 30
            .Columns(2).ReadOnly = True
            .Columns(2).Visible = False

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "matricula"
            .Columns(3).Width = 60
            .Columns(3).ReadOnly = True
            .Columns(3).Visible = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(4).HeaderText = "aluno"
            .Columns(4).Width = 400
            .Columns(4).ReadOnly = True
            .Columns(4).Visible = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).HeaderText = "idade"
            .Columns(5).Width = 80
            .Columns(5).ReadOnly = True
            .Columns(5).Visible = True
        End With

        LotAtual.Text = Format(DataGridViewTurma.RowCount, "00")

        VScrollBarTurma.Maximum = DataGridViewTurma.RowCount
        VScrollBarTurma.LargeChange = DataGridViewTurma.DisplayedRowCount(True)
        VScrollBarTurma.SmallChange = 1

        btnTurAdc.Enabled = podeLancar And (Val(LotAtual.Text) < Val(tLotacao.Text))
        btnTurDel.Enabled = DataGridViewTurma.Rows.Count > 0 And (podeLancar And Val(LotAtual.Text) <= Val(tLotacao.Text))
    End Sub

    Private Sub btnTurAdc_Click(sender As Object, e As EventArgs) Handles btnTurAdc.Click
        If Val(LotAtual.Text) >= Val(tLotacao.Text) Then
            MsgBox("A Turma já atingiu sua lotação máxima!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção!")
            Return
        End If

        Dim pesq As Boolean = False
        If idAluno.Equals(-1) Then
            Dim pTela As Pesquisar = New Pesquisar With {.PesquisarPor = Pesquisar.PesquisarEm.Clientes}
            pTela.ShowDialog()
            Dim gCodigo As String = pTela.getCodigo
            If gCodigo IsNot Nothing Then
                idAluno = gCodigo
            End If
            pesq = True
        End If

        If Not PesquisaAlunoGrade(idAluno) Then
            If Not PesquisaAlunoAno(idAluno, tAno.Value) Then
                Dim vrMensal As Decimal = PegaValorMensal(tCursos.SelectedItem.ToString, tSeries.SelectedItem.ToString)
                If vrMensal <= 0D Then
                    MsgBox("Impossivel lançar o aluno!" + vbNewLine + "A tabela com valor da mensalidade esta vazia.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
                    Return
                End If

                Dim insertSQL As String = "INSERT INTO `turmas_alunos` (`idturma`, `idaluno`, `ano`) VALUES (@idturma, @idaluno, @ano);"
                Dim param As Object()() = {
                    ({"@idturma", idTurma}),
                    ({"@idaluno", idAluno}),
                    ({"@ano", tAno.Value})
                }
                If dbMain.ExecuteCmd(insertSQL, param) Then
                    Dim tmp As New Lancamento()
                    tmp.AlunoId = idAluno
                    tmp.TurmaId = idTurma
                    tmp.DataMat = Now
                    tmp.ValorMat = vrMensal
                    tmp.Inicio = Month(Now)
                    tmp.ShowDialog()

                    MsgBox("Inserido com sucesso.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção!")
                    TurmaList()
                End If
            Else
                MsgBox("Aluno já esta lançado em outra turma neste ano letivo!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
            End If
        Else
            MsgBox("Aluno já esta lançado nesta turma este ano letivo!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
        End If

        If pesq Then idAluno = -1
    End Sub

    Private Function PegaValorMensal(curso As String, serie As String) As Decimal
        Dim retorno As Decimal = 0D
        Dim selectSQL = "SELECT `valor` FROM `mensalidade` WHERE `curso` = @curso AND `serie` = @serie LIMIT 1;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, {({"@curso", curso}), ({"@serie", serie})})
        If vrs.HasRows Then
            Try
                vrs.Read()
                retorno = vrs.GetDecimal("valor")
            Catch ex As Exception
                retorno = 0D
            End Try
        End If
        dbMain.CloseAll(conn, vrs)
        Return retorno
    End Function

    Private Sub btnTurDel_Click(sender As Object, e As EventArgs) Handles btnTurDel.Click
        If DataGridViewTurma.Rows.Count <= 0 Then
            MsgBox("Não existe aluno cadastrado ainda!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
            DataGridViewTurma.Focus()
            Return
        End If

        If DataGridViewTurma.SelectedRows.Count <= 0 Then
            MsgBox("Você precisa selecionar um aluno na lista.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
            DataGridViewTurma.Focus()
            Return
        End If

        If MsgBox("Você deseja excluir o registro selecionado?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, "Atenção!") = MsgBoxResult.No Then Return

        Dim id As Integer = DataGridViewTurma.SelectedRows(0).Cells(0).Value
        Dim deleteSQL As String = "DELETE FROM `turmas_alunos` WHERE id = @id;"
        If dbMain.ExecuteCmd(deleteSQL, {({"@id", id})}) Then
            '// Aqui deleta as cobranças futuras de mensalidades
            deleteSQL = "DELETE FROM `financeiro` WHERE idaluno = @idaluno AND (idtipo = 0 OR idtipo = 1) AND aut = 0;"
            dbMain.ExecuteCmd(deleteSQL, {({"@idaluno", idAluno})})

            MsgBox("Aluno excluido da lista.", MsgBoxStyle.OkOnly + MsgBoxStyle.OkOnly, "Atenção!")
            TurmaList()
        End If
        DataGridViewTurma.Focus()
    End Sub

    Private Function PesquisaAlunoAno(AlunoId As Integer, AnoLetivo As Integer) As Boolean
        Dim retorno As Boolean = False
        Dim selectSQL = "SELECT * FROM `turmas_alunos` WHERE `idaluno` = @idaluno AND `ano` = @ano LIMIT 1;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, {({"@idaluno", AlunoId}), ({"@ano", AnoLetivo})})
        retorno = vrs.HasRows
        dbMain.CloseAll(conn, vrs)
        Return retorno
    End Function

    Private Function PesquisaAlunoGrade(AlunoId As Integer) As Boolean
        Dim retorno As Boolean = False
        Dim match As DataGridViewCell()
        match = (From row As DataGridViewRow In Me.DataGridViewTurma.Rows From cell As DataGridViewCell In row.Cells Select cell Where cell.ColumnIndex = 2 And cell.Value.Equals(AlunoId)).ToArray()
        If match.Length > 0 Then
            retorno = True
        End If

        Return retorno
    End Function

    Private Sub tAno_Enter(sender As Object, e As EventArgs) Handles tAno.Enter
        btnTurAdc.Enabled = False
        btnTurDel.Enabled = False

        btnAbrir.Enabled = False
        DataGridViewTurma.DataSource = ""
    End Sub

    Private Sub tAno_KeyDown(sender As Object, e As KeyEventArgs) Handles tAno.KeyDown
        If e.KeyCode = Keys.Enter Then e.SuppressKeyPress = True
    End Sub

    Private Sub tAno_KeyUp(sender As Object, e As KeyEventArgs) Handles tAno.KeyUp
        If e.KeyCode = Keys.Enter And tTurnos.SelectedIndex > -1 Then
            btnTurAdc.Enabled = False
            btnTurDel.Enabled = False

            btnAbrir.Enabled = True
            DataGridViewTurma.DataSource = ""

            btnAbrir.Focus()
        End If
    End Sub
End Class