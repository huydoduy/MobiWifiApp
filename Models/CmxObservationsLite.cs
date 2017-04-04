using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;

namespace MobiWifiApp.Models
{
    public partial class CmxObservationsLite
    {
        public PhysicalAddress Clientmac { get; set; }
        public IPAddress Ipv4 { get; set; }
        public int? Seenyear { get; set; }
        public int? Seenmonth { get; set; }
        public int? Seenday { get; set; }
        public int? Seenhour { get; set; }
        public int? Seenminute { get; set; }
        public string Ssid { get; set; }
        public string Manufacturer { get; set; }
        public string Os { get; set; }
        public long Id { get; set; }
        public long? Eventid { get; set; }
    }
}
