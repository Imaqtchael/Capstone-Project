<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class analyticsReport
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.EventsChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EventChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.EventCountLabel = New System.Windows.Forms.Label()
        Me.GuestCountLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OverallBookedLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GuestsChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        CType(Me.EventsChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.EventChart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuestsChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EventsChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.EventsChart.ChartAreas.Add(ChartArea1)
        Me.EventsChart.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.EventsChart.Legends.Add(Legend1)
        Me.EventsChart.Location = New System.Drawing.Point(0, 0)
        Me.EventsChart.Name = "EventsChart"
        Me.EventsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Series1.BackSecondaryColor = System.Drawing.Color.Silver
        Series1.ChartArea = "ChartArea1"
        Series1.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Series1.Legend = "Legend1"
        Series1.Name = "Event Count"
        Me.EventsChart.Series.Add(Series1)
        Me.EventsChart.Size = New System.Drawing.Size(1371, 373)
        Me.EventsChart.TabIndex = 1
        Me.EventsChart.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.EventsChart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 374)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 373)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.EventChart)
        Me.Panel2.Controls.Add(Me.EventCountLabel)
        Me.Panel2.Controls.Add(Me.GuestCountLabel)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.OverallBookedLabel)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.GuestsChart)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1371, 374)
        Me.Panel2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(779, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 40)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Events"
        '
        'EventChart
        '
        ChartArea2.Name = "ChartArea1"
        Me.EventChart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.EventChart.Legends.Add(Legend2)
        Me.EventChart.Location = New System.Drawing.Point(682, 80)
        Me.EventChart.Name = "EventChart"
        Me.EventChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series2.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Series2.IsValueShownAsLabel = True
        Series2.Legend = "Legend1"
        Series2.Name = "Events"
        Me.EventChart.Series.Add(Series2)
        Me.EventChart.Size = New System.Drawing.Size(296, 222)
        Me.EventChart.TabIndex = 2
        Me.EventChart.Text = "Chart1"
        '
        'EventCountLabel
        '
        Me.EventCountLabel.AutoSize = True
        Me.EventCountLabel.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.EventCountLabel.Location = New System.Drawing.Point(129, 152)
        Me.EventCountLabel.Name = "EventCountLabel"
        Me.EventCountLabel.Size = New System.Drawing.Size(310, 58)
        Me.EventCountLabel.TabIndex = 1
        Me.EventCountLabel.Text = "<accomodated>"
        '
        'GuestCountLabel
        '
        Me.GuestCountLabel.AutoSize = True
        Me.GuestCountLabel.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.GuestCountLabel.Location = New System.Drawing.Point(130, 258)
        Me.GuestCountLabel.Name = "GuestCountLabel"
        Me.GuestCountLabel.Size = New System.Drawing.Size(178, 58)
        Me.GuestCountLabel.TabIndex = 1
        Me.GuestCountLabel.Text = "<guests>"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(39, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(252, 30)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Total events accomodated: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(39, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total booked events:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(39, 220)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(121, 30)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Total guest : "
        '
        'OverallBookedLabel
        '
        Me.OverallBookedLabel.AutoSize = True
        Me.OverallBookedLabel.Font = New System.Drawing.Font("Poppins", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.OverallBookedLabel.Location = New System.Drawing.Point(130, 62)
        Me.OverallBookedLabel.Name = "OverallBookedLabel"
        Me.OverallBookedLabel.Size = New System.Drawing.Size(192, 58)
        Me.OverallBookedLabel.TabIndex = 1
        Me.OverallBookedLabel.Text = "<booked>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(1133, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Guests"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(66, 318)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(430, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Events booked for the last 8 months"
        '
        'GuestsChart
        '
        ChartArea3.Name = "ChartArea1"
        Me.GuestsChart.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.GuestsChart.Legends.Add(Legend3)
        Me.GuestsChart.Location = New System.Drawing.Point(1043, 80)
        Me.GuestsChart.Name = "GuestsChart"
        Me.GuestsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series3.Font = New System.Drawing.Font("Poppins", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Series3.IsValueShownAsLabel = True
        Series3.Legend = "Legend1"
        Series3.Name = "Guest Attending Percentage"
        Me.GuestsChart.Series.Add(Series3)
        Me.GuestsChart.Size = New System.Drawing.Size(296, 222)
        Me.GuestsChart.TabIndex = 0
        Me.GuestsChart.Text = "Chart1"
        '
        'analyticsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1371, 747)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "analyticsReport"
        Me.Text = "analyticsReport"
        CType(Me.EventsChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.EventChart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuestsChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents EventsChart As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents OverallBookedLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GuestsChart As DataVisualization.Charting.Chart
    Friend WithEvents GuestCountLabel As Label
    Friend WithEvents EventCountLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents EventChart As DataVisualization.Charting.Chart
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
End Class
