Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Collections
Imports System.Data.OleDb
Imports System.ComponentModel.Component
Imports System.Object
Imports System.IO.StreamReader
Imports System.IO.StreamWriter
Imports System.Text
Imports System.Diagnostics.Process
Imports System.Windows.Forms

Public Class Info

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using wr As StreamWriter = File.CreateText(ClientDIR & "Info.inf")
            wr.WriteLine(CLIENT)
            wr.WriteLine(JOB)
        End Using
        MsgBox("Main form needs to be close.")
        MNFORM.Close()
        Me.Close()
    End Sub

    Private Sub cbClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCLIENT.SelectedIndexChanged
        getJobList(CLIENT)
    End Sub

    Private Sub cbJob_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJOB.SelectedIndexChanged
        getJobInfo(JOB)
    End Sub
End Class