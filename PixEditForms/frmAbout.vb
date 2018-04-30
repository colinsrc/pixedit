Public Class frmAbout
#Region "PropertiesAndVariables"


#End Region

#Region "frmAboutMethods"
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = SystemIcons.Information
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region
End Class