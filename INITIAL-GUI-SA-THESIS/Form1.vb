Imports MySql.Data.MySqlClient
Imports Guna.UI2.WinForms
Imports LiveCharts
Imports LiveCharts.Defaults
Imports LiveCharts.Wpf
Imports System.Runtime.InteropServices




Public Class Form1


    'Public Sub Gauge360Example()
    '    SolidGauge1.Uses360Mode = False
    '    SolidGauge1.From = 0
    '    SolidGauge1.To = 100
    '    SolidGauge1.Value = GetCurrentPercentage()

    'End Sub

    'Public Function GetCurrentPercentage() As Integer
    '    Dim milliLiter As Integer = 0
    '    Try
    '        Connect()
    '        Dim query As String = "SELECT milliLiter FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
    '        'Dim cmd As MySqlCommand = New MySqlCommand(query, connection)
    '        command = New MySqlCommand(query, conn)
    '        Dim reader = command.ExecuteReader()


    '        While reader.Read()
    '            query = "SELECT percentage FROM ultrasonic_data WHERE datetime <= NOW() ORDER BY datetime DESC LIMIT 1"
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


    Private currentChildForm As Form
    'constructor
    Public Sub New()
        InitializeComponent()
        'FORM
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        'change_menu("home")
        'Dim timer As New Timer()
        'timer.Interval = 2000 ' 5000 milliseconds (5 seconds)
        'timer.Start()
        'Gauge360Example()
        'AddHandler timer.Tick, AddressOf Gauge360Example

    End Sub

    Private Sub addForm(frm As Form)
        'paneldashboard.Controls.Clear()
        'frm.TopLevel = False
        'frm.Parent = paneldashboard
        'frm.Location = New Point(
        '(paneldashboard.Width - frm.Width) / 2,
        '(paneldashboard.Height - frm.Height) / 2)
        'paneldashboard.Controls.Add(frm)
        'frm.Show()
    End Sub

    Private Sub change_menu(menu As String)
        Select Case menu
            Case "home"
                addForm(Home)
            Case "analysis"
                addForm(Analysisform)
            Case "dashboard"
                addForm(dashboardform)
            Case "settings"
                addForm(settingsform)
        End Select
    End Sub

    Private Sub OpenChildForm(childForm As Form)
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()

        End If
        currentChildForm = childForm
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        paneldashboard.Controls.Add(childForm)
        paneldashboard.Tag = childForm
        childForm.BringToFront()
        childForm.Show()

    End Sub

    Private Sub minimizebtn_Click(sender As Object, e As EventArgs) Handles minimizebtn.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub exitbtn_Click(sender As Object, e As EventArgs) Handles exitbtn.Click
        Application.ExitThread()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dashboardbtn_Click(sender As Object, e As EventArgs) Handles dashboardbtn.Click
        OpenChildForm(New dashboardform)

    End Sub

    Private Sub paneldashboard_Paint(sender As Object, e As PaintEventArgs) Handles paneldashboard.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'If WindowState = FormWindowState.Maximized Then
        '    FormBorderStyle = FormBorderStyle.None
        'Else
        '    FormBorderStyle = FormBorderStyle.Sizable
        'End If
    End Sub

    Private Sub paneldashboard_Resize(sender As Object, e As EventArgs) Handles paneldashboard.Resize

    End Sub

    'drag the form
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub


    Private Sub toppanel_Paint(sender As Object, e As PaintEventArgs) Handles toppanel.Paint

    End Sub

    Private Sub toppanel_MouseDown(sender As Object, e As MouseEventArgs) Handles toppanel.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub

    Private Sub MaximizeBTN_Click(sender As Object, e As EventArgs) Handles MaximizeBTN.Click
        'Me.WindowState = FormWindowState.Maximized
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Private Sub logopanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles logoBtn.Click
        OpenChildForm(New Home)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged_2(sender As Object, e As EventArgs)


    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        OpenChildForm(New Analysisform)
    End Sub

    Private Sub Guna2Button2_Click_1(sender As Object, e As EventArgs)
        OpenChildForm(New overview)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles datetime.Click

    End Sub


    Private Sub SolidGauge1_ChildChanged(sender As Object, e As Integration.ChildChangedEventArgs) Handles SolidGauge1.ChildChanged

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        datetime.Text = Date.Now.ToString("dd-MMM-yyyy   hh:mm:ss")
    End Sub

End Class
