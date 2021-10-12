namespace OLT_FSP.Services.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDeviceService
    {
        int Create(string town, string dataCenter, string manifacturer);

        ICollection<DeviceServiceModel> All(string town, string dataCenter);

        ICollection<string> GetDataCenters();
    }
}
