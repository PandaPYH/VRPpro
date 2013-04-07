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
            this.求解ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.蚁群算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.求解ToolStripMenuItem,
            this.绘图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入文件ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导入文件ToolStripMenuItem.Text = "导入文件";
            this.导入文件ToolStripMenuItem.Click += new System.EventHandler(this.导入文件ToolStripMenuItem_Click);
            // 
            // 求解ToolStripMenuItem
            // 
            this.求解ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.蚁群算法ToolStripMenuItem});
            this.求解ToolStripMenuItem.Name = "求解ToolStripMenuItem";
            this.求解ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.求解ToolStripMenuItem.Text = "求解";
            // 
            // 蚁群算法ToolStripMenuItem
            // 
            this.蚁群算法ToolStripMenuItem.Name = "蚁群算法ToolStripMenuItem";
            this.蚁群算法ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.蚁群算法ToolStripMenuItem.Text = "蚁群算法";
            this.蚁群算法ToolStripMenuItem.Click += new System.EventHandler(this.蚁群算法ToolStripMenuItem_Click);
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
            this.路程收敛图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.路程收敛图ToolStripMenuItem.Text = "路程收敛图";
            this.路程收敛图ToolStripMenuItem.Click += new System.EventHandler(this.路程收敛图ToolStripMenuItem_Click);
            // 
            // 路程变化率图ToolStripMenuItem
            // 
            this.路程变化率图ToolStripMenuItem.Name = "路程变化率图ToolStripMenuItem";
            this.路程变化率图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.路程变化率图ToolStripMenuItem.Text = "路程变化率图";
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
            this.btnCal.Location = new System.Drawing.Point(803, 155);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(75, 23);
            this.btnCal.TabIndex = 2;
            this.btnCal.Text = "运算";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(732, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "信息素参数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(720, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "起发信息参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(744, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "迭代次数";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(803, 74);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 21);
            this.txtAlpha.TabIndex = 6;
            // 
            // txtBeta
            // 
            this.txtBeta.Location = new System.Drawing.Point(803, 101);
            this.txtBeta.Name = "txtBeta";
            this.txtBeta.Size = new System.Drawing.Size(100, 21);
            this.txtBeta.TabIndex = 7;
            // 
            // txtLoopCount
            // 
            this.txtLoopCount.Location = new System.Drawing.Point(803, 128);
            this.txtLoopCount.Name = "txtLoopCount";
            this.txtLoopCount.Size = new System.Drawing.Size(100, 21);
            this.txtLoopCount.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 521);
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
        private System.Windows.Forms.ToolStripMenuItem 求解ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 蚁群算法ToolStripMenuItem;
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
    }
}

