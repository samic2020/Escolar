<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MsgBoleto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MsgBoleto))
        Me.btnSair = New System.Windows.Forms.Button()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.txtMsg4 = New System.Windows.Forms.TextBox()
        Me.txtMsg3 = New System.Windows.Forms.TextBox()
        Me.txtMsg2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMsg1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSair
        '
        Me.btnSair.Image = CType(resources.GetObject("btnSair.Image"), System.Drawing.Image)
        Me.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSair.Location = New System.Drawing.Point(551, 110)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 19
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'btnGravar
        '
        Me.btnGravar.Image = CType(resources.GetObject("btnGravar.Image"), System.Drawing.Image)
        Me.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGravar.Location = New System.Drawing.Point(445, 110)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnGravar.Size = New System.Drawing.Size(100, 23)
        Me.btnGravar.TabIndex = 18
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'txtMsg4
        '
        Me.txtMsg4.Location = New System.Drawing.Point(95, 84)
        Me.txtMsg4.MaxLength = 70
        Me.txtMsg4.Name = "txtMsg4"
        Me.txtMsg4.Size = New System.Drawing.Size(531, 20)
        Me.txtMsg4.TabIndex = 17
        '
        'txtMsg3
        '
        Me.txtMsg3.Location = New System.Drawing.Point(95, 58)
        Me.txtMsg3.MaxLength = 70
        Me.txtMsg3.Name = "txtMsg3"
        Me.txtMsg3.Size = New System.Drawing.Size(531, 20)
        Me.txtMsg3.TabIndex = 16
        '
        'txtMsg2
        '
        Me.txtMsg2.Location = New System.Drawing.Point(95, 32)
        Me.txtMsg2.MaxLength = 70
        Me.txtMsg2.Name = "txtMsg2"
        Me.txtMsg2.Size = New System.Drawing.Size(531, 20)
        Me.txtMsg2.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Mensagem (4):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mensagem (3):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Mensagem (2):"
        '
        'txtMsg1
        '
        Me.txtMsg1.Location = New System.Drawing.Point(95, 6)
        Me.txtMsg1.MaxLength = 70
        Me.txtMsg1.Name = "txtMsg1"
        Me.txtMsg1.Size = New System.Drawing.Size(531, 20)
        Me.txtMsg1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Mensagem (1):"
        '
        'MsgBoleto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 146)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnGravar)
        Me.Controls.Add(Me.txtMsg4)
        Me.Controls.Add(Me.txtMsg3)
        Me.Controls.Add(Me.txtMsg2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMsg1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MsgBoleto"
        Me.Text = "MsgBoleto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSair As Button
    Friend WithEvents btnGravar As Button
    Friend WithEvents txtMsg4 As TextBox
    Friend WithEvents txtMsg3 As TextBox
    Friend WithEvents txtMsg2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMsg1 As TextBox
    Friend WithEvents Label1 As Label
End Class
