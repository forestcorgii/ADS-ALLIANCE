Imports System.IO
Imports System.Data.OleDb

Module Process

#Region "Save"
    Public Sub ForceSAVE()
        If mymode.Edit_Mode Or mymode.Entry_Mode Then
            forceSaving = True
            Using val As New ValClass(FIELDNAME, EDATA)
                If Not val.invalid Then
                    SAVE(mode)
                End If
            End Using
            forceSaving = False
        End If
    End Sub

    Public Sub SAVE(ByVal mode As mymode)
        Using finalVal As New ValClass()
            If Not finalVal.invalid Then
                setValueByField("ExRules", "0")
            End If
        End Using

        Select Case mode
            Case mymode.Entry_Mode
                saveENTRY()
                get_mdbRec(dt_Rec + 1)
                CurrentRow = 0
                Do While fromMailingFiles(ENTRY.dgv.Rows(CurrentRow).Cells(0).Value, ENTRY.dgv.Rows(CurrentRow).Cells(1).Value)
                    Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            CurrentRow += 1
                        Case "client_ref"
                            If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                        Case Else : Exit Do
                    End Select
                Loop
            Case mymode.Edit_Mode
                Dim ask As DialogResult = msgBoxOUT("Do You want to save?", "Save", MsgBoxStyle.YesNo)
                If ask = MsgBoxResult.Yes Then
                    saveEDIT()
                    get_mdbRec(dt_Rec)
                    set_mode(mymode.Browse_Mode)
                ElseIf ask = DialogResult.No Then
                    set_mode(mymode.Browse_Mode)
                End If
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

        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, mdb_Rec), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"ComFlag", "ComID", "ComDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", mdb_Rec}, conData)

        refresh_DT(conData)

        If CURRENTRECORD = TOTALRECORD Then
            MsgBox("All data has been keyed")
            set_mode(mymode.Browse_Mode)
        End If
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
        mdbUpdate("Data001", fld.ToArray, val.ToArray, New Object() {"RecNum", mdb_Rec}, conData)

        '=================CBATCH========================================================================================'
        Dim tmp As New DataTable
        Dim counter As Integer
        mdbToDT(String.Format("SELECT UpdFlag FROM {0} WHERE RecNum = {1}", MNJOBCODE, mdb_Rec), tmp, conData)
        counter = tmp.Rows(0).Item(0) + 1
        mdbUpdate(MNJOBCODE, New String() {"QCFlag", "QCID", "QCDate"}, New Object() {counter, USERID, PresentDATETIME}, New Object() {"RecNum", mdb_Rec}, conData)

        refresh_DT(conData)

        If CURRENTRECORD = TOTALRECORD Then
            MsgBox("All data has been keyed")
            set_mode(mymode.Browse_Mode)
        End If
    End Sub

#End Region

#Region "Entry Functions/Subs"
    Public Function fromMailingFiles(field As String, value As String) As Boolean
        Dim _mailingFileValue As String = mailingFilesData.Rows(dt_Rec).Item(field).ToString
        Return (_mailingFileValue = value) 'And Not value = "" ' And Not _mailingFileValue = "")Or getValueByField("cor_flag") = ""
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
        Dim imgVwerImagePath As String = ENTRY.imgVwer.ImagePath
        Dim img_name As String = ""
        Select Case page
            Case "1", "", "0"
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
                Else
                    For i As Integer = 0 To PublicDGV.Rows.Count - 1
                        If PublicDGV.Rows(i).Cells(0).Value <> "" Then
                            PublicDGV.Rows(i).Cells(1).Value = .Item(PublicDGV.Rows(i).Cells(0).Value).ToString.Replace("''", "'")
                        End If
                    Next
                End If
            End If

            If currentrows <= PublicDGV.Rows.Count - 1 Then
                CurrentRow = currentrows
            End If
            load_FieldInfo()
        End With
    End Sub

    Private Sub loadHeaderFields()
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
                PublicDGV.Rows.Add(i, dtData001.Rows(dt_Rec).Item(i).ToString)
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
                    If (TC.X <> 0 Or TC.Y <> 0) And Not Mode = mymode.KI_Mode Then
                        load_Image(1)
                        PublicImgVwer.Origin = New Point(TC.X, TC.Y)
                        PublicImgVwer.ZoomFactor = TC.Z
                    Else
                        Dim p As Integer = 0
                        Dim x As Double = 0
                        Dim y As Double = 0
                        Dim z As Double = 0

                        p = CInt(tmpArr(0))
                        x = CInt(tmpArr(1))
                        y = CInt(tmpArr(2))
                        z = Double.Parse(tmpArr(3)) * (My.Computer.Screen.Bounds.Width / 1366)

                        If Not Mode = mymode.KI_Mode Then load_Image(p)
                        PublicImgVwer.ZoomFactor = z
                        PublicImgVwer.Origin = New Point(CInt(x), CInt(y))

                    End If
                Catch ex As Exception
                    If TC.X <> 0 Or TC.Y <> 0 Then
                        PublicImgVwer.Origin = New Point(TC.X, TC.Y)
                        PublicImgVwer.ZoomFactor = TC.Z
                    End If
                End Try
                Exit Sub
            End If
        Next
        Application.DoEvents()
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
            EDATA = CurrentFieldValue
            PublicTB.SelectAll()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try

        PublicTB.Update()
        ENTRY.lbViewForm.Update()
        ENTRY.dgv.Update()
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
        End Select
    End Function

    Public populatedFromMailingFile As Boolean = False
    Public Sub get_mdbRec(Optional ByVal Rec As Integer = 0)
        If Rec >= 0 And Rec < dtData001.Rows.Count Then
            dt_Rec = Rec
            CURRENTRECORD = Rec + 1
            mdb_Rec = dtData001.Rows(dt_Rec).Item("Recnum").ToString
            populatedFromMailingFile = mailingFilesData.Rows(dt_Rec).Item("extra01").ToString = "1"
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

        Do While fromMailingFiles(ENTRY.dgv.Rows(CurrentRow).Cells(0).Value, ENTRY.dgv.Rows(CurrentRow).Cells(1).Value)
            Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                    CurrentRow += 1
                Case "client_ref"
                    If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                Case Else : Exit Do
            End Select
        Loop
    End Sub

    Public Function checkFlag() As Boolean
        Select Case MNFORM.Name.ToUpper
            Case "ENTRY"
                If dtCBatch.Rows(dt_Rec).Item("KeyFlag").ToString = Flag Then
                    If "*".Contains(PublicDGV.Rows(0).Cells(1).Value) And PublicDGV.Rows(0).Cells(1).Value <> "" Then CurrentRow = 0
                    If "1".Contains(PublicDGV.Rows(1).Cells(1).Value) And PublicDGV.Rows(1).Cells(1).Value <> "" Then CurrentRow = 1
                    If CurrentField = "exception" And getValueByField("cor_flag") = "2" Then
                        CurrentRow -= 1
                    End If

                    Do While fromMailingFiles(ENTRY.dgv.Rows(CurrentRow).Cells(0).Value, ENTRY.dgv.Rows(CurrentRow).Cells(1).Value)
                        Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                                CurrentRow += 1
                            Case "client_ref"
                                If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                            Case Else : Exit Do
                        End Select
                    Loop
                    Return True
                Else
                    MsgBox("This record has not been keyed")
                    Return False
                End If
        End Select
        Return True
    End Function
#End Region
#End Region


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

        Sub New()
            X = 0
            Y = 0
            Z = 0
        End Sub
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
            Case "PERSONAL_IDENTIFIER1", "PERSONAL_IDENTIFIER2", "COUNTRY1", "COUNTRY2", _
                 "ACCOUNTS1", "ACCOUNTS2", "ACCOUNTS3", "ACCOUNTS4", "ACCOUNTS5", "ACCOUNTS6", "ACCOUNTS7"
                VIEWFORM &= vbNewLine & vbNewLine & "F6 = If there's no Info"
        End Select
    End Sub
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
