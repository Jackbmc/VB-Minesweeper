<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gamePanel = New System.Windows.Forms.Panel()
        Me.btnLeaderboard = New System.Windows.Forms.Button()
        Me.usernameTextBox = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.timerLabel = New System.Windows.Forms.Label()
        Me.trkMines = New System.Windows.Forms.TrackBar()
        Me.lblMineCount = New System.Windows.Forms.Label()
        Me.lblDisclaimer = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblMainTitle = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        CType(Me.trkMines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gamePanel
        '
        Me.gamePanel.Location = New System.Drawing.Point(68, 270)
        Me.gamePanel.Name = "gamePanel"
        Me.gamePanel.Size = New System.Drawing.Size(400, 400)
        Me.gamePanel.TabIndex = 5
        '
        'btnLeaderboard
        '
        Me.btnLeaderboard.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnLeaderboard.Location = New System.Drawing.Point(410, 676)
        Me.btnLeaderboard.Name = "btnLeaderboard"
        Me.btnLeaderboard.Size = New System.Drawing.Size(112, 23)
        Me.btnLeaderboard.TabIndex = 6
        Me.btnLeaderboard.Text = "Leaderboard"
        Me.btnLeaderboard.UseVisualStyleBackColor = True
        '
        'usernameTextBox
        '
        Me.usernameTextBox.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.usernameTextBox.Location = New System.Drawing.Point(68, 117)
        Me.usernameTextBox.Name = "usernameTextBox"
        Me.usernameTextBox.PlaceholderText = "Name"
        Me.usernameTextBox.Size = New System.Drawing.Size(100, 31)
        Me.usernameTextBox.TabIndex = 7
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnStart.Location = New System.Drawing.Point(247, 116)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 8
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'timerLabel
        '
        Me.timerLabel.AutoSize = True
        Me.timerLabel.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.timerLabel.Location = New System.Drawing.Point(419, 120)
        Me.timerLabel.Name = "timerLabel"
        Me.timerLabel.Size = New System.Drawing.Size(74, 18)
        Me.timerLabel.TabIndex = 9
        Me.timerLabel.Text = "00:00:00"
        '
        'trkMines
        '
        Me.trkMines.Location = New System.Drawing.Point(68, 175)
        Me.trkMines.Maximum = 50
        Me.trkMines.Minimum = 10
        Me.trkMines.Name = "trkMines"
        Me.trkMines.Size = New System.Drawing.Size(400, 45)
        Me.trkMines.TabIndex = 10
        Me.trkMines.Value = 10
        '
        'lblMineCount
        '
        Me.lblMineCount.AutoSize = True
        Me.lblMineCount.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblMineCount.Location = New System.Drawing.Point(68, 157)
        Me.lblMineCount.Name = "lblMineCount"
        Me.lblMineCount.Size = New System.Drawing.Size(92, 18)
        Me.lblMineCount.TabIndex = 11
        Me.lblMineCount.Text = "Mine Count"
        '
        'lblDisclaimer
        '
        Me.lblDisclaimer.AutoSize = True
        Me.lblDisclaimer.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDisclaimer.Location = New System.Drawing.Point(185, 157)
        Me.lblDisclaimer.Name = "lblDisclaimer"
        Me.lblDisclaimer.Size = New System.Drawing.Size(0, 18)
        Me.lblDisclaimer.TabIndex = 12
        '
        'lblMainTitle
        '
        Me.lblMainTitle.AutoSize = True
        Me.lblMainTitle.Font = New System.Drawing.Font("Bauhaus 93", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblMainTitle.Location = New System.Drawing.Point(121, 9)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(324, 54)
        Me.lblMainTitle.TabIndex = 13
        Me.lblMainTitle.Text = "MINESWEEPER"
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Bauhaus 93", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnHelp.Location = New System.Drawing.Point(497, 9)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(25, 25)
        Me.btnHelp.TabIndex = 14
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 711)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.lblMainTitle)
        Me.Controls.Add(Me.lblDisclaimer)
        Me.Controls.Add(Me.lblMineCount)
        Me.Controls.Add(Me.trkMines)
        Me.Controls.Add(Me.timerLabel)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.usernameTextBox)
        Me.Controls.Add(Me.btnLeaderboard)
        Me.Controls.Add(Me.gamePanel)
        Me.Name = "frmMain"
        Me.Text = "Main"
        CType(Me.trkMines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gamePanel As Panel
    Friend WithEvents btnLeaderboard As Button
    Friend WithEvents usernameTextBox As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents timerLabel As Label
    Friend WithEvents trkMines As TrackBar
    Friend WithEvents lblMineCount As Label
    Friend WithEvents lblDisclaimer As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents trkGridWidth As TrackBar
    Friend WithEvents trkGridHeight As TrackBar
    Friend WithEvents lblMainTitle As Label
    Friend WithEvents btnHelp As Button
End Class
