<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Cupom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cupom))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.idCupom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.matAluno = New System.Windows.Forms.TextBox()
        Me.nomeAluno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPesq = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.descValor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.descValidade = New System.Windows.Forms.DateTimePicker()
        Me.BtnGravar = New System.Windows.Forms.Button()
        Me.DataGridViewCupons = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.VScrollBarCupons = New System.Windows.Forms.VScrollBar()
        CType(Me.DataGridViewCupons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Identificador do Cupom:"
        '
        'idCupom
        '
        Me.idCupom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.idCupom.FormattingEnabled = True
        Me.idCupom.Items.AddRange(New Object() {"0 - Matricula", "1 - Mensalidade", "2 - Estoque", "3 - Uniforme", "4 - Transporte", "5 - Extra Curricular"})
        Me.idCupom.Location = New System.Drawing.Point(129, 6)
        Me.idCupom.Name = "idCupom"
        Me.idCupom.Size = New System.Drawing.Size(143, 21)
        Me.idCupom.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Matricula:"
        '
        'matAluno
        '
        Me.matAluno.BackColor = System.Drawing.Color.White
        Me.matAluno.Location = New System.Drawing.Point(11, 53)
        Me.matAluno.Name = "matAluno"
        Me.matAluno.ReadOnly = True
        Me.matAluno.Size = New System.Drawing.Size(69, 20)
        Me.matAluno.TabIndex = 3
        '
        'nomeAluno
        '
        Me.nomeAluno.BackColor = System.Drawing.Color.White
        Me.nomeAluno.Location = New System.Drawing.Point(86, 53)
        Me.nomeAluno.Name = "nomeAluno"
        Me.nomeAluno.ReadOnly = True
        Me.nomeAluno.Size = New System.Drawing.Size(309, 20)
        Me.nomeAluno.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Aluno:"
        '
        'BtnPesq
        '
        Me.BtnPesq.Image = CType(resources.GetObject("BtnPesq.Image"), System.Drawing.Image)
        Me.BtnPesq.Location = New System.Drawing.Point(395, 52)
        Me.BtnPesq.Name = "BtnPesq"
        Me.BtnPesq.Size = New System.Drawing.Size(30, 22)
        Me.BtnPesq.TabIndex = 6
        Me.BtnPesq.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Cupom com Desconto de R$"
        '
        'descValor
        '
        Me.descValor.Location = New System.Drawing.Point(154, 83)
        Me.descValor.Name = "descValor"
        Me.descValor.Size = New System.Drawing.Size(102, 20)
        Me.descValor.TabIndex = 8
        Me.descValor.Text = "0,00"
        Me.descValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(263, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Valido até:"
        '
        'descValidade
        '
        Me.descValidade.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.descValidade.Location = New System.Drawing.Point(326, 83)
        Me.descValidade.Name = "descValidade"
        Me.descValidade.Size = New System.Drawing.Size(99, 20)
        Me.descValidade.TabIndex = 10
        '
        'BtnGravar
        '
        Me.BtnGravar.Location = New System.Drawing.Point(314, 109)
        Me.BtnGravar.Name = "BtnGravar"
        Me.BtnGravar.Size = New System.Drawing.Size(111, 23)
        Me.BtnGravar.TabIndex = 11
        Me.BtnGravar.Text = "Gravar"
        Me.BtnGravar.UseVisualStyleBackColor = True
        '
        'DataGridViewCupons
        '
        Me.DataGridViewCupons.AllowUserToAddRows = False
        Me.DataGridViewCupons.AllowUserToDeleteRows = False
        Me.DataGridViewCupons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCupons.Location = New System.Drawing.Point(11, 163)
        Me.DataGridViewCupons.Name = "DataGridViewCupons"
        Me.DataGridViewCupons.ReadOnly = True
        Me.DataGridViewCupons.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataGridViewCupons.Size = New System.Drawing.Size(414, 150)
        Me.DataGridViewCupons.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Image = CType(resources.GetObject("Label6.Image"), System.Drawing.Image)
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(12, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(413, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "       Descontos Concedidos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VScrollBarCupons
        '
        Me.VScrollBarCupons.Location = New System.Drawing.Point(426, 233)
        Me.VScrollBarCupons.Name = "VScrollBarCupons"
        Me.VScrollBarCupons.Size = New System.Drawing.Size(10, 80)
        Me.VScrollBarCupons.TabIndex = 282
        '
        'Cupom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 323)
        Me.Controls.Add(Me.VScrollBarCupons)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataGridViewCupons)
        Me.Controls.Add(Me.BtnGravar)
        Me.Controls.Add(Me.descValidade)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.descValor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnPesq)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nomeAluno)
        Me.Controls.Add(Me.matAluno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.idCupom)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cupom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cupom"
        CType(Me.DataGridViewCupons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents idCupom As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents matAluno As TextBox
    Friend WithEvents nomeAluno As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnPesq As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents descValor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents descValidade As DateTimePicker
    Friend WithEvents BtnGravar As Button
    Friend WithEvents DataGridViewCupons As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents VScrollBarCupons As VScrollBar
End Class
