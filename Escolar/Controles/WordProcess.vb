Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports MySql.Data.MySqlClient

Public Class WordProcess
    Private dbMain As [Db] = New Db
    Private match As DataGridViewCell()
    Private pos As Integer
    Private first As Boolean = True

    Private Sub WordProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulaDGVAlunos(NumericUpDownAno.Value)
        first = False
    End Sub

    Private Sub LabelClear_Click(sender As Object, e As EventArgs) Handles LabelClear.Click
        pos = -1
        LabelClear.Enabled = False
        LabelPrevious.Enabled = False
        LabelNext.Enabled = False

        TextBoxBuscar.Text = ""
        TextBoxBuscar.Focus()
    End Sub

    Private Sub TextBoxBuscar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxBuscar.TextChanged
        If TextBoxBuscar.Text.Length = 0 Then
            pos = -1
            match = Nothing
            DataGridViewAlunos.Refresh()
            LabelClear.Enabled = False
            Exit Sub
        End If

        LabelClear.Enabled = True
        match = (From row As DataGridViewRow In DataGridViewAlunos.Rows From cell As DataGridViewCell In row.Cells Select cell Where CStr(cell.FormattedValue).Contains(TextBoxBuscar.Text.ToUpper.Trim)).ToArray()

        If match.Length > 0 Then
            pos = 0
            DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
            DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex

            If match.Length = 1 Then
                LabelNext.Enabled = False
                LabelPrevious.Enabled = False
            Else
                LabelNext.Enabled = True
                LabelPrevious.Enabled = False
            End If
        End If

        If match.Length <= 0 Then
            pos = -1
            LabelNext.Enabled = False
            LabelPrevious.Enabled = False
        End If
    End Sub

    Private Sub PopulaDGVAlunos(ano As Integer)
        Dim sql As String = "SELECT al.`id` id, al.`matricula` matricula, al.`nome` nome FROM `alunos` al, `turmas_alunos` ta WHERE ta.`idaluno` = al.`id` and ta.`ano` = @ano;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@ano", ano})})
        Dim datatable As New DataTable("AlunosAno")
        datatable.Columns.Add("id", GetType(Integer))
        datatable.Columns.Add("matricula", GetType(String))
        datatable.Columns.Add("nome", GetType(String))
        datatable.Load(vrs)
        dbMain.CloseAll(conn, vrs)

        With DataGridViewAlunos
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

            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).HeaderText = "id"
            .Columns(0).Width = 60
            .Columns(0).ReadOnly = True
            .Columns(0).Visible = False

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).HeaderText = "matricula"
            .Columns(1).Width = 80
            .Columns(1).ReadOnly = True

            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(2).HeaderText = "nome"
            .Columns(2).Width = 280
            .Columns(2).ReadOnly = True
        End With

    End Sub

    Private Sub NumericUpDownAno_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownAno.ValueChanged
        If Not first Then PopulaDGVAlunos(NumericUpDownAno.Value)
    End Sub

    Private Sub LabelPrevious_Click(sender As Object, e As EventArgs) Handles LabelPrevious.Click
        pos -= 1
        LabelNext.Enabled = True
        LabelPrevious.Enabled = True
        If pos <= 0 Then
            pos = 0
            LabelPrevious.Enabled = False
            LabelNext.Enabled = True
        End If
        DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub

    Private Sub LabelNext_Click(sender As Object, e As EventArgs) Handles LabelNext.Click
        pos += 1
        LabelNext.Enabled = True
        LabelPrevious.Enabled = True
        If pos >= match.Length - 1 Then
            pos = match.Length - 1
            LabelPrevious.Enabled = True
            LabelNext.Enabled = False
        End If
        DataGridViewAlunos.Rows(match(pos).RowIndex).Selected = True
        DataGridViewAlunos.FirstDisplayedScrollingRowIndex = match(pos).RowIndex
    End Sub

    Private Sub DocClear_Click(sender As Object, e As EventArgs) Handles DocClear.Click
        DocClear.Enabled = False
        DocFiles.Enabled = True

        DocFileName.Text = ""
        DocFileName.Focus()
    End Sub

    Private Sub DocFiles_Click(sender As Object, e As EventArgs) Handles DocFiles.Click
        Dim fd As OpenFileDialog = New OpenFileDialog
        fd.InitialDirectory = FileIO.SpecialDirectories.MyDocuments
        fd.RestoreDirectory = True
        fd.Title = "Selecione o arquivo a Imprimir..."
        fd.DefaultExt = "docx"
        fd.Filter = "docx files (*.docx)|*.docx"
        fd.FilterIndex = 1
        fd.CheckFileExists = True
        fd.CheckPathExists = True
        '// fd.Multiselect = False

        Dim dr As DialogResult = fd.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then
            DocFileName.Text = fd.FileName
        End If

        DocClear.Enabled = DocFileName.Text.Trim.Length > 0
        DocFiles.Enabled = Not DocFileName.Text.Trim.Length > 0
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If DocFileName.Text.Trim.Length <= 0 Then
            MsgBox("Voce tem de selecionar um modelo de texto!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Atenção")
            Return
        End If

        Dim oWordApplication As Word.Application = New Word.Application()
        Dim sDocFilePath As Object = DocFileName.Text
        Dim oWordDocument As Word.Document = oWordApplication.Documents.Open(sDocFilePath,, True)
        Dim range As Word.Range
        Dim findText As String = "\<\@*\>"
        '//Dim findText As String = "\<\@*_*>\>"
        findText = "\<\@*\>"

        While True
            range = oWordDocument.Range
            With range.Find
                .Text = findText
                .Forward = True
            End With
            Dim textSel As String = ""

            While range.Find.Execute(findText, MatchCase:=False, MatchWholeWord:=True, MatchWildcards:=True)
                Dim selText As String = range.Text
                textSel = selText
                If selText.Trim.Length = 0 Then Exit While

                Dim fieldName As String = Strings.Mid(selText, 3)
                fieldName = Strings.Mid(fieldName, 1, fieldName.Length - 1)
                Dim replaceText As String = ""

                Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
                Dim selectSQL As String = "SELECT * FROM `alunos` WHERE `id` = @id"
                Dim param As Object()() = New Object()() {
                    ({"@id", DataGridViewAlunos.SelectedRows.Item(0).Cells("id").Value.ToString.Trim})
                }
                Dim tcadfun As MySqlDataReader = dbMain.OpenTable(conn, selectSQL, param)
                Try
                    If tcadfun.HasRows Then
                        While tcadfun.Read
                            replaceText = tcadfun(fieldName).ToString
                            If fieldName.Contains("cpf") Then
                                replaceText = Strings.Mid(replaceText, 1, 3) + "." + Strings.Mid(replaceText, 4, 3) + "." + Strings.Mid(replaceText, 7, 3) + "-" + Strings.Mid(replaceText, 10)
                            ElseIf fieldName.Contains("cep") Then
                                replaceText = Strings.Mid(replaceText, 1, 5) + "-" + Strings.Mid(replaceText, 6)
                            End If
                        End While
                    End If
                Catch ex As Exception
                    MsgBox("Variavel " + fieldName + " não encontrada! Corriga o texto e tente novamente...")
                    dbMain.CloseAll(conn, tcadfun)
                    Return
                End Try
                dbMain.CloseAll(conn, tcadfun)

                range.Text = replaceText
            End While

            If textSel.Trim.Length = 0 Then Exit While
        End While

        oWordDocument.PrintOut(Background:=False)
        oWordDocument.Close(SaveChanges:=False)
        oWordApplication.Quit()
        Marshal.ReleaseComObject(oWordApplication)
    End Sub
End Class