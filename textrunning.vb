Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Public Class textrunning
    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Public str As String

    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(Str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Sub carikode()
        cmd = New OleDbCommand("select * from tbl_runtext where nourut='" & textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub


    'menampilkan tombol EDIT dan HAPUS

      

    Sub panggildata()
        Call koneksidb()
        Call carikode()

        textbox1.Text = dr.Item("nourut")
        GunaComboBox1.Text = dr.Item("Speed")
        textbox2.Text = dr.Item("TextRunning")
    End Sub

    Private Sub textrunning_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksidb()
        Call carikode()
        Call panggildata()

       
    End Sub

  

    Private Sub GunaButton1_Click_1(sender As Object, e As EventArgs) Handles GunaButton1.Click
        If textbox1.Text = "" Or textbox2.Text = "" Or GunaComboBox1.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call carikode()
            If dr.HasRows Then
                Dim EDIT As String = "UPDATE tbl_runtext SET TextRunning='" & textbox2.Text & "', Speed='" & GunaComboBox1.Text & "' where nourut='" & textbox1.Text & "'"
                cmd = New OleDbCommand(EDIT, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Informasi")


            End If
        End If
    End Sub
End Class


