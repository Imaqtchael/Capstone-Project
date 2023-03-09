<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.RememberMeCheckBox = New System.Windows.Forms.CheckBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StopCheckTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RefreshTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Poppins", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(14, 248)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(356, 127)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login to your account"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.UsernameTextBox.Location = New System.Drawing.Point(30, 405)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.PlaceholderText = " Username"
        Me.UsernameTextBox.Size = New System.Drawing.Size(315, 37)
        Me.UsernameTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PasswordTextBox.Location = New System.Drawing.Point(30, 485)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.PlaceholderText = " Password"
        Me.PasswordTextBox.Size = New System.Drawing.Size(315, 37)
        Me.PasswordTextBox.TabIndex = 1
        '
        'RememberMeCheckBox
        '
        Me.RememberMeCheckBox.AutoSize = True
        Me.RememberMeCheckBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RememberMeCheckBox.Location = New System.Drawing.Point(30, 535)
        Me.RememberMeCheckBox.Name = "RememberMeCheckBox"
        Me.RememberMeCheckBox.Size = New System.Drawing.Size(144, 30)
        Me.RememberMeCheckBox.TabIndex = 2
        Me.RememberMeCheckBox.Text = "Remember me"
        Me.RememberMeCheckBox.UseVisualStyleBackColor = True
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.BlueViolet
        Me.LoginButton.Enabled = False
        Me.LoginButton.FlatAppearance.BorderSize = 0
        Me.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoginButton.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LoginButton.ForeColor = System.Drawing.Color.White
        Me.LoginButton.Location = New System.Drawing.Point(30, 604)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(315, 51)
        Me.LoginButton.TabIndex = 3
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(81, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(205, 196)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'CheckTimer
        '
        Me.CheckTimer.Enabled = True
        Me.CheckTimer.Interval = 15000
        '
        'StopCheckTimer
        '
        Me.StopCheckTimer.Interval = 86300000
        '
        'RefreshTimer
        '
        Me.RefreshTimer.Enabled = True
        Me.RefreshTimer.Interval = 10000
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(382, 670)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.RememberMeCheckBox)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "login"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents RememberMeCheckBox As CheckBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckTimer As Timer
    Friend WithEvents StopCheckTimer As Timer
    Friend WithEvents RefreshTimer As Timer
End Class
