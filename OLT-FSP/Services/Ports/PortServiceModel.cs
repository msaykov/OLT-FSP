namespace OLT_FSP.Services.Ports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PortServiceModel
    {
        public string PortFullName { get; set; } //   0/5/4

        public string Zone { get; set; }

        public string Path { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        public string Description { get; set; } // Residential customers , Business customers ... 

        public string DestinationAddress { get; set; }

        public int DestinationId { get; set; }

        public string Notes { get; set; }  // 1/2 in Cabinet , ....

        // public int SlotId { get; set; }

        public string DeviceFullName { get; set; } // OLT-3 KRAM

        
    }
}
