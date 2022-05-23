Imports System.Collections
Imports System.Net.Mail

Public Class SendEmail
    Private Attachment As System.Net.Mail.Attachment
    Private Mailmsg As New System.Net.Mail.MailMessage()

    Private wPara As String()
    Private wAnexos As String()
    Private retMsg As ArrayList = New ArrayList()

    Public ReadOnly Property get_Ret() As ArrayList
        Get
            Return retMsg
        End Get
    End Property

    Public WriteOnly Property Set_Para() As String()
        Set(value As String())
            wPara = value

            ePara.Items.Clear()
            For n As Integer = 0 To wPara.Length - 1
                If wPara(n) IsNot Nothing Then ePara.Items.Add(wPara(n))
            Next
            If wPara.Length > 0 Then ePara.SelectedIndex = 0
        End Set
    End Property

    Public WriteOnly Property Set_Anexos() As String()
        Set(value As String())
            wAnexos = value

            eAnexos.Items.Clear()
            For n As Integer = 0 To wAnexos.Length - 1
                eAnexos.Items.Add(wAnexos(n))
            Next
        End Set
    End Property

    Private Sub eAdcAnexo_Click(sender As Object, e As EventArgs) Handles eAdcAnexo.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.CheckFileExists = True
        openFileDialog.Title = "Selecione um arquivo para anexar"
        openFileDialog.ShowDialog()

        For Conta As Integer = 0 To UBound(openFileDialog.FileNames)
            eAnexos.Items.Add(openFileDialog.FileNames(Conta))
        Next
    End Sub

    Private Sub eDelAnexo_Click(sender As Object, e As EventArgs) Handles eDelAnexo.Click
        If eAnexos.SelectedIndex > -1 Then
            eAnexos.Items.RemoveAt(eAnexos.SelectedIndex)
        End If
    End Sub

    Private Sub eEnviar_Click(sender As Object, e As EventArgs) Handles eEnviar.Click
        If ePara.Items.Count < 1 Then
            MsgBox("Informe o endereço de destino ...!!!", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
        End If

        If eAssunto.Text = "" Then
            MsgBox("Informe o assunto do email ...!!!", MsgBoxStyle.Information, "Envia Email")
            Exit Sub
        End If

        eEnviar.Enabled = False
        Dim sendMsg As ArrayList = New ArrayList()
        Dim totEmails As Integer = ePara.Items.Count
        eProgressBar.Value = 0
        Dim aAnexos As String() = (From var In eAnexos.Items.Cast(Of String)() Where Not String.IsNullOrWhiteSpace(var)).ToArray
        For n As Integer = 0 To ePara.Items.Count - 1
            sendMsg.Add(ePara.Items.Item(n).ToString & " - " & IIf(enviaMensagemEmail(ePara.Items.Item(n).ToString, "", "", eAssunto.Text, eMensagem.Text, aAnexos), "Ok", "Error"))
            eProgressBar.Value = (100 * (n + 1)) / totEmails
        Next

        eEnvios.BeginUpdate()
        For n As Integer = 0 To sendMsg.Count - 1
            Dim rMsg As String = sendMsg.Item(n).ToString
            eEnvios.Items.Add(rMsg)
            retMsg.Add(rMsg)
        Next
        eEnvios.EndUpdate()
        Me.Height = 529
    End Sub

    Public Function enviaMensagemEmail(ByVal recepient As String, ByVal bcc As String, ByVal cc As String,
                                         ByVal subject As String, ByVal body As String, ByVal Attachments As String()) As Boolean
        Dim eSettings As New EmailSettings()
        Dim retorno As Boolean = False
        Try
            ' cria uma instância do objeto MailMessage
            Dim mMailMessage As New MailMessage()

            ' Define o endereço do remetente
            mMailMessage.From = New MailAddress(eSettings.user, eSettings.user)

            ' Define o destinario da mensagem
            mMailMessage.To.Add(New MailAddress(recepient))

            ' Verifica se o valor para bcc é null ou uma string vazia
            If Not bcc Is Nothing And bcc <> String.Empty Then
                ' Define o endereço bcc
                mMailMessage.Bcc.Add(New MailAddress(bcc))
            End If

            ' verifica se o valor para cc é nulo ou uma string vazia
            If Not cc Is Nothing And cc <> String.Empty Then
                ' Define o endereço cc
                mMailMessage.CC.Add(New MailAddress(cc))
            End If

            ' anexa arquivos
            If Attachments.Length > 0 Then
                For n As Integer = 0 To Attachments.Length - 1
                    mMailMessage.Attachments.Add(New Attachment(Attachments(n)))
                Next
            End If

            ' Define o assunto
            mMailMessage.Subject = subject

            ' Define o corpo da mensagem
            mMailMessage.Body = body

            ' Define o formato do email como HTML
            mMailMessage.IsBodyHtml = True

            ' Define a prioridade da mensagem como normal
            mMailMessage.Priority = MailPriority.Normal

            ' Cria uma instância de SmtpClient - Nota - Define qual o host a ser usado para envio
            ' de mensagens, no local de smtp.server.com use o nome do SEU servidor
            Dim servidorSMTP As String = eSettings.smtpAddress  '// "mail.mundoemduasrodas.com.br"
            Dim mSmtpClientPort As Integer = eSettings.smtpPort '// 587
            Dim mSmtpClient As New SmtpClient(servidorSMTP, mSmtpClientPort)
            '// mSmtpClient.Credentials = New Net.NetworkCredential("pedido@mundoemduasrodas.com.br", "mM@12345678")
            mSmtpClient.Credentials = New Net.NetworkCredential(eSettings.user, eSettings.passwd)

            ' Envia o email
            mSmtpClient.Send(mMailMessage)
            retorno = True
        Catch ex As Exception
            retorno = False
        End Try

        Return retorno
    End Function

    Private Sub SendEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 526
        Me.Height = 413
    End Sub

    Private Sub Configuracoes_Click(sender As Object, e As EventArgs) Handles Configuracoes.Click
        Dim emailsetup As New EmailSetup
        emailsetup.ShowDialog()
    End Sub
End Class