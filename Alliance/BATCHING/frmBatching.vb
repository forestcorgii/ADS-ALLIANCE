Imports System.IO

Public Class frmBatching
    Private bat_Location As String
    '  Private bat_Size As Integer
    Private dblog As String
    Private reBatch As Boolean = False
    Private imgloc As DirectoryInfo
#Region "Setup"
    Private Sub MainSetup()
        lbClientName.Text = ClientName
        lbJobName.Text = JobName
    End Sub
#End Region

#Region "Controls"
    Private Sub getList(ByRef dtg1 As DataGridView, ByVal dirListPath As String)
        On Error Resume Next
        dtg1.Rows.Clear()
        Dim folders() As String
        folders = IO.Directory.GetDirectories(dirListPath, "**", SearchOption.TopDirectoryOnly)
        For Each i As String In folders
            Dim batch As New BatchInfo(i)

            If batch.Valid Then
                dtg1.Rows.Add(i, batch.Files.Count, batch.Files.Count)
            End If
        Next

        If dtg1.RowCount = 1 Then
            dtg1.Rows(0).Selected = True
        End If
        Application.DoEvents()
    End Sub
    Private Sub DirListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dirLB.SelectedIndexChanged
        dirLB.Path = dirLB.DirList(dirLB.DirListIndex)
        getList(dgvB, dirLB.Path)
        Application.DoEvents()
    End Sub
    Private Sub dtg1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvB.CellMouseDoubleClick
        addSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub dtg2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvBSEL.CellMouseDoubleClick
        removeSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        addSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAll.Click
        addAll(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        removeSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        removeAll(dgvB, dgvBSEL)
    End Sub

    Private Sub DriveListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles driLB.SelectedIndexChanged
        dirLB.Path = driLB.Drive
    End Sub
#End Region

    Private Sub btnBatch_Click(sender As Object, e As EventArgs) Handles btnBatch.Click
        For Each dgvr As DataGridViewRow In dgvBSEL.Rows
            Dim batch As BatchInfo = DirectCast(dgvr.Cells(0).Value, BatchInfo)
            copyImg(batch.Files.ToArray, DataPath & JobFolders.I1 & "\")
            For Each img As String In batch.Files

            Next
        Next
    End Sub

    Private Sub frmBatching_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MainSetup()
    End Sub

#Region "Batching Process"

#Region "PREPARATION"
    Private Sub bat_prep()
        For Each dgvr As DataGridViewRow In dgvBSEL.Rows
            Dim batch As BatchInfo = DirectCast(dgvr.Cells(0).Value, BatchInfo)
            lbFolder.Text = "From " & dgvr.Index + 1 & " to " & dgvBSEL.RowCount & " - " & dgvr.Cells(0).Value
            imgloc = New DirectoryInfo(dgvr.Cells(0).Value)
            Application.DoEvents()
            ' zipFileToJobcode(zipFile)

            If check_Zipfile(Application.StartupPath & "\CBATCH\", batch.ZipFile) Then

                JobPath = String.Format("{0}\CBATCH\{1}\{2}\{3}", Application.StartupPath, JobName, dateTime2, batch.ZipFile)
                DataPath = String.Format("{0}\{1}\{2}\{3}\{4}\", bat_Location, ClientName, JobName, dateTime2, batch.ZipFile)

                If E1only Then
                    createMultipleFolder(DataPath, New String() {JobFolders.E1, JobFolders.I1}, reBatch)
                Else
                    createMultipleFolder(DataPath, New String() {JobFolders.E1, JobFolders.E2, JobFolders.C1, JobFolders.I1}, reBatch)
                End If
                createFolder(JobPath, reBatch)

                If Not File.Exists(JobPath & "\" & batch.ZipFile & ".mdb") Then
                    mdbCreate(JobPath & "\" & batch.ZipFile & ".mdb")
                    mdbOpen(JobPath & "\" & batch.ZipFile & ".mdb", conCBat)
                End If

                mdbOpen(JobPath & "\" & batch.ZipFile & ".mdb", conCBat)
                mdbCreateTable("origImage", New String() {"OImage001-text(70)", "Image001-text(70)", "OImage002-text(70)", "Image002-text(70)"}, conCBat)
                mdbCreateTable(JobName, New String() {"Recnum-int", "ZipFile-text(70)", "DvdName-text(70)", "BatchNo-text(70)", "OImage001-text(70)", "Image001-text(70)", "OImage002-text(70)", "Image002-text(70)"}, conCBat)

                log_Start(JobPath, batch.ZipFile, DataPath)
                bat_main(dgvr.Cells(0).Value)
            Else
                PB1.Maximum -= dgvr.Cells(1).Value
            End If
        Next
    End Sub

#End Region

#Region "MAIN PROCESS"
    Private Sub bat_main(batch As BatchInfo)
        Dim imgcount, dbCount, rec_start, rec_end, rec_cnt As New Integer

        copyImg(batch.Files.ToArray, DataPath & JobFolders.I1 & "\")
        For Each img As String In batch.Files
            Dim imgname As New DirectoryInfo(img)
            Dim mdbPath As String 'imgPath
            PB1.Value += 1
            Application.DoEvents()

            imgcount += 1
            ' imgPath = DataPath & JobFolders.I1 & "\" & imgcount.ToString("00000000.##")
            '  lbPROCIMG.Text = "From " & imgcount.ToString & " to " & img_count & " - " & img
            ' File.Copy(img, imgPath & EXT.tif, True)

            If rec_end = tbBatchSize.Text * dbCount Or dbCount = 0 Then
                dbCount += 1
                mdbPath = DataPath & JobFolders.E1 & "\" & dbCount.ToString("00000000.##") & EXT.mdb
                If File.Exists(mdbPath) Then
                    File.Delete(mdbPath)
                End If
                mdbCreate(mdbPath)
                mdbOpen(mdbPath, conData)
                mdbCreateCBatch(JobName, conData)
                mdbCreateDataTBL(conData)
                If dbCount > 1 Then
                    rec_start = rec_end - (tbBatchSize.Text - 1)
                    log_Write(JobPath, batch.ZipFile, dbCount - 1, rec_start, rec_end, rec_cnt)
                    rec_cnt = 0
                End If
            End If
            If Twopages = True Then
                If Not imgcount Mod 2 = 0 Then
                    OImage001 = imgname.Name
                Else
                    rec_end += 1
                    rec_cnt += 1
                    OImage002 = imgname.Name
                    proc_2p(rec_end, dbCount, OImage001, OImage002)
                End If
            Else
                rec_end += 1
                rec_cnt += 1
                OImage001 = imgname.Name
                proc_1p(rec_end, dbCount, OImage001)
            End If
        Next

        rec_start = rec_end - (rec_cnt - 1)
        log_end(JobPath, batch.ZipFile, dbCount, rec_start, rec_end, rec_cnt)
        bat_LastPart(batch.Files.Count, batch.Files.Count, dbCount)
    End Sub

#Region "ONE PAGE"
    Private Sub proc_1p(ByVal rec As Integer, ByVal mdb As Integer, ByVal img1_orig As String)
        Dim img1 As String
        img1 = rec.ToString("00000000.##") & ".tif"
        mdbInsert(JobName, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "RefInd", "VerFlag", "ComFlag", "UpdFlag", "QCFlag", "QASFlag", "ValFlag", "RefFlag", "LKFlag1", "LKFlag2", "LKFlag3", "LKFlag4", "LKFlag5", "OImage001", "Image001"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", img1_orig, img1}, conData)
        mdbInsert(JobName, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "OImage001", "Image001"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), img1_orig, img1}, conCBat)
        mdbInsert("origImage", New String() {"OImage001", "Image001"}, New String() {img1_orig, img1}, conCBat)
        mdbInsert("data001", New String() {"Recnum"}, New String() {rec}, conData)
    End Sub
#End Region

#Region "TWO PAGES"
    Private Sub proc_2p(ByVal rec As Integer, ByVal mdb As Integer, ByVal img1_orig As String, ByVal img2_orig As String)
        Dim img1, img2 As String
        img1 = ((rec * 2) - 1).ToString("00000000.##") & ".tif"
        img2 = (rec * 2).ToString("00000000.##") & ".tif"
        mdbInsert(JobName, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "RefInd", "VerFlag", "ComFlag", "UpdFlag", "QCFlag", "QASFlag", "ValFlag", "RefFlag", "LKFlag1", "LKFlag2", "LKFlag3", "LKFlag4", "LKFlag5", "OImage001", "Image001", "OImage002", "Image002"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", img1_orig, img1, img2_orig, img2}, conData)
        mdbInsert(JobName, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "OImage001", "Image001", "OImage002", "Image002"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), img1_orig, img1, img2_orig, img2}, conCBat)
        mdbInsert("origImage", New String() {"OImage001", "Image001", "OImage002", "Image002"}, New String() {img1_orig, img1, img2_orig, img2}, conCBat)
        mdbInsert("data001", New String() {"Recnum"}, New String() {rec}, conData)
    End Sub
#End Region

#End Region

#Region "FINAL"
    Private Sub bat_LastPart(ByVal img As Integer, ByVal rec As Integer, ByVal mdb As String)
        If conData IsNot Nothing Then If conData.State = ConnectionState.Open Then conData.Close()
        Dim qry As String = ""

        If Not E1only Then
            My.Computer.FileSystem.CopyDirectory(DataPath & JobFolders.E1, DataPath & JobFolders.C1, True)
            My.Computer.FileSystem.CopyDirectory(DataPath & JobFolders.E1, DataPath & JobFolders.E2, True)
        End If

        mdbOpen(Application.StartupPath & "\CBATCH" & "\" & JobName & ".mdb", conn)
        If File.Exists(Application.StartupPath & "\CBATCH" & "\" & JobName & ".mdb") = False Then
            mdbCreate(Application.StartupPath & "\CBATCH" & "\" & JobName & ".mdb")
            mdbCreateTable(JobName, New String() {"ZipFile-text(70)", "DvdName-text(70)", "SeqNo1-text(70)", "SeqNo2-text(70)", "Jobcode-text(70)", "Client-text(70)", "TotalImages-text(70)", "TotalRecord-text(70)", "BatchCount-text(70)", "BatchDate-text(70)", "BatchSize-text(70)", "ImageCount-text(70)", "RecordCount-text(70)"}, conn)
        End If
        mdbInsert(JobName, New String() {"ZipFile", "DvdName", "SeqNo1", "SeqNo2", "Jobcode", "Client", "TotalImages", "TotalRecord", "BatchCount", "BatchDate", "BatchSize", "ImageCount", "RecordCount"}, New String() {zipFile, dvdName, dateTime2, zipFile, MNJOBCODE, MNCLIENT, img, rec, mdb, dateTime2, bat_Size, img, rec}, conn)

        CreateCBatchCSV()

        If conData.State = ConnectionState.Open Then conData.Close()
        If conCBat.State = ConnectionState.Open Then conCBat.Close()
    End Sub
#End Region

#End Region
#Region "Function/Sub for Batching"



    Private Function check_Zipfile(ByVal path As String, ByVal zipFile As String) As Boolean
        If Not File.Exists(path & JobName & EXT.mdb) Then Return True
        mdbOpen(path & JobName & EXT.mdb, conn)
        Dim tmpDT As New DataTable
        mdbToDT("SELECT ZipFile FROM " & JobName, tmpDT, conn)
        For i As Integer = 0 To tmpDT.Rows.Count - 1
            If zipFile = tmpDT.Rows(i).Item(0).ToString Then
                If MsgBox("Batch File: " & zipFile & " is Already Batched....." & vbNewLine & "   Do You Want To Rebatch??", "Already Batched", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    reBatch = False
                Else
                    reBatch = True
                End If
                Exit For
            Else
                reBatch = True
            End If
        Next
        Return reBatch
    End Function

    Private Function countAllImages()
        Dim imgcount As Integer
        For Each i As DataGridViewRow In dgvBSEL.Rows
            imgcount += i.Cells(1).Value
        Next
        Return imgcount
    End Function
#End Region
End Class
