<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sgSenha
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
        Me.btEntre = New System.Windows.Forms.Button()
        Me.btSair = New System.Windows.Forms.Button()
        Me.Senha = New System.Windows.Forms.TextBox()
        Me.usuario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btEntre
        '
        Me.btEntre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btEntre.Location = New System.Drawing.Point(33, 58)
        Me.btEntre.Name = "btEntre"
        Me.btEntre.Padding = New System.Windows.Forms.Padding(5)
        Me.btEntre.Size = New System.Drawing.Size(127, 34)
        Me.btEntre.TabIndex = 25
        Me.btEntre.Text = "Entrar"
        Me.btEntre.UseVisualStyleBackColor = True
        '
        'btSair
        '
        Me.btSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btSair.Location = New System.Drawing.Point(192, 58)
        Me.btSair.Name = "btSair"
        Me.btSair.Padding = New System.Windows.Forms.Padding(5)
        Me.btSair.Size = New System.Drawing.Size(127, 34)
        Me.btSair.TabIndex = 24
        Me.btSair.Text = "Sair"
        Me.btSair.UseVisualStyleBackColor = True
        '
        'Senha
        '
        Me.Senha.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Senha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Senha.ForeColor = System.Drawing.Color.Green
        Me.Senha.Location = New System.Drawing.Point(217, 30)
        Me.Senha.Name = "Senha"
        Me.Senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Senha.Size = New System.Drawing.Size(124, 13)
        Me.Senha.TabIndex = 23
        Me.Senha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'usuario
        '
        Me.usuario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuario.ForeColor = System.Drawing.Color.SteelBlue
        Me.usuario.Location = New System.Drawing.Point(31, 30)
        Me.usuario.Name = "usuario"
        Me.usuario.Size = New System.Drawing.Size(124, 13)
        Me.usuario.TabIndex = 22
        Me.usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(189, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Usuário:"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 20)
        Me.Label5.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(192, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(154, 20)
        Me.Label6.TabIndex = 27
        '
        'sgSenha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 103)
        Me.Controls.Add(Me.btEntre)
        Me.Controls.Add(Me.btSair)
        Me.Controls.Add(Me.Senha)
        Me.Controls.Add(Me.usuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "sgSenha"
        Me.Text = "sgSenha"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btEntre As Button
    Friend WithEvents btSair As Button
    Friend WithEvents Senha As TextBox
    Friend WithEvents usuario As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
