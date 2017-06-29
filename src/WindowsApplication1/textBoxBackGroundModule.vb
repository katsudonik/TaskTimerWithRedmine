Module textBoxBackGroundModule
    Function textToLabel(ByVal textBox As TextBox, ByVal label As Label)
        textBox.Visible = False
        label.Text = textBox.Text
        label.Visible = True
        textToLabel = Nothing
    End Function
    Function labelToText(ByVal textBox As TextBox, ByVal label As Label)
        label.Visible = False
        textBox.Text = label.Text
        textBox.Visible = True
        labelToText = Nothing
    End Function
    Function comboboxToLabel(ByVal combobox As ComboBox, ByVal label As Label)
        combobox.Visible = False
        label.Text = combobox.Text
        label.Visible = True
        comboboxToLabel = Nothing
    End Function
    Function labelToCombobox(ByVal combobox As ComboBox, ByVal label As Label)
        label.Visible = False
        combobox.Visible = True
        labelToCombobox = Nothing
    End Function
End Module
