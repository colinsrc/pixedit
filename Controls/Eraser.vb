Imports System.Windows.Forms
Imports System.Drawing
Public Class Eraser
    Inherits ToolBagTool

#Region "PropertiesAndVariables"

    Public Property EraserSize As Integer = 1

    Public Property ParentForm As Form

    Public Overrides Property Icon As Bitmap
        Get
            Return My.Resources.Icon.Eraser
        End Get
        Set(value As Bitmap)
            MyBase.Icon = value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return "Eraser"
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Private gfx As Graphics  'used to draw to the canvas object
    Private gfx2 As Graphics 'used to draw the bounding box for eraser
    Public _canvas As Canvas
    Private _mousePosition As Point
    Private _previousmousePosition As Point
    Private _gfxPen As Pen
    Private _bolClicked As Boolean
    Private alertmessage As AlertMessage

    'controls that are put on the panel that is then sent to the ToolPropertiesControl
    Private lblText1 As System.Windows.Forms.Label
    Private WithEvents txtEraserSize As System.Windows.Forms.TextBox
    Private WithEvents tbEraserSize As System.Windows.Forms.TrackBar

#End Region

#Region "EraserMethods"

    Public Function InitEraser(ByVal parentFrm As Form, ByVal cnvs As Canvas, ByVal alrtmsg As AlertMessage) As Boolean
        Try
            'set variables from parameters
            ParentForm = parentFrm
            _canvas = cnvs
            AlertMessage = alrtmsg

            'init gfx objects
            gfx = Graphics.FromImage(_canvas.Canvas)
            gfx2 = Graphics.FromImage(_canvas.Pointer)

            'init eraser object
            _gfxPen = New Pen(New SolidBrush(Color.FromArgb(0, 0, 0)), EraserSize)
            _gfxPen.StartCap = Drawing2D.LineCap.Square
            _gfxPen.EndCap = Drawing2D.LineCap.Square

            'set the cursor image
            CursorImage = My.Resources.Icon.Eraser_png

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

            If ButtonDown = System.Windows.Forms.MouseButtons.Left Then
                _gfxPen = New Pen(New SolidBrush(_canvas.BackgroundColor), EraserSize)
            ElseIf ButtonDown = System.Windows.Forms.MouseButtons.Right Then
                _gfxPen = New Pen(New SolidBrush(_canvas.BackgroundColor), EraserSize)
            End If

            _gfxPen.StartCap = Drawing2D.LineCap.Square
            _gfxPen.EndCap = Drawing2D.LineCap.Square

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
                'reset mouse position for extreme accuracy
                _mousePosition = New Point(((Cursor.Position.X - ParentForm.Location.X) - 20) - _canvas.Housing.AutoScrollPosition.X,
                                       ((Cursor.Position.Y - ParentForm.Location.Y) - 70) - _canvas.Housing.AutoScrollPosition.Y)

                If _bolClicked = False Then
                    'draw a single dot depending on which mousebutton is used
                    If ButtonDown = System.Windows.Forms.MouseButtons.Left Then
                        gfx.FillRectangle(New SolidBrush(_canvas.BackgroundColor), New Rectangle(New Point(_mousePosition.X - EraserSize / 2, _mousePosition.Y - EraserSize / 2),
                                                                             New Size(EraserSize, EraserSize)))
                    ElseIf ButtonDown = System.Windows.Forms.MouseButtons.Right Then
                        gfx.FillRectangle(New SolidBrush(_canvas.BackgroundColor), New Rectangle(New Point(_mousePosition.X - EraserSize / 2, _mousePosition.Y - EraserSize / 2),
                                                     New Size(EraserSize, EraserSize)))
                    End If

                    _bolClicked = True
                End If

                'try to draw line
                Try

                    'if the previous mouse position is 0, 0 , set it to the current mouse position
                    If _previousmousePosition = New Point(0, 0) Then
                        _previousmousePosition = _mousePosition
                    End If

                    'draw square
                    gfx.FillRectangle(New SolidBrush(_canvas.BackgroundColor), New Rectangle(New Point(_mousePosition.X - EraserSize / 2,
                                                                                           _mousePosition.Y - EraserSize / 2),
                                                                   New Size(EraserSize, EraserSize)))


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

            'draw the eraser cursor
            If EraserSize > 1 Then
                gfx2.DrawRectangle(New Pen(New SolidBrush(Drawing.Color.Black)),
                          New Rectangle(New Point(_mousePosition.X - EraserSize / 2,
                                                  _mousePosition.Y - EraserSize / 2),
                            New Size(EraserSize, EraserSize)))
            Else
                gfx2.DrawRectangle(New Pen(New SolidBrush(Color.Black)),
                   New Rectangle(New Point(_mousePosition.X - EraserSize,
                                          _mousePosition.Y - EraserSize),
                                New Size(EraserSize * 2, EraserSize * 2)))

            End If

        End While

        'clear the drawn eraser cursor
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

            'controls for brush size
            lblText1 = New System.Windows.Forms.Label
            With lblText1
                .Text = "Eraser size:"
                .Location = New Point(4, 4)
                .Size = New Size(146, 14)
                .ForeColor = Drawing.Color.White
            End With

            txtEraserSize = New System.Windows.Forms.TextBox
            With txtEraserSize
                .Text = EraserSize.ToString
                .Size = New Size(70, 100)
                .Location = New Point(8, 20)
            End With

            tbEraserSize = New System.Windows.Forms.TrackBar
            With tbEraserSize
                .Size = New Size(70, 70)
                .Location = New Point(80, 20)
                .TickFrequency = 11
                .Value = 1
                .Minimum = 1

            End With

            'add the controls to the panel

            'controls for eraser size
            panel.Controls.Add(lblText1)
            panel.Controls.Add(txtEraserSize)
            panel.Controls.Add(tbEraserSize)

        Catch ex As Exception
            MessageBox.Show("Error creating properties panel, no properties will be displayed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return panel
    End Function


#End Region

#Region "PanelControlMethods"

    Private Sub txtEraserSize_TextChanged(sender As Object, e As EventArgs) Handles txtEraserSize.TextChanged
        If txtEraserSize.Text <> String.Empty Then
            'try to cast the contents of the text box to an integer
            Select Case Integer.TryParse(txtEraserSize.Text, EraserSize)
                Case True
                    EraserSize = CInt(txtEraserSize.Text)
                Case False
                    MessageBox.Show("Please enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
        End If
    End Sub

    Private Sub tbEraserSize_ValueChanged(sender As Object, e As EventArgs) Handles tbEraserSize.ValueChanged
        txtEraserSize.Text = tbEraserSize.Value * 10
    End Sub

#End Region

End Class
