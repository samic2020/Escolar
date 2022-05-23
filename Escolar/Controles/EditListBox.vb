Public Class EditListBox
    Inherits ListBox
    Public Sub New()
        Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed

        Me.CommitOnLeave = True
        Me.CommitOnEnter = True
        Me.AllowDelete = True
        Me.ConfirmDelete = True
        Me.ConfirmDeleteText = "Are you sure you want to delete the selected items?"

        ' Create a new TextBox and set some properties
        textBox = New TextBox()
        textBox.Visible = False
        textBox.AcceptsReturn = False
        textBox.AcceptsTab = True
        textBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        textBox.BackColor = Me.BackColor
        textBox.ForeColor = Me.ForeColor
        textBox.Font = Me.Font

        AddHandler textBox.Leave, AddressOf TextBox_Leave
        AddHandler textBox.KeyDown, AddressOf TextBox_KeyDown

        Me.Controls.Add(textBox)
    End Sub

#Region "Private Fields"

    Private textBox As TextBox
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
        textBox.Font = Me.Font
    End Sub

    Protected Overloads Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
        MyBase.OnBackColorChanged(e)

        ' Match the BackColor of the editing TextBox
        textBox.BackColor = Me.BackColor
    End Sub

    Protected Overloads Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
        MyBase.OnForeColorChanged(e)

        ' Match the ForeColor of the editing TextBox
        textBox.ForeColor = Me.ForeColor
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)

        ' Dispose the TextBox
        If disposing Then
            textBox.Dispose()
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
                    textBox.Bounds = itemRect
                    textBox.Visible = True
                    textBox.Text = Me.GetItemText(Me.Items(i))
                    textBox.SelectionStart = 0
                    textBox.SelectionLength = textBox.TextLength
                    textBox.Focus()
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

    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As EventArgs)
        If Me.CommitOnLeave Then
            Me.CommitTextBox()
        Else
            Me.RollBackTextBox()
        End If
    End Sub

    Private Sub TextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
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
                Dim e As New EditEventArgs(item, textBox.Text)
                If Me.ItemEditedEvent IsNot Nothing Then
                    RaiseEvent ItemEdited(Me, e)
                    Me.Items(editingIndex) = e.Item
                Else
                    ' User is not handling the event, so it won't work!
                    Throw New Exception("You should handle the ItemEdited event to allow for item editing if the items are not strings.")
                End If
            Else
                ' Item is a string, so we can handle it manually:
                Me.Items(editingIndex) = textBox.Text
            End If

            textBox.Visible = False
        End If
    End Sub

    Private Sub RollBackTextBox()
        textBox.Clear()
        textBox.Visible = False
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

