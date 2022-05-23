Public Class MsgBoleto
    Private dbMain As [Db] = New Db
    Private campos As Object()()
    Private fields As Controles

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        dbMain.lergravarPARAM({"MSG1", "" & txtMsg1.Text, "TEXTO"}, False)
        dbMain.lergravarPARAM({"MSG2", "" & txtMsg2.Text, "TEXTO"}, False)
        dbMain.lergravarPARAM({"MSG3", "" & txtMsg3.Text, "TEXTO"}, False)
        dbMain.lergravarPARAM({"MSG4", "" & txtMsg4.Text, "TEXTO"}, False)

        Dispose()
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Dispose()
    End Sub

    Private Sub MsgBoleto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        campos = {({txtMsg1}), ({txtMsg2}), ({txtMsg3}), ({txtMsg4})}

        fields = New Controles(campos)
        fields.FieldsEnabled(True)
        fields.Focus()

        txtMsg1.Text = "" & dbMain.lergravarPARAM({"MSG1"})
        txtMsg2.Text = "" & dbMain.lergravarPARAM({"MSG2"})
        txtMsg3.Text = "" & dbMain.lergravarPARAM({"MSG3"})
        txtMsg4.Text = "" & dbMain.lergravarPARAM({"MSG4"})
    End Sub
End Class