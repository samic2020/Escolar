Imports Canducci.Zip

Public Class Cep
    Private _cep As ZipCodeInfo
    Public ReadOnly Property getCep() As ZipCodeInfo
        Get
            Return _cep
        End Get
    End Property

    Public Sub New(zip As String)
        Dim zips As ZipCodeInfo = Nothing
        Try
            zips = New ZipCodeLoad().Find(zip)
            If zips.Erro Then
                zips = Nothing
            End If
        Catch ex As ZipCodeException
            Throw ex
        End Try
        _cep = zips
    End Sub
End Class
