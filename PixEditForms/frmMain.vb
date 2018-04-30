Public Class frmMain

#Region "PropertiesAndVariables"
    Public gfx As Graphics
    Private strAlert As String = ""
    Private bolClosed As Boolean = False

    Private WithEvents printer As New PrintDialog
    Private WithEvents document As New Printing.PrintDocument

    'project properties
    Private _name As String
    Private _directory As String
    Private _type As String
    Private _size As Size

#End Region

#Region "frmMain Methods"

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Select Case MessageBox.Show("Are you sure you want to quit before saving?", "Quit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
            Case MsgBoxResult.Yes
                bolClosed = True
            Case MsgBoxResult.No
                Canvas.Canvas.Save(_directory + _name + _type)
                bolClosed = True

            Case MsgBoxResult.Cancel
                e.Cancel = True
        End Select

        'set each tool to be not selected
        For Each tool In Toolbag.Tools
            tool.ToolSelected = False
        Next

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.Images.PixEdit

        Me.DoubleBuffered = True

    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AlertMessage.Refresh()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If InitObjects() = False Then
            MessageBox.Show("Error initializing objects, closing...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
    End Sub

    Public Function InitObjects() As Boolean
        Try
            ' these return booleans
            If ColorPicker.InitColors(PaintBrush, Pencil) _
                AndAlso AlertMessage.InitControls _
                AndAlso Canvas.InitCanvas(CanvasHousing) _
                AndAlso Toolbag.InitTools(Canvas) _
                AndAlso PaintBrush.InitPaintBrush(Me, Canvas, AlertMessage) _
                AndAlso Pencil.InitPencil(Me, Canvas, AlertMessage) _
                AndAlso Eraser.InitEraser(Me, Canvas, AlertMessage) Then
                AlertMessage.SendMessage("Ready to paint.", 200)
            Else
                MessageBox.Show("A fatal error as occurred... :(", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'init the toolproperties control
            ToolProperties.InitToolProperties(Toolbag)
            Toolbag.ToolPropertiesControl = ToolProperties

            'set the default file saving options
            _name = "Default"
            _directory = My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\" + _name + "\"
            _type = ".bmp"

            If My.Computer.FileSystem.DirectoryExists(_directory) Then
                Canvas.Canvas.Save(_directory + _name + _type)
                Me.Text = "New Project: " + _name + "   -   " + _directory
            Else
                My.Computer.FileSystem.CreateDirectory(_directory)
                Canvas.Canvas.Save(_directory + _name + _type)
                Me.Text = "New Project: " + _name + "   -   " + _directory

            End If

        Catch
            Return False
        End Try
        Return True
    End Function

    Public Function NewProject(ByVal name As String, ByVal path As String, type As String, ByVal canvascolor As Color, ByVal canvasSize As Size)
        Try

            'set form vars
            _name = name
            _directory = path + "\"
            _type = type
            _size = canvasSize

            Canvas.Size = _size
            Canvas.Canvas = New Bitmap(_size.Width, _size.Height)
            Canvas.Pointer = New Bitmap(_size.Width, _size.Height)

            Dim quickgfx As Graphics

            quickgfx = Graphics.FromImage(Canvas.Canvas)

            'set the background color for the canvas
            quickgfx.Clear(canvascolor)

            'dispose of the gfx object
            quickgfx.Dispose()

            'set the canvas background color    
            Canvas.BackgroundColor = canvascolor

            'save the first image
            Canvas.Canvas.Save(path + "\" + name + type)

            'set the forms text property to display the project name
            'and path
            Me.Text = "New Project: " + _name + "   -   " + _directory

        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region

#Region "ToolStripItem Methods"

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Canvas.Canvas.Save(_directory + _name + _type)
        Catch
            MessageBox.Show("Error saving image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AlertMessage.SendMessage("Project Saved.", 200)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        frmNew.ShowDialog()
    End Sub

    Private Sub GridToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GridToolStripMenuItem.Click
        Canvas.Gridlines = GridToolStripMenuItem.Checked
        Canvas.Refresh()
    End Sub

    Private Sub UndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UndoToolStripMenuItem.Click
        If Canvas.RemoveFromHistory = False Then
            MessageBox.Show("There was an error undoing your last change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedoToolStripMenuItem.Click
        If Canvas.RedoFromHistory = False Then
            MessageBox.Show("There was an error redoing your last change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        frmSaveAs.SendCanvas(Canvas.Canvas)

        frmSaveAs.ShowDialog()

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim file As New OpenFileDialog

            With file
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\"
                .Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp, *.gif) | *.jpg; *.jpeg; *.png; *.bmp; *.gif"
            End With


            If file.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Canvas.Canvas = New Bitmap(file.OpenFile)

                AlertMessage.SendMessage(file.SafeFileName + " Opened.", 200)
            End If

        Catch
            MessageBox.Show("Error opening file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click

        With printer
            .ShowNetwork = True
            .ShowHelp = True
            .Document = document
        End With

        If printer.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            document.Print()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub


#End Region

#Region "CanvasMethods"

#Region "RequiredCanvasMethods"

    Private Sub btnTest_MouseLeave(sender As Object, e As EventArgs) Handles Canvas.MouseLeave
        Canvas.HoveringInButton = False
    End Sub

    Private Sub btnTest_MouseDown(sender As Object, e As MouseEventArgs) Handles Canvas.MouseDown
        Canvas.InButton = True
        Toolbag.SelectedTool.ButtonDown = e.Button
    End Sub

    Private Sub btnTest_MouseUp(sender As Object, e As MouseEventArgs) Handles Canvas.MouseUp
        Canvas.InButton = False

        'add the last change to the history array
        If Canvas.AddToHistory = False Then
            MessageBox.Show("There was an error while creating a history footprint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnTest_MouseEnter(sender As Object, e As EventArgs) Handles Canvas.MouseEnter
        Canvas.HoveringInButton = True
    End Sub

#End Region

#End Region

#Region "PrintMethods"

    Private Sub document_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles document.PrintPage

        Dim bmp As New Bitmap(Canvas.Canvas)

        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone)

        e.Graphics.DrawImage(bmp, New Point(0, 0))

    End Sub
#End Region

End Class
