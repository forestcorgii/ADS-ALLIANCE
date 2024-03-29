Imports System.IO
Imports System.Data.OleDb

Module Process
    Public Running As Boolean = False

#Region "Save"
    Public Sub ForceSAVE()
        If mymode.Edit_Mode Or mymode.Entry_Mode Then
            forceSaving = True
            Using val As New ValClass(FIELDNAME, EDATA)
                If Not val.invalid Then
                    SAVE(Mode)
                End If
            End Using
            forceSaving = False
        End If
    End Sub

    Public Sub SAVE(ByVal mode As Integer)
        Select Case mode
            Case mymode.Entry_Mode
                saveENTRY()
                get_mdbRec(dt_Rec + 1)
                CurrentRow = 0
            Case mymode.Edit_Mode
                Dim ask As DialogResult
                If EXE = "QC" Then ask = msgBoxOUT("Do You want to save?", "Save", MsgBoxStyle.YesNo) Else ask = DialogResult.Yes
                If ask = MsgBoxResult.Yes Then
                    saveEDIT()
                    get_mdbRec(dt_Rec)
                    set_mode(mymode.Browse_Mode)
                ElseIf ask = DialogResult.No Then
                    set_mode(mymode.Browse_Mode)
                End If
            Case mymode.Compare_Mode, mymode.Recompare_Mode
                saveCOMPARE()
                get_mdbRec(dt_Rec + 1)
            Case mymode.QC_Mode, mymode.REQC_Mode
                saveQC()
                get_mdbRec(dt_Rec + 1)
        End Select
    End Sub

    Public Sub saveENTRY()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If i.Cells(1).Value Is Nothing Then i.Cells(1).Value = ""
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & "")
                val.Add(i.Cells(1).Value.replace("'", "''") & "")
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        mdbUpdate(MNJOBCODE, New String() {"KeyFlag", "KeyID", "KeyDate", "LocID1"}, New Object() {Flag, USERID, PresentDATETIME, LOCID}, New Object() {"RecNum", mdb_Rec}, conData)

        refresh_DT(conData)
        If CURRENTRECORD = TOTALRECORD Then
            MsgBox("All data has been keyed")
            set_mode(mymode.Browse_Mode)
        End If
    End Sub

    Public Sub saveEDIT()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If i.Cells(1).Value Is Nothing Then i.Cells(1).Value = ""
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & "")
                val.Add(i.Cells(1).Value.replace("'", "''") & "")
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, mdb_Rec), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"UpdFlag", "UpdID", "UpdDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", mdb_Rec}, conData)

        ' MsgBox("Saved.")
        writeResult(solvedMismatch)
        refresh_DT(conData)
    End Sub

    Public Sub saveCOMPARE()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If i.Cells(1).Value Is Nothing Then i.Cells(1).Value = ""
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & "")
                val.Add(i.Cells(1).Value.replace("'", "''") & "")
            End If
        Next

        For Each E1fld As String In FieldsE1
            If Not fld.Contains(E1fld) Then
                fld.Add(E1fld & vbNullString)
                val.Add(dtDataE1.Rows(dt_Rec).Item(E1fld).ToString.Replace("'", "''") & vbNullString)
            End If
        Next


        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT ComFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, mdb_Rec), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"ComFlag", "ComID", "ComDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", mdb_Rec}, conData)

        refresh_DT(conData)

        If CURRENTRECORD = TOTALRECORD Then
            MsgBox("All data has been Compared.")
            writeResult(solvedMismatch)
            set_mode(mymode.Browse_Mode)
        End If
    End Sub

    Public Sub saveQC()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If i.Cells(1).Value Is Nothing Then i.Cells(1).Value = ""
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & "")
                val.Add(i.Cells(1).Value.replace("'", "''") & "")
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT QCFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, mdb_Rec), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"QCFlag", "QCID", "QCDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", mdb_Rec}, conData)

        refresh_DT(conData)

        If CURRENTRECORD = TOTALRECORD Then
            MsgBox("All data has been QC-ed.")
            set_mode(mymode.Browse_Mode)
        End If
    End Sub

#End Region

#Region "Compare/QC Function/Subs"
    Public Sub openEntryData(ByVal path As String, ByVal mdb As String)
        mdbOpen(String.Format("{0}\{1}\{2}", path, JobFolders.E1, mdb), conE1)
        mdbOpen(String.Format("{0}\{1}\{2}", path, JobFolders.E2, mdb), conE2)

        mdbToDT(String.Format("SELECT * FROM {0}", MNJOBCODE), dtCBatchE1, conE1)
        mdbToDT(String.Format("SELECT * FROM {0}", MNJOBCODE), dtCBatchE2, conE2)
        mdbToDT("SELECT * FROM Data001", dtDataE1, conE1)
        mdbToDT("SELECT * FROM Data001", dtDataE2, conE2)
    End Sub

    Public Sub clearEntryDGV()
        PublicDGV.Rows.Clear()
        If (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = VERIFYP.Name Or MNFORM.Name = QCP.Name) Then
            PublicDGVE1.Rows.Clear()
            PublicDGVE1.Rows.Clear()
        ElseIf (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = VERIFYL.Name Or MNFORM.Name = QCL.Name) Then
        End If
    End Sub

    Public Sub loadEntryFields()
        PublicDGVE1.Rows.Clear()
        PublicDGVE2.Rows.Clear()

        If (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = VERIFYP.Name Or MNFORM.Name = QCP.Name) Then
            For Each rw As DataGridViewRow In PublicDGV.Rows
                If rw.Cells(0).Value.ToUpper = "KIDPCODE" And Not zipFile.Substring(zipFile.Length - 1) = "K" Then
                    Continue For
                Else
                    PublicDGVE1.Rows.Add(rw.Cells(0).Value)
                    PublicDGVE2.Rows.Add(rw.Cells(0).Value)
                End If
            Next
        ElseIf (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = VERIFYL.Name Or MNFORM.Name = QCL.Name) Then
        End If
    End Sub

    Public Sub loadEntryData(ByVal rw As Integer)
        Dim IDE1, IDE2, IDCOM, IDQC As String
        Dim UPDIDE1, UPDIDE2, UPDIDCOM, UPDIDQC As String

        IDE1 = dtCBatchE1.Rows(dt_Rec).Item("KeyId").ToString
        IDE2 = dtCBatchE2.Rows(dt_Rec).Item("KeyId").ToString
        IDCOM = dtCBatch.Rows(dt_Rec).Item("ComId").ToString
        IDQC = dtCBatch.Rows(dt_Rec).Item("QCId").ToString

        UPDIDE1 = dtCBatchE1.Rows(dt_Rec).Item("UpdId").ToString
        UPDIDE2 = dtCBatchE2.Rows(dt_Rec).Item("UpdId").ToString
        UPDIDCOM = dtCBatch.Rows(dt_Rec).Item("UpdId").ToString
        UPDIDQC = dtCBatch.Rows(dt_Rec).Item("UpdId").ToString

        If EXE = "COM" Then
            PublicDGV.Columns(1).HeaderText = "COMPARE DATA BY: " & IIf(UPDIDCOM = "", IDCOM, UPDIDCOM)

        ElseIf EXE = "QC" Then
            PublicDGV.Columns(1).HeaderText = "QC DATA BY: " & IIf(UPDIDQC = "", IDQC, UPDIDQC)
        End If

        If (EXE = "COM" Or EXE = "QC") And (Orientation = "P") Then
            PublicDGVE1.Columns(1).HeaderText = "ENTRY 1 DATA BY: " & IIf(UPDIDE1 = "", IDE1, UPDIDE1)
            PublicDGVE2.Columns(1).HeaderText = "ENTRY 2 DATA BY: " & IIf(UPDIDE2 = "", IDE2, UPDIDE2)

            For i As Integer = 0 To PublicDGV.Rows.Count - 1
                If Not PublicDGV.Rows(i).Cells(0).Value = "" Then
                    PublicDGVE1.Rows(i).Cells(1).Value = dtDataE1.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'") & ""
                    PublicDGVE2.Rows(i).Cells(1).Value = dtDataE2.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'") & ""
                End If
            Next
        ElseIf (EXE = "COM" Or EXE = "QC") And (Orientation = "L") Then
            PublicDGV.Columns(2).HeaderText = "ENTRY 1 DATA BY: " & IIf(UPDIDE1 = "", IDE1, UPDIDE1)
            PublicDGV.Columns(3).HeaderText = "ENTRY 2 DATA BY: " & IIf(UPDIDE2 = "", IDE2, UPDIDE2)


            For i As Integer = 0 To PublicDGV.Rows.Count - 1
                If Not PublicDGV.Rows(i).Cells(0).Value = "" Then
                    PublicDGV.Rows(i).Cells(2).Value = dtDataE1.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'") & ""
                    PublicDGV.Rows(i).Cells(3).Value = dtDataE2.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'") & ""
                End If
            Next
        End If
    End Sub

#Region "RUNNING"
#Region "MATCHING CLASS"
    Public mismatchList As New List(Of mList)
    Public matchList As New List(Of String)
    Public solvedMismatch As New List(Of mList)

    Public Class mList
        Public record As Integer
        Public fieldname As String

        Public E1 As String
        Public E2 As String
        Public Compare As String
        Public CompareResult As String

        Public ReadOnly Property name()
            Get
                Return String.Format("{0}{1}", record, fieldname)
            End Get
        End Property
    End Class
#End Region

    Public Function collectMismatch(Optional startingRecord As Integer = 0, Optional editMode As Boolean = False) As Boolean
        solvedMismatch = New List(Of mList)
        mismatchList = New List(Of mList)
        matchList = New List(Of String)

        For rw As Integer = startingRecord To dtData001.Rows.Count - 1
            For Each fld As String In FieldsE2
                Dim E1VALUE As String = dtDataE1.Rows(rw).Item(fld).ToString
                Dim E2VALUE As String = dtDataE2.Rows(rw).Item(fld).ToString
                Select Case fld : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                    Case Else
                        If Not E1VALUE.Trim = E2VALUE.Trim Then
                            Dim m As New mList
                            m.record = rw
                            m.fieldname = fld
                            mismatchList.Add(m)
                            If rw < startingRecord Then matchList.Add(m.name)
                        End If
                End Select
            Next
            If editMode And startingRecord = rw Then Exit For
        Next

        Return Not mismatchList.Count = 0
    End Function

    Public Sub RunComparison(startingRecord As Integer, startingRow As Integer, Optional isNextRecord As Boolean = False)
        If Mode = mymode.QC_Mode Or Mode = mymode.REQC_Mode Or Mode = mymode.Compare_Mode Or (EXE = "COM" And (Mode = mymode.Edit_Mode Or Mode = mymode.Recompare_Mode)) Then
            Running = True
            Dim MatchingDone As Boolean = False
            If isNextRecord Then startingRow = 0
            For Each m As mList In mismatchList
                If Not matchList.Contains(m.name) And m.record >= startingRecord Then
                    If Not m.record = startingRecord Then
                        For i As Integer = startingRecord To TOTALRECORD - 1
                            If m.record > i Then
                                If Mode = mymode.Compare_Mode Or startingRecord = i Then 'Mode = mymode.Compare_Mode Or Mode = mymode.QC_Mode) Or startingRecord = i Then
                                    If Not startingRecord = i Then
                                        get_mdbRec(i)
                                    End If
                                    fillCompareValue(startingRow)
                                    SAVE(Mode)
                                    startingRow = 0
                                End If
                            ElseIf m.record = i Then
                                get_mdbRec(i)
                                startingRow = 0
                                Application.DoEvents()
                                Exit For
                            End If
                        Next
                    End If
                    For cl As Integer = startingRow To PublicDGV.Rows.Count - 1
                        If FieldsE2.Contains(PublicDGV.Rows(cl).Cells(0).Value) Then
                            If Not m.fieldname = PublicDGV.Rows(cl).Cells(0).Value Then
                                fillCompareRowValue(cl)
                            ElseIf m.fieldname = PublicDGV.Rows(cl).Cells(0).Value Then
                                CurrentRow = cl
                                '           Exit For
                            End If
                        End If
                    Next
                    Exit For
                Else
                    If m.record = startingRecord + 1 Then 'Or m.record = startingRecord Then
                        SAVE(Mode)
                        startingRow = 0
                    End If
                    If mismatchList(mismatchList.Count - 1).name = m.name Then
                        MatchingDone = True
                    End If
                End If
            Next

            Running = False
            If MatchingDone Then
                runRemainingRecords(startingRow)
            ElseIf mismatchList.Count = 0 Then
                runRemainingRecords(startingRow)
                '            writeResult(solvedMismatch)
            Else
                load_FieldInfo()
            End If
        End If
    End Sub

    Private Sub runRemainingRecords(startingRow As Integer)
        If Mode = mymode.Edit_Mode Then
            SAVE(Mode)
        ElseIf Not Mode = mymode.Browse_Mode Then
            Dim startingRecord As Integer = dt_Rec
            For i As Integer = startingRecord To TOTALRECORD - 1
                If (Mode = mymode.Compare_Mode Or Mode = mymode.QC_Mode Or Mode = mymode.Recompare_Mode Or Mode = mymode.REQC_Mode) Or startingRecord = i Then
                    If Not startingRecord = i Then get_mdbRec(i)
                    If startingRecord = i Then
                        fillCompareValue(startingRow)
                    Else:fillCompareValue(0)
                    End If
                    SAVE(Mode)
                End If
            Next
            If Not Mode = mymode.Browse_Mode Then
                get_mdbRec(TOTALRECORD - 1)
                MsgBox("All data has been Compared.")
                writeResult(solvedMismatch)
                set_mode(mymode.Browse_Mode)
            End If
        End If
    End Sub

    Public Sub addtoMatchList(ByVal result As String, ByRef isNextRecord As Boolean, Optional isPullout As Boolean = False)
        If EXE = "COM" Or (EXE = "QC" And Not Mode = mymode.Edit_Mode) Then
            Dim m As New mList
            m.record = dt_Rec
            m.fieldname = CurrentField

            m.Compare = CurrentFieldValue
            m.E1 = CurrentFieldValueE1
            m.E2 = CurrentFieldValueE2

            m.CompareResult = result

            solvedMismatch.Add(m)
            matchList.Add(String.Format("{0}{1}", dt_Rec, CurrentField))
            If (CurrentRow + 1) = PublicDGV.Rows.Count Then
                SAVE(Mode)
                CurrentRow = 0
                isNextRecord = True
            Else : isNextRecord = False
            End If
        End If
    End Sub

    Public Sub fillCompareValue(result As String)
        Select Case result.ToUpper
            Case "ENTRY 1"
                CurrentFieldValue = CurrentFieldValueE1
            Case "ENTRY 2"
                CurrentFieldValue = CurrentFieldValueE1
            Case "EDITTED"
                CurrentFieldValue = PublicTB.Text
        End Select
    End Sub

    Public Sub fillCompareValue(Optional startingRow As Integer = 0)
        If EXE = "COM" Then 'And Mode = mymode.Compare_Mode Then
            For i As Integer = startingRow To PublicDGVE1.Rows.Count - 1
                Select Case PublicDGV.Rows(i).Cells(0).Value : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                    Case "client_ref"
                        Dim data As String() = populateData(PublicDGVE1.Rows(i).Cells(1).Value.ToString)
                        If Not data(1) = "" Then
                            If Not data(0) = "" Then setValueByField("forename", data(0))
                            If Not data(1) = "" Then setValueByField("surname", data(1))
                            If Not data(2) = "" Then setValueByField("accounts1", data(2))
                            If Not data(3) = "" Then setValueByField("accounts2", data(3))
                            If Not data(4) = "" Then setValueByField("accounts3", data(4))
                            If Not data(5) = "" Then setValueByField("accounts4", data(5))
                            If Not data(6) = "" Then setValueByField("accounts5", data(6))
                            If Not data(7) = "" Then setValueByField("accounts6", data(7))
                            If Not data(8) = "" Then setValueByField("accounts7", data(8))
                            If Not data(9) = "" Then setValueByField("accounts8", data(9))
                            If Not data(10) = "" Then setValueByField("client_ref", data(10))
                            mdbUpdate("MailingFilesData", New String() {"forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8", "client_ref"}, data, New Object() {"Recnum", mdb_Rec}, conData)
                            refresh_DT(conData)
                        Else
                            If FieldsE2.Contains(PublicDGVE1.Rows(i).Cells(0).Value) Then
                                PublicDGV.Rows(i).Cells(1).Value = PublicDGVE1.Rows(i).Cells(1).Value.ToString
                            End If
                        End If
                    Case Else
                        If FieldsE2.Contains(PublicDGVE1.Rows(i).Cells(0).Value) Then
                            PublicDGV.Rows(i).Cells(1).Value = PublicDGVE1.Rows(i).Cells(1).Value.ToString
                        End If
                End Select
            Next
        End If
    End Sub

    Public Sub fillCompareRowValue(ByVal i As Integer)
        If EXE = "COM" Then 'And Mode = mymode.Compare_Mode Then
            Select Case PublicDGV.Rows(i).Cells(0).Value : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                Case "client_ref"
                    Dim data As String() = populateData(PublicDGVE1.Rows(i).Cells(1).Value.ToString)
                    If Not data(1) = "" Then
                        If Not data(0) = "" Then setValueByField("forename", data(0))
                        If Not data(1) = "" Then setValueByField("surname", data(1))
                        If Not data(2) = "" Then setValueByField("accounts1", data(2))
                        If Not data(3) = "" Then setValueByField("accounts2", data(3))
                        If Not data(4) = "" Then setValueByField("accounts3", data(4))
                        If Not data(5) = "" Then setValueByField("accounts4", data(5))
                        If Not data(6) = "" Then setValueByField("accounts5", data(6))
                        If Not data(7) = "" Then setValueByField("accounts6", data(7))
                        If Not data(8) = "" Then setValueByField("accounts7", data(8))
                        If Not data(9) = "" Then setValueByField("accounts8", data(9))
                        If Not data(10) = "" Then setValueByField("client_ref", data(10))
                        mdbUpdate("MailingFilesData", New String() {"forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8", "client_ref"}, data, New Object() {"Recnum", mdb_Rec}, conData)
                        refresh_DT(conData)
                    Else
                        If FieldsE2.Contains(PublicDGVE1.Rows(i).Cells(0).Value) Then
                            PublicDGV.Rows(i).Cells(1).Value = PublicDGVE1.Rows(i).Cells(1).Value.ToString
                        End If
                    End If
                Case Else
                    PublicDGV.Rows(i).Cells(1).Value = PublicDGVE1.Rows(i).Cells(1).Value.ToString
            End Select
        End If
    End Sub

#Region "COMPARE LOG"
    Public logWriter As StreamWriter
    Public logPath As String
    Public Function compareMode() As String
        Select Case Mode
            Case mymode.Compare_Mode
                Return "Compare"
            Case mymode.Recompare_Mode
                Return "Recompare"
        End Select
        Return ""
    End Function

    Public Sub startLog(ByVal dir As String, ByVal filename As String)
        If EXE = "COM" Then
            logPath = String.Format("{0}\{1}.log", dir, Path.GetFileNameWithoutExtension(filename))
            If Not My.Computer.FileSystem.FileExists(logPath) Then
                logWriter = File.CreateText(logPath)
                logWriter.WriteLine(String.Format("┌{0}┐", FillSpaces("─", 205, "─")))
                logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Opened At {1} By: {2}", logPath, PresentDATETIME, USERID), 205)))
                logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 205, "─")))
            Else
                logWriter = File.AppendText(logPath)
            End If
        End If
    End Sub

    Public Sub startRunning()
        If EXE = "COM" Then
            logWriter.WriteLine(String.Format("┌{0}┐", FillSpaces("─", 205, "─")))
            logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Started At {1} By: {2}", compareMode, PresentDATETIME, USERID), 205)))
            logWriter.WriteLine(String.Format("├{0}┬{1}┬{2}┬{3}┬{4}┬{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
            logWriter.WriteLine(String.Format("│{0}│{1}│{2}│{3}│{4}│{5}│", FillSpaces("  Record", 10), FillSpaces("   Field", 20), FillSpaces("   Entry 1", 50), FillSpaces("   Entry 2", 50), FillSpaces("   Compare", 50), FillSpaces("   Result", 20)))
            logWriter.WriteLine(String.Format("├{0}┼{1}┼{2}┼{3}┼{4}┼{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
        End If
    End Sub

    Public Sub writeResult(ByRef ml As List(Of mList), Optional endReason As String = "COMPARE ENDED")
        Try
            If EXE = "COM" Then
                If Not ml.Count = 0 And logWriter IsNot Nothing Then
                    For Each m As mList In ml
                        If Not m.CompareResult = "" Then
                            logWriter.WriteLine(String.Format("│{0}│{1}│{2}│{3}│{4}│{5}│", FillSpaces(m.record + 1, 10), FillSpaces(m.fieldname, 20), FillSpaces(m.E1, 50), FillSpaces(m.E2, 50), FillSpaces(m.Compare, 50), FillSpaces(m.CompareResult, 20)))
                        End If
                    Next
                Else
                    NoMismatch()
                End If
                If endReason = "COMPARE ENDED" Then
                    endRunning()
                ElseIf endReason = "INTERUPTED" Then

                End If
            End If
        Catch: End Try    
    End Sub

    Public Sub endRunning()
        If EXE = "COM" Then
            logWriter.WriteLine(String.Format("├{0}┴{1}┴{2}┴{3}┴{4}┴{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
            logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Finished At {1} By: {2}", compareMode, PresentDATETIME, USERID), 205)))
            logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 205, "─")))
            logWriter.Close()
            logWriter.Dispose()
        End If
    End Sub

    Public Sub interupted(ByVal abortReason As String)
        If EXE = "COM" And Not Mode = mymode.Browse_Mode Then
            logWriter.WriteLine(String.Format("├{0}┴{1}┴{2}┴{3}┴{4}┴{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
            logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Aborted At {1} PM User pressed : {2}", compareMode, PresentDATETIME, abortReason), 205)))
            logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 205, "─")))
            logWriter.Close()
            logWriter.Dispose()
        End If
    End Sub

    Public Sub NoMismatch()
        If Mode = mymode.Compare_Mode Or Mode = mymode.Edit_Mode Or Mode = mymode.Recompare_Mode Then
            logWriter.WriteLine(String.Format("│{0}│", FillSpaces("NO MISMATCH FOUND !!!", 205)))
        End If
    End Sub
#End Region
#End Region
#End Region

#Region "Entry Functions/Subs"
    Public Function fromMailingFiles(field As String, value As String) As Boolean
        Select Case field : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                Return True
            Case "client_rec"
                '    Dim _mailingFileValue As String = mailingFilesData.Rows(dt_Rec).Item(field).ToString
                '  Return _mailingFileValue = value And Not value = ""
        End Select
        Return False
      End Function

    Public Function get_Field(Optional ByVal rw As Integer = -1)
        Try
            If rw = -1 Then rw = CurrentRow()
            Return PublicDGV.Rows(rw).Cells(0).Value
        Catch ex As Exception
            Return "ERROR!!"
        End Try
    End Function

    Public Sub refresh_DT(ByVal con As OleDbConnection)
        dtData001 = New DataTable
        dtCBatch = New DataTable
        mailingFilesData = New DataTable
        mdbToDT("SELECT * FROM MailingFilesData", mailingFilesData, con)
        mdbToDT("SELECT * FROM Data001", dtData001, con)
        mdbToDT("SELECT * FROM " & MNJOBCODE, dtCBatch, con)
    End Sub

    Public Sub load_Image(Optional ByVal page As String = "1")

        Dim imgVwerImagePath As String = "" 'ENTRY.imgVwer.ImagePath
        Dim img_name As String = ""
        Select Case page
            Case "1", ""
                img_name = dtCBatch.Rows(dt_Rec).Item("Image001").ToString
            Case "2"
                img_name = dtCBatch.Rows(dt_Rec).Item("Image002").ToString
        End Select
        If Not imgVwerImagePath = img_path & "\" & img_name Then
            PublicImgVwer.ImagePath = img_path & "\" & img_name
        End If
        IMAGENAME = img_name
    End Sub

    Public Sub load_Data()
        If PublicDGV.Rows.Count <> 0 Then currentrows = CurrentRow()
        If Not Running Then load_Image()
        With dtData001.Rows(dt_Rec)

            Dim tmpList As New List(Of String)
            If mdb_Rec = 1 And mdbName = "00000001.mdb" And headerFields IsNot Nothing Then
                loadHeaderFields()
            Else
                If PublicDGV.Rows.Count = 0 Then
                    loadFields()
                    loadEntryFields()
                    loadEntryData(dt_Rec)
                Else
                    For i As Integer = 0 To PublicDGV.Rows.Count - 1
                        If PublicDGV.Rows(i).Cells(0).Value <> "" Then
                            PublicDGV.Rows(i).Cells(1).Value = .Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'")
                        End If
                    Next
                    loadEntryData(dt_Rec)
                End If
            End If

            If currentrows <= PublicDGV.Rows.Count - 1 Then
                CurrentRow = currentrows
            End If
            If Not Running Then load_FieldInfo()
        End With
    End Sub

    Private Sub loadHeaderFields()
        clearEntryDGV()
        If MNJOBCODEINFO.Headerfields.Item(0) <> "" Then
            For Each i As String In headerFields
                PublicDGV.Rows.Add(i, dtData001.Rows(dt_Rec).Item(i).ToString)
            Next
        Else
            For Each i As String In Fields
                If Not MNJOBCODEINFO.Headerfields.Contains(i) Then
                    PublicDGV.Rows.Add(i, dtData001.Rows(dt_Rec).Item(i).ToString)
                End If
            Next
        End If
    End Sub

    Private Sub loadFields()
          For Each i As String In Fields
            If i.ToUpper = "KIDPCODE" And Not zipFile.Substring(zipFile.Length - 1) = "K" Then
                Continue For
            Else
                PublicDGV.Rows.Add(i, dtData001.Rows(dt_Rec).Item(i).ToString & "")
            End If
        Next
    End Sub

    Private DEFH As Integer = 658
    Private DEFW As Integer = 975

    Private tempX, tempY As Integer
    Private tempZ As Double

    Public Sub set_coordinate(ByVal fld As String)
        For i As Integer = 0 To dtCoordinate.Rows.Count - 1
            If dtCoordinate.Rows(i).Item("Field") = fld Then
                Dim tmpArr() As String = dtCoordinate.Rows(i).Item("Coordinate").ToString.Split(",")
                Try
                    Dim p As Integer = Integer.Parse(tmpArr(0))
                    Dim x As Integer = Integer.Parse(tmpArr(1))
                    Dim y As Integer = Integer.Parse(tmpArr(2))
                    Dim z As Double = Double.Parse(tmpArr(3))

                    If Not Mode = mymode.KI_Mode Then load_Image(p)
                    PublicImgVwer.Origin = New Point(x, y)
                    PublicImgVwer.ZoomFactor = z
                Catch ex As Exception
                    If TC IsNot Nothing Then
                        If TC.X <> 0 Or TC.Y <> 0 Then
                            PublicImgVwer.Origin = New Point(TC.X, TC.Y)
                            PublicImgVwer.ZoomFactor = TC.Z
                        End If
                    Else
                    End If
                End Try
                Exit Sub
            End If
        Next
    End Sub
    Public Sub load_FieldInfo()
        If CurrentRow = -1 Then Exit Sub
        If CurrentRow() > PublicDGV.RowCount - 1 Or CurrentRow() < 0 Then Exit Sub

        Dim fld As String = PublicDGV.Rows(CurrentRow).Cells(0).Value.ToString
        Dim fl As New FieldInfo
        For Each flList As FieldInfo In MNJOBINFO.Fields
            If flList.Fieldname = fld Then
                fl = flList
                FIELDNAME = fld
                Exit For
            End If
        Next
        Try
            With fl
                If Mode = mymode.KI_Mode Then
                    set_coordinate(fld)
                    Exit Sub
                ElseIf Mode = mymode.Entry_Mode Or Mode = mymode.Edit_Mode Then
                    setLookUp(fl.Haslookup)
                    PublicTB.Focus()
                    PublicTB.SelectAll()
                End If

                If CurrentFieldValue.ToUpper = "SECOND PAGE" Then
                    load_Image(2)
                    Exit Try
                End If

                VIEWFORM = .Description
                addViewform(fld)
                set_coordinate(fld)
                autoNext = Boolean.Parse(.Autonext)

                PublicTB.CharacterCasing = Integer.Parse(.Casing.Substring(0, 1))
                PublicTB.MaxLength = .Maxlength
                PublicTB.Character = chrType(.Character)
                PublicTB.OtherCharacter = .OtherCharacter

                def_Value = .DefaultValue
                num_Format = .Numberformat
                charPerIndex = .Validcharperindex
                Haslookup = .Haslookup
                PO_Key = .Pulloutkey

                Select Case CurrentField.ToUpper
                    Case "NI_NUMBER", "PERSONAL_IDENTIFIER1", "PERSONAL_IDENTIFIER2", "PERSONAL_IDENTIFIER3"
                        PublicTB.WithSpaces = False
                    Case Else
                        PublicTB.WithSpaces = True
                End Select
            End With

            If EXE = "COM" Then
                If Mode = mymode.Browse_Mode Then
                    EDATA = CurrentFieldValue
                Else : EDATA = CurrentFieldValueE1
                End If
            Else : EDATA = CurrentFieldValue
            End If

            PublicTB.Focus()
            PublicTB.SelectAll()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try

        VERIFYP.lbViewForm.Update()
        VERIFYP.dgv.Update()
        PublicTB.Update()
    End Sub
    Private Function chrType(v As String) As Integer
        Select Case v.ToUpper
            Case "ALPHA"
                Return 0
            Case "NUMERIC"
                Return 1
            Case "ALPHANUMERIC"
                Return 2
            Case "ALLOWALL"
                Return 3
            Case "NONE"
                Return 4
            Case Else
                Return 0
        End Select
    End Function

    Public populatedFromMailingFile As Boolean = False
    Public Sub get_mdbRec(Optional ByVal Rec As Integer = 0)
        On Error Resume Next
        If Rec >= 0 And Rec < dtData001.Rows.Count Then
            dt_Rec = Rec
            CURRENTRECORD = Rec + 1
            mdb_Rec = dtData001.Rows(dt_Rec).Item("Recnum").ToString
            populatedFromMailingFile = mailingFilesData.Rows(dt_Rec).Item("extra01").ToString = "1"
            load_Data()
            Application.DoEvents()
        End If
    End Sub

#Region "Modes"
    Public Sub startQC()
        Dim alreadyKeyed As Boolean = True

        CurrentRow = 0
        Dim i As Integer = 0
        For i = 0 To dtCBatch.Rows.Count - 1
            With dtCBatch.Rows(i)
                If .Item("QCFlag").ToString = "0" Then
                    alreadyKeyed = False
                    get_mdbRec(i)
                    load_Data()
                    Exit For
                End If
            End With
        Next

        If alreadyKeyed Then
            If msgBoxOUT("All Records has been QCed", "Compare") = DialogResult.Yes Then
                set_mode(mymode.REQC_Mode)
            Else
                set_mode(mymode.Browse_Mode)
            End If
        ElseIf Not alreadyKeyed Then
            set_mode(mymode.QC_Mode)
        End If
    End Sub

    Public Sub startCompare()
        Dim alreadyKeyed As Boolean = True

        CurrentRow = 0
        Dim i As Integer = 0
        For i = 0 To dtCBatch.Rows.Count - 1
            With dtCBatch.Rows(i)
                If .Item("ComFlag").ToString = "0" Then
                    alreadyKeyed = False
                    get_mdbRec(i)
                    load_Data()
                    Exit For
                End If
            End With
        Next

        If alreadyKeyed Then
            If msgBoxOUT("All Records has been Compared", "Compare") = DialogResult.Yes Then
                set_mode(mymode.Recompare_Mode)
            Else
                set_mode(mymode.Browse_Mode)
            End If
        ElseIf Not alreadyKeyed Then
            set_mode(mymode.Compare_Mode)
        End If
    End Sub

    Public Sub startEntry()
        Dim alreadyKeyed As Boolean = True

        CurrentRow = 0
        Dim i As Integer = 0
        For i = 0 To dtCBatch.Rows.Count - 1
            With dtCBatch.Rows(i)
                If Not .Item("KeyFlag").ToString = Flag Then
                    alreadyKeyed = False
                    get_mdbRec(i)
                    load_Data()
                    Exit For
                End If
            End With
        Next
        If alreadyKeyed Then
            MsgBox("All Records has been Keyed")
            set_mode(mymode.Browse_Mode)
        Else
            set_mode(mymode.Entry_Mode)
        End If
    End Sub

    Public Function checkFlag(Optional ByRef md As mymode = mymode.Browse_Mode) As Boolean
        Select Case EXE
            Case "E1"
                If dtCBatch.Rows(dt_Rec).Item("KeyFlag").ToString = Flag Then
                    If "12*".Contains(PublicDGV.Rows(0).Cells(1).Value) And PublicDGV.Rows(0).Cells(1).Value <> "" Then CurrentRow = 0
                    If "*".Contains(PublicDGV.Rows(getRowByField("Code")).Cells(1).Value) And PublicDGV.Rows(getRowByField("Code")).Cells(1).Value <> "" Then setRowByField("Code")
                    Return True
                Else
                    MsgBox("This record has not been keyed")
                    Return False
                End If
            Case "COM"
                For i As Integer = 0 To dtCBatch.Rows.Count - 1
                    If dtCBatchE1.Rows(i).Item("KeyFlag").ToString = "" Then
                        MsgBox("Entry 1 Data is not yet finish")
                        Return False
                    ElseIf dtCBatchE2.Rows(i).Item("KeyFlag").ToString = "" Then
                        MsgBox("Entry 2 Data is not yet finish")
                        Return False
                    End If
                Next

                Select Case md
                    Case mymode.Compare_Mode
                        Dim dt As New DataTable
                        mdbToDT("SELECT * FROM " & MNJOBCODE & " WHERE ComFlag = '0'", dt, conData)
                        If Not dt.Rows.Count = 0 Then
                            get_mdbRec((From res In dt Where res.Item("ComFlag").ToString = 0 Select res.Item(0)).ToList(0) - dtCBatch.Rows(0).Item(0))
                            Return True
                        Else
                            If msgBoxOUT("All data has been Compared.. Do You want to Recompare?") = MsgBoxResult.Yes Then
                                md = mymode.Recompare_Mode
                                get_mdbRec(0)
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Case mymode.Edit_Mode
                        If Not dtCBatch.Rows(dt_Rec).Item("ComFlag").ToString = "0" Then
                            Return True
                        Else
                            MsgBox("This record has not been keyed")
                            Return False
                        End If
                    Case mymode.Browse_Mode
                        Return True
                End Select
            Case "QC"
                For i As Integer = 0 To dtCBatch.Rows.Count - 1
                    If dtCBatch.Rows(i).Item("ComFlag").ToString = 0 Then
                        MsgBox("Compare Data is not yet finish")
                        Return False
                    End If
                Next

                Select Case md
                    Case mymode.QC_Mode
                        Dim dt As New DataTable
                        mdbToDT("SELECT * FROM " & MNJOBCODE & " WHERE QCFlag = '0'", dt, conData)
                        If Not dt.Rows.Count = 0 Then
                            get_mdbRec((From res In dt Where res.Item("QCFlag").ToString = 0 Select res.Item(0)).ToList(0) - dtCBatch.Rows(0).Item(0))
                            Return True
                        Else
                            If msgBoxOUT("All data has been QC-ed.. Do You want to Re-QC?") = MsgBoxResult.Yes Then
                                md = mymode.REQC_Mode
                                Return True
                            Else
                                Return False
                            End If
                        End If
                    Case mymode.Edit_Mode
                        If "*".Contains(PublicDGV.Rows(0).Cells(1).Value) And PublicDGV.Rows(0).Cells(1).Value <> "" Then CurrentRow = 0
                        If "1".Contains(PublicDGV.Rows(1).Cells(1).Value) And PublicDGV.Rows(1).Cells(1).Value <> "" Then CurrentRow = 1
                        If CurrentField = "exception" And getValueByField("cor_flag") = "2" Then
                            CurrentRow -= 1
                        End If
                        Do While fromMailingFiles(PublicDGV.Rows(CurrentRow).Cells(0).Value, PublicDGV.Rows(CurrentRow).Cells(1).Value)
                            Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                                    CurrentRow = getRowByField("uk_nat_tick")
                                    Exit Do
                                  Case "client_ref"
                                    If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                                Case Else : Exit Do
                            End Select
                        Loop
                        Return True
                    Case mymode.Browse_Mode
                        Return True
                End Select
        End Select
        Return True
    End Function
#End Region



#End Region

    Public Function IsFileOpen(ByVal file As IO.FileInfo) As Boolean
        Dim stream As IO.FileStream = Nothing
        Try
            stream = file.Open(IO.FileMode.Open, IO.FileAccess.ReadWrite, IO.FileShare.None)
            stream.Close()
        Catch ex As Exception
            Return True
        End Try
        Return False
    End Function

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

    Public Sub setValueByField(ByVal fld As String, ByVal txt As String)
        For Each rw As DataGridViewRow In PublicDGV.Rows
            If rw.Cells(0).Value = fld Then
                rw.Cells(1).Value = txt
                Exit For
            End If
        Next
    End Sub

    Public Sub setRowByField(ByVal fld As String)
        For Each rw As DataGridViewRow In PublicDGV.Rows
            If rw.Cells(0).Value = fld Then
                CurrentRow = rw.Index
            End If
        Next
    End Sub

    Public Function getRowByField(ByVal fld As String) As Integer
        For Each rw As DataGridViewRow In PublicDGV.Rows
            If rw.Cells(0).Value = fld Then
                Return rw.Index
            End If
        Next
        Return 0
    End Function

    Public Function getValueByField(ByVal fld As String) As String
        For Each rw As DataGridViewRow In PublicDGV.Rows
            If rw.Cells(0).Value = fld Then
                If rw.Cells(1).Value IsNot Nothing Then
                    Return rw.Cells(1).Value.ToString
                Else
                    Return ""
                End If
            End If
        Next
        Return 0
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

#Region "Additional Feature(Temporary) For PP(Bounty)"
    Public TC As TemporaryCoordinate
    Public Class TemporaryCoordinate
        Public X As Integer
        Public Y As Integer
        Public Z As Double
    End Class

    Public Sub AdditionalControl(ByVal e As KeyEventArgs)
        Select Case Mode
            Case mymode.Browse_Mode
            Case mymode.Entry_Mode, mymode.Edit_Mode
                If MNJOBCODEINFO.Twopages Then
                    If e.Control AndAlso e.KeyCode = Keys.P Then
                        load_Image(2)
                    ElseIf e.Control AndAlso e.KeyCode = Keys.O Then
                        load_Image(1)
                    End If
                End If
        End Select

      
        If e.KeyCode = Keys.F12 Then
            saveTempCoordinate()
        End If
    End Sub

    Public Sub saveTempCoordinate(Optional noPrompt As Boolean = False)
        TC = New TemporaryCoordinate
        TC.X = Xorigin
        TC.Y = Yorigin
        TC.Z = zoomFactor
        If Not noPrompt Then
            msgBoxOUT(String.Format("Coordinate Saved. {0}X: {1} Y: {2} Zoom Factor: {3}", vbNewLine, TC.X, TC.Y, TC.Z), "Successfully saved", MessageBoxButtons.OK)
        End If

        PublicDGV.Focus()
    End Sub

    Public Sub addViewform(ByVal fld As String)
        Select Case fld.ToUpper
            Case "PERSONAL_IDENTIFIER1", "PERSONAL_IDENTIFIER2", "COUNTRY1", "COUNTRY2", "ACCOUNTS1", "ACCOUNTS2"
                VIEWFORM &= vbNewLine & vbNewLine & "F6 = If there's no Info"
        End Select
        If EXE = "COM" Then
            VIEWFORM &= vbNewLine & vbNewLine & String.Format("{0}{1}{2}", "F10/Enter - Entry 1", vbNewLine, "F11 - Entry 2")
        End If
    End Sub

#End Region

#Region "Check for missing images"
    Public Function checkImages() As Boolean
        Dim img404 As Boolean
        Dim img404list As New List(Of String)

        For Each rw As DataRow In dtCBatch.Rows
            If MNJOBCODEINFO.Twopages Then
                If Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image001").ToString)) Then
                    img404list.Add(rw.Item("Image001").ToString)
                    img404 = True
                End If
                If Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image002").ToString)) Then
                    img404list.Add(rw.Item("Image002").ToString)
                    img404 = True
                End If
            Else
                If Not File.Exists(String.Format("{0}\{1}", img_path, rw.Item("Image001").ToString)) Then
                    img404list.Add(rw.Item("Image001").ToString)
                    img404 = True
                End If
            End If
        Next
        If img404 Then
            Dim compile404 As String = ""
            For Each i As String In img404list
                compile404 &= i & Environment.NewLine
            Next
            MsgBox(String.Format("Missing/Corrupted Images in {0}{1}{2}", img_path, Environment.NewLine & Environment.NewLine, compile404))
            Return False
        End If
        Return True
    End Function
#End Region

End Module
