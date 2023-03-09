<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eventManagementEditORAddEvent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eventManagementEditORAddEvent))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NotPaidCheckBox = New System.Windows.Forms.CheckBox()
        Me.PaidCheckBox = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RFIDTextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BookerContactTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BookerNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EventDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TimeTextBox = New System.Windows.Forms.TextBox()
        Me.EventNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EditOrAddLabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.NotPaidCheckBox)
        Me.Panel1.Controls.Add(Me.PaidCheckBox)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.EventDateTimePicker)
        Me.Panel1.Controls.Add(Me.TypeComboBox)
        Me.Panel1.Controls.Add(Me.ExitButton)
        Me.Panel1.Controls.Add(Me.SaveButton)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TimeTextBox)
        Me.Panel1.Controls.Add(Me.EventNameTextBox)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 871)
        Me.Panel1.TabIndex = 1
        '
        'NotPaidCheckBox
        '
        Me.NotPaidCheckBox.AutoSize = True
        Me.NotPaidCheckBox.Location = New System.Drawing.Point(311, 275)
        Me.NotPaidCheckBox.Name = "NotPaidCheckBox"
        Me.NotPaidCheckBox.Size = New System.Drawing.Size(88, 24)
        Me.NotPaidCheckBox.TabIndex = 6
        Me.NotPaidCheckBox.Text = "Not Paid"
        Me.NotPaidCheckBox.UseVisualStyleBackColor = True
        '
        'PaidCheckBox
        '
        Me.PaidCheckBox.AutoSize = True
        Me.PaidCheckBox.Location = New System.Drawing.Point(23, 275)
        Me.PaidCheckBox.Name = "PaidCheckBox"
        Me.PaidCheckBox.Size = New System.Drawing.Size(59, 24)
        Me.PaidCheckBox.TabIndex = 6
        Me.PaidCheckBox.Text = "Paid"
        Me.PaidCheckBox.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.RFIDTextBox)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.EmailTextBox)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.BookerContactTextBox)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.AddressTextBox)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.BookerNameTextBox)
        Me.Panel2.Location = New System.Drawing.Point(23, 365)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(543, 439)
        Me.Panel2.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(17, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "RFID Tag"
        '
        'RFIDTextBox
        '
        Me.RFIDTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RFIDTextBox.Location = New System.Drawing.Point(17, 332)
        Me.RFIDTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RFIDTextBox.Name = "RFIDTextBox"
        Me.RFIDTextBox.Size = New System.Drawing.Size(509, 30)
        Me.RFIDTextBox.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(17, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 26)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Email"
        '
        'EmailTextBox
        '
        Me.EmailTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EmailTextBox.Location = New System.Drawing.Point(17, 261)
        Me.EmailTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.Size = New System.Drawing.Size(509, 30)
        Me.EmailTextBox.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(17, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 26)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Contact Number"
        '
        'BookerContactTextBox
        '
        Me.BookerContactTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BookerContactTextBox.Location = New System.Drawing.Point(17, 191)
        Me.BookerContactTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BookerContactTextBox.Name = "BookerContactTextBox"
        Me.BookerContactTextBox.Size = New System.Drawing.Size(509, 30)
        Me.BookerContactTextBox.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(17, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 26)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Address"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AddressTextBox.Location = New System.Drawing.Point(17, 120)
        Me.AddressTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(509, 30)
        Me.AddressTextBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(17, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 26)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Booker"
        '
        'BookerNameTextBox
        '
        Me.BookerNameTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BookerNameTextBox.Location = New System.Drawing.Point(17, 49)
        Me.BookerNameTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BookerNameTextBox.Name = "BookerNameTextBox"
        Me.BookerNameTextBox.Size = New System.Drawing.Size(509, 30)
        Me.BookerNameTextBox.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(23, 331)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 30)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "BOOKER INFORMATION"
        '
        'EventDateTimePicker
        '
        Me.EventDateTimePicker.Location = New System.Drawing.Point(23, 99)
        Me.EventDateTimePicker.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EventDateTimePicker.Name = "EventDateTimePicker"
        Me.EventDateTimePicker.Size = New System.Drawing.Size(542, 27)
        Me.EventDateTimePicker.TabIndex = 4
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Items.AddRange(New Object() {"BIRTHDAY", "VIP MEETING", "WEDDING"})
        Me.TypeComboBox.Location = New System.Drawing.Point(23, 159)
        Me.TypeComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(542, 28)
        Me.TypeComboBox.TabIndex = 3
        '
        'ExitButton
        '
        Me.ExitButton.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ExitButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.ExitButton.Location = New System.Drawing.Point(311, 812)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(135, 43)
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
        Me.SaveButton.Location = New System.Drawing.Point(163, 812)
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
        'TimeTextBox
        '
        Me.TimeTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TimeTextBox.Location = New System.Drawing.Point(23, 225)
        Me.TimeTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TimeTextBox.Name = "TimeTextBox"
        Me.TimeTextBox.Size = New System.Drawing.Size(542, 30)
        Me.TimeTextBox.TabIndex = 1
        '
        'EventNameTextBox
        '
        Me.EventNameTextBox.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventNameTextBox.Location = New System.Drawing.Point(23, 33)
        Me.EventNameTextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EventNameTextBox.Name = "EventNameTextBox"
        Me.EventNameTextBox.Size = New System.Drawing.Size(542, 30)
        Me.EventNameTextBox.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label7.Location = New System.Drawing.Point(23, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 26)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(23, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 26)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label12.Location = New System.Drawing.Point(23, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 26)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(23, 5)
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
        Me.EditOrAddLabel.Location = New System.Drawing.Point(233, 7)
        Me.EditOrAddLabel.Name = "EditOrAddLabel"
        Me.EditOrAddLabel.Size = New System.Drawing.Size(129, 36)
        Me.EditOrAddLabel.TabIndex = 2
        Me.EditOrAddLabel.Text = "ADD EVENT"
        '
        'eventManagementEditORAddEvent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlueViolet
        Me.ClientSize = New System.Drawing.Size(591, 917)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.EditOrAddLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "eventManagementEditORAddEvent"
        Me.ShowInTaskbar = False
        Me.Text = "eventManagementAddGuest"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TypeComboBox As ComboBox
    Friend WithEvents ExitButton As Button
    Friend WithEvents SaveButton As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents BookerNameTextBox As TextBox
    Friend WithEvents EventNameTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents EditOrAddLabel As Label
    Friend WithEvents EventDateTimePicker As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BookerContactTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents RFIDTextBox As TextBox
    Friend WithEvents TimeTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents NotPaidCheckBox As CheckBox
    Friend WithEvents PaidCheckBox As CheckBox
End Class
