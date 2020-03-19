Module Function4BAT

#Region "Message Boxes"
    Public Function msgBox_in(ByVal msg As String, Optional ByVal caption As String = "", Optional ByVal text_range As String = "", Optional ByVal acceptBlank As Boolean = True, Optional ByVal width As Integer = 300, Optional ByVal height As Integer = -1) As String
        If msg_in.Created = False Then
            Dim h As Integer = height
            If height = -1 Then
                h = msg_in.Height
            End If
            msg_in.Size = New Size(width, h)

            msg_in.lblPrompt.Text = msg
            msg_in.Text = caption

            msg_in.valid_range = text_range
            msg_in.acceptBlank = acceptBlank
            msg_in.ShowDialog()

            msgBox_in = msg_in.txtInput.Text
            msg_in.txtInput.Text = ""
            Return msgBox_in
        End If
        Return ""
    End Function

    Public Function msgBoxOUT(ByVal msg As String, Optional ByVal caption As String = "", Optional ByVal btn As MessageBoxButtons = MessageBoxButtons.YesNo,
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
                Return True
                recordCounts = J.Recordcount
            End If
        Next
        recordCounts = Nothing
        Return False
    End Function

    Public Sub getJobCode(ByVal zip As String)
        On Error Resume Next
        For i As Integer = 0 To dtJobs.Rows.Count - 1
            With dtJobs.Rows(i)
                Dim tmparr As String() = .Item("Substring").ToString.Split(",")
                Dim tmp As String = zip.Substring(Integer.Parse(tmparr(0)), Integer.Parse(tmparr(1)))
                If .Item("Keyword").ToString = tmp And tmp IsNot Nothing Then
                    MNJOBCODE = .Item("Jobcode").ToString
                    recordCounts = .Item("Record_Counting").ToString
                    Twopages = .Item("Twopages")
                    E1only = .Item("E1Only")
                    batchSize = .Item("Batchsize")
                    getFields(Fields)
                    Exit For
                End If
            End With
        Next
    End Sub

    Private Sub getFields(ByRef list As List(Of String))
        Dim i As Integer = 0
        list = New List(Of String)
        For i = i To dtFields.Rows.Count - 1
            If dtFields.Rows(i).Item("Jobcode").ToString = MNJOBCODE Then
                For j As Integer = 0 To dtFields.Columns.Count - 1
                    If dtFields.Rows(i).Item(j).ToString.Substring(fieldType, 1) = "1" Then list.Add(dtFields.Columns(j).ColumnName)
                Next
                Exit For
            End If
        Next
    End Sub
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
