<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DescansoTela
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
        Me.components = New System.ComponentModel.Container()
        Me.imagem = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.senhaFrame = New System.Windows.Forms.GroupBox()
        Me.senha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.imagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.senhaFrame.SuspendLayout()
        Me.SuspendLayout()
        '
        'imagem
        '
        Me.imagem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imagem.Location = New System.Drawing.Point(0, 0)
        Me.imagem.Name = "imagem"
        Me.imagem.Size = New System.Drawing.Size(800, 450)
        Me.imagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imagem.TabIndex = 2
        Me.imagem.TabStop = False
        '
        'senhaFrame
        '
        Me.senhaFrame.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.senhaFrame.Controls.Add(Me.senha)
        Me.senhaFrame.Controls.Add(Me.Label1)
        Me.senhaFrame.Location = New System.Drawing.Point(302, 191)
        Me.senhaFrame.Name = "senhaFrame"
        Me.senhaFrame.Size = New System.Drawing.Size(236, 58)
        Me.senhaFrame.TabIndex = 3
        Me.senhaFrame.TabStop = False
        Me.senhaFrame.Visible = False
        '
        'senha
        '
        Me.senha.Location = New System.Drawing.Point(67, 21)
        Me.senha.MaxLength = 30
        Me.senha.Name = "senha"
        Me.senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.senha.Size = New System.Drawing.Size(147, 20)
        Me.senha.TabIndex = 1
        Me.senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Senha:"
        '
        'DescansoTela
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.senhaFrame)
        Me.Controls.Add(Me.imagem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DescansoTela"
        Me.Text = "DescansoTela"
        CType(Me.imagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.senhaFrame.ResumeLayout(False)
        Me.senhaFrame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imagem As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents senhaFrame As GroupBox
    Friend WithEvents senha As TextBox
    Friend WithEvents Label1 As Label
End Class
