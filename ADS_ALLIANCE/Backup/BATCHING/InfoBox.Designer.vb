<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoBox
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbJobcode = New System.Windows.Forms.ComboBox
        Me.tbKW = New System.Windows.Forms.TextBox
        Me.tbSUB = New System.Windows.Forms.TextBox
        Me.tbREC = New System.Windows.Forms.TextBox
        Me.tbHEADER = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chE1Only = New System.Windows.Forms.CheckBox
        Me.chTWOPAGES = New System.Windows.Forms.CheckBox
        Me.chLANDSCAPE = New System.Windows.Forms.CheckBox
        Me.lbJOB = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbCLIENT = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.images1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnAddJOBCODE = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.tbBS = New System.Windows.Forms.TextBox
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Jobcode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Record Counting:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(150, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Substring:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Keyword:"
        '
        'cbJobcode
        '
        Me.cbJobcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJobcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbJobcode.FormattingEnabled = True
        Me.cbJobcode.Location = New System.Drawing.Point(68, 31)
        Me.cbJobcode.Name = "cbJobcode"
        Me.cbJobcode.Size = New System.Drawing.Size(188, 21)
        Me.cbJobcode.TabIndex = 4
        '
        'tbKW
        '
        Me.tbKW.Location = New System.Drawing.Point(69, 59)
        Me.tbKW.Name = "tbKW"
        Me.tbKW.Size = New System.Drawing.Size(75, 20)
        Me.tbKW.TabIndex = 5
        '
        'tbSUB
        '
        Me.tbSUB.Location = New System.Drawing.Point(210, 59)
        Me.tbSUB.Name = "tbSUB"
        Me.tbSUB.Size = New System.Drawing.Size(78, 20)
        Me.tbSUB.TabIndex = 6
        '
        'tbREC
        '
        Me.tbREC.Location = New System.Drawing.Point(102, 88)
        Me.tbREC.Name = "tbREC"
        Me.tbREC.Size = New System.Drawing.Size(87, 20)
        Me.tbREC.TabIndex = 7
        '
        'tbHEADER
        '
        Me.tbHEADER.Location = New System.Drawing.Point(76, 143)
        Me.tbHEADER.Name = "tbHEADER"
        Me.tbHEADER.Size = New System.Drawing.Size(211, 20)
        Me.tbHEADER.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Batch Size:"
        '
        'chE1Only
        '
        Me.chE1Only.AutoSize = True
        Me.chE1Only.Location = New System.Drawing.Point(205, 85)
        Me.chE1Only.Name = "chE1Only"
        Me.chE1Only.Size = New System.Drawing.Size(83, 17)
        Me.chE1Only.TabIndex = 10
        Me.chE1Only.Text = "Entry 1 Only"
        Me.chE1Only.UseVisualStyleBackColor = True
        '
        'chTWOPAGES
        '
        Me.chTWOPAGES.AutoSize = True
        Me.chTWOPAGES.Location = New System.Drawing.Point(205, 103)
        Me.chTWOPAGES.Name = "chTWOPAGES"
        Me.chTWOPAGES.Size = New System.Drawing.Size(64, 17)
        Me.chTWOPAGES.TabIndex = 11
        Me.chTWOPAGES.Text = "2 pages"
        Me.chTWOPAGES.UseVisualStyleBackColor = True
        '
        'chLANDSCAPE
        '
        Me.chLANDSCAPE.AutoSize = True
        Me.chLANDSCAPE.Location = New System.Drawing.Point(205, 122)
        Me.chLANDSCAPE.Name = "chLANDSCAPE"
        Me.chLANDSCAPE.Size = New System.Drawing.Size(79, 17)
        Me.chLANDSCAPE.TabIndex = 12
        Me.chLANDSCAPE.Text = "Landscape"
        Me.chLANDSCAPE.UseVisualStyleBackColor = True
        '
        'lbJOB
        '
        Me.lbJOB.AutoSize = True
        Me.lbJOB.Location = New System.Drawing.Point(172, 9)
        Me.lbJOB.Name = "lbJOB"
        Me.lbJOB.Size = New System.Drawing.Size(48, 13)
        Me.lbJOB.TabIndex = 13
        Me.lbJOB.Text = "Jobcode"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(136, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "JOB:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "CLIENT:"
        '
        'lbCLIENT
        '
        Me.lbCLIENT.AutoSize = True
        Me.lbCLIENT.Location = New System.Drawing.Point(66, 9)
        Me.lbCLIENT.Name = "lbCLIENT"
        Me.lbCLIENT.Size = New System.Drawing.Size(24, 13)
        Me.lbCLIENT.TabIndex = 15
        Me.lbCLIENT.Text = "Job"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.images1})
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(5, 170)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(282, 221)
        Me.dgv.TabIndex = 85
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "FIELD NAME"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'images1
        '
        Me.images1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.images1.HeaderText = "DATA TYPE"
        Me.images1.Name = "images1"
        '
        'btnAddJOBCODE
        '
        Me.btnAddJOBCODE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddJOBCODE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddJOBCODE.Location = New System.Drawing.Point(259, 31)
        Me.btnAddJOBCODE.Name = "btnAddJOBCODE"
        Me.btnAddJOBCODE.Size = New System.Drawing.Size(31, 21)
        Me.btnAddJOBCODE.TabIndex = 114
        Me.btnAddJOBCODE.Text = "..."
        Me.btnAddJOBCODE.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "Header:"
        '
        'tbBS
        '
        Me.tbBS.Location = New System.Drawing.Point(76, 116)
        Me.tbBS.Name = "tbBS"
        Me.tbBS.Size = New System.Drawing.Size(120, 20)
        Me.tbBS.TabIndex = 115
        '
        'InfoBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 394)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbBS)
        Me.Controls.Add(Me.btnAddJOBCODE)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbCLIENT)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbJOB)
        Me.Controls.Add(Me.chLANDSCAPE)
        Me.Controls.Add(Me.chTWOPAGES)
        Me.Controls.Add(Me.chE1Only)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbHEADER)
        Me.Controls.Add(Me.tbREC)
        Me.Controls.Add(Me.tbSUB)
        Me.Controls.Add(Me.tbKW)
        Me.Controls.Add(Me.cbJobcode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfoBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Information Box"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbJobcode As System.Windows.Forms.ComboBox
    Friend WithEvents tbKW As System.Windows.Forms.TextBox
    Friend WithEvents tbSUB As System.Windows.Forms.TextBox
    Friend WithEvents tbREC As System.Windows.Forms.TextBox
    Friend WithEvents tbHEADER As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chE1Only As System.Windows.Forms.CheckBox
    Friend WithEvents chTWOPAGES As System.Windows.Forms.CheckBox
    Friend WithEvents chLANDSCAPE As System.Windows.Forms.CheckBox
    Friend WithEvents lbJOB As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbCLIENT As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents images1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddJOBCODE As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbBS As System.Windows.Forms.TextBox

End Class
