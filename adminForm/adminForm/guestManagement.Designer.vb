<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class guestManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(guestManagement))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GuestSearchTextBox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AddGuestButton = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GuestsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GuestsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GuestSearchTextBox
        '
        Me.GuestSearchTextBox.BackColor = System.Drawing.Color.LightGray
        Me.GuestSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GuestSearchTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestSearchTextBox.Location = New System.Drawing.Point(14, 23)
        Me.GuestSearchTextBox.Name = "GuestSearchTextBox"
        Me.GuestSearchTextBox.PlaceholderText = "Search Event"
        Me.GuestSearchTextBox.Size = New System.Drawing.Size(314, 30)
        Me.GuestSearchTextBox.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.AddGuestButton)
        Me.Panel1.Controls.Add(Me.GuestSearchTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 80)
        Me.Panel1.TabIndex = 5
        '
        'AddGuestButton
        '
        Me.AddGuestButton.BackColor = System.Drawing.Color.BlueViolet
        Me.AddGuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddGuestButton.ForeColor = System.Drawing.Color.White
        Me.AddGuestButton.Image = CType(resources.GetObject("AddGuestButton.Image"), System.Drawing.Image)
        Me.AddGuestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddGuestButton.Location = New System.Drawing.Point(1198, 13)
        Me.AddGuestButton.Name = "AddGuestButton"
        Me.AddGuestButton.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.AddGuestButton.Size = New System.Drawing.Size(160, 53)
        Me.AddGuestButton.TabIndex = 5
        Me.AddGuestButton.Text = "ADD GUEST"
        Me.AddGuestButton.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.GuestsDataGridView)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 106)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1371, 641)
        Me.Panel4.TabIndex = 7
        '
        'GuestsDataGridView
        '
        Me.GuestsDataGridView.AllowUserToAddRows = False
        Me.GuestsDataGridView.AllowUserToDeleteRows = False
        Me.GuestsDataGridView.AllowUserToResizeColumns = False
        Me.GuestsDataGridView.AllowUserToResizeRows = False
        Me.GuestsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GuestsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GuestsDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.GuestsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GuestsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.GuestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GuestsDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GuestsDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.GuestsDataGridView.Location = New System.Drawing.Point(14, 69)
        Me.GuestsDataGridView.MultiSelect = False
        Me.GuestsDataGridView.Name = "GuestsDataGridView"
        Me.GuestsDataGridView.ReadOnly = True
        Me.GuestsDataGridView.RowHeadersVisible = False
        Me.GuestsDataGridView.RowHeadersWidth = 51
        Me.GuestsDataGridView.RowTemplate.DividerHeight = 1
        Me.GuestsDataGridView.RowTemplate.Height = 29
        Me.GuestsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GuestsDataGridView.Size = New System.Drawing.Size(1344, 557)
        Me.GuestsDataGridView.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(1160, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 36)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Actions"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(925, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(623, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 36)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(324, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 36)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Event"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(21, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 36)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Name"
        '
        'guestManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1371, 747)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "guestManagement"
        Me.Text = "guestManagement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.GuestsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GuestSearchTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddGuestButton As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GuestsDataGridView As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
End Class
