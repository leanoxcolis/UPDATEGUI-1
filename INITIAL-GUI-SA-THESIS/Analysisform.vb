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
    Private selectedItem As String = ""
    Public Sub Cart(tableName As String)
        ' Call the Connect method to establish a database connection
        Connector.Connect()

        ' SQL query to retrieve data from the database
        Dim query As String = $"SELECT datetime, milliLiter FROM {tableName}"

        ' Create lists to store the data
        Dim datetimes As New List(Of DateTime)()
        Dim milliLiters As New List(Of Double)()

        Try
            ' Execute the query using the existing connection
            Connector.command.Connection = Connector.conn
            Connector.command.CommandText = query

            Connector.reader = Connector.command.ExecuteReader()

            While Connector.reader.Read()
                ' Extract data
                datetimes.Add(Connector.reader.GetDateTime("datetime"))
                milliLiters.Add(Connector.reader.GetDouble("milliLiter"))
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Check if Connector.reader is not Nothing before attempting to close it
            If Connector.reader IsNot Nothing Then
                Connector.reader.Close()
            End If

            Connector.conn.Close()
        End Try

        ' Clear the existing series collection
        cartesianChart1.Series.Clear()

        ' Bind the data to the chart
        cartesianChart1.Series.Add(New LineSeries() With {
        .Title = selectedItem,
        .Values = New ChartValues(Of Double)(milliLiters),
        .PointGeometry = DefaultGeometries.Square,
        .PointGeometrySize = 15
    })

        ' Configure the chart axes and appearance
        cartesianChart1.AxisX.Clear()
        cartesianChart1.AxisX.Add(New Axis With {
    .Title = "",
    .Labels = datetimes.Select(Function(dt) dt.ToString("yyyy-MM-dd")).ToArray(),
    .Separator = New Separator With {
        .Step = 1,
        .IsEnabled = False
    }
})

        cartesianChart1.AxisY.Clear()
        cartesianChart1.AxisY.Add(New Axis With {
    .Title = "",
    .MinValue = 0,  ' Set the minimum value for the Y-axis
    .MaxValue = 200, ' Set the maximum value for the Y-axis
    .LabelFormatter = Function(value) If(value > 0, value.ToString("N0") & "mL", ""),
    .Separator = New Separator With {
        .IsEnabled = True  ' Keep the Y-axis line visible
    }
})

        cartesianChart1.LegendLocation = LegendLocation.Right

        ' Handle data clicks as before
        AddHandler cartesianChart1.DataClick, AddressOf CartesianChart1OnDataClick
    End Sub

    Private Sub CartesianChart1OnDataClick(sender As Object, chartPoint As ChartPoint)
        MessageBox.Show("You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub

    Private Sub Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()

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

    Private Sub InitializeUI()
        ' Add items to the ComboBox
        ComboBox5.Items.Add("TREE-01")
        ComboBox5.Items.Add("TREE-02")
        ComboBox5.Items.Add("TREE-03")

        ' Optionally, you can set the default selected item
        ComboBox5.SelectedIndex = 0

        ' Update the chart based on the selected item
        UpdateChart()
    End Sub

    Private Sub PopulateComboBox()
        ' Add items to the ComboBox
        ComboBox5.Items.Add("TREE-01")
        ComboBox5.Items.Add("TREE-02")
        ComboBox5.Items.Add("TREE-03")

        ' Optionally, you can set the default selected item
        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        UpdateChart()
    End Sub

    Private Sub UpdateChart()
        ' Hide the chart
        cartesianChart1.Hide()

        ' Get the selected item
        selectedItem = ComboBox5.SelectedItem.ToString()

        ' Use the selected item to construct the table name
        Dim tableName As String = If(ComboBox5.SelectedIndex = 0, "ultrasonic_data", $"ultrasonic_data{ComboBox5.SelectedIndex}")

        ' Call the Cart method to update the chart
        Cart(tableName)

        ' Show the chart after updating
        cartesianChart1.Show()
    End Sub

    Private Sub cartesianChart1_DataClick(sender As Object, chartPoint As ChartPoint) Handles cartesianChart1.DataClick

    End Sub

    'mao najud 
    'Private Sub LoadYears()
    '    ' Fetch distinct years from the database and populate ComboBox1
    '    ' Example: You need to replace 'YourTableName' with the actual name of your table
    '    Dim query As String = "SELECT DISTINCT YEAR(datetime) FROM ultrasonic_data1"
    '    Dim years As New List(Of String)()

    '    Try
    '        command = New MySqlCommand(query, conn)
    '        reader = command.ExecuteReader()

    '        While reader.Read()
    '            years.Add(reader(0).ToString())
    '        End While

    '        reader.Close()

    '        ' Update ComboBox1 with the retrieved years
    '        ComboBox1.DataSource = years
    '    Catch ex As Exception
    '        MessageBox.Show("Error fetching years: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub LoadWeeks()
    '    ' Populate ComboBox3 with weeks (e.g., Week 1, Week 2, etc.) - Limit to 4 weeks
    '    Dim weeks As New List(Of String)()

    '    For i As Integer = 1 To 5
    '        weeks.Add("Week " & i)
    '    Next

    '    ComboBox3.DataSource = weeks
    'End Sub


    'Private Sub LoadDevices()
    '    ' Fetch distinct devices from the database and populate ComboBox4
    '    ' Example: You need to replace 'YourTableName' with the actual name of your table
    '    Dim query As String = "SELECT DISTINCT device FROM ultrasonic_data1"
    '    Dim devices As New List(Of String)()

    '    Try
    '        command = New MySqlCommand(query, conn)
    '        reader = command.ExecuteReader()

    '        While reader.Read()
    '            devices.Add(reader(0).ToString())
    '        End While

    '        reader.Close()

    '        ' Update ComboBox4 with the retrieved devices
    '        ComboBox4.DataSource = devices
    '    Catch ex As Exception
    '        MessageBox.Show("Error fetching devices: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    ' When the Year ComboBox changes, update the data in the Month ComboBox
    '    If ComboBox1.SelectedItem IsNot Nothing Then
    '        UpdateMonthComboBox()
    '        LoadDevices()
    '        UpdateTotalMilliLitersTextBox()
    '    End If

    'End Sub

    'Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    '    UpdateTotalMilliLitersTextBox()
    'End Sub

    'Private Sub UpdateMonthComboBox()
    '    ' Fetch the months for the selected year from the database and update ComboBox2
    '    ' Example: You need to replace 'YourTableName' with the actual name of your table
    '    Dim selectedYear As String = ComboBox1.SelectedItem.ToString()
    '    Dim query As String = $"SELECT DISTINCT MONTH(datetime) FROM ultrasonic_data1 WHERE YEAR(datetime) = {selectedYear}"
    '    Dim months As New List(Of String)()

    '    Try
    '        command = New MySqlCommand(query, conn)
    '        reader = command.ExecuteReader()

    '        While reader.Read()
    '            ' Convert month number to month name
    '            Dim monthNumber As Integer = CInt(reader(0))
    '            Dim monthName As String = New DateTime(1, monthNumber, 1).ToString("MMMM")
    '            months.Add(monthName)
    '        End While

    '        reader.Close()

    '        ' Update ComboBox2 with the retrieved months
    '        ComboBox2.DataSource = months
    '    Catch ex As Exception
    '        MessageBox.Show("Error fetching months: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

    'Private Sub UpdateTotalMilliLitersTextBox()
    '    ' Fetch and display the total milliLiters for the selected Year, Month, Week, and Device
    '    Dim selectedYear As String = ComboBox1.SelectedItem?.ToString()
    '    Dim selectedMonth As String = ComboBox2.SelectedItem?.ToString()

    '    ' Check if selectedMonth is not null before parsing
    '    If selectedYear IsNot Nothing AndAlso selectedMonth IsNot Nothing Then
    '        ' Check if an item is selected in ComboBox3 and ComboBox4
    '        If ComboBox3.SelectedItem IsNot Nothing AndAlso ComboBox4.SelectedItem IsNot Nothing Then
    '            Dim selectedWeek As String = ComboBox3.SelectedItem.ToString()
    '            Dim selectedDevice As String = ComboBox4.SelectedItem.ToString()

    '            ' Calculate the first day of the selected month
    '            Dim firstDayOfMonth As New DateTime(Integer.Parse(selectedYear), DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month, 1)

    '            ' Calculate the starting and ending dates for the selected week
    '            Dim startWeek As Integer = (Integer.Parse(selectedWeek.Replace("Week ", "")) - 1)
    '            Dim startDate As DateTime = firstDayOfMonth.AddDays(startWeek * 7)
    '            Dim endDate As DateTime = startDate.AddDays(6)

    '            ' Example: You need to replace 'YourTableName' with the actual name of your table
    '            Dim query As String = "SELECT SUM(milliLiter) FROM ultrasonic_data1 WHERE YEAR(datetime) = @Year AND MONTH(datetime) = @Month AND DAYOFYEAR(datetime) BETWEEN @StartDay AND @EndDay AND device = @Device"

    '            Try
    '                Using conn As New MySqlConnection("server=127.0.0.1;userid=root;password='';database=ultrasonic_data")
    '                    conn.Open()

    '                    Using command As New MySqlCommand(query, conn)
    '                        ' Use parameterized queries to prevent SQL injection
    '                        command.Parameters.AddWithValue("@Year", selectedYear)
    '                        command.Parameters.AddWithValue("@Month", startDate.Month)
    '                        command.Parameters.AddWithValue("@StartDay", startDate.DayOfYear)
    '                        command.Parameters.AddWithValue("@EndDay", endDate.DayOfYear)
    '                        command.Parameters.AddWithValue("@Device", selectedDevice)

    '                        Dim totalMilliLiters As Object = command.ExecuteScalar()

    '                        If totalMilliLiters IsNot Nothing AndAlso Not DBNull.Value.Equals(totalMilliLiters) Then
    '                            ' Display the total milliLiters in TextBox1
    '                            TextBox1.Text = totalMilliLiters.ToString()
    '                        Else
    '                            ' Handle the case where no data is found for the selected week and device
    '                            TextBox1.Text = "0"
    '                        End If
    '                    End Using
    '                End Using
    '            Catch ex As Exception
    '                ' Handle the case where there is an error in the query or execution
    '                MessageBox.Show("Error fetching total milliLiters: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try
    '        Else
    '            ' Handle the case where no week or device is selected
    '            TextBox1.Text = "0"
    '        End If
    '    Else
    '        ' Handle the case where selectedYear or selectedMonth is null
    '        MessageBox.Show("Please select a year and month.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End If
    'End Sub

    'Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
    '    UpdateTotalMilliLitersTextBox()
    'End Sub

    'Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
    '    UpdateTotalMilliLitersTextBox()
    'End Sub
End Class