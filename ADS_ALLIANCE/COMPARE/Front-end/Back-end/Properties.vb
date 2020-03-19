Imports System.Windows.Forms

Module Properties
#Region "Set Properties"
#Region "Control Variables"
#Region "Menu Item"
    Private mnOpen As ToolStripMenuItem
    Private mnSave As ToolStripMenuItem
    Private mnBrowse As ToolStripMenuItem
    Private mnExit As ToolStripMenuItem
    Private mnEntry As ToolStripMenuItem
    Private mnEdit As ToolStripMenuItem
    Private mnReCom As ToolStripMenuItem
    Private mnGoto As ToolStripMenuItem
#End Region
    
    Private dgv, dgvE1, dgvE2 As DataGridView
    Private lbCRec As Label
    Private lbTotalRec As Label
    Private txtValue As TextBox
    Private imgVwer As ImageViewer.ImageViewer
    Private lbViewForm As Label
    Private lblFieldName As Label
    Private lblImgL As Label
    Private lblImg As ToolStripStatusLabel
    Private lbMode As Label
    Private mainForm As Form
    Private lblUserIDl As Label
    Private lblLocIDl As Label
    Private lblUserID As ToolStripStatusLabel
    Private lblLocID As ToolStripStatusLabel
    Private lblMDB As ToolStripStatusLabel

#End Region
    Public Sub setProperty(ByVal form As String)
        Select Case form.ToUpper
            Case "VERIFYP"
                With VERIFYP
                    dgv = .dgv
                    dgvE1 = .dgvE1
                    dgvE2 = .dgvE2
                    lbCRec = .lbCRec
                    lbTotalRec = .lbTotalRec
                    txtValue = .txtValue
                    imgVwer = .imgVwer
                    lbViewForm = .lbViewForm
                    lblFieldName = .lblFieldName
                    lbMode = .lbMode
                    mainForm = VERIFYP
                    lblImg = .lblImg
                    lblUserID = .lblUserID
                    lblLocID = .lblLocID
                    lblMDB = .lblMdb

                    mnOpen = .mnOpen
                    mnBrowse = .mnBrowse
                    mnEntry = .mnCompare
                    mnEdit = .mnRecompare
                    mnSave = .mnSave
                    mnGoto = .mnGoto
                    mnExit = .mnExit
                End With
                'Case "QCP"
                '    With VERIFYP
                '        dgv = .dgv
                '        dgvE1 = .dgvE1
                '        dgvE2 = .dgvE2
                '        lbCRec = .lbCRec
                '        lbTotalRec = .lbTotalRec
                '        txtValue = .txtValue
                '        imgVwer = .imgVwer
                '        lbViewForm = .lbViewForm
                '        lblFieldName = .lblFieldName
                '        lbMode = .lbMode
                '        mainForm = VERIFYP
                '        lblImg = .lblImg
                '        lblUserID = .lblUserID
                '        lblLocID = .lblLocID
                '        lblMDB = .lblMdb

                '        mnOpen = .mnOpen
                '        mnBrowse = .mnBrowse
                '        mnEntry = .mnCompare
                '        mnEdit = .mnRecompare
                '        mnSave = .mnSave
                '        mnGoto = .mnGoto
                '    End With

        End Select
    End Sub
#End Region

#Region "Public Properties"
#Region "Form"
    Public Property AppName() As String
        Get
            Return mainForm.Text
        End Get
        Set(ByVal value As String)
            mainForm.Text = value
        End Set
    End Property

    Public Property MNFORM() As Form
        Get
            Return mainForm
        End Get
        Set(ByVal value As Form)
            mainForm = value
        End Set
    End Property
#End Region

#Region "Datagridview"
    Public Property CurrentRow() As Integer
        Get
            Try
                Return dgv.CurrentCell.RowIndex
            Catch ex As Exception
                Return -1
            End Try
        End Get
        Set(ByVal value As Integer)
            Try
                If value < dgv.Rows.Count Then dgv.CurrentCell = dgv.Item(0, value)
                Application.DoEvents()
            Catch ex As Exception
            End Try
        End Set
    End Property

    Public Property CurrentField() As String
        Get
            Return dgv.Rows(dgv.CurrentCell.RowIndex).Cells(0).Value
        End Get
        Set(ByVal value As String)
            dgv.Rows(dgv.CurrentCell.RowIndex).Cells(0).Value = value
        End Set
    End Property

    Public Property CurrentFieldValue() As String
        Get
            If dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1).Value IsNot Nothing Then
                Return dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1).Value
            Else : Return ""
            End If
        End Get
        Set(ByVal value As String)
            dgv.Rows(dgv.CurrentCell.RowIndex).Cells(1).Value = value
        End Set
    End Property


    Public Property PublicDGV() As DataGridView
        Get
            Return dgv
        End Get
        Set(ByVal value As DataGridView)
            dgv = value
        End Set
    End Property

    Public Property PublicDGVE1() As DataGridView
        Get
            Return dgvE1
        End Get
        Set(ByVal value As DataGridView)
            dgv = value
        End Set
    End Property

    Public Property PublicDGVE2() As DataGridView
        Get
            Return dgvE2
        End Get
        Set(ByVal value As DataGridView)
            dgv = value
        End Set
    End Property
#End Region

#Region "Text Box"
    Public Property EDATA() As String
        Get
            Return txtValue.Text
        End Get
        Set(ByVal value As String)
            txtValue.Text = value
        End Set
    End Property


    Public Property PublicTB() As ModifiedComponents.ModifiedTextbox
        Get
            Return txtValue
        End Get
        Set(ByVal value As ModifiedComponents.ModifiedTextbox)
            txtValue = value
        End Set
    End Property
#End Region

#Region "Date time"
    Public ReadOnly Property PresentDATETIME() As String
        Get
            Return Now.ToString("G")
        End Get
    End Property

    Public ReadOnly Property PresentDATE() As String
        Get
            Return Now.ToString("dd/MM/yyyy")
        End Get
    End Property
#End Region

#Region "Image Viewer"
    Public Property PublicImgVwer() As ImageViewer.ImageViewer
        Get
            Return imgVwer
        End Get
        Set(ByVal value As ImageViewer.ImageViewer)
            imgVwer = value
        End Set
    End Property
#End Region

#Region "Label"
    Public Property CURRENTRECORD() As Integer
        Get
            Return IIf(lbCRec.Text = "", 1, lbCRec.Text)
        End Get
        Set(ByVal value As Integer)
            lbCRec.Text = value
        End Set
    End Property

    Public Property TOTALRECORD() As Integer
        Get
            Return IIf(lbTotalRec.Text = "", 0, lbTotalRec.Text)
        End Get
        Set(ByVal value As Integer)
            lbTotalRec.Text = value
        End Set
    End Property

    Public Property VIEWFORM() As String
        Get
            Return lbViewForm.Text
        End Get
        Set(ByVal value As String)
            lbViewForm.Text = value
        End Set
    End Property

    Public Property FIELDNAME() As String
        Get
            Return lblFieldName.Text
        End Get
        Set(ByVal value As String)
            lblFieldName.Text = value
        End Set
    End Property

    Public Property MODETITLE() As String
        Get
            Return lbMode.Text
        End Get
        Set(ByVal value As String)
            lbMode.Text = value
        End Set
    End Property

    Public Property IMAGENAME() As String
        Get
            If Orientation = "L" Then
                Return lblImgL.Text
            Else
                Return lblImg.Text
            End If
          End Get
        Set(ByVal value As String)
            If Orientation = "L" Then
                lblImgL.Text = value
            Else
                lblImg.Text = value
            End If
         End Set
    End Property

    Public Property USERID() As String
        Get
            If Orientation = "L" Then
                Return lblUserIDl.Text
            Else
                Return lblUserID.Text
            End If
        End Get
        Set(ByVal value As String)
            If Orientation = "L" Then
                lblUserIDl.Text = value
            Else
                lblUserID.Text = value
            End If
        End Set
    End Property

    Public Property LOCID() As String
        Get
            If Orientation = "L" Then
                Return lblLocIDl.Text
            Else
                Return lblLocID.Text
            End If
           End Get
        Set(ByVal value As String)
            If Orientation = "L" Then
                lblLocIDl.Text = value
            Else
                lblLocID.Text = value
            End If
          End Set
    End Property

    Public Property MDBPATH() As String
        Get
            Return lblMDB.Text
        End Get
        Set(ByVal value As String)
            lblMDB.Text = value
        End Set
    End Property

#End Region

#Region "Menu Item"
    Public Property menuOpen() As ToolStripMenuItem
        Get
            Return mnOpen
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnOpen = value
        End Set
    End Property

    Public Property menuBrowse() As ToolStripMenuItem
        Get
            Return mnBrowse
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnBrowse = value
        End Set
    End Property

    Public Property menuEntry() As ToolStripMenuItem
        Get
            Return mnEntry
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnEntry = value
        End Set
    End Property

    Public Property menuEdit() As ToolStripMenuItem
        Get
            Return mnEdit
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnEdit = value
        End Set
    End Property

    'Public Property menuCompare() As ToolStripMenuItem
    '    Get
    '        Return mnCom
    '    End Get
    '    Set(ByVal value As ToolStripMenuItem)
    '        mnCom = value
    '    End Set
    'End Property

    Public Property menuRecompare() As ToolStripMenuItem
        Get
            Return mnReCom
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnReCom = value
        End Set
    End Property

    'Public Property menuQC() As ToolStripMenuItem
    '    Get
    '        Return mnQC
    '    End Get
    '    Set(ByVal value As ToolStripMenuItem)
    '        mnQC = value
    '    End Set
    'End Property

    Public Property menuSave() As ToolStripMenuItem
        Get
            Return mnSave
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnSave = value
        End Set
    End Property

    Public Property menuGoto() As ToolStripMenuItem
        Get
            Return mnGoto
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnGoto = value
        End Set
    End Property

    Public Property menuExit() As ToolStripMenuItem
        Get
            Return mnExit
        End Get
        Set(ByVal value As ToolStripMenuItem)
            mnExit = value
        End Set
    End Property
#End Region

#End Region
   
#Region "Properties for Verifying EXE"
  
#End Region

#Region "Special Property for EXE with Landscape Orientaion"
    Public Property USERIDL() As String
        Get
            Return lblUserID.Text
        End Get
        Set(ByVal value As String)
            lblUserID.Text = value
        End Set
    End Property

    Public Property LOCIDL() As String
        Get
            Return lblLocIDl.Text
        End Get
        Set(ByVal value As String)
            lblLocIDl.Text = value
        End Set
    End Property

    Public ReadOnly Property CurrentFieldValueE1() As String
        Get
            If Orientation = "P" Then
                Return PublicDGVE1.Rows(dgv.CurrentCell.RowIndex).Cells(1).Value
            Else
                Return dgv.Rows(dgv.CurrentCell.RowIndex).Cells(2).Value
            End If
        End Get
    End Property

    Public ReadOnly Property CurrentFieldValueE2() As String
        Get
            If Orientation = "P" Then
                Return PublicDGVE2.Rows(dgv.CurrentCell.RowIndex).Cells(1).Value
            Else
                Return dgv.Rows(dgv.CurrentCell.RowIndex).Cells(3).Value
            End If
        End Get
    End Property
#End Region

#Region "Information properties"
    Public Property CBCLIENT() As ComboBox
        Get
            Return Info.cbCLIENT
        End Get
        Set(ByVal value As ComboBox)
            Info.cbCLIENT = value
        End Set
    End Property

    Public Property CBJOB() As ComboBox
        Get
            Return Info.cbJOB
        End Get
        Set(ByVal value As ComboBox)
            Info.cbJOB = value
        End Set
    End Property

    Public Property CLIENT() As String
        Get
            Return Info.cbCLIENT.SelectedItem
        End Get
        Set(ByVal value As String)
            Info.cbCLIENT.Text = value
        End Set
    End Property

    Public Property JOB() As String
        Get
            Return Info.cbJOB.SelectedItem
        End Get
        Set(ByVal value As String)
            Info.cbJOB.Text = value
        End Set
    End Property


#End Region
End Module



#Region "RECYCLE BIN"
#Region "PROPERTY SETUP"
'/*******************PROPERTY SETUP*****************************************/
'Case "COML"
'    With VERIFYL
'        dgv = .dgv
'        lbCRec = .lbCRec
'        lbTotalRec = .lbTotalRec
'        txtValue = .txtValue
'        imgVwer = .imgVwer
'        lbViewForm = .lbViewForm
'        lblFieldName = .lblFieldName
'        lbMode = .lbMode
'        mainForm = VERIFYL
'        lblImgL = .lblImg
'        lblUserIDl = .lblUserID
'        lblLocIDl = .lblLocID
'        lblMDB = .lblMdb

'        mnOpen = .mnOpen
'        mnBrowse = .mnBrowse
'        mnEntry = .mnCompare
'        mnEdit = .mnRecompare
'        mnSave = .mnSave
'        mnGoto = .mnGoto
'    End With
'Case "QCL"
'    With QCL
'        dgv = .dgv
'        lbCRec = .lbCRec
'        lbTotalRec = .lbTotalRec
'        txtValue = .txtValue
'        imgVwer = .imgVwer
'        lbViewForm = .lbViewForm
'        lblFieldName = .lblFieldName
'        lbMode = .lbMode
'        mainForm = QCL
'        lblImgL = .lblImg
'        lblUserIDl = .lblUserID
'        lblLocIDl = .lblLocID
'        lblMDB = .lblMdb

'        mnOpen = .mnOpen
'        mnBrowse = .mnBrowse
'        mnEntry = .mnQC
'        mnEdit = .mnEdit
'        mnSave = .mnSave
'        mnGoto = .mnGoto
'    End With
'/*****************************************************************************************/
#End Region



#End Region