<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class webBrowserForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tasklogWebBrowser = New System.Windows.Forms.WebBrowser()
        Me.UrltextBox = New System.Windows.Forms.TextBox()
        Me.URLLabel = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tasklogWebBrowser
        '
        Me.tasklogWebBrowser.Location = New System.Drawing.Point(12, 42)
        Me.tasklogWebBrowser.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tasklogWebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.tasklogWebBrowser.Name = "tasklogWebBrowser"
        Me.tasklogWebBrowser.Size = New System.Drawing.Size(1393, 944)
        Me.tasklogWebBrowser.TabIndex = 44
        Me.tasklogWebBrowser.Url = New System.Uri("http://hr.pmo/my/page", System.UriKind.Absolute)
        '
        'UrltextBox
        '
        Me.UrltextBox.Location = New System.Drawing.Point(54, 12)
        Me.UrltextBox.Name = "UrltextBox"
        Me.UrltextBox.Size = New System.Drawing.Size(714, 22)
        Me.UrltextBox.TabIndex = 45
        '
        'URLLabel
        '
        Me.URLLabel.AutoSize = True
        Me.URLLabel.Location = New System.Drawing.Point(12, 15)
        Me.URLLabel.Name = "URLLabel"
        Me.URLLabel.Size = New System.Drawing.Size(34, 15)
        Me.URLLabel.TabIndex = 46
        Me.URLLabel.Text = "URL"
        '
        'SearchButton
        '
        Me.SearchButton.BackColor = System.Drawing.Color.Transparent
        Me.SearchButton.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.SearchButton.Location = New System.Drawing.Point(776, 12)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(83, 22)
        Me.SearchButton.TabIndex = 47
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = False
        '
        'webBrowserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1417, 990)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.URLLabel)
        Me.Controls.Add(Me.UrltextBox)
        Me.Controls.Add(Me.tasklogWebBrowser)
        Me.Name = "webBrowserForm"
        Me.Text = "Web"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tasklogWebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents UrltextBox As System.Windows.Forms.TextBox
    Friend WithEvents URLLabel As System.Windows.Forms.Label
    Friend WithEvents SearchButton As System.Windows.Forms.Button
End Class
