Public Class Coordenadas
    Private cordX As Integer
    Private cordY As Integer
    Private tamW As Integer
    Private tamH As Integer

    Public Sub New()
        Me.cordX = 0
        Me.cordY = 0
        Me.tamW = 0
        Me.tamH = 0
    End Sub

    Public Sub New(cordX As Integer, CordY As Integer, tamW As Integer, tamH As Integer)
        Me.cordX = cordX
        Me.cordY = CordY
        Me.tamW = tamW
        Me.tamH = tamH
    End Sub

    Public Property CoordX As Integer
        Get
            Return cordX
        End Get
        Set(value As Integer)
            cordX = value
        End Set
    End Property

    Public Property CoordY As Integer
        Get
            Return cordY
        End Get
        Set(value As Integer)
            cordY = value
        End Set
    End Property

    Public Property TamWdt As Integer
        Get
            Return tamW
        End Get
        Set(value As Integer)
            tamW = value
        End Set
    End Property

    Public Property TamHgt As Integer
        Get
            Return tamH
        End Get
        Set(value As Integer)
            tamH = value
        End Set
    End Property
End Class
