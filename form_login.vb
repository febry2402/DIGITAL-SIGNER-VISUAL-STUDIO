Imports System.Data.OleDb
Public Class form_login
    Dim Hitung As Integer = 0

    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Public str As String

    Private Sub form_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksidb()
        Me.Refresh()
        Signage_Viewer.Refresh()

    End Sub
    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(Str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Sub Kosongkan()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksidb()
        cmd = New OleDbCommand("select * from login where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            MsgBox("Login gagal")
            Hitung = Hitung + 1
            If Hitung > 2 Then
                End
            End If
            Exit Sub
        Else
            If TextBox2.Text <> dr.Item("password") Then
                MsgBox("password salah")
                TextBox1.Focus()
                Call Kosongkan()
                Exit Sub
            End If
            Me.Visible = False
            Form1.Show()
        End If
    End Sub

    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        aktivasi.Show()

    End Sub
End Class