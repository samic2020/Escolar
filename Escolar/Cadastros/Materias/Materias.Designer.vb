<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Materias
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Materias))
        Me.btnMatDel = New System.Windows.Forms.Button()
        Me.btnMatAdc = New System.Windows.Forms.Button()
        Me.DataGridViewMaterias = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txbMateria = New System.Windows.Forms.TextBox()
        Me.txbHoras = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.matBtnOk = New System.Windows.Forms.Button()
        Me.VScrollBarMaterias = New System.Windows.Forms.VScrollBar()
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMatDel
        '
        Me.btnMatDel.Image = CType(resources.GetObject("btnMatDel.Image"), System.Drawing.Image)
        Me.btnMatDel.Location = New System.Drawing.Point(484, 53)
        Me.btnMatDel.Name = "btnMatDel"
        Me.btnMatDel.Size = New System.Drawing.Size(23, 21)
        Me.btnMatDel.TabIndex = 5
        Me.btnMatDel.UseVisualStyleBackColor = True
        '
        'btnMatAdc
        '
        Me.btnMatAdc.Image = CType(resources.GetObject("btnMatAdc.Image"), System.Drawing.Image)
        Me.btnMatAdc.Location = New System.Drawing.Point(484, 33)
        Me.btnMatAdc.Name = "btnMatAdc"
        Me.btnMatAdc.Size = New System.Drawing.Size(23, 21)
        Me.btnMatAdc.TabIndex = 4
        Me.btnMatAdc.UseVisualStyleBackColor = True
        '
        'DataGridViewMaterias
        '
        Me.DataGridViewMaterias.AllowUserToAddRows = False
        Me.DataGridViewMaterias.AllowUserToDeleteRows = False
        Me.DataGridViewMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMaterias.Location = New System.Drawing.Point(5, 33)
        Me.DataGridViewMaterias.MultiSelect = False
        Me.DataGridViewMaterias.Name = "DataGridViewMaterias"
        Me.DataGridViewMaterias.ReadOnly = True
        Me.DataGridViewMaterias.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridViewMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewMaterias.Size = New System.Drawing.Size(479, 150)
        Me.DataGridViewMaterias.TabIndex = 3
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 259
        Me.Label1.Text = "Matéria:"
        '
        'txbMateria
        '
        Me.txbMateria.Location = New System.Drawing.Point(53, 6)
        Me.txbMateria.Name = "txbMateria"
        Me.txbMateria.Size = New System.Drawing.Size(272, 20)
        Me.txbMateria.TabIndex = 0
        '
        'txbHoras
        '
        Me.txbHoras.Location = New System.Drawing.Point(394, 6)
        Me.txbHoras.Name = "txbHoras"
        Me.txbHoras.Size = New System.Drawing.Size(82, 20)
        Me.txbHoras.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(336, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 261
        Me.Label2.Text = "Q.H.Mês:"
        '
        'matBtnOk
        '
        Me.matBtnOk.Image = CType(resources.GetObject("matBtnOk.Image"), System.Drawing.Image)
        Me.matBtnOk.Location = New System.Drawing.Point(477, 5)
        Me.matBtnOk.Name = "matBtnOk"
        Me.matBtnOk.Size = New System.Drawing.Size(29, 22)
        Me.matBtnOk.TabIndex = 2
        Me.matBtnOk.UseVisualStyleBackColor = True
        '
        'VScrollBarMaterias
        '
        Me.VScrollBarMaterias.Location = New System.Drawing.Point(484, 103)
        Me.VScrollBarMaterias.Name = "VScrollBarMaterias"
        Me.VScrollBarMaterias.Size = New System.Drawing.Size(17, 80)
        Me.VScrollBarMaterias.TabIndex = 6
        '
        'Materias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 191)
        Me.Controls.Add(Me.VScrollBarMaterias)
        Me.Controls.Add(Me.matBtnOk)
        Me.Controls.Add(Me.txbHoras)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txbMateria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridViewMaterias)
        Me.Controls.Add(Me.btnMatDel)
        Me.Controls.Add(Me.btnMatAdc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Materias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Materias"
        CType(Me.DataGridViewMaterias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMatDel As Button
    Friend WithEvents btnMatAdc As Button
    Friend WithEvents DataGridViewMaterias As DataGridView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label1 As Label
    Friend WithEvents txbMateria As TextBox
    Friend WithEvents txbHoras As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents matBtnOk As Button
    Friend WithEvents VScrollBarMaterias As VScrollBar
End Class
