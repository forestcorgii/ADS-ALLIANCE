<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fieldMaker
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OFD1 = New System.Windows.Forms.OpenFileDialog
        Me.btdAdd = New System.Windows.Forms.Button
        Me.btnInsert = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.cbJOBCODE = New System.Windows.Forms.ComboBox
        Me.btnOPEN = New System.Windows.Forms.Button
        Me.lbTBL = New System.Windows.Forms.ListBox
        Me.cbJOB = New System.Windows.Forms.ComboBox
        Me.btnAddCLIENT = New System.Windows.Forms.Button
        Me.btnAddJOBCODE = New System.Windows.Forms.Button
        Me.btnAddJOB = New System.Windows.Forms.Button
        Me.cbCLIENT = New System.Windows.Forms.ComboBox
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Client:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Job:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Job Code:"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(12, 78)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(338, 283)
        Me.dgv.TabIndex = 84
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "FIELD NAME"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'OFD1
        '
        Me.OFD1.Filter = "MDB FILES|*.mdb"
        '
        'btdAdd
        '
        Me.btdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btdAdd.Location = New System.Drawing.Point(368, 182)
        Me.btdAdd.Name = "btdAdd"
        Me.btdAdd.Size = New System.Drawing.Size(116, 29)
        Me.btdAdd.TabIndex = 86
        Me.btdAdd.Text = "ADD"
        Me.btdAdd.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInsert.Location = New System.Drawing.Point(368, 217)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(116, 29)
        Me.btnInsert.TabIndex = 87
        Me.btnInsert.Text = "INSERT"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Location = New System.Drawing.Point(368, 252)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(116, 31)
        Me.btnDelete.TabIndex = 88
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Location = New System.Drawing.Point(368, 312)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(116, 31)
        Me.btnSave.TabIndex = 92
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbJOBCODE
        '
        Me.cbJOBCODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJOBCODE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbJOBCODE.FormattingEnabled = True
        Me.cbJOBCODE.Location = New System.Drawing.Point(69, 51)
        Me.cbJOBCODE.Name = "cbJOBCODE"
        Me.cbJOBCODE.Size = New System.Drawing.Size(121, 21)
        Me.cbJOBCODE.TabIndex = 94
        '
        'btnOPEN
        '
        Me.btnOPEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOPEN.Location = New System.Drawing.Point(392, 10)
        Me.btnOPEN.Name = "btnOPEN"
        Me.btnOPEN.Size = New System.Drawing.Size(75, 23)
        Me.btnOPEN.TabIndex = 109
        Me.btnOPEN.Text = "OPEN"
        Me.btnOPEN.UseVisualStyleBackColor = True
        '
        'lbTBL
        '
        Me.lbTBL.FormattingEnabled = True
        Me.lbTBL.Location = New System.Drawing.Point(356, 42)
        Me.lbTBL.Name = "lbTBL"
        Me.lbTBL.Size = New System.Drawing.Size(137, 121)
        Me.lbTBL.TabIndex = 110
        '
        'cbJOB
        '
        Me.cbJOB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJOB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbJOB.FormattingEnabled = True
        Me.cbJOB.Location = New System.Drawing.Point(69, 29)
        Me.cbJOB.Name = "cbJOB"
        Me.cbJOB.Size = New System.Drawing.Size(121, 21)
        Me.cbJOB.TabIndex = 112
        '
        'btnAddCLIENT
        '
        Me.btnAddCLIENT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddCLIENT.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCLIENT.Location = New System.Drawing.Point(191, 5)
        Me.btnAddCLIENT.Name = "btnAddCLIENT"
        Me.btnAddCLIENT.Size = New System.Drawing.Size(31, 22)
        Me.btnAddCLIENT.TabIndex = 101
        Me.btnAddCLIENT.Text = "..."
        Me.btnAddCLIENT.UseVisualStyleBackColor = True
        '
        'btnAddJOBCODE
        '
        Me.btnAddJOBCODE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddJOBCODE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddJOBCODE.Location = New System.Drawing.Point(191, 54)
        Me.btnAddJOBCODE.Name = "btnAddJOBCODE"
        Me.btnAddJOBCODE.Size = New System.Drawing.Size(31, 21)
        Me.btnAddJOBCODE.TabIndex = 113
        Me.btnAddJOBCODE.Text = "..."
        Me.btnAddJOBCODE.UseVisualStyleBackColor = True
        '
        'btnAddJOB
        '
        Me.btnAddJOB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddJOB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddJOB.Location = New System.Drawing.Point(191, 29)
        Me.btnAddJOB.Name = "btnAddJOB"
        Me.btnAddJOB.Size = New System.Drawing.Size(31, 22)
        Me.btnAddJOB.TabIndex = 114
        Me.btnAddJOB.Text = "..."
        Me.btnAddJOB.UseVisualStyleBackColor = True
        '
        'cbCLIENT
        '
        Me.cbCLIENT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCLIENT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbCLIENT.FormattingEnabled = True
        Me.cbCLIENT.Location = New System.Drawing.Point(69, 7)
        Me.cbCLIENT.Name = "cbCLIENT"
        Me.cbCLIENT.Size = New System.Drawing.Size(121, 21)
        Me.cbCLIENT.TabIndex = 111
        '
        'fieldMaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 371)
        Me.Controls.Add(Me.btnAddJOB)
        Me.Controls.Add(Me.btnAddJOBCODE)
        Me.Controls.Add(Me.cbJOB)
        Me.Controls.Add(Me.cbCLIENT)
        Me.Controls.Add(Me.lbTBL)
        Me.Controls.Add(Me.btnOPEN)
        Me.Controls.Add(Me.btnAddCLIENT)
        Me.Controls.Add(Me.cbJOBCODE)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.btdAdd)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fieldMaker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fieldMaker v2.0"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents OFD1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btdAdd As System.Windows.Forms.Button
    Friend WithEvents btnInsert As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbJOBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents btnOPEN As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbTBL As System.Windows.Forms.ListBox
    Friend WithEvents cbJOB As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddCLIENT As System.Windows.Forms.Button
    Friend WithEvents btnAddJOBCODE As System.Windows.Forms.Button
    Friend WithEvents btnAddJOB As System.Windows.Forms.Button
    Friend WithEvents cbCLIENT As System.Windows.Forms.ComboBox

End Class
