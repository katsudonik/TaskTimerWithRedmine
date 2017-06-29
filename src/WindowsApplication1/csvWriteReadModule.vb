Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module csvWriteReadModule


    Function rabeling(ByVal taskName As TextBox, ByVal thisLabel As Label, ByVal hour As TextBox, ByVal startTimeLabel As Label, ByVal finishTimeLabel As Label, ByVal status As ComboBox)
        rabeling = taskName.Text + "," _
            + thisLabel.Text + "," _
            + hour.Text + "," _
            + startTimeLabel.Text + "," _
            + finishTimeLabel.Text + "," _
            + CStr(status.SelectedIndex)
    End Function

    'log_file書き込み
    Function save(ByVal tasksStr As Array, ByVal note As TextBox, ByVal img As System.Drawing.Bitmap)
        'Shift JISで書き込む
        '書き込むファイルが既に存在している場合は、上書きする
        Dim appPath As String = _
            System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim directoryName As String
        directoryName = Path.GetDirectoryName(appPath)
        Try
            Dim sw As New System.IO.StreamWriter(directoryName + "\time_log.csv", _
                False, _
                System.Text.Encoding.GetEncoding("shift_jis"))

            '列名書き込み
            sw.WriteLine("taskName,time,hour,startTime,finishTime,status,note")
            For Each thisTaskStr As String In tasksStr
                'thisTaskStrの内容を書き込む
                Dim noteStr As String = note.Text.Replace(Environment.NewLine, "<br>")
                sw.WriteLine(thisTaskStr + "," + noteStr)
            Next
            '閉じる
            sw.Close()
            save = True
        Catch ex As IOException
            MsgBox("csvを閉じてください。")
            save = False
        End Try
    End Function

    Function formInitialize(ByVal log_file As String, ByVal tasks As Object, ByVal note As TextBox, ByVal CheckBoxs As Array, ByVal TextBoxs As Array, ByVal Labels As Array, ByVal Buttons As Array, ByVal ComboBoxs As Array, ByVal Panel As Panel) As System.Drawing.Bitmap
        Dim parser As New TextFieldParser(log_file, _
            System.Text.Encoding.GetEncoding("Shift_JIS"))
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",") ' 区切り文字はコンマ

        Dim img As System.Drawing.Bitmap
        Dim Row = 0
        While Not parser.EndOfData
            Dim thisRowStr As String() = parser.ReadFields() ' 1行読み込み
            If Row > 0 Then
                img = formWrite(tasks(Row), thisRowStr, note, CheckBoxs, TextBoxs, Labels, Buttons, ComboBoxs, Panel)
                formInitialize = img
            End If
            Row = Row + 1
        End While
    End Function

    Function formWrite(ByVal taskDetails As Array, ByVal thisRowStr As Array, ByVal note As TextBox, ByVal CheckBoxs As Array, ByVal TextBoxs As Array, ByVal Labels As Array, ByVal Buttons As Array, ByVal ComboBoxs As Array, ByVal Panel As Panel) As System.Drawing.Bitmap
        
        'Dim taskName As TextBox
        'Dim hour As TextBox
        ''Dim finishTimeSpan As TimeSpan
        'Dim startTimeLabel As Label
        'Dim finishTimeLabel As Label
        'Dim status As ComboBox

        Dim taskName As TextBox = taskDetails(0)
        Dim thisLabel As Label = taskDetails(1)
        Dim hour As TextBox = taskDetails(2)
        Dim finishTimeSpan As TimeSpan = taskDetails(3)
        Dim startTimeLabel As Label = taskDetails(4)
        Dim finishTimeLabel As Label = taskDetails(5)
        Dim status As ComboBox = taskDetails(6)

        'Dim writeCollection As New Collection
        'writeCollection.Add(taskName)
        'writeCollection.Add(thisLabel)
        'writeCollection.Add(hour)
        'writeCollection.Add(startTimeLabel)
        'writeCollection.Add(finishTimeLabel)
        'writeCollection.Add(status)
        'Dim Cnt As Integer = 0
        'For Each element In writeCollection
        '    element = taskDetails(Cnt)
        '    If Cnt < 4 Then
        '        element.Text = thisRowStr(Cnt)
        '    End If
        '    Cnt = Cnt + 1
        'Next


        taskName.Text = thisRowStr(0)
        thisLabel.Text = thisRowStr(1)
        finishTimeSpan = TimeSpan.Parse(thisRowStr(1))
        hour.Text = thisRowStr(2)
        startTimeLabel.Text = thisRowStr(3)
        finishTimeLabel.Text = thisRowStr(4)
        status.SelectedIndex = thisRowStr(5)
        Dim noteStr As String = thisRowStr(6).Replace("<br>", Environment.NewLine)
        note.Text = noteStr


        Dim appPath As String = _
        System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim directoryName As String
        directoryName = Path.GetDirectoryName(appPath)
        Dim Location
        If Dir(directoryName + "\img_log.bmp") <> "" Then
            Location = directoryName + "\img_log.bmp"
            'MsgBox("画像あり")
        Else
            'MsgBox("画像なし")
            Location = Nothing
        End If

        '画像貼り付け
        Dim img As System.Drawing.Bitmap = ImagePaste(TextBoxs, Labels, Buttons, ComboBoxs, Location, Panel)
        formWrite = img
    End Function
    '画像貼り付け
    Function ImagePaste(ByVal TextBoxs As Array, ByVal Labels As Array, ByVal Buttons As Array, ByVal ComboBoxs As Array, ByVal Location As String, ByVal Panel As Panel) As System.Drawing.Bitmap
        For Each thisTextBox As TextBox In TextBoxs
            Panel.Controls.Add(thisTextBox)
        Next
        For Each thisLabel As Label In Labels
            Panel.Controls.Add(thisLabel)
        Next
        For Each thisButton As Button In Buttons
            Panel.Controls.Add(thisButton)
        Next
        For Each thisComboBox In ComboBoxs
            Panel.Controls.Add(thisComboBox)
        Next

        'Form1.Controls.Add(front_display)

        Dim img As System.Drawing.Bitmap
        If Location Is Nothing Then
            ImagePaste = Nothing
        Else
            Dim appPath As String = _
            System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim directoryName As String
            directoryName = Path.GetDirectoryName(appPath)
            img = CreateImage(Location)
            img.Save(directoryName + "\img_log.bmp")
            MainForm.BackgroundImage = img
            ImagePaste = img
        End If
    End Function

    ''' <summary>
    ''' 指定したファイルをロックせずに、System.Drawing.Imageを作成する。
    ''' </summary>
    ''' <param name="filename">作成元のファイルのパス</param>
    ''' <returns>作成したSystem.Drawing.Image。</returns>
    Function CreateImage(ByVal filename As String) _
            As System.Drawing.Image
        Dim fs As New System.IO.FileStream( _
            filename, _
            System.IO.FileMode.Open, _
            System.IO.FileAccess.Read)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(fs)
        Using imgSrc As Image = Image.FromStream(fs)
            img = New Bitmap(imgSrc)
        End Using

        fs.Close()
        Return img
    End Function

End Module
