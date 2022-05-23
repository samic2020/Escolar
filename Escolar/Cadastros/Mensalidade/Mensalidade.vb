Imports MySql.Data.MySqlClient

Public Class Mensalidade
    Private dbMain As [Db] = New Db

    Private Sub Mensalidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulaMensalidades()
        EnableDisableVenctos(False)
        EnableDisablePrazos(False)

    End Sub

    Private Sub PopulaMensalidades()
        Dim sql As String = "SELECT id, curso, serie, vencimento, valor FROM `mensalidade` ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)
        Dim datatable As New DataTable("Mensalidades")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("curso", GetType(String))
        datatable.Columns.Add("serie", GetType(String))
        datatable.Columns.Add("vencimento", GetType(Integer))
        datatable.Columns.Add("valor", GetType(Decimal))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With Mensalidades
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
            .Columns(1).HeaderText = "curso"
            .Columns(1).Width = 100
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "serie"
            .Columns(2).Width = 100
            .Columns(2).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "vencimento"
            .Columns(2).Width = 30
            .Columns(2).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "valor"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True
        End With

        VScrollBarMensal.Maximum = Mensalidades.RowCount
        VScrollBarMensal.LargeChange = Mensalidades.DisplayedRowCount(True)
        VScrollBarMensal.SmallChange = 1

    End Sub

    Private Sub PopulaMensalidadesPrazos(idmensal As Integer)
        Dim sql As String = "SELECT id, dias, percentual, valor FROM `mensalidade_prazos` WHERE idmensalidade = @idmensalidade ORDER BY `id`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim param()() As Object = {({"@idmensalidade", idmensal})}
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, param)
        Dim datatable As New DataTable("Mensalidades_prazos")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("dias", GetType(Integer))
        datatable.Columns.Add("percentual", GetType(Decimal))
        datatable.Columns.Add("valor", GetType(Decimal))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With Prazos
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
            .Columns(1).HeaderText = "dias"
            .Columns(1).Width = 10
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "percentual"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(3).HeaderText = "valor"
            .Columns(3).Width = 80
            .Columns(3).ReadOnly = True
        End With

        VScrollBarMensalPrazos.Maximum = Prazos.RowCount
        VScrollBarMensalPrazos.LargeChange = Prazos.DisplayedRowCount(True)
        VScrollBarMensalPrazos.SmallChange = 1

    End Sub

    Private Sub EnableDisableVenctos(value As Boolean)
        With mCursos
            .Text = ""
            .SelectedIndex = -1
            .Enabled = value
        End With

        With mSeries
            .Text = ""
            .SelectedIndex = -1
            .Enabled = value
        End With

        With mVencto
            .Value = 0
            .Enabled = value
        End With

        With mValor
            .Text = "0"
            .Enabled = value
        End With

        With btnMenOk
            .Enabled = value
        End With

        With Mensalidades
            .Enabled = Not value
        End With

        With mMenAdc
            .Enabled = Not value
        End With

        With mMenDel
            .Enabled = Not value
        End With
    End Sub

    Private Sub EnableDisablePrazos(value As Boolean)
        With pDias
            .Value = 0
            .Enabled = value
        End With

        With pPerc
            .Value = 0
            .Enabled = value
        End With

        With pValor
            .Text = 0
            .Enabled = value
        End With

        With btnPrazOk
            .Enabled = value
        End With

        With Prazos
            .Enabled = Not value
        End With

        With pPrazAdc
            .Enabled = Not value
        End With

        With pPrazDel
            .Enabled = Not value
        End With
    End Sub

    Private Sub Mensalidades_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles Mensalidades.RowStateChanged
        If Mensalidades.SelectedRows.Count <= 0 Then
            'MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            Mensalidades.Focus()
            Return
        End If

        Dim idmensal As Integer = Mensalidades.SelectedRows.Item(0).Cells(0).Value

        PopulaMensalidadesPrazos(idmensal)
    End Sub

    Private Sub mMenAdc_Click(sender As Object, e As EventArgs) Handles mMenAdc.Click
        EnableDisableVenctos(True)
        mCursos.Items.AddRange(New ListasDiversas().Cursos())
    End Sub

    Private Sub btnMenOk_Click(sender As Object, e As EventArgs) Handles btnMenOk.Click
        '// Gravar dados
        Dim updateSQL As String = "INSERT INTO `mensalidade` (curso, serie, vencimento, valor) VALUE (@curso, @serie, @vencimento, @valor);"
        Dim param As Object()() = New Object()() {
            ({"@curso", mCursos.SelectedItem.ToString}),
            ({"@serie", mSeries.SelectedItem.ToString}),
            ({"@vencimento", mVencto.Value}),
            ({"@valor", CDec(mValor.Text)})
        }
        dbMain.ExecuteCmd(updateSQL, param)

        '// Reload Grid
        PopulaMensalidades()

        EnableDisableVenctos(False)
    End Sub

    Private Sub mSeries_Enter(sender As Object, e As EventArgs) Handles mSeries.Enter
        mSeries.Items.Clear()
        If mCursos.SelectedIndex > -1 Then mSeries.Items.AddRange(New ListasDiversas().Series(mCursos.SelectedIndex))
    End Sub

    Private Sub mMenDel_Click(sender As Object, e As EventArgs) Handles mMenDel.Click
        If MsgBox("Deseja excluir este lançamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção!") = MsgBoxResult.No Then Return

        If Mensalidades.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            Mensalidades.Focus()
            Return
        End If

        Dim deleteSQL As String = "DELETE FROM `mensalidade` WHERE id = @id"
        If dbMain.ExecuteCmd(deleteSQL, New Object()() {({"@id", Mensalidades.SelectedRows.Item(0).Cells(0).Value})}) Then
            deleteSQL = "DELETE FROM `mensalidade_prazos` WHERE idmensalidade = @idmensalidade;"
            dbMain.ExecuteCmd(deleteSQL, New Object()() {({"@idmensalidade", Mensalidades.SelectedRows.Item(0).Cells(0).Value})})
        End If

        '// Reload Grid
        PopulaMensalidades()
    End Sub

    Private Sub pPrazAdc_Click(sender As Object, e As EventArgs) Handles pPrazAdc.Click
        If Mensalidades.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            Mensalidades.Focus()
            Return
        End If

        EnableDisablePrazos(True)

    End Sub

    Private Sub pPrazDel_Click(sender As Object, e As EventArgs) Handles pPrazDel.Click
        If MsgBox("Deseja excluir este lançamento?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção!") = MsgBoxResult.No Then Return

        If Mensalidades.SelectedRows.Count <= 0 Then
            MsgBox("Você deve selecionar uma Matéria na lista.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            Mensalidades.Focus()
            Return
        End If

        Dim deleteSQL As String = "DELETE FROM `mensalidade_prazos` WHERE id = @id;"
        dbMain.ExecuteCmd(deleteSQL, New Object()() {({"@id", Prazos.SelectedRows.Item(0).Cells(0).Value})})

        Dim idmensal As Integer = Mensalidades.SelectedRows.Item(0).Cells(0).Value
        PopulaMensalidadesPrazos(idmensal)
    End Sub

    Private Sub btnPrazOk_Click(sender As Object, e As EventArgs) Handles btnPrazOk.Click
        Dim idmensal As Integer = Mensalidades.SelectedRows.Item(0).Cells(0).Value

        '// Gravar dados
        Dim updateSQL As String = "INSERT INTO `mensalidade_prazos` (idmensalidade, dias, percentual, valor) VALUE (@idmensalidade, @dias, @percentual, @valor);"
        Dim param As Object()() = New Object()() {
            ({"@idmensalidade", idmensal}),
            ({"@dias", pDias.Value}),
            ({"@percentual", pPerc.Value}),
            ({"@valor", CDec(pValor.Text)})
        }
        dbMain.ExecuteCmd(updateSQL, param)

        '// Reload Grid
        PopulaMensalidadesPrazos(idmensal)

        EnableDisablePrazos(False)
    End Sub
End Class