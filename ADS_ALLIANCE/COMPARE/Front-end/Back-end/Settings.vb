Imports System.IO
Imports System.Data.OleDb

Module Settings
    Public ProgrammersPriviledge As Boolean
    Public EXE As String
    Public Const Orientation = "P"

#Region "Additional Settings"
    Public leaflet As New List(Of String)
    Public Sub getLeaflet()
        leaflet = New List(Of String)
        Dim tmpconn As New OleDbConnection
        Dim tmpDT As New DataTable
        mdbOpen(Application.StartupPath & "\Leaflet\Leaflet Codes.mdb", tmpconn)
        mdbToDT("SELECT CODE FROM " & MNJOBCODE, tmpDT, tmpconn)

        For Each rw As DataRow In tmpDT.Rows
            leaflet.Add(rw.Item("CODE").ToString)
        Next
    End Sub
#End Region
#Region "Client Info"
    Public clients As List(Of ClientInfo)

    Public Class ClientInfo
        Public Client As String
        Public Coordinator As String
        Public Programmer As String
        Public Jobs As List(Of JobInfo)
    End Class

    Public Class JobInfo
        Public Job As String
        Public TAHour As String
        Public Jobcodes As List(Of JobcodeInfo)
        Public Fields As List(Of FieldInfo)
    End Class

    Public Class JobcodeInfo
        Public Jobcode As String
        Public Batchsize As String
        Public Keyword As String
        Public Substring As String
        Public Landscape As Boolean
        Public E1Only As Boolean
        Public Twopages As Boolean
        Public Recordcount As String
        Public Validfields As List(Of String)
        Public Verifiablefields As List(Of String)
        Public Entryfields As List(Of String)
        Public Headerfields As List(Of String)
    End Class

    Public Class FieldInfo
        Public Fieldname As String
        Public Displayname As String
        Public Jobcode As String
        Public Page As String
        Public Autonext As Boolean
        Public Description As String
        Public Haslookup As Boolean
        Public Maxlength As String
        Public Casing As String
        Public Character As String
        Public OtherCharacter As String
        Public Pulloutkey As String
        Public Numberformat As String
        Public DefaultValue As String
        Public Validcharperindex As String
    End Class

    Public Sub getInfo(ByVal startupPath As String)
        Dim tmp As String() = IO.Directory.GetFiles(startupPath, "*.mdb")
        clients = New List(Of ClientInfo)
        For Each CL As String In tmp
            Dim client As New ClientInfo
            Dim tmpConn As New OleDbConnection
            Dim tmpDT, tmpDT2 As New DataTable
            mdbOpen(CL, tmpConn)
            mdbToDT(String.Format("SELECT * FROM {0}", Path.GetFileNameWithoutExtension(CL)), tmpDT, tmpConn)
            mdbToDT(String.Format("SELECT * FROM {0}_Info", Path.GetFileNameWithoutExtension(CL)), tmpDT2, tmpConn)

            client.Jobs = New List(Of JobInfo)
            With tmpDT2.Rows(0)
                client.Client = .Item("Client").ToString
                client.Programmer = .Item("Programmer").ToString
                client.Coordinator = .Item("PC").ToString
            End With

            For Each J As DataRow In tmpDT.Rows
                Dim job As New JobInfo
                Dim JOBNAME As String = J.Item("Job").ToString
                job.Fields = New List(Of FieldInfo)
                job.Jobcodes = New List(Of JobcodeInfo)
                job.TAHour = J.Item("TAHour").ToString
                job.Job = JOBNAME
                Dim tmpConn2 As New OleDbConnection
                Dim tmpDT3, tmpDT4, tmpDT5 As New DataTable

                mdbToDT(String.Format("SELECT * FROM {0}", JOBNAME), tmpDT3, tmpConn)
                mdbToDT(String.Format("SELECT * FROM {0}_FieldInfo", JOBNAME), tmpDT4, tmpConn)
                mdbToDT(String.Format("SELECT * FROM {0}_Field", JOBNAME), tmpDT5, tmpConn)

                For Each FLDI As DataRow In tmpDT4.Rows
                    Dim FI As New FieldInfo
                    With FLDI
                        FI.Fieldname = .Item("Field").ToString
                        FI.Displayname = .Item("Displayname").ToString
                        FI.Page = .Item("Page").ToString
                        FI.Autonext = .Item("Autonext")
                        FI.Description = .Item("Description").ToString
                        FI.Haslookup = .Item("Haslookup")
                        FI.Maxlength = .Item("Maxlength").ToString
                        FI.Casing = .Item("Case").ToString
                        FI.Character = .Item("Character").ToString
                        FI.OtherCharacter = .Item("Othercharacter").ToString
                        FI.Pulloutkey = .Item("Pulloutkey").ToString
                        FI.Numberformat = .Item("Numberformat").ToString
                        FI.DefaultValue = .Item("Defaultvalue").ToString
                        FI.Validcharperindex = .Item("ValidCharPerIndex").ToString
                    End With
                    job.Fields.Add(FI)
                Next

                For Each JC As DataRow In tmpDT3.Rows
                    Dim jobcode As New JobcodeInfo
                    With jobcode
                        .Validfields = New List(Of String)
                        .Entryfields = New List(Of String)
                        .Verifiablefields = New List(Of String)
                        .Headerfields = New List(Of String)
                        .Jobcode = JC.Item("Jobcode").ToString

                        .Batchsize = JC.Item("Batchsize").ToString
                        .Headerfields.AddRange(JC.Item("Header").ToString.Split("|"))
                        .Recordcount = JC.Item("Record_Counting").ToString
                        .Twopages = JC.Item("TwoPages")
                        .E1Only = JC.Item("E1Only")
                        .Landscape = JC.Item("Landscape")
                        .Substring = JC.Item("Substring").ToString
                        .Keyword = JC.Item("Keyword").ToString

                        For FLR As Integer = 0 To tmpDT5.Rows.Count - 1
                            If tmpDT5.Rows(FLR).Item("Jobcode").ToString = JC.Item("Jobcode").ToString Then
                                For FLC As Integer = 1 To tmpDT5.Columns.Count - 1
                                    If tmpDT5.Rows(FLR).Item(FLC).ToString.Length >= fieldType + 1 Then
                                        If tmpDT5.Rows(FLR).Item(FLC).ToString.Substring(fieldType, 1) = "1" Then
                                            .Validfields.Add(tmpDT5.Columns(FLC).ColumnName)
                                        End If
                                    End If
                                    If tmpDT5.Rows(FLR).Item(FLC).ToString.Length = 3 Then
                                        If tmpDT5.Rows(FLR).Item(FLC).ToString.Substring(2, 1) = "1" Then
                                            .Verifiablefields.Add(tmpDT5.Columns(FLC).ColumnName)
                                        End If
                                    End If
                                    If tmpDT5.Rows(FLR).Item(FLC).ToString.Length >= 2 Then
                                        If tmpDT5.Rows(FLR).Item(FLC).ToString.Substring(1, 1) = "1" Then
                                            .Entryfields.Add(tmpDT5.Columns(FLC).ColumnName)
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End With
                    job.Jobcodes.Add(jobcode)
                Next
                client.Jobs.Add(job)
            Next
            clients.Add(client)
        Next
    End Sub

#Region "sub & function"
    Public Sub getClientInfo(ByVal client As String)
        For Each CL As ClientInfo In clients
            If CL.Client = client Then
                MNCLIENT = client
                MNCLIENTINFO = CL
                Exit For
            End If
        Next
    End Sub

    Public Sub getJobInfo(ByVal job As String)
        For Each J As JobInfo In MNCLIENTINFO.Jobs
            If J.Job = job Then
                MNJOBINFO = J
                MNJOB = job
                Exit For
            End If
        Next
    End Sub

    Public Sub getJobCodeInfo(ByVal jobcode As String)
        For Each J As JobcodeInfo In MNJOBINFO.Jobcodes
            If J.Jobcode = jobcode Then
                MNJOBCODEINFO = J
                MNJOBCODE = jobcode

                recordCounts = J.Recordcount
                Twopages = J.Twopages
                E1only = J.E1Only
                Fields = New List(Of String)
                Fields = J.Validfields
                Exit For
            End If
        Next
    End Sub

    Public Sub zipFileToJobcode(ByVal zip As String)
        For Each J As JobcodeInfo In MNJOBINFO.Jobcodes
            Dim tmparr As String() = J.Substring.Split(",")
            Dim tmp As String = zip.Substring(Integer.Parse(tmparr(0)), Integer.Parse(tmparr(1)))
            If J.Keyword = tmp Then
                MNJOBCODEINFO = J
                MNJOBCODE = J.Jobcode

                recordCounts = J.Recordcount
                Twopages = J.Twopages
                E1only = J.E1Only
                Fields = New List(Of String)
                FieldsE1 = New List(Of String)
                FieldsE2 = New List(Of String)

                Fields = J.Validfields
                FieldsE1 = J.Entryfields
                FieldsE2 = J.Verifiablefields

                mdbToDT(String.Format("SELECT * FROM {0}_Coordinate", MNJOBCODE), dtCoordinate, conClient)
                mdbToDT(String.Format("SELECT * FROM {0}_Coordinate", MNJOBCODE), dtGroups, conClient)
                Exit For
            End If
        Next
    End Sub

    Public Sub getJobList(ByVal client As String)
        For Each CL As ClientInfo In clients
            If CL.Client = client Then
                MNCLIENT = client
                MNCLIENTINFO = CL

                CBJOB.Items.Clear()
                For Each J As JobInfo In MNCLIENTINFO.Jobs
                    CBJOB.Items.Add(J.Job)
                Next
                If CBJOB.Items.Count <> 0 Then
                    CBJOB.SelectedIndex = 0
                End If
                mdbOpen(String.Format("{0}{1}.mdb", ClientDIR, MNCLIENT), conClient)
                Exit For
            End If
        Next
    End Sub

#End Region
#Region "MAIN PROPERTIES"
#Region "VARIABLES"
    Public MAINCLIENT As String
    Public MAINJOB As String
    Public MAINJOBCODE As String


    Public MAINCLIENTINFO As ClientInfo
    Public MAINJOBINFO As JobInfo
    Public MAINFIELDINFO As FieldInfo
    Public MAINJOBCODEINFO As JobcodeInfo

    Public MAINBATCHSIZE As String
    Public MAINPROGRAMMER As String
    Public MAINPC As String
    Public MAINTAHOUR As String


#End Region
    Public Property MNCLIENT() As String
        Get
            Return MAINCLIENT
        End Get
        Set(ByVal value As String)
            MAINCLIENT = value
        End Set
    End Property

    Public Property MNJOB() As String
        Get
            Return MAINJOB
        End Get
        Set(ByVal value As String)
            MAINJOB = value
        End Set
    End Property

    Public Property MNJOBCODE() As String
        Get
            Return MAINJOBCODE
        End Get
        Set(ByVal value As String)
            MAINJOBCODE = value
        End Set
    End Property

    Public Property MNCLIENTINFO() As ClientInfo
        Get
            Return MAINCLIENTINFO
        End Get
        Set(ByVal value As ClientInfo)
            MAINCLIENTINFO = value
        End Set
    End Property

    Public Property MNJOBINFO() As JobInfo
        Get
            Return MAINJOBINFO
        End Get
        Set(ByVal value As JobInfo)
            MAINJOBINFO = value
        End Set
    End Property

    Public Property MNBATCHSIZE() As String
        Get
            Return MAINBATCHSIZE
        End Get
        Set(ByVal value As String)
            MAINBATCHSIZE = value
        End Set
    End Property

    Public Property MNPC() As String
        Get
            Return MAINPC
        End Get
        Set(ByVal value As String)
            MAINPC = value
        End Set
    End Property

    Public Property MNprogrammer() As String
        Get
            Return MAINPROGRAMMER
        End Get
        Set(ByVal value As String)
            MAINPROGRAMMER = value
        End Set
    End Property

    Public Property MNTAHOUR() As String
        Get
            Return MAINTAHOUR
        End Get
        Set(ByVal value As String)
            MAINTAHOUR = value
        End Set
    End Property

    Public Property MNJOBCODEINFO() As JobcodeInfo
        Get
            Return MAINJOBCODEINFO
        End Get
        Set(ByVal value As JobcodeInfo)
            MAINJOBCODEINFO = value
        End Set
    End Property

    Public Property MNFIELDINFO() As FieldInfo
        Get
            Return MAINFIELDINFO
        End Get
        Set(ByVal value As FieldInfo)
            MAINFIELDINFO = value
        End Set
    End Property
#End Region
#Region "Get Default Client/Job"
    Public Sub getDefaultInfo()
        If File.Exists(ClientDIR & "Info.inf") Then
            Using wr As StreamReader = New StreamReader(ClientDIR & "Info.inf")
                DEFCLIENT = wr.ReadLine
                DEFJOB = wr.ReadLine
            End Using
        Else
            Using wr As StreamWriter = File.CreateText(ClientDIR & "Info.inf")

                '     wr.WriteLine(CLIENT)
                '     wr.WriteLine(JOB)
            End Using
        End If
    End Sub
#End Region
#End Region

    Public Sub checkPriviledge()
        ProgrammersPriviledge = (My.Computer.Name = My.Settings.ComputerName)
    End Sub

    Public Sub setup(ByVal path As String)
        checkPriviledge()
        exeSetup()
        getInfo(path)
        getDefaultInfo()

        CBCLIENT.Items.Clear()
        CBJOB.Items.Clear()
        For Each CL As ClientInfo In clients
            CBCLIENT.Items.Add(CL.Client)
        Next
        If CBCLIENT.Items.Count <> 0 Then
            Dim idx As Integer = 0
            For Each i As String In CBCLIENT.Items
                If i = DEFCLIENT Or DEFCLIENT = Nothing Then Exit For Else idx += 1
            Next
            CBCLIENT.SelectedIndex = idx
        End If
        getClientInfo(CLIENT)

        For Each J As JobInfo In MNCLIENTINFO.Jobs
            CBJOB.Items.Add(J.Job)
        Next
        If CBJOB.Items.Count <> 0 Then
            Dim idx As Integer = 0
            For Each i As String In CBJOB.Items
                If i = DEFJOB Or DEFJOB = Nothing Then Exit For Else idx += 1
            Next
            CBJOB.SelectedIndex = idx
        End If
        getJobInfo(JOB)
    End Sub

    Public Sub exeSetup()
        Select Case EXE
            Case "COM"
                If (MNFORM Is VERIFYL Or MNFORM Is VERIFYP) And (Orientation <> "") Then
                    Flag = ""
                    entryFolder = JobFolders.C1
                    fieldType = 2
                Else
                    MsgBox(String.Format("Error: {0}-The Programmer selected the wrong EXE{1}-Orientation Variable is blank", vbNewLine, vbNewLine))
                    MNFORM.Close()
                End If
            Case "QC"
                If (MNFORM Is VERIFYL Or MNFORM Is VERIFYP) And (Orientation <> "") Then
                    Flag = ""
                    entryFolder = JobFolders.C1
                    fieldType = 1
                Else
                    MsgBox(String.Format("Error: {0}-The Programmer selected the wrong EXE{1}-Orientation Variable is blank", vbNewLine, vbNewLine))
                    MNFORM.Close()
                End If
            Case Else
                MsgBox(String.Format("Error: {0}-The selected EXE does not exist", vbNewLine, vbNewLine))
                MNFORM.Close()
        End Select
    End Sub

    Public Sub ShowLogin()
        frmLogin.ShowDialog()
        If frmLogin.DialogResult = DialogResult.Cancel Then
            closeForm = True
        ElseIf frmLogin.DialogResult = DialogResult.Yes Then
            MNFORM.WindowState = FormWindowState.Maximized
            USERID = frmLogin.txtOperator.Text
            LOCID = frmLogin.txtLocation.Text
            setup(ClientDIR)
        End If
    End Sub
End Module
