using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VRPpro
{
    class IcpPathLength : IComparer<Vehicle>
    {

        public int Compare(Vehicle x, Vehicle y)
        {
            return x.PathLength.CompareTo(y.PathLength);
        }
    }
}
