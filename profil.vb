Imports System.Data.OleDb
Imports System.IO
Public Class profil
    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Public str As String

    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Sub carikode()
        cmd = New OleDbCommand("select * from tbl_profil where nourut='" & TextBox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub
    Sub panggildata()
        Call koneksidb()
        Call carikode()

        textbox1.Text = dr.Item("nourut")
        textbox2.Text = dr.Item("NamaPerusahaan")
    End Sub
    Private Sub profil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksidb()
        Call carikode()
        Call panggildata()


    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If TextBox1.Text = "" Or textbox2.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call carikode()
            If dr.HasRows Then
                Dim EDIT As String = "UPDATE tbl_profil SET NamaPerusahaan='" & textbox2.Text & "' where nourut='" & TextBox1.Text & "'"
                cmd = New OleDbCommand(EDIT, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Informasi")
            End If

        End If

    End Sub
End Class