Module Variables
    Public Const EXE = "BAT"

         ' Application.StartupPath & "\MDB\" & JobInfo.Client & ".mdb"
    Public ClientDIR As String = "D:\PRODUCT\MDB\"
    Public ClientPath As String
    Public DataPath As String
    Public JobPath As String
    Public BATPath As String


    Public Class JobFolders
        Public Const E1 As String = "Entry 1"
        Public Const E2 As String = "Entry 2"
        Public Const C1 As String = "Compare"
        Public Const I1 As String = "Images"
    End Class

    Public Class EXT
        Public Const tif = ".tif"
        Public Const mdb = ".mdb"
    End Class
    ' Public jobCode As String

    Public recordCounts As String
    Public batchSize As String
    Public Twopages As Boolean
    Public E1only As Boolean

    '  Public Const password As String = "1"
    '  Public AppName As String = IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath)

  
    Public tbl As List(Of String)
    Public Fields As List(Of String)
    Public headerFields As List(Of String)

    Public dtCBat, dtData001, dtFields, dtFieldInfo, dtSettings, dtJobs, dtGroups As New DataTable

    Public dateTime, dateTime2 As String
    Public dvdName, dvdName2, zipFile As String

    Public OImage001 As String = ""
    Public OImage002 As String = ""
    Public userID As String
End Module
