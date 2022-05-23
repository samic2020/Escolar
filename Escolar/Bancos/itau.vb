Imports System.IO

Public Class itau
    Private dbMain As [Db] = New Db

    Public Function NossoNumero(value As String, tam As Integer) As String
        Dim bco As New bancos
        bco.LerBanco("341")

        Dim valor1 As String = Right(StrDup(tam - 1, "0") + Integer.Parse(value).ToString().Trim(), tam - 1)
        Dim valor3 As String = bco.getAgencia() + bco.getConta() + bco.getCarteira() + valor1
        Dim valor2 As String = bco.CalcDig10(valor3)
        Return valor1 + valor2
    End Function

    Private Function fatorvencimento(vencimento As String) As String
        Dim retorno As String
        If Len(vencimento) < 8 Then
            retorno = "0000"
        Else
            retorno = DateDiff(DateInterval.Day, CDate("1997/10/07"), CDate(vencimento)).ToString
        End If
        Return retorno
    End Function

    Private Function CALCDIG11(cadeia As String, limitesup As Integer, lflag As Integer) As Integer
        Dim mult As Integer = 1 + (Len(cadeia) Mod (limitesup - 1))
        If mult = 1 Then
            mult = limitesup
        End If
        Dim total As Integer = 0
        For pos = 1 To Len(cadeia)
            total = total + (Mid(cadeia, pos, 1) * mult)
            mult = mult - 1
            If mult = 1 Then
                mult = limitesup
            End If
        Next
        Dim nresto As Integer = (total Mod 11)
        Dim ndig As Integer
        Dim result As Integer
        If lflag = 1 Then
            result = 11 - nresto
            If result = 0 Or result = 1 Or result = 10 Then
                ndig = 1
            Else
                ndig = result
            End If
        Else
            result = 11 - nresto
            If result > 9 Then
                ndig = 0
            Else
                ndig = result
            End If
        End If

        Return ndig
    End Function

    Public Function CodBar(vencimento As String, valor As String, nossonumero As String) As String
        Dim bco As New bancos
        bco.LerBanco("341")

        Dim strcodbar As String
        Dim dv3 As String
        strcodbar = bco.getBanco() + bco.getMoeda() +
                    fatorvencimento(vencimento) +
                    bco.Valor4Boleta(valor) +
                    bco.getCarteira() + nossonumero + bco.getAgencia() +
                    bco.getConta() + bco.getCtaDv() + "000"
        dv3 = CALCDIG11(strcodbar, 9, 0)
        Return bco.getBanco() + bco.getMoeda() + dv3 +
               fatorvencimento(vencimento) +
               bco.Valor4Boleta(valor) + bco.getCarteira() + nossonumero +
               bco.getAgencia() + bco.getConta() + bco.getCtaDv() + "000"
    End Function

    Public Function LinhaDigitavel(codigobarras As String) As String
        Dim bco As New bancos
        bco.LerBanco("341")

        Dim cmplivre As String
        Dim campo1 As String, campo2 As String, campo3 As String, campo4 As String, campo5 As String

        cmplivre = codigobarras.Substring(19, 44)
        campo1 = codigobarras.Substring(0, 4) + cmplivre.Substring(0, 5)
        campo1 += bco.CalcDig10(campo1)
        campo1 = campo1.Substring(0, 5) + "." + campo1.Substring(5, 10)

        campo2 = cmplivre.Substring(5, 15)
        campo2 += bco.CalcDig10(campo2)
        campo2 = campo2.Substring(0, 5) + "." + campo2.Substring(5, 11)

        campo3 = cmplivre.Substring(15, 25)
        campo3 += bco.CalcDig10(campo3)
        campo3 = campo3.Substring(0, 5) + "." + campo3.Substring(5, 11)

        campo4 = codigobarras.Substring(4, 5)

        campo5 = codigobarras.Substring(5, 19)

        If Convert.ToInt32(campo5) = 0 Then campo5 = "000"

        Return campo1 + "  " + campo2 + "  " + campo3 + "  " + campo4 + "  " + campo5
    End Function

    Public Sub Remessa(nrlote As String, movimento As String, Boletas As DataGridView)
        Dim bco As New bancos
        bco.LerBanco("341")

        If Not Directory.Exists(Globais.remPath) Then
            Directory.CreateDirectory(Globais.remPath)
        End If
        Dim fileRemessa As String = Globais.remPath & "\" & bco.getRemessa() & bco.getBanco() & "_Remessa_" & nrlote & ".REM"

        Dim ctalinhas As Integer = 1
        Using writer As New StreamWriter(fileRemessa, True)
            '// REGISTRO TIPO '0'
            writer.WriteLine(
                bco.getBanco().PadLeft(3, "0") &
                "0000" &
                "0" &
                Space(9) &
                IIf(Len(RmvSimbols(Globais.dadosAdm.Item("Cnpj").ToString.Replace(".", "").Replace("/", "").Replace("-", ""), "CPFCNPJ")) = 11, "1", "2") &
                Globais.dadosAdm.Item("Cnpj").ToString.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(15, "0") &
                bco.getAgencia().PadLeft(4, "0") & StrZero(bco.getIdentificacao(), 11) &
                Space(20) &
                bco.rmvAcentos(Globais.dadosAdm.Item("Razao").ToString.ToUpper.PadRight(30, " ")) &
                bco.rmvAcentos(bco.getNomeBanco()).PadRight(30, " ") &
                Space(10) &
                "1" &
                Format(Now, "ddMMyyyy") &
                Space(6) &
                StrZero(nrlote, 6) &
                "040" &
                Space(74)
            )

            ctalinhas += 1

            '// REGISTRO TIPO '1'
            writer.WriteLine(
                bco.getBanco().PadLeft(3, "0") &
                "0001" &
                "1" &
                "R" &
                "01" &
                Space(2) &
                "030" &
                Space(1) &
                IIf(Len(RmvSimbols(Globais.dadosAdm.Item("Cnpj").ToString.Replace(".", "").Replace("/", "").Replace("-", ""), "CPFCNPJ")) = 11, "1", "2") &
                Globais.dadosAdm.Item("Cnpj").ToString.Replace(".", "").Replace("/", "").Replace("-", "").PadLeft(15, "0") &
                Space(20) &
                bco.getAgencia().PadLeft(4, "0") & StrZero(bco.getIdentificacao(), 11) &
                Space(5) &
                bco.rmvAcentos(Globais.dadosAdm.Item("Razao").ToString.ToUpper).PadRight(30, " ") &
                Space(40) &
                Space(40) &
                "00000000" &
                Format(Now, "ddMMyyyy") &
                Space(41)
            )

            ctalinhas += 1

            For Each item As DataGridViewRow In Boletas.SelectedRows
                Dim newmvalordoc As Decimal
                '// Para cobrar tarifa
                Dim vrtarifa = CDec(item.Cells(13).Value.ToString)
                If vrtarifa > 0 Then
                    newmvalordoc = CDec(item.Cells(5).Value.ToString) + vrtarifa
                Else
                    newmvalordoc = CDec(item.Cells(5).Value.ToString)
                End If
                Dim vrtitulo_ = Valor2Boleta(Format(newmvalordoc, "#,##0.00"))

                Dim vrdesconto As Decimal = CDec(item.Cells(5).Value.ToString) * 0.1
                Dim vrdesconto_ = Valor2Boleta(Format(vrdesconto, "#,##0.00"))

                Dim vrmordia As Decimal
                vrmordia = newmvalordoc * 0.0033
                Dim jurmordia_ As String = Valor2Boleta(Format(vrmordia, "#,##0.00"))

                '// REGISTRO TIPO 'P'
                writer.WriteLine(
                    bco.getBanco().PadLeft(3, "0") &
                    "0001" &
                    "3" &
                    StrZero(CStr(ctalinhas - 2), 5) &
                    "P" &
                    Space(1) &
                    Strings.Mid(movimento, 1, 2) &
                    bco.getAgencia().PadRight(4) &
                    CALCDIG11(bco.getAgencia(), 9, 0).ToString.PadRight(1) &
                    bco.getCtaDv().PadLeft(1, "0") &
                    bco.getConta().PadLeft(9, "0") &
                    bco.getCtaDv().PadLeft(1, "0") &
                    bco.getConta().PadLeft(9, "0") &
                    Space(2) &
                    NossoNumero(item.Cells(2).Value.ToString.Trim, 13).Trim &
                    "5" &
                    "1" &
                    "2" &
                    Space(1) &
                    Space(1) &
                    item.Cells(0).Value.ToString.PadRight(15, " ") &
                    Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy")) &
                    vrtitulo_ &
                    "0000" &
                    "0" &
                    Space(1) &
                    "04" & '// 04 - Duplicata de Serviço || 17 - Recibo
                    "N" &
                    Format(Now, "ddMMyyyy") &
                    "1" &
                    Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy")) &
                    jurmordia_ &
                    "1" & '// Codigo desconto
                    Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy")) & '// data desconto
                    vrdesconto_ & '// "000000000000000" & '// valor ou percentual de comissao
                    "000000000000000" & '// iof
                    "000000000000000" & '// valor abatimento
                    Space(25) &
                    "0" & '// codigo para protesto
                    "00" & '// numero de dias para proteste
                    "1" & '// codigo baixa devolucao (2)
                    "0" &
                    "15" & '// numero de dias baixa devolução
                    "00" & '// codigo moeda
                    Space(11)
                )

                ctalinhas += 1

                If Strings.Mid(movimento, 1, 2) = "01" Then
                    Dim tipoinscpag_ As String = IIf(Len(RmvSimbols(item.Cells(7).Value.ToString, "CPFCNPJ")) = 11, "1", "2") '// 1 - CPF / 2 - CNPJ
                    Dim inscpagador_ As String = Strings.Right(StrDup(15, "0") & RmvSimbols(item.Cells(7).Value.ToString, "CPFCNPJ"), 15)
                    Dim nomepagador_ As String = Strings.Mid(MyLetras(item.Cells(4).Value.ToString) & Space(40), 1, 40)
                    Dim enderecopag_ As String = Strings.Mid(MyLetras(item.Cells(8).Value.ToString) & Space(40), 1, 40)
                    Dim bairropag_ As String = Strings.Mid(MyLetras(item.Cells(9).Value.ToString) & Space(15), 1, 15)
                    Dim ceppagador_ As String = Strings.Mid(MyLetras(item.Cells(12).Value.ToString) & Space(9), 1, 5)
                    Dim sufceppag_ As String = Strings.Mid(MyLetras(item.Cells(12).Value.ToString) & Space(9), 7, 3)
                    Dim cidadepag_ As String = Strings.Mid(MyLetras(item.Cells(10).Value.ToString) & Space(15), 1, 15)
                    Dim estpag_ As String = Strings.Mid(MyLetras(item.Cells(11).Value.ToString) & Space(2), 1, 2)

                    '// REGISTRO TIPO 'Q'
                    writer.WriteLine(
                        bco.getBanco().PadLeft(3, "0") &
                        "0001" &
                        "3" &
                        StrZero(CStr(ctalinhas - 2), 5) &
                        "Q" &
                        Space(1) &
                        Strings.Mid(movimento, 1, 2) & '// 01 - Entrada de titulo | 02 - Baixa de titulo
                        tipoinscpag_ & '// 1 - CPF | 2 - CNPJ
                        inscpagador_ & '// CPF ou CNPJ
                        nomepagador_ & '// Nome do Cliente
                        enderecopag_ & '// Endereco
                        bairropag_ & '// Bairro
                        ceppagador_ & sufceppag_ & '// Cep Ex.: 24400-000 <-> 24400000
                        cidadepag_ & '// Cidade
                        estpag_ & '// Uf
                        "0" &
                        "000000000000000" &
                        Space(40) &
                        "000" &
                        "000" &
                        "000" &
                        "000" &
                        Space(19)
                    )

                    ctalinhas += 1

                    '// REGISTRO TIPO 'R'
                    writer.WriteLine(
                        bco.getBanco().PadLeft(3, "0") &
                        "0001" &
                        "3" &
                        StrZero(CStr(ctalinhas - 2), 5) &
                        "R" &
                        Space(1) &
                        Strings.Mid(movimento, 1, 2) &
                        "0" & '// codigo desconto
                        "00000000" & '// data desconto
                        "000000000000000" & '// valor perc desco
                        "0" &
                        "00000000" &
                        "000000000000000" &
                        "2" & '// codigo multa 1 - valor fixo | 2 - percentual
                        Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy")) & '// data multa
                        "10".PadLeft(15, "0") & '// percentual ou valor multa 0,33
                        Space(10) &
                        Space(40) &
                        Space(40) &
                        Space(61)
                    )

                    ctalinhas += 1

                    '// Mensagens da boleta de 01 a 09
                    Dim msg As String() = {"", "", "", "", "", "", "", "", ""}
                    Dim ctamsg As Integer = 1
                    For m = 0 To msg.Length - 1
                        '// REGISTRO TIPO 'S'
                        writer.WriteLine(
                            bco.getBanco().PadLeft(3, "0") &
                            "0001" &
                            "3" &
                            StrZero(CStr(ctalinhas - 2), 5) &
                            "S" &
                            Space(1) &
                            Strings.Mid(movimento, 1, 2) &
                            "1" &
                            StrZero(CStr(ctamsg), 2) &
                            "4" &
                            msg(m).PadRight(100, " ") &
                            Space(119)
                        )

                        ctamsg += 1
                        ctalinhas += 1
                    Next
                End If
            Next

            '// REGISTRO TIPO '5' - trailer lote
            writer.WriteLine(
                bco.getBanco().PadLeft(3, "0") &
                "0001" &
                "5" &
                Space(9) &
                StrZero(CStr(ctalinhas - 1), 6) &
                Space(217)
            )

            '// REGISTRO TIPO '9' - trailer arquivo
            writer.WriteLine(
                bco.getBanco().PadLeft(3, "0") &
                "9999" &
                "9" &
                Space(9) &
                "000001" & '// quantidade de lotes do arquivo
                StrZero(CStr(ctalinhas + 1), 6) &
                Space(211)
            )
        End Using

        '// Avisar ao arquivo que já foi gerado remessa para esta nf/vecto
        For Each item As DataGridViewRow In Boletas.SelectedRows
            Dim updateSql As String = "UPDATE contas SET tx = '1' WHERE ntfiscal = @ntfiscal AND dtvenc = @dtvenc"
            dbMain.ExecuteCmd(updateSql, New Object()() {
                ({"@ntfiscal", item.Cells(0).Value.ToString}),
                ({"@dtvenc", Format(item.Cells(3).Value, "yyyy/MM/dd")})
            })
        Next
    End Sub

    Private Function convValor(Optional cValor As String = "0")
        If cValor = "0" Then convValor = "0000000000" : Exit Function
        Dim mValor As String, nConta As Integer
        For nConta = 1 To Len(cValor)
            If InStr(".,", Mid(cValor, nConta, 1)) <= 0 Then
                mValor = mValor & Mid(cValor, nConta, 1)
            End If
        Next nConta

        Return Strings.Right("0000000000" & mValor, 10)
    End Function

    Private Function CalBarras(cons_agencia As String, cons_conta As String, var_nossonumero As String, var_valordocumento As String,
                        var_datavencimento As String, cons_banco As String, cons_moeda As String) As String()

        Dim dvnossonumero As String = CALCDIG11(var_nossonumero, 9, 0)
        Dim dvagconta As String = "0"

        Dim valorvalor1 As String = var_valordocumento
        Dim valorvalor2 As String = Replace(valorvalor1, ",", "")
        valorvalor2 = Replace(valorvalor2, ".", "")
        Dim valorvalor3 As Integer = Len(valorvalor2)
        Dim valorvalor4 As Integer = 10 - valorvalor3
        Dim var_valor As String = StrDup(valorvalor4, "0") & ("" & valorvalor2 & "")
        If CDbl(valorvalor1) = 0 Then
            var_valor = "0000000000"
        End If

        Dim var_fatorvencimento As String = fatorvencimento("" & var_datavencimento & "")
        If var_fatorvencimento = "0000" Then
            var_datavencimento = "Contra Apresentação"
        End If

        Dim var_codigobarras As String = CodBar("" & var_datavencimento & "",
                                  "" & var_valor & "",
                                  "" & Strings.Right(var_nossonumero & dvnossonumero, 13) & "")

        Dim var_linhadigitavel As String = LinhaDigitavel(var_codigobarras)

        Return {var_codigobarras, var_linhadigitavel, Strings.Right(var_nossonumero, 12) & dvnossonumero}
    End Function

    Public Sub Imprimir(ds As DataSet)
        RepoCotacao.Text = "Preview - Boleta"
        RepoCotacao.WindowState = 2
        RepoCotacao.Boleta(ds)
        RepoCotacao.ShowDialog()
    End Sub

    Public Function Boleta(nossonumero As String, mnomesacado As String, mcpfcnpj As String, mendereco As String, nrcep As String, nrcepc As String, mbairro As String,
                          mcidade As String, mestado As String, mvencimento As Date, mvalordoc As String, msgpadrao As String, nrDoc As String, tarifa As Decimal,
                           Optional troca As Boolean = False, Optional nbanco As String = "033") As Object()()
        Dim msg1 As String, msg2 As String, msg3 As String
        Dim msg4 As String, msg5 As String, msg6 As String
        Dim msg7 As String, msg8 As String, msg9 As String
        Dim msg10 As String, msg11 As String, msg12 As String
        Dim msg13 As String, msg14 As String, msg15 As String
        Dim tmsg1 As String, tmsg2 As String

        msg1 = " "
        msg2 = " "
        msg3 = " "
        msg4 = " "
        msg5 = " "
        msg6 = " "
        msg7 = " "
        msg8 = " "
        msg9 = " "
        msg10 = " "
        msg11 = " "
        msg12 = " "
        msg13 = " "
        msg14 = " "
        msg15 = " "
        tmsg1 = " "
        tmsg2 = " "

        msg8 = msgpadrao

        On Error Resume Next
        msg3 = dbMain.lergravarPARAM({"MSG1"})
        On Error GoTo 0

        On Error Resume Next
        msg4 = dbMain.lergravarPARAM({"MSG2"})
        On Error GoTo 0

        On Error Resume Next
        msg5 = dbMain.lergravarPARAM({"MSG3"})
        On Error GoTo 0

        On Error Resume Next
        msg6 = dbMain.lergravarPARAM({"MSG4"})
        On Error GoTo 0

        'If IsEmpty(msg1) Or IsNull(msg1) Then msg1 = " "
        'If IsEmpty(msg2) Or IsNull(msg2) Then msg2 = " "
        'If IsEmpty(msg3) Or IsNull(msg3) Then msg3 = " "
        'If IsEmpty(msg4) Or IsNull(msg4) Then msg4 = " "
        'If IsEmpty(msg5) Or IsNull(msg5) Then msg5 = " "
        'If IsEmpty(msg6) Or IsNull(msg6) Then msg6 = " "
        'If IsEmpty(msg7) Or IsNull(msg7) Then msg7 = " "
        'If IsEmpty(msg8) Or IsNull(msg8) Then msg8 = " "
        'If IsEmpty(msg9) Or IsNull(msg9) Then msg9 = " "
        'If IsEmpty(msg10) Or IsNull(msg10) Then msg10 = " "
        'If IsEmpty(msg11) Or IsNull(msg11) Then msg11 = " "
        'If IsEmpty(msg12) Or IsNull(msg12) Then msg12 = " "
        'If IsEmpty(msg13) Or IsNull(msg13) Then msg13 = " "
        'If IsEmpty(msg14) Or IsNull(msg14) Then msg14 = " "
        'If IsEmpty(msg15) Or IsNull(msg15) Then msg15 = " "

        tmsg1 = "PAGAVEL EM QUALQUER BANCO, CASAS LOTERICAS E AG.CAIXA"
        tmsg2 = ""

        Dim nsnumero As String
        nsnumero = "" & nossonumero

        '* Dados
        Dim banco As bancos = New bancos
        banco.LerBanco(nbanco)

        '* Dados Banco
        Dim magced As String = banco.getAgencia
        Dim mctaced As String = banco.getIdentificacao
        Dim mdacced As String = banco.getIdentDv

        Dim vrtarifa As Decimal = tarifa
        Dim newmvalordoc As String
        If vrtarifa > 0 Then
            newmvalordoc = Format(CDec(mvalordoc) + vrtarifa, "#,##0.00")
            msg7 = "Tarifa Bancária já Inclusa"
        Else
            newmvalordoc = Format(CDec(mvalordoc), "#,##0.00")
        End If

        Dim barras_bco As String() = CalBarras(magced, mctaced & mdacced, nsnumero, newmvalordoc, mvencimento, banco.getBanco, "9")

        Dim digitavel As String = barras_bco(1)
        Dim imprimivel As String = barras_bco(0)
        Dim nnsnumero As String = barras_bco(2)

        '// Codigo de Barras proprio - 27-08-2020 11h25m
        Dim cb As C2of5i = New C2of5i(imprimivel, 1, 50, imprimivel.Length)

        Dim cEndereco As String = Globais.dadosAdm.Item("Endereco").ToString.Trim.ToUpper & ", " & Globais.dadosAdm.Item("Numero").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Bairro").ToString.Trim.ToUpper + " - " &
        Globais.dadosAdm.Item("Cidade").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Estado").ToString.Trim.ToUpper & " - CEP " & Globais.dadosAdm.Item("Cep").ToString.Trim.ToUpper

        Dim nDoc As String = Strings.Mid(nrDoc, 1, nrDoc.ToString.IndexOf(" "))
        Dim cParc As String = Strings.Mid(nrDoc, nrDoc.ToString.IndexOf(" ") + 2)
        Dim parametros As Object()() = {
            ({"Beneficiario", Globais.dadosAdm.Item("Razao").ToString.ToUpper.Trim}),
            ({"BenefCNPJ", Globais.dadosAdm.Item("Cnpj").ToString.Trim.ToUpper}),
            ({"BenefAgCodigo", magced & " / " & mctaced}),
            ({"Parcelas", cParc}),
            ({"NNumero", nnsnumero}),
            ({"NumDoc", nDoc}),
            ({"Vencimento", Format(mvencimento, "dd/MM/yyyy")}),
            ({"Valor", newmvalordoc}),
            ({"BenefEndereco", cEndereco}),
            ({"PagadorNome", mnomesacado}),
            ({"PagadorCPFCNPJ", mcpfcnpj}),
            ({"PagadorEndereco", mendereco}),
            ({"PagadorCep", nrcep & "-" & nrcepc}),
            ({"PagadorBairro", mbairro}),
            ({"PagadorCidade", mcidade}),
            ({"PagadorEstado", mestado}),
            ({"Carteira", "104"}),
            ({"LinhaDigitavel", digitavel}),
            ({"CodigoBarras", imprimivel}),
            ({"Msg01", msg1}),
            ({"Msg02", msg2}),
            ({"Msg03", msg3}),
            ({"Msg04", msg4}),
            ({"Msg05", msg5}),
            ({"Msg06", msg6}),
            ({"Msg07", msg7}),
            ({"Msg08", msg8}),
            ({"Msg09", msg9}),
            ({"Msg10", msg10}),
            ({"DataDoc", Now}),
            ({"Tarifa", tarifa}),
            ({"Banco", banco.getBanco}),
            ({"BancoDv", banco.getBancoDv}),
            ({"LogoBco", banco.getLogo}),
            ({"CodigoBarrasImg", cb.ToByte})
        }

        Return parametros
    End Function

    Private Function Data2Boleta(dataent As String) As String
        Return Strings.Left(dataent, 2) & Strings.Mid(dataent, 4, 2) & Strings.Right(dataent, 4)
    End Function

    Private Function Valor2Boleta(Valor As String) As String
        Dim valor_ As String
        valor_ = Replace(Valor, ".", "")
        Dim valor1_ As String
        Dim valor2_ As String
        valor1_ = Strings.Right(StrDup(13, "0") & Strings.Mid(valor_, 1, Strings.InStr(valor_, ",") - 1), 13)
        valor2_ = Strings.Right(valor_, 2)
        Return valor1_ & valor2_
    End Function

    Private Function RmvSimbols(value As String, Tipo As String) As String
        Dim Retorno As String = ""
        For i = 1 To Len(value)
            If Strings.Asc(Strings.Mid(value, i, 1)) >= 48 And Strings.Asc(Strings.Mid(value, i, 1)) <= 57 Then
                Retorno = Retorno & Strings.Mid(value, i, 1)
            End If
        Next i

        If Tipo = "CPFCNPJ" Then
            If Retorno.Length <= 11 Then
                Retorno = Strings.Right(StrDup(11, "0") & Retorno, 11)
            ElseIf Retorno.Length <= 14 Or Retorno.Length >= 14 Then
                Retorno = Strings.Right(StrDup(14, "0") & Retorno, 14)
            End If
        Else ' "CEP"
            If Retorno.Length <= 8 Or Retorno.Length >= 8 Then
                Retorno = Strings.Right(StrDup(8, "0") & Retorno, 8)
            End If
        End If
        Return Retorno
    End Function

    Private Function MyLetras(value As String) As String
        Dim cWord As String = value
        Dim iLetras As String() = {"à", "è", "ì", "ò", "ù", "ã", "õ", "â", "ê", "î", "ô", "û", "á",
                    "é", "í", "ó", "ú", "ä", "ë", "ï", "ö", "ü", "ç", "À", "È", "Ì",
                    "Ò", "Ù", "Ã", "Õ", "Â", "Ê", "Î", "Ô", "Û", "Á", "É", "Í", "Ó",
                    "Ú", "Ä", "Ë", "Ï", "Ö", "Ü", "Ç", ".", ":", "-", ",", ";", "/"}
        Dim oLetras As String() = {"a", "e", "i", "o", "u", "a", "o", "a", "e", "i", "o", "u", "a",
                    "e", "i", "o", "u", "a", "e", "i", "o", "u", "c", "A", "E", "I",
                    "O", "U", "A", "O", "A", "E", "I", "O", "U", "A", "E", "I", "O",
                    "U", "A", "E", "I", "O", "U", "C", " ", " ", " ", " ", " ", " "}

        Dim bAchei As Boolean = False
        Dim bLetra As String = ""
        Dim Index As Integer = 0
        For i = 1 To value.Length
            bAchei = False

            bLetra = Strings.Mid(value, i, 1)
            For Index = 0 To iLetras.Length - 1
                If iLetras(Index).Equals(bLetra) Then
                    bAchei = True
                    Exit For
                End If
            Next Index

            If bAchei Then
                cWord = Replace(cWord, bLetra, oLetras(Index))
            End If
        Next i

        Return cWord
    End Function

End Class
