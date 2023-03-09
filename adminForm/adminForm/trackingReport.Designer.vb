<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trackingReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GuestSearchTextBox = New System.Windows.Forms.TextBox()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.TrackingDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GuestInLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GuestOutLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.EventsComboBox = New System.Windows.Forms.ComboBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.TrackingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GuestSearchTextBox
        '
        Me.GuestSearchTextBox.BackColor = System.Drawing.Color.LightGray
        Me.GuestSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GuestSearchTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestSearchTextBox.Location = New System.Drawing.Point(11, 213)
        Me.GuestSearchTextBox.Name = "GuestSearchTextBox"
        Me.GuestSearchTextBox.PlaceholderText = "Search Guest"
        Me.GuestSearchTextBox.Size = New System.Drawing.Size(314, 30)
        Me.GuestSearchTextBox.TabIndex = 0
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DateLabel.Location = New System.Drawing.Point(11, 75)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(47, 26)
        Me.DateLabel.TabIndex = 1
        Me.DateLabel.Text = "Date"
        '
        'TrackingDataGridView
        '
        Me.TrackingDataGridView.AllowUserToAddRows = False
        Me.TrackingDataGridView.AllowUserToDeleteRows = False
        Me.TrackingDataGridView.AllowUserToResizeColumns = False
        Me.TrackingDataGridView.AllowUserToResizeRows = False
        Me.TrackingDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TrackingDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.TrackingDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.TrackingDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrackingDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.TrackingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TrackingDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.TrackingDataGridView.DefaultCellStyle = DataGridViewCellStyle1
        Me.TrackingDataGridView.Location = New System.Drawing.Point(14, 69)
        Me.TrackingDataGridView.MultiSelect = False
        Me.TrackingDataGridView.Name = "TrackingDataGridView"
        Me.TrackingDataGridView.ReadOnly = True
        Me.TrackingDataGridView.RowHeadersVisible = False
        Me.TrackingDataGridView.RowHeadersWidth = 51
        Me.TrackingDataGridView.RowTemplate.DividerHeight = 1
        Me.TrackingDataGridView.RowTemplate.Height = 29
        Me.TrackingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.TrackingDataGridView.Size = New System.Drawing.Size(1344, 409)
        Me.TrackingDataGridView.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.GuestInLabel)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(1000, 19)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(151, 91)
        Me.Panel1.TabIndex = 4
        '
        'GuestInLabel
        '
        Me.GuestInLabel.AutoSize = True
        Me.GuestInLabel.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestInLabel.ForeColor = System.Drawing.Color.White
        Me.GuestInLabel.Location = New System.Drawing.Point(17, 16)
        Me.GuestInLabel.Name = "GuestInLabel"
        Me.GuestInLabel.Size = New System.Drawing.Size(76, 36)
        Me.GuestInLabel.TabIndex = 1
        Me.GuestInLabel.Text = "Count"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(17, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 26)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Guest In"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Orange
        Me.Panel2.Controls.Add(Me.GuestOutLabel)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(1183, 19)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(151, 91)
        Me.Panel2.TabIndex = 4
        '
        'GuestOutLabel
        '
        Me.GuestOutLabel.AutoSize = True
        Me.GuestOutLabel.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestOutLabel.ForeColor = System.Drawing.Color.White
        Me.GuestOutLabel.Location = New System.Drawing.Point(16, 16)
        Me.GuestOutLabel.Name = "GuestOutLabel"
        Me.GuestOutLabel.Size = New System.Drawing.Size(76, 36)
        Me.GuestOutLabel.TabIndex = 1
        Me.GuestOutLabel.Text = "Count"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(16, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 26)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Total Guest"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.EventsComboBox)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.DateLabel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1371, 203)
        Me.Panel3.TabIndex = 5
        '
        'EventsComboBox
        '
        Me.EventsComboBox.BackColor = System.Drawing.Color.Gainsboro
        Me.EventsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EventsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EventsComboBox.Font = New System.Drawing.Font("Poppins", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventsComboBox.FormattingEnabled = True
        Me.EventsComboBox.Location = New System.Drawing.Point(11, 12)
        Me.EventsComboBox.Name = "EventsComboBox"
        Me.EventsComboBox.Size = New System.Drawing.Size(517, 56)
        Me.EventsComboBox.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.TrackingDataGridView)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 254)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1371, 493)
        Me.Panel4.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(1027, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 36)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Time out"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(693, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 36)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Time in"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(354, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 36)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Date"
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
        'trackingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1371, 747)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GuestSearchTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "trackingReport"
        Me.Text = "trackingReport"
        CType(Me.TrackingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GuestSearchTextBox As TextBox
    Friend WithEvents DateLabel As Label
    Friend WithEvents TrackingDataGridView As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GuestInLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GuestOutLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents EventsComboBox As ComboBox
End Class
