Module KIMode
#Region "KI Mode Functions/Subs"
    Public Xorigin, Yorigin As Integer
    Public zoomFactor As Double

    Public Sub load_FieldCoord(ByVal rec As Integer)
        mdbToDT("SELECT * FROM " & MNJOBCODE & "_Coordinate", dtCoordinate, conClient)
        currentrows = CurrentRow()
        Dim img_name As String = dtCBatch.Rows(rec).Item("Image001").ToString
        PublicImgVwer.ImagePath = img_path & "\" & img_name
        mdb_Rec = rec + 1
        With dtData001.Rows(rec)
            If mdb_Rec = 1 And mdbName = "00000001.mdb" Then
                PublicDGV.Rows.Clear()
                If MNJOBCODEINFO.Headerfields.Item(0) <> "" Then
                    For Each i As String In MNJOBCODEINFO.Headerfields
                        PublicDGV.Rows.Add(headerFields(i))
                    Next
                Else
                    For Each i As String In Fields
                        If Not MNJOBCODEINFO.Headerfields.Contains(i) Then
                            PublicDGV.Rows.Add(i, .Item(i).ToString)
                        End If
                    Next
                End If
            ElseIf mdb_Rec = 2 Then
                PublicDGV.Rows.Clear()
                For i As Integer = 0 To Fields.Count - 1
                    If Not MNJOBCODEINFO.Headerfields.Contains(Fields(i)) Then
                        PublicDGV.Rows.Add(Fields(i))
                    End If
                Next
            End If
        End With

        For i As Integer = 0 To PublicDGV.Rows.Count - 1
            Dim tmp As String = PublicDGV.Rows(i).Cells(0).Value
            For j As Integer = 0 To dtCoordinate.Rows.Count - 1
                With dtCoordinate.Rows(j)
                    If tmp = .Item("Field").ToString Then
                        PublicDGV.Rows(i).Cells(1).Value = .Item("Coordinate").ToString
                    End If
                End With
            Next
        Next
        If currentrows <= PublicDGV.Rows.Count - 1 Then
            CurrentRow = currentrows
        End If
        load_FieldInfo()
    End Sub
    Public Sub get_group()
        VIEWFORM = "Group:"
        mdbToDT("SELECT * FROM " & MNJOBCODE & "_Groups", dtGroups, conClient)
        If dtgroups.Rows.Count > 0 Then
            For i As Integer = 0 To dtgroups.Rows.Count - 1
                With dtgroups.Rows(i)
                    VIEWFORM &= vbNewLine & i + 1 & " = " & .Item("Coordinate").ToString
                End With
            Next
        Else
            VIEWFORM &= vbNewLine & "NONE"
        End If
    End Sub
    Public Sub save_group(ByVal key As Char)
        If Not Integer.Parse(key) - 1 >= dtGroups.Rows.Count Then
            Dim coordinate As String = dtGroups.Rows(Integer.Parse(key) - 1).Item("Coordinate").ToString
            executeQRY("UPDATE " & MNJOBCODE & "_Coordinate SET [Coordinate] = '" & coordinate & "' WHERE [Field] = '" & FIELDNAME & "'", conClient)
            get_group()
            load_FieldCoord(mdb_Rec - 1)
            CurrentFieldValue = coordinate
            CurrentRow = CurrentRow() + 1
        End If
    End Sub
 
    Public Sub add_Group()
        If MsgBox("Do you want to save as Group??", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            executeQRY("INSERT INTO " & MNJOBCODE & "_Groups([Group],[Coordinate]) VALUES(" & dtGroups.Rows.Count + 1 & ",'" & Xorigin & "," & Yorigin & "," & zoomFactor & "')", conClient)
            MsgBox("Saved")
            get_group()
            load_FieldCoord(mdb_Rec - 1)
        End If
    End Sub
    Public Sub edit_group()
        Dim tmp As String = InputBox("Type the group number you want to edit:")
        If Integer.Parse(tmp) >= dtGroups.Rows.Count Then
            If MsgBox("Do you want to Edit this Group??", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                executeQRY("UPDATE " & MNJOBCODE & "_Groups SET [Coordinate] = '" & Xorigin & "," & Yorigin & "," & zoomFactor & "' WHERE [Group] = " & tmp, conClient)
                MsgBox("Saved")
                get_group()
                load_FieldCoord(mdb_Rec - 1)
            End If
        Else
            MsgBox("Out of Bound")
        End If
    End Sub
  
#End Region
End Module
