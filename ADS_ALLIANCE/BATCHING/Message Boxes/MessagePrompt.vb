Imports System.Windows.Forms

Public Class MessagePrompt
    Friend WithEvents btnYES As System.Windows.Forms.Button
    Friend WithEvents btnNO As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCANCEL As System.Windows.Forms.Button


   


    Public Sub New(ByVal text As String, ByVal caption As String, ByVal imageType As Bitmap)
        InitializeComponent()

        With TableLayoutPanel1
            .Controls.Add(btnOK, 2, 0)
        End With

    End Sub

    Private Sub btnYES_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnYES.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNO_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnYES.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnOK_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnYES.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCANCEL_click(ByVal sender As Object, ByVal e As EventArgs) Handles btnYES.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
