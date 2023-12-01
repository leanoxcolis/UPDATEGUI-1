<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trydashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cartesianChart1 = New LiveCharts.WinForms.CartesianChart()
        Me.SuspendLayout()
        '
        'cartesianChart1
        '
        Me.cartesianChart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cartesianChart1.BackColor = System.Drawing.Color.Transparent
        Me.cartesianChart1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cartesianChart1.Location = New System.Drawing.Point(44, 41)
        Me.cartesianChart1.Name = "cartesianChart1"
        Me.cartesianChart1.Size = New System.Drawing.Size(1018, 440)
        Me.cartesianChart1.TabIndex = 2
        Me.cartesianChart1.Text = "CartesianChart1"
        '
        'trydashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1229, 784)
        Me.Controls.Add(Me.cartesianChart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "trydashboard"
        Me.Text = "trydashboard"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cartesianChart1 As LiveCharts.WinForms.CartesianChart
End Class
