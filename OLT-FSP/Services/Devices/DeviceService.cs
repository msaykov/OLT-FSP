namespace OLT_FSP.Services.Devices
{
    using OLT_FSP.Data;
    using OLT_FSP.Data.Models;
    using System;
    using System.Linq;

    public class DeviceService : IDeviceService
    {
        private readonly OltDbContext data;

        public DeviceService(OltDbContext data)
        => this.data = data;

        public void Create(string town, string dataCenter, string manifacturer)
        {
            var currentTown = this.GetTownByName(town);
            var TownEntity = currentTown == null ? new Town { Name = town } : currentTown;

            var currentdataCenter = this.GetDataCenterByName(dataCenter);
            var DataCenterEntity = currentdataCenter == null ? new DataCenter { Name = dataCenter, Town = TownEntity } : currentdataCenter;

            //TownEntity.DataCenters.Add(DataCenterEntity);
            var devicesCount = GetDataCenterDevicesCount(dataCenter);
            var deviceEntity = new Device
            {
                Name = $"OLT-{devicesCount + 1}",
                Manifacturer = manifacturer,
                DataCenter = DataCenterEntity,
            };

            //DataCenterEntity.Devices.Add(deviceEntity);
            this.data.Devices.Add(deviceEntity);
            this.data.SaveChanges();

        }

        private int GetDataCenterDevicesCount(string dataCenter)
            => this.data
                .Devices
                .Where(d => d.DataCenter.Name == dataCenter)
                .Count();


        private DataCenter GetDataCenterByName(string dataCenter)
            => this.data
                .DataCenters
                .FirstOrDefault(dc => dc.Name == dataCenter);

        private Town GetTownByName(string town)
            => this.data
                .Towns
                .FirstOrDefault(t => t.Name == town);

    }
}
