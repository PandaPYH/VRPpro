using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanG;

namespace VrpForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chartlet1.ChartTitle.Text = "Test1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chartlet1_Load(object sender, EventArgs e)
        {
            chartlet1.ChartType = Chartlet.ChartTypes.Line;
        }
    }
}
