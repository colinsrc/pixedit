<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CanvasHousing = New System.Windows.Forms.Panel()
        Me.Canvas = New Controls.Canvas()
        Me.ToolProperties = New Controls.ToolProperties()
        Me.AlertMessage = New Controls.AlertMessage()
        Me.ColorPicker = New Controls.ColorPicker()
        Me.Toolbag = New Controls.Toolbag()
        Me.Eraser = New Controls.Eraser()
        Me.Pencil = New Controls.Pencil()
        Me.PaintBrush = New Controls.PaintBrush()
        Me.MenuStrip1.SuspendLayout()
        Me.CanvasHousing.SuspendLayout()
        Me.Toolbag.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1146, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripSeparator2, Me.PrintToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoNew
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoOpen
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(190, 6)
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoSave
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoSave
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save as..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(190, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoPrint
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(190, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoClose
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoUndo
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoRedo
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(144, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GridToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'GridToolStripMenuItem
        '
        Me.GridToolStripMenuItem.CheckOnClick = True
        Me.GridToolStripMenuItem.Image = CType(resources.GetObject("GridToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GridToolStripMenuItem.Name = "GridToolStripMenuItem"
        Me.GridToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.GridToolStripMenuItem.Text = "Grid"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.PixEdit.My.Resources.Images.icoPixEdit
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'CanvasHousing
        '
        Me.CanvasHousing.AutoScroll = True
        Me.CanvasHousing.Controls.Add(Me.Canvas)
        Me.CanvasHousing.Location = New System.Drawing.Point(11, 38)
        Me.CanvasHousing.Name = "CanvasHousing"
        Me.CanvasHousing.Size = New System.Drawing.Size(953, 477)
        Me.CanvasHousing.TabIndex = 8
        '
        'Canvas
        '
        Me.Canvas.BackgroundColor = System.Drawing.Color.Empty
        Me.Canvas.Canvas = CType(resources.GetObject("Canvas.Canvas"), System.Drawing.Bitmap)
        Me.Canvas.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Canvas.Gridlines = False
        Me.Canvas.GridLinesBmp = Nothing
        Me.Canvas.Housing = Nothing
        Me.Canvas.HoveringInButton = False
        Me.Canvas.InButton = False
        Me.Canvas.Location = New System.Drawing.Point(1, 1)
        Me.Canvas.Name = "Canvas"
        Me.Canvas.Pointer = CType(resources.GetObject("Canvas.Pointer"), System.Drawing.Bitmap)
        Me.Canvas.Size = New System.Drawing.Size(952, 476)
        Me.Canvas.TabIndex = 0
        Me.Canvas.Text = "Button1"
        Me.Canvas.UseVisualStyleBackColor = True
        '
        'ToolProperties
        '
        Me.ToolProperties.BackColor = System.Drawing.Color.Gray
        Me.ToolProperties.Location = New System.Drawing.Point(970, 468)
        Me.ToolProperties.Name = "ToolProperties"
        Me.ToolProperties.ParentToolBag = Nothing
        Me.ToolProperties.Size = New System.Drawing.Size(168, 171)
        Me.ToolProperties.TabIndex = 7
        Me.ToolProperties.ToolProperties = Nothing
        '
        'AlertMessage
        '
        Me.AlertMessage.BackColor = System.Drawing.Color.Gray
        Me.AlertMessage.Location = New System.Drawing.Point(0, 644)
        Me.AlertMessage.Message = "PixEdit"
        Me.AlertMessage.MousePoint = New System.Drawing.Point(0, 0)
        Me.AlertMessage.Name = "AlertMessage"
        Me.AlertMessage.Size = New System.Drawing.Size(1146, 20)
        Me.AlertMessage.TabIndex = 4
        '
        'ColorPicker
        '
        Me.ColorPicker.BackColor = System.Drawing.Color.Gray
        Me.ColorPicker.Location = New System.Drawing.Point(12, 521)
        Me.ColorPicker.Name = "ColorPicker"
        Me.ColorPicker.SelectedPrimaryColor = System.Drawing.Color.Empty
        Me.ColorPicker.SelectedSecondaryColor = System.Drawing.Color.Empty
        Me.ColorPicker.Size = New System.Drawing.Size(355, 100)
        Me.ColorPicker.TabIndex = 2
        '
        'Toolbag
        '
        Me.Toolbag.BackColor = System.Drawing.Color.Gray
        Me.Toolbag.Controls.Add(Me.Eraser)
        Me.Toolbag.Controls.Add(Me.Pencil)
        Me.Toolbag.Controls.Add(Me.PaintBrush)
        Me.Toolbag.FriendCanvas = Nothing
        Me.Toolbag.Location = New System.Drawing.Point(970, 38)
        Me.Toolbag.Name = "Toolbag"
        Me.Toolbag.SelectedTool = Nothing
        Me.Toolbag.Size = New System.Drawing.Size(168, 423)
        Me.Toolbag.TabIndex = 1
        Me.Toolbag.ToolPropertiesControl = Nothing
        '
        'Eraser
        '
        Me.Eraser.ButtonDown = System.Windows.Forms.MouseButtons.None
        Me.Eraser.CursorImage = Nothing
        Me.Eraser.EraserSize = 1
        Me.Eraser.Icon = CType(resources.GetObject("Eraser.Icon"), System.Drawing.Bitmap)
        Me.Eraser.Location = New System.Drawing.Point(5, 97)
        Me.Eraser.Name = "Eraser"
        Me.Eraser.ParentForm = Nothing
        Me.Eraser.ParentToolBag = Nothing
        Me.Eraser.Size = New System.Drawing.Size(160, 36)
        Me.Eraser.TabIndex = 2
        Me.Eraser.Text = "Eraser"
        Me.Eraser.ToolSelected = False
        '
        'Pencil
        '
        Me.Pencil.ButtonDown = System.Windows.Forms.MouseButtons.None
        Me.Pencil.Color = System.Drawing.Color.Empty
        Me.Pencil.CursorImage = Nothing
        Me.Pencil.Icon = CType(resources.GetObject("Pencil.Icon"), System.Drawing.Bitmap)
        Me.Pencil.Image = CType(resources.GetObject("Pencil.Image"), System.Drawing.Image)
        Me.Pencil.Location = New System.Drawing.Point(5, 61)
        Me.Pencil.Name = "Pencil"
        Me.Pencil.ParentForm = Nothing
        Me.Pencil.ParentToolBag = Nothing
        Me.Pencil.PencilSize = 1
        Me.Pencil.Size = New System.Drawing.Size(160, 36)
        Me.Pencil.TabIndex = 1
        Me.Pencil.Text = "Pencil"
        Me.Pencil.ToolSelected = False
        '
        'PaintBrush
        '
        Me.PaintBrush.BrushOpacity = 255
        Me.PaintBrush.BrushSize = 1
        Me.PaintBrush.ButtonDown = System.Windows.Forms.MouseButtons.None
        Me.PaintBrush.CursorImage = Nothing
        Me.PaintBrush.Icon = CType(resources.GetObject("PaintBrush.Icon"), System.Drawing.Bitmap)
        Me.PaintBrush.Image = CType(resources.GetObject("PaintBrush.Image"), System.Drawing.Image)
        Me.PaintBrush.Location = New System.Drawing.Point(5, 25)
        Me.PaintBrush.Name = "PaintBrush"
        Me.PaintBrush.ParentForm = Nothing
        Me.PaintBrush.ParentToolBag = Nothing
        Me.PaintBrush.PrimaryColor = System.Drawing.Color.Empty
        Me.PaintBrush.SecondaryColor = System.Drawing.Color.Empty
        Me.PaintBrush.Size = New System.Drawing.Size(160, 36)
        Me.PaintBrush.TabIndex = 0
        Me.PaintBrush.Text = "Paint Brush"
        Me.PaintBrush.ToolSelected = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1146, 664)
        Me.Controls.Add(Me.ToolProperties)
        Me.Controls.Add(Me.AlertMessage)
        Me.Controls.Add(Me.ColorPicker)
        Me.Controls.Add(Me.Toolbag)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.CanvasHousing)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.CanvasHousing.ResumeLayout(False)
        Me.Toolbag.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Canvas As Controls.Canvas
    Friend WithEvents Toolbag As Controls.Toolbag
    Friend WithEvents ColorPicker As Controls.ColorPicker
    Friend WithEvents PaintBrush As Controls.PaintBrush
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlertMessage As Controls.AlertMessage
    Friend WithEvents Pencil As Controls.Pencil
    Friend WithEvents ToolProperties As Controls.ToolProperties
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Eraser As Controls.Eraser
    Friend WithEvents CanvasHousing As Panel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
End Class
