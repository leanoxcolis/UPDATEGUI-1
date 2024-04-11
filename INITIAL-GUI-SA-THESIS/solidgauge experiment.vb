Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class solidgauge_experiment


    Private Sub Gauge360Example()
        SolidGauge100.Uses360Mode = False
        SolidGauge100.From = 0
        SolidGauge100.To = 200
        SolidGauge100.Value = GetCurrentPercentage1()
    End Sub

    Public Function GetCurrentPercentage1() As Integer
        Dim milliLiter As Integer = 0
        Try
            Connect()
            Dim query As String = "SELECT milliLiter FROM ultrasonic_data WHERE device = 'TREE-01'"
            command = New MySqlCommand(query, conn)
            Dim reader = command.ExecuteReader()

            While reader.Read()
                query = "SELECT milliLiter FROM ultrasonic_data WHERE device = 'TREE-01'"
                milliLiter = Convert.ToInt32(reader("milliLiter"))
            End While
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
        Return milliLiter
    End Function


    Private Sub solidgauge_experiment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Gauge360Example()
        GetCurrentPercentage1()
    End Sub



End Class
