Imports System.Windows.Forms
Imports System.Drawing
Public Class Canvas
    Inherits System.Windows.Forms.Button

#Region "PropertiesAndVariables"
    Private Dot As Point
    Private _bolGridlines As Boolean
    Private gfx As Graphics
    Private _hIndex As Integer = 0
    Private _hIndex2 As Integer = 0
    Private _hHighest As Integer = 0

    Public Property Pointer As Bitmap = New Bitmap(Me.size.Width, Me.Size.Height)
    Public Property Canvas As Bitmap = New Bitmap(Me.Size.Width, Me.Size.Height)
    Public Property GridLinesBmp As Bitmap
    Public Property InButton As Boolean
    Public Property HoveringInButton As Boolean
    Public Property BackgroundColor As Color
    Public Property Housing As Panel

    Public History(30) As Bitmap

    Public Property Gridlines As Boolean
        Get
            Return _bolGridlines
        End Get
        Set(value As Boolean)
            _bolGridlines = value
            CreateGridLines(Color.FromArgb(30, Color.Black))
        End Set
    End Property
#End Region

#Region "CanvasMethods"

    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        'paint the canvas first, then the brush's pointer
        paintEvent.Graphics.DrawImage(Canvas, New Point(0, 0))
        paintEvent.Graphics.DrawImage(Pointer, New Point(0, 0))

        'if gridlines are enabled, draw them last
        If Gridlines Then
            paintEvent.Graphics.DrawImage(GridLinesBmp, New Point(0, 0))
        End If

    End Sub

    Public Function InitCanvas(ByVal house As Panel) As Boolean

        'populate the history array
        For i As Integer = 0 To 30
            History(i) = New Bitmap(Me.Size.Width, Me.Size.Height)
        Next

        Try
            Canvas = New Bitmap(Me.Size.Width, Me.Size.Height)
            Pointer = New Bitmap(Me.Size.Width, Me.Size.Height)
            GridLinesBmp = New Bitmap(Me.Size.Width, Me.Size.Height)
            Housing = house

            'clear the canvas and set its color to white (default)
            gfx = Graphics.FromImage(Canvas)
            gfx.Clear(Color.White)

            'create gridlines
            CreateGridLines(Color.Black)

            'add this first bitmap to the history array
            History(0) = New Bitmap(Canvas)

            'set the backgroundcolor property to the color white
            BackgroundColor = Color.White



        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


    Public Function CreateGridLines(ByVal clr As Color) As Boolean
        Try
            'set the graphics object to paint to the gridline image
            gfx = Graphics.FromImage(GridLinesBmp)

            'clear the gridline image
            gfx.Clear(Color.Transparent)

            'draw gridlines
            For x As Integer = 0 To GridLinesBmp.Size.Width Step 8
                For y As Integer = 0 To GridLinesBmp.Size.Height Step 8
                    gfx.DrawRectangle(New Pen(New SolidBrush(clr)), New Rectangle(New Point(x, y), New Size(8, 8)))
                Next
            Next

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function SetBackgroundColor(ByVal clr As Color) As Boolean
        Try
            'set the graphics object to paint to the main canvas
            gfx = Graphics.FromImage(Canvas)
            gfx.Clear(clr)
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function AddToHistory() As Boolean
        Try
            If _hIndex = 30 Then
                _hIndex = 0
                _hHighest = 0
                History(_hIndex) = New Bitmap(Canvas)
            End If

            _hHighest = _hIndex

            _hIndex += 1

            'add the canvas to the history array
            History(_hIndex) = New Bitmap(Canvas)

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function RemoveFromHistory() As Boolean
        Try
            If _hIndex <> 0 Then
                _hIndex2 = _hIndex
                _hIndex -= 1
            End If

            'set the canvas to the previous image
            Canvas = New Bitmap(History(_hIndex))

            Me.Refresh()

        Catch ex As Exception
            Return Nothing
        End Try
        Return True
    End Function

    Public Function RedoFromHistory() As Boolean
        Try
            If _hIndex2 <= _hHighest + 1 Then

                'set the canvas to the next image
                Canvas = New Bitmap(History(_hIndex2))

                Me.Refresh()
                _hIndex = _hIndex2
                _hIndex2 += 1
            End If

        Catch ex As Exception
            Return Nothing
        End Try
        Return True
    End Function

#End Region

End Class