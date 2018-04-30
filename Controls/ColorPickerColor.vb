Imports System.Windows.Forms
Imports System.Drawing
Public Class ColorPickerColor
    Inherits System.Windows.Forms.Button
#Region "PropertiesAndVariables"
    Public Property Color As Color
    Public Property ColorPickerParent As ColorPicker
    Public Property ToolTip As ToolTip

    Public Overrides Property Text As String
        Get
            Return Nothing
        End Get
        Set(value As String)
            MyBase.Text = Nothing
        End Set
    End Property

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(15, 14)
        End Get
    End Property
#End Region

#Region "ColorPickerColorMethods"
    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)
        'draw the color defined in the colorpicker parent and an encapsulating box
        paintEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(New Point(0, 0), New Size(Size.Width - 1, Size.Height - 1)))
        paintEvent.Graphics.FillRectangle(New SolidBrush(Color), New Rectangle(New Point(1, 1), New Size(Size.Width - 2, Size.Height - 2)))
    End Sub

    Private Sub ColorPickerColor_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Select Case e.Button
            Case System.Windows.Forms.MouseButtons.Left
                ColorPickerParent.SelectedPrimaryColor = Color
            Case System.Windows.Forms.MouseButtons.Right
                ColorPickerParent.SelectedSecondaryColor = Color

        End Select
    End Sub

#End Region
End Class
