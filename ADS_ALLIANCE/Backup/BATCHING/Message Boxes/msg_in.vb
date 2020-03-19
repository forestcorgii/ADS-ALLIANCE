Imports System.Windows.Forms

Public Class msg_in
    Public valid_range As String = ""
    Public acceptBlank As Boolean = True
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub msg_in_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
         valid_range = ""
        acceptBlank = True
    End Sub

    Private Sub msg_in_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                txtInput.Text = ""
                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()
            Case Keys.Enter
                If acceptBlank = False And txtInput.Text = "" Then
                    msgBox_Out("Answer cannot be Blank", Me.Text)
                Else
                    If valid_range <> "" Then
                        Dim tmp() As String = valid_range.Split("-")
                        If txtInput.Text.Length < tmp(0) And txtInput.Text.Length > tmp(1) Then
                            ' If msgBox_bool("Length is Invalid.. Do You want to proceed?", Me.Text) = True Then
                            '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            '    Me.Close()
                            '  Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                            Me.Close()
                            ' End If
                        Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    Else
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
        End Select
    End Sub
End Class
