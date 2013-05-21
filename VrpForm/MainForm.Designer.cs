namespace VrpForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入VRP文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路程收敛图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.路程变化率图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.txtBeta = new System.Windows.Forms.TextBox();
            this.txtLoopCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labLength = new System.Windows.Forms.Label();
            this.txtNearCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPop = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rtbPath = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAntCount = new System.Windows.Forms.TextBox();
            this.txtGAloopCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtStartCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStopCount = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.绘图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(976, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件ToolStripMenuItem,
            this.导入VRP文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.导入文件ToolStripMenuItem.Text = "导入solomon文件";
            this.导入文件ToolStripMenuItem.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // 导入VRP文件ToolStripMenuItem
            // 
            this.导入VRP文件ToolStripMenuItem.Name = "导入VRP文件ToolStripMenuItem";
            this.导入VRP文件ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.导入VRP文件ToolStripMenuItem.Text = "导入VRPLib文件";
            this.导入VRP文件ToolStripMenuItem.Click += new System.EventHandler(this.导入VRP文件ToolStripMenuItem_Click);
            // 
            // 绘图ToolStripMenuItem
            // 
            this.绘图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.路程收敛图ToolStripMenuItem,
            this.路程变化率图ToolStripMenuItem});
            this.绘图ToolStripMenuItem.Name = "绘图ToolStripMenuItem";
            this.绘图ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.绘图ToolStripMenuItem.Text = "绘图";
            // 
            // 路程收敛图ToolStripMenuItem
            // 
            this.路程收敛图ToolStripMenuItem.Name = "路程收敛图ToolStripMenuItem";
            this.路程收敛图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.路程收敛图ToolStripMenuItem.Text = "路程收敛图";
            this.路程收敛图ToolStripMenuItem.Click += new System.EventHandler(this.路程收敛图ToolStripMenuItem_Click);
            // 
            // 路程变化率图ToolStripMenuItem
            // 
            this.路程变化率图ToolStripMenuItem.Name = "路程变化率图ToolStripMenuItem";
            this.路程变化率图ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.路程变化率图ToolStripMenuItem.Text = "最优解变化曲线";
            this.路程变化率图ToolStripMenuItem.Click += new System.EventHandler(this.路程变化率图ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 481);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(722, 275);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(119, 23);
            this.btnCal.TabIndex = 2;
            this.btnCal.Text = "基础蚁群算法求解";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(758, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "信息素参数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(746, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "起发信息参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(770, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "迭代次数";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(829, 25);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 21);
            this.txtAlpha.TabIndex = 6;
            // 
            // txtBeta
            // 
            this.txtBeta.Location = new System.Drawing.Point(829, 52);
            this.txtBeta.Name = "txtBeta";
            this.txtBeta.Size = new System.Drawing.Size(100, 21);
            this.txtBeta.TabIndex = 7;
            // 
            // txtLoopCount
            // 
            this.txtLoopCount.Location = new System.Drawing.Point(829, 79);
            this.txtLoopCount.Name = "txtLoopCount";
            this.txtLoopCount.Size = new System.Drawing.Size(100, 21);
            this.txtLoopCount.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(848, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "混合蚁群算法求解";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(722, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "基本(VRPLib)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(848, 304);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "混合(VRPLib)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(720, 537);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "算得最短路径长度";
            // 
            // labLength
            // 
            this.labLength.AutoSize = true;
            this.labLength.Location = new System.Drawing.Point(827, 537);
            this.labLength.Name = "labLength";
            this.labLength.Size = new System.Drawing.Size(0, 12);
            this.labLength.TabIndex = 13;
            // 
            // txtNearCity
            // 
            this.txtNearCity.Location = new System.Drawing.Point(829, 107);
            this.txtNearCity.Name = "txtNearCity";
            this.txtNearCity.Size = new System.Drawing.Size(100, 21);
            this.txtNearCity.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "临近城市数目";
            // 
            // txtPop
            // 
            this.txtPop.Location = new System.Drawing.Point(829, 162);
            this.txtPop.Name = "txtPop";
            this.txtPop.Size = new System.Drawing.Size(100, 21);
            this.txtPop.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(772, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "种群数量";
            // 
            // rtbPath
            // 
            this.rtbPath.Location = new System.Drawing.Point(722, 344);
            this.rtbPath.Name = "rtbPath";
            this.rtbPath.ReadOnly = true;
            this.rtbPath.Size = new System.Drawing.Size(242, 190);
            this.rtbPath.TabIndex = 18;
            this.rtbPath.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(722, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "路径显示";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(770, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "蚂蚁数量";
            // 
            // txtAntCount
            // 
            this.txtAntCount.Location = new System.Drawing.Point(829, 135);
            this.txtAntCount.Name = "txtAntCount";
            this.txtAntCount.Size = new System.Drawing.Size(100, 21);
            this.txtAntCount.TabIndex = 21;
            // 
            // txtGAloopCount
            // 
            this.txtGAloopCount.Location = new System.Drawing.Point(829, 190);
            this.txtGAloopCount.Name = "txtGAloopCount";
            this.txtGAloopCount.Size = new System.Drawing.Size(100, 21);
            this.txtGAloopCount.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(758, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "GA循环次数";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(764, 220);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "停滞参数1";
            // 
            // txtStartCount
            // 
            this.txtStartCount.Location = new System.Drawing.Point(829, 217);
            this.txtStartCount.Name = "txtStartCount";
            this.txtStartCount.Size = new System.Drawing.Size(100, 21);
            this.txtStartCount.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(766, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 26;
            this.label11.Text = "停滞参数2";
            // 
            // txtStopCount
            // 
            this.txtStopCount.Location = new System.Drawing.Point(829, 245);
            this.txtStopCount.Name = "txtStopCount";
            this.txtStopCount.Size = new System.Drawing.Size(100, 21);
            this.txtStopCount.TabIndex = 27;
            this.txtStopCount.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 555);
            this.Controls.Add(this.txtStopCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtStartCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGAloopCount);
            this.Controls.Add(this.txtAntCount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtbPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNearCity);
            this.Controls.Add(this.labLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLoopCount);
            this.Controls.Add(this.txtBeta);
            this.Controls.Add(this.txtAlpha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "解决VRP问题";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路程收敛图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 路程变化率图ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAlpha;
        private System.Windows.Forms.TextBox txtBeta;
        private System.Windows.Forms.TextBox txtLoopCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 导入VRP文件ToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labLength;
        private System.Windows.Forms.TextBox txtNearCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPop;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox rtbPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAntCount;
        private System.Windows.Forms.TextBox txtGAloopCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStartCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStopCount;
    }
}

