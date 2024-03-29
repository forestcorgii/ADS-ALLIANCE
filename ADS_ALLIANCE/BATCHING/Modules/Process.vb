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
        Dim txt1 As String
        txt1 = "Date:              " & dateTime & vbNewLine & _
                "Job              : " & "(" & MNJOB & ")" & MNCLIENT & " " & vbNewLine & _
                "Shipment/ZipFile : " & zip & vbNewLine & _
                "Batch By (OperId): " & userID & vbNewLine & _
                "Directory Entry1 : " & dt & "\Entry1" & vbNewLine
        If Not MNJOBCODEINFO.E1Only Then
            txt1 &= "Directory Entry2 : " & dt & "\Entry2" & vbNewLine & _
                    "Directory Compare: " & dt & "\Compare" & vbNewLine
        End If
        txt1 &= "Date Received    : __________________________________________" & vbNewLine & _
                "Output Date      : __________________________________________" & vbNewLine & _
                "DE Target Date   : __________________________________________" & vbNewLine & _
                "QC Target Date   : __________________________________________" & vbNewLine & _
                "Val Target Date  : __________________________________________" & vbNewLine & _
                "                                                                 " & vbNewLine & _
                "┌─────────┬────────────────┬───────────┬───────────┬───────────┐" & vbNewLine & _
                "│ Number  │ MDB Name       │ Start Rec │ End Rec   │ Rec Count │" & vbNewLine & _
                "├─────────┼────────────────┼───────────┼───────────┼───────────┤"
        My.Computer.FileSystem.WriteAllText(cbat & "\" & zip & ".log", txt1, False)
    End Sub

    Public Sub log_Write(ByVal cbat As String, ByVal mdb_count As String, ByVal rec_start As String, ByVal rec_end As String, ByVal rec_count As String)
        Dim mdb_name As String = Val(mdb_count).ToString("00000000.##") & ".mdb"
        mdb_count = addLength(mdb_count, 9)
        mdb_name = addLength(mdb_name, 16)
        rec_start = addLength(rec_start, 11)
        rec_end = addLength(rec_end, 11)
        rec_count = addLength(rec_count, 11)

        Dim tmp As String = vbNewLine & "│" & mdb_count & "│" & mdb_name & "│" & rec_start & "│" & rec_end & "│" & rec_count & "│"
        My.Computer.FileSystem.WriteAllText(cbat & "\" & zipFile & ".log", tmp, True)
    End Sub

    Public Sub log_end(ByVal cbat As String, ByVal mdb_count As String, ByVal rec_start As String, ByVal rec_end As String, ByVal rec_count As String)
        Dim mdb_name As String = Val(mdb_count).ToString("00000000.##") & ".mdb"
        mdb_count = addLength(mdb_count, 9)
        mdb_name = addLength(mdb_name, 16)
        rec_start = addLength(rec_start, 11)
        rec_end = addLength(rec_end, 11)
        rec_count = addLength(rec_count, 11)

        Dim tmp As String = vbNewLine & "│" & mdb_count & "│" & mdb_name & "│" & rec_start & "│" & rec_end & "│" & rec_count & "│"
        tmp += Environment.NewLine & "└─────────┴────────────────┴───────────┴───────────┴───────────┘"
        My.Computer.FileSystem.WriteAllText(cbat & "\" & zipFile & ".log", tmp, True)
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
End Module
