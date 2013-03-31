using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    class AntVRP
    {
        /// <summary>
        /// 车辆数组
        /// </summary>
        Vehicle[] vehicle;

        /// <summary>
        /// 最优车辆
        /// </summary>
        Vehicle[] bestVehicle;
        
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData() 
        {
        }

        public AntVRP()
        {
            vehicle = new Vehicle[Common.CityCount];
            for (int i = 0; i < Common.CityCount; i++)
            {
                vehicle[i] = new Vehicle();
            }
            bestVehicle = new Vehicle();
        }

        /// <summary>
        /// 更新信息素
        /// </summary>
        public void UpdateTrial()
        { 
        }

        /// <summary>
        /// 开始搜索
        /// </summary>
        public void Search()
        { 
        }
    }
}
