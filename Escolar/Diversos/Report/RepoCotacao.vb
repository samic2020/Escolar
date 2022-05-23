Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class RepoCotacao
    Private dbMain As [Db] = New Db

    Public Sub RepSaidaEstoque(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelSaidaEstoque.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        'RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepSaidaEstoqueMontagem(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelSaidaEstoqueMontagem.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        'RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RelNotaFisc(ds As DataSet, Estatistica As String, vrparc As Decimal, Optional credTroca As Decimal = 0D)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\\NotaFiscal.rpt"            '//, "NotaFiscalMorto.rpt")
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("empresa", Globais.dadosAdm.Item("Razao"))
        Dim cEndereco As String = Globais.dadosAdm.Item("Endereco").ToString.Trim.ToUpper & ", " & Globais.dadosAdm.Item("Numero").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Bairro").ToString.Trim.ToUpper
        CRPT.SetParameterValue("endereco", cEndereco)
        CRPT.SetParameterValue("enderecol2", Globais.dadosAdm.Item("Cidade").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Estado").ToString.Trim.ToUpper & " - CEP " & Globais.dadosAdm.Item("Cep").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("enderecol3", "C.N.P.J: " & Globais.dadosAdm.Item("Cnpj").ToString.Trim.ToUpper & " - INSC.EST: " & Globais.dadosAdm.Item("Inscricao").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("mensagem", Funcoes.MensagemBuild(Globais.dadosAdm.Item("Mensagem").ToString.Trim.ToUpper))
        CRPT.SetParameterValue("hpage", Globais.dadosAdm.Item("HPage").ToString.Trim.ToLower)
        CRPT.SetParameterValue("telefone", "(" & Globais.dadosAdm.Item("Ddd").ToString.Trim.ToUpper & ")" & Globais.dadosAdm.Item("Telefone").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("Estatistica", IIf(Val(Estatistica) < 0, 0, IIf(Val(Estatistica) > 100, 100, Math.Abs(Val(Estatistica)))))
        CRPT.SetParameterValue("VrParcDesconto", Val(vrparc))
        CRPT.SetParameterValue("credTroca", credTroca)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo").ToString)
        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Function RelNotaFiscPDF(ds As DataSet, Estatistica As String, vrparc As Decimal, Optional credTroca As Decimal = 0D) As String
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\NotaFiscal.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("empresa", Globais.dadosAdm.Item("Razao"))
        Dim cEndereco As String = Globais.dadosAdm.Item("Endereco").ToString.Trim.ToUpper & ", " & Globais.dadosAdm.Item("Numero").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Bairro").ToString.Trim.ToUpper
        CRPT.SetParameterValue("endereco", cEndereco)
        CRPT.SetParameterValue("enderecol2", Globais.dadosAdm.Item("Cidade").ToString.Trim.ToUpper & " - " & Globais.dadosAdm.Item("Estado").ToString.Trim.ToUpper & " - CEP " & Globais.dadosAdm.Item("Cep").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("enderecol3", "C.N.P.J: " & Globais.dadosAdm.Item("Cnpj").ToString.Trim.ToUpper & " - INSC.EST: " & Globais.dadosAdm.Item("Inscricao").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("mensagem", Funcoes.MensagemBuild(Globais.dadosAdm.Item("Mensagem").ToString.Trim.ToUpper))
        CRPT.SetParameterValue("hpage", Globais.dadosAdm.Item("HPage").ToString.Trim.ToLower)
        CRPT.SetParameterValue("telefone", "(" & Globais.dadosAdm.Item("Ddd").ToString.Trim.ToUpper & ")" & Globais.dadosAdm.Item("Telefone").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("Estatistica", IIf(Val(Estatistica) < 0, 0, Math.Abs(Val(Estatistica))))
        CRPT.SetParameterValue("VrParcDesconto", CDbl(vrparc))
        CRPT.SetParameterValue("credTroca", credTroca)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        Dim NotaFiscalTmp As String = Path.GetTempFileName() & ".pdf"

        CRPT.ExportToDisk(ExportFormatType.PortableDocFormat, NotaFiscalTmp)
        CRPT.Refresh()
        Return NotaFiscalTmp
    End Function

    Public Sub RelVisitados(ds As DataSet)
        '// Todos
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\Visitados.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        'RViewer.RefreshReport()
        'RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RelSimVisitados(ds As DataSet)
        '// Visitados
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\SimVisitados.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        'RViewer.RefreshReport()
        'RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RelNaoVisitados(ds As DataSet)
        '// Não Visitados
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\NaoVisitados.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        'RViewer.RefreshReport()
        'RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RepBaixaContas(ds As DataSet, nrReport As Integer)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\BaixaContas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("nrReport", nrReport)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepContasBaixadas(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\ContasBaixadas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelMotivos(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\RelListaMotivos.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RelTrocas(ds As DataSet, DataDe As Date, DataAte As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\ControleTrocas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)

        RViewer.ReportSource = CRPT
        CRPT.SetParameterValue("dtInicial", DataAte)
        CRPT.SetParameterValue("dtFinal", DataDe)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RelCota(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelCotacoes.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Function RelCotaPDF(ds As DataSet, pagina As String, paginaate As String) As String
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelCotacoes.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        Dim exportOpts As ExportOptions = New ExportOptions()
        Dim pdfRtfWordOpts As PdfRtfWordFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions()
        Dim destinationOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()
        If Not pagina.Equals("TODAS") Then
            pdfRtfWordOpts.FirstPageNumber = Val(pagina)
            pdfRtfWordOpts.LastPageNumber = Val(paginaate)
            pdfRtfWordOpts.UsePageRange = True
        Else
            pdfRtfWordOpts.UsePageRange = False
        End If
        exportOpts.ExportFormatOptions = pdfRtfWordOpts
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat

        Dim RelCotacoesTmp As String = Path.GetTempFileName() & ".pdf"
        destinationOpts.DiskFileName = RelCotacoesTmp
        exportOpts.ExportDestinationOptions = destinationOpts
        exportOpts.ExportDestinationType = ExportDestinationType.DiskFile
        CRPT.Export(exportOpts)

        Return RelCotacoesTmp
    End Function

    Public Function RelCotaDOC(ds As DataSet, pagina As String, paginaate As String) As String
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelCotacoes.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        Dim exportOpts As ExportOptions = New ExportOptions()
        Dim pdfRtfWordOpts As PdfRtfWordFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions()
        Dim destinationOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()
        If Not pagina.Equals("TODAS") Then
            pdfRtfWordOpts.FirstPageNumber = Val(pagina)
            pdfRtfWordOpts.LastPageNumber = Val(paginaate)
            pdfRtfWordOpts.UsePageRange = True
        Else
            pdfRtfWordOpts.UsePageRange = False
        End If
        exportOpts.ExportFormatOptions = pdfRtfWordOpts
        exportOpts.ExportFormatType = ExportFormatType.WordForWindows

        Dim RelCotacoesTmp As String = Path.GetTempFileName() & ".doc"
        destinationOpts.DiskFileName = RelCotacoesTmp
        exportOpts.ExportDestinationOptions = destinationOpts
        exportOpts.ExportDestinationType = ExportDestinationType.DiskFile
        CRPT.Export(exportOpts)

        Return RelCotacoesTmp
    End Function

    Public Sub RepEstoqueTotal(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstTotal.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoqueTotalSQtde(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstTotalSQtde.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoque(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstPcoNormal.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoqueSQtde(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstPcoNormalSQtde.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoquePromocaoSQtde(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstPcoPromocaoSQtde.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoquePromocao(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstPcoPromocao.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepConferencia(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEstConferencia.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoqueMin(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RepEstMinimo.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepEstoqueBal(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\EstoqueBalanco.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RepComissao(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RepComissao.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepComissaoMorto(ds As DataSet, cMesAno As String)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RepComissaoMorto.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        CRPT.SetParameterValue("MesAno", cMesAno)

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RelVisitas(ds As DataSet, dtaVisita As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\Visitas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtVisita", dtaVisita)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepCliente(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\Clientes.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        ' RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RelOrca(ds As DataSet, Estatistica As String, vrparc As Decimal)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\NotaOrcam.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Function RelOrcaPDF(ds As DataSet, Estatistica As String, vrparc As Decimal) As String
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\NotaOrcam.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        Dim NotaFiscalTmp As String = Path.GetTempFileName() & ".pdf"
        CRPT.ExportToDisk(ExportFormatType.PortableDocFormat, NotaFiscalTmp)
        CRPT.Refresh()
        Return NotaFiscalTmp
    End Function

    Public Sub Boleta(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\boletas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Marca"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelEntradas(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\Entradas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelNotaFiscTroca(ds As DataSet) ', notaFiscal As String)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\NotaFiscalTroca.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("empresa", Globais.dadosAdm.Item("Razao").ToString.ToUpper.Trim)
        CRPT.SetParameterValue("cnpj", Globais.dadosAdm.Item("Cnpj").ToString.Trim.ToUpper)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelContas()
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\ListaContas.rpt"
        CRPT.Load(APPPATH)
        'CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelAcertos()
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\Acertos.rpt"
        CRPT.Load(APPPATH)

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelContasPagar()
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\ListaContasPagar.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelVisitar(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelVisitas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepFornProd(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RepFornProd.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepPrevCompras(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RepPrevCompras.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RepPontoVisitas(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\PontoVisitas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepPontoRotas(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\PontoRotas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepPontoRotasErros(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\PontoRotasErros.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepTempoGasto(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\TempoGasto.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepTempoGastoAna(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\TempoGastoAna.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelObservacoes(ds As DataSet, dtIni As Date, dtFim As Date)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelObservacoes.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelAtrasados(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelAtrasados.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

    Public Sub RelChequesADep(ds As DataSet, dados As Object())
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelChequesDep.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        CRPT.SetParameterValue("Data", dados(0))
        CRPT.SetParameterValue("Banco", dados(1).ToString)
        CRPT.SetParameterValue("Agencia", dados(2).ToString)
        CRPT.SetParameterValue("Conta", dados(3).ToString)
        CRPT.SetParameterValue("Depositante", dados(4).ToString)

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        RViewer.Show()
    End Sub

    Public Sub RelEntradasPreview(ds As DataSet, aResp As MsgBoxResult)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelEntradasPreview.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Estoque", IIf(aResp = MsgBoxResult.Yes, True, False))
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RepPontoAquisicao(ds As DataSet, dtIni As Date, dtFim As Date, tHrs As Object)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\Aquisicao.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("dtIni", dtIni)
        CRPT.SetParameterValue("dtFim", dtFim)
        CRPT.SetParameterValue("TotalHoras", Strings.Mid(tHrs.ToString(), 1, tHrs.ToString().Length - 3))
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelMontagemPreview()
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\ListaPreviewMontagem.rpt"
        CRPT.Load(APPPATH)
        'CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelObs()
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\Observacoes.rpt"
        CRPT.Load(APPPATH)
        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelRetornoArq(ds As DataSet, fileName As String)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\RelRetornoArq.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        CRPT.SetParameterValue("FildName", fileName)
        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelEmbarque(ds As DataSet)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\Embarque.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Sub RelEstatisticas(cliente As String, anos As Integer)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String

        APPPATH = Globais.relPath & "\Estatisticas.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))
        CRPT.SetParameterValue("Cliente", cliente)
        CRPT.SetParameterValue("Anos", anos)

        RViewer.ReportSource = CRPT
        RViewer.Show()
    End Sub

    Public Function RepCotacao(ds As DataSet, forn As String, Optional export As Boolean = False) As String
        Dim RelCotacoesTmp As String = Nothing
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\Cotacao.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        CRPT.SetParameterValue("Fornecedor", forn)
        CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        If export Then
            Dim exportOpts As ExportOptions = New ExportOptions()
            Dim pdfRtfWordOpts As PdfRtfWordFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions()
            Dim destinationOpts As DiskFileDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions()
            pdfRtfWordOpts.UsePageRange = False
            exportOpts.ExportFormatOptions = pdfRtfWordOpts
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat
            RelCotacoesTmp = Path.GetTempFileName() & ".pdf"
            destinationOpts.DiskFileName = RelCotacoesTmp
            exportOpts.ExportDestinationOptions = destinationOpts
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile
            CRPT.Export(exportOpts)
        Else
            RViewer.ReportSource = CRPT
            RViewer.Show()
        End If

        Return RelCotacoesTmp
    End Function

    Public Sub RelAtuaPrecos(ds As DataTable)
        Dim CRPT As New ReportDocument
        Dim APPPATH As String
        APPPATH = Globais.relPath & "\AtualizaPrecos.rpt"
        CRPT.Load(APPPATH)
        CRPT.SetDataSource(ds)
        'CRPT.SetParameterValue("Logo", Globais.dadosAdm.Item("Logo"))

        RViewer.ReportSource = CRPT
        RViewer.Refresh()
        'RViewer.RefreshReport()
        RViewer.Show()
    End Sub

End Class