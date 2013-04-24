using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            list.Insert(0, 10);
            foreach (int k in list)
            {
                Console.Write("{0},", k);
            }
            Console.Read();
        }
    }
}
