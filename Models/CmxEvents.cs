using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace MobiWifiApp.Models
{
    public partial class CmxEvents
    {
        public long Id { get; set; }
        public PhysicalAddress Apmac { get; set; }
        public string Type { get; set; }
        public DateTime Received { get; set; }
    }
}
