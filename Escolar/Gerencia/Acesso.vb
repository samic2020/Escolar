Imports MySql.Data.MySqlClient

Public Class Acesso
    Private dbMain As [Db] = New Db

    Private Sub Acesso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillUsuarioBox()
        MontaAcessos()
    End Sub

    Private Sub FillUsuarioBox()
        '// Limpa o combobox
        aUsuario.DataSource = Nothing

        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vSql As String = "SELECT CADFUN.F_COD AS CODIGO, USUARIO AS NOME FROM CADFUN WHERE TRIM(USUARIO) != '' ORDER BY F_COD;"
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, vSql)

        Dim datatable As New DataTable("Usuario")
        datatable.Columns.Add("Codigo", GetType(String))
        datatable.Columns.Add("Nome", GetType(String))
        datatable.Load(vrs)
        vrs.Close()
        conn.Close()

        aUsuario.DataSource = datatable
        aUsuario.DisplayMember = "Codigo, Nome"
        aUsuario.ValueMember = "Nome"
        aUsuario.DisplayMultiColumnsInBox = True
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim _chaves As String = Nothing

        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vSql As String = "SELECT ATALHOS FROM CADFUN WHERE F_COD = '" + aUsuario.SelectedItem("codigo") + "'"
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        Try
            If vrs.HasRows Then
                While vrs.Read
                    Try
                        _chaves = vrs("atalhos")
                    Catch ex As Exception
                        _chaves = Nothing
                    End Try
                End While
            End If
        Catch ex As Exception
        End Try
        dbMain.CloseAll(conn, vrs)

        If _chaves IsNot Nothing Then
            Mostrar(_chaves)
        Else
            limpar()
        End If

    End Sub

    Private Sub Mostrar(chaves As String)
        If chaves = "" Then Exit Sub
        Dim _tree As String = chaves.Replace(";", ",")
        Dim _nodes As String() = _tree.Split(",")
        Dim i As Integer = 0
        Dim maxcpos As Integer = pnlAcessos.Controls.Count
        Dim j As Integer = 0
        Dim _chaves As String = "", _chave As String = "", _schave As String = ""

        For i = 0 To maxcpos - 1
            If TypeOf pnlAcessos.Controls.Item(i) Is Label Then
                '// Faz nada
            ElseIf TypeOf pnlAcessos.Controls.Item(i) Is CheckBox Then
                _chave = CType(pnlAcessos.Controls.Item(i), CheckBox).Name
                If IsNumeric(_chave.Substring(0, 1)) Then
                    _schave = ""
                    For z As Integer = 0 To _nodes.Length - 1
                        Dim pos As Integer = OcourCount(_nodes(z), ":", 2)
                        Dim _node As String = _nodes(z).Substring(0, pos)
                        Dim _setar As Boolean = (_chave.Trim.Equals(_node.Trim()))
                        If _setar Then
                            Dim _acesso As String() = _nodes(z).Split(":")
                            If InStr(_acesso(2), "|") > 0 Then
                                _schave = _acesso(2).Substring(InStr(_acesso(2), "|"))
                                _acesso(2) = _acesso(2).Substring(0, InStr(_acesso(2), "|") - 1)
                            End If
                            CType(pnlAcessos.Controls.Item(i), CheckBox).Checked = IIf(_acesso(2).Trim.Equals("1"), True, False)
                            'CType(pnlAcessos.Controls.Item(i), CheckBox).Checked = IIf(_acesso(_sacesso(0)).Trim.Equals("1"), True, False)
                        End If
                    Next
                Else
                    If _schave.Trim <> "" Then
                        Dim _aschave As String() = _schave.Split("|")
                        Dim _pos As Integer = Val(_chave.Substring(1, 1))
                        Try
                            CType(pnlAcessos.Controls.Item(i), CheckBox).Checked = IIf(_aschave(_pos).Trim.Equals("1"), True, False)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub MontaAcessos()
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vSql As String = "SELECT * FROM menu ORDER BY tipo,cod"
        Dim mnu As MySqlDataReader = dbMain.OpenTable(conn, vSql)

        Try
            Dim _ypos As Integer = 0
            Dim _iwidth As Integer = 280 'pnlAcessos.Height

            Dim _corBG As Color = Color.FromArgb(90, 90, 220)
            Dim _corBG2 As Color = pnlAcessos.BackColor
            Dim _corFG As Color = Color.FromArgb(254, 254, 254)
            Dim _corFG2 As Color = Color.FromArgb(76, 76, 76)

            If mnu.HasRows Then
                While mnu.Read
                    Dim _tipo As Integer = mnu("tipo")
                    Dim _cod As Integer = mnu("cod")
                    Dim _nome As String = mnu("nome").ToString.Trim.ToUpper
                    Dim _permitir As String = mnu("permitir").ToString.Trim.ToUpper

                    If _nome.Trim = "-" Then Continue While

                    Dim _xpos As Integer = IIf(_cod = 0, 0, 30)
                    Dim _width As Integer = IIf(_cod = 0, _iwidth, _iwidth - 30)
                    Dim _heigth As Integer = 24

                    Dim item As Control = Nothing
                    'If _cod <> 0 Then
                    Dim _item As CheckBox = New CheckBox
                    _item.Text = _nome
                    _item.Name = _tipo.ToString + ":" + _cod.ToString
                    _item.Size = New Size(_width, _heigth)
                    _item.Location = New Point(_xpos, _ypos)

                    _item.ForeColor = IIf(_cod = 0, _corFG, _corFG2)
                    _item.BackColor = IIf(_cod = 0, _corBG, _corBG2)
                    _item.SendToBack()
                    _item.Visible = True
                    item = _item

                    pnlAcessos.Controls.Add(item)

                    If _permitir <> "" Then
                        _xpos += 260
                        Dim apermitir() As String = _permitir.Split(";")
                        For p = 0 To apermitir.Length - 1
                            Dim sitem As Control = Nothing
                            Dim _sitem As CheckBox = New CheckBox

                            _sitem.Text = apermitir(p)
                            _sitem.Name = "S" & p
                            _sitem.Size = New Size(80, _heigth)
                            _sitem.Location = New Point(_xpos, _ypos)

                            _sitem.ForeColor = IIf(_cod = 0, _corFG, _corFG2)
                            _sitem.BackColor = IIf(_cod = 0, _corBG, _corBG2)
                            _sitem.BringToFront()
                            _sitem.Visible = True

                            sitem = _sitem

                            pnlAcessos.Controls.Add(sitem)
                            _xpos += 85
                        Next
                    End If

                    _ypos += 29
                End While
            End If
        Catch e As Exception
            MsgBox(e.Message)
        End Try
        mnu.Close()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim chaves As String = Chaveamento()
        Dim Sql As String = "UPDATE cadfun SET atalhos = '" + chaves + "' WHERE f_cod = '" + aUsuario.SelectedItem("codigo") + "';"
        dbMain.ExecuteCmd(Sql)

        '// Auditor
        Auditor.auditor("Acesso", "Alteração", "Usuário: " & aUsuario.Text, "Data: " & Now)
    End Sub

    Private Sub limpar()
        Dim i As Integer = 0
        Dim maxcpos As Integer = pnlAcessos.Controls.Count
        For i = 0 To maxcpos - 1
            If TypeOf pnlAcessos.Controls.Item(i) Is Label Then
                '// nada
            ElseIf TypeOf pnlAcessos.Controls.Item(i) Is CheckBox Then
                CType(pnlAcessos.Controls.Item(i), CheckBox).Checked = False
            End If
        Next
    End Sub

    Private Function Chaveamento() As String
        Dim i As Integer = 0
        Dim maxcpos As Integer = pnlAcessos.Controls.Count
        Dim j As Integer = 0
        Dim _chaves As String = "", _chave As String = "", _schave = ""
        For i = 0 To maxcpos - 1
            If TypeOf pnlAcessos.Controls.Item(i) Is CheckBox Then
                Dim nomeControl As String = CType(pnlAcessos.Controls.Item(i), CheckBox).Name
                Dim simnao As Boolean = CType(pnlAcessos.Controls.Item(i), CheckBox).Checked
                If IsNumeric(nomeControl.Substring(0, 1)) Then
                    If simnao Then
                        _chave = If(_chaves <> "", ",", "") & CType(pnlAcessos.Controls.Item(i), CheckBox).Name + ":1"
                    Else
                        _chave = ""
                    End If
                Else
                    _schave += "|" & If(simnao, 1, 0)
                    Continue For
                End If
            End If
            If _chave <> "" Then
                _chaves += _schave & _chave
                _schave = ""
                _chave = ""
            End If
        Next

        If _schave <> "" Then _chave += _schave
        '_chaves = _chaves.Substring(0, _chaves.Length - 1)
        '// Acertas (.;)
        _chaves = _chaves.Replace(",;", ";")

        Dim chaves As String() = _chaves.Split(";")
        For z As Integer = 0 To chaves.Length - 1
            Dim nodes As String() = chaves(z).Split(",")
            Dim root As Boolean = False
            For w As Integer = 0 To nodes.Length - 1
                Dim tree As String() = nodes(w).Split(":")
                root = root Or tree(2).Trim.Equals("1")
            Next
            '// Faz root = true
            Dim _node As String = ""
            If root Then
                Dim tree As String() = nodes(0).Split(":")
                tree(2) = "1"

                nodes(0) = tree(0) + ":" + tree(1) + ":" + tree(2)
            End If
            chaves(z) = String.Join(",", nodes)
        Next

        Return String.Join(";", chaves)
    End Function

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Dispose()
    End Sub
End Class