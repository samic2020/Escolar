<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WordProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WordProcess))
        Me.LabelNext = New System.Windows.Forms.Label()
        Me.LabelPrevious = New System.Windows.Forms.Label()
        Me.NumericUpDownAno = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.LabelClear = New System.Windows.Forms.Label()
        Me.TextBoxBuscar = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridViewAlunos = New System.Windows.Forms.DataGridView()
        Me.DocClear = New System.Windows.Forms.Label()
        Me.DocFileName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DocFiles = New System.Windows.Forms.Label()
        CType(Me.NumericUpDownAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewAlunos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelNext
        '
        Me.LabelNext.AutoSize = True
        Me.LabelNext.Enabled = False
        Me.LabelNext.Location = New System.Drawing.Point(376, 174)
        Me.LabelNext.Name = "LabelNext"
        Me.LabelNext.Size = New System.Drawing.Size(13, 13)
        Me.LabelNext.TabIndex = 21
        Me.LabelNext.Text = ">"
        '
        'LabelPrevious
        '
        Me.LabelPrevious.AutoSize = True
        Me.LabelPrevious.Enabled = False
        Me.LabelPrevious.Location = New System.Drawing.Point(360, 174)
        Me.LabelPrevious.Name = "LabelPrevious"
        Me.LabelPrevious.Size = New System.Drawing.Size(13, 13)
        Me.LabelPrevious.TabIndex = 20
        Me.LabelPrevious.Text = "<"
        '
        'NumericUpDownAno
        '
        Me.NumericUpDownAno.Location = New System.Drawing.Point(318, 7)
        Me.NumericUpDownAno.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.NumericUpDownAno.Minimum = New Decimal(New Integer() {2022, 0, 0, 0})
        Me.NumericUpDownAno.Name = "NumericUpDownAno"
        Me.NumericUpDownAno.Size = New System.Drawing.Size(77, 20)
        Me.NumericUpDownAno.TabIndex = 19
        Me.NumericUpDownAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDownAno.Value = New Decimal(New Integer() {2022, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Ano Letivo:"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(268, 222)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.BtnPrint.Size = New System.Drawing.Size(127, 23)
        Me.BtnPrint.TabIndex = 16
        Me.BtnPrint.Text = "Imprimir"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'LabelClear
        '
        Me.LabelClear.AutoSize = True
        Me.LabelClear.Enabled = False
        Me.LabelClear.Location = New System.Drawing.Point(340, 174)
        Me.LabelClear.Name = "LabelClear"
        Me.LabelClear.Size = New System.Drawing.Size(14, 13)
        Me.LabelClear.TabIndex = 15
        Me.LabelClear.Text = "X"
        '
        'TextBoxBuscar
        '
        Me.TextBoxBuscar.Location = New System.Drawing.Point(45, 171)
        Me.TextBoxBuscar.Name = "TextBoxBuscar"
        Me.TextBoxBuscar.Size = New System.Drawing.Size(350, 20)
        Me.TextBoxBuscar.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Aluno:"
        '
        'DataGridViewAlunos
        '
        Me.DataGridViewAlunos.AllowUserToAddRows = False
        Me.DataGridViewAlunos.AllowUserToDeleteRows = False
        Me.DataGridViewAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewAlunos.Location = New System.Drawing.Point(12, 33)
        Me.DataGridViewAlunos.Name = "DataGridViewAlunos"
        Me.DataGridViewAlunos.ReadOnly = True
        Me.DataGridViewAlunos.Size = New System.Drawing.Size(383, 132)
        Me.DataGridViewAlunos.TabIndex = 12
        '
        'DocClear
        '
        Me.DocClear.AutoSize = True
        Me.DocClear.Enabled = False
        Me.DocClear.Location = New System.Drawing.Point(360, 200)
        Me.DocClear.Name = "DocClear"
        Me.DocClear.Size = New System.Drawing.Size(14, 13)
        Me.DocClear.TabIndex = 24
        Me.DocClear.Text = "X"
        '
        'DocFileName
        '
        Me.DocFileName.Location = New System.Drawing.Point(72, 197)
        Me.DocFileName.Name = "DocFileName"
        Me.DocFileName.ReadOnly = True
        Me.DocFileName.Size = New System.Drawing.Size(323, 20)
        Me.DocFileName.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Documento:"
        '
        'DocFiles
        '
        Me.DocFiles.AutoSize = True
        Me.DocFiles.Location = New System.Drawing.Point(375, 200)
        Me.DocFiles.Name = "DocFiles"
        Me.DocFiles.Size = New System.Drawing.Size(16, 13)
        Me.DocFiles.TabIndex = 25
        Me.DocFiles.Text = "..."
        '
        'WordProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 256)
        Me.Controls.Add(Me.DocFiles)
        Me.Controls.Add(Me.DocClear)
        Me.Controls.Add(Me.DocFileName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LabelNext)
        Me.Controls.Add(Me.LabelPrevious)
        Me.Controls.Add(Me.NumericUpDownAno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.LabelClear)
        Me.Controls.Add(Me.TextBoxBuscar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DataGridViewAlunos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "WordProcess"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Processador de Contratos (WordProcess)"
        CType(Me.NumericUpDownAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewAlunos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelNext As Label
    Friend WithEvents LabelPrevious As Label
    Friend WithEvents NumericUpDownAno As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnPrint As Button
    Friend WithEvents LabelClear As Label
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridViewAlunos As DataGridView
    Friend WithEvents DocClear As Label
    Friend WithEvents DocFileName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DocFiles As Label
End Class
