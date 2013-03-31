using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace VrpForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //创建图形区域
            ChartArea carea1 = new ChartArea();
            ChartArea carea2 = new ChartArea();
            carea1.Name = "carea1";
            carea2.Name = "carea2";

            chart1.ChartAreas.Add(carea1);
            chart1.ChartAreas.Add(carea2);


            //Y轴属性设置
            carea1.AxisX.IsStartedFromZero = false;
            carea1.AxisY.IsStartedFromZero = true;
            carea1.AxisX.Title = "日期";
            carea1.AxisY.Title = "数量";

            //添加标题
            Title title = new Title();
            title.Text = "测试MSChart";
            chart1.Titles.Add(title);

            //添加图例
            Legend leg = new Legend();
            leg.LegendStyle = LegendStyle.Column;
            chart1.Legends.Add(leg);

            Axis axis1 = new Axis();

            //创建的3个系列 快速线形、散点、气泡
            Series series = new Series();
            series.ChartType = SeriesChartType.FastLine;
            series.ChartArea = "carea1";
            Series series0 = new Series();
            series0.ChartType = SeriesChartType.Point;
            series0.ChartArea = "carea1";
            Series series1 = new Series();
            series1.ChartType = SeriesChartType.Bubble;
            series1.ChartArea = "carea2";

            //系列上点显示的样式 如：圆形、菱形、矩形……
            series.MarkerStyle = MarkerStyle.Circle;
            series.BorderWidth = 3;
            series.ShadowOffset = 2;

            //对系列添加数据点
            series.Points.AddXY(0, 30);
            series.Points.AddXY(1, 67);
            series.Points.AddXY(2, 57);
            series.Points.AddXY(3, 83);
            series.Points.AddXY(4, 23);
            series.Points.AddXY(5, 70);
            series.Points.AddXY(6, 60);
            series.Points.AddXY(7, 90);
            series.Points.AddXY(8, 20);

            series0.Points.AddXY(5, 70);
            series0.Points.AddXY(6, 60);
            series0.Points.AddXY(7, 90);
            series0.Points.AddXY(8, 20);

            series1.Points.AddXY(0, 30);
            series1.Points.AddXY(1, 67);
            series1.Points.AddXY(2, 57);
            series1.Points.AddXY(3, 83);
            series1.Points.AddXY(4, 23);

            // 添加3个图形系列
            chart1.Series.Add(series);
            chart1.Series.Add(series0);
            chart1.Series.Add(series1);
            //设置X、Y为主坐标轴
            chart1.Series[0].XAxisType = AxisType.Primary;
            chart1.Series[0].YAxisType = AxisType.Primary;
            //实现鼠标移动到数据点上显示数据
            chart1.Series[0].ToolTip = "X value \t= #VALX{d}\nY value \t= #VALY{D}";
            //可以加载一个含有数据的xml文件
            //chart1.LoadTemplate(this.MapPath("" + ".xml"));

        }
    }
}

