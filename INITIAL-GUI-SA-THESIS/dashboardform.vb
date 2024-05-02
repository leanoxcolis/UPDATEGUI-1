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
        timer.Interval = 2000 ' 2000 milliseconds (2 seconds)
        timer.Start()
        Gauge360Example()

        AddHandler timer.Tick, AddressOf Gauge360Example


        ''BATTERY
        Guna2CircleProgressBar1.Maximum = TotalDurationSeconds
        Timer1.Interval = 1000 ' Set the timer interval to 1000 milliseconds (1 second)
        Guna2CircleProgressBar1.Value = TotalDurationSeconds ' Start from the maximum value
        Label6.Text = "100%"
        Timer1.Start()



        Dim refreshTimer As New Timer()
        refreshTimer.Interval = 2000
        ' AddHandler refreshTimer.Tick, AddressOf RefreshData
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
        'Dim query2 As String = "SELECT * FROM ultrasonic_data1"
        'Dim query3 As String = "SELECT * FROM ultrasonic_data2"

        Dim cmd1 As New MySqlCommand(query1, Connector.conn)
        Dim adapter1 As New MySqlDataAdapter(cmd1)
        Dim dataTable1 As New DataTable()

        'Dim cmd2 As New MySqlCommand(query2, Connector.conn)
        'Dim adapter2 As New MySqlDataAdapter(cmd2)
        'Dim dataTable2 As New DataTable()

        'Dim cmd3 As New MySqlCommand(query3, Connector.conn)
        'Dim adapter3 As New MySqlDataAdapter(cmd3)
        Dim dataTable3 As New DataTable()

        Try
            ' Fill the DataTables with data from the queries
            adapter1.Fill(dataTable1)
            'adapter2.Fill(dataTable2)
            'adapter3.Fill(dataTable3)
        Catch ex As Exception

        End Try

        ' Merge the two DataTables into one
        Dim mergedTable As New DataTable()
        mergedTable.Merge(dataTable1)
        'mergedTable.Merge(dataTable2)
        mergedTable.Merge(dataTable3)

        ' Bind the merged DataTable to the DataGridView
        datagridview1.DataSource = mergedTable

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




    Public Sub datagridview1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles datagridview1.CellClick
        Dim mlValueFromTable1 As Integer = GetMilliliterValueFromDatabase("ultrasonic_data")
        Dim mlValueFromTable2 As Integer = GetMilliliterValueFromDatabase("ultrasonic_data1")
        Dim mlValueFromTable3 As Integer = GetMilliliterValueFromDatabase("ultrasonic_data2")

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

    Private Sub SolidGauge1_ChildChanged_1(sender As Object, e As Integration.ChildChangedEventArgs)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub SolidGauge1_ChildChanged_2(sender As Object, e As Integration.ChildChangedEventArgs) Handles SolidGauge1.ChildChanged

    End Sub

    Private Sub device_TextChanged(sender As Object, e As EventArgs) Handles device.TextChanged

    End Sub

    Private Sub Guna2Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Guna2Panel2.Paint

    End Sub
End Class