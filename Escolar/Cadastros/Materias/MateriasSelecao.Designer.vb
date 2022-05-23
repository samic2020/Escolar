<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MateriasSelecao
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MateriasSelecao))
        Me.VScrollBarMaterias = New System.Windows.Forms.VScrollBar()
        Me.DataGridViewMaterias = New System.Windows.Forms.DataGridView()
        Me.btnSelect = New System.Windows.Forms.Button()
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VScrollBarMaterias
        '
        Me.VScrollBarMaterias.Location = New System.Drawing.Point(491, 82)
        Me.VScrollBarMaterias.Name = "VScrollBarMaterias"
        Me.VScrollBarMaterias.Size = New System.Drawing.Size(17, 80)
        Me.VScrollBarMaterias.TabIndex = 266
        '
        'DataGridViewMaterias
        '
        Me.DataGridViewMaterias.AllowUserToAddRows = False
        Me.DataGridViewMaterias.AllowUserToDeleteRows = False
        Me.DataGridViewMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMaterias.Location = New System.Drawing.Point(12, 12)
        Me.DataGridViewMaterias.MultiSelect = False
        Me.DataGridViewMaterias.Name = "DataGridViewMaterias"
        Me.DataGridViewMaterias.ReadOnly = True
        Me.DataGridViewMaterias.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridViewMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewMaterias.Size = New System.Drawing.Size(479, 150)
        Me.DataGridViewMaterias.TabIndex = 265
        '
        'btnSelect
        '
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.Location = New System.Drawing.Point(491, 12)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(29, 22)
        Me.btnSelect.TabIndex = 267
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'MateriasSelecao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 175)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.VScrollBarMaterias)
        Me.Controls.Add(Me.DataGridViewMaterias)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MateriasSelecao"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Selecione a Materia desejada"
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VScrollBarMaterias As VScrollBar
    Friend WithEvents DataGridViewMaterias As DataGridView
    Friend WithEvents btnSelect As Button
End Class
