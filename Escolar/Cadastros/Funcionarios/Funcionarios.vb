Imports System.Collections
Imports MySql.Data.MySqlClient

Public Class Funcionarios
    Private dbMain As [Db] = New Db

    Private vrs As MySqlDataReader

    Private ctrl As Controles
    Private fields As Controles
    Private botoes As Button()
    Private campos As Object()()

    Private bNew As Boolean = False
    Private isIncAlt As Boolean = False
    Private strImagePath As String
    Private imgTemp As Image
    Private _schave As String()

    '// Parâmetros de Acesso da tela Clientes
    Private bIncluir As Boolean = True
    Private bAlterar As Boolean = True
    Private bExcluir As Boolean = True

    Private Sub Funcionarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.Tag IsNot Nothing Then
            Me._schave = Me.Tag.ToString.Split("|")
            If Me._schave.Length > 0 Then
                bIncluir = Me._schave(0).Equals("1")
                bAlterar = Me._schave(1).Equals("1")
                bExcluir = Me._schave(2).Equals("1")
            End If
        End If

        btnTelAdc.DataBindings.Add(New Binding("Enabled", fTels, "Enabled"))
        btnTelDel.DataBindings.Add(New Binding("Enabled", fTels, "Enabled"))
        btnVer.DataBindings.Add(New Binding("Enabled", fTels, "Enabled"))
        botoes = {btnIncluir, btnAlterar, btnExcluir, btnPesquisar, btnGravar, btnSair}
        ctrl = New Controles(botoes)

        campos = {({fFoto, False}), ({fCodigo, True}), ({fNome}), ({fCargo}), ({fCpf, False, Nothing}), ({fRg}), ({fEnd}), ({fNum}), ({fCplto}), ({fBai}),
                  ({fCid}), ({fEst}), ({fCep, False, Nothing}), ({fTels}), ({fEstoque}), ({fPedidos}), ({fAutoriza}), ({fDtEnt, False, Nothing}),
                  ({fUsuario}), ({fSenha}), ({fObs})}
        fields = New Controles(campos)
        fields.FieldsEnabled(False)

        fields.FormataCPF(fCpf, "000\.000\.000\-00", Color.Black)
        fields.FormataMask(fCep, "00000-000", Color.Black)
        fields.FormataData(fDtEnt,, Color.Black)
        fields.Focus()

        FillCargosBox()
        Start()

        fNome.Focus()
    End Sub

    Private Sub Start()
        Dim vSql As String = ""
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        vrs = dbMain.OpenTable(conn, vSql)

        Try
            If vrs.HasRows Then
                ler()
                ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), If(bExcluir, btnExcluir, Nothing), If(bAlterar, btnAlterar, Nothing), btnPesquisar, btnSair})
            Else
                ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), btnSair})
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillCargosBox()
        '// Limpa o combobox
        fCargo.DataSource = Nothing

        Dim datatable As New DataTable("Cargos")
        datatable.Columns.Add("Funcao", GetType(String))

        Dim vSql As String = "SELECT distinct f_funcao AS Funcao FROM cadfun ORDER BY f_funcao;"

        Dim dbMainMySql As [Db] = New Db
        Dim conn As MySqlConnection = dbMainMySql.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMainMySql.OpenTable(conn, vSql)
        datatable.Load(vrs)
        vrs.Close()
        conn.Close()

        fCargo.DataSource = datatable
        fCargo.DisplayMember = "Funcao"
        fCargo.ValueMember = "Funcao"
    End Sub

    Private Sub limpar()
        fFoto.Image = fFoto.ErrorImage
        fFoto.SizeMode = PictureBoxSizeMode.StretchImage

        fCodigo.Text = ""
        fNome.Text = ""
        fCargo.SelectedIndex = -1 : fCargo.Text = ""
        fCpf.Text = ""
        fRg.Text = ""
        fCtps.Text = ""
        fEnd.Text = ""
        fNum.Text = ""
        fCplto.Text = ""
        fBai.Text = ""
        fCid.Text = ""
        fEst.Text = ""
        fCep.Text = ""
        fTels.Items.Clear() : fTels.SelectedIndex = -1 : fTels.Text = ""
        fObs.Text = ""
        fEstoque.Checked = False
        fPedidos.Checked = False
        fAutoriza.Checked = False
        fDtEnt.Text = ""
        fUsuario.Text = ""
        fSenha.Text = ""
    End Sub

    Private Sub ler()
        vrs.Read()

        Try
            Dim bImage As Byte() = vrs("foto")
            Using ms As New IO.MemoryStream(bImage)
                fFoto.Image = New Bitmap(Image.FromStream(ms))
                fFoto.SizeMode = PictureBoxSizeMode.StretchImage
            End Using
        Catch ex As Exception
            fFoto.Image = fFoto.ErrorImage
            fFoto.SizeMode = PictureBoxSizeMode.StretchImage
        End Try

        Try
            fCodigo.Text = vrs("f_cod")
        Catch ex As Exception
            fCodigo.Text = ""
        End Try
        fCodigo.ForeColor = Color.DarkGreen : fCodigo.BackColor = Color.White

        Try
            fNome.Text = vrs("f_nome")
        Catch ex As Exception
            fNome.Text = ""
        End Try

        Try
            Dim tCargo As String = vrs("f_funcao").ToString.Trim.ToUpper
            fCargo.Text = tCargo

            'Dim tpos As Integer = fCargo.FindString(tCargo)
            'If tpos > -1 Then fCargo.SelectedIndex = tpos
        Catch ex As Exception
            fCargo.SelectedIndex = -1 : fCargo.Text = ""
        End Try

        Dim cpfcnpj As String
        Try
            cpfcnpj = RemoveAllSymbols("" & vrs("f_cpf"))
        Catch ex As Exception
            cpfcnpj = ""
        End Try
        If cpfcnpj.Length = 11 Then cpfcnpj = Convert.ToUInt64(cpfcnpj).ToString("000\.000\.000\-00")
        fCpf.Text = cpfcnpj

        Try
            fRg.Text = vrs("f_rg")
        Catch ex As Exception
            fRg.Text = ""
        End Try

        Try
            fCtps.Text = vrs("f_ctps")
        Catch ex As Exception
            fCtps.Text = ""
        End Try

        Try
            fEnd.Text = vrs("f_end")
        Catch ex As Exception
            fEnd.Text = ""
        End Try

        Try
            fNum.Text = vrs("f_num")
        Catch ex As Exception
            fNum.Text = ""
        End Try

        Try
            fCplto.Text = vrs("f_cplto")
        Catch ex As Exception
            fCplto.Text = ""
        End Try

        Try
            fBai.Text = vrs("f_bai")
        Catch ex As Exception
            fBai.Text = ""
        End Try

        Try
            fCid.Text = vrs("f_cid")
        Catch ex As Exception
            fCid.Text = ""
        End Try

        Try
            fEst.Text = vrs("f_est")
        Catch ex As Exception
            fEst.Text = ""
        End Try

        Dim tCep As String
        Try
            tCep = RemoveAllSymbols(vrs("f_cep").ToString)
        Catch ex As Exception
            tCep = "0"
        End Try
        If tCep = "" Then tCep = "0"
        Try
            fCep.Text = Convert.ToUInt64(tCep).ToString("00000\-000")
        Catch ex As Exception
        End Try

        fTels.Items.Clear()
        Dim aTels As String()
        Try
            aTels = vrs("f_tel").ToString.Split(",")
        Catch ex As Exception
            aTels = {}
        End Try
        If aTels.Length > 0 Then
            fTels.Items.AddRange(aTels)
            fTels.SelectedIndex = 0
        Else
            fTels.SelectedIndex = -1
        End If

        fEstoque.Checked = vrs("f_estoque")
        fPedidos.Checked = vrs("f_pedido")
        fAutoriza.Checked = vrs("f_autoriza")

        Try
            fDtEnt.Text = vrs("F_OBS")
        Catch ex As Exception
            fDtEnt.Text = ""
        End Try

        Try
            fObs.Text = vrs("F_OBS")
        Catch ex As Exception
            fObs.Text = ""
        End Try

        Try
            fUsuario.Text = vrs("usuario")
        Catch ex As Exception
            fUsuario.Text = ""
        End Try

        Try
            fSenha.Text = vrs("senha")
        Catch ex As Exception
            fSenha.Text = ""
        End Try
    End Sub

    Private Sub gravar(isNew As Boolean, cCodigo As String)
        Dim Sql As String
        Dim param As Object()() = New Object()() {}

        Dim mstream As New IO.MemoryStream
        If fFoto.Image.GetType.Name.Equals("Bitmap") Then
            fFoto.Image.Save(mstream, Imaging.ImageFormat.Bmp)
        Else
            fFoto.Image.Save(mstream, Imaging.ImageFormat.Jpeg)
        End If
        Dim bytes() As Byte = mstream.ToArray
        mstream.Close()

        ' telefones
        Dim list As New ArrayList
        For Each item As Object In fTels.Items
            list.Add(item.ToString)
        Next
        Dim combined As String = String.Join(",", list.ToArray)

        Dim dtCpras As Date
        If fDtEnt.Text <> "" Then
            Try
                dtCpras = CDate(fDtEnt.Text())
            Catch ex As Exception
                dtCpras = Nothing
            End Try
        Else
            dtCpras = Nothing
        End If


        If isNew Then
            Sql = "INSERT INTO cadfun (f_cod, foto, f_nome, f_funcao, f_cpf, f_rg, f_ctps, f_externo, f_end, f_num, f_cplto, f_bai, f_cid, f_est, f_cep, f_tel, f_entrada, usuario, senha, f_estoque, f_pedido, f_autoriza, f_obs) " &
                  "VALUES (@FCOD, @FOTO, @FNOME, @FFUNCAO, @FCPF, @FRG, @FCTPS, @FEXTERNO, @FEND, @FNUM, @FCPLTO, @FBAI, @FCID, @FEST, @FCEP, @FTEL, @FENTRADA, @USUARIO, @SENHA, @FESTOQUE, @FPEDIDO, @FAUTORIZA, @FOBS)"
            param = New Object()() {
                ({"@FCOD", cCodigo}),
                ({"@FOTO", bytes}),
                ({"@FNOME", fNome.Text()}),
                ({"@FFUNCAO", fCargo.Text}),
                ({"@FCPF", fCpf.Text()}),
                ({"@FRG", fRg.Text()}),
                ({"@FCTPS", fCtps.Text()}),
                ({"@FEND", fEnd.Text()}),
                ({"@FNUM", fNum.Text()}),
                ({"@FCPLTO", fCplto.Text()}),
                ({"@FBAI", fBai.Text()}),
                ({"@FCID", fCid.Text()}),
                ({"@FEST", fEst.Text()}),
                ({"@FCEP", fCep.Text()}),
                ({"@FTEL", combined}),
                ({"@FENTRADA", dtCpras}),
                ({"@USUARIO", fUsuario.Text()}),
                ({"@SENHA", fSenha.Text()}),
                ({"@FESTOQUE", If(fEstoque.Checked, 1, 0)}),
                ({"@FPEDIDO", If(fPedidos.Checked, 1, 0)}),
                ({"@FAUTORIZA", If(fAutoriza.Checked, 1, 0)}),
                ({"@FOBS", fObs.Text.Trim})
            }
        Else
            Sql = "UPDATE cadfun SET f_cod = @FCOD, foto = @FOTO, f_nome = @FNOME, f_funcao = @FFUNCAO, f_cpf = @FCPF, f_rg = @FRG, f_ctps = @FCTPS, f_externo = @FEXTERNO, f_end = @FEND, f_num = @FNUM, f_cplto = @FCPLTO, f_bai = @FBAI, " &
                "f_cid = @FCID, f_est = @FEST, f_cep = @FCEP, f_tel = @FTEL, f_entrada = @FENTRADA, usuario = @USUARIO, senha = @SENHA, " &
                "f_estoque = @FESTOQUE, f_pedido = @FPEDIDO, f_autoriza = @FAUTORIZA, f_obs = @FOBS WHERE f_cod = @FCOD"
            param = New Object()() {
                ({"@FCOD", cCodigo}),
                ({"@FOTO", bytes}),
                ({"@FNOME", fNome.Text()}),
                ({"@FFUNCAO", fCargo.Text}),
                ({"@FCPF", fCpf.Text()}),
                ({"@FRG", fRg.Text()}),
                ({"@FCTPS", fCtps.Text()}),
                ({"@FEND", fEnd.Text()}),
                ({"@FNUM", fNum.Text()}),
                ({"@FCPLTO", fCplto.Text()}),
                ({"@FBAI", fBai.Text()}),
                ({"@FCID", fCid.Text()}),
                ({"@FEST", fEst.Text()}),
                ({"@FCEP", fCep.Text()}),
                ({"@FTEL", combined}),
                ({"@FENTRADA", dtCpras}),
                ({"@USUARIO", fUsuario.Text()}),
                ({"@SENHA", fSenha.Text()}),
                ({"@FESTOQUE", If(fEstoque.Checked, 1, 0)}),
                ({"@FPEDIDO", If(fPedidos.Checked, 1, 0)}),
                ({"@FAUTORIZA", If(fAutoriza.Checked, 1, 0)}),
                ({"@FOBS", fObs.Text.Trim})
            }
        End If
        If Not dbMain.ExecuteCmd(Sql, param) Then
            MsgBox("Não consegui atualiza cadfun. Chame suporte!")
        End If
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        isIncAlt = True
        bNew = True
        limpar()
        fields.FieldsEnabled(True)

        ctrl.BotaoEnabled({btnGravar, btnSair})
        fotoplus.Enabled = True : fotominus.Enabled = True : fotoplus.Visible = True : fotominus.Visible = True

        fNome.Focus()
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        isIncAlt = True
        bNew = False
        fields.FieldsEnabled(True)
        ctrl.BotaoEnabled({btnGravar, btnSair})
        fotoplus.Enabled = True : fotominus.Enabled = True : fotoplus.Visible = True : fotominus.Visible = True
        fNome.Focus()
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        isIncAlt = False
        bNew = False
        fields.FieldsEnabled(False)
        If MsgBox("Exclui este funcionario?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Atenção") = MsgBoxResult.Yes Then
            If ChecaUsuario(fCodigo.Text.Trim) Then
                MsgBox("Este usuário possui clientes!" & vbNewLine & vbNewLine & "Você deve mover os clientes para outro código para poder excluir.")
            Else
                Dim deleteSQL As String = "DELETE FROM cadfun WHERE f_cod = @fcod"
                dbMain.ExecuteCmd(deleteSQL, New Object()() {({"@fcod", fCodigo.Text})})

                vrs.Close()
                Start()
            End If
        End If
        ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), If(bAlterar, btnAlterar, Nothing), If(bExcluir, btnExcluir, Nothing), btnPesquisar, btnSair})
    End Sub

    Private Function ChecaUsuario(user As String) As Boolean
        Dim selectSQL As String = "SELECT cli_vend FROM cadcli WHERE cli_vend = @clivend"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@clivend", user})})
        Dim retorno As Boolean = vrs.HasRows
        dbMain.CloseTable(vrs)
        dbMain.CloseDB(conn)
        Return retorno
    End Function

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        Dim pTela As Pesquisar = New Pesquisar With {.PesquisarPor = Pesquisar.PesquisarEm.Usuarios}
        pTela.ShowDialog()
        Dim gCodigo As String = pTela.getCodigo
        If gCodigo IsNot Nothing Then
            mover(gCodigo)
        End If
    End Sub

    Public Sub mover(codigo As String)
        conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        vrs = dbMain.OpenTable(conn, "SELECT * FROM cadfun WHERE F_COD = '" & codigo & "'")
        If vrs.HasRows Then ler()
        vrs.Close()
        conn.Close()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If fNome.Text = "" Then
            MsgBox("Razão é um campo essencial!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
            fNome.Focus()
            Exit Sub
        End If

        If bNew Then
            fCodigo.Text = Format(Val(dbMain.lergravarPARAM({"CODFUN"}) + 1), "000000")
        End If
        gravar(bNew, fCodigo.Text.Trim)
        If bNew Then dbMain.lergravarPARAM({"CODFUN", fCodigo.Text.Trim, "NUMERICO"}, False)

        '// Auditor
        Auditor.auditor("Funcionarios", If(bNew, "Inclusão", "Alteração"), "Funcionario: " & fCodigo.Text, "Data: " & Now)

        ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), If(bExcluir, btnExcluir, Nothing), If(bAlterar, btnAlterar, Nothing), btnPesquisar, btnSair})
        fields.FieldsEnabled(False)
        fotoplus.Enabled = False : fotominus.Enabled = False : fotoplus.Visible = False : fotominus.Visible = False
        bNew = False : isIncAlt = False
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        If isIncAlt Then
            fields.FieldsEnabled(False)
            fotoplus.Enabled = False : fotominus.Enabled = False : fotoplus.Visible = False : fotominus.Visible = False
            Try
                If vrs.HasRows Then
                    limpar()
                    ler()
                    ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), If(bExcluir, btnExcluir, Nothing), If(bAlterar, btnAlterar, Nothing), btnPesquisar, btnSair})
                Else
                    ctrl.BotaoEnabled({If(bIncluir, btnIncluir, Nothing), btnSair})
                End If
            Catch ex As Exception
            End Try
            bNew = False : isIncAlt = False
        Else
            vrs.Close()
            Dispose()
        End If
    End Sub

    Private Sub btnVer_CheckedChanged(sender As Object, e As EventArgs) Handles btnVer.CheckedChanged
        If btnVer.Checked Then
            fSenha.PasswordChar = "*"
        Else
            frmAutoriza.Visible = True
            autSenha.Text = ""
            autSenha.Focus()
        End If
    End Sub

    Private Sub btnTelAdc_Click(sender As Object, e As EventArgs) Handles btnTelAdc.Click
        Dim tTela As New Telefones
        tTela.ShowDialog()
        If tTela.getTelefone <> Nothing Then
            fTels.Items.Add(tTela.getTelefone)
        End If
    End Sub

    Private Sub btnTelDel_Click(sender As Object, e As EventArgs) Handles btnTelDel.Click
        If fTels.SelectedIndex > -1 Then fTels.Items.RemoveAt(fTels.SelectedIndex)
    End Sub

    Private Sub autSenha_KeyUp(sender As Object, e As KeyEventArgs) Handles autSenha.KeyUp
        If e.KeyCode = Keys.Escape Then
            frmAutoriza.Visible = False
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            If autSenha.Text.Trim.ToUpper.Equals("09082006") Then
                fSenha.PasswordChar = Nothing
                frmAutoriza.Visible = False
                Exit Sub
            Else
                MsgBox("Senha não confere!")
            End If
        End If
    End Sub

    Private Sub autSenha_KeyDown(sender As Object, e As KeyEventArgs) Handles autSenha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub fotoplus_Click(sender As Object, e As EventArgs) Handles fotoplus.Click
        Dim ofdOpen As New OpenFileDialog()
        ofdOpen.InitialDirectory = "c:\\"
        ofdOpen.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png"
        ofdOpen.FilterIndex = 2
        ofdOpen.RestoreDirectory = True

        ofdOpen.ShowDialog(Me)
        strImagePath = ofdOpen.FileName
        imgTemp = Image.FromFile(ofdOpen.FileName)
        fFoto.SizeMode = PictureBoxSizeMode.StretchImage
        fFoto.Image = imgTemp
    End Sub

    Private Sub fotominus_Click(sender As Object, e As EventArgs) Handles fotominus.Click
        fFoto.SizeMode = PictureBoxSizeMode.StretchImage
        fFoto.Image = fFoto.ErrorImage
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub fCep_TextChanged(sender As Object, e As EventArgs) Handles fCep.TextChanged

    End Sub
End Class