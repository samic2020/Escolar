Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports System.IO

Public Class Principal
    Private dbMain As [Db] = New Db
    Private conn As MySqlConnection
    Private tblMenu As MySqlDataReader

    Private _MousePosition As Point
    Private _intervalo As Integer = 0

    Private Sub BarraNotificacoes()
        Dim Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim Version = Assembly.GetName().Version.ToString()

        BaseDados.Text = Globais.databaseName
        mLocal.Text = Globais.unidade
        UserName.Text = Globais.usuario

        Try
            Dim tLogo As Image = Image.FromFile(Globais.dadosAdm.Item("Logo"))
            mLogo.Image = New Bitmap(tLogo)
            tLogo.Dispose()
        Catch ex As Exception
            mLogo.Image = Nothing
        End Try

        SoftVersion.Text = Version
        SoftData.Text = Format(Now, "dd 'de' MMMM 'de' yyyy")

        SoftHora.Text = Format(Now, "HH")
        SoftMinutos.Text = Format(Now, "mm")
        SoftSegundos.Text = Format(Now, "ss")
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Feche todos os formulários filhos do pai.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub Principal_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MsgBox("Sr(a). Usuário(a) já realizou o Back-Up diário de seu arquivos!!!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!!!")
        Login.ShowLogin()
    End Sub

    Private Sub MontaMenu()

        'barraMenu.BackColor = Color.DarkBlue
        If Not Globais.usuario = "MASTER" And Not Globais.funcao = "MASTER" Then
            SetarMenu()
        End If

        Dim mnuBackUpRestore As New ToolStripMenuItem("Base de Dados")
        If Globais.usuario = "MASTER" And Globais.funcao = "MASTER" And Globais.codfun = "MASTER" Then
            '// Funcionarios
            Dim itemFuncionarios As New ToolStripMenuItem("&Funcionários")
            'itemFuncionarios.Image = ImageListMenu.Images.Item("backup")
            'itemFuncionarios.ToolTipText = "Cópia de segurança do Sistema..."
            AddHandler itemFuncionarios.Click, Sub()
                                                   Dim tFunc As New Funcionarios
                                                   tFunc.MdiParent = Me
                                                   tFunc.Show()
                                               End Sub
            mnuBackUpRestore.DropDownItems.Add(itemFuncionarios)

            '// Acessos
            Dim itemAcessos As New ToolStripMenuItem("&Acessos")
            'itemFuncionarios.Image = ImageListMenu.Images.Item("backup")
            'itemFuncionarios.ToolTipText = "Cópia de segurança do Sistema..."
            AddHandler itemAcessos.Click, Sub()
                                              Dim tFuncAcessos As New Acesso
                                              tFuncAcessos.MdiParent = Me
                                              tFuncAcessos.Show()
                                          End Sub
            mnuBackUpRestore.DropDownItems.Add(itemAcessos)

            '// Backup do Sistema
            Dim itemBackup As New ToolStripMenuItem("&BackUp do Banco de Dados")
            itemBackup.Image = ImageListMenu.Images.Item("backup")
            itemBackup.ToolTipText = "Cópia de segurança do Sistema..."
            AddHandler itemBackup.Click, Sub()
                                             Dim tBck As New BackUp
                                             tBck.MdiParent = Me
                                             tBck.Show()
                                         End Sub
            mnuBackUpRestore.DropDownItems.Add(itemBackup)

            '// Restore do Sistema
            Dim itemRestore As New ToolStripMenuItem("&Restore do Banco de Dados")
            itemRestore.Image = ImageListMenu.Images.Item("restore")
            itemRestore.ToolTipText = "Restauração da Banco de Dados do Sistema..."
            AddHandler itemRestore.Click, Sub()
                                              Dim tBck As New Restore
                                              tBck.MdiParent = Me
                                              tBck.Show()
                                          End Sub
            mnuBackUpRestore.DropDownItems.Add(itemRestore)

            '// Acessos
            Dim itemIpConfig As New ToolStripMenuItem("&IpConfig")
            'itemFuncionarios.Image = ImageListMenu.Images.Item("backup")
            'itemFuncionarios.ToolTipText = "Cópia de segurança do Sistema..."
            AddHandler itemIpConfig.Click, Sub()
                                               Dim tConfig As New Config
                                               tConfig.MdiParent = Me
                                               tConfig.Show()
                                           End Sub
            mnuBackUpRestore.DropDownItems.Add(itemIpConfig)
        Else
            '// Backup do Sistema
            Dim itemBackup As New ToolStripMenuItem("&BackUp do Banco de Dados")
            itemBackup.Image = ImageListMenu.Images.Item("backup")
            itemBackup.ToolTipText = "Cópia de segurança do Sistema..."
            AddHandler itemBackup.Click, Sub()
                                             Dim tBck As New BackUp
                                             tBck.MdiParent = Me
                                             tBck.Show()
                                         End Sub
            mnuBackUpRestore.DropDownItems.Add(itemBackup)
        End If
        barraMenu.Items.Add(mnuBackUpRestore)

        '// Saida do Sistema
        Dim mnuSair As New ToolStripMenuItem("&Sair")

        If Not Globais.usuario = "MASTER" And Not Globais.funcao = "MASTER" And Not Globais.codfun = "MASTER" Then
            '// LogOut
            Dim itemLogOut As New ToolStripMenuItem("&LogOut")
            itemLogOut.Image = ImageListMenu.Images.Item("menu-logout.png")
            itemLogOut.ToolTipText = "LogOut do Sistema..."
            AddHandler itemLogOut.Click, Sub()
                                             For i = Application.OpenForms.Count - 1 To 1 Step -1
                                                 Dim form As Form = Application.OpenForms(i)
                                                 form.Close()
                                             Next i
                                             Me.Close()
                                         End Sub
            mnuSair.DropDownItems.Add(itemLogOut)
        End If

        '// Terminar
        Dim itemTerminar As New ToolStripMenuItem("&Encerrar o Sistema")
        itemTerminar.Image = ImageListMenu.Images.Item("menu-exit.png")
        itemTerminar.ToolTipText = "Sair completamente do sistema..."
        AddHandler itemTerminar.Click, Sub()
                                           Me.Dispose()
                                           End
                                       End Sub
        mnuSair.DropDownItems.Add(itemTerminar)

        barraMenu.Items.Add(mnuSair)
        barraMenu.Visible = True
    End Sub

    Private Function Setar(_nodes As String(), _chave As String) As Boolean
        If Globais.protocolomenu.Equals("") Then Return True
        For z As Integer = 0 To _nodes.Length - 1
            Dim pos As Integer = Funcoes.OcourCount(_nodes(z), ":", 2)
            Dim _node As String = _nodes(z).Substring(0, pos)
            Dim _setar As Boolean = _chave.Trim.Equals(_node.Trim())
            If _setar Then
                Dim _acesso As String() = _nodes(z).Split(":")
                If InStr(_acesso(2), "|") > 0 Then
                    _acesso(2) = _acesso(2).Substring(0, InStr(_acesso(2), "|") - 1)
                End If

                If _acesso(2).Equals("1") Then Return True
            End If
        Next
        Return False
    End Function

    <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)>
    Private Sub SetarMenu()
        If Globais.protocolomenu.Trim = "" Then Return

        Dim protocolomenu As String = Globais.protocolomenu

        conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)

        Dim _tree As String = protocolomenu.Replace(";", ",")
        Dim _nodes As String() = _tree.Split(",")

        Dim mnu As MySqlDataReader = dbMain.OpenTable(conn, "SELECT * FROM menu ORDER BY tipo, cod;")
        Try
            Dim menuItem As ToolStripMenuItem
            Dim item As ToolStripMenuItem

            If mnu.HasRows Then
                While mnu.Read
                    Dim cod As Integer = mnu.Item("cod")
                    Dim tip As Integer = mnu.Item("tipo")
                    Dim nome As String = mnu.Item("nome")
                    Dim rotina As String = mnu.Item("rotina")
                    Dim icone As String = mnu.Item("icone")
                    Dim _senha As Integer = mnu.Item("senha")
                    Dim parent As Boolean = mnu.Item("parente")
                    Dim _chave As String = tip & ":" & cod
                    Dim _schave As String = Funcoes.FuncoesAuxiliares(_nodes, _chave)

                    'If _chave = "1:7" Then Stop

                    If cod = 0 Then
                        '// Cria o menu
                        menuItem = New ToolStripMenuItem(nome)
                        menuItem.Visible = Setar(_nodes, _chave)
                        menuItem.Tag = _schave

                        If rotina.Trim <> "" Then
                            AddHandler menuItem.Click, Sub()
                                                           If _senha Then
                                                               Dim tSenha As sgSenha = New sgSenha
                                                               tSenha.ShowDialog()
                                                               If tSenha.getPodeAbrir = 0 Then
                                                                   MsgBox("Usuário sem permissão!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton1, "Atenção!")
                                                                   Exit Sub
                                                               End If
                                                           End If

                                                           If VerificaFormRun(rotina) Then
                                                               Exit Sub
                                                           End If
                                                           Dim inst As Object = MethodBase.GetCurrentMethod().ReflectedType.Namespace & "." & rotina
                                                           Dim asyb As Assembly = Assembly.GetExecutingAssembly()
                                                           Dim frm As Object = asyb.CreateInstance(inst.ToString)
                                                           Dim tela As Form = DirectCast(frm, Form)
                                                           'If frm <> Nothing Then
                                                           Try
                                                               If parent Then tela.MdiParent = Me
                                                               If _schave <> "" Then
                                                                   tela.Tag = _schave
                                                               End If
                                                               If rotina.ToUpper.Trim = "CONFERENCIA" Then
                                                                   Timer1.Enabled = False
                                                                   Timer1.Stop()
                                                               End If
                                                               tela.Show()
                                                               tela.BringToFront()

                                                               'DirectCast(frm, Form).Show()
                                                           Catch ex As Exception
                                                               MsgBox("Não Implementado ainda!")
                                                           End Try
                                                       End Sub
                            barraMenu.Items.Add(menuItem)
                        End If
                    Else
                        '// Adiciona o item ao menu
                        barraMenu.Items.Add(menuItem)

                        If nome.Trim <> "-" Then
                            '// Aqui vão os itens
                            item = New ToolStripMenuItem
                            ' Setar Icone
                            item.ImageAlign = ContentAlignment.MiddleLeft
                            If icone.Trim <> "" Then item.Image = ImageListMenu.Images.Item(icone)

                            item.Text = nome
                            item.Tag = _schave
                            ' Setar ToolTip
                            'item.ToolTipText =

                            AddHandler item.Click, Sub()
                                                       If _senha Then
                                                           Dim tSenha As sgSenha = New sgSenha
                                                           tSenha.ShowDialog()
                                                           If tSenha.getPodeAbrir = 0 Then
                                                               MsgBox("Usuário sem permissão!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton1, "Atenção!")
                                                               Exit Sub
                                                           End If
                                                       End If

                                                       If VerificaFormRun(rotina) Then
                                                           Exit Sub
                                                       End If
                                                       Dim inst As Object = MethodBase.GetCurrentMethod().ReflectedType.Namespace & "." & rotina
                                                       Dim asyb As Assembly = Assembly.GetExecutingAssembly()
                                                       Dim frm As Object = Nothing
                                                       Try
                                                           frm = asyb.CreateInstance(inst.ToString)
                                                       Catch ex As Exception
                                                           MsgBox(ex.Message)
                                                           Return
                                                       End Try
                                                       Dim tela As Form = DirectCast(frm, Form)

                                                       'If frm <> Nothing Then
                                                       Try
                                                           If parent Then tela.MdiParent = Me
                                                           If _schave <> "" Then
                                                               tela.Tag = _schave
                                                           End If
                                                           If rotina.ToUpper.Trim = "CONFERENCIA" Then
                                                               Timer1.Enabled = False
                                                               Timer1.Stop()
                                                           End If
                                                           tela.Show()
                                                           tela.BringToFront()

                                                           'DirectCast(frm, Form).Show()
                                                       Catch ex As Exception
                                                           MsgBox("Não Implementado ainda!")
                                                       End Try
                                                       'Else
                                                       'MsgBox("Não Implementado ainda!")
                                                       'End If
                                                       'Boolean pode = True;
                                                       'If (_senha > 0) Then {
                                                       '   jAutoriza oAut = New jAutoriza(null, True);
                                                       '   oAut.setVisible(True);
                                                       '   pode = oAut.pode;
                                                       '}

                                                       'If (pode) Then {
                                                       '   classe = Class.forName(rotina);  
                                                       '   JInternalFrame frame = (JInternalFrame) classe.newInstance();  
                                                       '   jDesktopPane1.add(frame);
                                                       '   CentralizaTela.setCentro(frame, jDesktopPane1, 0, 0);

                                                       '   jDesktopPane1.getDesktopManager().activateFrame(frame);
                                                       '   frame.requestFocus();
                                                       '   frame.setSelected(True);
                                                       '   frame.setVisible(True);  
                                                       '}
                                                   End Sub
                            item.Visible = Setar(_nodes, _chave)
                            menuItem.DropDownItems.Add(item)
                        Else
                            menuItem.DropDownItems.Add(New ToolStripSeparator())
                        End If
                    End If
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        mnu.Close()
        conn.Close()
    End Sub

    Private Function VerificaFormRun(runForm As String) As Boolean
        Dim retorno As Boolean = False
        Try
            For Each child In MdiChildren
                If child.Name.ToUpper.Trim = runForm.ToUpper.Trim Then
                    child.BringToFront()
                    retorno = True
                    Exit For
                End If
            Next
        Catch ex As Exception
        End Try
        Return retorno
    End Function

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim TitleAttribute = TryCast(Assembly.GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False).FirstOrDefault(), System.Reflection.AssemblyTitleAttribute)
        Dim DescrAttribute = TryCast(Assembly.GetCustomAttributes(GetType(System.Reflection.AssemblyDescriptionAttribute), False).FirstOrDefault(), System.Reflection.AssemblyDescriptionAttribute)
        Dim Title = If(TitleAttribute IsNot Nothing, TitleAttribute.Title, String.Empty)
        Dim Descricao = If(DescrAttribute IsNot Nothing, DescrAttribute.Description, String.Empty)
        Me.Text = Title & " - " & Descricao

        If Globais.usuario = "MASTER" And Globais.funcao = "MASTER" Then
            '// Nada
        Else
            Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
            Dim param As MySqlDataReader = dbMain.OpenTable(conn, "SELECT * FROM parametros WHERE variavel = 'LOGO_MDI'")
            Dim tmpImage As Image

            Dim FileName As String = ""
            If param.HasRows Then
                param.Read()
                FileName = param.Item("conteudo")
            End If
            param.Close()
            conn.Close()

            If (Not File.Exists(FileName)) Then
                FileName = Application.StartupPath & "\\escolar.png"
                If (Not File.Exists(FileName)) Then
                    FileName = ""
                End If
            End If

            If Not FileName.Equals("") Then
                tmpImage = Image.FromFile(FileName)
                Me.BackgroundImage = tmpImage
            Else
                'tmpImage = ImageListAvisos.Images.Item("bike1")  ' & CInt(Int((2 * Rnd()) + 1)))
                'Me.BackgroundImage = tmpImage
            End If

            CarregaDadosAdm()
            CriarContasBanco()
        End If

        '// Descanço de tela
        LigarDescanso()

        '// Pegar pasta windows system
        Dim windows_x86 As String = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
        Dim windows_x64 As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
        'Globais.biometria = File.Exists(windows_x86 + ("\ftrScanApi.dll")) Or File.Exists(windows_x64 + ("\ftrScanApi.dll"))

        Globais.biometria = File.Exists(Globais.appPath + ("\ftrSDKHelper13.dll"))

        MontaMenu()

        BarraNotificacoes()
    End Sub

    Public Sub LigarDescanso()
        If _intervalo > 0 Then
            With Timer1
                .Interval = _intervalo
                .Enabled = True
                .Start()
                _MousePosition = MousePosition
            End With
        End If
    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Globais.usuario = "MASTER" And Globais.funcao = "MASTER" Then
            '// Nada
        Else
            Dim LastDate As String = ""
            LastDate = dbMain.lergravarPARAM({"LASTDATE"})
            If LastDate Is Nothing Or LastDate = "" Then
                dbMain.lergravarPARAM({"LASTDATE", Format(Now, "dd/MM/yyyy"), "DATA"}, False)
            Else
                If DateDiff(DateInterval.Day, CDate(LastDate), Now) > 0 Then
                    dbMain.lergravarPARAM({"LASTDATE", Format(Now, "dd/MM/yyyy"), "DATA"}, False)
                Else
                    pnProcessos.Visible = False
                End If
            End If
        End If
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

        '// Descanço de tela
        Dim _Tempo As String = dbMain.lergravarPARAM({"etempo"})
        If _Tempo = Nothing Then _Tempo = 0
        Globais.eTempo = Val(_Tempo) * 60000
        _intervalo = Globais.eTempo
    End Sub

    Private Sub Principal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub

    Private Sub Principal_Move(sender As Object, e As EventArgs) Handles Me.Move
        Me.Refresh()
    End Sub

    Private Sub CriarContasBanco()
        Dim createSQl As String = "CREATE TABLE IF NOT EXISTS `contas_boletas` (`id` int(11) NOT NULL DEFAULT '0',`agencia` varchar(45) DEFAULT NULL," &
            "`conta` varchar(45) DEFAULT NULL,`conta_dv` varchar(45) DEFAULT NULL,`nbanco` varchar(45) DEFAULT NULL,`carteira` varchar(45) DEFAULT NULL," &
            "`moeda` varchar(45) DEFAULT NULL,`tarifa` varchar(45) DEFAULT '0000000000',`nnumero` varchar(45) DEFAULT '9',`nbancodv` varchar(45) DEFAULT NULL," &
            "`identificacao` varchar(45) DEFAULT NULL,`identdv` varchar(2) DEFAULT NULL,PRIMARY KEY (`id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        dbMain.ExecuteCmd(createSQl)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If _MousePosition.X = MousePosition.X Or _MousePosition.Y = MousePosition.Y Then
                With Timer1
                    .Stop()
                    .Enabled = False
                End With
                Dim dct As DescansoTela = New DescansoTela()
                dct.ShowDialog()
                If dct.Saida = 1 Then
                    For i = Application.OpenForms.Count - 1 To 1 Step -1
                        Dim form As Form = Application.OpenForms(i)
                        form.Close()
                    Next i
                    Me.Close()
                Else
                    With Timer1
                        .Start()
                        .Enabled = True
                    End With
                End If
                dct = Nothing
            Else
                _MousePosition = MousePosition
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Principal_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If _intervalo > 0 Then
            With Timer1
                .Enabled = False
                .Stop()
            End With
        End If
    End Sub

    Private Sub Principal_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If _intervalo > 0 Then
            With Timer1
                .Enabled = False
                .Stop()

                .Enabled = True
                .Start()
            End With
        End If

        If e.KeyCode = Keys.F12 And e.Control Then
            Dim emaisetup As New EmailSetup
            emaisetup.ShowDialog()
        End If
    End Sub

    Private Sub Relogio_Tick(sender As Object, e As EventArgs) Handles Relogio.Tick
        Dim SoftHorario As Date = Now
        SoftHora.Text = Format(SoftHorario, "HH")
        SoftMinutos.Text = Format(SoftHorario, "mm")
        SoftSegundos.Text = Format(SoftHorario, "ss")

        Dim SoftRelogioColorOn As Color = Color.White
        Dim SoftRelogioColorOff As Color = Color.FromArgb(64, 64, 64)
        SoftPontoHora.ForeColor = If(SoftPontoHora.ForeColor = SoftRelogioColorOn, SoftRelogioColorOff, SoftRelogioColorOn)
        SoftPontoMinutos.ForeColor = If(SoftPontoHora.ForeColor = SoftRelogioColorOn, SoftRelogioColorOff, SoftRelogioColorOn)
    End Sub
End Class
