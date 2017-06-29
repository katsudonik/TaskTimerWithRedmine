Public Class webBrowserForm

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        urlAccess(UrltextBox.Text)
    End Sub
    Function urlAccess(ByVal Url As String)
        '指定されたURLのWebページを読み込む.
        Try
            tasklogWebBrowser.Navigate(New Uri(Url))
            urlAccess = True
        Catch ex As System.UriFormatException
            'Return
            urlAccess = False
        End Try
    End Function

    Private Sub UrltextBox_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UrltextBox.KeyPress
        If e.KeyChar = Chr(13) Then 'chr(13)はEnterキー
            urlAccess(UrltextBox.Text)
        End If
    End Sub
    Public WebBrowserWindowOpen As Boolean
    'フォームのFormClosingイベントハンドラ
    Private Sub WebBrowserForm_FormClosing(ByVal sender As System.Object, _
            ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles MyBase.FormClosing
        WebBrowserWindowOpen = False
    End Sub
End Class