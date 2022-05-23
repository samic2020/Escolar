Imports MySql.Data.MySqlClient

Public Class SelecaoBanco
    Private dbMain As [Db] = New Db
    Private _banco As String = Nothing
    Private _tarifa As String = "0,00"

    Private _isMoved As Boolean
    Private _x As Integer
    Private _y As Integer

    Public ReadOnly Property getTarifa() As String
        Get
            Return _tarifa
        End Get
    End Property

    Public ReadOnly Property getBanco() As String
        Get
            Return _banco
        End Get
    End Property

    Private Sub SelecaoBanco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillBancos()

        Dim fields As Controles = New Controles({})
        fields.FormataNumero(bcTarifa, 2, Color.Black)
        'cdBanco.Focus()
        _banco = Nothing
    End Sub

    Private Sub FillBancos()
        '// Limpa o combobox
        'cdBanco.DataSource = Nothing

        Dim datatable As New DataTable("Bancos")
        datatable.Columns.Add("Codigo", GetType(String))
        datatable.Columns.Add("Nome", GetType(String))
        datatable.Columns.Add("Tarifa", GetType(String))
        datatable.Columns.Add("NNumero", GetType(String))

        Dim vSql As String = "SELECT b.codigo, b.nome, c.tarifa, c.nnumero FROM bancos b INNER JOIN contas_boletas c ON c.nbanco = b.codigo ORDER BY c.id;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, vSql)
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        'cdBanco.DataSource = datatable
        'cdBanco.DisplayMember = "Codigo, Nome"
        'cdBanco.ValueMember = "Codigo"
        'cdBanco.DisplayMultiColumnsInBox = True
    End Sub

    Private Sub cdBanco_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles cdBanco.SelectedIndexChanged
        'nmBanco.Text = cdBanco.SelectedItem("Nome").ToString
        'bcTarifa.Text = cdBanco.SelectedItem("Tarifa").ToString
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        _banco = Nothing
        _tarifa = Nothing
        Dispose()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        '_banco = cdBanco.SelectedItem("Codigo").ToString
        _tarifa = bcTarifa.Text
        Dispose()
    End Sub

    Private Sub Caption_MouseDown(sender As Object, e As MouseEventArgs) Handles Caption.MouseDown
        _isMoved = True
        _x = e.Location.X
        _y = e.Location.Y
        Caption.Cursor = Cursors.SizeAll
    End Sub

    Private Sub Caption_MouseMove(sender As Object, e As MouseEventArgs) Handles Caption.MouseMove
        If _isMoved Then
            Me.Location = New Point(Me.Location.X + (e.Location.X - _x), Me.Location.Y + (e.Location.Y - _y))
        End If
    End Sub

    Private Sub Caption_MouseUp(sender As Object, e As MouseEventArgs) Handles Caption.MouseUp
        _isMoved = False
        Caption.Cursor = Cursors.Default
    End Sub

    Private Sub cdBanco_KeyDown(sender As Object, e As KeyEventArgs) 'Handles cdBanco.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub cdBanco_KeyUp(sender As Object, e As KeyEventArgs) 'Handles cdBanco.KeyUp
        If e.KeyCode = Keys.Return Then bcTarifa.Focus()
    End Sub

    Private Sub bcTarifa_KeyDown(sender As Object, e As KeyEventArgs) Handles bcTarifa.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub bcTarifa_KeyUp(sender As Object, e As KeyEventArgs) Handles bcTarifa.KeyUp
        If e.KeyCode = Keys.Return Then btnConfirmar.Focus()
    End Sub
End Class