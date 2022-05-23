Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class BackUp
    Private dbMain As [Db] = New Db
    Private conn As MySqlConnection = Nothing
    Private mb As MySqlBackup

    Private _currentTableName As String = ""
    Private _totalRowsInCurrentTable As Integer = 0
    Private _totalRowsInAllTables As Integer = 0
    Private _currentRowIndexInCurrentTable As Integer = 0
    Private _currentRowIndexInAllTable As Integer = 0
    Private _totalTables As Integer = 0
    Private _currentTableIndex As Integer = 0
    Private cancel As Boolean = False

    Private Sub BackUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadIpBase()
        bckFile.Text = CreateFileNameBackUp()
    End Sub

    Private Function CreateFileNameBackUp() As String
        Return Globais.databaseName & "_" & Format(Now, "ddMMyyyy_HHmm") & ".sql"
    End Function

    Private Sub LoadIpBase()
        unidade.Items.Clear()
        unidade.DataSource = Nothing
        Dim datatable As New DataTable("Config")
        datatable.Columns.Add("Ip", GetType(String))
        datatable.Columns.Add("BaseDados", GetType(String))
        datatable.Columns.Add("User", GetType(String))
        datatable.Columns.Add("PassWord", GetType(String))

        For n = 0 To 4
            Dim nIP As String = Setting.Load("Unidade" & n, If(n = 0, "127.0.0.1", ""))
            Dim nDataBase As String = Setting.Load("DataBaseName" & n, If(n = 0, "escola", ""))
            Dim nUser As String = Setting.Load("User" & n, If(n = 0, "root", ""))
            Dim nPassWord As String = Setting.Load("PassWord" & n, If(n = 0, "7kf51b", ""))

            If nIP.Trim <> "" Then
                datatable.Rows.Add({nIP, nDataBase, nUser, nPassWord})
            End If
        Next

        unidade.DataSource = datatable
        unidade.DisplayMember = "Ip"
        unidade.ValueMember = "Ip"
    End Sub

    Private Sub unidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unidade.SelectedIndexChanged
        BaseDados.Text = unidade.SelectedItem("BaseDados")
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
                Globais.unidade = unidade.SelectedItem("Ip")
                Globais.databaseName = unidade.SelectedItem("BaseDados")
                Globais.user = unidade.SelectedItem("User")
                Globais.pwd = unidade.SelectedItem("PassWord")
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
            conn = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName, "charset=utf8;convertzerodatetime=true;")
            If Not IsNothing(conn) Then
                '//
                bckFile.Text = CreateFileNameBackUp()
                btExport.Enabled = True
                btExport.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnBackUp_Click(sender As Object, e As EventArgs) Handles btExport.Click
        If bckPath.Text.Trim = "" Then
            MsgBox("Você deve selecionar um caminho para o arquivo de cópia.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Atenção")
            Exit Sub
        End If

        btnReset.Enabled = False
        btExport.Enabled = False
        btCancel.Enabled = True

        cancel = False
        _currentTableName = ""
        _totalRowsInCurrentTable = 0
        _totalRowsInAllTables = 0
        _currentRowIndexInCurrentTable = 0
        _currentRowIndexInAllTable = 0
        _totalTables = 0
        _currentTableIndex = 0

        Dim cmd As MySqlCommand = New MySqlCommand()
        cmd.Connection = conn
        mb = New MySqlBackup(cmd)
        AddHandler mb.ExportProgressChanged, New MySqlBackup.exportProgressChange(AddressOf mb_ExportProgressChanged)

        ' mb.ExportInfo.AddDropDatabase = addDropDatabases.Checked
        mb.ExportInfo.AddCreateDatabase = addCreateDatabases.Checked

        ' mb.ExportInfo.AddDropTable = addDropTables.Checked
        mb.ExportInfo.ExportTableStructure = addCreateTables.Checked
        'mb.ExportInfo.ExportRows = False
        ' mb.ExportInfo.BlobExportMode = BlobDataExportMode.HexString

        'mb.ExportInfo.ExportProcedures = ExportAll.Checked
        'mb.ExportInfo.ExportFunctions = ExportAll.Checked
        'mb.ExportInfo.ExportViews = ExportAll.Checked
        'mb.ExportInfo.ExportEvents = ExportAll.Checked
        'mb.ExportInfo.ExportTriggers = ExportAll.Checked
        Timer1.Start()

        mb.ExportInfo.IntervalForProgressReport = 50

        bwExport.RunWorkerAsync()
    End Sub

    Private Sub mb_ExportProgressChanged(sender As Object, e As ExportProgressArgs)
        If cancel Then
            mb.StopAllProcess()
            Return
        End If

        _currentRowIndexInAllTable = CInt(e.CurrentRowIndexInAllTables)
        _currentRowIndexInCurrentTable = CInt(e.CurrentRowIndexInCurrentTable)
        _currentTableIndex = e.CurrentTableIndex
        _currentTableName = e.CurrentTableName
        _totalRowsInAllTables = CInt(e.TotalRowsInAllTables)
        _totalRowsInCurrentTable = CInt(e.TotalRowsInCurrentTable)
        _totalTables = e.TotalTables
    End Sub

    Private Sub unidade_Enter(sender As Object, e As EventArgs) Handles unidade.Enter
        btExport.Enabled = False
        btCancel.Enabled = False
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        bckFile.Text = CreateFileNameBackUp()
    End Sub

    Private Sub btnPath_Click(sender As Object, e As EventArgs) Handles btnPath.Click
        Dim ofdOpen As New FolderBrowserDialog()
        With ofdOpen
            '// .Description = Globais.appPathBackUp
            .SelectedPath = Globais.appPathBackUp
            .ShowNewFolderButton = True
        End With

        ofdOpen.ShowDialog(Me)
        If ofdOpen.ShowDialog() = DialogResult.OK Then bckPath.Text = ofdOpen.SelectedPath
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If cancel Then
            Timer1.Enabled = False
            Return
        End If

        pbTable.Maximum = _totalTables
        If _currentTableIndex <= pbTable.Maximum Then pbTable.Value = _currentTableIndex
        pbRowInCurTable.Maximum = _totalRowsInCurrentTable
        If _currentRowIndexInCurrentTable <= pbRowInCurTable.Maximum Then pbRowInCurTable.Value = _currentRowIndexInCurrentTable
        pbRowInAllTable.Maximum = _totalRowsInAllTables
        If _currentRowIndexInAllTable <= pbRowInAllTable.Maximum Then pbRowInAllTable.Value = _currentRowIndexInAllTable
        lbCurrentTableName.Text = "Processando a Tabela = " & _currentTableName
        lbRowInCurTable.Text = CStr(pbRowInCurTable.Value) & " de " + CStr(pbRowInCurTable.Maximum)
        lbRowInAllTable.Text = CStr(pbRowInAllTable.Value) & " de " + CStr(pbRowInAllTable.Maximum)
        lbTableCount.Text = Str(_currentTableIndex) & " de " + CStr(_totalTables)
    End Sub

    Private Sub bwExport_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwExport.DoWork
        Try
            mb.ExportToFile(bckPath.Text.Trim & "\\" & bckFile.Text.Trim)
        Catch ex As Exception
            cancel = True
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub bwExport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwExport.RunWorkerCompleted
        If (cancel) Then
            MessageBox.Show("Cancel by user.")
        Else
            If (mb.LastError Is Nothing) Then
                pbRowInAllTable.Value = pbRowInAllTable.Maximum
                pbRowInCurTable.Value = pbRowInCurTable.Maximum
                pbTable.Value = pbTable.Maximum
                MessageBox.Show("Completed.")
            Else
                MessageBox.Show("Completed with error(s)." + Environment.NewLine + Environment.NewLine + mb.LastError.ToString())
            End If
        End If

        Timer1.Stop()

        btnReset.Enabled = True
        btExport.Enabled = True
        btCancel.Enabled = False
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        cancel = True
    End Sub
End Class