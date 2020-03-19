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
        Public Const LessThanLen As String = "Greater"
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
            End If
         End Sub

        Public Sub New(ByVal fld As String, ByVal value As String)
            'Additional Validations
            Select Case fld
                Case "Code"
                    validate_Blank(invalid, value, ErrorType.OTO)
                    checkLeaflet(invalid, value, ErrorType.OTO)
                Case "URN"
                    CheckURN(invalid, value, fld, ErrorType.OTO)
                Case "PromoCode"
                     validate_Length(invalid, value, New Integer() {5}, LengthType.LessThanLen, ErrorType.OTO)
                    checkCode(invalid, value, promoCodeFormat, ErrorType.OTO)
                Case "SNumb", "SNum"
                    checkLookup(invalid, value, l1l, ErrorType.OTO)
                Case "Sname"
                    validate_Blank(invalid, value, ErrorType.OTO)
                    validate_Length(invalid, value, New Integer() {1}, LengthType.GreaterThanLen, ErrorType.OTO)
                    'Case "Fname"
                Case "Title"
                    checkTitle(invalid, value, ErrorType.OTO)
                Case "Add1", "Town", "County"
                    validate_Blank(invalid, value, ErrorType.OTO)
                Case "Add2", "Add3"
                    'Case "Town", "County" 
                Case "Pcode"
                    validate_Blank(invalid, value, ErrorType.OTO)
                Case "QAS"
                    validate_Blank(invalid, value, ErrorType.Required)
                Case "Tel"
                    validate_Length(invalid, value, New Integer() {10}, LengthType.LessThanLen, ErrorType.OTO)
                Case "Email"
                    validate_Regex(invalid, value, emailRegex, ErrorType.OTO)
                    ' Case "Q1"
                Case "TDate"
                    validate_Length(invalid, value, New Integer() {6}, LengthType.ExactLen, ErrorType.Required)
                    validate_Date(invalid, value, noRange, noRange, noRange, ErrorType.OTO)
                Case "Ydob"
                    validate_Length(invalid, value, New Integer() {6}, LengthType.ExactLen, ErrorType.Required)
                    validate_Date(invalid, value, noRange, noRange, noRange, ErrorType.OTO)
                    'Case "C1-Gender", "C2-Gender", "C3-Gender"
                Case "C1-Dob", "C2-Dob", "C3-Dob"
                    validate_Length(invalid, value, New Integer() {6}, LengthType.ExactLen, ErrorType.Required)
                    validate_Date(invalid, value, noRange, noRange, noRange, ErrorType.OTO)
                    'Case "Brand"
                    'Case "Retailer"
                Case "Dpack"
                    validate_Date(invalid, value, noRange, noRange, noRange, ErrorType.OTO)
                Case "KidPCode"
                    checkCode(invalid, value, kidPCodeFormat, ErrorType.OTO)
                    'Case "ExFlag", "ExFlag2"
                    'case "ExRules"
                    'Case "ExRules2"
            End Select

               'validate_Regex(invalid, value, erMsg)
            'validate_Length(invalid, value.Length, erMsg)
            'validate_Blank(invalid, value, erMsg)
            'validate_Dup(invalid, value, erMsg)
            'validate_Date(invalid, value, erMsg)
            'validate_DueDate(invalid, value, erMsg)

            sendPrompt(fld, value)
        End Sub

        Public Sub sendPrompt(ByVal fld As String, ByVal value As String)
            If invalid Then
                getValResult(erType)
                Select Case erType
                    Case ErrorType.OTO
                        If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            CurrentRow += 1
                            invalid = False
                            changeValue(fld)
                        End If
                    Case ErrorType.Required
                        msgBoxOUT(erMsg, fld, MessageBoxButtons.OK)
                    Case ErrorType.Pullout
                        If msgBoxOUT(erMsg, fld, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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

            If (CurrentRow + 1) = PublicDGV.Rows.Count Then
                SAVE(IIf(Mode = mymode.Entry_Mode, "ENTRY", "EDIT"))
            ElseIf forceSaving = True Then
                If Mode = mymode.Entry_Mode Then
                    If msgBoxOUT("Are You sure You want to Save?", "Force Save", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                        invalid = True
                        PublicTB.Undo()
                        CurrentFieldValue = value
                    End If
                End If
            Else
                CurrentRow += 1
            End If
        End Sub

        Public Sub pullout(ByVal value As String)
            EDATA = value
            nextRecord(EDATA)
            For i As Integer = CurrentRow To PublicDGV.Rows.Count - 1
                PublicDGV.Rows(i).Cells(1).Value = ""
            Next
            SAVE(IIf(Mode = mymode.Entry_Mode, "ENTRY", "EDIT"))
        End Sub

        Public Sub checkLookup(ByRef invalid As Boolean, ByVal value As String, ByVal l As List(Of String), ByVal er_type As String)
            If Haslookup Then
                If Not l.Contains(value) Then
                    invalid = True
                    erMsg = "This value is not on the lookup. "
                    erType = er_type
                    'getValResult(er_type)
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
                erType = ErrorType.Pullout
                'getValResult(erType)
                invalid = True
            End If
        End Sub

        Private Sub validate_Regex(ByRef invalid As Boolean, ByVal value As String, ByVal reg As String, ByRef er_type As String)
            If Not value = "" Then
                If Not reg = "" Then
                    If Regex.IsMatch(value, reg, RegexOptions.IgnoreCase) = False Then
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
                                If txtL > Integer.Parse(rng(0)) Then invalid = False Else invalid = True
                            Case LengthType.LessThanLen
                                If txtL < Integer.Parse(rng(0)) Then invalid = False Else invalid = True
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
                    erMsg = "Blank value. "
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
                        erType = er_type
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
                    If day <> noRange And month <> noRange And year <> noRange Then
                        date_RangeA = getExactDate_Date(dd_rng(0), mm_rng(0), yy_rng(0), "ddMMyyyy")
                        date_RangeB = getExactDate_Date(dd_rng(1), mm_rng(1), yy_rng(1), "ddMMyyyy")
                        If date_Entered < date_RangeA Or date_Entered > date_RangeB Then
                            invalid = True
                            erMsg = " Invalid Range Detected(" & valMessage & ").."
                            erType = er_type
                        End If
                    End If
                   If date_Entered > date_now Then
                        invalid = True
                        erMsg = "Future Date Detected.. "
                        erType = er_type
                    End If
                End If
                'If invalid = True Then
                '    getValResult(erType)
                'End If
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
                mm -= 1
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
                            Dim leaf = Val(mm) Mod 4
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
                    invalid = False
                Else
                    invalid = True
                End If

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
                    nextRecord(separatedChar(1))
                    invalid = True
                    Exit For
                End If
            Next
        End Sub
#End Region
        Public Sub checkTitle(ByRef invalid As Boolean, ByRef value As String, ByRef er_type As String)
            Select Case value
                Case "MR", "MRS", "MISS", "MS", "MASTER", "LADY", "REV", "DR", "MAJOR", "SIR", "CAPT", "PROF", "BRIG", "CPL", ""
                Case Else
                    erMsg = "Invalid Title.. "
                    invalid = True
                    erType = er_type
                    '   getValResult(erType)
            End Select
        End Sub
        Public Sub changeValue(ByVal fld As String)
            Select Case fld
                Case "Code", "URN"
                    changeValueByField("ExRules", "4")
            End Select
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
        'Public Sub CheckCode(ByRef invalid As Boolean, ByVal value As String, ByRef er_type As String)
        '    If Not invalid Then
        '        If value <> "" Then
        '            If Not Char.IsLetter(value.Substring(0, 2)) Or Not Char.IsNumber(value.Substring(2, 3)) Then
        '                erMsg = "Invalid Promo Code... "
        '                invalid = True
        '                erType = er_type
        '                getValResult(erType)
        '            End If
        '        End If
        '    End If
        'End Sub

        Public Sub checkCode(ByVal invalid As Boolean, ByVal value As String, ByVal format As String(), ByVal er_type As String)
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

            For Each f As String In format
                If Not tmp = f Then
                    erMsg = "Invalid Format.. "
                    invalid = True
                    erType = er_type
                    '         getValResult(erType)
                    Exit For
                End If
            Next
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
#End Region

#Region "IDisposable Members"
        Public Sub Dispose() Implements IDisposable.Dispose
            erMsg = ""
            erType = ""
            invalid = False
        End Sub
#End Region
    End Class
End Module
