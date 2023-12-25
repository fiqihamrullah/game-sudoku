Public Class FrmGame
    Dim awalx As Integer, akhirx As Integer
    Dim awaly As Integer, akhiry As Integer
    Dim renggangx As Integer
    Dim renggangy As Integer
    Dim lstsoal(9, 9) As Integer
    Dim selesai As Boolean
    Private Structure SudokuPoint
        Dim row As Integer
        Dim col As Integer
    End Structure
    Dim cp As SudokuPoint
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
                If (lstsoal(i, j) = 0) Then
                    g.DrawString(lstsoal(i, j), New Font("verdana", 14, FontStyle.Bold), Brushes.BlueViolet, (awalx + (j * renggangx)) + renggangx / 3, (awaly + (i * renggangy) + renggangy / 3))
                Else
                    g.DrawString(lstsoal(i, j), New Font("verdana", 14, FontStyle.Bold), Brushes.Tomato, (awalx + (j * renggangx)) + renggangx / 3, (awaly + (i * renggangy) + renggangy / 3))
                End If
            Next
        Next
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
            MessageBox.Show("Selesai")
            Exit Sub

        End If

        If (lstsoal(row, col) <> 0 And selesai = False) Then
            nextSolve(row, col)
        Else

            For num = 1 To 9

                If (checkRow(row, num) And checkCol(col, num) And checkBox(row, col, num)) Then
                    lstsoal(row, col) = num

                    Me.Invalidate()
                    Threading.Thread.Sleep(10)
                    Application.DoEvents()

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

    Private Sub FrmGame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        FrmInputSoal.ShowDialog(Me)
        lstsoal(cp.row - 1, cp.col - 1) = CInt(FrmInputSoal.txtSoal.Text)
        Me.Refresh()
    End Sub

    Private Sub FrmGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
    End Sub

    Private Sub FrmGame_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim i As Integer, j As Integer
        Dim g As Graphics
        awalx = 160
        akhirx = Me.Width - 200
        awaly = 48
        akhiry = Me.Height - 55
        renggangx = (akhirx - awalx) / 9
        renggangy = (akhiry - awaly) / 9
        g = e.Graphics
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
        cp = GetSudokuPoint(e.X, e.Y)
        Me.Text = "Colom : " + cp.col.ToString() + " ,Baris : " + cp.row.ToString()
    End Sub

    Private Sub btnCariSolusi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariSolusi.Click
        selesai = False
        solve(0, 0)
    End Sub

    Private Sub btnStartGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartGame.Click
        Dim jsoal As Integer
        Dim cjsoal As Integer = 0
        Dim poscol, posrow As Integer

        jsoal = 12
        Dim randomgen As New Random
        Dim soal As Integer
        While cjsoal < jsoal
            poscol = randomgen.Next(0, 9)
            posrow = randomgen.Next(0, 9)
            soal = randomgen.Next(1, 10)
            If (soal <> 0) Then
                If (checkRow(posrow, soal) And checkCol(poscol, soal) And checkBox(posrow, poscol, soal)) Then
                    lstsoal(posrow, poscol) = soal
                    cjsoal += 1

                End If
            End If
        End While
        Me.Invalidate()
        btnStartGame.Enabled = False
    End Sub
End Class