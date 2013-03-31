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
            Common.InitCommon();
            Vehicle vehicle = new Vehicle();
            vehicle.Search();
            Console.WriteLine();
            Console.Read();
        }
    }
}
