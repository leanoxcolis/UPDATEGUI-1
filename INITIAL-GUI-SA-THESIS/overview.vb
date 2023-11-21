Imports System.Data.SqlClient
Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient

Public Class overview

    Private Const TotalDurationSeconds As Integer = 120 ' 2 minutes * 60 seconds
    Dim progress As Integer = 0
    Dim totalSteps As Integer = 100
    Dim anglePerStep As Single = 360 / totalSteps
    Dim lastProgress As Integer = 0


    Private Sub overview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cart()
        Dim timer As New Timer()
        timer.Interval = 2000 ' 2000 milliseconds (2 seconds)
        timer.Start()
        Gauge360Example()
        AddHandler timer.Tick, AddressOf Gauge360Example


        ''DIRI KAY SA CIRCLE PROGRESS BAR
        Guna2CircleProgressBar1.Maximum = TotalDurationSeconds
        Timer1.Interval = 1000 ' Set the timer interval to 1000 milliseconds (1 second)
        Guna2CircleProgressBar1.Value = lastProgress
        Label3.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"

        Timer1.Start()


        ''KUHAON ANG TOTAL SA MILLILITER PER DAY
        Connector.Connect()
        Dim queryTotalMilliLiter As String = "SELECT SUM(milliLiter) AS TotalMilliLiter FROM ultrasonic_data1"

        Dim cmdTotalMilliLiter As New MySqlCommand(queryTotalMilliLiter, Connector.conn)

        Try
            Dim totalMilliLiter As Object = cmdTotalMilliLiter.ExecuteScalar()
            If totalMilliLiter IsNot DBNull.Value Then
                producetxtbox.Text = totalMilliLiter.ToString()
            Else
                producetxtbox.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        ''KANI KAY SA CARTESIAN CHART
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
            ' Handle exceptions if necessary
        End Try

        ' Merge the two DataTables into one
        Dim mergedTable As New DataTable()
        mergedTable.Merge(dataTable1)
        mergedTable.Merge(dataTable2)
        mergedTable.Merge(dataTable3)

        ' Bind the merged DataTable to the DataGridView
        datagridview1.DataSource = mergedTable

        Dim mlValue As Integer = GetMilliliterValueFromDatabase()

        ' Check if the value exceeds 70 mL
        'If mlValue > 70 Then
        '    ' Create an instance of the notification form
        '    Dim notificationForm As New notification()

        '    ' Set the TopLevel property of the notification form to False
        '    notificationForm.TopLevel = False

        '    ' Add the notification form to the notifpanel
        '    notifpanel.Controls.Add(notificationForm)

        '    ' Show the notification form within the panel
        '    notificationForm.Show()
        'End If
    End Sub

    Private Function GetMilliliterValueFromDatabase() As Integer
        ' Establish a connection to your database and execute a query to retrieve the milliliter value
        Dim mlValue As Integer = 0 ' Initialize with a default value
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


    Public Sub Cart()
        ' Call the Connect method to establish a database connection
        Connector.Connect()

        ' SQL queries to retrieve data from the database
        Dim query1 As String = "SELECT datetime, milliLiter FROM ultrasonic_data"
        Dim query2 As String = "SELECT datetime, milliLiter FROM ultrasonic_data1"
        Dim query3 As String = "SELECT datetime, milliLiter FROM ultrasonic_data2"

        ' Create lists to store the data from each table
        Dim datetimes1 As New List(Of DateTime)()
        Dim milliLiters1 As New List(Of Double)()

        Dim datetimes2 As New List(Of DateTime)()
        Dim milliLiters2 As New List(Of Double)()

        Dim datetimes3 As New List(Of DateTime)()
        Dim milliLiters3 As New List(Of Double)()

        ' Execute the first query using the existing connection
        Connector.command.Connection = Connector.conn
        Connector.command.CommandText = query1

        Try
            Connector.reader = Connector.command.ExecuteReader()

            While Connector.reader.Read()
                ' Extract data from the first table
                datetimes1.Add(Connector.reader.GetDateTime("datetime"))
                milliLiters1.Add(Connector.reader.GetDouble("milliLiter"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connector.reader.Close()
        End Try

        ' Execute the second query using the existing connection
        Connector.command.CommandText = query2

        Try
            Connector.reader = Connector.command.ExecuteReader()

            While Connector.reader.Read()
                ' Extract data from the second table
                datetimes2.Add(Connector.reader.GetDateTime("datetime"))
                milliLiters2.Add(Connector.reader.GetDouble("milliLiter"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connector.reader.Close()
        End Try

        ' Execute the third query using the existing connection
        Connector.command.CommandText = query3

        Try
            Connector.reader = Connector.command.ExecuteReader()

            While Connector.reader.Read()
                ' Extract data from the third table
                datetimes3.Add(Connector.reader.GetDateTime("datetime"))
                milliLiters3.Add(Connector.reader.GetDouble("milliLiter"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Connector.reader.Close()
            Connector.conn.Close()
        End Try

        ' Bind the data from all three tables to the chart
        CartesianChart1.Series = New SeriesCollection() From {
        New LineSeries() With {
            .Title = "Tree1",
            .Values = New ChartValues(Of Double)(milliLiters1),
            .PointGeometry = DefaultGeometries.Square,
            .PointGeometrySize = 15
        },
        New LineSeries() With {
            .Title = "Tree2",
            .Values = New ChartValues(Of Double)(milliLiters2),
            .PointGeometry = DefaultGeometries.Square,
            .PointGeometrySize = 15
        },
        New LineSeries() With {
            .Title = "Tree3",
            .Values = New ChartValues(Of Double)(milliLiters3),
            .PointGeometry = DefaultGeometries.Square,
            .PointGeometrySize = 15
        }
    }

        Dim allDatetimes As List(Of DateTime) = datetimes1.Concat(datetimes2).Concat(datetimes3).Distinct().ToList()
        allDatetimes.Sort()

        ' Group datetime values by day
        Dim groupedDatetimes As Dictionary(Of DateTime, List(Of DateTime)) = allDatetimes.GroupBy(Function(d) d.[Date]).ToDictionary(Function(g) g.Key, Function(g) g.ToList())
        Dim uniqueDates As List(Of DateTime) = groupedDatetimes.Keys.ToList()
        uniqueDates.Sort()

        ' Assuming datetimes are X-axis values
        CartesianChart1.AxisX.Add(New Axis With {
        .Title = "",
        .Labels = uniqueDates.Select(Function(d) d.ToString("yyyy-MM-dd")).ToArray(),
        .Separator = New Separator With {
            .Step = 1,
            .IsEnabled = False
    }
    })

        CartesianChart1.AxisY.Add(New Axis With {
        .Title = "MilliLiters",
        .LabelFormatter = Function(value) value.ToString("N0") & "mL"
    })

        CartesianChart1.LegendLocation = LegendLocation.Right

        ' Handle data clicks as before
        AddHandler CartesianChart1.DataClick, AddressOf CartesianChart1OnDataClick
    End Sub

    Private Sub CartesianChart1OnDataClick(sender As Object, chartPoint As ChartPoint)
        MessageBox.Show("You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub

    Public Sub Gauge360Example()
        'SolidGauge1.Uses360Mode = False
        'SolidGauge1.From = 0
        'SolidGauge1.To = 100
        'SolidGauge1.Value = GetCurrentPercentage()

    End Sub

    'Public Function GetCurrentPercentage() As Integer
    '    Dim milliLiter As Integer = 0
    '    Try
    '        Connect()
    '        Dim query As String = "SELECT milliLiter FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
    '        'Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
    '        command = New MySqlCommand(query, conn)
    '        Dim reader = command.ExecuteReader()


    '        While reader.Read()
    '            query = "SELECT milliLiter FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
    '            milliLiter = Convert.ToInt32(reader("milliLiter"))
    '        End While
    '        'percentageGauge.Value = percentage

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        conn.Close()
    '    End Try

    '    Return milliLiter
    'End Function



    Private Sub PieChart1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel3.Paint

    End Sub

    Private Sub SolidGauge1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub Guna2Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub datagridview1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        If e.RowIndex >= 0 Then ' Ensure a valid row is clicked
            Dim selectedRow As DataGridViewRow = datagridview1.Rows(e.RowIndex)
            Dim deviceValue As String = selectedRow.Cells("device").Value.ToString()
            'Dim datetimeValue As String = selectedRow.Cells("datetime").Value.ToString()

            'device.Text = deviceValue
            'datestarted.Text = datetimeValue
        End If
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Guna2CircleProgressBar1.Value < Guna2CircleProgressBar1.Maximum Then
            Guna2CircleProgressBar1.Value += 1
            ' Example: Update the label text with the percentage as a whole number
            Label3.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"
        Else
            ' Example: Stop the timer when the progress reaches the maximum value
            Timer1.Stop()

            ' Store the last progress value
            lastProgress = Guna2CircleProgressBar1.Value
        End If
    End Sub
End Class