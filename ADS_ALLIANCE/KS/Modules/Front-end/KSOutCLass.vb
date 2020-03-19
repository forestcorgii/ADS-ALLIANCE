Imports System.IO

Public Class KSOutCLass
    Implements IDisposable
#Region "Pullout Strings"
    Public exflag, code, exrules As String
#End Region
#Region "Variables for Reformat Process"
    Public RECORD, PULLOUT As Integer
     Public batchName As String
    Public JOBCODE As String

    Public TEMPPATH As String

    Public KSPERMDB, KSPERBATCH, KSPERROW As Integer

#End Region

    Public Sub New(BATCH As String, jobfolder As String)
        '   zipFileToJobcode(batchName)
        JOBCODE = MNJOBCODE

        '===========Flag List============'
        PulloutList(JOBCODE, PulloutFlag)
        '===========Field List=========='
        MotherFieldlist(JOBCODE, MotherField)
        '=============END==============='

        For Each MDB As String In Directory.GetFiles(BATCH & "\" & jobfolder, "*.mdb")
            mdbOpen(MDB, conData)
            refresh_DT(conData)
            KSPERMDB += RUN(dtData001, jobfolder)
        Next
        KSPERBATCH = KSPERMDB
        KSPERMDB = 0
    End Sub

#Region "RUN REFORMAT"
    Public Function RUN(DT As DataTable, jobfolder As String) As Integer
        For Each ROW As DataRow In DT.Rows
             If Not FLAG(ROW, PulloutFlag) Then
                RECORD += 1
                KSPERROW += COUNTE1(ROW, jobfolder)
                KSPERROW += COUNTE2(ROW, jobfolder)
            Else
                PULLOUT += 1  'plus pullout
            End If
        Next
        KSPERMDB = KSPERROW
        KSPERROW = 0

        Return KSPERMDB
    End Function

#Region "DATA"
    Public Function COUNTE1(ROW As DataRow, jobfolder As String) As Integer
        Select Case jobfolder
            Case JobFolders.E1 ', JobFolders.C1
                For Each M As FieldClass In MotherField
                    Try
                        Select Case M.name
                            Case "country1", "country2", "country3", "personal_identifier1", "personal_identifier2", "personal_identifier3"
                                If M.name = "country1" Then
                                    COUNTE1 += ROW.Item(M.name).ToString.Replace("''", "'").Length + 1
                                End If
                            Case Else
                                If ROW.Item(M.name).ToString.Length = M.length Then
                                    COUNTE1 += ROW.Item(M.name).ToString.Replace("''", "'").Length
                                Else
                                    COUNTE1 += ROW.Item(M.name).ToString.Replace("''", "'").Length + 1
                                End If
                        End Select
                    Catch : End Try
                Next
            Case JobFolders.C1
                For Each M As FieldClass In MotherField
                    Try
                        If ROW.Item(M.name).ToString.Length = M.length Then
                            COUNTE1 += ROW.Item(M.name).ToString.Replace("''", "'").Length
                        Else
                            COUNTE1 += ROW.Item(M.name).ToString.Replace("''", "'").Length + 1
                        End If
                    Catch : End Try
                Next
        End Select
        Return COUNTE1
    End Function

    Public Function COUNTE2(ROW As DataRow, jobfolder As String) As Integer
        Select Case jobfolder
            Case JobFolders.E2 ', JobFolders.C1
                For Each M As FieldClass In MotherField
                    Try
                        Select Case M.name
                            Case "country1", "country2", "country3", "personal_identifier1", "personal_identifier2", "personal_identifier3"
                                If M.name = "country1" Then
                                    COUNTE2 += ROW.Item(M.name).ToString.Replace("''", "'").Length + 1
                                End If
                            Case Else
                                If ROW.Item(M.name).ToString.Length = M.length Then
                                    COUNTE2 += ROW.Item(M.name).ToString.Replace("''", "'").Length
                                Else
                                    COUNTE2 += ROW.Item(M.name).ToString.Replace("''", "'").Length + 1
                                End If
                        End Select
                    Catch : End Try
                Next
        End Select
        Return COUNTE2
    End Function
#End Region
#End Region

#Region "KS METHODS"
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

    Public Sub MotherFieldlist(jobcode As String, ByRef FieldList As List(Of FieldClass))
        FieldList = New List(Of FieldClass)

        Select Case jobcode
            Case "Cell2"
                addField(FieldList, "client_ref", 100)
                addField(FieldList, "cor_flag", 1)
                '          addField(FieldList, "forename", 100)
                '         addField(FieldList, "surname", 100)
                '        addField(FieldList, "accounts1", 100)
                '       addField(FieldList, "accounts2", 100)
                '      addField(FieldList, "accounts3", 100)
                '     addField(FieldList, "accounts4", 100)
                '    addField(FieldList, "accounts5", 100)
                '   addField(FieldList, "accounts6", 100)
                '  addField(FieldList, "accounts7", 100)
                ' addField(FieldList, "accounts8", 100)
                addField(FieldList, "uk_nat_tick", 1)
                addField(FieldList, "ni_number", 100)
                addField(FieldList, "ni_tick", 1)
                addField(FieldList, "country1", 100)
                addField(FieldList, "personal_identifier1", 100)
                addField(FieldList, "country2", 100)
                addField(FieldList, "personal_identifier2", 100)
                addField(FieldList, "country3", 100)
                addField(FieldList, "personal_identifier3", 100)
                addField(FieldList, "signature", 1)
                addField(FieldList, "date", 6)
                addField(FieldList, "exception", 1)
        End Select
    End Sub

#End Region

#Region "Field Class"
    Public MotherField As New List(Of FieldClass)

    Public Class FieldClass
        Public name As String
        Public length As Integer
    End Class

    Public Sub addField(list As List(Of FieldClass), name As String, length As Integer)
        Dim FC As New FieldClass
        FC.name = name
        FC.length = length

        list.Add(FC)
    End Sub
#End Region

#Region "Flag Class"
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

#Region "IDisposable Members"
    Public Sub Dispose() Implements IDisposable.Dispose
        KSPERBATCH = 0
        RECORD = 0
        PULLOUT = 0
    End Sub
#End Region
End Class
