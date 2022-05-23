<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.versao = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LinkEmpresa = New System.Windows.Forms.LinkLabel()
        Me.LinkProgramador = New System.Windows.Forms.LinkLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btEntre = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.senha = New System.Windows.Forms.TextBox()
        Me.usuario = New System.Windows.Forms.TextBox()
        Me.unidade = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nameProg = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BaseDados = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(436, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "BaseDados:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(453, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 9)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Versão do Proprama -"
        '
        'versao
        '
        Me.versao.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.versao.ForeColor = System.Drawing.Color.Crimson
        Me.versao.Location = New System.Drawing.Point(545, 37)
        Me.versao.Name = "versao"
        Me.versao.Size = New System.Drawing.Size(42, 9)
        Me.versao.TabIndex = 39
        Me.versao.Text = "1.0.0.0"
        Me.versao.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(193, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 9)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "2022"
        '
        'LinkEmpresa
        '
        Me.LinkEmpresa.AutoSize = True
        Me.LinkEmpresa.Location = New System.Drawing.Point(322, 205)
        Me.LinkEmpresa.Name = "LinkEmpresa"
        Me.LinkEmpresa.Size = New System.Drawing.Size(164, 13)
        Me.LinkEmpresa.TabIndex = 36
        Me.LinkEmpresa.TabStop = True
        Me.LinkEmpresa.Text = "http://www.samicsistemascom.br"
        '
        'LinkProgramador
        '
        Me.LinkProgramador.AutoSize = True
        Me.LinkProgramador.Location = New System.Drawing.Point(448, 229)
        Me.LinkProgramador.Name = "LinkProgramador"
        Me.LinkProgramador.Size = New System.Drawing.Size(143, 13)
        Me.LinkProgramador.TabIndex = 35
        Me.LinkProgramador.TabStop = True
        Me.LinkProgramador.Text = "gmldias.sistemas@gmail.com"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(367, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Programado por:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(275, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(318, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Todos os direitos reservados a GMLDias Samic Sistemas Ltda-ME"
        '
        'btEntre
        '
        Me.btEntre.Image = CType(resources.GetObject("btEntre.Image"), System.Drawing.Image)
        Me.btEntre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEntre.Location = New System.Drawing.Point(280, 145)
        Me.btEntre.Name = "btEntre"
        Me.btEntre.Padding = New System.Windows.Forms.Padding(5)
        Me.btEntre.Size = New System.Drawing.Size(127, 34)
        Me.btEntre.TabIndex = 30
        Me.btEntre.Text = "Entrar"
        Me.btEntre.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.Image = CType(resources.GetObject("btSair.Image"), System.Drawing.Image)
        Me.btSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSair.Location = New System.Drawing.Point(439, 145)
        Me.btSair.Name = "btSair"
        Me.btSair.Padding = New System.Windows.Forms.Padding(5)
        Me.btSair.Size = New System.Drawing.Size(127, 34)
        Me.btSair.TabIndex = 29
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'senha
        '
        Me.senha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.senha.ForeColor = System.Drawing.Color.Green
        Me.senha.Location = New System.Drawing.Point(464, 117)
        Me.senha.Name = "senha"
        Me.senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.senha.Size = New System.Drawing.Size(124, 13)
        Me.senha.TabIndex = 28
        Me.senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'usuario
        '
        Me.usuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuario.ForeColor = System.Drawing.Color.SteelBlue
        Me.usuario.Location = New System.Drawing.Point(278, 117)
        Me.usuario.Name = "usuario"
        Me.usuario.Size = New System.Drawing.Size(124, 13)
        Me.usuario.TabIndex = 27
        Me.usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'unidade
        '
        Me.unidade.FormattingEnabled = True
        Me.unidade.Location = New System.Drawing.Point(253, 67)
        Me.unidade.Name = "unidade"
        Me.unidade.Size = New System.Drawing.Size(169, 21)
        Me.unidade.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(436, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(250, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Usuário:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(250, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Unidade:"
        '
        'nameProg
        '
        Me.nameProg.AutoSize = True
        Me.nameProg.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nameProg.Location = New System.Drawing.Point(248, 12)
        Me.nameProg.Name = "nameProg"
        Me.nameProg.Size = New System.Drawing.Size(299, 25)
        Me.nameProg.TabIndex = 22
        Me.nameProg.Text = "Acesso ao Sistema Escolar"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(230, 220)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(253, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 20)
        Me.Label5.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(439, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 20)
        Me.Label6.TabIndex = 32
        '
        'BaseDados
        '
        Me.BaseDados.BackColor = System.Drawing.Color.White
        Me.BaseDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BaseDados.Image = CType(resources.GetObject("BaseDados.Image"), System.Drawing.Image)
        Me.BaseDados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BaseDados.Location = New System.Drawing.Point(439, 67)
        Me.BaseDados.Name = "BaseDados"
        Me.BaseDados.Size = New System.Drawing.Size(154, 20)
        Me.BaseDados.TabIndex = 41
        Me.BaseDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.versao)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LinkEmpresa)
        Me.Controls.Add(Me.LinkProgramador)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btEntre)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.senha)
        Me.Controls.Add(Me.usuario)
        Me.Controls.Add(Me.unidade)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nameProg)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BaseDados)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Login do Sistema"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents versao As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LinkEmpresa As LinkLabel
    Friend WithEvents LinkProgramador As LinkLabel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btEntre As Button
    Friend WithEvents btSair As Button
    Friend WithEvents senha As TextBox
    Friend WithEvents usuario As TextBox
    Friend WithEvents unidade As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nameProg As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BaseDados As Label
End Class
