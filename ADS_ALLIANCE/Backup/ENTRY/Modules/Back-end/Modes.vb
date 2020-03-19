Module Modes
#Region "Mode"
    Public Class modeName
        Public Const ENTRY = "ENTRY MODE"
        Public Const EDIT = "EDIT MODE"
        Public Const BRO = "BROWSE MODE"
        Public Const COM = "COMPARE MODE"
        Public Const RECOM = "RECOMPARE MODE"
        Public Const QC = "QC MODE"
        Public Const REQC = "RE-QC MODE"
        Public Const KI = "KI MODE"
        Public Const VAL = "VALIDATION MODE"
        Public Const TICK = "TICK MODE"
    End Class
    Public Mode As mymode
    Public Enum mymode
        KI_Mode = 0
        Validation_Mode = 1
        Tick_Mode = 2
        Browse_Mode = 3
        Entry_Mode = 4
        Edit_Mode = 5
        Compare_Mode = 6
        Recompare_Mode = 7
        QC_Mode = 8
        REQC_Mode = 9
    End Enum

    Public Sub controls()
        Select Case Mode
            '=========KI MODE========'
            Case mymode.KI_Mode
                menuOpen.Enabled = False
                menuEntry.Enabled = False
                menuEdit.Enabled = False
                menuBrowse.Enabled = True
                menuGoto.Enabled = False
                menuSave.Enabled = False
                PublicDGV.Enabled = True
                PublicTB.Enabled = False

                '=====VALIDATION MODE===='
            Case mymode.Validation_Mode
                menuOpen.Enabled = False
                menuEntry.Enabled = False
                menuEdit.Enabled = False
                menuBrowse.Enabled = True
                menuGoto.Enabled = False
                menuSave.Enabled = False
                PublicDGV.Enabled = True
                PublicTB.Enabled = False

                '=======TICK MODE========'
            Case mymode.Tick_Mode
                menuOpen.Enabled = False
                menuEntry.Enabled = False
                menuEdit.Enabled = False
                menuBrowse.Enabled = True
                menuGoto.Enabled = False
                menuSave.Enabled = False
                PublicDGV.Enabled = True
                PublicTB.Enabled = False

                '=======BROWSE MODE======'
            Case mymode.Browse_Mode
                menuOpen.Enabled = True
                menuEntry.Enabled = True
                menuEdit.Enabled = True
                menuBrowse.Enabled = False
                menuGoto.Enabled = True
                menuSave.Enabled = False
                PublicDGV.Enabled = True
                PublicTB.Enabled = False

                '=======ENTRY MODE======='
            Case mymode.Entry_Mode
                menuOpen.Enabled = False
                menuEntry.Enabled = False
                menuEdit.Enabled = False
                menuBrowse.Enabled = True
                menuGoto.Enabled = False
                menuSave.Enabled = True
                PublicDGV.Enabled = False
                PublicTB.Enabled = True

                '========EDIT MODE======='
            Case mymode.Edit_Mode
                menuOpen.Enabled = False
                menuEntry.Enabled = False
                menuEdit.Enabled = False
                menuBrowse.Enabled = True
                menuGoto.Enabled = False
                menuSave.Enabled = True
                PublicDGV.Enabled = False
                PublicTB.Enabled = True

                '=======COMPARE MODE====='
            Case mymode.Compare_Mode
                menuOpen.Enabled = False
                menuCompare.Enabled = True
                menuRecompare.Enabled = False
                menuBrowse.Enabled = False
                menuGoto.Enabled = False
                PublicDGV.Enabled = False

                '======RECOMPARE MODE===='
            Case mymode.Recompare_Mode
                menuOpen.Enabled = False
                menuCompare.Enabled = False
                menuRecompare.Enabled = True
                menuBrowse.Enabled = False
                menuGoto.Enabled = False
                PublicDGV.Enabled = False
                PublicTB.Enabled = True

                '=========QC MODE========'
            Case mymode.QC_Mode
                menuOpen.Enabled = False
                menuQC.Enabled = True
                menuRecompare.Enabled = False
                menuBrowse.Enabled = False
                menuGoto.Enabled = False
                menuSave.Enabled = True
                PublicDGV.Enabled = False
                PublicTB.Enabled = True

                '=========RE QC MODE====='
            Case mymode.REQC_Mode
                menuOpen.Enabled = False
                menuQC.Enabled = False
                menuRecompare.Enabled = True
                menuBrowse.Enabled = False
                menuGoto.Enabled = False
                menuSave.Enabled = True
                PublicDGV.Enabled = False
                PublicTB.Enabled = True
        End Select
    End Sub

    Public Sub changemode()
        Select Case Mode
            Case mymode.KI_Mode
                controls()
                MODETITLE = modeName.KI
                get_group()
                load_FieldCoord(0)
            Case mymode.Validation_Mode
                controls()
                MODETITLE = modeName.VAL
                fieldInfoEditor.Show()
            Case mymode.Tick_Mode
                controls()
                MODETITLE = modeName.TICK
                load_tickFields()
                VIEWFORM = "1 - Show" & vbNewLine & "0 - Hide"
            Case mymode.Browse_Mode
                controls()
                MODETITLE = modeName.BRO
                PublicDGV.Focus()
                get_mdbRec(dt_Rec)
            Case mymode.Entry_Mode
                controls()
                MODETITLE = modeName.ENTRY
                PublicTB.Focus()
                load_FieldInfo()
            Case mymode.Edit_Mode
                controls()
                MODETITLE = modeName.EDIT
                PublicTB.Focus()
                load_FieldInfo()
            Case mymode.Compare_Mode
                controls()
                MODETITLE = modeName.COM
                RunComparison()
            Case mymode.Recompare_Mode
                controls()
                MODETITLE = modeName.RECOM
                RunComparison()
            Case mymode.QC_Mode
                controls()
                MODETITLE = modeName.QC
                RunComparison()
            Case mymode.REQC_Mode
                controls()
                MODETITLE = modeName.REQC
                RunComparison()
        End Select
    End Sub

    Public Sub set_mode(ByVal m As mymode)
        Mode = m
        changemode()

        If Mode = mymode.Browse_Mode Then
            If Twopages = True Then PublicDGV.Rows.Add("", "Second Page")
        ElseIf Mode = mymode.Edit_Mode Or Mode = mymode.Entry_Mode Then
            If Twopages = True Then
                If PublicDGV.Rows.Count > 0 Then
                    PublicDGV.Rows.RemoveAt(PublicDGV.Rows.Count - 1)
                End If
            End If
        End If
    End Sub


    Public Sub browseMode_Keydown(ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Left
                get_mdbRec(dt_Rec - 1)
            Case Keys.Right
                get_mdbRec(dt_Rec + 1)
        End Select
    End Sub

    Public Sub entryMode_Keydown(ByVal e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Up
                CurrentFieldValue = EDATA
                CurrentRow -= 1
        End Select
    End Sub

    Public Sub tickMode_Keydown(ByVal e As KeyEventArgs)
        Select Case Chr(e.KeyCode)
            Case "1", "0"
                CurrentFieldValue = CurrentFieldValue.Substring(0, fieldType) & Chr(e.KeyCode)
                CurrentRow = CurrentRow() + 1
        End Select
        If e.Control AndAlso e.KeyCode = Keys.S Then
            If MsgBox("Do you want to Edit??", MsgBoxStyle.YesNo, "Edit") = MsgBoxResult.Yes Then
                edit_Code()
            End If
        End If
    End Sub
#End Region

End Module
