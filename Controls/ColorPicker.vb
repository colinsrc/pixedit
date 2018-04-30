Imports System.Windows.Forms
Imports System.Drawing
Public Class ColorPicker
    Inherits System.Windows.Forms.Panel
#Region "PropertiesAndVariables"
    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(355, 100)
        End Get
    End Property

    Public Property SelectedPrimaryColor As Color
        Get
            Return _selectedPrimaryColor
        End Get
        Set(value As Color)
            _selectedPrimaryColor = value

            If ParentBrush IsNot Nothing Then
                'set the brushes primary color
                ParentBrush.PrimaryColor = _selectedPrimaryColor
                Me.Refresh()
            End If
        End Set
    End Property

    Public Property SelectedSecondaryColor As Color
        Get
            Return _selectedSecondaryColor
        End Get
        Set(value As Color)
            _selectedSecondaryColor = value

            If ParentBrush IsNot Nothing Then
                'set the brushes secondary color
                ParentBrush.SecondaryColor = _selectedSecondaryColor
                Me.Refresh()
            End If
        End Set
    End Property

    Public ReadOnly Property DefaultPrimaryColor As Color
        Get
            Return Color.Black
        End Get
    End Property

    Public ReadOnly Property DefaultSecondaryColor As Color
        Get
            Return Color.White
        End Get
    End Property

    Private Colors(15) As ColorPickerColor
    Private _selectedPrimaryColor As Color
    Private _selectedSecondaryColor As Color
    Private MoreColors As ColorDialog
    Private WithEvents MoreColorsButton As System.Windows.Forms.Button
    Private ParentBrush As PaintBrush
    Private ParentPencil As Pencil
    Private _init As Boolean = False

#End Region

#Region "ColorPickerMethods"
    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        'draw outline for colorpicker
        Dim rects(1) As Rectangle
        rects(0) = New Rectangle(3, 3, Size.Width - 5, Size.Height)
        rects(1) = New Rectangle(3, 23, Size.Width - 5, Size.Height - 25)
        paintEvent.Graphics.DrawRectangles(New Pen(Brushes.White, 2), rects)

        'draw toolbag title
        paintEvent.Graphics.DrawString("Color Picker", New Font("Microsoft Sans Serif", 8.25), Brushes.White, New Point(5, 5))

        If _init = True Then
            'draw the colors selected as filled rectangles
            paintEvent.Graphics.DrawRectangle(Pens.White, New Rectangle(New Point(304, 34), New Size(30, 30)))
            paintEvent.Graphics.FillRectangle(New SolidBrush(ParentBrush.SecondaryColor), New Rectangle(New Point(305, 35), New Size(29, 29)))
            paintEvent.Graphics.DrawRectangle(Pens.white, New Rectangle(New Point(299, 29), New Size(30, 30)))
            paintEvent.Graphics.FillRectangle(New SolidBrush(ParentBrush.PrimaryColor), New Rectangle(New Point(300, 30), New Size(29, 29)))
        End If

    End Sub

    Public Function InitColors(ByVal brush As PaintBrush, ByVal pencil As Pencil) As Boolean
        Try
            'setup colorpickercolor objects
            For intSub As Integer = 0 To 15

                Colors(intSub) = New ColorPickerColor
                Colors(intSub).Location = New Point(8 + (intSub * Colors(intSub).Size.Width), 28)
                Colors(intSub).ColorPickerParent = Me
                Controls.Add(Colors(intSub))
            Next

            'set their respective colors
            Colors(0).Color = Color.Red
            Colors(1).Color = Color.Blue
            Colors(2).Color = Color.Green
            Colors(3).Color = Color.Yellow
            Colors(4).Color = Color.Orange
            Colors(5).Color = Color.Indigo
            Colors(6).Color = Color.Violet
            Colors(7).Color = Color.Brown
            Colors(8).Color = Color.Pink
            Colors(9).Color = Color.Black
            Colors(10).Color = Color.White
            Colors(11).Color = Color.DarkGray
            Colors(12).Color = Color.DarkOrange
            Colors(13).Color = Color.SaddleBrown
            Colors(14).Color = Color.DarkBlue
            Colors(15).Color = Color.DarkCyan

            'set their tooltips
            For intSub As Integer = 0 To 15
                Colors(intSub).ToolTip = New ToolTip
                Colors(intSub).ToolTip.SetToolTip(Colors(intSub), Colors(intSub).Color.ToString)
            Next

            'init the colordialog button
            MoreColorsButton = New System.Windows.Forms.Button
            With MoreColorsButton
                .Size = Colors(0).Size
                .Text = "..."
                .Location = New Point(Colors(15).Location.X + MoreColorsButton.Size.Width, Colors(15).Location.Y)
            End With
            Controls.Add(MoreColorsButton)

            'init settings controls for brush
            ParentBrush = brush
            ParentBrush.BrushSize = 1
            ParentBrush.PrimaryColor = Colors(9).Color
            ParentBrush.SecondaryColor = Colors(10).Color


        Catch
            Return False
        End Try

        'init settings for pencil
        ParentPencil = pencil
        ParentPencil.PencilSize = 1
        ParentPencil.Color = Colors(9).Color

        'refresh the control
        _init = True
        Me.Refresh()

        Return True
    End Function

    Private Sub MoreColorsButton_MouseDown(sender As Object, e As MouseEventArgs) Handles MoreColorsButton.MouseDown
        'open the color dialog
        MoreColors = New ColorDialog()
        MoreColors.ShowHelp = True
        MoreColors.ShowDialog()

        'set colors accordingly
        Select Case e.Button
            Case System.Windows.Forms.MouseButtons.Left
                SelectedPrimaryColor = MoreColors.Color
            Case System.Windows.Forms.MouseButtons.Right
                SelectedSecondaryColor = MoreColors.Color
        End Select
    End Sub

#End Region

End Class
