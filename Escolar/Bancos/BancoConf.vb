Imports MySql.Data.MySqlClient

Public Class BancoConf
    Private dbMain As [Db] = New Db

    Private Sub btnAdc_Click(sender As Object, e As EventArgs) Handles btnAdc.Click
        If jAgencia.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("Número da Agência Obrigatório!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        If jConta.Text.Trim & jCtaDv.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("Conta Obrigatório!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        ''''''''''''If cBancos.SelectedIndex < 0 Then
        ''''''''''''    MsgBox("Selecione um BANCO!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
        ''''''''''''    Return
        ''''''''''''End If

        If jCarteira.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("Número da Carteira Obrigatório!" & vbNewLine & "Para saber Consulte seu banco...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        If jMoeda.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("Código da Moeda Obrigatório!" & vbNewLine & "Digite 9 - Para Real.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        If jTarifa.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("A tarifa pode variar de R$ 0,00 até a Contratada!" & vbNewLine & "Para saber Consulte seu banco...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        If jNossoNumero.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("O NossoNumero deve começar por 1 até a posição emitida!" & vbNewLine & "Para saber Consulte seu banco...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Return
        End If

        If jIdentificacao.Text.Trim & jIdentificacaoDv.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            If MsgBox("Em Alguns Bancos esta informação é nescessária!" & vbNewLine & "Para saber Consulte seu banco..." &
                   vbNewLine & "Prossegue sem cadastrar este item?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Atenção") = MsgBoxResult.No Then
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
                Return
            End If
        End If

        bcoAdc()
    End Sub

    Private Sub bcoAdc()
        Dim tagencia As String = jAgencia.Text()
        Dim tconta As String = jConta.Text()
        Dim tcontadv As String = jCtaDv.Text()
        Dim tnbanco As String '= cBancos.SelectedItem("Codigo").ToString
        Dim tnbancodv As String ' = cBancos.SelectedItem("Digito").ToString
        Dim tchamada As String '= cBancos.SelectedItem("Chamada").ToString
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
        Dim tcarteira As String = jCarteira.Text()
        Dim tmoeda As String = jMoeda.Text()
        Dim ttarifa As String = jTarifa.Text()
        Dim tnnumero As String = jNossoNumero.Text()
        Dim tidentificacao As String = jIdentificacao.Text
        Dim tidentdv As String = jIdentificacaoDv.Text

        Dim sql As String = "INSERT INTO contas_boletas (agencia, conta, conta_dv, nbanco, nbancodv, carteira, moeda, tarifa, nnumero, identificacao, identdv, nremessa, remessa, retorno, chamada) VALUES " +
            "('{0}',',{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','0','0','0','{11}');"
        sql = String.Format(sql, tagencia, tconta, tcontadv, tnbanco, tnbancodv, tcarteira, tmoeda, ttarifa, tnnumero, tidentificacao, tidentdv, tchamada)
        Try
            dbMain.ExecuteCmd(sql)
        Catch ex As Exception
        End Try

        '// Auditor
        Auditor.auditor("Bancos Boleta", "Inclusão", "AG: " & tagencia & " /  Conta: " & tconta & " / BCO: " & tnbanco, "Data: " & Now)

        jAgencia.Text = ""
        jConta.Text = ""
        jCtaDv.Text = ""
        '''''''''cBancos.SelectedIndex = -1
        jCarteira.Text = ""
        jMoeda.Text = ""
        jTarifa.Text = ""
        jNossoNumero.Text = ""
        jIdentificacao.Text = ""
        jIdentificacaoDv.Text = ""

        ListaContasBoletas()
    End Sub

    Private Sub bcoDel()
        If MsgBox("Exclui este registro???", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Excluir") = MsgBoxResult.Yes Then
            Try
                dbMain.ExecuteCmd("DELETE FROM contas_boletas WHERE id = '" + bancos.CurrentRow.Cells(0).Value.ToString + "'")

                '// Auditor
                Auditor.auditor("BANCOS", "EXCLUSÃO", bancos.CurrentRow.Cells(0).Value + "," + bancos.CurrentRow.Cells(1).Value + "," + bancos.CurrentRow.Cells(2).Value + "," + bancos.CurrentRow.Cells(3).Value)

                ''* Atualiza
                bancos.Rows.Remove(bancos.CurrentRow)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ListaContasBoletas()
        Dim datatable As New DataTable("Bancos")
        Dim vSql As String = "SELECT id, agencia, conta, conta_dv, nbanco, nbancodv, carteira, moeda, tarifa, nnumero,  identificacao, identdv FROM contas_boletas ORDER BY id"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim uFile As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(uFile)
        uFile.Close()

        With bancos
            .DataSource = ""
            .DataSource = datatable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False
            .RowHeadersWidth = 25
            .MultiSelect = True
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "Id"
            .Columns(0).Width = 60
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).HeaderText = "Agencia"
            .Columns(1).Width = 80
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).HeaderText = "Conta"
            .Columns(2).Width = 80
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "Dv"
            .Columns(3).Width = 80
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).HeaderText = "Banco"
            .Columns(4).Width = 80
            .Columns(4).ReadOnly = True

            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).HeaderText = "Dv"
            .Columns(5).Width = 80
            .Columns(5).ReadOnly = True

            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).HeaderText = "Carteira"
            .Columns(6).Width = 40
            .Columns(6).ReadOnly = True

            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).HeaderText = "Moeda"
            .Columns(7).Width = 40
            .Columns(7).ReadOnly = True

            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(8).HeaderText = "Tarifa"
            .Columns(8).Width = 60
            .Columns(8).DefaultCellStyle.Format = "#,##0.00"
            .Columns(8).ReadOnly = True

            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(9).HeaderText = "NossoNumero"
            .Columns(9).Width = 80
            .Columns(9).ReadOnly = True

            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(10).HeaderText = "Identificacao"
            .Columns(10).Width = 80
            .Columns(10).ReadOnly = True

            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(11).HeaderText = "Dv"
            .Columns(11).Width = 80
            .Columns(11).ReadOnly = True
        End With
    End Sub

    Private Sub BancoConf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaContasBoletas()
        FillBancos()
    End Sub

    Private Sub bancos_DoubleClick(sender As Object, e As EventArgs) Handles bancos.DoubleClick
        bcoDel()
    End Sub

    Private Sub FillBancos()
        '// Limpa o combobox
        ''''''''''''''''''cBancos.DataSource = Nothing

        Dim datatable As New DataTable("Bancos")
        datatable.Columns.Add("Codigo", GetType(String))
        datatable.Columns.Add("Nome", GetType(String))

        Dim vSql As String = "SELECT b.codigo, b.digito, b.nome, b.chamada FROM bancos b ORDER BY Upper(b.nome);"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        '''''''''cBancos.DataSource = datatable
        '''''''''cBancos.DisplayMember = "Codigo, Digito, Nome"
        '''''''''cBancos.ValueMember = "Codigo"
        '''''''''cBancos.DisplayMultiColumnsInBox = True
    End Sub

End Class