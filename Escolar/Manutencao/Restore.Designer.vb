<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Restore
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Restore))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbRowInAllTable = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbRowInAllTable = New System.Windows.Forms.ProgressBar()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.BaseDados = New System.Windows.Forms.Label()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.bckPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.unidade = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bwImport = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbRowInAllTable)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.pbRowInAllTable)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(683, 67)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Progresso ]"
        '
        'lbRowInAllTable
        '
        Me.lbRowInAllTable.Location = New System.Drawing.Point(529, 16)
        Me.lbRowInAllTable.Name = "lbRowInAllTable"
        Me.lbRowInAllTable.Size = New System.Drawing.Size(145, 17)
        Me.lbRowInAllTable.TabIndex = 41
        Me.lbRowInAllTable.Text = "1/1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(7, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(521, 17)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Progresso Geral"
        '
        'pbRowInAllTable
        '
        Me.pbRowInAllTable.Location = New System.Drawing.Point(6, 33)
        Me.pbRowInAllTable.Name = "pbRowInAllTable"
        Me.pbRowInAllTable.Size = New System.Drawing.Size(671, 23)
        Me.pbRowInAllTable.TabIndex = 39
        '
        'btnRestore
        '
        Me.btnRestore.Enabled = False
        Me.btnRestore.Image = CType(resources.GetObject("btnRestore.Image"), System.Drawing.Image)
        Me.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRestore.Location = New System.Drawing.Point(397, 7)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnRestore.Size = New System.Drawing.Size(155, 23)
        Me.btnRestore.TabIndex = 44
        Me.btnRestore.Text = "Iniciar Restore"
        Me.btnRestore.UseVisualStyleBackColor = True
        '
        'BaseDados
        '
        Me.BaseDados.BackColor = System.Drawing.Color.White
        Me.BaseDados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.BaseDados.Image = CType(resources.GetObject("BaseDados.Image"), System.Drawing.Image)
        Me.BaseDados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BaseDados.Location = New System.Drawing.Point(237, 7)
        Me.BaseDados.Name = "BaseDados"
        Me.BaseDados.Size = New System.Drawing.Size(154, 20)
        Me.BaseDados.TabIndex = 43
        Me.BaseDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(659, 31)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(29, 23)
        Me.btnPath.TabIndex = 42
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'bckPath
        '
        Me.bckPath.BackColor = System.Drawing.Color.White
        Me.bckPath.Location = New System.Drawing.Point(180, 33)
        Me.bckPath.Name = "bckPath"
        Me.bckPath.ReadOnly = True
        Me.bckPath.Size = New System.Drawing.Size(473, 20)
        Me.bckPath.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(162, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Caminho do arquivo a Restaurar:"
        '
        'unidade
        '
        Me.unidade.FormattingEnabled = True
        Me.unidade.Location = New System.Drawing.Point(62, 6)
        Me.unidade.Name = "unidade"
        Me.unidade.Size = New System.Drawing.Size(169, 21)
        Me.unidade.TabIndex = 39
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Unidade:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'btCancel
        '
        Me.btCancel.Image = CType(resources.GetObject("btCancel.Image"), System.Drawing.Image)
        Me.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCancel.Location = New System.Drawing.Point(553, 7)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btCancel.Size = New System.Drawing.Size(135, 23)
        Me.btCancel.TabIndex = 46
        Me.btCancel.Text = "Parar Restore"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'Restore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 143)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnRestore)
        Me.Controls.Add(Me.BaseDados)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.bckPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.unidade)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btCancel)
        Me.Name = "Restore"
        Me.Text = "Restore"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbRowInAllTable As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pbRowInAllTable As ProgressBar
    Friend WithEvents btnRestore As Button
    Friend WithEvents BaseDados As Label
    Friend WithEvents btnPath As Button
    Friend WithEvents bckPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents unidade As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents bwImport As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btCancel As Button
End Class
