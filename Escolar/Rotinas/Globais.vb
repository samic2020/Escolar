Imports MySql.Data.MySqlClient

Module Globais
    Public Setting As [Settings] = New Settings()

    Public conn As MySqlConnection = Nothing
    Public codfun As String = Nothing
    Public usuario As String = Nothing
    Public senha As String = Nothing
    Public funcao As String = Nothing
    Public autoriza As Boolean = False
    Public emaster As Boolean = False
    Public protocolomenu As String

    Public dadosAdm As Collection = New Collection

    Public unidade As String = Setting.Load("Unidade0", "127.0.0.1")
    Public user As String = Setting.Load("User0", "root")
    Public pwd As String = Setting.Load("PassWord0", "7kf51b")
    Public databaseName As String = Setting.Load("DataBaseName0", "escola")

    'Public appPath As String = "C:\\CicleDotNet\\"
    Public appPath As String = Application.StartupPath & "\\"
    Public appPathBackUp As String = Application.StartupPath & "\\BackUp\\"

    Public relPath As String = appPath & "Reports"
    Public remPath As String = appPath & "Remessa\\"
    Public xmlPath As String = appPath & "Xml"

    '// E-Mail - parametros
    Public emailAddress As String = Setting.Load("eAddress", "pedido@mundoemduasrodas.com.br")
    Public emailPassWord As String = Setting.Load("ePwd", "mM@12345679")
    Public emailSmtp As String = Setting.Load("eSmtp", "mail.mundoemduasrodas.com.br")
    Public emailSmtpPort As String = Setting.Load("ePort", "587")
    Public emailSmtpSsl As String = Setting.Load("eSSL", "False")

    '// Caixa Economica Federal
    Public cxaPath As String = "C:\\CAIXA\\Cobranca\\Remessa\\"
    Public cxaPathRet As String = "C:\\CAIXA\\Cobranca\\Retorno\\"

    '// Biometria
    Public biometria As Boolean = False
    Public farn As Integer = 166

    '// Descanço de tela
    Public eTempo As Integer = 0
End Module

