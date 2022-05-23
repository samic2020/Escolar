<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.pgbProcessos = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mLocal = New System.Windows.Forms.Label()
        Me.SearchBar = New System.Windows.Forms.Panel()
        Me.ClockBar = New System.Windows.Forms.Panel()
        Me.SoftData = New System.Windows.Forms.Label()
        Me.SoftPontoMinutos = New System.Windows.Forms.Label()
        Me.SoftPontoHora = New System.Windows.Forms.Label()
        Me.SoftSegundos = New System.Windows.Forms.Label()
        Me.SoftMinutos = New System.Windows.Forms.Label()
        Me.SoftHora = New System.Windows.Forms.Label()
        Me.SoftVersion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UserName = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BaseDados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mLogo = New System.Windows.Forms.PictureBox()
        Me.barraMenu = New System.Windows.Forms.MenuStrip()
        Me.LabelGauge = New System.Windows.Forms.Label()
        Me.pnProcessos = New System.Windows.Forms.Panel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageListMenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Relogio = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.ClockBar.SuspendLayout()
        CType(Me.mLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnProcessos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgbProcessos
        '
        Me.pgbProcessos.Location = New System.Drawing.Point(3, 25)
        Me.pgbProcessos.Name = "pgbProcessos"
        Me.pgbProcessos.Size = New System.Drawing.Size(247, 23)
        Me.pgbProcessos.Step = 1
        Me.pgbProcessos.TabIndex = 2
        Me.pgbProcessos.UseWaitCursor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.mLocal)
        Me.Panel1.Controls.Add(Me.SearchBar)
        Me.Panel1.Controls.Add(Me.ClockBar)
        Me.Panel1.Controls.Add(Me.SoftVersion)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.UserName)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.BaseDados)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.mLogo)
        Me.Panel1.Controls.Add(Me.barraMenu)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 81)
        Me.Panel1.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(191, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Local:"
        '
        'mLocal
        '
        Me.mLocal.BackColor = System.Drawing.Color.White
        Me.mLocal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.mLocal.Image = CType(resources.GetObject("mLocal.Image"), System.Drawing.Image)
        Me.mLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mLocal.Location = New System.Drawing.Point(235, 56)
        Me.mLocal.Name = "mLocal"
        Me.mLocal.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.mLocal.Size = New System.Drawing.Size(154, 20)
        Me.mLocal.TabIndex = 32
        Me.mLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SearchBar
        '
        Me.SearchBar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SearchBar.Location = New System.Drawing.Point(795, 24)
        Me.SearchBar.Name = "SearchBar"
        Me.SearchBar.Size = New System.Drawing.Size(229, 57)
        Me.SearchBar.TabIndex = 30
        '
        'ClockBar
        '
        Me.ClockBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClockBar.BackgroundImage = CType(resources.GetObject("ClockBar.BackgroundImage"), System.Drawing.Image)
        Me.ClockBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClockBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ClockBar.Controls.Add(Me.SoftData)
        Me.ClockBar.Controls.Add(Me.SoftPontoMinutos)
        Me.ClockBar.Controls.Add(Me.SoftPontoHora)
        Me.ClockBar.Controls.Add(Me.SoftSegundos)
        Me.ClockBar.Controls.Add(Me.SoftMinutos)
        Me.ClockBar.Controls.Add(Me.SoftHora)
        Me.ClockBar.ForeColor = System.Drawing.Color.White
        Me.ClockBar.Location = New System.Drawing.Point(633, 27)
        Me.ClockBar.Name = "ClockBar"
        Me.ClockBar.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
        Me.ClockBar.Size = New System.Drawing.Size(156, 51)
        Me.ClockBar.TabIndex = 29
        '
        'SoftData
        '
        Me.SoftData.BackColor = System.Drawing.Color.Transparent
        Me.SoftData.Font = New System.Drawing.Font("digital display tfb", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SoftData.Location = New System.Drawing.Point(-2, 28)
        Me.SoftData.Name = "SoftData"
        Me.SoftData.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.SoftData.Size = New System.Drawing.Size(156, 20)
        Me.SoftData.TabIndex = 22
        Me.SoftData.Text = "XX de XXXXXXXX de XXXX"
        Me.SoftData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftPontoMinutos
        '
        Me.SoftPontoMinutos.AutoSize = True
        Me.SoftPontoMinutos.BackColor = System.Drawing.Color.Transparent
        Me.SoftPontoMinutos.Font = New System.Drawing.Font("digital display tfb", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftPontoMinutos.Location = New System.Drawing.Point(101, 1)
        Me.SoftPontoMinutos.Name = "SoftPontoMinutos"
        Me.SoftPontoMinutos.Size = New System.Drawing.Size(17, 30)
        Me.SoftPontoMinutos.TabIndex = 28
        Me.SoftPontoMinutos.Text = ":"
        Me.SoftPontoMinutos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftPontoHora
        '
        Me.SoftPontoHora.AutoSize = True
        Me.SoftPontoHora.BackColor = System.Drawing.Color.Transparent
        Me.SoftPontoHora.Font = New System.Drawing.Font("digital display tfb", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftPontoHora.Location = New System.Drawing.Point(60, 1)
        Me.SoftPontoHora.Name = "SoftPontoHora"
        Me.SoftPontoHora.Size = New System.Drawing.Size(17, 30)
        Me.SoftPontoHora.TabIndex = 27
        Me.SoftPontoHora.Text = ":"
        Me.SoftPontoHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftSegundos
        '
        Me.SoftSegundos.BackColor = System.Drawing.Color.Transparent
        Me.SoftSegundos.Font = New System.Drawing.Font("digital display tfb", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftSegundos.Location = New System.Drawing.Point(113, 2)
        Me.SoftSegundos.Name = "SoftSegundos"
        Me.SoftSegundos.Size = New System.Drawing.Size(36, 29)
        Me.SoftSegundos.TabIndex = 26
        Me.SoftSegundos.Text = "00"
        Me.SoftSegundos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftMinutos
        '
        Me.SoftMinutos.BackColor = System.Drawing.Color.Transparent
        Me.SoftMinutos.Font = New System.Drawing.Font("digital display tfb", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftMinutos.Location = New System.Drawing.Point(73, 2)
        Me.SoftMinutos.Name = "SoftMinutos"
        Me.SoftMinutos.Size = New System.Drawing.Size(36, 29)
        Me.SoftMinutos.TabIndex = 25
        Me.SoftMinutos.Text = "00"
        Me.SoftMinutos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftHora
        '
        Me.SoftHora.BackColor = System.Drawing.Color.Transparent
        Me.SoftHora.Font = New System.Drawing.Font("digital display tfb", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoftHora.Location = New System.Drawing.Point(32, 2)
        Me.SoftHora.Name = "SoftHora"
        Me.SoftHora.Size = New System.Drawing.Size(36, 29)
        Me.SoftHora.TabIndex = 24
        Me.SoftHora.Text = "00"
        Me.SoftHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SoftVersion
        '
        Me.SoftVersion.BackColor = System.Drawing.Color.White
        Me.SoftVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SoftVersion.Image = CType(resources.GetObject("SoftVersion.Image"), System.Drawing.Image)
        Me.SoftVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SoftVersion.Location = New System.Drawing.Point(470, 56)
        Me.SoftVersion.Margin = New System.Windows.Forms.Padding(5, 0, 3, 0)
        Me.SoftVersion.Name = "SoftVersion"
        Me.SoftVersion.Size = New System.Drawing.Size(154, 20)
        Me.SoftVersion.TabIndex = 28
        Me.SoftVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(395, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Versão Soft:"
        '
        'UserName
        '
        Me.UserName.BackColor = System.Drawing.Color.White
        Me.UserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UserName.Image = CType(resources.GetObject("UserName.Image"), System.Drawing.Image)
        Me.UserName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserName.Location = New System.Drawing.Point(470, 31)
        Me.UserName.Name = "UserName"
        Me.UserName.Size = New System.Drawing.Size(154, 20)
        Me.UserName.TabIndex = 25
        Me.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(418, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Usuário:"
        '
        'BaseDados
        '
        Me.BaseDados.BackColor = System.Drawing.Color.White
        Me.BaseDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BaseDados.Image = CType(resources.GetObject("BaseDados.Image"), System.Drawing.Image)
        Me.BaseDados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BaseDados.Location = New System.Drawing.Point(235, 31)
        Me.BaseDados.Name = "BaseDados"
        Me.BaseDados.Size = New System.Drawing.Size(154, 20)
        Me.BaseDados.TabIndex = 22
        Me.BaseDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(162, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "BaseDados:"
        '
        'mLogo
        '
        Me.mLogo.BackColor = System.Drawing.Color.White
        Me.mLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.mLogo.Location = New System.Drawing.Point(3, 27)
        Me.mLogo.Name = "mLogo"
        Me.mLogo.Size = New System.Drawing.Size(155, 49)
        Me.mLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.mLogo.TabIndex = 10
        Me.mLogo.TabStop = False
        '
        'barraMenu
        '
        Me.barraMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.barraMenu.Location = New System.Drawing.Point(0, 0)
        Me.barraMenu.Name = "barraMenu"
        Me.barraMenu.Size = New System.Drawing.Size(1024, 24)
        Me.barraMenu.TabIndex = 9
        Me.barraMenu.Text = "MenuStrip1"
        '
        'LabelGauge
        '
        Me.LabelGauge.BackColor = System.Drawing.Color.CornflowerBlue
        Me.LabelGauge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGauge.ForeColor = System.Drawing.Color.White
        Me.LabelGauge.Location = New System.Drawing.Point(3, 4)
        Me.LabelGauge.Name = "LabelGauge"
        Me.LabelGauge.Size = New System.Drawing.Size(247, 18)
        Me.LabelGauge.TabIndex = 1
        Me.LabelGauge.Text = "Processos em execução..."
        Me.LabelGauge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnProcessos
        '
        Me.pnProcessos.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnProcessos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnProcessos.Controls.Add(Me.pgbProcessos)
        Me.pnProcessos.Controls.Add(Me.LabelGauge)
        Me.pnProcessos.Location = New System.Drawing.Point(2, 9)
        Me.pnProcessos.Name = "pnProcessos"
        Me.pnProcessos.Size = New System.Drawing.Size(253, 54)
        Me.pnProcessos.TabIndex = 22
        Me.pnProcessos.Visible = False
        '
        'ImageListMenu
        '
        Me.ImageListMenu.ImageStream = CType(resources.GetObject("ImageListMenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListMenu.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListMenu.Images.SetKeyName(0, "menu-clientes.png")
        Me.ImageListMenu.Images.SetKeyName(1, "menu-fornecedor.png")
        Me.ImageListMenu.Images.SetKeyName(2, "menu-caminhão.png")
        Me.ImageListMenu.Images.SetKeyName(3, "menu-empilhadera.png")
        Me.ImageListMenu.Images.SetKeyName(4, "menu-empilhadera2.png")
        Me.ImageListMenu.Images.SetKeyName(5, "menu-logout.png")
        Me.ImageListMenu.Images.SetKeyName(6, "menu-exit.png")
        Me.ImageListMenu.Images.SetKeyName(7, "juros2-ico.png")
        Me.ImageListMenu.Images.SetKeyName(8, "agenda.png")
        Me.ImageListMenu.Images.SetKeyName(9, "funcionario.png")
        Me.ImageListMenu.Images.SetKeyName(10, "preco-icone.png")
        Me.ImageListMenu.Images.SetKeyName(11, "vendas-ico.png")
        Me.ImageListMenu.Images.SetKeyName(12, "contas-ico.jpg")
        Me.ImageListMenu.Images.SetKeyName(13, "acerto-preco-ico.png")
        Me.ImageListMenu.Images.SetKeyName(14, "baixacontas-ico.png")
        Me.ImageListMenu.Images.SetKeyName(15, "listamotivos-ico.png")
        Me.ImageListMenu.Images.SetKeyName(16, "trocas-ico.png")
        Me.ImageListMenu.Images.SetKeyName(17, "msgboleto-ico.png")
        Me.ImageListMenu.Images.SetKeyName(18, "dadosemp-ico.png")
        Me.ImageListMenu.Images.SetKeyName(19, "acesso-ico.png")
        Me.ImageListMenu.Images.SetKeyName(20, "bolettoremessa-ico.png")
        Me.ImageListMenu.Images.SetKeyName(21, "confcustos-ico.png")
        Me.ImageListMenu.Images.SetKeyName(22, "vendtroca-ico.png")
        Me.ImageListMenu.Images.SetKeyName(23, "inconsistencia-ico.png")
        Me.ImageListMenu.Images.SetKeyName(24, "baixafidel-ico.png")
        Me.ImageListMenu.Images.SetKeyName(25, "avalcred-ico.png")
        Me.ImageListMenu.Images.SetKeyName(26, "indpro-ico.png")
        Me.ImageListMenu.Images.SetKeyName(27, "indjur-ico.png")
        Me.ImageListMenu.Images.SetKeyName(28, "cotacao-ico.png")
        Me.ImageListMenu.Images.SetKeyName(29, "montagem-ico.png")
        Me.ImageListMenu.Images.SetKeyName(30, "estoque-ico.png")
        Me.ImageListMenu.Images.SetKeyName(31, "comissao-ico.png")
        Me.ImageListMenu.Images.SetKeyName(32, "consultaprodutosestoque-ico.png")
        Me.ImageListMenu.Images.SetKeyName(33, "conferencia-ico.png")
        Me.ImageListMenu.Images.SetKeyName(34, "backup")
        Me.ImageListMenu.Images.SetKeyName(35, "restore")
        Me.ImageListMenu.Images.SetKeyName(36, "Alunos.ico")
        '
        'Timer1
        '
        '
        'Relogio
        '
        Me.Relogio.Enabled = True
        Me.Relogio.Interval = 1000
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(9, 98)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 153)
        Me.Panel2.TabIndex = 25
        Me.Panel2.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(256, 25)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Turmas 2022"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "1º Período - Manhã - Turma: A"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(182, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "40"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(223, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "23"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Location = New System.Drawing.Point(277, 99)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(262, 153)
        Me.Panel3.TabIndex = 29
        Me.Panel3.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(223, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "23"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(89, 13)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Alunos em Atraso"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(3, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label12.Size = New System.Drawing.Size(256, 25)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Caixa 2022"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Contas a Pagar"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(229, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "3"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Location = New System.Drawing.Point(545, 100)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(262, 153)
        Me.Panel4.TabIndex = 31
        Me.Panel4.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(214, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "300,00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Contas a Pagar"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(139, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(19, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "23"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 13)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Alunos em Atraso"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(3, 2)
        Me.Label18.Name = "Label18"
        Me.Label18.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label18.Size = New System.Drawing.Size(256, 25)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Financeiro 2022"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(205, 34)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "5.850,33"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(145, 47)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(13, 13)
        Me.Label20.TabIndex = 32
        Me.Label20.Text = "3"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 598)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnProcessos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.IsMdiContainer = True
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Principal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ClockBar.ResumeLayout(False)
        Me.ClockBar.PerformLayout()
        CType(Me.mLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnProcessos.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pgbProcessos As ProgressBar
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents mLocal As Label
    Friend WithEvents SearchBar As Panel
    Friend WithEvents ClockBar As Panel
    Friend WithEvents SoftData As Label
    Friend WithEvents SoftPontoMinutos As Label
    Friend WithEvents SoftPontoHora As Label
    Friend WithEvents SoftSegundos As Label
    Friend WithEvents SoftMinutos As Label
    Friend WithEvents SoftHora As Label
    Friend WithEvents SoftVersion As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents UserName As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BaseDados As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mLogo As PictureBox
    Friend WithEvents barraMenu As MenuStrip
    Friend WithEvents LabelGauge As Label
    Friend WithEvents pnProcessos As Panel
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents ImageListMenu As ImageList
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Relogio As Timer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
End Class
