<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtAccountList = New System.Windows.Forms.TextBox()
        Me.btnStartChecking = New System.Windows.Forms.Button()
        Me.chkUseProxy = New System.Windows.Forms.CheckBox()
        Me.txtHttpProxies = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSocks4Proxies = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSocks5Proxies = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtUsedProxies = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblFailureCount = New System.Windows.Forms.Label()
        Me.lblSuccessCount = New System.Windows.Forms.Label()
        Me.txtSuccessAccounts = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFailedAccounts = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkHeadless = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAccountList
        '
        Me.txtAccountList.Location = New System.Drawing.Point(13, 8)
        Me.txtAccountList.Multiline = True
        Me.txtAccountList.Name = "txtAccountList"
        Me.txtAccountList.Size = New System.Drawing.Size(307, 59)
        Me.txtAccountList.TabIndex = 0
        '
        'btnStartChecking
        '
        Me.btnStartChecking.Location = New System.Drawing.Point(85, 124)
        Me.btnStartChecking.Name = "btnStartChecking"
        Me.btnStartChecking.Size = New System.Drawing.Size(162, 23)
        Me.btnStartChecking.TabIndex = 2
        Me.btnStartChecking.Text = "btnStartChecking"
        Me.btnStartChecking.UseVisualStyleBackColor = True
        '
        'chkUseProxy
        '
        Me.chkUseProxy.AutoSize = True
        Me.chkUseProxy.Location = New System.Drawing.Point(18, 19)
        Me.chkUseProxy.Name = "chkUseProxy"
        Me.chkUseProxy.Size = New System.Drawing.Size(74, 17)
        Me.chkUseProxy.TabIndex = 3
        Me.chkUseProxy.Text = "Use Proxy"
        Me.chkUseProxy.UseVisualStyleBackColor = True
        '
        'txtHttpProxies
        '
        Me.txtHttpProxies.Location = New System.Drawing.Point(15, 65)
        Me.txtHttpProxies.Multiline = True
        Me.txtHttpProxies.Name = "txtHttpProxies"
        Me.txtHttpProxies.Size = New System.Drawing.Size(133, 117)
        Me.txtHttpProxies.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "HttpProxies"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(222, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Socks4Proxies"
        '
        'txtSocks4Proxies
        '
        Me.txtSocks4Proxies.Location = New System.Drawing.Point(190, 65)
        Me.txtSocks4Proxies.Multiline = True
        Me.txtSocks4Proxies.Name = "txtSocks4Proxies"
        Me.txtSocks4Proxies.Size = New System.Drawing.Size(133, 117)
        Me.txtSocks4Proxies.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Socks5Proxies"
        '
        'txtSocks5Proxies
        '
        Me.txtSocks5Proxies.Location = New System.Drawing.Point(16, 214)
        Me.txtSocks5Proxies.Multiline = True
        Me.txtSocks5Proxies.Name = "txtSocks5Proxies"
        Me.txtSocks5Proxies.Size = New System.Drawing.Size(133, 117)
        Me.txtSocks5Proxies.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(222, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "UsedProxies"
        '
        'txtUsedProxies
        '
        Me.txtUsedProxies.Location = New System.Drawing.Point(190, 214)
        Me.txtUsedProxies.Multiline = True
        Me.txtUsedProxies.Name = "txtUsedProxies"
        Me.txtUsedProxies.Size = New System.Drawing.Size(133, 117)
        Me.txtUsedProxies.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSocks4Proxies)
        Me.GroupBox1.Controls.Add(Me.chkUseProxy)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHttpProxies)
        Me.GroupBox1.Controls.Add(Me.txtUsedProxies)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSocks5Proxies)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 297)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 351)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblStatus)
        Me.GroupBox2.Controls.Add(Me.lblFailureCount)
        Me.GroupBox2.Controls.Add(Me.lblSuccessCount)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 171)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(447, 100)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(14, 68)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Status"
        '
        'lblFailureCount
        '
        Me.lblFailureCount.AutoSize = True
        Me.lblFailureCount.Location = New System.Drawing.Point(14, 45)
        Me.lblFailureCount.Name = "lblFailureCount"
        Me.lblFailureCount.Size = New System.Drawing.Size(66, 13)
        Me.lblFailureCount.TabIndex = 15
        Me.lblFailureCount.Text = "FailureCount"
        '
        'lblSuccessCount
        '
        Me.lblSuccessCount.AutoSize = True
        Me.lblSuccessCount.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblSuccessCount.Location = New System.Drawing.Point(14, 16)
        Me.lblSuccessCount.Name = "lblSuccessCount"
        Me.lblSuccessCount.Size = New System.Drawing.Size(76, 13)
        Me.lblSuccessCount.TabIndex = 14
        Me.lblSuccessCount.Text = "SuccessCount"
        '
        'txtSuccessAccounts
        '
        Me.txtSuccessAccounts.Location = New System.Drawing.Point(466, 171)
        Me.txtSuccessAccounts.Multiline = True
        Me.txtSuccessAccounts.Name = "txtSuccessAccounts"
        Me.txtSuccessAccounts.Size = New System.Drawing.Size(133, 117)
        Me.txtSuccessAccounts.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(498, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "SuccessAccounts"
        '
        'txtFailedAccounts
        '
        Me.txtFailedAccounts.Location = New System.Drawing.Point(605, 171)
        Me.txtFailedAccounts.Multiline = True
        Me.txtFailedAccounts.Name = "txtFailedAccounts"
        Me.txtFailedAccounts.Size = New System.Drawing.Size(133, 117)
        Me.txtFailedAccounts.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(637, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "FailedAccounts"
        '
        'chkHeadless
        '
        Me.chkHeadless.AutoSize = True
        Me.chkHeadless.Location = New System.Drawing.Point(27, 271)
        Me.chkHeadless.Name = "chkHeadless"
        Me.chkHeadless.Size = New System.Drawing.Size(87, 17)
        Me.chkHeadless.TabIndex = 18
        Me.chkHeadless.Text = "Hide Chrome"
        Me.chkHeadless.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 758)
        Me.Controls.Add(Me.chkHeadless)
        Me.Controls.Add(Me.txtFailedAccounts)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSuccessAccounts)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStartChecking)
        Me.Controls.Add(Me.txtAccountList)
        Me.Name = "Form1"
        Me.Text = "netflix checker vb selenium webdriver"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtAccountList As TextBox
    Friend WithEvents btnStartChecking As Button
    Friend WithEvents chkUseProxy As CheckBox
    Friend WithEvents txtHttpProxies As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSocks4Proxies As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSocks5Proxies As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUsedProxies As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblFailureCount As Label
    Friend WithEvents lblSuccessCount As Label
    Friend WithEvents txtSuccessAccounts As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFailedAccounts As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents chkHeadless As CheckBox
End Class
