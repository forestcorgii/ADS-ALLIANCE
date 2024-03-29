Imports System.IO
Imports System.Data.OleDb
Imports System.Text.RegularExpressions

Module Process

#Region "Save"
    Public Sub saveVal(con As OleDbConnection)
        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT ValFlag FROM {0}", MNJOBCODE), tmp, con)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"RefFlag", "RefID", "RefDate"}, New Object() {counter, USERID, PresentDATETIME}, Nothing, con)

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
                If mdbCount.Length > 0 Then
                    ' If checkFlag(tmpJobcode, mdbCount) Then
                    dtg1.Rows.Add(i)
                    'End If
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
                If MNJOBCODE = "PP367" Then
                    Return JobFolders.E1.Trim(" ")
                Else
                    Return JobFolders.E1
                End If
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
        dtg2.Sort(dtg2.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
        dtg2.SelectAll()
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


#Region "Flag Checking"
    Public Function checkFlag(jobcode As String, mdbs As String()) As Boolean
        Dim con As New OleDbConnection
        Dim dt As New DataTable
        For Each mdb As String In mdbs
            mdbOpen(mdb, con)
            mdbToDT("SELECT * FROM " & jobcode & " WHERE ValFlag = '0' OR ComFlag = '0'", dt, con)
            If Not dt.Rows.Count = 0 Then
                Return False
            End If
        Next

        Return True
    End Function
#End Region
#End Region



#Region "Data Manipulation"
    Public Function populateData(client_ref As String) As String()
        Dim data(10) As String
        data(0) = "" : data(1) = "" : data(2) = "" : data(3) = "" : data(4) = "" : data(5) = "" : data(6) = "" : data(7) = "" : data(8) = "" : data(9) = "" : data(10) = ""
        '   Dim qry As String = String.Format("SELECT * FROM Sheet1 WHERE ClientReference='{0}'", client_ref)
        Dim thrdcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), thirdMailingFile)
        Dim Zcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), ZonalCon)
        Dim NZcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), NonZonalCon)
        Dim reader As OleDbDataReader
        reader = Zcmd.ExecuteReader()
        While reader.Read()
            data(0) = reader.Item("Forename").ToString
            data(1) = reader.Item("Surname").ToString
            data(2) = reader.Item("Account number 1").ToString
            data(3) = reader.Item("Account number 2").ToString
            data(4) = reader.Item("Account number 3").ToString
            data(5) = reader.Item("Account number 4").ToString
            data(6) = reader.Item("Account number 5").ToString
            data(7) = reader.Item("Account number 6").ToString
            data(8) = reader.Item("Account number 7").ToString
            data(9) = reader.Item("Account number 8").ToString
            data(10) = reader.Item("ClientReference").ToString
        End While

        If data(1) = "" Then
            reader = NZcmd.ExecuteReader()
            While reader.Read()
                data(0) = reader.Item("Forename").ToString
                data(1) = reader.Item("Surname").ToString
                data(2) = reader.Item("Account number 1").ToString
                data(3) = reader.Item("Account number 2").ToString
                data(4) = reader.Item("Account number 3").ToString
                data(5) = reader.Item("Account number 4").ToString
                data(6) = reader.Item("Account number 5").ToString
                data(7) = reader.Item("Account number 6").ToString
                data(8) = reader.Item("Account number 7").ToString
                data(9) = reader.Item("Account number 8").ToString
                data(10) = reader.Item("ClientReference").ToString
            End While
        End If

        If data(1) = "" Then
            reader = thrdcmd.ExecuteReader()
            While reader.Read()
                data(0) = reader.Item("Forename").ToString
                data(1) = reader.Item("Surname").ToString
                data(2) = reader.Item("Account number 1").ToString
                data(3) = reader.Item("Account number 2").ToString
                data(4) = reader.Item("Account number 3").ToString
                data(5) = reader.Item("Account number 4").ToString
                data(6) = reader.Item("Account number 5").ToString
                data(7) = reader.Item("Account number 6").ToString
                data(8) = reader.Item("Account number 7").ToString
                data(9) = reader.Item("Account number 8").ToString
                data(10) = reader.Item("ClientReference").ToString
            End While
        End If

        Return data
    End Function


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
