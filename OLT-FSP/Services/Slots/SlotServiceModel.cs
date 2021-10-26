namespace OLT_FSP.Services.Slots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SlotServiceModel
    {
        public int Id { get; set; }

        public string DeviceName { get; set; }

        public int SlotNumber { get; set; }      

        public int PortsCount { get; set; }  

        public int UsedPorts { get; set; }  

        public bool IsServiceSlot { get; set; }
    }
}
