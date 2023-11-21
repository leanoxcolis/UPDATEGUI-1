Imports System.Data.SqlClient
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class dashboardform
    Private Const TotalDurationSeconds As Integer = 60 ' 2 minutes * 60 seconds
    Dim progress As Integer = 0
    Dim totalSteps As Integer = 100
    Dim anglePerStep As Single = 360 / totalSteps
    Dim lastProgress As Integer = 0 ' Variable to store the last progress

    Public Sub Gauge360Example()
        SolidGauge1.Uses360Mode = False
        SolidGauge1.From = 0
        SolidGauge1.To = 100
        SolidGauge1.Value = GetCurrentPercentage()

    End Sub

    Public Function GetCurrentPercentage() As Integer
        Dim milliLiter As Integer = 0
        Try
            Connect()
            Dim query As String = "SELECT milliLiter FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
            'Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
            command = New MySqlCommand(query, conn)
            Dim reader = command.ExecuteReader()


            While reader.Read()
                query = "SELECT milliLiter FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
                milliLiter = Convert.ToInt32(reader("milliLiter"))

            End While
            'percentageGauge.Value = percentage

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return milliLiter
    End Function

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim timer As New Timer()
        timer.Interval = 2000 ' 2000 milliseconds (2 seconds)
        timer.Start()
        Gauge360Example()
        AddHandler timer.Tick, AddressOf Gauge360Example


        ''BATTERY
        Guna2CircleProgressBar1.Maximum = TotalDurationSeconds
        Timer1.Interval = 1000 ' Set the timer interval to 1000 milliseconds (1 second)
        Guna2CircleProgressBar1.Value = lastProgress
        Label6.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"

        Timer1.Start()

        Connector.Connect()

        ' Define SQL queries for the two tables
        Dim query1 As String = "SELECT * FROM ultrasonic_data"
        Dim query2 As String = "SELECT * FROM ultrasonic_data1"
        Dim query3 As String = "SELECT * FROM ultrasonic_data2"

        Dim cmd1 As New MySqlCommand(query1, Connector.conn)
        Dim adapter1 As New MySqlDataAdapter(cmd1)
        Dim dataTable1 As New DataTable()

        Dim cmd2 As New MySqlCommand(query2, Connector.conn)
        Dim adapter2 As New MySqlDataAdapter(cmd2)
        Dim dataTable2 As New DataTable()

        Dim cmd3 As New MySqlCommand(query3, Connector.conn)
        Dim adapter3 As New MySqlDataAdapter(cmd3)
        Dim dataTable3 As New DataTable()

        Try
            ' Fill the DataTables with data from the queries
            adapter1.Fill(dataTable1)
            adapter2.Fill(dataTable2)
            adapter3.Fill(dataTable3)
        Catch ex As Exception

        End Try

        ' Merge the two DataTables into one
        Dim mergedTable As New DataTable()
        mergedTable.Merge(dataTable1)
        mergedTable.Merge(dataTable2)
        mergedTable.Merge(dataTable3)

        ' Bind the merged DataTable to the DataGridView
        datagridview1.DataSource = mergedTable



        ' CHECK IF THE VALUE EXCEEDS 70
        Dim mlValue As Integer = GetMilliliterValueFromDatabase()
        If mlValue > 70 Then
            Dim notificationForm As New notification()
            notificationForm.TopLevel = False
            notifpanel.Controls.Add(notificationForm)
            notificationForm.Show()
        End If

    End Sub

    Private Function GetMilliliterValueFromDatabase() As Integer

        Dim mlValue As Integer = 0
        Using conn As New MySqlConnection("server=127.0.0.1;userid=root;password='';database=ultrasonic_data")
            conn.Open()
            Using cmd As New MySqlCommand("SELECT milliliter FROM ultrasonic_data", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        mlValue = Convert.ToInt32(reader("milliliter"))
                    End If
                End Using
            End Using
        End Using

        Return mlValue
    End Function

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SolidGauge1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'SolidGauge1.Value = 50
    End Sub

    Private Sub ElementHost1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub datagridview1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        If e.RowIndex >= 0 Then ' Ensure a valid row is clicked
            Dim selectedRow As DataGridViewRow = datagridview1.Rows(e.RowIndex)
            Dim deviceValue As String = selectedRow.Cells("device").Value.ToString()
            Dim datetimeValue As String = selectedRow.Cells("datetime").Value.ToString()

            device.Text = deviceValue
            datestarted.Text = datetimeValue
        End If
    End Sub

    Private Sub datagridview1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellContentClick

    End Sub

    Private Sub device_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub notifpanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub


    'SA BATTERY NA CODE NI
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Guna2CircleProgressBar1.Value < Guna2CircleProgressBar1.Maximum Then
            Guna2CircleProgressBar1.Value += 1
            ' Example: Update the label text with the percentage as a whole number
            Label6.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"
        Else
            ' Example: Stop the timer when the progress reaches the maximum value
            Timer1.Stop()

            ' Store the last progress value
            lastProgress = Guna2CircleProgressBar1.Value
        End If
    End Sub

    Private Sub SolidGauge1_ChildChanged_1(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub
End Class