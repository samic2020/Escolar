<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Indicacoes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Indicacoes))
        Me.indBolsista = New System.Windows.Forms.CheckBox()
        Me.indLista = New System.Windows.Forms.DataGridView()
        Me.indBtnDel = New System.Windows.Forms.Button()
        Me.indBtnAdc = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.indIndPor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.indBtnOk = New System.Windows.Forms.Button()
        Me.indFunc = New System.Windows.Forms.RadioButton()
        Me.indIrmao = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bolper = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.indLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.bolper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'indBolsista
        '
        Me.indBolsista.AutoSize = True
        Me.indBolsista.Location = New System.Drawing.Point(191, 19)
        Me.indBolsista.Name = "indBolsista"
        Me.indBolsista.Size = New System.Drawing.Size(62, 17)
        Me.indBolsista.TabIndex = 5
        Me.indBolsista.Text = "Bolsista"
        Me.indBolsista.UseVisualStyleBackColor = True
        '
        'indLista
        '
        Me.indLista.AllowUserToAddRows = False
        Me.indLista.AllowUserToDeleteRows = False
        Me.indLista.AllowUserToOrderColumns = True
        Me.indLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.indLista.Location = New System.Drawing.Point(12, 91)
        Me.indLista.Name = "indLista"
        Me.indLista.ReadOnly = True
        Me.indLista.Size = New System.Drawing.Size(491, 121)
        Me.indLista.TabIndex = 6
        '
        'indBtnDel
        '
        Me.indBtnDel.Image = CType(resources.GetObject("indBtnDel.Image"), System.Drawing.Image)
        Me.indBtnDel.Location = New System.Drawing.Point(480, 218)
        Me.indBtnDel.Name = "indBtnDel"
        Me.indBtnDel.Size = New System.Drawing.Size(23, 21)
        Me.indBtnDel.TabIndex = 29
        Me.indBtnDel.UseVisualStyleBackColor = True
        '
        'indBtnAdc
        '
        Me.indBtnAdc.Image = CType(resources.GetObject("indBtnAdc.Image"), System.Drawing.Image)
        Me.indBtnAdc.Location = New System.Drawing.Point(458, 218)
        Me.indBtnAdc.Name = "indBtnAdc"
        Me.indBtnAdc.Size = New System.Drawing.Size(23, 21)
        Me.indBtnAdc.TabIndex = 28
        Me.indBtnAdc.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.bolper)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.indIndPor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.indBtnOk)
        Me.GroupBox1.Controls.Add(Me.indFunc)
        Me.GroupBox1.Controls.Add(Me.indIrmao)
        Me.GroupBox1.Controls.Add(Me.indBolsista)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(491, 73)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " [Desconto] "
        '
        'indIndPor
        '
        Me.indIndPor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.indIndPor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.indIndPor.Location = New System.Drawing.Point(88, 42)
        Me.indIndPor.Name = "indIndPor"
        Me.indIndPor.Size = New System.Drawing.Size(359, 20)
        Me.indIndPor.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Indicado pôr:"
        '
        'indBtnOk
        '
        Me.indBtnOk.Image = CType(resources.GetObject("indBtnOk.Image"), System.Drawing.Image)
        Me.indBtnOk.Location = New System.Drawing.Point(447, 41)
        Me.indBtnOk.Name = "indBtnOk"
        Me.indBtnOk.Size = New System.Drawing.Size(38, 22)
        Me.indBtnOk.TabIndex = 8
        Me.indBtnOk.UseVisualStyleBackColor = True
        '
        'indFunc
        '
        Me.indFunc.AutoSize = True
        Me.indFunc.Location = New System.Drawing.Point(71, 19)
        Me.indFunc.Name = "indFunc"
        Me.indFunc.Size = New System.Drawing.Size(117, 17)
        Me.indFunc.TabIndex = 7
        Me.indFunc.Text = "Filho de funcionário"
        Me.indFunc.UseVisualStyleBackColor = True
        '
        'indIrmao
        '
        Me.indIrmao.AutoSize = True
        Me.indIrmao.Location = New System.Drawing.Point(14, 19)
        Me.indIrmao.Name = "indIrmao"
        Me.indIrmao.Size = New System.Drawing.Size(51, 17)
        Me.indIrmao.TabIndex = 6
        Me.indIrmao.Text = "Irmão"
        Me.indIrmao.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(247, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Percentual de"
        '
        'bolper
        '
        Me.bolper.Location = New System.Drawing.Point(317, 18)
        Me.bolper.Name = "bolper"
        Me.bolper.Size = New System.Drawing.Size(50, 20)
        Me.bolper.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "%"
        '
        'Indicacoes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 249)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.indBtnDel)
        Me.Controls.Add(Me.indBtnAdc)
        Me.Controls.Add(Me.indLista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Indicacoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Indicacoes"
        CType(Me.indLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.bolper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents indBolsista As CheckBox
    Friend WithEvents indLista As DataGridView
    Friend WithEvents indBtnDel As Button
    Friend WithEvents indBtnAdc As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents indBtnOk As Button
    Friend WithEvents indFunc As RadioButton
    Friend WithEvents indIrmao As RadioButton
    Friend WithEvents indIndPor As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents bolper As NumericUpDown
    Friend WithEvents Label2 As Label
End Class
