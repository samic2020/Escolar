Imports Tulpep.NotificationWindow

Public Class Expiracao

    Private Sub actCode_KeyDown(sender As Object, e As KeyEventArgs) Handles actCode.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub actCode_KeyUp(sender As Object, e As KeyEventArgs) Handles actCode.KeyUp
        If e.KeyCode = Keys.Return And actCode.Text.Trim.Length > 0 Then
            btnAtivar.Focus()
        End If
    End Sub

    Private Sub Expiracao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lMensagem.Text = "O período de ultilização do sistema encontra-se expirado." & vbNewLine & "Entre em contato com a empresa responsável pelo sistema e solicite um código de ativação."
        ChaveAtivacao.Text = MacAddress()
        actCode.Focus()
    End Sub

    Private Sub btnAtivar_Click(sender As Object, e As EventArgs) Handles btnAtivar.Click
        Globais.Setting.Store("expData", actCode.Text.Trim)
        Dispose()
    End Sub

    Private Sub CopiarColar_Click(sender As Object, e As EventArgs) Handles CopiarColar.Click
        Clipboard.SetDataObject(ChaveAtivacao.Text)

        Dim objPopUp As New PopupNotifier
        With objPopUp
            .HeaderColor = Color.Red
            .AnimationDuration = 1000

            '// .Image = ImageListMessage.Images.Item(1)
            .ImageSize = New Size(32, 32)

            .TitleFont = New Font("Arial", 18, FontStyle.Bold)
            .TitleColor = Color.BlueViolet
            .TitleText = "Notificação"

            .ContentFont = New Font("Arial", 12, FontStyle.Bold.Italic)
            .ContentColor = Color.DeepPink
            .ContentPadding = New Padding(20)
            .ContentText = "Copiado para Área de Tranferência."
            .Popup()
        End With
    End Sub

    Private Sub ColarIcon_Click(sender As Object, e As EventArgs) Handles ColarIcon.Click
        actCode.Text = Clipboard.GetText
    End Sub
End Class