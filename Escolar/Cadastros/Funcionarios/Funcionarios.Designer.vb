<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Funcionarios
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Funcionarios))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnVer = New System.Windows.Forms.CheckBox()
        Me.fSenha = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.fUsuario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.fDtEnt = New System.Windows.Forms.TextBox()
        Me.btnTelDel = New System.Windows.Forms.Button()
        Me.btnTelAdc = New System.Windows.Forms.Button()
        Me.fTels = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.fCep = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.fEst = New System.Windows.Forms.Label()
        Me.fCid = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fBai = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.fCplto = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.fEstoque = New System.Windows.Forms.CheckBox()
        Me.fPedidos = New System.Windows.Forms.CheckBox()
        Me.fAutoriza = New System.Windows.Forms.CheckBox()
        Me.fObs = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.fotominus = New System.Windows.Forms.Label()
        Me.fotoplus = New System.Windows.Forms.Label()
        Me.fFoto = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.autSenha = New System.Windows.Forms.TextBox()
        Me.frmAutoriza = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.fNum = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnIncluir = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.fEnd = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fCtps = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fRg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fCpf = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.fCargo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.fCodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExcluir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.fFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmAutoriza.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnVer)
        Me.GroupBox2.Controls.Add(Me.fSenha)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.fUsuario)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 271)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 49)
        Me.GroupBox2.TabIndex = 174
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Login ]"
        '
        'btnVer
        '
        Me.btnVer.Appearance = System.Windows.Forms.Appearance.Button
        Me.btnVer.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.Location = New System.Drawing.Point(432, 20)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(30, 20)
        Me.btnVer.TabIndex = 103
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'fSenha
        '
        Me.fSenha.BackColor = System.Drawing.Color.White
        Me.fSenha.Location = New System.Drawing.Point(266, 19)
        Me.fSenha.MaxLength = 6
        Me.fSenha.Name = "fSenha"
        Me.fSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.fSenha.Size = New System.Drawing.Size(163, 20)
        Me.fSenha.TabIndex = 102
        Me.fSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(224, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 101
        Me.Label15.Text = "Senha:"
        '
        'fUsuario
        '
        Me.fUsuario.BackColor = System.Drawing.Color.White
        Me.fUsuario.Location = New System.Drawing.Point(59, 19)
        Me.fUsuario.MaxLength = 10
        Me.fUsuario.Name = "fUsuario"
        Me.fUsuario.Size = New System.Drawing.Size(163, 20)
        Me.fUsuario.TabIndex = 100
        Me.fUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Usuário:"
        '
        'fDtEnt
        '
        Me.fDtEnt.BackColor = System.Drawing.Color.White
        Me.fDtEnt.Location = New System.Drawing.Point(668, 119)
        Me.fDtEnt.MaxLength = 10
        Me.fDtEnt.Name = "fDtEnt"
        Me.fDtEnt.Size = New System.Drawing.Size(79, 20)
        Me.fDtEnt.TabIndex = 173
        Me.fDtEnt.Text = "99/99/9999"
        Me.fDtEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnTelDel
        '
        Me.btnTelDel.Location = New System.Drawing.Point(372, 119)
        Me.btnTelDel.Name = "btnTelDel"
        Me.btnTelDel.Size = New System.Drawing.Size(23, 21)
        Me.btnTelDel.TabIndex = 171
        Me.btnTelDel.Text = "-"
        Me.btnTelDel.UseVisualStyleBackColor = True
        '
        'btnTelAdc
        '
        Me.btnTelAdc.Location = New System.Drawing.Point(350, 119)
        Me.btnTelAdc.Name = "btnTelAdc"
        Me.btnTelAdc.Size = New System.Drawing.Size(23, 21)
        Me.btnTelAdc.TabIndex = 170
        Me.btnTelAdc.Text = "+"
        Me.btnTelAdc.UseVisualStyleBackColor = True
        '
        'fTels
        '
        Me.fTels.BackColor = System.Drawing.Color.White
        Me.fTels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fTels.Location = New System.Drawing.Point(73, 119)
        Me.fTels.Name = "fTels"
        Me.fTels.Size = New System.Drawing.Size(277, 21)
        Me.fTels.TabIndex = 169
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 122)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 168
        Me.Label16.Text = "Telefones:"
        '
        'fCep
        '
        Me.fCep.BackColor = System.Drawing.Color.White
        Me.fCep.Location = New System.Drawing.Point(686, 93)
        Me.fCep.MaxLength = 10
        Me.fCep.Name = "fCep"
        Me.fCep.Size = New System.Drawing.Size(61, 20)
        Me.fCep.TabIndex = 167
        Me.fCep.Text = "00000-000"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(659, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 166
        Me.Label14.Text = "Cep:"
        '
        'fEst
        '
        Me.fEst.AutoSize = True
        Me.fEst.Location = New System.Drawing.Point(567, 96)
        Me.fEst.Name = "fEst"
        Me.fEst.Size = New System.Drawing.Size(43, 13)
        Me.fEst.TabIndex = 164
        Me.fEst.Text = "Estado:"
        '
        'fCid
        '
        Me.fCid.BackColor = System.Drawing.Color.White
        Me.fCid.Location = New System.Drawing.Point(365, 93)
        Me.fCid.MaxLength = 25
        Me.fCid.Name = "fCid"
        Me.fCid.Size = New System.Drawing.Size(201, 20)
        Me.fCid.TabIndex = 163
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(316, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 162
        Me.Label12.Text = "Cidade:"
        '
        'fBai
        '
        Me.fBai.BackColor = System.Drawing.Color.White
        Me.fBai.Location = New System.Drawing.Point(161, 93)
        Me.fBai.MaxLength = 25
        Me.fBai.Name = "fBai"
        Me.fBai.Size = New System.Drawing.Size(153, 20)
        Me.fBai.TabIndex = 161
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(112, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "Bairro:"
        '
        'fCplto
        '
        Me.fCplto.BackColor = System.Drawing.Color.White
        Me.fCplto.Location = New System.Drawing.Point(680, 67)
        Me.fCplto.MaxLength = 15
        Me.fCplto.Name = "fCplto"
        Me.fCplto.Size = New System.Drawing.Size(67, 20)
        Me.fCplto.TabIndex = 159
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.fEstoque)
        Me.GroupBox3.Controls.Add(Me.fPedidos)
        Me.GroupBox3.Controls.Add(Me.fAutoriza)
        Me.GroupBox3.Location = New System.Drawing.Point(493, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 49)
        Me.GroupBox3.TabIndex = 182
        Me.GroupBox3.TabStop = False
        '
        'fEstoque
        '
        Me.fEstoque.AutoSize = True
        Me.fEstoque.Location = New System.Drawing.Point(11, 20)
        Me.fEstoque.Name = "fEstoque"
        Me.fEstoque.Size = New System.Drawing.Size(63, 17)
        Me.fEstoque.TabIndex = 134
        Me.fEstoque.Text = "Agenda"
        Me.fEstoque.UseVisualStyleBackColor = True
        '
        'fPedidos
        '
        Me.fPedidos.AutoSize = True
        Me.fPedidos.Location = New System.Drawing.Point(106, 20)
        Me.fPedidos.Name = "fPedidos"
        Me.fPedidos.Size = New System.Drawing.Size(49, 17)
        Me.fPedidos.TabIndex = 135
        Me.fPedidos.Text = "Web"
        Me.fPedidos.UseVisualStyleBackColor = True
        '
        'fAutoriza
        '
        Me.fAutoriza.AutoSize = True
        Me.fAutoriza.Location = New System.Drawing.Point(172, 21)
        Me.fAutoriza.Name = "fAutoriza"
        Me.fAutoriza.Size = New System.Drawing.Size(15, 14)
        Me.fAutoriza.TabIndex = 136
        Me.fAutoriza.UseVisualStyleBackColor = True
        '
        'fObs
        '
        Me.fObs.Location = New System.Drawing.Point(17, 157)
        Me.fObs.Multiline = True
        Me.fObs.Name = "fObs"
        Me.fObs.Size = New System.Drawing.Size(732, 103)
        Me.fObs.TabIndex = 180
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(14, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 13)
        Me.Label18.TabIndex = 179
        Me.Label18.Text = "Obs.:"
        '
        'fotominus
        '
        Me.fotominus.Enabled = False
        Me.fotominus.Location = New System.Drawing.Point(27, 90)
        Me.fotominus.Name = "fotominus"
        Me.fotominus.Size = New System.Drawing.Size(13, 13)
        Me.fotominus.TabIndex = 178
        Me.fotominus.Text = "-"
        Me.fotominus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fotominus.Visible = False
        '
        'fotoplus
        '
        Me.fotoplus.Enabled = False
        Me.fotoplus.Location = New System.Drawing.Point(13, 90)
        Me.fotoplus.Name = "fotoplus"
        Me.fotoplus.Size = New System.Drawing.Size(13, 13)
        Me.fotoplus.TabIndex = 177
        Me.fotoplus.Text = "+"
        Me.fotoplus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.fotoplus.Visible = False
        '
        'fFoto
        '
        Me.fFoto.BackColor = System.Drawing.Color.White
        Me.fFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.fFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fFoto.ErrorImage = CType(resources.GetObject("fFoto.ErrorImage"), System.Drawing.Image)
        Me.fFoto.Image = CType(resources.GetObject("fFoto.Image"), System.Drawing.Image)
        Me.fFoto.Location = New System.Drawing.Point(12, 12)
        Me.fFoto.Name = "fFoto"
        Me.fFoto.Size = New System.Drawing.Size(91, 92)
        Me.fFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.fFoto.TabIndex = 176
        Me.fFoto.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(601, 122)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 172
        Me.Label22.Text = "Dt.Entrada:"
        '
        'autSenha
        '
        Me.autSenha.Location = New System.Drawing.Point(68, 19)
        Me.autSenha.Name = "autSenha"
        Me.autSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(64)
        Me.autSenha.Size = New System.Drawing.Size(115, 20)
        Me.autSenha.TabIndex = 1
        Me.autSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmAutoriza
        '
        Me.frmAutoriza.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.frmAutoriza.Controls.Add(Me.autSenha)
        Me.frmAutoriza.Controls.Add(Me.Label17)
        Me.frmAutoriza.ForeColor = System.Drawing.Color.Red
        Me.frmAutoriza.Location = New System.Drawing.Point(167, 270)
        Me.frmAutoriza.Name = "frmAutoriza"
        Me.frmAutoriza.Size = New System.Drawing.Size(195, 54)
        Me.frmAutoriza.TabIndex = 175
        Me.frmAutoriza.TabStop = False
        Me.frmAutoriza.Text = "[ Autorização ]"
        Me.frmAutoriza.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(15, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(47, 13)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Senha:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(650, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Cplto:"
        '
        'btnAlterar
        '
        Me.btnAlterar.Image = CType(resources.GetObject("btnAlterar.Image"), System.Drawing.Image)
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.Location = New System.Drawing.Point(92, 19)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAlterar.Size = New System.Drawing.Size(87, 32)
        Me.btnAlterar.TabIndex = 68
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'fNum
        '
        Me.fNum.BackColor = System.Drawing.Color.White
        Me.fNum.Location = New System.Drawing.Point(597, 67)
        Me.fNum.MaxLength = 10
        Me.fNum.Name = "fNum"
        Me.fNum.Size = New System.Drawing.Size(49, 20)
        Me.fNum.TabIndex = 157
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(556, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 156
        Me.Label9.Text = "Num.:"
        '
        'btnSair
        '
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(647, 19)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSair.Size = New System.Drawing.Size(79, 32)
        Me.btnSair.TabIndex = 74
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnIncluir
        '
        Me.btnIncluir.Image = CType(resources.GetObject("btnIncluir.Image"), System.Drawing.Image)
        Me.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIncluir.Location = New System.Drawing.Point(4, 19)
        Me.btnIncluir.Name = "btnIncluir"
        Me.btnIncluir.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnIncluir.Size = New System.Drawing.Size(85, 32)
        Me.btnIncluir.TabIndex = 67
        Me.btnIncluir.Text = "Incluir"
        Me.btnIncluir.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(555, 19)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnGravar.Size = New System.Drawing.Size(89, 32)
        Me.btnGravar.TabIndex = 73
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'fEnd
        '
        Me.fEnd.BackColor = System.Drawing.Color.White
        Me.fEnd.Location = New System.Drawing.Point(174, 67)
        Me.fEnd.MaxLength = 50
        Me.fEnd.Name = "fEnd"
        Me.fEnd.Size = New System.Drawing.Size(343, 20)
        Me.fEnd.TabIndex = 155
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(112, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Endereço:"
        '
        'fCtps
        '
        Me.fCtps.BackColor = System.Drawing.Color.White
        Me.fCtps.Location = New System.Drawing.Point(638, 41)
        Me.fCtps.MaxLength = 12
        Me.fCtps.Name = "fCtps"
        Me.fCtps.Size = New System.Drawing.Size(109, 20)
        Me.fCtps.TabIndex = 153
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(602, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "CTPS:"
        '
        'fRg
        '
        Me.fRg.BackColor = System.Drawing.Color.White
        Me.fRg.Location = New System.Drawing.Point(487, 41)
        Me.fRg.MaxLength = 12
        Me.fRg.Name = "fRg"
        Me.fRg.Size = New System.Drawing.Size(111, 20)
        Me.fRg.TabIndex = 151
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(462, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "RG:"
        '
        'fCpf
        '
        Me.fCpf.BackColor = System.Drawing.Color.White
        Me.fCpf.Location = New System.Drawing.Point(366, 41)
        Me.fCpf.MaxLength = 15
        Me.fCpf.Name = "fCpf"
        Me.fCpf.Size = New System.Drawing.Size(86, 20)
        Me.fCpf.TabIndex = 149
        Me.fCpf.Text = "000.000.000-00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(337, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 148
        Me.Label5.Text = "CPF:"
        '
        'fCargo
        '
        Me.fCargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fCargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.fCargo.BackColor = System.Drawing.Color.White
        Me.fCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fCargo.Location = New System.Drawing.Point(156, 38)
        Me.fCargo.MaxLength = 25
        Me.fCargo.Name = "fCargo"
        Me.fCargo.Size = New System.Drawing.Size(174, 21)
        Me.fCargo.TabIndex = 147
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(117, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 146
        Me.Label3.Text = "Cargo:"
        '
        'fNome
        '
        Me.fNome.BackColor = System.Drawing.Color.White
        Me.fNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.fNome.Location = New System.Drawing.Point(269, 12)
        Me.fNome.MaxLength = 50
        Me.fNome.Name = "fNome"
        Me.fNome.Size = New System.Drawing.Size(478, 20)
        Me.fNome.TabIndex = 145
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(230, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 144
        Me.Label2.Text = "Nome:"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Image = CType(resources.GetObject("btnPesquisar.Image"), System.Drawing.Image)
        Me.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPesquisar.Location = New System.Drawing.Point(270, 19)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnPesquisar.Size = New System.Drawing.Size(95, 32)
        Me.btnPesquisar.TabIndex = 70
        Me.btnPesquisar.Text = "Pesquisar"
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'fCodigo
        '
        Me.fCodigo.BackColor = System.Drawing.Color.White
        Me.fCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fCodigo.ForeColor = System.Drawing.Color.DarkGreen
        Me.fCodigo.Location = New System.Drawing.Point(156, 12)
        Me.fCodigo.MaxLength = 6
        Me.fCodigo.Name = "fCodigo"
        Me.fCodigo.ReadOnly = True
        Me.fCodigo.Size = New System.Drawing.Size(63, 20)
        Me.fCodigo.TabIndex = 143
        Me.fCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Código:"
        '
        'btnExcluir
        '
        Me.btnExcluir.Image = CType(resources.GetObject("btnExcluir.Image"), System.Drawing.Image)
        Me.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcluir.Location = New System.Drawing.Point(182, 19)
        Me.btnExcluir.Name = "btnExcluir"
        Me.btnExcluir.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnExcluir.Size = New System.Drawing.Size(81, 32)
        Me.btnExcluir.TabIndex = 69
        Me.btnExcluir.Text = "Excluir"
        Me.btnExcluir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSair)
        Me.GroupBox1.Controls.Add(Me.btnIncluir)
        Me.GroupBox1.Controls.Add(Me.btnGravar)
        Me.GroupBox1.Controls.Add(Me.btnAlterar)
        Me.GroupBox1.Controls.Add(Me.btnExcluir)
        Me.GroupBox1.Controls.Add(Me.btnPesquisar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 326)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(734, 64)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Opções ]"
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Image = CType(resources.GetObject("Label19.Image"), System.Drawing.Image)
        Me.Label19.Location = New System.Drawing.Point(518, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(26, 20)
        Me.Label19.TabIndex = 270
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Location = New System.Drawing.Point(608, 92)
        Me.ComboBox1.MaxLength = 25
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(49, 21)
        Me.ComboBox1.TabIndex = 271
        '
        'Funcionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 397)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.frmAutoriza)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.fDtEnt)
        Me.Controls.Add(Me.btnTelDel)
        Me.Controls.Add(Me.btnTelAdc)
        Me.Controls.Add(Me.fTels)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.fCep)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.fEst)
        Me.Controls.Add(Me.fCid)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.fBai)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.fCplto)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.fObs)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.fotominus)
        Me.Controls.Add(Me.fotoplus)
        Me.Controls.Add(Me.fFoto)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.fNum)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.fEnd)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.fCtps)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.fRg)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.fCpf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.fCargo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.fNome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fCodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Funcionarios"
        Me.Text = "Funcionarios"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.fFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmAutoriza.ResumeLayout(False)
        Me.frmAutoriza.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnVer As CheckBox
    Friend WithEvents fSenha As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents fUsuario As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents fDtEnt As TextBox
    Friend WithEvents btnTelDel As Button
    Friend WithEvents btnTelAdc As Button
    Friend WithEvents fTels As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents fCep As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents fEst As Label
    Friend WithEvents fCid As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents fBai As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents fCplto As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents fEstoque As CheckBox
    Friend WithEvents fPedidos As CheckBox
    Friend WithEvents fAutoriza As CheckBox
    Friend WithEvents fObs As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents fotominus As Label
    Friend WithEvents fotoplus As Label
    Friend WithEvents fFoto As PictureBox
    Friend WithEvents Label22 As Label
    Friend WithEvents autSenha As TextBox
    Friend WithEvents frmAutoriza As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btnAlterar As Button
    Friend WithEvents fNum As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSair As Button
    Friend WithEvents btnIncluir As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents fEnd As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents fCtps As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents fRg As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents fCpf As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents fCargo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents fNome As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents fCodigo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExcluir As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label19 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
