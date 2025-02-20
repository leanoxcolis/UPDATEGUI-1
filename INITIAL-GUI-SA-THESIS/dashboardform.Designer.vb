<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dashboardform
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.datagridview1 = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.MySqlDataAdapter1 = New MySql.Data.MySqlClient.MySqlDataAdapter()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SolidGauge1 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge2 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge3 = New LiveCharts.WinForms.SolidGauge()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.millilitertxt = New System.Windows.Forms.TextBox()
        Me.notificationtxt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.Timer(Me.components)
        Me.blinkTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse3 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse4 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse5 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse6 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse7 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse8 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse9 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse10 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Elipse11 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel3.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'datagridview1
        '
        Me.datagridview1.AllowUserToAddRows = False
        Me.datagridview1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.datagridview1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridview1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.datagridview1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.datagridview1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.datagridview1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.datagridview1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.datagridview1.ColumnHeadersHeight = 40
        Me.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.datagridview1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.datagridview1.DefaultCellStyle = DataGridViewCellStyle3
        Me.datagridview1.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.datagridview1.Location = New System.Drawing.Point(0, 0)
        Me.datagridview1.Name = "datagridview1"
        Me.datagridview1.ReadOnly = True
        Me.datagridview1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.datagridview1.RowHeadersVisible = False
        Me.datagridview1.RowHeadersWidth = 51
        Me.datagridview1.RowTemplate.Height = 24
        Me.datagridview1.Size = New System.Drawing.Size(576, 235)
        Me.datagridview1.TabIndex = 4
        Me.datagridview1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.datagridview1.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.datagridview1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.datagridview1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.datagridview1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.datagridview1.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.datagridview1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.datagridview1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.datagridview1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.datagridview1.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Century Gothic", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagridview1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.datagridview1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.datagridview1.ThemeStyle.HeaderStyle.Height = 40
        Me.datagridview1.ThemeStyle.ReadOnly = True
        Me.datagridview1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.datagridview1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.datagridview1.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.datagridview1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.datagridview1.ThemeStyle.RowsStyle.Height = 24
        Me.datagridview1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.datagridview1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(181, Byte), Integer))
        '
        'MySqlDataAdapter1
        '
        Me.MySqlDataAdapter1.DeleteCommand = Nothing
        Me.MySqlDataAdapter1.InsertCommand = Nothing
        Me.MySqlDataAdapter1.SelectCommand = Nothing
        Me.MySqlDataAdapter1.UpdateCommand = Nothing
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Guna2Panel3.Controls.Add(Me.Label2)
        Me.Guna2Panel3.Controls.Add(Me.SolidGauge1)
        Me.Guna2Panel3.Location = New System.Drawing.Point(19, 12)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2Panel3.Size = New System.Drawing.Size(282, 235)
        Me.Guna2Panel3.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(105, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "TREE 1"
        '
        'SolidGauge1
        '
        Me.SolidGauge1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SolidGauge1.Location = New System.Drawing.Point(12, 56)
        Me.SolidGauge1.Margin = New System.Windows.Forms.Padding(4)
        Me.SolidGauge1.Name = "SolidGauge1"
        Me.SolidGauge1.Size = New System.Drawing.Size(252, 172)
        Me.SolidGauge1.TabIndex = 6
        Me.SolidGauge1.Text = "SolidGauge1"
        '
        'SolidGauge2
        '
        Me.SolidGauge2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SolidGauge2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SolidGauge2.Location = New System.Drawing.Point(16, 56)
        Me.SolidGauge2.Margin = New System.Windows.Forms.Padding(4)
        Me.SolidGauge2.Name = "SolidGauge2"
        Me.SolidGauge2.Size = New System.Drawing.Size(252, 172)
        Me.SolidGauge2.TabIndex = 25
        Me.SolidGauge2.Text = "SolidGauge2"
        '
        'SolidGauge3
        '
        Me.SolidGauge3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SolidGauge3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SolidGauge3.Location = New System.Drawing.Point(16, 56)
        Me.SolidGauge3.Margin = New System.Windows.Forms.Padding(4)
        Me.SolidGauge3.Name = "SolidGauge3"
        Me.SolidGauge3.Size = New System.Drawing.Size(252, 172)
        Me.SolidGauge3.TabIndex = 26
        Me.SolidGauge3.Text = "SolidGauge3"
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Guna2Panel2.Controls.Add(Me.Label1)
        Me.Guna2Panel2.Controls.Add(Me.SolidGauge2)
        Me.Guna2Panel2.Location = New System.Drawing.Point(307, 12)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2Panel2.Size = New System.Drawing.Size(282, 235)
        Me.Guna2Panel2.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(116, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 32)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "TREE 2"
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Guna2Panel5.Controls.Add(Me.Label4)
        Me.Guna2Panel5.Controls.Add(Me.SolidGauge3)
        Me.Guna2Panel5.Location = New System.Drawing.Point(595, 12)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2Panel5.Size = New System.Drawing.Size(282, 235)
        Me.Guna2Panel5.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 32)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "TREE 3"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.millilitertxt)
        Me.Panel2.Controls.Add(Me.notificationtxt)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(896, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(287, 494)
        Me.Panel2.TabIndex = 29
        '
        'millilitertxt
        '
        Me.millilitertxt.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.millilitertxt.Location = New System.Drawing.Point(27, 56)
        Me.millilitertxt.Multiline = True
        Me.millilitertxt.Name = "millilitertxt"
        Me.millilitertxt.Size = New System.Drawing.Size(234, 225)
        Me.millilitertxt.TabIndex = 10
        '
        'notificationtxt
        '
        Me.notificationtxt.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notificationtxt.Location = New System.Drawing.Point(27, 287)
        Me.notificationtxt.Multiline = True
        Me.notificationtxt.Name = "notificationtxt"
        Me.notificationtxt.Size = New System.Drawing.Size(234, 192)
        Me.notificationtxt.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(70, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 32)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "NOTIFICATION"
        '
        'ProgressBar
        '
        '
        'blinkTimer
        '
        Me.blinkTimer.Interval = 1500
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 30
        Me.Guna2Elipse1.TargetControl = Me.Panel2
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.BorderRadius = 30
        Me.Guna2Elipse2.TargetControl = Me.Guna2Panel3
        '
        'Guna2Elipse3
        '
        Me.Guna2Elipse3.BorderRadius = 30
        Me.Guna2Elipse3.TargetControl = Me.Guna2Panel2
        '
        'Guna2Elipse4
        '
        Me.Guna2Elipse4.BorderRadius = 30
        Me.Guna2Elipse4.TargetControl = Me.Guna2Panel5
        '
        'Guna2Elipse5
        '
        Me.Guna2Elipse5.BorderRadius = 30
        '
        'Guna2Elipse6
        '
        Me.Guna2Elipse6.BorderRadius = 30
        Me.Guna2Elipse6.TargetControl = Me.datagridview1
        '
        'Guna2Elipse7
        '
        Me.Guna2Elipse7.BorderRadius = 30
        '
        'Guna2Elipse8
        '
        Me.Guna2Elipse8.BorderRadius = 30
        Me.Guna2Elipse8.TargetControl = Me.Guna2Panel5
        '
        'Guna2Elipse9
        '
        Me.Guna2Elipse9.BorderRadius = 30
        '
        'Guna2Elipse11
        '
        Me.Guna2Elipse11.BorderRadius = 30
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.datagridview1)
        Me.Panel1.Location = New System.Drawing.Point(12, 271)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 235)
        Me.Panel1.TabIndex = 6
        '
        'dashboardform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1229, 749)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Guna2Panel5)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "dashboardform"
        Me.Text = "dashboard"
        CType(Me.datagridview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel3.PerformLayout()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Guna2Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents datagridview1 As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents MySqlDataAdapter1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents SolidGauge1 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge2 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge3 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents notificationtxt As TextBox
    Friend WithEvents ProgressBar As Timer
    Friend WithEvents millilitertxt As TextBox
    Friend WithEvents blinkTimer As Timer
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse3 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse4 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse5 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse6 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse7 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse8 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse9 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse10 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Elipse11 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Panel1 As Panel
End Class
