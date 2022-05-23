Imports MySql.Data.MySqlClient

Public Class Indicacoes
    Private dbMain As [Db] = New Db

    Private _idAluno As Integer = -1

    WriteOnly Property idAluno As Integer
        Set(ByVal value As Integer)
            _idAluno = value
        End Set
    End Property

    Private Sub Indicacoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnabledInd(False)
        LerIndicacoes(_idAluno)
    End Sub

    Private Sub indIrmao_CheckedChanged(sender As Object, e As EventArgs) Handles indIrmao.CheckedChanged
        eIrmao(indIndPor)
        indBolsista.Checked = False
        indBolsista.Enabled = True
        bolper.Enabled = True
        bolper.Value = 0
    End Sub

    Private Sub indFunc_CheckedChanged(sender As Object, e As EventArgs) Handles indFunc.CheckedChanged
        eFuncionario(indIndPor)
        indBolsista.Checked = False
        indBolsista.Enabled = False
        bolper.Enabled = False
        bolper.Value = 0
    End Sub

    Private Sub indBtnAdc_Click(sender As Object, e As EventArgs) Handles indBtnAdc.Click
        EnabledInd()
        indIrmao.Focus()
    End Sub

    Private Sub indBtnDel_Click(sender As Object, e As EventArgs) Handles indBtnDel.Click
        If indLista.SelectedRows.Count <= 0 Then Return

        Dim canDelete As Boolean = True
        canDelete = (MessageBox.Show("Exclui pendência(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        If canDelete Then
            ' Delete all selected items
            For sel = 0 To indLista.SelectedRows.Count - 1
                If RemoveIndicacao(indLista.SelectedRows.Item(sel).Cells(0).Value) Then
                    '// Auditor
                    Auditor.auditor("Indicações", "Exclusão", "Item: ", indLista.SelectedRows.Item(sel).Cells(2).Value & " - Irmão: " &
                                indLista.SelectedRows.Item(sel).Cells(3).Value & " Func: " &
                                indLista.SelectedRows.Item(sel).Cells(4).Value & " Bols: " &
                                indLista.SelectedRows.Item(sel).Cells(5).Value)
                End If
            Next
            LerIndicacoes(_idAluno)
        End If

    End Sub

    Private Sub indBtnOk_Click(sender As Object, e As EventArgs) Handles indBtnOk.Click
        If indIndPor.Text.Trim = "" Then Return
        If AdicionaIndicacao() Then
            LerIndicacoes(_idAluno)
        End If
        EnabledInd(False)
    End Sub

    Private Sub EnabledInd(Optional value As Boolean = True)
        indIrmao.Enabled = value
        indFunc.Enabled = value
        indBolsista.Enabled = value
        indBolsista.Checked = False
        indBtnOk.Enabled = value
        indLista.Enabled = Not value
        indIndPor.Text = ""
        indIndPor.Enabled = value
        indBtnAdc.Enabled = Not value
        indBtnDel.Enabled = Not value
        bolper.Enabled = value
        bolper.Value = 0
    End Sub

    Private Sub eIrmao(value As TextBox)
        Dim sql As String = "SELECT `nome` FROM `alunos` ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        Dim aluno As New List(Of String)
        If vrs.HasRows Then
            Try
                While vrs.Read
                    aluno.Add(vrs.GetString("nome"))
                End While
            Catch ex As Exception
            End Try
        End If
        dbMain.CloseAll(conn, vrs)

        With value
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim myValue As New AutoCompleteStringCollection
            myValue.AddRange(aluno.ToArray)
            .AutoCompleteCustomSource = myValue
            .Text = ""
        End With

    End Sub

    Private Sub eFuncionario(ByVal value As TextBox)
        Dim sql As String = "SELECT `f_nome` FROM `cadfun` ORDER BY `f_cod`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        Dim aluno As New List(Of String)
        If vrs.HasRows Then
            Try
                While vrs.Read
                    aluno.Add(vrs.GetString("f_nome"))
                End While
            Catch ex As Exception
            End Try
        End If
        dbMain.CloseAll(conn, vrs)

        With value
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim myValue As New AutoCompleteStringCollection
            myValue.AddRange(aluno.ToArray)
            .AutoCompleteCustomSource = myValue
            .Text = ""
        End With

    End Sub

    Private Sub indIndPor_KeyDown(sender As Object, e As KeyEventArgs) Handles indIndPor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub indIndPor_KeyUp(sender As Object, e As KeyEventArgs) Handles indIndPor.KeyUp
        If e.KeyCode = Keys.Enter And indIndPor.Text.Trim <> "" Then
            indBtnOk.Focus()
        End If
    End Sub

    Private Sub LerIndicacoes(id As Integer)
        Dim sql As String = "SELECT * FROM `alunos_indicacoes` WHERE `idaluno` = @idaluno ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@idaluno", id})})
        Dim datatable As New DataTable("Indicados")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("idAluno", GetType(Integer))
        datatable.Columns.Add("indicacao", GetType(String))
        datatable.Columns.Add("irmao", GetType(Boolean))
        datatable.Columns.Add("filhofunc", GetType(Boolean))
        datatable.Columns.Add("bolsista", GetType(Boolean))
        datatable.Columns.Add("percentual", GetType(Integer))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        Indicados(datatable)
    End Sub

    Private Function AdicionaIndicacao() As Boolean
        Dim insertSQL As String = "INSERT INTO `alunos_indicacoes`(`idaluno`,`indicacao`,`irmao`,`filhofunc`,`bolsista`,`percentual`) VALUES (@idaluno, @indicacao, @irmao, @filhofunc, @bolsista, @percentual);"
        Dim param As Object()() = {
            ({"@idaluno", _idAluno}),
            ({"@indicacao", indIndPor.Text.Trim}),
            ({"@irmao", indIrmao.Checked}),
            ({"@filhofunc", indFunc.Checked}),
            ({"@bolsista", indBolsista.Checked}),
            ({"@percentual", bolper.Value})
            }
        Dim retorno As Boolean = dbMain.ExecuteCmd(insertSQL, param)
        If Not retorno Then
            MsgBox("Não foi possível escluir." & vbNewLine & "Contact o suporte do sistema.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Atenção")
        End If
        Return retorno
    End Function

    Private Function RemoveIndicacao(id As Integer) As Boolean
        Dim deleteSQL As String = "DELETE FROM `alunos_indicacoes` WHERE id = @id;"
        Dim retorno As Boolean = dbMain.ExecuteCmd(deleteSQL, {({"@id", id})})
        If Not retorno Then
            MsgBox("Não foi possível escluir." & vbNewLine & "Contact o suporte do sistema.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "Atenção")
        End If
        Return retorno
    End Function

    Private Sub Indicados(table As DataTable)
        With indLista
            .DataSource = ""
            .DataSource = table

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
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 60
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "idAluno"
            .Columns(1).Width = 60
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = False

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "Nome"
            .Columns(2).Width = 300
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "Irmao"
            .Columns(3).Width = 40
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).HeaderText = "Filho Func"
            .Columns(4).Width = 70
            .Columns(4).ReadOnly = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).HeaderText = "Bolsista"
            .Columns(5).Width = 60
            .Columns(5).ReadOnly = True

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).HeaderText = "Percentual"
            .Columns(6).Width = 60
            .Columns(6).ReadOnly = True
        End With
    End Sub

End Class