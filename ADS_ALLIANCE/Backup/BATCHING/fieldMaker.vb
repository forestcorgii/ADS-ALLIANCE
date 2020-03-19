Imports System.Windows.Forms
Imports System.IO
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.Diagnostics.Process

Imports System.Text.RegularExpressions
Public Class fieldMaker
    'Private dtBat, dtC, dtTick As DataTable
    'Private client As String = JobInfo.Client
    'Private job As String = JobInfo.Job
    'Private jobcode As String = jobCode
    Private oldMdb_conn As OleDbConnection

    Public Sub New(ByVal cb As ComboBox)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        cbCLIENT.Items.Clear()
        For Each i As String In cb.Items
            cbCLIENT.Items.Add(i)
        Next
        If cbCLIENT.Items.Count > 0 Then
            cbCLIENT.SelectedIndex = 0
        End If
   
       End Sub

    Private Sub fieldMaker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' fieldMaker_setup()
    End Sub

#Region "Public Properties"
    Private Property JOB() As String
        Get
            Return cbJOB.Text
        End Get
        Set(ByVal value As String)
            cbJOB.Text = value
        End Set
    End Property

    Private Property JOBCODE() As String
        Get
            Return cbJOBCODE.Text
        End Get
        Set(ByVal value As String)
            cbJOBCODE.Text = value
        End Set
    End Property

    Public Property CLIENT() As String
        Get
            Return cbCLIENT.Text
        End Get
        Set(ByVal value As String)
            cbCLIENT.Text = value
        End Set
    End Property
#End Region

#Region "Tables Class"
    Public Class tbl
        Public _name As String
        Public _dt As DataTable

        Public Sub New(ByVal d As DataTable, ByVal n As String)
            name = n
            dt = d
        End Sub

        Public Property name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property dt() As DataTable
            Get
                Return _dt
            End Get
            Set(ByVal value As DataTable)
                _dt = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return name
        End Function
    End Class

    Private Sub tblFromMDB()
        Dim ask As DialogResult = OFD1.ShowDialog
        If ask = Windows.Forms.DialogResult.OK Then
            mdbOpen(OFD1.FileName, oldMdb_conn)
            Dim tmpList As List(Of String) = getTables(oldMdb_conn)

            If tmpList.Count > 0 Then
                Dim tmp As New DataTable
                For Each i As String In tmpList
                    mdbToDT(String.Format("SELECT * FROM {0}", i), tmp, oldMdb_conn)
                    lbTBL.Items.Add(New tbl(tmp, i))
                Next
                lbTBL.SelectedIndex = 0
            Else
                MsgBox("No tables!!")
            End If
        End If
    End Sub
#End Region

#Region "Controls"

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btdAdd.Click
        dgv.Rows.Add("Field" & dgv.Rows.Count)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        For i As Integer = 0 To dgv.SelectedRows.Count - 1
            dgv.Rows.Remove(dgv.SelectedRows(0))
        Next
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        dgv.Rows.Insert(dgv.SelectedRows(0).Index, "field" & dgv.Rows.Count)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save_Job()
         End Sub
#End Region

#Region "DGV function"
    Public Property currentRow() As Integer
        Get
            Return dgv.CurrentCell.RowIndex
        End Get
        Set(ByVal value As Integer)
            dgv.CurrentCell = dgv.Item(0, value)
        End Set
    End Property

#End Region

    'Private Sub fieldMaker_setup()
    '    Try
    '        '     gatherClients(ClientDIR)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Function check_Jobcode(Optional ByVal getcount As Boolean = False) As Boolean
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("SELECT jobCode FROM " & JOB, conClient)
        da.Fill(dt)
        If getcount = True Then If dt.Rows.Count = 0 Then Return False Else Return True
        For i As Integer = 0 To dt.Rows.Count - 1
            If cbJOBCODE.Text = dt.Rows(i).Item(0).ToString Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub load_Fields(ByVal dt As DataTable)
        If dt Is Nothing Then Exit Sub
        dgv.Rows.Clear()
        If dt.Columns.Count <> 0 Then
            If dt.Columns(0).ColumnName <> "Jobcode" Then
                dgv.Rows.Add("Jobcode")
            End If
            For i As Integer = 0 To dt.Columns.Count - 1
                dgv.Rows.Add(dt.Columns(i).ColumnName)
            Next
        End If
    End Sub

    Public Sub change_Jobcode()
        Dim dt As New DataTable
        mdbToDT("SELECT * FROM " & job, dt, conClient)

        cbJOBCODE.Items.Clear()
        For jc As Integer = 0 To dt.Rows.Count - 1
            cbJOBCODE.Items.Add(dt.Rows(jc).Item("Jobcode").ToString)
        Next
        cbJOBCODE.SelectedIndex = 0
        mdbToDT("SELECT * FROM " & lbTBL.SelectedItem, lbTBL.SelectedItem, conClient)
    End Sub

    Private Sub cbJobcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbJOBCODE.KeyDown
        If e.KeyCode = Keys.Enter Then
            jobcode = cbJOBCODE.Text
            dgv.Rows(0).Cells(1).Value = jobcode
            MsgBox("New Jobcode: " & jobcode)
            currentRow = currentRow() + 1
            dgv.Focus()
        End If
    End Sub
  

    Private Sub fieldMaker_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then

        ElseIf e.KeyCode = Keys.F1 Then
            tblFromMDB()
        ElseIf e.KeyCode = Keys.F2 Then
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnAddCLIENT.PerformClick()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.A Then
            btdAdd.PerformClick()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.I Then
            btnInsert.PerformClick()
        ElseIf e.Alt AndAlso e.KeyCode = Keys.D Then
            btnDelete.PerformClick()
        End If
    End Sub

   

    Private Sub create_Table(ByVal dt As DataTable, ByVal tblName As String, ByRef con As OleDbConnection, Optional ByVal addJC As Boolean = False)
        If dt Is Nothing Then Exit Sub

        Dim qry As String = "CREATE TABLE " & tblName & "("
        If addJC = True Then qry += "[Jobcode] text(8), [" & dt.Columns(0).ColumnName & "] text(3)" Else qry += "[" & dt.Columns(0).ColumnName & "] text(3)"
        For i As Integer = 1 To dt.Columns.Count - 1
            qry += ", [" & dt.Columns(i).ColumnName & "] text(3)"

        Next
        qry += ")"
        executeqry(qry, con)
    End Sub

    Private Sub save_fieldInfo(ByVal tbl As String, ByVal dg As DataGridView, ByVal con As OleDbConnection)
        If dg Is Nothing Then Exit Sub

        For Each i As DataGridViewRow In dg.Rows
            If i.Cells(0).Value = "Recnum" Or i.Cells(0).Value = "Jobcode" Then
            Else
                executeQRY(String.Format("INSERT INTO {0}([Field]) VALUES('{1}')", tbl, i.Cells(0).Value), conClient)
            End If
        Next

    End Sub

    Private Sub save_Job()
        Dim tmplist As List(Of String) = getTables(conClient)
        If tmplist.Contains(job & "_Field") = False Then
            mdbCreateTable(job & "_Field", dgv, "text(15)", conClient)
            mdbCreateTable(JOB, New String() {"Jobcode-text(30)", "Keyword-text(30)", "Substring-text(30)", "Landscape-YESNO", "E1Only-YESNO", "TwoPages-YESNO", "Record_Counting-text(30)", "Header-text(30)", "Batchsize-text(10)"}, conClient)
            save_fieldInfo(JOB & "_FieldInfo", dgv, conClient)
            MsgBox("Saved!")
        Else
            If MsgBox("All data will be erased.. do you want to overwrite??", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                executeQRY("DELETE * FROM " & JOB & "_FieldInfo", conClient)
                executeQRY("DELETE * FROM " & JOB & "_Groups", conClient)
                executeQRY("DROP TABLE " & JOB & "_Field", conClient)
                mdbCreateTable(JOB & "_Field", dgv, "text(15)", conClient)
                Dim tmp As New DataTable
                mdbToDT("SELECT Jobcode FROM " & JOB, tmp, conClient)
                For Each i As DataRow In tmp.Rows
                    mdbInsert(JOB & "_Field", New String() {"Jobcode"}, New String() {i.Item(0).ToString}, conClient)
                Next
                save_fieldInfo(JOB & "_FieldInfo", dgv, conClient)
                MsgBox("Saved!")
            End If
        End If

         End Sub


#Region "OPEN"
    Private Sub btnOPEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOPEN.Click
        tblFromMDB()
    End Sub
#End Region

    Private Sub lb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTBL.SelectedIndexChanged
        If lbTBL.SelectedItem IsNot Nothing Then
            load_Fields(DirectCast(lbTBL.SelectedItem, tbl).dt)
        End If
    End Sub




#Region "Client"
    Private Sub btnAddCLIENT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCLIENT.Click
        Using cl As New clientInformation(cbCLIENT)
            cl.ShowDialog()
            cbCLIENT.Items.Clear()
            For Each i As String In cl.cbClient.Items
                cbCLIENT.Items.Add(i)
            Next
            If cbCLIENT.Items.Count > 0 Then
                cbCLIENT.SelectedIndex = 0
            End If
        End Using
    End Sub

    'Private Sub gatherClients(ByVal path As String)
    '    Dim tmp As String() = IO.Directory.GetFiles(path, "*.mdb")

    '    If tmp.Length <> 0 Then
    '        For Each i As String In tmp
    '            cbCLIENT.Items.Add(IO.Path.GetFileNameWithoutExtension(i))
    '        Next
    '        If cbCLIENT.Items.Count > 0 Then
    '            cbCLIENT.SelectedIndex = 0
    '        End If
    '    Else

    '    End If
    'End Sub

    Private Sub cbCLIENT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCLIENT.SelectedIndexChanged
        CLIENT = cbCLIENT.SelectedItem
        mdbOpen(String.Format("{0}{1}.mdb", ClientDIR, CLIENT), conClient)

        Dim tmp As New DataTable
        mdbToDT("SELECT * FROM " & CLIENT, tmp, conClient)

        cbJOB.Items.Clear()
        If tmp.Rows.Count <> 0 Then
            For Each i As DataRow In tmp.Rows
                cbJOB.Items.Add(i.Item(0).ToString)
            Next
            If cbJOB.Items.Count > 0 Then
                cbJOB.SelectedIndex = 0
            End If
        End If
    End Sub

#End Region

#Region "JOB"
    Private Sub btnAddJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJOB.Click
        If Not CLIENT = "" Then
            Using cl As New jobInformation(CLIENT, cbJOB)
                cl.ShowDialog()
                cbJOB.Items.Clear()
                For Each i As String In cl.cbJob.Items
                    cbJOB.Items.Add(i)
                Next
                If cbJOB.Items.Count > 0 Then
                    cbJOB.SelectedIndex = 0
                    btnOPEN.PerformClick()
                End If
            End Using
        End If
    End Sub

    Private Sub cbJOB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJOB.SelectedIndexChanged
        JOB = cbJOB.SelectedItem

        Dim tmp As New DataTable
        mdbToDT("SELECT * FROM " & JOB & "_Field", tmp, conClient)

        load_Fields(tmp)
        cbJOBCODE.Items.Clear()
        If tmp.Rows.Count <> 0 Then
            For Each i As DataRow In tmp.Rows
                cbJOBCODE.Items.Add(i.Item(0).ToString)
            Next
            If cbJOB.Items.Count > 0 Then
                cbJOB.SelectedIndex = 0
            End If
        End If
    End Sub
#End Region

#Region "Job code"
    Private Sub btnAddJOBCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJOBCODE.Click
        Dim tmp As String = msgBox_in("Job code: ", "Add Jobcode", "", False)

        If getTables(conClient).Contains(JOB & "_Field") Then

        If MsgBox(String.Format("Add {0} in {1}??", tmp, JOB), MsgBoxStyle.YesNo, "Add Client") = MsgBoxResult.Yes Then
                cbJOBCODE.Items.Add(tmp)
                JOBCODE = tmp

                mdbInsert(JOB, New String() {"Jobcode"}, New String() {JOBCODE}, conClient)
                mdbInsert(JOB & "_Field", New String() {"Jobcode"}, New String() {JOBCODE}, conClient)
                mdbCreateTable(JOBCODE & "_Groups", New String() {"Group-int", "Coordinate-text(50)"}, conClient)
                mdbCreateTable(JOBCODE & "_Coordinate", New String() {"Field-text(20)", "Coordinate-text(50)"}, conClient)
                save_fieldInfo(JOBCODE & "_Coordinate", dgv, conClient)
            End If
        Else
            MsgBox(String.Format("JOB: {0} have no saved fields", JOB))
        End If
    End Sub

    Private Sub cbJobcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJOBCODE.SelectedIndexChanged
        'Dim tmp As New DataTable

        JOBCODE = cbJOBCODE.SelectedItem
        'mdbToDT("SELECT * FROM " & JOB, tmp, conClient)
        'load_Fields(DirectCast(lbTBL.SelectedItem, tbl).dt)
    End Sub
#End Region
    
   
End Class
