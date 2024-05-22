Imports System.Data.SqlClient
Imports System.Drawing.Text
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class dashboardform
    'Private Const TotalDurationSeconds As Integer = 60 ' 2 minutes * 60 seconds
    Private TotalDurationSeconds As Integer = 360 ' Set the total duration for the progress bar
    Dim progress As Integer = 0
    Dim totalSteps As Integer = 100
    Dim anglePerStep As Single = 360 / totalSteps
    Dim lastProgress As Integer = 0 ' Variable to store the last progress


    Public Sub Gauge360Example()
        SolidGauge1.Uses360Mode = False
        SolidGauge1.From = 0
        SolidGauge1.To = 200


    End Sub


    Private blinkingTimer As New Timer()
    Private Sub StartBlinking()
        blinkingTimer.Interval = 500 ' Set the blinking interval (milliseconds)
        AddHandler blinkingTimer.Tick, AddressOf BlinkNotification
        blinkingTimer.Start()
    End Sub

    Private Sub StopBlinking()
        blinkingTimer.Stop()
        RemoveHandler blinkingTimer.Tick, AddressOf BlinkNotification
    End Sub

    Private Sub BlinkNotification(sender As Object, e As EventArgs)
        ' Toggle the visibility of the notification forms
        For Each control In notifpanel.Controls
            If TypeOf control Is notification Or TypeOf control Is negativenotification1 Then
                control.Visible = Not control.Visible
            End If
        Next
    End Sub

    Private Sub dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RefreshDataGridView()
        Dim timer As New Timer()
        timer.Interval = 500                'GA REFRESH SIYAG DATA EVERY SECONDS 
        timer.Start()
        Gauge360Example()

        AddHandler timer.Tick, AddressOf Gauge360Example

        'BATTERY
        Guna2CircleProgressBar1.Maximum = TotalDurationSeconds
        Timer1.Interval = 1000 ' Set the timer interval to 1000 milliseconds (1 second)
        Guna2CircleProgressBar1.Value = TotalDurationSeconds ' Start from the maximum value
        Label6.Text = "100%"
        Timer1.Start()

        ' Setup the refresh timer
        Dim refreshTimer As New Timer()
        refreshTimer.Interval = 1000
        AddHandler refreshTimer.Tick, AddressOf RefreshData
        refreshTimer.Start()
    End Sub


    Private Sub RefreshData(sender As Object, e As EventArgs)
        ' Refresh the data in the DataGridView
        RefreshDataGridView()
    End Sub

    Private Sub RefreshDataGridView()
        ' Refresh the data in the DataGridView
        ' You may need to re-implement the code to retrieve and bind the data to the DataGridView
        ' For simplicity, I'm reusing your existing code for retrieving and binding the data
        Connector.Connect()

        Dim query1 As String = "SELECT * FROM ultrasonic_data"

        Dim cmd1 As New MySqlCommand(query1, Connector.conn)
        Dim adapter1 As New MySqlDataAdapter(cmd1)
        Dim dataTable1 As New DataTable()

        Try
            ' Fill the DataTable with data from the query
            adapter1.Fill(dataTable1)
        Catch ex As Exception
            ' Handle exception
        End Try

        ' Bind the DataTable to the DataGridView
        datagridview1.DataSource = dataTable1

    End Sub


    Private Function GetMilliliterValueFromDatabase(tableName As String) As Integer
        Dim mlValue As Integer = 0

        Using conn As New MySqlConnection("server=127.0.0.1;userid=root;password='';database=rubber_thesisdb")
            conn.Open()

            ' Use parameterized query to prevent SQL injection
            Dim query As String = $"SELECT milliliter FROM {tableName}"
            Using cmd As New MySqlCommand(query, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        mlValue = Convert.ToInt32(reader("milliliter"))
                    End If
                End Using
            End Using
        End Using

        Return mlValue
    End Function


    Public Sub datagridview1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim mlValueFromTable1 As Integer = GetMilliliterValueFromDatabase("ultrasonic_data")

        If e.RowIndex >= 0 Then ' Ensure a valid row is clicked
            Dim selectedRow As DataGridViewRow = datagridview1.Rows(e.RowIndex)
            Dim deviceValue As String = selectedRow.Cells("device").Value.ToString()
            Dim datetimeValue As String = selectedRow.Cells("datetime").Value.ToString()

            ' Declare milliLiterValue outside of the If block
            Dim milliLiterValue As Integer

            ' Check if the value is not null before attempting to convert to Integer
            Dim milliLiterCellValue As Object = selectedRow.Cells("milliLiter").Value
            If milliLiterCellValue IsNot Nothing AndAlso Integer.TryParse(milliLiterCellValue.ToString(), milliLiterValue) Then
                ' The value is not null, and it can be successfully parsed as an Integer
                ' Do something with milliLiterValue if needed
                If milliLiterValue >= 150 Then
                    ' MilliLiters exceeds 150, show positive notification form in notifpanel
                    Dim notificationForm As New notification()
                    notificationForm.TopLevel = False
                    notificationForm.AutoScroll = True
                    notifpanel.Controls.Clear()
                    notifpanel.Controls.Add(notificationForm)
                    notificationForm.Show()
                    notifpanel.Visible = True
                    StartBlinking()
                ElseIf milliLiterValue < 0 Then
                    ' MilliLiters is negative, show negative notification form in notifpanel
                    Dim negativeNotificationForm As New negativenotification1()
                    negativeNotificationForm.TopLevel = False
                    negativeNotificationForm.AutoScroll = True
                    notifpanel.Controls.Clear()
                    notifpanel.Controls.Add(negativeNotificationForm)
                    negativeNotificationForm.Show()
                    notifpanel.Visible = True
                    StartBlinking()
                Else
                    ' milliLiter is between 0 and 149, show noalert form in notifpanel
                    Dim noAlertForm As New noalert()
                    noAlertForm.TopLevel = False
                    noAlertForm.AutoScroll = True
                    notifpanel.Controls.Clear()
                    notifpanel.Controls.Add(noAlertForm)
                    noAlertForm.Show()
                    notifpanel.Visible = True
                    'StopBlinking() ' Stop blinking when no alert is displayed
                End If
            Else
                ' Handle the case where the value is null or cannot be parsed as an Integer
                ' You might want to display an error message or take appropriate action
            End If

            device.Text = deviceValue
            datestarted.Text = datetimeValue
            SolidGauge1.Value = milliLiterValue ' Assuming SolidGauge1 is a control with a 'Value' property

        End If
    End Sub


    'SA BATTERY NA CODE NI
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Guna2CircleProgressBar1.Value > 0 Then
            Guna2CircleProgressBar1.Value -= 1
            ' Example: Update the label text with the percentage as a whole number
            Label6.Text = $"{CInt((Guna2CircleProgressBar1.Value / Guna2CircleProgressBar1.Maximum) * 100)}%"
        Else
            ' Example: Stop the timer when the progress reaches 0
            Timer1.Stop()

            ' Store the last progress value
            lastProgress = Guna2CircleProgressBar1.Value
        End If
    End Sub

End Class