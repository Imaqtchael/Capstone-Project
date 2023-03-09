<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home))
        Me.TrackingReportButton = New System.Windows.Forms.Button()
        Me.GuestManagementButton = New System.Windows.Forms.Button()
        Me.EventManagementButton = New System.Windows.Forms.Button()
        Me.UserManagementButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.LogoutButton = New System.Windows.Forms.Button()
        Me.ControlView = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.AnalyticsButton = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrackingReportButton
        '
        Me.TrackingReportButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TrackingReportButton.Enabled = False
        Me.TrackingReportButton.FlatAppearance.BorderSize = 0
        Me.TrackingReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.TrackingReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TrackingReportButton.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.TrackingReportButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.TrackingReportButton.Image = CType(resources.GetObject("TrackingReportButton.Image"), System.Drawing.Image)
        Me.TrackingReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.TrackingReportButton.Location = New System.Drawing.Point(95, 49)
        Me.TrackingReportButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TrackingReportButton.Name = "TrackingReportButton"
        Me.TrackingReportButton.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.TrackingReportButton.Size = New System.Drawing.Size(240, 48)
        Me.TrackingReportButton.TabIndex = 0
        Me.TrackingReportButton.Text = "Tracking Report"
        Me.TrackingReportButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.TrackingReportButton.UseVisualStyleBackColor = False
        '
        'GuestManagementButton
        '
        Me.GuestManagementButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GuestManagementButton.Enabled = False
        Me.GuestManagementButton.FlatAppearance.BorderSize = 0
        Me.GuestManagementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.GuestManagementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GuestManagementButton.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GuestManagementButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GuestManagementButton.Image = CType(resources.GetObject("GuestManagementButton.Image"), System.Drawing.Image)
        Me.GuestManagementButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GuestManagementButton.Location = New System.Drawing.Point(335, 49)
        Me.GuestManagementButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GuestManagementButton.Name = "GuestManagementButton"
        Me.GuestManagementButton.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.GuestManagementButton.Size = New System.Drawing.Size(240, 48)
        Me.GuestManagementButton.TabIndex = 0
        Me.GuestManagementButton.Text = "Guest Management"
        Me.GuestManagementButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.GuestManagementButton.UseVisualStyleBackColor = False
        '
        'EventManagementButton
        '
        Me.EventManagementButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.EventManagementButton.Enabled = False
        Me.EventManagementButton.FlatAppearance.BorderSize = 0
        Me.EventManagementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.EventManagementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EventManagementButton.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.EventManagementButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.EventManagementButton.Image = CType(resources.GetObject("EventManagementButton.Image"), System.Drawing.Image)
        Me.EventManagementButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EventManagementButton.Location = New System.Drawing.Point(575, 49)
        Me.EventManagementButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EventManagementButton.Name = "EventManagementButton"
        Me.EventManagementButton.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.EventManagementButton.Size = New System.Drawing.Size(240, 48)
        Me.EventManagementButton.TabIndex = 0
        Me.EventManagementButton.Text = "Event Management"
        Me.EventManagementButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.EventManagementButton.UseVisualStyleBackColor = False
        '
        'UserManagementButton
        '
        Me.UserManagementButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.UserManagementButton.Enabled = False
        Me.UserManagementButton.FlatAppearance.BorderSize = 0
        Me.UserManagementButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.UserManagementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UserManagementButton.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.UserManagementButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.UserManagementButton.Image = CType(resources.GetObject("UserManagementButton.Image"), System.Drawing.Image)
        Me.UserManagementButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.UserManagementButton.Location = New System.Drawing.Point(815, 49)
        Me.UserManagementButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UserManagementButton.Name = "UserManagementButton"
        Me.UserManagementButton.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.UserManagementButton.Size = New System.Drawing.Size(240, 48)
        Me.UserManagementButton.TabIndex = 0
        Me.UserManagementButton.Text = "User Management"
        Me.UserManagementButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.UserManagementButton.UseVisualStyleBackColor = False
        '
        'ExitButton
        '
        Me.ExitButton.BackColor = System.Drawing.Color.BlueViolet
        Me.ExitButton.FlatAppearance.BorderSize = 0
        Me.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExitButton.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ExitButton.ForeColor = System.Drawing.Color.White
        Me.ExitButton.Image = CType(resources.GetObject("ExitButton.Image"), System.Drawing.Image)
        Me.ExitButton.Location = New System.Drawing.Point(1353, 3)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(41, 35)
        Me.ExitButton.TabIndex = 0
        Me.ExitButton.UseVisualStyleBackColor = False
        '
        'LogoutButton
        '
        Me.LogoutButton.BackColor = System.Drawing.Color.BlueViolet
        Me.LogoutButton.FlatAppearance.BorderSize = 0
        Me.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogoutButton.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LogoutButton.ForeColor = System.Drawing.Color.White
        Me.LogoutButton.Image = CType(resources.GetObject("LogoutButton.Image"), System.Drawing.Image)
        Me.LogoutButton.Location = New System.Drawing.Point(1, 3)
        Me.LogoutButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LogoutButton.Name = "LogoutButton"
        Me.LogoutButton.Size = New System.Drawing.Size(41, 35)
        Me.LogoutButton.TabIndex = 0
        Me.LogoutButton.UseVisualStyleBackColor = False
        '
        'ControlView
        '
        Me.ControlView.Location = New System.Drawing.Point(95, 90)
        Me.ControlView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ControlView.Name = "ControlView"
        Me.ControlView.Size = New System.Drawing.Size(1200, 560)
        Me.ControlView.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.BlueViolet
        Me.Panel2.Controls.Add(Me.LogoutButton)
        Me.Panel2.Controls.Add(Me.ExitButton)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1400, 40)
        Me.Panel2.TabIndex = 2
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20000
        '
        'AnalyticsButton
        '
        Me.AnalyticsButton.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AnalyticsButton.Enabled = False
        Me.AnalyticsButton.FlatAppearance.BorderSize = 0
        Me.AnalyticsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.AnalyticsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AnalyticsButton.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.AnalyticsButton.ForeColor = System.Drawing.Color.DodgerBlue
        Me.AnalyticsButton.Image = CType(resources.GetObject("AnalyticsButton.Image"), System.Drawing.Image)
        Me.AnalyticsButton.Location = New System.Drawing.Point(1054, 49)
        Me.AnalyticsButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AnalyticsButton.Name = "AnalyticsButton"
        Me.AnalyticsButton.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.AnalyticsButton.Size = New System.Drawing.Size(240, 48)
        Me.AnalyticsButton.TabIndex = 0
        Me.AnalyticsButton.Text = "Analytics"
        Me.AnalyticsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.AnalyticsButton.UseVisualStyleBackColor = False
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1400, 675)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ControlView)
        Me.Controls.Add(Me.UserManagementButton)
        Me.Controls.Add(Me.EventManagementButton)
        Me.Controls.Add(Me.GuestManagementButton)
        Me.Controls.Add(Me.TrackingReportButton)
        Me.Controls.Add(Me.AnalyticsButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "home"
        Me.Text = "home"
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TrackingReportButton As Button
    Friend WithEvents GuestManagementButton As Button
    Friend WithEvents EventManagementButton As Button
    Friend WithEvents UserManagementButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents LogoutButton As Button
    Friend WithEvents ControlView As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents AnalyticsButton As Button
End Class
