Imports System
Imports System.Windows.Forms
Imports System.Windows.Media
Imports LiveCharts
Imports LiveCharts.Wpf

Public Class trydashboard
    Inherits Form

    Private WithEvents basicLineExample As BasicLineExample

    Private Sub trydashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        basicLineExample = New BasicLineExample()
        basicLineExample.TopLevel = False
        basicLineExample.FormBorderStyle = FormBorderStyle.None
        basicLineExample.Dock = DockStyle.Fill
        Controls.Add(basicLineExample)
        basicLineExample.Show()
    End Sub

    Private Sub cartesianChart1_DataClick(sender As Object, chartPoint As ChartPoint) Handles cartesianChart1.DataClick
        MessageBox.Show("Data Click Event in trydashboard: You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub
End Class

Public Class BasicLineExample
    Inherits Form

    Public WithEvents CartesianChart1 As LiveCharts.WinForms.CartesianChart

    Public Sub New()
        'InitializeComponent()

        CartesianChart1.Series = New SeriesCollection From {
            New LineSeries With {
                .Title = "Series 1",
                .Values = New ChartValues(Of Double) From {4, 6, 5, 2, 7}
            },
            New LineSeries With {
                .Title = "Series 2",
                .Values = New ChartValues(Of Double) From {6, 7, 3, 4, 6},
                .PointGeometry = Nothing
            },
            New LineSeries With {
                .Title = "Series 2",
                .Values = New ChartValues(Of Double) From {5, 2, 8, 3},
                .PointGeometry = DefaultGeometries.Square,
                .PointGeometrySize = 15
            }
        }

        CartesianChart1.AxisX.Add(New Axis With {
            .Title = "Month",
            .Labels = {"Jan", "Feb", "Mar", "Apr", "May"}
        })

        CartesianChart1.AxisY.Add(New Axis With {
            .Title = "Sales",
            .LabelFormatter = Function(value) value.ToString("C")
        })

        CartesianChart1.LegendLocation = LegendLocation.Right

        ' Modifying the series collection will animate and update the chart
        CartesianChart1.Series.Add(New LineSeries With {
            .Values = New ChartValues(Of Double) From {5, 3, 2, 4, 5},
            .LineSmoothness = 0,
            .PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
            .PointGeometrySize = 50,
            .PointForeground = Brushes.Gray
        })

        ' Modifying any series values will also animate and update the chart
        CartesianChart1.Series(2).Values.Add(5.0)

        AddHandler CartesianChart1.DataClick, AddressOf CartesianChart1OnDataClick
    End Sub

    Private Sub CartesianChart1OnDataClick(ByVal sender As Object, ByVal chartPoint As ChartPoint)
        MessageBox.Show("You clicked (" & chartPoint.X & "," & chartPoint.Y & ")")
    End Sub
End Class