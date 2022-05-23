Public Class Datas
    Public DAY As Integer = 0

    Public Datas()

    Public Function PrimeiroDiadoMes(Data As Date) As Date
        Return DateTime.Parse("01" + Data.ToString("/MM/yyyy"))
    End Function

    Public Function UltimoDiadoMes(Data As Date) As Date
        Dim pDiadoMes As Date = PrimeiroDiadoMes(Data)
        Dim pDiaMesSeg As Date = pDiadoMes.AddMonths(1)
        Return pDiaMesSeg.AddDays(-1)
    End Function

    Public Function StringToDate(value As String) As Date
        Return Convert.ToDateTime(value)
    End Function

    Public Function DateDiff(patern As String, Data1 As Date, Data2 As Date) As Integer
        Dim a As Long = Data2.Ticks
        Dim b As Long = Data1.Ticks

        Dim i As Long = (a - b)

        Dim r As Long = 0
        If "D".Equals(patern.Trim.ToUpper) Then
            r = (i / 1000 / 60 / 60 / 24)
        ElseIf "M".Equals(patern.Trim.ToUpper) Then
            r = (i / 1000 / 60 / 60 / 24 / 30)
        ElseIf "A".Equals(patern.Trim.ToUpper) Then
            r = (i / 1000 / 60 / 60 / 24 / 365)
        End If

        Return Convert.ToInt32(r)
    End Function

End Class
