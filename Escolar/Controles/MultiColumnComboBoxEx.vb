Imports System.ComponentModel
Imports System.Globalization

Namespace CSUST.Data
    <ToolboxItem(True)>
    <ToolboxBitmap(GetType(System.Windows.Forms.ComboBox))>
    Public Class MultiColumnComboBoxEx
        Inherits ComboBox

        Private Const m_minColumnPadding As Integer = 1
        Private Const m_maxColumnPadding As Integer = 100
        Private Const m_leftOffset As Integer = 1
        Private Const m_bottomPadding As Integer = 2
        Private Const WM_LBUTTONDOWN As Integer = &H201
        Private Const WM_LBUTTONDOUBLECLICK As Integer = &H203
        Private Const WM_ADDITEM As Integer = &H143
        Private Const WM_DELETEITEM As Integer = &H144
        Private m_columnNames As List(Of String) = New List(Of String)()
        Private m_columnWidths As Integer() = New Integer(-1) {}
        Private m_maxItemWidth As Integer = 20
        Private m_itemDropDownHeight As Integer = 12
        Private m_maxDropDownHeight As Integer = 12 + m_bottomPadding
        Private m_minDropDownHeight As Integer = 12 + m_bottomPadding
        Private m_columnPadding As Integer = 5
        Private m_displayColumnNames As String = String.Empty
        Private m_textDisplayed As String = String.Empty
        Private m_valueMemberColumnIndex As Integer = -1
        Private m_displayMemberColumnIndex As Integer = -1
        Private m_displayMultiColumnsInBox As Boolean = False
        Private m_displayVerticalLine As Boolean = True
        Private m_gridLinePen As Pen = New Pen(SystemColors.GrayText)
        Private m_foreColorBrush As SolidBrush = New SolidBrush(Color.Black)
        Private m_backColorBrush As SolidBrush = New SolidBrush(Color.White)
        Private m_stringFormat As StringFormat = New StringFormat()
        Private m_version As String = "1.0"

        Public Sub New()
            MyBase.ItemHeight = m_itemDropDownHeight
            MyBase.DropDownWidth = MyBase.Width
            m_maxItemWidth = MyBase.Width
            MyBase.DrawMode = DrawMode.OwnerDrawFixed
            Me.SetDropDownHeight()
            m_stringFormat.LineAlignment = StringAlignment.Center
            m_stringFormat.Alignment = StringAlignment.Near
            m_version = "1.2"
        End Sub

        Private Sub Release()
            m_gridLinePen.Dispose()
            m_foreColorBrush.Dispose()
            m_backColorBrush.Dispose()
            m_stringFormat.Dispose()
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try

                If disposing Then
                    m_columnNames.Clear()
                    m_columnWidths = Nothing
                End If

                Me.Release()
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        <Category("Custom")>
        <DefaultValue(False)>
        <Description("Display multi columns text in box, it is valid when DropDownList.")>
        Public Property DisplayMultiColumnsInBox As Boolean
            Get
                Return m_displayMultiColumnsInBox
            End Get
            Set(ByVal value As Boolean)
                m_displayMultiColumnsInBox = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Custom")>
        <DefaultValue(True)>
        <Description("Display vertical separate line when multi columns.")>
        Public Property DisplayVerticalLine As Boolean
            Get
                Return m_displayVerticalLine
            End Get
            Set(ByVal value As Boolean)
                m_displayVerticalLine = value
                Me.Invalidate()
            End Set
        End Property

        <Category("Custom")>
        <DefaultValue("")>
        <Description("Display column names and orders separated by comma(,) or |, all when empty.")>
        Public Property DisplayColumnNames As String
            Get
                Return m_displayColumnNames
            End Get
            Set(ByVal value As String)

                If String.IsNullOrEmpty(value) = True Then
                    m_displayColumnNames = String.Empty
                Else
                    m_displayColumnNames = value.Trim()
                End If

                If String.IsNullOrEmpty(m_displayColumnNames) = False Then

                    If m_displayColumnNames.EndsWith(",") OrElse m_displayColumnNames.EndsWith("|") OrElse m_displayColumnNames(0) = ","c OrElse m_displayColumnNames(0) = "|"c Then
                        Throw New NotSupportedException("Can not ends/begins with comma(,) or |")
                    End If
                End If

                Me.SetDisplayedColumns()
                Me.SetDisplayMemberColumn()
                Me.SetValueMemberColumn()
                Me.RefreshIMultiColumntems()
            End Set
        End Property

        <Description("Disalble this property.")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Overloads Property ItemHeight As Integer
            Get
                Return MyBase.ItemHeight
            End Get
            Set(ByVal value As Integer)

                If value < 1 Then
                    Throw New ArgumentOutOfRangeException("ItemHeight must be positive number.")
                End If

                MyBase.ItemHeight = value
                Me.SetDropDownHeight()
                Me.RefreshIMultiColumntems()
            End Set
        End Property

        <Category("Custom")>
        <DefaultValue(12)>
        <Description("Height of ComboBox itself, which is used instead of ItemHeight.")>
        Public Property ComboBoxHeight As Integer
            Get
                Return Me.ItemHeight
            End Get
            Set(ByVal value As Integer)
                Me.ItemHeight = value
            End Set
        End Property

        <Category("Custom")>
        <DefaultValue(12)>
        <Description("Item height of dropDown list item.")>
        Public Property ItemDropDownHeight As Integer
            Get
                Return m_itemDropDownHeight
            End Get
            Set(ByVal value As Integer)

                If value < 1 Then
                    Throw New ArgumentOutOfRangeException("ItemHeight must be positive number.")
                End If

                m_itemDropDownHeight = value
                Me.SetDropDownHeight()
                Me.RefreshIMultiColumntems()
            End Set
        End Property

        <Category("Custom")>
        <DefaultValue(5)>
        <Description("Column padding.")>
        Public Property ColumnPadding As Integer
            Get
                Return m_columnPadding
            End Get
            Set(ByVal value As Integer)

                If value < m_minColumnPadding OrElse value > m_maxColumnPadding Then
                    Throw New ArgumentOutOfRangeException("ColumnPadding must between " & m_minColumnPadding.ToString() & " and " & m_maxColumnPadding.ToString())
                End If

                m_columnPadding = value
                Me.RefreshIMultiColumntems()
            End Set
        End Property

        Public Overloads Property MaxDropDownItems As Integer
            Get
                Return MyBase.MaxDropDownItems
            End Get
            Set(ByVal value As Integer)
                MyBase.MaxDropDownItems = value
                Me.SetDropDownHeight()
            End Set
        End Property

        <Category("Custom")>
        <Description("Get the displayed text separated by comma(,) when multi columns shown.")>
        Public ReadOnly Property TextDisplayed As String
            Get
                Return m_textDisplayed
            End Get
        End Property

        <Category("Custom")>
        <Description("version.")>
        Public ReadOnly Property Version As String
            Get
                Return m_version
            End Get
        End Property

        <Description("Disalble this property.")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Overloads ReadOnly Property DrawMode As DrawMode
            Get
                Return MyBase.DrawMode
            End Get
        End Property

        Public Overloads Property DropDownStyle As ComboBoxStyle
            Get
                Return MyBase.DropDownStyle
            End Get
            Set(ByVal value As ComboBoxStyle)

                If value = ComboBoxStyle.Simple Then
                    Throw New NotSupportedException("ComboBoxStyle.Simple is not supported")
                End If

                MyBase.DropDownStyle = value
            End Set
        End Property

        <Description("Disalble this property.")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
        Public Overloads ReadOnly Property IntegralHeight As Boolean
            Get
                Return MyBase.IntegralHeight
            End Get
        End Property

        Private ReadOnly Property TotalDropDownWidth As Integer
            Get

                If Me.Items.Count = 0 Then
                    Return m_maxItemWidth
                End If

                Dim totalWidth As Integer = m_columnPadding

                For k As Integer = 0 To m_columnNames.Count - 1
                    totalWidth += m_columnWidths(k)
                Next

                If Me.Items.Count > MyBase.MaxDropDownItems OrElse MyBase.RightToLeft = RightToLeft.Yes Then
                    totalWidth += SystemInformation.VerticalScrollBarWidth
                End If

                If totalWidth < m_maxItemWidth Then
                    Return m_maxItemWidth
                End If

                Return totalWidth
            End Get
        End Property

        Protected Overrides Sub OnDataSourceChanged(ByVal e As EventArgs)
            MyBase.OnDataSourceChanged(e)
            Me.SetDisplayedColumns()
            Me.SetDisplayMemberColumn()
            Me.SetValueMemberColumn()
            Me.RefreshIMultiColumntems()
            MyBase.Invalidate()
            m_textDisplayed = String.Empty
        End Sub

        Protected Overrides Sub OnValueMemberChanged(ByVal e As EventArgs)
            MyBase.OnValueMemberChanged(e)
            Me.SetValueMemberColumn()
            MyBase.Invalidate()
        End Sub

        Protected Overrides Sub OnDisplayMemberChanged(ByVal e As EventArgs)
            MyBase.OnDisplayMemberChanged(e)
            Me.SetDisplayMemberColumn()
            MyBase.Invalidate()
        End Sub

        Protected Overrides Sub OnDropDown(ByVal e As EventArgs)
            MyBase.OnDropDown(e)

            If MyBase.Focused = False Then
                MyBase.Focus()
            End If

            MyBase.DropDownWidth = Me.TotalDropDownWidth
        End Sub

        Protected Overrides Sub OnForeColorChanged(ByVal e As EventArgs)
            MyBase.OnForeColorChanged(e)
            m_foreColorBrush.Color = MyBase.ForeColor
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
            MyBase.OnBackColorChanged(e)
            m_backColorBrush.Color = MyBase.BackColor
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)
            m_maxItemWidth = MyBase.Width
        End Sub

        Protected Overrides Sub OnRightToLeftChanged(ByVal e As EventArgs)
            MyBase.OnRightToLeftChanged(e)
            Me.RefreshIMultiColumntems()
            Me.Invalidate()
        End Sub

        Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)
            If DesignMode Then
                Return
            End If

            If m_columnNames.Count = 0 Then
                Dim item As String = Convert.ToString(Items(e.Index))
                Dim width As Integer = CInt((e.Graphics.MeasureString(item, MyBase.Font).Width)) + m_columnPadding

                If width > m_maxItemWidth Then
                    m_maxItemWidth = width
                End If
            Else

                For k As Integer = 0 To m_columnNames.Count - 1
                    Dim item As String = Convert.ToString(FilterItemOnProperty(Items(e.Index), m_columnNames(k)))
                    Dim width As Integer = CInt((e.Graphics.MeasureString(item, MyBase.Font).Width))
                    width += m_leftOffset + CInt(m_gridLinePen.Width) + m_columnPadding
                    m_columnWidths(k) = Math.Max(m_columnWidths(k), width)
                Next
            End If

            e.ItemWidth = Me.TotalDropDownWidth
            e.ItemHeight = m_itemDropDownHeight
        End Sub

        Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
            MyBase.OnDrawItem(e)

            If DesignMode Then
                Return
            End If

            If Me.Items.Count = 0 OrElse e.Index = -1 Then
                Return
            End If

            e.DrawBackground()
            Dim fontColorBrush As SolidBrush

            If (e.State And DrawItemState.Selected) <> 0 Then
                fontColorBrush = m_backColorBrush
            Else
                fontColorBrush = m_foreColorBrush
            End If

            If m_columnNames.Count = 0 Then
                m_textDisplayed = Convert.ToString(MyBase.Items(e.Index))
                e.Graphics.DrawString(m_textDisplayed, MyBase.Font, fontColorBrush, e.Bounds, m_stringFormat)
                Return
            End If

            Dim boundRect As Rectangle = e.Bounds

            If (m_displayMultiColumnsInBox = False) AndAlso (e.State And DrawItemState.ComboBoxEdit) <> 0 Then
                m_textDisplayed = String.Empty

                If m_displayMemberColumnIndex <> -1 Then
                    m_textDisplayed = Convert.ToString(FilterItemOnProperty(MyBase.Items(e.Index), m_columnNames(m_displayMemberColumnIndex)))
                End If

                If Me.RightToLeft = RightToLeft.Yes Then
                    m_stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft
                    boundRect.Width += m_leftOffset
                Else
                    m_stringFormat.FormatFlags = 0
                    boundRect.X = m_leftOffset
                End If

                e.Graphics.DrawString(m_textDisplayed, MyBase.Font, fontColorBrush, boundRect, m_stringFormat)
                Return
            End If

            m_textDisplayed = String.Empty
            boundRect.X = 0

            If Me.RightToLeft = RightToLeft.Yes Then
                m_stringFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft

                If (e.State And DrawItemState.ComboBoxEdit) <> 0 Then
                    boundRect.X = SystemInformation.VerticalScrollBarWidth + m_leftOffset
                Else

                    If MyBase.Items.Count < MyBase.MaxDropDownItems Then
                        boundRect.X = SystemInformation.VerticalScrollBarWidth
                    Else
                        boundRect.X = 0
                    End If
                End If

                For k As Integer = m_columnNames.Count - 1 To 0
                    Dim item As String = Convert.ToString(FilterItemOnProperty(MyBase.Items(e.Index), m_columnNames(k)))
                    boundRect.Width = m_columnWidths(k)
                    e.Graphics.DrawString(item, MyBase.Font, fontColorBrush, boundRect, m_stringFormat)

                    If m_displayVerticalLine = True AndAlso (e.State And DrawItemState.ComboBoxEdit) = 0 AndAlso k > 0 Then
                        e.Graphics.DrawLine(m_gridLinePen, boundRect.Right, boundRect.Top, boundRect.Right, boundRect.Bottom)
                    End If

                    m_textDisplayed += item & (If((k > 0), ",", ""))
                    boundRect.X = boundRect.Right
                Next

                Return
            Else

                If (e.State And DrawItemState.ComboBoxEdit) <> 0 Then
                    boundRect.X = m_leftOffset
                End If

                m_stringFormat.FormatFlags = 0
                Dim lastRight As Integer = 0

                For k As Integer = 0 To m_columnNames.Count - 1

                    If lastRight > 0 Then

                        If m_displayVerticalLine = True AndAlso (e.State And DrawItemState.ComboBoxEdit) = 0 Then
                            e.Graphics.DrawLine(m_gridLinePen, boundRect.Right, boundRect.Top, boundRect.Right, boundRect.Bottom)
                        End If

                        boundRect.X = lastRight
                        m_textDisplayed += ","
                    End If

                    Dim item As String = Convert.ToString(FilterItemOnProperty(MyBase.Items(e.Index), m_columnNames(k)))
                    boundRect.Width = m_columnWidths(k)
                    e.Graphics.DrawString(item, MyBase.Font, fontColorBrush, boundRect, m_stringFormat)
                    m_textDisplayed += item
                    lastRight = boundRect.Right + m_leftOffset
                Next
            End If
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = WM_LBUTTONDOWN OrElse m.Msg = WM_LBUTTONDOUBLECLICK Then

                If Me.Items.Count = 0 Then

                    If MyBase.DrawMode <> DrawMode.OwnerDrawFixed Then
                        MyBase.DrawMode = DrawMode.OwnerDrawFixed
                        MyBase.DropDownHeight = m_minDropDownHeight
                        MyBase.IntegralHeight = True
                        MyBase.DroppedDown = True
                    ElseIf MyBase.DropDownHeight <> m_minDropDownHeight Then
                        MyBase.DropDownHeight = m_minDropDownHeight
                        MyBase.IntegralHeight = True
                        MyBase.DroppedDown = True
                    ElseIf MyBase.IntegralHeight = False Then
                        MyBase.IntegralHeight = True
                        MyBase.DroppedDown = True
                    Else
                        MyBase.WndProc(m)
                    End If
                Else

                    If MyBase.DrawMode <> DrawMode.OwnerDrawVariable Then
                        MyBase.DrawMode = DrawMode.OwnerDrawVariable
                        MyBase.IntegralHeight = False
                        MyBase.DroppedDown = True
                    ElseIf MyBase.DropDownHeight <> m_maxDropDownHeight Then
                        MyBase.DropDownHeight = m_maxDropDownHeight
                        MyBase.IntegralHeight = False
                        MyBase.DroppedDown = True
                    ElseIf MyBase.IntegralHeight = True Then
                        MyBase.IntegralHeight = False
                        MyBase.DroppedDown = True
                    Else
                        MyBase.WndProc(m)
                    End If
                End If
            ElseIf m.Msg = WM_ADDITEM AndAlso MyBase.Items.Count = 1 Then

                If MyBase.DropDownHeight <> m_maxDropDownHeight Then
                    MyBase.DropDownHeight = m_maxDropDownHeight
                End If

                MyBase.WndProc(m)
            ElseIf m.Msg = WM_DELETEITEM AndAlso MyBase.Items.Count = 1 Then

                If MyBase.DropDownHeight = m_maxDropDownHeight Then
                    MyBase.DropDownHeight = m_itemDropDownHeight
                End If

                MyBase.WndProc(m)
            Else
                MyBase.WndProc(m)
            End If
        End Sub

        Public Function ItemIndexOf(ByVal itemValue As String, ByVal ignoreCase As Boolean, ByVal columnName As String) As Integer
            If Me.DataSource Is Nothing OrElse m_columnNames.Count = 0 Then
                Return Me.ItemIndexOf(itemValue, ignoreCase)
            Else

                For k As Integer = 0 To MyBase.Items.Count - 1
                    Dim item As String = Convert.ToString(FilterItemOnProperty(MyBase.Items(k), columnName))

                    If String.IsNullOrEmpty(item) = False Then

                        If String.Compare(item, itemValue, ignoreCase, CultureInfo.CurrentUICulture) = 0 Then
                            Return k
                        End If
                    End If
                Next

                Return -1
            End If
        End Function

        Public Function ItemIndexOf(ByVal itemValue As String, ByVal columnName As String) As Integer
            Return Me.ItemIndexOf(itemValue, True, columnName)
        End Function

        Public Function ItemIndexOf(ByVal itemValue As String, ByVal ignoreCase As Boolean) As Integer
            If Me.DataSource Is Nothing OrElse m_columnNames.Count = 0 Then

                For k As Integer = 0 To Me.Items.Count - 1
                    Dim item As String = Convert.ToString(FilterItemOnProperty(MyBase.Items(k)))

                    If String.Compare(item, itemValue, ignoreCase, CultureInfo.CurrentUICulture) = 0 Then
                        Return k
                    End If
                Next

                Return -1
            End If

            If m_displayMemberColumnIndex = -1 Then
                Return -1
            End If

            For k As Integer = 0 To MyBase.Items.Count - 1
                Dim item As String = Convert.ToString(FilterItemOnProperty(MyBase.Items(k), m_columnNames(m_displayMemberColumnIndex)))

                If String.Compare(item, itemValue, ignoreCase, CultureInfo.CurrentUICulture) = 0 Then
                    Return k
                End If
            Next

            Return -1
        End Function

        Public Function ItemIndexOf(ByVal itemValue As String) As Integer
            Return Me.ItemIndexOf(itemValue, True)
        End Function

        Private Sub SetDisplayedColumns()
            m_columnNames.Clear()

            If Me.DataSource Is Nothing OrElse Me.DesignMode Then
                Return
            End If

            Dim propertyDescriptorCollection As PropertyDescriptorCollection = Me.DataManager.GetItemProperties()

            If String.IsNullOrEmpty(m_displayColumnNames) = True Then

                For k As Integer = 0 To propertyDescriptorCollection.Count - 1
                    m_columnNames.Add(propertyDescriptorCollection(k).Name)
                Next
            Else
                Dim delimiterChars As Char() = {"|"c, ","c}
                Dim displayedColumns As String() = m_displayColumnNames.Split(delimiterChars)

                For n As Integer = 0 To displayedColumns.Length - 1

                    For k As Integer = 0 To propertyDescriptorCollection.Count - 1
                        Dim name As String = propertyDescriptorCollection(k).Name

                        If String.Compare(displayedColumns(n).Trim(), name, True, CultureInfo.CurrentUICulture) = 0 Then

                            If m_columnNames.Contains(name) = False Then
                                m_columnNames.Add(name)
                            End If

                            Exit For
                        End If
                    Next
                Next
            End If

            m_columnWidths = New Integer(m_columnNames.Count - 1) {}
        End Sub

        Private Sub SetValueMemberColumn()
            If Me.DesignMode Then
                Return
            End If

            m_valueMemberColumnIndex = -1

            For k As Integer = 0 To m_columnNames.Count - 1

                If String.Compare(m_columnNames(k), MyBase.ValueMember, True, CultureInfo.CurrentUICulture) = 0 Then
                    m_valueMemberColumnIndex = k
                    Exit For
                End If
            Next
        End Sub

        Private Sub SetDisplayMemberColumn()
            If Me.DesignMode Then
                Return
            End If

            m_displayMemberColumnIndex = -1

            For k As Integer = 0 To m_columnNames.Count - 1

                If String.Compare(m_columnNames(k), MyBase.DisplayMember, True, CultureInfo.CurrentUICulture) = 0 Then
                    m_displayMemberColumnIndex = k
                    Exit For
                End If
            Next
        End Sub

        Private Sub RefreshIMultiColumntems()
            If m_columnNames.Count = 0 Then
                Return
            End If

            m_columnWidths = New Integer(m_columnWidths.Length - 1) {}

            If MyBase.DrawMode <> DrawMode.OwnerDrawVariable Then
                MyBase.DrawMode = DrawMode.OwnerDrawVariable
                MyBase.RefreshItems()
                MyBase.DrawMode = DrawMode.OwnerDrawFixed
            Else
                MyBase.RefreshItems()
            End If
        End Sub

        Private Sub SetDropDownHeight()
            m_maxDropDownHeight = MyBase.MaxDropDownItems * m_itemDropDownHeight + m_bottomPadding
            m_minDropDownHeight = m_itemDropDownHeight + m_bottomPadding
            MyBase.DropDownHeight = m_maxDropDownHeight
        End Sub

        Private Sub InitializeComponent()
            Me.SuspendLayout()
            Me.ResumeLayout(False)

        End Sub
    End Class
End Namespace
