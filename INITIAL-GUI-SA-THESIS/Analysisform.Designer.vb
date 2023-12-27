<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Analysisform
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
        Me.cartesianChart1 = New LiveCharts.WinForms.CartesianChart()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.producetxtbox = New System.Windows.Forms.TextBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.update = New System.Windows.Forms.Timer(Me.components)
        Me.Guna2Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cartesianChart1
        '
        Me.cartesianChart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cartesianChart1.BackColor = System.Drawing.Color.Transparent
        Me.cartesianChart1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cartesianChart1.Location = New System.Drawing.Point(114, 12)
        Me.cartesianChart1.Name = "cartesianChart1"
        Me.cartesianChart1.Size = New System.Drawing.Size(1132, 440)
        Me.cartesianChart1.TabIndex = 1
        Me.cartesianChart1.Text = "CartesianChart1"
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Guna2Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.Guna2Panel2.Controls.Add(Me.Label1)
        Me.Guna2Panel2.Controls.Add(Me.producetxtbox)
        Me.Guna2Panel2.Location = New System.Drawing.Point(749, 584)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Guna2Panel2.Size = New System.Drawing.Size(282, 235)
        Me.Guna2Panel2.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 27)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Produced"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'producetxtbox
        '
        Me.producetxtbox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.producetxtbox.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.producetxtbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.producetxtbox.Font = New System.Drawing.Font("Century Gothic", 64.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.producetxtbox.Location = New System.Drawing.Point(35, 79)
        Me.producetxtbox.Multiline = True
        Me.producetxtbox.Name = "producetxtbox"
        Me.producetxtbox.ReadOnly = True
        Me.producetxtbox.Size = New System.Drawing.Size(217, 142)
        Me.producetxtbox.TabIndex = 0
        Me.producetxtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBox5
        '
        Me.ComboBox5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBox5.Font = New System.Drawing.Font("Century Gothic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.Location = New System.Drawing.Point(393, 663)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(238, 40)
        Me.ComboBox5.TabIndex = 9
        '
        'update
        '
        '
        'Analysisform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(61, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1391, 982)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.cartesianChart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Analysisform"
        Me.Text = "Analysis"
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cartesianChart1 As LiveCharts.WinForms.CartesianChart
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents producetxtbox As TextBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents update As Timer
End Class
