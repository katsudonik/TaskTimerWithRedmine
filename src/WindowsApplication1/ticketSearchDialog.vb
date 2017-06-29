Imports System.Windows.Forms


Public Class ticketSearchDialog
    Public big_project_id As String '= "2"
    Public getTicketData As Collection
    Public databaseInformation As Collection
    Public targetTicketId As String

    'コンストラクタを用いて、値を受け取る
    Public Sub New(ByVal ticketData As Collection, ByVal databaseInformation As Collection)
        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        If ticketData Is Nothing Then
        Else
            'ticketData.Text = ticketData("databaseHost")
        End If
        Dim tracker_id As String = getTrackerId("プロジェクト")
        If tracker_id Is Nothing Then
        Else
            Dim results As Collection = getTicketNameCollection(tracker_id, big_project_id)
            Call setComboBoxItem(results, "subject", project)
        End If

    End Sub
    '値を渡すメソッド
    Public Function GetValue() As Collection
        Dim results As New Collection()
        results.Add(targetTicketId, "ticketId")
        results.Add(ticketNameLabel.Text, "ticketName")
        Return results
    End Function
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub bTicketConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bTicketConfirm.Click
        If noInput.Text <> "" Then
            Dim strSELECT = "SELECT issues.id as id,issues.subject as subject FROM issues where issues.id=" + noInput.Text + ""

            Dim selectItem() As String = {"id", "subject"}
            Dim results As Collection
            results = mysqlSelect(selectItem, strSELECT)
            If results Is Nothing Then
            Else
                For Each result In results
                    setTicket(result("id"), result("subject"))
                Next
            End If
        End If
    End Sub

    Private Sub project_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles project.SelectedIndexChanged
        If project.SelectedIndex <> -1 Then
            Dim tracker_id As String = getTrackerId("タスク")
            If tracker_id Is Nothing Then
            Else
                Dim results As Collection = getTicketNameCollection(tracker_id, big_project_id, getComboBoxsSelectedId(project))
                Call setComboBoxItem(results, "subject", task)
            End If
        End If
    End Sub


    Private Sub task_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles task.SelectedIndexChanged
        If task.SelectedIndex <> -1 Then
            Dim tracker_id As String = getTrackerId("項目詳細")
            If tracker_id Is Nothing Then
            Else
                Dim results As Collection = getTicketNameCollection(tracker_id, big_project_id, getComboBoxsSelectedId(task))
                Call setComboBoxItem(results, "subject", detail)
            End If
        End If
    End Sub

    Private Sub detail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles detail.SelectedIndexChanged
        setTicket(getComboBoxsSelectedId(detail), detail.Text)
    End Sub
    Function setTicket(ByVal id As Integer, ByVal ticketName As String)
        targetTicketId = id
        ticketNameLabel.Text = ticketName
        setTicket = id
    End Function
End Class
