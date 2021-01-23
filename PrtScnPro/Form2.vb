Public Class Form2
    Private Sub Form2_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.ControlKey Then '如果释放Ctrl
            Form1.Timer1.Enabled = False '关闭计时器
            With Form1
                .Label1.Text = "区域已选择，你可以：" '显示提示
                .Button1.Enabled = True '按钮可用
                .Button2.Enabled = True
            End With
        End If
        Dispose() '关闭自己
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TopMost = True '置顶防止忽略
        Form1.Label1.Text = "正在绘制区域，松开Ctrl可完成选择" '显示提示
    End Sub
End Class