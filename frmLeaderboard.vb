Imports Microsoft.VisualBasic.FileSystem
Imports System.IO
Public Class frmLeaderboard

    Public Structure recHighScore
        Public name As String
        Public score As String
    End Structure

    Dim arrHighScores(6) As recHighScore

    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadLB()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Hide()
    End Sub

    Public Sub loadLB()
        Dim filepath As String = Application.StartupPath() & "\lb.txt"

        If File.Exists(filepath) Then
            FileSystem.FileOpen(1, filepath, OpenMode.Input)

            Dim i As Integer = 1
            While Not EOF(1)
                FileSystem.Input(1, arrHighScores(i).name)
                    FileSystem.Input(1, arrHighScores(i).score)
                    lstLeaderboard.Items.Add($"{arrHighScores(i).name}: {arrHighScores(i).score}")
                    i += 1
            End While

            FileSystem.FileClose(1)
        Else
            lstLeaderboard.Items.Add("Win a game to initiate the leaderboard!")
        End If
    End Sub

End Class
