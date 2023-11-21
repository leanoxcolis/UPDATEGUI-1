Imports LiveCharts
Imports LiveCharts.WinForms
Imports LiveCharts.Wpf
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Utilities



Public Class settingsform

    Dim Curwidth As Integer = Me.Width
    Dim Curheight As Integer = Me.Height

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub settingsform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim RatioHeight As Double = (Me.Height - Curheight) / Curheight
        Dim RatioWidght As Double = (Me.Width - Curwidth) / Curwidth

        For Each Ctrl As Control In Controls
            Ctrl.Width += Ctrl.Width * RatioWidght
            Ctrl.Left += Ctrl.Left * RatioWidght
            Ctrl.Top += Ctrl.Top * RatioHeight
            Ctrl.Height += Ctrl.Height * RatioHeight
        Next

        Curheight = Me.Height
        Curwidth = Me.Width

        'originalFormSize = New Rectangle(Me.Location.X, Me.Location.Y, Me.Size.Width, Me.Size.Height)
        'treepanelOriginalRectangle = New Rectangle(treepanel.Location.X, treepanel.Location.Y, treepanel.Width, treepanel.Height)
        'guna2Panel2OriginalRectangle = New Rectangle(Guna2Panel2.Location.X, Guna2Panel2.Location.Y, Guna2Panel2.Width, Guna2Panel2.Height)
        'guna2Panel3OriginalRectangle = New Rectangle(Guna2Panel3.Location.X, Guna2Panel3.Location.Y, Guna2Panel3.Width, Guna2Panel3.Height)
    End Sub

    Private Sub settingsform_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'ResizeControl(treepanelOriginalRectangle, treepanel)
        'ResizeControl(guna2Panel2OriginalRectangle, Guna2Panel2)
        'ResizeControl(guna2Panel3OriginalRectangle, Guna2Panel3)
    End Sub

    'Private Sub ResizeControl(r As Rectangle, c As Control)
    '    Dim xRatio As Single = CSng(Me.Width) / CSng(originalFormSize.Width)
    '    Dim yRatio As Single = CSng(Me.Height) / CSng(originalFormSize.Height)

    '    Dim newX As Integer = CInt(r.X * xRatio)
    '    Dim newY As Integer = CInt(r.Y * yRatio)

    '    Dim newWidth As Integer = CInt(r.Width * xRatio)
    '    Dim newHeight As Integer = CInt(r.Height * yRatio)

    '    c.Location = New Point(newX, newY)
    '    c.Size = New Size(newWidth, newHeight)
    'End Sub

End Class