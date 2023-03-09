<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class userManagement
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(userManagement))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.AddUserButton = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.UsersDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.AddUserButton)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 80)
        Me.Panel1.TabIndex = 7
        '
        'AddUserButton
        '
        Me.AddUserButton.BackColor = System.Drawing.Color.BlueViolet
        Me.AddUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddUserButton.ForeColor = System.Drawing.Color.White
        Me.AddUserButton.Image = CType(resources.GetObject("AddUserButton.Image"), System.Drawing.Image)
        Me.AddUserButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddUserButton.Location = New System.Drawing.Point(1198, 13)
        Me.AddUserButton.Name = "AddUserButton"
        Me.AddUserButton.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.AddUserButton.Size = New System.Drawing.Size(160, 53)
        Me.AddUserButton.TabIndex = 5
        Me.AddUserButton.Text = "ADD USER"
        Me.AddUserButton.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.UsersDataGridView)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 106)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1371, 641)
        Me.Panel4.TabIndex = 8
        '
        'UsersDataGridView
        '
        Me.UsersDataGridView.AllowUserToAddRows = False
        Me.UsersDataGridView.AllowUserToDeleteRows = False
        Me.UsersDataGridView.AllowUserToResizeColumns = False
        Me.UsersDataGridView.AllowUserToResizeRows = False
        Me.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.UsersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.UsersDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.UsersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UsersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.UsersDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.UsersDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.UsersDataGridView.Location = New System.Drawing.Point(14, 69)
        Me.UsersDataGridView.MultiSelect = False
        Me.UsersDataGridView.Name = "UsersDataGridView"
        Me.UsersDataGridView.ReadOnly = True
        Me.UsersDataGridView.RowHeadersVisible = False
        Me.UsersDataGridView.RowHeadersWidth = 51
        Me.UsersDataGridView.RowTemplate.DividerHeight = 1
        Me.UsersDataGridView.RowTemplate.Height = 29
        Me.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UsersDataGridView.Size = New System.Drawing.Size(1344, 557)
        Me.UsersDataGridView.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(1148, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 36)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Actions"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(690, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 36)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(354, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 36)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Role"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(17, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 36)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Name"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'userManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1371, 747)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "userManagement"
        Me.Text = "userManagement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.UsersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddUserButton As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents UsersDataGridView As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
End Class
