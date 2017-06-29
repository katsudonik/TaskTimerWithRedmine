Module MenuBarModule
    Function menuBar(ByVal MenuStrip As MenuStrip, ByVal menuItems As Array)
        'メニュー項目の
        Dim item As New ToolStripMenuItem
        For Each MenuItem In menuItems
            item.Text = MenuItem
            'メニュー項目の追加
            MenuStrip.Items.Add(item)
        Next
    End Function
End Module
