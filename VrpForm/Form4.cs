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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PaintLineImage("基础蚁群算法", Common.listBestAcLength);
            PaintLineImage("混合蚁群算法", Common.listBestGaAcLength);
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
