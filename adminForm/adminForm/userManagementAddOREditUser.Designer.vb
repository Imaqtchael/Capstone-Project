<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class userManagementAddOREditUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(userManagementAddOREditUser))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusComboBox = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RoleComboBox = New System.Windows.Forms.ComboBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ContactTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.FullNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EditOrAddLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.StatusComboBox)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.RoleComboBox)
        Me.Panel1.Controls.Add(Me.ExitButton)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ContactTextBox)
        Me.Panel1.Controls.Add(Me.EmailTextBox)
        Me.Panel1.Controls.Add(Me.AddressTextBox)
        Me.Panel1.Controls.Add(Me.PasswordTextBox)
        Me.Panel1.Controls.Add(Me.UserNameTextBox)
        Me.Panel1.Controls.Add(Me.FullNameTextBox)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(-1, 49)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(805, 736)
        Me.Panel1.TabIndex = 1
        '
        'StatusComboBox
        '
        Me.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StatusComboBox.FormattingEnabled = True
        Me.StatusComboBox.Items.AddRange(New Object() {"ACTIVE", "INACTIVE"})
        Me.StatusComboBox.Location = New System.Drawing.Point(23, 627)
        Me.StatusComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StatusComboBox.Name = "StatusComboBox"
        Me.StatusComboBox.Size = New System.Drawing.Size(761, 28)
        Me.StatusComboBox.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(23, 596)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 26)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Status"
        '
        'RoleComboBox
        '
        Me.RoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RoleComboBox.FormattingEnabled = True
        Me.RoleComboBox.Items.AddRange(New Object() {"EVENT MANAGER", "STAFF"})
        Me.RoleComboBox.Location = New System.Drawing.Point(23, 549)
        Me.RoleComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RoleComboBox.Name = "RoleComboBox"
        Me.RoleComboBox.Size = New System.Drawing.Size(761, 28)
        Me.RoleComboBox.TabIndex = 4
        '
        'ExitButton
        '
        Me.ExitButton.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ExitButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.ExitButton.Location = New System.Drawing.Point(408, 677)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(137, 43)
        Me.ExitButton.TabIndex = 2
        Me.ExitButton.Text = "BACK TO HOME"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'SaveButton
        '
        Me.SaveButton.BackColor = System.Drawing.Color.DodgerBlue
        Me.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveButton.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SaveButton.ForeColor = System.Drawing.Color.White
        Me.SaveButton.Location = New System.Drawing.Point(266, 677)
        Me.SaveButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(125, 43)
        Me.SaveButton.TabIndex = 2
        Me.SaveButton.Text = "SAVE"
        Me.SaveButton.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(42, -39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Label1"
        '
        'ContactTextBox
        '
        Me.ContactTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContactTextBox.Location = New System.Drawing.Point(23, 389)
        Me.ContactTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ContactTextBox.Name = "ContactTextBox"
        Me.ContactTextBox.Size = New System.Drawing.Size(761, 30)
        Me.ContactTextBox.TabIndex = 1
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EmailTextBox.Location = New System.Drawing.Point(23, 469)
        Me.EmailTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(761, 30)
        Me.EmailTextBox.TabIndex = 1
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AddressTextBox.Location = New System.Drawing.Point(23, 307)
        Me.AddressTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(761, 30)
        Me.AddressTextBox.TabIndex = 1
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PasswordTextBox.Location = New System.Drawing.Point(23, 221)
        Me.PasswordTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(761, 30)
        Me.PasswordTextBox.TabIndex = 1
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.UserNameTextBox.Location = New System.Drawing.Point(23, 136)
        Me.UserNameTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(761, 30)
        Me.UserNameTextBox.TabIndex = 1
        '
        'FullNameTextBox
        '
        Me.FullNameTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FullNameTextBox.Location = New System.Drawing.Point(23, 65)
        Me.FullNameTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FullNameTextBox.Name = "FullNameTextBox"
        Me.FullNameTextBox.Size = New System.Drawing.Size(761, 30)
        Me.FullNameTextBox.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(23, 439)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 26)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "E-mail"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(23, 519)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 26)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Role"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(23, 360)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 26)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Contact Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(23, 273)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 26)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(23, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(23, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(23, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 26)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'EditOrAddLabel
        '
        Me.EditOrAddLabel.AutoSize = True
        Me.EditOrAddLabel.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.EditOrAddLabel.ForeColor = System.Drawing.Color.White
        Me.EditOrAddLabel.Location = New System.Drawing.Point(344, 9)
        Me.EditOrAddLabel.Name = "EditOrAddLabel"
        Me.EditOrAddLabel.Size = New System.Drawing.Size(117, 36)
        Me.EditOrAddLabel.TabIndex = 2
        Me.EditOrAddLabel.Text = "ADD USER"
        '
        'userManagementAddOREditUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlueViolet
        Me.ClientSize = New System.Drawing.Size(805, 785)
        Me.Controls.Add(Me.EditOrAddLabel)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "userManagementAddOREditUser"
        Me.ShowInTaskbar = False
        Me.Text = "userManagementAddOREditUser"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ExitButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ContactTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents FullNameTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents EditOrAddLabel As Label
    Friend WithEvents RoleComboBox As ComboBox
    Friend WithEvents StatusComboBox As ComboBox
    Friend WithEvents Label10 As Label
End Class
