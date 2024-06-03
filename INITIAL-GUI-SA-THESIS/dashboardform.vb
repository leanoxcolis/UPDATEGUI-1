Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports Guna.UI2.WinForms
Imports LiveCharts.WinForms
Imports MySql.Data.MySqlClient

Public Class dashboardform


    Private TotalDurationSeconds As Integer = 30 '23 * 60 * 60 ' 23 hours converted to seconds
    Dim progress As Integer = 0
    Dim totalSteps As Integer = 100
    Dim anglePerStep As Single = 360 / totalSteps
    Dim lastProgress As Integer = 0 ' Variable to store the last progress









    Public Sub Gauge360Example()
        SolidGauge1.Uses360Mode = False
        SolidGauge1.From = 0
        SolidGauge1.To = 200

        SolidGauge2.Uses360Mode = False
        SolidGauge2.From = 0
        SolidGauge2.To = 200

        SolidGauge3.Uses360Mode = False
        SolidGauge3.From = 0
        SolidGauge3.To = 200
    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'BATTERY
        Guna2CircleProgressBar1.Maximum = TotalDurationSeconds
        ProgressBar.Interval = 1000 ' Set the timer interval to 1000 milliseconds (1 second)
        Guna2CircleProgressBar1.Value = TotalDurationSeconds ' Start from the maximum value
        Label6.Text = "100%"
        ProgressBar.Start()

        '---------------------------------------------------------------------------------------------

        Gauge360Example()
        GetCurrentPercentage()
        Connect()
        Dim dataTable As New DataTable()

        Try
            Dim query As String = "SELECT * FROM ultrasonic_data"

            Using command As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using

            datagridview1.DataSource = dataTable

            ' Set up a Timer control to periodically refresh data
            Dim timer As New Timer()
            timer.Interval = 500 ' Refresh every 5 seconds (adjust as needed)
            AddHandler timer.Tick, AddressOf Timer_Tick
            timer.Start()

            ' Add a handler for the DataGridView's CellClick event
            'AddHandler datagridview1.CellClick, AddressOf DataGridView1_CellClick

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub GetCurrentPercentage()
        Try
            Connect()
            ' Assuming you have already initialized the MySQL connection
            Dim query As String = "SELECT device, milliLiter FROM ultrasonic_data ORDER BY datetime DESC"
            Dim command As New MySqlCommand(query, conn)

            Dim reader As MySqlDataReader = command.ExecuteReader()



            While reader.Read()
                Dim device As String = reader("device").ToString()
                Dim milliLiter As Integer = Convert.ToInt32(reader("milliLiter"))

                If milliLiter >= 150 Then
                    ' Set the message in notificationtxt
                    millilitertxt.ForeColor = Color.Red
                    millilitertxt.Text += $"- The latex is 150 mL for the {device}." & Environment.NewLine
                    blinkTimer.Start()
                Else
                    ' Clear the message for the device if milliLiter is less than 150 mL
                    millilitertxt.Text = millilitertxt.Text.Replace($"The latex is 150 mL for the {device}." & Environment.NewLine, "")
                    'blinkTimer.Stop()
                    'millilitertxt.ForeColor = SystemColors.ControlText
                End If

                ' Update the appropriate SolidGauge control based on device
                Select Case device
                    Case "TREE-01"
                        SolidGauge1.Value = milliLiter
                    Case "TREE-02"
                        SolidGauge2.Value = milliLiter
                    Case "TREE-03"
                        SolidGauge3.Value = milliLiter
                        ' Add more cases if you have more trees
                End Select
            End While

            reader.Close()


        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        Dim dataTable As New DataTable()
        Try

            Dim query As String = "SELECT * FROM ultrasonic_data"

            Using command As New MySqlCommand(query, conn)
                Using adapter As New MySqlDataAdapter(command)
                    adapter.Fill(dataTable)
                End Using
            End Using

            datagridview1.DataSource = Nothing
            datagridview1.DataSource = dataTable

            ' Update SolidGauge values after refreshing the data
            SolidGauge1.Value = GetCurrentPercentage("TREE-01")
            SolidGauge2.Value = GetCurrentPercentage("TREE-02")
            SolidGauge3.Value = GetCurrentPercentage("TREE-03")

            ' Refresh the SolidGauge controls
            SolidGauge1.Refresh()
            SolidGauge2.Refresh()
            SolidGauge3.Refresh()

            'notificationtxt.Text = ""
            millilitertxt.Text = ""
            GetCurrentPercentage()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Public Function GetCurrentPercentage(device As String) As Integer
        Dim milliLiter As Integer = 0
        Try
            Connect()

            Dim query As String = $"SELECT milliLiter FROM ultrasonic_data WHERE device = '{device}' ORDER BY datetime DESC LIMIT 1"
            Dim command As MySqlCommand = New MySqlCommand(query, conn)

            Dim reader = command.ExecuteReader()

            If reader.Read() Then
                milliLiter = Convert.ToInt32(reader("milliLiter"))
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return milliLiter
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles ProgressBar.Tick
        If Guna2CircleProgressBar1.Value > 0 Then
            Guna2CircleProgressBar1.Value -= 1
            ' Example: Update the label text with the percentage as a whole number
            Label6.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"

            ' Check if progress reaches 20%
            If Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum = 0.2 Then
                notificationtxt.ForeColor = Color.Red
                notificationtxt.Text = "Battery in 20%, you need to charge"
            End If
        Else
            ' Example: Stop the timer when the progress reaches 0
            ProgressBar.Stop()

            ' Store the last progress value
            lastProgress = Guna2CircleProgressBar1.Value
        End If
    End Sub

    Private Sub blinkTimer_Tick(sender As Object, e As EventArgs) Handles blinkTimer.Tick
        If millilitertxt.ForeColor = Color.Red Then
            millilitertxt.ForeColor = SystemColors.ControlText
        Else
            millilitertxt.ForeColor = Color.Red
        End If
    End Sub
End Class