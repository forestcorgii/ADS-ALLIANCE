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


Module Lookup
    Public l1 As New DataTable
    Public l1l As New List(Of String)
    Private ls1 As New List(Of String)

    Public Sub LookupSetup()
        l1 = New DataTable
        Dim lconn As New OleDbConnection
        mdbOpen(String.Format("{0}\LookUp\STORE.mdb", Application.StartupPath), lconn)
        mdbToDT(String.Format("SELECT STORE FROM DATA001"), l1, lconn)
        DTtoList(ls1, l1)
    End Sub
    Private Sub DTtoList(ByRef l As List(Of String), ByVal dt As DataTable)
        l = New List(Of String)
        If dt IsNot Nothing Then
            For Each n As DataRow In dt.Rows
                l.Add(n.Item(0).ToString)
            Next
        End If
    End Sub

    Public Sub setLookUp(ByVal hasLookUp As Boolean)
        l1l = New List(Of String)
        If hasLookUp = True Then
            Select Case FIELDNAME
                Case "SNumb", "SNum"
                    l1l = ls1
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub
End Module
