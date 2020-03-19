Imports System.Runtime.InteropServices
Imports Microsoft.win32
Public Class frmLogin
    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtLocation.Text = "" Then
            MsgBox("Enter Location ID", MsgBoxStyle.Exclamation, "Username")
            txtLocation.Focus()
        ElseIf txtLocation.Text.Length < 4 Then
            MsgBox("Must enter 4 - 8 characters. (Location ID)", MsgBoxStyle.Exclamation, "Username")
            txtLocation.Focus()
        ElseIf txtOperator.Text = "" Then
            MsgBox("Enter Operator ID", MsgBoxStyle.Exclamation, "Password")
            txtOperator.Focus()
        ElseIf txtOperator.Text.Length < 4 Then
            MsgBox("Must enter 4 - 8 characters. (Operator ID)", MsgBoxStyle.Exclamation, "Username")
            txtOperator.Focus()
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Yes
            Timer1.Enabled = False
            LocID = txtLocation.Text
            UserID = txtOperator.Text
            'Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim servicePack As String = Environment.OSVersion.ServicePack
        ' Dim osVersion As String = Environment.OSVersion.VersionString.Replace(servicePack, "")


        Dim username As String = Environment.UserName.ToString
        Dim strCompName As String = Environment.MachineName.ToString


        Dim CPU As String = Main()
        Dim temp() As String = AppName.Split("-")
        lblInfo.Text = temp(0) & "-" & temp(1)
        'lblInfo2.Text = osVersion & vbNewLine & CPU & vbNewLine & "Computer Name: " & strCompName & vbNewLine & "User: " & username
        lblInfo2.Text = "Version: " & My.Application.Info.Version.ToString
        lblTime.Text = "System Date: " & DateTime.Now.ToString("MMM dd, yyyy") & vbNewLine & _
                       "System Time: " & DateTime.Now.ToString("hh:mm:ss tt")

        txtLocation.Focus()
    End Sub

    Private Sub txt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLocation.Enter, txtOperator.Enter
        sender.SelectAll()
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocation.KeyPress
        If Asc(e.KeyChar) = 13 And txtLocation.Text <> "" Then
            txtOperator.Focus()
        End If
    End Sub

    Private Sub txtbox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLocation.KeyDown, txtOperator.KeyDown
        If (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Down) Then
            If UCase(Me.ActiveControl.Name) = "TXTLOCATION" Then
                txtOperator.Focus()
            End If
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            If UCase(Me.ActiveControl.Name) = "TXTOPERATOR" Then
                txtLocation.Focus()
            End If
        End If
    End Sub

    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOperator.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogIn_Click(sender, e)
        End If
    End Sub

    Private Function Main() As String
        Dim res As String

        Dim m_LM As RegistryKey
        Dim m_HW As RegistryKey
        Dim m_Des As RegistryKey
        Dim m_System As RegistryKey
        Dim m_CPU As RegistryKey
        Dim m_Info As RegistryKey

        m_LM = Registry.LocalMachine
        m_HW = m_LM.OpenSubKey("HARDWARE")
        m_Des = m_HW.OpenSubKey("DESCRIPTION")
        m_System = m_Des.OpenSubKey("SYSTEM")
        m_CPU = m_System.OpenSubKey("CentralProcessor")
        m_Info = m_CPU.OpenSubKey("0")

        res = m_Info.GetValue("ProcessorNameString")

        Return res
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = "System Date: " & DateTime.Now.ToString("MMM dd, yyyy") & vbNewLine & _
                       "System Time: " & DateTime.Now.ToString("hh:mm:ss tt")
    End Sub
End Class
