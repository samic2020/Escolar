Module Auditor
    Private dbMain As [Db] = New Db

    Public Sub auditor(modulo As String, operacao As String, Optional novo As String = "", Optional velho As String = "")
        Dim sql As String = "INSERT INTO auditor (datahora, usuario, modulo, operacao, novo, velho) VALUES (@datahora, @usuario, @modulo, @operacao, @novo, @velho)"
        Dim param As Object()() = New Object()() {
            ({"@datahora", Now}),
            ({"@usuario", Strings.Mid(Globais.usuario, 1, 25)}),
            ({"@modulo", Strings.Mid(modulo.Trim.ToUpper, 1, 50)}),
            ({"@operacao", Strings.Mid(operacao.Trim.ToUpper, 1, 50)}),
            ({"@novo", novo}),
            ({"@velho", velho})
        }

        '// Cria Banco de dados caso não exista
        CreateAuditor()
        '// Grava Registro
        dbMain.ExecuteCmd(sql, param)
    End Sub

    Private Sub CreateAuditor()
        Dim createSQL As String = "CREATE TABLE IF NOT EXISTS auditor (id int(11) NOT NULL AUTO_INCREMENT, datahora datetime DEFAULT NULL, usuario varchar(25) DEFAULT NULL, " &
                                  "modulo varchar(50) DEFAULT NULL, operacao varchar(50) DEFAULT NULL, novo longtext, velho longtext, PRIMARY KEY (id)) " &
                                  "ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;"
        dbMain.ExecuteCmd(createSQL)
    End Sub

    Public Function getCampos(Form As Form)
        Dim campos As Object
        For Each Controle In Form.Controls
            If TypeOf Controle Is TextBox Then
                campos = campos + Controle.Text + "| "
            End If
            If TypeOf Controle Is ComboBox Then
                campos = campos + Controle.Text + "| "
            End If
            If TypeOf Controle Is CheckBox Then
                campos = campos + Str(Controle.value) + "| "
            End If
        Next

        Return Split(campos, "|")
    End Function

    Public Sub difCampos(ctrl1 As Object, ctrl2 As Object, modulo As String, operacao As String)
        For i = 0 To UBound(ctrl1)
            If ctrl1(i) <> ctrl2(i) Then
                auditor(modulo, operacao, Trim(ctrl2(i)), Trim(ctrl1(i)))
            End If
        Next
    End Sub

End Module
