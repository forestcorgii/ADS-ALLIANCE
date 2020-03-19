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

    Private Class ErrorType
        Public Const OTO As String = "Option to Overwrite"
        Public Const Required As String = "Required"
        Public Const Pullout As String = "Pullout"
    End Class

    Public Class ValClass
        Implements IDisposable
        Public erMsg As String
        Public erType As String
        Public invalid As Boolean

        Public Sub New()
            CheckExRules()
        End Sub

        Public Sub New(ByVal fld As String, ByVal keyChar As Char, ByVal value As String)
            Dim tmp As String = ""

            If keyChar = Chr(13) Then
                tmp = value
            Else
                tmp = keyChar
            End If

            'Additional Validations 
            Select Case fld
                'All fields are temporary
                Case "ExRules", "ExRules2", "QAS"
                    validate_Blank(invalid, tmp, ErrorType.Required)
            End Select

            validate_Char(fld, tmp)
            handleChar(keyChar)

            'If Not invalid Then
            '    CurrentFieldValue = tmp
            'End If

            sendPrompt(fld, tmp)
        End Sub

        Public Sub New(ByVal fld As String, ByVal e As Char)
            validate_Char(fld, e)
            handleChar(e)

            'Conversion 
            If Not invalid Then
                Select Case fld
                    'All fields are temporary
                    Case "Title"
                        convertValue(e, titleCon)
                    Case "Brand"
                        convertValue(e, brandCon)
                    Case "Retailer"
                        convertValue(e, retailerCon)
                End Select
            Else
                sendPrompt(fld, e)
            End If
        End Sub

        Public Sub New(ByVal fld As String, ByVal value As String)
            'Additional Validations
            value = Regex.Replace(value, " {2,}", " ")

            If value.Length = 1 Then
                validate_Char(fld, value)
            End If

            Select Case fld
                Case "client_ref"
                    validate_Blank(invalid, value, ErrorType.Required)
                    checkMailingFiles(invalid, value, ErrorType.Required)
                Case "surname"
                    validate_Blank(invalid, value, ErrorType.OTO)
                    validate_Length(invalid, value, New Integer() {2}, LengthType.LessThanLen, ErrorType.OTO)
                    checkCasing(invalid, value, ErrorType.Required, True)
                Case "forename"
                    checkCasing(invalid, value, ErrorType.Required, True)
                Case "personal_identifier1", "personal_identifier2", "personal_identifier3"
                    validate_Length(invalid, value, New Integer() {2}, LengthType.LessThanLen, ErrorType.OTO)
                Case "country1", "country2", "country3"
                    validate_Length(invalid, value, New Integer() {2}, LengthType.LessThanLen, ErrorType.OTO)
                    checkCasing(invalid, value, ErrorType.OTO)
                Case "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                    validate_Length(invalid, value, New Integer() {8}, LengthType.LessThanLen, ErrorType.OTO)
                    checkAccounts(invalid, value, ErrorType.OTO)
                Case "date"
                    validate_Length(invalid, value, New Integer() {6}, LengthType.ExactLen, ErrorType.Required)
                    validate_Date(invalid, value, noRange, noRange, "0-8", ErrorType.OTO, ErrorType.OTO)
            End Select

            sendPrompt(fld, value)
        End Sub

        Public Sub sendPrompt(ByVal fld As String, ByVal value As String)
            If invalid Then
                getValResult(erType)
                Select Case erType
                    Case ErrorType.OTO
                        If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            invalid = False
                            changeValue(fld, erType)
                            nextRecord(value)
                        End If
                    Case ErrorType.Required
                        msgBoxOUT(erMsg, fld, MessageBoxButtons.OK)
                    Case ErrorType.Pullout
                        If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            changeValue(fld, value)
                            pullout(value)
                        End If
                End Select
            Else
                nextRecord(value)
            End If
        End Sub

        Public Function autocorrect(ByVal txt As String) As String
            txt = Regex.Replace(txt, " {2,}", " ")
            txt = Replace(txt, "@@{2,}", "@")
            txt = Replace(txt, "..{2,}", ".")
            Return txt
        End Function

        Public Sub nextRecord(ByVal value As String)
            PublicTB.Copy()
            CurrentFieldValue = autocorrect(value)

            If (CurrentRow + 1) = PublicDGV.Rows.Count And forceSaving = False Then
                SAVE(Mode)
            ElseIf forceSaving = True Then
                If Mode = mymode.Entry_Mode Then
                    If checkToPO() Then
                        If msgBoxOUT("Are You sure You want to Pullout?", "All fields are blank", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                            invalid = True
                            PublicTB.Undo()
                            CurrentFieldValue = value
                        Else
                            setValueByField("ExFlag", "*")
                        End If
                        'Else
                        '    If msgBoxOUT("Are You sure You want to Save?", "Force Save", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        '        invalid = True
                        '        PublicTB.Undo()
                        '        CurrentFieldValue = value
                        '    End If
                    End If
                ElseIf Mode = mymode.Edit_Mode Then
                    CurrentFieldValue = value
                    invalid = False
                End If
            Else
                CurrentRow += 1
                If CurrentField = "exception" And getValueByField("cor_flag") = "2" Then
                    nextRecord("")
                End If

                Do While fromMailingFiles(ENTRY.dgv.Rows(CurrentRow).Cells(0).Value, ENTRY.dgv.Rows(CurrentRow).Cells(1).Value)
                    Select Case FIELDNAME : Case "forename", "surname", "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            CurrentRow += 1
                        Case "client_ref"
                            If populatedFromMailingFile Then CurrentRow += 1 Else Exit Do
                        Case Else : Exit Do
                    End Select
                Loop
              End If
        End Sub

        Public Sub pullout(ByVal value As String)
            EDATA = value
            nextRecord(EDATA)
            'For i As Integer = CurrentRow To PublicDGV.Rows.Count - 1
            '         PublicDGV.Rows(i).Cells(1).Value = ""
            'Next
            SAVE(Mode)
        End Sub

        Public Sub checkLookup(ByRef invalid As Boolean, ByVal value As String, ByVal l As List(Of String), ByVal er_type As String)
            If Not invalid Then
                If Not value = "" Then
                    If Haslookup Then
                        If Not l.Contains(value) Then
                            invalid = True
                            erMsg = "This value is not on the lookup. "
                            erType = er_type
                        End If
                    End If
                End If
            End If
        End Sub

        Public Sub getValResult(ByVal type As String)
            Select Case Type
                Case ErrorType.OTO
                    erMsg &= " Do you want to Continue??"
                    erType = Type
                Case ErrorType.Required
                    erType = Type
                Case ErrorType.Pullout
                    erMsg &= " Do you want to Pullout??"
                    erType = type
            End Select
        End Sub
#Region "Validation(Default)"
        Private Sub validate_Char(ByVal fld As String, ByVal val As Char)
            If PO_Key.Contains(val) Then
                PublicTB.Text = val
                erType = ErrorType.Pullout
                'getValResult(erType)
                invalid = True
            End If
        End Sub

        Private Sub validate_Regex(ByRef invalid As Boolean, ByVal value As String, ByVal reg As String, ByRef er_type As String)
            If Not value = "" Then
                If Not reg = "" Then
                    If Not Regex.IsMatch(value, reg, RegexOptions.Multiline) Then
                        '    If Not Regex.IsMatch(value, reg, RegexOptions.IgnoreCase) Then
                        invalid = True
                        erMsg = "Invalid " & FIELDNAME & ".. "
                        ' getValResult(er_type)
                        erType = er_type
                    End If
                End If
            End If
        End Sub

        Private Sub validate_Length(ByRef invalid As Boolean, ByVal txt As String, ByVal rng As Integer(), ByVal lenType As String, ByRef er_type As String)
            If Not invalid Then
                If txt <> "" Then
                    Dim txtL As Integer = txt.Length
                    For Each i As Integer In rng
                        Select Case lenType
                            Case LengthType.ExactLen
                                If txtL = Integer.Parse(rng(0)) Then invalid = False Else invalid = True
                            Case LengthType.GreaterThanLen
                                If txtL > Integer.Parse(rng(0)) Then invalid = True Else invalid = False
                            Case LengthType.LessThanLen
                                If txtL < Integer.Parse(rng(0)) Then invalid = True Else invalid = False
                        End Select
                    Next
                    If invalid = True Then
                        erMsg = "Invalid Length. "
                        erType = er_type
                        '  getValResult(er_type)
                    End If
                End If
            End If
        End Sub

        Private Sub validate_Blank(ByRef invalid As Boolean, ByVal value As String, ByRef er_type As String)
            value = value.Trim(Chr(13))
            If Not invalid Then
                If value = "" Then
                    invalid = True
                    erMsg = "Field should not be blank... "
                    erType = er_type
                    '  getValResult(erType)
                End If
            End If
        End Sub

        'Private Sub validate_Dup(ByRef invalid As Boolean, ByVal value As String, ByRef er_type As String)
        '    If invalid = False Then
        '        If val_Dup IsNot Nothing Then
        '            Dim tmp() As String = val_Dup.Split("|")
        '            If Boolean.Parse(tmp(0)) = True Then
        '                Dim chrCount As New List(Of String)
        '                For c As Integer = 0 To value.Length - 1
        '                    If chrCount.Contains(value.Substring(c, 1)) Then
        '                        invalid = True
        '                        getValResult(tmp(1))
        '                        Exit For
        '                    Else
        '                        chrCount.Add(value.Substring(c, 1))
        '                    End If
        '                Next
        '            End If
        '        End If
        '    End If
        'End Sub

        Public Sub validate_Date(ByRef invalid As Boolean, ByVal value As String, ByRef day As String, _
        ByRef month As String, ByRef year As String, ByRef er_type As String, ByRef futureDate_er_type As String, Optional manualDate As String = "")

            If invalid = False And value <> "" Then
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
                        invalid = True
                        erMsg = " Date is invalid."
                        erType = ErrorType.Required
                        Exit Sub
                    End If

                    If Not dd_rng(1) = 0 Then valMessage = " Range should be within " & dd_rng(0) & " - " & dd_rng(1) & " days"
                    If Not mm_rng(1) = 0 Then valMessage = " Range should be within " & mm_rng(0) & " - " & mm_rng(1) & " months"
                    If Not yy_rng(1) = 0 Then valMessage = " Range should be within " & yy_rng(0) & " - " & yy_rng(1) & " years"
                    'Year
                    If yy > Val(Now.ToString("yy") + 5) Then yyyy = "19" & yy Else yyyy = "20" & yy
                    'For Date Ranges
                    date_now = Date.ParseExact(Format(tmpDateNow, "ddMMyyyy"), "ddMMyyyy", Nothing)
                    date_Entered = Date.ParseExact(dd & mm & yyyy, "ddMMyyyy", Nothing)
                    If day <> noRange Or month <> noRange Or year <> noRange Then
                        date_RangeA = getExactDate_Date(dd_rng(0), mm_rng(0), yy_rng(0), "ddMMyyyy")
                        date_RangeB = getExactDate_Date(dd_rng(1), mm_rng(1), yy_rng(1), "ddMMyyyy")
                        If date_Entered > date_RangeA Or date_Entered < date_RangeB Then
                            invalid = True
                            erMsg = " Invalid Range Detected(" & valMessage & ").."
                            erType = er_type
                        End If
                    End If
                    If date_Entered > date_now Then
                        invalid = True
                        erMsg = "Future Date Detected.. "
                        erType = futureDate_er_type
                    End If
                End If
                'If invalid = True Then
                '    getValResult(erType)
                'End If
            End If
        End Sub

        'Public Function FutureDate(ByRef invalid As Boolean, value As String, Optional presentDate As String = "") As Boolean
        '    If Not invalid Then
        '        If presentDate.Equals("") Then
        '            If getExactDate_Date(presentDate) Then
        '            Else

        '            End If
        '        End If
        'End Function

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
                mm = IIf(Val(mm) = "1", 12, mm - 1)
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

        Public Sub validate_DueDate(ByRef invalid As Boolean, ByVal value As String, ByRef day As String, _
        ByRef month As String, ByRef year As String, ByRef er_type As String)
            If invalid = False And value <> "" Then
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
                        invalid = True
                        erMsg = " Date is invalid."
                        Exit Sub
                    End If

                    If Not dd_rng(1) = 0 Then valMessage = " Range should be within " & dd_rng(0) & " - " & dd_rng(1) & " days"
                    If Not mm_rng(1) = 0 Then valMessage = " Range should be within " & mm_rng(0) & " - " & mm_rng(1) & " months"
                    If Not yy_rng(1) = 0 Then valMessage = " Range should be within " & yy_rng(0) & " - " & yy_rng(1) & " years"
                    'Year
                    If yy > Val(Now.ToString("yy")) Then yyyy = "19" & yy Else yyyy = "20" & yy
                    'For Date Ranges
                    date_now = Date.ParseExact(Format(Now, "ddMMyyyy"), "ddMMyyyy", Nothing)
                    date_Entered = Date.ParseExact(dd & mm & yyyy, "ddMMyyyy", Nothing)
                    date_RangeA = getExactDate_Date(dd_rng(0), mm_rng(0), yy_rng(0), "ddMMyyyy")
                    date_RangeB = getExactDate_Date(dd_rng(1), mm_rng(1), yy_rng(1), "ddMMyyyy")
                    If date_Entered < date_RangeA Or date_Entered > date_RangeB Then
                        invalid = True
                        erMsg = " Invalid Range Detected(" & valMessage & ").."
                        erType = er_type
                    ElseIf date_Entered > date_now Then
                        erMsg = "Future Date Detected"
                        erType = er_type
                        invalid = True
                    End If
                End If
                'If invalid = True Then
                '    getValResult(erType)
                'End If
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
                              (Val(dd) = 0 Or Val(mm) = 0) Then
                Return False
            Else
                'Month
                If Val(mm) > 12 Then
                    Return False
                Else
                    'Day
                    Select Case Val(mm)
                        Case 1, 3, 5, 7, 8, 10, 12
                            If Val(dd) > 31 Then
                                Return False
                            End If
                        Case 2
                            Dim leaf = Val(yy) Mod 4
                            If leaf = 0 Then
                                If Val(dd) > 29 Then
                                    Return False
                                End If
                            Else
                                If Val(dd) > 28 Then
                                    Return False
                                End If
                            End If
                        Case Else
                            If Val(dd) > 30 Then
                                Return False
                            End If
                    End Select
                End If
            End If
            Return True
        End Function
        Public Sub handleChar(ByVal e As Char)
            If Not invalid Then

                ' Dim valchr As String = Chr(10) & Chr(11) & Chr(12) & Chr(13) & char_Other.ToUpper
                If charPerIndex Is Nothing Then charPerIndex = ""
                ' If char_Valid Is Nothing Then char_Valid = "None"
                ' If char_Valid = "AlphaNumeric" Then
                '  valchr += "0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                '  ElseIf char_Valid = "Numeric" Then
                '      valchr += "0123456789"
                '  ElseIf char_Valid = "Alpha" Then
                '      valchr += " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
                '  End If
                'If valchr.Contains(e.ToString.ToUpper) Or e = Nothing Then
                'invalid = False
                ' Else
                '     invalid = True
                ' End If

                Dim sp As Integer = PublicTB.SelectionStart
                Dim ch As String() = charPerIndex.Split("|")
                If charPerIndex <> "" Then
                    If Not invalid Then
                        For i As Integer = 0 To ch.GetUpperBound(0)
                            If sp = i Then
                                Dim Vch As New List(Of String)
                                Vch.AddRange(ch(i).Split(","))
                                If Vch.Contains(e) Then
                                    invalid = False
                                Else
                                    invalid = True
                                End If
                                'For j As Integer = 0 To Vch.GetUpperBound(0)
                                '    If e = Vch(j) Then
                                '        invalid = False
                                '        Exit For
                                '    End If
                                'Next
                                'invalid = True
                            End If
                        Next
                    End If
                End If
            End If
        End Sub
#End Region

#Region "Validation (Additional)"
#Region "Conversion"

#Region "Date String"
        Public noRange As String = "0-0"
#End Region
#Region "Format String"
        Public promoCodeFormat As String() = New String() {"AANNNAA", "AANNAA", "ANNNAA", "ANNAA", "ANANAA", "AANANAA", "AANNN"}
#End Region
#Region "Regex String"
        Public emailRegex As Regex = New Regex("([a-zA-Z0-9\.\-]+@[a-zA-Z0-9\.\-]+\.[a-z]{2,})") '"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"
#End Region
#Region "Conversion Strings"
        Public titleCon As String() = New String() {"1-Ms", "2-Mrs", "3-Miss"}
        Public retailerCon As String() = New String() {"1-A", "6-F", "2-B", "7-G", "3-C", "8-H", "4-D", "9-I", "5-E"}
        Public brandCon As String() = New String() {"1-A", "6-F", "2-B", "3-C", "4-D", "5-E"}
#End Region
        Public Sub convertValue(ByVal value As String, ByVal conversionType As String())
            Dim separatedChar As String()
            For Each ch As String In conversionType
                separatedChar = ch.Split("-")
                If separatedChar(0) = value Then
                    nextRecord(separatedChar(1))
                    invalid = True
                    Exit For
                End If
            Next
        End Sub
#End Region

        Public Function checkToPO() As Boolean
            For Each rw As DataGridViewRow In PublicDGV.Rows
                If Not rw.Cells(1).Value = "" Then
                    Return False
                End If
            Next
            Return True
        End Function

        Public Function CheckExRules() As Boolean

            validate_Blank(invalid, getValueByField("Code"), ErrorType.OTO)
            checkLeaflet(invalid, getValueByField("Code"), ErrorType.Pullout)
            CheckURN(invalid, getValueByField("URN"), "URN", ErrorType.OTO)
            Return invalid
        End Function

        Public Sub checkTitle(ByRef invalid As Boolean, ByRef value As String, ByRef er_type As String)
            Select Case value.ToUpper
                Case "MR", "MRS", "MISS", "MS", "MASTER", "LADY", "REV", "DR", "MAJOR", "SIR", "CAPT", "PROF", "BRIG", "CPL", ""
                Case Else
                    erMsg = "Invalid Title.. "
                    invalid = True
                    erType = er_type
                    '   getValResult(erType)
            End Select
        End Sub
        Public Sub changeValue(ByVal fld As String, ByRef value As String)
            If erType = ErrorType.OTO Then
                Select Case fld
                    Case "Code", "URN"
                        setValueByField("ExRules", "4")
                        setValueByField("ExRules2", "4")
                End Select
            ElseIf erType = ErrorType.Pullout Then
                Select Case fld
                    Case "Code"
                        value = "*"
                End Select
            End If
        End Sub

        Public Sub checkLeaflet(ByRef invalid As Boolean, ByVal value As String, ByRef er_type As String)
            If Not invalid Then
                If Not leaflet.Contains(value) Then
                    invalid = True
                    erMsg = "Invalid Leaflet Code.."
                    erType = er_type
                    '  getValResult(erType)
                End If
            End If
        End Sub

        Public Sub checkEmail(ByRef invalid As Boolean, ByVal value As String, ByRef er_type As String)
            If Not invalid And Not value = "" Then
                If (Not Regex.Matches(value, "@").Count = 1 Or value.Contains("..")) Or Not value.Contains(".") _
                    Or Regex.Replace(value, "[@.!#$%&'*+/=?^_`{|}~-]", "").Length = 0 _
                    Or Not emailRegex.IsMatch(value) Then
                    invalid = True
                    erMsg = "Invalid Email.."
                    erType = er_type
                End If
            End If
        End Sub

        Public Sub checkCasing(ByRef invalid As Boolean, ByRef value As String, ByVal er_type As String, Optional auto As Boolean = False)
            If Not invalid Then
                Dim newVal As String = ""
                If Not value = "" Then
                    If Not Char.IsLetter(value.Substring(0, 1)) Or Not Char.IsLetter(value.Substring(value.Length - 1, 1)) Then
                        erMsg = "Invalid Value.. "
                        invalid = True
                        erType = er_type
                    Else
                        If auto Then
                            For Each c As String In value
                                If newVal.Length > 0 Then
                                    If newVal.ToUpper.Contains("MC") Then
                                        If newVal.Substring(newVal.Length - 2).ToUpper = "MC" Then
                                            If newVal.Length >= 3 Then
                                                If newVal.Substring(newVal.Length - 3).ToUpper = " MC" Then newVal &= UCase(c) Else newVal &= c
                                            Else : newVal &= UCase(c)
                                            End If
                                            Continue For
                                        ElseIf (newVal.Length >= 3) Then
                                            newVal &= c
                                            Continue For
                                        End If
                                    End If
                                    Select Case newVal.Substring(newVal.Length - 1, 1)
                                        Case " ", "'", "-"
                                            newVal &= UCase(c)
                                        Case Else
                                            newVal &= LCase(c)
                                    End Select
                                ElseIf (newVal.Length = 0) Then
                                    newVal &= UCase(c)
                                End If
                            Next
                            value = newVal
                        Else
                            If Not Char.IsUpper(value.Substring(0, 1)) Then
                                erMsg = "Invalid Casing.. "
                                invalid = True
                                erType = er_type
                            End If
                            For i As Integer = 1 To value.Length - 1
                                Select Case value.Substring(i - 1, 1)
                                    Case " ", "'", "-"
                                        If Not Char.IsUpper(value.Substring(i, 1)) Then
                                            erMsg = "Invalid Casing.. "
                                            invalid = True
                                            erType = er_type
                                        End If
                                    Case Else
                                        If Not Char.IsLower(value.Substring(i, 1)) And Char.IsLetter(value.Substring(i, 1)) Then
                                            erMsg = "Invalid Casing.. "
                                            invalid = True
                                            erType = er_type
                                        End If
                                End Select
                            Next
                        End If
                    End If
                End If
            End If
        End Sub

        Public Sub checkCode(ByRef invalid As Boolean, ByVal value As String, ByVal format As String(), ByVal er_type As String)
            If Not value = "" Then
                Dim tmp As String = ""
                For Each c As Char In value
                    If Char.IsLetter(c) Then
                        tmp &= "A"
                    ElseIf Char.IsNumber(c) Then
                        tmp &= "N"
                    Else
                        tmp &= c.ToString
                    End If
                Next

                Dim match As Boolean = False
                For Each f As String In format
                    If tmp = f Then
                        match = True
                        Exit For
                    End If
                Next

                If Not match Then
                    erMsg = "Invalid Format.. "
                    invalid = True
                    erType = er_type
                End If
            End If
        End Sub

        Public Sub CheckURN(ByRef invalid As Boolean, ByVal value As String, ByVal fieldname As String, ByRef er_type As String)
            Dim GrandTotal As Integer
            Dim Multiplier As Integer
            Dim Weighting As Integer
            Dim ChekDgit As Integer
            GrandTotal = 0
            If invalid = False Then
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
                            invalid = False
                        Else
                            erMsg = "Invalid URN.."
                            invalid = True
                        End If
                    Else
                        erMsg = "Invalid length.."
                        invalid = True
                    End If
                Else
                    erMsg = "Blank value.."
                    invalid = True
                End If
                If invalid = True Then
                    erType = er_type
                    ' getValResult(er_type)
                End If
            End If
        End Sub

        Public Sub checkPhone(ByRef invalid As Boolean, ByRef value As String, ByRef er_type As String)
            If Not invalid Then
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
                                erMsg = "Invalid Value, the first 2 digits must start with: " & vbNewLine _
                                    & " 01, 02, 03, 07 and 08."
                                invalid = True
                                erType = er_type
                        End Select
                End Select
            End If
        End Sub


        Public Sub checkAccounts(ByRef invalid As Boolean, ByRef value As String, ByRef er_type As String)
            If Not invalid And Not value = "" Then
                Dim _accounts As New List(Of String)
                _accounts.Add(value)
                For i As Integer = CurrentRow - 1 To 0 Step -1
                    Select Case PublicDGV.Rows(i).Cells(0).Value
                        Case "accounts1", "accounts2", "accounts3", "accounts4", "accounts5", "accounts6", "accounts7", "accounts8"
                            Dim i_value As String = PublicDGV.Rows(i).Cells(1).Value
                            If _accounts.Contains(i_value) Then
                                erMsg = "Duplicate Accounts found.."
                                invalid = True
                                erType = er_type
                            Else ': _accounts.Add(i_value)
                            End If
                    End Select
                Next

            End If
        End Sub
        Public Sub checkMailingFiles(ByRef invalid As Boolean, ByRef value As String, ByRef er_type As String)
            If Not invalid And Not value = "" And Not value = "*" Then
                Dim data As String() = populateData(value)
                If data(1) = "" Then
                    erMsg = "Invalid Client Number.."
                    invalid = True
                    erType = er_type
                Else
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
                End If
            End If
        End Sub

#End Region

#Region "IDisposable Members"
        Public Sub Dispose() Implements IDisposable.Dispose
            erMsg = ""
            erType = ""
            invalid = False
            erType = ""
        End Sub
#End Region

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Module
