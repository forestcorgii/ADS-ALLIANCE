Imports System.IO

Public Class VERIFYL

#Region "Entry Setup"
    Private Sub ShowLogin()
        frmLogin.ShowDialog()
        If frmLogin.DialogResult = DialogResult.Cancel Then
            Me.Close()
        ElseIf frmLogin.DialogResult = DialogResult.Yes Then
            Me.WindowState = FormWindowState.Maximized
            USERID = frmLogin.txtOperator.Text
            LOCID = frmLogin.txtLocation.Text
        End If
    End Sub
    Private Sub ENTRY_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If Mode <> mymode.Browse_Mode And Mode <> Nothing Then
            If Mode <> mymode.Browse_Mode And msgBoxOUT("Current record will not be save. Do You want to continue?", "Exit", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            Else
                If conData.State = ConnectionState.Open Then conData.Close()
                If conClient.State = ConnectionState.Open Then conClient.Close()
                'conn, conData, conClient, conCBat
            End If
        End If
    End Sub

    Private Sub ENRTY_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setProperty(Me.Name)
        ClientDIR = Application.StartupPath & "\SRC\"
        IO.Directory.CreateDirectory(ClientDIR)
        ' setup(ClientDIR)
        saveTempCoordinate(True)
        If MNCLIENT = "" Then
            Me.Close()
        Else
            entry_setup()
        End If
    End Sub
    Private Sub entry_setup()
        AppName = String.Format("{0}-{1}-NET", DEFJOB, EXE)
        ShowLogin()

        LookupSetup()
        mnOpen.PerformClick()
    End Sub
#End Region

#Region "Controls"
    Private Sub StartEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCompare.Click
        If Mode = mymode.Browse_Mode Then
            set_mode(mymode.Entry_Mode)
        End If
    End Sub

    Private Sub OPENToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnOpen.Click
retry:  Dim ask As DialogResult = OFD1.ShowDialog()
        If ask = DialogResult.OK Then
            clearEntryDGV()
            filename = OFD1.FileName
            Dim tmp As New DirectoryInfo(filename)
            If tmp.Parent.Name <> entryFolder Then
                MsgBox("Please Select Database From " & entryFolder & " Folder")
                GoTo retry
            ElseIf Not mdbOpen(filename, conData, True) Then
                MsgBox("File is in use.")
                GoTo retry
            End If

            lblMdb.Text = OFD1.FileName
            mdbName = tmp.Name
            zipFile = tmp.Parent.Parent.Name
            img_path = tmp.Parent.Parent.FullName & "\" & JobFolders.I1
            zipFileToJobcode(zipFile)
            If MNJOBCODE = "" Then
                MsgBox("Unknown Batchfile.")
                GoTo retry
            End If
            getLeaflet()
            refresh_DT(conData)
            openEntryData(tmp.Parent.Parent.FullName, mdbName)
            TOTALRECORD = dtData001.Rows.Count
            set_mode(mymode.Browse_Mode)
        End If
    End Sub

    Private Sub EditRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRecompare.Click
        If Mode = mymode.Browse_Mode Then
            If checkFlag() Then
                set_mode(mymode.Edit_Mode)
            End If
        End If
    End Sub

    Private Sub BrowseModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBrowse.Click
        Select Case Mode
            Case mymode.KI_Mode, mymode.Tick_Mode, mymode.Validation_Mode
                PublicDGV.Rows.Clear()
                '   setup(ClientDIR)
                set_mode(mymode.Browse_Mode)
            Case Else
                If msgBoxOUT("Current record will not be save. Do You want to continue?", "Wait", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    set_mode(mymode.Browse_Mode)
                End If
        End Select
    End Sub

    Private Sub dtg1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.LostFocus
        regainFocus()
    End Sub

    Private Sub txtValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.LostFocus
        regainFocus()
    End Sub

    Private Sub menuGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnGoto.Click
        Dim rec As String = msgBox_in("Go to:", , "1-" & TotalRecord, False, True)
        If rec <> "" Then
            get_mdbRec(Val(rec - 1))
        End If
    End Sub

    Private Sub ZoomOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomOutToolStripMenuItem.Click
        imgVwer.ZoomOut()
    End Sub

    Private Sub ZoomInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomInToolStripMenuItem.Click
        imgVwer.ZoomIn()
    End Sub

    Private Sub RotateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RotateToolStripMenuItem.Click
        imgVwer.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub MoveImageToLeftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveImageToLeftToolStripMenuItem.Click
        imgVwer.MoveLeft()
    End Sub

    Private Sub MoveImageToRightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveImageToRightToolStripMenuItem.Click
        imgVwer.MoveRight()
    End Sub

    Private Sub MoveImageDownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveImageDownToolStripMenuItem.Click
        imgVwer.MoveDown()
    End Sub

    Private Sub MoveImageUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveImageUpToolStripMenuItem.Click
        imgVwer.MoveUp()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "Keydown/Keypress"
    Private Sub txtValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValue.KeyDown
        If mymode.Edit_Mode And mymode.Entry_Mode Then
            If e.KeyCode = Keys.Enter And autoNext = False Then
                Using val As New ValClass(FIELDNAME, EDATA)
                    If val.invalid Then
                        e.SuppressKeyPress = True
                    End If
                End Using
            ElseIf e.KeyCode = Keys.Enter And autoNext Then
                Using val As New ValClass(FIELDNAME, Chr(e.KeyCode), EDATA)
                    e.SuppressKeyPress = True
                End Using
            ElseIf e.KeyCode = Keys.Up Then
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub txtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue.KeyPress
        If e.KeyChar = Chr(8) Then Exit Sub
        If autoNext And Asc(e.KeyChar) <> 13 Then
            Using val As New ValClass(FIELDNAME, e.KeyChar, EDATA)
                e.Handled = True '    CurrentRow += 1
            End Using
        Else
            Using val As New ValClass(FIELDNAME, e.KeyChar)
                e.Handled = val.invalid
            End Using
        End If
    End Sub

    Private Sub ENRTY_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case Mode
            Case mymode.Browse_Mode
                browseMode_Keydown(e)
            Case mymode.Entry_Mode, mymode.Edit_Mode
                entryMode_Keydown(e)
        End Select

        AdditionalControl(e)
    End Sub
#End Region

    Private Sub dtg1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellChanged
        load_FieldInfo()
        Try
            PublicDGVE1.CurrentCell = PublicDGVE1.Item(0, CurrentRow)
            PublicDGVE2.CurrentCell = PublicDGVE2.Item(0, CurrentRow)

            PublicDGVE1.PerformLayout()
            PublicDGVE2.PerformLayout()
        Catch ex As Exception
        End Try

    End Sub

#Region "KI"
    Private Sub imgVwer_Jon() Handles imgVwer.Jon
        Xorigin = imgVwer.Origin.X
        Yorigin = imgVwer.Origin.Y
        zoomFactor = imgVwer.ZoomFactor
    End Sub
#End Region

    Private Sub regainFocus(Optional ByVal s As Integer = 1)
        s = s * 1000
        Timer.Interval = s
        Timer.Enabled = True
        Timer.Start()
    End Sub
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Select Case Mode
            Case mymode.Edit_Mode, mymode.Entry_Mode
                txtValue.Focus()
            Case mymode.Browse_Mode
                dgv.Focus()
        End Select
        Timer.Stop()
        Timer.Enabled = False
    End Sub
End Class
