<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class trackingReportGuestLog
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(trackingReportGuestLog))
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.LogsDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackButton = New System.Windows.Forms.Button()
        CType(Me.LogsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NameLabel
        '
        Me.NameLabel.BackColor = System.Drawing.Color.BlueViolet
        Me.NameLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.NameLabel.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.NameLabel.ForeColor = System.Drawing.Color.White
        Me.NameLabel.Location = New System.Drawing.Point(0, 0)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(571, 81)
        Me.NameLabel.TabIndex = 0
        Me.NameLabel.Text = ":NAME:"
        Me.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogsDataGridView
        '
        Me.LogsDataGridView.AllowUserToAddRows = False
        Me.LogsDataGridView.AllowUserToDeleteRows = False
        Me.LogsDataGridView.AllowUserToResizeColumns = False
        Me.LogsDataGridView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LogsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.LogsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.LogsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.LogsDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.LogsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LogsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.LogsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.LogsDataGridView.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LogsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.LogsDataGridView.Location = New System.Drawing.Point(11, 47)
        Me.LogsDataGridView.Name = "LogsDataGridView"
        Me.LogsDataGridView.ReadOnly = True
        Me.LogsDataGridView.RowHeadersVisible = False
        Me.LogsDataGridView.RowHeadersWidth = 51
        Me.LogsDataGridView.RowTemplate.Height = 29
        Me.LogsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.LogsDataGridView.Size = New System.Drawing.Size(545, 619)
        Me.LogsDataGridView.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.LogsDataGridView)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(3, 95)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(565, 679)
        Me.Panel1.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(29, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Time in"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(291, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 36)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Time out"
        '
        'BackButton
        '
        Me.BackButton.BackColor = System.Drawing.Color.LightGray
        Me.BackButton.FlatAppearance.BorderSize = 0
        Me.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BackButton.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.BackButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.BackButton.Location = New System.Drawing.Point(411, 789)
        Me.BackButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BackButton.Name = "BackButton"
        Me.BackButton.Size = New System.Drawing.Size(149, 43)
        Me.BackButton.TabIndex = 6
        Me.BackButton.Text = "BACK TO HOME"
        Me.BackButton.UseVisualStyleBackColor = False
        '
        'trackingReportGuestLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(571, 845)
        Me.Controls.Add(Me.BackButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.NameLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "trackingReportGuestLog"
        Me.ShowInTaskbar = False
        Me.Text = "guestLog"
        CType(Me.LogsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NameLabel As Label
    Friend WithEvents LogsDataGridView As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BackButton As Button
End Class
