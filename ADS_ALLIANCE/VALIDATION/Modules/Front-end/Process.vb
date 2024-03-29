Imports System.IO
Imports System.Data.OleDb

Module Process

#Region "Save"
    Public Sub saveVal(con As OleDbConnection)
        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT ValFlag FROM {0}", MNJOBCODE), tmp, con)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"ValFlag", "ValID", "ValDate"}, New Object() {counter, USERID, PresentDATETIME}, Nothing, con)

    End Sub

#End Region

#Region "Commands"
    Public Sub getList(ByRef dtg1 As DataGridView, ByVal dirListPath As String)
        On Error Resume Next
        dtg1.Rows.Clear()
        Dim folders, subfolders, mdbCount As String()
        folders = IO.Directory.GetDirectories(dirListPath, "**", SearchOption.TopDirectoryOnly)
        For Each i As String In folders
            Dim getPar As New DirectoryInfo(i)
            Dim tmpJobcode As String = CheckJobCode(getPar.Name)
            If Not tmpJobcode = "" Then
                getJobCodeInfo(tmpJobcode)
                subfolders = IO.Directory.GetDirectories(i, valFolder, SearchOption.TopDirectoryOnly)
                mdbCount = IO.Directory.GetFiles(subfolders(0), "*.mdb")
                If mdbCount IsNot Nothing AndAlso mdbCount.Length > 0 Then
                    dtg1.Rows.Add(i)
                End If
            End If
        Next
        If dtg1.RowCount = 1 Then
            dtg1.Rows(0).Selected = True
        End If

        Application.DoEvents()
    End Sub

    Public Function valFolder() As String
        Select Case MNJOBCODEINFO.E1Only
            Case True
                Return JobFolders.E1
            Case False
                Return JobFolders.C1
            Case Else
                Return JobFolders.C1
        End Select
    End Function
#Region "ADD"
    Public Sub addAll(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        For i As Integer = 0 To dtg1.RowCount - 1
            dtg1.Rows(i).Selected = True
        Next
        addSelected(dtg1, dtg2)
    End Sub
    Public Sub addSelected(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg1.SelectedRows.Count = 0 Then
            If dtg1.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dtg1.SelectedRows.Count - 1
                    Dim li1 As String = dtg1.SelectedRows(i).Cells(0).Value
                     dtg2.Rows.Add(li1)
                Next
                For i As Integer = 0 To dtg1.SelectedRows.Count - 1
                    dtg1.Rows.Remove(dtg1.SelectedRows(0))
                Next
            End If
        End If
    End Sub

#End Region

#Region "REMOVE"
    Public Sub removeSelected(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg2.SelectedRows.Count = 0 Then
            If dtg2.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dtg2.SelectedRows.Count - 1
                    Dim li1 As String = dtg2.SelectedRows(i).Cells(0).Value
                    dtg1.Rows.Add(li1)
                Next
                For i As Integer = 0 To dtg2.SelectedRows.Count - 1
                    dtg2.Rows.Remove(dtg2.SelectedRows(0))
                Next
            End If
        End If
    End Sub
    Public Sub removeAll(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg2.Rows.Count = 0 Then
            For i As Integer = 0 To dtg2.RowCount - 1
                dtg2.Rows(i).Selected = True
            Next
            removeSelected(dtg1, dtg2)
        End If
    End Sub

#End Region

#End Region

#Region "Opening Data"
    Public Sub openEntryData(ByVal path As String, ByVal mdb As String)
        mdbOpen(String.Format("{0}\{1}\{2}", path, JobFolders.E1, mdb), conE1)
        mdbOpen(String.Format("{0}\{1}\{2}", path, JobFolders.E2, mdb), conE2)

        mdbToDT(String.Format("SELECT * FROM {0}", MNJOBCODE), dtCBatchE1, conE1)
        mdbToDT(String.Format("SELECT * FROM {0}", MNJOBCODE), dtCBatchE2, conE2)
        mdbToDT("SELECT * FROM Data001", dtDataE1, conE1)
        mdbToDT("SELECT * FROM Data001", dtDataE2, conE2)
    End Sub

    Public Sub refresh_DT(ByVal con As OleDbConnection)
        dtData001 = New DataTable
        dtCBatch = New DataTable
        mdbToDT("SELECT * FROM Data001", dtData001, con)
        mdbToDT("SELECT * FROM " & MNJOBCODE, dtCBatch, con)
    End Sub


    Public Sub load_FieldInfo(fld As String)
        Dim fl As New FieldInfo
        For Each flList As FieldInfo In MNJOBINFO.Fields
            If flList.Fieldname = fld Then
                fl = flList
                Exit For
            End If
        Next

        With fl
            Haslookup = .Haslookup
            setLookUp(.Haslookup)

            autoNext = Boolean.Parse(.Autonext)
            def_Value = .DefaultValue
            num_Format = .Numberformat

            charPerIndex = .Validcharperindex
            char_Valid = .Character
            PO_Key = .Pulloutkey
            char_Other = .OtherCharacter
        End With
    End Sub

#Region "Flag Checking"
    Public Function checkFlag() As Boolean
        For i As Integer = 0 To dtCBatch.Rows.Count - 1
            If dtCBatchE1.Rows(i).Item("KeyFlag").ToString = "" Then
                MsgBox("Entry 1 Data is not yet finish")
                Return False
            End If
        Next
        Return True
    End Function
#End Region
#End Region



#Region "Data Manipulation"
    Public Function FillSpaces(ByVal str As String, ByVal valLen As Integer, Optional ByVal myChar As String = " ") As String
        If Len(str) < valLen Then
            Do Until Len(str) = valLen
                str = str & myChar
            Loop
        End If
        FillSpaces = str
    End Function
#End Region

#Region "Check for missing images"
    'Public Function checkImages() As Boolean
    '    For Each rw As DataRow In dtCBatch.Rows
    '        If MNJOBCODEINFO.Twopages Then
    '            If Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image001").ToString)) Or _
    '              Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image002").ToString)) Then
    '                MsgBox("Some Images are Missing/Corrupted")
    '                MNFORM.Close()
    '                Return False
    '            End If
    '        Else
    '            If Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image001").ToString)) Then
    '                MsgBox("Some Images are Missing/Corrupted")
    '                MNFORM.Close()
    '                Return False
    '            End If
    '        End If
    '    Next
    '    Return True
    'End Function
#End Region

End Module
