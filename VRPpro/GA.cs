using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    public class GA
    {
        public List<int> Path1 = new List<int>();
        public List<int> Path2 = new List<int>();
        public List<int> GaBestPathList = new List<int>();
        public List<Vehicle> GaVehicleList = new List<Vehicle>();
        public double GaBestPathLength;

        public GA()
        {
            GaBestPathLength = Common.DBMax;
        }

        /// <summary>
        /// 种群交配
        /// </summary>
        /// <param name="vehicleList">被选出的蚁群样本</param>
        public void Cross(List<Vehicle> vehicleList)
        {
            double dbTotal = 0.0;
            double[] prob = new double[vehicleList.Count];
            GaBestPathLength = Common.DBMax;
            Vehicle vehicleFa = new Vehicle();
            Vehicle vehicleMo = new Vehicle(); 
            double tempLength1;
            double tempLength2;
            double dbTemp;
            GaVehicleList.Clear();

            //优秀解交叉
            for (int k = 0; k < Common.GALoogCount; k++)
            {
                dbTotal = 0.0;
                for (int i = 0; i < vehicleList.Count; i++)
                {
                    prob[i] = 1 / vehicleList[i].PathLength;
                    dbTotal += prob[i];
                }



                //使用轮盘赌选择两个父代进行交配

                int[] selected = new int[2];
                if (dbTotal > 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        dbTemp = Common.rnd(0.0, dbTotal);
                        for (int j = 0; j < Common.PopulationCount; j++)
                        {
                            dbTemp = dbTemp - prob[i]; //这个操作相当于转动轮盘
                            if (dbTemp < 0.0) //轮盘停止转动，记下蚂蚁编号，直接跳出循环
                            {
                                selected[i] = j;
                                prob[j] = 0;
                                break;
                            }
                        }
                    }
                }

                TwoAntCross(vehicleList[selected[0]], vehicleList[selected[1]]);
                tempLength1 = GetPathLength(Path1);
                tempLength2 = GetPathLength(Path2);

                if (tempLength1 < vehicleList[selected[0]].PathLength)
                {
                    vehicleList[selected[0]].PathLength = tempLength1;
                    vehicleList[selected[0]].VehiclePathList = (List<int>)INTSergesion.DeepClone(Path1);
                }
                else
                {
                    if (tempLength1 < vehicleList[selected[1]].PathLength)
                    {
                        vehicleList[selected[1]].PathLength = tempLength1;
                        vehicleList[selected[1]].VehiclePathList = (List<int>)INTSergesion.DeepClone(Path1);
                    }

                }

                if (tempLength2 < vehicleList[selected[1]].PathLength)
                {
                    vehicleList[selected[1]].PathLength = tempLength2;
                    vehicleList[selected[1]].VehiclePathList = (List<int>)INTSergesion.DeepClone(Path2);
                }
                else
                {
                    if (tempLength2 < vehicleList[selected[0]].PathLength)
                    {
                        vehicleList[selected[0]].PathLength = tempLength2;
                        vehicleList[selected[0]].VehiclePathList = (List<int>)INTSergesion.DeepClone(Path2);
                    }
                }
            }

            //变异


            for (int i = 0; i < vehicleList.Count; i++)
            {
                GaVehicleList.Add(vehicleList[i]);
                if (vehicleList[i].PathLength < GaBestPathLength)
                {
                    GaBestPathLength = vehicleList[i].PathLength;
                    GaBestPathList = (List<int>)INTSergesion.DeepClone(vehicleList[i].VehiclePathList);
                }
            }
        }

        /// <summary>
        /// 两蚂蚁交配
        /// </summary>
        public void TwoAntCross(Vehicle vehicleFa, Vehicle vehicleMo)
        {
            List<int> listZeroFa = new List<int>();
            List<int> listZeroMo = new List<int>();

            for (int i = 0; i < vehicleFa.VehiclePathList.Count; i++)
            {
                if (vehicleFa.VehiclePathList[i] == 0)
                {
                    listZeroFa.Add(i);
                }
            }

            for (int i = 0; i < vehicleMo.VehiclePathList.Count; i++)
            {
                if (vehicleMo.VehiclePathList[i] == 0)
                {
                    listZeroMo.Add(i);
                }
            }

            //交配段下界
            int LowPointFa = Common.rnd(0, listZeroFa.Count - 1);
            int LowPointMo = Common.rnd(0, listZeroMo.Count - 1);

            //交配段上界
            int UpPointFa = LowPointFa + 1;
            int UpPointMo = LowPointMo + 1;

            List<int> tempPath1 = new List<int>();
            List<int> tempPath2 = new List<int>();

            //获取母方交换基因段
            int temp = listZeroMo[LowPointMo];
            int count = listZeroMo[UpPointMo] - listZeroMo[LowPointMo] + 1;
            for (int i = 0; i < count; i++)
            {
                tempPath1.Add(vehicleMo.VehiclePathList[temp]);
                temp++;
            }

            //获取父方交换基因段
            temp = listZeroFa[LowPointFa];
            count = listZeroFa[UpPointFa] - listZeroFa[LowPointFa] + 1;
            for (int i = 0; i < count; i++)
            {
                tempPath2.Add(vehicleFa.VehiclePathList[temp]);
                temp++;
            }

            List<int> NewPath1 = (List<int>)INTSergesion.DeepClone(tempPath1);
            List<int> NewPath2 = (List<int>)INTSergesion.DeepClone(tempPath2);

            for (int i = 0; i < tempPath2.Count; i++)
            {
                if (!tempPath1.Contains(tempPath2[i]))
                {
                    NewPath1.Add(tempPath2[i]);
                }
            }
            for (int i = 0; i < tempPath1.Count; i++)
            {
                if (!tempPath2.Contains(tempPath1[i]))
                {
                    NewPath2.Add(tempPath1[i]);
                }
            }

            //父方
            for (int i = 0; i < listZeroFa[LowPointFa]; i++)
            {
                if (vehicleFa.VehiclePathList[i] != 0 && !PathComparer(tempPath1, vehicleFa.VehiclePathList[i]))
                {
                    NewPath1.Add(vehicleFa.VehiclePathList[i]);
                }
            }
            for (int i = listZeroFa[UpPointFa] + 1; i < vehicleFa.VehiclePathList.Count; i++)
            {
                if (vehicleFa.VehiclePathList[i] != 0 && !PathComparer(tempPath1, vehicleFa.VehiclePathList[i]))
                {
                    NewPath1.Add(vehicleFa.VehiclePathList[i]);
                }
            }

            //母方
            for (int i = 0; i < listZeroMo[LowPointMo]; i++)
            {
                if (vehicleMo.VehiclePathList[i] != 0 && !PathComparer(tempPath2, vehicleMo.VehiclePathList[i]))
                {
                    NewPath2.Add(vehicleMo.VehiclePathList[i]);
                }
            }
            for (int i = listZeroMo[UpPointMo] + 1; i < vehicleMo.VehiclePathList.Count; i++)
            {
                if (vehicleMo.VehiclePathList[i] != 0 && !PathComparer(tempPath2, vehicleMo.VehiclePathList[i]))
                {
                    NewPath2.Add(vehicleMo.VehiclePathList[i]);
                }
            }



            NewPath1.Add(0);
            NewPath2.Add(0);

            //按照条件插入0
            int begin = tempPath1.Count;
            int demand = 0;
            while (true)
            {
                if (NewPath1[begin] == 0)
                {
                    break;
                }
                demand += Common.cityInfo[NewPath1[begin]].Demand;
                if (demand + Common.cityInfo[NewPath1[begin + 1]].Demand > Common.Capacity)
                {
                    NewPath1.Insert(begin + 1, 0);
                    begin++;
                    demand = 0;
                }
                begin++;
            }

            begin = tempPath2.Count;
            demand = 0;
            while (true)
            {
                if (NewPath2[begin] == 0)
                {
                    break;
                }
                demand += Common.cityInfo[NewPath2[begin]].Demand;
                if (demand + Common.cityInfo[NewPath2[begin + 1]].Demand > Common.Capacity)
                {
                    NewPath2.Insert(begin + 1, 0);
                    begin++;
                    demand = 0;
                }
                begin++;
            }

            Path1 = (List<int>)INTSergesion.DeepClone(NewPath1);
            Path2 = (List<int>)INTSergesion.DeepClone(NewPath2);

            ////Test
            //for (int i = tempPath1.Count; i < NewPath1.Count; i++)
            //{
            //    if (NewPath1[i] != 0)
            //    {
            //        for (int j = 0; j < tempPath1.Count; j++)
            //        {
            //            if (NewPath1[i] == tempPath1[j])
            //            {
            //                throw new Exception("Error");
            //            }
            //        }
            //    }
            //}

            //for (int i = tempPath2.Count; i < NewPath2.Count; i++)
            //{
            //    if (NewPath2[i] != 0)
            //    {
            //        for (int j = 0; j < tempPath2.Count; j++)
            //        {
            //            if (NewPath2[i] == tempPath2[j])
            //            {
            //                throw new Exception("Error");
            //            }
            //        }
            //    }
            //}
        }

        ///// <summary>
        ///// 两蚂蚁交配
        ///// </summary>
        //public void TwoAntCross(Vehicle vehicleFa, Vehicle vehicleMo)
        //{
        //    List<int> listZeroFa = new List<int>();
        //    List<int> listZeroMo = new List<int>();
        //    int backcount = Common.BackCount;
        //    int keepBack = backcount / 2 + 1;

        //    for (int i = 0; i < vehicleFa.VehiclePathList.Count; i++)
        //    {
        //        if (vehicleFa.VehiclePathList[i] == 0)
        //        {
        //            listZeroFa.Add(i);
        //        }
        //    }

        //    for (int i = 0; i < vehicleMo.VehiclePathList.Count; i++)
        //    {
        //        if (vehicleMo.VehiclePathList[i] == 0)
        //        {
        //            listZeroMo.Add(i);
        //        }
        //    }


        //    //交配段下界
        //    int LowPointFa = 0;//Common.rnd(0, listZeroFa.Count - 1);
        //    int LowPointMo = 0;//Common.rnd(0, listZeroMo.Count - 1);

        //    //交配段上界
        //    int UpPointFa = LowPointFa + keepBack - 1;
        //    int UpPointMo = LowPointMo + keepBack - 1;

        //    List<int> tempPath1 = new List<int>();
        //    List<int> tempPath2 = new List<int>();

        //    //for (int k = 0; k < keepBack; k++)
        //    //{
        //    //获取母方交换基因段
        //    int temp = listZeroMo[LowPointMo];
        //    int count = listZeroMo[UpPointMo] - listZeroMo[LowPointMo] + 1;
        //    for (int i = 0; i < count; i++)
        //    {
        //        tempPath1.Add(vehicleMo.VehiclePathList[temp]);
        //        temp++;
        //    }


        //    //获取父方交换基因段
        //    temp = listZeroFa[LowPointFa];
        //    count = listZeroFa[UpPointFa] - listZeroFa[LowPointFa] + 1;
        //    for (int i = 0; i < count; i++)
        //    {
        //        tempPath2.Add(vehicleFa.VehiclePathList[temp]);
        //        temp++;
        //    }
        //    //}

        //    List<int> NewPath1 = (List<int>)INTSergesion.DeepClone(tempPath1);
        //    List<int> NewPath2 = (List<int>)INTSergesion.DeepClone(tempPath2);

        //    for (int i = 0; i < tempPath2.Count; i++)
        //    {
        //        if (!tempPath1.Contains(tempPath2[i]))
        //        {
        //            NewPath1.Add(tempPath2[i]);
        //        }
        //    }
        //    for (int i = 0; i < tempPath1.Count; i++)
        //    {
        //        if (!tempPath2.Contains(tempPath1[i]))
        //        {
        //            NewPath2.Add(tempPath1[i]);
        //        }
        //    }

        //    //父方
        //    for (int i = 0; i < listZeroFa[LowPointFa]; i++)
        //    {
        //        if (vehicleFa.VehiclePathList[i] != 0 && !PathComparer(tempPath1, vehicleFa.VehiclePathList[i]))
        //        {
        //            NewPath1.Add(vehicleFa.VehiclePathList[i]);
        //        }
        //    }
        //    for (int i = listZeroFa[UpPointFa] + 1; i < vehicleFa.VehiclePathList.Count; i++)
        //    {
        //        if (vehicleFa.VehiclePathList[i] != 0 && !PathComparer(tempPath1, vehicleFa.VehiclePathList[i]))
        //        {
        //            NewPath1.Add(vehicleFa.VehiclePathList[i]);
        //        }
        //    }

        //    //母方
        //    for (int i = 0; i < listZeroMo[LowPointMo]; i++)
        //    {
        //        if (vehicleMo.VehiclePathList[i] != 0 && !PathComparer(tempPath2, vehicleMo.VehiclePathList[i]))
        //        {
        //            NewPath2.Add(vehicleMo.VehiclePathList[i]);
        //        }
        //    }
        //    for (int i = listZeroMo[UpPointMo] + 1; i < vehicleMo.VehiclePathList.Count; i++)
        //    {
        //        if (vehicleMo.VehiclePathList[i] != 0 && !PathComparer(tempPath2, vehicleMo.VehiclePathList[i]))
        //        {
        //            NewPath2.Add(vehicleMo.VehiclePathList[i]);
        //        }
        //    }



        //    NewPath1.Add(0);
        //    NewPath2.Add(0);

        //    //按照条件插入0
        //    int begin = tempPath1.Count;
        //    int demand = 0;
        //    while (true)
        //    {
        //        if (NewPath1[begin] == 0)
        //        {
        //            break;
        //        }
        //        demand += Common.cityInfo[NewPath1[begin]].Demand;
        //        if (demand + Common.cityInfo[NewPath1[begin + 1]].Demand > Common.Capacity)
        //        {
        //            NewPath1.Insert(begin + 1, 0);
        //            begin++;
        //            demand = 0;
        //        }
        //        begin++;
        //    }

        //    begin = tempPath2.Count;
        //    demand = 0;
        //    while (true)
        //    {
        //        if (NewPath2[begin] == 0)
        //        {
        //            break;
        //        }
        //        demand += Common.cityInfo[NewPath2[begin]].Demand;
        //        if (demand + Common.cityInfo[NewPath2[begin + 1]].Demand > Common.Capacity)
        //        {
        //            NewPath2.Insert(begin + 1, 0);
        //            begin++;
        //            demand = 0;
        //        }
        //        begin++;
        //    }

        //    Path1 = (List<int>)INTSergesion.DeepClone(NewPath1);
        //    Path2 = (List<int>)INTSergesion.DeepClone(NewPath2);
        //}

        private static bool PathComparer(List<int> pathList, int i)
        {
            return pathList.Contains(i);
        }

        /// <summary>
        /// 寻找种群样本
        /// </summary>
        public List<Vehicle> FindPop(List<Vehicle> vehicleList)
        {
            double[] prob = new double[Common.CityCount];
            double dbTotal = 0;
            List<Vehicle> selectedVeicle = new List<Vehicle>();

            for (int i = 0; i < Common.CityCount; i++)
            {
                prob[i] = 1 / vehicleList[i].PathLength;
                dbTotal += prob[i];
            }

            double dbTemp = 0;
            int selected = 0;

            //轮盘赌选出指定个数蚂蚁
            if (dbTotal > 0)
            {
                for (int i = 0; i < Common.PopulationCount; i++)
                {
                    dbTemp = Common.rnd(0.0, dbTotal);
                    for (int j = 0; j < Common.CityCount; j++)
                    {
                        dbTemp = dbTemp - prob[i]; //这个操作相当于转动轮盘
                        if (dbTemp < 0.0) //轮盘停止转动，记下蚂蚁编号，直接跳出循环
                        {
                            selected = j;
                            dbTotal = dbTotal - prob[j];
                            prob[j] = 0;
                            break;
                        }
                    }
                    selectedVeicle.Add(vehicleList[selected]);
                }
            }

            return selectedVeicle;
        }

        /// <summary>
        /// 计算路径长度
        /// </summary>
        public double GetPathLength(List<int> PathList)
        {
            double pathLength = 0;
            for (int i = 1; i < PathList.Count; i++)
            {
                pathLength += Common.gDistance[PathList[i - 1], PathList[i]];
            }
            return pathLength;

            //PathLength += Common.gDistance[VehiclePathList[VehiclePathList.Count - 1], VehiclePathList[0]];
        }

        public void Search(List<Vehicle> vehicleList)
        {
            Cross(FindPop(vehicleList));
        }
    }
}
