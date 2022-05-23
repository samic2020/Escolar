Imports CicleDotNet.CSUST.Data

Public Class Controles
    Private controle As Object()

    Public Sub New(ctrl As Object())
        controle = ctrl
    End Sub

    Public Sub BotaoEnableDisable(ctrl As Object()())
        If (ctrl.Length <= 0) Then Return
        For Each jb As Object In controle
            For Each bt As Object() In ctrl
                If bt Is Nothing Then Continue For
                If CType(jb, Button).Name.Equals(CType(bt(0), Button).Name, StringComparison.CurrentCultureIgnoreCase) Then CType(jb, Button).Enabled = CType(bt(1), Boolean)
            Next
        Next
    End Sub

    Public Sub BotaoEnabled(botao As Button())
        '// Disable all buttons
        For Each jb As Button In controle
            jb.Enabled = False
        Next
        If (botao.Length <= 0) Then Return

        '// Enable same buttons
        For Each jb As Button In controle
            For Each bt As Button In botao
                If bt Is Nothing Then Continue For
                If jb.Name.Equals(bt.Name, StringComparison.CurrentCultureIgnoreCase) Then jb.Enabled = True
            Next
        Next
    End Sub

    Public Sub BotaoDisabled(botao As Button())
        '// Disable all buttons
        For Each jb As Button In controle
            If jb Is Nothing Then Continue For
            jb.Enabled = True
        Next
        If (botao.Length <= 0) Then Return

        '// Enable same buttons
        For Each jb As Button In controle
            For Each bt As Button In botao
                If bt Is Nothing Then Continue For
                If jb.Name.Equals(bt.Name, StringComparison.CurrentCultureIgnoreCase) Then jb.Enabled = False
            Next
        Next
    End Sub

    Public Sub FieldsEnabled(value As Boolean)
        For Each jb As Object() In controle
            ' If jb.Length > 1 Then If jb(1) = True Then Continue For

            If TypeOf jb(0) Is TextBox Then
                CType(jb(0), TextBox).ReadOnly = Not value
            ElseIf TypeOf jb(0) Is MaskedTextBox Then
                CType(jb(0), MaskedTextBox).ReadOnly = Not value
            ElseIf TypeOf jb(0) Is PictureBox Then
                CType(jb(0), PictureBox).Enabled = value
            ElseIf TypeOf jb(0) Is ComboBox Then
                CType(jb(0), ComboBox).Enabled = value
            ElseIf TypeOf jb(0) Is MultiColumnComboBoxEx Then
                CType(jb(0), ComboBox).Enabled = value
            ElseIf TypeOf jb(0) Is NumericUpDown Then
                CType(jb(0), NumericUpDown).Enabled = value
            ElseIf TypeOf jb(0) Is DomainUpDown Then
                CType(jb(0), DomainUpDown).Enabled = value
            ElseIf TypeOf jb(0) Is CheckBox Then
                CType(jb(0), CheckBox).Enabled = value
            ElseIf TypeOf jb(0) Is RichTextBox Then
                CType(jb(0), RichTextBox).ReadOnly = Not value
            ElseIf TypeOf jb(0) Is DateTimePicker Then
                CType(jb(0), DateTimePicker).Enabled = value
            End If
        Next
    End Sub

    Public Sub Focus()
        For Each jb As Object() In controle
            Dim podeEnter As Boolean = jb.Length = 1
            If jb.Length > 1 Then
                podeEnter = jb(1)
            End If
            If TypeOf jb(0) Is TextBox Then
                AddHandler CType(jb(0), TextBox).Enter, Sub(sender As Object, e As EventArgs)
                                                            If Not CType(jb(0), TextBox).ReadOnly Then
                                                                CType(jb(0), TextBox).BackColor = Color.White
                                                                CType(jb(0), TextBox).ForeColor = Color.DarkBlue
                                                                CType(jb(0), TextBox).Font = New Font(CType(jb(0), TextBox).Font.Name, CType(jb(0), TextBox).Font.Size, FontStyle.Bold)
                                                                If CType(jb(0), TextBox).Multiline Then
                                                                    CType(jb(0), TextBox).AcceptsReturn = False
                                                                    CType(jb(0), TextBox).AcceptsTab = False
                                                                Else
                                                                    CType(jb(0), TextBox).AcceptsReturn = True
                                                                    CType(jb(0), TextBox).AcceptsTab = True
                                                                End If
                                                            End If
                                                            CType(jb(0), TextBox).SelectAll()
                                                        End Sub

                AddHandler CType(jb(0), TextBox).Leave, Sub(sender As Object, e As EventArgs)
                                                            If Not CType(jb(0), TextBox).ReadOnly Then
                                                                CType(jb(0), TextBox).BackColor = Color.White
                                                                CType(jb(0), TextBox).ForeColor = Color.Black
                                                                CType(jb(0), TextBox).Font = New Font(CType(jb(0), TextBox).Font.Name, CType(jb(0), TextBox).Font.Size, FontStyle.Regular)
                                                            End If
                                                        End Sub

                If podeEnter Then
                    AddHandler CType(jb(0), TextBox).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                                If CType(jb(0), TextBox).Multiline Then
                                                                    If e.KeyCode = Keys.Enter And e.Control Then
                                                                        CType(jb(0), TextBox).AppendText(vbNewLine)
                                                                        Exit Sub
                                                                    End If
                                                                    If e.KeyCode = Keys.KeyCode.Return Then
                                                                        SendKeys.Send("{Tab}")
                                                                        Exit Sub
                                                                    End If
                                                                Else
                                                                    If e.KeyCode = Keys.KeyCode.Return Then
                                                                        SendKeys.Send("{Tab}")
                                                                        Exit Sub
                                                                    End If
                                                                End If
                                                            End Sub
                    AddHandler CType(jb(0), TextBox).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                  If e.KeyCode = Keys.KeyCode.Return Then
                                                                      e.SuppressKeyPress = True
                                                                  End If
                                                              End Sub
                End If
            ElseIf TypeOf jb(0) Is MaskedTextBox Then
                AddHandler CType(jb(0), MaskedTextBox).Enter, Sub(sender As Object, e As EventArgs)
                                                                  If Not CType(jb(0), MaskedTextBox).ReadOnly Then
                                                                      CType(jb(0), MaskedTextBox).BackColor = Color.White
                                                                      CType(jb(0), MaskedTextBox).ForeColor = Color.DarkBlue
                                                                      CType(jb(0), MaskedTextBox).Font = New Font(CType(jb(0), MaskedTextBox).Font.Name, CType(jb(0), MaskedTextBox).Font.Size, FontStyle.Bold)
                                                                  End If
                                                                  CType(jb(0), MaskedTextBox).SelectAll()
                                                              End Sub

                AddHandler CType(jb(0), MaskedTextBox).Leave, Sub(sender As Object, e As EventArgs)
                                                                  If Not CType(jb(0), MaskedTextBox).ReadOnly Then
                                                                      CType(jb(0), MaskedTextBox).BackColor = Color.White
                                                                      CType(jb(0), MaskedTextBox).ForeColor = Color.Black
                                                                      CType(jb(0), MaskedTextBox).Font = New Font(CType(jb(0), MaskedTextBox).Font.Name, CType(jb(0), MaskedTextBox).Font.Size, FontStyle.Regular)
                                                                  End If
                                                              End Sub
                AddHandler CType(jb(0), MaskedTextBox).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                                  If e.KeyCode = Keys.KeyCode.Return Then
                                                                      SendKeys.Send("{Tab}")
                                                                  End If
                                                              End Sub
                AddHandler CType(jb(0), MaskedTextBox).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                    If e.KeyCode = Keys.KeyCode.Return Then
                                                                        e.SuppressKeyPress = True
                                                                    End If
                                                                End Sub
            ElseIf TypeOf jb(0) Is RichTextBox Then
                AddHandler CType(jb(0), RichTextBox).Enter, Sub(sender As Object, e As EventArgs)
                                                                If Not CType(jb(0), RichTextBox).ReadOnly Then
                                                                    CType(jb(0), RichTextBox).BackColor = Color.White
                                                                    CType(jb(0), RichTextBox).ForeColor = Color.DarkBlue
                                                                    CType(jb(0), RichTextBox).Font = New Font(CType(jb(0), RichTextBox).Font.Name, CType(jb(0), RichTextBox).Font.Size, FontStyle.Bold)
                                                                End If
                                                                CType(jb(0), RichTextBox).SelectAll()
                                                            End Sub

                AddHandler CType(jb(0), RichTextBox).Leave, Sub(sender As Object, e As EventArgs)
                                                                If Not CType(jb(0), RichTextBox).ReadOnly Then
                                                                    CType(jb(0), RichTextBox).BackColor = Color.White
                                                                    CType(jb(0), RichTextBox).ForeColor = Color.Black
                                                                    CType(jb(0), RichTextBox).Font = New Font(CType(jb(0), RichTextBox).Font.Name, CType(jb(0), RichTextBox).Font.Size, FontStyle.Regular)
                                                                End If
                                                            End Sub
                AddHandler CType(jb(0), RichTextBox).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                                If e.KeyCode = Keys.KeyCode.Return Then
                                                                    SendKeys.Send("{Tab}")
                                                                End If
                                                            End Sub
                AddHandler CType(jb(0), RichTextBox).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                  If e.KeyCode = Keys.KeyCode.Return Then
                                                                      e.SuppressKeyPress = True
                                                                  End If
                                                              End Sub
            ElseIf TypeOf jb(0) Is Label Then
                AddHandler CType(jb(0), Label).Enter, Sub(sender As Object, e As EventArgs)
                                                          If CType(jb(0), Label).Enabled Then
                                                              CType(jb(0), Label).BackColor = Color.White
                                                              CType(jb(0), Label).ForeColor = Color.DarkBlue
                                                              CType(jb(0), Label).Font = New Font(CType(jb(0), Label).Font.Name, CType(jb(0), Label).Font.Size, FontStyle.Bold)
                                                          End If
                                                      End Sub
                AddHandler CType(jb(0), Label).Leave, Sub(sender As Object, e As EventArgs)
                                                          If CType(jb(0), Label).Enabled Then
                                                              CType(jb(0), Label).BackColor = Color.White
                                                              CType(jb(0), Label).ForeColor = Color.Black
                                                              CType(jb(0), Label).Font = New Font(CType(jb(0), Label).Font.Name, CType(jb(0), Label).Font.Size, FontStyle.Regular)
                                                          End If
                                                      End Sub
                AddHandler CType(jb(0), Label).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                          If e.KeyCode = Keys.KeyCode.Return Then
                                                              SendKeys.Send("{Tab}")
                                                          End If
                                                      End Sub
                AddHandler CType(jb(0), Label).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                            If e.KeyCode = Keys.KeyCode.Return Then
                                                                e.SuppressKeyPress = True
                                                            End If
                                                        End Sub
            ElseIf TypeOf jb(0) Is ComboBox Then
                AddHandler CType(jb(0), ComboBox).Enter, Sub(sender As Object, e As EventArgs)
                                                             If CType(jb(0), ComboBox).Enabled Then
                                                                 CType(jb(0), ComboBox).BackColor = Color.White
                                                                 CType(jb(0), ComboBox).ForeColor = Color.DarkBlue
                                                                 CType(jb(0), ComboBox).Font = New Font(CType(jb(0), ComboBox).Font.Name, CType(jb(0), ComboBox).Font.Size, FontStyle.Bold)
                                                             End If
                                                             CType(jb(0), ComboBox).SelectAll()
                                                         End Sub
                AddHandler CType(jb(0), ComboBox).Leave, Sub(sender As Object, e As EventArgs)
                                                             If CType(jb(0), ComboBox).Enabled Then
                                                                 CType(jb(0), ComboBox).BackColor = Color.White
                                                                 CType(jb(0), ComboBox).ForeColor = Color.Black
                                                                 CType(jb(0), ComboBox).Font = New Font(CType(jb(0), ComboBox).Font.Name, CType(jb(0), ComboBox).Font.Size, FontStyle.Regular)
                                                             End If
                                                         End Sub
                AddHandler CType(jb(0), ComboBox).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                             If e.KeyCode = Keys.KeyCode.Return Then
                                                                 SendKeys.Send("{Tab}")
                                                             End If
                                                         End Sub
                AddHandler CType(jb(0), ComboBox).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                               If e.KeyCode = Keys.KeyCode.Return Then
                                                                   e.SuppressKeyPress = True
                                                               End If
                                                           End Sub
            ElseIf TypeOf jb(0) Is MultiColumnComboBoxEx Then
                'AddHandler CType(jb(0), MultiColumnComboBoxEx).Enter, Sub(sender As Object, e As EventArgs)
                '                                                          If CType(jb(0), MultiColumnComboBoxEx).Enabled Then
                '                                                              CType(jb(0), MultiColumnComboBoxEx).BackColor = Color.White
                '                                                              CType(jb(0), MultiColumnComboBoxEx).ForeColor = Color.DarkBlue
                '                                                              CType(jb(0), MultiColumnComboBoxEx).Font = New Font("Arial", 8, FontStyle.Bold)
                '                                                          End If
                '                                                          CType(jb(0), MultiColumnComboBoxEx).SelectAll()
                '                                                      End Sub
                'AddHandler CType(jb(0), MultiColumnComboBoxEx).Leave, Sub(sender As Object, e As EventArgs)
                '                                                          If CType(jb(0), ComboBox).Enabled Then
                '                                                              CType(jb(0), ComboBox).BackColor = Color.White
                '                                                              CType(jb(0), ComboBox).ForeColor = Color.Black
                '                                                              CType(jb(0), ComboBox).Font = New Font("Arial", 8, FontStyle.Regular)
                '                                                          End If
                '                                                      End Sub
                'AddHandler CType(jb(0), MultiColumnComboBoxEx).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                '                                                          If e.KeyCode = Keys.KeyCode.Return Then
                '                                                              SendKeys.Send("{Tab}")
                '                                                          End If
                '                                                      End Sub
                'AddHandler CType(jb(0), MultiColumnComboBoxEx).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                '                                                            If e.KeyCode = Keys.KeyCode.Return Then
                '                                                                e.SuppressKeyPress = True
                '                                                            End If
                '                                                        End Sub
            ElseIf TypeOf jb(0) Is NumericUpDown Then
                AddHandler CType(jb(0), NumericUpDown).Enter, Sub(sender As Object, e As EventArgs)
                                                                  If Not CType(jb(0), NumericUpDown).ReadOnly Then
                                                                      CType(jb(0), NumericUpDown).BackColor = Color.White
                                                                      CType(jb(0), NumericUpDown).ForeColor = Color.DarkBlue
                                                                      CType(jb(0), NumericUpDown).Font = New Font(CType(jb(0), NumericUpDown).Font.Name, CType(jb(0), NumericUpDown).Font.Size, FontStyle.Bold)
                                                                  End If
                                                              End Sub
                AddHandler CType(jb(0), NumericUpDown).Leave, Sub(sender As Object, e As EventArgs)
                                                                  If Not CType(jb(0), NumericUpDown).ReadOnly Then
                                                                      CType(jb(0), NumericUpDown).BackColor = Color.White
                                                                      CType(jb(0), NumericUpDown).ForeColor = Color.Black
                                                                      CType(jb(0), NumericUpDown).Font = New Font(CType(jb(0), NumericUpDown).Font.Name, CType(jb(0), NumericUpDown).Font.Size, FontStyle.Regular)
                                                                  End If
                                                              End Sub
                AddHandler CType(jb(0), NumericUpDown).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                                  If e.KeyCode = Keys.KeyCode.Return Then
                                                                      SendKeys.Send("{Tab}")
                                                                  End If
                                                              End Sub
                AddHandler CType(jb(0), NumericUpDown).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                    If e.KeyCode = Keys.KeyCode.Return Then
                                                                        e.SuppressKeyPress = True
                                                                    End If
                                                                End Sub
            ElseIf TypeOf jb(0) Is CheckBox Then
                AddHandler CType(jb(0), CheckBox).Enter, Sub(sender As Object, e As EventArgs)
                                                             If CType(jb(0), CheckBox).Enabled Then
                                                                 CType(jb(0), CheckBox).BackColor = Color.White
                                                                 CType(jb(0), CheckBox).ForeColor = Color.DarkBlue
                                                                 CType(jb(0), CheckBox).Font = New Font(CType(jb(0), CheckBox).Font.Name, CType(jb(0), CheckBox).Font.Size, FontStyle.Bold)
                                                             End If
                                                         End Sub
                AddHandler CType(jb(0), CheckBox).Leave, Sub(sender As Object, e As EventArgs)
                                                             If CType(jb(0), CheckBox).Enabled Then
                                                                 CType(jb(0), CheckBox).BackColor = Color.White
                                                                 CType(jb(0), CheckBox).ForeColor = Color.Black
                                                                 CType(jb(0), CheckBox).Font = New Font(CType(jb(0), CheckBox).Font.Name, CType(jb(0), CheckBox).Font.Size, FontStyle.Regular)
                                                             End If
                                                         End Sub
                AddHandler CType(jb(0), CheckBox).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                             If e.KeyCode = Keys.KeyCode.Return Then
                                                                 SendKeys.Send("{Tab}")
                                                             End If
                                                         End Sub
                AddHandler CType(jb(0), CheckBox).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                               If e.KeyCode = Keys.KeyCode.Return Then
                                                                   e.SuppressKeyPress = True
                                                               End If
                                                           End Sub
            ElseIf TypeOf jb(0) Is DateTimePicker Then
                AddHandler CType(jb(0), DateTimePicker).Enter, Sub(sender As Object, e As EventArgs)
                                                                   If CType(jb(0), DateTimePicker).Enabled Then
                                                                       CType(jb(0), DateTimePicker).BackColor = Color.White
                                                                       CType(jb(0), DateTimePicker).ForeColor = Color.DarkBlue
                                                                       CType(jb(0), DateTimePicker).Font = New Font(CType(jb(0), DateTimePicker).Font.Name, CType(jb(0), DateTimePicker).Font.Size, FontStyle.Bold)
                                                                   End If
                                                               End Sub
                AddHandler CType(jb(0), DateTimePicker).Leave, Sub(sender As Object, e As EventArgs)
                                                                   If CType(jb(0), DateTimePicker).Enabled Then
                                                                       CType(jb(0), DateTimePicker).BackColor = Color.White
                                                                       CType(jb(0), DateTimePicker).ForeColor = Color.Black
                                                                       CType(jb(0), DateTimePicker).Font = New Font(CType(jb(0), DateTimePicker).Font.Name, CType(jb(0), DateTimePicker).Font.Size, FontStyle.Regular)
                                                                   End If
                                                               End Sub
                AddHandler CType(jb(0), DateTimePicker).KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                                                   If e.KeyCode = Keys.KeyCode.Return Then
                                                                       SendKeys.Send("{Tab}")
                                                                   End If
                                                               End Sub
                AddHandler CType(jb(0), DateTimePicker).KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                                                     If e.KeyCode = Keys.KeyCode.Return Then
                                                                         e.SuppressKeyPress = True
                                                                     End If
                                                                 End Sub
            End If

            'If jb.Length > 2 Then
            '    If jb(2) = Nothing Then
            '        SendKeys.Send("{Tab}")
            '        'Continue For
            '    End If
            'End If

        Next
    End Sub

    Public Sub FormataNumero(controle As TextBox, Optional decimais As Integer = 0, Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)

        AddHandler controle.TextChanged, Sub(sender As Object, e As EventArgs)
                                             Dim retorno As String = Nothing
                                             If controle.Text.Length = 0 Then
                                                 retorno = "0" & If(decimais > 0, "," & StrDup(decimais, "0"), "")
                                                 controle.Text = retorno
                                                 Exit Sub
                                             End If

                                             Dim auxtxt As String = RemoveAllSymbols(controle.Text)
                                             auxtxt = auxtxt.TrimStart("0")
                                             retorno = Format(CDec(Val(auxtxt).ToString("0\.000\.000\.000" & If(decimais > 0, "\," & StrDup(decimais, "0"), ""))), If(decimais > 0, "#," & StrDup(decimais, "#") & "0." & StrDup(decimais, "0"), "#0"))
                                             controle.Text = retorno
                                             controle.SelectionStart = controle.Text.Length
                                         End Sub

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.KeyCode.Return Then
                                           SendKeys.Send("{Tab}")
                                           Exit Sub
                                       End If
                                       If InStr("1234567890", Chr(e.KeyCode)) = 0 Then
                                           e.Handled = True
                                       End If
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Regular)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub
    End Sub

    Public Sub FormataData(controle As TextBox, Optional mask As String = "00\-00\-0000", Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)
        controle.MaxLength = mask.Replace("\", "").Length + 1

        AddHandler controle.TextChanged, Sub(sender As Object, e As EventArgs)
                                             Dim retorno As String = Nothing
                                             If controle.Text.Length = 0 Then
                                                 retorno = ""
                                                 controle.Text = retorno
                                                 Exit Sub
                                             End If

                                             Dim auxtxt As String = RemoveAllSymbols(controle.Text)
                                             auxtxt = auxtxt.TrimStart("0")
                                             retorno = Val(auxtxt).ToString(mask)
                                             controle.Text = retorno
                                             controle.SelectionStart = controle.Text.Length
                                         End Sub

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.KeyCode.Return Then
                                           If controle.Text.Trim = mask.Replace("\", "") Then
                                               controle.Text = ""
                                               SendKeys.Send("{Tab}")
                                           End If
                                           'If Not IsDate(controle.Text) Then Exit Sub
                                           SendKeys.Send("{Tab}")
                                           Return
                                       End If
                                       If InStr("1234567890", Chr(e.KeyCode)) = 0 Then
                                           e.Handled = True
                                       End If
                                       If controle.Text.Trim.Length > mask.Replace("\", "").Length Then
                                           SendKeys.Send("{Backspace}")
                                           Exit Sub
                                       End If
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Regular)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub

    End Sub

    Public Sub FormataMask(controle As TextBox, Optional mask As String = "00000\-000", Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)
        Dim isAutoEnter As Boolean = False

        AddHandler controle.TextChanged, Sub(sender As Object, e As EventArgs)
                                             Dim retorno As String = Nothing
                                             If controle.Text.Length = 0 Then
                                                 retorno = ""
                                                 controle.Text = retorno
                                                 Exit Sub
                                             End If

                                             Dim auxtxt As String = RemoveAllSymbols(controle.Text)
                                             auxtxt = auxtxt.TrimStart("0")
                                             retorno = Val(auxtxt).ToString(Right(mask.Replace("\", ""), controle.Text.Trim.Length))
                                             controle.Text = retorno
                                             controle.SelectionStart = controle.Text.Length
                                         End Sub

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.KeyCode.Return Then
                                           '    If controle.Text.Trim = mask.Replace("\", "") Or controle.Text.Trim = "" Then
                                           '        controle.Text = ""
                                           '        SendKeys.Send("{Tab}")
                                           '        Exit Sub
                                           '    End If
                                           '    If controle.Text.Trim.Length < mask.Replace("\", "").Length Then Exit Sub
                                           SendKeys.Send("{Tab}")
                                           Exit Sub
                                       End If
                                       If InStr("1234567890", Chr(e.KeyCode)) = 0 Then
                                           e.Handled = True
                                       End If
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                           controle.MaxLength = mask.Length
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Regular)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub

    End Sub

    Public Sub FormataCPF(controle As TextBox, Optional mask As String = "000\.000\.000\-00", Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)

        AddHandler controle.TextChanged, Sub(sender As Object, e As EventArgs)
                                             Dim retorno As String = Nothing
                                             If controle.Text.Length = 0 Then
                                                 retorno = ""
                                                 controle.Text = retorno
                                                 Exit Sub
                                             End If

                                             Dim auxtxt As String = RemoveAllSymbols(controle.Text)
                                             retorno = Val(auxtxt).ToString(mask)
                                             controle.Text = retorno
                                             controle.SelectionStart = controle.Text.Length
                                         End Sub

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.KeyCode.Return Then
                                           If controle.Text.Trim = mask.Replace("\", "") Or controle.Text.Trim = "" Then
                                               controle.Text = ""
                                               SendKeys.Send("{Tab}")
                                               Exit Sub
                                           End If
                                           If controle.Text.Trim.Length < mask.Replace("\", "").Length Then Exit Sub
                                           SendKeys.Send("{Tab}")
                                       End If
                                       If InStr("1234567890", Chr(e.KeyCode)) = 0 Then
                                           e.Handled = True
                                       End If
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Regular)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub

    End Sub

    Public Sub FormataHora(controle As TextBox, Optional mask As String = "00\:00", Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)

        AddHandler controle.TextChanged, Sub(sender As Object, e As EventArgs)
                                             Dim retorno As String = Nothing
                                             If controle.Text.Length = 0 Then
                                                 retorno = ""
                                                 controle.Text = retorno
                                                 Exit Sub
                                             End If

                                             Dim auxtxt As String = RemoveAllSymbols(controle.Text)
                                             retorno = Val(auxtxt.Replace(":", "")).ToString(mask)
                                             controle.Text = retorno
                                             controle.SelectionStart = controle.Text.Length
                                         End Sub

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.KeyCode.Return Then
                                           If controle.Text.Trim = mask.Replace("\", "") Or controle.Text.Trim = "" Then
                                               controle.Text = ""
                                               SendKeys.Send("{Tab}")
                                               Exit Sub
                                           End If
                                           If controle.Text.Trim.Length < mask.Replace("\", "").Length Then Exit Sub
                                           SendKeys.Send("{Tab}")
                                       End If
                                       If InStr("1234567890", Chr(e.KeyCode)) = 0 Then
                                           e.Handled = True
                                       End If
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub

    End Sub

    Public Sub FormataTelephone(controle As TextBox, Optional foreColor As Color = Nothing, Optional backColor As Color = Nothing)
        If foreColor = Nothing Then foreColor = Color.FromArgb(0, 0, 192)
        If backColor = Nothing Then backColor = Color.FromArgb(255, 255, 255)
        Dim isAutoEnter As Boolean = False

        AddHandler controle.KeyUp, Sub(sender As Object, e As KeyEventArgs)
                                       If e.KeyCode = Keys.Return Then
                                           SendKeys.Send("{Tab}")
                                           Return
                                       End If
                                       If Not IsNumeric(e.KeyValue) Then Return
                                       If controle.Text.Trim.Length > 10 Then
                                           e.SuppressKeyPress = True
                                           Return
                                       End If
                                       If Len(controle.Text) = 4 Then
                                           controle.Text = controle.Text + "-"
                                           controle.SelectionStart = controle.Text.Length
                                           Return
                                       End If
                                       If Len(controle.Text) = 10 Then
                                           controle.Text = Strings.Left(controle.Text, 4) + Mid(controle.Text, 6, 1) + "-" + Strings.Right(controle.Text, 4)
                                           controle.SelectionStart = controle.Text.Length
                                           Return
                                       End If
                                       e.SuppressKeyPress = True
                                       controle.Text.Insert(controle.Text.Length, e.KeyValue)
                                   End Sub

        AddHandler controle.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                         If e.KeyCode = Keys.KeyCode.Return Then
                                             e.SuppressKeyPress = True
                                         End If
                                     End Sub

        AddHandler controle.Enter, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = Color.White
                                           controle.ForeColor = Color.DarkBlue
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Bold)
                                       End If
                                   End Sub

        AddHandler controle.Leave, Sub(sender As Object, e As EventArgs)
                                       If Not controle.ReadOnly Then
                                           controle.BackColor = backColor
                                           controle.ForeColor = foreColor
                                           controle.Font = New Font(controle.Font.Name, controle.Font.Size, FontStyle.Regular)
                                       End If
                                   End Sub

        AddHandler controle.Click, Sub(sender As Object, e As EventArgs)
                                       controle.SelectionStart = controle.Text.Length
                                   End Sub

    End Sub

    Public Sub SetTabOrder(ctrl As Object())
        Dim zOrder As Integer = 0
        For Each jb As Object In controle
            If TypeOf jb(0) Is TextBox Then
                CType(jb(0), TextBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is MaskedTextBox Then
                CType(jb(0), MaskedTextBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is RichTextBox Then
                CType(jb(0), RichTextBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is Label Then
                CType(jb(0), Label).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is ComboBox Then
                CType(jb(0), ComboBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is MultiColumnComboBoxEx Then
                CType(jb(0), ComboBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is NumericUpDown Then
                CType(jb(0), NumericUpDown).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is CheckBox Then
                CType(jb(0), CheckBox).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is DateTimePicker Then
                CType(jb(0), DateTimePicker).TabIndex = zOrder
            ElseIf TypeOf jb(0) Is Button Then
                CType(jb(0), Button).TabIndex = zOrder
            End If
        Next
    End Sub
End Class
