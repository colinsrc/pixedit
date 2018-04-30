Imports System.Windows.Forms
Imports System.Drawing
Public Class Toolbag
    Inherits System.Windows.Forms.Panel
#Region "PropertiesAndVariables"
    Public Tools As List(Of ToolBagTool)
    Public Property SelectedTool As ToolBagTool

    Public Property ToolPropertiesControl As ToolProperties

    Public Property FriendCanvas As Canvas

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(168, 423)
        End Get
    End Property

    Private _strTitle As String = "ToolBag"

#End Region

#Region "ToolbagMethods"
    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        'draw outline for toolbag
        Dim rects(1) As Rectangle
        rects(0) = New Rectangle(3, 3, Size.Width - 5, Size.Height)
        rects(1) = New Rectangle(3, 23, Size.Width - 5, Size.Height - 25)
        paintEvent.Graphics.DrawRectangles(New Pen(Brushes.White, 2), rects)

        'draw toolbag title
        paintEvent.Graphics.DrawString(_strTitle, New Font("Microsoft Sans Serif", 8.25), Brushes.White, New Point(5, 5))

    End Sub

    Public Function InitTools(ByVal canvas As Canvas) As Boolean
        'add all controls from inside the tool bag to the ToolBagTool list
        Try
            Tools = New List(Of ToolBagTool)
            For Each tool In Controls
                Tools.Add(CType(tool, ToolBagTool))
            Next
        Catch
            Return False
        End Try

        'set each tool's parent to the toolbag
        Try
            For Each tool In Tools
                tool.ParentToolBag = Me
            Next
        Catch ex As Exception
            Return False
        End Try

        'for fun, set a different name to the tool bag each time the program starts
        Dim a As New Random
        Dim abc As Integer = a.Next(1, 16)


        Select Case abc
            Case 1
                _strTitle = "Tool Bag"
            Case 2
                _strTitle = "Tool Shed"
            Case 3
                _strTitle = "Tool Drawer"
            Case 4
                _strTitle = "Tool Box"
            Case 5
                _strTitle = "Tool Pouch"
            Case 6
                _strTitle = "Tool Pack"
            Case 7
                _strTitle = "Tool Sash"
            Case 8
                _strTitle = "Tool Chest"
            Case 9
                _strTitle = "Tool Cubby"
            Case 10
                _strTitle = "Tool Tray"
            Case 11
                _strTitle = "Tool Array"
            Case 12
                _strTitle = "Tool Crib"
            Case 13
                _strTitle = "Tool Caddy"
            Case 14
                _strTitle = "Tool Set"
            Case 15
                _strTitle = "Tool Trunk"
            Case 16
                _strTitle = "Tool Basket"
        End Select

        'set the SelectedTool object to something
        SelectedTool = New ToolBagTool

        'set the friendcanvas property
        FriendCanvas = canvas

        Return True
    End Function

    Public Sub SelectTool(ByVal tooltoselect As ToolBagTool)

        For i As Integer = 0 To Tools.Count - 1
            If Tools(i) IsNot tooltoselect Then
                Tools(i).ToolSelected = False
                Tools(i).BackColor = SystemColors.Control
            End If
        Next

    End Sub
#End Region

End Class
