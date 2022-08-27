Imports System.Data.OleDb
Imports System.Drawing.Configuration


Public Class Signage_Viewer
    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim j As Integer
    Dim redup As Integer = 10
    Dim i As Integer = 0
    Public str As String
    Dim k As Integer




    Sub carikode()
        cmd = New OleDbCommand("select * from tbl_kurs where KursBendera='" & PictureBox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()

    End Sub

    Sub carirunningtext()
        cmd = New OleDbCommand("select * from tbl_runtext where nourut='" & TextBox8.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub


    Sub koneksidb()
        str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb ;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(Str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Private Sub GunaImageButton1_Click(sender As Object, e As EventArgs)

    End Sub
    '----------------------------
    Sub carisukubunga1()
        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut ='" & TextBox3.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub
    '-----------------------------------
    Sub cariprofil()
        cmd = New OleDbCommand("select * from tbl_profil where no ='" & TextBox9.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
    End Sub
    Sub tampil_Produk1()
        '1-------------------------------------------------tampil no 1 sebalah kanan 
        Call koneksidb()
        Call carisukubunga1()
        Dim count As Long

        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut='" & TextBox3.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            count += 1
            GunaLabel5.Text = dr.Item("NamaProduk")
            GunaLabel42.Text = dr.Item("detail_1")
            GunaLabel36.Text = dr.Item("detail_2")
            GunaLabel38.Text = dr.Item("detail_3")
            GunaLabel39.Text = dr.Item("detail_4")
            GunaLabel40.Text = dr.Item("detail_5")
            GunaLabel41.Text = dr.Item("detail_6")

            GunaLabel43.Text = dr.Item("detail_7")
            GunaLabel44.Text = dr.Item("detail_8")
            GunaLabel45.Text = dr.Item("detail_9")
            GunaLabel46.Text = dr.Item("detail_10")
            GunaLabel47.Text = dr.Item("detail_11")
            GunaLabel48.Text = dr.Item("detail_12")
        End If
        '------------------------------------------------------------------------------------
    End Sub
    Sub tampil_produk2()
        '2-------------------------------------------------tampil no 2 sebalah kanan
        Call koneksidb()
        Call carisukubunga1()
        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut='" & TextBox3.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then


            GunaLabel2.Text = dr.Item("NamaProduk")
            GunaLabel26.Text = dr.Item("detail_1")
            GunaLabel23.Text = dr.Item("detail_2")
            GunaLabel24.Text = dr.Item("detail_3")
            GunaLabel25.Text = dr.Item("detail_4")
            GunaLabel27.Text = dr.Item("detail_5")
            GunaLabel28.Text = dr.Item("detail_6")

            GunaLabel29.Text = dr.Item("detail_7")
            GunaLabel30.Text = dr.Item("detail_8")
            GunaLabel31.Text = dr.Item("detail_9")
            GunaLabel32.Text = dr.Item("detail_10")
            GunaLabel33.Text = dr.Item("detail_11")
            GunaLabel34.Text = dr.Item("detail_12")



        End If

    End Sub

    '33333333333333333333333
    Sub tampil_produk3()
        '3-------------------------------------------------tampil no 3 sebalah kanan
        Call koneksidb()
        Call carisukubunga1()
        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut='" & TextBox4.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then


            GunaLabel35.Text = dr.Item("NamaProduk")
            GunaLabel59.Text = dr.Item("detail_1")
            GunaLabel58.Text = dr.Item("detail_2")
            GunaLabel57.Text = dr.Item("detail_3")
            GunaLabel56.Text = dr.Item("detail_4")
            GunaLabel55.Text = dr.Item("detail_5")
            GunaLabel54.Text = dr.Item("detail_6")

            GunaLabel37.Text = dr.Item("detail_7")
            GunaLabel49.Text = dr.Item("detail_8")
            GunaLabel50.Text = dr.Item("detail_9")
            GunaLabel51.Text = dr.Item("detail_10")
            GunaLabel52.Text = dr.Item("detail_11")
            GunaLabel53.Text = dr.Item("detail_12")



        End If

    End Sub
    '44444444444444444444444444444
    Sub tampil_produk4()
        '4-------------------------------------------------tampil no 4 sebalah kanan
        Call koneksidb()
        Call carisukubunga1()
        cmd = New OleDbCommand("select * from tbl_sukubunga where nourut='" & TextBox4.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then


            GunaLabel72.Text = dr.Item("NamaProduk")
            GunaLabel71.Text = dr.Item("detail_1")
            GunaLabel70.Text = dr.Item("detail_2")
            GunaLabel69.Text = dr.Item("detail_3")
            GunaLabel68.Text = dr.Item("detail_4")
            GunaLabel67.Text = dr.Item("detail_5")
            GunaLabel66.Text = dr.Item("detail_6")

            GunaLabel60.Text = dr.Item("detail_7")
            GunaLabel61.Text = dr.Item("detail_8")
            GunaLabel62.Text = dr.Item("detail_9")
            GunaLabel63.Text = dr.Item("detail_10")
            GunaLabel64.Text = dr.Item("detail_11")
            GunaLabel65.Text = dr.Item("detail_12")



        End If

    End Sub
    '--------------------------------------


    Sub kurs1()
        'textbox 1 kurs-----------------------------------------------------
        Call koneksidb()

        cmd = New OleDbCommand("select * from tbl_kurs where KursUrut='" & TextBox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GunaLabel6.Text = dr.Item("KursTTJual")
            GunaLabel7.Text = dr.Item("KursTTBeli")
            PictureBox1.ImageLocation = dr.Item("KursBendera")
            PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        End If
        '------------------------------------------------------------------------
    End Sub

    Sub kurs2()
        'textbox 2 kurs-----------------------------------------------------
        Call koneksidb()

        cmd = New OleDbCommand("select * from tbl_kurs where KursUrut='" & TextBox1.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GunaLabel22.Text = dr.Item("KursTTJual")
            GunaLabel21.Text = dr.Item("KursTTBeli")
            PictureBox2.ImageLocation = dr.Item("KursBendera")
            PictureBox2.SizeMode = PictureBoxSizeMode.Normal
        End If
        '------------------------------------------------------------------------
    End Sub
    Sub kurs3()
        'textbox 2 kurs-----------------------------------------------------
        Call koneksidb()

        cmd = New OleDbCommand("select * from tbl_kurs where KursUrut='" & TextBox2.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GunaLabel20.Text = dr.Item("KursTTJual")
            GunaLabel19.Text = dr.Item("KursTTBeli")
            PictureBox3.ImageLocation = dr.Item("KursBendera")
            PictureBox3.SizeMode = PictureBoxSizeMode.Normal
        End If
        '------------------------------------------------------------------------
    End Sub
    Sub kurs4()
        'textbox 2 kurs-----------------------------------------------------
        Call koneksidb()

        cmd = New OleDbCommand("select * from tbl_kurs where KursUrut='" & TextBox2.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GunaLabel8.Text = dr.Item("KursTTJual")
            GunaLabel18.Text = dr.Item("KursTTBeli")
            PictureBox4.ImageLocation = dr.Item("KursBendera")
            PictureBox4.SizeMode = PictureBoxSizeMode.Normal
        End If
        '------------------------------------------------------------------------
    End Sub

    Private Sub Signage_Viewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load









        '--------------------
        Me.Refresh()
        Call koneksidb()
        Call carikode()
        'produk1---------------------------
        Call tampil_Produk1()
        Call tampil_produk2()
        TextBox3.Refresh()
        deposito.Start()

        'produk 2
        Call tampil_produk3()
        Call tampil_produk4()
        TextBox4.Refresh()
        produk2.Start()

        '--------------------------kurs
        Call kurs1()
        Call kurs2()

        kurs.Start()
        kurs_2.Start()
        TextBox1.Refresh()

        '------------
        Call kurs3()
        Call kurs4()
        TextBox2.Refresh()

        'llooping
        AxWindowsMediaPlayer1.settings.setMode("loop", True)

        runningtext.Enabled = True
        runningtext.Interval = 100
        'resolusi 


        '-------------------------------
        Timer1.Start()


        jam.Refresh()
        tanggal.Text = Format(Now, "dd-MMM-yyyy")
        hari.Text = Format(Now, "dddd")



        '-------------------------------------- PROFIL PERUSAHAAN
        Call koneksidb()
        Call cariprofil()
        cmd = New OleDbCommand("select * from tbl_profil where nourut='" & TextBox9.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            GunaLabel11.Text = dr.Item("NamaPerusahaan")
        End If

        '---------------------------------------

        '----------------
        'running
        Timer1.Enabled = True
        Call carirunningtext()

        cmd = New OleDbCommand("select * from tbl_runtext where nourut='" & TextBox8.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            textberjalan.Text = dr.Item("TextRunning")
            j = dr.Item("Speed")
        End If




        'mediaplayer kurs-----------------------------------------------------
        cmd = New OleDbCommand("select * from playlist where nourut='" & TextBox7.Text & "'", conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            AxWindowsMediaPlayer1.URL = dr.Item("linkvideo")
            AxWindowsMediaPlayer1.Ctlcontrols.play()



        End If
        '------------------------------------------------------------------------


        '-----------------------------------------------------------------------------------



        runningtext.Start()




    End Sub
    Private tabSwitcher2 As Boolean = True
    Private Sub kurs_Tick(sender As Object, e As EventArgs) Handles kurs.Tick
        On Error Resume Next

        deposito.Interval = 10000
        If tabSwitcher = True Then
            TextBox1.Text = "1"

        Else
            TextBox1.Text = "2"
        End If
        tabSwitcher2 = Not tabSwitcher2
    End Sub

    Private tabSwitcher3 As Boolean = True
    Private Sub produk2_Tick(sender As Object, e As EventArgs) Handles produk2.Tick
        On Error Resume Next

        deposito.Interval = 10000
        If tabSwitcher = True Then
            TextBox4.Text = "3"

        Else
            TextBox4.Text = "4"
        End If
        tabSwitcher3 = Not tabSwitcher3
    End Sub

    Private tabSwitcher As Boolean = True
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles deposito.Tick
        On Error Resume Next

        deposito.Interval = 10000
        If tabSwitcher = True Then
            TextBox3.Text = "1"

        Else
            TextBox3.Text = "2"
        End If
        tabSwitcher = Not tabSwitcher

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        jam.Text = Format(Now, "HH:mm:ss")

    End Sub




    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        On Error Resume Next
        Call tampil_Produk1()
        Call tampil_produk2()
        TextBox3.Refresh()
    End Sub
    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        On Error Resume Next
        Call tampil_produk3()
        Call tampil_produk4()
        TextBox4.Refresh()
    End Sub

    'kurs
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        Call kurs1()
        Call kurs2()
        TextBox1.Refresh()
    End Sub

    'text running
    Private Sub runningtext_Tick(sender As Object, e As EventArgs) Handles runningtext.Tick


        If (textberjalan.Left + textberjalan.Width <= 0) Then
            textberjalan.Left = Me.Width
        End If
        textberjalan.Left = textberjalan.Left - j

    End Sub



    Private Sub AxWindowsMediaPlayer1_Enter_1(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter
        'AxWindowsMediaPlayer1.settings.setMode("loop", True)
    End Sub





    'kurs timer


   
    Private Sub GunaCirclePictureBox1_Click(sender As Object, e As EventArgs)
        Call koneksidb()
        Call carikode()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GunaGradient2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles GunaGradient2Panel2.Paint

    End Sub

   
   
    'kurs 2
    Private Sub kurs_2_Tick(sender As Object, e As EventArgs) Handles kurs_2.Tick
        On Error Resume Next

        deposito.Interval = 10000
        If tabSwitcher = True Then
            TextBox2.Text = "3"

        Else
            TextBox2.Text = "4"
        End If
        tabSwitcher2 = Not tabSwitcher2
    End Sub

  
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        On Error Resume Next
        Call kurs3()
        Call kurs4()
        TextBox1.Refresh()
    End Sub

    Private Sub GunaLabel11_Click(sender As Object, e As EventArgs) Handles GunaLabel11.Click
       
    End Sub

    Private Sub GunaTransfarantPictureBox1_Click(sender As Object, e As EventArgs) Handles GunaTransfarantPictureBox1.Click
        Form1.Show()
    End Sub
End Class