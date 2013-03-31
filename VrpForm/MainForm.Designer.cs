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
            this.menuStrip1.Size = new System.Drawing.Size(729, 25);
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
            this.蚁群算法ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 540);
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
    }
}

