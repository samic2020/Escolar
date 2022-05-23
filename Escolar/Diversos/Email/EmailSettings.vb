Public Class EmailSettings
    Private dbMain As [Db] = New Db

    Private _popAddress As String
    Private _popPort As Integer
    Private _smtpAddress As String
    Private _smtpPort As Integer
    Private _ssl As Boolean
    Private _emailTimer As Integer
    Private _user As String
    Private _passwd As String

    Public Sub New()
        _popAddress = dbMain.lergravarPARAM({"POP"})
        _popPort = Integer.Parse(dbMain.lergravarPARAM({"POPPORT"}))
        _smtpAddress = dbMain.lergravarPARAM({"SMTP"})
        _smtpPort = Integer.Parse(dbMain.lergravarPARAM({"SMTPPORT"}))
        _ssl = IIf(dbMain.lergravarPARAM({"SSL"}) = "TRUE", True, False)
        _emailTimer = Integer.Parse(dbMain.lergravarPARAM({"EMAILTIMER"}))
        _user = dbMain.lergravarPARAM({"EMAILUSER"})
        _passwd = dbMain.lergravarPARAM({"EMAILPWD"})
    End Sub

    Public ReadOnly Property popAddress() As String
        Get
            Return _popAddress
        End Get
    End Property

    Public ReadOnly Property popPort() As Integer
        Get
            Return _popPort
        End Get
    End Property

    Public ReadOnly Property smtpAddress() As String
        Get
            Return _smtpAddress
        End Get
    End Property

    Public ReadOnly Property smtpPort() As Integer
        Get
            Return _smtpPort
        End Get
    End Property

    Public ReadOnly Property ssl() As Boolean
        Get
            Return _ssl
        End Get
    End Property

    Public ReadOnly Property emailTimer() As Integer
        Get
            Return _emailTimer
        End Get
    End Property

    Public ReadOnly Property user() As String
        Get
            Return _user
        End Get
    End Property

    Public ReadOnly Property passwd() As String
        Get
            Return _passwd
        End Get
    End Property

End Class
