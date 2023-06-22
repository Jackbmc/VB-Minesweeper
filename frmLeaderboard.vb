Imports Microsoft.VisualBasic.FileSystem
Imports System.IO
Public Class frmLeaderboard
    Public Structure recHighScore
        Public name As String
        Public score As String
    End Structure

    Dim arrHighScores(10) As recHighScore

    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Calls the loadLB subroutine.
        loadLB()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Changes forms the show the main page.
        frmMain.Show()
        Me.Hide()
    End Sub

    Public Sub loadLB()
        Dim filepath As String = Application.StartupPath() & "\lb.txt"

        'Reads the score board.
        If File.Exists(filepath) Then
            FileSystem.FileOpen(1, filepath, OpenMode.Input)

            Dim i As Integer = 1
            'Loops through the scores until the end of file, adding each entry to the list box.
            While Not EOF(1)
                FileSystem.Input(1, arrHighScores(i).name)
                FileSystem.Input(1, arrHighScores(i).score)
                lstLeaderboard.Items.Add($"{arrHighScores(i).name}: {arrHighScores(i).score}")
                i += 1
            End While

            FileSystem.FileClose(1)
        Else
            'Informs the user if there are no scores to display.
            lstLeaderboard.Items.Add("Win a game to initiate the leaderboard!")
        End If
    End Sub

End Class
