<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigEmail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigEmail))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.emailSsl = New System.Windows.Forms.CheckBox()
        Me.emailPort = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.emailSmtp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.emailPwd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.emailAddressPedido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnRetornar = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnAlterar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.emailSsl)
        Me.GroupBox2.Controls.Add(Me.emailPort)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.emailSmtp)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.emailPwd)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.emailAddressPedido)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(451, 156)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "[ Parametros de E-MAIL ]"
        '
        'emailSsl
        '
        Me.emailSsl.AutoSize = True
        Me.emailSsl.Location = New System.Drawing.Point(167, 126)
        Me.emailSsl.Name = "emailSsl"
        Me.emailSsl.Size = New System.Drawing.Size(46, 17)
        Me.emailSsl.TabIndex = 10
        Me.emailSsl.Text = "SSL"
        Me.emailSsl.UseVisualStyleBackColor = True
        '
        'emailPort
        '
        Me.emailPort.Location = New System.Drawing.Point(64, 122)
        Me.emailPort.Name = "emailPort"
        Me.emailPort.Size = New System.Drawing.Size(85, 20)
        Me.emailPort.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Port:"
        '
        'emailSmtp
        '
        Me.emailSmtp.Location = New System.Drawing.Point(64, 89)
        Me.emailSmtp.Name = "emailSmtp"
        Me.emailSmtp.Size = New System.Drawing.Size(372, 20)
        Me.emailSmtp.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Smtp:"
        '
        'emailPwd
        '
        Me.emailPwd.Location = New System.Drawing.Point(75, 56)
        Me.emailPwd.Name = "emailPwd"
        Me.emailPwd.Size = New System.Drawing.Size(361, 20)
        Me.emailPwd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "PassWord:"
        '
        'emailAddressPedido
        '
        Me.emailAddressPedido.Location = New System.Drawing.Point(99, 23)
        Me.emailAddressPedido.Name = "emailAddressPedido"
        Me.emailAddressPedido.Size = New System.Drawing.Size(337, 20)
        Me.emailAddressPedido.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "E-Mail de envio:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Aqua
        Me.GroupBox3.Controls.Add(Me.btnRetornar)
        Me.GroupBox3.Controls.Add(Me.btnGravar)
        Me.GroupBox3.Controls.Add(Me.btnAlterar)
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(469, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(138, 156)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "[ Opções ]"
        '
        'btnRetornar
        '
        Me.btnRetornar.Image = CType(resources.GetObject("btnRetornar.Image"), System.Drawing.Image)
        Me.btnRetornar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRetornar.Location = New System.Drawing.Point(6, 110)
        Me.btnRetornar.Name = "btnRetornar"
        Me.btnRetornar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnRetornar.Size = New System.Drawing.Size(124, 39)
        Me.btnRetornar.TabIndex = 2
        Me.btnRetornar.Text = "Retornar"
        Me.btnRetornar.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(6, 65)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnGravar.Size = New System.Drawing.Size(124, 39)
        Me.btnGravar.TabIndex = 1
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'btnAlterar
        '
        Me.btnAlterar.Image = CType(resources.GetObject("btnAlterar.Image"), System.Drawing.Image)
        Me.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAlterar.Location = New System.Drawing.Point(6, 20)
        Me.btnAlterar.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.btnAlterar.Name = "btnAlterar"
        Me.btnAlterar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnAlterar.Size = New System.Drawing.Size(124, 39)
        Me.btnAlterar.TabIndex = 0
        Me.btnAlterar.Text = "Alterar"
        Me.btnAlterar.UseVisualStyleBackColor = True
        '
        'ConfigEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 176)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ConfigEmail"
        Me.Text = "ConfigEmail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents emailSsl As CheckBox
    Friend WithEvents emailPort As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents emailSmtp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents emailPwd As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents emailAddressPedido As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnRetornar As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents btnAlterar As Button
End Class
