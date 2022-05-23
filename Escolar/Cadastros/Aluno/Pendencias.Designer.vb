<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pendencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pendencias))
        Me.pendListaDel = New System.Windows.Forms.Button()
        Me.pendListaAdc = New System.Windows.Forms.Button()
        Me.pendLista = New Escolar.ComboEditListBox()
        Me.SuspendLayout()
        '
        'pendListaDel
        '
        Me.pendListaDel.Image = CType(resources.GetObject("pendListaDel.Image"), System.Drawing.Image)
        Me.pendListaDel.Location = New System.Drawing.Point(325, 32)
        Me.pendListaDel.Name = "pendListaDel"
        Me.pendListaDel.Size = New System.Drawing.Size(23, 21)
        Me.pendListaDel.TabIndex = 257
        Me.pendListaDel.UseVisualStyleBackColor = True
        '
        'pendListaAdc
        '
        Me.pendListaAdc.Image = CType(resources.GetObject("pendListaAdc.Image"), System.Drawing.Image)
        Me.pendListaAdc.Location = New System.Drawing.Point(325, 11)
        Me.pendListaAdc.Name = "pendListaAdc"
        Me.pendListaAdc.Size = New System.Drawing.Size(23, 21)
        Me.pendListaAdc.TabIndex = 256
        Me.pendListaAdc.UseVisualStyleBackColor = True
        '
        'pendLista
        '
        Me.pendLista.AllowDelete = True
        Me.pendLista.CommitOnEnter = True
        Me.pendLista.CommitOnLeave = True
        Me.pendLista.ConfirmDelete = False
        Me.pendLista.ConfirmDeleteText = "Are you sure you want to delete the selected items?"
        Me.pendLista.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.pendLista.FormattingEnabled = True
        Me.pendLista.Location = New System.Drawing.Point(12, 11)
        Me.pendLista.Name = "pendLista"
        Me.pendLista.Size = New System.Drawing.Size(313, 238)
        Me.pendLista.TabIndex = 258
        '
        'Pendencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 256)
        Me.Controls.Add(Me.pendLista)
        Me.Controls.Add(Me.pendListaDel)
        Me.Controls.Add(Me.pendListaAdc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Pendencias"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Pendencias"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pendListaDel As Button
    Friend WithEvents pendListaAdc As Button
    Friend WithEvents pendLista As ComboEditListBox
End Class
