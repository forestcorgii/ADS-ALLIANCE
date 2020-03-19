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
    Public Function CheckJobCode(ByVal zip As String) As Boolean
        For Each J As JobcodeInfo In MNJOBINFO.Jobcodes
            Dim tmparr As String() = J.Substring.Split(",")
            Dim tmp As String = zip.Substring(Integer.Parse(tmparr(0)), Integer.Parse(tmparr(1)))
            If J.Keyword = tmp Then
                ' MNJOBCODEINFO = J
                ' MNJOBCODE = J.Jobcode

                recordCounts = J.Recordcount
                ' Twopages = J.Twopages
                '  E1only = J.E1Only
                '  batchSize = J.Batchsize
                ' Fields = New List(Of String)
                '  Fields = J.Validfields
                Return True
            End If
        Next
    End Function

    'Public Sub JobCodeInfo(ByVal zip As String)
    '    On Error Resume Next
    '    For i As Integer = 0 To dtJobs.Rows.Count - 1
    '        With dtJobs.Rows(i)
    '            Dim tmparr As String() = .Item("Substring").ToString.Split(",")
    '            Dim tmp As String = zip.Substring(Integer.Parse(tmparr(0)), Integer.Parse(tmparr(1)))
    '            If .Item("Keyword").ToString = tmp And tmp IsNot Nothing Then
    '                MNJOBCODE = .Item("Jobcode").ToString
    '                getHeaderFields(.Item("Header").ToString.Split("|"))
    '                recordCounts = .Item("Record_Counting").ToString
    '                Twopages = .Item("Twopages")
    '                E1only = .Item("E1Only")
    '                getFields(Fields)
    '                Exit For
    '            End If
    '        End With
    '    Next
    'End Sub

    'Private Sub getHeaderFields(ByVal arr() As String)
    '    headerFields = New List(Of String)
    '    For Each i As String In arr
    '        If i <> "" Then headerFields.Add(i)
    '    Next
    'End Sub

    'Private Sub getFields(ByRef list As List(Of String))
    '    Dim i As Integer = 0
    '    list = New List(Of String)
    '    For i = i To dtFields.Rows.Count - 1
    '        If dtFields.Rows(i).Item("Jobcode").ToString = MNJOBCODE Then
    '            For j As Integer = 2 To dtFields.Columns.Count - 1
    '                Dim tmp As String = dtFields.Rows(i).Item(j).ToString
    '                Dim substr As Integer = fieldType

    '                If tmp.Length - 1 < substr Then
    '                    substr -= 1
    '                End If

    '                If tmp.Length >= Val(substr) + 1 Then
    '                    If tmp.Substring(substr, 1) = "1" Then
    '                        list.Add(dtFields.Columns(j).ColumnName)
    '                    End If
    '                End If
    '            Next
    '            Exit For
    '        End If
    '    Next
    'End Sub

#End Region

#Region "OTHER"
    Public Function addLength(ByVal str As String, ByVal valLen As Integer, Optional ByVal myChar As String = " ") As String
        If Len(str) < valLen Then
            Do Until Len(str) = valLen
                str = str & myChar
            Loop
        End If
        addLength = str
    End Function
#End Region

End Module
