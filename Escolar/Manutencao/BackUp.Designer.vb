<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BackUp))
        Me.bwExport = New System.ComponentModel.BackgroundWorker()
        Me.lbRowInAllTable = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbRowInAllTable = New System.Windows.Forms.ProgressBar()
        Me.lbRowInCurTable = New System.Windows.Forms.Label()
        Me.lbTableCount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbRowInCurTable = New System.Windows.Forms.ProgressBar()
        Me.lbCurrentTableName = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pbTable = New System.Windows.Forms.ProgressBar()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.bckFile = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExportAll = New System.Windows.Forms.CheckBox()
        Me.addCreateTables = New System.Windows.Forms.CheckBox()
        Me.addDropTables = New System.Windows.Forms.CheckBox()
        Me.addCreateDatabases = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.addDropDatabases = New System.Windows.Forms.CheckBox()
        Me.btExport = New System.Windows.Forms.Button()
        Me.BaseDados = New System.Windows.Forms.Label()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.bckPath = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.unidade = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbRowInAllTable
        '
        Me.lbRowInAllTable.Location = New System.Drawing.Point(534, 97)
        Me.lbRowInAllTable.Name = "lbRowInAllTable"
        Me.lbRowInAllTable.Size = New System.Drawing.Size(145, 17)
        Me.lbRowInAllTable.TabIndex = 41
        Me.lbRowInAllTable.Text = "1/1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(7, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(521, 17)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Progresso Geral"
        '
        'pbRowInAllTable
        '
        Me.pbRowInAllTable.Location = New System.Drawing.Point(6, 114)
        Me.pbRowInAllTable.Name = "pbRowInAllTable"
        Me.pbRowInAllTable.Size = New System.Drawing.Size(673, 23)
        Me.pbRowInAllTable.TabIndex = 39
        '
        'lbRowInCurTable
        '
        Me.lbRowInCurTable.Location = New System.Drawing.Point(534, 54)
        Me.lbRowInCurTable.Name = "lbRowInCurTable"
        Me.lbRowInCurTable.Size = New System.Drawing.Size(145, 17)
        Me.lbRowInCurTable.TabIndex = 38
        Me.lbRowInCurTable.Text = "1/1"
        '
        'lbTableCount
        '
        Me.lbTableCount.Location = New System.Drawing.Point(531, 13)
        Me.lbTableCount.Name = "lbTableCount"
        Me.lbTableCount.Size = New System.Drawing.Size(145, 17)
        Me.lbTableCount.TabIndex = 37
        Me.lbTableCount.Text = "1/1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(521, 17)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Linhas na tabela corrente."
        '
        'pbRowInCurTable
        '
        Me.pbRowInCurTable.Location = New System.Drawing.Point(6, 71)
        Me.pbRowInCurTable.Name = "pbRowInCurTable"
        Me.pbRowInCurTable.Size = New System.Drawing.Size(673, 23)
        Me.pbRowInCurTable.TabIndex = 35
        '
        'lbCurrentTableName
        '
        Me.lbCurrentTableName.Location = New System.Drawing.Point(7, 13)
        Me.lbCurrentTableName.Name = "lbCurrentTableName"
        Me.lbCurrentTableName.Size = New System.Drawing.Size(521, 17)
        Me.lbCurrentTableName.TabIndex = 34
        Me.lbCurrentTableName.Text = "Tabela"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbRowInAllTable)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.pbRowInAllTable)
        Me.GroupBox1.Controls.Add(Me.lbRowInCurTable)
        Me.GroupBox1.Controls.Add(Me.lbTableCount)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.pbRowInCurTable)
        Me.GroupBox1.Controls.Add(Me.lbCurrentTableName)
        Me.GroupBox1.Controls.Add(Me.pbTable)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 146)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(685, 143)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "[ Progresso ]"
        '
        'pbTable
        '
        Me.pbTable.Location = New System.Drawing.Point(6, 30)
        Me.pbTable.Name = "pbTable"
        Me.pbTable.Size = New System.Drawing.Size(673, 23)
        Me.pbTable.TabIndex = 33
        '
        'btCancel
        '
        Me.btCancel.Image = CType(resources.GetObject("btCancel.Image"), System.Drawing.Image)
        Me.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btCancel.Location = New System.Drawing.Point(549, 7)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btCancel.Size = New System.Drawing.Size(151, 23)
        Me.btCancel.TabIndex = 52
        Me.btCancel.Text = "Parar BackUp"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(671, 59)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(29, 23)
        Me.btnReset.TabIndex = 51
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'bckFile
        '
        Me.bckFile.BackColor = System.Drawing.Color.White
        Me.bckFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bckFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bckFile.Location = New System.Drawing.Point(299, 59)
        Me.bckFile.Name = "bckFile"
        Me.bckFile.ReadOnly = True
        Me.bckFile.Size = New System.Drawing.Size(366, 22)
        Me.bckFile.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(190, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Arquivo de BackUp:"
        '
        'ExportAll
        '
        Me.ExportAll.AutoSize = True
        Me.ExportAll.Checked = True
        Me.ExportAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ExportAll.Location = New System.Drawing.Point(466, 100)
        Me.ExportAll.Name = "ExportAll"
        Me.ExportAll.Size = New System.Drawing.Size(234, 17)
        Me.ExportAll.TabIndex = 48
        Me.ExportAll.Text = "Export Procedures, Functions, Tigers, Views"
        Me.ExportAll.UseVisualStyleBackColor = True
        '
        'addCreateTables
        '
        Me.addCreateTables.AutoSize = True
        Me.addCreateTables.Checked = True
        Me.addCreateTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.addCreateTables.Location = New System.Drawing.Point(193, 123)
        Me.addCreateTables.Name = "addCreateTables"
        Me.addCreateTables.Size = New System.Drawing.Size(109, 17)
        Me.addCreateTables.TabIndex = 47
        Me.addCreateTables.Text = "Add Create Table"
        Me.addCreateTables.UseVisualStyleBackColor = True
        '
        'addDropTables
        '
        Me.addDropTables.AutoSize = True
        Me.addDropTables.Checked = True
        Me.addDropTables.CheckState = System.Windows.Forms.CheckState.Checked
        Me.addDropTables.Location = New System.Drawing.Point(16, 123)
        Me.addDropTables.Name = "addDropTables"
        Me.addDropTables.Size = New System.Drawing.Size(101, 17)
        Me.addDropTables.TabIndex = 46
        Me.addDropTables.Text = "Add Drop Table"
        Me.addDropTables.UseVisualStyleBackColor = True
        '
        'addCreateDatabases
        '
        Me.addCreateDatabases.AutoSize = True
        Me.addCreateDatabases.Checked = True
        Me.addCreateDatabases.CheckState = System.Windows.Forms.CheckState.Checked
        Me.addCreateDatabases.Location = New System.Drawing.Point(193, 100)
        Me.addCreateDatabases.Name = "addCreateDatabases"
        Me.addCreateDatabases.Size = New System.Drawing.Size(128, 17)
        Me.addCreateDatabases.TabIndex = 45
        Me.addCreateDatabases.Text = "Add Create Database"
        Me.addCreateDatabases.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Opções:"
        '
        'addDropDatabases
        '
        Me.addDropDatabases.AutoSize = True
        Me.addDropDatabases.Checked = True
        Me.addDropDatabases.CheckState = System.Windows.Forms.CheckState.Checked
        Me.addDropDatabases.Location = New System.Drawing.Point(15, 100)
        Me.addDropDatabases.Name = "addDropDatabases"
        Me.addDropDatabases.Size = New System.Drawing.Size(120, 17)
        Me.addDropDatabases.TabIndex = 43
        Me.addDropDatabases.Text = "Add Drop Database"
        Me.addDropDatabases.UseVisualStyleBackColor = True
        '
        'btExport
        '
        Me.btExport.Enabled = False
        Me.btExport.Image = CType(resources.GetObject("btExport.Image"), System.Drawing.Image)
        Me.btExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btExport.Location = New System.Drawing.Point(397, 7)
        Me.btExport.Name = "btExport"
        Me.btExport.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btExport.Size = New System.Drawing.Size(146, 23)
        Me.btExport.TabIndex = 42
        Me.btExport.Text = "Iniciar BackUp"
        Me.btExport.UseVisualStyleBackColor = True
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
        Me.BaseDados.TabIndex = 41
        Me.BaseDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(671, 31)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(29, 23)
        Me.btnPath.TabIndex = 40
        Me.btnPath.Text = "..."
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'bckPath
        '
        Me.bckPath.BackColor = System.Drawing.Color.White
        Me.bckPath.Location = New System.Drawing.Point(193, 33)
        Me.bckPath.Name = "bckPath"
        Me.bckPath.ReadOnly = True
        Me.bckPath.Size = New System.Drawing.Size(472, 20)
        Me.bckPath.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Caminho para o arquivo de BackUp:"
        '
        'unidade
        '
        Me.unidade.FormattingEnabled = True
        Me.unidade.Location = New System.Drawing.Point(62, 6)
        Me.unidade.Name = "unidade"
        Me.unidade.Size = New System.Drawing.Size(169, 21)
        Me.unidade.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Unidade:"
        '
        'BackUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 298)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.bckFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ExportAll)
        Me.Controls.Add(Me.addCreateTables)
        Me.Controls.Add(Me.addDropTables)
        Me.Controls.Add(Me.addCreateDatabases)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.addDropDatabases)
        Me.Controls.Add(Me.btExport)
        Me.Controls.Add(Me.BaseDados)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.bckPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.unidade)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BackUp"
        Me.Text = "BackUp"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bwExport As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbRowInAllTable As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pbRowInAllTable As ProgressBar
    Friend WithEvents lbRowInCurTable As Label
    Friend WithEvents lbTableCount As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pbRowInCurTable As ProgressBar
    Friend WithEvents lbCurrentTableName As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pbTable As ProgressBar
    Friend WithEvents btCancel As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents bckFile As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ExportAll As CheckBox
    Friend WithEvents addCreateTables As CheckBox
    Friend WithEvents addDropTables As CheckBox
    Friend WithEvents addCreateDatabases As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents addDropDatabases As CheckBox
    Friend WithEvents btExport As Button
    Friend WithEvents BaseDados As Label
    Friend WithEvents btnPath As Button
    Friend WithEvents bckPath As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents unidade As ComboBox
    Friend WithEvents Label1 As Label
End Class
