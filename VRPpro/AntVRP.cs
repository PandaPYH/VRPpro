using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    public class AntVRP
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
        /// 全局最优车辆
        /// </summary>
        public Vehicle globalBestVehicle;

        

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

        public AntVRP()
        {
            vehicle = new Vehicle[Common.AntCount];
            for (int i = 0; i < Common.AntCount; i++)
            {
                vehicle[i] = new Vehicle();
            }
            globalBestVehicle = new Vehicle();
            localBestVehicle = new Vehicle();
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
                        betaT = 1 / Math.Pow(Common.gDistance[m, n], 3);
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
                    Common.gTrial[i, j] = Common.gTrial[i, j] * Common.ROU + (1 - Common.ROU) * dbTempAry[i, j];  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
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
                    Common.gTrial[i, j] = Common.gTrial[i, j] * Common.ROU + dbTempAry[i, j];  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
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

        //private void UpadateGlobal()
        //{
        //    double[,] dbTempAry = new double[Common.CityCount, Common.CityCount];

        //    for (int i = 0; i < Common.CityCount; i++) //计算每只蚂蚁留下的信息素
        //    {
        //        for (int j = 1; j < Common.CityCount; j++)
        //        {
        //            dbTempAry[i, j] = 0.0;
        //        }
        //    }

        //    int m = 0;
        //    int n = 0;
        //    double betaT = 0.0;

        //    for (int i = 0; i < Common.CityCount; i++)
        //    {
        //        for (int j = 1; j < globalBestVehicle.VehiclePathList.Count; j++)
        //        {
        //            m = globalBestVehicle.VehiclePathList[j];
        //            n = globalBestVehicle.VehiclePathList[j - 1];
        //            if (m != n && m != 0)
        //            {
        //                betaT = 1 / (Common.gDistance[m, n] * globalBestVehicle.VehiclePathList.FindAll(EqulesZero).Count);
        //            }
        //            dbTempAry[n, m] = dbTempAry[n, m] + betaT;
        //            //Console.WriteLine(dbTempAry[n, m]);
        //        }
        //    }

        //    //更新环境信息素
        //    for (int i = 0; i < Common.CityCount; i++)
        //    {
        //        for (int j = 0; j < Common.CityCount; j++)
        //        {
        //            Common.gTrial[i, j] = Common.gTrial[i, j] * Common.ROU + dbTempAry[i, j];  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
        //            //if (Common.gTrial[i, j] > Common.Maxpheromone)
        //            //{
        //            //    Common.gTrial[i, j] = Common.Maxpheromone;
        //            //}
        //            //if (Common.gTrial[i, j] < Common.Minpheromone)
        //            //{
        //            //    Common.gTrial[i, j] = Common.Minpheromone;
        //            //}
        //            //Console.WriteLine(Common.gTrial[i, j]);
        //        }
        //    }
        //}

        /// <summary>
        /// 开始搜索
        /// </summary>
        public void Search()
        {
            Common.sACLocalLength.Clear();
            Common.listBestAcLength.Clear();
            InitData();
            int[] PathArray = new int[200];

            //for (int i = 0; i < Common.CityCount; i++)
            //{
            //    for (int j = 0; j < Common.CityCount; j++)
            //    {
            //        //Common.gTrial[i, j] = Common.gTrial[i, j] * Common.ROU + dbTempAry[i, j];  //最新的环境信息素 = 留存的信息素 + 新留下的信息素
            //        //if (Common.gTrial[i, j] > Common.Maxpheromone)
            //        //{
            //        //    Common.gTrial[i, j] = Common.Maxpheromone;
            //        //}
            //        //if (Common.gTrial[i, j] < Common.Minpheromone)
            //        //{
            //        //    Common.gTrial[i, j] = Common.Minpheromone;
            //        //}
            //        Console.WriteLine(Common.gTrial[i, j]);
            //    }
            //}

            //在迭代次数内进行循环
            for (int i = 0; i < Common.LoopCount; i++)
            {
                //每只蚂蚁搜索一遍
                for (int j = 0; j < Common.AntCount; j++)
                {
                    vehicle[j].VehicleSearch();
                    //foreach (int k in vehicle[j].VehiclePathList)
                    //{
                    //    Console.Write("{0},", k);
                    //}
                    //Console.Write(j);
                }

                localBestVehicle.PathLength = Common.DBMax;
                //保存局部最佳结果
                for (int j = 0; j < Common.AntCount; j++)
                {
                    if (vehicle[j].PathLength < localBestVehicle.PathLength)
                    {
                        localBestVehicle.PathLength = vehicle[j].PathLength;
                        localBestVehicle.TotalTime = vehicle[j].TotalTime;
                        localBestVehicle.VehiclePathList = vehicle[j].VehiclePathList;
                    }
                }
                Common.sACLocalLength.Add(localBestVehicle.PathLength);

                //Console.WriteLine("localBestVehicle = {0}", localBestVehicle.PathLength);

                //for (int j = 0; j < Common.CityCount; j++)
                //{
                //    if (vehicle[j].Consumption < localBestVehicle.Consumption)
                //    {
                //        localBestVehicle.PathLength = vehicle[j].PathLength;
                //        localBestVehicle.TotalTime = vehicle[j].TotalTime;
                //        localBestVehicle.VehiclePathList = vehicle[j].VehiclePathList;
                //        localBestVehicle.Consumption = vehicle[j].Consumption;
                //    }
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
                    //for (int k = 0; k < PathArray.Length; k++)
                    //{
                    //    PathArray[k] = 0;
                    //}

                    //for (int k = 0; k < globalBestVehicle.VehiclePathList.Count; k++)
                    //{
                    //    PathArray[k] = globalBestVehicle.VehiclePathList[k];
                    //}
                    
                }

                //if (localBestVehicle.Consumption < globalBestVehicle.Consumption)
                //{
                //    globalBestVehicle.PathLength = localBestVehicle.PathLength;
                //    globalBestVehicle.VehiclePathList = localBestVehicle.VehiclePathList;
                //    globalBestVehicle.TotalTime = localBestVehicle.TotalTime;
                //    globalBestVehicle.Consumption = localBestVehicle.Consumption;
                //    Console.WriteLine("迭代次数{0}\t车辆数{1}", i, globalBestVehicle.VehiclePathList.FindAll(EqulesZero).Count - 1);
                //    Console.WriteLine("路径长度{0}", globalBestVehicle.PathLength);
                //    Console.Write("路径长度为{0}\t", globalBestVehicle.PathLength);
                //    Console.WriteLine("总耗费时间:{0}", globalBestVehicle.TotalTime);
                //    foreach (int k in globalBestVehicle.VehiclePathList)
                //    {
                //        Console.Write("{0},", k);
                //    }
                //    Console.WriteLine();
                //}  

                //更新环境信息素
                //UpdateTrial();
                UpdateLocalTrial();
                Common.listBestAcLength.Add(globalBestVehicle.PathLength);
                //UpadateGlobal();
            }

            //Console.WriteLine("最优路径为:");
            //Console.WriteLine("路径长度为{0}", globalBestVehicle.PathLength);
            ////foreach (int i in globalBestVehicle.VehiclePathList)
            ////{
            ////    Console.Write("{0}\t", i);
            ////}
            //for (int i = 0; i < PathArray.Length; i++)
            //{
            //    Console.Write("{0}\t", PathArray[i]);
            //    if (PathArray[i] == 0 && PathArray[i + 1] == 0)
            //    {
            //        break;
            //    }
            //}
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
