Imports System.Data.OleDb
Imports System.IO
Module MDB
    Public Const Provider As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source="
    Public Const ExcelProvider As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="

    Public conn, conData, conClient, conCBat As OleDb.OleDbConnection
    Public ZonalCon, NonZonalCon, thirdMailingFile As OleDbConnection

#Region "OPEN"
    Public Sub mdbOpen(ByVal DatabaseFullPath As String, ByRef con As OleDbConnection)
        Try
            If con IsNot Nothing Then If con.State = ConnectionState.Open Then con.Close()
            con = New System.Data.OleDb.OleDbConnection(Provider & DatabaseFullPath & ";User Id=admin;Password=;")
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ExcelOpen(ByVal DatabaseFullPath As String, ByRef con As OleDbConnection)
        'Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + YourEXCELFilePath + ";Extended Properties=Excel 12.0;
        Try
            If con IsNot Nothing Then If con.State = ConnectionState.Open Then con.Close()
            con = New System.Data.OleDb.OleDbConnection(ExcelProvider & DatabaseFullPath & ";User Id=admin;Password=;Extended Properties=Excel 12.0 Xml")
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

#Region "Delete"
    Public Sub mdbDrop(ByVal tbls As String(), ByVal con As OleDbConnection)
        For Each i As String In tbls
            executeQRY(String.Format("DROP TABLE {0}", i), con)
        Next
    End Sub

    Public Sub mdbDrop(ByVal tbls As String, ByVal con As OleDbConnection)
        For Each i As String In tbls
            executeQRY(String.Format("DROP TABLE {0}", i), con)
        Next
    End Sub
#End Region

#Region "Create"
    Public Sub mdbCreate(ByVal DatabaseFullPath As String)
        Try
            Dim cat As New ADOX.Catalog
            cat.Create(Provider & DatabaseFullPath & ";Jet OLEDB:Engine Type=5")
        Catch Ex As System.Exception
        End Try
    End Sub

    Public Sub mdbCreateTable(ByVal tbl As String, ByVal flds As String(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("CREATE TABLE {0}(", tbl)
        For Each fld As String In flds
            Dim tmp() As String = fld.Split(Char.Parse("-"))
            If fld = flds(0) Then
                qry &= String.Format("[{0}] {1} NULL", tmp(0), tmp(1))
            Else
                qry &= String.Format(",[{0}] {1} NULL", tmp(0), tmp(1))
            End If
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub

    Public Sub mdbCreateTable(ByVal tbl As String, ByVal flds As DataTable, ByVal DDTT As String, ByVal con As OleDbConnection)
        Dim qry As String = String.Format("CREATE TABLE {0}(", tbl)
        For Each fld As DataRow In flds.Rows
            If fld.Item(0).ToString = flds.Rows(0).Item(0).ToString Then
                qry &= String.Format("[{0}] {1} NULL", fld.Item(0).ToString, DDTT)
            Else
                qry &= String.Format(",[{0}] {1} NULL", fld.Item(0).ToString, DDTT)
            End If
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub

    Public Sub mdbCreateTable(ByVal tbl As String, ByVal flds As DataGridView, ByVal DDTT As String, ByVal con As OleDbConnection)
        Dim qry As String = String.Format("CREATE TABLE {0}(", tbl)
        For Each fld As DataGridViewRow In flds.Rows
            If fld.Cells(0).Value = flds.Rows(0).Cells(0).Value Then
                qry &= String.Format("[{0}] {1} NULL", fld.Cells(0).Value, DDTT)
            Else
                qry &= String.Format(",[{0}] {1} NULL", fld.Cells(0).Value, DDTT)
            End If
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub
#End Region

#Region "Convert"
    Public Sub mdbToDT(ByVal qry As String, ByRef dt As System.Data.DataTable, ByVal con As OleDbConnection)
        Try
            dt = New DataTable
            Dim da As New OleDbDataAdapter(qry, con)
            da.Fill(dt)
        Catch
        End Try
    End Sub
#End Region

#Region "Commands"
    Public Sub executeQRY(ByVal Qry As String, ByVal con As OleDbConnection)
        Try
            Dim com As New OleDbCommand(Qry, con)
            If con.State = System.Data.ConnectionState.Closed Then con.Open()
            com.ExecuteNonQuery()
            '     If con.State = System.Data.ConnectionState.Closed Then con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub mdbInsert(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("INSERT INTO {0} (", tbl)
        Dim valtype As String = ""
        Dim counter As Integer = 0

        For Each f As String In fld
            If f = fld(0) And counter = 0 Then
                qry &= String.Format("[{0}]", f)
            Else
                qry &= String.Format(",[{0}]", f)
            End If
            counter += 1
        Next

        qry &= ") VALUES("

        counter = 0
        For Each v As Object In val
            valtype = TypeName(v)
            If v.ToString = val(0).ToString And counter = 0 Then
                If valtype = "String" Then
                    qry &= String.Format("'{0}'", v)
                Else
                    qry &= String.Format("{0}", v)
                End If
            Else
                If valtype = "String" Then
                    qry &= String.Format(",'{0}'", v)
                Else
                    qry &= String.Format(",{0}", v)
                End If
            End If
            counter += 1
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub

    Public Sub mdbUpdate(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal condition As Object(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("UPDATE {0} SET ", tbl)
        Dim valtype As String = ""
        Dim counter As Integer = 0

        If fld.Length = val.Length Then
            For f As Integer = 0 To fld.GetUpperBound(0)
                valtype = TypeName(val(f))
                If f = 0 Then
                    If valtype = "String" Then
                        qry &= String.Format("[{0}]='{1}'", fld(f), val(f))
                    Else
                        qry &= String.Format("[{0}]={1}", fld(f), val(f))
                    End If
                Else
                    If valtype = "String" Then
                        qry &= String.Format(",[{0}]='{1}'", fld(f), val(f))
                    Else
                        qry &= String.Format(",[{0}]={1}", fld(f), val(f))
                    End If
                End If
            Next
        End If

        If Not condition Is Nothing Then
            If TypeName(condition(1)) = "String" Then
                qry &= String.Format(" WHERE {0} = '{1}'", condition(0), condition(1))
            Else
                qry &= String.Format(" WHERE {0} = {1}", condition(0), condition(1))
            End If
        End If

        executeQRY(qry, con)
    End Sub
#End Region

    Public Function getTables(ByVal con As OleDbConnection) As List(Of String)
       If con.State = ConnectionState.Closed Then con.Open()
        Dim dt As New DataTable
        getTables = New List(Of String)
        Dim restrictions() As String = New String(3) {}
        restrictions(3) = "Table"
        dt = con.GetSchema("Tables", restrictions)
        For i As Integer = 0 To dt.Rows.Count - 1
            getTables.Add(dt.Rows(i)(2).ToString)
        Next
        If con.State = ConnectionState.Open Then con.Close()
        Return getTables
    End Function

    Public Sub mdbCreateDataTBL(tblName As String, additionalFields As String(), ByRef con As OleDbConnection)
        Dim qry As String = "CREATE TABLE " & tblName & "([Recnum] int"
        For i As Integer = 1 To Fields.Count - 1
            qry += ", [" & Fields(i) & "] text NULL"
        Next

        For i As Integer = 0 To additionalFields.Length - 1
            qry += ", [" & additionalFields(i) & "] text NULL"
        Next

        qry += ")"
        executeQRY(qry, con)
    End Sub

    Public Sub mdbCreateCBatch(ByVal tbl As String, ByVal con As OleDb.OleDbConnection)
        mdbCreateTable(tbl, New String() {"Recnum-int", "ZipFile-text", "DvdName-text", "BatchNo-text", "PullOut-text", "RefInd-text", _
        "KeyFlag-text", "KeyID-text", "KeyDate-text", "VerFlag-text", "VerID-text", "VerDate-text", "ComFlag-text", _
        "ComID-text", "ComDate-text", "UpdFlag-text", "UpdID-text", "UpdDate-text", "QCFlag-text", "QCID-text", _
        "QCDate-text", "QASFlag-text", "QASID-text", "QASDate-text", "ValFlag-text", "ValID-text", "ValDate-text", _
        "RefFlag-text", "RefID-text", "RefDate-text", "Accuracy1-text", "Accuracy2-text", "Accuracy3-text", "Accuracy4-text", _
        "Accuracy5-text", "KSCount-text", "QCID1-text", "QCID2-text", "QCID3-text", "QCID4-text", "QCID5-text", _
        "LKFlag1-text", "LKFlag2-text", "LKFlag3-text", "LKFlag4-text", "LKFlag5-text", "LocID1-text", "LocID2-text", _
        "OImage001-text", "Image001-text", "OImage002-text", "Image002-text"}, con)
    End Sub

    'Public Sub executeqry(ByVal Qry As String, ByVal con As OleDbConnection)
    '    Dim com As New OleDbCommand(Qry, con)
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    com.ExecuteNonQuery()
    '    If con.State = ConnectionState.Open Then con.Close()
    'End Sub

    'Public Sub create_CBatTable(ByRef con As OleDbConnection, ByVal tblName As String, ByVal ParamArray fields() As String)
    '    Dim qry As String = "CREATE TABLE " & tblName & "("
    '    If fields(0) = "1" Then qry += "[Recnum] int" Else qry += "[" & fields(0) & "] text(70)"
    '    For i As Integer = 1 To fields.GetUpperBound(0)
    '        qry += ", [" & fields(i) & "] text(70) NULL"
    '    Next
    '    qry += ")"
    '    executeqry(qry, con)
    'End Sub

    'Public Function create_CbatTables(ByVal cbatchPath As String) As Boolean
    '    'If File.Exists(cbatchPath) Then
    '    '    If conCBat.State = ConnectionState.Open Then conCBat.Close()
    '    '    File.Delete(cbatchPath)
    '    'End If
    '    create_CBatTable(conCBat, "origImage", "OImage001", "Image001", "OImage002 ", "Image002")
    '    create_CBatTable(conCBat, jobCode, "1", "ZipFile", "DvdName", "BatchNo", "OImage001", "Image001", "OImage002 ", "Image002")
    '    Return True
    'End Function

    'Public Function insert_Field(ByVal j As String, ByVal ParamArray fields() As String) As String
    '    insert_Field = "INSERT INTO [" & j & "]([" & fields(0) & "]"
    '    For i As Integer = 1 To fields.GetUpperBound(0)
    '        insert_Field += ",[" & fields(i) & "]"
    '    Next
    '    Return insert_Field
    'End Function

    'Public Function insert_Value(ByVal ParamArray value() As String) As String
    '    insert_Value = ") VALUES('" & value(0) & "'"
    '    For i As Integer = 1 To value.GetUpperBound(0)
    '        insert_Value += ",'" & value(i) & "'"
    '    Next
    '    insert_Value += ")"
    '    Return insert_Value
    'End Function

    Public Sub CreateCBatchCSV()
        Dim dbCommand As OleDb.OleDbCommand
        Dim dbAdapter As OleDb.OleDbDataAdapter
        mdbOpen(Application.StartupPath & "\CBATCH" & "\" & MNJOBCODE & ".mdb", conn)
        conn.Open()
        dbCommand = New OleDb.OleDbCommand("SELECT * FROM [" & MNJOBCODE & "]", conn)
        dbAdapter = New OleDb.OleDbDataAdapter
        dbAdapter.SelectCommand = dbCommand
        Dim dbTable As New DataTable
        dbAdapter.Fill(dbTable)
        Dim sw As New System.IO.StreamWriter(Application.StartupPath & "\CBATCH\" & MNJOBCODE & ".csv")
        Dim columnHeaders As New System.Text.StringBuilder
        For Each col As DataColumn In dbTable.Columns
            If columnHeaders.ToString.Length > 0 Then columnHeaders.Append(",")
            columnHeaders.Append("""" & col.ColumnName & """")
        Next
        sw.WriteLine(columnHeaders.ToString)
        Dim dataValues As New System.Text.StringBuilder
        For Each row As DataRow In dbTable.Rows
            For Each col As DataColumn In dbTable.Columns
                If dataValues.ToString.Length > 0 Then dataValues.Append(",")
                dataValues.Append("""" & row(col.ColumnName).ToString & """")
            Next
            sw.WriteLine(dataValues.ToString)
            dataValues = New System.Text.StringBuilder
        Next
        sw.Close()
        conn.Close()
    End Sub
End Module
