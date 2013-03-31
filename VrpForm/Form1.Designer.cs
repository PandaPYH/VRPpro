namespace VrpForm
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
            this.chartlet1 = new FanG.Chartlet();
            this.SuspendLayout();
            // 
            // chartlet1
            // 
            this.chartlet1.Alpha3D = ((byte)(255));
            this.chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Bar_2D_Aurora_FlatCrystal_Glow_NoBorder;
            this.chartlet1.AutoBarWidth = true;
            this.chartlet1.Background.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(238)))));
            this.chartlet1.Background.Lowlight = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.chartlet1.Background.Paper = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartlet1.ChartTitle.BackColor = System.Drawing.Color.White;
            this.chartlet1.ChartTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ChartTitle.ForeColor = System.Drawing.Color.SlateGray;
            this.chartlet1.ChartTitle.OffsetY = 0;
            this.chartlet1.ChartTitle.Show = true;
            this.chartlet1.ChartTitle.Text = "";
            this.chartlet1.ChartType = FanG.Chartlet.ChartTypes.Line;
            this.chartlet1.ClientClick = "";
            this.chartlet1.ClientMouseMove = "";
            this.chartlet1.ClientMouseOut = "";
            this.chartlet1.ClientMouseOver = "";
            this.chartlet1.ClientUseMap = "";
            this.chartlet1.Colorful = true;
            this.chartlet1.ColorGuider.BackColor = System.Drawing.Color.White;
            this.chartlet1.ColorGuider.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ColorGuider.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.ColorGuider.Show = true;
            this.chartlet1.CopyrightText = "Provided by Chartlet.cn";
            this.chartlet1.Crystal.Contraction = 1;
            this.chartlet1.Crystal.CoverFull = true;
            this.chartlet1.Crystal.Direction = FanG.Chartlet.Direction.TopBottom;
            this.chartlet1.Crystal.Enable = true;
            this.chartlet1.Depth3D = 10;
            this.chartlet1.Dimension = FanG.Chartlet.ChartDimensions.Chart2D;
            this.chartlet1.Fill.Color1 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.ColorStyle = FanG.Chartlet.ColorStyles.Aurora;
            this.chartlet1.Fill.ShiftStep = 0;
            this.chartlet1.Fill.TextureEnable = false;
            this.chartlet1.Fill.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.GroupSize = 0;
            this.chartlet1.ImageBorder = 0;
            this.chartlet1.ImageFolder = "Chartlet";
            this.chartlet1.ImageStyle = "";
            this.chartlet1.InflateBottom = 0;
            this.chartlet1.InflateLeft = 0;
            this.chartlet1.InflateRight = 0;
            this.chartlet1.InflateTop = 0;
            this.chartlet1.LineConnectionRadius = 10;
            this.chartlet1.LineConnectionType = FanG.Chartlet.LineConnectionTypes.Round;
            this.chartlet1.Location = new System.Drawing.Point(6, 12);
            this.chartlet1.MaxValueY = 0;
            this.chartlet1.MinValueY = 0;
            this.chartlet1.Name = "chartlet1";
            this.chartlet1.OutputFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.chartlet1.RootPath = "C:\\";
            this.chartlet1.RoundRadius = 2;
            this.chartlet1.RoundRectangle = false;
            this.chartlet1.Shadow.Alpha = ((byte)(192));
            this.chartlet1.Shadow.Angle = 60F;
            this.chartlet1.Shadow.Color = System.Drawing.Color.Black;
            this.chartlet1.Shadow.Distance = 0;
            this.chartlet1.Shadow.Enable = true;
            this.chartlet1.Shadow.Hollow = false;
            this.chartlet1.Shadow.Radius = 3;
            this.chartlet1.ShowCopyright = false;
            this.chartlet1.ShowErrorInfo = true;
            this.chartlet1.Size = new System.Drawing.Size(600, 400);
            this.chartlet1.Stroke.Color1 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.ColorStyle = FanG.Chartlet.ColorStyles.None;
            this.chartlet1.Stroke.ShiftStep = 0;
            this.chartlet1.Stroke.TextureEnable = false;
            this.chartlet1.Stroke.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.Stroke.Width = 0;
            this.chartlet1.TabIndex = 1;
            this.chartlet1.Tips.BackColor = System.Drawing.Color.White;
            this.chartlet1.Tips.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.Tips.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.Tips.Show = true;
            this.chartlet1.XLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.XLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.XLabels.RotateAngle = 30F;
            this.chartlet1.XLabels.SampleSize = 1;
            this.chartlet1.XLabels.Show = true;
            this.chartlet1.XLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.UnitText = "TESTABC";
            this.chartlet1.XLabels.ValueFormat = "0.0";
            this.chartlet1.YLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.YLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.YLabels.Show = true;
            this.chartlet1.YLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.UnitText = "TESTDEF";
            this.chartlet1.YLabels.ValueFormat = "0.0";
            this.chartlet1.Load += new System.EventHandler(this.chartlet1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 424);
            this.Controls.Add(this.chartlet1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FanG.Chartlet chartlet1;

    }
}