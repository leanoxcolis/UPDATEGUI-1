
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Data
Module Connector
    Public conn As MySqlConnection
    Public command As New MySqlCommand
    Public reader As MySqlDataReader
    Public query As String
    Public Sub Connect()
        Try
            conn = New MySqlConnection With {
            .ConnectionString = "server=127.0.0.1;userid=root;password='';database=ultrasonic_data"
            }

            conn.Open()

        Catch ex As Exception
            MessageBox.Show("ERROR" & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module