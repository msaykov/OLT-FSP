namespace OLT_FSP.Services.Ports
{
    using OLT_FSP.Data;
    using OLT_FSP.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PortService : IPortService
    {
        private readonly OltDbContext data;

        public PortService(OltDbContext data)
        => this.data = data;

        public void Add(
            string path,
            //string zone,
            //string destinationAddress,
            string description,
            //int coremapNumber,
            string notes,
            int slotId
            )
        {
            var currentSlot = GetSlotById(slotId);
            var portsCount = GetPortsCount(slotId);
            if (portsCount == currentSlot.PortsCount)
            {
                return;// message
            }


            var portEntity = new Port
            {
                Number = portsCount,
                Path = path,
                Description = description,
                Notes = notes,                
                //Destination = destinationEntity,
                PortFullName = $"0/{currentSlot.Number}/{portsCount}",
            };

            //var destinationEntity = GetDestinationByCoremapId(destination.MapNumber);
            //if (destinationEntity == null)
            //{
            //    destinationEntity = new Destination
            //    {
            //        Address = destination.Address,
            //        MapNumber = destination.MapNumber,
            //        Zone = destination.Zone,
            //    };
            //}
            //portEntity.Targets.Add(destinationEntity);

            currentSlot.Ports.Add(portEntity);
            this.data.SaveChanges();
        }

        public ICollection<PortServiceModel> All(string destinationAddress, string coremapNumber)
        {
            var portsQuery = this.data
                .Ports
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(destinationAddress))
            {
                portsQuery = portsQuery
                    .Where(p => p.Targets.Any(t => t.Address.ToLower().Contains(destinationAddress.ToLower())));
            }

            if (!string.IsNullOrWhiteSpace(coremapNumber))
            {
                int coremapId;
                var success = int.TryParse(coremapNumber, out coremapId);
                if (success)
                {
                    portsQuery = portsQuery
                    .Where(p => p.Targets.Any(t => t.MapNumber == coremapId));
                }
                else
                {
                    // Error message
                }                
            }            
            
            var portsList = portsQuery
                .OrderBy(p => p.Number)
                .Select(pq => new PortServiceModel
                {
                    DataCenterName = pq.Slot.Device.DataCenter.Name,
                    DeviceFullName = pq.Slot.Device.DeviceFullName, 
                    PortFullName = pq.PortFullName,
                    DataCenterSplit = "Direct port",
                    DataCenterOdfOut = pq.Path,
                    Description = pq.Description,
                    Targets = pq.Targets,
                    //DestinationId = pq.Destination.MapNumber,
                    //DestinationAddress = pq.Destination.Address,
                    //Zone = pq.Destination.Zone,
                })
                .ToList();

            return portsList;

        }

       
        private string GetDeviceFullName(int slotId)
        {
            var deviceName = this.data
                .Slots
                .Where(s => s.Id == slotId)
                .Select(d => d.Device.Name)
                .FirstOrDefault();

            var dataCenter = this.data
                .Slots
                .Where(s => s.Id == slotId)
                .Select(c => c.Device.DataCenter.Name)
                .FirstOrDefault();

            return $"{deviceName} {dataCenter}";
        }

        private Destination GetDestinationByCoremapId(int coremapNumber)
            => this.data.Destinations
            .FirstOrDefault(d => d.MapNumber == coremapNumber);

        private int GetPortsCount(int slotId)
            => this.data.Ports
            .Where(p => p.SlotId == slotId)
            .Count();

        private Slot GetSlotById(int slotId)
            => this.data.Slots
            .FirstOrDefault(s => s.Id == slotId);
    }
}
