Imports System.Data.OleDb
Imports System.IO
Public Class sukubunga

    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Public str As String
    ' tampil grid
    Sub TampilGrid()
        da = New OleDbDataAdapter("select * from tbl_sukubunga", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub
    'kolom grid
    Sub colom_grid()
        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 900
        Me.DataGridView1.Columns(2).Width = 0
        Me.DataGridView1.Columns(3).Width = 0
        Me.DataGridView1.Columns(4).Width = 0
        Me.DataGridView1.Columns(5).Width = 0
        Me.DataGridView1.Columns(6).Width = 0
        Me.DataGridView1.Columns(7).Width = 0
        Me.DataGridView1.Columns(8).Width = 0
        Me.DataGridView1.Columns(9).Width = 0
        Me.DataGridView1.Columns(10).Width = 0
        Me.DataGridView1.Columns(11).Width = 0
        Me.DataGridView1.Columns(12).Width = 0
        Me.DataGridView1.Columns(13).Width = 0


        'text header
        Me.DataGridView1.Columns(0).HeaderText = "No"
        Me.DataGridView1.Columns(1).HeaderText = "Nama Produk"

        'posisi header
        Me.DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'posisi isi grid
        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'size font header
        Me.DataGridView1.Columns(0).HeaderCell.Style.Font = New Font("Arial", 18, FontStyle.Bold)
        Me.DataGridView1.Columns(1).HeaderCell.Style.Font = New Font("Arial", 18, FontStyle.Bold)
        'size font isi
        Me.DataGridView1.Columns(0).DefaultCellStyle.Font = New Font("Arial", 18, FontStyle.Bold)
        Me.DataGridView1.Columns(1).DefaultCellStyle.Font = New Font("Arial", 18, FontStyle.Bold)
        'header tidak bisa di clik

    End Sub
    'fokus textbox
    Sub fokus()
        textbox2.Focus()

    End Sub

    'cari kode
    Sub carikode()
        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut='" & textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub
    '------------------------------------------------------------KONEKSI DATABASE ACCESS
    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Sub awal()
        textbox1.Focus()
    End Sub
    'textbox 1-14 
    Sub kosongkan()

        textbox2.Clear()
        textbox3.Clear()
        textbox4.Clear()
        textbox5.Clear()
        textbox6.Clear()
        textbox7.Clear()
        textbox8.Clear()
        textbox9.Clear()
        textbox10.Clear()
        textbox11.Clear()
        textbox12.Clear()
        textbox13.Clear()
        textbox14.Clear()
    End Sub
    Private Sub sukubunga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksidb()
        Call TampilGrid()
        Call colom_grid()

        Call awal()
        textbox1.Enabled = False


    End Sub
    'simpan
    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        If textbox1.Text = "" Or textbox2.Text = "" Then
            MsgBox("Nama Produk Wajib di isi")
            Exit Sub
        Else
            Call carikode()
            If dr.HasRows Then
                Dim EDIT As String = "UPDATE tbl_sukubunga SET NamaProduk='" & textbox2.Text & "',detail_1='" & textbox3.Text & "',detail_2='" & textbox4.Text & "',detail_3='" & textbox5.Text & "',detail_4='" & textbox6.Text & "',detail_5='" & textbox7.Text & "',detail_6='" & textbox8.Text & "',detail_7='" & textbox9.Text & "',detail_8='" & textbox10.Text & "',detail_9='" & textbox11.Text & "',detail_10='" & textbox12.Text & "',detail_11='" & textbox13.Text & "',detail_12='" & textbox14.Text & "' where nourut='" & textbox1.Text & "'"
                cmd = New OleDbCommand(EDIT, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Informasi")
                Call TampilGrid()

            End If


        End If

    End Sub


    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Call kosongkan()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call koneksidb()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        cmd = New OleDbCommand("Select * from tbl_sukubunga  where nourut='" & DataGridView1.Item(0, i).Value & "'", conn)

        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then

            textbox1.Focus()
        Else
            textbox1.Text = dr.Item("nourut")
            textbox2.Text = dr.Item("NamaProduk")
            textbox3.Text = dr.Item("detail_1")
            textbox4.Text = dr.Item("detail_2")
            textbox5.Text = dr.Item("detail_3")
            textbox6.Text = dr.Item("detail_4")
            textbox7.Text = dr.Item("detail_5")
            textbox8.Text = dr.Item("detail_6")
            textbox9.Text = dr.Item("detail_7")
            textbox10.Text = dr.Item("detail_8")
            textbox11.Text = dr.Item("detail_9")
            textbox12.Text = dr.Item("detail_10")
            textbox13.Text = dr.Item("detail_11")
            textbox14.Text = dr.Item("detail_12")





            'menampilkan tombol EDIT dan HAPUS

        End If
    End Sub


End Class