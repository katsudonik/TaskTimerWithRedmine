Module FormCleateModule
    Function setComboBoxItem(ByVal itemsCollection As Collection, ByVal key As String, ByVal targetComboBox As ComboBox)
        targetComboBox.Items.Clear()
        targetComboBox.Text = ""
        If itemsCollection Is Nothing Then
        Else

            '項目をコンボボックスに追加していく
            Dim myComboBoxItem As MyComboBoxItem
            For Each item In itemsCollection
                MyComboBoxItem = New MyComboBoxItem(item("id"), item(key))
                '                targetComboBox.Items.Add(item(key))
                targetComboBox.Items.Add(myComboBoxItem)
            Next
        End If
    End Function
    Function getComboBoxsSelectedId(ByVal fromComboBox As ComboBox)
        Dim item As MyComboBoxItem
        'Load時に追加したオブジェクトの中から選択中のものを取得
        item = DirectCast(fromComboBox.SelectedItem, MyComboBoxItem)
        getComboBoxsSelectedId = item.Id
    End Function
End Module
