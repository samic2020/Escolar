Imports System.IO
Imports Canducci.Zip
Imports MySql.Data.MySqlClient

Public Class Alunos
    Private dbMain As [Db] = New Db
    Private aAlergiasListaAdcisOn As Boolean = False
    Private ctrl As Controles
    Private fields As Controles
    Private bNovo As Boolean = False
    Private bSQL As Boolean = False
    Private _schave As String()

    '// Parâmetros de Acesso da tela Clientes
    Private bIncluir As Boolean = True
    Private bAlterar As Boolean = True
    Private bExcluir As Boolean = True

    Private Sub Alunos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Tag IsNot Nothing Then
            _schave = Me.Tag.ToString.Split("|")
            If _schave.Length > 0 Then
                bIncluir = Me._schave(0).Equals("1")
                bAlterar = Me._schave(1).Equals("1")
                bExcluir = Me._schave(2).Equals("1")
            End If
        End If

        aPaiEscolar.Items.AddRange(New ListasDiversas().Escolaridades)
        aMaeEscolar.Items.AddRange(New ListasDiversas().Escolaridades)
        aRH.Items.AddRange(New ListasDiversas().FatorSanguineo)
        aAlergias.Items.AddRange(New ListasDiversas().SimNao)
        aEstado.Items.AddRange(New ListasDiversas().Estados)

        With aCidade
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim myCid As New AutoCompleteStringCollection
            myCid.AddRange(New ListasDiversas().Municipios)
            .AutoCompleteCustomSource = myCid
        End With

        aAlergiasLista.Enabled = aAlergias.SelectedIndex > 0
        aAlergiasListaAdc.Enabled = aAlergias.SelectedIndex > 0
        aAlergiasListaDel.Enabled = aAlergias.SelectedIndex > 0
        aAlergiasListaAdcisOn = aAlergias.SelectedIndex > 0

        Dim acampos As Object()() = New Object()() {
            ({aFoto, False}), ({aNome}), ({aCPF}), ({aRg}), ({aEmail, True}), ({aEndereco}), ({aNumero}), ({aComplemento}),
            ({aBairro}), ({aCidade}), ({aEstado, True}), ({aCep}), ({aDtNasc}), ({aNatural}), ({aTelefones}),
            ({aPaiNome}), ({aPaiEscolar, True}), ({aPaiProfissao}), ({aPaiRg}), ({aPaiCpf}), ({aPaiEmail, True}),
            ({aMaeNome}), ({aMaeEscolar, True}), ({aMaeProfissao}), ({aMaeRg}), ({aMaeCpf}), ({aMaeEmail, True}),
            ({aRH, True}), ({aAlergias, True}), ({aAlergiasLista}), ({aObsLista})}

        fields = New Controles(acampos)
        fields.FormataCPF(aCPF)
        fields.FormataCPF(aPaiCpf)
        fields.FormataCPF(aMaeCpf)
        fields.FormataMask(aCep, "00000\-000")
        fields.FormataData(aDtNasc, "00\/00\/0000")
        fields.FieldsEnabled(False)
        fields.Focus()

        Dim botoes As Button() = {btnIncluir, btnAlterar, btnExcluir, btnPesquisar, btnDemais, btnGravar, btnSair}
        ctrl = New Controles(botoes)

        If Ler() Then
            ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, If(bAlterar, True, False)}), ({btnExcluir, If(bExcluir, True, False)}), ({btnPesquisar, True}), ({btnDemais, True}), ({btnGravar, False}), ({btnSair, True})})
        Else
            ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, False}), ({btnExcluir, False}), ({btnPesquisar, False}), ({btnDemais, False}), ({btnGravar, False}), ({btnSair, True})})
        End If

        CamposEnabled(False)
    End Sub

    Private Sub CamposEnabled(Optional enable As Boolean = False)
        ComboEnabled({aEmail, aEmailAdc, aEmailDel}, Not enable)
        ComboEnabled({aTelefones, aTelefonesAdc, aTelefonesDel}, Not enable)
        ComboEnabled({aPaiEmail, aPaiEmailAdc, aPaiEmailDel}, Not enable)
        ComboEnabled({aMaeEmail, aMaeEmailAdc, aMaeEmailDel}, Not enable)

        aEstado.Enabled = enable
        aPaiEscolar.Enabled = enable
        aMaeEscolar.Enabled = enable
        aRH.Enabled = enable
        aAlergias.Enabled = enable

        aObsLista.Enabled = enable
        aObsListaAdc.Enabled = enable
        aObsListaDel.Enabled = enable
    End Sub

    Private Sub aFotos_Click(sender As Object, e As EventArgs) Handles aFoto.Click
        If btnIncluir.Enabled Or btnAlterar.Enabled Then Return
        Dim ofdOpen As New OpenFileDialog()
        ofdOpen.InitialDirectory = "c:\\"
        ofdOpen.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png"
        ofdOpen.FilterIndex = 2
        ofdOpen.RestoreDirectory = True

        ofdOpen.ShowDialog(Me)
        Dim strImagePath As String = ofdOpen.FileName
        If strImagePath <> "" Then
            Dim imgTemp As Image = Image.FromFile(ofdOpen.FileName)
            aFoto.SizeMode = PictureBoxSizeMode.StretchImage
            aFoto.Image = imgTemp
        End If
    End Sub

    Private Sub aAlergias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles aAlergias.SelectedIndexChanged
        aAlergiasLista.Enabled = aAlergias.SelectedIndex > 0
        aAlergiasListaAdc.Enabled = aAlergias.SelectedIndex > 0
        aAlergiasListaDel.Enabled = aAlergias.SelectedIndex > 0
    End Sub

    Private Sub aAlergiasListaAdc_Click(sender As Object, e As EventArgs) Handles aAlergiasListaAdc.Click
        aAlergiasLista.Items.Add("item")
        aAlergiasListaAdcisOn = True
    End Sub

    Private Sub aAlergiasListaDel_Click(sender As Object, e As EventArgs) Handles aAlergiasListaDel.Click
        aAlergiasLista.DeleteSelectedItems()
        aAlergiasListaAdcisOn = False
    End Sub

    Private Sub aObsListaAdc_Click(sender As Object, e As EventArgs) Handles aObsListaAdc.Click
        aObsLista.Items.Add("item")
    End Sub

    Private Sub aObsListaDel_Click(sender As Object, e As EventArgs) Handles aObsListaDel.Click
        aObsLista.DeleteSelectedItems()
    End Sub

    Private Sub aTelefonesAdc_Click(sender As Object, e As EventArgs) Handles aTelefonesAdc.Click
        Dim tTel As New Telefones
        tTel.ShowDialog()
        Dim tmpTel As Object = tTel.getTelefone
        If tmpTel IsNot Nothing Then
            aTelefones.Items.Add(tmpTel)
            aTelefones.SelectedIndex = 0
        End If
    End Sub

    Private Sub aTelefonesDel_Click(sender As Object, e As EventArgs) Handles aTelefonesDel.Click
        If aTelefones.SelectedIndex <> -1 Then
            aTelefones.Items.RemoveAt(aTelefones.SelectedIndex)
            If aTelefones.Items.Count > 0 Then aTelefones.SelectedIndex = 0
        End If
    End Sub

    Private Sub aEmailAdc_Click(sender As Object, e As EventArgs) Handles aEmailAdc.Click
        Dim tEmail As New EMail
        tEmail.ShowDialog()
        Dim tmpEmail As Object = tEmail.getEmail
        If tmpEmail IsNot Nothing Then
            aEmail.Items.Add(tmpEmail)
            aEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub aEmailDel_Click(sender As Object, e As EventArgs) Handles aEmailDel.Click
        If aEmail.SelectedIndex <> -1 Then
            aEmail.Items.RemoveAt(aEmail.SelectedIndex)
            If aEmail.Items.Count > 0 Then aEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub aPaiEmailAdc_Click(sender As Object, e As EventArgs) Handles aPaiEmailAdc.Click
        Dim tEmail As New EMail
        tEmail.ShowDialog()
        Dim tmpEmail As Object = tEmail.getEmail
        If tmpEmail IsNot Nothing Then
            aPaiEmail.Items.Add(tmpEmail)
            aPaiEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub aPaiEmailDel_Click(sender As Object, e As EventArgs) Handles aPaiEmailDel.Click
        If aPaiEmail.SelectedIndex <> -1 Then
            aPaiEmail.Items.RemoveAt(aPaiEmail.SelectedIndex)
            If aPaiEmail.Items.Count > 0 Then aPaiEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub aMaeEmailAdc_Click(sender As Object, e As EventArgs) Handles aMaeEmailAdc.Click
        Dim tEmail As New EMail
        tEmail.ShowDialog()
        Dim tmpEmail As Object = tEmail.getEmail
        If tmpEmail IsNot Nothing Then
            aMaeEmail.Items.Add(tmpEmail)
            aMaeEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub aMaeEmailDel_Click(sender As Object, e As EventArgs) Handles aMaeEmailDel.Click
        If aMaeEmail.SelectedIndex <> -1 Then
            aMaeEmail.Items.RemoveAt(aMaeEmail.SelectedIndex)
            If aMaeEmail.Items.Count > 0 Then aMaeEmail.SelectedIndex = 0
        End If
    End Sub

    Private Sub LimpaCampos()
        aCodigo.Text = ""
        aMatricula.Text = ""
        aNome.Text = ""
        aCPF.Text = ""
        aRg.Text = ""

        '// Email
        LimpaComboBox(aEmail)

        aEndereco.Text = ""
        aNumero.Text = ""
        aComplemento.Text = ""
        aBairro.Text = ""
        aCidade.Text = ""

        '// Estado
        aEstado.SelectedIndex = -1

        aCep.Text = ""
        aDtNasc.ResetText()
        aNatural.Text = ""

        '// Telefone
        LimpaComboBox(aTelefones)

        aPaiNome.Text = ""

        '// Escolar
        aPaiEscolar.SelectedIndex = -1

        aPaiProfissao.Text = ""
        aPaiRg.Text = ""
        aPaiCpf.Text = ""
        LimpaComboBox(aPaiEmail)

        aMaeNome.Text = ""

        '// Escolar
        aMaeEscolar.SelectedIndex = -1

        aMaeProfissao.Text = ""
        aMaeRg.Text = ""
        aMaeCpf.Text = ""
        LimpaComboBox(aMaeEmail)

        '// RH
        aRH.SelectedIndex = -1

        aAlergias.SelectedIndex = 0
        aAlergiasLista.Items.Clear()

        aObsLista.Items.Clear()

        aPendencias.Text = "Pendências: [00]"
        aInforme.Text = "AAAA - 1º Ano - Manhã - Turma: A"
    End Sub

    Private Function Ler(Optional id As Integer = -1) As Boolean
        Dim sql As String = ""
        If id = -1 Then
            sql = "select * from alunos order by matricula LIMIT 1;"
        Else
            sql = "select * from `alunos` where id = " & id & " order by matricula limit 1;"
        End If
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql)

        If Not vrs.HasRows Then
            dbMain.CloseAll(conn, vrs)
            Return False
        End If

        vrs.Read()

        Try
            Dim bImage As Byte() = vrs("foto")
            Using ms As New IO.MemoryStream(bImage)
                aFoto.Image = New Bitmap(Image.FromStream(ms))
                aFoto.SizeMode = PictureBoxSizeMode.StretchImage
            End Using
        Catch ex As Exception
            aFoto.Image = aFoto.ErrorImage
            aFoto.SizeMode = PictureBoxSizeMode.StretchImage
        End Try

        Try
            aCodigo.Text = Format(Val(vrs("id")), "000000")
        Catch ex As Exception
            aCodigo.Text = "000000"
        End Try

        Try
            aMatricula.Text = Format(Val(vrs("matricula")), "000000")
        Catch ex As Exception
            aMatricula.Text = "000000"
        End Try

        Try
            aNome.Text = "" & vrs("nome").ToString.ToUpper
        Catch ex As Exception
            aNome.Text = ""
        End Try

        Try
            aCPF.Text = vrs("cpf").ToString
        Catch ex As Exception
            aCPF.Text = ""
        End Try

        Try
            aRg.Text = "" & vrs("rg").ToString
        Catch ex As Exception
            aRg.Text = ""
        End Try

        ' email
        aEmail.Items.Clear()
        Dim aEmails As String()
        Try
            aEmails = vrs("emails").ToString.Split(",")
        Catch ex As Exception
            aEmails = {}
        End Try
        If aEmails.Length > 0 Then
            aEmail.Items.AddRange(aEmails)
            aEmail.SelectedIndex = 0
        Else
            aEmail.SelectedIndex = -1
        End If

        Try
            aEndereco.Text = "" & vrs("endereco")
        Catch ex As Exception
            aEndereco.Text = ""
        End Try

        Try
            aNumero.Text = "" & vrs("numero")
        Catch ex As Exception
            aNumero.Text = ""
        End Try

        Try
            aComplemento.Text = "" & vrs("complemento")
        Catch ex As Exception
            aComplemento.Text = ""
        End Try

        Try
            aBairro.Text = "" & vrs("bairro")
        Catch ex As Exception
            aBairro.Text = ""
        End Try

        Try
            aCidade.Text = "" & vrs("cidade")
        Catch ex As Exception
            aCidade.Text = ""
        End Try

        Try
            aEstado.Text = "" & vrs("estado")
        Catch ex As Exception
            aEstado.SelectedIndex = -1
        End Try

        Try
            aCep.Text = "" & vrs("cep")
        Catch ex As Exception
            aCep.Text = ""
        End Try

        Try
            aDtNasc.Text = Format(vrs.GetDateTime("dtnasc"), "dd/MM/yyyy").Replace("/", "")
            Dim ttips As ToolTip = New ToolTip()
            ttips.SetToolTip(aDtNasc, DateDiff(DateInterval.Year, Convert.ToDateTime(aDtNasc.Text), Now) & " ano(s)")
        Catch ex As Exception
            aDtNasc.ResetText()
        End Try

        Try
            aNatural.Text = "" & vrs("natural")
        Catch ex As Exception
            aNatural.Text = ""
        End Try

        ' telefones
        aTelefones.Items.Clear()
        Dim aTels As String()
        Try
            aTels = vrs("telefones").ToString.Split(",")
        Catch ex As Exception
            aTels = {}
        End Try
        If aTels.Length > 0 Then
            aTelefones.Items.AddRange(aTels)
            aTelefones.SelectedIndex = 0
        Else
            aTelefones.SelectedIndex = -1
        End If

        '// Pai
        Try
            aPaiNome.Text = "" & vrs("pai_nome")
        Catch ex As Exception
            aPaiNome.Text = ""
        End Try
        Try
            aPaiEscolar.Text = "" & vrs("pai_escolar")
        Catch ex As Exception
            aPaiEscolar.SelectedIndex = -1
        End Try
        Try
            aPaiProfissao.Text = "" & vrs("pai_profissao")
        Catch ex As Exception
            aPaiProfissao.Text = ""
        End Try
        Try
            aPaiRg.Text = "" & vrs("pai_rg")
        Catch ex As Exception
            aPaiRg.Text = ""
        End Try
        Try
            aPaiCpf.Text = "" & vrs("pai_cpf")
        Catch ex As Exception
            aPaiCpf.Text = ""
        End Try
        aPaiEmail.Items.Clear()
        Dim aPaiEmails As String()
        Try
            aPaiEmails = vrs("pai_email").ToString.Split(",")
        Catch ex As Exception
            aPaiEmails = {}
        End Try
        If aPaiEmails.Length > 0 Then
            aPaiEmail.Items.AddRange(aPaiEmails)
            aPaiEmail.SelectedIndex = 0
        Else
            aPaiEmail.SelectedIndex = -1
        End If

        '// Mae
        Try
            aMaeNome.Text = "" & vrs("mae_nome")
        Catch ex As Exception
            aMaeNome.Text = ""
        End Try
        Try
            aMaeEscolar.Text = "" & vrs("mae_escolar")
        Catch ex As Exception
            aMaeEscolar.SelectedIndex = -1
        End Try
        Try
            aMaeProfissao.Text = "" & vrs("mae_profissao")
        Catch ex As Exception
            aMaeProfissao.Text = ""
        End Try
        Try
            aMaeRg.Text = "" & vrs("mae_rg")
        Catch ex As Exception
            aMaeRg.Text = ""
        End Try
        Try
            aMaeCpf.Text = "" & vrs("mae_cpf")
        Catch ex As Exception
            aMaeCpf.Text = ""
        End Try

        aMaeEmail.Items.Clear()
        Dim aMaeEmails As String()
        Try
            aMaeEmails = vrs("mae_email").ToString.Split(",")
        Catch ex As Exception
            aMaeEmails = {}
        End Try
        If aMaeEmails.Length > 0 Then
            aMaeEmail.Items.AddRange(aMaeEmails)
            aMaeEmail.SelectedIndex = 0
        Else
            aMaeEmail.SelectedIndex = -1
        End If

        '// RH
        Try
            aRH.Text = vrs("rh")
        Catch ex As Exception
            aRH.Text = ""
        End Try

        '// Alergias
        Try
            aAlergias.Text = vrs("alergia")
        Catch ex As Exception
            aAlergias.SelectedIndex = 0
        End Try
        aAlergiasListaAdc.Enabled = aAlergias.SelectedIndex = 1
        aAlergiasListaDel.Enabled = aAlergias.SelectedIndex = 1
        If aAlergias.SelectedIndex = 1 Then
            LerAlergias(vrs("id"))
        Else
            aAlergiasLista.Items.Clear()
        End If

        '// Obs
        LerObs(vrs("id"))
        aObsListaAdc.Enabled = True
        aObsListaDel.Enabled = True

        LerPendencias(vrs("id"))

        dbMain.CloseAll(conn, vrs)

        Return True
    End Function

    Private Sub GravarDados()
        Dim insertSql As String = "INSERT INTO `alunos`(`matricula`,`foto`,`nome`,`cpf`,`rg`,`emails`,`endereco`,`numero`,`complemento`,`bairro`,`cidade`," &
                            "`estado`,`cep`,`dtnasc`,`natural`,`telefones`,`pai_nome`,`pai_escolar`,`pai_profissao`,`pai_rg`,`pai_cpf`,`pai_email`," &
                            "`mae_nome`,`mae_escolar`,`mae_profissao`,`mae_rg`,`mae_cpf`,`mae_email`,`rh`,`alergia`, `dtcadastro`) VALUES " &
                            "(@matricula, @foto, @nome, @cpf, @rg, @emails, @endereco, @numero, @complemento, @bairro, @cidade, @estado, @cep, " &
                            "@dtnasc, @natural, @telefones, @pai_nome, @pai_escolar, @pai_profissao, @pai_rg, @pai_cpf, @pai_email, @mae_nome," &
                            "@mae_escolar, @mae_profissao, @mae_rg, @mae_cpf, @mae_email, @rh, @alergia, @dtcadastro);"


        Dim updateSql As String = "UPDATE `alunos` SET `matricula` = @matricula, `foto` = @foto, `nome` = @nome, `cpf` = @cpf, `rg` = @rg," &
                                     "`emails` = @emails, `endereco` = @endereco, `numero` = @numero, `complemento` = @complemento," &
                                     "`bairro` = @bairro, `cidade` = @cidade, `estado` = @estado, `cep` = @cep, `dtnasc` = @dtnasc," &
                                     "`natural` = @natural, `telefones` = @telefones, `pai_nome` = @pai_nome, `pai_escolar` = @pai_escolar," &
                                     "`pai_profissao` = @pai_profissao, `pai_rg` = @pai_rg, `pai_cpf` = @pai_cpf, `pai_email` = @pai_email," &
                                     "`mae_nome` = @mae_nome, `mae_escolar` = @mae_escolar, `mae_profissao` = @mae_profissao, `mae_rg` = @mae_rg," &
                                     "`mae_cpf` = @mae_cpf, `mae_email` = @mae_email, `rh` = @rh, `alergia` = @alergia WHERE `id` = @id;"

        Dim paramAluno As Object()()
        If bNovo Then
            '// Gerar um numero de matricula novo
            aMatricula.Text = getMatricula()

            paramAluno = New Object()() {
                    ({"@matricula", Trim(Str(aMatricula.Text))}),
                    ({"@foto", getPhoto(aFoto)}),
                    ({"@nome", aNome.Text}),
                    ({"@cpf", getCPF(aCPF.Text)}),
                    ({"@rg", aRg.Text}),
                    ({"@emails", getListas(aEmail)}),
                    ({"@endereco", aEndereco.Text}),
                    ({"@numero", aNumero.Text}),
                    ({"@complemento", aComplemento.Text}),
                    ({"@bairro", aBairro.Text}),
                    ({"@cidade", aCidade.Text}),
                    ({"@estado", aEstado.SelectedItem.ToString}),
                    ({"@cep", getCEP(aCep.Text)}),
                    ({"@dtnasc", Convert.ToDateTime(aDtNasc.Text)}),
                    ({"@natural", aNatural.Text}),
                    ({"@telefones", getListas(aTelefones)}),
                    ({"@pai_nome", aPaiNome.Text}),
                    ({"@pai_escolar", If(aPaiEscolar.SelectedIndex > -1, aPaiEscolar.SelectedItem.ToString, "")}),
                    ({"@pai_profissao", aPaiProfissao.Text}),
                    ({"@pai_rg", aPaiRg.Text}),
                    ({"@pai_cpf", getCPF(aPaiCpf.Text)}),
                    ({"@pai_email", getListas(aPaiEmail)}),
                    ({"@mae_nome", aMaeNome.Text}),
                    ({"@mae_escolar", If(aMaeEscolar.SelectedIndex > -1, aMaeEscolar.SelectedItem.ToString, "")}),
                    ({"@mae_profissao", aMaeProfissao.Text}),
                    ({"@mae_rg", aMaeRg.Text}),
                    ({"@mae_cpf", getCPF(aMaeCpf.Text)}),
                    ({"@mae_email", getListas(aMaeEmail)}),
                    ({"@rh", aRH.SelectedItem.ToString}),
                    ({"@alergia", aAlergias.SelectedItem.ToString}),
                    ({"@dtcadastro", Format(Now, "yyyy-MM-dd")})
                }
            If dbMain.ExecuteCmd(insertSql, paramAluno) Then
                Dim id As Integer = getID(aMatricula.Text)
                aCodigo.Text = Strings.Right("000000" + Trim(Str(id)), 5)
                insertAlergias(id, aAlergiasLista)
                insertObservacoes(id, aObsLista)
                bNovo = False
            Else
                retMatricula(aMatricula.Text)
            End If
        Else
            paramAluno = New Object()() {
                    ({"@matricula", Trim(Str(aMatricula.Text))}),
                    ({"@foto", getPhoto(aFoto)}),
                    ({"@nome", aNome.Text}),
                    ({"@cpf", getCPF(aCPF.Text)}),
                    ({"@rg", aRg.Text}),
                    ({"@emails", getListas(aEmail)}),
                    ({"@endereco", aEndereco.Text}),
                    ({"@numero", aNumero.Text}),
                    ({"@complemento", aComplemento.Text}),
                    ({"@bairro", aBairro.Text}),
                    ({"@cidade", aCidade.Text}),
                    ({"@estado", aEstado.SelectedItem.ToString}),
                    ({"@cep", getCEP(aCep.Text)}),
                    ({"@dtnasc", Convert.ToDateTime(aDtNasc.Text)}),
                    ({"@natural", aNatural.Text}),
                    ({"@telefones", getListas(aTelefones)}),
                    ({"@pai_nome", aPaiNome.Text}),
                    ({"@pai_escolar", If(aPaiEscolar.SelectedIndex > -1, aPaiEscolar.SelectedItem.ToString, "")}),
                    ({"@pai_profissao", aPaiProfissao.Text}),
                    ({"@pai_rg", aPaiRg.Text}),
                    ({"@pai_cpf", getCPF(aPaiCpf.Text)}),
                    ({"@pai_email", getListas(aPaiEmail)}),
                    ({"@mae_nome", aMaeNome.Text}),
                    ({"@mae_escolar", If(aMaeEscolar.SelectedIndex > -1, aMaeEscolar.SelectedItem.ToString, "")}),
                    ({"@mae_profissao", aMaeProfissao.Text}),
                    ({"@mae_rg", aMaeRg.Text}),
                    ({"@mae_cpf", getCPF(aMaeCpf.Text)}),
                    ({"@mae_email", getListas(aMaeEmail)}),
                    ({"@rh", aRH.SelectedItem.ToString}),
                    ({"@alergia", aAlergias.SelectedItem.ToString}),
                    ({"@id", Val(aCodigo.Text)})
                }
            If dbMain.ExecuteCmd(updateSql, paramAluno) Then
                Dim id As Integer = getID(aMatricula.Text)
                insertAlergias(id, aAlergiasLista)
                insertObservacoes(id, aObsLista)
            End If
        End If
    End Sub

    Private Sub insertAlergias(idaluno As Integer, value As EditListBox)
        Dim deleteSQL As String = "DELETE FROM `alunos_alergias` WHERE `idaluno` = @idaluno;"
        dbMain.ExecuteCmd(deleteSQL, {({"@idaluno", idaluno})})
        Dim insertSQL As String = "INSERT INTO `alunos_alergias`(`idaluno`,`alergia`) VALUES (@idaluno, @alergia);"
        For Each item As String In value.Items
            If Not item.ToString.Trim.ToUpper.Equals("ITEM") Then
                dbMain.ExecuteCmd(insertSQL, {({"@idaluno", idaluno}), ({"@alergia", item.ToString})})
            End If
        Next
    End Sub

    Private Sub insertObservacoes(idaluno As Integer, value As EditListBox)
        Dim deleteSQL As String = "DELETE FROM `alunos_observacoes` WHERE `idaluno` = @idaluno;"
        dbMain.ExecuteCmd(deleteSQL, {({"@idaluno", idaluno})})
        Dim insertSQL As String = "INSERT INTO `alunos_observacoes`(`idaluno`,`observacao`) VALUES (@idaluno, @observacao);"
        For Each item As String In value.Items
            If Not item.ToString.Trim.ToUpper.Equals("ITEM") Then
                dbMain.ExecuteCmd(insertSQL, {({"@idaluno", idaluno}), ({"@observacao", item.ToString})})
            End If
        Next
    End Sub

    Private Function getID(value As String) As Integer
        Dim sql As String = "select id from alunos where matricula = @matricula;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@matricula", Trim(Str(Val(value)))})})
        Dim id As Integer = -1
        If vrs.HasRows Then
            vrs.Read()
            id = vrs.GetInt32("id")
        End If
        dbMain.CloseAll(conn, vrs)
        Return id
    End Function

    Private Function getMatricula() As String
        Dim matricula As String = dbMain.lergravarPARAM({"MATRICULA"})
        If matricula Is Nothing Then
            dbMain.lergravarPARAM({"MATRICULA", "001000", "NUMERICO"}, False)
            matricula = "001000"
        End If
        matricula = Strings.Right("000000" + Trim(Str(Val(matricula) + 1)), 6)
        dbMain.lergravarPARAM({"MATRICULA", matricula, "NUMERICO"}, False)
        Return matricula
    End Function

    Private Sub retMatricula(value As String)
        Dim matricula As String = value
        If Val(matricula) > 1000 Then
            matricula = Strings.Left("00000" + Str(Val(matricula) - 1), 5)
        End If
        dbMain.lergravarPARAM({"MATRICULA", matricula, "NUMERICO"}, False)
    End Sub

    Private Function getListas(value As ComboBox) As String
        Dim itens As ArrayList = New ArrayList
        For Each item As Object In value.Items
            itens.Add(item.ToString)
        Next
        Return String.Join(",", itens.ToArray)
    End Function

    Private Function getCEP(cep As String) As String
        Return cep.Replace("-", "")
    End Function

    Public Function getCPF(cpf As String) As String
        Return cpf.Replace(".", "").Replace("-", "")
    End Function

    Private Function getPhoto(photo As PictureBox) As Byte()
        Dim mstream As New MemoryStream
        photo.Image.Save(mstream, Imaging.ImageFormat.Png)
        Dim bytes() As Byte = mstream.ToArray
        mstream.Close()
        Return bytes
    End Function

    Private Sub LerAlergias(id As Integer)
        Dim sql As String = "SELECT alergia FROM alunos_alergias WHERE idaluno = @id"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@id", id})})

        aAlergiasLista.Items.Clear()
        If Not vrs.HasRows Then
            dbMain.CloseAll(conn, vrs)
            Return
        End If

        Try
            While vrs.Read
                aAlergiasLista.Items.Add("" & vrs("alergia"))
            End While
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, vrs)
    End Sub

    Private Sub LerPendencias(id As Integer)
        Dim sql As String = "SELECT Count(`pendencia`) AS pendencias FROM `alunos_pendencias` WHERE `idaluno` = @idaluno ORDER BY `pendencia`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@idaluno", id})})

        Dim totPend As Integer = 0
        If vrs.HasRows Then
            Try
                While vrs.Read
                    totPend = vrs.GetInt32("pendencias")
                End While
            Catch ex As Exception
            End Try
        End If
        dbMain.CloseAll(conn, vrs)

        aPendencias.Text = "Pendências: [" + Format(totPend, "00") + "]"
    End Sub

    Private Sub LerObs(id As Integer)
        Dim sql As String = "SELECT observacao FROM alunos_observacoes WHERE idaluno = @id"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@id", id})})

        aObsLista.Items.Clear()
        If Not vrs.HasRows Then
            dbMain.CloseAll(conn, vrs)
            Return
        End If

        Try
            While vrs.Read
                aObsLista.Items.Add("" & vrs("observacao"))
            End While
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, vrs)
    End Sub

    Private Sub LimpaComboBox(campo As ComboBox)
        campo.Items.Clear()
        campo.SelectedIndex = -1
    End Sub

    Private Sub ComboEnabled(campo As Object(), Optional enable As Boolean = False)
        CType(campo(0), ComboBox).Enabled = True
        CType(campo(1), Button).Enabled = Not enable
        CType(campo(2), Button).Enabled = Not enable
    End Sub

    Private Sub btnIncluir_Click(sender As Object, e As EventArgs) Handles btnIncluir.Click
        bSQL = True
        bNovo = True
        ctrl.BotaoEnableDisable({({btnIncluir, False}), ({btnAlterar, False}), ({btnExcluir, False}), ({btnPesquisar, False}), ({btnDemais, False}), ({btnGravar, True}), ({btnSair, True})})
        LimpaCampos()
        CamposEnabled(True)
        fields.FieldsEnabled(True)
    End Sub

    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        bSQL = True
        bNovo = False
        ctrl.BotaoEnableDisable({({btnIncluir, False}), ({btnAlterar, False}), ({btnExcluir, False}), ({btnPesquisar, False}), ({btnDemais, False}), ({btnGravar, True}), ({btnSair, True})})
        CamposEnabled(True)
        fields.FieldsEnabled(True)
    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click
        If MsgBox("Esta exclusão é permanente e não retorna a Matricula." & vbNewLine & "Tem certeza que deseja proseguir?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return
    End Sub

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        Dim pTela As Pesquisar = New Pesquisar With {.PesquisarPor = Pesquisar.PesquisarEm.Clientes}
        pTela.ShowDialog()
        Dim gCodigo As String = pTela.getCodigo
        If gCodigo IsNot Nothing Then
            mover(gCodigo)
        End If
    End Sub

    Public Sub mover(id As String)
        Ler(Val(id))
    End Sub

    Private Sub btnDemais_Click(sender As Object, e As EventArgs) Handles btnDemais.Click
        demais.Show(btnDemais, New Point(0, btnDemais.Height + 1))
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click

        If aNome.Text.Trim = "" Then
            MsgBox("Campo Nome do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aNome.Focus()
            Return
        End If

        If aEndereco.Text.Trim = "" Then
            MsgBox("Campo Endereço do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aEndereco.Focus()
            Return
        End If

        If aNumero.Text.Trim = "" Then
            MsgBox("Campo Numero do Endereço do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aNumero.Focus()
            Return
        End If

        If aComplemento.Text.Trim = "" Then
            MsgBox("Campo Complemento do Endereço do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aNumero.Focus()
            Return
        End If

        If aBairro.Text.Trim = "" Then
            MsgBox("Campo Bairro do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aBairro.Focus()
            Return
        End If

        If aCidade.Text.Trim = "" Then
            MsgBox("Campo Cidade do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aCidade.Focus()
            Return
        End If

        If aEstado.SelectedIndex = -1 Then
            MsgBox("Campo Estado do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aEstado.Focus()
            Return
        End If

        If aDtNasc.Text.Trim = "" Then
            MsgBox("Campo Data de Nascimento do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aDtNasc.Focus()
            Return
        End If

        If aTelefones.Items.Count <= 0 Then
            MsgBox("Campo Telefone do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aTelefones.Focus()
            Return
        End If

        If aPaiNome.Text.Trim = "" And aMaeNome.Text.Trim = "" Then
            MsgBox("Campo Nome do Pai do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aPaiNome.Focus()
            Return
        End If

        If aMaeNome.Text.Trim = "" And aPaiNome.Text.Trim = "" Then
            MsgBox("Campo Nome do Mãe do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aMaeNome.Focus()
            Return
        End If

        If aPaiCpf.Text.Trim = "" And aMaeCpf.Text.Trim = "" Then
            MsgBox("Campo CPF do Pai do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aPaiCpf.Focus()
            Return
        End If

        If aMaeCpf.Text.Trim = "" And aPaiCpf.Text.Trim = "" Then
            MsgBox("Campo CPF do Mãe do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aMaeCpf.Focus()
            Return
        End If

        If aPaiEmail.Items.Count <= 0 And aMaeEmail.Items.Count <= 0 Then
            MsgBox("Campo Email do Pai do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aPaiEmail.Focus()
            Return
        End If

        If aPaiEmail.Items.Count <= 0 And aMaeEmail.Items.Count <= 0 Then
            MsgBox("Campo Email do Mãe do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aMaeEmail.Focus()
            Return
        End If

        If aRH.SelectedIndex = -1 Then
            MsgBox("Campo RH do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aRH.Focus()
            Return
        End If

        If aAlergias.SelectedIndex = -1 Then
            MsgBox("Campo Alergias do Aluno Obrigatório!", MsgBoxStyle.Critical, "Atenção")
            aAlergias.Focus()
            Return
        End If

        If MsgBox("Grava informações do Aluno", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.No Then Return

        GravarDados()
        bSQL = False

        '// Auditor
        Auditor.auditor("Funcionarios", If(bNovo, "Inclusão", "Alteração"), "Funcionario: " & aCodigo.Text, "Data: " & Now)

        If Ler(Val(aCodigo.Text)) Then
            ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, If(bAlterar, True, False)}), ({btnExcluir, If(bExcluir, True, False)}), ({btnPesquisar, True}), ({btnDemais, True}), ({btnGravar, False}), ({btnSair, True})})
        Else
            ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, False}), ({btnExcluir, False}), ({btnPesquisar, False}), ({btnDemais, False}), ({btnGravar, False}), ({btnSair, True})})
        End If

        fields.FieldsEnabled(False)
        CamposEnabled(False)
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        If bSQL Then
            If MsgBox("Deseja ignonar informações do Aluno", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção") = MsgBoxResult.Yes Then
                bNovo = False
                bSQL = False
                If Ler(Val(aCodigo.Text)) Then
                    ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, If(bAlterar, True, False)}), ({btnExcluir, If(bExcluir, True, False)}), ({btnPesquisar, True}), ({btnDemais, True}), ({btnGravar, False}), ({btnSair, True})})
                Else
                    ctrl.BotaoEnableDisable({({btnIncluir, If(bIncluir, True, False)}), ({btnAlterar, False}), ({btnExcluir, False}), ({btnPesquisar, False}), ({btnDemais, False}), ({btnGravar, False}), ({btnSair, True})})
                End If
                fields.FieldsEnabled(False)
                CamposEnabled(False)
                Return
            End If
        Else
            Dispose()
        End If
    End Sub

    Private Sub aCep_Leave(sender As Object, e As EventArgs) Handles aCep.Leave
        If aEndereco.Text.Trim = "" And aNumero.Text.Trim = "" And aComplemento.Text.Trim = "" And aBairro.Text.Trim = "" And aCidade.Text.Trim = "" And aEstado.SelectedIndex > -1 Then
            Dim cep As New Cep(aCep.Text.Replace("-", ""))
            Dim cepInfo As ZipCodeInfo = cep.getCep
            If cepInfo IsNot Nothing Then
                aEndereco.Text = cepInfo.Address
                aComplemento.Text = ""
                aNumero.Text = ""
                aBairro.Text = cepInfo.District
                aCidade.Text = cepInfo.City
                aEstado.Text = cepInfo.Uf

                If aEndereco.Text.Trim = "" Then
                    aEndereco.Focus()
                Else
                    aNumero.Focus()
                End If
            Else
                MsgBox("Cep inválido ou não encontrado!", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, "Atenção")
                aCep.Focus()
            End If
        End If
    End Sub

    Private Sub btnEnder_Click(sender As Object, e As EventArgs) Handles btnEnder.Click
        Dim endereco As New Enderecos()
        endereco.ShowDialog()
        Dim zip As ZipCodeInfo = endereco.getCep()
        If zip IsNot Nothing Then
            aEndereco.Text = zip.Address
            aComplemento.Text = ""
            aNumero.Text = ""
            aBairro.Text = zip.District
            aCidade.Text = zip.City
            aEstado.Text = zip.Uf
            aCep.Text = zip.Zip

            If aEndereco.Text.Trim = "" Then
                aEndereco.Focus()
            Else
                aNumero.Focus()
            End If
        End If
    End Sub

    Private Sub Pendências00ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Pendências00ToolStripMenuItem.Click
        If btnIncluir.Enabled And btnAlterar.Enabled Then
            Dim pendTela As New Pendencias()
            '//pendTela.idAluno = Val(aCodigo.Text)
            pendTela.ShowDialog()

            LerPendencias(Val(aCodigo.Text))
        End If
    End Sub

    Private Sub IndicaçõesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndicaçõesToolStripMenuItem.Click
        If btnIncluir.Enabled And btnAlterar.Enabled Then
            Dim indTela As New Indicacoes
            indTela.idAluno = Val(aCodigo.Text)
            indTela.ShowDialog()
        End If
    End Sub

    Private Sub PisicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PisicoToolStripMenuItem.Click
        If btnIncluir.Enabled And btnAlterar.Enabled Then
            Dim pscTela As New Pisico
            pscTela.idAluno = Val(aCodigo.Text)
            pscTela.ShowDialog()
        End If
    End Sub

    Private Sub LançarATurmaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LançarATurmaToolStripMenuItem.Click
        '// Exemplo de teste
        'If btnIncluir.Enabled And btnAlterar.Enabled Then
        'Dim pscTela As New Turmas
        'pscTela.ShowDialog()
        'End If

        Dim tmp As New Abertura
        tmp.AlunoId = Integer.Parse(aCodigo.Text)
        tmp.ShowDialog()
    End Sub

    Private Sub FinanceiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinanceiroToolStripMenuItem.Click
        Dim tmp As New CriaEventos()
        tmp.ShowDialog()
    End Sub
End Class