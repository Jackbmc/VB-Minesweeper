Imports System.IO
Public Class frmMain
    Const gridSize As Integer = 10
    Dim mineCount As Integer = 10
    Dim buttons(gridSize - 1, gridSize - 1) As Button
    Dim mines(gridSize - 1, gridSize - 1) As Boolean
    Dim uncoveredTiles As Integer
    Dim gameTimer As Timer
    Dim restartCooldown As DateTime

    Private Sub frmMain(sender As Object, e As EventArgs) Handles MyBase.Load
        InitialiseButtons()
        btnStart.Text = "Start"
    End Sub

    Private Sub InitialiseButtons()
        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                Dim newButton As New Button With {
                    .Size = New Size(35, 35),
                    .Location = New Point(35 * x, 35 * y)
                }
                AddHandler newButton.MouseUp, AddressOf Button_MouseUp
                pnlGrid.Controls.Add(newButton)
                buttons(x, y) = newButton
            Next
        Next
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If txtName.Text.Length <> 3 Then
            MessageBox.Show("Username must be 3 characters long.")
            Return
        End If

        If btnStart.Text = "Restart" AndAlso DateTime.Now < restartCooldown.AddSeconds(1) Then
            MessageBox.Show("Please wait 1 seconds before restarting.")
            Return
        End If

        lblTime.Text = "00:00:00" ' Reset the timer to 0

        InitialiseMines()
        uncoveredTiles = 0

        If gameTimer Is Nothing Then
            gameTimer = New Timer With {.Interval = 1000}
            AddHandler gameTimer.Tick, AddressOf GameTimer_Tick
        End If

        gameTimer.Start()
        btnStart.Text = "Restart"
    End Sub

    Private Sub InitialiseMines()
        Dim rnd As New Random()

        ' Clear the mines array
        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                mines(x, y) = False
            Next
        Next

        ' Set the location of the mines
        For i As Integer = 1 To mineCount
            Dim x, y As Integer
            Do
                x = rnd.Next(gridSize)
                y = rnd.Next(gridSize)
            Loop While mines(x, y)

            mines(x, y) = True
        Next

        For x As Integer = 0 To gridSize - 1
            For y As Integer = 0 To gridSize - 1
                buttons(x, y).Enabled = True
                buttons(x, y).Text = ""
            Next
        Next
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs)
        lblTime.Text = TimeSpan.FromSeconds(TimeSpan.Parse(lblTime.Text).TotalSeconds + 1).ToString()
    End Sub

    Private Sub Button_MouseUp(sender As Object, e As MouseEventArgs)
        If gameTimer Is Nothing OrElse Not gameTimer.Enabled Then
            MessageBox.Show($"Please enter a name and press 'Start'.")
            Return
        End If

        Dim clickedButton As Button = CType(sender, Button)
        Dim x, y As Integer
        GetButtonPosition(clickedButton, x, y)

        If e.Button = MouseButtons.Left Then
            If mines(x, y) Then
                gameTimer.Stop()
                restartCooldown = DateTime.Now
                MessageBox.Show($"Game over! You lost in {lblTime.Text}.")
            Else
                RevealEmptyCells(x, y)
            End If
        ElseIf e.Button = MouseButtons.Right Then
            clickedButton.Text = If(clickedButton.Text = "", "F", "")
        End If

        If gridSize * gridSize - uncoveredTiles = mineCount Then
            gameTimer.Stop()
            SavePlayerResult(txtName.Text, lblTime.Text)
            MessageBox.Show($"Congratulations! You won in {lblTime.Text}.")
        End If
    End Sub

    Private Sub RevealEmptyCells(x As Integer, y As Integer)
        Dim stack As New Stack(Of Point)
        stack.Push(New Point(x, y))

        While stack.Count > 0
            Dim current As Point = stack.Pop()
            x = current.X
            y = current.Y

            If Not buttons(x, y).Enabled Then
                Continue While
            End If

            buttons(x, y).Enabled = False
            uncoveredTiles += 1

            Dim adjacentMines As Integer = CountAdjacentMines(x, y)

            If adjacentMines > 0 Then
                buttons(x, y).Text = adjacentMines.ToString()
            Else
                For i As Integer = -1 To 1
                    For j As Integer = -1 To 1
                        Dim newX As Integer = x + i
                        Dim newY As Integer = y + j

                        If newX >= 0 AndAlso newX < gridSize AndAlso newY >= 0 AndAlso newY < gridSize Then
                            stack.Push(New Point(newX, newY))
                        End If
                    Next
                Next
            End If
        End While
    End Sub

    Private Function CountAdjacentMines(x As Integer, y As Integer) As Integer
        Dim count As Integer = 0

        For i As Integer = -1 To 1
            For j As Integer = -1 To 1
                Dim newX As Integer = x + i
                Dim newY As Integer = y + j

                If newX >= 0 AndAlso newX < gridSize AndAlso newY >= 0 AndAlso newY < gridSize AndAlso mines(newX, newY) Then
                    count += 1
                End If
            Next
        Next

        Return count
    End Function

    Private Sub GetButtonPosition(clickedButton As Button, ByRef x As Integer, ByRef y As Integer)
        For i As Integer = 0 To gridSize - 1
            For j As Integer = 0 To gridSize - 1
                If buttons(i, j) Is clickedButton Then
                    x = i
                    y = j
                    Exit Sub
                End If
            Next
        Next
    End Sub

    Private Sub SavePlayerResult(username As String, time As String)
        Dim filepath As String = "lb.txt"
        Dim scores As New List(Of String)

        If File.Exists(filepath) Then
            scores = File.ReadAllLines(filepath).ToList()
        End If

        Dim playerScore As String = $"{username},{time}"
        scores.Add(playerScore)

        scores = scores.OrderBy(Function(score) TimeSpan.Parse(score.Split(",")(1))).ToList()

        If scores.Count > 10 Then
            scores.RemoveAt(10)
        End If

        File.WriteAllLines(filepath, scores)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Me.Hide()
    End Sub
    Private Sub btnLeaderboard_Click(sender As Object, e As EventArgs) Handles btnLeaderboard.Click
        refreshLB()
        frmLeaderboard.Show()
        Me.Hide()
    End Sub
End Class
