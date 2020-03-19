<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QCL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCL))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMdb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.rwFieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clE1Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clE2Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lbMode = New System.Windows.Forms.Label()
        Me.lblFieldName = New System.Windows.Forms.Label()
        Me.lbViewForm = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblImg = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblUserID = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLocID = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbCRec = New System.Windows.Forms.Label()
        Me.lbTotalRec = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.imgVwer = New ImageViewer.ImageViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnQC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGoto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveImageToLeftToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveImageToRightToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveImageDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoveImageUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(1)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel11, Me.lblMdb})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 426)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1197, 22)
        Me.StatusStrip1.TabIndex = 16
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLabel11.Text = "MDB:"
        '
        'lblMdb
        '
        Me.lblMdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblMdb.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMdb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblMdb.Name = "lblMdb"
        Me.lblMdb.Size = New System.Drawing.Size(107, 17)
        Me.lblMdb.Text = "********************"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.dgv, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1197, 401)
        Me.TableLayoutPanel5.TabIndex = 17
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rwFieldName, Me.rwValue, Me.clE1Value, Me.clE2Value})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(1, 252)
        Me.dgv.Margin = New System.Windows.Forms.Padding(1)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(1195, 148)
        Me.dgv.TabIndex = 42
        '
        'rwFieldName
        '
        Me.rwFieldName.HeaderText = "FIELD"
        Me.rwFieldName.Name = "rwFieldName"
        Me.rwFieldName.ReadOnly = True
        '
        'rwValue
        '
        Me.rwValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.rwValue.HeaderText = "COMPARE"
        Me.rwValue.Name = "rwValue"
        Me.rwValue.ReadOnly = True
        '
        'clE1Value
        '
        Me.clE1Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clE1Value.HeaderText = "ENTRY 1"
        Me.clE1Value.Name = "clE1Value"
        Me.clE1Value.ReadOnly = True
        '
        'clE2Value
        '
        Me.clE2Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clE2Value.HeaderText = "ENTRY 2"
        Me.clE2Value.Name = "clE2Value"
        Me.clE2Value.ReadOnly = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.25587!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.74413!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.imgVwer, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1197, 251)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(927, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(267, 245)
        Me.Panel1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtValue, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lbMode, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFieldName, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbViewForm, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(267, 245)
        Me.TableLayoutPanel2.TabIndex = 56
        '
        'txtValue
        '
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValue.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue.Location = New System.Drawing.Point(3, 220)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(261, 25)
        Me.txtValue.TabIndex = 41
        '
        'lbMode
        '
        Me.lbMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lbMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMode.ForeColor = System.Drawing.Color.White
        Me.lbMode.Location = New System.Drawing.Point(3, 0)
        Me.lbMode.Name = "lbMode"
        Me.lbMode.Size = New System.Drawing.Size(261, 32)
        Me.lbMode.TabIndex = 0
        Me.lbMode.Text = "BROWSE MODE"
        Me.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFieldName
        '
        Me.lblFieldName.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lblFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFieldName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFieldName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldName.ForeColor = System.Drawing.Color.White
        Me.lblFieldName.Location = New System.Drawing.Point(3, 191)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(261, 26)
        Me.lblFieldName.TabIndex = 39
        Me.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbViewForm
        '
        Me.lbViewForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lbViewForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbViewForm.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbViewForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbViewForm.Location = New System.Drawing.Point(3, 32)
        Me.lbViewForm.Name = "lbViewForm"
        Me.lbViewForm.Size = New System.Drawing.Size(261, 39)
        Me.lbViewForm.TabIndex = 40
        Me.lbViewForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.60055!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.39945!))
        Me.TableLayoutPanel3.Controls.Add(Me.lblImg, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblUserID, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblLocID, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 74)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(261, 114)
        Me.TableLayoutPanel3.TabIndex = 43
        '
        'lblImg
        '
        Me.lblImg.AutoSize = True
        Me.lblImg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblImg.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblImg.Location = New System.Drawing.Point(87, 86)
        Me.lblImg.Name = "lblImg"
        Me.lblImg.Size = New System.Drawing.Size(169, 26)
        Me.lblImg.TabIndex = 59
        Me.lblImg.Text = "********.tif"
        Me.lblImg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(5, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 26)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "IMAGE:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserID.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblUserID.Location = New System.Drawing.Point(87, 58)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(169, 26)
        Me.lblUserID.TabIndex = 57
        Me.lblUserID.Text = "****"
        Me.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(5, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 26)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "USER ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLocID
        '
        Me.lblLocID.AutoSize = True
        Me.lblLocID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocID.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblLocID.Location = New System.Drawing.Point(87, 30)
        Me.lblLocID.Name = "lblLocID"
        Me.lblLocID.Size = New System.Drawing.Size(169, 26)
        Me.lblLocID.TabIndex = 55
        Me.lblLocID.Text = "****"
        Me.lblLocID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(5, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 26)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "RECORD"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lbCRec, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.lbTotalRec, 2, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(84, 2)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(175, 26)
        Me.TableLayoutPanel4.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(73, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 26)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "OF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbCRec
        '
        Me.lbCRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbCRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCRec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbCRec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbCRec.Location = New System.Drawing.Point(3, 0)
        Me.lbCRec.Name = "lbCRec"
        Me.lbCRec.Size = New System.Drawing.Size(64, 26)
        Me.lbCRec.TabIndex = 47
        Me.lbCRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTotalRec
        '
        Me.lbTotalRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbTotalRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTotalRec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbTotalRec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbTotalRec.Location = New System.Drawing.Point(108, 0)
        Me.lbTotalRec.Name = "lbTotalRec"
        Me.lbTotalRec.Size = New System.Drawing.Size(64, 26)
        Me.lbTotalRec.TabIndex = 48
        Me.lbTotalRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(5, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 26)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "LOCATION ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'imgVwer
        '
        Me.imgVwer.AlignCenter = False
        Me.imgVwer.AntiAlias = True
        Me.imgVwer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.imgVwer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgVwer.CanvassBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.imgVwer.CursorTheme = ImageViewer.ImageViewer.MyCursor.Light
        Me.imgVwer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgVwer.Image = Nothing
        Me.imgVwer.ImagePath = ""
        Me.imgVwer.initialimage = Nothing
        Me.imgVwer.Location = New System.Drawing.Point(0, 0)
        Me.imgVwer.Margin = New System.Windows.Forms.Padding(0)
        Me.imgVwer.Name = "imgVwer"
        Me.imgVwer.Origin = New System.Drawing.Point(0, 0)
        Me.imgVwer.PageCount = 0
        Me.imgVwer.PageNumber = 1
        Me.imgVwer.PanButton = System.Windows.Forms.MouseButtons.Left
        Me.imgVwer.PanMode = True
        Me.imgVwer.RetainRotation = False
        Me.imgVwer.RulerColor = System.Drawing.Color.Firebrick
        Me.imgVwer.RulerTop = 0
        Me.imgVwer.RulerVisible = False
        Me.imgVwer.ScrollbarsVisible = True
        Me.imgVwer.Size = New System.Drawing.Size(924, 251)
        Me.imgVwer.StretchImageToFit = False
        Me.imgVwer.TabIndex = 3
        Me.imgVwer.ZoomFactor = 1.0R
        Me.imgVwer.ZoomOnMouseWheel = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ImageToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1197, 25)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnOpen, Me.mnQC, Me.mnSave, Me.mnBrowse, Me.mnEdit, Me.mnGoto, Me.mnExit})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(44, 21)
        Me.FileToolStripMenuItem.Text = "FILE"
        '
        'mnOpen
        '
        Me.mnOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnOpen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnOpen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnOpen.Image = CType(resources.GetObject("mnOpen.Image"), System.Drawing.Image)
        Me.mnOpen.Name = "mnOpen"
        Me.mnOpen.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnOpen.Size = New System.Drawing.Size(177, 22)
        Me.mnOpen.Text = "OPEN"
        '
        'mnQC
        '
        Me.mnQC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnQC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnQC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnQC.Image = CType(resources.GetObject("mnQC.Image"), System.Drawing.Image)
        Me.mnQC.Name = "mnQC"
        Me.mnQC.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnQC.Size = New System.Drawing.Size(177, 22)
        Me.mnQC.Text = "START QC"
        '
        'mnSave
        '
        Me.mnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnSave.Image = CType(resources.GetObject("mnSave.Image"), System.Drawing.Image)
        Me.mnSave.Name = "mnSave"
        Me.mnSave.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnSave.Size = New System.Drawing.Size(177, 22)
        Me.mnSave.Text = "SAVE"
        '
        'mnBrowse
        '
        Me.mnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnBrowse.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnBrowse.Image = CType(resources.GetObject("mnBrowse.Image"), System.Drawing.Image)
        Me.mnBrowse.Name = "mnBrowse"
        Me.mnBrowse.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.mnBrowse.Size = New System.Drawing.Size(177, 22)
        Me.mnBrowse.Text = "BROWSE MODE"
        '
        'mnEdit
        '
        Me.mnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnEdit.Image = CType(resources.GetObject("mnEdit.Image"), System.Drawing.Image)
        Me.mnEdit.Name = "mnEdit"
        Me.mnEdit.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.mnEdit.Size = New System.Drawing.Size(177, 22)
        Me.mnEdit.Text = "EDIT RECORD"
        '
        'mnGoto
        '
        Me.mnGoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnGoto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnGoto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnGoto.Image = CType(resources.GetObject("mnGoto.Image"), System.Drawing.Image)
        Me.mnGoto.Name = "mnGoto"
        Me.mnGoto.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnGoto.Size = New System.Drawing.Size(177, 22)
        Me.mnGoto.Text = "GO TO"
        '
        'mnExit
        '
        Me.mnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnExit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnExit.Image = CType(resources.GetObject("mnExit.Image"), System.Drawing.Image)
        Me.mnExit.Name = "mnExit"
        Me.mnExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.mnExit.Size = New System.Drawing.Size(177, 22)
        Me.mnExit.Text = "EXIT"
        '
        'ImageToolStripMenuItem
        '
        Me.ImageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RotateToolStripMenuItem, Me.ZoomInToolStripMenuItem, Me.ZoomOutToolStripMenuItem, Me.MoveImageToLeftToolStripMenuItem, Me.MoveImageToRightToolStripMenuItem, Me.MoveImageDownToolStripMenuItem, Me.MoveImageUpToolStripMenuItem})
        Me.ImageToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImageToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem"
        Me.ImageToolStripMenuItem.Size = New System.Drawing.Size(61, 21)
        Me.ImageToolStripMenuItem.Text = "IMAGE"
        '
        'RotateToolStripMenuItem
        '
        Me.RotateToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.RotateToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RotateToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.RotateToolStripMenuItem.Image = CType(resources.GetObject("RotateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RotateToolStripMenuItem.Name = "RotateToolStripMenuItem"
        Me.RotateToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.RotateToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.RotateToolStripMenuItem.Text = "ROTATE"
        '
        'ZoomInToolStripMenuItem
        '
        Me.ZoomInToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ZoomInToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZoomInToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ZoomInToolStripMenuItem.Image = CType(resources.GetObject("ZoomInToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ZoomInToolStripMenuItem.Name = "ZoomInToolStripMenuItem"
        Me.ZoomInToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.ZoomInToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ZoomInToolStripMenuItem.Text = "ZOOM IN"
        '
        'ZoomOutToolStripMenuItem
        '
        Me.ZoomOutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ZoomOutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZoomOutToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ZoomOutToolStripMenuItem.Image = CType(resources.GetObject("ZoomOutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ZoomOutToolStripMenuItem.Name = "ZoomOutToolStripMenuItem"
        Me.ZoomOutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ZoomOutToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.ZoomOutToolStripMenuItem.Text = "ZOOM OUT"
        '
        'MoveImageToLeftToolStripMenuItem
        '
        Me.MoveImageToLeftToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MoveImageToLeftToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveImageToLeftToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveImageToLeftToolStripMenuItem.Image = CType(resources.GetObject("MoveImageToLeftToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveImageToLeftToolStripMenuItem.Name = "MoveImageToLeftToolStripMenuItem"
        Me.MoveImageToLeftToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.J), System.Windows.Forms.Keys)
        Me.MoveImageToLeftToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MoveImageToLeftToolStripMenuItem.Text = "MOVE IMAGE LEFT"
        '
        'MoveImageToRightToolStripMenuItem
        '
        Me.MoveImageToRightToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MoveImageToRightToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveImageToRightToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveImageToRightToolStripMenuItem.Image = CType(resources.GetObject("MoveImageToRightToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveImageToRightToolStripMenuItem.Name = "MoveImageToRightToolStripMenuItem"
        Me.MoveImageToRightToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.MoveImageToRightToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MoveImageToRightToolStripMenuItem.Text = "MOVE IMAGE RIGHT"
        '
        'MoveImageDownToolStripMenuItem
        '
        Me.MoveImageDownToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MoveImageDownToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveImageDownToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveImageDownToolStripMenuItem.Image = CType(resources.GetObject("MoveImageDownToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveImageDownToolStripMenuItem.Name = "MoveImageDownToolStripMenuItem"
        Me.MoveImageDownToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+,"
        Me.MoveImageDownToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Oemcomma), System.Windows.Forms.Keys)
        Me.MoveImageDownToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MoveImageDownToolStripMenuItem.Text = "MOVE IMAGE DOWN"
        '
        'MoveImageUpToolStripMenuItem
        '
        Me.MoveImageUpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.MoveImageUpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveImageUpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.MoveImageUpToolStripMenuItem.Image = CType(resources.GetObject("MoveImageUpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoveImageUpToolStripMenuItem.Name = "MoveImageUpToolStripMenuItem"
        Me.MoveImageUpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+I"
        Me.MoveImageUpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.MoveImageUpToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.MoveImageUpToolStripMenuItem.Text = "MOVE IMAGE UP"
        '
        'QCL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1197, 448)
        Me.Controls.Add(Me.TableLayoutPanel5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "QCL"
        Me.Text = "QCL"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblMdb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents rwFieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clE1Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clE2Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lbMode As System.Windows.Forms.Label
    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents lbViewForm As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblImg As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblUserID As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblLocID As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbCRec As System.Windows.Forms.Label
    Friend WithEvents lbTotalRec As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents imgVwer As ImageViewer.ImageViewer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnQC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnGoto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveImageToLeftToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveImageToRightToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveImageDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveImageUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
