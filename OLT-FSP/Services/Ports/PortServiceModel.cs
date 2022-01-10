namespace OLT_FSP.Services.Ports
{
    using OLT_FSP.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PortServiceModel
    {
        public string DataCenterName { get; set; }

        public string DeviceFullName { get; set; } // OLT-3 KRAM

        public string PortFullName { get; set; } //   0/5/4

        public string DataCenterSplit { get; set; }   // Direct Port , Splitter 1/2 ... 

        public string DataCenterOdfOut { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        public string SecondDataCenterName { get; set; }    
        public string SecondDataCenterOdfIn { get; set; }   
        public string SecondDataCenterSplit { get; set; }    
        public string SecondDataCenterOdfOut { get; set; }

        public ICollection<Destination> Targets { get; set; }
        //public int DestinationId { get; set; }

        //public string DestinationAddress { get; set; }

        //public string Zone { get; set; }

        public string Description { get; set; } // Residential customers , Business customers ... 
        
    }
}
