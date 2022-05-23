<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expiracao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Expiracao))
        Me.ColarIcon = New System.Windows.Forms.PictureBox()
        Me.CopiarColar = New System.Windows.Forms.PictureBox()
        Me.ChaveAtivacao = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAtivar = New System.Windows.Forms.Button()
        Me.actCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lMensagem = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.ColarIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CopiarColar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColarIcon
        '
        Me.ColarIcon.Image = CType(resources.GetObject("ColarIcon.Image"), System.Drawing.Image)
        Me.ColarIcon.Location = New System.Drawing.Point(478, 269)
        Me.ColarIcon.Name = "ColarIcon"
        Me.ColarIcon.Size = New System.Drawing.Size(20, 19)
        Me.ColarIcon.TabIndex = 19
        Me.ColarIcon.TabStop = False
        '
        'CopiarColar
        '
        Me.CopiarColar.Image = CType(resources.GetObject("CopiarColar.Image"), System.Drawing.Image)
        Me.CopiarColar.Location = New System.Drawing.Point(578, 222)
        Me.CopiarColar.Name = "CopiarColar"
        Me.CopiarColar.Size = New System.Drawing.Size(20, 19)
        Me.CopiarColar.TabIndex = 18
        Me.CopiarColar.TabStop = False
        '
        'ChaveAtivacao
        '
        Me.ChaveAtivacao.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChaveAtivacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ChaveAtivacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChaveAtivacao.Location = New System.Drawing.Point(274, 220)
        Me.ChaveAtivacao.Name = "ChaveAtivacao"
        Me.ChaveAtivacao.Size = New System.Drawing.Size(329, 23)
        Me.ChaveAtivacao.TabIndex = 17
        Me.ChaveAtivacao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(12, 223)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Informe ao suporte esta chave de ativação:"
        '
        'btnAtivar
        '
        Me.btnAtivar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAtivar.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.btnAtivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtivar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAtivar.Location = New System.Drawing.Point(508, 265)
        Me.btnAtivar.Name = "btnAtivar"
        Me.btnAtivar.Size = New System.Drawing.Size(95, 27)
        Me.btnAtivar.TabIndex = 15
        Me.btnAtivar.Text = "Ativar"
        Me.btnAtivar.UseVisualStyleBackColor = False
        '
        'actCode
        '
        Me.actCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.actCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.actCode.ForeColor = System.Drawing.Color.Green
        Me.actCode.Location = New System.Drawing.Point(12, 266)
        Me.actCode.Name = "actCode"
        Me.actCode.Size = New System.Drawing.Size(490, 26)
        Me.actCode.TabIndex = 14
        Me.actCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Entre aqui o Código de Ativação:"
        '
        'lMensagem
        '
        Me.lMensagem.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lMensagem.Location = New System.Drawing.Point(12, 157)
        Me.lMensagem.Name = "lMensagem"
        Me.lMensagem.Size = New System.Drawing.Size(589, 62)
        Me.lMensagem.TabIndex = 12
        Me.lMensagem.Text = "O período de ultilização do sistema encontra-se expirado." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Entre em contato com a" &
    " empresa responsável pelo sistema e solicite um código de ativação."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(162, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(439, 142)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 11
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 142)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Expiracao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 304)
        Me.Controls.Add(Me.ColarIcon)
        Me.Controls.Add(Me.CopiarColar)
        Me.Controls.Add(Me.ChaveAtivacao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAtivar)
        Me.Controls.Add(Me.actCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lMensagem)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Expiracao"
        Me.Text = "Expiracao"
        CType(Me.ColarIcon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CopiarColar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColarIcon As PictureBox
    Friend WithEvents CopiarColar As PictureBox
    Friend WithEvents ChaveAtivacao As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAtivar As Button
    Friend WithEvents actCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lMensagem As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
