<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerGuests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(registerGuests))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EventComboBox = New System.Windows.Forms.ComboBox()
        Me.GoButton = New System.Windows.Forms.Button()
        Me.GuestTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RFIDTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(219, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Choose an Event "
        '
        'EventComboBox
        '
        Me.EventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EventComboBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventComboBox.FormattingEnabled = True
        Me.EventComboBox.Location = New System.Drawing.Point(40, 79)
        Me.EventComboBox.Name = "EventComboBox"
        Me.EventComboBox.Size = New System.Drawing.Size(566, 44)
        Me.EventComboBox.TabIndex = 1
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.BlueViolet
        Me.GoButton.Enabled = False
        Me.GoButton.FlatAppearance.BorderSize = 0
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GoButton.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GoButton.ForeColor = System.Drawing.Color.White
        Me.GoButton.Location = New System.Drawing.Point(479, 140)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(127, 44)
        Me.GoButton.TabIndex = 2
        Me.GoButton.Text = "GO"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'GuestTextBox
        '
        Me.GuestTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestTextBox.Location = New System.Drawing.Point(42, 253)
        Me.GuestTextBox.Name = "GuestTextBox"
        Me.GuestTextBox.ReadOnly = True
        Me.GuestTextBox.Size = New System.Drawing.Size(564, 37)
        Me.GuestTextBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(42, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 36)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(42, 313)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "RFID Tag"
        '
        'RFIDTextBox
        '
        Me.RFIDTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RFIDTextBox.Location = New System.Drawing.Point(42, 352)
        Me.RFIDTextBox.Name = "RFIDTextBox"
        Me.RFIDTextBox.Size = New System.Drawing.Size(564, 37)
        Me.RFIDTextBox.TabIndex = 3
        '
        'registerGuests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(640, 421)
        Me.Controls.Add(Me.RFIDTextBox)
        Me.Controls.Add(Me.GuestTextBox)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.EventComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "registerGuests"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents EventComboBox As ComboBox
    Friend WithEvents GoButton As Button
    Friend WithEvents GuestTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RFIDTextBox As TextBox
End Class
