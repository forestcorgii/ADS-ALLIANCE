Imports System.IO

Public Class ENTRY

#Region "Entry Setup"
    Sub New()
         ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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
                If thirdMailingFile.State = ConnectionState.Open Then thirdMailingFile.Close()

                'conn, conData, conClient, conCBat
            End If
        End If
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
        '       LookupSetup()
        ShowLogin()
         If closeForm Then Me.Close() Else mnOpen.PerformClick()
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

    Private Function getID() As Boolean
        USERID = msgBox_in("Input User ID here:", "User ID", "4-8", False)
        If USERID = "" Then Return False

        LOCID = msgBox_in("Input Location ID here:", "Location ID", "4-8", False)
        If LOCID = "" Then Return False
        Return True
    End Function
#End Region

#Region "Controls"
    Private Sub StartEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEntry.Click
        startEntry()
    End Sub

    Private Sub OPENToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnOpen.Click
        If conData IsNot Nothing AndAlso conData.State = ConnectionState.Open Then conData.Close()
        If conClient IsNot Nothing AndAlso conClient.State = ConnectionState.Open Then conClient.Close()

retry:  Dim ask As DialogResult = OFD1.ShowDialog()
        If ask = DialogResult.OK Then
            PublicDGV.Rows.Clear()
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

            TC = New TemporaryCoordinate
            MDBPATH = OFD1.FileName
            AppName = String.Format("{0}-{1}-NET - {2}", DEFJOB, EXE, MDBPATH)
            mdbName = tmp.Name
            zipFile = tmp.Parent.Parent.Name
            img_path = tmp.Parent.Parent.FullName & "\Images"
            BatchDate = tmp.Parent.Parent.Parent.Name
            zipFileToJobcode(zipFile)
            If MNJOBCODE = "" Then
                MsgBox("Unknown Batchfile.")
                GoTo retry
            End If
            '    getLeaflet()
            refresh_DT(conData)
            If Not checkImages() Then GoTo retry
            TOTALRECORD = dtData001.Rows.Count
            set_mode(mymode.Browse_Mode)
            get_mdbRec(0)
        End If
    End Sub

    Private Sub EditRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnEdit.Click
        If checkFlag() Then
            set_mode(mymode.Edit_Mode)
        End If
    End Sub

    Private Sub BrowseModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnBrowse.Click
        Select Case Mode
            Case mymode.KI_Mode, mymode.Tick_Mode, mymode.Validation_Mode
                PublicDGV.Rows.Clear()
                setup(ClientDIR)
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

    Private Sub menuItem_KIMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuKI.Click
        If ProgrammersPriviledge Then set_mode(mymode.KI_Mode)
    End Sub

    Private Sub menuItem_ValMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuVal.Click
        If ProgrammersPriviledge Then set_mode(mymode.Validation_Mode)
    End Sub

    Private Sub menuItem_TickMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTick.Click
        If ProgrammersPriviledge Then set_mode(mymode.Tick_Mode)
    End Sub

    Private Sub menuInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuInfo.Click
        If ProgrammersPriviledge Then Info.Show()
    End Sub

    Private Sub menuGoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnGoto.Click
        Dim rec As String = msgBox_in("Go to:", "", "1-" & TOTALRECORD, False, True)
        If rec <> "" Then
            get_mdbRec(Val(rec - 1))
        ElseIf rec > TOTALRECORD Then
            MsgBox("Out of Bound.")
        End If
    End Sub

    Private Sub menuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnSave.Click
        ForceSAVE()
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

        If Not PublicDGV.Rows.Count = 0 Then
            If e.KeyCode = Keys.Up Then
                '  If CurrentRow > 0 Then
                Do While fromMailingFiles(dgv.Rows(CurrentRow).Cells(0).Value, dgv.Rows(CurrentRow).Cells(1).Value)
                    Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            CurrentRow -= 1
                        Case "client_ref"
                            If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                        Case Else : Exit Do
                    End Select
                Loop
                'End If
            ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
                If CurrentRow < PublicDGV.Rows.Count - 1 Then
                    Do While fromMailingFiles(dgv.Rows(CurrentRow).Cells(0).Value, dgv.Rows(CurrentRow).Cells(1).Value)
                        Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                                CurrentRow += 1
                            Case "client_ref"
                                If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                            Case Else : Exit Do
                        End Select
                    Loop
                    ' If e.KeyCode = Keys.Down Then CurrentRow += 1
                End If
            End If
        End If
    End Sub

    Private Sub txtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValue.KeyPress
        If e.KeyChar = Chr(8) Or e.Handled Then Exit Sub
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
            Case mymode.KI_Mode
                kiMode_Keydown(e)
            Case mymode.Tick_Mode
                tickMode_Keydown(e)
            Case mymode.Entry_Mode, mymode.Edit_Mode
                entryMode_Keydown(e)
        End Select

        If e.KeyCode = Keys.F8 Then
            '  MsgBox(imgVwer.Width & " X " & imgVwer.Height)
        End If

        AdditionalControl(e)
    End Sub
#End Region

    Private Sub dtg1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellChanged
        load_FieldInfo()
    End Sub

#Region "KI"
    Private Sub imgVwer_Jon() Handles imgVwer.Jon
        Xorigin = imgVwer.Origin.X
        Yorigin = imgVwer.Origin.Y
        zoomFactor = imgVwer.ZoomFactor
    End Sub

    Public Sub kiMode_Keydown(ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            add_Group()
        ElseIf e.Control AndAlso e.KeyCode = Keys.E Then
            edit_group()
        ElseIf Char.IsNumber(Chr(e.KeyCode).ToString) Then
            save_group(Chr(e.KeyCode).ToString)
        End If
        Select Case e.KeyCode
            Case Keys.Left
                If mdb_Rec <> 1 Then
                    load_FieldCoord(0)
                    load_Image(1)
                    CURRENTRECORD = 1
                End If
            Case Keys.Right
                If mdb_Rec <> 2 Then
                    load_FieldCoord(1)
                    load_Image(2)
                    CURRENTRECORD = 2
                End If
            Case Keys.F7
                save_Coordinate()
        End Select
    End Sub

    Public Sub save_Coordinate()
        If MsgBox("Save this Coordinate to " & FIELDNAME & "??" & vbNewLine & Xorigin & "  " & Yorigin & "  " & zoomFactor, MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
            executeQRY("UPDATE " & MNJOBCODE & "_Coordinate SET [Coordinate] = '" & String.Format("{0},{1},{2},{3}", CURRENTRECORD, Xorigin, Yorigin, zoomFactor) & "' WHERE Field = '" & FIELDNAME & "'", conClient)
            MsgBox("Saved")
            get_group()
            load_FieldCoord(mdb_Rec - 1)
            CurrentRow = CurrentRow() + 1
        End If
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
