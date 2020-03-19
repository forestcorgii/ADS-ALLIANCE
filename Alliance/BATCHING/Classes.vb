Imports System.IO

Module Classes
    Public Class BatchInfo
        Public Path As DirectoryInfo
        Public Files As List(Of String)

        Public ReadOnly Property DvdName As String
            Get
                Return Path.Parent.Parent.Name
            End Get
        End Property
        Public ReadOnly Property MainFile As String
            Get
                Return Path.Parent.Name
            End Get
        End Property
        Public ReadOnly Property ZipFile As String
            Get
                Return Path.Name
            End Get
        End Property

        Sub New(_path As String)
            Path = New DirectoryInfo(_path)
            Files = New List(Of String)
            Files.AddRange(Directory.GetFiles(_path, "*.tif"))
        End Sub

        Public Function Valid() As Boolean
            If Files.Count = 0 Then Return False
            If Not ZipFile.Contains("ALLIANCE") Then Return False

            Select Case MainFile
                Case "CELL1", "CELL2", "CELL3", "CELL4", "CELL5"
                Case Else
                    Return False
            End Select

            Return True
        End Function
    End Class
End Module
