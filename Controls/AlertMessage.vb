Imports System.Windows.Forms
Imports System.Drawing
Public Class AlertMessage
    Inherits System.Windows.Forms.Panel

#Region "PropertiesAndVariables"
    Private WithEvents AlertTimer As New System.Windows.Forms.Timer
    Private AlertTimerTick As Integer = 0
    Private MessageSent As Boolean = False
    Private lblMousePosition As New System.Windows.Forms.Label
    Private MessageLength As Integer = 0
    Public Property Message As String = ""
    Public Property MousePoint As Point

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(50, 50)
        End Get
    End Property
#End Region

#Region "AlertMessageMethods"
    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        'set the size
        Size = New Size(Parent.Width - 16, 20)

        'draw outline for toolbag
        Dim rect As Rectangle
        rect = New Rectangle(0, 0, Parent.Size.Width, 19)
        paintEvent.Graphics.DrawRectangle(New Pen(Brushes.White, 3), rect)

        'draw toolbag title
        paintEvent.Graphics.DrawString(Message, New Font("Microsoft Sans Serif", 8.25), Brushes.White, New Point(5, 3))

    End Sub

    Private Sub AlertTimer_Tick(sender As Object, e As EventArgs) Handles AlertTimer.Tick

        If AlertTimerTick = MessageLength Then
            AlertTimerTick = 0
            Message = "PixEdit"
            MessageSent = True
            Me.Refresh()
            AlertTimer.Enabled = False
        Else
            AlertTimerTick += 1
            Select Case AlertTimerTick
                Case 1
                    Me.Refresh()
                Case 100
                    Me.Refresh()
                Case 200
                    Me.Refresh()
                Case 300
                    Me.Refresh()
                Case 400
                    Me.Refresh()
                Case 500
                    Me.Refresh()
            End Select
        End If

    End Sub

    Public Function SendMessage(ByVal msg As String, ByVal time As Integer) As Boolean

        Message = msg
        MessageLength = time
        AlertTimer = New System.Windows.Forms.Timer
        With AlertTimer
            .Interval = 1
            .Enabled = True
        End With
        Return MessageSent
    End Function

    Public Function UpdateMousePosition(ByVal pos As Point) As Boolean
        Try
            lblMousePosition.Text = pos.ToString
            lblMousePosition.Refresh()
        Catch
            Return False
        End Try
        Return True

    End Function

    Public Function InitControls() As Boolean

        Try
            lblMousePosition = New System.Windows.Forms.Label
            With lblMousePosition
                .Location = New Point(200, 3)
                .Text = MousePosition.ToString
                .Size = New Size(lblMousePosition.Size.Width, 15)
                .Font = New Font("Microsoft Sans Serif", 8.25)
                .ForeColor = Color.White
            End With
            Me.Controls.Add(lblMousePosition)

            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.DoubleBuffered = True

        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function
#End Region

End Class
