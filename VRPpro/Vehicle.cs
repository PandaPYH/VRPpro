using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    public class Vehicle
    {
        #region 参数定义

        /// <summary>
        /// 当前城市
        /// </summary>
        public static int CurCity;

        /// <summary>
        /// 上一个城市
        /// </summary>
        public static int LastCity;

        /// <summary>
        /// 车辆路径链表
        /// </summary>
        public List<int> VehiclePathList;

        /// <summary>
        /// 车辆路径数组
        /// </summary>
        //public static int[] VehiclePath;

        /// <summary>
        /// 没有去过的城市
        /// </summary>
        public int[] AllowCity;

        /// <summary>
        /// 车辆走过的长度
        /// </summary>
        public double PathLength = 0;

        public List<double> PathLengthList = new List<double>();

        /// <summary>
        /// 去过城市的数目
        /// </summary>
        public int MoveCityCount;

        //private int Min;

        /// <summary>
        /// 车辆当前载重
        /// </summary>
        public int CurCapacity;

        /// <summary>
        /// 当前时间
        /// </summary>
        public double CurTime = 0;

        /// <summary>
        /// 等待时间
        /// </summary>
        public double WaitTime = 0;

        /// <summary>
        /// 总等待时间
        /// </summary>
        public double TotalTime = 0;

        /// <summary>
        /// 车辆经过城市的个数
        /// </summary>
        public int Count;

        /// <summary>
        /// 消耗量
        /// </summary>
        public double Consumption = 0;

        #endregion

        public Vehicle()
        {
            VehiclePathList = new List<int>();
            AllowCity = new int[Common.CityCount];
        }

        /// <summary>
        /// 初始化车辆
        /// </summary>
        public void InitVehicle()
        {
            for (int i = 0; i < Common.CityCount; i++)
            {
                AllowCity[i] = 1;
            }

            CurCity = 0;
            VehiclePathList.Clear();
            WaitTime = 0;
            TotalTime = 0;
            PathLength = 0.0;
            VehiclePathList.Add(0);
            MoveCityCount = 1;
            Count = 1;
            CurTime = 0;
            CurCapacity = Common.Capacity;
        }

        /// <summary>
        /// 选择下一个城市
        /// </summary>
        /// <returns></returns>
        public int ChooseNextCity()
        {
            int nSelectedCity = -1; //返回结果，先暂时把其设置为-1
            LastCity = CurCity;

            //double timediff = 0;
            double dbTotal = 0.0;
            double[] prob = new double[Common.CityCount]; //保存各个城市被选中的概率
            for (int i = 0; i < Common.CityCount; i++)
            {
                prob[i] = 0;
            }

            if (CurCity == 0)//当前城市为仓库时，可以去往各地
            {
                for (int i = 1; i < Common.CityCount; i++)
                {
                    if (isAllowCity(i) && isNoload(i)) //城市没去过
                    {
                        //timediff = Common.cityInfo[i].DueDate - (CurTime + Common.gDistance[CurCity, i]);
                        //economy = Common.gDistance[CurCity, 0] + Common.gDistance[0, i] - Common.gDistance[CurCity, i];
                        //WaitTime = GetWaitTime(CurCity, i);
                        prob[i] = Math.Pow(Common.gTrial[CurCity, i], Common.alpha)
                            * Math.Pow(1.0 / Common.gDistance[CurCity, i], Common.beta);
                            //* Math.Pow(economy, Common.gama)
                            //* Math.Pow(1.0 / timediff, Common.gama)
                            //* Math.Pow(1.0 / WaitTime, Common.thelta);
                        dbTotal = dbTotal + prob[i]; //累加信息素，得到总和
                    }
                    else //如果城市去过了，则其被选中的概率值为0
                    {
                        prob[i] = 0.0;
                    }
                }
            }
            else
            {
                //for (int i = 0; i < Common.CityCount; i++)
                //{
                //    if (isAllowCity(i) && isAllowTimeWindow(i) && isNoload(i)) //城市没去过
                //    {
                //        timediff = Common.cityInfo[i].DueDate - (CurTime + Common.gDistance[CurCity, i]);
                //        //economy = Common.gDistance[CurCity, 0] + Common.gDistance[0, i] - Common.gDistance[CurCity, i];
                //        WaitTime = GetWaitTime(CurCity, i);
                //        prob[i] = Math.Pow(Common.gTrial[CurCity, i], Common.alpha) 
                //            * Math.Pow(1.0 / Common.gDistance[CurCity, i], Common.beta)
                //            //* Math.Pow(economy, Common.gama)
                //            * Math.Pow(1.0 / timediff, Common.gama) 
                //            * Math.Pow(1.0 / WaitTime, Common.thelta);
                //        dbTotal = dbTotal + prob[i]; //累加信息素，得到总和
                //    }
                //    else //如果城市去过了，则其被选中的概率值为0
                //    {
                //        prob[i] = 0.0;
                //    }
                //}
                for (int i = 0; i < Common.NearCityCount; i++)
                {
                    int cityNo = Common.NearCityList[CurCity, i];
                    if (isAllowCity(cityNo) && isNoload(cityNo)) //城市没去过
                    {
                        //timediff = Common.cityInfo[cityNo].DueDate - (CurTime + Common.gDistance[CurCity, cityNo]);
                        //economy = Common.gDistance[CurCity, 0] + Common.gDistance[0, i] - Common.gDistance[CurCity, i];
                        //WaitTime = GetWaitTime(CurCity, cityNo);
                        prob[cityNo] = Math.Pow(Common.gTrial[CurCity, cityNo], Common.alpha)
                            * Math.Pow(1.0 / Common.gDistance[CurCity, cityNo], Common.beta);
                            //* Math.Pow(economy, Common.gama)
                            //* Math.Pow(1.0 / timediff, Common.gama)
                            //* Math.Pow(1.0 / WaitTime, Common.thelta);
                        dbTotal = dbTotal + prob[cityNo]; //累加信息素，得到总和
                    }
                    else //如果城市去过了，则其被选中的概率值为0
                    {
                        prob[cityNo] = 0.0;
                    }
                }

                //当邻近城市都被选择时
                //if (nSelectedCity == -1)
                //{
                //    for (int i = 1; i < Common.CityCount; i++)
                //    {
                //        if (isAllowCity(i) && isAllowTimeWindow(i) && isNoload(i)) //城市没去过
                //        {
                //            nSelectedCity = i;
                //            break;
                //        }
                //    }
                //}
            }

            //==============================================================================
            //进行轮盘选择
            double dbTemp = 0.0;
            if (dbTotal > 0.0) //总的信息素值大于0
            {
                dbTemp = Common.rnd(0.0, dbTotal); //取一个随机数

                for (int i = 0; i < Common.CityCount; i++)
                {
                    if (AllowCity[i] == 1) //城市没去过
                    {
                        dbTemp = dbTemp - prob[i]; //这个操作相当于转动轮盘，如果对轮盘选择不熟悉，仔细考虑一下
                        if (dbTemp < 0.0) //轮盘停止转动，记下城市编号，直接跳出循环
                        {
                            nSelectedCity = i;
                            break;
                        }
                    }
                }
            }

            //==============================================================================
            //如果城市间的信息素非常小 ( 小到比double能够表示的最小的数字还要小 )
            //那么由于浮点运算的误差原因，上面计算的概率总和可能为0
            //会出现经过上述操作，没有城市被选择出来
            //出现这种情况，就把第一个没去过的城市作为返回结果
            if (nSelectedCity == -1 && LastCity == 0)
            {
                for (int i = 1; i < Common.CityCount; i++)
                {
                    if (isAllowCity(i)) //城市没去过
                    {
                        nSelectedCity = i;
                        break;
                    }
                }
            }



            if (nSelectedCity == -1)
            {
                nSelectedCity = 0;
            }

            GetTotalTime(nSelectedCity);
            //==============================================================================
            //返回结果，就是城市的编号
            return nSelectedCity;
        }

        /// <summary>
        /// 车辆移动
        /// </summary>
        public void Move()
        {
            CurCity = ChooseNextCity();
            if (CurCity == 0)
            {
                CurCapacity = Common.Capacity;
                CurTime = 0;
                VehiclePathList.Add(0);
                CurTime += Common.gDistance[LastCity, CurCity];
            }
            else
            {
                WaitTime = GetWaitTime(LastCity, CurCity);
                CurTime += Common.gDistance[LastCity, CurCity] + WaitTime;
                VehiclePathList.Add(CurCity);
                AllowCity[CurCity] = 0;
                CurCapacity -= Common.cityInfo[CurCity].Demand;
                MoveCityCount++;
            }
        }

        /// <summary>
        /// 车辆进行搜索
        /// </summary>
        public void VehicleSearch()
        {
            InitVehicle();

            while (MoveCityCount < Common.CityCount)
            {
                Move();
            }
            VehiclePathList.Add(0);
            GetPathLength();
            //GetConsumption();
            //Console.WriteLine(VehiclePathList.Count);
            //Console.WriteLine("pathlength: {0}", PathLength);
            //Console.WriteLine("TotalTime: {0}", TotalTime);
        }

        /// <summary>
        /// 计算路径长度
        /// </summary>
        public void GetPathLength()
        {
            for (int i = 1; i < VehiclePathList.Count; i++)
            {
                PathLength += Common.gDistance[VehiclePathList[i - 1], VehiclePathList[i]]; 
            }

            //PathLength += Common.gDistance[VehiclePathList[VehiclePathList.Count - 1], VehiclePathList[0]];
        }
        
        /// <summary>
        /// 计算等待时间
        /// </summary>
        /// <param name="curCity">当前城市</param>
        /// <param name="nextCity">下一个城市</param>
        /// <returns>等待时间</returns>
        public double GetWaitTime(int curCity, int nextCity)
        {
            if (nextCity == 0)
            {
                return 0x7fff;
            }
            else
            {
                if (Common.cityInfo[nextCity].ReadyTime > Common.gDistance[curCity, nextCity] + CurTime)
                    return Common.cityInfo[nextCity].ReadyTime -
                        (Common.gDistance[curCity, nextCity] + CurTime) + Common.cityInfo[nextCity].ServiceTime;
                else
                    return Common.cityInfo[nextCity].ServiceTime;
            }
        }

        //得到总时间
        public void GetTotalTime(int CityNo)
        {
            if (CityNo == 0)
            {
                TotalTime += 0;
            }
            else
            {
                TotalTime += WaitTime;
            }
        }

        public void GetConsumption()
        {
            Consumption = PathLength * TotalTime;
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

        #region 逻辑判断

        /// <summary>
        /// 判断该城市是否去过
        /// </summary>
        /// <param name="cityId">城市编号</param>
        /// <returns></returns>
        private bool isAllowCity(int cityId)
        {
            if (AllowCity[cityId] == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 判断城市是否符合时间窗
        /// </summary>
        /// <param name="nextCity">下一个城市编号</param>
        /// <returns></returns>
        private bool isAllowTimeWindow(int nextCity)
        {
            if (Common.cityInfo[nextCity].DueDate - (CurTime + Common.gDistance[CurCity, nextCity]) >= 0)
                return true;
            return false;
        }

        /// <summary>
        /// 是否有足够货物
        /// </summary>
        /// <param name="nextCity">下一个城市编号</param>
        /// <returns></returns>
        private bool isNoload(int nextCity)
        {
            if (CurCapacity - Common.cityInfo[nextCity].Demand >= 0)
                return true;
            return false;
        }

        #endregion
    }
}
