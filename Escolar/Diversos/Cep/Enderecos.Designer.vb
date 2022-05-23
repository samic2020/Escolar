<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Enderecos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Enderecos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.endEstado = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.endCidade = New System.Windows.Forms.ComboBox()
        Me.endEndereco = New System.Windows.Forms.Label()
        Me.endEnder = New System.Windows.Forms.TextBox()
        Me.DataGridViewCep = New System.Windows.Forms.DataGridView()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.DataGridViewCep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Estado:"
        '
        'endEstado
        '
        Me.endEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.endEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.endEstado.BackColor = System.Drawing.Color.White
        Me.endEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.endEstado.Location = New System.Drawing.Point(58, 10)
        Me.endEstado.MaxLength = 25
        Me.endEstado.Name = "endEstado"
        Me.endEstado.Size = New System.Drawing.Size(49, 21)
        Me.endEstado.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(123, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Cidade:"
        '
        'endCidade
        '
        Me.endCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.endCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.endCidade.BackColor = System.Drawing.Color.White
        Me.endCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.endCidade.Location = New System.Drawing.Point(172, 10)
        Me.endCidade.MaxLength = 25
        Me.endCidade.Name = "endCidade"
        Me.endCidade.Size = New System.Drawing.Size(319, 21)
        Me.endCidade.TabIndex = 1
        '
        'endEndereco
        '
        Me.endEndereco.AutoSize = True
        Me.endEndereco.Location = New System.Drawing.Point(9, 43)
        Me.endEndereco.Name = "endEndereco"
        Me.endEndereco.Size = New System.Drawing.Size(56, 13)
        Me.endEndereco.TabIndex = 17
        Me.endEndereco.Text = "Endereço:"
        '
        'endEnder
        '
        Me.endEnder.Location = New System.Drawing.Point(71, 40)
        Me.endEnder.Name = "endEnder"
        Me.endEnder.Size = New System.Drawing.Size(446, 20)
        Me.endEnder.TabIndex = 2
        '
        'DataGridViewCep
        '
        Me.DataGridViewCep.AllowUserToAddRows = False
        Me.DataGridViewCep.AllowUserToDeleteRows = False
        Me.DataGridViewCep.AllowUserToOrderColumns = True
        Me.DataGridViewCep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewCep.Location = New System.Drawing.Point(12, 66)
        Me.DataGridViewCep.Name = "DataGridViewCep"
        Me.DataGridViewCep.ReadOnly = True
        Me.DataGridViewCep.Size = New System.Drawing.Size(618, 150)
        Me.DataGridViewCep.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(523, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnBuscar.Size = New System.Drawing.Size(107, 23)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Image = CType(resources.GetObject("btnConfirmar.Image"), System.Drawing.Image)
        Me.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirmar.Location = New System.Drawing.Point(442, 222)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnConfirmar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfirmar.TabIndex = 5
        Me.btnConfirmar.Text = "&Ok"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(523, 222)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCancelar.Size = New System.Drawing.Size(107, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancela"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.Location = New System.Drawing.Point(497, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 23)
        Me.Label4.TabIndex = 23
        '
        'Enderecos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(640, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.DataGridViewCep)
        Me.Controls.Add(Me.endEnder)
        Me.Controls.Add(Me.endEndereco)
        Me.Controls.Add(Me.endCidade)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.endEstado)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Enderecos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Busca Cep do Endereco"
        CType(Me.DataGridViewCep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents endEstado As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents endCidade As ComboBox
    Friend WithEvents endEndereco As Label
    Friend WithEvents endEnder As TextBox
    Friend WithEvents DataGridViewCep As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label4 As Label
End Class
