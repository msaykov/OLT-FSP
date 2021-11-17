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
                    MapNumber = coremapNumber
                };
            } 

            var portEntity = new Port
            {
                Number = portsCount,
                Path = path,
                Zone = zone,
                Description = description,
                Notes = notes,
                Destination = destinationEntity,
            };

            currentSlot.Ports.Add(portEntity);
            this.data.SaveChanges();

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
