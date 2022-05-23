Public Class Desconto
    Private dbMain As [Db] = New Db

    Private Sub Desconto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fields As Controles = New Controles(Nothing)
        fields.FormataNumero(desfilvr, 2)
        fields.FormataNumero(desfunvr, 2)

        Try
            desfilpe.Value = Integer.Parse(dbMain.lergravarPARAM({"DESFILPE"}))
        Catch ex As Exception
            desfilpe.Value = 0
        End Try

        Try
            desfilvr.Text = Format(CDec(dbMain.lergravarPARAM({"DESFILVR"})), "#,##0.00")
        Catch ex As Exception
            desfilvr.Text = "0,00"
        End Try

        Try
            desfunpe.Value = Integer.Parse(dbMain.lergravarPARAM({"DESFUNPE"}))
        Catch ex As Exception
            desfunpe.Value = 100
        End Try

        Try
            desfunvr.Text = Format(CDec(dbMain.lergravarPARAM({"DESFUNVR"})), "#,##0.00")
        Catch ex As Exception
            desfunvr.Text = "0,00"
        End Try
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        dbMain.lergravarPARAM({"DESFILPE", desfilpe.Value.ToString, "NUMERICO"}, False)
        dbMain.lergravarPARAM({"DESFILVR", desfilvr.Text, "NUMERICO"}, False)

        dbMain.lergravarPARAM({"DESFUNPE", desfunpe.Value.ToString, "NUMERICO"}, False)
        dbMain.lergravarPARAM({"DESFUNVR", desfunvr.Text, "NUMERICO"}, False)
    End Sub

    Private Sub desfilpe_ValueChanged(sender As Object, e As EventArgs) Handles desfilpe.ValueChanged
        If desfilpe.Value > 0 Then
            desfilvr.Enabled = False
            desfilvr.Text = "0,00"
        Else
            desfilvr.Enabled = True
            desfilvr.Text = "0,00"
        End If
    End Sub

    Private Sub desfunpe_ValueChanged(sender As Object, e As EventArgs) Handles desfunpe.ValueChanged
        If desfunpe.Value = 100 Then
            desfunvr.Enabled = False
            desfunvr.Text = "0,00"
        Else
            desfunvr.Enabled = True
            desfunvr.Text = "0,00"
        End If
    End Sub
End Class