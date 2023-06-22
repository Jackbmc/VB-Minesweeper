Imports System.IO
Public Class frmMain
    'Declares necessary variables
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
        'Calls the initialise buttons subroutine to place the buttons and updates the start/restart button
        initialiseButtons()
        btnStart.Text = "Start"
        sbState = btnStart.Text
    End Sub

    Private Sub initialiseButtons()
        'Places buttons in the panel with set size and location. Also gives butons handlers for click detection.
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
        'Gets the player name and validates it to ensure that it is 3 characters, if it is valid, starts the game.
        pName = txtName.Text
        Dim nameVal As Boolean = validateName(pName)
        If nameVal = False Then
            MsgBox("Username must be 3 characters long.")
        Else
            startGame()
        End If
    End Sub
    Private Sub startGame()
        'General setup procedure for starting the game (resetting timer, resetting tiles/mines, starting the timer, unlocking the board, and updating the start/restart button.
        initialiseMines()
        setupTimer()
        time = "00:00:00"
        lblTime.Text = time
        uncoveredTiles = 0
        timGame.Start()
        btnStart.Text = "Restart"
        sbState = btnStart.Text
        gameLocked = False
    End Sub
    Private Sub setupTimer()
        'Checks to see if the timer is nothing, if so, sets the timer and interval and adds the necessary handler for game ticks.
        If timGame Is Nothing Then
            timGame = New Timer With {.Interval = 1000}
            AddHandler timGame.Tick, AddressOf timGame_Tick
        End If
    End Sub

    Private Function validateName(pName As String) As Boolean
        'Validates that the name is 3 characters and returns the result as a boolean.
        Dim result As Boolean = True
        If pName.Length <> 3 Then
            result = False
        End If
        Return result
    End Function

    Private Sub initialiseMines()
        Dim random As New Random()

        'Sets everything in arrMines to false.
        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                arrMines(x, y) = False
            Next y
        Next x

        'Generates mines on the board to the value of the predefined mineCount.
        For i As Integer = 1 To mineCount
            Dim x, y As Integer
            While arrMines(x, y) = True
                x = random.Next(gridSize)
                y = random.Next(gridSize)
            End While

            arrMines(x, y) = True
        Next i

        'Clears the text of all buttons and enables them so they can be clicked.
        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                arrButtons(x, y).Enabled = True
                arrButtons(x, y).Text = ""
            Next y
        Next x
    End Sub

    Private Sub timGame_Tick(sender As Object, e As EventArgs)
        'Increments the time by +1 second and updates the timer label to display the time.
        time = TimeSpan.FromSeconds(TimeSpan.Parse(lblTime.Text).TotalSeconds + 1).ToString()
        lblTime.Text = time
    End Sub

    Private Sub Button_MouseUp(sender As Object, e As MouseEventArgs)
        'If the game is not running, inform the user.
        If timGame Is Nothing OrElse Not timGame.Enabled Then
            MsgBox("Please enter a name and press " & "'" & sbState & "'.")
        End If

        Dim clickedButton As Button = CType(sender, Button)
        Dim x As Integer
        Dim y As Integer
        getPos(clickedButton, x, y)

        'If the game s not locked (is running) check for a mine. Depending on the cell state either proceed to reveal empty cells or call the lossCondition.
        If e.Button = MouseButtons.Left And gameLocked = False Then
            If arrMines(x, y) = True Then
                lossCondition()
            Else
                revealEmpty(x, y)
            End If
        End If

        'If the game is not locked (is running) flag the clicked tile (set to "F").
        If e.Button = MouseButtons.Right And gameLocked = False Then
            clickedButton.Text = If(clickedButton.Text = "", "F", "")
        End If

        'If the user has cleared all non-mine tiles, call the winCondition.
        If (gridSize * gridSize - uncoveredTiles) = mineCount Then
            winCondition()
        End If
    End Sub

    Private Sub winCondition()
        'Stop the timer, save the score, lock the game, and inform the user that they won.
        timGame.Stop()
        saveScore(pName, time)
        MsgBox($"Congratulations! You won in " & lblTime.Text & ".")
        gameLocked = True
    End Sub

    Private Sub lossCondition()
        'Stop the timer, inform the user that they won, lock the game.
        timGame.Stop()
        MsgBox($"Game over! You lost in " & lblTime.Text & ".")
        gameLocked = True
    End Sub

    Private Sub revealEmpty(x As Integer, y As Integer)
        'Checks to ensure that the clicked position is within the grid size and checks to ensure that the clicked button is enabled.
        If x < 0 OrElse x >= gridSize OrElse y < 0 OrElse y >= gridSize Then

        ElseIf Not arrButtons(x, y).Enabled Then

        Else
            'Disables the button so that it can not be clicked again and increments the uncoveredTiles by +1.
            arrButtons(x, y).Enabled = False
            uncoveredTiles += 1

            Dim adjacentMines As Integer = calcAdjacent(x, y)

            If adjacentMines > 0 Then
                'Sets the button text to display the adjacent mine count.
                arrButtons(x, y).Text = adjacentMines.ToString()
            Else
                'Recursively reveals empty cells if there are no adjacent mines (flooding).
                For xShift As Integer = -1 To 1
                    For yShift As Integer = -1 To 1
                        revealEmpty(x + xShift, y + yShift)
                    Next yShift
                Next xShift
            End If
        End If
    End Sub


    Private Function calcAdjacent(x As Integer, y As Integer) As Integer
        'Calculates the number of adjacent mines by recursively checking surrounding tiles.
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
        'Gets the position of the clicked button and sets the x and y values of said button.
        For xShift As Integer = 0 To gridSize - 1
            For yShift As Integer = 0 To gridSize - 1
                If arrButtons(xShift, yShift) Is clickedButton Then
                    x = xShift
                    y = yShift
                    yShift = gridSize + 1
                    xShift = gridSize + 1
                End If
            Next yShift
        Next xShift
    End Sub

    Private Sub saveScore(username As String, time As String)
        Dim filepath As String = "lb.txt"
        Dim scores As New List(Of String)

        'Checks to ensure that the file exists before reading the contents (shouldn't be an issue unless the user tampers with internal files)
        If File.Exists(filepath) Then
            scores = File.ReadAllLines(filepath).ToList()
        End If

        'Defines the player score by combining the username and game time, seperates with ",". Adds the new player score to the existing list of scores (read from file).
        Dim playerScore As String = username & "," & time
        scores.Add(playerScore)

        'Orders the scores by time.
        scores = scores.OrderBy(Function(score) TimeSpan.Parse(score.Split(",")(1))).ToList()

        'Truncates scores that exceed the top 10.
        If scores.Count > 10 Then
            scores.RemoveAt(10)
        End If

        'Writes the updated scores.
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
        'Changes forms the show the leaderboard.
        frmLeaderboard.Show()
        Me.Hide()
    End Sub
End Class
