<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mensalidade
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mensalidade))
        Me.Mensalidades = New System.Windows.Forms.DataGridView()
        Me.mCursos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mSeries = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mVencto = New System.Windows.Forms.NumericUpDown()
        Me.mValor = New System.Windows.Forms.TextBox()
        Me.btnMenOk = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Prazos = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pDias = New System.Windows.Forms.NumericUpDown()
        Me.pPerc = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pValor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPrazOk = New System.Windows.Forms.Button()
        Me.mMenDel = New System.Windows.Forms.Button()
        Me.mMenAdc = New System.Windows.Forms.Button()
        Me.pPrazDel = New System.Windows.Forms.Button()
        Me.pPrazAdc = New System.Windows.Forms.Button()
        Me.VScrollBarMensal = New System.Windows.Forms.VScrollBar()
        Me.VScrollBarMensalPrazos = New System.Windows.Forms.VScrollBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.Mensalidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mVencto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Prazos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pDias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pPerc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mensalidades
        '
        Me.Mensalidades.AllowUserToAddRows = False
        Me.Mensalidades.AllowUserToDeleteRows = False
        Me.Mensalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Mensalidades.Location = New System.Drawing.Point(12, 61)
        Me.Mensalidades.Name = "Mensalidades"
        Me.Mensalidades.ReadOnly = True
        Me.Mensalidades.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Mensalidades.Size = New System.Drawing.Size(472, 157)
        Me.Mensalidades.TabIndex = 0
        '
        'mCursos
        '
        Me.mCursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mCursos.Location = New System.Drawing.Point(58, 7)
        Me.mCursos.Name = "mCursos"
        Me.mCursos.Size = New System.Drawing.Size(211, 21)
        Me.mCursos.TabIndex = 263
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 262
        Me.Label6.Text = "Curso:"
        '
        'mSeries
        '
        Me.mSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mSeries.Enabled = False
        Me.mSeries.Location = New System.Drawing.Point(57, 34)
        Me.mSeries.Name = "mSeries"
        Me.mSeries.Size = New System.Drawing.Size(211, 21)
        Me.mSeries.TabIndex = 261
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Série:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(289, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Vencimento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(289, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 265
        Me.Label3.Text = "Valor:"
        '
        'mVencto
        '
        Me.mVencto.Location = New System.Drawing.Point(361, 8)
        Me.mVencto.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.mVencto.Name = "mVencto"
        Me.mVencto.Size = New System.Drawing.Size(53, 20)
        Me.mVencto.TabIndex = 266
        '
        'mValor
        '
        Me.mValor.Location = New System.Drawing.Point(329, 34)
        Me.mValor.Name = "mValor"
        Me.mValor.Size = New System.Drawing.Size(85, 20)
        Me.mValor.TabIndex = 267
        '
        'btnMenOk
        '
        Me.btnMenOk.Image = CType(resources.GetObject("btnMenOk.Image"), System.Drawing.Image)
        Me.btnMenOk.Location = New System.Drawing.Point(420, 4)
        Me.btnMenOk.Name = "btnMenOk"
        Me.btnMenOk.Size = New System.Drawing.Size(64, 51)
        Me.btnMenOk.TabIndex = 268
        Me.btnMenOk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 13)
        Me.Label4.TabIndex = 269
        Me.Label4.Text = "Prazos"
        '
        'Prazos
        '
        Me.Prazos.AllowUserToAddRows = False
        Me.Prazos.AllowUserToDeleteRows = False
        Me.Prazos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Prazos.Location = New System.Drawing.Point(6, 100)
        Me.Prazos.Name = "Prazos"
        Me.Prazos.ReadOnly = True
        Me.Prazos.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Prazos.Size = New System.Drawing.Size(162, 121)
        Me.Prazos.TabIndex = 270
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 271
        Me.Label5.Text = "Dia(s) Antenecete(s):"
        '
        'pDias
        '
        Me.pDias.Location = New System.Drawing.Point(115, 8)
        Me.pDias.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.pDias.Name = "pDias"
        Me.pDias.Size = New System.Drawing.Size(53, 20)
        Me.pDias.TabIndex = 272
        '
        'pPerc
        '
        Me.pPerc.Location = New System.Drawing.Point(39, 35)
        Me.pPerc.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.pPerc.Name = "pPerc"
        Me.pPerc.Size = New System.Drawing.Size(53, 20)
        Me.pPerc.TabIndex = 273
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(95, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 274
        Me.Label7.Text = "%"
        '
        'pValor
        '
        Me.pValor.Location = New System.Drawing.Point(43, 60)
        Me.pValor.Name = "pValor"
        Me.pValor.Size = New System.Drawing.Size(85, 20)
        Me.pValor.TabIndex = 275
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 276
        Me.Label8.Text = "Valor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 277
        Me.Label9.Text = "Perc.:"
        '
        'btnPrazOk
        '
        Me.btnPrazOk.Image = CType(resources.GetObject("btnPrazOk.Image"), System.Drawing.Image)
        Me.btnPrazOk.Location = New System.Drawing.Point(129, 59)
        Me.btnPrazOk.Name = "btnPrazOk"
        Me.btnPrazOk.Size = New System.Drawing.Size(36, 22)
        Me.btnPrazOk.TabIndex = 278
        Me.btnPrazOk.UseVisualStyleBackColor = True
        '
        'mMenDel
        '
        Me.mMenDel.Image = CType(resources.GetObject("mMenDel.Image"), System.Drawing.Image)
        Me.mMenDel.Location = New System.Drawing.Point(484, 82)
        Me.mMenDel.Name = "mMenDel"
        Me.mMenDel.Size = New System.Drawing.Size(23, 21)
        Me.mMenDel.TabIndex = 280
        Me.mMenDel.UseVisualStyleBackColor = True
        '
        'mMenAdc
        '
        Me.mMenAdc.Image = CType(resources.GetObject("mMenAdc.Image"), System.Drawing.Image)
        Me.mMenAdc.Location = New System.Drawing.Point(484, 61)
        Me.mMenAdc.Name = "mMenAdc"
        Me.mMenAdc.Size = New System.Drawing.Size(23, 21)
        Me.mMenAdc.TabIndex = 279
        Me.mMenAdc.UseVisualStyleBackColor = True
        '
        'pPrazDel
        '
        Me.pPrazDel.Image = CType(resources.GetObject("pPrazDel.Image"), System.Drawing.Image)
        Me.pPrazDel.Location = New System.Drawing.Point(168, 121)
        Me.pPrazDel.Name = "pPrazDel"
        Me.pPrazDel.Size = New System.Drawing.Size(23, 21)
        Me.pPrazDel.TabIndex = 282
        Me.pPrazDel.UseVisualStyleBackColor = True
        '
        'pPrazAdc
        '
        Me.pPrazAdc.Image = CType(resources.GetObject("pPrazAdc.Image"), System.Drawing.Image)
        Me.pPrazAdc.Location = New System.Drawing.Point(168, 100)
        Me.pPrazAdc.Name = "pPrazAdc"
        Me.pPrazAdc.Size = New System.Drawing.Size(23, 21)
        Me.pPrazAdc.TabIndex = 281
        Me.pPrazAdc.UseVisualStyleBackColor = True
        '
        'VScrollBarMensal
        '
        Me.VScrollBarMensal.Location = New System.Drawing.Point(484, 138)
        Me.VScrollBarMensal.Name = "VScrollBarMensal"
        Me.VScrollBarMensal.Size = New System.Drawing.Size(23, 80)
        Me.VScrollBarMensal.TabIndex = 283
        '
        'VScrollBarMensalPrazos
        '
        Me.VScrollBarMensalPrazos.Location = New System.Drawing.Point(168, 147)
        Me.VScrollBarMensalPrazos.Name = "VScrollBarMensalPrazos"
        Me.VScrollBarMensalPrazos.Size = New System.Drawing.Size(23, 74)
        Me.VScrollBarMensalPrazos.TabIndex = 284
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Mensalidades)
        Me.SplitContainer1.Panel1.Controls.Add(Me.VScrollBarMensal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mSeries)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mCursos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mMenDel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mMenAdc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mVencto)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mValor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMenOk)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.VScrollBarMensalPrazos)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pPrazDel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Prazos)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pPrazAdc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pDias)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnPrazOk)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pPerc)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pValor)
        Me.SplitContainer1.Size = New System.Drawing.Size(713, 227)
        Me.SplitContainer1.SplitterDistance = 510
        Me.SplitContainer1.TabIndex = 285
        '
        'Mensalidade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 229)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Mensalidade"
        Me.Text = ".:: Mensalidade"
        CType(Me.Mensalidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mVencto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Prazos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pDias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pPerc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Mensalidades As DataGridView
    Friend WithEvents mCursos As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents mSeries As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents mVencto As NumericUpDown
    Friend WithEvents mValor As TextBox
    Friend WithEvents btnMenOk As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Prazos As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents pDias As NumericUpDown
    Friend WithEvents pPerc As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents pValor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnPrazOk As Button
    Friend WithEvents mMenDel As Button
    Friend WithEvents mMenAdc As Button
    Friend WithEvents pPrazDel As Button
    Friend WithEvents pPrazAdc As Button
    Friend WithEvents VScrollBarMensal As VScrollBar
    Friend WithEvents VScrollBarMensalPrazos As VScrollBar
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
