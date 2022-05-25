using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Trans
{
    public class TravelTime
    {
        public TimeSpan GetTravelTime(DateTime d1, DateTime d2)
        {
            return d2 - d1;
        }
    }
}

