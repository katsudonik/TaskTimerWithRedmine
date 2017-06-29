
Module taskNameColorChangeModule
    Function taskNameColorChange(ByVal status As System.Windows.Forms.ComboBox, ByVal taskName As System.Windows.Forms.TextBox)
        If status.SelectedItem = "完了" Then
            taskName.BackColor = Color.Gold
        Else
            taskName.BackColor = Color.White

        End If
        taskNameColorChange = Nothing
    End Function
End Module
