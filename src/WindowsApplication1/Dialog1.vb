Imports System.Windows.Forms

Public Class Dialog1


    'コンストラクタを用いて、値を受け取る
    Public Sub New(ByVal Value As String, ByVal taskName As String)
        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()
        Me.Text = "【" + taskName + "】開始時刻を編集"
        TextBox1.Text = Value
    End Sub
    '値を渡すメソッド
    Public Function GetValue() As String
        Return TextBox1.Text
    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


End Class
