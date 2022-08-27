Imports System.Data.OleDb

Public Class aktivasi
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

    Sub koneksidb()
        Str = "provider=microsoft.ace.oledb.12.0;data source=db_signage.accdb ;persist security info = true;jet OLEDB:Database password=gakbolehtau;"
        conn = New OleDbConnection(Str)
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Private Sub aktivasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SerialTextBox_TextChanged(sender As Object, e As EventArgs) Handles SerialTextBox.TextChanged
        SerialTextBox.Text = "0330"
    End Sub
End Class