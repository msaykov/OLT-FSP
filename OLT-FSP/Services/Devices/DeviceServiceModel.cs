namespace OLT_FSP.Services.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeviceServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string DataCenter { get; set; }
        public string Manifacturer { get; set; }
        public string OltName { get; set; }
        public int OltSlots { get; set; }
        public int OltPorts { get; set; }
        public int OltFreePorts { get; set; }
        
    }
}
