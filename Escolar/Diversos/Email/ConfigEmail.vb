Public Class ConfigEmail
    Private Sub btnAlterar_Click(sender As Object, e As EventArgs) Handles btnAlterar.Click
        btnAlterar.Enabled = False
        btnGravar.Enabled = True
        btnRetornar.Enabled = True

        Enabled(True)
        emailAddressPedido.Focus()
    End Sub

    Private Sub Enabled(value As Boolean)
        '// E-Mail - parametros
        emailAddressPedido.Enabled = value
        emailPwd.Enabled = value
        emailSmtp.Enabled = value
        emailPort.Enabled = value
        emailSsl.Enabled = value
    End Sub

    Private Sub Ler()
        '// E-Mail - parametros
        emailAddressPedido.Text = Setting.Load("eAddress", "pedido@mundoemduasrodas.com.br")
        emailPwd.Text = Setting.Load("ePwd", "mM@12345678")
        emailSmtp.Text = Setting.Load("eSmtp", "mail.mundoemduasrodas.com.br")
        emailPort.Text = Setting.Load("ePort", "587")
        emailSsl.Checked = CBool(Setting.Load("eSSL", "False"))
    End Sub

    Private Sub Gravar()
        '// E-Mail - parametros
        Setting.Store("eAddress", emailAddressPedido.Text)
        Setting.Store("ePwd", emailPwd.Text)
        Setting.Store("eSmtp", emailSmtp.Text)
        Setting.Store("ePort", emailPort.Text)
        Setting.Store("eSSL", If(emailSsl.Checked, "True", "False"))
    End Sub

    Private Sub Update()
        '// E-Mail - parametros
        Globais.emailAddress = emailAddressPedido.Text
        Globais.emailPassWord = emailPwd.Text
        Globais.emailSmtp = emailSmtp.Text
        Globais.emailSmtpPort = emailPort.Text
        Globais.emailSmtpSsl = If(emailSsl.Checked, "True", "False")
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        btnAlterar.Enabled = True
        btnGravar.Enabled = False
        btnRetornar.Enabled = True
        Gravar()
        Update()
        Enabled(False)
    End Sub

    Private Sub btnRetornar_Click(sender As Object, e As EventArgs) Handles btnRetornar.Click
        If Not btnAlterar.Enabled Then
            If MsgBox("Você perdera as asterações digitadas." & vbNewLine & "Continua?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Atenção!") = MsgBoxResult.No Then
                Return
            End If
        End If

        Dispose()
    End Sub

    Private Sub ConfigEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Enabled(False)
        Ler()
        btnAlterar.Enabled = True
        btnGravar.Enabled = False
        btnRetornar.Enabled = True
    End Sub
End Class