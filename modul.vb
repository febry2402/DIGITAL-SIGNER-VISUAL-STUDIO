Imports System.Data.OleDb
Module modul
    Dim Hitung As Integer = 0

    Dim conn As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As DataSet
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader

    Sub koneksidb()
        conn = New OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb;persist security info = true;jet OLEDB:Database password=gakbolehtau;")
        conn.Open()
    End Sub
End Module
