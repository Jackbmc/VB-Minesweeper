Imports System.IO

Public Class frmLeaderboard
    Private Sub frmLeaderboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 1 To 2
            lstLeaderboard.Items.Clear()
            loadLB()
        Next i
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        frmMain.Show()
        Me.Hide()
    End Sub


    Private Sub loadLB()
        Dim filepath As String = "lb.txt"

        If File.Exists(filepath) Then
            Using sr As StreamReader = New StreamReader(filepath)
                While Not sr.EndOfStream
                    Dim line As String = sr.ReadLine()
                    Dim parts() As String = line.Split(","c)
                    Dim name As String = parts(0)
                    Dim time As String = parts(1)
                    lstLeaderboard.Items.Add($"{name}: {time}")
                End While
            End Using
        Else
            lstLeaderboard.Items.Add("Win a game to initiate the leaderboard!")
        End If
    End Sub
End Class