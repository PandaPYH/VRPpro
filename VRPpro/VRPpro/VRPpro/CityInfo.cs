using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    public class CityInfo
    {
        /// <summary>
        /// 城市编号
        /// </summary>
        public int CityId;

        /// <summary>
        /// 城市的X坐标
        /// </summary>
        public int Xcoord;

        /// <summary>
        /// 城市的Y坐标
        /// </summary>
        public int Ycoord;

        /// <summary>
        /// 城市的需求量
        /// </summary>
        public int Demand;

        /// <summary>
        /// 最早开始服务时间
        /// </summary>
        public int ReadyTime;

        /// <summary>
        /// 最晚开始服务时间
        /// </summary>
        public int DueDate;

        /// <summary>
        /// 服务所需时间
        /// </summary>
        public int ServiceTime;
    }
}
