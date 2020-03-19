Module TickMode
#Region "Tick Mode Functions/Subs"

    Public Sub load_tickFields()
        Dim tmp_dt As New DataTable
        mdbToDT(String.Format("SELECT * FROM {0}_Field WHERE Jobcode = '{1}'", MNJOB, MNJOBCODE), tmp_dt, conClient)
        PublicDGV.Rows.Clear()
        For i As Integer = 1 To tmp_dt.Columns.Count - 1
            PublicDGV.Rows.Add(tmp_dt.Columns(i).ColumnName, tmp_dt.Rows(0).Item(i).ToString)
        Next
    End Sub

    Public Sub edit_Code()
        Dim sql As String = "UPDATE " & mnjob & "_Field set "
        For i As Integer = 0 To PublicDGV.Rows.Count - 1
            Dim field As String = PublicDGV.Rows(i).Cells(0).Value
            Dim value As String = PublicDGV.Rows(i).Cells(1).Value
            If value.Length - 1 < fieldType Then value &= "0"
            If i = PublicDGV.Rows.Count - 1 Then
                sql = sql & "[" & field & "]" & " = '" & value.Replace("'", "''") & "'"
            Else
                sql = sql & "[" & field & "]" & " = '" & value.Replace("'", "''") & "',"
            End If
        Next
        sql = sql + " where Jobcode = '" & MNJOBCODE & "'"
        executeQRY(sql, conClient)
    End Sub
#End Region
End Module
