﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace VRPpro
{
    public class Common
    {
        #region 参数定义
        
        /// <summary>
        /// 信息素重要性
        /// </summary>
        public static int alpha = 2;

        /// <summary>
        /// 启发信息重要性
        /// </summary>
        public static int beta = 5;

        /// <summary>
        /// 时间差的重要性
        /// </summary>
        public static int gama = 1;

        /// <summary>
        /// 等待时间的相对重要性
        /// </summary>
        public static int thelta = 2;

        public static double Maxpheromone = 0.0;

        public static double Minpheromone = 0.0;

        public static bool Output = true;

        /// <summary>
        /// 信息素残留率
        /// </summary>
        public static double ROU = 0.8;

        /// <summary>
        /// 遗传算法所求得路径信息素残留率
        /// </summary>
        public static double GaROU = 0.4;

        /// <summary>
        /// 信息素最小值
        /// </summary>
        public static double ROUMin = 0.65;

        /// <summary>
        /// 信息素最大值
        /// </summary>
        public static double GaROUMax = 0.8;

        /// <summary>
        /// 蚂蚁数量
        /// </summary>
        public static int AntCount = 101;

        /// <summary>
        /// 循环次数
        /// </summary>
        public static int LoopCount = 1000;

        /// <summary>
        /// 遗传算法迭代次数
        /// </summary>
        public static int GALoogCount = 800;

        /// <summary>
        /// 城市数量
        /// </summary>
        public static int CityCount = 101;

        /// <summary>
        /// 遗传算法开始标识
        /// </summary>
        public static int StartCount = 200;

        /// <summary>
        /// 遗传算法执行的频度
        /// </summary>
        public static int stopCount = 10;

        /// <summary>
        /// 遗传种群数量
        /// </summary>
        public static int PopulationCount = 80;

        public static CityInfo[] cityInfo = new CityInfo[CityCount];

        /// <summary>
        /// 临近城市数量
        /// </summary>
        public static int NearCityCount = 10;

        /// <summary>
        /// 临近城市列表
        /// </summary>
        public static int[,] NearCityList = new int[CityCount, NearCityCount];

        public static double DBMax = 10e9;        

        /// <summary>
        /// 信息素矩阵
        /// </summary>
        public static double[,] gTrial = new double[CityCount, CityCount];

        /// <summary>
        /// 两两城市间距离
        /// </summary>
        public static double[,] gDistance = new double[CityCount, CityCount];

        /// <summary>
        /// 最大车辆数
        /// </summary>
        public static int vehicleMax;

        /// <summary>
        /// 车辆最大载重
        /// </summary>
        public static int Capacity;

        public static string filePath = "D:\\Vrp-All\\M\\M-n101-k10.vrp";

        //public static string filePath = "";

        public static double TotalDistance = 0.0;

        public static double TotalVehicleCount = 0.0;

        public static List<double> sACLocalLength = new List<double>();

        public static List<double> listBestAcLength = new List<double>();

        public static List<double> gaLocalLength = new List<double>();

        public static List<double> listBestGaAcLength = new List<double>();

        public static List<Vehicle> listLocBestVe = new List<Vehicle>();

        public static int BackCount = 0;

        #endregion

        #region 读取文件

        /// <summary>
        /// 读取VRP问题集
        /// </summary>
        public static void ReadVRPTWFile()
        {
            for (int a = 0; a < CityCount; a++)
            {
                cityInfo[a] = new CityInfo();
            }

            FileStream fs = new FileStream(filePath,FileMode.Open,FileAccess.Read);
            StreamReader reader = new StreamReader(fs);

            string str;
            int row = 0;

            while (row < 4)
            {
                reader.ReadLine();
                row++;
            }

            str = reader.ReadLine();
            string temp = ReplaceTheSpace(str);

            string[] str1 = temp.Split(',');
            vehicleMax = Convert.ToInt32(str1[0]);
            Capacity = Convert.ToInt32(str1[1]);

            row = 0;

            while (row < 4)
            {
                reader.ReadLine();
                row++;
            }
            for (int i = 0; i < CityCount; i++)
            {
                str = reader.ReadLine();
                temp = ReplaceTheSpace(str);
                string[] str2 = temp.Split(',');
                for (int j = 0; j < str2.Length; j++)
                {
                    switch (j)
                    {
                        case 0: cityInfo[i].CityId = Convert.ToInt32(str2[j]); break;
                        case 1: cityInfo[i].Xcoord = Convert.ToInt32(str2[j]); break;
                        case 2: cityInfo[i].Ycoord = Convert.ToInt32(str2[j]); break;
                        case 3: cityInfo[i].Demand = Convert.ToInt32(str2[j]); break;
                        case 4: cityInfo[i].ReadyTime = Convert.ToInt32(str2[j]); break;
                        case 5: cityInfo[i].DueDate = Convert.ToInt32(str2[j]); break;
                        case 6: cityInfo[i].ServiceTime = Convert.ToInt32(str2[j]); break;
                    }
                }
            }
            reader.Close();
        }

        /// <summary>
        /// 替换掉文本中的空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string ReplaceTheSpace(string str)
        {
            string temp = null;
            int flag = 0;
            char[] cr = str.Trim().ToCharArray();

            for (int k = 0; k < cr.Length; k++)
            {
                if (cr[k] != ' ')
                {
                    temp += cr[k];
                    flag = 0;
                }
                else
                {
                    if (flag == 0)
                    {
                        flag = 1;
                        temp += ',';
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return temp;
        }

        public static void ReadVRPTypeFile()
        {
            FileStream fs;
            fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
            StreamReader r = new StreamReader(fs);
            string str;
            while (true)
            {
                str = r.ReadLine();
                string[] temp = str.Split(' ');
                if (temp[0] == "DIMENSION")
                {
                    CityCount = Convert.ToInt32(temp[2]);
                }
                if (temp[0] == "CAPACITY")
                {
                    Capacity = Convert.ToInt32(temp[2]);
                }
                if (temp[0] == "NODE_COORD_SECTION")
                {
                    break;
                }
            }
            fs.Close();
        }

        public static void ReadVRPFile()
        {
            ReadVRPTypeFile();
            cityInfo = new CityInfo[CityCount];

            for (int a = 0; a < CityCount; a++)
            {
                cityInfo[a] = new CityInfo();
            }
            FileStream fs;
            fs = File.Open(filePath, FileMode.Open, FileAccess.Read);
            StreamReader r = new StreamReader(fs);
            string str;
            while (true)
            {
                str = r.ReadLine();
                string[] temp = str.Split(' ');
                if (temp[0] == "NODE_COORD_SECTION")
                {
                    break;
                }
            }

            for (int i = 0; i < CityCount; i++)
            {
                str = r.ReadLine();
                string[] temp1 = str.Split(' ');
                cityInfo[i].CityId = Convert.ToInt32(temp1[0]);
                cityInfo[i].Xcoord = Convert.ToInt32(temp1[1]);
                cityInfo[i].Ycoord = Convert.ToInt32(temp1[2]);
            }

            while (true)
            {
                str = r.ReadLine();
                string[] temp = str.Split(' ');
                if (temp[0] == "DEMAND_SECTION")
                {
                    break;
                }
            }

            for (int i = 0; i < CityCount; i++)
            {
                str = r.ReadLine();
                string[] temp1 = str.Split(' ');
                cityInfo[i].Demand = Convert.ToInt32(temp1[1]);
            }

            fs.Close();
        }

        #endregion

        /// <summary>
        /// 生成距离矩阵
        /// </summary>
        /// <returns>距离矩阵</returns>
        private static void CreatgDistance()
        {
            gDistance = new double[CityCount, CityCount];
            for (int i = 0; i < CityCount; i++)
            {
                for (int j = 0; j < CityCount; j++)
                {
                    if (i == j)
                    {
                        gDistance[i, j] = 0;
                    }
                    else
                    {
                        gDistance[i, j] = Math.Sqrt(Math.Pow((double)(cityInfo[i].Xcoord - cityInfo[j].Xcoord), 2)
                            + Math.Pow((double)(cityInfo[i].Ycoord - cityInfo[j].Ycoord), 2));
                    }
                }
            }
        }

        /// <summary>
        /// 初始化信息素
        /// </summary>
        private static void CreatTrial()
        {
            gTrial = new double[CityCount, CityCount];
            for (int i = 0; i < Common.CityCount; i++)
                for (int j = 0; j < Common.CityCount; j++)
                {
                    gTrial[i, j] = 1 / (gDistance[i, j]);
                }
        }

        /// <summary>
        /// 创建临近列表
        /// </summary>
        public static void CreatNNlist()
        {
            NearCityList = new int[CityCount, NearCityCount];
            Dictionary<int, double> tempNNlist = new Dictionary<int, double>();

            for (int i = 1; i < Common.CityCount; i++)
            {
                for (int j = 1; j < Common.CityCount; j++)
                {
                    if (i == j && i != 0)
                    {
                        continue;
                    }
                    else
                    {
                        tempNNlist.Add(j, gDistance[i, j]);
                    }
                }

                var result = from pair in tempNNlist orderby pair.Value select pair;

                int count = 0;
                foreach (KeyValuePair<int, double> pair in result)
                {
                    NearCityList[i, count] = pair.Key;
                    count++;
                    if (count == NearCityCount)
                    {
                        break;
                    }
                }
                tempNNlist.Clear();
            }

            //for (int i = 1; i < Common.CityCount; i++)
            //{
            //    Console.Write("City : {0},NNCity : ", i);
            //    for (int j = 0; j < NearCityCount; j++)
            //    {
            //        Console.Write("{0},", NearCityList[i, j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        public static void InitCommon()
        {
            CreatgDistance();
            CreatTrial();
            CreatNNlist();
        }

        #region 随机数操作

        static int RAND_MAX = 0x7fff; //随机数最大值

        static Random rand = new Random(System.DateTime.Now.Millisecond);

        /// <summary>
        /// 返回指定范围内的随机整数
        /// </summary>
        /// <param name="nLow"></param>
        /// <param name="nUpper"></param>
        /// <returns></returns>
        public static int rnd(int nLow, int nUpper)
        {
            return nLow + (nUpper - nLow) * rand.Next(RAND_MAX) / (RAND_MAX + 1);
        }

        /// <summary>
        /// 返回指定范围内的随机浮点数
        /// </summary>
        /// <param name="dbLow"></param>
        /// <param name="dbUpper"></param>
        /// <returns></returns>
        public static double rnd(double dbLow, double dbUpper)
        {
            double dbTemp = (double)rand.Next(RAND_MAX) / ((double)RAND_MAX + 1.0);
            return dbLow + dbTemp * (dbUpper - dbLow);
        }

        /// <summary>
        /// 返回浮点数四舍五入取整后的浮点数
        /// </summary>
        /// <param name="dbA"></param>
        /// <returns></returns>
        public static double ROUND(double dbA)
        {
            return (double)((int)(dbA + 0.5));
        }

        #endregion

    }
}
