Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.ComponentModel
Imports MySql.Data.MySqlClient
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class MainForm

    '##################################################################################################################################################

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName1.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan1 = TimeSpan.Parse(Label1.Text)
            'スタートボタン押下時の時刻を控える
            startTime1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))

            Call start_function(bStart1, bStop1, reset1, Timer1, startTime1, startTimeLabel1, taskName1, NotifyIcon1, Label1)
            'e.KeyChar(13) = "" 'キーをクリアする(必要であれば)
            Call textToLabel(taskName1, taskName1Label)
        End If

    End Sub
    '経過時間
    Private timeCount1 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime1 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Public finishTimeSpan1 As TimeSpan

    ' Private finishLabelTimeSpan1 As TimeSpan


    ' スタートボタン　クリックイベント
    Private Sub bStart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart1.Click
        finishTimeSpan1 = TimeSpan.Parse(Label1.Text)
        'スタートボタン押下時の時刻を控える
        startTime1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart1, bStop1, reset1, Timer1, startTime1, startTimeLabel1, taskName1, NotifyIcon1, Label1)
    End Sub
    ' タイマーイベント
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timeCount1 = timer_Function(Label1, finishTimeSpan1, startTime1, timeCount1, NotifyIcon1, taskName1)
    End Sub
    ' ストップボタン　クリックイベント
    Private Sub bStop1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop1.Click
        finishTimeSpan1 = stop_Function(bStart1, bStop1, reset1, Label1, Timer1, timeCount1, finishTimeLabel1, taskName1, NotifyIcon1)
    End Sub
    Private Sub reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset1.Click
        finishTimeSpan1 = reset_Function(reset1, bStop1, Label1, finishTimeSpan1, timeCount1, startTimeLabel1, finishTimeLabel1)
    End Sub
    Private Sub Label1_Changed() Handles Label1.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName1, Label1)
    End Sub
    Private Sub status1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status1.SelectedIndexChanged
        taskNameColorChange(status1, taskName1)
    End Sub

    Private Sub taskName1Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName1Label.Click
        Call labelToText(taskName1, taskName1Label)
    End Sub
    Private Sub startTimeLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel1.Click
        'startTimeLabel_change(startTimeLabel1, taskName1)
        Call labelToText(startTime1TextBox, startTimeLabel1)
    End Sub
    Private Sub startTime1TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime1TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime1TextBox, startTimeLabel1)
        End If
    End Sub
    Private Sub regist1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist1.Click
        registUsedTime(taskName1, hour1, "1", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName2.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan2 = TimeSpan.Parse(Label2.Text)
            'スタートボタン押下時の時刻を控える
            startTime2 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart2, bStop2, reset2, Timer2, startTime2, startTimeLabel2, taskName2, NotifyIcon1, Label2)
            Call textToLabel(taskName2, taskName2Label)
        End If
    End Sub
    '経過時間
    Public timeCount2 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime2 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan2 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart2.Click
        finishTimeSpan2 = TimeSpan.Parse(Label2.Text)
        'スタートボタン押下時の時刻を控える
        startTime2 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        If startTimeLabel2.Text = "開始時刻" Then
            startTimeLabel2.Text = startTime2.ToString
        End If
        Call start_function(bStart2, bStop2, reset2, Timer2, startTime2, startTimeLabel2, taskName2, NotifyIcon1, Label2)

    End Sub
    ' タイマーイベント
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        timeCount2 = timer_Function(Label2, finishTimeSpan2, startTime2, timeCount2, NotifyIcon1, taskName2)
    End Sub
    Private Sub bStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop2.Click
        finishTimeSpan2 = stop_Function(bStart2, bStop2, reset2, Label2, Timer2, timeCount2, finishTimeLabel2, taskName2, NotifyIcon1)
        finishTimeLabel2.Text = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss")).ToString
    End Sub
    Private Sub reset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset2.Click
        finishTimeSpan2 = reset_Function(reset2, bStop2, Label2, finishTimeSpan2, timeCount2, startTimeLabel2, finishTimeLabel2)
    End Sub
    Private Sub Label2_Changed() Handles Label2.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName2, Label2)
    End Sub
    Private Sub status2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status2.SelectedIndexChanged
        taskNameColorChange(status2, taskName2)
    End Sub
    Private Sub taskName2Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName2Label.Click
        Call labelToText(taskName2, taskName2Label)
    End Sub
    Private Sub startTimeLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel2.Click
        'startTimeLabel_change(startTimeLabel2, taskName2)
        Call labelToText(startTime2TextBox, startTimeLabel2)
    End Sub
    Private Sub startTime2TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime2TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime2TextBox, startTimeLabel2)
        End If
    End Sub
    Private Sub regist2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist2.Click
        registUsedTime(taskName2, hour2, "2", ticketData)
    End Sub

    '##################################################################################################################################################

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName3.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan3 = TimeSpan.Parse(Label3.Text)
            'スタートボタン押下時の時刻を控える
            startTime3 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart3, bStop3, reset3, Timer3, startTime3, startTimeLabel3, taskName3, NotifyIcon1, Label3)
            Call textToLabel(taskName3, taskName3Label)
        End If
    End Sub
    '経過時間
    Public timeCount3 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime3 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan3 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart3.Click
        finishTimeSpan3 = TimeSpan.Parse(Label3.Text)
        'スタートボタン押下時の時刻を控える
        startTime3 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart3, bStop3, reset3, Timer3, startTime3, startTimeLabel3, taskName3, NotifyIcon1, Label3)

    End Sub
    ' タイマーイベント
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        timeCount3 = timer_Function(Label3, finishTimeSpan3, startTime3, timeCount3, NotifyIcon1, taskName3)
    End Sub
    Private Sub bStop3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop3.Click
        finishTimeSpan3 = stop_Function(bStart3, bStop3, reset3, Label3, Timer3, timeCount3, finishTimeLabel3, taskName3, NotifyIcon1)
    End Sub
    Private Sub reset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset3.Click
        finishTimeSpan3 = reset_Function(reset3, bStop3, Label3, finishTimeSpan3, timeCount3, startTimeLabel3, finishTimeLabel3)
    End Sub
    Private Sub Label3_Changed() Handles Label3.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName3, Label3)
    End Sub
    Private Sub status3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status3.SelectedIndexChanged
        taskNameColorChange(status3, taskName3)
    End Sub
    Private Sub taskName3Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName3Label.Click
        Call labelToText(taskName3, taskName3Label)
    End Sub
    Private Sub startTimeLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel3.Click
        'startTimeLabel_change(startTimeLabel3, taskName3)
        Call labelToText(startTime3TextBox, startTimeLabel3)
    End Sub
    Private Sub startTime3TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime3TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime3TextBox, startTimeLabel3)
        End If
    End Sub
    Private Sub regist3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist3.Click
        registUsedTime(taskName3, hour3, "3", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName4.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan4 = TimeSpan.Parse(Label4.Text)
            'スタートボタン押下時の時刻を控える
            startTime4 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart4, bStop4, reset4, Timer4, startTime4, startTimeLabel4, taskName4, NotifyIcon1, Label4)
            Call textToLabel(taskName4, taskName4Label)
        End If
    End Sub
    '経過時間
    Public timeCount4 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime4 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan4 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart4.Click
        finishTimeSpan4 = TimeSpan.Parse(Label4.Text)
        'スタートボタン押下時の時刻を控える
        startTime4 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart4, bStop4, reset4, Timer4, startTime4, startTimeLabel4, taskName4, NotifyIcon1, Label4)
    End Sub
    ' タイマーイベント
    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        timeCount4 = timer_Function(Label4, finishTimeSpan4, startTime4, timeCount4, NotifyIcon1, taskName4)
    End Sub
    Private Sub bStop4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop4.Click
        finishTimeSpan4 = stop_Function(bStart4, bStop4, reset4, Label4, Timer4, timeCount4, finishTimeLabel4, taskName4, NotifyIcon1)
    End Sub
    Private Sub reset4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset4.Click
        finishTimeSpan4 = reset_Function(reset4, bStop4, Label4, finishTimeSpan4, timeCount4, startTimeLabel4, finishTimeLabel4)
    End Sub
    Private Sub Label4_Changed() Handles Label4.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName4, Label4)
    End Sub
    Private Sub status4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status4.SelectedIndexChanged
        taskNameColorChange(status4, taskName4)
    End Sub
    Private Sub taskName4Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName4Label.Click
        Call labelToText(taskName4, taskName4Label)
    End Sub
    Private Sub startTimeLabel4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel4.Click
        'startTimeLabel_change(startTimeLabel4, taskName4)
        Call labelToText(startTime4TextBox, startTimeLabel4)
    End Sub
    Private Sub startTime4TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime4TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime4TextBox, startTimeLabel4)
        End If
    End Sub
    Private Sub regist4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist4.Click
        registUsedTime(taskName4, hour4, "4", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName5.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan5 = TimeSpan.Parse(Label5.Text)
            'スタートボタン押下時の時刻を控える
            startTime5 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart5, bStop5, reset5, Timer5, startTime5, startTimeLabel5, taskName5, NotifyIcon1, Label5)
            Call textToLabel(taskName5, taskName5Label)
        End If
    End Sub
    '経過時間
    Public timeCount5 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime5 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan5 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart5.Click
        finishTimeSpan5 = TimeSpan.Parse(Label5.Text)
        'スタートボタン押下時の時刻を控える
        startTime5 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart5, bStop5, reset5, Timer5, startTime5, startTimeLabel5, taskName5, NotifyIcon1, Label5)
    End Sub
    ' タイマーイベント
    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        timeCount5 = timer_Function(Label5, finishTimeSpan5, startTime5, timeCount5, NotifyIcon1, taskName5)
    End Sub
    Private Sub bStop5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop5.Click
        finishTimeSpan5 = stop_Function(bStart5, bStop5, reset5, Label5, Timer5, timeCount5, finishTimeLabel5, taskName5, NotifyIcon1)
    End Sub
    Private Sub reset5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset5.Click
        finishTimeSpan5 = reset_Function(reset5, bStop5, Label5, finishTimeSpan5, timeCount5, startTimeLabel5, finishTimeLabel5)
    End Sub
    Private Sub Label5_Changed() Handles Label5.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName5, Label5)
    End Sub
    Private Sub status5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status5.SelectedIndexChanged
        taskNameColorChange(status5, taskName5)
    End Sub
    Private Sub taskName5Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName5Label.Click
        Call labelToText(taskName5, taskName5Label)
    End Sub
    Private Sub startTimeLabel5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel5.Click
        'startTimeLabel_change(startTimeLabel5, taskName5)
        Call labelToText(startTime5TextBox, startTimeLabel5)
    End Sub
    Private Sub startTime5TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime5TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime5TextBox, startTimeLabel5)
        End If
    End Sub
    Private Sub regist5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist5.Click
        registUsedTime(taskName5, hour5, "5", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName6.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan6 = TimeSpan.Parse(Label6.Text)
            'スタートボタン押下時の時刻を控える
            startTime6 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart6, bStop6, reset6, Timer6, startTime6, startTimeLabel6, taskName6, NotifyIcon1, Label6)
            Call textToLabel(taskName6, taskName6Label)
        End If
    End Sub
    '経過時間
    Public timeCount6 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime6 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan6 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart6.Click
        finishTimeSpan6 = TimeSpan.Parse(Label6.Text)
        'スタートボタン押下時の時刻を控える
        startTime6 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart6, bStop6, reset6, Timer6, startTime6, startTimeLabel6, taskName6, NotifyIcon1, Label6)
    End Sub
    ' タイマーイベント
    Private Sub Timer6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        timeCount6 = timer_Function(Label6, finishTimeSpan6, startTime6, timeCount6, NotifyIcon1, taskName6)
    End Sub
    Private Sub bStop6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop6.Click
        finishTimeSpan6 = stop_Function(bStart6, bStop6, reset6, Label6, Timer6, timeCount6, finishTimeLabel6, taskName6, NotifyIcon1)
    End Sub
    Private Sub reset6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset6.Click
        finishTimeSpan6 = reset_Function(reset6, bStop6, Label6, finishTimeSpan6, timeCount6, startTimeLabel6, finishTimeLabel6)
    End Sub
    Private Sub Label6_Changed() Handles Label6.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName6, Label6)
    End Sub
    Private Sub status6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status6.SelectedIndexChanged
        taskNameColorChange(status6, taskName6)
    End Sub
    Private Sub taskName6Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName6Label.Click
        Call labelToText(taskName6, taskName6Label)
    End Sub
    Private Sub startTimeLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel6.Click
        'startTimeLabel_change(startTimeLabel6, taskName6)
        Call labelToText(startTime6TextBox, startTimeLabel6)
    End Sub
    Private Sub startTime6TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime6TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime6TextBox, startTimeLabel6)
        End If
    End Sub
    Private Sub regist6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist6.Click
        registUsedTime(taskName6, hour6, "6", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName7.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan7 = TimeSpan.Parse(Label7.Text)
            'スタートボタン押下時の時刻を控える
            startTime7 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart7, bStop7, reset7, Timer7, startTime7, startTimeLabel7, taskName7, NotifyIcon1, Label7)
            Call textToLabel(taskName7, taskName7Label)
        End If
    End Sub
    '経過時間
    Public timeCount7 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime7 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan7 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart7.Click
        finishTimeSpan7 = TimeSpan.Parse(Label7.Text)
        'スタートボタン押下時の時刻を控える
        startTime7 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart7, bStop7, reset7, Timer7, startTime7, startTimeLabel7, taskName7, NotifyIcon1, Label7)
    End Sub
    ' タイマーイベント
    Private Sub Timer7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        timeCount7 = timer_Function(Label7, finishTimeSpan7, startTime7, timeCount7, NotifyIcon1, taskName7)
    End Sub
    Private Sub bStop7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop7.Click
        finishTimeSpan7 = stop_Function(bStart7, bStop7, reset7, Label7, Timer7, timeCount7, finishTimeLabel7, taskName7, NotifyIcon1)
    End Sub
    Private Sub reset7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset7.Click
        finishTimeSpan7 = reset_Function(reset7, bStop7, Label7, finishTimeSpan7, timeCount7, startTimeLabel7, finishTimeLabel7)
    End Sub
    Private Sub Label7_Changed() Handles Label7.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName7, Label7)
    End Sub
    Private Sub status7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status7.SelectedIndexChanged
        taskNameColorChange(status7, taskName7)
    End Sub
    Private Sub taskName7Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName7Label.Click
        Call labelToText(taskName7, taskName7Label)
    End Sub
    Private Sub startTimeLabel7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel7.Click
        'startTimeLabel_change(startTimeLabel7, taskName7)
        Call labelToText(startTime7TextBox, startTimeLabel7)
    End Sub
    Private Sub startTime7TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime7TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime7TextBox, startTimeLabel7)
        End If
    End Sub
    Private Sub regist7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist7.Click
        registUsedTime(taskName7, hour7, "7", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName8.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan8 = TimeSpan.Parse(Label8.Text)
            'スタートボタン押下時の時刻を控える
            startTime8 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart8, bStop8, reset8, Timer8, startTime8, startTimeLabel8, taskName8, NotifyIcon1, Label8)
            Call textToLabel(taskName8, taskName8Label)
        End If
    End Sub
    '経過時間
    Public timeCount8 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime8 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan8 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart8.Click
        finishTimeSpan8 = TimeSpan.Parse(Label8.Text)
        'スタートボタン押下時の時刻を控える
        startTime8 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart8, bStop8, reset8, Timer8, startTime8, startTimeLabel8, taskName8, NotifyIcon1, Label8)
    End Sub
    ' タイマーイベント
    Private Sub Timer8_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer8.Tick
        timeCount8 = timer_Function(Label8, finishTimeSpan8, startTime8, timeCount8, NotifyIcon1, taskName8)
    End Sub
    Private Sub bStop8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop8.Click
        finishTimeSpan8 = stop_Function(bStart8, bStop8, reset8, Label8, Timer8, timeCount8, finishTimeLabel8, taskName8, NotifyIcon1)
    End Sub
    Private Sub reset8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset8.Click
        finishTimeSpan8 = reset_Function(reset8, bStop8, Label8, finishTimeSpan8, timeCount8, startTimeLabel8, finishTimeLabel8)
    End Sub

    Private Sub Label8_Changed() Handles Label8.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName8, Label8)
    End Sub
    Private Sub taskName8Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName8Label.Click
        Call labelToText(taskName8, taskName8Label)
    End Sub
    Private Sub startTimeLabel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel8.Click
        'startTimeLabel_change(startTimeLabel8, taskName8)
        Call labelToText(startTime8TextBox, startTimeLabel8)
    End Sub
    Private Sub startTime8TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime8TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime8TextBox, startTimeLabel8)
        End If
    End Sub
    Private Sub regist8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist8.Click
        registUsedTime(taskName8, hour8, "8", ticketData)
    End Sub
    '##################################################################################################################################################

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles taskName9.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            finishTimeSpan9 = TimeSpan.Parse(Label9.Text)
            'スタートボタン押下時の時刻を控える
            startTime9 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            Call start_function(bStart9, bStop9, reset9, Timer9, startTime9, startTimeLabel9, taskName9, NotifyIcon1, Label9)
            Call textToLabel(taskName9, taskName9Label)
        End If
    End Sub
    Private Sub status8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status8.SelectedIndexChanged
        taskNameColorChange(status8, taskName8)
    End Sub
    '経過時間
    Public timeCount9 As TimeSpan
    'スタートボタン押下時の時刻
    Private startTime9 As TimeSpan
    '前回停止またはリセット時のTimeSpan
    Private finishTimeSpan9 As TimeSpan

    ' スタートボタン　クリックイベント
    Private Sub bStart9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStart9.Click
        finishTimeSpan9 = TimeSpan.Parse(Label9.Text)
        'スタートボタン押下時の時刻を控える
        startTime9 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Call start_function(bStart9, bStop9, reset9, Timer9, startTime9, startTimeLabel9, taskName9, NotifyIcon1, Label9)
    End Sub
    ' タイマーイベント
    Private Sub Timer9_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer9.Tick
        timeCount9 = timer_Function(Label9, finishTimeSpan9, startTime9, timeCount9, NotifyIcon1, taskName9)
    End Sub
    Private Sub bStop9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bStop9.Click
        finishTimeSpan9 = stop_Function(bStart9, bStop9, reset9, Label9, Timer9, timeCount9, finishTimeLabel9, taskName9, NotifyIcon1)
    End Sub
    Private Sub reset9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reset9.Click
        finishTimeSpan9 = reset_Function(reset9, bStop9, Label9, finishTimeSpan9, timeCount9, startTimeLabel9, finishTimeLabel9)
    End Sub
    Private Sub Label9_Changed() Handles Label9.TextChanged
        'Call BalloonTip(NotifyIcon1, taskName9, Label9)
    End Sub
    Private Sub status9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles status9.SelectedIndexChanged
        taskNameColorChange(status9, taskName9)
    End Sub
    Private Sub taskName9Label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName9Label.Click
        Call labelToText(taskName9, taskName9Label)
    End Sub
    Private Sub startTimeLabel9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startTimeLabel9.Click
        'startTimeLabel_change(startTimeLabel9, taskName9)
        Call labelToText(startTime9TextBox, startTimeLabel9)
    End Sub
    Private Sub startTime9TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles startTime9TextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            Call textToLabel(startTime9TextBox, startTimeLabel9)
        End If
    End Sub
    Private Sub regist9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles regist9.Click
        registUsedTime(taskName9, hour9, "9", ticketData)
    End Sub































































    Public img As System.Drawing.Bitmap
    Public Buttons() As System.Windows.Forms.Button
    Public outAreaButtons() As System.Windows.Forms.Button
    Public TextBoxs() As System.Windows.Forms.TextBox
    Public Labels() As Label
    Public ComboBoxs() As System.Windows.Forms.ComboBox
    Public checkBoxs() As CheckBox
    Public TimersCollection As New Collection
    '起動時イベント
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'デフォルト表示の初期設定（ラベルかテキストボックスか）
        Dim startTimeTextBox() As System.Windows.Forms.TextBox = {startTime1TextBox, startTime2TextBox, startTime3TextBox, startTime4TextBox, startTime5TextBox, startTime6TextBox, startTime7TextBox, startTime8TextBox, startTime9TextBox}
        For Each thisTextBox In startTimeTextBox
            thisTextBox.Text = "開始時刻"
        Next

        labelToText(taskName1, taskName1Label)
        labelToText(taskName2, taskName2Label)
        labelToText(taskName3, taskName3Label)
        labelToText(taskName4, taskName4Label)
        labelToText(taskName5, taskName5Label)
        labelToText(taskName6, taskName6Label)
        labelToText(taskName7, taskName7Label)
        labelToText(taskName8, taskName8Label)
        labelToText(taskName9, taskName9Label)
        labelToText(hour1, hour1Label)
        labelToText(hour2, hour2Label)
        labelToText(hour3, hour3Label)
        labelToText(hour4, hour4Label)
        labelToText(hour5, hour5Label)
        labelToText(hour6, hour6Label)
        labelToText(hour7, hour7Label)
        labelToText(hour8, hour8Label)
        labelToText(hour9, hour9Label)
        labelToText(note, noteLabel)
        textToLabel(startTime1TextBox, startTimeLabel1)
        textToLabel(startTime2TextBox, startTimeLabel2)
        textToLabel(startTime3TextBox, startTimeLabel3)
        textToLabel(startTime4TextBox, startTimeLabel4)
        textToLabel(startTime5TextBox, startTimeLabel5)
        textToLabel(startTime6TextBox, startTimeLabel6)
        textToLabel(startTime7TextBox, startTimeLabel7)
        textToLabel(startTime8TextBox, startTimeLabel8)
        textToLabel(startTime9TextBox, startTimeLabel9)




        'csvからデータ読み込み
        Dim tasks(9) As Object

        bStop1.Enabled = False
        tasks(1) = {taskName1, Label1, hour1, finishTimeSpan1, startTimeLabel1, finishTimeLabel1, status1}
        bStop2.Enabled = False
        tasks(2) = {taskName2, Label2, hour2, finishTimeSpan2, startTimeLabel2, finishTimeLabel2, status2}
        bStop3.Enabled = False
        tasks(3) = {taskName3, Label3, hour3, finishTimeSpan3, startTimeLabel3, finishTimeLabel3, status3}
        bStop4.Enabled = False
        tasks(4) = {taskName4, Label4, hour4, finishTimeSpan4, startTimeLabel4, finishTimeLabel4, status4}
        bStop5.Enabled = False
        tasks(5) = {taskName5, Label5, hour5, finishTimeSpan5, startTimeLabel5, finishTimeLabel5, status5}
        bStop6.Enabled = False
        tasks(6) = {taskName6, Label6, hour6, finishTimeSpan6, startTimeLabel6, finishTimeLabel6, status6}
        bStop7.Enabled = False
        tasks(7) = {taskName7, Label7, hour7, finishTimeSpan7, startTimeLabel7, finishTimeLabel7, status7}
        bStop8.Enabled = False
        tasks(8) = {taskName8, Label8, hour8, finishTimeSpan8, startTimeLabel8, finishTimeLabel8, status8}
        bStop9.Enabled = False
        tasks(9) = {taskName9, Label9, hour9, finishTimeSpan9, startTimeLabel9, finishTimeLabel9, status9}

        TextBoxs = {taskName1, taskName2, taskName3, taskName4, taskName5, taskName6, taskName7, taskName8, taskName9, hour1, hour2, hour3, hour4, hour5, hour6, hour7, hour8, hour9}
        'Labels = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, startTimeLabel1, startTimeLabel2, startTimeLabel3, startTimeLabel4, startTimeLabel5, startTimeLabel6, startTimeLabel7, startTimeLabel8, startTimeLabel9, nyoryo1, nyoryo2, nyoryo3, nyoryo4, nyoryo5, nyoryo6, nyoryo7, nyoryo8, nyoryo9, finishTimeLabel1, finishTimeLabel2, finishTimeLabel3, finishTimeLabel4, finishTimeLabel5, finishTimeLabel6, finishTimeLabel7, finishTimeLabel8, finishTimeLabel9, h1, h2, h3, h4, h5, h6, h7, h8, h9, ticketNameLabel1, ticketNameLabel2, ticketNameLabel3, ticketNameLabel4, ticketNameLabel5, ticketNameLabel6, ticketNameLabel7, ticketNameLabel8, ticketNameLabel9}

        Buttons = {bStart1, bStart2, bStart3, bStart4, bStart5, bStart6, bStart7, bStart8, bStart9, bStop1, bStop2, bStop3, bStop4, bStop5, bStop6, bStop7, bStop8, bStop9, reset1, reset2, reset3, reset4, reset5, reset6, reset7, reset8, reset9, ticketFind1, ticketFind2, ticketFind3, ticketFind4, ticketFind5, ticketFind6, ticketFind7, ticketFind8, ticketFind9, regist1, regist2, regist3, regist4, regist5, regist6, regist7, regist8, regist9}
        ComboBoxs = {status1, status2, status3, status4, status5, status6, status7, status8, status9}
        checkBoxs = {front_display, inputMode}
        outAreaButtons = {setting, allTaskReset, bSave, tasklog}
        ColorChangeLabels = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, startTimeLabel1, startTimeLabel2, startTimeLabel3, startTimeLabel4, startTimeLabel5, startTimeLabel6, startTimeLabel7, startTimeLabel8, startTimeLabel9, nyoryo1, nyoryo2, nyoryo3, nyoryo4, nyoryo5, nyoryo6, nyoryo7, nyoryo8, nyoryo9, finishTimeLabel1, finishTimeLabel2, finishTimeLabel3, finishTimeLabel4, finishTimeLabel5, finishTimeLabel6, finishTimeLabel7, finishTimeLabel8, finishTimeLabel9, h1, h2, h3, h4, h5, h6, h7, h8, h9, taskName1Label, taskName2Label, taskName3Label, taskName4Label, taskName5Label, taskName6Label, taskName7Label, taskName8Label, taskName9Label, hour1Label, hour2Label, hour3Label, hour4Label, hour5Label, hour6Label, hour7Label, hour8Label, hour9Label, noteLabel, ticketNameLabel1, ticketNameLabel2, ticketNameLabel3, ticketNameLabel4, ticketNameLabel5, ticketNameLabel6, ticketNameLabel7, ticketNameLabel8, ticketNameLabel9}

        Dim Label As Label() = New Label() {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9}
        Dim startTimeLabels As Label() = New Label() {startTimeLabel1, startTimeLabel2, startTimeLabel3, startTimeLabel4, startTimeLabel5, startTimeLabel6, startTimeLabel7, startTimeLabel8, startTimeLabel9}
        Dim nyoryoLabels As Label() = New Label() {nyoryo1, nyoryo2, nyoryo3, nyoryo4, nyoryo5, nyoryo6, nyoryo7, nyoryo8, nyoryo9}
        Dim finishTimeLabels As Label() = New Label() {finishTimeLabel1, finishTimeLabel2, finishTimeLabel3, finishTimeLabel4, finishTimeLabel5, finishTimeLabel6, finishTimeLabel7, finishTimeLabel8, finishTimeLabel9}
        Dim hLabels As Label() = New Label() {h1, h2, h3, h4, h5, h6, h7, h8, h9}
        Dim ticketNameLabels As Label() = New Label() {ticketNameLabel1, ticketNameLabel2, ticketNameLabel3, ticketNameLabel4, ticketNameLabel5, ticketNameLabel6, ticketNameLabel7, ticketNameLabel8, ticketNameLabel9}
        Dim statusLabels As Label() = New Label() {statusLabel1, statusLabel2, statusLabel3, statusLabel4, statusLabel5, statusLabel6, statusLabel7, statusLabel8, statusLabel9}

        Dim LabelsCollection As New Collection
        LabelsCollection.Add(Label)
        LabelsCollection.Add(startTimeLabels)
        LabelsCollection.Add(nyoryoLabels)
        LabelsCollection.Add(finishTimeLabels)
        LabelsCollection.Add(hLabels)
        LabelsCollection.Add(ticketNameLabels)
        LabelsCollection.Add(statusLabels)
        Labels = arrayMergeCustom(LabelsCollection)

        Dim appPath As String = _
        System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim directoryName As String
        directoryName = Path.GetDirectoryName(appPath)
        Dim log_file As String = directoryName + "\time_log.csv"
        If System.IO.File.Exists(log_file) Then
            img = formInitialize(log_file, tasks, note, checkBoxs, TextBoxs, Labels, Buttons, ComboBoxs, Panel1)
        Else
            For Each thisComboBox In ComboBoxs
                thisComboBox.SelectedIndex = 0
            Next
        End If

        Panel2.Controls.Add(noteLabel)


        Me.Timer9 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer9.Site.Name = "Timer9"
        TimersCollection.Add(Timer9, "Timer9")



        tabIndexChange(TextBoxs)
        tabIndexChange(Buttons)
        tabIndexChange(ComboBoxs)

        'WebBrowser1.Visible = False
        'WebBrowserDisPlay = False

        'redmineに登録されているチケットをリストボックスに全件表示
        'Dim ticketComboBoxes() As ComboBox = {ticketComboBox1, ticketComboBox2, ticketComboBox3, ticketComboBox4, ticketComboBox5, ticketComboBox6, ticketComboBox7, ticketComboBox8, ticketComboBox9}
        'Call getTicketList(ticketComboBoxes, databaseInformation)

        'Dim I As Integer
        'For I = 0 To Buttons.Length - 1
        '    '3-1)イベントハンドラの登録
        '    AddHandler Buttons(I).Click, AddressOf ButtonClick
        'Next

        databaseInformation = getDatabaseInformation()
    End Sub
    Function arrayMergeCustom(ByVal arrayCollection As Collection)
        Dim newArraysLength As Integer
        Dim Cnt As Integer = 1
        For Each thisArray In arrayCollection
            newArraysLength = newArraysLength + thisArray.length
            Cnt = Cnt + 1
        Next
        Dim newArray As Array = New Label(newArraysLength - 1) {}
        Cnt = 1
        Dim nowArrayLength = 0
        For Each thisArray In arrayCollection
            thisArray.CopyTo(newArray, nowArrayLength)
            nowArrayLength = nowArrayLength + thisArray.length
            Cnt = Cnt + 1
        Next
        arrayMergeCustom = newArray
    End Function

    'startボタンのリファクタリング
    Public startSet As New Collection
    Private Sub ButtonClick(ByVal sender As Object, ByVal e As System.EventArgs)
        If CType(sender, System.Windows.Forms.Button).Text = "start" Then
            Dim targetbStart As Button = CType(sender, System.Windows.Forms.Button)
            Dim targetbStop As Button = findControllCustom("bStop", targetbStart.Name, Me)
            Dim targetbReset As Button = findControllCustom("reset", targetbStart.Name, Me)
            Dim number As Integer = getControllsNumber(targetbStart.Name)
            Dim targetTimer As Timer = TimersCollection("Timer" + CStr("9"))



            'Dim HogeStr As String = "bStop126"                '対象となる文字列  
            'HogeStr = System.Text.RegularExpressions.Regex.Replace(HogeStr, "^.*[^0-9]+", "")
            'MsgBox(HogeStr)

            'finishTimeSpan1 = TimeSpan.Parse(Label1.Text)
            ''スタートボタン押下時の時刻を控える
            'startTime1 = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            'Call start_function(bStart1, bStop1, reset1, Timer1, startTime1, startTimeLabel1, taskName1, NotifyIcon1, Label1)


        End If
    End Sub

    Function getControllsNumber(ByVal targetStr As String)
        getControllsNumber = System.Text.RegularExpressions.Regex.Replace(targetStr, "^.*[^0-9]+", "")
    End Function
    Function findControllCustom(ByVal findControllName As String, ByVal triggerButtonsName As String, ByVal targetForm As Form)
        Dim number As Integer = getControllsNumber(triggerButtonsName)
        If targetForm.Controls.Find(findControllName + CStr(number), True).Length <> 0 Then
            findControllCustom = targetForm.Controls.Find(findControllName + CStr(number), True)(0)
        End If
    End Function

    Friend WithEvents Timer9 As System.Windows.Forms.Timer

    Private Sub Form1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Dim Location As String
        Location = file_select()
        If Location <> "" Then
            img = ImagePaste(TextBoxs, Labels, Buttons, ComboBoxs, Location, Panel1)
        End If
    End Sub

    Private Sub allTaskReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles allTaskReset.Click
        Call stop_Function(bStart1, bStop1, reset1, Label1, Timer1, timeCount1, finishTimeLabel1, taskName1, NotifyIcon1)
        finishTimeSpan1 = reset_Function(reset1, bStop1, Label1, finishTimeSpan1, timeCount1, startTimeLabel1, finishTimeLabel1)
        Call stop_Function(bStart2, bStop2, reset2, Label2, Timer2, timeCount2, finishTimeLabel2, taskName2, NotifyIcon1)
        finishTimeSpan2 = reset_Function(reset2, bStop2, Label2, finishTimeSpan2, timeCount2, startTimeLabel2, finishTimeLabel2)
        Call stop_Function(bStart3, bStop3, reset3, Label3, Timer3, timeCount3, finishTimeLabel3, taskName3, NotifyIcon1)
        finishTimeSpan3 = reset_Function(reset3, bStop3, Label3, finishTimeSpan3, timeCount3, startTimeLabel3, finishTimeLabel3)
        Call stop_Function(bStart4, bStop4, reset4, Label4, Timer4, timeCount4, finishTimeLabel4, taskName4, NotifyIcon1)
        finishTimeSpan4 = reset_Function(reset4, bStop4, Label4, finishTimeSpan4, timeCount4, startTimeLabel4, finishTimeLabel4)
        Call stop_Function(bStart5, bStop5, reset5, Label5, Timer5, timeCount5, finishTimeLabel5, taskName5, NotifyIcon1)
        finishTimeSpan5 = reset_Function(reset5, bStop5, Label5, finishTimeSpan5, timeCount5, startTimeLabel5, finishTimeLabel5)
        Call stop_Function(bStart6, bStop6, reset6, Label6, Timer6, timeCount6, finishTimeLabel6, taskName6, NotifyIcon1)
        finishTimeSpan6 = reset_Function(reset6, bStop6, Label6, finishTimeSpan6, timeCount6, startTimeLabel6, finishTimeLabel6)
        Call stop_Function(bStart7, bStop7, reset7, Label7, Timer7, timeCount7, finishTimeLabel7, taskName7, NotifyIcon1)
        finishTimeSpan7 = reset_Function(reset7, bStop7, Label7, finishTimeSpan7, timeCount7, startTimeLabel7, finishTimeLabel7)
        Call stop_Function(bStart8, bStop8, reset8, Label8, Timer8, timeCount8, finishTimeLabel8, taskName8, NotifyIcon1)
        finishTimeSpan8 = reset_Function(reset8, bStop8, Label8, finishTimeSpan8, timeCount8, startTimeLabel8, finishTimeLabel8)
        Call stop_Function(bStart9, bStop9, reset9, Label9, Timer9, timeCount9, finishTimeLabel9, taskName9, NotifyIcon1)
        finishTimeSpan9 = reset_Function(reset9, bStop9, Label9, finishTimeSpan9, timeCount9, startTimeLabel9, finishTimeLabel9)
        For Each thisTextBox In TextBoxs
            thisTextBox.Text = ""
        Next
        Dim Labels() As Label = {taskName1Label, taskName2Label, taskName3Label, taskName4Label, taskName5Label, taskName6Label, taskName7Label, taskName8Label, taskName9Label, hour1Label, hour2Label, hour3Label, hour4Label, hour5Label, hour6Label, hour7Label, hour8Label, hour9Label}
        For Each thisLabel In Labels
            thisLabel.Text = ""
        Next
        Dim ComboBoxs() As System.Windows.Forms.ComboBox = {status1, status2, status3, status4, status5, status6, status7, status8, status9}
        For Each thisComboBox In ComboBoxs
            thisComboBox.SelectedItem = "未着手"
        Next
    End Sub



    'フォームのFormClosingイベントハンドラ
    Private Sub Form1_FormClosing(ByVal sender As System.Object, _
            ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles MyBase.FormClosing

        Dim tasksStr() As String = { _
            rabeling(taskName1, Label1, hour1, startTimeLabel1, finishTimeLabel1, status1), _
            rabeling(taskName2, Label2, hour2, startTimeLabel2, finishTimeLabel2, status2), _
            rabeling(taskName3, Label3, hour3, startTimeLabel3, finishTimeLabel3, status3), _
            rabeling(taskName4, Label4, hour4, startTimeLabel4, finishTimeLabel4, status4), _
            rabeling(taskName5, Label5, hour5, startTimeLabel5, finishTimeLabel5, status5), _
            rabeling(taskName6, Label6, hour6, startTimeLabel6, finishTimeLabel6, status6), _
            rabeling(taskName7, Label7, hour7, startTimeLabel7, finishTimeLabel7, status7), _
            rabeling(taskName8, Label8, hour8, startTimeLabel8, finishTimeLabel8, status8), _
            rabeling(taskName9, Label9, hour9, startTimeLabel9, finishTimeLabel9, status9) _
        }

        Dim reason As String
        Select Case e.CloseReason
            Case CloseReason.ApplicationExitCall
                reason = "Application.Exitにより終了"
            Case CloseReason.FormOwnerClosing
                reason = "所有側のフォームが閉じられようとしている"
            Case CloseReason.MdiFormClosing
                reason = "MDIの親フォームが閉じられようとしている"
            Case CloseReason.TaskManagerClosing
                reason = "タスクマネージャにより終了"
            Case CloseReason.UserClosing
                reason = "ユーザーインターフェイスにより終了"
            Case CloseReason.WindowsShutDown
                reason = "OSのシャットダウンにより終了"
            Case CloseReason.None
                reason = "未知の理由により終了"
            Case Else
                reason = "それ以外により終了"
        End Select

        If MessageBox.Show("[" + reason + "]" & vbCrLf & "閉じますか?", "確認", MessageBoxButtons.YesNo) = DialogResult.No Then
            e.Cancel = True
        Else
            If save(tasksStr, note, img) = False Then
                e.Cancel = True
            End If
            Call saveDatabaseInformation(databaseInformation)
        End If
    End Sub



    Private Sub note_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles note.DoubleClick
        Me.note.SelectAll()
    End Sub
    Private Sub note_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles note.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Control Then
            DirectCast(sender, System.Windows.Forms.TextBox).SelectAll()
        End If
    End Sub

    Private Sub front_display_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles front_display.CheckedChanged
        If front_display.Checked = True Then
            ' このフォームを常に最前面に表示する
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub

    'Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
    '    ' 基底の背景を描画する必要があるときはこれを呼ぶ
    '    MyBase.OnPaintBackground(pevent)
    '    ' あとは pevent.Graphics を使用して好きなように背景を描画
    'End Sub


    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        'TODO 起動しているタイマーの時間をバルーンチップで表示
        'Call BalloonTip(NotifyIcon1, taskName1, Label1)
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.Activate()
        Me.TopMost = False
    End Sub











    Public LocationHeight = 210

    Private Sub taskAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LocationHeight = LocationHeight + 30

        Dim taskName As System.Windows.Forms.TextBox = New System.Windows.Forms.TextBox()
        taskName.Name = "taskName10"
        Dim btn1 As System.Windows.Forms.Button = New System.Windows.Forms.Button()
        '// イベントハンドラを登録
        AddHandler btn1.Click, AddressOf btn_Click
        btn1.Margin = New Padding(0, 0, 0, 0)
        btn1.Size = New Size(57, 26)
        btn1.Name = "bStart10"
        btn1.Text = "start"
        btn1.Font = New Font("HGS行書体", 9)

        Dim taskControls As Object = {taskName, btn1}
        For Each thisControl As Object In taskControls
            'Panel1.Controls.Add(thisControl)
            If thisControl.Name = "bStart10" Then
                thisControl.Location = New Point(323, LocationHeight)

            ElseIf thisControl.Name = "taskName10" Then
                thisControl.Location = New Point(15, LocationHeight)
            End If

            Panel1.Controls.Add(thisControl)
        Next
    End Sub

    '// 動的ボタンのイベントハンドラ

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '// 押されたボタンはsenderに渡されてきます

        Dim btn As System.Windows.Forms.Button = CType(sender, System.Windows.Forms.Button)

        MsgBox(btn.Name & "が押されました")

        '正規表現でnumberを引き出す

        If btn.Text = "start" Then
            Dim num As String = "9"
            finishTimeSpan2 = TimeSpan.Parse(FindControl(Panel1, "Label" & num).Text)

            ''スタートボタン押下時の時刻を控える
            Dim startTimes As New Collection
            Dim startTime As TimeSpan
            startTime = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
            startTimes.Add(startTime, num)

            Dim timers As New Collection
            Dim timer As Timer
            timer = FindControlFromForm(Me, "Timer" & num)

            Dim startTimeLabel As Control = FindControl(Panel1, "startTimeLabel" & num)
            If startTimeLabel.Text = "開始時刻" Then
                startTimeLabel.Text = startTime.ToString
            End If

            Call start_function( _
                FindControl(Panel1, "bStart" & num), _
                FindControl(Panel1, "bStop" & num), _
                FindControl(Panel1, "reset" & num), _
                timer, _
                startTimes(num), _
                FindControl(Panel1, "startTimeLabel" & num), _
                FindControl(Panel1, "taskName" & num), _
                NotifyIcon1, _
                FindControl(Panel1, "Label" & num) _
            )
        Else
            'stopなどのイベント処理
        End If
    End Sub

    ' --------------------------------------------------------------------------------------
    '       指定したコントロール内に含まれるコントロールを指定した名前で検索します。
    '
    ' @Param    cForm   検索対象となるフォーム。
    ' @Param    stName  検索するコントロールの名前。
    ' @Return           取得したコントロールのインスタンス。取得できなかった場合は Nothing。
    ' --------------------------------------------------------------------------------------
    Public Function FindControl(ByVal cPanel As Panel, ByVal stName As String) As Control
        Dim cControl As Control

        ' cForm 内のすべてのコントロールを列挙する
        For Each cControl In cPanel.Controls
            ' コントロール名が合致した場合はそのコントロールのインスタンスを返す
            If cControl.Name = stName Then
                FindControl = cControl
                Exit For
            End If
        Next cControl
    End Function


    ' --------------------------------------------------------------------------------------
    '       指定したコントロール内に含まれるコントロールを指定した名前で検索します。
    '
    ' @Param    cForm   検索対象となるフォーム。
    ' @Param    stName  検索するコントロールの名前。
    ' @Return           取得したコントロールのインスタンス。取得できなかった場合は Nothing。
    ' --------------------------------------------------------------------------------------
    Public Function FindControlFromForm(ByVal cForm As Form, ByVal stName As String) As Timer
        Dim cControl As Control

        ' cForm 内のすべてのコントロールを列挙する
        If cForm.HasChildren Then
        End If

        Dim datalist As System.ComponentModel.Container = Me.components
        'MsgBox(datalist.Components.Count)
        'MsgBox(datalist.Components(0).Site.Name)
        'datalist.Components(0).Site.Name = "Timer1"
        'MsgBox(datalist.Components(0).Site.Name)
        For Each component In datalist.Components
            MsgBox(component.Site.Name)
            If component.Site.Name = stName Then
                FindControlFromForm = component
            End If
        Next
    End Function

    Private Sub inputMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles inputMode.CheckedChanged

        If inputMode.Checked = True Then
            labelToText(taskName1, taskName1Label)
            labelToText(taskName2, taskName2Label)
            labelToText(taskName3, taskName3Label)
            labelToText(taskName4, taskName4Label)
            labelToText(taskName5, taskName5Label)
            labelToText(taskName6, taskName6Label)
            labelToText(taskName7, taskName7Label)
            labelToText(taskName8, taskName8Label)
            labelToText(taskName9, taskName9Label)
            labelToText(hour1, hour1Label)
            labelToText(hour2, hour2Label)
            labelToText(hour3, hour3Label)
            labelToText(hour4, hour4Label)
            labelToText(hour5, hour5Label)
            labelToText(hour6, hour6Label)
            labelToText(hour7, hour7Label)
            labelToText(hour8, hour8Label)
            labelToText(hour9, hour9Label)
            labelToText(note, noteLabel)
            labelToCombobox(status1, statusLabel1)
            labelToCombobox(status2, statusLabel2)
            labelToCombobox(status3, statusLabel3)
            labelToCombobox(status4, statusLabel4)
            labelToCombobox(status5, statusLabel5)
            labelToCombobox(status6, statusLabel6)
            labelToCombobox(status7, statusLabel7)
            labelToCombobox(status8, statusLabel8)
            labelToCombobox(status9, statusLabel9)
        Else
            textToLabel(taskName1, taskName1Label)
            textToLabel(taskName2, taskName2Label)
            textToLabel(taskName3, taskName3Label)
            textToLabel(taskName4, taskName4Label)
            textToLabel(taskName5, taskName5Label)
            textToLabel(taskName6, taskName6Label)
            textToLabel(taskName7, taskName7Label)
            textToLabel(taskName8, taskName8Label)
            textToLabel(taskName9, taskName9Label)
            textToLabel(hour1, hour1Label)
            textToLabel(hour2, hour2Label)
            textToLabel(hour3, hour3Label)
            textToLabel(hour4, hour4Label)
            textToLabel(hour5, hour5Label)
            textToLabel(hour6, hour6Label)
            textToLabel(hour7, hour7Label)
            textToLabel(hour8, hour8Label)
            textToLabel(hour9, hour9Label)
            textToLabel(note, noteLabel)
            comboboxToLabel(status1, statusLabel1)
            comboboxToLabel(status2, statusLabel2)
            comboboxToLabel(status3, statusLabel3)
            comboboxToLabel(status4, statusLabel4)
            comboboxToLabel(status5, statusLabel5)
            comboboxToLabel(status6, statusLabel6)
            comboboxToLabel(status7, statusLabel7)
            comboboxToLabel(status8, statusLabel8)
            comboboxToLabel(status9, statusLabel9)
        End If
    End Sub


    Private Sub bSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSave.Click
        Dim tasksStr() As String = { _
    rabeling(taskName1, Label1, hour1, startTimeLabel1, finishTimeLabel1, status1), _
    rabeling(taskName2, Label2, hour2, startTimeLabel2, finishTimeLabel2, status2), _
    rabeling(taskName3, Label3, hour3, startTimeLabel3, finishTimeLabel3, status3), _
    rabeling(taskName4, Label4, hour4, startTimeLabel4, finishTimeLabel4, status4), _
    rabeling(taskName5, Label5, hour5, startTimeLabel5, finishTimeLabel5, status5), _
    rabeling(taskName6, Label6, hour6, startTimeLabel6, finishTimeLabel6, status6), _
    rabeling(taskName7, Label7, hour7, startTimeLabel7, finishTimeLabel7, status7), _
    rabeling(taskName8, Label8, hour8, startTimeLabel8, finishTimeLabel8, status8), _
    rabeling(taskName9, Label9, hour9, startTimeLabel9, finishTimeLabel9, status9) _
}
        Call save(tasksStr, note, img)
        MsgBox("保存しました。")
    End Sub

    Public WebBrowserDisPlay As Boolean

    Public WebBrowserWindowOpen As Boolean = False

    Private Sub tasklog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tasklog.Click
        Dim domain = databaseInformation("databaseHost")
        Dim tasklogUrl = "http://" + domain + "/my/page"
        'Form2クラスのインスタンスを作成する
        Dim webBrowserForm As New webBrowserForm()
        'Form2を表示する
        'ここではモードレスフォームとして表示する
        If webBrowserForm.Visible = False Then
            webBrowserForm.Show()
        Else
            webBrowserForm.Activate()
        End If

        'webBrowserForm.Show()
        WebBrowserWindowOpen = True
        webBrowserForm.UrltextBox.Text = tasklogUrl
        webBrowserForm.urlAccess(tasklogUrl)

        ''指定されたURLのWebページを読み込む.
        'Try
        '    webBrowserForm.tasklogWebBrowser.Navigate(New Uri(tasklogUrl))
        'Catch ex As System.UriFormatException
        '    Return
        'End Try

        'If WebBrowserDisPlay = False Then
        '    WebBrowser1.Visible = True
        '    Me.WindowState = FormWindowState.Maximized
        '    WebBrowserDisPlay = True
        'Else
        '    WebBrowser1.Visible = False
        '    Me.WindowState = FormWindowState.Normal
        '    WebBrowserDisPlay = False
        'End If
    End Sub

    Public databaseInformation As Collection
    Public ColorChangeLabels() As Label
    Private Sub setting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setting.Click
        Dim Panel As Panel = Panel1

        Dim d As SettingDialog = New SettingDialog(TextBoxs, ColorChangeLabels, Buttons, outAreaButtons, taskName1, checkBoxs, ComboBoxs, Panel, databaseInformation)  'ダイアログに値を渡す
        'ダイアログでOKの場合、該当タスクの開始時刻を置き換える
        If d.ShowDialog() = DialogResult.OK Then
            '値を受け取る
            Dim results As New Collection()
            results = d.GetValue
            databaseInformation = New Collection
            databaseInformation = results("databaseInformation")
        End If
    End Sub





    Public ticketData As Collection = New Collection()
    Function openTicketSearchDialog(ByVal ticketNo As String, ByVal ticketNameLabel As Label)
        Dim d As ticketSearchDialog = New ticketSearchDialog(ticketData, databaseInformation)
        'ダイアログでOKの場合、該当タスクの開始時刻を置き換える
        If d.ShowDialog() = DialogResult.OK Then
            '値を受け取る
            Dim results As New Collection()
            results = d.GetValue
            If d.GetValue("ticketId") Is Nothing Then
            Else
                If (ticketData.Contains(ticketNo)) Then
                    ticketData.Remove(ticketNo)
                End If
                ticketData.Add(d.GetValue("ticketId"), ticketNo)
                ticketNameLabel.Text = d.GetValue("ticketName")
            End If
        End If
    End Function
    Private Sub ticketFind1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind1.Click
        openTicketSearchDialog(1, ticketNameLabel1)
    End Sub
    Private Sub ticketFind2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind2.Click
        openTicketSearchDialog(2, ticketNameLabel2)
    End Sub

    Private Sub ticketFind3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind3.Click
        openTicketSearchDialog(3, ticketNameLabel3)
    End Sub

    Private Sub ticketFind4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind4.Click
        openTicketSearchDialog(4, ticketNameLabel4)
    End Sub

    Private Sub ticketFind5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind5.Click
        openTicketSearchDialog(5, ticketNameLabel5)
    End Sub

    Private Sub ticketFind6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind6.Click
        openTicketSearchDialog(6, ticketNameLabel6)
    End Sub

    Private Sub ticketFind7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind7.Click
        openTicketSearchDialog(7, ticketNameLabel7)
    End Sub

    Private Sub ticketFind8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind8.Click
        openTicketSearchDialog(8, ticketNameLabel8)
    End Sub

    Private Sub ticketFind9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ticketFind9.Click
        openTicketSearchDialog(9, ticketNameLabel9)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub statusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statusLabel1.Click

    End Sub

    Private Sub finishTimeLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles finishTimeLabel1.Click

    End Sub

    Private Sub taskName1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles taskName1.TextChanged

    End Sub
End Class




