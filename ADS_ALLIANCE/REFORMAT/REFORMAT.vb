Imports System.IO

Public Class REFORMAT
#Region "Setup"

    Private Sub REFORMAT_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next

        If ZonalCon.State = ConnectionState.Open Then ZonalCon.Close()
        If NonZonalCon.State = ConnectionState.Open Then NonZonalCon.Close()
        If thirdMailingFile.State = ConnectionState.Open Then thirdMailingFile.Close()

    End Sub
    Private Sub VAL_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClientDIR = Application.StartupPath & "\SRC\"
        setup(ClientDIR)
        ' LookupSetup()
        openMailingFiles()
        'My.Application.Info.Version.
    End Sub

    Private Sub openMailingFiles()
        Dim xlsxpaths() As String = IO.Directory.GetFiles("C:\ADS\ALLIANCE\Cell2\MAILING FILES\", "*.xlsx")
        ExcelOpen(xlsxpaths(0), NonZonalCon)
        ExcelOpen(xlsxpaths(1), ZonalCon)
        ExcelOpen(xlsxpaths(2), thirdMailingFile)
        thirdMailingFile.Open()
        NonZonalCon.Open()
        ZonalCon.Open()
    End Sub
#End Region

#Region "Controls"
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

    Private Sub DriveListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles driLB.SelectedIndexChanged
        dirLB.Path = driLB.Drive
    End Sub

#End Region

#Region "Reformat Process"
#Region "Variables for Reformat Process"
    Private _totalRecord, _pulloutCount As Integer
    Private PASTBATCHDATE As String
#End Region
    Private Sub cmdBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBATCH.Click
        If Not dgvBSEL.RowCount = 0 Then
            PASTBATCHDATE = ""
            Dim newFilelist As New List(Of String)
            PB1.Maximum = dgvBSEL.Rows.Count
            PB1.Value = 0
            'For Each BATCH As DataGridViewRow In dgvBSEL.Rows
            '    Dim dirInfo As New DirectoryInfo(BATCH.Cells(0).Value)
            '    Dim batchname As String = dirInfo.Name
            '    Dim OUTPATH As String = String.Format("{0}\OUT\{1}\{2}", Application.StartupPath, MNCLIENT, JOB & "-" & batchname.Substring(0, 4))
            '    If File.Exists(String.Format("{0}\FileList\FILELIST.txt", OUTPATH)) Then
            '        If Not newFilelist.Contains(OUTPATH) Then
            '            File.Delete(String.Format("{0}\FileList\FILELIST.txt", OUTPATH))
            '            newFilelist.Add(OUTPATH)
            '        End If
            '    Else
            '        newFilelist.Add(OUTPATH)
            '    End If
            '    Using REFOUTPUT As New RefOutClass(BATCH.Cells(0).Value, PASTBATCHDATE)
            '        PASTBATCHDATE = REFOUTPUT.batchDate
            '    End Using
            '    PB1.Value += 1
            'Next
            Using REFOUTPUT As New RefOutClass(dgvBSEL, PASTBATCHDATE, PB1)
                PASTBATCHDATE = REFOUTPUT.batchDate
            End Using
            MsgBox("Done")
        Else
            MsgBox("No Items To Be Validate")
        End If
    End Sub

#End Region
End Class
