<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Carne
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Carne))
        Me.DataGridViewAlunos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxBuscar = New System.Windows.Forms.TextBox()
        Me.LabelClear = New System.Windows.Forms.Label()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.CheckBoxSelAll = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NumericUpDownAno = New System.Windows.Forms.NumericUpDown()
        Me.LabelPrevious = New System.Windows.Forms.Label()
        Me.LabelNext = New System.Windows.Forms.Label()
        CType(Me.DataGridViewAlunos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownAno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewAlunos
        '
        Me.DataGridViewAlunos.AllowUserToAddRows = False
        Me.DataGridViewAlunos.AllowUserToDeleteRows = False
        Me.DataGridViewAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewAlunos.Location = New System.Drawing.Point(12, 30)
        Me.DataGridViewAlunos.Name = "DataGridViewAlunos"
        Me.DataGridViewAlunos.ReadOnly = True
        Me.DataGridViewAlunos.Size = New System.Drawing.Size(383, 132)
        Me.DataGridViewAlunos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Aluno:"
        '
        'TextBoxBuscar
        '
        Me.TextBoxBuscar.Location = New System.Drawing.Point(45, 168)
        Me.TextBoxBuscar.Name = "TextBoxBuscar"
        Me.TextBoxBuscar.Size = New System.Drawing.Size(350, 20)
        Me.TextBoxBuscar.TabIndex = 4
        '
        'LabelClear
        '
        Me.LabelClear.AutoSize = True
        Me.LabelClear.Enabled = False
        Me.LabelClear.Location = New System.Drawing.Point(340, 171)
        Me.LabelClear.Name = "LabelClear"
        Me.LabelClear.Size = New System.Drawing.Size(14, 13)
        Me.LabelClear.TabIndex = 5
        Me.LabelClear.Text = "X"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(268, 194)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.BtnPrint.Size = New System.Drawing.Size(127, 23)
        Me.BtnPrint.TabIndex = 6
        Me.BtnPrint.Text = "Imprimir"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'CheckBoxSelAll
        '
        Me.CheckBoxSelAll.Location = New System.Drawing.Point(12, 195)
        Me.CheckBoxSelAll.Name = "CheckBoxSelAll"
        Me.CheckBoxSelAll.Size = New System.Drawing.Size(250, 22)
        Me.CheckBoxSelAll.TabIndex = 7
        Me.CheckBoxSelAll.Text = "Selecionar Todos"
        Me.CheckBoxSelAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(251, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ano Letivo:"
        '
        'NumericUpDownAno
        '
        Me.NumericUpDownAno.Location = New System.Drawing.Point(318, 4)
        Me.NumericUpDownAno.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.NumericUpDownAno.Minimum = New Decimal(New Integer() {2022, 0, 0, 0})
        Me.NumericUpDownAno.Name = "NumericUpDownAno"
        Me.NumericUpDownAno.Size = New System.Drawing.Size(77, 20)
        Me.NumericUpDownAno.TabIndex = 9
        Me.NumericUpDownAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NumericUpDownAno.Value = New Decimal(New Integer() {2022, 0, 0, 0})
        '
        'LabelPrevious
        '
        Me.LabelPrevious.AutoSize = True
        Me.LabelPrevious.Enabled = False
        Me.LabelPrevious.Location = New System.Drawing.Point(360, 171)
        Me.LabelPrevious.Name = "LabelPrevious"
        Me.LabelPrevious.Size = New System.Drawing.Size(13, 13)
        Me.LabelPrevious.TabIndex = 10
        Me.LabelPrevious.Text = "<"
        '
        'LabelNext
        '
        Me.LabelNext.AutoSize = True
        Me.LabelNext.Enabled = False
        Me.LabelNext.Location = New System.Drawing.Point(376, 171)
        Me.LabelNext.Name = "LabelNext"
        Me.LabelNext.Size = New System.Drawing.Size(13, 13)
        Me.LabelNext.TabIndex = 11
        Me.LabelNext.Text = ">"
        '
        'Carne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(406, 228)
        Me.Controls.Add(Me.LabelNext)
        Me.Controls.Add(Me.LabelPrevious)
        Me.Controls.Add(Me.NumericUpDownAno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBoxSelAll)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.LabelClear)
        Me.Controls.Add(Me.TextBoxBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewAlunos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Carne"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Impressão do Carne"
        CType(Me.DataGridViewAlunos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownAno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridViewAlunos As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxBuscar As TextBox
    Friend WithEvents LabelClear As Label
    Friend WithEvents BtnPrint As Button
    Friend WithEvents CheckBoxSelAll As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents NumericUpDownAno As NumericUpDown
    Friend WithEvents LabelPrevious As Label
    Friend WithEvents LabelNext As Label
End Class
