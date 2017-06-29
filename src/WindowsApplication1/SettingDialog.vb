Imports System.Windows.Forms

Public Class SettingDialog
    Public getTextBoxs() As TextBox
    Public getLabels() As Label
    Public getButtons() As Button
    Public getoutAreaButtons() As Button
    Public gettaskName1 As TextBox
    Public getcheckBoxs() As CheckBox
    Public getcomboBoxs() As ComboBox
    Public getPanel As Panel
    Public img As System.Drawing.Bitmap

    'コンストラクタを用いて、値を受け取る
    Public Sub New(ByVal TextBoxs As Array, ByVal Labels As Array, ByVal Buttons As Array, ByVal outAreaButtons As Array, ByVal taskName1 As TextBox, ByVal checkBoxs As Array, ByVal comboBoxs As Array, ByVal Panel As Panel, ByVal databaseInformation As Collection)
        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()
        getTextBoxs = TextBoxs
        getLabels = Labels
        getButtons = Buttons
        getoutAreaButtons = outAreaButtons
        gettaskName1 = taskName1
        getcheckBoxs = checkBoxs
        getcomboBoxs = comboBoxs
        getPanel = Panel

        If databaseInformation Is Nothing Then
        Else
            databaseHost.Text = databaseInformation("databaseHost")
            databaseName.Text = databaseInformation("databaseName")
            databaseUser.Text = databaseInformation("databaseUser")
            databasePassword.Text = databaseInformation("databasePassword")
        End If
    End Sub
    '値を渡すメソッド
    Public Function GetValue() As Collection

        Dim databaseInformationTargets() As TextBox = {databaseHost, databaseName, databaseUser, databasePassword}
        Dim databaseInformation As New Collection()
        For Each target In databaseInformationTargets
            databaseInformation.Add(target.Text, target.Name)
        Next


        Dim generalSetting As New Collection()
        generalSetting.Add(selectedColorName)

        Dim results As New Collection()
        results.Add(databaseInformation, "databaseInformation")
        results.Add(generalSetting, "generalSetting")
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
    Public selectedColorName As String
    Private Sub bFontColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bFontColor.Click
        'Dim dialogsButtons() As Button = {bFontColor}
        Dim defaultColor As String
        If selectedColorName <> "" Then
            defaultColor = selectedColorName
        Else
            defaultColor = ""
        End If
        Dim selectedColor = font_color(defaultColor, getLabels, getButtons, getoutAreaButtons, gettaskName1, getcheckBoxs, getcomboBoxs)
        'MsgBox(selectedColor.Name)
    End Sub

    Private Sub backGroundImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backGroundImage.Click
        Dim Location As String
        Location = file_select()
        If Location <> "" Then
            img = ImagePaste(getTextBoxs, getLabels, getButtons, getcomboBoxs, Location, getPanel)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bConnectTest.Click
        Dim databaseInformation As New Collection
        databaseInformation.Add(databaseHost.Text, "databaseHost")
        databaseInformation.Add(databaseName.Text, "databaseName")
        databaseInformation.Add(databaseUser.Text, "databaseUser")
        databaseInformation.Add(databasePassword.Text, "databasePassword")
        connectTest(databaseInformation)
    End Sub
End Class
