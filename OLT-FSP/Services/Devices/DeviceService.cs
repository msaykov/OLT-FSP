namespace OLT_FSP.Services.Devices
{
    using OLT_FSP.Data;
    using OLT_FSP.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DeviceService : IDeviceService
    {
        private readonly OltDbContext data;

        public DeviceService(OltDbContext data)
        => this.data = data;

        public int Create(string town, string dataCenter, string manifacturer)
        {
            var currentTown = this.GetTownByName(town);
            var TownEntity = currentTown == null ? new Town { Name = town } : currentTown;

            var currentdataCenter = this.GetDataCenterByName(dataCenter);
            var DataCenterEntity = currentdataCenter == null ? new DataCenter { Name = dataCenter, Town = TownEntity } : currentdataCenter;

            var devicesCount = GetDataCenterDevicesCount(dataCenter);
            var deviceEntity = new Device
            {
                Name = $"OLT-{devicesCount + 1}",
                Manifacturer = manifacturer,
                DataCenter = DataCenterEntity,
            };

            this.data.Devices.Add(deviceEntity);
            this.data.SaveChanges();

            return deviceEntity.Id;
        }

        public ICollection<DeviceServiceModel> All(string townName, string dataCenter)
        {
            var devicesQuery = this.data.Devices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(dataCenter))
            {
                devicesQuery = devicesQuery
                    .Where(d => d.DataCenter.Name == dataCenter);
            }

            if (!string.IsNullOrWhiteSpace(townName))
            {
                devicesQuery = devicesQuery
                    .Where(d => d.DataCenter.Town.Name.ToLower().Contains(townName.ToLower()));
            }

            return devicesQuery
                .OrderBy(d => d.DataCenter.Name)
                .Select(d => new DeviceServiceModel
                {
                    Id = d.Id,
                    Town = d.DataCenter.Town.Name,
                    DataCenter = d.DataCenter.Name,
                    Manifacturer = d.Manifacturer,
                    OltName = d.Name,
                    OltSlots = d.Slots.Count(),
                    

                })
                .ToList();
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

        public ICollection<string> GetDataCenters()
            => this.data
                .DataCenters
                .Select(dc => dc.Name)
                .Distinct()
                .ToList();
    }
}
