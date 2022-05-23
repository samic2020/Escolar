<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BancoConf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BancoConf))
        Me.jIdentificacaoDv = New System.Windows.Forms.TextBox()
        Me.jIdentificacao = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAdc = New System.Windows.Forms.Button()
        Me.bancos = New System.Windows.Forms.DataGridView()
        Me.jNossoNumero = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.jTarifa = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.jMoeda = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.jCarteira = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.jCtaDv = New System.Windows.Forms.TextBox()
        Me.jConta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.jAgencia = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.bancos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'jIdentificacaoDv
        '
        Me.jIdentificacaoDv.Location = New System.Drawing.Point(242, 58)
        Me.jIdentificacaoDv.Name = "jIdentificacaoDv"
        Me.jIdentificacaoDv.Size = New System.Drawing.Size(112, 20)
        Me.jIdentificacaoDv.TabIndex = 41
        '
        'jIdentificacao
        '
        Me.jIdentificacao.Location = New System.Drawing.Point(91, 58)
        Me.jIdentificacao.Name = "jIdentificacao"
        Me.jIdentificacao.Size = New System.Drawing.Size(145, 20)
        Me.jIdentificacao.TabIndex = 40
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "identificação:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(15, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(674, 18)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "..: Bancos para emissão de Boletos"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAdc
        '
        Me.btnAdc.Image = CType(resources.GetObject("btnAdc.Image"), System.Drawing.Image)
        Me.btnAdc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdc.Location = New System.Drawing.Point(360, 56)
        Me.btnAdc.Name = "btnAdc"
        Me.btnAdc.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAdc.Size = New System.Drawing.Size(106, 23)
        Me.btnAdc.TabIndex = 37
        Me.btnAdc.Text = "Adiciona"
        Me.btnAdc.UseVisualStyleBackColor = True
        '
        'bancos
        '
        Me.bancos.AllowUserToAddRows = False
        Me.bancos.AllowUserToDeleteRows = False
        Me.bancos.AllowUserToOrderColumns = True
        Me.bancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.bancos.Location = New System.Drawing.Point(15, 102)
        Me.bancos.Name = "bancos"
        Me.bancos.ReadOnly = True
        Me.bancos.Size = New System.Drawing.Size(674, 150)
        Me.bancos.TabIndex = 36
        '
        'jNossoNumero
        '
        Me.jNossoNumero.Location = New System.Drawing.Point(481, 32)
        Me.jNossoNumero.Name = "jNossoNumero"
        Me.jNossoNumero.Size = New System.Drawing.Size(210, 20)
        Me.jNossoNumero.TabIndex = 35
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(401, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Nosso Numero:"
        '
        'jTarifa
        '
        Me.jTarifa.Location = New System.Drawing.Point(310, 32)
        Me.jTarifa.Name = "jTarifa"
        Me.jTarifa.Size = New System.Drawing.Size(85, 20)
        Me.jTarifa.TabIndex = 33
        Me.jTarifa.Text = "0,00"
        Me.jTarifa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(267, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Tarifa:"
        '
        'jMoeda
        '
        Me.jMoeda.Location = New System.Drawing.Point(206, 32)
        Me.jMoeda.Name = "jMoeda"
        Me.jMoeda.Size = New System.Drawing.Size(51, 20)
        Me.jMoeda.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(157, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Moeda:"
        '
        'jCarteira
        '
        Me.jCarteira.Location = New System.Drawing.Point(67, 32)
        Me.jCarteira.Name = "jCarteira"
        Me.jCarteira.Size = New System.Drawing.Size(79, 20)
        Me.jCarteira.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Carteira:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(478, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Numero do Banco:"
        '
        'jCtaDv
        '
        Me.jCtaDv.Location = New System.Drawing.Point(354, 6)
        Me.jCtaDv.Name = "jCtaDv"
        Me.jCtaDv.Size = New System.Drawing.Size(112, 20)
        Me.jCtaDv.TabIndex = 26
        '
        'jConta
        '
        Me.jConta.Location = New System.Drawing.Point(203, 6)
        Me.jConta.Name = "jConta"
        Me.jConta.Size = New System.Drawing.Size(145, 20)
        Me.jConta.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Conta:"
        '
        'jAgencia
        '
        Me.jAgencia.Location = New System.Drawing.Point(67, 6)
        Me.jAgencia.Name = "jAgencia"
        Me.jAgencia.Size = New System.Drawing.Size(79, 20)
        Me.jAgencia.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Agência:"
        '
        'BancoConf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 264)
        Me.Controls.Add(Me.jIdentificacaoDv)
        Me.Controls.Add(Me.jIdentificacao)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnAdc)
        Me.Controls.Add(Me.bancos)
        Me.Controls.Add(Me.jNossoNumero)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.jTarifa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.jMoeda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.jCarteira)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.jCtaDv)
        Me.Controls.Add(Me.jConta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.jAgencia)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BancoConf"
        Me.Text = "BancoConf"
        CType(Me.bancos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents jIdentificacaoDv As TextBox
    Friend WithEvents jIdentificacao As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnAdc As Button
    Friend WithEvents bancos As DataGridView
    Friend WithEvents jNossoNumero As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents jTarifa As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents jMoeda As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents jCarteira As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents jCtaDv As TextBox
    Friend WithEvents jConta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents jAgencia As TextBox
    Friend WithEvents Label1 As Label
End Class
