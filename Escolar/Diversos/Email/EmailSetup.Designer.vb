<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailSetup))
        Me.smtpPort = New System.Windows.Forms.TextBox()
        Me.popPort = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.emailTimer = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.viewPasswd = New System.Windows.Forms.CheckBox()
        Me.passwd = New System.Windows.Forms.TextBox()
        Me.user = New System.Windows.Forms.TextBox()
        Me.smtpAddress = New System.Windows.Forms.TextBox()
        Me.ssl = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.popAddress = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'smtpPort
        '
        Me.smtpPort.Location = New System.Drawing.Point(621, 35)
        Me.smtpPort.Name = "smtpPort"
        Me.smtpPort.Size = New System.Drawing.Size(47, 20)
        Me.smtpPort.TabIndex = 35
        Me.smtpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'popPort
        '
        Me.popPort.Location = New System.Drawing.Point(621, 9)
        Me.popPort.Name = "popPort"
        Me.popPort.Size = New System.Drawing.Size(47, 20)
        Me.popPort.TabIndex = 34
        Me.popPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(640, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "minuto(s)."
        '
        'emailTimer
        '
        Me.emailTimer.Location = New System.Drawing.Point(587, 60)
        Me.emailTimer.Name = "emailTimer"
        Me.emailTimer.Size = New System.Drawing.Size(47, 20)
        Me.emailTimer.TabIndex = 32
        Me.emailTimer.Text = "5"
        Me.emailTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(481, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Fazer leitura a cada"
        '
        'viewPasswd
        '
        Me.viewPasswd.Appearance = System.Windows.Forms.Appearance.Button
        Me.viewPasswd.AutoSize = True
        Me.viewPasswd.Image = CType(resources.GetObject("viewPasswd.Image"), System.Drawing.Image)
        Me.viewPasswd.Location = New System.Drawing.Point(652, 117)
        Me.viewPasswd.Name = "viewPasswd"
        Me.viewPasswd.Size = New System.Drawing.Size(38, 22)
        Me.viewPasswd.TabIndex = 30
        Me.viewPasswd.UseVisualStyleBackColor = True
        '
        'passwd
        '
        Me.passwd.Location = New System.Drawing.Point(64, 117)
        Me.passwd.Name = "passwd"
        Me.passwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passwd.Size = New System.Drawing.Size(582, 20)
        Me.passwd.TabIndex = 29
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(64, 92)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(625, 20)
        Me.user.TabIndex = 28
        '
        'smtpAddress
        '
        Me.smtpAddress.Location = New System.Drawing.Point(58, 35)
        Me.smtpAddress.Name = "smtpAddress"
        Me.smtpAddress.Size = New System.Drawing.Size(516, 20)
        Me.smtpAddress.TabIndex = 27
        '
        'ssl
        '
        Me.ssl.AutoSize = True
        Me.ssl.Location = New System.Drawing.Point(15, 64)
        Me.ssl.Name = "ssl"
        Me.ssl.Size = New System.Drawing.Size(46, 17)
        Me.ssl.TabIndex = 26
        Me.ssl.Text = "SSL"
        Me.ssl.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(580, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Porta:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(580, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Porta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Senha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Usuário:"
        '
        'popAddress
        '
        Me.popAddress.Location = New System.Drawing.Point(58, 9)
        Me.popAddress.Name = "popAddress"
        Me.popAddress.Size = New System.Drawing.Size(516, 20)
        Me.popAddress.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "SMTP:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "POP:"
        '
        'EmailSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 153)
        Me.Controls.Add(Me.smtpPort)
        Me.Controls.Add(Me.popPort)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.emailTimer)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.viewPasswd)
        Me.Controls.Add(Me.passwd)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.smtpAddress)
        Me.Controls.Add(Me.ssl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.popAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EmailSetup"
        Me.Text = "EmailSetup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents smtpPort As TextBox
    Friend WithEvents popPort As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents emailTimer As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents viewPasswd As CheckBox
    Friend WithEvents passwd As TextBox
    Friend WithEvents user As TextBox
    Friend WithEvents smtpAddress As TextBox
    Friend WithEvents ssl As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents popAddress As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
