Imports MySql.Data.MySqlClient

Public Class Cupom
    Private dbMain As [Db] = New Db

    Private Sub Cupom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnGravar.Enabled = False
        '//Dim b As Binding = BtnGravar.DataBindings.Add("Enabled", Me.descValor, "Text", True, DataSourceUpdateMode.OnPropertyChanged)
        '//AddHandler b.Format, Sub(s As Object, args As ConvertEventArgs) args.Value = Not String.IsNullOrEmpty(CStr(args.Value))
    End Sub

    Private Sub BtnPesq_Click(sender As Object, e As EventArgs) Handles BtnPesq.Click
        Dim pTela As Pesquisar = New Pesquisar With {.PesquisarPor = Pesquisar.PesquisarEm.Clientes}
        pTela.ShowDialog()
        Dim gCodigo As String = pTela.getCodigo
        If gCodigo IsNot Nothing Then
            Dim selectSQL As String = "SELECT matricula, nome FROM alunos WHERE id = @ID;"
            Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
            Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, {({"@id", gCodigo})})
            If vrs.HasRows Then
                Try
                    While vrs.Read
                        matAluno.Text = vrs.GetString("matricula")
                        matAluno.Tag = gCodigo
                        nomeAluno.Text = vrs.GetString("nome")

                        GridViewCupons(Integer.Parse(gCodigo))
                    End While
                Catch ex As Exception
                End Try
            End If
            dbMain.CloseAll(conn, vrs)
        End If
    End Sub

    Private Sub GridViewCupons(idAluno As Integer)
        Dim selectSQL As String = "SELECT cp.id id, cp.idcupom idcupom, cp.idaluno idaluno, al.matricula matricula, al.nome nome, cp.valor valor, cp.validade validade, cp.logado logado, cp.lancado lancado " +
            "from cupom cp, alunos al WHERE (al.id = cp.idaluno) AND cp.idaluno = @idaluno AND not cp.usado ORDER BY cp.id;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim param As Object()() = {
                    ({"@idaluno", idAluno})
                }
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, param)

        Dim datatable As New DataTable("turma")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("idcupom", GetType(Integer))
        datatable.Columns.Add("idaluno", GetType(Integer))
        datatable.Columns.Add("matricula", GetType(String))
        datatable.Columns.Add("nome", GetType(String))
        datatable.Columns.Add("valor", GetType(Decimal))
        datatable.Columns.Add("validade", GetType(Date))
        datatable.Columns.Add("logado", GetType(String))
        datatable.Columns.Add("lancado", GetType(Date))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewCupons
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
            .ScrollBars = ScrollBars.Horizontal

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 30
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "idcupom"
            .Columns(1).Width = 30
            .Columns(1).ReadOnly = True
            .Columns(1).Visible = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
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
            .Columns(4).HeaderText = "nome"
            .Columns(4).Width = 230
            .Columns(4).ReadOnly = True
            .Columns(4).Visible = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "valor"
            .Columns(5).Width = 80
            .Columns(5).ReadOnly = True
            .Columns(5).Visible = True

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).HeaderText = "validade"
            .Columns(6).Width = 80
            .Columns(6).ReadOnly = True
            .Columns(6).Visible = True

            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(7).HeaderText = "logado"
            .Columns(7).Width = 80
            .Columns(7).ReadOnly = True
            .Columns(7).Visible = True

            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(8).HeaderText = "lancado"
            .Columns(8).Width = 100
            .Columns(8).DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
            .Columns(8).ReadOnly = True
            .Columns(8).Visible = True
        End With

        VScrollBarCupons.Maximum = DataGridViewCupons.RowCount
        VScrollBarCupons.LargeChange = DataGridViewCupons.DisplayedRowCount(True)
        VScrollBarCupons.SmallChange = 1

    End Sub

    Private Sub descValor_TextChanged(sender As Object, e As EventArgs) Handles descValor.TextChanged
        BtnGravar.Enabled = Val(descValor.Text) > 0 And matAluno.Text.Length > 0 And idCupom.SelectedIndex > -1
    End Sub

    Private Sub BtnGravar_Click(sender As Object, e As EventArgs) Handles BtnGravar.Click
        Dim insertSQL As String = "INSERT INTO `cupom`(`idcupom`,`idaluno`,`valor`,`validade`,`logado`,`lancado`,`usado`) VALUES" +
                                  "(@idcupom,@idaluno,@valor,@validade,@logado,@lancado,@usado);"
        Dim param As Object()() = {
                ({"@idcupom", idCupom.SelectedIndex}),
                ({"@idaluno", Integer.Parse(matAluno.Tag)}),
                ({"@valor", CDec(descValor.Text)}),
                ({"@validade", descValidade.Value}),
                ({"@logado", Globais.usuario}),
                ({"@lancado", Now}),
                ({"@usado", False})
            }

        If Not dbMain.ExecuteCmd(insertSQL, param) Then
            MsgBox("Cupom não gravado!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
            Return
        End If
        '//GridViewCupons(Integer.Parse(matAluno.Tag))

        idCupom.SelectedIndex = -1
        matAluno.Text = ""
        matAluno.Tag = ""
        nomeAluno.Text = ""
        descValor.Text = "0,00"
        descValidade.Value = Now
    End Sub

    Private Sub DataGridViewCupons_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewCupons.KeyDown
        If e.KeyCode = Keys.Delete Then e.SuppressKeyPress = True
    End Sub

    Private Sub DataGridViewCupons_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridViewCupons.KeyUp
        If e.KeyCode = Keys.Delete And DataGridViewCupons.SelectedRows.Count > 0 Then
            If MsgBox("Exclui este cupom?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
            Dim id As Integer = DataGridViewCupons.SelectedRows(0).Cells(0).Value
            Dim deleteSQL As String = "DELETE FROM `cupom` WHERE id = @id;"
            If dbMain.ExecuteCmd(deleteSQL, {({"@id", id})}) Then
                MsgBox("Cupom excluido da lista.", MsgBoxStyle.OkOnly + MsgBoxStyle.OkOnly, "Atenção!")
                GridViewCupons(Integer.Parse(matAluno.Tag))
            End If
            DataGridViewCupons.Focus()
        End If
    End Sub
End Class