using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiWifiApp.Models
{
    public class Report
    {
        public Report()
        {
        }

        public Report(int count, int hours)
        {
            Count = count;
            Hours = hours;
        }
        public int Count { get; set; }
        public int Hours { get; set; }
    }
}
