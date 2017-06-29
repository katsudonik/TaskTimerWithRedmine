Module balloonTipModule
    Function BalloonTip(ByVal notify As NotifyIcon, ByVal taskName As TextBox, ByVal Label As Label)
        notify.Visible = True
        'バルーンヒントのタイトル
        notify.BalloonTipTitle = taskName.Text
        'バルーンヒントに表示するメッセージ
        notify.BalloonTipText = Label.Text
        'バルーンヒントに表示するアイコン
        notify.BalloonTipIcon = ToolTipIcon.Info
        'バルーンヒントを表示する
        '表示する時間をミリ秒で指定する
        notify.ShowBalloonTip(30000)
        BalloonTip = notify
    End Function
End Module
