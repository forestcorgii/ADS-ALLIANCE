Imports System.Windows.Forms
Imports System.IO
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.Diagnostics.Process

Public Class clientInformation
    Private ReadOnly Property CLIENT() As String
        Get
            Return cbClient.Text
        End Get
    End Property

    Public Sub New(ByVal cb As ComboBox)
        InitializeComponent()
        cbClient.Items.Clear()
        For Each i As String In cb.Items
            cbClient.Items.Add(i)
        Next
        If cbClient.Items.Count > 0 Then
            cbClient.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not File.Exists(String.Format("{0}{1}.mdb", ClientDIR, CLIENT)) Then
            If MsgBox(String.Format("Add {0} as client??", CLIENT), MsgBoxStyle.YesNo, "Add Client") = MsgBoxResult.Yes Then
                cbClient.Items.Add(CLIENT)
                mdbCreate(ClientDIR & CLIENT & ".mdb")
                mdbOpen(ClientDIR & CLIENT & ".mdb", conClient)
                mdbCreateTable(CLIENT & "_Info", New String() {"Client-text(50)", "Programmer-text(100)", "Programmers_Email-text(100)", "PC-text(100)", "PC_Email-text(100)"}, conClient)
                mdbCreateTable(CLIENT, New String() {"Job-text(50)", "TAHour-text(10)"}, conClient)

                mdbInsert(CLIENT & "_Info", New String() {"Client", "Programmer", "Programmers_Email", "PC", "PC_Email"}, New String() {CLIENT, tbProName.Text, tbProEmail.Text, tbPCName.Text, tbPCEmail.Text}, conClient)
            End If
            MsgBox("Saved.")
        Else
            mdbUpdate(CLIENT & "_Info", New String() {"Client", "Programmer", "Programmers_Email", "PC", "PC_Email"}, New String() {CLIENT, tbProName.Text, tbProEmail.Text, tbPCName.Text, tbPCEmail.Text}, Nothing, conClient)
            MsgBox("Editted.")
        End If
    End Sub

    Private Sub cbClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.SelectedIndexChanged
        If File.Exists(ClientDIR & cbClient.SelectedItem & ".mdb") Then
            Dim tmp As New DataTable
            mdbOpen(ClientDIR & cbClient.SelectedItem & ".mdb", conClient)
            mdbToDT(String.Format("SELECT * FROM {0}_Info", cbClient.SelectedItem), tmp, conClient)

            With tmp.Rows(0)
                tbPCEmail.Text = .Item("PC_Email").ToString
                tbPCName.Text = .Item("PC").ToString
            End With
        End If
    End Sub
End Class