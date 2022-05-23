Imports System.Drawing.Imaging
Imports System.IO

Public MustInherit Class BarCodeBase
    Private _code As String
    Private _height As Integer
    Private _digits As Integer
    Private _thin As Integer
    Private _full As Integer
    Protected xPos As Integer = 0
    Protected yPos As Integer = 0
    Private _contenttype As String
    Protected BLACK As Brush = Brushes.Black
    Protected WHITE As Brush = Brushes.White

    Public Property Code As String
        Get

            Try
                Return _code
            Catch
                Return ""
            End Try
        End Get
        Set(ByVal value As String)

            Try
                _code = value
            Catch
                _code = Nothing
            End Try
        End Set
    End Property

    Public Property Width As Integer
        Get

            Try
                Return _thin
            Catch
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)

            Try
                Dim temp As Integer = value
                _thin = temp
                _full = temp * 3
            Catch
                Dim temp As Integer = 1
                _thin = temp
                _full = temp * 3
            End Try
        End Set
    End Property

    Public Property Height As Integer
        Get

            Try
                Return _height
            Catch
                Return 15
            End Try
        End Get
        Set(ByVal value As Integer)

            Try
                _height = value
            Catch
                _height = 1
            End Try
        End Set
    End Property

    Public Property Digits As Integer
        Get

            Try
                Return _digits
            Catch
                Return 0
            End Try
        End Get
        Set(ByVal value As Integer)

            Try
                _digits = value
            Catch
                _digits = 0
            End Try
        End Set
    End Property

    Public Property ContentType As String
        Get

            Try
                If _contenttype Is Nothing Then Return "image/jpeg"
                Return _contenttype
            Catch
                Return "image/jpeg"
            End Try
        End Get
        Set(ByVal value As String)

            Try
                _contenttype = value
            Catch
                _contenttype = "image/jpeg"
            End Try
        End Set
    End Property

    Protected ReadOnly Property Thin As Integer
        Get

            Try
                Return _thin
            Catch
                Return 1
            End Try
        End Get
    End Property

    Protected ReadOnly Property Full As Integer
        Get

            Try
                Return _full
            Catch
                Return 3
            End Try
        End Get
    End Property

    Protected Overridable Function toByte(ByVal bitmap As Bitmap) As Byte()
        Dim mstream As MemoryStream = New MemoryStream()
        Dim myImageCodecInfo As ImageCodecInfo = GetEncoderInfo(ContentType)
        Dim myEncoderParameter0 As EncoderParameter = New EncoderParameter(Encoder.Quality, CLng(100))
        Dim myEncoderParameters As EncoderParameters = New EncoderParameters(1)
        myEncoderParameters.Param(0) = myEncoderParameter0
        bitmap.Save(mstream, myImageCodecInfo, myEncoderParameters)
        Return mstream.GetBuffer()
    End Function

    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()

        For j = 0 To encoders.Length - 1
            If encoders(j).MimeType = mimeType Then Return encoders(j)
        Next

        Return Nothing
    End Function

    Protected Overridable Sub DrawPattern(ByRef g As Graphics, ByVal Pattern As String)
        Dim tempWidth As Integer

        For i As Integer = 0 To Pattern.Length - 1

            If Pattern(i) = "0"c Then
                tempWidth = _thin
            Else
                tempWidth = _full
            End If

            If i Mod 2 = 0 Then
                g.FillRectangle(BLACK, xPos, yPos, tempWidth, _height)
            Else
                g.FillRectangle(WHITE, xPos, yPos, tempWidth, _height)
            End If

            xPos += tempWidth
        Next
    End Sub
End Class