Imports System.Configuration
Imports System.IO

Public Class Settings
    Private cAppConfig As Configuration
    Private asSettings As AppSettingsSection

    Public Sub New()
        cAppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        asSettings = cAppConfig.AppSettings
    End Sub

    Public Sub New(Optional iniFile As String = "Escolar")
        If File.Exists(Application.StartupPath & "\" & iniFile) Then
            cAppConfig = ConfigurationManager.OpenExeConfiguration(Application.StartupPath & "\" & iniFile)
            asSettings = cAppConfig.AppSettings
        End If
    End Sub

    Public Sub Store(key As String, value As Object)
        Try
            asSettings.Settings.Item(key).Value = value
        Catch ex As Exception
            asSettings.Settings.Add(key, value)
        End Try
        cAppConfig.Save(ConfigurationSaveMode.Full)
    End Sub

    Public Function Load(key As String, Optional optionalvalue As Object = Nothing) As Object
        Try
            Dim appSettings = ConfigurationManager.AppSettings
            Dim result As Object = appSettings(key)

            If IsNothing(result) Then
                result = optionalvalue
            End If

            Return result
        Catch ec As ConfigurationErrorsException
            MessageBox.Show("Error reading app settings")
        End Try
        Return optionalvalue
    End Function

    Public Sub ConfigCreate()
        cAppConfig.SaveAs(Globais.appPath & "Escolar.config", ConfigurationSaveMode.Full, True)
    End Sub
End Class
