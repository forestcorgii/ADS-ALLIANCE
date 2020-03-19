<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KS
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KS))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.PB1 = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.driLB = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox()
        Me.dirLB = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbE1 = New System.Windows.Forms.RadioButton()
        Me.rbE2 = New System.Windows.Forms.RadioButton()
        Me.rbCom = New System.Windows.Forms.RadioButton()
        Me.dgvBSEL = New System.Windows.Forms.DataGridView()
        Me.bSel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvB = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnADDALL = New System.Windows.Forms.Button()
        Me.btnCLEAR = New System.Windows.Forms.Button()
        Me.btnCLEARALL = New System.Windows.Forms.Button()
        Me.btnBATCH = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dgvBSEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(818, 373)
        Me.TableLayoutPanel1.TabIndex = 85
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblProcess, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.PB1, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 344)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(818, 29)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.BackColor = System.Drawing.Color.Transparent
        Me.lblProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcess.ForeColor = System.Drawing.Color.Black
        Me.lblProcess.Location = New System.Drawing.Point(4, 1)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(57, 27)
        Me.lblProcess.TabIndex = 72
        Me.lblProcess.Text = "Status :"
        Me.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PB1
        '
        Me.PB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.PB1.Location = New System.Drawing.Point(68, 4)
        Me.PB1.MarqueeAnimationSpeed = 50
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(746, 21)
        Me.PB1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PB1.TabIndex = 73
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel7, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(812, 339)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.driLB, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.dirLB, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(194, 333)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'driLB
        '
        Me.driLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.driLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.driLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.driLB.FormattingEnabled = True
        Me.driLB.Location = New System.Drawing.Point(4, 4)
        Me.driLB.Name = "driLB"
        Me.driLB.Size = New System.Drawing.Size(186, 21)
        Me.driLB.TabIndex = 0
        '
        'dirLB
        '
        Me.dirLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dirLB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dirLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dirLB.FormattingEnabled = True
        Me.dirLB.IntegralHeight = False
        Me.dirLB.Location = New System.Drawing.Point(3, 34)
        Me.dirLB.Margin = New System.Windows.Forms.Padding(2)
        Me.dirLB.Name = "dirLB"
        Me.dirLB.Size = New System.Drawing.Size(188, 296)
        Me.dirLB.TabIndex = 1
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.dgvBSEL, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.dgvB, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(203, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(456, 333)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel4.Controls.Add(Me.rbE1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.rbE2, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.rbCom, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 304)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(448, 25)
        Me.TableLayoutPanel4.TabIndex = 85
        '
        'rbE1
        '
        Me.rbE1.AutoSize = True
        Me.rbE1.Checked = True
        Me.rbE1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbE1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbE1.ForeColor = System.Drawing.Color.Black
        Me.rbE1.Location = New System.Drawing.Point(3, 3)
        Me.rbE1.Name = "rbE1"
        Me.rbE1.Size = New System.Drawing.Size(143, 19)
        Me.rbE1.TabIndex = 0
        Me.rbE1.TabStop = True
        Me.rbE1.Text = "Entry 1"
        Me.rbE1.UseVisualStyleBackColor = True
        '
        'rbE2
        '
        Me.rbE2.AutoSize = True
        Me.rbE2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbE2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbE2.ForeColor = System.Drawing.Color.Black
        Me.rbE2.Location = New System.Drawing.Point(152, 3)
        Me.rbE2.Name = "rbE2"
        Me.rbE2.Size = New System.Drawing.Size(143, 19)
        Me.rbE2.TabIndex = 1
        Me.rbE2.Text = "Entry 2"
        Me.rbE2.UseVisualStyleBackColor = True
        '
        'rbCom
        '
        Me.rbCom.AutoSize = True
        Me.rbCom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbCom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCom.ForeColor = System.Drawing.Color.Black
        Me.rbCom.Location = New System.Drawing.Point(301, 3)
        Me.rbCom.Name = "rbCom"
        Me.rbCom.Size = New System.Drawing.Size(144, 19)
        Me.rbCom.TabIndex = 2
        Me.rbCom.Text = "Compare"
        Me.rbCom.UseVisualStyleBackColor = True
        '
        'dgvBSEL
        '
        Me.dgvBSEL.AllowUserToAddRows = False
        Me.dgvBSEL.AllowUserToDeleteRows = False
        Me.dgvBSEL.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvBSEL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBSEL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBSEL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBSEL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBSEL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bSel})
        Me.dgvBSEL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBSEL.EnableHeadersVisualStyles = False
        Me.dgvBSEL.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvBSEL.Location = New System.Drawing.Point(4, 154)
        Me.dgvBSEL.Name = "dgvBSEL"
        Me.dgvBSEL.ReadOnly = True
        Me.dgvBSEL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvBSEL.RowHeadersVisible = False
        Me.dgvBSEL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.dgvBSEL.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBSEL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvBSEL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBSEL.Size = New System.Drawing.Size(448, 143)
        Me.dgvBSEL.TabIndex = 82
        '
        'bSel
        '
        Me.bSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.bSel.HeaderText = "SELECTED BATCHES"
        Me.bSel.Name = "bSel"
        Me.bSel.ReadOnly = True
        '
        'dgvB
        '
        Me.dgvB.AllowUserToAddRows = False
        Me.dgvB.AllowUserToDeleteRows = False
        Me.dgvB.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvB.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvB.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.dgvB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvB.EnableHeadersVisualStyles = False
        Me.dgvB.GridColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.dgvB.Location = New System.Drawing.Point(4, 4)
        Me.dgvB.Name = "dgvB"
        Me.dgvB.ReadOnly = True
        Me.dgvB.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvB.RowHeadersVisible = False
        Me.dgvB.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgvB.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvB.Size = New System.Drawing.Size(448, 143)
        Me.dgvB.TabIndex = 83
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "BATCHES"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnADD, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnADDALL, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.btnCLEAR, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.btnCLEARALL, 0, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.btnBATCH, 0, 4)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(665, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 7
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(144, 333)
        Me.TableLayoutPanel7.TabIndex = 2
        '
        'btnADD
        '
        Me.btnADD.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnADD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADD.ForeColor = System.Drawing.Color.White
        Me.btnADD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnADD.Location = New System.Drawing.Point(4, 4)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(136, 33)
        Me.btnADD.TabIndex = 52
        Me.btnADD.Text = "Add &Selected"
        Me.btnADD.UseVisualStyleBackColor = False
        '
        'btnADDALL
        '
        Me.btnADDALL.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnADDALL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnADDALL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnADDALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADDALL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADDALL.ForeColor = System.Drawing.Color.White
        Me.btnADDALL.Location = New System.Drawing.Point(4, 44)
        Me.btnADDALL.Name = "btnADDALL"
        Me.btnADDALL.Size = New System.Drawing.Size(136, 33)
        Me.btnADDALL.TabIndex = 53
        Me.btnADDALL.Text = "Select &All"
        Me.btnADDALL.UseVisualStyleBackColor = False
        '
        'btnCLEAR
        '
        Me.btnCLEAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCLEAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCLEAR.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLEAR.ForeColor = System.Drawing.Color.White
        Me.btnCLEAR.Location = New System.Drawing.Point(4, 84)
        Me.btnCLEAR.Name = "btnCLEAR"
        Me.btnCLEAR.Size = New System.Drawing.Size(136, 33)
        Me.btnCLEAR.TabIndex = 56
        Me.btnCLEAR.Text = "Remove Selected"
        Me.btnCLEAR.UseVisualStyleBackColor = False
        '
        'btnCLEARALL
        '
        Me.btnCLEARALL.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnCLEARALL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCLEARALL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCLEARALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCLEARALL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLEARALL.ForeColor = System.Drawing.Color.White
        Me.btnCLEARALL.Location = New System.Drawing.Point(4, 124)
        Me.btnCLEARALL.Name = "btnCLEARALL"
        Me.btnCLEARALL.Size = New System.Drawing.Size(136, 33)
        Me.btnCLEARALL.TabIndex = 55
        Me.btnCLEARALL.Text = "Clear All"
        Me.btnCLEARALL.UseVisualStyleBackColor = False
        '
        'btnBATCH
        '
        Me.btnBATCH.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnBATCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBATCH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBATCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBATCH.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBATCH.ForeColor = System.Drawing.Color.White
        Me.btnBATCH.Location = New System.Drawing.Point(4, 164)
        Me.btnBATCH.Name = "btnBATCH"
        Me.btnBATCH.Size = New System.Drawing.Size(136, 34)
        Me.btnBATCH.TabIndex = 54
        Me.btnBATCH.Text = "&Start KS"
        Me.btnBATCH.UseVisualStyleBackColor = False
        '
        'KS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(818, 373)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "KS"
        Me.Text = "KS"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.dgvBSEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents driLB As Microsoft.VisualBasic.Compatibility.VB6.DriveListBox
    Friend WithEvents dirLB As Microsoft.VisualBasic.Compatibility.VB6.DirListBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvBSEL As System.Windows.Forms.DataGridView
    Friend WithEvents bSel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvB As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnADDALL As System.Windows.Forms.Button
    Friend WithEvents btnCLEAR As System.Windows.Forms.Button
    Friend WithEvents btnCLEARALL As System.Windows.Forms.Button
    Friend WithEvents btnBATCH As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbE1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbE2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbCom As System.Windows.Forms.RadioButton

End Class
