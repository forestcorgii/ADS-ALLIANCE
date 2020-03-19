Imports System.Windows.Forms
Imports System.IO
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.Diagnostics.Process

Module Settings
    Public Const ProgrammersPriviledge As Boolean = True
    Public fieldType As Integer = 0

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
                                    If tmpDT5.Rows(FLR).Item(FLC).ToString <> "" Then
                                        If tmpDT5.Rows(FLR).Item(FLC).ToString.Substring(fieldType, 1) = "1" Then
                                            .Validfields.Add(tmpDT5.Columns(FLC).ColumnName)
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
                MNPC = CL.Coordinator
                MNprogrammer = CL.Programmer
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
        If jobcode = "" Then Exit Sub
        For Each J As JobcodeInfo In MNJOBINFO.Jobcodes
            If J.Jobcode = jobcode Then
                MNJOBCODEINFO = J
                MNJOBCODE = jobcode

                recordCounts = J.Recordcount
                Twopages = J.Twopages
                E1only = J.E1Only
                batchSize = J.Batchsize
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
                batchSize = J.Batchsize
                Fields = New List(Of String)
                Fields = J.Validfields
                Exit For
            End If
        Next
    End Sub

    Public Sub getJobList(ByVal client As String)
        For Each CL As ClientInfo In clients
            If CL.Client = client Then
                MNCLIENT = client
                MNCLIENTINFO = CL
            
                BATCHING.cbJob.Items.Clear()
                For Each J As JobInfo In MNCLIENTINFO.Jobs
                    BATCHING.cbJob.Items.Add(J.Job)
                Next
                If BATCHING.cbJob.Items.Count <> 0 Then
                    BATCHING.cbJob.SelectedIndex = 0
                End If
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
#End Region
    Public Sub gatherClients(ByVal path As String)
        Dim tmp As String() = IO.Directory.GetFiles(path, "*.mdb")
        BATCHING.cbClient.Items.Clear()
        If tmp.Length <> 0 Then
            For Each i As String In tmp
                BATCHING.cbClient.Items.Add(IO.Path.GetFileNameWithoutExtension(i))
            Next
            If BATCHING.cbClient.Items.Count > 0 Then
                BATCHING.cbClient.SelectedIndex = 0
            End If
        Else
            BATCHING.showFieldMaker()
        End If
    End Sub
    Public Sub setup(ByVal path As String)
        getInfo(path)

        BATCHING.cbClient.Items.Clear()
        BATCHING.cbJob.Items.Clear()
        For Each CL As ClientInfo In clients
            BATCHING.cbClient.Items.Add(CL.Client)
        Next
        If BATCHING.cbClient.Items.Count <> 0 Then
            BATCHING.cbClient.SelectedIndex = 0
        End If
        getClientInfo(BATCHING.CLIENT)
        getJobList(BATCHING.CLIENT)
        getJobCodeInfo(BATCHING.JOB)

        'ClientPath = path
        'If File.Exists(ClientPath) = True Then
        '    mdbOpen(ClientPath, conClient)
        '    mdbToDT("SELECT * FROM " & BATCHING.CLIENT, dtSettings, conClient)
        '    mdbToDT("SELECT * FROM " & BATCHING.JOB, dtJobs, conClient)
        '    mdbToDT("SELECT * FROM " & fieldList, dtFields, conClient)
        'Else
        '    MsgBox("KI File is missing")
        'End If
    End Sub

    'Public Function execute_PasswordBox() As Boolean
    '    Dim tmpBool As Boolean
    '    Dim tmp As String = "ex. 0000"
    '    While tmpBool = False
    '        tmp = msgBox_in("Enter your 4-PIN Number:", "Password")
    '        If tmp <> "" Then
    '            If tmp <> password Then
    '                tmpBool = False
    '                MsgBox("Invalid Password")
    '            Else
    '                Return True
    '            End If
    '        Else
    '            Exit While
    '        End If
    '    End While
    '    Return False
    'End Function
End Module
