<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fieldInfoEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fieldInfoEditor))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.tbDisplayName = New System.Windows.Forms.TextBox
        Me.tbField = New System.Windows.Forms.TextBox
        Me.tbPage = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.cbHasLookup = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbAutoNext = New System.Windows.Forms.CheckBox
        Me.txtValidChar = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbxCase = New System.Windows.Forms.ComboBox
        Me.txtPOKey = New System.Windows.Forms.TextBox
        Me.txtLength = New System.Windows.Forms.TextBox
        Me.txtOChar = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbxChar = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtRegex = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.cbCheckBlank = New System.Windows.Forms.CheckBox
        Me.cbxAct2 = New System.Windows.Forms.ComboBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cbxAct3 = New System.Windows.Forms.ComboBox
        Me.cbCheckDup = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbxDDay2 = New System.Windows.Forms.ComboBox
        Me.cbxDYear2 = New System.Windows.Forms.ComboBox
        Me.cbxDMonth2 = New System.Windows.Forms.ComboBox
        Me.cbCheckDueDate = New System.Windows.Forms.CheckBox
        Me.cbxAct5 = New System.Windows.Forms.ComboBox
        Me.cbxDDay = New System.Windows.Forms.ComboBox
        Me.cbxDYear = New System.Windows.Forms.ComboBox
        Me.cbxDMonth = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbxDay2 = New System.Windows.Forms.ComboBox
        Me.cbxYear2 = New System.Windows.Forms.ComboBox
        Me.cbxMonth2 = New System.Windows.Forms.ComboBox
        Me.cbCheckDate = New System.Windows.Forms.CheckBox
        Me.cbxAct4 = New System.Windows.Forms.ComboBox
        Me.cbxDay = New System.Windows.Forms.ComboBox
        Me.cbxYear = New System.Windows.Forms.ComboBox
        Me.cbxMonth = New System.Windows.Forms.ComboBox
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.txtLB = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtLA = New System.Windows.Forms.TextBox
        Me.cbxAct1 = New System.Windows.Forms.ComboBox
        Me.cbxCon = New System.Windows.Forms.ComboBox
        Me.cbCheckLength = New System.Windows.Forms.CheckBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.clPage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clFieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clDisplayName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clDescription = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clMaxLength = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clCase = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clCharacter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clOtherCharacter = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clPulloutKey = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clValidCharPerIndex = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clHasLookup = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.clAutoNext = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 284)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Field / Page / Description:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDescription, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(219, 265)
        Me.TableLayoutPanel3.TabIndex = 35
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.tbDisplayName, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tbField, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tbPage, 1, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(219, 25)
        Me.TableLayoutPanel4.TabIndex = 36
        '
        'tbDisplayName
        '
        Me.tbDisplayName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbDisplayName.Location = New System.Drawing.Point(78, 3)
        Me.tbDisplayName.Name = "tbDisplayName"
        Me.tbDisplayName.Size = New System.Drawing.Size(69, 20)
        Me.tbDisplayName.TabIndex = 17
        '
        'tbField
        '
        Me.tbField.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbField.Location = New System.Drawing.Point(3, 3)
        Me.tbField.Name = "tbField"
        Me.tbField.Size = New System.Drawing.Size(69, 20)
        Me.tbField.TabIndex = 16
        '
        'tbPage
        '
        Me.tbPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPage.Location = New System.Drawing.Point(153, 3)
        Me.tbPage.Name = "tbPage"
        Me.tbPage.Size = New System.Drawing.Size(63, 20)
        Me.tbPage.TabIndex = 15
        Me.tbPage.Text = "1"
        '
        'txtDescription
        '
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(3, 28)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(213, 234)
        Me.txtDescription.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 293)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(225, 285)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Key Settings:"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.cbHasLookup, 0, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.cbAutoNext, 1, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.txtValidChar, 1, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label9, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.cbxCase, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtPOKey, 1, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.txtLength, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtOChar, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.cbxChar, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.btnSave, 1, 7)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 9
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(219, 266)
        Me.TableLayoutPanel5.TabIndex = 17
        '
        'cbHasLookup
        '
        Me.cbHasLookup.AutoSize = True
        Me.cbHasLookup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbHasLookup.Location = New System.Drawing.Point(3, 153)
        Me.cbHasLookup.Name = "cbHasLookup"
        Me.cbHasLookup.Size = New System.Drawing.Size(119, 19)
        Me.cbHasLookup.TabIndex = 18
        Me.cbHasLookup.Text = "Has LookUp"
        Me.cbHasLookup.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Case:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAutoNext
        '
        Me.cbAutoNext.AutoSize = True
        Me.cbAutoNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbAutoNext.Location = New System.Drawing.Point(128, 153)
        Me.cbAutoNext.Name = "cbAutoNext"
        Me.cbAutoNext.Size = New System.Drawing.Size(88, 19)
        Me.cbAutoNext.TabIndex = 5
        Me.cbAutoNext.Text = "Auto-Next"
        Me.cbAutoNext.UseVisualStyleBackColor = True
        '
        'txtValidChar
        '
        Me.txtValidChar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValidChar.Location = New System.Drawing.Point(128, 128)
        Me.txtValidChar.Name = "txtValidChar"
        Me.txtValidChar.Size = New System.Drawing.Size(88, 20)
        Me.txtValidChar.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Max length:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 25)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Valid Char Per Index:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxCase
        '
        Me.cbxCase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCase.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxCase.FormattingEnabled = True
        Me.cbxCase.Items.AddRange(New Object() {"0 Normal", "1 Upper", "2 Lower", "3 Proper"})
        Me.cbxCase.Location = New System.Drawing.Point(128, 3)
        Me.cbxCase.Name = "cbxCase"
        Me.cbxCase.Size = New System.Drawing.Size(88, 21)
        Me.cbxCase.TabIndex = 8
        '
        'txtPOKey
        '
        Me.txtPOKey.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPOKey.Location = New System.Drawing.Point(128, 103)
        Me.txtPOKey.Name = "txtPOKey"
        Me.txtPOKey.Size = New System.Drawing.Size(88, 20)
        Me.txtPOKey.TabIndex = 14
        '
        'txtLength
        '
        Me.txtLength.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLength.Location = New System.Drawing.Point(128, 28)
        Me.txtLength.Name = "txtLength"
        Me.txtLength.Size = New System.Drawing.Size(88, 20)
        Me.txtLength.TabIndex = 12
        '
        'txtOChar
        '
        Me.txtOChar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOChar.Location = New System.Drawing.Point(128, 78)
        Me.txtOChar.Name = "txtOChar"
        Me.txtOChar.Size = New System.Drawing.Size(88, 20)
        Me.txtOChar.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Character:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxChar
        '
        Me.cbxChar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cbxChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbxChar.FormattingEnabled = True
        Me.cbxChar.Items.AddRange(New Object() {"Alpha", "Numeric", "AlphaNumeric", "None"})
        Me.cbxChar.Location = New System.Drawing.Point(128, 53)
        Me.cbxChar.Name = "cbxChar"
        Me.cbxChar.Size = New System.Drawing.Size(88, 21)
        Me.cbxChar.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Oth. Char:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pullout Key:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(128, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtRegex)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.GroupBox8)
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.GroupBox9)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 458)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(339, 225)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Validation:"
        Me.GroupBox3.Visible = False
        '
        'txtRegex
        '
        Me.txtRegex.Location = New System.Drawing.Point(52, 17)
        Me.txtRegex.Name = "txtRegex"
        Me.txtRegex.Size = New System.Drawing.Size(281, 20)
        Me.txtRegex.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Regex:"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.cbCheckBlank)
        Me.GroupBox8.Controls.Add(Me.cbxAct2)
        Me.GroupBox8.Location = New System.Drawing.Point(246, 81)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(86, 43)
        Me.GroupBox8.TabIndex = 30
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Check Blank:"
        '
        'cbCheckBlank
        '
        Me.cbCheckBlank.AutoSize = True
        Me.cbCheckBlank.Location = New System.Drawing.Point(6, 20)
        Me.cbCheckBlank.Name = "cbCheckBlank"
        Me.cbCheckBlank.Size = New System.Drawing.Size(15, 14)
        Me.cbCheckBlank.TabIndex = 26
        Me.cbCheckBlank.UseVisualStyleBackColor = True
        '
        'cbxAct2
        '
        Me.cbxAct2.Enabled = False
        Me.cbxAct2.FormattingEnabled = True
        Me.cbxAct2.Items.AddRange(New Object() {"Required", "OTO", "Pullout"})
        Me.cbxAct2.Location = New System.Drawing.Point(24, 17)
        Me.cbxAct2.Name = "cbxAct2"
        Me.cbxAct2.Size = New System.Drawing.Size(55, 21)
        Me.cbxAct2.TabIndex = 33
        Me.cbxAct2.Text = "OTO"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cbxAct3)
        Me.GroupBox7.Controls.Add(Me.cbCheckDup)
        Me.GroupBox7.Location = New System.Drawing.Point(247, 37)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(85, 43)
        Me.GroupBox7.TabIndex = 31
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Check Dup:"
        '
        'cbxAct3
        '
        Me.cbxAct3.Enabled = False
        Me.cbxAct3.FormattingEnabled = True
        Me.cbxAct3.Items.AddRange(New Object() {"Required", "OTO", "Pullout"})
        Me.cbxAct3.Location = New System.Drawing.Point(23, 17)
        Me.cbxAct3.Name = "cbxAct3"
        Me.cbxAct3.Size = New System.Drawing.Size(56, 21)
        Me.cbxAct3.TabIndex = 36
        Me.cbxAct3.Text = "OTO"
        '
        'cbCheckDup
        '
        Me.cbCheckDup.AutoSize = True
        Me.cbCheckDup.Location = New System.Drawing.Point(6, 21)
        Me.cbCheckDup.Name = "cbCheckDup"
        Me.cbCheckDup.Size = New System.Drawing.Size(15, 14)
        Me.cbCheckDup.TabIndex = 26
        Me.cbCheckDup.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 37)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(240, 134)
        Me.GroupBox4.TabIndex = 32
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Check Date:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.cbxDDay2)
        Me.GroupBox6.Controls.Add(Me.cbxDYear2)
        Me.GroupBox6.Controls.Add(Me.cbxDMonth2)
        Me.GroupBox6.Controls.Add(Me.cbCheckDueDate)
        Me.GroupBox6.Controls.Add(Me.cbxAct5)
        Me.GroupBox6.Controls.Add(Me.cbxDDay)
        Me.GroupBox6.Controls.Add(Me.cbxDYear)
        Me.GroupBox6.Controls.Add(Me.cbxDMonth)
        Me.GroupBox6.Location = New System.Drawing.Point(119, 15)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(114, 112)
        Me.GroupBox6.TabIndex = 33
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Due Date:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(51, 86)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 15)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(51, 63)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 15)
        Me.Label14.TabIndex = 43
        Me.Label14.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(51, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 15)
        Me.Label15.TabIndex = 42
        Me.Label15.Text = "-"
        '
        'cbxDDay2
        '
        Me.cbxDDay2.Enabled = False
        Me.cbxDDay2.FormattingEnabled = True
        Me.cbxDDay2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cbxDDay2.Location = New System.Drawing.Point(68, 37)
        Me.cbxDDay2.Name = "cbxDDay2"
        Me.cbxDDay2.Size = New System.Drawing.Size(40, 21)
        Me.cbxDDay2.TabIndex = 38
        Me.cbxDDay2.Text = "dd"
        '
        'cbxDYear2
        '
        Me.cbxDYear2.Enabled = False
        Me.cbxDYear2.FormattingEnabled = True
        Me.cbxDYear2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cbxDYear2.Location = New System.Drawing.Point(65, 85)
        Me.cbxDYear2.Name = "cbxDYear2"
        Me.cbxDYear2.Size = New System.Drawing.Size(43, 21)
        Me.cbxDYear2.TabIndex = 37
        Me.cbxDYear2.Text = "yy"
        '
        'cbxDMonth2
        '
        Me.cbxDMonth2.Enabled = False
        Me.cbxDMonth2.FormattingEnabled = True
        Me.cbxDMonth2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbxDMonth2.Location = New System.Drawing.Point(67, 61)
        Me.cbxDMonth2.Name = "cbxDMonth2"
        Me.cbxDMonth2.Size = New System.Drawing.Size(41, 21)
        Me.cbxDMonth2.TabIndex = 36
        Me.cbxDMonth2.Text = "MM"
        '
        'cbCheckDueDate
        '
        Me.cbCheckDueDate.AutoSize = True
        Me.cbCheckDueDate.Location = New System.Drawing.Point(10, 16)
        Me.cbCheckDueDate.Name = "cbCheckDueDate"
        Me.cbCheckDueDate.Size = New System.Drawing.Size(15, 14)
        Me.cbCheckDueDate.TabIndex = 34
        Me.cbCheckDueDate.UseVisualStyleBackColor = True
        '
        'cbxAct5
        '
        Me.cbxAct5.Enabled = False
        Me.cbxAct5.FormattingEnabled = True
        Me.cbxAct5.Items.AddRange(New Object() {"Required", "OTO", "Pullout"})
        Me.cbxAct5.Location = New System.Drawing.Point(31, 13)
        Me.cbxAct5.Name = "cbxAct5"
        Me.cbxAct5.Size = New System.Drawing.Size(70, 21)
        Me.cbxAct5.TabIndex = 35
        Me.cbxAct5.Text = "OTO"
        '
        'cbxDDay
        '
        Me.cbxDDay.Enabled = False
        Me.cbxDDay.FormattingEnabled = True
        Me.cbxDDay.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cbxDDay.Location = New System.Drawing.Point(7, 37)
        Me.cbxDDay.Name = "cbxDDay"
        Me.cbxDDay.Size = New System.Drawing.Size(40, 21)
        Me.cbxDDay.TabIndex = 32
        Me.cbxDDay.Text = "0"
        '
        'cbxDYear
        '
        Me.cbxDYear.Enabled = False
        Me.cbxDYear.FormattingEnabled = True
        Me.cbxDYear.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cbxDYear.Location = New System.Drawing.Point(4, 85)
        Me.cbxDYear.Name = "cbxDYear"
        Me.cbxDYear.Size = New System.Drawing.Size(43, 21)
        Me.cbxDYear.TabIndex = 31
        Me.cbxDYear.Text = "0"
        '
        'cbxDMonth
        '
        Me.cbxDMonth.Enabled = False
        Me.cbxDMonth.FormattingEnabled = True
        Me.cbxDMonth.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbxDMonth.Location = New System.Drawing.Point(6, 61)
        Me.cbxDMonth.Name = "cbxDMonth"
        Me.cbxDMonth.Size = New System.Drawing.Size(41, 21)
        Me.cbxDMonth.TabIndex = 30
        Me.cbxDMonth.Text = "0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.cbxDay2)
        Me.GroupBox5.Controls.Add(Me.cbxYear2)
        Me.GroupBox5.Controls.Add(Me.cbxMonth2)
        Me.GroupBox5.Controls.Add(Me.cbCheckDate)
        Me.GroupBox5.Controls.Add(Me.cbxAct4)
        Me.GroupBox5.Controls.Add(Me.cbxDay)
        Me.GroupBox5.Controls.Add(Me.cbxYear)
        Me.GroupBox5.Controls.Add(Me.cbxMonth)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(109, 112)
        Me.GroupBox5.TabIndex = 29
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Date:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(48, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 15)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(48, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 15)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 15)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "-"
        '
        'cbxDay2
        '
        Me.cbxDay2.Enabled = False
        Me.cbxDay2.FormattingEnabled = True
        Me.cbxDay2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cbxDay2.Location = New System.Drawing.Point(64, 37)
        Me.cbxDay2.Name = "cbxDay2"
        Me.cbxDay2.Size = New System.Drawing.Size(40, 21)
        Me.cbxDay2.TabIndex = 39
        Me.cbxDay2.Text = "dd"
        '
        'cbxYear2
        '
        Me.cbxYear2.Enabled = False
        Me.cbxYear2.FormattingEnabled = True
        Me.cbxYear2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cbxYear2.Location = New System.Drawing.Point(63, 85)
        Me.cbxYear2.Name = "cbxYear2"
        Me.cbxYear2.Size = New System.Drawing.Size(41, 21)
        Me.cbxYear2.TabIndex = 38
        Me.cbxYear2.Text = "yy"
        '
        'cbxMonth2
        '
        Me.cbxMonth2.Enabled = False
        Me.cbxMonth2.FormattingEnabled = True
        Me.cbxMonth2.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbxMonth2.Location = New System.Drawing.Point(64, 61)
        Me.cbxMonth2.Name = "cbxMonth2"
        Me.cbxMonth2.Size = New System.Drawing.Size(40, 21)
        Me.cbxMonth2.TabIndex = 37
        Me.cbxMonth2.Text = "MM"
        '
        'cbCheckDate
        '
        Me.cbCheckDate.AutoSize = True
        Me.cbCheckDate.Location = New System.Drawing.Point(8, 17)
        Me.cbCheckDate.Name = "cbCheckDate"
        Me.cbCheckDate.Size = New System.Drawing.Size(15, 14)
        Me.cbCheckDate.TabIndex = 28
        Me.cbCheckDate.UseVisualStyleBackColor = True
        '
        'cbxAct4
        '
        Me.cbxAct4.Enabled = False
        Me.cbxAct4.FormattingEnabled = True
        Me.cbxAct4.Items.AddRange(New Object() {"Required", "OTO", "Pullout"})
        Me.cbxAct4.Location = New System.Drawing.Point(29, 13)
        Me.cbxAct4.Name = "cbxAct4"
        Me.cbxAct4.Size = New System.Drawing.Size(74, 21)
        Me.cbxAct4.TabIndex = 36
        Me.cbxAct4.Text = "OTO"
        '
        'cbxDay
        '
        Me.cbxDay.Enabled = False
        Me.cbxDay.FormattingEnabled = True
        Me.cbxDay.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"})
        Me.cbxDay.Location = New System.Drawing.Point(5, 37)
        Me.cbxDay.Name = "cbxDay"
        Me.cbxDay.Size = New System.Drawing.Size(40, 21)
        Me.cbxDay.TabIndex = 32
        Me.cbxDay.Text = "0"
        '
        'cbxYear
        '
        Me.cbxYear.Enabled = False
        Me.cbxYear.FormattingEnabled = True
        Me.cbxYear.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"})
        Me.cbxYear.Location = New System.Drawing.Point(4, 85)
        Me.cbxYear.Name = "cbxYear"
        Me.cbxYear.Size = New System.Drawing.Size(41, 21)
        Me.cbxYear.TabIndex = 31
        Me.cbxYear.Text = "0"
        '
        'cbxMonth
        '
        Me.cbxMonth.Enabled = False
        Me.cbxMonth.FormattingEnabled = True
        Me.cbxMonth.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cbxMonth.Location = New System.Drawing.Point(5, 61)
        Me.cbxMonth.Name = "cbxMonth"
        Me.cbxMonth.Size = New System.Drawing.Size(40, 21)
        Me.cbxMonth.TabIndex = 30
        Me.cbxMonth.Text = "0"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtLB)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.txtLA)
        Me.GroupBox9.Controls.Add(Me.cbxAct1)
        Me.GroupBox9.Controls.Add(Me.cbxCon)
        Me.GroupBox9.Controls.Add(Me.cbCheckLength)
        Me.GroupBox9.Location = New System.Drawing.Point(4, 170)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(240, 48)
        Me.GroupBox9.TabIndex = 29
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Check Length:"
        '
        'txtLB
        '
        Me.txtLB.Enabled = False
        Me.txtLB.Location = New System.Drawing.Point(126, 17)
        Me.txtLB.Name = "txtLB"
        Me.txtLB.Size = New System.Drawing.Size(37, 20)
        Me.txtLB.TabIndex = 46
        Me.txtLB.Text = "0"
        Me.txtLB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(112, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 15)
        Me.Label16.TabIndex = 45
        Me.Label16.Text = "-"
        '
        'txtLA
        '
        Me.txtLA.Enabled = False
        Me.txtLA.Location = New System.Drawing.Point(71, 17)
        Me.txtLA.Name = "txtLA"
        Me.txtLA.Size = New System.Drawing.Size(38, 20)
        Me.txtLA.TabIndex = 26
        Me.txtLA.Text = "0"
        Me.txtLA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbxAct1
        '
        Me.cbxAct1.Enabled = False
        Me.cbxAct1.FormattingEnabled = True
        Me.cbxAct1.Items.AddRange(New Object() {"Required", "OTO", "Pullout"})
        Me.cbxAct1.Location = New System.Drawing.Point(168, 17)
        Me.cbxAct1.Name = "cbxAct1"
        Me.cbxAct1.Size = New System.Drawing.Size(64, 21)
        Me.cbxAct1.TabIndex = 34
        Me.cbxAct1.Text = "OTO"
        '
        'cbxCon
        '
        Me.cbxCon.Enabled = False
        Me.cbxCon.FormattingEnabled = True
        Me.cbxCon.Items.AddRange(New Object() {"<", ">", "=<", "=>", "=", "<>", "Rng"})
        Me.cbxCon.Location = New System.Drawing.Point(23, 17)
        Me.cbxCon.Name = "cbxCon"
        Me.cbxCon.Size = New System.Drawing.Size(46, 21)
        Me.cbxCon.TabIndex = 27
        Me.cbxCon.Text = "Rng"
        '
        'cbCheckLength
        '
        Me.cbCheckLength.AutoSize = True
        Me.cbCheckLength.Location = New System.Drawing.Point(9, 20)
        Me.cbCheckLength.Name = "cbCheckLength"
        Me.cbCheckLength.Size = New System.Drawing.Size(15, 14)
        Me.cbCheckLength.TabIndex = 26
        Me.cbCheckLength.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clPage, Me.clFieldName, Me.clDisplayName, Me.clDescription, Me.clMaxLength, Me.clCase, Me.clCharacter, Me.clOtherCharacter, Me.clPulloutKey, Me.clValidCharPerIndex, Me.clHasLookup, Me.clAutoNext})
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(234, 3)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(769, 575)
        Me.dgv.TabIndex = 37
        '
        'clPage
        '
        Me.clPage.FillWeight = 86.37016!
        Me.clPage.HeaderText = "Page"
        Me.clPage.Name = "clPage"
        Me.clPage.ReadOnly = True
        Me.clPage.Width = 35
        '
        'clFieldName
        '
        Me.clFieldName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clFieldName.FillWeight = 86.37016!
        Me.clFieldName.HeaderText = "Field Name"
        Me.clFieldName.Name = "clFieldName"
        Me.clFieldName.ReadOnly = True
        '
        'clDisplayName
        '
        Me.clDisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clDisplayName.FillWeight = 86.37016!
        Me.clDisplayName.HeaderText = "Display Name"
        Me.clDisplayName.Name = "clDisplayName"
        Me.clDisplayName.ReadOnly = True
        '
        'clDescription
        '
        Me.clDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clDescription.FillWeight = 86.37016!
        Me.clDescription.HeaderText = "Description"
        Me.clDescription.Name = "clDescription"
        Me.clDescription.ReadOnly = True
        '
        'clMaxLength
        '
        Me.clMaxLength.FillWeight = 86.37016!
        Me.clMaxLength.HeaderText = "Max Length"
        Me.clMaxLength.Name = "clMaxLength"
        Me.clMaxLength.ReadOnly = True
        Me.clMaxLength.Width = 60
        '
        'clCase
        '
        Me.clCase.FillWeight = 86.37016!
        Me.clCase.HeaderText = "Case"
        Me.clCase.Name = "clCase"
        Me.clCase.ReadOnly = True
        Me.clCase.Width = 60
        '
        'clCharacter
        '
        Me.clCharacter.FillWeight = 86.37016!
        Me.clCharacter.HeaderText = "Character"
        Me.clCharacter.Name = "clCharacter"
        Me.clCharacter.ReadOnly = True
        Me.clCharacter.Width = 60
        '
        'clOtherCharacter
        '
        Me.clOtherCharacter.FillWeight = 86.37016!
        Me.clOtherCharacter.HeaderText = "Other Character"
        Me.clOtherCharacter.Name = "clOtherCharacter"
        Me.clOtherCharacter.ReadOnly = True
        Me.clOtherCharacter.Width = 60
        '
        'clPulloutKey
        '
        Me.clPulloutKey.FillWeight = 86.37016!
        Me.clPulloutKey.HeaderText = "Pullout Key"
        Me.clPulloutKey.Name = "clPulloutKey"
        Me.clPulloutKey.ReadOnly = True
        Me.clPulloutKey.Width = 60
        '
        'clValidCharPerIndex
        '
        Me.clValidCharPerIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clValidCharPerIndex.HeaderText = "Valid Character "
        Me.clValidCharPerIndex.Name = "clValidCharPerIndex"
        Me.clValidCharPerIndex.ReadOnly = True
        '
        'clHasLookup
        '
        Me.clHasLookup.FillWeight = 167.5127!
        Me.clHasLookup.HeaderText = "Has Lookup"
        Me.clHasLookup.Name = "clHasLookup"
        Me.clHasLookup.ReadOnly = True
        Me.clHasLookup.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clHasLookup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clHasLookup.Width = 45
        '
        'clAutoNext
        '
        Me.clAutoNext.FillWeight = 155.156!
        Me.clAutoNext.HeaderText = "Auto Next"
        Me.clAutoNext.Name = "clAutoNext"
        Me.clAutoNext.ReadOnly = True
        Me.clAutoNext.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clAutoNext.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clAutoNext.Width = 45
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgv, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1006, 581)
        Me.TableLayoutPanel1.TabIndex = 38
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(231, 581)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'fieldInfoEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 581)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "fieldInfoEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "fieldInfoEditor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAutoNext As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxCase As System.Windows.Forms.ComboBox
    Friend WithEvents txtPOKey As System.Windows.Forms.TextBox
    Friend WithEvents txtOChar As System.Windows.Forms.TextBox
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents cbxChar As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxAct2 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCheckDup As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCheckDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxDDay As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDMonth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxDay As System.Windows.Forms.ComboBox
    Friend WithEvents cbxYear As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMonth As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCheckBlank As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLA As System.Windows.Forms.TextBox
    Friend WithEvents cbxCon As System.Windows.Forms.ComboBox
    Friend WithEvents cbCheckLength As System.Windows.Forms.CheckBox
    Friend WithEvents cbxAct3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAct5 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAct4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAct1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtRegex As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbCheckDueDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbxDay2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxYear2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMonth2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbxDDay2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDYear2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDMonth2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtLB As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbPage As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbHasLookup As System.Windows.Forms.CheckBox
    Friend WithEvents tbField As System.Windows.Forms.TextBox
    Friend WithEvents txtValidChar As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents clPage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clFieldName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDisplayName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMaxLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCharacter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clOtherCharacter As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clPulloutKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clValidCharPerIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clHasLookup As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clAutoNext As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tbDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button

End Class
