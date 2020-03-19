Imports System.IO

Public Class RefOutClass
    Implements IDisposable
#Region "Pullout Strings"
    Public exflag, code, exrules As String
#End Region
#Region "Variables for Reformat Process"
    Public _totalRecord, _pulloutCount As Integer
    Public batchDate, distDate, arrDate, mdbname As String
    Public batchName, outputFilename As String
  
    Public bundle, storepack, snum As String

    Public IMAGEPATH, PULLOUTIMGPATH, EXIMGPATH As String
    Public IMG1, IMG2, OIMG1, OIMG2 As String


    Public TEMPPATH, MOTHERPATH, RULEPATH, WRITTENPATH As String
    Private currentIndex As Integer
    Private codeVersion As String = ""
#End Region

    Public Sub New(dgv As DataGridView, PASTBATCHDATE As String, ByRef pb As ProgressBar)

        outputFilename = InputBox("Output Filename:")
        If Not outputFilename = "" Then
            Dim firstRun As Boolean = True
            For b As Integer = 0 To dgv.Rows.Count - 1
                Dim BATCH As String = dgv.Rows(b).Cells(0).Value
                Dim MDBs As String() = Directory.GetFiles(BATCH & "\" & valFolder(), "*.mdb")
                If Not MDBs.Length = 0 AndAlso checkFlag(MNJOBCODE, MDBs) Then
                    codeVersion = ""
                    showIntro(BATCH, PASTBATCHDATE)
                    zipFileToJobcode(batchName)

                    '===========Flag List============'
                    PulloutList(MNJOBCODE, PulloutFlag)
                    RuleList(MNJOBCODE, RuleFlag)
                    ' WrittenList(JOBCODE, WrittenFlag)
                    '===========Field List=========='
                    PulloutFieldlist(MNJOBCODE, PulloutField)
                    RuleFieldlist(MNJOBCODE, RuleField)
                    '   WrittenFieldlist(JOBCODE, WrittenField)
                    MotherFieldlist(MNJOBCODE, MotherField)
                    '=============END==============='
                    CREATEFDIRECTORIES(String.Format("{0}\{1}\{2}\{3}\OUT", "C:", "ADS", "ALLIANCE", MNJOBCODE), firstRun)
                    OPENWRITER(String.Format("{0}\{1}\{2}\{3}\OUT", "C:", "ADS", "ALLIANCE", MNJOBCODE), firstRun)
                    CREATEHEADER(firstRun)

                    If MNJOBCODEINFO.Twopages Then
                        imgCount = 2
                    Else : imgCount = 1
                    End If

                    For Each MDB As String In MDBs
                        mdbname = Path.GetFileNameWithoutExtension(MDB)
                        mdbOpen(MDB, conData)
                        refresh_DT(conData)
                        getVersion(dtData001.Rows(0))
                        '  CREATEHEADER(b = 0 And dtData001.Rows(0).Item("Recnum").ToString = "1")
                        For i As Integer = 0 To dtData001.Rows.Count - 1
                            currentIndex = i + 1
                            GETIMAGES(i)
                            RUN(dtData001.Rows(i))
                        Next
                    Next
                    firstRun = False
                Else
                    MsgBox(String.Format("{0} is not yet Validated.", BATCH))
                End If
                pb.Value += 1
            Next
            ''==PUT REPORT=====
            'REPORT()  ' <------  HERE
            'FILELIST()

            CLOSEWRITER()       '<----|CLOSING STREAMWRITER WRITER
            DELETEEMPTYWRITER() '<----|DELETING EMPTY CSV/TXT FILES
            '=================
        End If

    End Sub

    Private Sub getVersion(ROW As DataRow)
        If codeVersion = "" Then
            Try
                ROW.Item("accounts8").ToString()
                codeVersion = "NEW"
            Catch ex As Exception
                codeVersion = "OLD"
            End Try
        End If
    End Sub

    Private Function checkMailingFiles(ROW As DataRow) As Boolean
        Dim data As String() = populateData(ROW.Item("client_ref"))
        If Not data(0) = "" Then
            If Not data(0) = ROW.Item("forename").ToString Then Return False
            If Not data(1) = ROW.Item("surname").ToString Then Return False
            If Not data(2) = ROW.Item("accounts1").ToString Then Return False
            If Not data(3) = ROW.Item("accounts2").ToString Then Return False
            If Not data(4) = ROW.Item("accounts3").ToString Then Return False
            If codeVersion = "NEW" Then
                If Not data(5) = ROW.Item("accounts4").ToString Then Return False
                If Not data(6) = ROW.Item("accounts5").ToString Then Return False
                If Not data(7) = ROW.Item("accounts6").ToString Then Return False
                If Not data(8) = ROW.Item("accounts7").ToString Then Return False
                If Not data(9) = ROW.Item("accounts8").ToString Then Return False
            End If
            Return True
        End If
        Return False
    End Function

#Region "RUN REFORMAT"
    Private imgCount As Integer = 0
    Public Sub RUN(ROW As DataRow)
        RECORDS += 1
        SHEET += imgCount
        IMAGES += imgCount

        RUNRULE(ROW)
        RUNMOTHER(ROW)
        RUNFINALVAL(ROW)
        RUNPULLOUT(ROW)
        ' RUNWRITTEN(ROW)
    End Sub

    Public Sub RUNMOTHER(ROW As DataRow)
        If Not FLAG(ROW, PulloutFlag) Then
            VALID += 1
            For Each M As FieldClass In MotherField
                If M.getFrom = getFrm.conditional And codeVersion = "NEW" Then
                    If Not M.getFrom = getFrm.temp Then MOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, M, False, False), Chr(34)))
                    TMPMOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, M, False, True), Chr(34)))
                ElseIf M.getFrom = getFrm.conditional And codeVersion = "OLD" Then
                    If Not M.getFrom = getFrm.temp Then MOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), "", Chr(34)))
                    TMPMOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), "", Chr(34)))
                Else
                    If Not M.getFrom = getFrm.temp Then MOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, M, False, False), Chr(34)))
                    TMPMOTHERWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, M, False, True), Chr(34)))
                End If
            Next

            MOTHERWRITER.Write(Environment.NewLine)
            TMPMOTHERWRITER.Write(Environment.NewLine)
        End If
    End Sub

    Private Sub RUNFINALVAL(ROW As DataRow)
        If Not checkMailingFiles(ROW) Then
            INVALID += 1
            For Each R As FieldClass In RuleField
                If Not R.getFrom = getFrm.temp Then VALWRITER.Write(GETDATA(ROW, R, True))
            Next
            VALWRITER.Write(Environment.NewLine)
        End If
    End Sub

    Public Sub RUNPULLOUT(ROW As DataRow)
        If FLAG(ROW, PulloutFlag) Then
            PULLOUT += 1
            For Each R As FieldClass In PulloutField
                If Not R.getFrom = getFrm.temp Then PULLOUTWRITER.Write(GETDATA(ROW, R, True))
            Next
            PULLOUTWRITER.Write(Environment.NewLine)
        End If
    End Sub

    Public Sub RUNRULE(ROW As DataRow)
        If Not FLAG(ROW, PulloutFlag) And (FLAG(ROW, RuleFlag) Or OTHERCONDITION(MNJOBCODE, ROW, "RULE")) And Not FLAG(ROW, WrittenFlag) Then
            RULE += 1
            For Each R As FieldClass In RuleField
                If Not R.getFrom = getFrm.temp Then REPORTWRITER.Write(GETDATA(ROW, R, True))
            Next
            REPORTWRITER.Write(Environment.NewLine)
        End If
    End Sub

    Public Sub RUNWRITTEN(ROW As DataRow)
        If FLAG(ROW, WrittenFlag) Then
            WRITTEN += 1

            For Each R As FieldClass In WrittenField
                If Not R.getFrom = getFrm.temp Then WRITTENWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, R, False), Chr(34)))
                TMPWRITTENWRITER.Write(String.Format("{0}{1}{2},", Chr(34), GETDATA(ROW, R, False, True), Chr(34)))
            Next
            WRITTENWRITER.Write(Environment.NewLine)
            TMPWRITTENWRITER.Write(Environment.NewLine)

            File.Copy(String.Format("{0}\{1}", IMAGEPATH, IMG1), String.Format("{0}\{1}", EXIMGPATH, OIMG1), True)
            If MNJOBCODEINFO.Twopages Then
                File.Copy(String.Format("{0}\{1}", IMAGEPATH, IMG2), String.Format("{0}\{1}", EXIMGPATH, OIMG2), True)
            End If
        End If
    End Sub

#Region "DATA"
    Public Function GETDATA(dt As DataRow, fld As FieldClass, fillspace As Boolean, Optional withTemp As Boolean = False) As String
        Dim NEWDATA As String = ""
        Select Case fld.getFrom
            Case getFrm.data
                NEWDATA = dt.Item(fld.name).ToString
            Case getFrm._date
                NEWDATA = dt.Item(fld.name).ToString
                If Not NEWDATA = "" Then
                    With NEWDATA
                        NEWDATA = Date.Parse(String.Format("{0}/{1}/{2}", .Substring(2, 2), .Substring(0, 2), .Substring(4, 2))).ToString("dd/MM/yyyy")
                    End With

                    If fld.name = "Dpack" And (Date.Parse(String.Format("{0}/{1}/{2}", NEWDATA.Substring(3, 2), NEWDATA.Substring(0, 2), NEWDATA.Substring(6, 2))) _
                                               > Date.Parse(String.Format("{0}/{1}/{2}", arrDate.Substring(3, 2), arrDate.Substring(0, 2), arrDate.Substring(6, 2)))) Then
                        NEWDATA = ""
                    End If
                End If
            Case getFrm.conditional
                NEWDATA = CONDITIONAL_DATA(dt, fld.name)
            Case getFrm.bool
                NEWDATA = dt.Item(fld.name).ToString
                If NEWDATA = "" Or NEWDATA = "2" Then
                    NEWDATA = "N"
                Else : NEWDATA = "Y"
                End If
            Case getFrm.gender
                NEWDATA = dt.Item(fld.name).ToString
                If NEWDATA = "2" Then
                    NEWDATA = "B"
                ElseIf NEWDATA = "1" Then
                    NEWDATA = "G"
                Else : NEWDATA = "?"
                End If
            Case getFrm.title
                NEWDATA = dt.Item(fld.name).ToString
                If NEWDATA = "" Then NEWDATA = "Ms"
            Case getFrm.other
                NEWDATA = OTHERDATA(dt, fld.name)
            Case getFrm.blank
                NEWDATA = ""
            Case getFrm.temp
                If withTemp Then NEWDATA = TEMP(dt, fld.name)
            Case Else
                NEWDATA = ""
        End Select

        If NEWDATA = "" Then NEWDATA = fld.DefaultValue

        If fillspace Then
            Return FillSpaces(NEWDATA.Replace("''", "'"), fld.length)
        Else
            Return NEWDATA.Replace("''", "'")
        End If
    End Function

    Public Function TEMP(dt As DataRow, name As String) As String
        Select Case name
            Case "record_number"
                Return currentIndex
            Case "mdb_name"
                Return mdbname & ".mdb"
        End Select
        Return ""
    End Function

    Public Function CONDITIONAL_DATA(dt As DataRow, name As String) As String
        '    Select Case name
        '    Case "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
        Return dt.Item(name).ToString
        '  End Select
        '   Return ""
    End Function

    Public Function OTHERDATA(dt As DataRow, name As String) As String
        Select Case name
            Case "Batch Number"
                Return batchName
            Case "MDB"
                Return mdbname
            Case "Record Number"
                Return dt.Item("Recnum").ToString
            Case "Mismatch Name"
                Return String.Format("{0} {1}", dt.Item("forename").ToString, dt.Item("surname").ToString)
            Case "Pullout Name"
                Return String.Format("{0} {1}", dt.Item("forename").ToString, dt.Item("surname").ToString)
            Case "batch"
                Return batchName.Substring(8)
            Case "filename"
                Return OIMG1
            Case "exception"
                If dt.Item("cor_flag").ToString = "2" Then
                    Return "1"
                Else: Return dt.Item("exception").ToString
                End If
        End Select
        Return ""
    End Function
#End Region
#End Region

#Region "REFORMAT METHODS"
#Region "CHECK FLAG"
    Public Function FLAG(dt As DataRow, exlist As List(Of FlagClass)) As Boolean
        For Each flg As FlagClass In exlist
            If flg.flag.Contains(dt.Item(flg.name).ToString) And dt.Item(flg.name).ToString <> "" Then
                Return True
            End If
        Next
        Return False
    End Function
#End Region

    Private Function getExactDate(dt As String, ByVal ddRng As String, ByVal mmRng As String, ByVal yyRng As String, ByVal format As String) As String
        Dim dd, mm, yy, maxDD As String
        maxDD = ""
        yy = dt.Substring(0, 4)
        mm = dt.Substring(4, 2)
        dd = dt.Substring(6, 2)

        yy = yy - yyRng
        If mm - mmRng <= 0 Then
            yy -= 1
            mm = (mm + 12) - mmRng
        Else
            mm = mm - mmRng
        End If

        If dd - ddRng <= 0 Then
            mm = IIf(Integer.Parse(mm) = "1", 12, mm - 1)
            dd = (dd + Date.DaysInMonth(yy, mm)) - ddRng
        Else
            dd = dd - ddRng
        End If
        If dd > Date.DaysInMonth(yy, mm) Then
            dd -= Date.DaysInMonth(yy, mm)
            mm += 1
        End If
        If dd = "0" Then dd = "30"
        If mm = "0" Then mm = "12"
        If dd.Length = 1 Then dd = "0" & dd
        If mm.Length = 1 Then mm = "0" & mm

        Return String.Format("{0}/{1}/{2}", dd, mm, yy)
    End Function

    Private Sub showIntro(path As String, Pastbdate As String)
        Dim pathInfo As New DirectoryInfo(path)
        batchDate = pathInfo.Parent.Name
        batchName = pathInfo.Name
        '  bundle = batchName.Substring(4, 5)
        IMAGEPATH = String.Format("{0}\{1}", path, JobFolders.I1)

        distDate = getExactDate(batchDate, "0", "0", "0", "dd/MM/yyyy")
        arrDate = getExactDate(batchDate, "1", "0", "0", "dd/MM/yyyy")

        If batchDate <> Pastbdate Then
            '    MsgBox(String.Format("Check Date:    DD/MM/YYYY{0}Data Capture Date: {1}{2}Arrival Date: {3}" _
            '                        , Environment.NewLine, distDate, Environment.NewLine, arrDate), MsgBoxStyle.OkOnly, batchName)
        End If
    End Sub

#End Region

#Region "REFORMAT OUTPUT"
#Region "Stream writer"
    Private MOTHERWRITER, TMPMOTHERWRITER As StreamWriter
    Private RULEWRITER, TMPRULEWRITER As StreamWriter
    Private TMPPULLOUTWRITER, PULLOUTWRITER As StreamWriter
    Private WRITTENWRITER, TMPWRITTENWRITER As StreamWriter
    Private REPORTWRITER, VALWRITER As StreamWriter

    Private Sub OPENWRITER(OUTPATH As String, isNew As Boolean)
        If isNew Then
            MOTHERWRITER = File.CreateText(String.Format("{0}\{1}.csv", OUTPATH, outputFilename))
            TMPMOTHERWRITER = File.CreateText(String.Format("{0}\{1}_INT.csv", OUTPATH, outputFilename))
            REPORTWRITER = File.CreateText(String.Format("{0}\mismatch.log", OUTPATH))
            VALWRITER = File.CreateText(String.Format("{0}\Final Validation.log", OUTPATH))
            PULLOUTWRITER = File.CreateText(String.Format("{0}\Pullout.log", OUTPATH))
            '   Else
            '   MOTHERWRITER = File.AppendText(String.Format("{0}\{1}.csv", OUTPATH, MNJOBCODE))
            '   REPORTWRITER = File.AppendText(String.Format("{0}\mismatch.log", OUTPATH))
        End If
    End Sub

    Private Sub CREATEFDIRECTORIES(OUTPATH As String, isNew As Boolean)
        If isNew Then
            MOTHERPATH = OUTPATH
            Directory.CreateDirectory(MOTHERPATH)
        End If
    End Sub

    Private Sub CREATEHEADER(isnew As Boolean)
        If isnew Then
            '=============MOTHER DATA==========='
            For Each M As FieldClass In MotherField
                If Not M.getFrom = getFrm.temp Then MOTHERWRITER.Write(String.Format("{0},", M.name))
                TMPMOTHERWRITER.Write(String.Format("{0},", M.name))
              Next

            MOTHERWRITER.Write(Environment.NewLine)
            TMPMOTHERWRITER.Write(Environment.NewLine)

            For Each R As FieldClass In RuleField
                REPORTWRITER.Write(String.Format("{0,-" & R.length & "}", R.name))
                VALWRITER.Write(String.Format("{0,-" & R.length & "}", R.name))
                '   PULLOUTWRITER.Write(String.Format("{0,-" & R.length & "}", R.name))
            Next
            REPORTWRITER.Write(Environment.NewLine)
            VALWRITER.Write(Environment.NewLine)
            ' PULLOUTWRITER.Write(Environment.NewLine)

            ''============RULE EXCEPTION========'
            'For Each R As FieldClass In RuleField
            '    TMPRULEWRITER.Write(String.Format("{0},", R.name))
            'Next
            ''==========WRITTEN EXCEPTION======='
            'For Each W As FieldClass In WrittenField
            '    TMPWRITTENWRITER.Write(String.Format("{0},", W.name))
            'Next
            ''============PULLOUT========='
            For Each P As FieldClass In PulloutField
                PULLOUTWRITER.Write(String.Format("{0,-" & P.length & "}", P.name))
            Next
            PULLOUTWRITER.Write(Environment.NewLine)

            'TMPPULLOUTWRITER.Write(Environment.NewLine)
            'TMPWRITTENWRITER.Write(Environment.NewLine)
            'TMPRULEWRITER.Write(Environment.NewLine)
            ''==============END=============================
        End If
    End Sub
#End Region

#Region "REPORTING OUTPUT"
#Region "REPORT COUNTING"
    Private SHEET, IMAGES, RECORDS As Integer
    Private VALID, RULE, WRITTEN As Integer
    '  Private CAPSCAN As Integer
    Private BLANK, PULLOUT, INVALID As Integer

    Public Sub COUNTPULLOUT()

    End Sub

    Public Sub REPORT()
        REPORTWRITER.WriteLine(String.Format("Total Sheets(including header),{0}", SHEET))
        REPORTWRITER.WriteLine(String.Format("Total Mum To Be Images ,{0}", IMAGES))
        REPORTWRITER.WriteLine(String.Format("Total Records,{0}", RECORDS))
        REPORTWRITER.WriteLine(Environment.NewLine)
        REPORTWRITER.WriteLine(String.Format("Valid Data,{0}", VALID))
        REPORTWRITER.WriteLine(String.Format("Written,{0}", WRITTEN))
        REPORTWRITER.WriteLine(String.Format("Rule-based Exclusion,{0}", RULE))
        REPORTWRITER.WriteLine(String.Format("Capscan Invalid,{0}", WRITTEN))
        REPORTWRITER.WriteLine(String.Format("Sub Total,{0}", (VALID + RULE + WRITTEN)))
        REPORTWRITER.WriteLine(String.Format("Bounty Count,{0}", IMAGES))
        REPORTWRITER.WriteLine(Environment.NewLine)
        REPORTWRITER.WriteLine(String.Format("Crossed through and/or blank,{0}", PULLOUT))
        REPORTWRITER.WriteLine(Environment.NewLine)
        REPORTWRITER.WriteLine(String.Format("Total,{0}", (VALID + RULE + WRITTEN))) '+ PULLOUT
    End Sub

    Public Sub FILELIST()
        'If VALID > 0 Then
        '    IO.TextWriter.WriteLine(String.Format("DATA FILES\{0}.txt", batchName))
        'End If

        'For Each ex As String In Directory.GetFiles(EXIMGPATH, "*.tif")
        '    FILELISTWRITER.WriteLine(String.Format("EXCEPTION IMAGES\{0}\{1}", batchName, Path.GetFileName(ex)))
        'Next
        'FILELISTWRITER.WriteLine(String.Format("REPORTS\{0}.csv", batchName))

        'If RULE > 0 Then
        '    FILELISTWRITER.WriteLine(String.Format("RULE EXCEPTIONS\{0}P.csv", batchName))
        'End If

        'If WRITTEN > 0 Then
        '    FILELISTWRITER.WriteLine(String.Format("WRITTEN EXCEPTIONS\{0}W.csv", batchName))
        'End If

        'FILELISTWRITER.WriteLine("")
    End Sub

    Public Sub CLOSEWRITER()
        MOTHERWRITER.Close()
        TMPMOTHERWRITER.Close()
        VALWRITER.Close()
        'RULEWRITER.Close()
        'WRITTENWRITER.Close()
        PULLOUTWRITER.Close()
        'TMPRULEWRITER.Close()
        'TMPWRITTENWRITER.Close()
        REPORTWRITER.Close()
        'FILELISTWRITER.Close()
    End Sub

    Public Sub DELETEEMPTYWRITER()
        If VALID = 0 Then
            File.Delete(String.Format("{0}\{1}.csv", MOTHERPATH, MNJOBCODE))
        End If
        If RULE = 0 Then
            File.Delete(String.Format("{0}\mismatch.log", MOTHERPATH))
        End If
        If INVALID = 0 Then
            File.Delete(String.Format("{0}\Final Validation.log", MOTHERPATH))
        End If
        If PULLOUT = 0 Then
            File.Delete(String.Format("{0}\Pullout.log", MOTHERPATH))
        End If
    End Sub
#End Region
#End Region
#End Region

#Region "Fields Order(can be changed depending on the job)"

    Public Sub PulloutList(jobcode As String, ByRef FlagList As List(Of FlagClass))
        FlagList = New List(Of FlagClass)

        Select Case jobcode
            Case "Cell2"
                addFlag(FlagList, "client_ref", "*")
                addFlag(FlagList, "cor_flag", "1")
        End Select
    End Sub

    Public Sub RuleList(jobcode As String, ByRef FlagList As List(Of FlagClass))
        FlagList = New List(Of FlagClass)

        Select Case jobcode
            Case "Cell2"
                addFlag(FlagList, "cor_flag", "2")
        End Select
    End Sub

    Public Sub WrittenList(jobcode As String, ByRef FlagList As List(Of FlagClass))
        FlagList = New List(Of FlagClass)

        Select Case jobcode
            Case "PP367", "PP369", "PP370", "PP355", "PP341", "PP362", "PP363", "PP364", "PP357", "PP350", "PP340", "PP337"
                addFlag(FlagList, "ExFlag", "12")
        End Select
    End Sub

    Public Sub MotherFieldlist(jobcode As String, ByRef FieldList As List(Of FieldClass))
        FieldList = New List(Of FieldClass)

        Select Case jobcode
            Case "Cell2"
                addField(FieldList, "batch", 9, getFrm.other)
                addField(FieldList, "record_number", 9, getFrm.temp)
                addField(FieldList, "mdb_name", 9, getFrm.temp)
                addField(FieldList, "filename", 9, getFrm.other)
                addField(FieldList, "client_ref", 9, getFrm.data)
                addField(FieldList, "forename", 9, getFrm.data)
                addField(FieldList, "surname", 9, getFrm.data)
                addField(FieldList, "accounts1", 9, getFrm.data)
                addField(FieldList, "accounts2", 9, getFrm.data)
                addField(FieldList, "accounts3", 9, getFrm.data)
                addField(FieldList, "accounts4", 9, getFrm.conditional)
                addField(FieldList, "accounts5", 9, getFrm.conditional)
                addField(FieldList, "accounts6", 9, getFrm.conditional)
                addField(FieldList, "accounts7", 9, getFrm.conditional)
                addField(FieldList, "accounts8", 9, getFrm.conditional)
                addField(FieldList, "uk_nat_tick", 9, getFrm.data)
                addField(FieldList, "ni_number", 9, getFrm.data)
                addField(FieldList, "ni_tick", 9, getFrm.data)
                addField(FieldList, "country1", 9, getFrm.data)
                addField(FieldList, "personal_identifier1", 9, getFrm.data)
                addField(FieldList, "country2", 9, getFrm.data)
                addField(FieldList, "personal_identifier2", 9, getFrm.data)
                addField(FieldList, "country3", 9, getFrm.data)
                addField(FieldList, "personal_identifier3", 9, getFrm.data)
                addField(FieldList, "signature", 9, getFrm.data, "0")
                addField(FieldList, "date", 9, getFrm.data)
                addField(FieldList, "exception", 9, getFrm.other, "0")
        End Select
    End Sub

    Public Sub RuleFieldlist(jobcode As String, ByRef FieldList As List(Of FieldClass))
        FieldList = New List(Of FieldClass)

        Select Case jobcode
            Case "Cell2"
                addField(FieldList, "Batch Number", 20, getFrm.other)
                addField(FieldList, "Record Number", 20, getFrm.other)
                addField(FieldList, "Mismatch Name", 50, getFrm.other)
        End Select
    End Sub

    Public Sub WrittenFieldlist(jobcode As String, ByRef FieldList As List(Of FieldClass))
        FieldList = New List(Of FieldClass)

        Select Case jobcode
            Case "PP367", "PP369", "PP370", "PP355", "PP341", "PP362", "PP363", "PP364", "PP357", "PP350", "PP340", "PP337"
                addField(FieldList, "Batch Name", 15, getFrm.other)
                addField(FieldList, "Image 1", 12, getFrm.other)

                If MNJOBCODEINFO.Twopages Then
                    addField(FieldList, "Image 2", 12, getFrm.other)
                Else : addField(FieldList, "Image 2", 12, getFrm.blank)
                End If

                addField(FieldList, "Written Exception Reason", 50, getFrm.other)
                addField(FieldList, "MDB", 12, getFrm.temp)
                addField(FieldList, "Recordnumber", 12, getFrm.temp)

        End Select
    End Sub

    Public Sub PulloutFieldlist(jobcode As String, ByRef FieldList As List(Of FieldClass))
        FieldList = New List(Of FieldClass)
           Select Case jobcode
            Case "Cell2"
                addField(FieldList, "Batch Number", 20, getFrm.other)
                addField(FieldList, "MDB", 20, getFrm.other)
                addField(FieldList, "Record Number", 20, getFrm.other)
        End Select
    End Sub
#End Region

#Region "Field Class"
    Public MotherField As New List(Of FieldClass)
    Public RuleField As New List(Of FieldClass)
    Public WrittenField As New List(Of FieldClass)
    Public PulloutField As New List(Of FieldClass)

    Public Class getFrm
        Public Const data As String = "DATA"
        Public Const conditional As String = "CONDITIONAL"
        Public Const other As String = "OTHER"
        Public Const blank As String = "BLANK"
        Public Const temp As String = "TEMP"
        Public Const _date As String = "DATE"
        Public Const gender As String = "GENDER"
        Public Const bool As String = "BOOLEAN"
        Public Const title As String = "TITLE"
    End Class

    Public Class FieldClass
        Public name As String
        Public length As Integer
        Public getFrom As String
        Public DefaultValue As String
    End Class

    Public Sub addField(list As List(Of FieldClass), name As String, length As Integer, getfrom As String, Optional defaultValue As String = "")
        Dim FC As New FieldClass
        FC.name = name
        FC.length = length
        FC.getFrom = getfrom
        FC.DefaultValue = defaultValue

        list.Add(FC)
    End Sub
#End Region

#Region "Flag Class"
    Public RuleFlag As New List(Of FlagClass)
    Public WrittenFlag As New List(Of FlagClass)
    Public PulloutFlag As New List(Of FlagClass)

    Public Class FlagClass
        Public name As String
        Public flag As String
    End Class

    Public Sub addFlag(list As List(Of FlagClass), name As String, flag As String)
        Dim FC As New FlagClass
        FC.name = name
        FC.flag = flag

        list.Add(FC)
    End Sub
#End Region

#Region "IMAGES"
    Public Sub GETIMAGES(ROW As Integer)
        IMG1 = dtCBatch.Rows(ROW).Item("Image001")
        OIMG1 = dtCBatch.Rows(ROW).Item("OImage001")

        If Not IsDBNull(dtCBatch.Rows(ROW).Item("Image002")) Then
            IMG2 = dtCBatch.Rows(ROW).Item("Image002")
            OIMG2 = dtCBatch.Rows(ROW).Item("OImage002")
        End If
    End Sub
#End Region

#Region "OTHER METHOD"
    Public Function InvalidURN(ByVal value As String) As Boolean
        Dim GrandTotal As Integer
        Dim Multiplier As Integer
        Dim Weighting As Integer
        Dim ChekDgit As Integer
        GrandTotal = 0
        If Not value = "" Then
            If value.Length = 9 Then
                For i As Integer = 1 To value.Length - 1
                    Select Case i
                        Case 1
                            Multiplier = 19
                        Case 2
                            Multiplier = 17
                        Case 3
                            Multiplier = 13
                        Case 4
                            Multiplier = 11
                        Case 5
                            Multiplier = 7
                        Case 6
                            Multiplier = 5
                        Case 7
                            Multiplier = 3
                    End Select
                    If i <= 7 Then
                        GrandTotal += value.Substring(i, 1) * Multiplier
                    Else
                        GrandTotal += value.Substring(i, 1)
                    End If
                Next i
                Weighting = Int(GrandTotal / 9) * 9
                ChekDgit = (GrandTotal - Weighting) + 1
                If ChekDgit = value.Substring(0, 1) Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
    Public Function Blankdata(ByVal value As String)
        Return value.Trim(Chr(13)) = ""
    End Function



    Public Function OTHERCONDITION(jobcode As String, dt As DataRow, Reason As String) As Boolean
        Select Case Reason
            'Case "RULE"
            '    Select Case jobcode
            '        Case "PP367", "PP369", "PP370", "PP355", "PP341", "PP362", "PP363", "PP364"
            '            If InvalidURN(dt.Item("URN").ToString) Then Return True
            '            If Blankdata(dt.Item("Code").ToString) Then Return True
            '        Case Else
            '            If Blankdata(dt.Item("Code").ToString) Then Return True
            '    End Select
            'Case "WRITTEN"
            'Case "PULLOUT"
        End Select

        Return False
    End Function
#End Region

#Region "IDisposable Members"
    Public Sub Dispose() Implements IDisposable.Dispose
        SHEET = 0
        IMAGES = 0
        RECORDS = 0

        VALID = 0
        RULE = 0
        WRITTEN = 0

        BLANK = 0
        PULLOUT = 0

        _totalRecord = 0
        _pulloutCount = 0
    End Sub
#End Region
End Class
