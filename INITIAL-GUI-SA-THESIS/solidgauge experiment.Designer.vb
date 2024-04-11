<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class solidgauge_experiment
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
        Me.SolidGauge100 = New LiveCharts.WinForms.SolidGauge()
        Me.SolidGauge101 = New LiveCharts.WinForms.SolidGauge()
        Me.SuspendLayout()
        '
        'SolidGauge100
        '
        Me.SolidGauge100.Location = New System.Drawing.Point(74, 47)
        Me.SolidGauge100.Name = "SolidGauge100"
        Me.SolidGauge100.Size = New System.Drawing.Size(217, 177)
        Me.SolidGauge100.TabIndex = 0
        Me.SolidGauge100.Text = "SolidGauge100"
        '
        'SolidGauge101
        '
        Me.SolidGauge101.Location = New System.Drawing.Point(433, 56)
        Me.SolidGauge101.Name = "SolidGauge101"
        Me.SolidGauge101.Size = New System.Drawing.Size(217, 177)
        Me.SolidGauge101.TabIndex = 1
        Me.SolidGauge101.Text = "SolidGauge1"
        '
        'solidgauge_experiment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SolidGauge101)
        Me.Controls.Add(Me.SolidGauge100)
        Me.Name = "solidgauge_experiment"
        Me.Text = "solidgauge_experiment"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SolidGauge100 As LiveCharts.WinForms.SolidGauge
    Friend WithEvents SolidGauge101 As LiveCharts.WinForms.SolidGauge
End Class
