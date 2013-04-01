using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanG;
using System.Collections;
using VRPpro;

namespace VrpForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chartlet1.ChartTitle.Text = "Test1";
            chartlet1.ChartType = Chartlet.ChartTypes.Line;
            ArrayList listLength = new ArrayList();
            listLength.Add(100);
            listLength.Add(50);
            listLength.Add(4);
            listLength.Add(80);
            ArrayList[] ChartData = { listLength };
            chartlet1.InitializeData(ChartData, null, null);
        }

        private void chartlet1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
