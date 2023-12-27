Imports System.Data.SqlClient
Imports System.Globalization
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient

Public Class Analysisform



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

        Dim tableNames As String() = {"ultrasonic_data1"}
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
        'ComboBox5.Items.Add("TREE-01")
        ComboBox5.Items.Add("TREE-01")
        'ComboBox5.Items.Add("TREE-03")


        ComboBox5.SelectedIndex = 0

        UpdateChart()
    End Sub

    Private Sub PopulateComboBox()

        'ComboBox5.Items.Add("TREE-01")
        ComboBox5.Items.Add("TREE-01")
        'ComboBox5.Items.Add("TREE-03")

        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        UpdateChart()
    End Sub

    Private Sub UpdateChart()

        cartesianChart1.Hide()

        ' selectedItem is not used, so you can remove this line
        ' selectedItem = ComboBox5.SelectedItem.ToString()

        ' Use only ultrasonic_data1
        Dim tableName As String = "ultrasonic_data1"
        Cart(tableName)

        cartesianChart1.Show()

    End Sub

    Private Sub cartesianChart1_DataClick(sender As Object, chartPoint As ChartPoint) Handles cartesianChart1.DataClick

    End Sub

    Private Sub update_Tick(sender As Object, e As EventArgs) Handles update.Tick

    End Sub
End Class