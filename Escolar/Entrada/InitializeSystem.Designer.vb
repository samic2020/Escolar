<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InitializeSystem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InitializeSystem))
        Me.btnCriar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pgbProcessos = New System.Windows.Forms.ProgressBar()
        Me.iPassWord = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.iDataBaseName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.iIpDns = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCriar
        '
        Me.btnCriar.Image = CType(resources.GetObject("btnCriar.Image"), System.Drawing.Image)
        Me.btnCriar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCriar.Location = New System.Drawing.Point(117, 324)
        Me.btnCriar.Name = "btnCriar"
        Me.btnCriar.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnCriar.Size = New System.Drawing.Size(154, 33)
        Me.btnCriar.TabIndex = 21
        Me.btnCriar.Text = "Criar Arquivos"
        Me.btnCriar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 279)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Processos:"
        '
        'pgbProcessos
        '
        Me.pgbProcessos.Location = New System.Drawing.Point(12, 295)
        Me.pgbProcessos.Name = "pgbProcessos"
        Me.pgbProcessos.Size = New System.Drawing.Size(367, 23)
        Me.pgbProcessos.TabIndex = 19
        '
        'iPassWord
        '
        Me.iPassWord.Location = New System.Drawing.Point(154, 218)
        Me.iPassWord.Name = "iPassWord"
        Me.iPassWord.Size = New System.Drawing.Size(225, 20)
        Me.iPassWord.TabIndex = 18
        Me.iPassWord.Text = "7kf51b"
        Me.iPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 46)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Coloque aqui a senha do banco de dados:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O padrão é 7kf51b."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'iDataBaseName
        '
        Me.iDataBaseName.Location = New System.Drawing.Point(154, 162)
        Me.iDataBaseName.Name = "iDataBaseName"
        Me.iDataBaseName.Size = New System.Drawing.Size(225, 20)
        Me.iDataBaseName.TabIndex = 16
        Me.iDataBaseName.Text = "escola"
        Me.iDataBaseName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 46)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Coloque aqui o nome do banco de dados:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O padrão é cicle."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(367, 71)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Esta é a primeira execução do programa Escolar neste computado." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "É necessário alg" &
    "umas informações para o sistema funcionar." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Caso tenha alguma dúvida, favor entr" &
    "ar em contato com o suporte técnico."
        '
        'iIpDns
        '
        Me.iIpDns.Location = New System.Drawing.Point(154, 109)
        Me.iIpDns.Name = "iIpDns"
        Me.iIpDns.Size = New System.Drawing.Size(225, 20)
        Me.iIpDns.TabIndex = 13
        Me.iIpDns.Text = "127.0.0.1"
        Me.iIpDns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 59)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Coloque aqui o IP ou DNS do computador a cessar:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "O padrão é 127.0.0.1 ou localho" &
    "st."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InitializeSystem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 363)
        Me.Controls.Add(Me.btnCriar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pgbProcessos)
        Me.Controls.Add(Me.iPassWord)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.iDataBaseName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.iIpDns)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InitializeSystem"
        Me.Text = "InitializeSystem"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCriar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents pgbProcessos As ProgressBar
    Friend WithEvents iPassWord As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents iDataBaseName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents iIpDns As TextBox
    Friend WithEvents Label1 As Label
End Class
