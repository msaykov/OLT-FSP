namespace OLT_FSP.Services.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDeviceService
    {
        void Create(string town, string dataCenter, string manifacturer);
    }
}
