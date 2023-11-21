Imports System.Data.SqlClient
Imports System.Globalization
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient

Public Class Analysisform

    'Dim connectionString As String = "server=127.0.0.1;userid=root;password='';database=ultrasonic_data"
    'Dim connection As MySqlConnection
    'Dim Connector As New Connector()

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
        cartesianChart1.Series = New SeriesCollection() From {
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
        cartesianChart1.AxisX.Add(New Axis With {
        .Title = "Date",
        .Labels = uniqueDates.Select(Function(d) d.ToString("yyyy-MM-dd")).ToArray(),
        .Separator = New Separator With {
            .Step = 1,
            .IsEnabled = False
    }
    })

        cartesianChart1.AxisY.Add(New Axis With {
        .Title = "MilliLiters",
        .LabelFormatter = Function(value) value.ToString("N0") & "mL"
    })

        cartesianChart1.LegendLocation = LegendLocation.Right

        ' Handle data clicks as before
        AddHandler cartesianChart1.DataClick, AddressOf CartesianChart1OnDataClick
    End Sub

    Private Sub CartesianChart1OnDataClick(sender As Object, chartPoint As ChartPoint)
        MessageBox.Show("You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub

    Private Sub Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cart()
        Connect()
        LoadYears()
        LoadWeeks()

        'TOTAL SA MILLILITER SA TANAN TABLENAME
        Connector.Connect()

        Dim tableNames As String() = {"ultrasonic_data", "ultrasonic_data1", "ultrasonic_data2"}
        Dim totalMilliLiters As Double = 0

        For Each tableName As String In tableNames
            Dim queryTotalMilliLiter As String = $"SELECT SUM(milliLiter) AS TotalMilliLiter FROM {tableName}"
            Dim cmdTotalMilliLiter As New MySqlCommand(queryTotalMilliLiter, Connector.conn)

            Try
                Dim totalMilliLiter As Object = cmdTotalMilliLiter.ExecuteScalar()

                If totalMilliLiter IsNot DBNull.Value Then
                    totalMilliLiters += Convert.ToDouble(totalMilliLiter)
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        Next

        producetxtbox.Text = totalMilliLiters.ToString()
    End Sub

    Private Sub LoadYears()
        ' Fetch distinct years from the database and populate ComboBox1
        ' Example: You need to replace 'YourTableName' with the actual name of your table
        Dim query As String = "SELECT DISTINCT YEAR(datetime) FROM ultrasonic_data1"
        Dim years As New List(Of String)()

        Try
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()

            While reader.Read()
                years.Add(reader(0).ToString())
            End While

            reader.Close()

            ' Update ComboBox1 with the retrieved years
            ComboBox1.DataSource = years
        Catch ex As Exception
            MessageBox.Show("Error fetching years: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadWeeks()
        ' Populate ComboBox3 with weeks (e.g., Week 1, Week 2, etc.) - Limit to 4 weeks
        Dim weeks As New List(Of String)()

        For i As Integer = 1 To 5
            weeks.Add("Week " & i)
        Next

        ComboBox3.DataSource = weeks
    End Sub

    Private Sub ElementHost1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub cartesianChart1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles cartesianChart1.ChildChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' When the Year ComboBox changes, update the data in the Month ComboBox
        If ComboBox1.SelectedItem IsNot Nothing Then
            UpdateMonthComboBox()
            UpdateTotalMilliLitersTextBox()
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        UpdateTotalMilliLitersTextBox()
    End Sub

    Private Sub UpdateMonthComboBox()
        ' Fetch the months for the selected year from the database and update ComboBox2
        ' Example: You need to replace 'YourTableName' with the actual name of your table
        Dim selectedYear As String = ComboBox1.SelectedItem.ToString()
        Dim query As String = $"SELECT DISTINCT MONTH(datetime) FROM ultrasonic_data1 WHERE YEAR(datetime) = {selectedYear}"
        Dim months As New List(Of String)()

        Try
            command = New MySqlCommand(query, conn)
            reader = command.ExecuteReader()

            While reader.Read()
                ' Convert month number to month name
                Dim monthNumber As Integer = CInt(reader(0))
                Dim monthName As String = New DateTime(1, monthNumber, 1).ToString("MMMM")
                months.Add(monthName)
            End While

            reader.Close()

            ' Update ComboBox2 with the retrieved months
            ComboBox2.DataSource = months
        Catch ex As Exception
            MessageBox.Show("Error fetching months: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateTotalMilliLitersTextBox()
        ' Fetch and display the total milliLiters for the selected Year, Month, and Week
        Dim selectedYear As String = ComboBox1.SelectedItem?.ToString()
        Dim selectedMonth As String = ComboBox2.SelectedItem?.ToString()

        ' Check if an item is selected in ComboBox3
        If ComboBox3.SelectedItem IsNot Nothing Then
            Dim selectedWeek As String = ComboBox3.SelectedItem.ToString()

            ' Calculate the first day of the selected month
            Dim firstDayOfMonth As New DateTime(Integer.Parse(selectedYear), DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month, 1)

            ' Calculate the starting and ending dates for the selected week
            Dim startWeek As Integer = (Integer.Parse(selectedWeek.Replace("Week ", "")) - 1)
            Dim startDate As DateTime = firstDayOfMonth.AddDays(startWeek * 7)

            Dim endDate As DateTime = startDate.AddDays(6)

            ' Example: You need to replace 'YourTableName' with the actual name of your table
            Dim query As String = $"SELECT SUM(milliLiter) FROM ultrasonic_data1 WHERE YEAR(datetime) = {selectedYear} AND MONTH(datetime) = {startDate.Month} AND DAYOFYEAR(datetime) BETWEEN {startDate.DayOfYear} AND {endDate.DayOfYear}"

            Try
                command = New MySqlCommand(query, conn)
                Dim totalMilliLiters As Object = command.ExecuteScalar()

                ' Display the total milliLiters in TextBox1
                TextBox1.Text = If(totalMilliLiters IsNot Nothing, totalMilliLiters.ToString(), "0")
            Catch ex As Exception
                MessageBox.Show("Error fetching total milliLiters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Handle the case where no week is selected
            TextBox1.Text = "0"
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        UpdateTotalMilliLitersTextBox()
    End Sub

    Private Sub producetxtbox_TextChanged(sender As Object, e As EventArgs) Handles producetxtbox.TextChanged

    End Sub
End Class