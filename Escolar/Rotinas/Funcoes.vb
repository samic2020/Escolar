Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Management
Imports System.Globalization

Module Funcoes
    Private dbMain As [Db] = New Db

    ' ************************************************************************
    ' ** Finalidade: Converte um valor-texto em Decimal                     **
    ' ************************************************************************
    Function cValor(cValue As String) As Decimal
        If String.IsNullOrEmpty(cValue) Then
            Return Decimal.Parse("0")
            Exit Function
        End If
        Return Format(cValue, "Fixed")
    End Function

    Function OcourCount(valor As String, oQue As String, nQtd As Integer) As Integer
        Dim i As Integer = 0, j As Integer = 0
        Dim achei As Boolean = False

        For i = 0 To valor.Length - 1 Step 1
            If valor.Substring(i, oQue.Length).Equals(oQue) Then j += 1
            If j = nQtd Then
                achei = True
                Exit For
            End If
        Next
        Return IIf(achei, i, -1)
    End Function

    Public Function FuncoesAuxiliares(_nodes As String(), _chave As String) As String
        If Globais.protocolomenu.Equals("") Then Return ""
        For z As Integer = 0 To _nodes.Length - 1
            Dim pos As Integer = Funcoes.OcourCount(_nodes(z), ":", 2)
            Dim _node As String = _nodes(z).Substring(0, pos)
            Dim _setar As Boolean = _chave.Trim.Equals(_node.Trim())
            If _setar Then
                Dim _acesso As String() = _nodes(z).Split(":")
                Dim _sacesso As String = ""
                If InStr(_acesso(2), "|") > 0 Then
                    _sacesso = _acesso(2).Substring(InStr(_acesso(2), "|"))
                End If

                If Not _sacesso.Equals("") Then Return _sacesso
            End If
        Next
        Return ""
    End Function

    Public Function RemoveAllSymbols(value As String) As String
        Dim retorno As String = value.Replace(".", "")
        retorno = retorno.Replace(",", "")
        retorno = retorno.Replace("-", "")
        retorno = retorno.Replace("/", "")
        retorno = retorno.Replace("`", "")
        Return retorno
    End Function

    Public Function ValidateEmail(ByVal strCheck As String) As Boolean
        Try
            Dim vEmailAddress As New System.Net.Mail.MailAddress(strCheck)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function IsValidIP(ByVal ip As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\." &
        "([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$"
        'cria o objeto Regex
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If ip = "" Then
            'ip invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(ip, 0)
        End If
        Return valida
    End Function

    Public Function IsCPF(v As String) As Boolean
        Dim multiplicador1 As Integer() = {10, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim multiplicador2 As Integer() = {11, 10, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim tempCpf As String
        Dim digito As String
        Dim cpf As String
        Dim soma As Integer
        Dim resto As Integer

        cpf = v
        cpf = cpf.Trim()
        cpf = cpf.Replace(".", String.Empty).Replace("-", String.Empty)

        If cpf.Length <> 11 Then Return False

        tempCpf = cpf.Substring(0, 9)
        soma = 0
        For i = 0 To 8
            soma += Integer.Parse(tempCpf(i).ToString()) * multiplicador1(i)
        Next

        resto = soma Mod 11
        If resto < 2 Then
            resto = 0
        Else
            resto = 11 - resto
        End If

        digito = resto.ToString()

        tempCpf = tempCpf + digito

        soma = 0
        For i = 0 To 9
            soma += Integer.Parse(tempCpf(i).ToString()) * multiplicador2(i)
        Next

        resto = soma Mod 11
        If resto < 2 Then
            resto = 0
        Else
            resto = 11 - resto
        End If
        digito = digito + resto.ToString()

        Return cpf.EndsWith(digito)
    End Function

    Public Function IsCNPJ(v As String) As Boolean
        Dim multiplicador1 As Integer() = {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim multiplicador2 As Integer() = {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim soma As Integer
        Dim resto As Integer
        Dim digito As String
        Dim tempCnpj As String

        Dim cnpj As String = v
        cnpj = cnpj.Trim()
        cnpj = cnpj.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty)

        If (cnpj.Length <> 14) Then Return False

        tempCnpj = cnpj.Substring(0, 12)

        soma = 0
        For i = 0 To 11
            soma += Integer.Parse(tempCnpj(i).ToString()) * multiplicador1(i)
        Next

        resto = (soma Mod 11)
        If resto < 2 Then
            resto = 0
        Else
            resto = 11 - resto
        End If
        digito = resto.ToString()

        tempCnpj = tempCnpj + digito
        soma = 0
        For i = 0 To 12
            soma += Integer.Parse(tempCnpj(i).ToString()) * multiplicador2(i)
        Next
        resto = (soma Mod 11)
        If (resto < 2) Then
            resto = 0
        Else
            resto = 11 - resto
        End If
        digito = digito + resto.ToString()

        Return cnpj.EndsWith(digito)
    End Function

    Sub ExtructBoleta(ByRef ds As DataSet, ByRef bl As DataTable)
        bl.Columns.Add("Beneficiario", GetType(String))
        bl.Columns.Add("BenefCNPJ", GetType(String))
        bl.Columns.Add("BenefAgCodigo", GetType(String))
        bl.Columns.Add("Parcelas", GetType(String))
        bl.Columns.Add("NNumero", GetType(String))
        bl.Columns.Add("NumDoc", GetType(String))
        bl.Columns.Add("Vencimento", GetType(String))
        bl.Columns.Add("Valor", GetType(String))
        bl.Columns.Add("BenefEndereco", GetType(String))
        bl.Columns.Add("PagadorNome", GetType(String))
        bl.Columns.Add("PagadorCPFCNPJ", GetType(String))
        bl.Columns.Add("PagadorEndereco", GetType(String))
        bl.Columns.Add("PagadorCep", GetType(String))
        bl.Columns.Add("PagadorBairro", GetType(String))
        bl.Columns.Add("PagadorCidade", GetType(String))
        bl.Columns.Add("PagadorEstado", GetType(String))
        bl.Columns.Add("Carteira", GetType(String))
        bl.Columns.Add("LinhaDigitavel", GetType(String))
        bl.Columns.Add("CodigoBarras", GetType(String))
        bl.Columns.Add("Msg01", GetType(String))
        bl.Columns.Add("Msg02", GetType(String))
        bl.Columns.Add("Msg03", GetType(String))
        bl.Columns.Add("Msg04", GetType(String))
        bl.Columns.Add("Msg05", GetType(String))
        bl.Columns.Add("Msg06", GetType(String))
        bl.Columns.Add("Msg07", GetType(String))
        bl.Columns.Add("Msg08", GetType(String))
        bl.Columns.Add("Msg09", GetType(String))
        bl.Columns.Add("Msg10", GetType(String))
        bl.Columns.Add("DataDoc", GetType(Date))
        bl.Columns.Add("Tarifa", GetType(Decimal))
        bl.Columns.Add("Banco", GetType(String))
        bl.Columns.Add("BancoDv", GetType(String))
        bl.Columns.Add("LogoBco", GetType(Byte()))
        bl.Columns.Add("CodigoBarrasImg", GetType(Byte()))
        ds.Tables.Add(bl)
    End Sub

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean
        ' Pattern ou mascara de verificação
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        ' Verifica se o email corresponde a pattern/mascara
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)

        ' Caso corresponda
        Return emailAddressMatch.Success
    End Function

    Public Function DiadaSemana(value As Date) As Integer
        Dim nDiaSem As Integer = value.DayOfWeek
        Dim retorno As Integer = -1
        Select Case nDiaSem
            Case 0
                retorno = 6
            Case 1
                retorno = 0
            Case 2
                retorno = 1
            Case 3
                retorno = 2
            Case 4
                retorno = 3
            Case 5
                retorno = 4
            Case 6
                retorno = 5
        End Select
        Return retorno
    End Function

    Public Function Resolucao() As Size
        Return New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
    End Function

    Public Function MensagemBuild(value As String) As String
        value = value.Replace("[DESCONTO]", Globais.dadosAdm.Item("Desconto").ToString.Trim)
        Return value
    End Function

    Public Function StrZero(value As String, length As Integer) As String
        Dim zeros As String = StrDup(length, "0")
        Return Right(zeros & value.Trim, length)
    End Function

    Public Function PadL(value As String, Optional fill As String = " ", Optional length As Integer = 1) As String
        Dim tfill As String = StrDup(length, fill)
        Return Right(tfill & value.Trim, length)
    End Function

    Public Function PadR(value As String, Optional fill As String = " ", Optional length As Integer = 1) As String
        Dim tfill As String = StrDup(length, fill)
        Return Right(value.Trim & tfill, length)
    End Function

    Public Function PadC(value As String, Optional fill As String = " ", Optional length As Integer = 1) As String
        Dim nEsquerdo As Integer = (length - value.Trim.Length) / 2
        Dim nDireito As Integer = (length - value.Trim.Length) / 2
        If (nEsquerdo + value.Length + nDireito) <> length Then nDireito += 1
        Return StrDup(nEsquerdo, fill) & value.Trim & StrDup(nDireito, fill)
    End Function

    Public Function RemoveSimbols(_value As String) As String
        Dim retorno As String = ""
        For i = 0 To _value.Length - 1
            Dim iChar As Integer = Strings.Asc(_value.ToUpper.Substring(i, 1))
            If (iChar < 65 Or iChar > 90) Or (iChar < 48 Or iChar > 57) Then
                Continue For
            End If
            retorno += _value.ToUpper.Substring(i, 1)
        Next
        Return retorno
    End Function

    Public Function RetornaTelefone(_value As String) As String
        Dim retorno As String = ""
        For i = 0 To _value.Length - 1
            Dim iChar As Integer = Strings.Asc(_value.ToUpper.Substring(i, 1))
            If (iChar < 48 Or iChar > 57) Then
                Continue For
            End If
            retorno += _value.ToUpper.Substring(i, 1)
        Next
        Return retorno
    End Function

    Public Function RemoveAcentos(ByVal texto As String) As String
        Dim charFrom As String = "ŠŒŽšœžŸ¥µÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýÿ"
        Dim charTo As String = "SOZsozYYuAAAAAAACEEEEIIIIDNOOOOOOUUUUYsaaaaaaaceeeeiiiionoooooouuuuyy"
        For i As Integer = 0 To charFrom.Length - 1
            texto = Replace(texto, charFrom(i), charTo(i))
        Next
        Return texto
    End Function

    Function SafeFileDelete(ByVal FileName As String) As Boolean
        If My.Computer.FileSystem.FileExists(FileName) Then
            For i As Integer = 1 To 10
                Try
                    File.Delete(FileName)
                    Exit For
                Catch ex As Exception
                    If i = 10 Then
                        MsgBox("Unable to delete file " & FileName & " after 10 tries over 10 seconds. Exception says " & ex.Message)
                    Else
                        Threading.Thread.Sleep(1000)    ' same as Threading.Thread.Sleep(1000)
                    End If
                End Try
            Next
        End If

        Return File.Exists(FileName)
    End Function

    Public Function MacAddress2() As String
        Dim nmMac As String = String.Empty
        Dim mc As System.Management.ManagementClass
        Dim mo As System.Management.ManagementBaseObject
        mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim moc As Management.ManagementObjectCollection = mc.GetInstances
        For Each mo In moc
            Dim isMacEnabled As Boolean = mo.Item("IPenabled")
            If isMacEnabled Then
                nmMac = mo.Item("MacAddress")
            End If
        Next
        Return nmMac
    End Function

    Public Function MacAddress() As String
        Dim mo_HD As ManagementObject
        Try
            mo_HD = DiscoInfo("C")
            mo_HD.Get()
            'Pega o Serial
            Return mo_HD("VolumeSerialNumber").ToString()
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Function DiscoInfo(ByVal strDrive As String) As ManagementObject
        'Verifica se a letra do drive foi informada. O padrão é a letra C
        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Try
            'Usa Win32_LogicalDisk para obter as propriedades do HD
            Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")
            Return moHD
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function IndexOf(param As Object()(), collumn As Integer, seek As String) As Integer
        Dim retorno As Integer = -1

        If param.Length > 0 Then
            For i = 0 To param.Length - 1
                If param(i)(collumn) = seek Then
                    retorno = i
                    Exit For
                End If
            Next
        End If

        Return retorno
    End Function

    Public Function RemoverAcentuacao(ByVal text As String) As String
        Return New String(text.Normalize(NormalizationForm.FormD).Where(Function(ch) Char.GetUnicodeCategory(ch) <> UnicodeCategory.NonSpacingMark).ToArray())
    End Function
End Module
