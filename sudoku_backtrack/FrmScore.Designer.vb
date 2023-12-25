<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScore
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
        Me.dgvScore = New System.Windows.Forms.DataGridView
        Me.btnTutup = New System.Windows.Forms.Button
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NmPlayer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Waktu = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JHint = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgvScore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvScore
        '
        Me.dgvScore.AllowUserToAddRows = False
        Me.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvScore.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.NmPlayer, Me.Waktu, Me.JHint})
        Me.dgvScore.Location = New System.Drawing.Point(1, 41)
        Me.dgvScore.Name = "dgvScore"
        Me.dgvScore.Size = New System.Drawing.Size(443, 184)
        Me.dgvScore.TabIndex = 0
        '
        'btnTutup
        '
        Me.btnTutup.Location = New System.Drawing.Point(314, 231)
        Me.btnTutup.Name = "btnTutup"
        Me.btnTutup.Size = New System.Drawing.Size(111, 32)
        Me.btnTutup.TabIndex = 1
        Me.btnTutup.Text = "Tutup"
        Me.btnTutup.UseVisualStyleBackColor = True
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        '
        'NmPlayer
        '
        Me.NmPlayer.HeaderText = "Nama Player"
        Me.NmPlayer.Name = "NmPlayer"
        '
        'Waktu
        '
        Me.Waktu.HeaderText = "Waktu"
        Me.Waktu.Name = "Waktu"
        '
        'JHint
        '
        Me.JHint.HeaderText = "Jumlah Hint"
        Me.JHint.Name = "JHint"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Player Record"
        '
        'FrmScore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(449, 267)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTutup)
        Me.Controls.Add(Me.dgvScore)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmScore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Score"
        CType(Me.dgvScore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvScore As System.Windows.Forms.DataGridView
    Friend WithEvents btnTutup As System.Windows.Forms.Button
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NmPlayer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Waktu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JHint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
