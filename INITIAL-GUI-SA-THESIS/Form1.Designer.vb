<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.toppanel = New System.Windows.Forms.Panel()
        Me.datetime = New System.Windows.Forms.Label()
        Me.MaximizeBTN = New System.Windows.Forms.Button()
        Me.exitbtn = New System.Windows.Forms.Button()
        Me.minimizebtn = New System.Windows.Forms.Button()
        Me.sidepanel = New System.Windows.Forms.Panel()
        Me.Guna2Button1 = New Guna.UI2.WinForms.Guna2Button()
        Me.logoBtn = New System.Windows.Forms.Button()
        Me.dashboardbtn = New Guna.UI2.WinForms.Guna2Button()
        Me.paneldashboard = New Guna.UI2.WinForms.Guna2Panel()
        Me.SolidGauge1 = New LiveCharts.WinForms.SolidGauge()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.toppanel.SuspendLayout()
        Me.sidepanel.SuspendLayout()
        Me.paneldashboard.SuspendLayout()
        Me.SuspendLayout()
        '
        'toppanel
        '
        Me.toppanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.toppanel.Controls.Add(Me.datetime)
        Me.toppanel.Controls.Add(Me.MaximizeBTN)
        Me.toppanel.Controls.Add(Me.exitbtn)
        Me.toppanel.Controls.Add(Me.minimizebtn)
        Me.toppanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.toppanel.Location = New System.Drawing.Point(0, 0)
        Me.toppanel.Margin = New System.Windows.Forms.Padding(4)
        Me.toppanel.Name = "toppanel"
        Me.toppanel.Size = New System.Drawing.Size(1549, 81)
        Me.toppanel.TabIndex = 1
        '
        'datetime
        '
        Me.datetime.AutoSize = True
        Me.datetime.BackColor = System.Drawing.Color.Transparent
        Me.datetime.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datetime.ForeColor = System.Drawing.Color.White
        Me.datetime.Location = New System.Drawing.Point(21, 27)
        Me.datetime.Name = "datetime"
        Me.datetime.Size = New System.Drawing.Size(170, 27)
        Me.datetime.TabIndex = 3
        Me.datetime.Text = "date and time"
        '
        'MaximizeBTN
        '
        Me.MaximizeBTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaximizeBTN.BackColor = System.Drawing.Color.White
        Me.MaximizeBTN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.MaximizeBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MaximizeBTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBTN.ForeColor = System.Drawing.SystemColors.Control
        Me.MaximizeBTN.Image = CType(resources.GetObject("MaximizeBTN.Image"), System.Drawing.Image)
        Me.MaximizeBTN.Location = New System.Drawing.Point(1466, 16)
        Me.MaximizeBTN.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBTN.Name = "MaximizeBTN"
        Me.MaximizeBTN.Size = New System.Drawing.Size(31, 33)
        Me.MaximizeBTN.TabIndex = 2
        Me.MaximizeBTN.UseVisualStyleBackColor = False
        '
        'exitbtn
        '
        Me.exitbtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.exitbtn.BackColor = System.Drawing.Color.White
        Me.exitbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.exitbtn.Image = CType(resources.GetObject("exitbtn.Image"), System.Drawing.Image)
        Me.exitbtn.Location = New System.Drawing.Point(1505, 16)
        Me.exitbtn.Margin = New System.Windows.Forms.Padding(4)
        Me.exitbtn.Name = "exitbtn"
        Me.exitbtn.Size = New System.Drawing.Size(31, 33)
        Me.exitbtn.TabIndex = 1
        Me.exitbtn.UseVisualStyleBackColor = False
        '
        'minimizebtn
        '
        Me.minimizebtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimizebtn.BackColor = System.Drawing.Color.White
        Me.minimizebtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.minimizebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.minimizebtn.ForeColor = System.Drawing.SystemColors.Control
        Me.minimizebtn.Image = CType(resources.GetObject("minimizebtn.Image"), System.Drawing.Image)
        Me.minimizebtn.Location = New System.Drawing.Point(1427, 16)
        Me.minimizebtn.Margin = New System.Windows.Forms.Padding(4)
        Me.minimizebtn.Name = "minimizebtn"
        Me.minimizebtn.Size = New System.Drawing.Size(31, 33)
        Me.minimizebtn.TabIndex = 0
        Me.minimizebtn.UseVisualStyleBackColor = False
        '
        'sidepanel
        '
        Me.sidepanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.sidepanel.Controls.Add(Me.Guna2Button1)
        Me.sidepanel.Controls.Add(Me.logoBtn)
        Me.sidepanel.Controls.Add(Me.dashboardbtn)
        Me.sidepanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.sidepanel.Location = New System.Drawing.Point(0, 81)
        Me.sidepanel.Margin = New System.Windows.Forms.Padding(4)
        Me.sidepanel.Name = "sidepanel"
        Me.sidepanel.Size = New System.Drawing.Size(320, 784)
        Me.sidepanel.TabIndex = 2
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.Guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.Guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.Guna2Button1.FillColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.Font = New System.Drawing.Font("Century Gothic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Guna2Button1.Image = CType(resources.GetObject("Guna2Button1.Image"), System.Drawing.Image)
        Me.Guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.Guna2Button1.ImageSize = New System.Drawing.Size(30, 30)
        Me.Guna2Button1.Location = New System.Drawing.Point(0, 406)
        Me.Guna2Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(320, 69)
        Me.Guna2Button1.TabIndex = 4
        Me.Guna2Button1.Text = "Analysis"
        '
        'logoBtn
        '
        Me.logoBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.logoBtn.BackgroundImage = CType(resources.GetObject("logoBtn.BackgroundImage"), System.Drawing.Image)
        Me.logoBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.logoBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.logoBtn.FlatAppearance.BorderSize = 0
        Me.logoBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.logoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.logoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logoBtn.Location = New System.Drawing.Point(0, 39)
        Me.logoBtn.Name = "logoBtn"
        Me.logoBtn.Size = New System.Drawing.Size(320, 268)
        Me.logoBtn.TabIndex = 3
        Me.logoBtn.UseVisualStyleBackColor = False
        '
        'dashboardbtn
        '
        Me.dashboardbtn.BackColor = System.Drawing.Color.Transparent
        Me.dashboardbtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.dashboardbtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.dashboardbtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.dashboardbtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.dashboardbtn.FillColor = System.Drawing.Color.Transparent
        Me.dashboardbtn.Font = New System.Drawing.Font("Century Gothic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dashboardbtn.ForeColor = System.Drawing.SystemColors.Window
        Me.dashboardbtn.Image = CType(resources.GetObject("dashboardbtn.Image"), System.Drawing.Image)
        Me.dashboardbtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.dashboardbtn.ImageSize = New System.Drawing.Size(30, 30)
        Me.dashboardbtn.Location = New System.Drawing.Point(4, 329)
        Me.dashboardbtn.Margin = New System.Windows.Forms.Padding(4)
        Me.dashboardbtn.Name = "dashboardbtn"
        Me.dashboardbtn.Size = New System.Drawing.Size(316, 69)
        Me.dashboardbtn.TabIndex = 0
        Me.dashboardbtn.Text = "Dashboard"
        '
        'paneldashboard
        '
        Me.paneldashboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.paneldashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.paneldashboard.Controls.Add(Me.SolidGauge1)
        Me.paneldashboard.Controls.Add(Me.Label1)
        Me.paneldashboard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paneldashboard.Location = New System.Drawing.Point(320, 81)
        Me.paneldashboard.Margin = New System.Windows.Forms.Padding(4)
        Me.paneldashboard.Name = "paneldashboard"
        Me.paneldashboard.Size = New System.Drawing.Size(1229, 784)
        Me.paneldashboard.TabIndex = 3
        '
        'SolidGauge1
        '
        Me.SolidGauge1.Location = New System.Drawing.Point(56, 39)
        Me.SolidGauge1.Name = "SolidGauge1"
        Me.SolidGauge1.Size = New System.Drawing.Size(97, 60)
        Me.SolidGauge1.TabIndex = 3
        Me.SolidGauge1.Text = "SolidGauge1"
        Me.SolidGauge1.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Impact", 25.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(228, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(755, 106)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Natural Later Rubber Monitoring System" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       with Yield Data Visualization"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1549, 865)
        Me.Controls.Add(Me.paneldashboard)
        Me.Controls.Add(Me.sidepanel)
        Me.Controls.Add(Me.toppanel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.toppanel.ResumeLayout(False)
        Me.toppanel.PerformLayout()
        Me.sidepanel.ResumeLayout(False)
        Me.paneldashboard.ResumeLayout(False)
        Me.paneldashboard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents toppanel As Panel
    Friend WithEvents exitbtn As Button
    Friend WithEvents minimizebtn As Button
    Friend WithEvents sidepanel As Panel
    Friend WithEvents dashboardbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents paneldashboard As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents MaximizeBTN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Button1 As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents datetime As Label
    Friend WithEvents SolidGauge1 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Timer1 As Timer
    Friend WithEvents logoBtn As Button
End Class
