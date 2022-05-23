Imports System.Text.RegularExpressions

Public Class Config
    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIpBase()
        cIp0.Focus()
    End Sub

    Private Sub LoadIpBase()
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cIp0.Text = Setting.Load("Unidade0", "127.0.0.1")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cBaseDados0.Text = Setting.Load("DataBaseName0", "cicle")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cUsuario0.Text = Setting.Load("User0", "root")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cSenha0.Text = Setting.Load("PassWord0", "7kf51b")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cIp1.Text = Setting.Load("Unidade1", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cBaseDados1.Text = Setting.Load("DataBaseName1", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cUsuario1.Text = Setting.Load("User1", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cSenha1.Text = Setting.Load("PassWord1", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cIp2.Text = Setting.Load("Unidade2", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cBaseDados2.Text = Setting.Load("DataBaseName2", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cUsuario2.Text = Setting.Load("User2", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cSenha2.Text = Setting.Load("PassWord2", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cIp3.Text = Setting.Load("Unidade3", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cBaseDados3.Text = Setting.Load("DataBaseName3", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cUsuario3.Text = Setting.Load("User3", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cSenha3.Text = Setting.Load("PassWord3", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cIp4.Text = Setting.Load("Unidade4", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cBaseDados4.Text = Setting.Load("DataBaseName4", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cUsuario4.Text = Setting.Load("User4", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        cSenha4.Text = Setting.Load("PassWord4", "")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
    End Sub

    Private Sub cIp0_Leave(sender As Object, e As EventArgs) Handles cIp0.Leave
        Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

        If Not rx.IsMatch(cIp0.Text) Then
            MessageBox.Show("O Endereço de IP não está em um formato próprio!")
            cIp0.SelectAll()
        End If
    End Sub

    Private Sub cIp1_Leave(sender As Object, e As EventArgs) Handles cIp1.Leave
        Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

        If Not rx.IsMatch(cIp1.Text) Then
            MessageBox.Show("O Endereço de IP não está em um formato próprio!")
            cIp1.SelectAll()
        End If
    End Sub

    Private Sub cIp2_Leave(sender As Object, e As EventArgs) Handles cIp2.Leave
        Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

        If Not rx.IsMatch(cIp2.Text) Then
            MessageBox.Show("O Endereço de IP não está em um formato próprio!")
            cIp2.SelectAll()
        End If
    End Sub

    Private Sub cIp3_Leave(sender As Object, e As EventArgs) Handles cIp3.Leave
        Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

        If Not rx.IsMatch(cIp3.Text) Then
            MessageBox.Show("O Endereço de IP não está em um formato próprio!")
            cIp3.SelectAll()
        End If
    End Sub

    Private Sub cIp4_Leave(sender As Object, e As EventArgs) Handles cIp4.Leave
        Dim rx As New Regex("^(?:(?:25[0-5]|2[0-4]\d|[01]\d\d|\d?\d)(?(?=\.?\d)\.)){4}$")

        If Not rx.IsMatch(cIp4.Text) Then
            MessageBox.Show("O Endereço de IP não está em um formato próprio!")
            cIp4.SelectAll()
        End If
    End Sub

    Private Sub btnGravar0_Click(sender As Object, e As EventArgs) Handles btnGravar0.Click
        Gravar(0, cIp0.Text.Trim, cBaseDados0.Text.Trim, cUsuario0.Text.Trim, cSenha0.Text.Trim)
    End Sub

    Private Sub btnGravar1_Click(sender As Object, e As EventArgs) Handles btnGravar1.Click
        Gravar(1, cIp1.Text.Trim, cBaseDados1.Text.Trim, cUsuario1.Text.Trim, cSenha1.Text.Trim)
    End Sub

    Private Sub btnGravar2_Click(sender As Object, e As EventArgs) Handles btnGravar2.Click
        Gravar(2, cIp2.Text.Trim, cBaseDados2.Text.Trim, cUsuario2.Text.Trim, cSenha2.Text.Trim)
    End Sub

    Private Sub btnGravar3_Click(sender As Object, e As EventArgs) Handles btnGravar3.Click
        Gravar(3, cIp3.Text.Trim, cBaseDados3.Text.Trim, cUsuario3.Text.Trim, cSenha3.Text.Trim)
    End Sub

    Private Sub btnGravar4_Click(sender As Object, e As EventArgs) Handles btnGravar4.Click
        Gravar(4, cIp4.Text.Trim, cBaseDados4.Text.Trim, cUsuario4.Text.Trim, cSenha4.Text.Trim)
    End Sub

    Private Sub Gravar(n As Integer, tIp As String, tBd As String, tUs As String, tSn As String)
        Globais.Setting.Store("Unidade" & n, tIp)
        Globais.Setting.Store("DataBaseName" & n, tBd)
        Globais.Setting.Store("User" & n, tUs)
        Globais.Setting.Store("PassWord" & n, tSn)
    End Sub
End Class