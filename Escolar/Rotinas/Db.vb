Imports MySql.Data.MySqlClient

Public Class Db
    Public Function OpenDB(Unidade As String, user As String, senha As String) As MySqlConnection
        Dim objConn As MySqlConnection = Nothing
        Dim strConn As String
        strConn = "server={0};userid={1};password={2};database=;pooling=false;Connect Timeout=100; pooling='true'; Max Pool Size=400;charset=utf8;"
        strConn = String.Format(strConn, Unidade, user, senha)
        objConn = New MySqlConnection(strConn)

        Try
            objConn.Open()
        Catch ex As Exception
            objConn = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        Return objConn
    End Function

    Public Function OpenDB(Unidade As String, user As String, senha As String, database As String, Optional param As String = "") As MySqlConnection
        Dim objConn As MySqlConnection = Nothing
        Dim strConn As String
        strConn = "server={0};userid={1};password={2};database={3};pooling=false;Connect Timeout=100; pooling='true'; Max Pool Size=400;charset=utf8;" & param
        strConn = String.Format(strConn, Unidade, user, senha, database)
        objConn = New MySqlConnection(strConn)

        Try
            objConn.Open()
        Catch ex As Exception
            objConn = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        Return objConn
    End Function

    Public Function OpenDBMaster(Unidade As String, user As String, senha As String, Optional param As String = "") As MySqlConnection
        Dim objConn As MySqlConnection = Nothing
        Dim strConn As String
        strConn = "server={0};userid={1};password={2};database=;pooling=false;Connect Timeout=100; pooling='true'; Max Pool Size=400;charset=utf8;" & param
        strConn = String.Format(strConn, Unidade, user, senha)
        objConn = New MySqlConnection(strConn)

        Try
            objConn.Open()
        Catch ex As Exception
            objConn = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

        Return objConn
    End Function

    Public Sub CloseDB(conn As MySqlConnection)
        conn.Close()
        conn.Dispose()
        conn = Nothing
    End Sub

    Public Function ExecuteCmdMaster(sql As String, Optional parameters As Object()() = Nothing) As Boolean
        Dim cnx As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd)
        Dim cmd As MySqlCommand = Nothing
        Dim RecordsAffected As Integer
        If cnx.State = ConnectionState.Closed Then
            MsgBox("Conexão esta fechada!")
            Return False
        End If

        Try
            cmd = New MySqlCommand(sql, cnx) With {
                .CommandTimeout = 900
            }

            If parameters IsNot Nothing Then
                For Each pr As Object In parameters
                    cmd.Parameters.AddWithValue(pr(0), pr(1))
                Next
            End If

            RecordsAffected = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            RecordsAffected = -1
        End Try
        cnx.Close()
        cnx.Dispose()
        cnx = Nothing

        cmd.Dispose()
        cmd = Nothing

        Return RecordsAffected > -1
    End Function

    Public Function ExecuteCmd(sql As String, Optional parameters As Object()() = Nothing) As Boolean
        Dim cnx As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim cmd As MySqlCommand = Nothing
        Dim RecordsAffected As Integer
        If cnx.State = ConnectionState.Closed Then
            MsgBox("Conexão esta fechada!")
            Return False
        End If

        Try
            cmd = New MySqlCommand(sql, cnx) With {
                .CommandTimeout = 900
            }

            If parameters IsNot Nothing Then
                For Each pr As Object In parameters
                    cmd.Parameters.AddWithValue(pr(0), pr(1))
                Next
            End If

            RecordsAffected = cmd.ExecuteNonQuery()
        Catch ex As Exception
            RecordsAffected = -1
        End Try
        cnx.Close()
        cnx.Dispose()
        cnx = Nothing

        cmd.Dispose()
        cmd = Nothing

        Return RecordsAffected > -1
    End Function

    Public Function OpenTable(cnx As MySqlConnection, sql As String, Optional parameters As Object()() = Nothing, Optional timeOut As Integer = 60) As MySqlDataReader
        If cnx.State = ConnectionState.Closed Then
            MsgBox("Conexão esta fechada!")
            Return Nothing
        End If

        Dim RecordsAffected As MySqlDataReader
        Try
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnx) With {
                    .CommandTimeout = timeOut
                }

            If parameters IsNot Nothing Then
                For Each pr As Object In parameters
                    cmd.Parameters.AddWithValue(pr(0), pr(1))
                Next
            End If
            RecordsAffected = cmd.ExecuteReader()
        Catch ex As Exception
            MsgBox(ex.Message)
            RecordsAffected = Nothing
        End Try

        Return RecordsAffected
    End Function

    Public Sub CloseTable(table As MySqlDataReader)
        table.Close()
        table.Dispose()
        table = Nothing
    End Sub

    Public Sub CloseAll(conn As MySqlConnection, table As MySqlDataReader)
        CloseTable(table)
        CloseDB(conn)
    End Sub

    Public Function OpenAdapter(cnx As MySqlConnection, sql As String, Optional parameters As Object()() = Nothing, Optional timeOut As Integer = 60) As MySqlDataAdapter
        If cnx.State = ConnectionState.Closed Then
            MsgBox("Conexão esta fechada!")
            Return Nothing
        End If

        Dim RecordsAffected As New MySqlDataAdapter
        Try
            Dim cmd As MySqlCommand = New MySqlCommand(sql, cnx) With {
                    .CommandTimeout = timeOut
            }
            If parameters IsNot Nothing Then
                For Each pr As Object In parameters
                    cmd.Parameters.AddWithValue(pr(0), pr(1))
                Next
            End If
            RecordsAffected.SelectCommand = cmd
        Catch ex As Exception
            MsgBox(ex.Message)
            RecordsAffected = Nothing
        End Try

        Return RecordsAffected
    End Function

    Public Function ReportDataSource(cnx As MySqlConnection, sql As String, Optional parameters As Object()() = Nothing, Optional nameTable As String = Nothing, Optional setDataSetName As Boolean = False) As DataSet
        Dim da As MySqlDataAdapter = OpenAdapter(cnx, sql, parameters, 0)
        Dim ds As New DataSet
        If setDataSetName Then
            ds.Namespace = nameTable
        End If
        If nameTable Is Nothing Then
            da.Fill(ds)
        Else
            da.Fill(ds, nameTable)
        End If
        da = Nothing

        If ds.Tables.Count > 0 Then
            Try
                ds.WriteXml(Globais.xmlPath & "\" & nameTable & ".xml", XmlWriteMode.WriteSchema)
            Catch ex As Exception
            End Try

            Return ds
        Else
            Return Nothing
        End If
    End Function

    Function lergravarPARAM(aParam As Object(), Optional lTipo As Boolean = True) As Object
        '/*********************************************************************************
        ' * aParam(0) - Variavel
        ' * aParam(1) - Tipo
        ' * aParam(2) - Conteudo
        ' */
        Dim retorno As Object = Nothing

        Dim pSql As String = "SELECT * FROM parametros WHERE Upper(variavel) = @VARIAVEL ORDER BY variavel;"
        Dim conn As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim myPar As MySqlDataReader = OpenTable(conn, pSql, {({"@VARIAVEL", aParam(0)})})
        If myPar.HasRows Then
            myPar.Read()
            Select Case myPar.Item("tipo").ToString.Trim.ToUpper
                Case "TEXTO"
                    retorno = myPar.Item("conteudo").ToString.Trim
                Case "NUMERICO"
                    retorno = Val(myPar.Item("conteudo").ToString)
                Case "DATA"
                    retorno = Format(CDate(myPar.Item("conteudo").ToString), "dd/MM/yyyy")
                Case "HORA"
                    retorno = Format(myPar.Item("conteudo").ToString.Trim, "hh:mm")
                Case "LOGICO"
                    retorno = myPar.Item("conteudo").ToString.Trim.ToUpper = "TRUE"
            End Select
        Else
            retorno = Nothing
        End If
        myPar.Close()
        conn.Close()

        If Not lTipo Then
            Dim Sql As String = ""
            Dim con As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
            If retorno Is Nothing Then
                Sql = "INSERT INTO parametros (variavel, tipo, conteudo) VALUES (@VARIAVEL, @TIPO, @CONTEUDO)"
            Else
                Sql = "UPDATE parametros SET conteudo = @CONTEUDO WHERE variavel = @VARIAVEL"
            End If
            Dim param As Object()()
            If retorno Is Nothing Then
                param = New Object()() {({"@VARIAVEL", aParam(0)}), ({"@TIPO", aParam(2)}), ({"@CONTEUDO", aParam(1)})}
            Else
                param = New Object()() {({"@VARIAVEL", aParam(0)}), ({"@CONTEUDO", aParam(1)})}
            End If
            ExecuteCmd(Sql, param)
            con.Close()
        End If

        Return retorno
    End Function

    Public Function RecordsCount(sql As String, Optional conn As MySqlConnection = Nothing, Optional parameters As Object()() = Nothing) As Integer
        Dim cnn As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim command As New MySqlCommand(sql, cnn)
        If parameters IsNot Nothing Then
            For Each pr As Object In parameters
                command.Parameters.AddWithValue(pr(0), pr(1))
            Next
        End If
        Dim retorno As Integer = command.ExecuteScalar()
        CloseDB(cnn)
        Return retorno
    End Function

    Public Sub CreateView(cNome As String, cSql As String)
        '// Apaga a View
        ExecuteCmd("DROP VIEW IF EXISTS " & cNome & ";")

        '// Cria a View
        ExecuteCmd("CREATE VIEW " & cNome & " AS " & cSql)
    End Sub

    Public Function PegaDataHoraServidor() As DateTime
        Dim cnn As MySqlConnection = OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim selectSQL As String = "SELECT sysdate() as datahora;"
        Dim rs As MySqlDataReader = OpenTable(cnn, selectSQL)
        Dim DataHoraServidor As DateTime = Nothing
        Try
            rs.Read()
            DataHoraServidor = rs.GetDateTime("datahora")
        Catch ex As Exception
        End Try
        CloseAll(cnn, rs)

        Return DataHoraServidor
    End Function

End Class

