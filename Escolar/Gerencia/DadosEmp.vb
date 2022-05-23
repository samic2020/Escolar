Imports MySql.Data.MySqlClient

Public Class DadosEmp
    Private dbMain As [Db] = New Db
    Private campos As Object()()
    Private fields As Controles
    Private conn As MySqlConnection

    Private Sub DadosEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)

        campos = {({eNome}), ({eCnpj, False, Nothing}), ({eInsc}), ({eEnd}), ({eNro}), ({eCplto}), ({eBai}),
                  ({eCid}), ({eEst}), ({eCep, False, Nothing}), ({eDdd, False, Nothing}), ({eTel, False, Nothing}),
                  ({eFax, False, Nothing}), ({eMsg}), ({eHPage}),
                  ({eLogo}), ({eMarca}), ({eRemessa}),
                  ({eRetorno}), ({eTempo, False, Nothing})}

        fields = New Controles(campos)
        fields.FieldsEnabled(True)
        fields.FormataCPF(eCnpj, "00\.000\.000\/0000\-00", Color.Black)
        fields.FormataMask(eCep, "00000-000", Color.Black)
        fields.FormataNumero(eDdd, 0, Color.Black)
        fields.FormataMask(eTel, "0000\-0000", Color.Black)
        fields.FormataMask(eFax, "0000\-0000", Color.Black)
        fields.Focus()

        ler()

        fields.FieldsEnabled(False)
        btAlterar.Enabled = True
        btnGravar.Enabled = False
        btnSair.Enabled = True

        btnLogo.Enabled = False
        btnMarca.Enabled = False
    End Sub

    Private Sub limpar()
        eNome.Text = ""
        eCnpj.Text = ""
        eInsc.Text = ""
        eEnd.Text = ""
        eNro.Text = ""
        eCplto.Text = ""
        eBai.Text = ""
        eCid.Text = ""
        eEst.Text = ""
        eCep.Text = ""
        eDdd.Text = ""
        eTel.Text = ""
        eFax.Text = ""
        eRemessa.Text = ""
        eRetorno.Text = ""
        eMsg.Text = ""
        eHPage.Text = ""
    End Sub

    Private Sub ler()
        limpar()

        eNome.Text = dbMain.lergravarPARAM({"DA_02"})
        eCnpj.Text = dbMain.lergravarPARAM({"DA_01"})
        eInsc.Text = dbMain.lergravarPARAM({"DA_00"})
        eEnd.Text = dbMain.lergravarPARAM({"DA_03"})

        eNro.Text = dbMain.lergravarPARAM({"DA_3A"})
        eCplto.Text = dbMain.lergravarPARAM({"DA_3B"})

        eBai.Text = dbMain.lergravarPARAM({"DA_04"})
        eCid.Text = dbMain.lergravarPARAM({"DA_05"})
        eEst.Text = dbMain.lergravarPARAM({"DA_06"})
        eCep.Text = dbMain.lergravarPARAM({"DA_07"})
        eDdd.Text = dbMain.lergravarPARAM({"DA_08"})
        eTel.Text = dbMain.lergravarPARAM({"DA_09"})
        eFax.Text = dbMain.lergravarPARAM({"DA_10"})
        eMsg.Text = dbMain.lergravarPARAM({"DA_13"})
        eHPage.Text = dbMain.lergravarPARAM({"DA_14"})
        eLogo.Text = dbMain.lergravarPARAM({"logo"})
        eMarca.Text = dbMain.lergravarPARAM({"marca"})

        eRemessa.Text = dbMain.lergravarPARAM({"remessapath"})
        eRetorno.Text = dbMain.lergravarPARAM({"retornopath"})

        Dim _eTempo As String = Val(dbMain.lergravarPARAM({"etempo"}))
        If _eTempo = Nothing Then _eTempo = "0"
        'eTempo.Text = _eTempo.ToString
    End Sub

    Private Sub gravar()
        dbMain.lergravarPARAM({"DA_00", eInsc.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_01", eCnpj.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_02", eNome.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_03", eEnd.Text.Trim, "TEXTO"}, False)

        dbMain.lergravarPARAM({"DA_3A", eNro.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_3B", eCplto.Text.Trim, "TEXTO"}, False)

        dbMain.lergravarPARAM({"DA_04", eBai.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_05", eCid.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_06", eEst.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_07", eCep.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_08", eDdd.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_09", eTel.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_10", eFax.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_13", eMsg.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"DA_14", eHPage.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"logo", eLogo.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"marca", eMarca.Text.Trim, "TEXTO"}, False)

        dbMain.lergravarPARAM({"remessapath", eRemessa.Text.Trim, "TEXTO"}, False)
        dbMain.lergravarPARAM({"retornopath", eRetorno.Text.Trim, "TEXTO"}, False)

        'dbMain.lergravarPARAM({"etempo", eTempo.Text, "TEXTO"}, False)

        CarregaDadosAdm()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        gravar()

        '// Auditor
        Auditor.auditor("Dados da Empresa", "Alteração", "Dados Alterados", "Data " & Now)

        fields.FieldsEnabled(False)
        btAlterar.Enabled = True
        btnGravar.Enabled = False
        btnSair.Enabled = True

        btnLogo.Enabled = False
        btnMarca.Enabled = False
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        conn.Close()
        Dispose()
    End Sub

    Private Sub DadosEmp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        conn.Close()
    End Sub

    Private Sub CarregaDadosAdm()
        Globais.dadosAdm.Clear()
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_02"}), "Razao")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_01"}), "Cnpj")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_00"}), "Inscricao")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_03"}), "Endereco")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_3A"}), "Numero")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_3B"}), "Complemento")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_04"}), "Bairro")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_05"}), "Cidade")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_06"}), "Estado")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_07"}), "Cep")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_08"}), "Ddd")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_09"}), "Telefone")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_10"}), "Fax")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_11"}), "Sequencia")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_12"}), "Desconto")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_13"}), "Mensagem")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"DA_14"}), "HPage")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"logo"}), "Logo")
        Globais.dadosAdm.Add("" & dbMain.lergravarPARAM({"marca"}), "Marca")

        Dim tmpRemessa As String = "" & dbMain.lergravarPARAM({"remessapath"})
        Dim tmpRetorno As String = "" & dbMain.lergravarPARAM({"retornopath"})

        If tmpRemessa <> "" Then Globais.cxaPath = tmpRemessa

        '// Descanço de tela
        Dim _Tempo As String = dbMain.lergravarPARAM({"etempo"})
        If _Tempo = Nothing Then _Tempo = "0"
        Globais.eTempo = Val(_Tempo) * 60000
    End Sub

    Private Sub btAlterar_Click(sender As Object, e As EventArgs) Handles btAlterar.Click
        fields.FieldsEnabled(True)
        btAlterar.Enabled = False
        btnGravar.Enabled = True
        btnSair.Enabled = True

        btnLogo.Enabled = True
        btnMarca.Enabled = True

        eNome.Focus()
    End Sub

    Private Sub btnLogo_Click(sender As Object, e As EventArgs) Handles btnLogo.Click
        Dim ofdOpen As New OpenFileDialog()
        ofdOpen.InitialDirectory = Globais.appPath
        ofdOpen.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png"
        ofdOpen.FilterIndex = 2
        ofdOpen.RestoreDirectory = True

        ofdOpen.ShowDialog(Me)
        eLogo.Text = ofdOpen.FileName
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim ofdOpen As New OpenFileDialog()
        ofdOpen.InitialDirectory = Globais.appPath
        ofdOpen.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg|png files (*.png)|*.png"
        ofdOpen.FilterIndex = 2
        ofdOpen.RestoreDirectory = True

        ofdOpen.ShowDialog(Me)
        eMarca.Text = ofdOpen.FileName
    End Sub

    Private Sub btnRemessa_Click(sender As Object, e As EventArgs) Handles btnRemessa.Click
        Dim ofdOpen As New FolderBrowserDialog()
        With ofdOpen
            .ShowNewFolderButton = True
            .RootFolder = Environment.SpecialFolder.MyComputer
            .SelectedPath = Globais.appPath
            If .ShowDialog(Me) = DialogResult.OK Then
                eRemessa.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub btnRetorno_Click(sender As Object, e As EventArgs) Handles btnRetorno.Click
        Dim ofdOpen As New FolderBrowserDialog()
        With ofdOpen
            .ShowNewFolderButton = True
            .RootFolder = Environment.SpecialFolder.MyComputer
            .SelectedPath = Globais.appPath
            If .ShowDialog(Me) = DialogResult.OK Then
                eRetorno.Text = .SelectedPath
            End If
        End With
    End Sub
End Class