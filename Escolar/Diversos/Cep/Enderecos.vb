Imports Canducci.Zip

Public Class Enderecos
    Private gCep As ZipCodeInfo = Nothing
    Public ReadOnly Property getCep() As ZipCodeInfo
        Get
            Return gCep
        End Get
    End Property

    Private Sub Enderecos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        endEstado.Items.AddRange(New ListasDiversas().Estados)
        endEstado.Text = "RJ"

        endCidade.Items.AddRange(New ListasDiversas().Municipios)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim datatable As New DataTable("Ceps")
        datatable.Columns.Add("Endereço", GetType(String))
        datatable.Columns.Add("Complemento", GetType(String))
        datatable.Columns.Add("Bairro", GetType(String))
        datatable.Columns.Add("Cep", GetType(String))
        datatable.Columns.Add("Zip", GetType(ZipCodeInfo))

        'Dim ufs As Dictionary(Of Object, Object) = ZipCodeLoad.UfToList
        'Dim codeUfs As ZipCodeUf() = ufs.Where(endEstado.SelectedItem.ToString)
        'match = (From row As ZipCodeUf In ZipCodeLoad.UfToList() From cell As Dictionary(Of Object, Object) In ZipCodeLoad.UfToList() Select cell Where CStr(cell.Value).Contains(endEstado.SelectedItem.ToString)).ToArray()

        Dim zips As ZipCodeInfo()
        Try
            zips = New ZipCodeLoad().Address(If(endEstado.SelectedItem.ToString.Trim.ToUpper.Equals("RJ"), ZipCodeUf.RJ, ZipCodeUf.SP), endCidade.SelectedItem.ToString.Trim, endEnder.Text.Trim)
            'zips = New ZipCodeLoad().Address(codeUfs, endCidade.SelectedItem.ToString.Trim, endEnder.Text.Trim)
            If zips.Count() <= 0 Then
                Return
            End If
        Catch ex As ZipCodeException
            Throw ex
        End Try

        For Each zip As ZipCodeInfo In zips
            With datatable
                .Rows.Add({zip.Address, zip.Complement, zip.District, zip.Zip, zip})
            End With
        Next

        With DataGridViewCep
            .DataSource = ""
            .DataSource = datatable

            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Black
            .RowHeadersVisible = False
            .RowHeadersWidth = 25
            .MultiSelect = False
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(0).HeaderText = "Endereço"
            .Columns(0).Width = 250
            .Columns(0).ReadOnly = True

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "Complemento"
            .Columns(1).Width = 100
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "Bairro"
            .Columns(2).Width = 150
            .Columns(2).ReadOnly = True

            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).HeaderText = "Cep"
            .Columns(3).Width = 80
            .Columns(3).ReadOnly = True

            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).HeaderText = "Zip"
            .Columns(4).Width = 80
            .Columns(4).ReadOnly = True
            .Columns(4).Visible = False
        End With
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If DataGridViewCep.Rows.Count <= 0 Then Return
        gCep = DataGridViewCep.SelectedRows.Item(0).Cells.Item(4).Value
        Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        gCep = Nothing
        Dispose()
    End Sub
End Class