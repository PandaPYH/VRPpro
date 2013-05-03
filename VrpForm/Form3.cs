using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRPpro;
using System.Collections;

namespace VrpForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int count = Common.listBestAcLength.Count - 1;
            //chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Common.sACLocalLength[count] * 1.2;
            //chart1.ChartAreas["ChartArea1"].AxisY.Maximum = Common.sACLocalLength[count] * 0.8;
            textBox1.Text = Common.listBestAcLength[count].ToString();
            count = Common.listBestGaAcLength.Count - 1;
            textBox2.Text = Common.listBestGaAcLength[count].ToString();
            PaintLineImage("基础蚁群算法", Common.sACLocalLength);
            PaintLineImage("混合蚁群算法", Common.gaLocalLength);
        }

        private void PaintLineImage(string series, IList list)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                chart1.Series[series].Points.AddXY(i, list[i - 1]);
            }
        }
    }
}
