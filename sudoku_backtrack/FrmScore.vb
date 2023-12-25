Imports System.IO
Public Class FrmScore

    Private Sub btnTutup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTutup.Click
        Me.Dispose()
    End Sub

    Private Sub FrmScore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fs As FileStream
        Dim freader As StreamReader
        Dim isi As String
        Dim sp() As String
        Dim spr(1) As Char
        Dim no As Integer = 0
        spr(0) = ";"
        fs = New FileStream(Application.StartupPath + "\record.txt", FileMode.Open)
        freader = New StreamReader(fs)
        While Not freader.EndOfStream
            isi = freader.ReadLine
            no += 1
            sp = isi.Split(spr)
            dgvScore.Rows.Add()
            dgvScore.Rows(no - 1).Cells(0).Value = no.ToString()
            dgvScore.Rows(no - 1).Cells(1).Value = sp(0)
            dgvScore.Rows(no - 1).Cells(2).Value = sp(1)
            dgvScore.Rows(no - 1).Cells(3).Value = sp(2)
        End While

    End Sub
End Class