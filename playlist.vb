Imports System.Data.OleDb
Imports System.IO
Public Class playlist
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
    'tampil grid
    Sub TampilGrid()
        da = New OleDbDataAdapter("select * from playlist", conn)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.ReadOnly = True

    End Sub

    Private Sub playlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Call koneksidb()
        Call TampilGrid()
        Call awal()
        Call grid()

    End Sub
    Sub kosongkan()
        textbox1.Clear()
        textbox2.Clear()

    End Sub
    Sub carikode()
        cmd = New OleDbCommand("select * from playlist where linkvideo='" & textbox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub
    Sub grid()
        Me.DataGridView1.Columns(0).Width = 70
        Me.DataGridView1.Columns(1).Width = 1200
        'text header
        Me.DataGridView1.Columns(0).HeaderText = "No"
        Me.DataGridView1.Columns(1).HeaderText = "Link Video"

        'posisi header
        Me.DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'posisi isi grid
        Me.DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'size font header
        Me.DataGridView1.Columns(0).HeaderCell.Style.Font = New Font("Arial", 18, FontStyle.Bold)
        Me.DataGridView1.Columns(1).HeaderCell.Style.Font = New Font("Arial", 18, FontStyle.Bold)
        'size font isi
        Me.DataGridView1.Columns(0).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        Me.DataGridView1.Columns(1).DefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
        'header tidak bisa di clik
    End Sub
    Private Sub GunaButton6_Click(sender As Object, e As EventArgs) Handles GunaButton6.Click
        If textbox1.Text = "" Or textbox2.Text = "" Then
            MsgBox("HARAP ISI SEMUA DATA TERLEBIH DAHULU !")
            Call kosongkan()
            Exit Sub
        Else
            Call koneksidb()
            cmd = New OleDbCommand("Select * from playlist where nourut='" & textbox2.Text & "'", conn) ' data tidakboleh sama
            dr = cmd.ExecuteReader '------
            dr.Read() '------
            If Not dr.HasRows Then '--------
                Call koneksidb()
                Dim simpan As String = "insert into playlist values ('" & textbox2.Text & "','" & textbox1.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
                Call TampilGrid()
                Call kosongkan()
            Else
                MsgBox("no urut Tidak Boleh Sama")
                dr.Close()

            End If
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        On Error Resume Next
        Dim hapus As String = "delete from playlist where linkvideo='" & textbox1.Text & "'"
        cmd = New OleDbCommand(hapus, conn)
        cmd.ExecuteNonQuery()
        File.Delete(textbox1.Text)
        '=======================
        OpenFileDialog1.Filter = "Audio Video files (*.mp3,*.mp4, *.avi, *.flv) | *.mp3; *.mp4; *.avi; *.flv"
        OpenFileDialog1.ShowDialog()
        textbox1.Text = OpenFileDialog1.FileName
        Me.AxWindowsMediaPlayer1.URL = textbox1.Text
        'textbox1.Text = Application.StartupPath + "\film\" + System.IO.Path.GetFileName(OpenFileDialog1.FileName)
    End Sub
    Sub awal()
        GunaButton6.Enabled = True

        GunaButton1.Enabled = False
        textbox2.Text = "1"
    End Sub
    Sub hapus()
        GunaButton6.Enabled = False

        GunaButton1.Enabled = True
    End Sub

   

  

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
    'hapus
    Private Sub GunaButton1_Click(sender As Object, e As EventArgs) Handles GunaButton1.Click
        Call carikode()
        If Not dr.HasRows Then
            MsgBox("Nama Playlist Tidak Ada")
            Exit Sub
        End If
        If MessageBox.Show("Yakin akan dihapus...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim hapus As String = "delete * from playlist where nourut='" & textbox2.Text & "'"
            cmd = New OleDbCommand(hapus, conn)
            cmd.ExecuteNonQuery()
            textbox1.Enabled = True 'enable textbox1
            Call kosongkan()
            Call TampilGrid()
            Call awal()
        Else
            Call kosongkan()
            Call awal()

        End If
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call koneksidb()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        cmd = New OleDbCommand("Select * from playlist where nourut='" & DataGridView1.Item(0, i).Value & "'", conn)

        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then

            textbox1.Focus()
        Else
            textbox1.Text = dr.Item("linkvideo")
            textbox2.Text = dr.Item("nourut")


            Me.AxWindowsMediaPlayer1.URL = textbox1.Text

            'menampilkan tombol EDIT dan HAPUS

        End If
    End Sub

End Class