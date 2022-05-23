Imports System.IO

Public Class cef
    Private dbMain As [Db] = New Db

    Private Function CALCDIG10(cadeia As String) As Integer
        Dim mult As Integer = (Len(cadeia) Mod 2)
        mult = mult + 1
        Dim total As Integer = 0
        For pos = 1 To Len(cadeia)
            Dim Res As Integer = CInt(Mid(cadeia, pos, 1)) * mult
            If Res > 9 Then
                Res = Int(Res / 10) + (Res Mod 10)
            End If
            total = total + Res
            If mult = 2 Then
                mult = 1
            Else
                mult = 2
            End If
        Next
        Dim calc As Integer = Int(total Mod 10)
        If calc = 0 Then
            total = 0
        Else
            total = ((10 - (total Mod 10)) Mod 10)
        End If
        Return total
    End Function

    Public Function linhadigitavel(codigobarras As String) As String
        Dim campo1 As String = Left(codigobarras, 4) & Mid(codigobarras, 20, 5)
        campo1 = campo1 & CALCDIG10(campo1)
        campo1 = Mid(campo1, 1, 5) & "." & Mid(campo1, 6, 5)

        Dim campo2 As String = Mid(codigobarras, 25, 10)
        campo2 = campo2 & CALCDIG10(campo2)
        campo2 = Mid(campo2, 1, 5) & "." & Mid(campo2, 6, 6)

        Dim campo3 As String = Mid(codigobarras, 35, 10)
        campo3 = campo3 & CALCDIG10(campo3)
        campo3 = Mid(campo3, 1, 5) & "." & Mid(campo3, 6, 6)

        Dim campo4 As String = Mid(codigobarras, 5, 1)

        Dim campo5 As String = Mid(codigobarras, 6, 4) & Mid(codigobarras, 10, 10)

        Return campo1 & Space(2) & campo2 & Space(2) & campo3 & Space(2) & campo4 & Space(2) & campo5
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
            If result > 9 Or result = 0 Then
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

    Private Function fatorvencimento(vencimento As String) As String
        Dim retorno As String
        If Len(vencimento) < 8 Then
            retorno = "0000"
        Else
            retorno = DateDiff(DateInterval.Day, CDate("1997/10/07"), CDate(vencimento)).ToString  '//DateValue(vencimento) - DateValue("1997/10/07")
        End If
        Return retorno
    End Function

    Public Function CodBarras(nBanco As String, moeda As String, Vencto As String, Valor As String, codcli As String, nossonumero As String) As String
        Dim dvcpobenef As String = CALCDIG11(codcli, 9, 0).ToString

        Dim cpolivre, dvcpolivre As String
        cpolivre = codcli & dvcpobenef & Mid(nossonumero, 3, 3) & Mid(nossonumero, 1, 1) & Mid(nossonumero, 6, 3) &
               Mid(nossonumero, 2, 1) & Mid(nossonumero, 9, 9)
        dvcpolivre = CALCDIG11(cpolivre, 9, 0).ToString

        Dim tDigVerGeral As String
        tDigVerGeral = DigitoVGeral(nBanco, moeda, Vencto, Valor, codcli & dvcpobenef, nossonumero, dvcpolivre)

        Dim tCodBar As String
        tCodBar = nBanco & moeda & tDigVerGeral & fatorvencimento(Vencto) & Valor & cpolivre & dvcpolivre

        Return tCodBar
    End Function

    Public Function DigitoVGeral(nBanco As String, moeda As String, Vencto As String, Valor As String, cdbenf As String, nnumero As String, dvcampolivre As String) As String
        Dim tmpCalc As String
        tmpCalc = ""
        tmpCalc = nBanco & moeda & fatorvencimento(Vencto) & Valor & cdbenf & Mid(nnumero, 3, 3) &
            Mid(nnumero, 1, 1) & Mid(nnumero, 6, 3) & Mid(nnumero, 2, 1) & Mid(nnumero, 9, 9) &
            dvcampolivre

        Return CALCDIG11(tmpCalc, 9, 1).ToString
    End Function

    Public Function CalBarras_Cef(cons_agencia As String, cons_conta As String, var_nossonumero As String, var_valordocumento As String,
                        var_datavencimento As String, cons_banco As String, cons_moeda As String) As String()

        Dim dvnossonumero As String = CALCDIG11(var_nossonumero, 9, 2).ToString
        Dim dvagconta As String = "0"

        Dim valorvalor1 As String = var_valordocumento
        Dim valorvalor2 As String = Replace(valorvalor1, ",", "")
        valorvalor2 = Replace(valorvalor2, ".", "")
        Dim valorvalor3 As Integer = Len(valorvalor2)
        Dim valorvalor4 As Integer = 10 - valorvalor3
        Dim var_valor As String = StrDup(valorvalor4, "0") & ("" & valorvalor2 & "")
        If valorvalor1 = 0 Then
            var_valor = ""
        End If

        Dim var_fatorvencimento As String = fatorvencimento("" & var_datavencimento & "")
        If var_fatorvencimento = "0000" Then
            var_datavencimento = "Contra Apresentação"
        End If

        Dim var_codigobarras As String = CodBarras("" & cons_banco & "",
                                  "" & cons_moeda & "",
                                  "" & var_datavencimento & "",
                                  "" & var_valor & "",
                                  "739777",
                                  "" & var_nossonumero & "")

        Dim var_linhadigitavel As String = linhadigitavel("" & var_codigobarras & "")

        Return {var_codigobarras, var_linhadigitavel, var_nossonumero & "-" & dvnossonumero}
    End Function
    Public Function convValor(Optional cValor As String = "0")
        If cValor = "0" Then convValor = "0000000000" : Exit Function
        Dim mValor As String, nConta As Integer
        For nConta = 1 To Len(cValor)
            If InStr(".,", Mid(cValor, nConta, 1)) <= 0 Then
                mValor = mValor & Mid(cValor, nConta, 1)
            End If
        Next nConta

        Return Strings.Right("0000000000" & mValor, 10)
    End Function

    Public Function Boleta(nossonumero As String, mnomesacado As String, mcpfcnpj As String, mendereco As String, nrcep As String, nrcepc As String, mbairro As String,
                          mcidade As String, mestado As String, mvencimento As Date, mvalordoc As String, msgpadrao As String, nrDoc As String, tarifa As Decimal,
                           Optional troca As Boolean = False, Optional nBanco As String = "104") As Object()()
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
        banco.LerBanco(nBanco)

        '* Dados Banco
        Dim magced As String = banco.getAgencia '// "0174"
        Dim mctaced As String = banco.getConta  '// "739777"
        Dim mdacced As String = banco.getCtaDv  '// "1"

        Dim vrtarifa As Decimal = tarifa
        Dim newmvalordoc As String
        If vrtarifa > 0 Then
            newmvalordoc = Format(CDec(mvalordoc) + vrtarifa, "#,##0.00")
            msg7 = "Tarifa Bancária já Inclusa"
        Else
            newmvalordoc = Format(CDec(mvalordoc), "#,##0.00")
        End If

        Dim barras_cef As String() = CalBarras_Cef(magced, mctaced & mdacced, nsnumero,
                  convValor(newmvalordoc),
                  mvencimento, banco.getBanco, "9")

        Dim digitavel As String = barras_cef(1)
        Dim imprimivel As String = barras_cef(0)
        Dim nnsnumero As String = barras_cef(2)

        '// Codigo de Barras proprio - 27-08-2020 11h25m
        Dim cb As C2of5i = New C2of5i(imprimivel, 1, 50, imprimivel.Length)

        Dim cEndereco As String = Globais.dadosAdm.Item("Endereco").ToString.Trim.ToUpper & ", " & Globais.dadosAdm.Item("Numero").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Bairro").ToString.Trim.ToUpper + " - " &
        Globais.dadosAdm.Item("Cidade").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Estado").ToString.Trim.ToUpper & " - CEP " & Globais.dadosAdm.Item("Cep").ToString.Trim.ToUpper

        Dim nDoc As String = Strings.Mid(nrDoc, 1, nrDoc.ToString.IndexOf(" "))
        Dim cParc As String = Strings.Mid(nrDoc, nrDoc.ToString.IndexOf(" ") + 2)
        Dim parametros As Object()() = {
            ({"Beneficiario", Globais.dadosAdm.Item("Razao").ToString.ToUpper.Trim}),
            ({"BenefCNPJ", Globais.dadosAdm.Item("Cnpj").ToString.Trim.ToUpper}),
            ({"BenefAgCodigo", magced & " / " & mctaced & "-" & mdacced}),
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
            ({"Carteira", banco.getCarteira}),
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

    Private Function DescBoletaVenc(valor As String, Optional troca As Boolean = False) As String
        Dim descBase As Decimal = CDec(dbMain.lergravarPARAM({"DESCBASE"})) / 100
        If troca Then descBase = 0
        Return (CDec(valor) - (CDec(valor) * descBase)).ToString
    End Function

    Public Sub Imprimir(ds As DataSet)
        RepoCotacao.Text = "Preview - Boleta"
        RepoCotacao.WindowState = 2
        RepoCotacao.Boleta(ds)
        RepoCotacao.ShowDialog()
    End Sub

    Public Sub Remessa(nremessa As String, tpMovimento As String, Boletas As DataGridView)
        If Not Directory.Exists(Globais.cxaPath) Then
            Directory.CreateDirectory(Globais.cxaPath)
        End If

        Dim FileRemessa As String
        FileRemessa = Globais.cxaPath & "\E000" & nremessa & ".REM"

        Using writer As New StreamWriter(FileRemessa, True)
            Dim LF As String
            LF = "" '//Chr(13) & Chr(10)
            Dim nsa As Integer
            nsa = Val(nremessa)
            Dim codlote As Integer
            codlote = 0
            Dim nrreg As Integer
            nrreg = 1
            Dim vrtttitulos As Decimal

            Dim banco_ As String = "104"
            Dim codlote_ As String = Format(codlote, "0000")
            Dim tiporeg_ As String = "0"
            Dim filler_ As String = Space(9)
            Dim tipoinsc_ As String = "2"
            Dim numinsc_ As String = "74143074000113"
            Dim exclus1_ As String = StrDup(20, "0")
            Dim agencia_ As String = "00174"
            Dim digagen_ As String = "0"
            Dim codbenef_ As String = "739777"
            Dim exclus2_ As String = StrDup(8, "0")
            Dim nomeemp_ As String = Mid("MUNDO EM DUAS RODAS LTDA ME" + Space(30), 1, 30)
            Dim nmbanco_ As String = Mid("CAIXA ECONOMICA FEDERAL" + Space(30), 1, 30)
            Dim filler2_ As String = Space(10)
            Dim codreme_ As String = "1"
            Dim dtgerac_ As String = Format(Now, "ddMMyyyy")
            Dim hrgerac_ As String = Format(Now, "HHmmss")
            Dim nsa_ As String = Format(nsa, "000000")
            Dim versao_ As String = "050"
            Dim densid_ As String = StrDup(5, "0")
            Dim filler3_ As String = Space(20)
            Dim situacao_ As String = Space(20)
            Dim usoint_ As String = Space(4)
            Dim filler4_ As String = Space(25)

            '// REGISTRO TIPO '0'
            writer.WriteLine(banco_ & codlote_ & tiporeg_ & filler_ & tipoinsc_ & numinsc_ &
                  exclus1_ & agencia_ & digagen_ & codbenef_ & exclus2_ &
                  nomeemp_ & nmbanco_ & filler2_ & codreme_ & dtgerac_ & hrgerac_ &
                  nsa_ & versao_ & densid_ & filler3_ & situacao_ & usoint_ & filler4_ & LF)

            codlote = codlote + 1

            'banco_ = "104"
            codlote_ = Format(codlote, "0000")
            tiporeg_ = "1"
            Dim tipooper_ As String = "R"
            Dim tiposerv_ As String = "01"
            filler4_ = StrDup(2, "0")
            Dim nverlay_ = "030"
            Dim filler5_ = Space(1)
            'dim tipoinsc_ = "2"
            numinsc_ = "074143074000113"
            'dim codbenef_ = "000000"
            Dim exclus3_ = StrDup(14, "0")
            'dim agencia_
            'dim digagen_
            'dim codbenef_
            Dim codboleto_ = StrDup(7, "0")
            Dim exclus4_ = "0"
            'dim nomeemp_
            Dim msg1_ = Mid("" + Space(40), 1, 40)
            Dim msg2_ = Mid("" + Space(40), 1, 40)
            nsa_ = Format(nsa, "00000000")
            'dim dtgerac_
            Dim filler6_ = StrDup(8, "0")
            Dim filler7_ = Space(33)

            '// REGISTRO TIPO '1'
            writer.WriteLine(banco_ & codlote_ & tiporeg_ & tipooper_ & tiposerv_ & filler4_ & nverlay_ &
                  filler5_ & tipoinsc_ & numinsc_ & codbenef_ & exclus3_ & agencia_ &
                  digagen_ & codbenef_ & codboleto_ & exclus4_ & nomeemp_ &
                  msg1_ & msg2_ & nsa_ & dtgerac_ & filler6_ & filler7_ & LF)

            '// REGISTRO TIPO '3' - P
            Dim nDias As Integer
            nDias = Val("0" & dbMain.lergravarPARAM({"DIASBOLETA"}))

            For Each item As DataGridViewRow In Boletas.SelectedRows
                'banco_ = "104"
                codlote_ = Format(codlote, "0000")
                tiporeg_ = "3"
                Dim nrreg_ As String = Format(nrreg, "00000")
                tipooper_ = "P"
                Dim filler8_ As String = Space(1)
                Dim codrem_ As String = Mid(tpMovimento, 1, 2)
                'agencia_
                'digagen_
                'codbenef_
                Dim exclus8_ As String = StrDup(8, "0")
                Dim filler9_ As String = StrDup(2, "0")
                Dim modcart_ As String = "0" '// 17 posições
                Dim impcart_ As String = "14" '// Impressão pelo beneficiario
                Dim nnumero_ As String = Strings.Right(StrDup(15, "0") & item.Cells(2).Value.ToString.Trim, 15)
                Dim codcart_ As String = "1"
                Dim fmcadbco_ As String = "1"
                Dim tipodoc_ As String = "2"
                Dim idboleta_ As String = "2"
                Dim identbol_ As String = "0"
                Dim nrcobra_ As String = Mid(item.Cells(0).Value.ToString & Space(11), 1, 11)
                Dim fillera_ As String = Space(4)
                Dim dtvecto_ As String = Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy"))
                Dim newmvalordoc As Decimal
                '// Para cobrar tarifa
                Dim vrtarifa = CDec(item.Cells(13).Value.ToString)
                If vrtarifa > 0 Then
                    newmvalordoc = CDec(item.Cells(5).Value.ToString) + vrtarifa
                Else
                    newmvalordoc = CDec(item.Cells(5).Value.ToString)
                End If

                Dim vrtitulo_ = Valor2Boleta(Format(newmvalordoc, "#,##0.00"))

                '// Soma os titulos
                vrtttitulos = vrtttitulos + newmvalordoc

                Dim agcob_ As String = StrDup(5, "0")
                Dim digagcob_ As String = "0"
                Dim esptitulo_ As String = "17" '// RC - recibo
                Dim aceite_ As String = "N"
                Dim dtemistit_ As String = Data2Boleta(Format(item.Cells(1).Value, "dd/MM/yyyy"))
                Dim cdjurmora_ As String = "1"
                Dim dtjurmora_ As String = "00000000"

                Dim vrmordia As Decimal
                vrmordia = newmvalordoc * 0.0033
                Dim jurmordia_ As String = Valor2Boleta(Format(vrmordia, "#,##0.00"))

                Dim coddesconto_ As String = "1"
                Dim datadescont_ As String = Data2Boleta(Format(item.Cells(3).Value, "dd/MM/yyyy"))
                Dim vrdesconto As Decimal
                vrdesconto = (newmvalordoc - vrtarifa) * 0.1
                Dim vrdesconto_ As String = Valor2Boleta(Format(vrdesconto, "#,##0.00"))

                Dim vriof_ As String = StrDup(15, "0")
                Dim vrabat_ As String = StrDup(15, "0")
                Dim nrdoemp_ As String = Strings.Mid(item.Cells(0).Value.ToString & Space(25), 1, 25)
                Dim codprotest_ As String = "3"
                Dim diaprotest_ As String = "00"
                Dim codbaixa_ As String = "1"
                Dim diasbaixa_ As String = Format(nDias, "000") '"015"
                Dim codmoeda_ As String = "09" '// Real
                Dim fillerb_ As String = StrDup(10, "0")
                Dim autparc_ As String = " "

                writer.WriteLine(banco_ & codlote_ & tiporeg_ & nrreg_ & tipooper_ & filler8_ &
                      codrem_ & agencia_ & digagen_ & codbenef_ & exclus8_ & filler9_ &
                      modcart_ & impcart_ & nnumero_ & codcart_ & fmcadbco_ & tipodoc_ &
                      idboleta_ & identbol_ & nrcobra_ & fillera_ & dtvecto_ &
                      vrtitulo_ & agcob_ & digagcob_ & esptitulo_ & aceite_ & dtemistit_ &
                      cdjurmora_ & dtjurmora_ & jurmordia_ & coddesconto_ & datadescont_ &
                      vrdesconto_ & vriof_ & vrabat_ & nrdoemp_ & codprotest_ & diaprotest_ &
                      codbaixa_ & diasbaixa_ & codmoeda_ & fillerb_ & autparc_ & LF)

                '// REGISTRO TIPO '3' - Q
                'banco_ = "104"
                codlote_ = Format(codlote, "0000")
                'tiporeg_

                nrreg = nrreg + 1
                nrreg_ = Format(nrreg, "00000")

                tipooper_ = "Q"
                Dim fillerc_ As String = Space(1)
                'codrem_
                Dim tipoinscpag_ As String = IIf(Len(RmvSimbols(item.Cells(7).Value.ToString, "CPFCNPJ")) = 11, "1", "2") '// 1 - CPF / 2 - CNPJ
                Dim inscpagador_ As String = Strings.Right(StrDup(15, "0") & RmvSimbols(item.Cells(7).Value.ToString, "CPFCNPJ"), 15)
                Dim nomepagador_ As String = Strings.Mid(MyLetras(item.Cells(4).Value.ToString) & Space(40), 1, 40)
                Dim enderecopag_ As String = Strings.Mid(Space(40), 1, 40)
                Dim bairropag_ As String = Strings.Mid(Space(15), 1, 15)
                Dim ceppagador_ As String = Strings.Mid(StrDup(5, "0"), 1, 5)
                Dim sufceppag_ As String = Strings.Mid(StrDup(3, "0"), 1, 3)
                Dim cidadepag_ As String = Strings.Mid(Space(15), 1, 15)
                Dim estpag_ As String = Strings.Mid(Space(2), 1, 2)
                Dim tpinscaval_ As String = "0"
                Dim nrinscaval_ As String = StrDup(15, "0")
                Dim nmaval_ As String = Space(40)
                Dim cdbcocomp_ As String = StrDup(3, " ") '//"000"
                Dim nnbcocomp_ As String = Space(20)
                Dim fillerd_ As String = Space(8)

                writer.WriteLine(banco_ & codlote_ & tiporeg_ & nrreg_ & tipooper_ & fillerc_ &
                  codrem_ & tipoinscpag_ & inscpagador_ & nomepagador_ &
                  enderecopag_ & bairropag_ & ceppagador_ & sufceppag_ &
                  cidadepag_ & estpag_ & tpinscaval_ & nrinscaval_ & nmaval_ &
                  cdbcocomp_ & nnbcocomp_ & fillerd_ & LF)

                nrreg = nrreg + 1

            Next

            '// REGISTRO TIPO '5' - Trayler
            'banco_ = "104"
            codlote_ = Format(codlote, "0000")
            tiporeg_ = "5"
            Dim fillere_ = Space(9)
            Dim qtdreglote_ = Format(nrreg + 1, "000000")
            Dim qtdtitcob_ = Format(Boletas.SelectedRows.Count + 1, "000000")

            Dim vrtttit As String
            vrtttit = Format(vrtttitulos, "#,##0.00")

            Dim vrtottitcob_ As String = "00" & Valor2Boleta(vrtttit)
            Dim qtdtitcau_ As String = StrDup(6, "0")
            Dim vrtitcau_ As String = StrDup(17, "0")
            Dim qttdesc_ As String = StrDup(6, "0")
            Dim vrttdesc_ As String = StrDup(17, "0")
            Dim fillerf_ As String = Space(31)
            Dim fillerg_ As String = Space(117)

            writer.WriteLine(banco_ & codlote_ & tiporeg_ & fillere_ & qtdreglote_ &
                  qtdtitcob_ & vrtottitcob_ & qtdtitcau_ & vrtitcau_ &
                  qttdesc_ & vrttdesc_ & fillerf_ & fillerg_ & LF)

            '// REGISTRO TIPO '9' - Trayler
            'banco_ = "104"
            codlote_ = "9999"
            tiporeg_ = "9"
            Dim fillerh_ As String = Space(9)
            Dim qtdlotearquivo_ As String = "000001"
            Dim qtdregarquivo_ As String = Format(nrreg + 3, "000000")
            Dim filleri_ As String = Space(6)
            Dim fillerj_ As String = Space(205)

            writer.WriteLine(banco_ & codlote_ & tiporeg_ & fillerh_ & qtdlotearquivo_ &
                  qtdregarquivo_ & filleri_ & fillerj_ & LF)

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

    Private Function Data2Db(value As String) As String
        Return Strings.Right(value, 4) & "-" & Strings.Mid$(value, 4, 2) & "-" & Strings.Left(value, 2)
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
                    "O", "U", "A", "O", "A", "E", "I", "O", "A", "E", "I", "O", "U",
                    "A", "E", "I", "O", "U", "C", " ", " ", " ", " ", " ", " ", " "}

        Dim bAchei As Boolean = False
        Dim bLetra As String = ""
        Dim Index As Integer = 0
        For i = 1 To Len(value)
            bAchei = False

            bLetra = Strings.Mid(value, i, 1)
            For Index = 0 To UBound(iLetras) - 1
                If iLetras(Index) = bLetra Then
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
