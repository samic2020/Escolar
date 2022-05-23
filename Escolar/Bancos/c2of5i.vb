Imports System.ComponentModel

Public Class C2of5i
    Inherits BarCodeBase

    Private cPattern As String() = New String(99) {}
    Private Const START As String = "0000"
    Private Const [STOP] As String = "1000"
    Private bitmap As Bitmap
    Private g As Graphics

    Public Sub New()
    End Sub

    Public Sub New(ByVal Code As String, ByVal BarWidth As Integer, ByVal Height As Integer)
        Me.Code = Code
        Me.Height = Height
        Me.Width = BarWidth
    End Sub

    Public Sub New(ByVal Code As String, ByVal BarWidth As Integer, ByVal Height As Integer, ByVal Digits As Integer)
        Me.Code = Code
        Me.Height = Height
        Me.Width = BarWidth
        Me.Digits = Digits
    End Sub

    Private Sub FillPatern()
        Dim f As Integer
        Dim strTemp As String

        If cPattern(0) Is Nothing Then
            cPattern(0) = "00110"
            cPattern(1) = "10001"
            cPattern(2) = "01001"
            cPattern(3) = "11000"
            cPattern(4) = "00101"
            cPattern(5) = "10100"
            cPattern(6) = "01100"
            cPattern(7) = "00011"
            cPattern(8) = "10010"
            cPattern(9) = "01010"

            For f1 As Integer = 9 To 0 Step -1

                For f2 As Integer = 9 To 0 Step -1
                    f = f1 * 10 + f2
                    strTemp = ""

                    For i As Integer = 0 To 5 - 1
                        strTemp += cPattern(f1)(i).ToString() & cPattern(f2)(i).ToString()
                    Next

                    cPattern(f) = strTemp
                Next
            Next
        End If
    End Sub

    Public Function ToBitmap() As Bitmap
        Dim i As Integer
        Dim ftemp As String
        xPos = 0
        yPos = 0

        If Me.Digits = 0 Then
            Me.Digits = Me.Code.Length
        End If

        If Me.Digits Mod 2 > 0 Then Me.Digits += 1

        While Me.Code.Length < Me.Digits OrElse Me.Code.Length Mod 2 > 0
            Me.Code = "0" & Me.Code
        End While

        Dim _width As Integer = (2 * Full + 3 * Thin) * (Digits) + 7 * Thin + Full
        bitmap = New Bitmap(_width, Height)
        g = Graphics.FromImage(bitmap)
        DrawPattern(g, START)
        FillPatern()

        While Code.Length > 0
            i = Convert.ToInt32(Code.Substring(0, 2))

            If Me.Code.Length > 2 Then
                Me.Code = Me.Code.Substring(2, Me.Code.Length - 2)
            Else
                Me.Code = ""
            End If

            ftemp = cPattern(i)
            DrawPattern(g, ftemp)
        End While

        DrawPattern(g, [STOP])
        Return bitmap
    End Function

    Public Function ToByte() As Byte()
        Return MyBase.toByte(ToBitmap())
    End Function

    Public Shared Function ConvertImageToByte(ByVal image As Image) As Byte()
        If image Is Nothing Then Return Nothing
        Dim bytes As Byte()

        If image.[GetType]().ToString() = "System.Drawing.Image" Then
            Dim converter As ImageConverter = New ImageConverter()
            bytes = CType(converter.ConvertTo(image, GetType(Byte())), Byte())
            Return bytes
        ElseIf image.[GetType]().ToString() = "System.Drawing.Bitmap" Then
            bytes = CType(TypeDescriptor.GetConverter(image).ConvertTo(image, GetType(Byte())), Byte())
            Return bytes
        Else
            Throw New NotImplementedException("ConvertImageToByte invalid type " & image.[GetType]().ToString())
        End If
    End Function
End Class

' C2of5i cb = new C2of5i(Boleto.CodigoBarra.Codigo, 1, 50, Boleto.CodigoBarra.Codigo.Length);
' ms = New MemoryStream(Utils.ConvertImageToByte(cb.ToBitmap()));

' lrImagemCodigoBarra = New LinkedResource(ms, MediaTypeNames.Image.Gif);
' lrImagemCodigoBarra.ContentId = "codigobarra" + randomSufix; ;
