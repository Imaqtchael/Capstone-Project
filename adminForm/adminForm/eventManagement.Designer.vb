<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class eventManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eventManagement))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TypeComboBox = New System.Windows.Forms.ComboBox()
        Me.RegisterGuestButton = New System.Windows.Forms.Button()
        Me.AddEventButton = New System.Windows.Forms.Button()
        Me.SearchTextBox = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EventDataGridView = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.EventDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TypeComboBox)
        Me.Panel1.Controls.Add(Me.RegisterGuestButton)
        Me.Panel1.Controls.Add(Me.AddEventButton)
        Me.Panel1.Controls.Add(Me.SearchTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 80)
        Me.Panel1.TabIndex = 6
        '
        'TypeComboBox
        '
        Me.TypeComboBox.BackColor = System.Drawing.Color.Gainsboro
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TypeComboBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Items.AddRange(New Object() {"FINISHED EVENTS", "UNFINISHED EVENTS", "ALL EVENTS"})
        Me.TypeComboBox.Location = New System.Drawing.Point(767, 19)
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(240, 44)
        Me.TypeComboBox.TabIndex = 6
        '
        'RegisterGuestButton
        '
        Me.RegisterGuestButton.BackColor = System.Drawing.Color.BlueViolet
        Me.RegisterGuestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RegisterGuestButton.ForeColor = System.Drawing.Color.White
        Me.RegisterGuestButton.Image = CType(resources.GetObject("RegisterGuestButton.Image"), System.Drawing.Image)
        Me.RegisterGuestButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RegisterGuestButton.Location = New System.Drawing.Point(1013, 13)
        Me.RegisterGuestButton.Name = "RegisterGuestButton"
        Me.RegisterGuestButton.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.RegisterGuestButton.Size = New System.Drawing.Size(179, 53)
        Me.RegisterGuestButton.TabIndex = 5
        Me.RegisterGuestButton.Text = "REGISTER GUESTS"
        Me.RegisterGuestButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.RegisterGuestButton.UseVisualStyleBackColor = False
        '
        'AddEventButton
        '
        Me.AddEventButton.BackColor = System.Drawing.Color.BlueViolet
        Me.AddEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddEventButton.ForeColor = System.Drawing.Color.White
        Me.AddEventButton.Image = CType(resources.GetObject("AddEventButton.Image"), System.Drawing.Image)
        Me.AddEventButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddEventButton.Location = New System.Drawing.Point(1198, 13)
        Me.AddEventButton.Name = "AddEventButton"
        Me.AddEventButton.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.AddEventButton.Size = New System.Drawing.Size(160, 53)
        Me.AddEventButton.TabIndex = 5
        Me.AddEventButton.Text = "ADD EVENT"
        Me.AddEventButton.UseVisualStyleBackColor = False
        '
        'SearchTextBox
        '
        Me.SearchTextBox.BackColor = System.Drawing.Color.LightGray
        Me.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SearchTextBox.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.SearchTextBox.Location = New System.Drawing.Point(14, 20)
        Me.SearchTextBox.Name = "SearchTextBox"
        Me.SearchTextBox.PlaceholderText = " Search Event"
        Me.SearchTextBox.Size = New System.Drawing.Size(314, 30)
        Me.SearchTextBox.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.EventDataGridView)
        Me.Panel4.Controls.Add(Me.Label11)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(659, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 36)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Is Paid"
        '
        'EventDataGridView
        '
        Me.EventDataGridView.AllowUserToAddRows = False
        Me.EventDataGridView.AllowUserToDeleteRows = False
        Me.EventDataGridView.AllowUserToResizeColumns = False
        Me.EventDataGridView.AllowUserToResizeRows = False
        Me.EventDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.EventDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.EventDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.EventDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.EventDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.EventDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EventDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EventDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.EventDataGridView.Location = New System.Drawing.Point(14, 69)
        Me.EventDataGridView.MultiSelect = False
        Me.EventDataGridView.Name = "EventDataGridView"
        Me.EventDataGridView.ReadOnly = True
        Me.EventDataGridView.RowHeadersVisible = False
        Me.EventDataGridView.RowHeadersWidth = 51
        Me.EventDataGridView.RowTemplate.DividerHeight = 1
        Me.EventDataGridView.RowTemplate.Height = 29
        Me.EventDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EventDataGridView.Size = New System.Drawing.Size(1344, 557)
        Me.EventDataGridView.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(1077, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 36)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Actions"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label10.Location = New System.Drawing.Point(446, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 36)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label9.Location = New System.Drawing.Point(231, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 36)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label8.Location = New System.Drawing.Point(17, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 36)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Event"
        '
        'eventManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1371, 747)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "eventManagement"
        Me.Text = "eventManagement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.EventDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddEventButton As Button
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents EventDataGridView As DataGridView
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents RegisterGuestButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TypeComboBox As ComboBox
End Class
