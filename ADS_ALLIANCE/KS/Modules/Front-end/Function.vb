Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.IO.StreamReader
Imports System.IO.StreamWriter
Imports System.Text
Imports System.Diagnostics.Process
Imports System.Windows.Forms

Module Function4BAT

#Region "Message Boxes"
    Public Function msgBox_in(ByVal msg As String, Optional ByVal caption As String = "", Optional ByVal text_range As String = "", Optional ByVal acceptBlank As Boolean = True, Optional ByVal numberOnly As Boolean = False, Optional ByVal width As Integer = 300, Optional ByVal height As Integer = -1) As String
        If msg_in.Created = False Then
            Dim h As Integer = height
            If height = -1 Then
                h = msg_in.Height
            End If
            Dim input As New msg_in

            input.Size = New Size(width, h)

            input.lblPrompt.Text = msg
            input.Text = caption

            input.valid_range = text_range
            input.acceptBlank = acceptBlank
            input.ShowDialog()

            If input.DialogResult <> DialogResult.OK Then
                msgBox_in = ""
            Else
                msgBox_in = input.txtInput.Text
            End If
            input.txtInput.Text = ""
            Return msgBox_in
        End If
        Return ""
    End Function

    Public Function msgBoxOUT(ByVal msg As String, Optional ByVal caption As String = "", Optional ByVal btn As MessageBoxButtons = MessageBoxButtons.YesNo, _
    Optional ByVal ICON As MessageBoxIcon = MessageBoxIcon.None, Optional ByVal DEF As MessageBoxDefaultButton = MessageBoxDefaultButton.Button2) As DialogResult
        msgBoxOUT = MessageBox.Show(msg, caption, btn, ICON, DEF)
        Return msgBoxOUT
    End Function

#End Region

#Region "JOBCODE INFO"
    Public Function CheckJobCode(ByVal zip As String) As String
        For Each J As JobcodeInfo In MNJOBINFO.Jobcodes
            Dim tmparr As String() = J.Substring.Split(",")
            If zip.Length >= Integer.Parse(tmparr(1)) Then
                Dim tmp As String = zip.Substring(Integer.Parse(tmparr(0)), Integer.Parse(tmparr(1)))
                If J.Keyword = tmp Then
                    Return J.Jobcode
                End If
            End If
        Next
        Return ""
    End Function
#End Region

End Module
