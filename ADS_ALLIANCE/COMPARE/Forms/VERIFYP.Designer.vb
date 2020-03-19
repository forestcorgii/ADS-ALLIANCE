<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VERIFYP
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VERIFYP))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnCompare = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnRecompare = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnBrowse = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvE1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvE2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.rwFieldName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbMode = New System.Windows.Forms.Label()
        Me.lblFieldName = New System.Windows.Forms.Label()
        Me.lbViewForm = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbCRec = New System.Windows.Forms.Label()
        Me.lbTotalRec = New System.Windows.Forms.Label()
        Me.txtValue = New ModifiedComponents.ModifiedTextbox(Me.components)
        Me.imgVwer = New ImageViewer.ImageViewer()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbll = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLocID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUserID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblImg = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblMdb = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OFD1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvE2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 0)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ImageToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(936, 25)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnOpen, Me.mnSave, Me.mnCompare, Me.mnRecompare, Me.mnBrowse, Me.mnGoto, Me.mnExit})
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
        Me.mnOpen.Size = New System.Drawing.Size(193, 22)
        Me.mnOpen.Text = "OPEN"
        '
        'mnSave
        '
        Me.mnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnSave.Enabled = False
        Me.mnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnSave.Image = CType(resources.GetObject("mnSave.Image"), System.Drawing.Image)
        Me.mnSave.Name = "mnSave"
        Me.mnSave.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnSave.Size = New System.Drawing.Size(193, 22)
        Me.mnSave.Text = "SAVE"
        '
        'mnCompare
        '
        Me.mnCompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnCompare.Enabled = False
        Me.mnCompare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnCompare.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnCompare.Image = CType(resources.GetObject("mnCompare.Image"), System.Drawing.Image)
        Me.mnCompare.Name = "mnCompare"
        Me.mnCompare.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnCompare.Size = New System.Drawing.Size(193, 22)
        Me.mnCompare.Text = "START RUNNING"
        '
        'mnRecompare
        '
        Me.mnRecompare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnRecompare.Enabled = False
        Me.mnRecompare.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnRecompare.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnRecompare.Image = CType(resources.GetObject("mnRecompare.Image"), System.Drawing.Image)
        Me.mnRecompare.Name = "mnRecompare"
        Me.mnRecompare.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F3), System.Windows.Forms.Keys)
        Me.mnRecompare.Size = New System.Drawing.Size(193, 22)
        Me.mnRecompare.Text = "EDIT RECORD"
        '
        'mnBrowse
        '
        Me.mnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnBrowse.Enabled = False
        Me.mnBrowse.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnBrowse.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnBrowse.Image = CType(resources.GetObject("mnBrowse.Image"), System.Drawing.Image)
        Me.mnBrowse.Name = "mnBrowse"
        Me.mnBrowse.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.mnBrowse.Size = New System.Drawing.Size(193, 22)
        Me.mnBrowse.Text = "BROWSE MODE"
        '
        'mnGoto
        '
        Me.mnGoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.mnGoto.Enabled = False
        Me.mnGoto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnGoto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.mnGoto.Image = CType(resources.GetObject("mnGoto.Image"), System.Drawing.Image)
        Me.mnGoto.Name = "mnGoto"
        Me.mnGoto.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnGoto.Size = New System.Drawing.Size(193, 22)
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
        Me.mnExit.Size = New System.Drawing.Size(193, 22)
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.imgVwer, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(936, 430)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(671, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(262, 424)
        Me.Panel1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvE1, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.dgvE2, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.dgv, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lbMode, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFieldName, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbViewForm, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.txtValue, 0, 4)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 7
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.71121!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.4296!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.4296!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.4296!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(262, 424)
        Me.TableLayoutPanel2.TabIndex = 56
        '
        'dgvE1
        '
        Me.dgvE1.AllowUserToAddRows = False
        Me.dgvE1.AllowUserToDeleteRows = False
        Me.dgvE1.AllowUserToResizeColumns = False
        Me.dgvE1.AllowUserToResizeRows = False
        Me.dgvE1.BackgroundColor = System.Drawing.Color.White
        Me.dgvE1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvE1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvE1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvE1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvE1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvE1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvE1.EnableHeadersVisualStyles = False
        Me.dgvE1.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvE1.Location = New System.Drawing.Point(1, 246)
        Me.dgvE1.Margin = New System.Windows.Forms.Padding(1)
        Me.dgvE1.MultiSelect = False
        Me.dgvE1.Name = "dgvE1"
        Me.dgvE1.ReadOnly = True
        Me.dgvE1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvE1.RowHeadersVisible = False
        Me.dgvE1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.dgvE1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvE1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvE1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvE1.Size = New System.Drawing.Size(260, 87)
        Me.dgvE1.TabIndex = 45
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "FIELD"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "ENTRY 1"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'dgvE2
        '
        Me.dgvE2.AllowUserToAddRows = False
        Me.dgvE2.AllowUserToDeleteRows = False
        Me.dgvE2.AllowUserToResizeColumns = False
        Me.dgvE2.AllowUserToResizeRows = False
        Me.dgvE2.BackgroundColor = System.Drawing.Color.White
        Me.dgvE2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvE2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvE2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvE2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvE2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgvE2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvE2.EnableHeadersVisualStyles = False
        Me.dgvE2.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgvE2.Location = New System.Drawing.Point(1, 335)
        Me.dgvE2.Margin = New System.Windows.Forms.Padding(1)
        Me.dgvE2.MultiSelect = False
        Me.dgvE2.Name = "dgvE2"
        Me.dgvE2.ReadOnly = True
        Me.dgvE2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvE2.RowHeadersVisible = False
        Me.dgvE2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgvE2.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvE2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvE2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvE2.Size = New System.Drawing.Size(260, 88)
        Me.dgvE2.TabIndex = 44
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "FIELD"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "ENTRY 2"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeColumns = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rwFieldName, Me.rwValue})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(1, 157)
        Me.dgv.Margin = New System.Windows.Forms.Padding(1)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgv.RowHeadersVisible = False
        Me.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(260, 87)
        Me.dgv.TabIndex = 42
        '
        'rwFieldName
        '
        Me.rwFieldName.HeaderText = "FIELD"
        Me.rwFieldName.Name = "rwFieldName"
        Me.rwFieldName.ReadOnly = True
        Me.rwFieldName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'rwValue
        '
        Me.rwValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.rwValue.HeaderText = "COMPARE"
        Me.rwValue.Name = "rwValue"
        Me.rwValue.ReadOnly = True
        Me.rwValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'lbMode
        '
        Me.lbMode.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lbMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMode.ForeColor = System.Drawing.Color.White
        Me.lbMode.Location = New System.Drawing.Point(3, 0)
        Me.lbMode.Name = "lbMode"
        Me.lbMode.Size = New System.Drawing.Size(256, 18)
        Me.lbMode.TabIndex = 0
        Me.lbMode.Text = "BROWSE MODE"
        Me.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFieldName
        '
        Me.lblFieldName.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lblFieldName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFieldName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFieldName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFieldName.ForeColor = System.Drawing.Color.White
        Me.lblFieldName.Location = New System.Drawing.Point(3, 108)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(256, 20)
        Me.lblFieldName.TabIndex = 39
        Me.lblFieldName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbViewForm
        '
        Me.lbViewForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lbViewForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbViewForm.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbViewForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbViewForm.Location = New System.Drawing.Point(3, 18)
        Me.lbViewForm.Name = "lbViewForm"
        Me.lbViewForm.Size = New System.Drawing.Size(256, 70)
        Me.lbViewForm.TabIndex = 40
        Me.lbViewForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.57143!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.42857!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 91)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(256, 14)
        Me.TableLayoutPanel3.TabIndex = 43
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
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
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(73, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(183, 14)
        Me.TableLayoutPanel4.TabIndex = 53
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(76, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 14)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "OF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbCRec
        '
        Me.lbCRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbCRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbCRec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbCRec.ForeColor = System.Drawing.Color.Black
        Me.lbCRec.Location = New System.Drawing.Point(3, 0)
        Me.lbCRec.Name = "lbCRec"
        Me.lbCRec.Size = New System.Drawing.Size(67, 14)
        Me.lbCRec.TabIndex = 47
        Me.lbCRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbTotalRec
        '
        Me.lbTotalRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lbTotalRec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTotalRec.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lbTotalRec.ForeColor = System.Drawing.Color.Black
        Me.lbTotalRec.Location = New System.Drawing.Point(112, 0)
        Me.lbTotalRec.Name = "lbTotalRec"
        Me.lbTotalRec.Size = New System.Drawing.Size(68, 14)
        Me.lbTotalRec.TabIndex = 48
        Me.lbTotalRec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtValue
        '
        Me.txtValue.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
        Me.txtValue.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Normal
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValue.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValue.Location = New System.Drawing.Point(3, 131)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.OtherCharacter = Nothing
        Me.txtValue.Size = New System.Drawing.Size(256, 26)
        Me.txtValue.TabIndex = 46
        Me.txtValue.WithSpaces = True
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
        Me.imgVwer.ScrollbarsVisible = False
        Me.imgVwer.Size = New System.Drawing.Size(668, 430)
        Me.imgVwer.StretchImageToFit = False
        Me.imgVwer.TabIndex = 3
        Me.imgVwer.ZoomFactor = 1.0R
        Me.imgVwer.ZoomOnMouseWheel = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.StatusStrip1.GripMargin = New System.Windows.Forms.Padding(1)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbll, Me.lblLocID, Me.ToolStripStatusLabel2, Me.lblUserID, Me.ToolStripStatusLabel3, Me.lblImg, Me.ToolStripStatusLabel11, Me.lblMdb})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 455)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(936, 22)
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbll
        '
        Me.lbll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbll.ForeColor = System.Drawing.Color.Black
        Me.lbll.Name = "lbll"
        Me.lbll.Size = New System.Drawing.Size(82, 17)
        Me.lbll.Text = "LOCATION ID:"
        '
        'lblLocID
        '
        Me.lblLocID.AutoSize = False
        Me.lblLocID.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblLocID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocID.ForeColor = System.Drawing.Color.Black
        Me.lblLocID.Name = "lblLocID"
        Me.lblLocID.Size = New System.Drawing.Size(50, 17)
        Me.lblLocID.Text = "*****"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusLabel2.Text = "USER ID:"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = False
        Me.lblUserID.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblUserID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserID.ForeColor = System.Drawing.Color.Black
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(50, 17)
        Me.lblUserID.Text = "*****"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(46, 17)
        Me.ToolStripStatusLabel3.Text = "IMAGE:"
        '
        'lblImg
        '
        Me.lblImg.AutoSize = False
        Me.lblImg.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblImg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImg.ForeColor = System.Drawing.Color.Black
        Me.lblImg.Name = "lblImg"
        Me.lblImg.Size = New System.Drawing.Size(100, 17)
        Me.lblImg.Text = "########.tif"
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel11.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLabel11.Text = "MDB:"
        '
        'lblMdb
        '
        Me.lblMdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.lblMdb.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMdb.ForeColor = System.Drawing.Color.Black
        Me.lblMdb.Name = "lblMdb"
        Me.lblMdb.Size = New System.Drawing.Size(107, 17)
        Me.lblMdb.Text = "********************"
        '
        'OFD1
        '
        Me.OFD1.FileName = "00000001"
        Me.OFD1.Filter = "MDB File|*.mdb"
        '
        'Timer
        '
        Me.Timer.Enabled = True
        '
        'VERIFYP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(936, 477)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "VERIFYP"
        Me.Text = "VERIFY"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.dgvE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvE2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnCompare As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnRecompare As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents imgVwer As ImageViewer.ImageViewer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbll As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLocID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUserID As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblImg As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblMdb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvE1 As System.Windows.Forms.DataGridView
    Friend WithEvents dgvE2 As System.Windows.Forms.DataGridView
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lbMode As System.Windows.Forms.Label
    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents lbViewForm As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbCRec As System.Windows.Forms.Label
    Friend WithEvents lbTotalRec As System.Windows.Forms.Label
    Friend WithEvents OFD1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents txtValue As ModifiedComponents.ModifiedTextbox
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwFieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnSave As System.Windows.Forms.ToolStripMenuItem
End Class
