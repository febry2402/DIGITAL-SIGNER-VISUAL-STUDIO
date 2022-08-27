Public Class Form1

    Private Sub GunaButton7_Click(sender As Object, e As EventArgs) Handles GunaButton7.Click
        sukubunga.Show()
    End Sub

    Private Sub GunaButton5_Click(sender As Object, e As EventArgs) Handles GunaButton5.Click
        kurs.Show()
    End Sub

    Private Sub GunaButton8_Click(sender As Object, e As EventArgs) Handles GunaButton8.Click
        playlist.Show()

    End Sub

    Private Sub GunaButton4_Click(sender As Object, e As EventArgs) Handles GunaButton4.Click
        profil.Show()

    End Sub

    Private Sub GunaButton9_Click(sender As Object, e As EventArgs) Handles GunaButton9.Click
        textrunning.Show()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        Call koneksidb()

        Me.Refresh()
        Signage_Viewer.Refresh()
        GunaTransfarantPictureBox1.Refresh() ' This works
    End Sub

    Private Sub GunaButton2_Click(sender As Object, e As EventArgs) Handles GunaButton2.Click
        Signage_Viewer.Show()


    End Sub

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs)
        profil.Show()


    End Sub

    Private Sub GunaTransfarantPictureBox2_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox2.Click

    End Sub

End Class
