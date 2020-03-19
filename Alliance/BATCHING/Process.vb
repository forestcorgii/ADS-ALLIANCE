Imports System.IO
Imports System.Threading
Module Process



#Region "Commands"
#Region "ADD"
    Public Sub addAll(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        For i As Integer = 0 To dtg1.RowCount - 1
            dtg1.Rows(i).Selected = True
        Next
        addSelected(dtg1, dtg2)
    End Sub

    Public Sub addSelected(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg1.SelectedRows.Count = 0 Then
            If dtg1.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dtg1.SelectedRows.Count - 1
                    Dim li1 As String = dtg1.SelectedRows(i).Cells(0).Value
                    Dim li2 As String = dtg1.SelectedRows(i).Cells(1).Value
                    Dim li3 As String = dtg1.SelectedRows(i).Cells(2).Value
                    dtg2.Rows.Add(li1, li2, li3)
                Next
                For i As Integer = 0 To dtg1.SelectedRows.Count - 1
                    dtg1.Rows.Remove(dtg1.SelectedRows(0))
                Next
            End If
        End If
    End Sub

#End Region

#Region "REMOVE"
    Public Sub removeSelected(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg2.SelectedRows.Count = 0 Then
            If dtg2.SelectedRows.Count > 0 Then
                For i As Integer = 0 To dtg2.SelectedRows.Count - 1
                    Dim li1 As String = dtg2.SelectedRows(i).Cells(0).Value
                    Dim li2 As String = dtg2.SelectedRows(i).Cells(1).Value
                    Dim li3 As String = dtg2.SelectedRows(i).Cells(2).Value
                    dtg1.Rows.Add(li1, li2, li3)
                Next
                For i As Integer = 0 To dtg2.SelectedRows.Count - 1
                    dtg2.Rows.Remove(dtg2.SelectedRows(0))
                Next
            End If
        End If
    End Sub
    Public Sub removeAll(ByRef dtg1 As DataGridView, ByRef dtg2 As DataGridView)
        If Not dtg2.Rows.Count = 0 Then
            For i As Integer = 0 To dtg2.RowCount - 1
                dtg2.Rows(i).Selected = True
            Next
            removeSelected(dtg1, dtg2)
        End If
    End Sub

#End Region

#End Region

#Region "INSERT"
#Region "INSERT DATA/JOB"
    Public Sub insertJobNData()

    End Sub
#End Region

#End Region

#Region "Log for Batching"
    Public Sub log_Start(ByVal cbat As String, ByVal zip As String, ByVal dt As String)
        Using writer As New StreamWriter(cbat & "\" & zip & ".log", False)
            With writer
                .WriteLine("Date:              " & dateTime)
                .WriteLine("Job              : " & "(" & JobName & ")" & ClientName & " ")
                .WriteLine("Shipment/ZipFile : " & zip)
                .WriteLine("Batch By (OperId): " & userID)
                .WriteLine("Directory Entry1 : " & dt & "\Entry1")
                .WriteLine("Directory Entry2 : " & dt & "\Entry2")
                .WriteLine("Directory Compare: " & dt & "\Compare")
                .WriteLine("Date Received    : __________________________________________")
                .WriteLine("Output Date      : __________________________________________")
                .WriteLine("DE Target Date   : __________________________________________")
                .WriteLine("QC Target Date   : __________________________________________")
                .WriteLine("Val Target Date  : __________________________________________")
                .WriteLine("                                                                 ")
                .WriteLine("┌─────────┬────────────────┬───────────┬───────────┬───────────┐")
                .WriteLine("│ Number  │ MDB Name       │ Start Rec │ End Rec   │ Rec Count │")
                .WriteLine("├─────────┼────────────────┼───────────┼───────────┼───────────┤")
            End With
        End Using
    End Sub

    Public Sub log_Write(ByVal cbat As String, zipFile As String, ByVal mdb_count As String, ByVal rec_start As String, ByVal rec_end As String, ByVal rec_count As String)
        Dim mdb_name As String = Val(mdb_count).ToString("00000000.##") & ".mdb"
        mdb_count = addLength(mdb_count, 9)
        mdb_name = addLength(mdb_name, 16)
        rec_start = addLength(rec_start, 11)
        rec_end = addLength(rec_end, 11)
        rec_count = addLength(rec_count, 11)

        Using writer As New StreamWriter(cbat & "\" & zipFile & ".log", True)
            writer.WriteLine("│" & mdb_count & "│" & mdb_name & "│" & rec_start & "│" & rec_end & "│" & rec_count & "│")
        End Using
    End Sub

    Public Sub log_end(ByVal cbat As String, zipFile As String, ByVal mdb_count As String, ByVal rec_start As String, ByVal rec_end As String, ByVal rec_count As String)
        Dim mdb_name As String = Val(mdb_count).ToString("00000000.##") & ".mdb"
        mdb_count = addLength(mdb_count, 9)
        mdb_name = addLength(mdb_name, 16)
        rec_start = addLength(rec_start, 11)
        rec_end = addLength(rec_end, 11)
        rec_count = addLength(rec_count, 11)

        Using writer As New StreamWriter(cbat & "\" & zipFile & ".log", True)
            writer.WriteLine("│" & mdb_count & "│" & mdb_name & "│" & rec_start & "│" & rec_end & "│" & rec_count & "│")
        End Using
    End Sub

#End Region

#Region "Other"
    Public Sub createMultipleFolder(ByVal folder As String, ByVal subfolders() As String, ByVal overwrite As Boolean)
        If overwrite = True Then
            If Directory.Exists(folder) Then Directory.Delete(folder, True)
        End If

        Directory.CreateDirectory(folder)
        For Each sfl As String In subfolders
            If Not Directory.Exists(folder & "\" & sfl) Then
                Directory.CreateDirectory(folder & "\" & sfl)
            End If
        Next
    End Sub

    Public Sub createFolder(ByVal folder As String, ByVal overwrite As Boolean)
        If overwrite = True Then
            If Directory.Exists(folder) Then Directory.Delete(folder, True)
        End If

        Directory.CreateDirectory(folder)
    End Sub
#End Region

#Region "Threading(Experimental)"
    Private imgThread As Thread
    Private imageList() As String
    Private destination As String
    Public Sub copyImg(ByVal imgList() As String, ByVal dest As String)
        imageList = imgList
        destination = dest

        imgThread = New System.Threading.Thread(AddressOf startCopy)
        imgThread.Start()
    End Sub

    Private Sub startCopy()
        '    Try
        Dim imgcount As Integer = 0
        For Each img As String In imageList
            Dim imgname As New DirectoryInfo(img)
            Dim imgPath As String

            imgcount += 1
            imgPath = destination & imgcount.ToString("00000000.##")
            File.Copy(img, imgPath & EXT.tif, True)
        Next

        imgThread.Abort()
        '  Catch ex As Exception
        ' Debug.Print(ex.Message)
        ' End Try
    End Sub
#End Region

    Public Function addLength(ByVal str As String, ByVal valLen As Integer, Optional ByVal myChar As String = " ") As String
        If Len(str) < valLen Then
            Do Until Len(str) = valLen
                str = str & myChar
            Loop
        End If
        addLength = str
    End Function
End Module
