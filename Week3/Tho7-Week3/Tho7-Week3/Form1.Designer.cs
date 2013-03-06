namespace Tho7_Week3
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.noisePercTxt = new System.Windows.Forms.Label();
            this.NoisePixels = new System.Windows.Forms.Label();
            this.NoisePerc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CorrectedPix = new System.Windows.Forms.Label();
            this.CorrectedPerc = new System.Windows.Forms.Label();
            this.PixCount = new System.Windows.Forms.Label();
            this.CBNoise = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.BStart = new System.Windows.Forms.Button();
            this.imageView3 = new Tho7_Week3.ImageView();
            this.imageView2 = new Tho7_Week3.ImageView();
            this.imageView1 = new Tho7_Week3.ImageView();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PixCount);
            this.groupBox1.Controls.Add(this.CorrectedPerc);
            this.groupBox1.Controls.Add(this.CorrectedPix);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.NoisePerc);
            this.groupBox1.Controls.Add(this.NoisePixels);
            this.groupBox1.Controls.Add(this.noisePercTxt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 310);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pixel Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Image with added Noise";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Correct Pixels:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Filtered Image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(512, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Correct Pixels:";
            // 
            // noisePercTxt
            // 
            this.noisePercTxt.AutoSize = true;
            this.noisePercTxt.Location = new System.Drawing.Point(262, 54);
            this.noisePercTxt.Name = "noisePercTxt";
            this.noisePercTxt.Size = new System.Drawing.Size(68, 13);
            this.noisePercTxt.TabIndex = 6;
            this.noisePercTxt.Text = "Percentage: ";
            // 
            // NoisePixels
            // 
            this.NoisePixels.AutoSize = true;
            this.NoisePixels.Location = new System.Drawing.Point(340, 36);
            this.NoisePixels.Name = "NoisePixels";
            this.NoisePixels.Size = new System.Drawing.Size(0, 13);
            this.NoisePixels.TabIndex = 7;
            // 
            // NoisePerc
            // 
            this.NoisePerc.AutoSize = true;
            this.NoisePerc.Location = new System.Drawing.Point(343, 53);
            this.NoisePerc.Name = "NoisePerc";
            this.NoisePerc.Size = new System.Drawing.Size(0, 13);
            this.NoisePerc.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Percentage: ";
            // 
            // CorrectedPix
            // 
            this.CorrectedPix.AutoSize = true;
            this.CorrectedPix.Location = new System.Drawing.Point(592, 36);
            this.CorrectedPix.Name = "CorrectedPix";
            this.CorrectedPix.Size = new System.Drawing.Size(0, 13);
            this.CorrectedPix.TabIndex = 10;
            // 
            // CorrectedPerc
            // 
            this.CorrectedPerc.AutoSize = true;
            this.CorrectedPerc.Location = new System.Drawing.Point(590, 54);
            this.CorrectedPerc.Name = "CorrectedPerc";
            this.CorrectedPerc.Size = new System.Drawing.Size(0, 13);
            this.CorrectedPerc.TabIndex = 11;
            // 
            // PixCount
            // 
            this.PixCount.AutoSize = true;
            this.PixCount.Location = new System.Drawing.Point(76, 36);
            this.PixCount.Name = "PixCount";
            this.PixCount.Size = new System.Drawing.Size(0, 13);
            this.PixCount.TabIndex = 12;
            // 
            // CBNoise
            // 
            this.CBNoise.FormattingEnabled = true;
            this.CBNoise.Location = new System.Drawing.Point(397, 3);
            this.CBNoise.Name = "CBNoise";
            this.CBNoise.Size = new System.Drawing.Size(121, 21);
            this.CBNoise.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(358, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Noise";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(538, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Filter";
            // 
            // CBFilter
            // 
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Location = new System.Drawing.Point(573, 3);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(121, 21);
            this.CBFilter.TabIndex = 16;
            // 
            // BStart
            // 
            this.BStart.Location = new System.Drawing.Point(700, 2);
            this.BStart.Name = "BStart";
            this.BStart.Size = new System.Drawing.Size(75, 23);
            this.BStart.TabIndex = 17;
            this.BStart.Text = "Start";
            this.BStart.UseVisualStyleBackColor = true;
            this.BStart.Click += new System.EventHandler(this.BStart_Click);
            // 
            // imageView3
            // 
            this.imageView3.Image = null;
            this.imageView3.Location = new System.Drawing.Point(524, 50);
            this.imageView3.Name = "imageView3";
            this.imageView3.Size = new System.Drawing.Size(250, 250);
            this.imageView3.TabIndex = 2;
            // 
            // imageView2
            // 
            this.imageView2.Image = null;
            this.imageView2.Location = new System.Drawing.Point(268, 50);
            this.imageView2.Name = "imageView2";
            this.imageView2.Size = new System.Drawing.Size(250, 250);
            this.imageView2.TabIndex = 1;
            // 
            // imageView1
            // 
            this.imageView1.Image = null;
            this.imageView1.Location = new System.Drawing.Point(12, 50);
            this.imageView1.Name = "imageView1";
            this.imageView1.Size = new System.Drawing.Size(250, 250);
            this.imageView1.TabIndex = 0;
            this.imageView1.DoubleClick += new System.EventHandler(this.InputImageDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 422);
            this.Controls.Add(this.BStart);
            this.Controls.Add(this.CBFilter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CBNoise);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageView3);
            this.Controls.Add(this.imageView2);
            this.Controls.Add(this.imageView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageView imageView1;
        private ImageView imageView2;
        private ImageView imageView3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CorrectedPerc;
        private System.Windows.Forms.Label CorrectedPix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label NoisePerc;
        private System.Windows.Forms.Label NoisePixels;
        private System.Windows.Forms.Label noisePercTxt;
        private System.Windows.Forms.Label PixCount;
        private System.Windows.Forms.ComboBox CBNoise;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.Button BStart;
    }
}

