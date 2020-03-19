<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clientInformation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.tbProName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbProEmail = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbPCName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.tbPCEmail = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbClient = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "New Client:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(239, 142)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tbProName
        '
        Me.tbProName.Location = New System.Drawing.Point(123, 42)
        Me.tbProName.Name = "tbProName"
        Me.tbProName.ReadOnly = True
        Me.tbProName.Size = New System.Drawing.Size(191, 20)
        Me.tbProName.TabIndex = 4
        Me.tbProName.Text = "Sean Ivan M. Fernandez"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Programmer's Name:"
        '
        'tbProEmail
        '
        Me.tbProEmail.Location = New System.Drawing.Point(123, 69)
        Me.tbProEmail.Name = "tbProEmail"
        Me.tbProEmail.ReadOnly = True
        Me.tbProEmail.Size = New System.Drawing.Size(191, 20)
        Me.tbProEmail.TabIndex = 6
        Me.tbProEmail.Text = " sean.fernandez@ddcgroup.asia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Programmer's Email:"
        '
        'tbPCName
        '
        Me.tbPCName.Location = New System.Drawing.Point(123, 94)
        Me.tbPCName.Name = "tbPCName"
        Me.tbPCName.Size = New System.Drawing.Size(191, 20)
        Me.tbPCName.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "PC Name:"
        '
        'tbPCEmail
        '
        Me.tbPCEmail.Location = New System.Drawing.Point(123, 119)
        Me.tbPCEmail.Name = "tbPCEmail"
        Me.tbPCEmail.Size = New System.Drawing.Size(191, 20)
        Me.tbPCEmail.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "PC Email:"
        '
        'cbClient
        '
        Me.cbClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbClient.FormattingEnabled = True
        Me.cbClient.Location = New System.Drawing.Point(79, 12)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(163, 21)
        Me.cbClient.TabIndex = 11
        '
        'clientInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 171)
        Me.Controls.Add(Me.cbClient)
        Me.Controls.Add(Me.tbPCEmail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbPCName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbProEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tbProName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Name = "clientInfo"
        Me.Text = "Add New Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tbProName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbProEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbPCName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbPCEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbClient As System.Windows.Forms.ComboBox
End Class
