Module Variables

    Public Const EXE = "COM"
    Public Const Orientation = "P"
    Public DEFCLIENT As String
    Public DEFJOB As String
    Public Flag As String
    Public entryFolder As String

    Public fieldType As Integer
  
    ' Application.StartupPath & "\MDB\" & mnClient & ".mdb"
    Public ClientDIR As String = "D:\PRODUCT\MDB\"
    Public ClientPath As String
    Public DataPath As String
    Public JobPath As String
    Public BATPath As String

    Public Class Flags
        Public Const E1 As String = "♪"
        Public Const E2 As String = "♫"
    End Class

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

    Public recordCounts As String
    Public Twopages As Boolean
    Public Haslookup As Boolean
    Public E1only As Boolean

    'Public Const password As String = "1"
    'Public AppName As String

   
    Public tbl As List(Of String)

    Public FieldsE1 As List(Of String)
    Public FieldsE2 As List(Of String)
    Public Fields As List(Of String)
    Public headerFields As List(Of String)

    Public dtCBatch, dtData001, dtFieldInfo, dtGroups, dtCoordinate As New DataTable
    Public dtDataE1, dtCBatchE1, dtDataE2, dtCBatchE2 As New DataTable

    '  Public dateTime, dateTime2 As String
    Public dvdName, dvdName2, zipFile As String

    Public OImage001 As String = ""
    Public OImage002 As String = ""

    Public mdb_Rec As Integer = 1
    Public dt_Rec As Integer = 0
    Public currentrows As Integer = 0
    Public img_path As String = ""

    Public filename As String = ""
    Public mdbName As String = ""
End Module
