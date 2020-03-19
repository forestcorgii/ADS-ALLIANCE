<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class jobInformation
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.tbTAHours = New System.Windows.Forms.TextBox
        Me.cbJob = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tbClient = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Job:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(138, 59)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TA Hours:"
        '
        'tbTAHours
        '
        Me.tbTAHours.Location = New System.Drawing.Point(61, 61)
        Me.tbTAHours.Name = "tbTAHours"
        Me.tbTAHours.Size = New System.Drawing.Size(73, 20)
        Me.tbTAHours.TabIndex = 8
        '
        'cbJob
        '
        Me.cbJob.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbJob.FormattingEnabled = True
        Me.cbJob.Location = New System.Drawing.Point(61, 32)
        Me.cbJob.Name = "cbJob"
        Me.cbJob.Size = New System.Drawing.Size(149, 21)
        Me.cbJob.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Client:"
        '
        'tbClient
        '
        Me.tbClient.Location = New System.Drawing.Point(61, 6)
        Me.tbClient.Name = "tbClient"
        Me.tbClient.ReadOnly = True
        Me.tbClient.Size = New System.Drawing.Size(149, 20)
        Me.tbClient.TabIndex = 13
        '
        'jobInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 89)
        Me.Controls.Add(Me.tbClient)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbJob)
        Me.Controls.Add(Me.tbTAHours)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Name = "jobInformation"
        Me.Text = "Add New Job"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbTAHours As System.Windows.Forms.TextBox
    Friend WithEvents cbJob As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbClient As System.Windows.Forms.TextBox
End Class
