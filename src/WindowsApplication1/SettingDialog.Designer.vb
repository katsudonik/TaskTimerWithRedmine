<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingDialog
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.databaseTab = New System.Windows.Forms.TabPage()
        Me.databasePasswordLabel = New System.Windows.Forms.Label()
        Me.databaseUserLabel = New System.Windows.Forms.Label()
        Me.databaseNameLabel = New System.Windows.Forms.Label()
        Me.hostLabel = New System.Windows.Forms.Label()
        Me.databasePassword = New System.Windows.Forms.TextBox()
        Me.databaseUser = New System.Windows.Forms.TextBox()
        Me.databaseName = New System.Windows.Forms.TextBox()
        Me.databaseHost = New System.Windows.Forms.TextBox()
        Me.generalTab = New System.Windows.Forms.TabPage()
        Me.backGroundImage = New System.Windows.Forms.Button()
        Me.bFontColor = New System.Windows.Forms.Button()
        Me.bConnectTest = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.databaseTab.SuspendLayout()
        Me.generalTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(111, 199)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 3)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 3)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "キャンセル"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.databaseTab)
        Me.TabControl1.Controls.Add(Me.generalTab)
        Me.TabControl1.Location = New System.Drawing.Point(7, 9)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(315, 182)
        Me.TabControl1.TabIndex = 1
        '
        'databaseTab
        '
        Me.databaseTab.Controls.Add(Me.bConnectTest)
        Me.databaseTab.Controls.Add(Me.databasePasswordLabel)
        Me.databaseTab.Controls.Add(Me.databaseUserLabel)
        Me.databaseTab.Controls.Add(Me.databaseNameLabel)
        Me.databaseTab.Controls.Add(Me.hostLabel)
        Me.databaseTab.Controls.Add(Me.databasePassword)
        Me.databaseTab.Controls.Add(Me.databaseUser)
        Me.databaseTab.Controls.Add(Me.databaseName)
        Me.databaseTab.Controls.Add(Me.databaseHost)
        Me.databaseTab.Location = New System.Drawing.Point(4, 25)
        Me.databaseTab.Name = "databaseTab"
        Me.databaseTab.Padding = New System.Windows.Forms.Padding(3)
        Me.databaseTab.Size = New System.Drawing.Size(307, 153)
        Me.databaseTab.TabIndex = 0
        Me.databaseTab.Text = "database"
        Me.databaseTab.UseVisualStyleBackColor = True
        '
        'databasePasswordLabel
        '
        Me.databasePasswordLabel.AutoSize = True
        Me.databasePasswordLabel.Location = New System.Drawing.Point(6, 99)
        Me.databasePasswordLabel.Name = "databasePasswordLabel"
        Me.databasePasswordLabel.Size = New System.Drawing.Size(65, 15)
        Me.databasePasswordLabel.TabIndex = 1
        Me.databasePasswordLabel.Text = "password"
        '
        'databaseUserLabel
        '
        Me.databaseUserLabel.AutoSize = True
        Me.databaseUserLabel.Location = New System.Drawing.Point(6, 71)
        Me.databaseUserLabel.Name = "databaseUserLabel"
        Me.databaseUserLabel.Size = New System.Drawing.Size(35, 15)
        Me.databaseUserLabel.TabIndex = 1
        Me.databaseUserLabel.Text = "user"
        '
        'databaseNameLabel
        '
        Me.databaseNameLabel.AutoSize = True
        Me.databaseNameLabel.Location = New System.Drawing.Point(6, 43)
        Me.databaseNameLabel.Name = "databaseNameLabel"
        Me.databaseNameLabel.Size = New System.Drawing.Size(62, 15)
        Me.databaseNameLabel.TabIndex = 1
        Me.databaseNameLabel.Text = "database"
        '
        'hostLabel
        '
        Me.hostLabel.AutoSize = True
        Me.hostLabel.Location = New System.Drawing.Point(6, 15)
        Me.hostLabel.Name = "hostLabel"
        Me.hostLabel.Size = New System.Drawing.Size(35, 15)
        Me.hostLabel.TabIndex = 1
        Me.hostLabel.Text = "host"
        '
        'databasePassword
        '
        Me.databasePassword.Location = New System.Drawing.Point(90, 96)
        Me.databasePassword.Name = "databasePassword"
        Me.databasePassword.Size = New System.Drawing.Size(200, 22)
        Me.databasePassword.TabIndex = 0
        '
        'databaseUser
        '
        Me.databaseUser.Location = New System.Drawing.Point(90, 68)
        Me.databaseUser.Name = "databaseUser"
        Me.databaseUser.Size = New System.Drawing.Size(200, 22)
        Me.databaseUser.TabIndex = 0
        '
        'databaseName
        '
        Me.databaseName.Location = New System.Drawing.Point(90, 40)
        Me.databaseName.Name = "databaseName"
        Me.databaseName.Size = New System.Drawing.Size(200, 22)
        Me.databaseName.TabIndex = 0
        '
        'databaseHost
        '
        Me.databaseHost.Location = New System.Drawing.Point(90, 12)
        Me.databaseHost.Name = "databaseHost"
        Me.databaseHost.Size = New System.Drawing.Size(200, 22)
        Me.databaseHost.TabIndex = 0
        '
        'generalTab
        '
        Me.generalTab.Controls.Add(Me.backGroundImage)
        Me.generalTab.Controls.Add(Me.bFontColor)
        Me.generalTab.Location = New System.Drawing.Point(4, 25)
        Me.generalTab.Name = "generalTab"
        Me.generalTab.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTab.Size = New System.Drawing.Size(307, 153)
        Me.generalTab.TabIndex = 1
        Me.generalTab.Text = "general"
        Me.generalTab.UseVisualStyleBackColor = True
        '
        'backGroundImage
        '
        Me.backGroundImage.BackColor = System.Drawing.Color.Transparent
        Me.backGroundImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.backGroundImage.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.backGroundImage.Location = New System.Drawing.Point(6, 49)
        Me.backGroundImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.backGroundImage.Name = "backGroundImage"
        Me.backGroundImage.Size = New System.Drawing.Size(144, 29)
        Me.backGroundImage.TabIndex = 1003
        Me.backGroundImage.Text = "backGroundImage"
        Me.backGroundImage.UseVisualStyleBackColor = False
        '
        'bFontColor
        '
        Me.bFontColor.BackColor = System.Drawing.Color.Transparent
        Me.bFontColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bFontColor.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.bFontColor.Location = New System.Drawing.Point(6, 16)
        Me.bFontColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.bFontColor.Name = "bFontColor"
        Me.bFontColor.Size = New System.Drawing.Size(123, 29)
        Me.bFontColor.TabIndex = 1003
        Me.bFontColor.Text = "font color"
        Me.bFontColor.UseVisualStyleBackColor = False
        '
        'bConnectTest
        '
        Me.bConnectTest.Location = New System.Drawing.Point(215, 124)
        Me.bConnectTest.Name = "bConnectTest"
        Me.bConnectTest.Size = New System.Drawing.Size(86, 23)
        Me.bConnectTest.TabIndex = 2
        Me.bConnectTest.Text = "test"
        Me.bConnectTest.UseVisualStyleBackColor = True
        '
        'SettingDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(322, 246)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.databaseTab.ResumeLayout(False)
        Me.databaseTab.PerformLayout()
        Me.generalTab.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents generalTab As System.Windows.Forms.TabPage
    Friend WithEvents databaseTab As System.Windows.Forms.TabPage
    Friend WithEvents databasePasswordLabel As System.Windows.Forms.Label
    Friend WithEvents databaseUserLabel As System.Windows.Forms.Label
    Friend WithEvents databaseNameLabel As System.Windows.Forms.Label
    Friend WithEvents hostLabel As System.Windows.Forms.Label
    Friend WithEvents databasePassword As System.Windows.Forms.TextBox
    Friend WithEvents databaseUser As System.Windows.Forms.TextBox
    Friend WithEvents databaseName As System.Windows.Forms.TextBox
    Friend WithEvents databaseHost As System.Windows.Forms.TextBox
    Friend WithEvents bFontColor As System.Windows.Forms.Button
    Friend WithEvents backGroundImage As System.Windows.Forms.Button
    Friend WithEvents bConnectTest As System.Windows.Forms.Button

End Class
