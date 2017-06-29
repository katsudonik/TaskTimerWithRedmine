<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ticketSearchDialog
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
        Me.project = New System.Windows.Forms.ComboBox()
        Me.task = New System.Windows.Forms.ComboBox()
        Me.projectLabel = New System.Windows.Forms.Label()
        Me.taskLabel = New System.Windows.Forms.Label()
        Me.detailLabel = New System.Windows.Forms.Label()
        Me.detail = New System.Windows.Forms.ComboBox()
        Me.noInput = New System.Windows.Forms.TextBox()
        Me.ticketNameLabel = New System.Windows.Forms.Label()
        Me.noInputLabel = New System.Windows.Forms.Label()
        Me.sharpLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bTicketConfirm = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(268, 176)
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
        'project
        '
        Me.project.FormattingEnabled = True
        Me.project.Location = New System.Drawing.Point(118, 11)
        Me.project.Name = "project"
        Me.project.Size = New System.Drawing.Size(345, 23)
        Me.project.TabIndex = 1
        '
        'task
        '
        Me.task.FormattingEnabled = True
        Me.task.Location = New System.Drawing.Point(118, 40)
        Me.task.Name = "task"
        Me.task.Size = New System.Drawing.Size(345, 23)
        Me.task.TabIndex = 1
        '
        'projectLabel
        '
        Me.projectLabel.AutoSize = True
        Me.projectLabel.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.projectLabel.Location = New System.Drawing.Point(13, 14)
        Me.projectLabel.Name = "projectLabel"
        Me.projectLabel.Size = New System.Drawing.Size(103, 15)
        Me.projectLabel.TabIndex = 2
        Me.projectLabel.Text = "プロジェクト"
        '
        'taskLabel
        '
        Me.taskLabel.AutoSize = True
        Me.taskLabel.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.taskLabel.Location = New System.Drawing.Point(13, 44)
        Me.taskLabel.Name = "taskLabel"
        Me.taskLabel.Size = New System.Drawing.Size(55, 15)
        Me.taskLabel.TabIndex = 2
        Me.taskLabel.Text = "タスク"
        '
        'detailLabel
        '
        Me.detailLabel.AutoSize = True
        Me.detailLabel.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.detailLabel.Location = New System.Drawing.Point(13, 74)
        Me.detailLabel.Name = "detailLabel"
        Me.detailLabel.Size = New System.Drawing.Size(71, 15)
        Me.detailLabel.TabIndex = 2
        Me.detailLabel.Text = "項目詳細"
        '
        'detail
        '
        Me.detail.FormattingEnabled = True
        Me.detail.Location = New System.Drawing.Point(118, 70)
        Me.detail.Name = "detail"
        Me.detail.Size = New System.Drawing.Size(345, 23)
        Me.detail.TabIndex = 1
        '
        'noInput
        '
        Me.noInput.Location = New System.Drawing.Point(139, 111)
        Me.noInput.Name = "noInput"
        Me.noInput.Size = New System.Drawing.Size(60, 22)
        Me.noInput.TabIndex = 3
        '
        'ticketNameLabel
        '
        Me.ticketNameLabel.AutoSize = True
        Me.ticketNameLabel.Location = New System.Drawing.Point(136, 149)
        Me.ticketNameLabel.Name = "ticketNameLabel"
        Me.ticketNameLabel.Size = New System.Drawing.Size(37, 15)
        Me.ticketNameLabel.TabIndex = 4
        Me.ticketNameLabel.Text = "　　　"
        '
        'noInputLabel
        '
        Me.noInputLabel.AutoSize = True
        Me.noInputLabel.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.noInputLabel.Location = New System.Drawing.Point(13, 114)
        Me.noInputLabel.Name = "noInputLabel"
        Me.noInputLabel.Size = New System.Drawing.Size(87, 15)
        Me.noInputLabel.TabIndex = 2
        Me.noInputLabel.Text = "チケットNo"
        '
        'sharpLabel
        '
        Me.sharpLabel.AutoSize = True
        Me.sharpLabel.Location = New System.Drawing.Point(119, 114)
        Me.sharpLabel.Name = "sharpLabel"
        Me.sharpLabel.Size = New System.Drawing.Size(15, 15)
        Me.sharpLabel.TabIndex = 2
        Me.sharpLabel.Text = "#"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(13, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "対象チケット："
        '
        'bTicketConfirm
        '
        Me.bTicketConfirm.Font = New System.Drawing.Font("HG創英角ﾎﾟｯﾌﾟ体", 9.0!)
        Me.bTicketConfirm.Location = New System.Drawing.Point(216, 111)
        Me.bTicketConfirm.Name = "bTicketConfirm"
        Me.bTicketConfirm.Size = New System.Drawing.Size(56, 22)
        Me.bTicketConfirm.TabIndex = 6
        Me.bTicketConfirm.Text = "適用"
        Me.bTicketConfirm.UseVisualStyleBackColor = True
        '
        'ticketSearchDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(479, 223)
        Me.Controls.Add(Me.bTicketConfirm)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ticketNameLabel)
        Me.Controls.Add(Me.noInput)
        Me.Controls.Add(Me.sharpLabel)
        Me.Controls.Add(Me.noInputLabel)
        Me.Controls.Add(Me.detailLabel)
        Me.Controls.Add(Me.taskLabel)
        Me.Controls.Add(Me.projectLabel)
        Me.Controls.Add(Me.detail)
        Me.Controls.Add(Me.task)
        Me.Controls.Add(Me.project)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ticketSearchDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "チケット選択"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents project As System.Windows.Forms.ComboBox
    Friend WithEvents task As System.Windows.Forms.ComboBox
    Friend WithEvents projectLabel As System.Windows.Forms.Label
    Friend WithEvents taskLabel As System.Windows.Forms.Label
    Friend WithEvents detailLabel As System.Windows.Forms.Label
    Friend WithEvents detail As System.Windows.Forms.ComboBox
    Friend WithEvents noInput As System.Windows.Forms.TextBox
    Friend WithEvents ticketNameLabel As System.Windows.Forms.Label
    Friend WithEvents noInputLabel As System.Windows.Forms.Label
    Friend WithEvents sharpLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bTicketConfirm As System.Windows.Forms.Button

End Class
