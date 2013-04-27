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
            //Common.InitCommon();
            //GAAntVRP gaAntvrp = new GAAntVRP();
            //gaAntvrp.Search();
            //DateTime start = DateTime.Now;

            double avg = 0;
            for (int i = 0; i < 10; i++)
            {
                Common.InitCommon();
                //GAAntVRP gaAntvrp = new GAAntVRP();
                //gaAntvrp.Search();
                AntVRP antvrp = new AntVRP();
                antvrp.Search();
                avg += antvrp.globalBestVehicle.PathLength;
                Console.WriteLine("[{0}]: {1}", i, antvrp.globalBestVehicle.PathLength);
                //avg += gaAntvrp.globalBestVehicle.PathLength;
                //Console.WriteLine("[{0}]: {1}", i, gaAntvrp.globalBestVehicle.PathLength);
            }

            avg = avg / 10;

            Console.WriteLine("avg: {0}", avg);

            avg = 0;
            for (int i = 0; i < 10; i++)
            {
                Common.InitCommon();
                GAAntVRP gaAntvrp = new GAAntVRP();
                gaAntvrp.Search();
                //AntVRP antvrp = new AntVRP();
                //antvrp.Search();
                //avg += antvrp.globalBestVehicle.PathLength;
                //Console.WriteLine("[{0}]: {1}", i, antvrp.globalBestVehicle.PathLength);
                avg += gaAntvrp.globalBestVehicle.PathLength;
                Console.WriteLine("[{0}]: {1}", i, gaAntvrp.globalBestVehicle.PathLength);
            }

            avg = avg / 10;

            Console.WriteLine("avg: {0}", avg);

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
