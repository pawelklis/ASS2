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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStartRun = new System.Windows.Forms.Button();
            this.cbSortProgram = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbFeederParcels = new System.Windows.Forms.Label();
            this.lbTactTime = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbRun = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dg2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).BeginInit();
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
            // panel4
            // 
            this.panel4.Controls.Add(this.dg1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 228);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1070, 268);
            this.panel4.TabIndex = 4;
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.AllowUserToDeleteRows = false;
            this.dg1.BackgroundColor = System.Drawing.Color.White;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg1.Location = new System.Drawing.Point(0, 0);
            this.dg1.Name = "dg1";
            this.dg1.ReadOnly = true;
            this.dg1.Size = new System.Drawing.Size(1070, 268);
            this.dg1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dg2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 496);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1070, 239);
            this.panel5.TabIndex = 5;
            // 
            // dg2
            // 
            this.dg2.AllowUserToAddRows = false;
            this.dg2.AllowUserToDeleteRows = false;
            this.dg2.BackgroundColor = System.Drawing.Color.White;
            this.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg2.Location = new System.Drawing.Point(0, 0);
            this.dg2.Name = "dg2";
            this.dg2.ReadOnly = true;
            this.dg2.Size = new System.Drawing.Size(1070, 239);
            this.dg2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(980, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // usWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dg2;
        private System.Windows.Forms.Label lbFeederParcels;
        private System.Windows.Forms.Button button1;
    }
}
