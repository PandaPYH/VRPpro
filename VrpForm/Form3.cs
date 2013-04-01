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
            PaintLineImage("Series1", Common.listLength);
        }

        private void PaintLineImage(string series, IList list)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                chart1.Series[series].Points.AddXY(i, list[i]);
            }
        }
    }
}
