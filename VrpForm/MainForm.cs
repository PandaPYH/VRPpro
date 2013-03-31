using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VRPpro;

namespace VrpForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private static string filepath;
        Graphics graphics;
        private void 导入文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileopen = new OpenFileDialog();

            if (fileopen.ShowDialog() == DialogResult.OK)
            {
                filepath = fileopen.FileName;
                Common.filePath = filepath;
                Common.ReadVRPFile();
                graphics = pictureBox1.CreateGraphics();
                graphics.Clear(Color.White);
                Pen mypen = new Pen(Color.Blue, 3);
                float x, y, mutiple;
                mutiple = 5.3F;
                for(int i = 0; i <Common.cityInfo.Length; i++)
                {
                    x = (float)((float)Common.cityInfo[i].Xcoord * mutiple);
                    y = (float)((float)Common.cityInfo[i].Ycoord * mutiple);
                    //Point point = new Point(x, y);
                    //Rectangle rec = new Rectangle(x, y, 3, 3);
                    graphics.DrawEllipse(mypen, x, y, 3, 3);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void 蚁群算法ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.filePath = filepath;
            Common.ReadVRPFile();
            Common.InitCommon();
            graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            Pen mypen = new Pen(Color.Blue, 3);
            float x, y, mutiple;
            mutiple = 5.3F;
            for (int i = 0; i < Common.cityInfo.Length; i++)
            {
                x = (float)((float)Common.cityInfo[i].Xcoord * mutiple);
                y = (float)((float)Common.cityInfo[i].Ycoord * mutiple);
                //Point point = new Point(x, y);
                //Rectangle rec = new Rectangle(x, y, 3, 3);
                graphics.DrawEllipse(mypen, x, y, 3, 3);
            }

            AntVRP antVRP = new AntVRP();
            antVRP.Search();
            Pen myLinepen = new Pen(Color.Black, 1);
            float x1, x2, y1, y2;
            PointF p1, p2;
            for (int i = 1; i < antVRP.globalBestVehicle.VehiclePathList.Count; i++)
            {
                x1 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[i - 1]].Xcoord * mutiple;
                y1 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[i - 1]].Ycoord * mutiple;
                x2 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[i]].Xcoord * mutiple;
                y2 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[i]].Ycoord * mutiple;
                p1 = new PointF(x1, y1);
                p2 = new PointF(x2, y2);
                graphics.DrawLine(myLinepen, p1, p2);
            }

            x1 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[antVRP.globalBestVehicle.VehiclePathList.Count - 1]].Xcoord * mutiple;
            y1 = (float)Common.cityInfo[antVRP.globalBestVehicle.VehiclePathList[antVRP.globalBestVehicle.VehiclePathList.Count - 1]].Ycoord * mutiple;
            x2 = (float)Common.cityInfo[0].Xcoord * mutiple;
            y2 = (float)Common.cityInfo[0].Ycoord * mutiple;
            p1 = new PointF(x1, y1);
            p2 = new PointF(x2, y2);
            graphics.DrawLine(myLinepen, p1, p2);


        }
    }
}
