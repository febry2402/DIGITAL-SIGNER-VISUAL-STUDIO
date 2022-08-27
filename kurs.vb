Imports System.Data.OleDb
Imports System.IO
Public Class kurs
    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Public str As String
    ' tampil grid
    Sub TampilGrid()
        da = New OleDbDataAdapter("select * from tbl_kurs", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True
    End Sub
    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(Str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    'sub rapih grid
    Sub grid()
        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 1200
        'text header
        Me.DataGridView1.Columns(0).HeaderText = "No"
        Me.DataGridView1.Columns(1).HeaderText = "Mata Uang"

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
    Sub kosongkan()

        textbox2.Clear()
        textbox3.Clear()
        textbox4.Clear()

        textbox7.Clear()
        textbox7.Enabled = False
    End Sub
   


    Private Sub GunaTransfarantPictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        On Error Resume Next
        OpenFileDialog1.ShowDialog()
        textbox7.Text = OpenFileDialog1.FileName
        PictureBox1.Load(textbox7.Text)
        PictureBox1.SizeMode = PictureBoxSizeMode.Normal
    End Sub
    'menampilkan foto
    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textbox7.TextChanged
        On Error Resume Next
        Call koneksidb()
        Call NamaKurs()

    End Sub
    Sub NamaKurs()
        Call koneksidb()
        cmd = New OleDbCommand("select * from tbl_kurs where KursUrut='" & textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub



    Private Sub kurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksidb()
        Call TampilGrid()
        Call kosongkan()
        Call grid()

        textbox7.Enabled = False



      


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call koneksidb()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        cmd = New OleDbCommand("Select * from tbl_kurs where KursUrut='" & DataGridView1.Item(0, i).Value & "'", conn)

        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then

            textbox2.Focus()
            PictureBox1.Load(textbox7.Text)
        Else
            textbox1.Text = dr.Item("KursUrut")
            textbox2.Text = dr.Item("KursNama")
            textbox3.Text = dr.Item("KursTTJual")
            textbox4.Text = dr.Item("KursTTBeli")
            textbox7.Text = dr.Item("KursBendera")

            PictureBox1.Load(textbox7.Text)
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal



            'menampilkan tombol EDIT dan HAPUS

        End If
    End Sub
   
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

 
  

    Private Sub GunaButton3_Click(sender As Object, e As EventArgs) Handles GunaButton3.Click
        Call kosongkan()
    End Sub

    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        Call koneksidb()

        If textbox1.Text = "" Then
            MsgBox("Nama Kurs Wajib di isi")
            Exit Sub
        Else
            Call NamaKurs()
            If dr.HasRows Then
                Dim EDIT As String = "UPDATE tbl_kurs SET KursNama='" & textbox2.Text & "',KursTTJual='" & textbox3.Text & "',KursTTBeli='" & textbox4.Text & "',KursBendera='" & textbox7.Text & "' where KursUrut='" & textbox1.Text & "'"
                cmd = New OleDbCommand(EDIT, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Informasi")
                Call TampilGrid()


            End If

        End If

    End Sub

End Class