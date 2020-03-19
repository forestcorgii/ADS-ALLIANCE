Imports System.IO

Public Class VERIFYP

#Region "Entry Setup"
    Private Sub ShowLogin()
        frmLogin.ShowDialog()
        If Not frmLogin.DialogResult = DialogResult.Yes Then
            closeForm = True
        ElseIf frmLogin.DialogResult = DialogResult.Yes Then
            Me.WindowState = FormWindowState.Maximized
            USERID = frmLogin.txtOperator.Text
            LOCID = frmLogin.txtLocation.Text
            setup(ClientDIR)
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
                If ZonalCon.State = ConnectionState.Open Then ZonalCon.Close()
                If NonZonalCon.State = ConnectionState.Open Then NonZonalCon.Close()
                'conn, conData, conClient, conCBat
            End If
        End If
        writeResult(solvedMismatch, "")
        interupted("Exit Button")
    End Sub

    Private Sub ENRTY_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EXE = My.Settings.EXE
        setProperty(Me.Name)
        ClientDIR = Application.StartupPath & "\SRC\"
        IO.Directory.CreateDirectory(ClientDIR)
        setup(ClientDIR)

        saveTempCoordinate(True)
        If MNCLIENT = "" Then
            Me.Close()
        Else
            entry_setup()
        End If
    End Sub

    Private Sub entry_setup()
        openMailingFiles()
        AppName = String.Format("{0}-{1}-NET", DEFJOB, EXE)
        ShowLogin()
        '   LookupSetup()

        If closeForm Then Me.Close() Else mnOpen.PerformClick()
        If EXE = "QC" Then
            menuEdit.ShortcutKeys = Keys.F4
        Else
            menuEdit.ShortcutKeys = Keys.Control Or Keys.F3
        End If
    End Sub
#End Region

    Private Sub openMailingFiles()
        Dim xlsxpaths() As String = IO.Directory.GetFiles("C:\ADS\ALLIANCE\Cell2\MAILING FILES\", "*.xlsx")
        ExcelOpen(xlsxpaths(0), NonZonalCon)
        ExcelOpen(xlsxpaths(1), ZonalCon)
        ExcelOpen(xlsxpaths(2), thirdMailingFile)
        thirdMailingFile.Open()
        NonZonalCon.Open()
        ZonalCon.Open()
    End Sub

#Region "Controls"
    Private Sub StartEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnCompare.Click
        Dim tmpMode As mymode
        If EXE = "COM" Then tmpMode = mymode.Compare_Mode Else tmpMode = mymode.QC_Mode
        If checkFlag(tmpMode) Then
            set_mode(tmpMode)
            startLog(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename))
            startRunning() 'LOG
            'If tmpMode = mymode.Compare_Mode Or tmpMode = mymode.QC_Mode Then
            '    get_mdbRec(dt_Rec)
            '    If collectMismatch(dt_Rec) Then
            '        RunComparison(dt_Rec, 0)
            '    Else
            '        MsgBox("No mismatch found")
            '        writeResult(solvedMismatch)
            '        set_mode(mymode.Browse_Mode)
            '    End If
            'Else
            '    get_mdbRec(0)
            If Not Mode = mymode.Edit_Mode Then
                get_mdbRec(0)
            End If

            If collectMismatch(dt_Rec) Then
                RunComparison(dt_Rec, 0)
            Else
                RunComparison(0, 0)
                MsgBox("No mismatch found")
                set_mode(mymode.Browse_Mode)
                ' End If
            End If
        End If
    End Sub

    Private Sub OPENToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnOpen.Click
        If conData IsNot Nothing AndAlso conData.State = ConnectionState.Open Then conData.Close()
        If conClient IsNot Nothing AndAlso conClient.State = ConnectionState.Open Then conClient.Close()

retry:  Dim ask As DialogResult = OFD1.ShowDialog()
        If ask = DialogResult.OK Then
            clearEntryDGV()
          
            filename = OFD1.FileName
            Dim tmp As New DirectoryInfo(filename)
            If tmp.Parent.Name <> entryFolder Then
                MsgBox("Please Select Database From " & entryFolder & " Folder")
                GoTo retry
            ElseIf IsFileOpen(New FileInfo(filename)) Then
                MsgBox("File is in use.")
                GoTo retry
            ElseIf Not mdbOpen(filename, conData, True) Then
                MsgBox("File is in use.")
                GoTo retry
            End If

            lblMdb.Text = OFD1.FileName
            Me.Text = String.Format("ALLIANCE-{0}-NET - {1}", EXE, OFD1.FileName)
            mdbName = tmp.Name
            zipFile = tmp.Parent.Parent.Name
            img_path = tmp.Parent.Parent.FullName & "\" & JobFolders.I1
            zipFileToJobcode(zipFile)
            If MNJOBCODE = "" Then
                MsgBox("Unknown Batchfile.")
                GoTo retry
            Else
                '   getLeaflet()
                refresh_DT(conData)
                If isOldVersion() Then
                    MsgBox("This data comes from the old version.")
                    GoTo retry
                End If
                openEntryData(tmp.Parent.Parent.FullName, mdbName)

                If checkFlag() Then
                    TOTALRECORD = dtData001.Rows.Count
                    set_mode(mymode.Browse_Mode)
                End If
            End If
        End If
    End Sub

    Private Function isOldVersion() As Boolean
        If EXE = "QC" Then
            Try
                dtData001.Rows(0).Item("accounts8").ToString()
                Return False
            Catch ex As Exception
                Return True
            End Try
        End If
    End Function

    Private Sub EditRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnRecompare.Click
        If Mode = mymode.Browse_Mode Then
            Dim tmpMode As mymode = mymode.Edit_Mode
            If checkFlag(tmpMode) Then
                set_mode(tmpMode)
                startLog(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename))
                startRunning() 'LOG
                If EXE = "COM" Then
                    If collectMismatch(dt_Rec, True) Then
                        RunComparison(dt_Rec, 0)
                    Else
                          MsgBox("No mismatch found")
                        writeResult(solvedMismatch)
                        set_mode(mymode.Browse_Mode)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BrowseModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBrowse.Click
        Select Case Mode
            Case mymode.KI_Mode, mymode.Tick_Mode, mymode.Validation_Mode
                PublicDGV.Rows.Clear()
                set_mode(mymode.Browse_Mode)
            Case Else
                If msgBoxOUT("Current record will not be save. Do You want to continue?", "Wait", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    writeResult(solvedMismatch, "")
                    interupted("Browse Mode Button(F9)")
                    set_mode(mymode.Browse_Mode)
                End If
        End Select
    End Sub

    Private Sub menuGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnGoto.Click
        Dim rec As String = msgBox_in("Go to:", , "1-" & TOTALRECORD, False, True)
        If rec.Trim <> "" Then
            Try
                get_mdbRec(Val(rec - 1))
            Catch
                MsgBox("Invalid Input")
            End Try
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

        If Not Running Then
            If Not autoNext And Not e.KeyCode = Keys.F11 And Not e.KeyCode = Keys.F10 And Not e.KeyCode = Keys.Enter And Not e.KeyCode = Keys.Up Then
                Exit Sub
            ElseIf Mode = mymode.QC_Mode Or Mode = mymode.REQC_Mode Or Mode = mymode.Compare_Mode Or (EXE = "COM" And (Mode = mymode.Edit_Mode Or Mode = mymode.Recompare_Mode)) Then
                ' txtValue.Enabled = False
            End If
            '  Running = True
            If Not PublicTB.WithSpaces And e.KeyCode = Keys.Space Then
                e.Handled = True
                e.SuppressKeyPress = True
            End If
            If Not Mode = mymode.Browse_Mode Then
                If e.KeyCode = Keys.F10 And EXE = "COM" And Not autoNext Then
                    Using val As New ValClass(FIELDNAME, CurrentFieldValueE1)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            addtoMatchList(JobFolders.E1, nextRecord)

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.F10 And autoNext And EXE = "COM" Then
                    Using val As New ValClass(FIELDNAME, Chr(13), CurrentFieldValueE1)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            addtoMatchList(JobFolders.E1, nextRecord)

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.F11 And autoNext And EXE = "COM" Then
                    Using val As New ValClass(FIELDNAME, Chr(13), CurrentFieldValueE2)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            addtoMatchList(JobFolders.E2, nextRecord)

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.F11 And Not autoNext And EXE = "COM" Then
                    Using val As New ValClass(FIELDNAME, CurrentFieldValueE2)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            addtoMatchList(JobFolders.E2, nextRecord)

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.Enter And Not autoNext Then
                    Using val As New ValClass(FIELDNAME, EDATA)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            If PublicTB.Modified = False Then
                                addtoMatchList(JobFolders.E1, nextRecord)
                            Else
                                addtoMatchList("Editted", nextRecord)
                            End If

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.Enter And autoNext Then
                    Using val As New ValClass(FIELDNAME, Chr(e.KeyCode), EDATA)
                        If val.invalid Then
                            e.SuppressKeyPress = True
                            Running = False
                        Else
                            Dim nextRecord As Boolean = False
                            If PublicTB.Modified = False Then
                                addtoMatchList(JobFolders.E1, nextRecord)
                            Else
                                addtoMatchList("Editted", nextRecord)
                            End If

                            If val.isPullout Then
                                val.pullout(EDATA)
                                RunComparison(dt_Rec, 0)
                            Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                            End If
                        End If
                    End Using
                ElseIf e.KeyCode = Keys.Up Then
                    e.SuppressKeyPress = True
                End If
            End If
        End If

        If e.KeyCode = Keys.F10 Then e.SuppressKeyPress = True
        If EXE = "QC" And Mode = mymode.Edit_Mode Then
                If e.KeyCode = Keys.Up Then
                Do While fromMailingFiles(dgv.Rows(CurrentRow).Cells(0).Value, dgv.Rows(CurrentRow).Cells(1).Value)
                    Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            CurrentRow = getRowByField("cor_flag")
                            Exit Do
                        Case "client_ref"
                            If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                        Case Else : Exit Do
                    End Select
                Loop
                'Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                '        CurrentRow = getRowByField("cor_flag")
                'End Select
                ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
                Do While fromMailingFiles(dgv.Rows(CurrentRow).Cells(0).Value, dgv.Rows(CurrentRow).Cells(1).Value)
                    Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            CurrentRow = getRowByField("uk_nat_tick")
                            Exit Do '      CurrentRow += 1
                        Case "client_ref"
                            If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                            Case Else : Exit Do
                        End Select
                Loop
            End If
            End If
       End Sub

    Private Sub txtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue.KeyPress
        If e.KeyChar = Chr(8) Or e.Handled Then Exit Sub
        If autoNext And Asc(e.KeyChar) <> 13 Then
            Using val As New ValClass(FIELDNAME, e.KeyChar, EDATA)
                e.Handled = True '    CurrentRow += 1
                If val.invalid Then
                    Running = False
                Else
                    Dim nextRecord As Boolean = False
                    addtoMatchList("Editted", nextRecord)
                    If val.isPullout Then
                        val.pullout(EDATA)
                        RunComparison(dt_Rec, 0)
                    Else : RunComparison(dt_Rec, CurrentRow + 1, nextRecord)
                    End If
                End If
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

    Private Sub mnSave_Click(sender As Object, e As EventArgs) Handles mnSave.Click
        ForceSAVE()
    End Sub

    Private Sub dtg1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.LostFocus
        regainFocus()
    End Sub

    Private Sub txtValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.LostFocus
        regainFocus()
    End Sub

    Private Sub regainFocus(Optional ByVal s As Integer = 1)
        s = s * 1000
        Timer.Interval = s
        Timer.Enabled = True
        Timer.Start()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        Select Case Mode
            Case mymode.Edit_Mode, mymode.Compare_Mode, mymode.Recompare_Mode, mymode.QC_Mode, mymode.REQC_Mode
                txtValue.Focus()
            Case mymode.Browse_Mode
                dgv.Focus()
        End Select
        Timer.Stop()
        Timer.Enabled = False
    End Sub
End Class
