Imports System.IO

Public Class FrmMenuUtama

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Dim respon As DialogResult
        respon = MessageBox.Show("Apakah Anda yakin akan menutup aplikasi ini?", "Konfirmasi Tutup", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respon = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub btnMulai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMulai.Click
        Dim fgame As New FrmGame
        Dim nama As String
        nama = InputBox("Nama Pemain:", "Masukkan Nama Anda", "Anonymous")
        fgame.setNamaPlayer(nama)
        fgame.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fscore As New FrmScore
        fscore.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTentang.Click
   
    End Sub
End Class