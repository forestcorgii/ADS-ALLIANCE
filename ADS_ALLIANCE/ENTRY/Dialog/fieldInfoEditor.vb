Imports System.Windows.Forms

Public Class fieldInfoEditor
#Region "Field Info Editor Setup"
    Private editor_DT As DataTable

    Private Sub get_fieldList()
        On Error Resume Next
        mdbToDT("SELECT * FROM " & MNJOB & "_FieldInfo", dtFieldInfo, conClient)
        dgv.Rows.Clear()
        For i As Integer = 0 To dtFieldInfo.Rows.Count - 1
            Select Case dtFieldInfo.Rows(i).Item("Field").ToString
                Case "RecNum"
                Case Else
                    With dtFieldInfo.Rows(i)
                        dgv.Rows.Add(.Item("Page").ToString, _
                        .Item("Field").ToString, _
                        .Item("DisplayName").ToString, _
                        .Item("Description").ToString, _
                        .Item("Maxlength").ToString, _
                        .Item("Case").ToString, _
                        .Item("Character").ToString, _
                        .Item("Othercharacter").ToString, _
                        .Item("Pulloutkey").ToString, _
                        .Item("ValidCharPerIndex").ToString, _
                        .Item("Haslookup"), _
                        .Item("Autonext"))
                    End With
            End Select
        Next
    End Sub
    Private Sub editor_setup()
        get_fieldList()
        If Twopages = True Then tbDisplayName.Enabled = True Else tbDisplayName.Enabled = False

    End Sub
#End Region

    Public Function dataChange() As Boolean
        If Not dgv.Rows.Count = 0 Then
            If Not tbPage.Text.Equals(dgv.SelectedRows(0).Cells(0).Value) Then
                Return True
            ElseIf Not tbField.Text.Equals(dgv.SelectedRows(0).Cells(1).Value) Then
                Return True
            ElseIf Not tbDisplayName.Text.Equals(dgv.SelectedRows(0).Cells(2).Value) Then
                Return True
            ElseIf Not txtDescription.Text.Equals(dgv.SelectedRows(0).Cells(3).Value) Then
                Return True
            ElseIf Not txtLength.Text.Equals(dgv.SelectedRows(0).Cells(4).Value) Then
                Return True
            ElseIf Not cbxCase.Text.Equals(dgv.SelectedRows(0).Cells(5).Value) Then
                Return True
            ElseIf Not cbxChar.Text.Equals(dgv.SelectedRows(0).Cells(6).Value) Then
                Return True
            ElseIf Not txtOChar.Text.Equals(dgv.SelectedRows(0).Cells(7).Value) Then
                Return True
            ElseIf Not txtPOKey.Text.Equals(dgv.SelectedRows(0).Cells(8).Value) Then
                Return True
            ElseIf Not txtValidChar.Text.Equals(dgv.SelectedRows(0).Cells(9).Value) Then
                Return True
            ElseIf Not cbHasLookup.Checked.Equals(dgv.SelectedRows(0).Cells(10).Value) Then
                Return True
            ElseIf Not cbAutoNext.Checked.Equals(dgv.SelectedRows(0).Cells(11).Value) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub save_FieldInfo()
        If MsgBox("Do you want to save??", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
            Dim qry As String = "UPDATE " & MNJOB & "_FieldInfo SET [Page] = '" & IIf(tbPage.Text = "", "1", tbPage.Text) & _
            "',  [Displayname] = '" & IIf(tbDisplayName.Text = "", tbField.Text, tbDisplayName.Text) & _
            "',  [ValidCharPerIndex] = '" & txtValidChar.Text.Replace("'", "''") & _
            "', [Description] = '" & txtDescription.Text.Replace("'", "''") & _
            "', [Maxlength] = '" & IIf(txtLength.Text = "", 0, txtLength.Text) & "', [Case] = '" & cbxCase.Text & _
            "', [Character] = '" & cbxChar.Text & "', [Othercharacter] = '" & txtOChar.Text.Replace("'", "''") & _
            "', [Pulloutkey] = '" & txtPOKey.Text.Replace("'", "''") & _
            "', [HasLookup] = " & cbHasLookup.Checked & _
            ", [Autonext] = " & cbAutoNext.Checked & " WHERE [Field] = '" & tbField.Text & "'"
            executeQRY(qry, conClient)
            '  MsgBox("Saved!")
            get_fieldList()
        End If
    End Sub

    Public Sub load_FieldInfo()
        On Error Resume Next
        With dgv.Rows(dgv.CurrentRow.Index)
            tbPage.Text = .Cells(0).Value
            tbField.Text = .Cells(1).Value
            tbDisplayName.Text = .Cells(2).Value
            txtDescription.Text = .Cells(3).Value
            txtLength.Text = .Cells(4).Value
            cbxCase.Text = .Cells(5).Value
            cbxChar.Text = .Cells(6).Value
            txtOChar.Text = .Cells(7).Value
            txtPOKey.Text = .Cells(8).Value
            txtValidChar.Text = .Cells(9).Value
            cbHasLookup.Checked = .Cells(10).Value
            cbAutoNext.Checked = .Cells(11).Value
        End With
    End Sub

    Private Sub fieldInfoEditor_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        set_mode(mymode.Browse_Mode)
    End Sub

    Private Sub fieldInfoEditor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            save_FieldInfo()
        End If
    End Sub

     Private Sub fieldInfoEditor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        editor_setup()
    End Sub

    Private Sub cbCheckLength_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCheckLength.CheckedChanged
        If cbCheckLength.Checked = True Then
            cbxCon.Enabled = True
            txtLA.Enabled = True
            cbxAct1.Enabled = True
        Else
            cbxCon.Enabled = True
            txtLA.Enabled = True
            cbxAct1.Enabled = True
        End If
    End Sub

    Private Sub cbCheckBlank_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCheckBlank.CheckedChanged
        If cbCheckBlank.Checked = True Then cbxAct2.Enabled = True Else cbxAct2.Enabled = False
    End Sub

    Private Sub cbCheckDup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCheckDup.CheckedChanged
        If cbCheckDup.Checked = True Then cbxAct3.Enabled = True Else cbxAct3.Enabled = False
    End Sub

    Private Sub cbCheckDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCheckDate.CheckedChanged
        If cbCheckDate.Checked = True Then
            cbxDay.Enabled = True
            cbxMonth.Enabled = True
            cbxYear.Enabled = True
            cbxAct4.Enabled = True
        Else
            cbxDay.Enabled = False
            cbxMonth.Enabled = False
            cbxYear.Enabled = False
            cbxAct4.Enabled = False
        End If
    End Sub

    Private Sub cbCheckDueDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCheckDueDate.CheckedChanged
        If cbCheckDueDate.Checked = True Then
            cbxDDay.Enabled = True
            cbxDMonth.Enabled = True
            cbxDYear.Enabled = True
            cbxAct5.Enabled = True
        Else
            cbxDDay.Enabled = False
            cbxDMonth.Enabled = False
            cbxDYear.Enabled = False
            cbxAct5.Enabled = False
        End If
    End Sub

    Private Sub txtLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLength.TextChanged
        If txtLength.Text = "1" Then cbAutoNext.Enabled = True Else cbAutoNext.Enabled = False
    End Sub
  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("")
    End Sub

    Public Enum valtype
        Tick = 0
        Date_type = 1
        Name = 2
        Address = 3
        Email = 4
    End Enum
  
    Private Sub cbxCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCon.SelectedIndexChanged
        If cbxCon.SelectedItem.ToString = "Rng" Then
            txtLB.Enabled = True
        Else
            txtLB.Enabled = False
        End If
    End Sub

    Private Sub dgv_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellChanged
             load_FieldInfo()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save_FieldInfo()
    End Sub

    Private Sub dgv_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.RowLeave
        If dataChange() Then
            save_FieldInfo()
        End If
    End Sub
End Class

'Private Sub default_Valtype(ByVal type As valtype)
'    Select Case type
'        Case valtype.Address
'            cbAutoNext.Checked = False
'            txtLength.Text = "50"
'            cbxChar.Text = "AlphaNumeric"
'            txtOChar.Text = "-'#"
'            cbCheckDate.Checked = True
'            cbCheckDate.Enabled = True
'            cbCheckDueDate.Checked = True
'            cbCheckDueDate.Enabled = True
'            cbCheckDup.Checked = False
'            cbCheckDup.Enabled = False

'        Case valtype.Date_type
'            cbAutoNext.Checked = False
'            txtLength.Text = "30"
'            cbxChar.Text = "Alpha"
'            txtOChar.Text = "'-"
'            cbCheckDate.Checked = True
'            cbCheckDate.Enabled = True
'            cbCheckDueDate.Checked = True
'            cbCheckDueDate.Enabled = True
'            cbCheckDup.Checked = False
'            cbCheckDup.Enabled = False

'        Case valtype.Email

'        Case valtype.Name
'            cbAutoNext.Checked = False
'            txtLength.Text = "30"
'            cbxChar.Text = "Alpha"
'            txtOChar.Text = "'-"
'            cbCheckDate.Checked = False
'            cbCheckDate.Enabled = False
'            cbCheckDueDate.Checked = False
'            cbCheckDueDate.Enabled = False
'            cbCheckDup.Checked = False
'            cbCheckDup.Enabled = False

'        Case valtype.Tick
'            cbAutoNext.Checked = True
'            txtLength.Text = "1"
'            txtOChar.Text = "12"
'            cbxChar.Text = "None"
'            cbCheckDate.Checked = False
'            cbCheckDate.Enabled = False
'            cbCheckDueDate.Checked = False
'            cbCheckDueDate.Enabled = False
'            cbCheckDup.Checked = False
'            cbCheckDup.Enabled = False
'    End Select
'End Sub
'& _
'"', [CheckLength] = '" & cbCheckLength.Checked & "|" & cbxCon.Text & "|" & txtLA.Text & "-" & txtLA.Text & "|" & cbxAct1.Text & _
'"', [CheckBlank] = '" & cbCheckBlank.Checked & "|" & cbxAct2.Text & _
'"', [CheckDup] = '" & cbCheckDup.Checked & "|" & cbxAct3.Text & _
'"', [CheckDate] = '" & cbCheckDate.Checked & "|" & cbxDay.Text & "-" & cbxDay2.Text & "," & cbxMonth.Text & "-" & cbxMonth2.Text & "," & cbxYear.Text & "-" & cbxYear2.Text & "|" & cbxAct4.Text & _
'"', [CheckDueDate] = '" & cbCheckDueDate.Checked & "|" & cbxDDay.Text & "-" & cbxDDay2.Text & "," & cbxDMonth.Text & "-" & cbxDMonth2.Text & "," & cbxDYear.Text & "-" & cbxDYear2.Text & "|" & cbxAct5.Text & _
'"', [Regex] = '" & txtRegex.Text.Replace("'", "''")

'txtRegex.Text = .Item("Regex").ToString

'Dim chkL, chkB, chkDup, chkDt, chkDDt, dt, ddt, dd, mm, yy, ddd, dmm, dyy, LRng As String()
'chkL = .Item("Checklength").ToString.Split("|")
'LRng = chkL(2).Split("-")
'chkB = .Item("Checkblank").ToString.Split("|")
'chkDup = .Item("Checkdup").ToString.Split("|")
'chkDt = .Item("Checkdate").ToString.Split("|")
'dt = chkDt(1).Split(",")
'dd = dt(0).Split("-")
'mm = dt(1).Split("-")
'yy = dt(2).Split("-")
'chkDDt = .Item("CheckdueDate").ToString.Split("|")
'ddt = chkDDt(1).Split(",")
'ddd = ddt(0).Split("-")
'dmm = ddt(1).Split("-")
'dyy = ddt(2).Split("-")

'cbxAct1.Text = chkL(chkL.GetUpperBound(0))
'cbxAct2.Text = chkB(chkB.GetUpperBound(0))
'cbxAct3.Text = chkDup(chkDup.GetUpperBound(0))
'cbxAct4.Text = chkDt(chkDt.GetUpperBound(0))
'cbxAct5.Text = chkDDt(chkDDt.GetUpperBound(0))

'cbCheckLength.Checked = Boolean.Parse(chkL(0))
'cbCheckBlank.Checked = Boolean.Parse(chkB(0))
'cbCheckDup.Checked = Boolean.Parse(chkDup(0))
'cbCheckDate.Checked = Boolean.Parse(chkDt(0))
'cbCheckDueDate.Checked = Boolean.Parse(chkDDt(0))

'cbxCon.Text = chkL(1)

'txtLA.Text = LRng(0)
'txtLB.Text = LRng(1)

'cbxDay.Text = dd(0)
'cbxDay2.Text = dd(1)

'cbxMonth.Text = mm(0)
'cbxMonth2.Text = mm(1)

'cbxYear.Text = yy(0)
'cbxYear2.Text = yy(1)

'cbxDDay.Text = ddd(0)
'cbxDDay2.Text = ddd(1)

'cbxDMonth.Text = dmm(0)
'cbxDMonth2.Text = dmm(1)

'cbxDYear.Text = dyy(0)
'cbxDYear2.Text = dyy(1)