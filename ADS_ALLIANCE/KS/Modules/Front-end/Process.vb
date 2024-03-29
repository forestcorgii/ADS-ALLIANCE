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
                subfolders = IO.Directory.GetDirectories(i, valFolder, SearchOption.TopDirectoryOnly)
                mdbCount = IO.Directory.GetFiles(subfolders(0), "*.mdb")
                If mdbCount.Length > 0 Then
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
#End Region

#Region "KS LOG"
    Public KSWRITER As StreamWriter
    Public KSPATH As String

    Public Sub startWriteCNT(ByVal reset As Boolean)
        Dim p As New DirectoryInfo(KSPATH)
        Directory.CreateDirectory(p.Parent.FullName)
        If reset = True Then
            If File.Exists(KSPATH & ".CNT") Then
                File.Delete(KSPATH & ".CNT")
            End If
            KSWRITER = File.AppendText(KSPATH & ".CNT")
            KSWRITER.WriteLine("Batch No,Total Count,Total KeyStroke,Total Average")
            End If
    End Sub
    Public Sub write(ByVal batch As String, ByVal totalREC As Integer, ByVal totalPU As Integer, ByVal totalKeyStroke As Integer)
        Dim AVERAGE As Double = 0
        If Not totalREC = 0 And Not totalKeyStroke = 0 Then
            AVERAGE = totalKeyStroke / totalREC
        End If

        KSWRITER.WriteLine(batch & "," & totalREC & "," & totalKeyStroke & "," & AVERAGE)
    End Sub

    Public Sub finishWriteCNT(KSVAR As KSVariables)
        KSWRITER.WriteLine("")
        KSWRITER.WriteLine("================================================")
        KSWRITER.WriteLine(String.Format("Pullout Records: {0}", KSVAR.TOTALPULLOUT))
        KSWRITER.WriteLine("================================================")
        KSWRITER.WriteLine(String.Format("Total Records: {0}", KSVAR.TOTALRECORD + KSVAR.TOTALPULLOUT))
        KSWRITER.WriteLine(String.Format("Total Valid Records: {0}", KSVAR.VALIDRECORD))
        KSWRITER.WriteLine("Total KeyStroke: {0}", KSVAR.TOTALKS)
        KSWRITER.WriteLine("Average KeyStroke: {0}", KSVAR.AVERAGEKS)
        '  KSWRITER.WriteLine("No. of Forms/Sheets:	{0}", KSVAR.TOTALFORMS)
        '   KSWRITER.WriteLine("Average KS w/ Forms:	{0}", KSVAR.AVERAGEKSbyFORMS)
        KSWRITER.WriteLine("================================================")

        KSWRITER.Close()
    End Sub

    Public Class KSVariables
        Public TOTALPULLOUT As Integer
        Public TOTALRECORD As Integer
        Public TOTALKS As Integer
        Public TOTALFORMS As Integer
        Public AVERAGEKS As Double
        Public AVERAGEKSbyFORMS As Double
        Public VALIDRECORD As Integer
    End Class
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
