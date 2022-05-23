<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pisico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pisico))
        Me.PsicoLista = New System.Windows.Forms.DataGridView()
        CType(Me.PsicoLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PsicoLista
        '
        Me.PsicoLista.AllowUserToAddRows = False
        Me.PsicoLista.AllowUserToDeleteRows = False
        Me.PsicoLista.AllowUserToOrderColumns = True
        Me.PsicoLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PsicoLista.Location = New System.Drawing.Point(12, 12)
        Me.PsicoLista.Name = "PsicoLista"
        Me.PsicoLista.ReadOnly = True
        Me.PsicoLista.Size = New System.Drawing.Size(692, 150)
        Me.PsicoLista.TabIndex = 265
        '
        'Pisico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 171)
        Me.Controls.Add(Me.PsicoLista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pisico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Comportamento"
        CType(Me.PsicoLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PsicoLista As DataGridView
End Class
