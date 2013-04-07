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
            int count = Common.listLength.Count - 1;
            textBox1.Text = Common.listLength[count].ToString();
            PaintLineImage("Series1", Common.listLength);
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
