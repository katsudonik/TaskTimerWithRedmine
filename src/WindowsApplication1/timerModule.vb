Module timerModule
    Function start_function(ByVal startButton As Button, ByVal stopButton As Button, ByVal resetButton As Button, ByVal Timer As Timer, ByVal startTime As TimeSpan, ByVal startTimeLabel As Label, ByVal taskName As TextBox, ByVal notify As NotifyIcon, ByVal Label As Label)
        'Labelを更新する
        If startTimeLabel.Text = "開始時刻" Then
            startTimeLabel.Text = startTime.ToString
        End If


        ' タイマーを起動する
        Timer.Start()
        ' スタートボタンを選択できないようにする
        startButton.Enabled = False
        startButton.Font = New Font(startButton.Font, FontStyle.Regular)
        ' ストップボタンを選択できるようにする
        stopButton.Enabled = True
        stopButton.Font = New Font(resetButton.Font, FontStyle.Bold)
        resetButton.Enabled = False
        resetButton.Font = New Font(resetButton.Font, FontStyle.Regular)
        taskName.ForeColor = Color.Red

        start_function = Nothing
        'Call BalloonTip(notify, taskName, Label)
    End Function
    Function timer_Function(ByVal Label As Label, ByVal finishTimeSpan As TimeSpan, ByVal startTime As TimeSpan, ByVal timeCount As TimeSpan, ByVal notify As NotifyIcon, ByVal taskName As TextBox)
        'スタートボタン押下時の時刻と現在の時刻の差分を取り、控えていた前回停止時のTimeSpanに足す
        Dim nowTime As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        timeCount = finishTimeSpan + startTime.Subtract(nowTime).Duration
        Label.Text = timeCount.ToString
        timer_Function = timeCount

        'Call BalloonTip(notify, taskName, Label)
    End Function
    Function stop_Function(ByVal startButton As Button, ByVal stopButton As Button, ByVal resetButton As Button, ByVal Label As Label, ByVal Timer As Timer, ByVal timeCount As TimeSpan, ByVal finishTimeLabel As Label, ByVal taskName As TextBox, ByVal notify As NotifyIcon)
        ' タイマーを停止
        Timer.Stop()
        ' ラベルの文字を更新する
        Label.Text = timeCount.ToString
        ' フラグを消す
        'fStart = False
        ' ボタンの選択可否を設定
        startButton.Enabled = True
        startButton.Font = New Font(startButton.Font, FontStyle.Bold)
        stopButton.Enabled = False
        stopButton.Font = New Font(stopButton.Font, FontStyle.Regular)
        resetButton.Enabled = True
        resetButton.Font = New Font(resetButton.Font, FontStyle.Bold)
        '終了時刻ラベルを更新する
        finishTimeLabel.Text = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss")).ToString

        taskName.ForeColor = Color.Black

        '停止時のTimeSpanを控える
        stop_Function = timeCount

        notify.Visible = False
    End Function
    Function reset_Function(ByVal resetButton As Button, ByVal stopButton As Button, ByVal Label As Label, ByVal finishTimeSpan As TimeSpan, ByVal timeCount As TimeSpan, ByVal startTimeLabel As Label, ByVal finishTimeLabel As Label)
        Label.Text = TimeSpan.Parse("00:00:00").ToString
        resetButton.Enabled = False
        resetButton.Font = New Font(resetButton.Font, FontStyle.Regular)
        stopButton.Enabled = False
        stopButton.Font = New Font(stopButton.Font, FontStyle.Regular)
        reset_Function = TimeSpan.Parse("00:00:00")

        'Labelをリセット
        startTimeLabel.Text = "開始時刻"
        finishTimeLabel.Text = "終了時刻"
    End Function

    Function startTimeLabel_change(ByVal startTimeLabel As Label, ByVal taskName As TextBox)
        Dim d As Dialog1 = New Dialog1(startTimeLabel.Text, taskName.Text)   'ダイアログに値を渡す
        'ダイアログでOKの場合、該当タスクの開始時刻を置き換える
        If d.ShowDialog() = DialogResult.OK Then
            '値を受け取る
            Call startTimeChange(startTimeLabel, d.GetValue)
        End If
        startTimeLabel_change = Nothing
    End Function

    Function startTimeChange(ByVal startTimeLabel As Label, ByVal changeTime As String)
        startTimeLabel.Text = changeTime
        startTimeChange = Nothing
    End Function
End Module
