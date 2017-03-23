using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net;

namespace MobiWifiApp
{
    public partial class CmxObservations
    {
        public PhysicalAddress Clientmac { get; set; }
        public IPAddress Ipv4 { get; set; }
        public IPAddress Ipv6 { get; set; }
        public DateTime Seentime { get; set; }
        public string Ssid { get; set; }
        public int Rssi { get; set; }
        public string Manufacturer { get; set; }
        public string Os { get; set; }
        public float LocationLat { get; set; }
        public float LocationLng { get; set; }
        public float LocationUnc { get; set; }
        public long Id { get; set; }
        public long? Eventid { get; set; }
        public string Ipv4String
        {
            get => Ipv4?.ToString();
        }
        public virtual CmxEvents Event { get; set; }
    }
}
