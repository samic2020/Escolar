<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Lancamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Lancamento))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.vrMatricula = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mesIniMensal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mesFinMensal = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtaMatricula = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dt.Matricula:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Valor:"
        '
        'vrMatricula
        '
        Me.vrMatricula.BackColor = System.Drawing.Color.White
        Me.vrMatricula.Location = New System.Drawing.Point(229, 6)
        Me.vrMatricula.Name = "vrMatricula"
        Me.vrMatricula.ReadOnly = True
        Me.vrMatricula.Size = New System.Drawing.Size(77, 20)
        Me.vrMatricula.TabIndex = 3
        Me.vrMatricula.Text = "0,00"
        Me.vrMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mensalidade:"
        '
        'mesIniMensal
        '
        Me.mesIniMensal.CustomFormat = "MMM/yyyy"
        Me.mesIniMensal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mesIniMensal.Location = New System.Drawing.Point(85, 33)
        Me.mesIniMensal.Name = "mesIniMensal"
        Me.mesIniMensal.Size = New System.Drawing.Size(90, 20)
        Me.mesIniMensal.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(188, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "até"
        '
        'mesFinMensal
        '
        Me.mesFinMensal.CustomFormat = "MMM/yyyy"
        Me.mesFinMensal.Enabled = False
        Me.mesFinMensal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.mesFinMensal.Location = New System.Drawing.Point(216, 33)
        Me.mesFinMensal.Name = "mesFinMensal"
        Me.mesFinMensal.Size = New System.Drawing.Size(90, 20)
        Me.mesFinMensal.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(191, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(115, 41)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&Lançar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtaMatricula
        '
        Me.dtaMatricula.BackColor = System.Drawing.Color.White
        Me.dtaMatricula.Location = New System.Drawing.Point(85, 6)
        Me.dtaMatricula.Name = "dtaMatricula"
        Me.dtaMatricula.ReadOnly = True
        Me.dtaMatricula.Size = New System.Drawing.Size(78, 20)
        Me.dtaMatricula.TabIndex = 9
        '
        'Lancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 107)
        Me.Controls.Add(Me.dtaMatricula)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.mesFinMensal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.mesIniMensal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.vrMatricula)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Lancamento"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = ".:: Lancamento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents vrMatricula As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents mesIniMensal As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents mesFinMensal As DateTimePicker
    Friend WithEvents Button1 As Button
    Friend WithEvents dtaMatricula As TextBox
End Class
