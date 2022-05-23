Imports System.IO

Public Class DescansoTela
    Private ImagesScreenSaver() As FileInfo
    Private FilesPath As String = "C:\Users\Public\Pictures\Sample Pictures\"
    Private fimDoSaver As Integer = 20
    Private contSaver As Integer = 0
    Private nImage As Integer = 0
    Private _saida As Integer = 0

    Public ReadOnly Property Saida() As Integer
        Get
            Return _saida
        End Get
    End Property

    Private Sub DescansoTela_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Directory.Exists(FilesPath) Then
                Dim DirDiretorio As DirectoryInfo = New DirectoryInfo(FilesPath)
                ImagesScreenSaver = DirDiretorio.GetFiles("*.*")
            End If
        Catch ex As Exception
        End Try

        If ImagesScreenSaver.Length > 0 Then
            imagem.Image = Image.FromFile(FilesPath & "\\" & ImagesScreenSaver.GetValue(nImage).ToString)
        Else
            imagem.Image = Nothing
        End If

        With Timer1
            .Interval = 60000
            .Start()
            .Enabled = True
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If contSaver >= fimDoSaver Then
            _saida = 1
            Dispose()
        Else
            contSaver += 1
            nImage = Rnd(1) * ImagesScreenSaver.Length
            If nImage > 20 Then nImage = 0

            Try
                imagem.Image = Image.FromFile(FilesPath & "\\" & ImagesScreenSaver.GetValue(nImage).ToString)
            Catch ex As Exception
            End Try

            With Timer1
                .Enabled = False
                .Stop()

                .Interval = 60000
                .Start()
                .Enabled = True
            End With
        End If
    End Sub

    Private Sub DescansoTela_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Not senhaFrame.Visible Then
            senha.Text = ""
            senhaFrame.Visible = True
            senha.Focus()
        End If
    End Sub

    Private Sub senha_KeyDown(sender As Object, e As KeyEventArgs) Handles senha.KeyDown
        If e.KeyCode = Keys.Return Then e.SuppressKeyPress = True
    End Sub

    Private Sub senha_KeyUp(sender As Object, e As KeyEventArgs) Handles senha.KeyUp
        If e.KeyCode = Keys.Return Then
            If senha.Text.Trim = Globais.senha.Trim Then
                _saida = 0
                Dispose()
            End If
        End If
        If e.KeyCode = Keys.Escape Then
            senhaFrame.Visible = False
        End If
    End Sub
End Class