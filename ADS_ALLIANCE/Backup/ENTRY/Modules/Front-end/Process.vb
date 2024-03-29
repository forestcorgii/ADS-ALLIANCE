Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.IO.StreamReader
Imports System.IO.StreamWriter
Imports System.Text
Imports System.Diagnostics.Process
Imports System.Windows.Forms

Module Process

#Region "Save"
    Public Sub ForceSAVE()
        If mymode.Edit_Mode And mymode.Entry_Mode Then
            ForceSAVing = True
            Using val As New ValClass(FIELDNAME, EDATA)
                If Not val.invalid Then
                    SAVE(IIf(Mode = mymode.Entry_Mode, "ENTRY", "EDIT"))
                End If
            End Using
        End If
    End Sub

    Public Sub SAVE(ByVal mode As String)
        Select Case mode
            Case "ENTRY"
                saveENTRY()
                get_mdbRec(dt_Rec + 1)
                CurrentRow = 0
            Case "EDIT"
                Dim ask As DialogResult = msgBoxOUT("Do You want to save?", "Save", MsgBoxStyle.YesNoCancel)
                If ask = MsgBoxResult.Yes Then
                    saveEDIT()
                    get_mdbRec(dt_Rec)
                    set_mode(mymode.Browse_Mode)
                ElseIf ask = DialogResult.No Then
                    set_mode(mymode.Browse_Mode)
                ElseIf ask = DialogResult.Cancel Then
                    PublicTB.Undo()
                    CurrentFieldValue = EDATA
                End If
            Case "COMPARE"
                saveCOMPARE()
                RunComparison()
            Case "QC"
                saveQC()
                RunComparison()
        End Select
    End Sub

    Public Sub saveENTRY()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & vbNullString)
                val.Add(i.Cells(1).Value & vbNullString)
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", CurrentRecord}, conData)

        '=================CBATCH========================================================================================'
        mdbUpdate(MNJOBCODE, New String() {"KeyFlag", "KeyID", "KeyDate", "LocID1"}, New Object() {Flag, userID, PresentDATETIME, locID}, New Object() {"RecNum", CurrentRecord}, conData)
        ' MsgBox("Saved.")
        refresh_DT(conData)
    End Sub

    Public Sub saveEDIT()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & vbNullString)
                val.Add(i.Cells(1).Value & vbNullString)
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", CurrentRecord}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, CurrentRecord), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"UpdFlag", "UpdID", "UpdDate"}, New Object() {counter, userID, PresentDATETIME}, New Object() {"RecNum", CurrentRecord}, conData)

        MsgBox("Saved.")
        refresh_DT(conData)
    End Sub


    Public Sub saveCOMPARE()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & vbNullString)
                val.Add(i.Cells(1).Value & vbNullString)
            End If
        Next

        For Each E1fld As String In FieldsE1
            If Not fld.Contains(E1fld) Then
                fld.Add(E1fld & vbNullString)
                val.Add(dtDataE1.Rows(CurrentRow).Item(E1fld).ToString & vbNullString)
            End If
        Next

        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", CurrentRecord}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, CurrentRecord), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"ComFlag", "ComID", "ComDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", CurrentRecord}, conData)

        MsgBox("Saved.")
        refresh_DT(conData)
    End Sub


    Public Sub saveQC()
        '======================Data001=================================================================================='
        Dim fld, val As List(Of String)
        fld = New List(Of String)
        val = New List(Of String)

        For Each i As DataGridViewRow In PublicDGV.Rows
            If Not i.Cells(0).Value = "" Then
                fld.Add(i.Cells(0).Value & vbNullString)
                val.Add(i.Cells(1).Value & vbNullString)
            End If
        Next
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", CurrentRecord}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, CurrentRecord), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"QCFlag", "QCID", "QCDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", CurrentRecord}, conData)

        MsgBox("Saved.")
        refresh_DT(conData)
    End Sub

#End Region

#Region "Copare/QC Function/Subs"
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
        If (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COMP.Name Or MNFORM.Name = QCP.Name) Then
            PublicDGVE1.Rows.Clear()
            PublicDGVE1.Rows.Clear()
        ElseIf (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COML.Name Or MNFORM.Name = QCL.Name) Then
        End If
    End Sub

    Public Sub loadEntryFields()
        If (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COMP.Name Or MNFORM.Name = QCP.Name) Then
            For Each rw As DataGridViewRow In PublicDGV.Rows
                PublicDGVE1.Rows.Add(rw.Cells(0).Value)
                PublicDGVE2.Rows.Add(rw.Cells(0).Value)
            Next
        ElseIf (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COML.Name Or MNFORM.Name = QCL.Name) Then
        End If
    End Sub

    Public Sub loadEntryData(ByVal rw As Integer)
        If (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COMP.Name Or MNFORM.Name = QCP.Name) Then
            PublicDGV.Columns(1).HeaderText = "COMPARE DATA BY: " & dtCBatchE1.Rows(dt_Rec).Item("ComId").ToString
            PublicDGVE1.Columns(1).HeaderText = "ENTRY 1 DATA BY: " & dtCBatchE1.Rows(dt_Rec).Item("KeyId").ToString
            PublicDGVE2.Columns(1).HeaderText = "ENTRY 2 DATA BY: " & dtCBatchE2.Rows(dt_Rec).Item("KeyId").ToString

            For i As Integer = 0 To PublicDGV.Rows.Count - 1
                If Not PublicDGV.Rows(i).Cells(0).Value = "" Then
                    PublicDGVE1.Rows(i).Cells(1).Value = dtDataE1.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString
                    PublicDGVE2.Rows(i).Cells(1).Value = dtDataE2.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString
                End If
             Next
        ElseIf (EXE = "COM" Or EXE = "QC") And (MNFORM.Name = COML.Name Or MNFORM.Name = QCL.Name) Then
            PublicDGV.Columns(1).HeaderText = "COMPARE DATA BY: " & dtCBatchE1.Rows(dt_Rec).Item("ComId").ToString
            PublicDGV.Columns(2).HeaderText = "ENTRY 1 DATA BY: " & dtCBatchE1.Rows(dt_Rec).Item("KeyId").ToString
            PublicDGV.Columns(3).HeaderText = "ENTRY 2 DATA BY: " & dtCBatchE2.Rows(dt_Rec).Item("KeyId").ToString

            For i As Integer = 0 To PublicDGV.Rows.Count - 1
                If Not PublicDGV.Rows(i).Cells(0).Value = "" Then
                    PublicDGV.Rows(i).Cells(2).Value = dtDataE1.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString
                    PublicDGV.Rows(i).Cells(3).Value = dtDataE2.Rows(rw).Item(PublicDGV.Rows(i).Cells(0).Value).ToString
                End If
            Next
        ElseIf (EXE = "E1" Or EXE = "E2") And (MNFORM.Name = ENTRY.Name) Then
            PublicDGV.Columns(1).HeaderText = "ENTRY 1 DATA BY: " & dtCBatch.Rows(dt_Rec).Item("KeyId").ToString
        End If
    End Sub
#End Region
#Region "Entry Functions/Subs"
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
        mdbToDT("SELECT * FROM Data001", dtData001, con)
        mdbToDT("SELECT * FROM " & MNJOBCODE, dtCBatch, con)
    End Sub

    Public Sub load_Image(Optional ByVal page As String = "1")
        Dim imgVwerImagePath As String = ENTRY.imgVwer.ImagePath
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
        load_Image()
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
                            PublicDGV.Rows(i).Cells(1).Value = .Item(PublicDGV.Rows(i).Cells(0).Value).ToString
                        End If
                    Next
                    loadEntryData(dt_Rec)
                End If
            End If

            If currentrows <= PublicDGV.Rows.Count - 1 Then
                CurrentRow = currentrows
            End If
            load_FieldInfo()
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
            PublicDGV.Rows.Add(i, dtData001.Rows(dt_Rec).Item(i).ToString)
        Next
    End Sub

    Public Sub set_coordinate(ByVal fld As String)
        For i As Integer = 1 To dtCoordinate.Rows.Count - 1
            If dtCoordinate.Rows(i).Item("Field") = fld Then
                Dim tmpArr() As String = dtCoordinate.Rows(i).Item("Coordinate").ToString.Split(",")
                Try
                    Dim x As Integer = Integer.Parse(tmpArr(0))
                    Dim y As Integer = Integer.Parse(tmpArr(1))
                    Dim z As Double = Double.Parse(tmpArr(2))

                    PublicImgVwer.Origin = New Point(x, y)
                    PublicImgVwer.ZoomFactor = z
                Catch ex As Exception
                    If TC IsNot Nothing Then
                        If TC.X <> 0 Or TC.Y <> 0 Then
                            PublicImgVwer.Origin = New Point(TC.X, TC.Y)
                            PublicImgVwer.ZoomFactor = TC.Z
                        End If
                    Else
                        ' PublicImgVwer.fittoscreen()
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
                Exit For
            End If
        Next
        'For ndx = 0 To dtFieldInfo.Rows.Count - 1
        '    If dtFieldInfo.Rows(ndx).Item(0).ToString = fld Then Exit For
        'Next
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

                If CurrentFieldValue = "Second Page" Then
                    load_Image(2)
                Else
                    load_Image(.Page)
                End If

                VIEWFORM = .Description
                addViewform(fld)
                set_coordinate(fld)
                autoNext = Boolean.Parse(.Autonext)

                PublicTB.CharacterCasing = Integer.Parse(.Casing.Substring(0, 1))
                PublicTB.MaxLength = .Maxlength
                def_Value = .DefaultValue
                num_Format = .Numberformat
                charPerIndex = .Validcharperindex
                Haslookup = .Haslookup
                char_Valid = .Character
                PO_Key = .Pulloutkey
                char_Other = .OtherCharacter
            End With

            FIELDNAME = fld

            If EXE = "COM" Then
                EDATA = CurrentFieldValueE1
            Else
                EDATA = CurrentFieldValue
            End If
            PublicTB.SelectAll()
        Catch ex As Exception
            '    MsgBox(ex.Message)
        End Try

        PublicTB.Update()
        ENTRY.lbViewForm.Update()
        ENTRY.dgv.Update()
    End Sub

    Public Sub get_mdbRec(Optional ByVal Rec As Integer = 0)
        If Rec >= 0 And Rec < dtData001.Rows.Count Then
            dt_Rec = Rec
            CurrentRecord = Rec + 1
            mdb_Rec = dtData001.Rows(dt_Rec).Item("Recnum").ToString
            load_Data()
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

    Public Function checkFlag() As Boolean
        Select Case MNFORM.Name.ToUpper
            Case "ENTRY"
                If dtCBatch.Rows(dt_Rec).Item("KeyFlag").ToString = Flag Then
                    If "12*".Contains(PublicDGV.Rows(0).Cells(1).Value) And PublicDGV.Rows(0).Cells(1).Value <> "" Then CurrentRow = 0
                    Return True
                Else
                    MsgBox("This record has not been keyed")
                    Return False
                End If
            Case "COML", "COMP"
                For i As Integer = 0 To dtCBatch.Rows.Count - 1
                    If dtCBatchE1.Rows(i).Item("KeyFlag").ToString = "" Then
                        MsgBox("Entry 1 Data is not yet finish")
                        Return False
                    ElseIf dtCBatchE2.Rows(i).Item("KeyFlag").ToString = "" Then
                        MsgBox("Entry 2 Data is not yet finish")
                        Return False
                    End If
                Next
            Case "QCL", "QCP"
                For i As Integer = 0 To dtCBatch.Rows.Count - 1
                    If dtCBatch.Rows(i).Item("ComFlag").ToString = "" Then
                        MsgBox("Compare Data is not yet finish")
                        Return False
                    End If
                Next
        End Select
        Return True
    End Function
#End Region


#Region "RUNNING"
#Region "MATCHING CLASS"
    Public mismatchList As List(Of mList)
    Public matchList As List(Of String)
    Public solvedMismatch As List(Of mList)

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

    Public Sub collectMismatch()
        mismatchList = New List(Of mList)
        matchList = New List(Of String)
        For rw As Integer = 0 To dtData001.Rows.Count - 1
            For Each fld As String In FieldsE2
                Dim E1VALUE As String = dtDataE1.Rows(rw).Item(fld).ToString
                Dim E2VALUE As String = dtDataE2.Rows(rw).Item(fld).ToString
                If Not E1VALUE = E2VALUE Then
                    Dim m As New mList
                    m.record = rw
                    m.fieldname = fld
                    mismatchList.Add(m)
                End If
            Next
        Next
    End Sub

    Public Sub RunComparison()
        For Each m As mList In mismatchList
            If Not matchList.Contains(m.name) Then
                For i As Integer = 0 To TOTALRECORD - 1
                    If m.record > i Then
                        get_mdbRec(i)
                        fillCompareValue()
                        SAVE(Mode)
                    ElseIf m.record = i Then
                        Exit For
                    End If
                Next

                For cl As Integer = 0 To PublicDGV.Rows.Count - 1
                    CurrentRow = cl
                    If Not m.fieldname = CurrentField Then
                        fillCompareValue(cl)
                    ElseIf m.fieldname = CurrentField Then
                        Exit For
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Public Sub addtoMatchList(ByVal result As String)
        Dim m As New mList
        m.record = dt_Rec
        m.fieldname = CurrentField

        m.Compare = CurrentFieldValue
        m.E1 = CurrentFieldValueE1
        m.E2 = CurrentFieldValueE2

        m.CompareResult = result

        solvedMismatch.Add(m)

        matchList.Add(String.Format("{0}{1}", dt_Rec, CurrentField))
    End Sub

    Public Sub fillCompareValue()
        For Each i As DataGridViewRow In PublicDGV.Rows
            CurrentRow = i.Index
            CurrentFieldValue = CurrentFieldValueE1
        Next
    End Sub

    Public Sub fillCompareValue(ByVal i As Integer)
        CurrentFieldValue = CurrentFieldValueE1
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
        logPath = String.Format("{0}\{1}.log", Dir, Path.GetFileNameWithoutExtension(filename))
        If Not My.Computer.FileSystem.FileExists(logPath) Then
            logWriter = File.CreateText(logPath)
            logWriter.WriteLine(String.Format("┌{0}┐", FillSpaces("─", 200, "─")))
            logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Opened At {1} By: {2}", logPath, PresentDATETIME, USERID), 200)))
            logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 200, "─")))
        Else
            logWriter = File.AppendText(logPath)
        End If
    End Sub

    Public Sub startRunning()
        logWriter.WriteLine(String.Format("┌{0}┐", FillSpaces("─", 200, "─")))
        logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Started At {1} By: {2}", compareMode, PresentDATETIME, USERID), 200)))
        logWriter.WriteLine(String.Format("├{0}┬{1}┬{2}┬{3}┬{4}┬{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
        logWriter.WriteLine(String.Format("│{0}│{1}│{2}│{3}│{4}│{5}│", FillSpaces("Record", 10, "─"), FillSpaces("Field", 20, "─"), FillSpaces("Entry 1", 50, "─"), FillSpaces("Entry 2", 50, "─"), FillSpaces("Compare", 50, "─"), FillSpaces("Result", 20, "─")))
        logWriter.WriteLine(String.Format("├{0}┼{1}┼{2}┼{3}┼{4}┼{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
    End Sub

    Public Sub writeResult(ByVal ml As List(Of mList))
        If Not ml.Count = 0 Then
            For Each m As mList In ml
                logWriter.WriteLine(String.Format("│{0}│{1}│{2}│{3}│{4}│{5}│", FillSpaces(m.record, 10), FillSpaces(m.fieldname, 20), FillSpaces(m.E1, 50), FillSpaces(m.E2, 50), FillSpaces(m.Compare, 50), FillSpaces(m.CompareResult, 20)))
            Next
        Else
            NoMismatch()
        End If
        endRunning()
    End Sub

    Public Sub endRunning()
        logWriter.WriteLine(String.Format("├{0}┴{1}┴{2}┴{3}┴{4}┴{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
        logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Finished At {1} By: {2}", compareMode, PresentDATETIME, USERID), 200)))
        logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 200, "─")))
        logWriter.Close()
    End Sub

    Public Sub interuptted(ByVal abortReason As String)
        logWriter.WriteLine(String.Format("├{0}┴{1}┴{2}┴{3}┴{4}┴{5}┤", FillSpaces("─", 10, "─"), FillSpaces("─", 20, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 50, "─"), FillSpaces("─", 20, "─")))
        logWriter.WriteLine(String.Format("│{0}│", FillSpaces(String.Format("{0} Aborted At {1} PM User pressed : {2}", compareMode, PresentDATETIME, abortReason), 200)))
        logWriter.WriteLine(String.Format("└{0}┘", FillSpaces("─", 200, "─")))
        logWriter.Close()
    End Sub

    Public Sub NoMismatch()
        logWriter.WriteLine(String.Format("│{0}│", FillSpaces("NO MISMATCH FOUND !!!", 200)))
    End Sub

#End Region
#End Region
#End Region


#Region "Data Manipulation"
    Public Sub changeValueByField(ByVal fld As String, ByVal txt As String)
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
                If e.Control AndAlso e.KeyCode = Keys.P Then
                    load_Image(2)
                ElseIf e.Control AndAlso e.KeyCode = Keys.O Then
                    load_Image(1)
                End If
        End Select

        If e.KeyCode = Keys.F12 Then
            saveTempCoordinate()
        End If
    End Sub

    Public Sub saveTempCoordinate()
        TC = New TemporaryCoordinate
        TC.X = Xorigin
        TC.Y = Yorigin
        TC.Z = zoomFactor
        msgBoxOUT(String.Format("Coordinate Saved. {0}X: {1} Y: {2} Zoom Factor: {3}", vbNewLine, TC.X, TC.Y, TC.Z), "Successfully saved", MessageBoxButtons.OK)
        PublicDGV.Focus()
    End Sub

    Public Sub addViewform(ByVal fld As String)
        Select Case fld
            Case "Code"
                VIEWFORM &= String.Format("{0}Leaflet Codes:{1}{2}", vbNewLine, vbNewLine, vbNewLine)
                For Each i As String In leaflet
                    VIEWFORM &= String.Format("{0}{1}", i, vbTab)
                Next
        End Select
    End Sub

#End Region
End Module
