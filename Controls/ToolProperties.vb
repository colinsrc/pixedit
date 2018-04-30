Imports System.Windows.Forms
Imports System.Drawing
Public Class ToolProperties
    Inherits System.Windows.Forms.Panel

#Region "PropertiesAndVariables"
    Private _selectedTool As ToolBagTool
    Private WithEvents _propertiesPanel As System.Windows.Forms.Panel
    Private _strToolName As String = ""

    Public Property ParentToolBag As Toolbag

    Public Property ToolProperties As System.Windows.Forms.Panel
        Get
            Return _propertiesPanel
        End Get
        Set(value As System.Windows.Forms.Panel)
            _propertiesPanel = value
            Me.Refresh()
        End Set
    End Property

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(168, 264)
        End Get
    End Property

#End Region

#Region "ToolPropertiesMethods"

    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        'draw outline for tool properties control
        Dim rects(1) As Rectangle
        rects(0) = New Rectangle(3, 3, Size.Width - 5, Size.Height)
        rects(1) = New Rectangle(3, 23, Size.Width - 5, Size.Height - 25)
        paintEvent.Graphics.DrawRectangles(New Pen(Brushes.White, 2), rects)

        'draw the title for the tool properties control
        paintEvent.Graphics.DrawString(_strToolName + " Properties", New Font("Microsoft Sans Serif", 8.25), Brushes.White, New Point(5, 5))

    End Sub

    Public Function InitToolProperties(ByVal toolbag As Toolbag) As Boolean
        Try
            'set the parent toolbag
            ParentToolBag = toolbag

            'get the tool name
            _strToolName = ParentToolBag.SelectedTool.Name

            'init the properties panel and set its location
            _propertiesPanel = New System.Windows.Forms.Panel
            With _propertiesPanel
                .Location = New Point(4, 24)
                .AutoScroll = True
                .Size = New Size(161, 237)
                .Parent = Me
                .BackColor = SystemColors.ControlDark
            End With

            'add the panel to this panel's control list
            Me.Controls.Add(_propertiesPanel)

            'refresh the parent panel
            Me.Refresh()

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function ResetToolProperties() As Boolean
        Try
            ToolProperties = New Panel
            With ToolProperties
                .Location = New Point(4, 24)
                .AutoScroll = True
                .Size = New Size(161, 237)
                .Parent = Me
                .BackColor = SystemColors.ControlDark
            End With

            Me.Controls.Clear()
            Me.Controls.Add(ToolProperties)

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region

End Class
