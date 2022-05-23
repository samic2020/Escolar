Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class Pendencias
    Private dbMain As [Db] = New Db

    Private _idAluno As Integer = -1

    WriteOnly Property idAluno As Integer
        Set(ByVal value As Integer)
            _idAluno = value
        End Set
    End Property

    Private Sub pendListaAdc_Click(sender As Object, e As EventArgs) Handles pendListaAdc.Click
        pendLista.Items.Add("item")
    End Sub

    Private Sub pendListaDel_Click(sender As Object, e As EventArgs) Handles pendListaDel.Click
        Dim canDelete As Boolean = True
        canDelete = (MessageBox.Show("Exclui pendência(s)?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)

        If canDelete Then
            ' Delete all selected items
            While pendLista.SelectedItems.Count > 0
                '// Auditor
                Auditor.auditor("Pendências", "Exclusão", "Item: ", pendLista.SelectedItem)

                pendLista.Items.Remove(pendLista.SelectedItem)
            End While
        End If

        pendLista.DeleteSelectedItems()
    End Sub

    Private Sub Pendencias_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        insertPendencias(_idAluno, pendLista)
    End Sub

    Private Sub insertPendencias(idaluno As Integer, value As ComboEditListBox)
        Dim deleteSQL As String = "DELETE FROM `alunos_pendencias` WHERE `idaluno` = @idaluno;"
        dbMain.ExecuteCmd(deleteSQL, {({"@idaluno", idaluno})})
        Dim insertSQL As String = "INSERT INTO `alunos_pendencias`(`idaluno`,`pendencia`) VALUES (@idaluno, @pendencia);"
        If value IsNot Nothing Then
            For Each item As String In value.Items
                If Not item.ToString.Trim.ToUpper.Equals("ITEM") Then
                    dbMain.ExecuteCmd(insertSQL, {({"@idaluno", idaluno}), ({"@pendencia", item.ToString})})
                End If
            Next
        End If
    End Sub

    Private Sub Pendencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT `pendencia` FROM `alunos_pendencias` WHERE `idaluno` = @idaluno ORDER BY `pendencia`;"
        Dim conn As MySqlConnection = dbMain.OpenDB(Globais.unidade, Globais.user, Globais.pwd, Globais.databaseName)
        Dim vrs As MySqlDataReader = dbMain.OpenTable(conn, sql, {({"@idaluno", _idAluno})})

        pendLista.Items.Clear()
        If vrs.HasRows Then
            Try
                While vrs.Read
                    pendLista.Items.Add(vrs.GetString("pendencia"))
                End While
            Catch ex As Exception
            End Try
        End If
        dbMain.CloseAll(conn, vrs)

    End Sub
End Class