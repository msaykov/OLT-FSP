namespace OLT_FSP.Services.Devices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class DeviceSearchServiceModel
    {
        public ICollection<DeviceServiceModel> Devices { get; set; }

        [Display(Name = "Search by Town name:")]
        public string TownName { get; set; }

        [Display(Name = "Search by Data Center:")]
        public string DataCenter { get; set; }

        public ICollection<string> DataCenters { get; set; }
        
    }
}
