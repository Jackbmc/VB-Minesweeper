Module modGlobal
    Public firstGame As Boolean = False

    Public Sub refreshLB()
        frmLeaderboard.lstLeaderboard.Items.Clear()
        frmLeaderboard.loadLB()
    End Sub
End Module