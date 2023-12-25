<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGame
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnSolve = New System.Windows.Forms.Button
        Me.btnStartGame = New System.Windows.Forms.Button
        Me.btnCariSolusi = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblwaktu = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnSolve)
        Me.Panel1.Controls.Add(Me.btnStartGame)
        Me.Panel1.Controls.Add(Me.btnCariSolusi)
        Me.Panel1.Location = New System.Drawing.Point(688, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(168, 511)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gisha", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(32, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "F1 - Hint"
        '
        'BtnSolve
        '
        Me.BtnSolve.Enabled = False
        Me.BtnSolve.Location = New System.Drawing.Point(22, 146)
        Me.BtnSolve.Name = "BtnSolve"
        Me.BtnSolve.Size = New System.Drawing.Size(130, 48)
        Me.BtnSolve.TabIndex = 2
        Me.BtnSolve.Text = "Solve"
        Me.BtnSolve.UseVisualStyleBackColor = True
        '
        'btnStartGame
        '
        Me.btnStartGame.Location = New System.Drawing.Point(22, 87)
        Me.btnStartGame.Name = "btnStartGame"
        Me.btnStartGame.Size = New System.Drawing.Size(132, 48)
        Me.btnStartGame.TabIndex = 1
        Me.btnStartGame.Text = "Mulai Permainan"
        Me.btnStartGame.UseVisualStyleBackColor = True
        '
        'btnCariSolusi
        '
        Me.btnCariSolusi.Location = New System.Drawing.Point(22, 146)
        Me.btnCariSolusi.Name = "btnCariSolusi"
        Me.btnCariSolusi.Size = New System.Drawing.Size(132, 49)
        Me.btnCariSolusi.TabIndex = 0
        Me.btnCariSolusi.Text = "Cari Solusi"
        Me.btnCariSolusi.UseVisualStyleBackColor = True
        Me.btnCariSolusi.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblwaktu)
        Me.Panel2.Location = New System.Drawing.Point(-1, -6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(153, 517)
        Me.Panel2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Waktu:"
        '
        'lblwaktu
        '
        Me.lblwaktu.BackColor = System.Drawing.Color.YellowGreen
        Me.lblwaktu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblwaktu.Font = New System.Drawing.Font("Mangal", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblwaktu.ForeColor = System.Drawing.Color.Maroon
        Me.lblwaktu.Location = New System.Drawing.Point(-9, 87)
        Me.lblwaktu.Name = "lblwaktu"
        Me.lblwaktu.Size = New System.Drawing.Size(171, 48)
        Me.lblwaktu.TabIndex = 0
        Me.lblwaktu.Text = "00:00"
        Me.lblwaktu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'FrmGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(855, 508)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGame"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anda Bermain Sebagai "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCariSolusi As System.Windows.Forms.Button
    Friend WithEvents btnStartGame As System.Windows.Forms.Button
    Friend WithEvents BtnSolve As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblwaktu As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
