<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BATCHING
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BATCHING))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbPROCFOLDER = New System.Windows.Forms.Label()
        Me.lbPROCIMG = New System.Windows.Forms.Label()
        Me.PB1 = New System.Windows.Forms.ProgressBar()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.dirLB = New Microsoft.VisualBasic.Compatibility.VB6.DirListBox()
        Me.driLB = New Microsoft.VisualBasic.Compatibility.VB6.DriveListBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvBSEL = New System.Windows.Forms.DataGridView()
        Me.fieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.images2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.records2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvB = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.images1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.records1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPATH = New System.Windows.Forms.Button()
        Me.tbPATH = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.btnADDALL = New System.Windows.Forms.Button()
        Me.btnCLEAR = New System.Windows.Forms.Button()
        Me.btnCLEARALL = New System.Windows.Forms.Button()
        Me.btnBATCH = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbPC = New System.Windows.Forms.Label()
        Me.lbProgrammer = New System.Windows.Forms.Label()
        Me.cbClient = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbTAHour = New System.Windows.Forms.Label()
        Me.cbJob = New System.Windows.Forms.ComboBox()
        Me.tbBSIZE = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.FBD1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.dgvBSEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(869, 400)
        Me.TableLayoutPanel1.TabIndex = 82
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblProcess, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lbPROCFOLDER, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbPROCIMG, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.PB1, 1, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 321)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 1, 3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(863, 76)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.BackColor = System.Drawing.Color.Transparent
        Me.lblProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcess.ForeColor = System.Drawing.Color.Black
        Me.lblProcess.Location = New System.Drawing.Point(3, 50)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(57, 26)
        Me.lblProcess.TabIndex = 72
        Me.lblProcess.Text = "Status :"
        Me.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 25)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Folder :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 25)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Image :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbPROCFOLDER
        '
        Me.lbPROCFOLDER.BackColor = System.Drawing.Color.Transparent
        Me.lbPROCFOLDER.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPROCFOLDER.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPROCFOLDER.ForeColor = System.Drawing.Color.Black
        Me.lbPROCFOLDER.Location = New System.Drawing.Point(66, 0)
        Me.lbPROCFOLDER.Name = "lbPROCFOLDER"
        Me.lbPROCFOLDER.Size = New System.Drawing.Size(794, 25)
        Me.lbPROCFOLDER.TabIndex = 70
        Me.lbPROCFOLDER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbPROCIMG
        '
        Me.lbPROCIMG.BackColor = System.Drawing.Color.Transparent
        Me.lbPROCIMG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPROCIMG.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPROCIMG.ForeColor = System.Drawing.Color.Black
        Me.lbPROCIMG.Location = New System.Drawing.Point(66, 25)
        Me.lbPROCIMG.Name = "lbPROCIMG"
        Me.lbPROCIMG.Size = New System.Drawing.Size(794, 25)
        Me.lbPROCIMG.TabIndex = 71
        Me.lbPROCIMG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PB1
        '
        Me.PB1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.PB1.Location = New System.Drawing.Point(66, 53)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(794, 20)
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
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 88)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(863, 231)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.dirLB, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.driLB, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(194, 225)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'dirLB
        '
        Me.dirLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dirLB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dirLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dirLB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dirLB.ForeColor = System.Drawing.Color.Black
        Me.dirLB.FormattingEnabled = True
        Me.dirLB.IntegralHeight = False
        Me.dirLB.Location = New System.Drawing.Point(4, 28)
        Me.dirLB.Name = "dirLB"
        Me.dirLB.Size = New System.Drawing.Size(186, 193)
        Me.dirLB.TabIndex = 79
        '
        'driLB
        '
        Me.driLB.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.driLB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.driLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.driLB.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.driLB.ForeColor = System.Drawing.Color.Black
        Me.driLB.FormattingEnabled = True
        Me.driLB.Location = New System.Drawing.Point(1, 1)
        Me.driLB.Margin = New System.Windows.Forms.Padding(0)
        Me.driLB.Name = "driLB"
        Me.driLB.Size = New System.Drawing.Size(192, 23)
        Me.driLB.TabIndex = 78
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.dgvBSEL, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.dgvB, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel12, 0, 2)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(203, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 3
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(507, 225)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'dgvBSEL
        '
        Me.dgvBSEL.AllowUserToAddRows = False
        Me.dgvBSEL.AllowUserToDeleteRows = False
        Me.dgvBSEL.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
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
        Me.dgvBSEL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fieldName, Me.images2, Me.records2})
        Me.dgvBSEL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBSEL.EnableHeadersVisualStyles = False
        Me.dgvBSEL.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvBSEL.Location = New System.Drawing.Point(4, 98)
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
        Me.dgvBSEL.Size = New System.Drawing.Size(499, 87)
        Me.dgvBSEL.TabIndex = 82
        '
        'fieldName
        '
        Me.fieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.fieldName.HeaderText = "SELECTED BATCHES"
        Me.fieldName.Name = "fieldName"
        Me.fieldName.ReadOnly = True
        '
        'images2
        '
        Me.images2.HeaderText = "IMAGES"
        Me.images2.Name = "images2"
        Me.images2.ReadOnly = True
        Me.images2.Width = 75
        '
        'records2
        '
        Me.records2.HeaderText = "RECORDS"
        Me.records2.Name = "records2"
        Me.records2.ReadOnly = True
        Me.records2.Width = 75
        '
        'dgvB
        '
        Me.dgvB.AllowUserToAddRows = False
        Me.dgvB.AllowUserToDeleteRows = False
        Me.dgvB.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
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
        Me.dgvB.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.images1, Me.records1})
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
        Me.dgvB.Size = New System.Drawing.Size(499, 87)
        Me.dgvB.TabIndex = 83
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "BATCHES"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'images1
        '
        Me.images1.HeaderText = "IMAGES"
        Me.images1.Name = "images1"
        Me.images1.ReadOnly = True
        Me.images1.Width = 75
        '
        'records1
        '
        Me.records1.HeaderText = "RECORDS"
        Me.records1.Name = "records1"
        Me.records1.ReadOnly = True
        Me.records1.Width = 75
        '
        'TableLayoutPanel12
        '
        Me.TableLayoutPanel12.ColumnCount = 2
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel12.Controls.Add(Me.btnPATH, 0, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.tbPATH, 0, 0)
        Me.TableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel12.Location = New System.Drawing.Point(4, 192)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        Me.TableLayoutPanel12.RowCount = 1
        Me.TableLayoutPanel12.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel12.Size = New System.Drawing.Size(499, 29)
        Me.TableLayoutPanel12.TabIndex = 84
        '
        'btnPATH
        '
        Me.btnPATH.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.btnPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPATH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPATH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPATH.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPATH.ForeColor = System.Drawing.Color.White
        Me.btnPATH.Location = New System.Drawing.Point(432, 3)
        Me.btnPATH.Name = "btnPATH"
        Me.btnPATH.Size = New System.Drawing.Size(64, 23)
        Me.btnPATH.TabIndex = 74
        Me.btnPATH.Text = "Path"
        Me.btnPATH.UseVisualStyleBackColor = False
        '
        'tbPATH
        '
        Me.tbPATH.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.tbPATH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPATH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbPATH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPATH.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPATH.ForeColor = System.Drawing.Color.Black
        Me.tbPATH.Location = New System.Drawing.Point(3, 3)
        Me.tbPATH.Multiline = True
        Me.tbPATH.Name = "tbPATH"
        Me.tbPATH.ReadOnly = True
        Me.tbPATH.Size = New System.Drawing.Size(423, 23)
        Me.tbPATH.TabIndex = 73
        Me.tbPATH.Text = "D:\"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel7.ColumnCount = 1
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.btnADD, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnADDALL, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.btnCLEAR, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.btnCLEARALL, 0, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.btnBATCH, 0, 4)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(716, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 7
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(144, 225)
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
        Me.btnBATCH.Text = "&Batch"
        Me.btnBATCH.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 4
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel10, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel9, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Panel5, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel8, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(869, 85)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel10.ColumnCount = 1
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel10.Controls.Add(Me.Label8, 0, 1)
        Me.TableLayoutPanel10.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(437, 3)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 3
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(211, 79)
        Me.TableLayoutPanel10.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(205, 27)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "TA Hour:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(205, 26)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Batch Size:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(205, 26)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Job:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.lbPC, 0, 2)
        Me.TableLayoutPanel9.Controls.Add(Me.lbProgrammer, 0, 1)
        Me.TableLayoutPanel9.Controls.Add(Me.cbClient, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(220, 3)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 3
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(211, 79)
        Me.TableLayoutPanel9.TabIndex = 5
        '
        'lbPC
        '
        Me.lbPC.BackColor = System.Drawing.Color.Transparent
        Me.lbPC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPC.ForeColor = System.Drawing.Color.Black
        Me.lbPC.Location = New System.Drawing.Point(3, 53)
        Me.lbPC.Name = "lbPC"
        Me.lbPC.Size = New System.Drawing.Size(205, 26)
        Me.lbPC.TabIndex = 64
        Me.lbPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbProgrammer
        '
        Me.lbProgrammer.AutoSize = True
        Me.lbProgrammer.BackColor = System.Drawing.Color.Transparent
        Me.lbProgrammer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbProgrammer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProgrammer.ForeColor = System.Drawing.Color.Black
        Me.lbProgrammer.Location = New System.Drawing.Point(3, 29)
        Me.lbProgrammer.Name = "lbProgrammer"
        Me.lbProgrammer.Size = New System.Drawing.Size(205, 24)
        Me.lbProgrammer.TabIndex = 65
        Me.lbProgrammer.Text = "Sean Ivan Fernandez"
        Me.lbProgrammer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbClient
        '
        Me.cbClient.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.cbClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbClient.FormattingEnabled = True
        Me.cbClient.Location = New System.Drawing.Point(3, 3)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(205, 21)
        Me.cbClient.TabIndex = 111
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.TableLayoutPanel11)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(654, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(212, 79)
        Me.Panel5.TabIndex = 3
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel11.ColumnCount = 1
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel11.Controls.Add(Me.lbTAHour, 0, 2)
        Me.TableLayoutPanel11.Controls.Add(Me.cbJob, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.tbBSIZE, 0, 1)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel11.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 3
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(212, 79)
        Me.TableLayoutPanel11.TabIndex = 7
        '
        'lbTAHour
        '
        Me.lbTAHour.BackColor = System.Drawing.Color.Transparent
        Me.lbTAHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTAHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTAHour.ForeColor = System.Drawing.Color.Black
        Me.lbTAHour.Location = New System.Drawing.Point(3, 54)
        Me.lbTAHour.Name = "lbTAHour"
        Me.lbTAHour.Size = New System.Drawing.Size(206, 25)
        Me.lbTAHour.TabIndex = 113
        Me.lbTAHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbJob
        '
        Me.cbJob.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.cbJob.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJob.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbJob.FormattingEnabled = True
        Me.cbJob.Location = New System.Drawing.Point(3, 3)
        Me.cbJob.Name = "cbJob"
        Me.cbJob.Size = New System.Drawing.Size(206, 21)
        Me.cbJob.TabIndex = 112
        '
        'tbBSIZE
        '
        Me.tbBSIZE.AcceptsTab = True
        Me.tbBSIZE.BackColor = System.Drawing.Color.White
        Me.tbBSIZE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbBSIZE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbBSIZE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBSIZE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.tbBSIZE.Location = New System.Drawing.Point(3, 26)
        Me.tbBSIZE.Name = "tbBSIZE"
        Me.tbBSIZE.Size = New System.Drawing.Size(206, 22)
        Me.tbBSIZE.TabIndex = 69
        Me.tbBSIZE.Text = "25"
        Me.tbBSIZE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel8.Controls.Add(Me.Label10, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label12, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 3
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(211, 79)
        Me.TableLayoutPanel8.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(205, 27)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Project Coor:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(3, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(205, 26)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Programmer:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(205, 26)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Client:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BATCHING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(869, 400)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "BATCHING"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        CType(Me.dgvBSEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.TableLayoutPanel12.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.TableLayoutPanel11.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbPROCFOLDER As System.Windows.Forms.Label
    Friend WithEvents lbPROCIMG As System.Windows.Forms.Label
    Friend WithEvents PB1 As System.Windows.Forms.ProgressBar
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dirLB As Compatibility.VB6.DirListBox
    Friend WithEvents driLB As Compatibility.VB6.DriveListBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvB As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents images1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents records1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents btnADDALL As System.Windows.Forms.Button
    Friend WithEvents btnCLEAR As System.Windows.Forms.Button
    Friend WithEvents btnCLEARALL As System.Windows.Forms.Button
    Friend WithEvents btnBATCH As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbPC As System.Windows.Forms.Label
    Friend WithEvents lbProgrammer As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbBSIZE As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents FBD1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents dgvBSEL As System.Windows.Forms.DataGridView
    Friend WithEvents fieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents images2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents records2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnPATH As System.Windows.Forms.Button
    Friend WithEvents tbPATH As System.Windows.Forms.TextBox
    Friend WithEvents cbClient As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbJob As System.Windows.Forms.ComboBox
    Friend WithEvents lbTAHour As System.Windows.Forms.Label

End Class
