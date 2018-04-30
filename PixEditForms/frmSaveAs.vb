Public Class frmSaveAs

#Region "PropertiesAndVariables"

    Private _error As New ToolTip
    Private fileType As String
    Private fileName As String
    Private fileDirectory As String
    Private _image As Bitmap

#End Region

#Region "frmSaveAsMethods"

    Private Sub frmSaveAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set the form icon
        Me.Icon = My.Resources.Images.Save

        'init the error handling tooltip
        With _error
            .ToolTipIcon = ToolTipIcon.Error
            .UseFading = True
            .UseAnimation = True
            .IsBalloon = True
        End With

        'set the default filetype
        ComboBox1.SelectedItem = ComboBox1.Items(0)

        'set the canvas image to the picture box image
        pbImage.Image = _image

    End Sub

    Private Sub btnDirectory_Click(sender As Object, e As EventArgs) Handles btnDirectory.Click

        Dim fileDialog As New FolderBrowserDialog

        If txtName.Text <> String.Empty Then

            Dim tmpString As String = FileIO.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\" + txtName.Text

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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            fileDirectory = txtDirectory.Text + "\"
            fileName = txtName.Text

            _image.Save(fileDirectory + fileName + fileType)

            Me.Dispose()

        Catch ex As Exception
            _error.Show("Error saving, please check the fields.", btnSave, 2000)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        fileType = ComboBox1.SelectedItem.ToString.Substring(0, ComboBox1.SelectedItem.ToString.IndexOf(" "))

    End Sub

    Public Function SendCanvas(ByVal canvas As Bitmap) As Boolean
        Try
            _image = canvas
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

#End Region

End Class