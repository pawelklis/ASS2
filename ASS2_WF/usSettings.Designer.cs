namespace ASS2_WF
{
    partial class usSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txdelay = new System.Windows.Forms.NumericUpDown();
            this.txspeed = new System.Windows.Forms.NumericUpDown();
            this.txCom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtactscount = new System.Windows.Forms.NumericUpDown();
            this.txparcelstoptactnumber = new System.Windows.Forms.NumericUpDown();
            this.txstartdetectionparcel = new System.Windows.Forms.NumericUpDown();
            this.txstopsensortact = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txdelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtactscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txparcelstoptactnumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txstartdetectionparcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txstopsensortact)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port COM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prędkość";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Opóźnienie odczytu[ms]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txdelay);
            this.groupBox1.Controls.Add(this.txspeed);
            this.groupBox1.Controls.Add(this.txCom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skaner";
            // 
            // txdelay
            // 
            this.txdelay.Location = new System.Drawing.Point(287, 92);
            this.txdelay.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txdelay.Name = "txdelay";
            this.txdelay.Size = new System.Drawing.Size(120, 29);
            this.txdelay.TabIndex = 10;
            // 
            // txspeed
            // 
            this.txspeed.Location = new System.Drawing.Point(287, 59);
            this.txspeed.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txspeed.Name = "txspeed";
            this.txspeed.Size = new System.Drawing.Size(120, 29);
            this.txspeed.TabIndex = 9;
            // 
            // txCom
            // 
            this.txCom.Location = new System.Drawing.Point(287, 25);
            this.txCom.Name = "txCom";
            this.txCom.Size = new System.Drawing.Size(121, 29);
            this.txCom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Liczba wszystkch taktów";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Czujnik STOP numer taktu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(251, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Numer taktu zatrzymania przesyłki";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(272, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Czujnik detekcji przesyłki numer taktu";
            // 
            // txtactscount
            // 
            this.txtactscount.Location = new System.Drawing.Point(288, 28);
            this.txtactscount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtactscount.Name = "txtactscount";
            this.txtactscount.Size = new System.Drawing.Size(120, 29);
            this.txtactscount.TabIndex = 8;
            // 
            // txparcelstoptactnumber
            // 
            this.txparcelstoptactnumber.Location = new System.Drawing.Point(288, 63);
            this.txparcelstoptactnumber.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txparcelstoptactnumber.Name = "txparcelstoptactnumber";
            this.txparcelstoptactnumber.Size = new System.Drawing.Size(120, 29);
            this.txparcelstoptactnumber.TabIndex = 9;
            // 
            // txstartdetectionparcel
            // 
            this.txstartdetectionparcel.Location = new System.Drawing.Point(288, 98);
            this.txstartdetectionparcel.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txstartdetectionparcel.Name = "txstartdetectionparcel";
            this.txstartdetectionparcel.Size = new System.Drawing.Size(120, 29);
            this.txstartdetectionparcel.TabIndex = 10;
            // 
            // txstopsensortact
            // 
            this.txstopsensortact.Location = new System.Drawing.Point(288, 133);
            this.txstopsensortact.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txstopsensortact.Name = "txstopsensortact";
            this.txstopsensortact.Size = new System.Drawing.Size(120, 29);
            this.txstopsensortact.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtactscount);
            this.groupBox2.Controls.Add(this.txstopsensortact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txstartdetectionparcel);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txparcelstoptactnumber);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(15, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 181);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametry";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "Zapisz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(491, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 552);
            this.panel1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(0, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(471, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "*Po zapisaniu ustawień należy uruchomić nowy przebieg aby ustawienia weszły do uż" +
    "ytku.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Taktowanie stanowisk";
            // 
            // usSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "usSettings";
            this.Size = new System.Drawing.Size(939, 588);
            this.Load += new System.EventHandler(this.usSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txdelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtactscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txparcelstoptactnumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txstartdetectionparcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txstopsensortact)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txCom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtactscount;
        private System.Windows.Forms.NumericUpDown txparcelstoptactnumber;
        private System.Windows.Forms.NumericUpDown txstartdetectionparcel;
        private System.Windows.Forms.NumericUpDown txstopsensortact;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown txdelay;
        private System.Windows.Forms.NumericUpDown txspeed;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button S2L2;
        private System.Windows.Forms.NumericUpDown S2NM1;
        private System.Windows.Forms.Button S2L1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}
