Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

'CustomTabControl
'Created by: System32
'https://github.com/System32-0

Public Class CustomTabControl
    Inherits TabControl

    Private _selectedTabBrushColor As Color = Color.FromArgb(71, 80, 100)
    Private _unselectedTabBrushColor As Color = Color.FromArgb(95, 105, 127)
    Private _selectedTabBrush As Brush
    Private _unselectedTabBrush As Brush
    Private _textBrush As Brush = Brushes.White
    Private _cornerRadius As Integer = 15

    Public Property SelectedTabColor As Color
        Get
            Return _selectedTabBrushColor
        End Get
        Set(value As Color)
            _selectedTabBrushColor = value
            _selectedTabBrush = New SolidBrush(value)
        End Set
    End Property

    Public Property UnselectedTabColor As Color
        Get
            Return _unselectedTabBrushColor
        End Get
        Set(value As Color)
            _unselectedTabBrushColor = value
            _unselectedTabBrush = New SolidBrush(value)
        End Set
    End Property

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.AllPaintingInWmPaint, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(100, 30)
        DrawMode = TabDrawMode.OwnerDrawFixed
        Font = New Font("Segoe UI", 8)

        SelectedTabColor = Color.FromArgb(71, 80, 100)
        UnselectedTabColor = Color.FromArgb(95, 105, 127)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim TabRect As Rectangle

        For i As Integer = 0 To TabCount - 1
            TabRect = GetTabRect(i)

            If i = SelectedIndex Then
                Dim fillPath As GraphicsPath = TopRoundRect(TabRect, _cornerRadius)
                e.Graphics.FillPath(_selectedTabBrush, fillPath)
            Else
                Dim fillPath As GraphicsPath = TopRoundRect(TabRect, _cornerRadius)
                e.Graphics.FillPath(_unselectedTabBrush, fillPath)
            End If

            Dim textSize As SizeF = e.Graphics.MeasureString(TabPages(i).Text, Font)
            Dim textX As Integer = TabRect.X + (TabRect.Width - textSize.Width) / 2
            Dim textY As Integer = TabRect.Y + (TabRect.Height - textSize.Height) / 2
            e.Graphics.DrawString(TabPages(i).Text, Font, _textBrush, textX, textY)
        Next
    End Sub

    Private Function TopRoundRect(ByVal rect As Rectangle, ByVal cornerRad As Integer) As GraphicsPath
        Dim roundedRect As New GraphicsPath
        roundedRect.AddArc(rect.X, rect.Y, cornerRad, cornerRad, 180, 90)
        roundedRect.AddArc(rect.X + rect.Width - cornerRad, rect.Y, cornerRad, cornerRad, 270, 90)
        roundedRect.AddLine(rect.X + rect.Width, rect.Y + rect.Height, rect.X, rect.Y + rect.Height)
        roundedRect.CloseFigure()
        Return roundedRect
    End Function

End Class
