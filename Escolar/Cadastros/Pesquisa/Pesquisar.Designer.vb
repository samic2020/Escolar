<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pesquisar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pesquisar))
        Me.btnClear = New System.Windows.Forms.Label()
        Me.TextBoxPesquisar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewPesquisar = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridViewPesquisar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.White
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(560, 185)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(15, 15)
        Me.btnClear.TabIndex = 16
        '
        'TextBoxPesquisar
        '
        Me.TextBoxPesquisar.Location = New System.Drawing.Point(54, 182)
        Me.TextBoxPesquisar.Name = "TextBoxPesquisar"
        Me.TextBoxPesquisar.Size = New System.Drawing.Size(526, 20)
        Me.TextBoxPesquisar.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Buscar:"
        '
        'DataGridViewPesquisar
        '
        Me.DataGridViewPesquisar.AllowUserToAddRows = False
        Me.DataGridViewPesquisar.AllowUserToDeleteRows = False
        Me.DataGridViewPesquisar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewPesquisar.Location = New System.Drawing.Point(12, 12)
        Me.DataGridViewPesquisar.Name = "DataGridViewPesquisar"
        Me.DataGridViewPesquisar.ReadOnly = True
        Me.DataGridViewPesquisar.Size = New System.Drawing.Size(568, 164)
        Me.DataGridViewPesquisar.TabIndex = 15
        '
        'Pesquisar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(593, 215)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.TextBoxPesquisar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewPesquisar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pesquisar"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Pesquisar"
        CType(Me.DataGridViewPesquisar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClear As Label
    Friend WithEvents TextBoxPesquisar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewPesquisar As DataGridView
End Class
