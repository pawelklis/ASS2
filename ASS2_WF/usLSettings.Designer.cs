namespace ASS2_WF
{
    partial class usLSettings
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.S1NM2 = new System.Windows.Forms.NumericUpDown();
            this.S1L2 = new System.Windows.Forms.Button();
            this.S1NM1 = new System.Windows.Forms.NumericUpDown();
            this.S1L1 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.S1NM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S1NM1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.S1NM2);
            this.groupBox4.Controls.Add(this.S1L2);
            this.groupBox4.Controls.Add(this.S1NM1);
            this.groupBox4.Controls.Add(this.S1L1);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 66);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stanowisko 1";
            // 
            // S1NM2
            // 
            this.S1NM2.Location = new System.Drawing.Point(198, 30);
            this.S1NM2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.S1NM2.Name = "S1NM2";
            this.S1NM2.Size = new System.Drawing.Size(50, 20);
            this.S1NM2.TabIndex = 3;
            this.S1NM2.ValueChanged += new System.EventHandler(this.S1NM2_ValueChanged);
            // 
            // S1L2
            // 
            this.S1L2.Location = new System.Drawing.Point(130, 30);
            this.S1L2.Name = "S1L2";
            this.S1L2.Size = new System.Drawing.Size(62, 29);
            this.S1L2.TabIndex = 2;
            this.S1L2.Text = "L2";
            this.S1L2.UseVisualStyleBackColor = true;
            this.S1L2.Click += new System.EventHandler(this.S1L2_Click);
            // 
            // S1NM1
            // 
            this.S1NM1.Location = new System.Drawing.Point(74, 30);
            this.S1NM1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.S1NM1.Name = "S1NM1";
            this.S1NM1.Size = new System.Drawing.Size(50, 20);
            this.S1NM1.TabIndex = 1;
            this.S1NM1.ValueChanged += new System.EventHandler(this.S1NM1_ValueChanged);
            // 
            // S1L1
            // 
            this.S1L1.Location = new System.Drawing.Point(6, 30);
            this.S1L1.Name = "S1L1";
            this.S1L1.Size = new System.Drawing.Size(62, 29);
            this.S1L1.TabIndex = 0;
            this.S1L1.Text = "L1";
            this.S1L1.UseVisualStyleBackColor = true;
            this.S1L1.Click += new System.EventHandler(this.S1L1_Click);
            // 
            // usLSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Name = "usLSettings";
            this.Size = new System.Drawing.Size(284, 80);
            this.Load += new System.EventHandler(this.usLSettings_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.S1NM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S1NM1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown S1NM2;
        private System.Windows.Forms.Button S1L2;
        private System.Windows.Forms.NumericUpDown S1NM1;
        private System.Windows.Forms.Button S1L1;
    }
}
