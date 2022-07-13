<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Abertura
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Abertura))
        Me.tCursos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tSeries = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tTurnos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tLotacao = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tAno = New System.Windows.Forms.NumericUpDown()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTurma = New System.Windows.Forms.DataGridView()
        Me.btnTurDel = New System.Windows.Forms.Button()
        Me.btnTurAdc = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LotAtual = New System.Windows.Forms.Label()
        Me.VScrollBarTurma = New System.Windows.Forms.VScrollBar()
        Me.tTurma = New System.Windows.Forms.ComboBox()
        CType(Me.tAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewTurma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tCursos
        '
        Me.tCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tCursos.Location = New System.Drawing.Point(61, 12)
        Me.tCursos.Name = "tCursos"
        Me.tCursos.Size = New System.Drawing.Size(211, 21)
        Me.tCursos.TabIndex = 263
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Curso:"
        '
        'tSeries
        '
        Me.tSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tSeries.Enabled = False
        Me.tSeries.Location = New System.Drawing.Point(60, 39)
        Me.tSeries.Name = "tSeries"
        Me.tSeries.Size = New System.Drawing.Size(211, 21)
        Me.tSeries.TabIndex = 261
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Série:"
        '
        'tTurnos
        '
        Me.tTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tTurnos.Enabled = False
        Me.tTurnos.Location = New System.Drawing.Point(327, 12)
        Me.tTurnos.Name = "tTurnos"
        Me.tTurnos.Size = New System.Drawing.Size(290, 21)
        Me.tTurnos.TabIndex = 265
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(278, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Turno:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(398, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 269
        Me.Label4.Text = "Lotação:"
        '
        'tLotacao
        '
        Me.tLotacao.Location = New System.Drawing.Point(449, 39)
        Me.tLotacao.Name = "tLotacao"
        Me.tLotacao.ReadOnly = True
        Me.tLotacao.Size = New System.Drawing.Size(38, 20)
        Me.tLotacao.TabIndex = 268
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "Turma:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(494, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "Ano:"
        '
        'tAno
        '
        Me.tAno.Location = New System.Drawing.Point(520, 40)
        Me.tAno.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.tAno.Minimum = New Decimal(New Integer() {2022, 0, 0, 0})
        Me.tAno.Name = "tAno"
        Me.tAno.Size = New System.Drawing.Size(58, 20)
        Me.tAno.TabIndex = 272
        Me.tAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tAno.Value = New Decimal(New Integer() {2022, 0, 0, 0})
        '
        'btnAbrir
        '
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.Location = New System.Drawing.Point(584, 39)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(33, 23)
        Me.btnAbrir.TabIndex = 273
        Me.ToolTip1.SetToolTip(Me.btnAbrir, "Abre e/ou cria turma para o ano letivo selecionado.")
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Abre a turma"
        '
        'DataGridViewTurma
        '
        Me.DataGridViewTurma.AllowUserToAddRows = False
        Me.DataGridViewTurma.AllowUserToDeleteRows = False
        Me.DataGridViewTurma.AllowUserToOrderColumns = True
        Me.DataGridViewTurma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTurma.Location = New System.Drawing.Point(15, 66)
        Me.DataGridViewTurma.Name = "DataGridViewTurma"
        Me.DataGridViewTurma.ReadOnly = True
        Me.DataGridViewTurma.Size = New System.Drawing.Size(602, 268)
        Me.DataGridViewTurma.TabIndex = 274
        '
        'btnTurDel
        '
        Me.btnTurDel.Image = CType(resources.GetObject("btnTurDel.Image"), System.Drawing.Image)
        Me.btnTurDel.Location = New System.Drawing.Point(594, 337)
        Me.btnTurDel.Name = "btnTurDel"
        Me.btnTurDel.Size = New System.Drawing.Size(23, 21)
        Me.btnTurDel.TabIndex = 276
        Me.btnTurDel.UseVisualStyleBackColor = True
        '
        'btnTurAdc
        '
        Me.btnTurAdc.Image = CType(resources.GetObject("btnTurAdc.Image"), System.Drawing.Image)
        Me.btnTurAdc.Location = New System.Drawing.Point(569, 337)
        Me.btnTurAdc.Name = "btnTurAdc"
        Me.btnTurAdc.Size = New System.Drawing.Size(23, 21)
        Me.btnTurAdc.TabIndex = 275
        Me.btnTurAdc.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 341)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 277
        Me.Label7.Text = "Lotação Atual:"
        '
        'LotAtual
        '
        Me.LotAtual.BackColor = System.Drawing.Color.White
        Me.LotAtual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LotAtual.Location = New System.Drawing.Point(94, 337)
        Me.LotAtual.Name = "LotAtual"
        Me.LotAtual.Size = New System.Drawing.Size(35, 20)
        Me.LotAtual.TabIndex = 278
        Me.LotAtual.Text = "00"
        Me.LotAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VScrollBarTurma
        '
        Me.VScrollBarTurma.Location = New System.Drawing.Point(618, 254)
        Me.VScrollBarTurma.Name = "VScrollBarTurma"
        Me.VScrollBarTurma.Size = New System.Drawing.Size(10, 80)
        Me.VScrollBarTurma.TabIndex = 279
        '
        'tTurma
        '
        Me.tTurma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tTurma.Enabled = False
        Me.tTurma.Location = New System.Drawing.Point(327, 39)
        Me.tTurma.Name = "tTurma"
        Me.tTurma.Size = New System.Drawing.Size(65, 21)
        Me.tTurma.TabIndex = 280
        '
        'Abertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 368)
        Me.Controls.Add(Me.tTurma)
        Me.Controls.Add(Me.VScrollBarTurma)
        Me.Controls.Add(Me.LotAtual)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnTurDel)
        Me.Controls.Add(Me.btnTurAdc)
        Me.Controls.Add(Me.DataGridViewTurma)
        Me.Controls.Add(Me.btnAbrir)
        Me.Controls.Add(Me.tAno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tLotacao)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tTurnos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCursos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tSeries)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Abertura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Abertura de Turma para o ano Letivo"
        CType(Me.tAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewTurma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tCursos As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tSeries As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tTurnos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tLotacao As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tAno As NumericUpDown
    Friend WithEvents btnAbrir As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents DataGridViewTurma As DataGridView
    Friend WithEvents btnTurDel As Button
    Friend WithEvents btnTurAdc As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents LotAtual As Label
    Friend WithEvents VScrollBarTurma As VScrollBar
    Friend WithEvents tTurma As ComboBox
End Class
