using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiWifiApp.Models
{
    public class CountPerson
    {

        public CountPerson()
        {
        }

        public CountPerson(int count, int? times)
        {
            Count = count;
            Times=times;
        }
        public int Count { get; set; }
        public int? Times { get; set; }
    }


}

