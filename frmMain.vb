Imports System.Collections.Specialized
Imports System.IO
Public Class frmMain
    Const gridSize As Integer = 10
    Dim mineCount As Integer = 10
    Dim arrButtons(gridSize - 1, gridSize - 1) As Button
    Dim arrMines(gridSize - 1, gridSize - 1) As Boolean
    Dim uncoveredTiles As Integer
    Dim timGame As Timer
    Dim pName As String
    Dim time As String = "00:00:00"
    Dim sbState As String
    Dim gameLocked As Boolean = True

    Private Sub frmMain(sender As Object, e As EventArgs) Handles MyBase.Load
        initialiseButtons()
        btnStart.Text = "Start"
        sbState = btnStart.Text
    End Sub

    Private Sub initialiseButtons()
        Dim x As Integer
        Dim y As Integer
        For x = 0 To gridSize - 1
            For y = 0 To gridSize - 1
                Dim btnTile As New Button With {
                    .Size = New Size(35, 35),
                    .Location = New Point(35 * x, 35 * y)
                }
                AddHandler btnTile.MouseUp, AddressOf Button_MouseUp
                pnlGrid.Controls.Add(btnTile)
                arrButtons(x, y) = btnTile
            Next y
        Next x
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'what this sub does
        pName = txtName.Text
        Dim nameVal As Boolean = validateName(pName)
        If nameVal = False Then
            MsgBox("Username must be 3 characters long.")
        Else
            time = "00:00:00"
            lblTime.Text = time

            initialiseMines()
            uncoveredTiles = 0

            'check ----
            If timGame Is Nothing Then
                timGame = New Timer With {.Interval = 1000}
                AddHandler timGame.Tick, AddressOf timGame_Tick
            End If

            timGame.Start()
            btnStart.Text = "Restart"
            sbState = btnStart.Text
            gameLocked = False
        End If
    End Sub

    Private Function validateName(pName As String) As Boolean
        Dim result As Boolean = True
        If pName.Length <> 3 Then
            result = False
        End If
        Return result
    End Function

    Private Sub initialiseMines()
        Dim random As New Random()

        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                arrMines(x, y) = False
            Next y
        Next x

        For i As Integer = 1 To mineCount
            Dim x, y As Integer
            While arrMines(x, y) = True
                x = random.Next(gridSize)
                y = random.Next(gridSize)
            End While

            arrMines(x, y) = True
        Next i

        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                arrButtons(x, y).Enabled = True
                arrButtons(x, y).Text = ""
            Next y
        Next x
    End Sub

    Private Sub timGame_Tick(sender As Object, e As EventArgs)
        time = TimeSpan.FromSeconds(TimeSpan.Parse(lblTime.Text).TotalSeconds + 1).ToString()
        lblTime.Text = time
    End Sub

    Private Sub Button_MouseUp(sender As Object, e As MouseEventArgs)
        If timGame Is Nothing OrElse Not timGame.Enabled Then
            MsgBox("Please enter a name and press " & "'" & sbState & "'.")
        End If

        Dim clickedButton As Button = CType(sender, Button)
        Dim x As Integer
        Dim y As Integer
        getPos(clickedButton, x, y)

        If e.Button = MouseButtons.Left And gameLocked = False Then
            If arrMines(x, y) = True Then
                timGame.Stop()
                MsgBox($"Game over! You lost in " & lblTime.Text & ".")
                gameLocked = True
            Else
                revealEmpty(x, y)
            End If
        End If

        If e.Button = MouseButtons.Right And gameLocked = False Then
            clickedButton.Text = If(clickedButton.Text = "", "F", "")
        End If

        If (gridSize * gridSize - uncoveredTiles) = mineCount Then
            timGame.Stop()
            saveScore(pName, time)
            MsgBox($"Congratulations! You won in " & lblTime.Text & ".")
        End If
    End Sub

    Private Sub revealEmpty(x As Integer, y As Integer)
        If x < 0 OrElse x >= gridSize OrElse y < 0 OrElse y >= gridSize Then Return
        If Not arrButtons(x, y).Enabled Then Return

        arrButtons(x, y).Enabled = False
        uncoveredTiles += 1

        Dim adjacentMines As Integer = calcAdjacent(x, y)

        If adjacentMines > 0 Then
            arrButtons(x, y).Text = adjacentMines.ToString()
        Else
            For xShift As Integer = -1 To 1
                For yShift As Integer = -1 To 1
                    revealEmpty(x + xShift, y + yShift)
                Next yShift
            Next xShift
        End If
    End Sub


    Private Function calcAdjacent(x As Integer, y As Integer) As Integer
        Dim count As Integer = 0

        For xShift As Integer = -1 To 1
            For yShift As Integer = -1 To 1
                Dim newX As Integer = x + xShift
                Dim newY As Integer = y + yShift

                If newX >= 0 AndAlso newX < gridSize AndAlso newY >= 0 AndAlso newY < gridSize AndAlso arrMines(newX, newY) = True Then
                    count += 1
                End If
            Next yShift
        Next xShift

        Return count
    End Function

    Private Sub getPos(clickedButton As Button, ByRef x As Integer, ByRef y As Integer)
        For xShift As Integer = 0 To gridSize - 1
            For yShift As Integer = 0 To gridSize - 1
                If arrButtons(xShift, yShift) Is clickedButton Then
                    x = xShift
                    y = yShift
                    Exit Sub
                End If
            Next yShift
        Next xShift
    End Sub

    Private Sub saveScore(username As String, time As String)
        Dim filepath As String = "lb.txt"
        Dim scores As New List(Of String)

        If File.Exists(filepath) Then
            scores = File.ReadAllLines(filepath).ToList()
        End If

        Dim playerScore As String = username & "," & time
        scores.Add(playerScore)

        scores = scores.OrderBy(Function(score) TimeSpan.Parse(score.Split(",")(1))).ToList()

        If scores.Count > 10 Then
            scores.RemoveAt(10)
        End If

        File.WriteAllLines(filepath, scores)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Opens a PDF of the user guide when the user clicks the "?" button. Credit to Kaelen Sorenson for the code.
        Dim openPDF As New Process
        openPDF.StartInfo.UseShellExecute = True
        openPDF.StartInfo.WorkingDirectory = Application.StartupPath
        openPDF.StartInfo.FileName = "UserGuide.pdf"
        openPDF.Start()
    End Sub
    Private Sub btnLeaderboard_Click(sender As Object, e As EventArgs) Handles btnLeaderboard.Click
        frmLeaderboard.Show()
        Me.Hide()
    End Sub
End Class
