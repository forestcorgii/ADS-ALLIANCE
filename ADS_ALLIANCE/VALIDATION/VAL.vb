Imports System.IO

Public Class VAL
#Region "Setup"
    Private Sub VAL_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClientDIR = Application.StartupPath & "\SRC\"
        setup(ClientDIR)
        '    LookupSetup()

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


#Region "Variables for Validation Process"
    Private _totalErrorCount, _pulloutCount As Integer
  #End Region

    Private Sub cmdBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBATCH.Click
        If Not dgvBSEL.RowCount = 0 Then

            USERID = msgBox_in("Enter your User ID here:", "USER ID", "4-8", False)
            If USERID = "" Then Exit Sub
            PB1.Enabled = True
            PB1.Maximum = dgvBSEL.Rows.Count
            PB1.Value = 0
            For Each BATCH As DataGridViewRow In dgvBSEL.Rows
                zipFileToJobcode(Path.GetFileNameWithoutExtension(BATCH.Cells(0).Value))
                PB2.Maximum = Directory.GetFiles(BATCH.Cells(0).Value & "\" & valFolder(), "*.mdb").Length
                PB2.Value = 0
                For Each MDB As String In Directory.GetFiles(BATCH.Cells(0).Value & "\" & valFolder(), "*.mdb")
                    Using ValOut As New ValOutputClass(MDB)
                        _totalErrorCount += ValOut._totalErrorCount
                        _pulloutCount += ValOut._pulloutCount
                    End Using
                    PB2.Value += 1
                    Application.DoEvents()
                Next
                PB1.Value += 1
                Application.DoEvents()
            Next
            MsgBox(String.Format("Done.{0}Total Pullout: {1}{2}Total Error Count:{3}", Environment.NewLine, _pulloutCount, Environment.NewLine, _totalErrorCount))
            _totalErrorCount = 0
            _pulloutCount = 0
        Else
            MsgBox("No Items To Be Validate")
        End If
    End Sub
#End Region

  
    Private Sub dgvBSEL_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvBSEL.RowsAdded
        dgvBSEL.Sort(dgvBSEL.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
End Class
