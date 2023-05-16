<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeaderboard
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
        Me.lstLeaderboard = New System.Windows.Forms.ListBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblLBTitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstLeaderboard
        '
        Me.lstLeaderboard.BackColor = System.Drawing.SystemColors.Control
        Me.lstLeaderboard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstLeaderboard.Font = New System.Drawing.Font("Bauhaus 93", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lstLeaderboard.FormattingEnabled = True
        Me.lstLeaderboard.ItemHeight = 39
        Me.lstLeaderboard.Location = New System.Drawing.Point(56, 130)
        Me.lstLeaderboard.Name = "lstLeaderboard"
        Me.lstLeaderboard.Size = New System.Drawing.Size(433, 468)
        Me.lstLeaderboard.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Bauhaus 93", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnBack.Location = New System.Drawing.Point(447, 676)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblLBTitle
        '
        Me.lblLBTitle.AutoSize = True
        Me.lblLBTitle.Font = New System.Drawing.Font("Bauhaus 93", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblLBTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblLBTitle.Location = New System.Drawing.Point(100, 9)
        Me.lblLBTitle.Name = "lblLBTitle"
        Me.lblLBTitle.Size = New System.Drawing.Size(343, 54)
        Me.lblLBTitle.TabIndex = 2
        Me.lblLBTitle.Text = "LEADERBOARD"
        '
        'frmLeaderboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(534, 711)
        Me.Controls.Add(Me.lblLBTitle)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lstLeaderboard)
        Me.Name = "frmLeaderboard"
        Me.Text = "Leaderboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstLeaderboard As ListBox
    Friend WithEvents btnBack As Button
    Friend WithEvents lblLBTitle As Label
End Class
