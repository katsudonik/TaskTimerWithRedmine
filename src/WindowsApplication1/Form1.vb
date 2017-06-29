Public Class Form1

    ' タイマー起動フラグ
    Private fStart As Boolean = False
    '経過時間
    Private tsSa2 As TimeSpan
    ' タイマー時間
    Private ts1 As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
   
    ' スタートボタン　クリックイベント
    Private Sub bStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart.Click
        ' もし、タイマーが起動していなかったら
        If fStart = False Then
            ' タイマーを起動する
            Timer1.Start()
            ' フラグを立てる
            fStart = True
            ' スタートボタンを選択できないようにする
            bStart.Enabled = False
            ' ストップボタンを選択できるようにする
            bStop.Enabled = True
            reset.Enabled = False
        End If
    End Sub

    ' タイマーイベント
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If fStart = True Then
            Dim ts2 As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            tsSa2 = ts1.Subtract(ts2).Duration
            Label1.Text = tsSa2.ToString
        End If
    End Sub

    ' ストップボタン　クリックイベント
    Private Sub bStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop.Click
        If fStart Then
            ' タイマーが起動している場合は実行
            ' ラベルの文字を更新する
            Label1.Text = tsSa2.ToString
            ' タイマーを停止
            Timer1.Stop()
            ' フラグを消す
            fStart = False

            ' ボタンの選択可否を設定
            bStart.Enabled = True
            bStop.Enabled = False
            reset.Enabled = True
        End If
    End Sub
    Private Sub reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset.Click
        tsSa2 = TimeSpan.Parse("00:00:00")
        Label1.Text = tsSa2.ToString
        ts1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        reset.Enabled = False
    End Sub
End Class

Public Class Form2

    ' タイマー起動フラグ
    Private fStart As Boolean = False
    '経過時間
    Private tsSa2 As TimeSpan
    ' タイマー時間
    Private ts1 As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))

    ' スタートボタン　クリックイベント
    Private Sub bStart2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart.Click
        ' もし、タイマーが起動していなかったら
        If fStart = False Then
            ' タイマーを起動する
            Timer2.Start()
            ' フラグを立てる
            fStart = True
            ' スタートボタンを選択できないようにする
            bStart.Enabled = False
            ' ストップボタンを選択できるようにする
            bStop2.Enabled = True
            Reset2.Enabled = False
        End If
    End Sub

    ' タイマーイベント
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If fStart = True Then
            Dim ts2 As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            tsSa2 = ts1.Subtract(ts2).Duration
            Label2.Text = tsSa2.ToString
        End If
    End Sub

    ' ストップボタン　クリックイベント
    Private Sub bStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop.Click
        If fStart Then
            ' タイマーが起動している場合は実行
            ' ラベルの文字を更新する
            Label1.Text = tsSa2.ToString
            ' タイマーを停止
            Timer1.Stop()
            ' フラグを消す
            fStart = False

            ' ボタンの選択可否を設定
            bStart.Enabled = True
            bStop.Enabled = False
            reset.Enabled = True
        End If
    End Sub
    Private Sub reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset.Click
        tsSa2 = TimeSpan.Parse("00:00:00")
        Label1.Text = tsSa2.ToString
        ts1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        reset.Enabled = False
    End Sub

End Class
