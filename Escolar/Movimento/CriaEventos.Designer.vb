<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CriaEventos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.eId = New System.Windows.Forms.TextBox()
        Me.eDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.eAno = New System.Windows.Forms.RadioButton()
        Me.eMes = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.eTermino = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.eInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.eValor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.eParcelas = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.eDividido = New System.Windows.Forms.CheckBox()
        Me.eBtnIncluir = New System.Windows.Forms.Button()
        Me.eBtnAlterar = New System.Windows.Forms.Button()
        Me.eBtnExcluir = New System.Windows.Forms.Button()
        Me.eBtnGravar = New System.Windows.Forms.Button()
        Me.eBtnCancelar = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ePesquisa = New System.Windows.Forms.TextBox()
        Me.DataGridViewEventos = New System.Windows.Forms.DataGridView()
        Me.eBtnClear = New System.Windows.Forms.Label()
        Me.eBtnPrevious = New System.Windows.Forms.Label()
        Me.eBtnNext = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridViewEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id:"
        '
        'eId
        '
        Me.eId.Location = New System.Drawing.Point(37, 6)
        Me.eId.Name = "eId"
        Me.eId.ReadOnly = True
        Me.eId.Size = New System.Drawing.Size(40, 20)
        Me.eId.TabIndex = 1
        Me.eId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'eDesc
        '
        Me.eDesc.Location = New System.Drawing.Point(146, 6)
        Me.eDesc.Name = "eDesc"
        Me.eDesc.Size = New System.Drawing.Size(377, 20)
        Me.eDesc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(91, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descrição:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.eAno)
        Me.GroupBox1.Controls.Add(Me.eMes)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(114, 44)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo do Evento"
        '
        'eAno
        '
        Me.eAno.AutoSize = True
        Me.eAno.Location = New System.Drawing.Point(57, 19)
        Me.eAno.Name = "eAno"
        Me.eAno.Size = New System.Drawing.Size(44, 17)
        Me.eAno.TabIndex = 1
        Me.eAno.TabStop = True
        Me.eAno.Text = "Ano"
        Me.eAno.UseVisualStyleBackColor = True
        '
        'eMes
        '
        Me.eMes.AutoSize = True
        Me.eMes.Checked = True
        Me.eMes.Location = New System.Drawing.Point(6, 19)
        Me.eMes.Name = "eMes"
        Me.eMes.Size = New System.Drawing.Size(45, 17)
        Me.eMes.TabIndex = 0
        Me.eMes.TabStop = True
        Me.eMes.Text = "Mês"
        Me.eMes.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.eTermino)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.eInicio)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(135, 32)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(389, 44)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'eTermino
        '
        Me.eTermino.CalendarMonthBackground = System.Drawing.Color.Red
        Me.eTermino.CustomFormat = "dd-MM-yyyy"
        Me.eTermino.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eTermino.Location = New System.Drawing.Point(226, 16)
        Me.eTermino.Name = "eTermino"
        Me.eTermino.Size = New System.Drawing.Size(76, 20)
        Me.eTermino.TabIndex = 3
        Me.eTermino.Value = New Date(2022, 7, 12, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(196, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "tirar"
        '
        'eInicio
        '
        Me.eInicio.CustomFormat = "dd-MM-yyyy"
        Me.eInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.eInicio.Location = New System.Drawing.Point(90, 15)
        Me.eInicio.Name = "eInicio"
        Me.eInicio.Size = New System.Drawing.Size(76, 20)
        Me.eInicio.TabIndex = 1
        Me.eInicio.Value = New Date(2022, 7, 12, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Data do Evento:"
        '
        'eValor
        '
        Me.eValor.Location = New System.Drawing.Point(52, 82)
        Me.eValor.Name = "eValor"
        Me.eValor.Size = New System.Drawing.Size(97, 20)
        Me.eValor.TabIndex = 7
        Me.eValor.Text = "0,00"
        Me.eValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Valor:"
        '
        'eParcelas
        '
        Me.eParcelas.Location = New System.Drawing.Point(250, 82)
        Me.eParcelas.Name = "eParcelas"
        Me.eParcelas.Size = New System.Drawing.Size(29, 20)
        Me.eParcelas.TabIndex = 9
        Me.eParcelas.Text = "0"
        Me.eParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(285, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "parcela(s)."
        '
        'eDividido
        '
        Me.eDividido.AutoSize = True
        Me.eDividido.Location = New System.Drawing.Point(170, 84)
        Me.eDividido.Name = "eDividido"
        Me.eDividido.Size = New System.Drawing.Size(84, 17)
        Me.eDividido.TabIndex = 8
        Me.eDividido.Text = "Dividido em "
        Me.eDividido.UseVisualStyleBackColor = True
        '
        'eBtnIncluir
        '
        Me.eBtnIncluir.Location = New System.Drawing.Point(8, 120)
        Me.eBtnIncluir.Name = "eBtnIncluir"
        Me.eBtnIncluir.Size = New System.Drawing.Size(75, 23)
        Me.eBtnIncluir.TabIndex = 12
        Me.eBtnIncluir.Text = "Incluir"
        Me.eBtnIncluir.UseVisualStyleBackColor = True
        '
        'eBtnAlterar
        '
        Me.eBtnAlterar.Location = New System.Drawing.Point(94, 120)
        Me.eBtnAlterar.Name = "eBtnAlterar"
        Me.eBtnAlterar.Size = New System.Drawing.Size(75, 23)
        Me.eBtnAlterar.TabIndex = 13
        Me.eBtnAlterar.Text = "Alterar"
        Me.eBtnAlterar.UseVisualStyleBackColor = True
        '
        'eBtnExcluir
        '
        Me.eBtnExcluir.Location = New System.Drawing.Point(179, 120)
        Me.eBtnExcluir.Name = "eBtnExcluir"
        Me.eBtnExcluir.Size = New System.Drawing.Size(75, 23)
        Me.eBtnExcluir.TabIndex = 14
        Me.eBtnExcluir.Text = "Excluir"
        Me.eBtnExcluir.UseVisualStyleBackColor = True
        '
        'eBtnGravar
        '
        Me.eBtnGravar.Location = New System.Drawing.Point(361, 120)
        Me.eBtnGravar.Name = "eBtnGravar"
        Me.eBtnGravar.Size = New System.Drawing.Size(75, 23)
        Me.eBtnGravar.TabIndex = 15
        Me.eBtnGravar.Text = "Gravar"
        Me.eBtnGravar.UseVisualStyleBackColor = True
        '
        'eBtnCancelar
        '
        Me.eBtnCancelar.Location = New System.Drawing.Point(449, 120)
        Me.eBtnCancelar.Name = "eBtnCancelar"
        Me.eBtnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.eBtnCancelar.TabIndex = 16
        Me.eBtnCancelar.Text = "Cancelar"
        Me.eBtnCancelar.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Pesquisar:"
        '
        'ePesquisa
        '
        Me.ePesquisa.Location = New System.Drawing.Point(67, 283)
        Me.ePesquisa.Name = "ePesquisa"
        Me.ePesquisa.Size = New System.Drawing.Size(461, 20)
        Me.ePesquisa.TabIndex = 0
        '
        'DataGridViewEventos
        '
        Me.DataGridViewEventos.AllowUserToAddRows = False
        Me.DataGridViewEventos.AllowUserToDeleteRows = False
        Me.DataGridViewEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewEventos.Location = New System.Drawing.Point(12, 149)
        Me.DataGridViewEventos.Name = "DataGridViewEventos"
        Me.DataGridViewEventos.ReadOnly = True
        Me.DataGridViewEventos.Size = New System.Drawing.Size(516, 128)
        Me.DataGridViewEventos.TabIndex = 19
        '
        'eBtnClear
        '
        Me.eBtnClear.Location = New System.Drawing.Point(467, 285)
        Me.eBtnClear.Name = "eBtnClear"
        Me.eBtnClear.Size = New System.Drawing.Size(17, 17)
        Me.eBtnClear.TabIndex = 20
        Me.eBtnClear.Text = "X"
        Me.eBtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'eBtnPrevious
        '
        Me.eBtnPrevious.Location = New System.Drawing.Point(487, 284)
        Me.eBtnPrevious.Name = "eBtnPrevious"
        Me.eBtnPrevious.Size = New System.Drawing.Size(17, 17)
        Me.eBtnPrevious.TabIndex = 21
        Me.eBtnPrevious.Text = "<"
        Me.eBtnPrevious.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'eBtnNext
        '
        Me.eBtnNext.Location = New System.Drawing.Point(506, 284)
        Me.eBtnNext.Name = "eBtnNext"
        Me.eBtnNext.Size = New System.Drawing.Size(17, 17)
        Me.eBtnNext.TabIndex = 22
        Me.eBtnNext.Text = ">"
        Me.eBtnNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CriaEventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 313)
        Me.Controls.Add(Me.eBtnNext)
        Me.Controls.Add(Me.eBtnPrevious)
        Me.Controls.Add(Me.eBtnClear)
        Me.Controls.Add(Me.DataGridViewEventos)
        Me.Controls.Add(Me.ePesquisa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.eBtnCancelar)
        Me.Controls.Add(Me.eBtnGravar)
        Me.Controls.Add(Me.eBtnExcluir)
        Me.Controls.Add(Me.eBtnAlterar)
        Me.Controls.Add(Me.eBtnIncluir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.eParcelas)
        Me.Controls.Add(Me.eDividido)
        Me.Controls.Add(Me.eValor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.eDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.eId)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CriaEventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Criação de Eventos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DataGridViewEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents eId As TextBox
    Friend WithEvents eDesc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents eAno As RadioButton
    Friend WithEvents eMes As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents eTermino As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents eInicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents eValor As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents eParcelas As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents eDividido As CheckBox
    Friend WithEvents eBtnIncluir As Button
    Friend WithEvents eBtnAlterar As Button
    Friend WithEvents eBtnExcluir As Button
    Friend WithEvents eBtnGravar As Button
    Friend WithEvents eBtnCancelar As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ePesquisa As TextBox
    Friend WithEvents DataGridViewEventos As DataGridView
    Friend WithEvents eBtnClear As Label
    Friend WithEvents eBtnPrevious As Label
    Friend WithEvents eBtnNext As Label
End Class
