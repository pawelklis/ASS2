namespace ASS2_WF
{
    partial class usWork
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.cbSortProgram = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbsp = new System.Windows.Forms.Label();
            this.lbtactnumber = new System.Windows.Forms.Label();
            this.lbcirclenumber = new System.Windows.Forms.Label();
            this.lbparcelsonline = new System.Windows.Forms.Label();
            this.lbFeederParcels = new System.Windows.Forms.Label();
            this.lbTactTime = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbRun = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbAllsorted = new System.Windows.Forms.Label();
            this.lbAllMissed = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 154);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 74);
            this.panel1.TabIndex = 1;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // btnStartRun
            // 
            this.btnStartRun.Location = new System.Drawing.Point(639, 14);
            this.btnStartRun.Name = "btnStartRun";
            this.btnStartRun.Size = new System.Drawing.Size(115, 38);
            this.btnStartRun.TabIndex = 2;
            this.btnStartRun.Text = "Start";
            this.btnStartRun.UseVisualStyleBackColor = true;
            this.btnStartRun.Click += new System.EventHandler(this.btnStartRun_Click);
            // 
            // cbSortProgram
            // 
            this.cbSortProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSortProgram.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbSortProgram.FormattingEnabled = true;
            this.cbSortProgram.Location = new System.Drawing.Point(228, 13);
            this.cbSortProgram.Name = "cbSortProgram";
            this.cbSortProgram.Size = new System.Drawing.Size(394, 38);
            this.cbSortProgram.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program sortowniczy";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.lbsp);
            this.panel2.Controls.Add(this.lbtactnumber);
            this.panel2.Controls.Add(this.lbcirclenumber);
            this.panel2.Controls.Add(this.lbparcelsonline);
            this.panel2.Controls.Add(this.lbFeederParcels);
            this.panel2.Controls.Add(this.lbTactTime);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.lbRun);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 735);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1070, 29);
            this.panel2.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(595, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(394, 29);
            this.listBox1.TabIndex = 9;
            // 
            // lbsp
            // 
            this.lbsp.AutoSize = true;
            this.lbsp.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbsp.Location = new System.Drawing.Point(376, 0);
            this.lbsp.Name = "lbsp";
            this.lbsp.Size = new System.Drawing.Size(219, 21);
            this.lbsp.TabIndex = 8;
            this.lbsp.Text = "Wybierz program sortowniczy";
            // 
            // lbtactnumber
            // 
            this.lbtactnumber.AutoSize = true;
            this.lbtactnumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbtactnumber.Location = new System.Drawing.Point(357, 0);
            this.lbtactnumber.Name = "lbtactnumber";
            this.lbtactnumber.Size = new System.Drawing.Size(19, 21);
            this.lbtactnumber.TabIndex = 7;
            this.lbtactnumber.Text = "0";
            // 
            // lbcirclenumber
            // 
            this.lbcirclenumber.AutoSize = true;
            this.lbcirclenumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbcirclenumber.Location = new System.Drawing.Point(338, 0);
            this.lbcirclenumber.Name = "lbcirclenumber";
            this.lbcirclenumber.Size = new System.Drawing.Size(19, 21);
            this.lbcirclenumber.TabIndex = 6;
            this.lbcirclenumber.Text = "0";
            // 
            // lbparcelsonline
            // 
            this.lbparcelsonline.AutoSize = true;
            this.lbparcelsonline.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbparcelsonline.Location = new System.Drawing.Point(319, 0);
            this.lbparcelsonline.Name = "lbparcelsonline";
            this.lbparcelsonline.Size = new System.Drawing.Size(19, 21);
            this.lbparcelsonline.TabIndex = 5;
            this.lbparcelsonline.Text = "0";
            // 
            // lbFeederParcels
            // 
            this.lbFeederParcels.AutoSize = true;
            this.lbFeederParcels.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbFeederParcels.Location = new System.Drawing.Point(300, 0);
            this.lbFeederParcels.Name = "lbFeederParcels";
            this.lbFeederParcels.Size = new System.Drawing.Size(19, 21);
            this.lbFeederParcels.TabIndex = 4;
            this.lbFeederParcels.Text = "0";
            // 
            // lbTactTime
            // 
            this.lbTactTime.AutoSize = true;
            this.lbTactTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbTactTime.Location = new System.Drawing.Point(250, 0);
            this.lbTactTime.Name = "lbTactTime";
            this.lbTactTime.Size = new System.Drawing.Size(50, 21);
            this.lbTactTime.TabIndex = 3;
            this.lbTactTime.Text = "0[ms]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox2.Image = global::ASS2_WF.Properties.Resources.workoff;
            this.pictureBox2.Location = new System.Drawing.Point(204, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(114, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(90, 29);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Maszyna";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lbRun
            // 
            this.lbRun.AutoSize = true;
            this.lbRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRun.Location = new System.Drawing.Point(0, 0);
            this.lbRun.Name = "lbRun";
            this.lbRun.Size = new System.Drawing.Size(114, 21);
            this.lbRun.TabIndex = 0;
            this.lbRun.Text = "Przebieg: STOP";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnStartRun);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbSortProgram);
            this.panel3.Location = new System.Drawing.Point(141, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 66);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.chart1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 228);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1070, 268);
            this.panel4.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1070, 268);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Resize += new System.EventHandler(this.chart1_Resize);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chart2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 496);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1070, 239);
            this.panel5.TabIndex = 5;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(1070, 239);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(954, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::ASS2_WF.Properties.Resources.masp;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbAllsorted
            // 
            this.lbAllsorted.AutoSize = true;
            this.lbAllsorted.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbAllsorted.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbAllsorted.Location = new System.Drawing.Point(3, 22);
            this.lbAllsorted.Name = "lbAllsorted";
            this.lbAllsorted.Size = new System.Drawing.Size(46, 54);
            this.lbAllsorted.TabIndex = 7;
            this.lbAllsorted.Text = "0";
            // 
            // lbAllMissed
            // 
            this.lbAllMissed.AutoSize = true;
            this.lbAllMissed.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbAllMissed.ForeColor = System.Drawing.Color.DarkRed;
            this.lbAllMissed.Location = new System.Drawing.Point(3, 98);
            this.lbAllMissed.Name = "lbAllMissed";
            this.lbAllMissed.Size = new System.Drawing.Size(46, 54);
            this.lbAllMissed.TabIndex = 8;
            this.lbAllMissed.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Wysortowane";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "Recyrkulacja";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(960, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(142, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(756, 130);
            this.label4.TabIndex = 14;
            this.label4.Text = "BRAK POŁĄCZENIA\r\nZE STEROWNIKIEM MASZYNY!!!";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // usWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAllMissed);
            this.Controls.Add(this.lbAllsorted);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "usWork";
            this.Size = new System.Drawing.Size(1070, 764);
            this.Load += new System.EventHandler(this.usWork_Load);
            this.Resize += new System.EventHandler(this.usWork_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSortProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartRun;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbRun;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbTactTime;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbFeederParcels;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbparcelsonline;
        private System.Windows.Forms.Label lbtactnumber;
        private System.Windows.Forms.Label lbcirclenumber;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Label lbsp;
        private System.Windows.Forms.Label lbAllsorted;
        private System.Windows.Forms.Label lbAllMissed;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label4;
    }
}
