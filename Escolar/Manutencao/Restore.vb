Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class Restore
    Private dbMain As [Db] = New Db
    Private conn As MySqlConnection = Nothing
    Private mb As MySqlBackup

    Private _totalBytes As Integer = 0
    Private _currentBytes As Integer = 0
    Private cancel As Boolean = False

    Private Sub unidade_Enter(sender As Object, e As EventArgs) Handles unidade.Enter
        btnRestore.Enabled = False
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If bckPath.Text.Trim = "" Then
#Disable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            MsgBox("Você deve selecionar o caminho do arquivo a Restaurar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
#Enable Warning BC42016 ' Conversão implícita de "Integer" para "MsgBoxStyle".
            Exit Sub
        End If

        btnRestore.Enabled = False
        btCancel.Enabled = True

        '// Setar para 1G
        dbMain.ExecuteCmdMaster("SET GLOBAL max_allowed_packet=1024*1024*1024;")
        dbMain.ExecuteCmdMaster("DROP SCHEMA IF EXISTS " & Globais.databaseName.Trim & ";")

        Dim cmd As MySqlCommand = New MySqlCommand() With {
                .CommandTimeout = 0
            }
        '// cmd.CommandText = "SET GLOBAL max_allowed_packet=1024*1024*1024;"
        cmd.Connection = conn
        mb = New MySqlBackup(cmd)
        AddHandler mb.ImportProgressChanged, New MySqlBackup.importProgressChange(AddressOf mb_ImportProgressChanged)

        Timer1.Start()
        mb.ImportInfo.IntervalForProgressReport = 50
        bwImport.RunWorkerAsync()

    End Sub

    Private Sub unidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unidade.SelectedIndexChanged
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
        BaseDados.Text = unidade.SelectedItem("BaseDados")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
    End Sub

    Private Sub unidade_KeyDown(sender As Object, e As KeyEventArgs) Handles unidade.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub unidade_KeyUp(sender As Object, e As KeyEventArgs) Handles unidade.KeyUp
        If e.KeyCode = Keys.Escape Then
            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then conn.Close()
            End If
            End
        End If

        If e.KeyCode = Keys.Return And unidade.Text.Length > 0 Then
            If Funcoes.IsValidIP(unidade.Text) Then
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                Globais.unidade = unidade.SelectedItem("Ip")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
                Globais.databaseName = unidade.SelectedItem("BaseDados")
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
                Globais.user = unidade.SelectedItem("User")
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
                Globais.pwd = unidade.SelectedItem("PassWord")
#Enable Warning BC42017 ' Resolução de associação tardia; poderão ocorrer erros de tempo de execução.
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
            Else
                MsgBox("Ip invalido")
                unidade.Focus()
                Exit Sub
            End If

            If Not IsNothing(conn) Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If
            conn = dbMain.OpenDBMaster(Globais.unidade, Globais.user, Globais.pwd, "charset=utf8;convertzerodatetime=true;")
            If Not IsNothing(conn) Then
                btnRestore.Enabled = True
                btnRestore.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Restore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIpBase()

        btCancel.Enabled = False
        btnRestore.Enabled = True
    End Sub

    Private Sub LoadIpBase()
        unidade.Items.Clear()
        unidade.DataSource = Nothing
        Dim datatable As New DataTable("Config")
        datatable.Columns.Add("Ip", GetType(String))
        datatable.Columns.Add("BaseDados", GetType(String))
        datatable.Columns.Add("User", GetType(String))
        datatable.Columns.Add("PassWord", GetType(String))

        For n = 0 To 4
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
            Dim nIP As String = Setting.Load("Unidade" & n, If(n = 0, "127.0.0.1", ""))
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
            Dim nDataBase As String = Setting.Load("DataBaseName" & n, If(n = 0, "cicle", ""))
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
            Dim nUser As String = Setting.Load("User" & n, If(n = 0, "root", ""))
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".
#Disable Warning BC42016 ' Conversão implícita de "Object" para "String".
            Dim nPassWord As String = Setting.Load("PassWord" & n, If(n = 0, "7kf51b", ""))
#Enable Warning BC42016 ' Conversão implícita de "Object" para "String".

            If nIP.Trim <> "" Then
                datatable.Rows.Add({nIP, nDataBase, nUser, nPassWord})
            End If
        Next

        unidade.DataSource = datatable
        unidade.DisplayMember = "Ip"
        unidade.ValueMember = "Ip"
    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        Dim ofdOpen As New OpenFileDialog()
        ofdOpen.InitialDirectory = Globais.appPathBackUp
        ofdOpen.Filter = "sql files (*.sql)|*.sql"
        ofdOpen.FilterIndex = 2
        ofdOpen.RestoreDirectory = True

        If ofdOpen.ShowDialog(Me) = DialogResult.OK Then bckPath.Text = ofdOpen.FileName
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If cancel Then
            Timer1.Enabled = False
            Return
        End If

        pbRowInAllTable.Maximum = _totalBytes
        lbRowInAllTable.Text = CStr(_currentBytes) & " de " + CStr(_totalBytes)
        pbRowInAllTable.Value = _currentBytes
    End Sub

    Private Sub mb_ImportProgressChanged(sender As Object, e As ImportProgressArgs)
        If cancel Then
            mb.StopAllProcess()
            Return
        End If

        _totalBytes = CInt(e.TotalBytes)
        _currentBytes = CInt(e.CurrentBytes)

    End Sub

    Private Sub bwImport_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwImport.DoWork
        Dim importFileName As String = bckPath.Text.Trim
        Try
            With mb
                '// Importar backup
                .ImportFromFile(importFileName)
            End With
        Catch ex As Exception
            cancel = True
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub bwImport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwImport.RunWorkerCompleted
        If (cancel) Then
            MessageBox.Show("Cancel by user.")
        Else
            If (mb.LastError Is Nothing) Then
                pbRowInAllTable.Value = pbRowInAllTable.Maximum
                MessageBox.Show("Completed.")
            Else
                MessageBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString())
            End If
        End If

        Timer1.Stop()

        btnRestore.Enabled = True
        btCancel.Enabled = False
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        cancel = True
    End Sub

    Private Sub Restore_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        cancel = True
    End Sub
End Class