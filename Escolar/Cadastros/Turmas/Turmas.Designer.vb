<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Turmas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Turmas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tSeries = New System.Windows.Forms.ComboBox()
        Me.tTurnos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTurDel = New System.Windows.Forms.Button()
        Me.btnTurAdc = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tLotacao = New System.Windows.Forms.TextBox()
        Me.DataGridViewTurmas = New System.Windows.Forms.DataGridView()
        Me.tCursos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tumBtnOk = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridViewMaterias = New System.Windows.Forms.DataGridView()
        Me.btnMatDel = New System.Windows.Forms.Button()
        Me.btnMatAdc = New System.Windows.Forms.Button()
        Me.btnMatDown = New System.Windows.Forms.Button()
        Me.btnMatUp = New System.Windows.Forms.Button()
        Me.tTurma = New System.Windows.Forms.TextBox()
        CType(Me.DataGridViewTurmas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Série:"
        '
        'tSeries
        '
        Me.tSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tSeries.Enabled = False
        Me.tSeries.Location = New System.Drawing.Point(62, 39)
        Me.tSeries.Name = "tSeries"
        Me.tSeries.Size = New System.Drawing.Size(211, 21)
        Me.tSeries.TabIndex = 1
        '
        'tTurnos
        '
        Me.tTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tTurnos.Enabled = False
        Me.tTurnos.Location = New System.Drawing.Point(329, 12)
        Me.tTurnos.Name = "tTurnos"
        Me.tTurnos.Size = New System.Drawing.Size(211, 21)
        Me.tTurnos.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Turno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(283, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Turma:"
        '
        'btnTurDel
        '
        Me.btnTurDel.Image = CType(resources.GetObject("btnTurDel.Image"), System.Drawing.Image)
        Me.btnTurDel.Location = New System.Drawing.Point(518, 87)
        Me.btnTurDel.Name = "btnTurDel"
        Me.btnTurDel.Size = New System.Drawing.Size(23, 21)
        Me.btnTurDel.TabIndex = 224
        Me.btnTurDel.UseVisualStyleBackColor = True
        '
        'btnTurAdc
        '
        Me.btnTurAdc.Image = CType(resources.GetObject("btnTurAdc.Image"), System.Drawing.Image)
        Me.btnTurAdc.Location = New System.Drawing.Point(518, 67)
        Me.btnTurAdc.Name = "btnTurAdc"
        Me.btnTurAdc.Size = New System.Drawing.Size(23, 21)
        Me.btnTurAdc.TabIndex = 223
        Me.btnTurAdc.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(421, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 255
        Me.Label4.Text = "Lotação:"
        '
        'tLotacao
        '
        Me.tLotacao.Location = New System.Drawing.Point(472, 40)
        Me.tLotacao.Name = "tLotacao"
        Me.tLotacao.Size = New System.Drawing.Size(38, 20)
        Me.tLotacao.TabIndex = 254
        '
        'DataGridViewTurmas
        '
        Me.DataGridViewTurmas.AllowUserToAddRows = False
        Me.DataGridViewTurmas.AllowUserToDeleteRows = False
        Me.DataGridViewTurmas.AllowUserToOrderColumns = True
        Me.DataGridViewTurmas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTurmas.Location = New System.Drawing.Point(17, 67)
        Me.DataGridViewTurmas.Name = "DataGridViewTurmas"
        Me.DataGridViewTurmas.ReadOnly = True
        Me.DataGridViewTurmas.Size = New System.Drawing.Size(501, 155)
        Me.DataGridViewTurmas.TabIndex = 257
        '
        'tCursos
        '
        Me.tCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tCursos.Location = New System.Drawing.Point(63, 12)
        Me.tCursos.Name = "tCursos"
        Me.tCursos.Size = New System.Drawing.Size(211, 21)
        Me.tCursos.TabIndex = 259
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 258
        Me.Label6.Text = "Curso:"
        '
        'tumBtnOk
        '
        Me.tumBtnOk.Image = CType(resources.GetObject("tumBtnOk.Image"), System.Drawing.Image)
        Me.tumBtnOk.Location = New System.Drawing.Point(512, 39)
        Me.tumBtnOk.Name = "tumBtnOk"
        Me.tumBtnOk.Size = New System.Drawing.Size(29, 22)
        Me.tumBtnOk.TabIndex = 260
        Me.tumBtnOk.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(501, 13)
        Me.Label7.TabIndex = 267
        Me.Label7.Text = "Turmas X Materias"
        '
        'DataGridViewMaterias
        '
        Me.DataGridViewMaterias.AllowUserToAddRows = False
        Me.DataGridViewMaterias.AllowUserToDeleteRows = False
        Me.DataGridViewMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMaterias.Location = New System.Drawing.Point(17, 241)
        Me.DataGridViewMaterias.MultiSelect = False
        Me.DataGridViewMaterias.Name = "DataGridViewMaterias"
        Me.DataGridViewMaterias.ReadOnly = True
        Me.DataGridViewMaterias.Size = New System.Drawing.Size(501, 150)
        Me.DataGridViewMaterias.TabIndex = 266
        '
        'btnMatDel
        '
        Me.btnMatDel.Image = CType(resources.GetObject("btnMatDel.Image"), System.Drawing.Image)
        Me.btnMatDel.Location = New System.Drawing.Point(518, 261)
        Me.btnMatDel.Name = "btnMatDel"
        Me.btnMatDel.Size = New System.Drawing.Size(23, 21)
        Me.btnMatDel.TabIndex = 269
        Me.btnMatDel.UseVisualStyleBackColor = True
        '
        'btnMatAdc
        '
        Me.btnMatAdc.Image = CType(resources.GetObject("btnMatAdc.Image"), System.Drawing.Image)
        Me.btnMatAdc.Location = New System.Drawing.Point(518, 241)
        Me.btnMatAdc.Name = "btnMatAdc"
        Me.btnMatAdc.Size = New System.Drawing.Size(23, 21)
        Me.btnMatAdc.TabIndex = 268
        Me.btnMatAdc.UseVisualStyleBackColor = True
        '
        'btnMatDown
        '
        Me.btnMatDown.Image = CType(resources.GetObject("btnMatDown.Image"), System.Drawing.Image)
        Me.btnMatDown.Location = New System.Drawing.Point(518, 363)
        Me.btnMatDown.Name = "btnMatDown"
        Me.btnMatDown.Size = New System.Drawing.Size(33, 30)
        Me.btnMatDown.TabIndex = 271
        Me.btnMatDown.UseVisualStyleBackColor = True
        '
        'btnMatUp
        '
        Me.btnMatUp.Image = CType(resources.GetObject("btnMatUp.Image"), System.Drawing.Image)
        Me.btnMatUp.Location = New System.Drawing.Point(518, 334)
        Me.btnMatUp.Name = "btnMatUp"
        Me.btnMatUp.Size = New System.Drawing.Size(33, 30)
        Me.btnMatUp.TabIndex = 270
        Me.btnMatUp.UseVisualStyleBackColor = True
        '
        'tTurma
        '
        Me.tTurma.Location = New System.Drawing.Point(329, 40)
        Me.tTurma.Name = "tTurma"
        Me.tTurma.Size = New System.Drawing.Size(86, 20)
        Me.tTurma.TabIndex = 273
        '
        'Turmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 401)
        Me.Controls.Add(Me.tTurma)
        Me.Controls.Add(Me.btnMatDown)
        Me.Controls.Add(Me.btnMatUp)
        Me.Controls.Add(Me.btnMatDel)
        Me.Controls.Add(Me.btnMatAdc)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.DataGridViewMaterias)
        Me.Controls.Add(Me.tumBtnOk)
        Me.Controls.Add(Me.tCursos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tLotacao)
        Me.Controls.Add(Me.btnTurDel)
        Me.Controls.Add(Me.btnTurAdc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tTurnos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tSeries)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewTurmas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Turmas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Turmas"
        CType(Me.DataGridViewTurmas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tSeries As ComboBox
    Friend WithEvents tTurnos As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnTurDel As Button
    Friend WithEvents btnTurAdc As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents tLotacao As TextBox
    Friend WithEvents DataGridViewTurmas As DataGridView
    Friend WithEvents tCursos As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tumBtnOk As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridViewMaterias As DataGridView
    Friend WithEvents btnMatDel As Button
    Friend WithEvents btnMatAdc As Button
    Friend WithEvents btnMatDown As Button
    Friend WithEvents btnMatUp As Button
    Friend WithEvents tTurma As TextBox
End Class
