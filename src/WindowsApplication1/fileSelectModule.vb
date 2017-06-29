Module fileSelectModule
    Function file_select()
        Dim ofd As New OpenFileDialog

        With ofd
            'タイトル
            .Title = "開くファイルを選択してください"
            '初期のファイル名
            .FileName = ""
            'フィルターの何番目を既定値にするか
            .FilterIndex = 1
            'フィルター：ファイルの種類
            .Filter = "画像ﾌｧｲﾙ名(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG"
            '初期のフォルダー
            .InitialDirectory = "C:\"
        End With

        '「ファイルを開く」ダイアログを表示。
        If ofd.ShowDialog() = DialogResult.OK Then
            '選択されたファイル名を表示
            '            TextBox1.Text = ofd.FileName
            file_select = ofd.FileName
        Else
            file_select = False
        End If
        ofd.Dispose()
    End Function
End Module
