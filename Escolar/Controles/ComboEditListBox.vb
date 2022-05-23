Imports MySql.Data.MySqlClient

Public Class ComboEditListBox
    Inherits ListBox

    Private dbMain As [Db] = New Db

    Public Sub New()
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed

        Me.CommitOnLeave = True
        Me.CommitOnEnter = True
        Me.AllowDelete = True
        Me.ConfirmDelete = True
        Me.ConfirmDeleteText = "Are you sure you want to delete the selected items?"

        ' Create a new TextBox and set some properties
        comboBox = New ComboBox()
        comboBox.Visible = False
        'comboBox.AcceptsReturn = False
        'comboBox.AcceptsTab = True
        comboBox.BackColor = Me.BackColor
        comboBox.ForeColor = Me.ForeColor
        comboBox.Font = Me.Font

        AddHandler comboBox.Leave, AddressOf comboBox_Leave
        AddHandler comboBox.KeyDown, AddressOf comboBox_KeyDown

        comboBox.MaxLength = 45
        With comboBox
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim myPend As New AutoCompleteStringCollection
            myPend.AddRange(New ListasDiversas().Pendencias)
            .AutoCompleteCustomSource = myPend
            .DataSource = myPend
        End With

        Me.Controls.Add(comboBox)
    End Sub

#Region "Private Fields"

    Private comboBox As ComboBox
    Private editingIndex As Integer = -1

#End Region

#Region "Constants"

    Private Const WM_VSCROLL As Integer = &H115
    Private Const WM_MOUSEWHEEL As Integer = &H20A

#End Region

#Region "Events"

    Public Event ItemEdited As EventHandler(Of EditEventArgs)

#End Region

#Region "Properties"

    Private _CommitOnLeave As Boolean
    ''' <summary>
    ''' Gets or sets a value determining whether the editing text is committed when the editing textbox loses focus.
    ''' </summary>
    Public Property CommitOnLeave() As Boolean
        Get
            Return _CommitOnLeave
        End Get
        Set(ByVal value As Boolean)
            _CommitOnLeave = value
        End Set
    End Property

    Private _CommitOnEnter As Boolean
    ''' <summary>
    ''' Gets or sets a value determining whether the editing text is committed when the user presses the Enter or Return key.
    ''' </summary>
    Public Property CommitOnEnter() As Boolean
        Get
            Return _CommitOnEnter
        End Get
        Set(ByVal value As Boolean)
            _CommitOnEnter = value
        End Set
    End Property

    Private _AllowDelete As Boolean
    ''' <summary>
    ''' Gets or sets a value determining whether the user can delete items using the Delete key.
    ''' </summary>
    Public Property AllowDelete() As Boolean
        Get
            Return _AllowDelete
        End Get
        Set(ByVal value As Boolean)
            _AllowDelete = value
        End Set
    End Property

    Private _ConfirmDelete As Boolean
    ''' <summary>
    ''' Gets or sets a value determining whether a confirmation MessageBox is shown when the Delete key is pressed to delete items.
    ''' </summary>
    Public Property ConfirmDelete() As Boolean
        Get
            Return _ConfirmDelete
        End Get
        Set(ByVal value As Boolean)
            _ConfirmDelete = value
        End Set
    End Property

    Private _ConfirmDeleteText As String
    ''' <summary>
    ''' Gets or sets the text displayed in the confirmation MessageBox when the Delete key is pressed to delete items.
    ''' </summary>
    Public Property ConfirmDeleteText() As String
        Get
            Return _ConfirmDeleteText
        End Get
        Set(ByVal value As String)
            _ConfirmDeleteText = value
        End Set
    End Property

#End Region

#Region "Overrides"

    Protected Overloads Overrides Sub OnFontChanged(ByVal e As EventArgs)
        MyBase.OnFontChanged(e)

        ' Match the font of the editing TextBox
        comboBox.Font = Me.Font
    End Sub

    Protected Overloads Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)

        ' Match the BackColor of the editing TextBox
        comboBox.BackColor = Me.BackColor
    End Sub

    Protected Overloads Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)

        ' Match the ForeColor of the editing TextBox
        comboBox.ForeColor = Me.ForeColor
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)

        ' Dispose the TextBox
        If disposing Then
            comboBox.Dispose()
        End If
    End Sub

    Protected Overloads Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
        MyBase.OnDrawItem(e)

        ' Draw the default background
        e.DrawBackground()

        If e.Index > -1 AndAlso e.Index < Me.Items.Count Then
            Dim item As Object = Me.Items(e.Index)
            Dim text As String = Me.GetItemText(item)
            Dim itemRect As Rectangle = Me.GetItemRectangle(e.Index)

            Dim textColor As Color

            ' Check if the item is selected
            ' if so, the background and textcolor is different
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                textColor = SystemColors.HighlightText
                Using b = New SolidBrush(SystemColors.Highlight)
                    e.Graphics.FillRectangle(b, itemRect)
                End Using
            Else
                textColor = Me.ForeColor
            End If

            ' Draw the text
            Using b = New SolidBrush(textColor)
                e.Graphics.DrawString(text, Me.Font, b, itemRect.Location)
            End Using
        End If

        ' Draw the focus rectangle
        e.DrawFocusRectangle()
    End Sub

    Protected Overloads Overrides Sub OnMouseDoubleClick(ByVal e As MouseEventArgs)
        MyBase.OnMouseDoubleClick(e)

        If e.Button = System.Windows.Forms.MouseButtons.Left Then
            ' If the left button is double-clicked, check if the double-click occured in an Item Rectangle
            For i As Integer = 0 To Me.Items.Count - 1
                Dim itemRect As Rectangle = Me.GetItemRectangle(i)
                If itemRect.Contains(e.Location) Then
                    ' The double-click occured in this item, so display the TextBox in the right place, match its Text to the item's Text and give it focus.
                    editingIndex = i
                    comboBox.Bounds = itemRect
                    comboBox.Visible = True
                    comboBox.Text = Me.GetItemText(Me.Items(i))
                    comboBox.SelectionStart = 0
                    comboBox.SelectionLength = comboBox.Text.Length
                    comboBox.Focus()
                    Exit For
                End If
            Next
        End If
    End Sub

    Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Delete AndAlso Me.AllowDelete Then
            Me.DeleteSelectedItems()
        End If
    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        ' When the user starts scrolling, commit the edit
        If m.Msg = WM_VSCROLL OrElse m.Msg = WM_MOUSEWHEEL Then
            If Me.CommitOnLeave Then
                Me.CommitTextBox()
            Else
                Me.RollBackTextBox()
            End If
        End If
    End Sub

#End Region

#Region "Textbox Events"

    Private Sub comboBox_Leave(ByVal sender As Object, ByVal e As EventArgs)
        If Me.CommitOnLeave Then
            If comboBox.SelectedIndex = -1 Then
                If comboBox.Text.Trim <> "" And comboBox.Text.Trim.ToUpper <> "ITEM" Then
                    Dim textoDig As String = comboBox.Text

                    '// Gravação da pendencia e adição
                    Dim ds As Object = comboBox.DataSource
                    ds.Add(textoDig)
                    comboBox.DataSource = Nothing
                    comboBox.DataSource = ds

                    Dim insertSQL As String = "INSERT INTO `pendencias`(`pendencia`) VALUES (@pendencia);"
                    dbMain.ExecuteCmd(insertSQL, New Object()() {({"@pendencia", textoDig})})
                End If
            End If
            'Me.CommitTextBox()
        Else
            Me.RollBackTextBox()
        End If
    End Sub

    Private Sub comboBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Me.CommitOnEnter Then
            If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.[Return] Then
                Me.CommitTextBox()
            End If
        End If
    End Sub

#End Region

#Region "Methods"

    ''' <summary>
    ''' Deletes all selected items, after possibly showing a confirmation MessageBox.
    ''' </summary>
    Public Sub DeleteSelectedItems()
        ' Display confirmation MessageBox if required
        Dim canDelete As Boolean = True
        If Me.ConfirmDelete Then
            canDelete = (MessageBox.Show(Me.ConfirmDeleteText, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes)
        End If

        If canDelete Then
            ' Delete all selected items
            While Me.SelectedItems.Count > 0
                Me.Items.Remove(Me.SelectedItem)
            End While
        End If
    End Sub

    Private Sub CommitTextBox()
        If editingIndex > -1 AndAlso editingIndex < Me.Items.Count Then
            Dim item As Object = Me.Items(editingIndex)
            If Not TypeOf item Is String Then
                ' Item is not a string, so let the user handle the change of the text via the ItemEdited event
                Dim e As New EditEventArgs(item, comboBox.SelectedItem.ToString)
                If Me.ItemEditedEvent IsNot Nothing Then
                    RaiseEvent ItemEdited(Me, e)
                    Me.Items(editingIndex) = e.Item
                Else
                    ' User is not handling the event, so it won't work!
                    Throw New Exception("You should handle the ItemEdited event to allow for item editing if the items are not strings.")
                End If
            Else
                ' Item is a string, so we can handle it manually:
                Me.Items(editingIndex) = comboBox.Text
            End If

            comboBox.Visible = False
        End If
    End Sub

    Private Sub RollBackTextBox()
        comboBox.Items.Clear()
        comboBox.Visible = False
    End Sub

#End Region

#Region "Nested Classes"

    Public Class EditEventArgs
        Inherits EventArgs

        Private _Item As Object
        ''' <summary>
        ''' The item that is being edited.
        ''' </summary>
        Public Property Item() As Object
            Get
                Return _Item
            End Get
            Set(ByVal value As Object)
                _Item = value
            End Set
        End Property

        Private _NewText As String
        ''' <summary>
        ''' The text that the user entered as the new item text.
        ''' </summary>
        Public Property NewText() As String
            Get
                Return _NewText
            End Get
            Set(ByVal value As String)
                _NewText = value
            End Set
        End Property

        Public Sub New(ByVal item As Object, ByVal newText As String)
            Me.Item = item
            Me.NewText = newText
        End Sub
    End Class

#End Region

End Class
