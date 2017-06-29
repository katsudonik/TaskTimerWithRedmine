Module fontColorModule
    Function font_color(ByVal defaultColor As String, ByVal Labels As Array, ByVal Buttons As Array, ByVal outAreaButtons As Array, ByVal taskName1 As TextBox, ByVal checkBoxs As Array, ByVal comboBoxs As Array)
        'ColorDialogクラスのインスタンスを作成
        Dim cd As New ColorDialog()

        'はじめに選択されている色を設定
        'cd.Color = taskName1.BackColor

        'If defaultColor <> "" Then
        '    cd.Color = Color.defaultColor
        'Else
        cd.Color = Labels(1).foreColor()
        'End If

        '色の作成部分を表示可能にする
        'デフォルトがTrueのため必要はない
        cd.AllowFullOpen = True
        '純色だけに制限しない
        'デフォルトがFalseのため必要はない
        cd.SolidColorOnly = False
        '[作成した色]に指定した色（RGB値）を表示する
        cd.CustomColors = New Integer() {&H33, &H66, &H99, _
            &HCC, &H3300, &H3333, &H3366, &H3399, &H33CC, _
            &H6600, &H6633, &H6666, &H6699, &H66CC, _
            &H9900, &H9933}

        'ダイアログを表示する
        If cd.ShowDialog() = DialogResult.OK Then
            '選択された色の取得

            For Each thisLabel As Label In Labels
                thisLabel.ForeColor = cd.Color
            Next

            For Each thisButton As Button In Buttons
                thisButton.ForeColor = cd.Color
            Next
            For Each thisOutAreaButton As Button In outAreaButtons
                thisOutAreaButton.ForeColor = cd.Color
            Next

            For Each checkBox As CheckBox In checkBoxs
                checkBox.ForeColor = cd.Color
            Next
            For Each comboBox As ComboBox In comboBoxs
                comboBox.ForeColor = cd.Color
            Next
            font_color = cd.Color
        Else
        End If

    End Function
End Module
