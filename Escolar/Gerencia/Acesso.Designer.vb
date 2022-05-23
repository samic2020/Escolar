<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Acesso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Acesso))
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.pnlAcessos = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.aUsuario = New Escolar.CSUST.Data.MultiColumnComboBoxEx()
        Me.SuspendLayout()
        '
        'btnSair
        '
        Me.btnSair.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSair.ForeColor = System.Drawing.Color.Black
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(460, 4)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.btnSair.Size = New System.Drawing.Size(62, 23)
        Me.btnSair.TabIndex = 41
        Me.btnSair.Text = "Sair"
        Me.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGravar.ForeColor = System.Drawing.Color.Black
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(374, 4)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.btnGravar.Size = New System.Drawing.Size(80, 23)
        Me.btnGravar.TabIndex = 40
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'pnlAcessos
        '
        Me.pnlAcessos.AutoScroll = True
        Me.pnlAcessos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAcessos.Location = New System.Drawing.Point(15, 33)
        Me.pnlAcessos.Name = "pnlAcessos"
        Me.pnlAcessos.Size = New System.Drawing.Size(507, 282)
        Me.pnlAcessos.TabIndex = 39
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = CType(resources.GetObject("btnMostrar.Image"), System.Drawing.Image)
        Me.btnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMostrar.Location = New System.Drawing.Point(249, 4)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnMostrar.Size = New System.Drawing.Size(98, 23)
        Me.btnMostrar.TabIndex = 38
        Me.btnMostrar.Text = "Mostrar"
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Usuário:"
        '
        'aUsuario
        '
        Me.aUsuario.DropDownHeight = 98
        Me.aUsuario.DropDownWidth = 121
        Me.aUsuario.FormattingEnabled = True
        Me.aUsuario.Location = New System.Drawing.Point(62, 7)
        Me.aUsuario.Name = "aUsuario"
        Me.aUsuario.Size = New System.Drawing.Size(181, 18)
        Me.aUsuario.TabIndex = 42
        '
        'Acesso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 326)
        Me.Controls.Add(Me.aUsuario)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.pnlAcessos)
        Me.Controls.Add(Me.btnMostrar)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Acesso"
        Me.Text = "Acesso"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSair As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents pnlAcessos As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents aUsuario As CSUST.Data.MultiColumnComboBoxEx
End Class
