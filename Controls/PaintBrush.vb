Imports System.Windows.Forms
Imports System.Drawing
Public Class PaintBrush
    Inherits ToolBagTool

#Region "PropertiesAndVariables"
    Public Property BrushSize As Integer = 1

    'shoutout to nick for this idea (thanks dude)
    Public Property BrushOpacity As Integer = 255

    Public Property PrimaryColor As Color
    Public Property SecondaryColor As Color

    Public Overrides Property Text As String
        Get
            Return "Paint Brush"
        End Get
        Set(value As String)
            MyBase.Text = value
        End Set
    End Property

    Public Property ParentForm As Form

    Public Overrides Property Icon As Bitmap
        Get
            Return My.Resources.Icon.Paintbrush
        End Get
        Set(value As Bitmap)
            MyBase.Icon = value
        End Set
    End Property

    Private gfx As Graphics  'used to draw to the canvas object
    Private gfx2 As Graphics 'used to draw the bounding box for brush
    Public _canvas As Canvas
    Private _mousePosition As Point
    Private _previousmousePosition As Point
    Private _gfxPen As Pen
    Private _bolClicked As Boolean
    Private alertmessage As AlertMessage

    'controls that are put on the panel that is then sent to the ToolPropertiesControl
    Private lblText1 As System.Windows.Forms.Label
    Private WithEvents txtBrushSize As System.Windows.Forms.TextBox
    Private lblText2 As System.Windows.Forms.Label
    Private WithEvents txtBrushOpacity As System.Windows.Forms.TextBox
    Private lblText3 As System.Windows.Forms.Label
    Private WithEvents tbBrushSize As System.Windows.Forms.TrackBar
    Private WithEvents tbBrushOpacity As System.Windows.Forms.TrackBar
#End Region

#Region "PaintBrushMethods"
    Public Function InitPaintBrush(ByVal parentFrm As Form, ByVal cnvs As Canvas, ByVal alrtmsg As AlertMessage) As Boolean
        Try
            'set variables from parameters
            ParentForm = parentFrm
            _canvas = cnvs
            alertmessage = alrtmsg

            'init gfx objects
            gfx = Graphics.FromImage(_canvas.Canvas)
            gfx2 = Graphics.FromImage(_canvas.Pointer)

            'init pen object
            _gfxPen = New Pen(New SolidBrush(Color.FromArgb(BrushOpacity, PrimaryColor.R, PrimaryColor.G, PrimaryColor.B)), BrushSize)
            _gfxPen.StartCap = Drawing2D.LineCap.Round
            _gfxPen.DashCap = Drawing2D.DashCap.Round
            _gfxPen.EndCap = Drawing2D.LineCap.Round

            'set the cursor image
            CursorImage = My.Resources.Icon.Paintbrush_png

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
                _gfxPen = New Pen(New SolidBrush(Color.FromArgb(BrushOpacity, PrimaryColor.R, PrimaryColor.G, PrimaryColor.B)), BrushSize)
            ElseIf ButtonDown = System.Windows.Forms.MouseButtons.Right Then
                _gfxPen = New Pen(New SolidBrush(Color.FromArgb(BrushOpacity, SecondaryColor.R, SecondaryColor.G, SecondaryColor.B)), BrushSize)
            End If

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
                'reset mouse position for extreme accuracy
                _mousePosition = New Point(((Cursor.Position.X - ParentForm.Location.X) - 20) - _canvas.Housing.AutoScrollPosition.X,
                                           ((Cursor.Position.Y - ParentForm.Location.Y) - 70) - _canvas.Housing.AutoScrollPosition.Y)

                If _bolClicked = False Then
                    'draw a single dot depending on which mousebutton is used
                    If ButtonDown = System.Windows.Forms.MouseButtons.Left Then
                        gfx.FillEllipse(New SolidBrush(Color.FromArgb(BrushOpacity, PrimaryColor.R, PrimaryColor.G, PrimaryColor.B)), New Rectangle(New Point(_mousePosition.X - BrushSize / 2, _mousePosition.Y - BrushSize / 2),
                                                                             New Size(BrushSize, BrushSize)))
                    ElseIf ButtonDown = System.Windows.Forms.MouseButtons.Right Then
                        gfx.FillEllipse(New SolidBrush(Color.FromArgb(BrushOpacity, SecondaryColor.R, SecondaryColor.G, SecondaryColor.B)), New Rectangle(New Point(_mousePosition.X - BrushSize / 2, _mousePosition.Y - BrushSize / 2),
                                                     New Size(BrushSize, BrushSize)))
                    End If

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
            If BrushSize > 1 Then
                gfx2.DrawEllipse(New Pen(New SolidBrush(Drawing.Color.Black)),
                          New Rectangle(New Point(_mousePosition.X - BrushSize / 2,
                                                  _mousePosition.Y - BrushSize / 2),
                            New Size(BrushSize, BrushSize)))
            Else
                gfx2.DrawRectangle(New Pen(New SolidBrush(Color.Black)),
                   New Rectangle(New Point(_mousePosition.X - BrushSize,
                                          _mousePosition.Y - BrushSize),
                                New Size(BrushSize * 2, BrushSize * 2)))

            End If

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

            'controls for brush size
            lblText1 = New System.Windows.Forms.Label
            With lblText1
                .Text = "Brush size:"
                .Location = New Point(4, 4)
                .Size = New Size(146, 14)
                .ForeColor = Drawing.Color.White
            End With

            txtBrushSize = New System.Windows.Forms.TextBox
            With txtBrushSize
                .Text = BrushSize.ToString
                .Size = New Size(70, 100)
                .Location = New Point(8, 20)
            End With

            tbBrushSize = New System.Windows.Forms.TrackBar
            With tbBrushSize
                .Size = New Size(70, 70)
                .Location = New Point(80, 20)
                .TickFrequency = 1
                .Value = 1
                .Minimum = 1
            End With


            'controls for brush opacity
            lblText2 = New System.Windows.Forms.Label
            With lblText2
                .Text = "Brush opacity:"
                .Location = New Point(4, 40)
                .Size = New Size(146, 14)
                .ForeColor = Drawing.Color.White
            End With

            txtBrushOpacity = New System.Windows.Forms.TextBox
            With txtBrushOpacity
                .Text = BrushOpacity.ToString
                .Size = New Size(70, 100)
                .Location = New Point(8, 58)
            End With

            lblText3 = New System.Windows.Forms.Label
            With lblText3
                .Text = "*Please note: Opacity will" & vbNewLine &
                        "cause oddly shaded lines.*"
                .ForeColor = SystemColors.ControlLightLight
                .Size = New Size(200, 30)
                .Location = New Point(4, 80)
            End With

            tbBrushOpacity = New System.Windows.Forms.TrackBar
            With tbBrushOpacity
                .Size = New Size(70, 70)
                .Location = New Point(80, 58)
                .TickFrequency = 1
                .Minimum = 1S
                .Maximum = 255
                .Value = BrushOpacity
            End With

            'add the controls to the panel

            'controls for brush size
            panel.Controls.Add(lblText1)
            panel.Controls.Add(txtBrushSize)
            panel.Controls.Add(tbBrushSize)

            'controls for brush opacity
            panel.Controls.Add(lblText2)
            panel.Controls.Add(txtBrushOpacity)
            panel.Controls.Add(lblText3)
            panel.Controls.Add(tbBrushOpacity)

        Catch ex As Exception
            MessageBox.Show("Error creating properties panel, no properties will be displayed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return panel
    End Function

#End Region


#Region "PanelControlMethods"

    Private Sub txtBrushSize_TextChanged(sender As Object, e As EventArgs) Handles txtBrushSize.TextChanged
        If txtBrushSize.Text <> String.Empty Then
            'try to cast the contents of the text box to an integer
            Select Case Integer.TryParse(txtBrushSize.Text, BrushSize)
                Case True
                    BrushSize = CInt(txtBrushSize.Text)
                Case False
                    MessageBox.Show("Please enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
        End If
    End Sub

    Private Sub txtBrushOpacity_TextChanged(sender As Object, e As EventArgs) Handles txtBrushOpacity.TextChanged
        If txtBrushOpacity.Text <> String.Empty Then
            'try to cast the contents of the text box to an integer
            Select Case Integer.TryParse(txtBrushOpacity.Text, BrushOpacity)
                Case True
                    BrushOpacity = CInt(txtBrushOpacity.Text)
                Case False
                    MessageBox.Show("Please enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
        End If
    End Sub

    Private Sub tbBrushSize_ValueChanged(sender As Object, e As EventArgs) Handles tbBrushSize.ValueChanged
        txtBrushSize.Text = tbBrushSize.Value * 10
    End Sub

    Private Sub tbBrushOpacity_ValueChanged(sender As Object, e As EventArgs) Handles tbBrushOpacity.ValueChanged
        txtBrushOpacity.Text = tbBrushOpacity.Value
    End Sub

#End Region

End Class
