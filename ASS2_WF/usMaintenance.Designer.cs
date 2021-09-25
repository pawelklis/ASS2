namespace ASS2_WF
{
    partial class usMaintenance
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbCounter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.lbdetectp = new System.Windows.Forms.Label();
            this.lbstopp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.lbdetectionsensortact = new System.Windows.Forms.Label();
            this.lbstopsensortact = new System.Windows.Forms.Label();
            this.lbparceltact = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtc = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbtc);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.lbCounter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 108);
            this.panel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(713, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(279, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Czas, stały numer taktu, bieżący takt od czujnika start";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1083, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(82, 35);
            this.button8.TabIndex = 3;
            this.button8.Text = "Wyczyść";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(716, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 88);
            this.listBox1.TabIndex = 2;
            // 
            // lbCounter
            // 
            this.lbCounter.AutoSize = true;
            this.lbCounter.Font = new System.Drawing.Font("Segoe UI", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbCounter.Location = new System.Drawing.Point(334, 0);
            this.lbCounter.Name = "lbCounter";
            this.lbCounter.Size = new System.Drawing.Size(174, 106);
            this.lbCounter.TabIndex = 0;
            this.lbCounter.Text = "000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Licznik taktu, czujnik start zeruje licznik";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 166);
            this.panel2.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(963, 83);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(225, 52);
            this.button6.TabIndex = 7;
            this.button6.Text = "Test wyłącz";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(733, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(225, 52);
            this.button5.TabIndex = 6;
            this.button5.Text = "Test włącz";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(733, 50);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(455, 29);
            this.comboBox2.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(733, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(455, 29);
            this.comboBox1.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(370, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(313, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Test lamp zgaś wszystkie";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(370, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(313, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "Test lamp zapal wszystkie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(31, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(313, 52);
            this.button2.TabIndex = 1;
            this.button2.Text = "Test lamp pojedynczo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test lamp sekwencyjny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.lbdetectp);
            this.panel3.Controls.Add(this.lbstopp);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.button7);
            this.panel3.Controls.Add(this.lbdetectionsensortact);
            this.panel3.Controls.Add(this.lbstopsensortact);
            this.panel3.Controls.Add(this.lbparceltact);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1225, 170);
            this.panel3.TabIndex = 5;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(963, 102);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(225, 52);
            this.button9.TabIndex = 13;
            this.button9.Text = "Restart systemu";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // lbdetectp
            // 
            this.lbdetectp.AutoSize = true;
            this.lbdetectp.Location = new System.Drawing.Point(439, 135);
            this.lbdetectp.Name = "lbdetectp";
            this.lbdetectp.Size = new System.Drawing.Size(19, 21);
            this.lbdetectp.TabIndex = 12;
            this.lbdetectp.Text = "0";
            // 
            // lbstopp
            // 
            this.lbstopp.AutoSize = true;
            this.lbstopp.Location = new System.Drawing.Point(439, 102);
            this.lbstopp.Name = "lbstopp";
            this.lbstopp.Size = new System.Drawing.Size(19, 21);
            this.lbstopp.TabIndex = 11;
            this.lbstopp.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ustawione parametry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(786, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Wciśnij Uruchom test, następnie uruchom przenośnik i pozwól przesyłce wykonać peł" +
    "ne okrążenie/kilka okrążeń.";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(481, 102);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(225, 52);
            this.button7.TabIndex = 8;
            this.button7.Text = "Uruchom test";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lbdetectionsensortact
            // 
            this.lbdetectionsensortact.AutoSize = true;
            this.lbdetectionsensortact.Location = new System.Drawing.Point(274, 135);
            this.lbdetectionsensortact.Name = "lbdetectionsensortact";
            this.lbdetectionsensortact.Size = new System.Drawing.Size(19, 21);
            this.lbdetectionsensortact.TabIndex = 6;
            this.lbdetectionsensortact.Text = "0";
            // 
            // lbstopsensortact
            // 
            this.lbstopsensortact.AutoSize = true;
            this.lbstopsensortact.Location = new System.Drawing.Point(274, 102);
            this.lbstopsensortact.Name = "lbstopsensortact";
            this.lbstopsensortact.Size = new System.Drawing.Size(19, 21);
            this.lbstopsensortact.TabIndex = 5;
            this.lbstopsensortact.Text = "0";
            // 
            // lbparceltact
            // 
            this.lbparceltact.AutoSize = true;
            this.lbparceltact.Location = new System.Drawing.Point(274, 69);
            this.lbparceltact.Name = "lbparceltact";
            this.lbparceltact.Size = new System.Drawing.Size(19, 21);
            this.lbparceltact.TabIndex = 4;
            this.lbparceltact.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Takt czujnika detekcji przesyłki:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Takt czujnika STOP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Takt przesyłki:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(730, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Przygotuj na taśmie jedną przesyłkę przed czujnikiem Start. Program policzy liczb" +
    "ę taktów dla czujników.";
            // 
            // lbtc
            // 
            this.lbtc.AutoSize = true;
            this.lbtc.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbtc.Location = new System.Drawing.Point(45, 43);
            this.lbtc.Name = "lbtc";
            this.lbtc.Size = new System.Drawing.Size(89, 54);
            this.lbtc.TabIndex = 5;
            this.lbtc.Text = "000";
            // 
            // usMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "usMaintenance";
            this.Size = new System.Drawing.Size(1225, 679);
            this.Load += new System.EventHandler(this.usMaintenance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbCounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbdetectionsensortact;
        private System.Windows.Forms.Label lbstopsensortact;
        private System.Windows.Forms.Label lbparceltact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lbdetectp;
        private System.Windows.Forms.Label lbstopp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lbtc;
    }
}
