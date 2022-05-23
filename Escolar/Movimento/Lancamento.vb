Imports MySql.Data.MySqlClient

Public Class Lancamento
    Private dbMain As [Db] = New Db
    Private idTurma As Integer = -1
    Private idAluno As Integer = -1
    Private _ano As Integer = Year(Now)

    Public WriteOnly Property AlunoId As Integer
        Set(value As Integer)
            idAluno = value
        End Set
    End Property

    Public WriteOnly Property TurmaId As Integer
        Set(value As Integer)
            idTurma = value
        End Set
    End Property

    Public WriteOnly Property Ano As Integer
        Set(value As Integer)
            _ano = value
        End Set
    End Property

    Private _dtmat As Date = Now
    Private _vrmat As Decimal = 0D
    Private _inicio As Integer = 1
    Private _final As Integer = 12

    Public WriteOnly Property DataMat As Date
        Set(value As Date)
            _dtmat = value
        End Set
    End Property

    Public WriteOnly Property ValorMat As Decimal
        Set(value As Decimal)
            _vrmat = value
        End Set
    End Property

    Public WriteOnly Property Inicio As Integer
        Set(value As Integer)
            _inicio = value
        End Set
    End Property

    Private Sub Lancamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtaMatricula.Text = Format(_dtmat, "dd/MM/yyyy")
        vrMatricula.Text = Format(_vrmat, "#,##0.00")
        mesIniMensal.Value = New Date(Year(Now), _inicio, 1)
        mesFinMensal.Value = New Date(Year(Now), _final, 1)
    End Sub

    Private Sub mesIniMensal_ValueChanged(sender As Object, e As EventArgs) Handles mesIniMensal.ValueChanged
        mesFinMensal.Value = New Date(Year(mesIniMensal.Value), _final, 1)
    End Sub

    Private Sub LancarMensalidades()
        Dim _dia As Integer
        Dim _mes As Integer = Month(mesIniMensal.Value)
        Dim _valor As Decimal = 0D
        Dim _desconto As Decimal = 0D
        Dim _vencimento As Date

        Dim desfilpe As Integer = 0
        Try
            desfilpe = Integer.Parse(dbMain.lergravarPARAM({"DESFILPE"}))
        Catch ex As Exception
            desfilpe = 0
        End Try

        Dim desfilvr As Decimal = 0
        Try
            desfilvr = CDec(dbMain.lergravarPARAM({"DESFILVR"}))
        Catch ex As Exception
            desfilvr = 0
        End Try

        Dim desfunpe As Integer = 0
        Try
            desfunpe = Integer.Parse(dbMain.lergravarPARAM({"DESFUNPE"}))
        Catch ex As Exception
            desfunpe = 100
        End Try

        Dim desfunvr As Decimal = 0
        Try
            desfunvr = CDec(dbMain.lergravarPARAM({"DESFUNVR"}))
        Catch ex As Exception
            desfunvr = 0
        End Try

        Dim selectSQL As String = "select ta.idturma, ta.idaluno, ta.ano, tu.curso, tu.serie, tu.turno, tu.turma, me.vencimento, me.valor, id.irmao, id.filhofunc, " +
                                  "id.bolsista, id.percentual from turmas_alunos ta, turmas tu, mensalidade me, alunos_indicacoes id WHERE ta.idturma = tu.id and " +
                                  "tu.curso = me.curso and tu.serie = me.serie and id.idaluno = ta.idaluno AND ta.idaluno = @idaluno and ta.ano = @ano LIMIT 1;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim param As Object()() = {
                    ({"@idaluno", idAluno}),
                    ({"@ano", _ano})
                }
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, param)
        Try
            If vrs.HasRows Then
                vrs.Read()
                _dia = vrs.GetInt32("vencimento")
                _valor = vrs.GetDecimal("valor")

                If vrs.GetBoolean("irmao") And Not vrs.GetBoolean("bolsista") Then
                    If desfilpe > 0 Then
                        _desconto = _valor * (desfilpe / 100)
                    Else
                        _desconto = _valor - desfilvr
                    End If
                ElseIf vrs.GetBoolean("irmao") And vrs.GetBoolean("bolsista") Then
                    _desconto = _valor * (vrs.GetInt16("percentual") / 100)
                Else
                    If desfunpe = 100 Then
                        _desconto = _valor
                    ElseIf desfunpe > 0 And desfunpe < 100 Then
                        _desconto = _valor * (desfunpe / 100)
                    ElseIf desfunpe = 0 Then
                        _desconto = _valor - desfunvr
                    End If
                End If

                Dim insertSQL As String = "INSERT INTO `financeiro`(`idtipo`,`idaluno`,`dtlanc`,`dtvenc`,`valor`,`desconto`,`credeb`) " +
                                          "VALUES (@idtipo,@idaluno,@dtlanc,@dtvenc,@valor,@desconto,@credeb);"

                '// Matricula
                _vencimento = _dtmat
                If DateDiff(DateInterval.Day, Now, _vencimento) <= 0 Then _vencimento = Now
                Dim param2 As Object()() = New Object()() {
                        ({"@idtipo", 0}),
                        ({"@idaluno", idAluno}),
                        ({"@dtlanc", Now}),
                        ({"@dtvenc", _vencimento}),
                        ({"@valor", _valor}),
                        ({"@desconto", 0D}),
                        ({"@credeb", "D"})
                    }
                dbMain.ExecuteCmd(insertSQL, param2)

                '// Mensalidades
                For i = _mes To 12
                    _vencimento = New Date(Year(Now), i, _dia)
                    If DateDiff(DateInterval.Day, Now, _vencimento) <= 0 Then _vencimento = Now

                    param2 = New Object()() {
                        ({"@idtipo", 1}),
                        ({"@idaluno", idAluno}),
                        ({"@dtlanc", Now}),
                        ({"@dtvenc", _vencimento}),
                        ({"@valor", _valor}),
                        ({"@desconto", _desconto}),
                        ({"@credeb", "D"})
                    }
                    dbMain.ExecuteCmd(insertSQL, param2)
                Next

            End If
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, vrs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LancarMensalidades()
        Dispose()
    End Sub
End Class