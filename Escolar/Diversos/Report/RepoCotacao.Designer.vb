<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepoCotacao
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
        Me.RViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'RViewer
        '
        Me.RViewer.ActiveViewIndex = 0
        Me.RViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.RViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RViewer.Location = New System.Drawing.Point(0, 0)
        Me.RViewer.Name = "RViewer"
        Me.RViewer.ReportSource = "C:\Projetos\vbReports\carne.rpt"
        Me.RViewer.Size = New System.Drawing.Size(800, 450)
        Me.RViewer.TabIndex = 0
        '
        'RepoCotacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RViewer)
        Me.Name = "RepoCotacao"
        Me.Text = "RepoCotacao"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
