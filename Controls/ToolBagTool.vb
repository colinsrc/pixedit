Imports System.Windows.Forms
Imports System.Drawing
Public Class ToolBagTool
    Inherits System.Windows.Forms.Label
#Region "PropertiesAndVariables"
    Private _bolSelected As Boolean
    Private _buttonDown
    Public Property ParentToolBag As Toolbag

    Public Property ToolSelected As Boolean
        Set(value As Boolean)
            _bolSelected = value

            'if selected is set to true, execute the tools main sub procedure
            If _bolSelected = True Then

                Main()
            End If
        End Set
        Get
            Return _bolSelected
        End Get
    End Property

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(160, 36)
        End Get
    End Property

    Public Overrides Property AutoSize As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
            MyBase.AutoSize = value
        End Set
    End Property

    Public Property ButtonDown As System.Windows.Forms.MouseButtons
        Get
            Return _buttonDown
        End Get
        Set(value As System.Windows.Forms.MouseButtons)
            _buttonDown = value
        End Set
    End Property

    Public Overridable Property Icon As Bitmap

    Public Property CursorImage As Icon

#End Region

#Region "ToolBagToolMethods"
    Protected Overrides Sub OnPaint(ByVal paintEvent As PaintEventArgs)

        paintEvent.Graphics.DrawString(Text, New Font(Font.FontFamily.ToString, 10), Brushes.Black, New Point(36, (36 / 2) / 2))

        paintEvent.Graphics.DrawImage(Icon, New Point(0, 0))

    End Sub

    Private Sub ToolBagTool_Click(sender As Object, e As EventArgs) Handles Me.Click
        If _bolSelected Then
            _bolSelected = False
        Else
            _bolSelected = True
        End If

        'reset all other tools in the toolbox
        ParentToolBag.SelectTool(Me)

        Select Case _bolSelected
            Case True
                Me.BackColor = SystemColors.Highlight
                Me.Refresh()
            Case False
                Me.BackColor = SystemColors.Control
                Me.Refresh()
        End Select

        'call the main sub procedure to execute code
        If _bolSelected = True Then
            Try
                'set the toolpropertiescontrol of the parent toolbag to the panel that is returned by
                'the GetProperties function of the inheriting tool
                If ParentToolBag.ToolPropertiesControl.ResetToolProperties = False Then
                    MessageBox.Show("Error resetting tool properties panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                ParentToolBag.ToolPropertiesControl.ToolProperties = GetProperties(ParentToolBag.ToolPropertiesControl.ToolProperties)

                ParentToolBag.SelectedTool = Me

                'execute the main code of the tool
                Main()
            Catch
                MessageBox.Show("There was an error loading this tool's properties", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If


    End Sub

    Public Function SelectMe() As Boolean
        Try
            'reset all other tools in the toolbox
            ParentToolBag.SelectTool(Me)

            'in this case, false = true and vice-versa
            Select Case _bolSelected
                Case False
                    Me.BackColor = SystemColors.Highlight
                    Me.Refresh()
                Case True
                    Me.BackColor = SystemColors.Control
                    Me.Refresh()
            End Select

            'set the tool's selected property to true
            ToolSelected = True

            'set the parent toolbag's selected tool property to this tool
            ParentToolBag.SelectedTool = Me


        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Overridable Function GetProperties(ByVal parentPanel As System.Windows.Forms.Panel) As System.Windows.Forms.Panel
        'code for getting the tool's properties goes in here
    End Function

    Public Overridable Sub Main()
        'main executed code for the tool goes in here
    End Sub
#End Region
End Class
