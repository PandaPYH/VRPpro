using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VRPpro
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.ReadVRPFile();
            //DateTime start = DateTime.Now;

            Common.InitCommon();
            AntVRP antvrp = new AntVRP();
            antvrp.Search();
            //for (int i = 0; i < 10; i++)
            //{
            //    AntVRP antvrp = new AntVRP();
            //    antvrp.Search();
            //}
            //DateTime end = DateTime.Now;
            //TimeSpan use = start - end;
            Console.WriteLine();
            //Console.WriteLine("车辆路径平均长度：{0}", Common.TotalDistance / 10);
            //Console.WriteLine("平均车辆数量：{0}", Common.TotalVehicleCount / 10);
            //Console.WriteLine("使用的时间为 {0}", use);
            Console.Read();

        }
    }
}
