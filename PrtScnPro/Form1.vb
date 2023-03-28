Public Class Form1
    Dim sPointX As Integer, sPointY As Integer, fPointX As Integer, fPointY As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Form2.Width = MousePosition.X - Form2.Left '终点坐标x
        Form2.Height = MousePosition.Y - Form2.Top '终点坐标y
        fPointX = MousePosition.X
        fPointY = MousePosition.Y '赋值
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged  '是否置顶
        If CheckBox1.Checked = True Then
            TopMost = True
        Else
            TopMost = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pointLeftSoure As New Point(sPointX, sPointY) '截屏起点
        Dim pointLeftDestination As New Point(0, 0) '图片起点
        Dim sizeBackImage As New Size(fPointX, fPointY) '截屏终点
        Dim imgpnlLock As New Bitmap(fPointX - sPointX, fPointY - sPointY) '保存图片大小
        Using g As Graphics = Graphics.FromImage(imgpnlLock)
            g.CopyFromScreen(pointLeftSoure, pointLeftDestination, sizeBackImage) '截屏
        End Using

        If CheckBox2.Checked And Label2.Text <> "" Then
            imgpnlLock.Save(Label2.Text + "\" + Format(DateAndTime.Now, "yyyy-MM-dd HH-mm-ss") + ".png"）
        ElseIf SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then ''显示保存对话框，并判断如果按下了是
            If Label2.Text <> "" Then
                imgpnlLock.Save(SaveFileDialog1.FileName) '保存图片
            End If
            SaveFileDialog1.InitialDirectory = IO.Path.GetDirectoryName(SaveFileDialog1.FileName) '返回上一步保存的文件位置
            SaveFileDialog1.FileName = "未命名.png" '默认文件名
            Label2.Text = SaveFileDialog1.InitialDirectory
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.KeyPreview = True '窗体比控件提前相应键盘事件
        Button1.Enabled = False
        Button2.Enabled = False '按钮不可用
        With SaveFileDialog1 '初始化对话框信息
            .Filter = "PNG(*.png)|*.png|JPEG(*.jpg;*.jpeg)|*.jpg|BMP(*.bmp)|*.bmp" '设置过滤器
            .InitialDirectory = Application.StartupPath '设置默认目录为程序目录
            .Title = "将截图保存为" '设置标题
            .FileName = "未命名.png"
        End With
        Dim dKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", True).GetValue("AppsUseLightTheme", "0")
        If dKey = 0 Then '如果是深色主题
            With Me '修改设置
                .BackColor = Color.FromArgb(53, 54, 58) '窗口背景色
                .Label1.ForeColor = Color.FromArgb(218, 220, 224) '标签前景色
                .CheckBox1.ForeColor = Color.FromArgb(218, 220, 224) '检查框前景色
                .Button1.ForeColor = Color.FromArgb(218, 220, 224) '按钮前景色
                .Button1.BackColor = Color.FromArgb(53, 54, 58) '按钮背景色
                .Button2.ForeColor = Color.FromArgb(218, 220, 224) '按钮前景色
                .Button2.BackColor = Color.FromArgb(53, 54, 58) '按钮背景色
            End With
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pointLeftSoure As New Point(sPointX, sPointY) '截屏起点
        Dim pointLeftDestination As New Point(0, 0) '图片起点
        Dim sizeBackImage As New Size(fPointX, fPointY) '截屏终点
        Dim imgpnlLock As New Bitmap(fPointX - sPointX, fPointY - sPointY) '保存图片大小
        Using g As Graphics = Graphics.FromImage(imgpnlLock)
            g.CopyFromScreen(pointLeftSoure, pointLeftDestination, sizeBackImage) '截屏
        End Using
        Clipboard.SetImage(imgpnlLock) '保存截屏到剪贴板
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.S Then '如果按下ctrl
            Form2.Show() '显示框架窗口
            Form2.Left = MousePosition.X '起始坐标x
            Form2.Top = MousePosition.Y '起始坐标y
            sPointX = MousePosition.X
            sPointY = MousePosition.Y '赋值
            Timer1.Enabled = True '开启计时器
        ElseIf e.KeyCode = Keys.Escape Then
            Dispose() '按下Esc退出
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs)

    End Sub
End Class
