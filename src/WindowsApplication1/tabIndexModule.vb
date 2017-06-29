Module tabIndexModule
    Public index As Integer = 0

    Function tabIndexChange(ByVal array As Array)
        For Each this In array
            index = index + 1
            this.TabIndex = index
        Next
    End Function

End Module
