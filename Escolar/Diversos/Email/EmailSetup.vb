Public Class EmailSetup
    Private dbMain As [Db] = New Db

    Private Sub viewPasswd_CheckedChanged(sender As Object, e As EventArgs) Handles viewPasswd.CheckedChanged
        If viewPasswd.Checked Then
            passwd.PasswordChar = ""
        Else
            passwd.PasswordChar = "*"
        End If
    End Sub

    Private Sub popAddress_TextChanged(sender As Object, e As EventArgs) Handles popAddress.TextChanged
        dbMain.lergravarPARAM({"POP", popAddress.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub smtpAddress_TextChanged(sender As Object, e As EventArgs) Handles smtpAddress.TextChanged
        dbMain.lergravarPARAM({"SMTP", smtpAddress.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub ssl_CheckedChanged(sender As Object, e As EventArgs) Handles ssl.CheckedChanged
        dbMain.lergravarPARAM({"SSL", IIf(ssl.Checked, "TRUE", "FALSE"), "LOGICO"}, False)
    End Sub

    Private Sub emailTimer_TextChanged(sender As Object, e As EventArgs) Handles emailTimer.TextChanged
        dbMain.lergravarPARAM({"EMAILTIMER", emailTimer.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub user_TextChanged(sender As Object, e As EventArgs) Handles user.TextChanged
        dbMain.lergravarPARAM({"EMAILUSER", user.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub passwd_TextChanged(sender As Object, e As EventArgs) Handles passwd.TextChanged
        dbMain.lergravarPARAM({"EMAILPWD", passwd.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub EmailSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        popAddress.Text = dbMain.lergravarPARAM({"POP"})
        popPort.Text = dbMain.lergravarPARAM({"POPPORT"})
        smtpAddress.Text = dbMain.lergravarPARAM({"SMTP"})
        smtpPort.Text = dbMain.lergravarPARAM({"SMTPPORT"})
        ssl.Checked = IIf(dbMain.lergravarPARAM({"SSL"}) = "TRUE", True, False)
        emailTimer.Text = dbMain.lergravarPARAM({"EMAILTIMER"})
        user.Text = dbMain.lergravarPARAM({"EMAILUSER"})
        passwd.Text = dbMain.lergravarPARAM({"EMAILPWD"})
    End Sub

    Private Sub smtpPort_TextChanged_1(sender As Object, e As EventArgs) Handles smtpPort.TextChanged
        dbMain.lergravarPARAM({"SMTPPORT", smtpPort.Text.Trim, "TEXTO"}, False)
    End Sub

    Private Sub popPort_TextChanged_1(sender As Object, e As EventArgs) Handles popPort.TextChanged
        dbMain.lergravarPARAM({"POPPORT", popPort.Text.Trim, "TEXTO"}, False)
    End Sub
End Class