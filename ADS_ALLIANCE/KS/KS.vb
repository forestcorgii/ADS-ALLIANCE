Imports System.IO

Public Class KS
#Region "Setup"
    Private Sub VAL_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClientDIR = Application.StartupPath & "\SRC\"
        setup(ClientDIR)
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

#Region "KS Process"
#Region "Variables for KS Process"
    Public jobfolder As String
#End Region

    Private Sub cmdBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBATCH.Click
        If Not dgvBSEL.RowCount = 0 Then
            Dim KV As New KSVariables

            If rbCom.Checked Then jobfolder = JobFolders.C1 Else If rbE2.Checked Then jobfolder = JobFolders.E2 Else If rbE1.Checked Then jobfolder = JobFolders.E1
            PB1.Maximum = dgvBSEL.Rows.Count
            PB1.Value = 0
            For Each BATCH As DataGridViewRow In dgvBSEL.Rows
                zipFileToJobcode(Path.GetFileName(BATCH.Cells(0).Value))
                KSPATH = String.Format("C:\ADS\ALLIANCE\{0}_{1}_{2}", MNJOBCODE, Now.ToString("yyyyMMdd"), jobfolder)
                startWriteCNT(BATCH.Index = 0)

                Using KSOUTPUT As New KSOutCLass(BATCH.Cells(0).Value, jobfolder)
                    write(Path.GetFileName(BATCH.Cells(0).Value), KSOUTPUT.RECORD, KSOUTPUT.PULLOUT, KSOUTPUT.KSPERBATCH)

                    KV.TOTALRECORD += KSOUTPUT.RECORD
                    KV.TOTALFORMS += KSOUTPUT.RECORD
                    KV.VALIDRECORD += KSOUTPUT.RECORD

                    KV.TOTALKS += KSOUTPUT.KSPERBATCH
                    KV.TOTALPULLOUT += KSOUTPUT.PULLOUT

                End Using
                PB1.Value += 1
            Next

            If Not KV.TOTALRECORD = 0 And Not KV.TOTALKS = 0 Then
                KV.AVERAGEKS = KV.TOTALKS / KV.TOTALRECORD
            End If

            If Not KV.TOTALFORMS = 0 And Not KV.TOTALKS = 0 Then
                KV.AVERAGEKSbyFORMS = KV.TOTALKS / KV.TOTALFORMS
            End If

            finishWriteCNT(KV)
            MsgBox("Done")

        Else
            MsgBox("No Items To Be Validate")
        End If
    End Sub

#End Region
End Class
