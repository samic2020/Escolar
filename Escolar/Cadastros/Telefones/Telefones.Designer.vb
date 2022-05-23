<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Telefones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Telefones))
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.tel_destino = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tel_ddd = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tel_numero = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSalvar
        '
        Me.btnSalvar.Image = CType(resources.GetObject("btnSalvar.Image"), System.Drawing.Image)
        Me.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalvar.Location = New System.Drawing.Point(185, 85)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSalvar.Size = New System.Drawing.Size(90, 30)
        Me.btnSalvar.TabIndex = 3
        Me.btnSalvar.Text = "&Salvar"
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'tel_destino
        '
        Me.tel_destino.FormattingEnabled = True
        Me.tel_destino.Items.AddRange(New Object() {"Residêncial", "Comercial", "Celular", "Recado", "Publico"})
        Me.tel_destino.Location = New System.Drawing.Point(70, 58)
        Me.tel_destino.MaxLength = 15
        Me.tel_destino.Name = "tel_destino"
        Me.tel_destino.Size = New System.Drawing.Size(205, 21)
        Me.tel_destino.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Telefone:"
        '
        'tel_ddd
        '
        Me.tel_ddd.AllowPromptAsInput = False
        Me.tel_ddd.BeepOnError = True
        Me.tel_ddd.Location = New System.Drawing.Point(52, 6)
        Me.tel_ddd.Mask = "00"
        Me.tel_ddd.Name = "tel_ddd"
        Me.tel_ddd.Size = New System.Drawing.Size(28, 20)
        Me.tel_ddd.TabIndex = 0
        Me.tel_ddd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tel_ddd.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Telefone:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "DDD:"
        '
        'tel_numero
        '
        Me.tel_numero.Location = New System.Drawing.Point(70, 32)
        Me.tel_numero.Name = "tel_numero"
        Me.tel_numero.Size = New System.Drawing.Size(100, 20)
        Me.tel_numero.TabIndex = 1
        '
        'Telefones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 126)
        Me.Controls.Add(Me.tel_numero)
        Me.Controls.Add(Me.btnSalvar)
        Me.Controls.Add(Me.tel_destino)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tel_ddd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Telefones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Telefones"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSalvar As Button
    Friend WithEvents tel_destino As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tel_ddd As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tel_numero As TextBox
End Class
