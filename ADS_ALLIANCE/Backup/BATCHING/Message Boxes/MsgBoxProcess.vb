'1  - YES/OK
'0  - NO
'-1 - CANCEL

Module MsgBoxProcess
    Public prIMAGE As promptImage
    Public Enum promptImage
        prSTOP = 0
        prWARNING = 1
        prWAIT = 2
    End Enum

    Public btnType As buttonType
    Public Enum buttonType
        yesno = 0
        ok = 1
        okcancel = 2
        yesnocancel = 3
    End Enum

    ''  Private Function getIMG(ByVal imgtype As promptImage) As Bitmap
    '    Select Case imgtype
    '        Case promptImage.prSTOP
    '        Case promptImage.prWAIT
    '        Case promptImage.prWARNING
    ''   getimg = 
    '    End Select

    '    Return getIMG
    'End Function
    Public Function msg(ByVal text As String, ByVal caption As String, ByVal imageType As promptImage) As Windows.Forms.DialogResult


    End Function

    Public Function msg(ByVal text As String, ByVal caption As String, ByVal imageType As promptImage, ByVal ButtonFormat As buttonType) As Windows.Forms.DialogResult


    End Function
End Module
