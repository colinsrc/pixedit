Imports System.Windows.Forms
Imports System.Drawing
Public Class Pencil
    Inherits ToolBagTool

#Region "PropertiesAndVariables"
    'this property is static, it will not change
    Public Property PencilSize As Integer = 1

    Public Property Color As Color

    Public Overrides Property Text As String
        Get
            Return "Pencil"
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Public Property ParentForm As Form

    Public Overrides Property Icon As Bitmap
        Get
            Return My.Resources.Icon.Pencil
        End Get
        Set(value As Bitmap)
            MyBase.Icon = value
        End Set
    End Property

    Private gfx As Graphics  'used to draw to the canvas object
    Private gfx2 As Graphics 'used to draw the bounding box for pencil
    Public _canvas As Canvas
    Private _mousePosition As Point
    Private _previousmousePosition As Point
    Private _gfxPen As Pen
    Private _bolClicked As Boolean
    Private alertmessage As AlertMessage

    'controls that are put on the panel that is then sent to the ToolPropertiesControl
    Private lblText1 As System.Windows.Forms.Label

#End Region

#Region "PencilMethods"
    Public Function InitPencil(ByVal parentFrm As Form, ByVal cnvs As Canvas, ByVal alrtmsg As AlertMessage) As Boolean
        Try
            'set variables from parameters
            ParentForm = parentFrm
            _canvas = cnvs
            alertmessage = alrtmsg

            'init gfx objects
            gfx = Graphics.FromImage(_canvas.Canvas)
            gfx2 = Graphics.FromImage(_canvas.Pointer)

            'init pen object
            _gfxPen = New Pen(New SolidBrush(Color), PencilSize)
            _gfxPen.StartCap = Drawing2D.LineCap.Round
            _gfxPen.DashCap = Drawing2D.DashCap.Round
            _gfxPen.EndCap = Drawing2D.LineCap.Round

            'set the cursor image
            CursorImage = My.Resources.Icon.Pencil_png


        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overrides Sub Main()
        While ToolSelected
            'set the boolean that determines if a click was done already to false
            _bolClicked = False

            'these calls are neccessary for the application to run without freezing
            Application.DoEvents()
            _canvas.Refresh()

            'reset the pen so changes take effect
            _gfxPen = New Pen(New SolidBrush(Color), PencilSize)
            _gfxPen.StartCap = Drawing2D.LineCap.Round
            _gfxPen.DashCap = Drawing2D.DashCap.Round
            _gfxPen.EndCap = Drawing2D.LineCap.Round

            're-init the gfx object incase a new canvase is made
            gfx = Graphics.FromImage(_canvas.Canvas)
            gfx2 = Graphics.FromImage(_canvas.Pointer)

            'clear the drawn brush cursor each time the outer loop executes
            gfx2.Clear(Drawing.Color.Transparent)

            'set the variable that holds mouse position
            _mousePosition = New Point(((Cursor.Position.X - ParentForm.Location.X) - 20) - _canvas.Housing.AutoScrollPosition.X,
                                       ((Cursor.Position.Y - ParentForm.Location.Y) - 70) - _canvas.Housing.AutoScrollPosition.Y)

            'update mouse position
            alertmessage.UpdateMousePosition(_mousePosition)

            'inner loop
            While _canvas.InButton
                'reset the mouse position for extreme accuracy
                _mousePosition = New Point(((Cursor.Position.X - ParentForm.Location.X) - 20) - _canvas.Housing.AutoScrollPosition.X,
                                       ((Cursor.Position.Y - ParentForm.Location.Y) - 70) - _canvas.Housing.AutoScrollPosition.Y)

                If _bolClicked = False Then
                    'draw a single dot
                    _canvas.Canvas.SetPixel(_mousePosition.X, _mousePosition.Y, Color)
                    _bolClicked = True
                End If

                'try to draw line
                Try

                    'if the previous mouse position is 0, 0 , set it to the current mouse position
                    If _previousmousePosition = New Point(0, 0) Then
                        _previousmousePosition = _mousePosition
                    End If

                    'draw line
                    gfx.DrawLine(_gfxPen, _previousmousePosition, _mousePosition)

                    'resume application calls
                    Application.DoEvents()

                    'refresh the canvase object
                    _canvas.Refresh()
                Catch ex As Exception
                    Select Case MsgBox("There was an error", MsgBoxStyle.Critical, "Error")
                        Case MsgBoxResult.Ok
                            ParentForm.Close()
                    End Select
                End Try

                'set previous mouse position to current mouse position
                _previousmousePosition = _mousePosition

            End While

            'set previous mouse position to current mouse position
            _previousmousePosition = _mousePosition

            'draw the brush cursor
            gfx2.DrawRectangle(New Pen(New SolidBrush(Color.Black)),
               New Rectangle(New Point(_mousePosition.X - PencilSize,
                                      _mousePosition.Y - PencilSize),
                            New Size(PencilSize * 2, PencilSize * 2)))
        End While

        'clear the drawn brush cursor
        gfx2.Clear(Drawing.Color.Transparent)

        'refresh the canvas for changes to take effect
        _canvas.Refresh()
    End Sub

    Public Overrides Function GetProperties(ByVal parentPanel As System.Windows.Forms.Panel) As System.Windows.Forms.Panel
        'this function returns a panel containing controls that are used to change
        'properties of this tool
        Dim panel As New System.Windows.Forms.Panel

        Try
            'set the panel properties
            With panel
                .AutoScroll = True
                .Size = New Size(161, 237)
                .Parent = parentPanel
                .BackColor = SystemColors.ControlDark
            End With

            'create controls
            lblText1 = New Label
            With lblText1
                .Text = "No properties found."
                .Location = New Point(4, 4)
                .Size = New Size(146, 23)
                .ForeColor = Drawing.Color.White
            End With

            'add the controls to the panel
            panel.Controls.Add(lblText1)

        Catch ex As Exception
            MessageBox.Show("Error creating properties panel, no properties will be displayed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return panel
    End Function

#End Region

End Class