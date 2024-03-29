Imports System.Windows.Forms
Imports System.IO
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.Diagnostics.Process

Public Class BATCHING
    Private bat_Location As String
    Private bat_Size As Integer
    Private dblog As String
    Private reBatch As Boolean = False
    Private imgloc As DirectoryInfo

#Region "Public properties"
    Public Property CLIENT() As String
        Get
            Return cbClient.Text
        End Get
        Set(ByVal value As String)
            cbClient.Text = value
        End Set
    End Property

    Public Property JOB() As String
        Get
            Return cbJob.Text
        End Get
        Set(ByVal value As String)
            cbJob.Text = value
        End Set
    End Property

    Public Property PPROGRAMMER() As String
        Get
            Return lbProgrammer.Text
        End Get
        Set(ByVal value As String)
            lbProgrammer.Text = value
        End Set
    End Property

    Public Property PC() As String
        Get
            Return lbPC.Text
        End Get
        Set(ByVal value As String)
            lbPC.Text = value
        End Set
    End Property

    Public Property BATCHSIZE() As String
        Get
            Return tbBSIZE.Text
        End Get
        Set(ByVal value As String)
            tbBSIZE.Text = value
        End Set
    End Property

    Public Property AppName() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property
#End Region

#Region "Setting Up"
    Private Sub bat_setup()
        Me.Text = String.Format("{0}-{1}-NET", MNJOB, EXE)
        cbClient.Text = MNCLIENT
        cbJob.Text = MNJOB
        lbPC.Text = MNPC
        lbTAHour.Text = MNJOBINFO.TAHour
        Me.Text = AppName
        dateTime2 = Now.ToString("yyyyMMdd")
        dateTime = Now.ToString("G")
    End Sub
#End Region

#Region "Controls"
    Private Function get_RecordCount(ByVal imgcnt As Integer) As Integer
        If recordCounts = "1img1rec" Or recordCounts = "" Then
            get_RecordCount = imgcnt
        ElseIf recordCounts = "2img1rec" Then
            get_RecordCount = imgcnt \ 2
        ElseIf recordCounts = "1img1recH" Then
            get_RecordCount = imgcnt - 1
        ElseIf recordCounts = "2img1recH" Then
            get_RecordCount = (imgcnt \ 2) - 1
        ElseIf recordCounts = "2img2recH" Then
            get_RecordCount = imgcnt - 2
        End If
        Return get_RecordCount
    End Function
    Private Sub getList(ByRef dtg1 As DataGridView, ByVal dirListPath As String)
        On Error Resume Next
        dtg1.Rows.Clear()
        Dim folders() As String
        folders = IO.Directory.GetDirectories(dirListPath, "**", SearchOption.TopDirectoryOnly)
        For Each i As String In folders
            Dim imgCount() As String = IO.Directory.GetFiles(i, "*.tif")
            ' Dim xlsxCount() As String = IO.Directory.GetFiles(i, "*.xlsx")
            Dim cntFiles As Integer = imgCount.Length
            Dim getPar As New DirectoryInfo(i)

            If imgCount.Length > 0 Then 'And xlsxCount.Length > 0 Then
                If CheckJobCode(getPar.Name) Then
                    dtg1.Rows.Add(i, cntFiles, get_RecordCount(cntFiles))
                End If
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
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click
        addSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADDALL.Click
        addAll(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLEAR.Click
        removeSelected(dgvB, dgvBSEL)
    End Sub
    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLEARALL.Click
        removeAll(dgvB, dgvBSEL)
    End Sub
    Private Sub btnPATH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPATH.Click
        Dim askBatchLoc As DialogResult = FBD1.ShowDialog()
        If askBatchLoc = DialogResult.Cancel Then
            Exit Sub
        ElseIf askBatchLoc = DialogResult.OK Then
            tbPATH.Text = FBD1.SelectedPath
        End If
    End Sub
    Private Sub DriveListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles driLB.SelectedIndexChanged
        dirLB.Path = driLB.Drive
    End Sub
    Private Sub cmdBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBATCH.Click
        If Not dgvBSEL.RowCount = 0 Then
            If Not IO.Directory.Exists(tbPATH.Text) Then
                Dim ask As DialogResult = FBD1.ShowDialog()
                If ask = DialogResult.Cancel Then
                    Exit Sub
                ElseIf ask = DialogResult.OK Then
                    tbPATH.Text = FBD1.SelectedPath
                    bat_Location = tbPATH.Text
                End If
            Else
                bat_Location = tbPATH.Text
            End If

            userID = msgBox_in("Enter your User ID here:", "USER ID", "4-8", False)
            If userID = "" Then Exit Sub

         
            PB1.Maximum = countAllImages()
            PB1.Value = 0

            bat_prep()

            MsgBox("Done" & vbNewLine & "File Processed: " & PB1.Maximum & " image(s)")
        Else
            MsgBox("No Items To Be Batch")
        End If
    End Sub
#End Region

#Region "Batching Process"

#Region "PREPARATION"
    Private Sub bat_prep()
        Dim xlsxpaths() As String = IO.Directory.GetFiles(Application.StartupPath, "*.xlsx")
        ExcelOpen(xlsxpaths(0), NonZonalCon)
        ExcelOpen(xlsxpaths(1), ZonalCon)
        ExcelOpen(xlsxpaths(2), thirdMailingFile)
        thirdMailingFile.Open()
        NonZonalCon.Open()
        ZonalCon.Open()

        For Each batch As DataGridViewRow In dgvBSEL.Rows
            lbPROCFOLDER.Text = "From " & batch.Index + 1 & " to " & dgvBSEL.RowCount & " - " & batch.Cells(0).Value
            imgloc = New DirectoryInfo(batch.Cells(0).Value)
            Application.DoEvents()
            zipFile = imgloc.Name
            dvdName = imgloc.Parent.Name
            dvdName2 = imgloc.Parent.Parent.Name
            zipFileToJobcode(zipFile)

            If Not MNJOBCODEINFO.Batchsize = "" And Not tbBSIZE.Modified Then
                bat_Size = MNJOBCODEINFO.Batchsize
            Else
                bat_Size = tbBSIZE.Text
            End If
            If check_Zipfile(Application.StartupPath & "\CBATCH\", zipFile) Then

                JobPath = String.Format("{0}\CBATCH\{1}\{2}\{3}", Application.StartupPath, MNJOBCODE, dateTime2, zipFile)
                DataPath = String.Format("{0}\{1}\{2}\{3}\{4}\", bat_Location, MNCLIENT, MNJOBCODE, dateTime2, zipFile)

                If E1only Then
                    createMultipleFolder(DataPath, New String() {JobFolders.E1, JobFolders.I1}, reBatch)
                Else
                    createMultipleFolder(DataPath, New String() {JobFolders.E1, JobFolders.E2, JobFolders.C1, JobFolders.I1}, reBatch)
                End If
                createFolder(JobPath, reBatch)

                If Not File.Exists(JobPath & "\" & zipFile & ".mdb") Then
                    mdbCreate(JobPath & "\" & zipFile & ".mdb")
                    mdbOpen(JobPath & "\" & zipFile & ".mdb", conCBat)
                End If

                mdbOpen(JobPath & "\" & zipFile & ".mdb", conCBat)
                mdbCreateTable("origImage", New String() {"OImage001-text(70)", "Image001-text(70)", "OImage002-text(70)", "Image002-text(70)"}, conCBat)
                mdbCreateTable(MNJOBCODE, New String() {"Recnum-int", "ZipFile-text(70)", "DvdName-text(70)", "BatchNo-text(70)", "OImage001-text(70)", "Image001-text(70)", "OImage002-text(70)", "Image002-text(70)"}, conCBat)

                log_Start(JobPath, zipFile, DataPath)

                bat_main(batch.Cells(0).Value, batch.Cells(1).Value, batch.Cells(2).Value)
            Else
                PB1.Maximum -= batch.Cells(1).Value
            End If
        Next
    End Sub
#End Region

#Region "MAIN PROCESS"
    Private Sub bat_main(ByVal path As String, ByVal img_count As Integer, ByVal rec_count As Integer)
        Dim imgcount, dbCount, rec_start, rec_end, rec_cnt As New Integer

        Dim imgPaths As String() = IO.Directory.GetFiles(path, "*.tif")
        
        Array.Sort(imgPaths)
        '   copyImg(imgPath, DataPath & JobFolders.I1 & "\")
        For Each img As String In imgPaths
            Dim imgname As New DirectoryInfo(img)
            Dim mdbPath, imgPath As String
            PB1.Value += 1
            Application.DoEvents()

            imgcount += 1
            imgPath = DataPath & JobFolders.I1 & "\" & imgcount.ToString("00000000.##")
            lbPROCIMG.Text = "From " & imgcount.ToString & " to " & img_count & " - " & img
            File.Copy(img, imgPath & EXT.tif, True)

            If rec_end = bat_Size * dbCount Or dbCount = 0 Then
                dbCount += 1
                mdbPath = DataPath & JobFolders.E1 & "\" & dbCount.ToString("00000000.##") & EXT.mdb
                If File.Exists(mdbPath) Then
                    File.Delete(mdbPath)
                End If
                mdbCreate(mdbPath)
                mdbOpen(mdbPath, conData)
                mdbCreateCBatch(MNJOBCODE, conData)
                mdbCreateDataTBL("Data001", New String() {"extra01", "extra02", "extra03", "extra04", "extra05"}, conData)
                mdbCreateDataTBL("MailingFilesData", New String() {"extra01", "extra02", "extra03", "extra04", "extra05"}, conData)
                If dbCount > 1 Then
                    rec_start = rec_end - (bat_Size - 1)
                    log_Write(JobPath, dbCount - 1, rec_start, rec_end, rec_cnt)
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
        log_end(JobPath, dbCount, rec_start, rec_end, rec_cnt)
        bat_LastPart(img_count, rec_count, dbCount)
    End Sub

#Region "ONE PAGE"
    Private Sub proc_1p(ByVal rec As Integer, ByVal mdb As Integer, ByVal img1_orig As String)
        Dim img1 As String
        img1 = rec.ToString("00000000.##") & ".tif"
        mdbInsert(MNJOBCODE, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "RefInd", "VerFlag", "ComFlag", "UpdFlag", "QCFlag", "QASFlag", "ValFlag", "RefFlag", "LKFlag1", "LKFlag2", "LKFlag3", "LKFlag4", "LKFlag5", "OImage001", "Image001"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", img1_orig, img1}, conData)
        mdbInsert(MNJOBCODE, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "OImage001", "Image001"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), img1_orig, img1}, conCBat)
        mdbInsert("origImage", New String() {"OImage001", "Image001"}, New String() {img1_orig, img1}, conCBat)
        '\\\\Special Case

        Dim splitted_Imagename As String() = img1_orig.Split("_")
        Dim client_ref As String = ""
        If splitted_Imagename.Length = 2 Then
            client_ref = splitted_Imagename(1)
            client_ref = client_ref.Substring(0, client_ref.Length - 4)
        End If
        mdbInsert("data001", New String() {"Recnum", "client_ref", "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8", "extra01"}, populateData(rec, client_ref), conData)
        mdbInsert("MailingFilesData", New String() {"Recnum", "client_ref", "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8", "extra01"}, populateData(rec, client_ref), conData)
        '   mdbInsert("data001", New String() {"Recnum", "client_ref"}, New String() {rec, client_ref}, conData)
    End Sub

    Public Function populateData(recnum As Integer, client_ref As String) As String()
        Dim data(12) As String
        data(0) = recnum : data(1) = "" : data(2) = "" : data(3) = "" : data(4) = "" : data(5) = "" : data(6) = "" : data(7) = "" : data(8) = "" : data(9) = "" : data(10) = "" : data(11) = "" : data(12) = ""
        If Not client_ref = "" Then
            '   Dim qry As String = String.Format("SELECT * FROM Sheet1 WHERE ClientReference='{0}'", client_ref)
            Dim thrdcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), thirdMailingFile)
            Dim Zcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), ZonalCon)
            Dim NZcmd As New OleDbCommand(String.Format("SELECT * FROM [Sheet1$] WHERE ClientReference='{0}';", client_ref), NonZonalCon)
            Dim reader As OleDbDataReader
            reader = Zcmd.ExecuteReader()
            While reader.Read()
                data(1) = reader.Item("ClientReference").ToString
                data(2) = reader.Item("Forename").ToString.Replace("'", "''")
                data(3) = reader.Item("Surname").ToString.Replace("'", "''")
                data(4) = reader.Item("Account number 1").ToString
                data(5) = reader.Item("Account number 2").ToString
                data(6) = reader.Item("Account number 3").ToString
                data(7) = reader.Item("Account number 4").ToString
                data(8) = reader.Item("Account number 5").ToString
                data(9) = reader.Item("Account number 6").ToString
                data(10) = reader.Item("Account number 7").ToString
                data(11) = reader.Item("Account number 8").ToString
                data(12) = "1"
            End While

            If data(3) = "" Then
                reader = NZcmd.ExecuteReader()
                While reader.Read()
                    data(1) = reader.Item("ClientReference").ToString
                    data(2) = reader.Item("Forename").ToString.Replace("'", "''")
                    data(3) = reader.Item("Surname").ToString.Replace("'", "''")
                    data(4) = reader.Item("Account number 1").ToString
                    data(5) = reader.Item("Account number 2").ToString
                    data(6) = reader.Item("Account number 3").ToString
                    data(7) = reader.Item("Account number 4").ToString
                    data(8) = reader.Item("Account number 5").ToString
                    data(9) = reader.Item("Account number 6").ToString
                    data(10) = reader.Item("Account number 7").ToString
                    data(11) = reader.Item("Account number 8").ToString
                    data(12) = "1"
                End While
            End If

            If data(3) = "" Then
                reader = thrdcmd.ExecuteReader()
                While reader.Read()
                    data(1) = reader.Item("ClientReference").ToString
                    data(2) = reader.Item("Forename").ToString.Replace("'", "''")
                    data(3) = reader.Item("Surname").ToString.Replace("'", "''")
                    data(4) = reader.Item("Account number 1").ToString
                    data(5) = reader.Item("Account number 2").ToString
                    data(6) = reader.Item("Account number 3").ToString
                    data(7) = reader.Item("Account number 4").ToString
                    data(8) = reader.Item("Account number 5").ToString
                    data(9) = reader.Item("Account number 6").ToString
                    data(10) = reader.Item("Account number 7").ToString
                    data(11) = reader.Item("Account number 8").ToString
                    data(12) = "1"
                End While
            End If
        End If

        Return data
     End Function
#End Region

#Region "TWO PAGES"
    Private Sub proc_2p(ByVal rec As Integer, ByVal mdb As Integer, ByVal img1_orig As String, ByVal img2_orig As String)
        Dim img1, img2 As String
        img1 = ((rec * 2) - 1).ToString("00000000.##") & ".tif"
        img2 = (rec * 2).ToString("00000000.##") & ".tif"
        mdbInsert(MNJOBCODE, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "RefInd", "VerFlag", "ComFlag", "UpdFlag", "QCFlag", "QASFlag", "ValFlag", "RefFlag", "LKFlag1", "LKFlag2", "LKFlag3", "LKFlag4", "LKFlag5", "OImage001", "Image001", "OImage002", "Image002"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", img1_orig, img1, img2_orig, img2}, conData)
        mdbInsert(MNJOBCODE, New String() {"Recnum", "ZipFile", "DvdName", "BatchNo", "OImage001", "Image001", "OImage002", "Image002"}, New String() {rec, zipFile, dvdName2, mdb.ToString("00000000.##"), img1_orig, img1, img2_orig, img2}, conCBat)
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
      
        mdbOpen(Application.StartupPath & "\CBATCH" & "\" & MNJOBCODE & ".mdb", conn)
        If File.Exists(Application.StartupPath & "\CBATCH" & "\" & MNJOBCODE & ".mdb") = False Then
            mdbCreate(Application.StartupPath & "\CBATCH" & "\" & MNJOBCODE & ".mdb")
            mdbCreateTable(MNJOBCODE, New String() {"ZipFile-text(70)", "DvdName-text(70)", "SeqNo1-text(70)", "SeqNo2-text(70)", "Jobcode-text(70)", "Client-text(70)", "TotalImages-text(70)", "TotalRecord-text(70)", "BatchCount-text(70)", "BatchDate-text(70)", "BatchSize-text(70)", "ImageCount-text(70)", "RecordCount-text(70)"}, conn)
        End If
        mdbInsert(MNJOBCODE, New String() {"ZipFile", "DvdName", "SeqNo1", "SeqNo2", "Jobcode", "Client", "TotalImages", "TotalRecord", "BatchCount", "BatchDate", "BatchSize", "ImageCount", "RecordCount"}, New String() {zipFile, dvdName, dateTime2, zipFile, MNJOBCODE, MNCLIENT, img, rec, mdb, dateTime2, bat_Size, img, rec}, conn)

        CreateCBatchCSV()

        'If NonZonalCon.State = ConnectionState.Open Then NonZonalCon.Close()
        'If ZonalCon.State = ConnectionState.Open Then ZonalCon.Close()

        If conData.State = ConnectionState.Open Then conData.Close()
        If conCBat.State = ConnectionState.Open Then conCBat.Close()
    End Sub
#End Region

#End Region

#Region "Function/Sub for Batching"
  


    Private Function check_Zipfile(ByVal path As String, ByVal zipFile As String) As Boolean
        If Not File.Exists(path & MNJOBCODE & EXT.mdb) Then Return True
        mdbOpen(path & MNJOBCODE & EXT.mdb, conn)
        Dim tmpDT As New DataTable
        mdbToDT("SELECT ZipFile FROM " & MNJOBCODE, tmpDT, conn)
        For i As Integer = 0 To tmpDT.Rows.Count - 1
            If zipFile = tmpDT.Rows(i).Item(0).ToString Then
                If msgBoxOUT("Batch File: " & zipFile & " is Already Batched....." & vbNewLine & "   Do You Want To Rebatch??", "Already Batched", MsgBoxStyle.YesNo, MessageBoxIcon.Hand) <> MsgBoxResult.Yes Then
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

    Private Sub BATCHING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If ProgrammersPriviledge Then
            If e.KeyCode = Keys.F1 Then
                showFieldMaker()
                  ElseIf e.KeyCode = Keys.F2 Then
                showJobEditor()
              End If
        End If
    End Sub

    Private Sub BATCHING_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   gatherClients(ClientDIR)
        ClientDIR = Application.StartupPath & "\SRC\"
        setup(ClientDIR)
        AppName = String.Format("{0}-{1}-NET", MNJOB, EXE)
        '    bat_setup()
        '      PC = MNCLIENTINFO.Coordinator
        '    PPROGRAMMER = MNCLIENTINFO.Programmer
    End Sub

    Private Sub showJobEditor()
        Dim tmpcon As New OleDbConnection
        If File.Exists(ClientDIR & MNCLIENT & EXT.mdb) Then
            mdbOpen(ClientDIR & MNCLIENT & EXT.mdb, tmpcon)
            Using inf As New InfoBox(cbClient.Text, cbJob.Text, tmpcon)
                inf.ShowDialog()
            End Using
            setup(ClientDIR)
        End If
     End Sub

    Public Sub showFieldMaker()
        Using cl As New fieldMaker(cbClient)
            cl.ShowDialog()
            cbClient.Items.Clear()
            For Each i As String In cl.cbCLIENT.Items
                cbClient.Items.Add(i)
            Next
            If cbClient.Items.Count > 0 Then
                cbClient.SelectedIndex = 0
            End If
        End Using
        setup(ClientDIR)
      End Sub

    Private Sub cbClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.SelectedIndexChanged
        getJobList(CLIENT)
    End Sub

    Private Sub cbJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJob.SelectedIndexChanged
        getJobInfo(JOB)
        bat_setup()
    End Sub
End Class
