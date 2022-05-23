<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendEmail))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Configuracoes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.eEnvios = New System.Windows.Forms.ListBox()
        Me.eStatus = New System.Windows.Forms.Label()
        Me.eProgressBar = New System.Windows.Forms.ProgressBar()
        Me.eDelAnexo = New System.Windows.Forms.Button()
        Me.eAdcAnexo = New System.Windows.Forms.Button()
        Me.ePara = New System.Windows.Forms.ComboBox()
        Me.eEnviar = New System.Windows.Forms.Button()
        Me.eMensagem = New System.Windows.Forms.RichTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.eAssunto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.eAnexos = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "&Anexos:"
        '
        'Configuracoes
        '
        Me.Configuracoes.Image = CType(resources.GetObject("Configuracoes.Image"), System.Drawing.Image)
        Me.Configuracoes.Location = New System.Drawing.Point(12, 9)
        Me.Configuracoes.Name = "Configuracoes"
        Me.Configuracoes.Size = New System.Drawing.Size(39, 40)
        Me.Configuracoes.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(59, 395)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Envios:"
        '
        'eEnvios
        '
        Me.eEnvios.FormattingEnabled = True
        Me.eEnvios.Location = New System.Drawing.Point(104, 395)
        Me.eEnvios.Name = "eEnvios"
        Me.eEnvios.Size = New System.Drawing.Size(411, 95)
        Me.eEnvios.TabIndex = 32
        '
        'eStatus
        '
        Me.eStatus.AutoSize = True
        Me.eStatus.BackColor = System.Drawing.Color.Transparent
        Me.eStatus.Location = New System.Drawing.Point(239, 357)
        Me.eStatus.Name = "eStatus"
        Me.eStatus.Size = New System.Drawing.Size(47, 13)
        Me.eStatus.TabIndex = 31
        Me.eStatus.Text = "Aguarde"
        Me.eStatus.Visible = False
        '
        'eProgressBar
        '
        Me.eProgressBar.Location = New System.Drawing.Point(104, 349)
        Me.eProgressBar.Name = "eProgressBar"
        Me.eProgressBar.Size = New System.Drawing.Size(310, 29)
        Me.eProgressBar.Step = 1
        Me.eProgressBar.TabIndex = 30
        Me.eProgressBar.Visible = False
        '
        'eDelAnexo
        '
        Me.eDelAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.eDelAnexo.Location = New System.Drawing.Point(80, 75)
        Me.eDelAnexo.Name = "eDelAnexo"
        Me.eDelAnexo.Size = New System.Drawing.Size(21, 22)
        Me.eDelAnexo.TabIndex = 29
        Me.eDelAnexo.Text = "-"
        Me.eDelAnexo.UseVisualStyleBackColor = True
        '
        'eAdcAnexo
        '
        Me.eAdcAnexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.eAdcAnexo.Location = New System.Drawing.Point(80, 47)
        Me.eAdcAnexo.Name = "eAdcAnexo"
        Me.eAdcAnexo.Size = New System.Drawing.Size(21, 22)
        Me.eAdcAnexo.TabIndex = 28
        Me.eAdcAnexo.Text = "+"
        Me.eAdcAnexo.UseVisualStyleBackColor = True
        '
        'ePara
        '
        Me.ePara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ePara.FormattingEnabled = True
        Me.ePara.Location = New System.Drawing.Point(104, 22)
        Me.ePara.Name = "ePara"
        Me.ePara.Size = New System.Drawing.Size(411, 21)
        Me.ePara.TabIndex = 27
        '
        'eEnviar
        '
        Me.eEnviar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.eEnviar.FlatAppearance.BorderSize = 2
        Me.eEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.eEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.eEnviar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.eEnviar.Location = New System.Drawing.Point(420, 349)
        Me.eEnviar.Name = "eEnviar"
        Me.eEnviar.Size = New System.Drawing.Size(95, 29)
        Me.eEnviar.TabIndex = 26
        Me.eEnviar.Text = "&Enviar"
        Me.eEnviar.UseVisualStyleBackColor = True
        '
        'eMensagem
        '
        Me.eMensagem.Location = New System.Drawing.Point(104, 174)
        Me.eMensagem.Name = "eMensagem"
        Me.eMensagem.Size = New System.Drawing.Size(411, 169)
        Me.eMensagem.TabIndex = 25
        Me.eMensagem.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Menssagem:"
        '
        'eAssunto
        '
        Me.eAssunto.Location = New System.Drawing.Point(104, 148)
        Me.eAssunto.Name = "eAssunto"
        Me.eAssunto.Size = New System.Drawing.Size(411, 20)
        Me.eAssunto.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Assunto:"
        '
        'eAnexos
        '
        Me.eAnexos.FormattingEnabled = True
        Me.eAnexos.Location = New System.Drawing.Point(104, 47)
        Me.eAnexos.Name = "eAnexos"
        Me.eAnexos.Size = New System.Drawing.Size(411, 95)
        Me.eAnexos.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Para:"
        '
        'SendEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 499)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Configuracoes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.eEnvios)
        Me.Controls.Add(Me.eStatus)
        Me.Controls.Add(Me.eProgressBar)
        Me.Controls.Add(Me.eDelAnexo)
        Me.Controls.Add(Me.eAdcAnexo)
        Me.Controls.Add(Me.ePara)
        Me.Controls.Add(Me.eEnviar)
        Me.Controls.Add(Me.eMensagem)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.eAssunto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.eAnexos)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SendEmail"
        Me.Text = "SendEmail"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Configuracoes As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents eEnvios As ListBox
    Friend WithEvents eStatus As Label
    Friend WithEvents eProgressBar As ProgressBar
    Friend WithEvents eDelAnexo As Button
    Friend WithEvents eAdcAnexo As Button
    Friend WithEvents ePara As ComboBox
    Friend WithEvents eEnviar As Button
    Friend WithEvents eMensagem As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents eAssunto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents eAnexos As ListBox
    Friend WithEvents Label2 As Label
End Class
