Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class InfoBox
    Private dtInfo As DataTable
    Private con As New OleDbConnection
    Private jobcodeList As New List(Of String)

    Public Class jobCodeVar
        Public jobcode, header, keyword, substring, reccount, batchsize As String
        Public e1only, twopages, landscape As Boolean
        Public jobFieldDT As DataTable
    End Class
    Public Class jobcodeINFO
        Public jc, head, kw, sb, bs, rc As String
        Public e1, p2, lnd As Boolean
        Public jbFldDT As DataTable

        Public Sub New(ByVal j As jobCodeVar)
            JOBCODE = j.jobcode
            JOBFIELD = j.jobFieldDT

            KEYWORD = j.keyword
            SUBSTRING = j.substring
            RECCOUNT = j.reccount
            HEADER = j.header
            E1ONLY = j.e1only
            TWOPAGES = j.twopages
            LANDSCAPE = j.landscape
            BATCHSIZE = j.batchsize

        End Sub

        Public Property JOBFIELD() As DataTable
            Get
                Return jbFldDT
            End Get
            Set(ByVal value As DataTable)
                jbFldDT = value
            End Set
        End Property

        Public Property JOBCODE() As String
            Get
                Return jc
            End Get
            Set(ByVal value As String)
                jc = value
            End Set
        End Property

        Public Property BATCHSIZE() As String
            Get
                Return bs
            End Get
            Set(ByVal value As String)
                bs = value
            End Set
        End Property

        Public Property KEYWORD() As String
            Get
                Return kw
            End Get
            Set(ByVal value As String)
                kw = value
            End Set
        End Property

        Public Property SUBSTRING() As String
            Get
                Return sb
            End Get
            Set(ByVal value As String)
                sb = value
            End Set
        End Property

        Public Property RECCOUNT() As String
            Get
                Return rc
            End Get
            Set(ByVal value As String)
                rc = value
            End Set
        End Property

        Public Property HEADER() As String
            Get
                Return head
            End Get
            Set(ByVal value As String)
                head = value
            End Set
        End Property

        Public Property E1ONLY() As Boolean
            Get
                Return e1
            End Get
            Set(ByVal value As Boolean)
                e1 = value
            End Set
        End Property

        Public Property TWOPAGES() As Boolean
            Get
                Return p2
            End Get
            Set(ByVal value As Boolean)
                p2 = value
            End Set
        End Property

        Public Property LANDSCAPE() As Boolean
            Get
                Return lnd
            End Get
            Set(ByVal value As Boolean)
                lnd = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return JOBCODE
        End Function
    End Class

    Public Sub New(ByVal cl As String, ByVal j As String, ByVal conn As OleDbConnection)
        InitializeComponent()

        CLIENT = cl
        JOB = j
        con = conn

        gatherJOBCODE()
    End Sub

    Public Sub gatherJOBCODE()
        Dim jobinfoDT, jobFieldDT As New DataTable
        jobcodeList = New List(Of String)

        mdbToDT("SELECT * FROM " & JOB, jobinfoDT, con)
      
        If jobinfoDT.Rows.Count <> 0 Then
            cbJobcode.Items.Clear()
            For Each i As DataRow In jobinfoDT.Rows
                Dim j As New jobCodeVar
                j.e1only = i.Item("E1Only")
                j.twopages = i.Item("TwoPages")
                j.landscape = i.Item("Landscape")
                j.header = i.Item("Header").ToString
                j.jobcode = i.Item("Jobcode").ToString
                j.batchsize = i.Item("Batchsize").ToString
                j.keyword = i.Item("Keyword").ToString
                j.substring = i.Item("Substring").ToString
                j.reccount = i.Item("Record_Counting").ToString
                jobcodeList.Add(i.Item("Jobcode").ToString)
                mdbToDT(String.Format("SELECT * FROM {0}_Field WHERE Jobcode = '{1}'", JOB, i.Item("Jobcode").ToString), jobFieldDT, con)
                j.jobFieldDT = jobFieldDT
                cbJobcode.Items.Add(New jobcodeINFO(j))
            Next
            cbJobcode.SelectedIndex = cbJobcode.Items.Count - 1
            set_Info()
        Else
            mdbToDT(String.Format("SELECT * FROM {0}_Field ", JOB), jobFieldDT, con)
            load_Fields(jobFieldDT)
        End If
     End Sub

    Private Sub load_Fields(ByVal dt As DataTable)
        If dt Is Nothing Then Exit Sub
        dgv.Rows.Clear()

        For i As Integer = 0 To dt.Columns.Count - 1
            If dt.Columns(i).ColumnName <> "Jobcode" Then
                If dt.Rows.Count <> 0 Then
                    dgv.Rows.Add(dt.Columns(i).ColumnName, dt.Rows(0).Item(i))
                Else
                    dgv.Rows.Add(dt.Columns(i).ColumnName, "")
                End If
            End If
        Next

    End Sub

#Region "Public Properties"
    Public Property CLIENT() As String
        Get
            Return lbCLIENT.Text
        End Get
        Set(ByVal value As String)
            lbCLIENT.Text = value
        End Set
    End Property

    Public Property JOB() As String
        Get
            Return lbJOB.Text
        End Get
        Set(ByVal value As String)
            lbJOB.Text = value
        End Set
    End Property

    Public Property JOBCODE() As String
        Get
            Return cbJobcode.Text
        End Get
        Set(ByVal value As String)
            cbJobcode.Text = value
        End Set
    End Property

    Public Property KEYWORD() As String
        Get
            Return tbKW.Text
        End Get
        Set(ByVal value As String)
            tbKW.Text = value
        End Set
    End Property

    Public Property SUBSTRING() As String
        Get
            Return tbSUB.Text
        End Get
        Set(ByVal value As String)
            tbSUB.Text = value
        End Set
    End Property

    Public Property RECCOUNT() As String
        Get
            Return tbREC.Text
        End Get
        Set(ByVal value As String)
            tbREC.Text = value
        End Set
    End Property

    Public Property HEADER() As String
        Get
            Return tbHEADER.Text
        End Get
        Set(ByVal value As String)
            tbHEADER.Text = value
        End Set
    End Property

    Public Property BATCHSIZE() As String
        Get
            Return tbBS.Text
        End Get
        Set(ByVal value As String)
            tbBS.Text = value
        End Set
    End Property

    Public Property E1ONLY() As Boolean
        Get
            Return chE1Only.Checked
        End Get
        Set(ByVal value As Boolean)
            chE1Only.Checked = value
        End Set
    End Property

    Public Property TWOPAGES() As Boolean
        Get
            Return chTWOPAGES.Checked
        End Get
        Set(ByVal value As Boolean)
            chTWOPAGES.Checked = value
        End Set
    End Property


    Public Property LANDSCAPE() As Boolean
        Get
            Return chLANDSCAPE.Checked
        End Get
        Set(ByVal value As Boolean)
            chLANDSCAPE.Checked = value
        End Set
    End Property

#End Region
    
    Private Sub cbJobcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJobcode.SelectedIndexChanged
        JOBCODE = DirectCast(cbJobcode.SelectedItem, jobcodeINFO).JOBCODE
        set_Info()
     End Sub
   
    Public Sub set_Info()
        Dim j As jobcodeINFO = cbJobcode.SelectedItem
        With j
            KEYWORD = .KEYWORD
            BATCHSIZE = .BATCHSIZE
            SUBSTRING = .SUBSTRING
            HEADER = .HEADER
            RECCOUNT = .RECCOUNT
            LANDSCAPE = .LANDSCAPE
            E1ONLY = .E1ONLY
            TWOPAGES = .TWOPAGES
            load_Fields(.JOBFIELD)
        End With
    End Sub

    Private Sub InfoBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            If MsgBox("Do you want to save?", MsgBoxStyle.YesNo, "Save Information") = MsgBoxResult.Yes Then
                tickUpdate(JOB & "_Field", dgv)
                mdbUpdate(JOB, New String() {"Batchsize", "Keyword", "Substring", "Header", "E1Only", "TwoPages", "Record_Counting", "Landscape"}, New Object() {BATCHSIZE, KEYWORD, SUBSTRING, HEADER, E1ONLY, TWOPAGES, RECCOUNT, LANDSCAPE}, New String() {"Jobcode", JOBCODE}, conClient)
                MsgBox("Saved")
                gatherJOBCODE()
            End If
        End If
        If dgv.Focused = True Then
            If Chr(e.KeyCode) = "1" Or e.KeyCode = Keys.NumPad1 Then
                dgv.Rows(currentRow).Cells(1).Value = "1"
                currentRow = currentRow() + 1
            ElseIf Chr(e.KeyCode) = "0" Or e.KeyCode = Keys.NumPad0 Then
                dgv.Rows(currentRow).Cells(1).Value = "0"
                currentRow = currentRow() + 1
            End If
            'If currentRow() + 1 = dgv.Rows.Count Then
            '    If MsgBox("Do you want to save?", MsgBoxStyle.YesNo, "Save Information") = MsgBoxResult.Yes Then
            '        tickUpdate(JOB & "_Field", dgv)
            '        mdbUpdate(JOB, New String() {"Keyword", "Substring", "Header", "E1Only", "TwoPages", "Record_Counting", "Landscape"}, New String() {KEYWORD, SUBSTRING, HEADER, E1ONLY, TWOPAGES, RECCOUNT, LANDSCAPE}, New String() {"Jobcode", String.Format("'{0}'", JOBCODE)}, con)
            '        MsgBox("Saved")
            '        gatherJOBCODE()
            '    End If
            'End If
        End If
    End Sub

    Public Property currentRow() As Integer
        Get
            Return dgv.CurrentCell.RowIndex
        End Get
        Set(ByVal value As Integer)
            If value < dgv.Rows.Count Then dgv.CurrentCell = dgv.Item(0, value)
        End Set
    End Property
#Region "DATAGRIDVIEW"
    Private Sub tickUpdate(ByVal tblname As String, ByVal dt As DataGridView)
        Dim sql As String = "UPDATE " & tblname & " set "
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim field As String = dt.Rows(i).Cells(0).Value.ToString
            Dim value As String = dt.Rows(i).Cells(1).Value.ToString
            If value = "" Then value = "0"
            If i = dt.Rows.Count - 1 Then
                sql = sql & String.Format("[{0}]" & " = '{1}'", field, value.Replace("'", "''"))
            Else
                sql = sql & String.Format("[{0}]" & " = '{1}',", field, value.Replace("'", "''"))
            End If
        Next
        sql = sql + " where Jobcode = '" & JOBCODE & "'"
        executeQRY(sql, conClient)
    End Sub
#End Region

    Private Sub btnAddJOBCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJOBCODE.Click
        Dim tmp As String = msgBox_in("Job code: ", "Add Jobcode", "", False)

        If Not jobcodeList.Contains(tmp) Then
            If MsgBox(String.Format("Add {0} in {1}??", tmp, JOB), MsgBoxStyle.YesNo, "Add Client") = MsgBoxResult.Yes Then
                mdbInsert(JOB, New String() {"Jobcode"}, New String() {tmp}, conClient)
                mdbInsert(JOB & "_Field", New String() {"Jobcode"}, New String() {tmp}, conClient)
                mdbCreateTable(tmp & "_Groups", New String() {"Group-int", "Coordinate-text(50)"}, conClient)
                mdbCreateTable(tmp & "_Coordinate", New String() {"Field-text(20)", "Coordinate-text(50)"}, conClient)
                save_fieldInfo(tmp & "_Coordinate", dgv, conClient)
                MsgBox("New Jobcode Added.")
                gatherJOBCODE()
            End If
        Else
            MsgBox(String.Format("Jobcode already in {0}", JOB))
        End If
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

    Private Sub InfoBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mdbOpen(ClientDIR & MNCLIENT & ".mdb", conClient)
    End Sub
End Class
