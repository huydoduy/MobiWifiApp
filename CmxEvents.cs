using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace MobiWifiApp
{
    public partial class CmxEvents
    {
        public CmxEvents()
        {
            CmxObservations = new HashSet<CmxObservations>();
        }

        public long Id { get; set; }
        public PhysicalAddress Apmac { get; set; }
        public string Type { get; set; }
        public DateTime Received { get; set; }

        public virtual ICollection<CmxObservations> CmxObservations { get; set; }
    }
}
