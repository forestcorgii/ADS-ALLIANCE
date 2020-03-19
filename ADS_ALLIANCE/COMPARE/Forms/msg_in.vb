Imports System.Windows.Forms

Public Class msg_in
    Public valid_range As String = ""
    Public acceptBlank, NumberOnly As Boolean

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
                    MsgBox("Answer cannot be Blank")
                ElseIf NumberOnly And (txtInput.Text.ToLower <> txtInput.Text.ToUpper) Then
                    MsgBox("Whole Number Only")
                Else
                    If valid_range <> "" Then
                        Dim tmp() As String = valid_range.Split("-")
                        If txtInput.Text.Length < tmp(0) Or txtInput.Text.Length > tmp(1) Then
                            If msgBoxOUT("Length is Invalid.. Do You want to proceed?", "Invalid Length", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()
                                'Else
                                '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                                '    Me.Close()
                            End If
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

    Private Sub msg_in_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If NumberOnly Then
            e.Handled = e.KeyChar.ToString.ToLower <> e.KeyChar.ToString.ToUpper
        End If
    End Sub
End Class
