Imports System.Data.SqlClient
Imports System.Globalization
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient

Public Class Analysisform

    Private selectedItem As String = ""

    Private WithEvents dataRefreshTimer As New Timer()

    Public Sub New()
        InitializeComponent()

        ' Set the interval for the timer (refresh every 5 seconds)
        dataRefreshTimer.Interval = 5000
    End Sub

    Private Sub dataRefreshTimer_Tick(sender As Object, e As EventArgs) Handles dataRefreshTimer.Tick
        UpdateProductTotal()
    End Sub

    Private isDataClickHandlerAttached As Boolean = False

    Public Sub Cart(tables As List(Of String), treeTitles As List(Of String))
        ' Call the Connect method to establish a database connection
        Connector.Connect()

        ' Create lists to store the data
        Dim datetimes As New List(Of DateTime)()
        Dim milliLiters As New List(Of ChartValues(Of Double))()

        For Each tableName In tables
            ' SQL query to retrieve data from the database
            Dim query As String = String.Format("SELECT datetime, milliLiter FROM {0}", tableName)
            Dim tableMilliLiters As New ChartValues(Of Double)()

            Try
                ' Execute the query using the existing connection
                Connector.command.Connection = Connector.conn
                Connector.command.CommandText = query

                Connector.reader = Connector.command.ExecuteReader()

                If Connector.reader.HasRows Then
                    While Connector.reader.Read()
                        ' Extract data
                        Dim dt As DateTime = Connector.reader.GetDateTime(Connector.reader.GetOrdinal("datetime"))
                        Dim ml As Double = Connector.reader.GetDouble(Connector.reader.GetOrdinal("milliLiter"))

                        If Not datetimes.Contains(dt) Then
                            datetimes.Add(dt)
                        End If
                        tableMilliLiters.Add(ml)
                    End While
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Check if Connector.reader is not Nothing before attempting to close it
                If Connector.reader IsNot Nothing Then
                    Connector.reader.Close()
                End If
            End Try

            milliLiters.Add(tableMilliLiters)
        Next

        Connector.conn.Close()

        ' Clear the existing series collection
        cartesianChart1.Series.Clear()

        ' Bind the data to the chart
        For i As Integer = 0 To tables.Count - 1
            cartesianChart1.Series.Add(New LineSeries() With {
                .Title = treeTitles(i),
                .Values = milliLiters(i),
                .PointGeometry = DefaultGeometries.Square,
                .PointGeometrySize = 15
            })
        Next

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
            .MinValue = 0,
            .MaxValue = 200,
            .LabelFormatter = Function(value) If(value > 0, value.ToString("N0") & "mL", ""),
            .Separator = New Separator With {
                .IsEnabled = True
            }
        })

        cartesianChart1.LegendLocation = LegendLocation.Right

        If Not isDataClickHandlerAttached Then
            AddHandler cartesianChart1.DataClick, AddressOf CartesianChart1OnDataClick
            isDataClickHandlerAttached = True
        End If
    End Sub

    Private Sub CartesianChart1OnDataClick(sender As Object, chartPoint As ChartPoint)
        MessageBox.Show("You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub

    Private Sub Analysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        UpdateProductTotal()
        dataRefreshTimer.Start()
    End Sub

    Private Sub InitializeUI()
        ' Add items to the ComboBox
        ComboBox5.Items.Add("Tree-01")
        ComboBox5.Items.Add("Tree-02")
        ComboBox5.Items.Add("Tree-03")
        ComboBox5.Items.Add("All Data")

        ComboBox5.SelectedIndex = 0
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        UpdateProductTotal()
    End Sub

    Private Sub UpdateProductTotal()
        Dim selectedTree As String = ComboBox5.SelectedItem.ToString().ToLower()
        Dim tableNames As New List(Of String)()
        Dim treeTitles As New List(Of String)()

        ' Determine the table name based on the selected item
        Select Case selectedTree
            Case "tree-01"
                tableNames.Add("ultrasonic_data1")
                treeTitles.Add("Tree-01")
            Case "tree-02"
                tableNames.Add("ultrasonic_data2")
                treeTitles.Add("Tree-02")
            Case "tree-03"
                tableNames.Add("ultrasonic_data3")
                treeTitles.Add("Tree-03")
            Case "all data"
                tableNames.AddRange(New List(Of String) From {"ultrasonic_data1", "ultrasonic_data2", "ultrasonic_data3"})
                treeTitles.AddRange(New List(Of String) From {"Tree-01", "Tree-02", "Tree-03"})
        End Select

        ' If a valid table name is determined, calculate the total milliliters
        If tableNames.Count > 0 Then
            Cart(tableNames, treeTitles) ' Pass the selected tree titles to the Cart method
            cartesianChart1.Show()

            Connector.Connect()
            Dim totalMilliLiter As Double = 0

            For Each tableName In tableNames
                Dim queryTotalMilliLiter As String = $"SELECT SUM(milliLiter) AS TotalMilliLiter FROM {tableName}"
                Dim cmdTotalMilliLiter As New MySqlCommand(queryTotalMilliLiter, Connector.conn)

                Try
                    Dim tableTotal As Object = cmdTotalMilliLiter.ExecuteScalar()

                    If tableTotal IsNot DBNull.Value Then
                        totalMilliLiter += Convert.ToDouble(tableTotal)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            Next

            producetxtbox.Text = totalMilliLiter.ToString()
            Connector.conn.Close()
        End If
    End Sub



    Private Sub cartesianChart1_DataClick(sender As Object, chartPoint As ChartPoint) Handles cartesianChart1.DataClick

    End Sub

    Private Sub update_Tick(sender As Object, e As EventArgs) Handles update.Tick

    End Sub
End Class