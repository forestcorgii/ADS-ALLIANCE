Imports System.Windows.Forms
Imports System.IO
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.Diagnostics.Process

Public Class jobInformation

    Private Property CLIENT() As String
        Get
            Return tbClient.Text
        End Get
        Set(ByVal value As String)
            tbClient.Text = value
        End Set
    End Property


    Private ReadOnly Property JOB() As String
        Get
            Return cbJob.Text
        End Get
    End Property

    Public Sub New(ByVal cl As String, ByVal cb As ComboBox)
        InitializeComponent()

        CLIENT = cl
        For Each i As String In cb.Items
            cbJob.Items.Add(i)
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim list As New List(Of String)
        list = getTables(conClient)

        If Not list.Contains(JOB) Then
            If MsgBox(String.Format("Add {0} as Job??", JOB), MsgBoxStyle.YesNo, "Add Client") = MsgBoxResult.Yes Then
                cbJob.Items.Add(JOB)
                mdbInsert(CLIENT, New String() {"Job", "TAHour"}, New String() {JOB, tbTAHours.Text}, conClient)
                mdbCreateTable(JOB & "_FieldInfo", New String() {"Field-text", "Displayname-text", "Page-text(1)", "Autonext-YESNO", "Description-text", "Haslookup-YESNO", "Maxlength-text(10)", "Case-text(10)", "Character-text(20)", "Othercharacter-text(30)", "Pulloutkey-text(20)", "Numberformat-text", "Defaultvalue-text", "ValidCharPerIndex-text"}, conClient)
                MsgBox("Saved.")
            End If
        Else
            mdbUpdate(CLIENT, New String() {"Job", "TAHour"}, New String() {JOB, tbTAHours.Text}, New String() {"Job", JOB}, conClient)
            MsgBox("Editted.")
        End If
    End Sub

    Private Sub cbClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJob.SelectedIndexChanged
        Dim list As New List(Of String)
        list = getTables(conClient)

        If list.Contains(JOB) Then
            Dim tmp As New DataTable
            mdbToDT(String.Format("SELECT * FROM {0}", cbJob.SelectedItem), tmp, conClient)

            With tmp.Rows(0)
                tbTAHours.Text = .Item("TAHour").ToString
            End With
        End If
    End Sub
End Class