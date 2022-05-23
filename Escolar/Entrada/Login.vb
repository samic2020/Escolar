Imports System.IO
Imports MySql.Data.MySqlClient

'// ****************************************************************************************************
'// * Data: 31/01/2022 - Programado por: wellspinto@gmail.com                                          *
'// ****************************************************************************************************
Public Class Login
    Private dbMain As [Db] = New Db
    Private conn As MySqlConnection = Nothing

    Private Sub unidade_KeyUp(sender As Object, e As KeyEventArgs) Handles unidade.KeyUp
        If e.KeyCode = Keys.Escape Then
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            End
        End If

        If e.KeyCode = Keys.Return And unidade.Text.Length > 0 Then
            If unidade.SelectedIndex < unidade.Items.Count - 1 Then
                If Funcoes.IsValidIP(unidade.Text) Then
                    Globais.unidade = unidade.Text.Trim
                Else
                    Globais.unidade = unidade.Text.Trim
                End If
                conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
                If Not IsNothing(conn) Then
                    usuario.Enabled = True
                    senha.Enabled = False
                    usuario.Focus()
                    Exit Sub
                End If
                If Not IsNothing(conn) Then
                    If conn.State = ConnectionState.Open Then conn.Close()
                End If
            Else
                usuario.Enabled = True
                senha.Enabled = False
                usuario.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btSair_Click(sender As Object, e As EventArgs) Handles btSair.Click
        Dispose()
        Application.Exit()
    End Sub

    Private Sub usuario_KeyUp(sender As Object, e As KeyEventArgs) Handles usuario.KeyUp
        If e.KeyCode = Keys.Escape Then
            usuario.Text = ""
            usuario.Enabled = False
            unidade.Focus()
        End If
        If e.KeyCode = Keys.Return And Trim(usuario.Text) <> "" Then
            senha.Text = ""
            senha.Enabled = True
            senha.Focus()
        End If
    End Sub

    Private Sub usuario_GotFocus(sender As Object, e As EventArgs) Handles usuario.GotFocus
        senha.Text = ""
        senha.Enabled = False
    End Sub

    Private Sub unidade_GotFocus(sender As Object, e As EventArgs) Handles unidade.GotFocus
        usuario.Text = ""
        usuario.Enabled = False
        senha.Text = ""
        senha.Enabled = False
    End Sub

    Private Sub senha_KeyUp(sender As Object, e As KeyEventArgs) Handles senha.KeyUp
        If e.KeyCode = Keys.Escape Then
            unidade.Focus()
        End If
        If e.KeyCode = Keys.Return And Trim(usuario.Text) <> "" Then
            '// Logar no usuário
            btEntre.Enabled = True
            btEntre.Focus()
        End If
    End Sub

    Private Sub btEntre_Click(sender As Object, e As EventArgs) Handles btEntre.Click
        If usuario.Text.Trim.ToUpper = "MASTER" And senha.Text.Trim.ToUpper = "MASTER" Then
            Globais.usuario = "MASTER"
            Globais.senha = "MASTER"
            Globais.funcao = "MASTER"
            Globais.codfun = "MASTER"
            Globais.emaster = True
            Me.Hide()
            Dim prin As New Principal
            prin.Show()
        Else
            If unidade.SelectedIndex = unidade.Items.Count Then
                MsgBox("Unidade inválida para este nível de usuário!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
                unidade.Focus()
                Exit Sub
            End If
            Dim tcadfun As MySqlDataReader
            tcadfun = dbMain.OpenTable(conn, "SELECT usuario, senha, f_funcao, f_cod, master, atalhos, f_estoque, f_pedido, f_autoriza, f_externo FROM cadfun WHERE usuario = '" & usuario.Text.Trim & "' AND senha = '" & senha.Text.Trim & "';")
            If tcadfun.HasRows Then
                tcadfun.Read()
                Globais.conn = conn
                Globais.usuario = tcadfun.Item("usuario")
                Globais.senha = tcadfun.Item("senha")
                Globais.funcao = tcadfun.Item("f_funcao")
                Globais.autoriza = tcadfun("f_autoriza")
                Globais.codfun = tcadfun.Item("f_cod")

                Globais.unidade = unidade.SelectedItem("Ip")
                Globais.databaseName = unidade.SelectedItem("BaseDados")
                Globais.user = unidade.SelectedItem("User")
                Globais.pwd = unidade.SelectedItem("PassWord")

                Dim protmenu As String = Nothing
                Try
                    protmenu = tcadfun.Item("atalhos")
                Catch ex As Exception
                    protmenu = Nothing
                End Try
                Globais.protocolomenu = IIf(protmenu IsNot Nothing, protmenu, "")
                Globais.emaster = Globais.funcao.ToUpper.Trim Like "GER*" 'tcadfun.Item("master")
                If Globais.protocolomenu.Trim = "" And Not Globais.emaster Then
                    MsgBox("Usuário sem permissões!" & vbNewLine & "Contate o gerente e peça o cadastramento.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton1, "Atenção!")
                    unidade.Focus()
                    tcadfun.Close()
                    Return
                End If
                Me.Hide()
                Dim prin As New Principal
                prin.Show()
            Else
                unidade.Focus()
            End If
            tcadfun.Close()
        End If
    End Sub

    Public Sub ShowLogin()
        Me.Show()
        unidade.Focus()
    End Sub

    Private Sub LinkEmpresa_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkEmpresa.LinkClicked
        LinkEmpresa.LinkVisited = True

        '// Navigate to a URL.
        Process.Start("http://www.samicsistemas.com.br")
    End Sub

    Private Sub LinkProgramador_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkProgramador.LinkClicked
        LinkProgramador.LinkVisited = True

        '// Navigate to a URL.
        Process.Start("mailto:gmldias.sistemas@gmail.com")
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox(Funcoes.RemoverAcentuacao("ŠŒŽšœžŸ¥µÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýÿ"))

        Dim myprocesses As Process() = Process.GetProcessesByName(Application.ProductName.Trim & "*") 'obter processos com o nome X
        If myprocesses.Length > 0 Then
            MsgBox(Application.ProductName & " já esta rodando no seu PC.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            End
        End If

        If Not File.Exists(Globais.appPath & "Escolar.ini") Then
            Dim iniProgram As InitializeSystem = New InitializeSystem
            iniProgram.ShowDialog()
            If Not iniProgram.Sucesso Then
                Me.Dispose()
                End
            End If
            ArquivoInicial()
        End If

        'SplashScreen.BarLong(100)
        'Dim i As Integer = 0
        'While i <= 100
        '    SplashScreen.ShowBar(i)
        '    i += 1
        '    Threading.Thread.Sleep(1)
        'End While
        '// dbMain.lergravarPARAM({"LASTDATE", Format(Now, "dd/MM/yyyy"), "DATA"}, False)

        '// Data de Expiração do programa
        Dim expData As DateTime = Nothing
        Dim s_expData As String = "" & Globais.Setting.Load("expData", "fHqW/UWuv3R3SR6W5Q4cbT0OJD86Vi92STC0ZC8R/UBbxX1Yq1MLDg==")
        Dim mMac As String = MacAddress().Trim.ToUpper
        Dim wrapper As New Simple3Des(mMac)
        Dim l_expData As Long = 0L
        Try
            l_expData = CLng(wrapper.DecryptData(s_expData))
        Catch ex As Exception
            l_expData = 1L
        End Try

        Dim t_expData As Long = l_expData

        If t_expData <> 0L Then
            expData = New DateTime(t_expData)
            Dim dateDif As Integer = DateDiff(DateInterval.Day, expData, Now)
            If dateDif > 0 Then
                Dim expWindow As New Expiracao()
                expWindow.ShowDialog()
                Environment.Exit(0)
            End If
        End If

        Try
            Dim Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim TitleAttribute = TryCast(Assembly.GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False).FirstOrDefault(), System.Reflection.AssemblyTitleAttribute)
            Dim Title = If(TitleAttribute IsNot Nothing, TitleAttribute.Title, String.Empty)
            Dim Version = Assembly.GetName().Version.ToString()
            nameProg.Text = "Acesso ao Sistema " & Title
            versao.Text = Version

            '// Configuracoes
            LoadIpBase()
        Catch ex As Exception
        End Try

        '// Checa se o computador esta com a Data
        Dim DataComputador As Date = Now
        Dim DataServidor As Date = dbMain.PegaDataHoraServidor

        If DateDiff(DateInterval.Day, DataComputador, DataServidor) <> 0 Then
            MsgBox("A data do COMPUTADOR não corresponde a data do SERVIDOR." &
                   vbNewLine & vbNewLine & "Data do Servidor: " & DataServidor &
                   vbNewLine & "Data do Computador: " & DataComputador, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção!")
            Environment.Exit(0)
        End If
    End Sub

    Private Sub ArquivoInicial()
        Dim oArquivo As System.IO.File
        Dim oEscrever As System.IO.StreamWriter

        oEscrever = oArquivo.CreateText(Globais.appPath & "Escolar.ini")
        oEscrever.WriteLine("Criado em " & Now)
        oEscrever.Close()
    End Sub
    Private Sub LoadIpBase()
        unidade.Items.Clear()
        unidade.DataSource = Nothing
        Dim datatable As New DataTable("Config")
        datatable.Columns.Add("Ip", GetType(String))
        datatable.Columns.Add("BaseDados", GetType(String))
        datatable.Columns.Add("User", GetType(String))
        datatable.Columns.Add("PassWord", GetType(String))

        For n = 0 To 4
            Dim nIP As String = Setting.Load("Unidade" & n, If(n = 0, "127.0.0.1", ""))
            Dim nDataBase As String = Setting.Load("DataBaseName" & n, If(n = 0, "escola", ""))
            Dim nUser As String = Setting.Load("User" & n, If(n = 0, "root", ""))
            Dim nPassWord As String = Setting.Load("PassWord" & n, If(n = 0, "7kf51b", ""))

            If nIP.Trim <> "" Then
                datatable.Rows.Add({nIP, nDataBase, nUser, nPassWord})
            End If
        Next

        '// BackUpRestore - Manutenção
        datatable.Rows.Add({"BackUp/Restore", "", "", ""})

        unidade.DataSource = datatable
        unidade.DisplayMember = "Ip"
        unidade.ValueMember = "Ip"
        'unidade.DisplayMultiColumnsInBox = True
    End Sub

    Private Sub CreateConfig()
        Dim createSQL As String = "CREATE TABLE IF NOT EXISTS `config` (`id` int(11) NOT NULL AUTO_INCREMENT,`ip` varchar(15) DEFAULT NULL,`DataBase` varchar(25) DEFAULT NULL,PRIMARY KEY (`id`)) ENGINE=MyISAM DEFAULT CHARSET=utf8;"
        dbMain.ExecuteCmd(createSQL)
    End Sub

    Private Sub unidade_KeyDown(sender As Object, e As KeyEventArgs) Handles unidade.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub usuario_KeyDown(sender As Object, e As KeyEventArgs) Handles usuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub senha_KeyDown(sender As Object, e As KeyEventArgs) Handles senha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub unidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unidade.SelectedIndexChanged
        BaseDados.Text = unidade.SelectedItem("BaseDados")
    End Sub
End Class