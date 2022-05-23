<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transmicao
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
        Me.btnVisualizarNNumero = New System.Windows.Forms.Button()
        Me.nnumero = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxRemessa = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btGerRemessa = New System.Windows.Forms.Button()
        Me.Boletas = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Boletas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnVisualizarNNumero
        '
        Me.btnVisualizarNNumero.Location = New System.Drawing.Point(502, 360)
        Me.btnVisualizarNNumero.Name = "btnVisualizarNNumero"
        Me.btnVisualizarNNumero.Size = New System.Drawing.Size(77, 23)
        Me.btnVisualizarNNumero.TabIndex = 29
        Me.btnVisualizarNNumero.Text = "Visualizar"
        Me.btnVisualizarNNumero.UseVisualStyleBackColor = True
        '
        'nnumero
        '
        Me.nnumero.Location = New System.Drawing.Point(405, 362)
        Me.nnumero.Name = "nnumero"
        Me.nnumero.Size = New System.Drawing.Size(94, 20)
        Me.nnumero.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(347, 365)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "NNumero:"
        '
        'cbxRemessa
        '
        Me.cbxRemessa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxRemessa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxRemessa.FormattingEnabled = True
        Me.cbxRemessa.Location = New System.Drawing.Point(85, 360)
        Me.cbxRemessa.Name = "cbxRemessa"
        Me.cbxRemessa.Size = New System.Drawing.Size(121, 21)
        Me.cbxRemessa.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 363)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Arq. Retorno:"
        '
        'btGerRemessa
        '
        Me.btGerRemessa.Location = New System.Drawing.Point(212, 360)
        Me.btGerRemessa.Name = "btGerRemessa"
        Me.btGerRemessa.Size = New System.Drawing.Size(77, 23)
        Me.btGerRemessa.TabIndex = 24
        Me.btGerRemessa.Text = "Visualizar"
        Me.btGerRemessa.UseVisualStyleBackColor = True
        '
        'Boletas
        '
        Me.Boletas.AllowUserToAddRows = False
        Me.Boletas.AllowUserToDeleteRows = False
        Me.Boletas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Boletas.Location = New System.Drawing.Point(12, 34)
        Me.Boletas.Name = "Boletas"
        Me.Boletas.ReadOnly = True
        Me.Boletas.Size = New System.Drawing.Size(567, 318)
        Me.Boletas.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Yellow
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(567, 23)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "LISTA BOLETAS EM REMESSA TRANSMITIDA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Transmicao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 395)
        Me.Controls.Add(Me.btnVisualizarNNumero)
        Me.Controls.Add(Me.nnumero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxRemessa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btGerRemessa)
        Me.Controls.Add(Me.Boletas)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Transmicao"
        Me.Text = "Transmicao"
        CType(Me.Boletas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnVisualizarNNumero As Button
    Friend WithEvents nnumero As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbxRemessa As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btGerRemessa As Button
    Friend WithEvents Boletas As DataGridView
    Friend WithEvents Label1 As Label
End Class
