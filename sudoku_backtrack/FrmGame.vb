
Imports System.IO
Public Class FrmGame
    Dim awalx As Integer, akhirx As Integer
    Dim awaly As Integer, akhiry As Integer
    Dim renggangx As Integer
    Dim renggangy As Integer
    Dim lstsoal(9, 9) As Integer
    Dim lstjawab(9, 9) As Integer
    Dim asal(9, 9) As Integer
    Dim selesai As Boolean
    Dim nmplayer As String
    Dim tmr As Stopwatch
    Dim mulai As Boolean
    Dim globalx As Integer
    Dim globaly As Integer
    Dim chint As Integer = 0
    Dim bsave As Boolean
    Private Structure SudokuPoint
        Dim row As Integer
        Dim col As Integer
    End Structure
    Dim cp As SudokuPoint
    Public Sub setNamaPlayer(ByVal namapemain As String)
        nmplayer = namapemain
    End Sub
    Private Function GetSudokuPoint(ByVal x As Integer, ByVal y As Integer) As SudokuPoint
        Dim sp As SudokuPoint
        If (renggangx <> 0) Then
            sp.col = ((x - awalx) \ renggangx) + 1
            sp.row = ((y - awaly) \ renggangy) + 1
        Else
            sp.col = 0
            sp.row = 0
        End If
        Return sp
    End Function
    Private Sub DrawText(ByVal g As Graphics)
        Dim i, j As Integer
        For i = 0 To 8
            For j = 0 To 8
                If (lstjawab(i, j) = 0) Then
                    g.DrawString("0", New Font("verdana", 14, FontStyle.Bold), Brushes.BlueViolet, (awalx + (j * renggangx)) + renggangx / 3, (awaly + (i * renggangy) + renggangy / 3))
                Else
                    g.DrawString(lstjawab(i, j), New Font("verdana", 14, FontStyle.Bold), Brushes.Tomato, (awalx + (j * renggangx)) + renggangx / 3, (awaly + (i * renggangy) + renggangy / 3))
                End If
            Next
        Next

        g.DrawString("Colom : " + cp.col.ToString() + " ,Baris : " + cp.row.ToString(), New Font("verdana", 14, FontStyle.Bold), Brushes.Tomato, awalx, awaly - 30)
    End Sub
    Private Function checkRow(ByVal row As Integer, ByVal num As Integer) As Boolean
        Dim col As Integer
        For col = 0 To 8
            If (lstsoal(row, col) = num) Then
                Return False
            End If
        Next col
        Return True
    End Function
    Private Function checkCol(ByVal col As Integer, ByVal num As Integer) As Boolean
        Dim row As Integer
        For row = 0 To 8
            If (lstsoal(row, col) = num) Then
                Return False
            End If
        Next row
        Return True
    End Function
    Private Function checkBox(ByVal row As Integer, ByVal col As Integer, ByVal num As Integer) As Boolean
        Dim r, c As Integer
        row = (row \ 3) * 3
        col = (col \ 3) * 3

        For r = 0 To 2
            For c = 0 To 2
                If (lstsoal(row + r, col + c) = num) Then
                    Return False
                End If
            Next c
        Next r
        Return True
    End Function
    Public Sub nextSolve(ByVal row As Integer, ByVal col As Integer)
        If (col < 8) Then
            solve(row, col + 1)
        Else
            solve(row + 1, 0)
        End If
    End Sub
    Public Sub solve(ByVal row As Integer, ByVal col As Integer)
        Dim num As Integer
        If (row > 8) Then
            selesai = True

            Exit Sub

        End If

        If (lstsoal(row, col) <> 0 And selesai = False) Then
            nextSolve(row, col)
        Else

            For num = 1 To 9

                If (checkRow(row, num) And checkCol(col, num) And checkBox(row, col, num)) Then
                    lstsoal(row, col) = num
                    asal(row, col) = 0
                    lstjawab(row, col) = 0
                    Me.Invalidate()
                    '   Threading.Thread.Sleep(1)
                    '  Application.DoEvents()

                    If (selesai = False) Then
                        nextSolve(row, col)
                    Else
                        Exit For
                    End If
                End If
            Next num


            If selesai = False Then
                lstsoal(row, col) = 0
                Me.Invalidate()
            End If

        End If

    End Sub

    Private Sub FrmGame_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Text = "Anda Bermain Sebagai " + nmplayer
    End Sub

    Private Sub FrmGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click

        'Dim soal As Integer = 0
        'If mulai Then
        '    FrmInputSoal.ShowDialog(Me)
        '    If FrmInputSoal.Text <> "" Then
        '        soal = CInt(FrmInputSoal.txtSoal.Text)
        '    End If
        '    If (checkRow(cp.row - 1, soal) And checkCol(cp.col - 1, soal) And checkBox(cp.row - 1, cp.col - 1, soal)) Then
        '        lstsoal(cp.row - 1, cp.col - 1) = soal
        '    Else
        '        MessageBox.Show("Tidak Berlaku", "Sudah Ada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        '    Me.Invalidate()
        'End If

        cp = GetSudokuPoint(globalx, globaly)
        Invalidate()
    End Sub

    Private Sub FrmGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        mulai = False
        cp.col = 1
        cp.row = 1
        Dim col, row As Integer

        For col = 0 To 8
            For row = 0 To 8
                asal(row, col) = 0
            Next
        Next
    End Sub

    Private Sub FrmGame_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim i As Integer, j As Integer
        Dim col, row As Integer
        Dim g As Graphics
        awalx = 160
        akhirx = Me.Width - 200
        awaly = 48
        akhiry = Me.Height - 55
        renggangx = (akhirx - awalx) / 9
        renggangy = (akhiry - awaly) / 9
        g = e.Graphics

        If (mulai = True) Then
            For row = 0 To 8
                For col = 0 To 8
                    If (asal(row, col) = 1) Then
                        g.FillRectangle(Brushes.Gold, awalx + ((col) * renggangx), awaly + ((row) * renggangy), renggangx, renggangy)
                    End If
                Next col
            Next row


            If (asal(cp.row - 1, cp.col - 1) = 1) Then
                g.FillRectangle(Brushes.MidnightBlue, awalx + ((cp.col - 1) * renggangx), awaly + ((cp.row - 1) * renggangy), renggangx, renggangy)
            Else
                g.FillRectangle(Brushes.LightSkyBlue, awalx + ((cp.col - 1) * renggangx), awaly + ((cp.row - 1) * renggangy), renggangx, renggangy)
            End If

        End If

        Dim posborder As Integer = 0
        For i = awalx To akhirx + renggangx Step renggangx
            If (posborder Mod 3 = 0) Then
                g.DrawLine(New Pen(Color.Olive, 3), i, awaly, i, akhiry)
                posborder = 0
            Else
                g.DrawLine(New Pen(Color.Crimson), i, awaly, i, akhiry)
            End If

            posborder += 1
        Next i
        posborder = 0
        For i = awaly To akhiry Step renggangy
            If (posborder Mod 3 = 0) Then
                g.DrawLine(New Pen(Color.Olive, 3), awalx, i, akhirx, i)
                posborder = 0
            Else
                g.DrawLine(New Pen(Color.Crimson), awalx, i, akhirx, i)
            End If

            posborder += 1
        Next i
        DrawText(g)

    End Sub

    Private Sub FrmGame_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        ' cp = GetSudokuPoint(e.X, e.Y)
        ' Invalidate()
        globalx = e.X
        globaly = e.Y
    End Sub

    Private Sub btnCariSolusi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariSolusi.Click
        selesai = False
        solve(0, 0)
    End Sub
    Public Sub resetSoal()
        Dim i, j As Integer
        For i = 0 To 8
            For j = 0 To 9
                lstsoal(i, j) = 0
            Next j
        Next i
        selesai = False
    End Sub
    Private Function checkBenar() As Boolean
        Dim benar As Boolean = True
        Dim i, j As Integer
        Dim num As Integer
        For i = 0 To 8
            For j = 0 To 8
                num = lstjawab(i, j)
                If checkRow(i, num) And checkCol(j, num) And checkBox(i, j, num) Then
                    benar = False
                    MessageBox.Show(i.ToString() + ";" + j.ToString())
                    Exit For
                End If

            Next
            If benar = False Then
                Exit For
            End If
        Next

        Return benar

    End Function
    Private Sub SimpanRecord(ByVal nmplayer As String, ByVal waktu As String, ByVal hintcount As Integer)
        Dim strfile As String
        Dim mywriter As StreamWriter
        Dim myfile As FileStream
        myfile = New FileStream(Application.StartupPath + "\record.txt", FileMode.Append)
        mywriter = New StreamWriter(myfile)
        mywriter.WriteLine(nmplayer + ";" + waktu + ";" + hintcount.ToString())
        mywriter.Close()
        myfile.Close()
    End Sub
    Private Sub btnStartGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartGame.Click
        Dim jsoal As Integer
        Dim cjsoal As Integer = 0
        Dim poscol, posrow As Integer
        jsoal = 12
        Dim randomgen As New Random
        Dim soal As Integer
        If btnStartGame.Text = "Mulai Permainan" Then

            While cjsoal < jsoal
                poscol = randomgen.Next(0, 9)
                posrow = randomgen.Next(0, 9)
                soal = randomgen.Next(1, 10)
                If (soal <> 0) Then
                    If (checkRow(posrow, soal) And checkCol(poscol, soal) And checkBox(posrow, poscol, soal)) Then
                        lstsoal(posrow, poscol) = soal
                        lstjawab(posrow, poscol) = lstsoal(posrow, poscol)
                        asal(posrow, poscol) = 1
                        cjsoal += 1

                    End If
                End If
            End While
            solve(0, 0)
            Me.Invalidate()
            tmr = New Stopwatch()
            tmr.Start()
            Timer1.Enabled = True
            btnStartGame.Text = "Akhiri Permainan"
            BtnSolve.Enabled = True
            mulai = True
            bsave = True
        Else
            Dim respon As DialogResult
            respon = MessageBox.Show("Apakah Anda yakin akan mengakhiri permainan ini?", "Konfirmasi Keluar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
            If respon = Windows.Forms.DialogResult.OK Then
                If checkBenar() Then
                    If bsave Then
                        SimpanRecord(nmplayer, lblwaktu.Text, chint.ToString)
                    End If
                Else
                    MessageBox.Show("Hasil Permainan Anda Masih Ada Yang Salah!", "Tidak Selesai", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                btnStartGame.Text = "Mulai Permainan"
                BtnSolve.Enabled = False
                Timer1.Enabled = False
                mulai = False
                resetSoal()
                Invalidate()
                tmr.Stop()


                lblwaktu.Text = "00:00:00"
                chint = 0
            End If
        End If
    End Sub

    Public Sub showHint()
        Dim rand As New Random
        Dim num As Integer
        Dim dapat As Boolean = False
        If (asal(cp.row - 1, cp.col - 1) = 2 Or asal(cp.row - 1, cp.col - 1) = 0) Then
            asal(cp.row - 1, cp.col - 1) = 1
            lstjawab(cp.row - 1, cp.col - 1) = lstsoal(cp.row - 1, cp.col - 1)
            Me.Invalidate()

            'While dapat = False
            '    num = rand.Next(1, 10)
            '    '
            '    If (checkRow(cp.row - 1, num) And checkCol(cp.col - 1, num) And checkBox(cp.row - 1, cp.col - 1, num)) Then
            '        lstsoal(cp.row - 1, cp.col - 1) = num
            '        asal(cp.row - 1, cp.col - 1) = False
            '        dapat = True
            '        Me.Invalidate()
            '        Threading.Thread.Sleep(10)
            '        Application.DoEvents()
            '    End If
            'End While
        End If
    End Sub

    Public Sub NextHint()
        Dim row As Integer
        Dim col As Integer
        Dim i, j As Integer
        Dim dapat As Boolean = False
        For i = 0 To 8
            For j = 0 To 8
                If (lstsoal(i, j) = 0) Then
                    row = i
                    col = j
                    dapat = True
                    Exit For
                End If
            Next j
            If dapat = True Then
                Exit For
            End If
        Next i
        '  MessageBox.Show("Row : " + row.ToString + " ,Col :" + col.ToString)
        dapat = False
        While dapat = False
            If lstsoal(row, col) = 0 Then
                For num = 1 To 9
                    If (checkRow(row, num) And checkCol(col, num) And checkBox(row, col, num)) Then
                        lstsoal(row, col) = num
                        dapat = True
                        Me.Invalidate()
                        Threading.Thread.Sleep(10)
                        Application.DoEvents()
                        Exit For
                    End If
                Next num
            End If

            If (col < 8) Then
                col = col + 1
            Else
                row = row + 1
                col = 0
            End If
            If (row = 9) Then
                Exit While
            End If
        End While
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ts As TimeSpan = tmr.Elapsed
        lblwaktu.Text = String.Format("{0:00}m:{1:00}s:{2:00}ms", ts.Minutes.ToString, ts.Seconds.ToString(), ts.Milliseconds.ToString())
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub FrmGame_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If mulai = True Then
            If e.KeyCode = Keys.Right Then
                'Me.Text = "Kanan"
                If (cp.col < 9) Then
                    cp.col = cp.col + 1
                Else
                    cp.col = 1
                End If
            ElseIf e.KeyCode = Keys.Left Then
                ' Me.Text = "Kiri"
                If (cp.col > 1) Then
                    cp.col = cp.col - 1
                Else
                    cp.col = 9
                End If
            ElseIf e.KeyCode = Keys.Up Then
                If (cp.row > 1) Then
                    cp.row = cp.row - 1
                Else
                    cp.row = 9
                End If
            ElseIf e.KeyCode = Keys.Down Then
                If (cp.row < 9) Then
                    cp.row = cp.row + 1
                Else
                    cp.row = 1
                End If
            ElseIf e.KeyCode = Keys.F1 Then
                showHint()
            End If
            Invalidate()
        End If
    End Sub


    Private Sub FrmGame_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If mulai = True Then
            If (asal(cp.row - 1, cp.col - 1) = 2 Or asal(cp.row - 1, cp.col - 1) = 0) Then
                lstjawab(cp.row - 1, cp.col - 1) = Convert.ToInt16(e.KeyChar.ToString)
                asal(cp.row - 1, cp.col - 1) = 2
            End If
        End If
    End Sub

    Private Sub BtnSolve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSolve.Click
        ' solve(0, 0)
        Dim i, j As Integer
        For i = 0 To 8
            For j = 0 To 8
                lstjawab(i, j) = lstsoal(i, j)
                asal(i, j) = 1
                Me.Invalidate()
                Threading.Thread.Sleep(50)
                Application.DoEvents()

            Next
        Next
        'If checkBenar() Then
        MessageBox.Show("Selesai")
        'End If
        bsave = False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class