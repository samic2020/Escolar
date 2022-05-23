Imports MySql.Data.MySqlClient

Public Class bancos
    Private dbMain As [Db] = New Db

    Private Agencia As String = "3402"
    Private ContaCed As String = "563350"
    Private CtaDv As String = "8"
    Private Banco As String = "033"
    Private BancoDv As String = "7"
    Private NomeBanco As String = "CAIXA ECONOMICA FEDERAL"
    Private Cart As String = "101"
    Private Moeda As String = "9"
    Private Tarifa As String = "6,00"
    Private Nnumero As String = "0000000000"
    Private Identificacao As String = "013000516"
    Private IdentDv As String = "3"
    Private Logo As Byte() = Nothing
    Private nRemessa As String = "1"
    Private Chamada As String
    Private FileRemessa As String = "C:\\CAIXA\\Cobranca\\Remessa\\"
    Private FileRetorno As String = "C:\\CAIXA\\Cobranca\\Retorno\\"

    Public Function CalcDig10(cadeia As String) As String
        Dim mult, total, res, pos As Integer
        mult = (cadeia.Length() Mod 2)
        mult += 1 : total = 0
        For pos = 1 To cadeia.Length()
#Disable Warning BC42016 ' Conversão implícita de "Double" para "Integer".
            res = Val(Strings.Mid(cadeia, pos, 1)) * mult
#Enable Warning BC42016 ' Conversão implícita de "Double" para "Integer".
            'res = Val(cadeia.Substring(pos, pos + 1)) * mult
#Disable Warning BC42016 ' Conversão implícita de "Double" para "Integer".
            If res > 9 Then res = (res / 10) + (res Mod 10)
#Enable Warning BC42016 ' Conversão implícita de "Double" para "Integer".
            total += res
            If mult = 2 Then mult = 1 Else mult = 2
        Next
        total = ((10 - (total Mod 10)) Mod 10)
        Return CStr(total)
    End Function

    Public Function Valor4Boleta(valor As String) As String
        Dim valor1 As String = "0000000000" + valor.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "")
        Return Strings.Left(valor1, 10)
        'Return valor1.Substring(valor1.Length() - 10, valor1.Length())
    End Function

    Public ReadOnly Property getAgencia() As String
        Get
            Return Me.Agencia
        End Get
    End Property

    Public WriteOnly Property setAgencia() As String
        Set(value As String)
            Me.Agencia = value
        End Set
    End Property

    Public ReadOnly Property getConta() As String
        Get
            Return Me.ContaCed
        End Get
    End Property

    Public WriteOnly Property setConta() As String
        Set(value As String)
            Me.ContaCed = value
        End Set
    End Property

    Public ReadOnly Property getCtaDv() As String
        Get
            Return Me.CtaDv
        End Get
    End Property

    Public WriteOnly Property setCtaDv() As String
        Set(value As String)
            Me.CtaDv = value
        End Set
    End Property

    Public ReadOnly Property getBanco() As String
        Get
            Return Me.Banco
        End Get
    End Property

    Public WriteOnly Property setBanco() As String
        Set(value As String)
            Me.Banco = value
        End Set
    End Property

    Public ReadOnly Property getBancoDv() As String
        Get
            Return Me.BancoDv
        End Get
    End Property

    Public WriteOnly Property setBancoDv() As String
        Set(value As String)
            Me.BancoDv = value
        End Set
    End Property

    Public ReadOnly Property getCarteira() As String
        Get
            Return Me.Cart
        End Get
    End Property

    Public WriteOnly Property setCarteira() As String
        Set(value As String)
            Me.Cart = value
        End Set
    End Property

    Public ReadOnly Property getMoeda() As String
        Get
            Return Me.Moeda
        End Get
    End Property

    Public WriteOnly Property setMoeda() As String
        Set(value As String)
            Me.Moeda = value
        End Set
    End Property

    Public ReadOnly Property getTarifa() As String
        Get
            Return Me.Tarifa
        End Get
    End Property

    Public WriteOnly Property setTarifa() As String
        Set(value As String)
            Me.Tarifa = value
        End Set
    End Property

    Public ReadOnly Property getNnumero() As String
        Get
            Return Me.Nnumero
        End Get
    End Property

    Public WriteOnly Property setNnumero() As String
        Set(value As String)
            Me.Nnumero = value
        End Set
    End Property

    Public ReadOnly Property getIdentificacao() As String
        Get
            Return Me.Identificacao
        End Get
    End Property

    Public WriteOnly Property setIdentificacao() As String
        Set(value As String)
            Me.Identificacao = value
        End Set
    End Property

    Public ReadOnly Property getIdentDv() As String
        Get
            Return Me.IdentDv
        End Get
    End Property

    Public WriteOnly Property setIdentDv() As String
        Set(value As String)
            Me.IdentDv = value
        End Set
    End Property

    Public ReadOnly Property getLogo() As Byte()
        Get
            Return Me.Logo
        End Get
    End Property

    Public WriteOnly Property setLogo() As Byte()
        Set(value As Byte())
            Me.Logo = value
        End Set
    End Property

    Public ReadOnly Property getRemessa() As String
        Get
            Return Me.FileRemessa
        End Get
    End Property

    Public WriteOnly Property setRemessa() As String
        Set(value As String)
            Me.FileRemessa = value
        End Set
    End Property

    Public ReadOnly Property getRetorno() As String
        Get
            Return Me.FileRetorno
        End Get
    End Property

    Public WriteOnly Property setRetorno() As String
        Set(value As String)
            Me.FileRetorno = value
        End Set
    End Property

    Public ReadOnly Property getNRemessa() As String
        Get
            Return Me.nRemessa
        End Get
    End Property

    Public WriteOnly Property setNRemessa() As String
        Set(value As String)
            Me.nRemessa = value
        End Set
    End Property

    Public ReadOnly Property getNomeBanco() As String
        Get
            Return Me.NomeBanco
        End Get
    End Property

    Public WriteOnly Property setNomeBanco() As String
        Set(value As String)
            Me.NomeBanco = value
        End Set
    End Property

    Public ReadOnly Property getChamada() As String
        Get
            Return Me.Chamada
        End Get
    End Property

    Public WriteOnly Property setChamada() As String
        Set(value As String)
            Me.Chamada = value
        End Set
    End Property

    Public Sub LerBanco(banco As String)
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim selectSQL As String = "SELECT c.agencia, c.conta, c.conta_dv, c.nbanco, c.nbancodv, c.carteira, c.moeda, c.tarifa, c.nnumero, c.identificacao, c.identdv, c.nremessa, c.remessa, c.retorno, c.chamada, b.logo FROM contas_boletas c INNER JOIN bancos b ON b.codigo = c.nbanco WHERE Trim(nbanco) = @nbanco"
        Dim bco As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@nbanco", banco})})

        Dim tagencia = Nothing, tconta = Nothing, tctadv = Nothing, tbanco = Nothing, tbancodv = Nothing, tnnumero As String = Nothing
        Dim tcarteira = Nothing, tmoeda = Nothing, ttarifa = Nothing, tidentificacao = Nothing, tidentdv As String = Nothing
        Dim tnremessa = Nothing, tremessa = Nothing, tretorno = Nothing, tchamada As String = Nothing
        Dim tlogo As Byte() = Nothing
        Try
            If bco.HasRows Then
                While bco.Read
                    tagencia = bco.Item("agencia")
                    tconta = bco.Item("conta")
                    tctadv = bco.Item("conta_dv")
                    tbanco = bco.Item("nbanco")
                    tbancodv = bco.Item("nbancodv")
                    tcarteira = bco.Item("carteira")
                    tmoeda = bco.Item("moeda")
                    ttarifa = bco.Item("tarifa")
                    tidentificacao = bco.Item("identificacao")
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                    tidentdv = bco.Item("identdv")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                    tnnumero = bco.Item("nnumero")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

                    tnremessa = bco.Item("nremessa")
                    tremessa = bco.Item("remessa")
                    tretorno = bco.Item("retorno")
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                    tchamada = bco.Item("chamada")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "Byte()".
                    tlogo = bco.Item("logo")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "Byte()".
                End While
            End If
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, bco)

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setAgencia = tagencia
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setConta = tconta
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setCtaDv = tctadv
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setBanco = tbanco
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setBancoDv = tbancodv
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setCarteira = tcarteira
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setMoeda = tmoeda
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setTarifa = ttarifa
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

        setLogo = tlogo

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        If tidentificacao IsNot Nothing Then setIdentificacao = tidentificacao
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
        If tidentdv IsNot Nothing Then setIdentDv = tidentdv
        setNnumero = tnnumero

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setNRemessa = If(tnremessa Is DBNull.Value, "0", tnremessa)
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setRemessa = If(tremessa Is DBNull.Value, "0", tremessa)
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setRetorno = If(tretorno Is DBNull.Value, "0", tretorno)
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
        setChamada = tchamada

        conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        selectSQL = "SELECT nome FROM bancos WHERE Trim(codigo) = @nbanco"
        bco = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@nbanco", banco})})
        Try
            If bco.HasRows Then
                bco.Read()
                setNomeBanco = bco.Item("nome").ToString.Trim.ToUpper
            Else
                setNomeBanco = "INEXISTENTE"
            End If
        Catch ex As Exception
            setNomeBanco = "INEXISTENTE"
        End Try
        dbMain.CloseAll(conn, bco)
    End Sub

    Public Function LerNossoNumero(banco As String) As String
        Dim retorno As String = Nothing
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim selectSQL As String = "SELECT nnumero FROM contas_boletas WHERE Trim(nbanco) = @nbanco"
        Dim bco As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@nbanco", banco})})
        Try
            If bco.HasRows Then
                While bco.Read
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                    retorno = bco.Item("nnumero")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
                End While
            End If
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, bco)
        Return retorno
    End Function

    Public Sub GravarNnumero(nbanco As String, Value As String)
        Dim nnumero As String = LerNossoNumero(nbanco)
        Dim oldnnumero As Double = -1
        If nnumero IsNot Nothing Then
            oldnnumero = CDbl(nnumero)
        Else
            MsgBox("Houve um problema ao ler nnumero!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
            End
        End If

        If CDbl(Value) > oldnnumero Then
            Dim updateSQL As String = "UPDATE contas_boletas SET nnumero = @nnumero WHERE Trim(nbanco) = @nbanco"
            If Not dbMain.ExecuteCmd(updateSQL, New Object()() {({"@nnumero", Value}), ({"@nbanco", nbanco})}) Then
                MsgBox("Não consegui gravar Nnumero!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
                End
            End If
        Else
            MsgBox("Nnumero não coerente!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
            End
        End If
    End Sub

    Public Function fmtNumero(value As String) As String
        Dim numero As String = "000000000000000"
        value = value.Substring(0, value.IndexOf(",") + 3)
        Dim saida As String = (numero + rmvNumero(value)).trim()
        Return saida.Substring(saida.Length() - 15)
    End Function

    Public Function rmvNumero(value As String) As String
        Return value.Replace(".", "").Replace("/", "").Replace("-", "").Replace(",", "").Replace(" ", "")
    End Function

    Public Function rmvLetras(value As String) As String
        Dim ret As String = ""
        For i = 0 To value.Length()
            Dim letra As String = value.Substring(i, i + 1)
            If letra = ":" Then
                '// nada
            ElseIf Asc(letra) < 48 Or Asc(letra) > 57 Then
                '// nada
            Else
                ret &= letra
            End If
        Next
        Return ret
    End Function

    Public Function SoNumeroSemZerosAEsq(numero As String) As String
        Dim Retorno As String = ""
        For i = 0 To numero.Length()
            If Not numero.Substring(i, i + 1) = "0" Then
                Retorno &= numero.Substring(i)
                Exit For
            End If
        Next
        Return Retorno
    End Function

    Public Function rmvAcentos(value As String) As String
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
        For i = 1 To value.Length
            bAchei = False

            bLetra = Strings.Mid(value, i, 1)
            For Index = 0 To iLetras.Length - 1
                If iLetras(Index) = bLetra Then
                    bAchei = True
                    Exit For
                End If
            Next Index

            If bAchei Then
                cWord = Replace(value, bLetra, oLetras(Index))
            End If
        Next i

        Return cWord
    End Function

    Function StringCodigoBarra(ByVal sCodigo As String) As String
        Dim sCod As String, sTmp As String
        Dim ii As Integer, jj As Integer, iTmp As Integer

        'Pressupoe-se que existe um numero par de digitos em sCodigo

        'Inicializacao
        sTmp = ""
        iTmp = 0
        ii = 1
        jj = Len(sCodigo)
        sCod = ""

        Do While ii < jj
            'Separando os digitos dois a dois
            sTmp = Mid(sCodigo, ii, 2)
            ii += 2
            iTmp = CInt(sTmp)

            'A + ABS(A<=49)*48 + ABS(A>=50)*142
            If iTmp <= 49 Then
                iTmp += 48
            Else
                iTmp += 142
            End If
            'iTmp = iTmp + Abs(iTmp <= 49) * 48 + Abs(iTmp >= 50) * 142

            'Pegando o caracter da conta acima.
            sCod = sCod & Chr(iTmp)
        Loop

        'Delimitadores - inicial e final
        If (sCod <> vbNullString) Then
            sCod = "(" + sCod + ")"
        End If

        'Retorno da funcao
        StringCodigoBarra = sCod
    End Function

    Public Sub GravarRemessa(nbanco As String, Value As String)
        Dim remessa As String = LerRemessa(nbanco)
        Dim oldremessa As Double = -1
        If remessa IsNot Nothing Then
            oldremessa = CDbl(remessa)
        Else
            MsgBox("Houve um problema ao ler numero da remessa!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
            End
        End If

        If CDbl(Value) > oldremessa Then
            Dim updateSQL As String = "UPDATE contas_boletas SET remessa = @remessa WHERE Trim(nbanco) = @nbanco"
            If Not dbMain.ExecuteCmd(updateSQL, New Object()() {({"@remessa", Value}), ({"@nbanco", nbanco})}) Then
                MsgBox("Não consegui gravar Numero da remessa!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
                End
            End If
        Else
            MsgBox("Numero da remessa não coerente!!!" & vbNewLine & "Contacte o administrador do sistema." & vbNewLine & "Tel.:(21)97665-9897")
            End
        End If
    End Sub

    Public Function LerRemessa(banco As String) As String
        Dim retorno As String = Nothing
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim selectSQL As String = "SELECT remessa FROM contas_boletas WHERE Trim(nbanco) = @nbanco"
        Dim bco As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, New Object()() {({"@nbanco", banco})})
        Try
            If bco.HasRows Then
                While bco.Read
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                    retorno = bco.Item("remessa")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
                End While
            End If
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, bco)
        Return retorno
    End Function

End Class
