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

        public void Add(string path, string zone, string destinationAddress, string description, int coremapNumber, string notes, int slotId)
        {
            var currentSlot = GetSlotById(slotId);
            var portsCount = GetPortsCount(slotId);
            if (portsCount == currentSlot.PortsCount)
            {
                return;
            }

            var destinationEntity = GetDestinationByCoremapId(coremapNumber);
            if (destinationEntity == null)
            {
                destinationEntity = new Destination
                {
                    Address = destinationAddress,
                    MapNumber = coremapNumber,
                    Zone = zone,
                };
            } 

            var portEntity = new Port
            {
                Number = portsCount,
                Path = path,
                Description = description,
                Notes = notes,
                Destination = destinationEntity,
                PortFullName = $"0/{currentSlot.Number}/{portsCount}",
            };

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
                    .Where(p => p.Destination.Address.ToLower().Contains(destinationAddress.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(coremapNumber))
            {
                int coremapId;
                var success = int.TryParse(coremapNumber, out coremapId);
                if (success)
                {
                    portsQuery = portsQuery
                    .Where(p => p.Destination.MapNumber == coremapId);
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
                    DeviceFullName = pq.Slot.Device.DeviceFullName, // GetDeviceFullName(pq.SlotId),
                    PortFullName = pq.PortFullName,
                    Zone = pq.Destination.Zone,
                    DestinationId = pq.Destination.MapNumber,
                    DestinationAddress = pq.Destination.Address,
                    Path = pq.Path,
                    Description = pq.Description,
                    Notes = pq.Notes,
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
