using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VRPpro
{
    public class GAAntVRP
    {
        /// <summary>
        /// 车辆数组
        /// </summary>
        Vehicle[] vehicle;

        /// <summary>
        /// 局部最优车辆
        /// </summary>
        public static Vehicle localBestVehicle;

        /// <summary>
        /// 汽车列表
        /// </summary>
        private List<Vehicle> listVehicle = new List<Vehicle>();

        private List<Vehicle> listBestVe = new List<Vehicle>();

        private List<int> listVehicleId = new List<int>();

        /// <summary>
        /// 全局最优车辆
        /// </summary>
        public Vehicle globalBestVehicle;

        public GA ga;

        public int vehicleCount;
        
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() 
        {
            localBestVehicle.PathLength = Common.DBMax;
            globalBestVehicle.PathLength = Common.DBMax;
            //localBestVehicle.Consumption = Common.DBMax;
            //globalBestVehicle.Consumption = Common.DBMax;
        }

        public GAAntVRP()
        {
            vehicle = new Vehicle[Common.CityCount];
            ga = new GA();
            for (int i = 0; i < Common.CityCount; i++)
            {
                vehicle[i] = new Vehicle();
            }
            globalBestVehicle = new Vehicle();
            localBestVehicle = new Vehicle();
        }

        /// <summary>
        /// 更新遗传路径信息素
        /// </summary>
        public void UpdateGaTrial()
        {
            double[,] dbTempAry = new double[Common.CityCount, Common.CityCount];

            for (int i = 0; i < Common.CityCount; i++) //计算每只蚂蚁留下的信息素
            {
                for (int j = 1; j < Common.CityCount; j++)
                {
                    dbTempAry[i, j] = 0.0;
                }
            }

            int m = 0;
            int n = 0;
            double betaT = 0.0;

            for (int i = 0; i < Common.PopulationCount; i++)
            {
                for (int j = 1; j < ga.GaVehicleList[i].VehiclePathList.Count; j++)
                {
                    m = ga.GaVehicleList[i].VehiclePathList[j];
                    n = ga.GaVehicleList[i].VehiclePathList[j - 1];
                    if (m != n && m != 0)
                    {
                        betaT = 1 / ga.GaVehicleList[i].PathLength;
                        //betaT = 1 / Math.Pow(Common.gDistance[m, n], 3);
                    }
                    dbTempAry[n, m] = dbTempAry[n, m] + betaT;
                    //Console.WriteLine(dbTempAry[n, m]);
                }
            }

            //更新环境信息素
            for (int i = 0; i < Common.CityCount; i++)
            {
                for (int j = 0; j < Common.CityCount; j++)
                {
                    Common.gTrial[i, j] = Common.gTrial[i, j] * Common.GaROU + dbTempAry[i, j] * (1 - Common.GaROU);  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
                    if (Common.gTrial[i, j] > Common.Maxpheromone)
                    {
                        Common.gTrial[i, j] = Common.Maxpheromone;
                    }
                    if (Common.gTrial[i, j] < Common.Minpheromone)
                    {
                        Common.gTrial[i, j] = Common.Minpheromone;
                    }
                    //Console.WriteLine(Common.gTrial[i, j]);
                }
            }
        }

        /// <summary>
        /// 更新信息素
        /// </summary>
        public void UpdateTrial()
        {
            double[,] dbTempAry = new double[Common.CityCount, Common.CityCount];

            for (int i = 0; i < Common.CityCount; i++) //计算每只蚂蚁留下的信息素
            {
                for (int j = 1; j < Common.CityCount; j++)
                {
                    dbTempAry[i, j] = 0.0;
                }
            }

            int m = 0;
            int n = 0;
            double betaT = 0.0;

            for (int i = 0; i < Common.CityCount; i++)
            {
                for (int j = 1; j < vehicle[i].VehiclePathList.Count; j++)
                {
                    m = vehicle[i].VehiclePathList[j];
                    n = vehicle[i].VehiclePathList[j - 1];
                    if (m != n && m != 0)
                    {
                        betaT = 1 / vehicle[i].PathLength;
                        //betaT = 1 / Math.Pow(Common.gDistance[m, n], 3);
                    }
                    dbTempAry[n, m] = dbTempAry[n, m] + betaT;
                    //Console.WriteLine(dbTempAry[n, m]);
                }
            }

            //更新环境信息素
            for (int i = 0; i < Common.CityCount; i++)
            {
                for (int j = 0; j < Common.CityCount; j++)
                {
                    Common.gTrial[i, j] = Common.gTrial[i, j] * Common.GaROU + dbTempAry[i, j] * (1 - Common.GaROU);  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
                    if (Common.gTrial[i, j] > Common.Maxpheromone)
                    {
                        Common.gTrial[i, j] = Common.Maxpheromone;
                    }
                    if (Common.gTrial[i, j] < Common.Minpheromone)
                    {
                        Common.gTrial[i, j] = Common.Minpheromone;
                    }
                    //Console.WriteLine(Common.gTrial[i, j]);
                }
            }
        }


        /// <summary>
        /// 更新局部最优信息素
        /// </summary>
        private void UpdateLocalTrial()
        {
            double[,] dbTempAry = new double[Common.CityCount, Common.CityCount];

            for (int i = 0; i < Common.CityCount; i++) //计算每只蚂蚁留下的信息素
            {
                for (int j = 1; j < Common.CityCount; j++)
                {
                    dbTempAry[i, j] = 0.0;
                }
            }

            int m = 0;
            int n = 0;
            double betaT = 0.0;

            for (int i = 0; i < Common.CityCount; i++)
            {
                for (int j = 1; j < localBestVehicle.VehiclePathList.Count; j++)
                {
                    m = localBestVehicle.VehiclePathList[j];
                    n = localBestVehicle.VehiclePathList[j - 1];
                    if (m != n)
                    {
                        betaT = 1 / (Common.gDistance[m, n] * localBestVehicle.VehiclePathList.FindAll(EqulesZero).Count);
                        //betaT = 1 / Math.Pow(Common.gDistance[m, n], 3);
                        //betaT = 1 / localBestVehicle.PathLength; 
                    }
                    dbTempAry[n, m] = dbTempAry[n, m] + betaT;
                    //Console.WriteLine(dbTempAry[n, m]);
                }
            }

            //更新环境信息素
            for (int i = 0; i < Common.CityCount; i++)
            {
                for (int j = 0; j < Common.CityCount; j++)
                {
                    Common.gTrial[i, j] = Common.gTrial[i, j] * Common.ROU + dbTempAry[i, j] *(1 - Common.ROU);  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
                    if (Common.gTrial[i, j] > Common.Maxpheromone)
                    {
                        Common.gTrial[i, j] = Common.Maxpheromone;
                    }
                    if (Common.gTrial[i, j] < Common.Minpheromone)
                    {
                        Common.gTrial[i, j] = Common.Minpheromone;
                    }
                    //Console.WriteLine(Common.gTrial[i, j]);
                }
            }
        }

        /// <summary>
        /// 开始搜索
        /// </summary>
        public void Search()
        {
            Common.gaLocalLength.Clear();
            Common.listBestGaAcLength.Clear();
            int count = 0;
            int tempCount = 20;
            InitData();
            int gaFlag = 0;
            int acFlag = 0;
            double gaAvg = 0;
            double selectFlag = 0;
            double tempLength = 0;

            //在迭代次数内进行循环
            for (int i = 0; i < Common.LoopCount; i++)
            {
                listVehicle.Clear();
                //每只蚂蚁搜索一遍
                for (int j = 0; j < Common.CityCount; j++)
                {
                    vehicle[j].VehicleSearch();
                    listVehicle.Add(vehicle[j]);
                }

                localBestVehicle.PathLength = Common.DBMax;
                //保存局部最佳结果
                int temp = 0;
                for (int j = 0; j < Common.CityCount; j++)
                {
                    if (vehicle[j].PathLength < localBestVehicle.PathLength)
                    {
                        temp = j;
                        localBestVehicle.PathLength = vehicle[j].PathLength;
                        localBestVehicle.TotalTime = vehicle[j].TotalTime;
                        localBestVehicle.VehiclePathList = (List<int>)INTSergesion.DeepClone(vehicle[j].VehiclePathList);
                    }
                }
                Common.gaLocalLength.Add(localBestVehicle.PathLength);

                //if (localBestVehicle.PathLength > ga.GaBestPathLength)
                //{
                //    localBestVehicle.PathLength = ga.GaBestPathLength;
                //    localBestVehicle.VehiclePathList = (List<int>)INTSergesion.DeepClone(ga.GaBestPathList);
                //    //count = 51;
                //}

                if (localBestVehicle.PathLength < globalBestVehicle.PathLength)
                {
                    globalBestVehicle.PathLength = localBestVehicle.PathLength;
                    globalBestVehicle.VehiclePathList = (List<int>)INTSergesion.DeepClone(localBestVehicle.VehiclePathList);
                    //globalBestVehicle.TotalTime = localBestVehicle.TotalTime;

                    //定义最大最小信息素
                    Common.Maxpheromone = 1 / (globalBestVehicle.PathLength * (1 - Common.ROU));
                    Common.Minpheromone = Common.Maxpheromone / 5;
                    if (Common.Output)
                    {
                        Common.BackCount = globalBestVehicle.VehiclePathList.FindAll(EqulesZero).Count - 1;
                        Console.WriteLine("迭代次数{0}\t车辆数{1}", i, globalBestVehicle.VehiclePathList.FindAll(EqulesZero).Count - 1);
                        Console.WriteLine("路径长度{0}", globalBestVehicle.PathLength);
                        Console.Write("路径长度为{0}\t", globalBestVehicle.PathLength);
                        //Console.WriteLine("总耗费时间:{0}", globalBestVehicle.TotalTime);

                        foreach (int k in globalBestVehicle.VehiclePathList)
                        {
                            Console.Write("{0},", k);
                        }
                        Console.WriteLine();
                    }
                    count = 0;
                    gaFlag = 0;
                    acFlag = 0;
                }
                else
                {
                    if (i > 250)
                    {
                        count++;
                        gaFlag++;
                        acFlag++;
                    }
                    //acFlag++;
                }

                if (count > 30)
                {
                    while (true)
                    {
                        ga.Search(listVehicle);
                        UpdateGaTrial();
                        for (int j = 0; j < ga.GaVehicleList.Count; j++)
                        {
                            gaAvg += ga.GaVehicleList[j].PathLength;
                        }

                        gaAvg = gaAvg / ga.GaVehicleList.Count;
                        tempLength = 1 / globalBestVehicle.PathLength;
                        gaAvg = 1 / gaAvg;
                        selectFlag = Common.rnd(0, tempLength + gaAvg);
                        if (selectFlag < tempLength)
                        {
                            break;
                        }
                    }
                    UpdateGaTrial();
                    count = 0;
                }

                if (gaFlag > 15 && Common.GaROU < Common.GaROUMax)
                {
                    Common.GaROU = Common.GaROU + Common.GaROU * 0.01;
                    gaFlag = 0;
                }

                if (acFlag > 20 && Common.ROU > Common.ROUMin)
                {
                    Common.ROU = Common.ROU - Common.ROU * 0.002;
                    acFlag = 0;
                }

                //更新环境信息素
                UpdateLocalTrial();
                //UpadateGlobal();
                Common.listBestGaAcLength.Add(globalBestVehicle.PathLength);

            }
            if (Common.Output)
            {
                Console.WriteLine();
                Console.WriteLine("最优路径为:");
                Console.WriteLine("车辆数{0}", globalBestVehicle.VehiclePathList.FindAll(EqulesZero).Count - 1);
                Console.WriteLine("路径长度{0}", globalBestVehicle.PathLength);
                Console.Write("路径长度为{0}\t", globalBestVehicle.PathLength);
                //Console.WriteLine("总耗费时间:{0}", globalBestVehicle.TotalTime);

                foreach (int k in globalBestVehicle.VehiclePathList)
                {
                    Console.Write("{0},", k);
                }
                Console.WriteLine();
            }
        }

        private bool EqulesZero(int cityNo)
        {
            if (cityNo == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
