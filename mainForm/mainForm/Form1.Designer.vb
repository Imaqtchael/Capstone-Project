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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WelcomeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.WelcomeLabel = New System.Windows.Forms.Label()
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EventIntroLabel = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.EventLabel = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Cooper Black", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(801, 157)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "WELCOME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WelcomeTimer
        '
        Me.WelcomeTimer.Interval = 10
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'WelcomeLabel
        '
        Me.WelcomeLabel.AllowDrop = True
        Me.WelcomeLabel.BackColor = System.Drawing.Color.Transparent
        Me.WelcomeLabel.Font = New System.Drawing.Font("Poppins", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.WelcomeLabel.ForeColor = System.Drawing.Color.White
        Me.WelcomeLabel.Location = New System.Drawing.Point(824, 480)
        Me.WelcomeLabel.Name = "WelcomeLabel"
        Me.WelcomeLabel.Size = New System.Drawing.Size(467, 258)
        Me.WelcomeLabel.TabIndex = 1
        Me.WelcomeLabel.Text = ":TEXT2:"
        Me.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Interval = 10000
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.EventIntroLabel)
        Me.Panel1.Controls.Add(Me.DateLabel)
        Me.Panel1.Controls.Add(Me.EventLabel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(807, 801)
        Me.Panel1.TabIndex = 2
        '
        'EventIntroLabel
        '
        Me.EventIntroLabel.BackColor = System.Drawing.Color.Transparent
        Me.EventIntroLabel.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventIntroLabel.Location = New System.Drawing.Point(9, 307)
        Me.EventIntroLabel.Name = "EventIntroLabel"
        Me.EventIntroLabel.Size = New System.Drawing.Size(789, 67)
        Me.EventIntroLabel.TabIndex = 1
        Me.EventIntroLabel.Text = ":EVENTTEXT:"
        Me.EventIntroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateLabel
        '
        Me.DateLabel.BackColor = System.Drawing.Color.Transparent
        Me.DateLabel.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DateLabel.Location = New System.Drawing.Point(11, 531)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(789, 93)
        Me.DateLabel.TabIndex = 1
        Me.DateLabel.Text = ":DATE:"
        Me.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EventLabel
        '
        Me.EventLabel.BackColor = System.Drawing.Color.Transparent
        Me.EventLabel.Font = New System.Drawing.Font("Freestyle Script", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventLabel.Location = New System.Drawing.Point(3, 373)
        Me.EventLabel.Name = "EventLabel"
        Me.EventLabel.Size = New System.Drawing.Size(805, 167)
        Me.EventLabel.TabIndex = 1
        Me.EventLabel.Text = ":TEXT2:"
        Me.EventLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(82, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 268)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(824, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(467, 449)
        Me.Panel3.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 25.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(42, 349)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(374, 76)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "RFID WRISTBAND"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(139, 297)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 53)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Scan your"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Malgun Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(982, 761)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 28)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Event Venue"
        '
        'SettingsButton
        '
        Me.SettingsButton.BackColor = System.Drawing.Color.White
        Me.SettingsButton.FlatAppearance.BorderSize = 0
        Me.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SettingsButton.Image = CType(resources.GetObject("SettingsButton.Image"), System.Drawing.Image)
        Me.SettingsButton.Location = New System.Drawing.Point(1259, 759)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(35, 35)
        Me.SettingsButton.TabIndex = 5
        Me.SettingsButton.UseVisualStyleBackColor = False
        '
        'CloseButton
        '
        Me.CloseButton.BackColor = System.Drawing.Color.DodgerBlue
        Me.CloseButton.FlatAppearance.BorderSize = 0
        Me.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CloseButton.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CloseButton.ForeColor = System.Drawing.Color.White
        Me.CloseButton.Image = CType(resources.GetObject("CloseButton.Image"), System.Drawing.Image)
        Me.CloseButton.Location = New System.Drawing.Point(1270, 0)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(31, 32)
        Me.CloseButton.TabIndex = 6
        Me.CloseButton.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DodgerBlue
        Me.ClientSize = New System.Drawing.Size(1303, 801)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.SettingsButton)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.WelcomeLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "68"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents WelcomeTimer As Timer
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents WelcomeLabel As Label
    Friend WithEvents RefreshTimer As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EventIntroLabel As Label
    Friend WithEvents DateLabel As Label
    Friend WithEvents EventLabel As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents SettingsButton As Button
    Friend WithEvents CloseButton As Button
End Class
