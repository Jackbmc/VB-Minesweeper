﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.btnLeaderboard = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblDisclaimer = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlGrid
        '
        Me.pnlGrid.Location = New System.Drawing.Point(105, 227)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(500, 500)
        Me.pnlGrid.TabIndex = 5
        '
        'btnLeaderboard
        '
        Me.btnLeaderboard.Font = New System.Drawing.Font("Unispace", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnLeaderboard.Location = New System.Drawing.Point(499, 809)
        Me.btnLeaderboard.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLeaderboard.Name = "btnLeaderboard"
        Me.btnLeaderboard.Size = New System.Drawing.Size(171, 31)
        Me.btnLeaderboard.TabIndex = 6
        Me.btnLeaderboard.Text = "Leaderboard"
        Me.btnLeaderboard.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Unispace", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtName.Location = New System.Drawing.Point(54, 153)
        Me.txtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.PlaceholderText = "Name"
        Me.txtName.Size = New System.Drawing.Size(114, 31)
        Me.txtName.TabIndex = 7
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Unispace", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnStart.Location = New System.Drawing.Point(270, 153)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(132, 31)
        Me.btnStart.TabIndex = 8
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Unispace", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTime.Location = New System.Drawing.Point(499, 158)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(106, 24)
        Me.lblTime.TabIndex = 9
        Me.lblTime.Text = "00:00:00"
        '
        'lblDisclaimer
        '
        Me.lblDisclaimer.AutoSize = True
        Me.lblDisclaimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblDisclaimer.Location = New System.Drawing.Point(211, 209)
        Me.lblDisclaimer.Name = "lblDisclaimer"
        Me.lblDisclaimer.Size = New System.Drawing.Size(0, 25)
        Me.lblDisclaimer.TabIndex = 12
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Unispace", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(111, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(437, 72)
        Me.lblTitle.TabIndex = 13
        Me.lblTitle.Text = "MINESWEEPER"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Unispace", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btnHelp.Location = New System.Drawing.Point(641, 13)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(29, 33)
        Me.btnHelp.TabIndex = 14
        Me.btnHelp.Text = "?"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 853)
        Me.Controls.Add(Me.btnLeaderboard)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDisclaimer)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.pnlGrid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMain"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlGrid As Panel
    Friend WithEvents btnLeaderboard As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDisclaimer As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents trkGridWidth As TrackBar
    Friend WithEvents trkGridHeight As TrackBar
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnHelp As Button
End Class
