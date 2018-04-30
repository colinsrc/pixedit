Public Class frmStartup
#Region "PropertiesAndVariables"

    Dim _totalChecks As Integer = 3
    Dim _checksCompleted As Integer = 0
    Dim _bolStart As Boolean = False

    'this form was created and programmed at 12am, please excuse all un-needed code, misspellings, and terrible crap

#End Region

#Region "frmStartupMethods"
    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer.Enabled = True

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Select Case Progress.Value
            Case 0
                'display first message letting user know program will now check for needed specs
                lblStatus.Text = "Begining startup check..."

                Threading.Thread.Sleep(1000)

            Case 20
                'being check for user documents
                Try
                    lblStatus.Text = "Checking paths..."

                    If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\") Then
                        lblStatus.Text = "Path exists."
                    Else
                        My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.MyDocuments.ToString + "\PixEditProjects\")
                        lblStatus.Text = "Path doesn't exist, creating..."
                    End If
                    _bolStart = True
                Catch
                    _bolStart = False
                End Try
            Case 30
                Try

                    lblStatus.Text = "Starting PixEdit..."

                    Progress.Value = 90

                Catch ex As Exception
                    MessageBox.Show("There was an error launching PixEdit, please contact the developer at his email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End Try

            Case 100
                If _bolStart = True Then
                    frmMain.Show()
                    Me.Close()
                Else
                    MessageBox.Show("There was an error launching PixEdit, please contact the developer at his email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If

        End Select
        If Progress.Value <> 100 Then
            Progress.Value += 10
        End If

    End Sub

#End Region

End Class