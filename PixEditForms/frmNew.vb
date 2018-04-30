Public Class frmNew

#Region "PropertiesAndVariables"

    Private _error As New ToolTip
    Private clr As Color
    Private fileType As String
    Private newSize As Size

#End Region


#Region "frmMainMethods"

    Private Sub frmNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set the form icon
        Me.Icon = My.Resources.Images._New

        'init the error handling tooltip
        With _error
            .ToolTipIcon = ToolTipIcon.Error
            .UseFading = True
            .UseAnimation = True
            .IsBalloon = True
        End With

        'set default color values
        txtR.Text = 0
        txtG.Text = 0
        txtB.Text = 0

        'select default color (white)
        ComboBox1.SelectedItem = "White"

        'set the default filetype
        ComboBox2.SelectedItem = ComboBox2.Items(0)

        'set the default canvas size measurement type
        txtHeight.Text = "952"

        txtWidth.Text = "476"

        LengthType.SelectedItem = LengthType.Items(0)

    End Sub

    Private Sub btnDirectory_Click(sender As Object, e As EventArgs) Handles btnDirectory.Click
        Dim fileDialog As New FolderBrowserDialog

        If txtName.Text <> String.Empty Then

            Dim tmpString As String = FileIO.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\" + txtName.Text

            If My.Computer.FileSystem.DirectoryExists(tmpString) = False Then
                My.Computer.FileSystem.CreateDirectory(tmpString)
            End If

            With fileDialog
                .SelectedPath = tmpString
                .ShowNewFolderButton = True
            End With

            Select Case fileDialog.ShowDialog
                Case System.Windows.Forms.DialogResult.OK
                    txtDirectory.Text = fileDialog.SelectedPath
            End Select

        Else
            _error.Show("Enter a project name.", txtName, 2000)
        End If

    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        'begin check to make sure all fields are valid
        If ValidateFields() = True Then

            'call the main forms create method
            frmMain.NewProject(txtName.Text, txtDirectory.Text, fileType, clr, newSize)

            'close this form
            Me.Dispose()
        End If
    End Sub

    Public Function ValidateFields() As Boolean
        Select Case True
            Case txtName.Text = String.Empty
                _error.Show("Enter a valid name.", txtName, 2000)
                Return False
            Case txtName.Text.Contains(".") OrElse txtName.Text.Contains("/") OrElse txtName.Text.Contains("\")
                _error.Show("Name cannot include chars (. / \ [ ])", txtName, 2000)
                Return False
            Case txtDirectory.Text = String.Empty
                _error.Show("Enter a valid directory", txtDirectory, 2000)
                Return False
            Case Else
                Return True
        End Select
    End Function

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        Select Case True

            Case ComboBox2.SelectedItem.ToString.Contains(".jpg")
                fileType = ".jpg"
            Case ComboBox2.SelectedItem.ToString.Contains(".png")
                fileType = ".png"
            Case ComboBox2.SelectedItem.ToString.Contains(".bmp")
                fileType = ".bmp"
            Case ComboBox2.SelectedItem.ToString.Contains(".gif")
                fileType = ".gif"

        End Select

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Select Case ComboBox1.SelectedItem
            Case "Red"
                txtR.Text = Color.Red.R
                txtG.Text = Color.Red.G
                txtB.Text = Color.Red.B

                Canvas.BackColor = Color.Red
            Case "Blue"
                txtR.Text = Color.Blue.R
                txtG.Text = Color.Blue.G
                txtB.Text = Color.Blue.B

                Canvas.BackColor = Color.Blue
            Case "Green"
                txtR.Text = Color.Green.R
                txtG.Text = Color.Green.G
                txtB.Text = Color.Green.B

                Canvas.BackColor = Color.Green
            Case "Orange"
                txtR.Text = Color.Orange.R
                txtG.Text = Color.Orange.G
                txtB.Text = Color.Orange.B

                Canvas.BackColor = Color.Orange
            Case "Yellow"
                txtR.Text = Color.Yellow.R
                txtG.Text = Color.Yellow.G
                txtB.Text = Color.Yellow.B

                Canvas.BackColor = Color.Yellow
            Case "Black"
                txtR.Text = Color.Black.R
                txtG.Text = Color.Black.G
                txtB.Text = Color.Black.B

                Canvas.BackColor = Color.Black
            Case "White"
                txtR.Text = Color.White.R
                txtG.Text = Color.White.G
                txtB.Text = Color.White.B

                Canvas.BackColor = Color.White
        End Select

    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click

        Dim colorDialog As New ColorDialog

        With colorDialog
            .AnyColor = True
        End With

        colorDialog.ShowDialog()

        clr = colorDialog.Color

        ComboBox1.SelectedItem = "Custom Selection"

        Canvas.BackColor = clr

        txtR.Text = clr.R
        txtG.Text = clr.G
        txtB.Text = clr.B

    End Sub

    Private Sub txtR_TextChanged(sender As Object, e As EventArgs) Handles txtR.TextChanged
        clr = GetColor()
        Canvas.BackColor = clr
    End Sub

    Private Sub txtG_TextChanged(sender As Object, e As EventArgs) Handles txtG.TextChanged
        clr = GetColor()
        Canvas.BackColor = clr
    End Sub

    Private Sub txtB_TextChanged(sender As Object, e As EventArgs) Handles txtB.TextChanged
        clr = GetColor()
        Canvas.BackColor = clr
    End Sub

    Public Function GetColor() As Color

        Dim finalColor As Color

        Try
            Dim r As Integer = 0
            If txtR.Text = "" Then
                r = 0
            Else
                r = CInt(txtR.Text)
            End If

            Dim g As Integer = 0
            If txtG.Text = "" Then
                g = 0
            Else
                g = CInt(txtG.Text)
            End If

            Dim b As Integer = 0
            If txtB.Text = "" Then
                b = 0
            Else
                b = CInt(txtB.Text)
            End If

            finalColor = Color.FromArgb(r, g, b)

        Catch ex As Exception
            Return Color.Black
        End Try

        Return finalColor
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub LengthType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LengthType.SelectedIndexChanged
        Try
            Select Case True
                Case LengthType.SelectedItem = "Pixels"
                    lblDimensionsPixels.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    newSize = New Size(x, y)

                    x = Math.Round((x / 75), 2)
                    y = Math.Round((y / 75), 2)

                    lblDimensionsInches.Text = x.ToString + "x" + y.ToString


                Case LengthType.SelectedItem = "Inches"
                    lblDimensionsInches.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    x = Math.Round((x * 75), 2)
                    y = Math.Round((y * 75), 2)

                    lblDimensionsPixels.Text = x.ToString + "x" + y.ToString

                    newSize = New Size(x, y)

            End Select
        Catch
            MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtHeight_TextChanged(sender As Object, e As EventArgs) Handles txtHeight.TextChanged
        Try
            Select Case True
                Case LengthType.SelectedItem = "Pixels"
                    lblDimensionsPixels.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    newSize = New Size(x, y)

                    x = Math.Round((x / 75), 2)
                    y = Math.Round((y / 75), 2)

                    lblDimensionsInches.Text = x.ToString + "x" + y.ToString


                Case LengthType.SelectedItem = "Inches"
                    lblDimensionsInches.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    x = Math.Round((x * 75), 2)
                    y = Math.Round((y * 75), 2)

                    lblDimensionsPixels.Text = x.ToString + "x" + y.ToString

                    newSize = New Size(x, y)

            End Select
        Catch
            MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtWidth_TextChanged(sender As Object, e As EventArgs) Handles txtWidth.TextChanged
        Try
            Select Case True
                Case LengthType.SelectedItem = "Pixels"
                    lblDimensionsPixels.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    newSize = New Size(x, y)

                    x = Math.Round((x / 300), 2)
                    y = Math.Round((y / 300), 2)

                    lblDimensionsInches.Text = x.ToString + "x" + y.ToString

                Case LengthType.SelectedItem = "Inches"
                    lblDimensionsInches.Text = txtHeight.Text + "x" + txtWidth.Text

                    Dim x As Integer = CInt(txtHeight.Text)
                    Dim y As Integer = CInt(txtWidth.Text)

                    x = Math.Round((x * 300), 2)
                    y = Math.Round((y * 300), 2)

                    lblDimensionsPixels.Text = x.ToString + "x" + y.ToString

                    newSize = New Size(x, y)

            End Select
        Catch
            MessageBox.Show("Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


#End Region
End Class