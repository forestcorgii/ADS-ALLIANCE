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

Module Validation

    Public autoNext, forceSaving As Boolean
    Public page, PO_Key, charPerIndex, num_Format, char_Valid, char_Other, def_Value As String
    Public prompt_OTO, prompt_Required, prompt_PO As String


    Private Class LengthType
        Public Const ExactLen As String = "Exact"
        Public Const GreaterThanLen As String = "Greater"
        Public Const LessThanLen As String = "Lesser"
    End Class

   
    Public BatchDate As String = ""
    Public Class ValOutputClass
        Implements IDisposable

#Region "Variables for Validation Process"
        Private _row As Integer
        Private _column As String
        Private _noError As Boolean
        Private _errorCount, _colErrorCount As Integer
        Public _totalErrorCount, _pulloutCount As Integer
        Private _Conn As New OleDbConnection

#End Region


        Public Sub New(mdb As String)
            BatchDate = New DirectoryInfo(mdb).Parent.Parent.Parent.Name
            zipFile = New DirectoryInfo(mdb).Parent.Parent.Name
            mdbOpen(mdb, _Conn)
            refresh_DT(_Conn)

            startLog(mdb) '----LOG----'
            startRunning() '----LOG----'

            For Each row As DataRow In dtData001.Rows
            
                _row += 1
                RECORD += 1

                With dtData001.Rows(_row - 1)
                    For Each f As String In FieldsE1
                        _column = f
                        FIELDNAME = f
                        load_FieldInfo(FIELDNAME)
                        Dim value As String = ""
                        Try
                            value = .Item(_column).ToString.Replace("''", "'")
                        Catch ex As Exception
                            Continue For
                        End Try
                 
                        Select Case autoNext
                            Case True
                                If .Item(_column).ToString.Length > 0 Then
                                    Using validating As New ValClass(logWriter, _column, Char.Parse(value))
                                        _errorCount += validating._errorCount
                                        _colErrorCount += validating._errorCount
                                        If validating._pullout Then
                                            _pulloutCount += 1
                                            insertSplitter() '----LOG----'
                                            Exit For
                                        End If
                                    End Using
                                End If
                            Case False
                                Using validating As New ValClass(logWriter, _column, value, dtData001.Rows(_row - 1))
                                    _errorCount += validating._errorCount
                                    _colErrorCount += validating._errorCount
                                    If validating._pullout Then
                                        _pulloutCount += 1
                                        insertSplitter() '----LOG----'
                                        Exit For
                                    End If
                                End Using
                        End Select
                    Next
                End With

                If Not _errorCount = 0 Then
                    insertSplitter() '----LOG----'
                End If

                _totalErrorCount += _errorCount
                _errorCount = 0
            Next

            If _totalErrorCount = 0 And _pulloutCount = 0 Then
                logWriter.Close()
                File.Delete(logPath)
            End If

            endRunning() '----LOG----'
            saveVal(_Conn)
            _Conn.Close()
        End Sub

#Region "VALIDATION LOG"
        Public logWriter As StreamWriter
        Public logPath As String

        Public Sub startLog(ByVal fullPath As String)
            logPath = String.Format("{0}\{1}.ERR", Path.GetDirectoryName(fullPath), Path.GetFileNameWithoutExtension(fullPath))
            logWriter = File.CreateText(logPath)
            With logWriter
                .WriteLine(FillSpaces(String.Format("ERROR LOGFILE FOUND IN: {0}({1})", MNCLIENT, MNJOBCODE), 160))
                .WriteLine(String.Format("{0,-160}", logPath))
                .WriteLine(String.Format("VALIDATION ID: {0,-10}Validation Date:  {1,-100}", USERID, Now.ToString("G")))
                .WriteLine("")
                .WriteLine(String.Format("{0,-10}{1,-20}{2,-65}{3,-65}", "RECORD", "FIELD NAME", "ERROR DETAIL", "VALUE"))
                .WriteLine("")
            End With
        End Sub

        Public Sub startRunning()
            logWriter.WriteLine("") 'String.Format("{0}{1}{2}{3}{4}", FillSpaces("RECORD", 10), FillSpaces("FIELD", 20), FillSpaces("MESSAGE", 65), FillSpaces("VALUE", 65), en))
        End Sub

        Public Sub insertSplitter()
            logWriter.Write(Environment.NewLine)
        End Sub

        Public Sub NoMismatch()
            '   logWriter.WriteLine(String.Format("{0}{1}{2}{3}", FillSpaces(RECORD, 10), FillSpaces(" ", 20), FillSpaces("     NO ERROR ", 65), FillSpaces(" ", 65)))
        End Sub

        Public Sub endRunning()
            logWriter.Close()
        End Sub
#End Region
#Region "IDisposable Members"
        Public Sub Dispose() Implements IDisposable.Dispose
            _errorCount = 0
            _totalErrorCount = 0
            logWriter = Nothing
            _row = 0
            _column = 0
            _Conn = Nothing
            RECORD = 0
            _pulloutCount = 0
          End Sub
#End Region
    End Class


    Public Class ValClass
        Implements IDisposable
        Public _pulloutCount, _errorCount As Integer
        Public _pullout As Boolean
        Private _logWriter As StreamWriter
        Public BatchDate As String = ""

#Region "Validation output (Extension)"
        Private Sub countError()
            _errorCount += 1
        End Sub

        Private Sub countPullout()
            _pulloutCount += 1
            _pullout = True
        End Sub

        Private Sub writeResult(r As String, f As String, m As String, v As String)
            _logWriter.WriteLine(String.Format("{0,-10}{1,-20}{2,-65}{3,-65}", r, f, m, v))
        End Sub
#End Region

        Public Sub New(lg As StreamWriter, ByVal fld As String, ByVal keyChar As Char)
            _logWriter = lg
             'Additional Validations 
            If Not Char.IsWhiteSpace(keyChar) Then
                validate_Char(fld, keyChar)
            End If

            If Not _pullout Then
                Select Case fld
                    'All fields are temporary
                    Case "ExRules", "ExRules2"
                        validate_Blank(keyChar)
                        If Not keyChar = "" AndAlso Not keyChar = "0" Then
                            writeResult(RECORD, FIELDNAME, "Rule Exception", keyChar)
                            countError()
                        End If
                    Case "QAS"
                        validate_Blank(keyChar)
                        If keyChar = "N" Then
                            writeResult(RECORD, FIELDNAME, "Please Check", keyChar)
                            countError()
                        End If
                End Select

                handleChar(keyChar)
            End If
            'If Not invalid Then
            '    CurrentFieldValue = tmp
            'End If

            'sendPrompt(fld, tmp)
        End Sub


        'Public Sub New(ByVal fld As String, ByVal e As Char)
        '    handleChar(e)

        '    'Conversion 
        '        Select Case fld
        '            'All fields are temporary
        '            Case "Title"
        '                convertValue(e, titleCon)
        '            Case "Brand"
        '                convertValue(e, brandCon)
        '            Case "Retailer"
        '                convertValue(e, retailerCon)
        '        End Select
        '    End Sub

        Public Sub New(lg As StreamWriter, ByVal fld As String, ByVal value As String, rw As DataRow)
            _logWriter = lg
            'Additional Validations
            If value.Length = 1 Then
                validate_Char(fld, value)
            End If
            If Not _pullout Then
                Select Case fld
                    Case "surname"
                        validate_Blank(value)
                        validate_Length(value, New Integer() {2}, LengthType.LessThanLen)
                        checkCasing(value)
                    Case "forename"
                        checkCasing(value)
                    Case "personal_identifier1", "personal_identifier2", "personal_identifier3"
                        validate_Length(value, New Integer() {2}, LengthType.LessThanLen)
                    Case "country1", "country2", "country3"
                        validate_Length(value, New Integer() {2}, LengthType.LessThanLen)
                        checkCasing(value)
                    Case "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                        validate_Length(value, New Integer() {8}, LengthType.LessThanLen)
                    Case "date"
                        validate_Length(value, New Integer() {6}, LengthType.ExactLen)
                        validate_Date(value, noRange, noRange, "0-8")
                End Select
            End If
        End Sub
       
        'Public Sub sendPrompt(ByVal fld As String, ByVal value As String)
        '    If invalid Then
        '        getValResult(erType)
        '        Select Case erType
        '            Case ErrorType.OTO
        '                If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '                    changeValue(fld)
        '                    nextRecord(value)
        '                End If
        '            Case ErrorType.Required
        '                msgBoxOUT(erMsg, fld, MessageBoxButtons.OK)
        '            Case ErrorType.Pullout
        '                If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '                    pullout(value)
        '                End If
        '        End Select
        '    Else
        '        nextRecord(value)
        '    End If
        'End Sub

        'Public Function autocorrect(ByVal txt As String) As String
        '    txt = Regex.Replace(txt, " {2,}", " ")
        '    txt = Replace(txt, "@@{2,}", "@")
        '    txt = Replace(txt, "..{2,}", ".")
        '    Return txt
        'End Function

        'Public Sub nextRecord(ByVal value As String)
        '    PublicTB.Copy()
        '    CurrentFieldValue = autocorrect(value)

        '    If (CurrentRow + 1) = PublicDGV.Rows.Count Then
        '        SAVE(IIf(Mode = mymode.Entry_Mode, "ENTRY", "EDIT"))
        '    ElseIf forceSaving = True Then
        '        If Mode = mymode.Entry_Mode Then
        '            If msgBoxOUT("Are You sure You want to Save?", "Force Save", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
        '                invalid = True
        '                PublicTB.Undo()
        '                CurrentFieldValue = value
        '            End If
        '        End If
        '    Else
        '        CurrentRow += 1
        '    End If
        'End Sub

        'Public Sub pullout(ByVal value As String)
        '    EDATA = value
        '    nextRecord(EDATA)
        '    For i As Integer = CurrentRow To PublicDGV.Rows.Count - 1
        '        PublicDGV.Rows(i).Cells(1).Value = ""
        '    Next
        '    SAVE(IIf(Mode = mymode.Entry_Mode, "ENTRY", "EDIT"))
        'End Sub

        Public Sub checkLookup(ByVal value As String, ByVal l As List(Of String))
            If Not value = "" Then
                If Haslookup Then
                    If Not l.Contains(value) Then
                        writeResult(RECORD, FIELDNAME, "Value is not on the lookup", value)
                        countError()
                    End If
                End If
            End If
        End Sub

        'Public Sub getValResult(ByVal type As String)
        '    Select Case Type
        '        Case ErrorType.OTO
        '            erMsg &= " Do you want to Continue??"
        '            erType = Type
        '        Case ErrorType.Required
        '            erType = Type
        '        Case ErrorType.Pullout
        '            erMsg &= " Do you want to Pullout??"
        '            erType = type
        '    End Select
        'End Sub

#Region "Validation(Default)"
        Private Sub validate_Char(ByVal fld As String, ByVal val As Char)
            If PO_Key.Contains(val) Then
                Select Case fld.ToUpper
                    Case "CODE"
                        writeResult(RECORD, FIELDNAME, "Other Code", val)
                    Case Else
                        writeResult(RECORD, FIELDNAME, "Pullout", val)
                End Select
                'countError()
                countPullout()
            End If
        End Sub

        Private Sub validate_Regex(ByVal value As String, ByVal reg As String)
            If Not value = "" Then
                If Not reg = "" Then
                    If Regex.IsMatch(value, reg, RegexOptions.IgnoreCase) = False Then
                        writeResult(RECORD, FIELDNAME, "Invalid value ", value)
                        countError()
                    End If
                End If
            End If
        End Sub

        Private Sub validate_Length(ByVal txt As String, ByVal rng As Integer(), ByVal lenType As String)
            If txt <> "" Then
                Dim txtL As Integer = txt.Length
                For Each i As Integer In rng
                    Select Case lenType
                        Case LengthType.ExactLen
                            If Not txtL = Integer.Parse(rng(0)) Then
                                writeResult(RECORD, FIELDNAME, "Invalid Length", txt)
                                countError()
                            End If
                        Case LengthType.GreaterThanLen
                            If txtL > Integer.Parse(rng(0)) Then
                                writeResult(RECORD, FIELDNAME, "Invalid Length", txt)
                                countError()
                            End If
                        Case LengthType.LessThanLen
                            If txtL < Integer.Parse(rng(0)) Then
                                writeResult(RECORD, FIELDNAME, "Invalid Length", txt)
                                countError()
                            End If
                    End Select
                Next
            End If
        End Sub

        Private Sub validate_Blank(ByVal value As String)
            value = value.Trim(Chr(13))
            If value = "" Then
                writeResult(RECORD, FIELDNAME, "Blank value", value)
                countError()
            End If
        End Sub
        'Public Function autocorrect(ByVal txt As String) As String
        '    txt = Regex.Replace(txt, " {2,}", " ")
        '    txt = Replace(txt, "@@{2,}", "@")
        '    txt = Replace(txt, "..{2,}", ".")
        '    Return txt
        'End Function
        Private Sub validate_Dup(ByVal value As String, ch As Char)
            If Not value = Replace(value, ch & ch & "{2,}", ch) Then
                writeResult(RECORD, FIELDNAME, "Contains Duplicate", value)
                countError()
            End If
        End Sub

        Public Sub validate_Date(ByVal value As String, ByRef day As String, _
        ByRef month As String, ByRef year As String, Optional manualDate As String = "")

            If value <> "" Then
                Dim tmpDateNow As Date
                If manualDate = "" Then
                    tmpDateNow = Now.ToString
                Else
                    tmpDateNow = Date.Parse(String.Format("{0}/{1}/{2}", manualDate.Substring(4, 2), manualDate.Substring(6, 2), manualDate.Substring(0, 4)))
                End If


                Dim yyyy As String = ""
                Dim dd, mm, yy As String
                Dim valMessage As String = ""
                Dim date_Entered, date_now, date_RangeA, date_RangeB As Date

                Dim dd_rng, mm_rng, yy_rng As String()
                dd_rng = day.Split("-")
                mm_rng = month.Split("-")
                yy_rng = year.Split("-")

                dd = value.Substring(0, 2)
                mm = value.Substring(2, 2)
                yy = value.Substring(4, 2)
                If value.Length = 6 Then
                    If checkValidDate(value) = False Then
                        writeResult(RECORD, FIELDNAME, "Date is invalid.", value)
                        countError()
                        Exit Sub
                    End If

                    If Not dd_rng(1) = 0 Then valMessage = " Range should be within " & dd_rng(0) & " - " & dd_rng(1) & " days"
                    If Not mm_rng(1) = 0 Then valMessage = " Range should be within " & mm_rng(0) & " - " & mm_rng(1) & " months"
                    If Not yy_rng(1) = 0 Then valMessage = " Range should be within " & yy_rng(0) & " - " & yy_rng(1) & " years"
                    'Year
                    If yy > Integer.Parse(Now.ToString("yy") + 5) Then yyyy = "19" & yy Else yyyy = "20" & yy
                    'For Date Ranges
                    date_now = Date.ParseExact(Format(tmpDateNow, "ddMMyyyy"), "ddMMyyyy", Nothing)
                    date_Entered = Date.ParseExact(dd & mm & yyyy, "ddMMyyyy", Nothing)
                    If date_Entered > date_now Then
                        writeResult(RECORD, FIELDNAME, "Future Date Detected.. ", value)
                        countError()
                        Exit Sub
                    End If
                    If day <> noRange Or month <> noRange Or year <> noRange Then
                        date_RangeA = getExactDate_Date(dd_rng(0), mm_rng(0), yy_rng(0), "ddMMyyyy")
                        date_RangeB = getExactDate_Date(dd_rng(1), mm_rng(1), yy_rng(1), "ddMMyyyy")
                        If date_Entered > date_RangeA Or date_Entered < date_RangeB Then
                            writeResult(RECORD, FIELDNAME, "Invalid Date Detected(" & valMessage & ")..", value)
                            countError()
                            Exit Sub
                        End If
                    End If
                   
                End If
            End If
        End Sub

        Public Function getExactDate_Date(ByVal ddRng As String, ByVal mmRng As String, ByVal yyRng As String, ByVal format As String) As Date
            Dim dd, mm, yy, maxDD As String
            maxDD = ""
            yy = Now.ToString("yyyy")
            mm = Now.ToString("MM")
            dd = Now.ToString("dd")

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
            getExactDate_Date = Date.ParseExact(dd & mm & yy, format, Nothing)
            Return getExactDate_Date
        End Function

        Public Sub validate_DueDate(ByVal value As String, ByRef day As String, _
        ByRef month As String, ByRef year As String)
            If value <> "" Then
                Dim yyyy As String = ""
                Dim dd, mm, yy As String
                Dim valMessage As String = ""
                Dim date_Entered, date_now, date_RangeA, date_RangeB As Date

                Dim dd_rng, mm_rng, yy_rng As String()
                dd_rng = day.Split("-")
                mm_rng = month.Split("-")
                yy_rng = year.Split("-")

                dd = value.Substring(0, 2)
                mm = value.Substring(2, 2)
                yy = value.Substring(4, 2)
                If value.Length = 6 Then
                    If checkValidDate(value) = False Then
                        writeResult(RECORD, FIELDNAME, "Date is invalid", value)
                        countError()
                        Exit Sub
                    End If

                    If Not dd_rng(1) = 0 Then valMessage = " Range should be within " & dd_rng(0) & " - " & dd_rng(1) & " days"
                    If Not mm_rng(1) = 0 Then valMessage = " Range should be within " & mm_rng(0) & " - " & mm_rng(1) & " months"
                    If Not yy_rng(1) = 0 Then valMessage = " Range should be within " & yy_rng(0) & " - " & yy_rng(1) & " years"
                    'Year
                    If yy > Integer.Parse(Now.ToString("yy")) Then yyyy = "19" & yy Else yyyy = "20" & yy
                    'For Date Ranges
                    date_now = Date.ParseExact(Format(Now, "ddMMyyyy"), "ddMMyyyy", Nothing)
                    date_Entered = Date.ParseExact(dd & mm & yyyy, "ddMMyyyy", Nothing)
                    date_RangeA = getExactDate_Date(dd_rng(0), mm_rng(0), yy_rng(0), "ddMMyyyy")
                    date_RangeB = getExactDate_Date(dd_rng(1), mm_rng(1), yy_rng(1), "ddMMyyyy")
                    If date_Entered < date_RangeA Or date_Entered > date_RangeB Then
                        writeResult(RECORD, FIELDNAME, "Invalid Range Detected(" & valMessage & ")", value)
                        countError()
                    ElseIf date_Entered > date_now Then
                        writeResult(RECORD, FIELDNAME, "Future Date Detected", value)
                        countError()
                    End If
                End If
            End If
        End Sub

        Public Function getExactDate_DueDate(ByVal ddRng As String, ByVal mmRng As String, ByVal yyRng As String, ByVal format As String) As Date
            Dim dd, mm, yy, maxDD As String
            maxDD = ""
            yy = Now.ToString("yyyy")
            mm = Now.ToString("MM")
            dd = Now.ToString("dd")

            yy = yy + yyRng
            If mm + mmRng > 12 Then
                yy += 1
                mm = (12 - mm) + mmRng
            Else
                mm = mm + mmRng
            End If

            If dd - ddRng < 0 Then
                mm += 1
                dd = (Date.DaysInMonth(yy, mm) - dd) + ddRng
            Else
                dd = dd + ddRng
            End If
            If dd > Date.DaysInMonth(yy, mm) Then
                dd -= Date.DaysInMonth(yy, mm)
                mm += 1
            End If
            If dd.Length = 1 Then dd = "0" & dd
            If mm.Length = 1 Then mm = "0" & mm
            getExactDate_DueDate = Date.ParseExact(dd & mm & yy, format, Nothing)
            Return getExactDate_DueDate
        End Function
        Public Function checkValidDate(ByVal value As String) As Boolean
            Dim dd As String = value.Substring(0, 2)
            Dim mm As String = value.Substring(2, 2)
            Dim yy As String = value.Substring(4, 2)

            If (dd.Trim.Equals("") And mm.Trim.Equals("") And yy.Trim.Equals("")) Or _
                              (Integer.Parse(dd) = 0 Or Integer.Parse(mm) = 0) Then
                Return False
            Else
                'Month
                If Integer.Parse(mm) > 12 Then
                    Return False
                Else
                    'Day
                    Select Case Integer.Parse(mm)
                        Case 1, 3, 5, 7, 8, 10, 12
                            If Integer.Parse(dd) > 31 Then
                                Return False
                            End If
                        Case 2
                            Dim leaf = Integer.Parse(yy) Mod 4
                            If leaf = 0 Then
                                If Integer.Parse(dd) > 29 Then
                                    Return False
                                End If
                            Else
                                If Integer.Parse(dd) > 28 Then
                                    Return False
                                End If
                            End If
                        Case Else
                            If Integer.Parse(dd) > 30 Then
                                Return False
                            End If
                    End Select
                End If
            End If
            Return True
        End Function
        Public Sub handleChar(ByVal e As Char)
            Dim valchr As String = Chr(10) & Chr(11) & Chr(12) & Chr(13) & char_Other.ToUpper
            If char_Valid Is Nothing Then char_Valid = "None"
            If charPerIndex Is Nothing Then charPerIndex = ""
            If char_Valid = "AlphaNumeric" Then
                valchr += "0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            ElseIf char_Valid = "Numeric" Then
                valchr += "0123456789"
            ElseIf char_Valid = "Alpha" Then
                valchr += " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            End If
            If valchr.Contains(e.ToString.ToUpper) Or e = Nothing Then
            Else
                writeResult(RECORD, FIELDNAME, "Invalid Character ", e)
                countError()
            End If

            Dim ch As String() = charPerIndex.Split("|")
            If charPerIndex <> "" Then
                For i As Integer = 0 To ch.GetUpperBound(0)
                    Dim Vch As New List(Of String)
                    Vch.AddRange(ch(i).Split(","))
                    If Not Vch.Contains(e) Then
                        writeResult(RECORD, FIELDNAME, "Invalid Character ", e)
                        countError()
                    End If
                Next
            End If
        End Sub
#End Region

#Region "Validation (Additional)"
#Region "Conversion"
        'Public Sub ConvertTitle(ByRef value As String)
        '    Select Case value
        '        Case "1"
        '            value = "MR"
        '            nextRecord(value)
        '            invalid = True
        '        Case "2"
        '            value = "MRS"
        '            nextRecord(value)
        '            invalid = True
        '        Case "3"
        '            value = "MISS"
        '            nextRecord(value)
        '            invalid = True
        '    End Select
        'End Sub
#Region "Date String"
        Public noRange As String = "0-0"
#End Region
#Region "Format String"
        Public kidPCodeFormat As String() = New String() {"ANNAA", "ANANAA", "ANNNAA", "AANNAA", "AANANAA", "AANNNAA"}
        Public promoCodeFormat As String() = New String() {"AANNN"}
#End Region
#Region "Regex String"
        Public emailRegex As String = "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
#End Region
#Region "Conversion Strings"
        Public titleCon As String() = New String() {"1-MR", "2-MRS", "3-MISS"}
        Public retailerCon As String() = New String() {"1-A", "6-F", "2-B", "7-G", "3-C", "8-H", "4-D", "9-I", "5-E"}
        Public brandCon As String() = New String() {"1-A", "6-F", "2-B", "3-C", "4-D", "5-E"}
#End Region
        Public Sub convertValue(ByVal value As String, ByVal conversionType As String())
            Dim separatedChar As String()
            For Each ch As String In conversionType
                separatedChar = ch.Split("-")
                If separatedChar(0) = value Then
                    Exit Sub
                End If
            Next
        End Sub
#End Region
        Public Sub checkTitle(ByRef value As String)
            Select Case value.ToUpper
                Case "MR", "MRS", "MISS", "MS", "MASTER", "LADY", "REV", "DR", "MAJOR", "SIR", "CAPT", "PROF", "BRIG", "CPL", ""
                Case Else
                    writeResult(RECORD, FIELDNAME, "Invalid Title", value)
                    countError()
            End Select
        End Sub
        'Public Sub changeValue(ByVal fld As String)
        '    Select Case fld
        '        Case "Code", "URN"
        '            changeValueByField("ExRules", "4")
        '    End Select
        'End Sub
        Public Sub checkLeaflet(ByVal value As String)
            If Not value = "" Then
                If Not leaflet.Contains(value) Then
                    writeResult(RECORD, FIELDNAME, "Invalid Leaflet Code", value)
                    countError()
                End If
            End If
        End Sub

        Public Sub checkAccounts(ByRef invalid As Boolean, ByRef value As String)
            'If Not invalid And Not value = "" Then
            '    Dim _accounts As New List(Of String)
            '    _accounts.Add(value)
            '    For i As Integer = CurrentRow - 1 To 0 Step -1
            '        Select Case PublicDGV.Rows(i).Cells(0).Value
            '            Case "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
            '                Dim i_value As String = PublicDGV.Rows(i).Cells(1).Value
            '                If _accounts.Contains(i_value) Then
            '                    erMsg = "Duplicate Accounts found.."

            '                Else
            '                End If
            '        End Select
            '    Next

            'End If
        End Sub

        Public Sub checkCasing(ByRef value As String)
            If Not value = "" Then
                value = value.Trim
                If (Not Char.IsLetterOrDigit(value.Substring(0, 1))) _
                Or (Not Char.IsLetterOrDigit(value.Substring(value.Length - 1, 1))) Then
                    writeResult(RECORD, FIELDNAME, "Invalid Casing", value)
                    countError()
                    Exit Sub
                End If

                If Not Char.IsUpper(value.Substring(0, 1)) Then
                    writeResult(RECORD, FIELDNAME, "Invalid Casing", value)
                    countError()
                    Exit Sub
                End If
                For i As Integer = 1 To value.Length - 1
                    Select Case value.Substring(i - 1, 1)
                        Case " ", "'", "-"
                            If Not Char.IsUpper(value.Substring(i, 1)) Then
                                writeResult(RECORD, FIELDNAME, "Invalid Casing", value)
                                countError()
                                Exit Sub
                            End If
                        Case Else
                            If Not Char.IsLower(value.Substring(i, 1)) And Char.IsLetter(value.Substring(i, 1)) Then
                                writeResult(RECORD, FIELDNAME, "Invalid Casing", value)
                                countError()
                                Exit Sub
                            End If
                    End Select
                Next
            End If
        End Sub

        Public Sub checkPhone(ByRef value As String)
            Select Case value.Length
                'Case Is < 10
                '    erMsg = "Invalid Length.."
                '    invalid = True
                '    erType = ErrorType.OTO
                Case 10, 11
                    Dim d As String = value.Substring(0, 2)
                    Select Case d
                        Case "01", "02", "03", "07", "08"
                        Case Else
                            writeResult(RECORD, FIELDNAME, "Invalid Value, the first 2 digits must start with: " & vbNewLine _
                                           & " 01, 02, 03, 07 and 08.", value)
                            countError()
                    End Select
            End Select
        End Sub

        Public Sub checkCode(ByVal value As String, ByVal format As String())
            If Not value = "" Then
                Dim tmp As String = ""
                For Each c As Char In value
                    If Char.IsLetter(c) Then
                        tmp &= "A"
                    ElseIf Char.IsNumber(c) Then
                        tmp &= "N"
                    Else
                        '  tmp &= c.ToString
                    End If
                Next

                Dim validCode As Boolean = False
                For Each f As String In format
                    If tmp = f Then
                        validCode = True : Exit For
                    End If
                Next
                If Not validCode Then
                    writeResult(RECORD, FIELDNAME, "Invalid Format", value)
                    countError()
                End If
            End If
        End Sub

        Public Sub checkEmail(ByVal value As String)
            If Not value = "" Then
                Dim Valid As Boolean
                Try
                    Valid = Regex.IsMatch(value, "^([A-z\d!#$%&'*+()/=?^_`{|}~-]+[\w\.]{1})+@(([A-z\d]+)([\.]{1}[A-z\d]{2,})+)$", RegexOptions.IgnoreCase)
                    '  If value.ToUpper = "EMAIL@YAHOO.COM.U" Or value.ToUpper = "EMAIL@YAHOO.CO.U" Then Valid = False
                Catch
                End Try

                If Not Valid Then
                    writeResult(RECORD, FIELDNAME, "Invalid Email..", value)
                    countError()
                End If
            End If
            'If Not invalid And Not value = "" Then
            '    If (Not Regex.Matches(value, "@").Count = 1 Or value.Contains("..")) Or Not value.Contains(".") _
            '        Or Regex.Replace(value, "[@.!#$%&'*+/=?^_`{|}~-]", "").Length = 0 _
            '        Or Not emailRegex.IsMatch(value) Then
            '        invalid = True
            '        erMsg = "Invalid Email.."
            '        erType = er_type
            '    End If
            'End If
        End Sub
        Public Sub CheckURN(ByVal value As String, ByVal fieldname As String)
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
                    If Not ChekDgit = value.Substring(0, 1) Then
                        writeResult(RECORD, fieldname, "Invalid URN", value)
                        countError()
                    End If
                Else
                    writeResult(RECORD, fieldname, "Invalid length", value)
                    countError()
                End If
            Else
                writeResult(RECORD, fieldname, "Blank value", value)
                countError()
            End If

        End Sub
#End Region

#Region "IDisposable Members"
        Public Sub Dispose() Implements IDisposable.Dispose
            _errorCount = 0
            _pulloutCount = 0
            _logWriter = Nothing
            _pullout = False

        End Sub
#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Module
