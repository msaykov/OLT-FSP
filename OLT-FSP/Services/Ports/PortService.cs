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
            string splitterOutputs,
            string path,
            string destinationAddress,
            int coremapNumber,
            string zone,
            string description,
            string notes,
            int slotId
            )
        {
            var currentSlot = GetSlotById(slotId);
            var portsCount = GetUsedPortsCount(slotId);
            if (portsCount == currentSlot.PortsCount)
            {
                return;// return error message 
            }


            var portEntity = new Port
            {
                Number = portsCount,
                Path = path,
                Description = description,
                Notes = notes,                
                //Destination = destinationEntity,
                PortFullName = $"0/{currentSlot.Number}/{portsCount}",
                IsUsed = true,
            };        

            //var splitterEntity = new Splitter
            //{
            //    OutputsCount = int.Parse(splitterOutputs),
            //};

            //var pathEntity = new Path
            //{
            //    OdfOutPosition = path,
            //};

            //if (splitterEntity.Paths.Count < splitterEntity.OutputsCount)
            //{
            //    splitterEntity.Paths.Add(pathEntity);
            //}
            //else
            //{
            //    // return error message
            //}

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
            //destinationEntity.Paths.Add(pathEntity);
            portEntity.Targets.Add(destinationEntity);

            currentSlot.Ports.Add(portEntity);
            this.data.SaveChanges();
        }

        
        public ICollection<PortServiceModel> All(string coremapId, string address, string port, int id)
        {

            var portsQuery = this.data
                .Ports
                .AsQueryable();

            if (id !=0)
            {
            portsQuery = portsQuery
                .Where(p => p.Slot.Device.Id == id)
                .AsQueryable();
            }



            //if (!string.IsNullOrWhiteSpace(address))
            //{
            //    portsQuery = GetPortByTargetAddress(address).ToList();


            //}

            if (!string.IsNullOrWhiteSpace(coremapId))
            {
                portsQuery = portsQuery
                    .Where(d => d.Targets.Any(t => t.MapNumber == int.Parse(coremapId)));
            }




            return portsQuery
                .OrderBy(p => p.PortFullName)
                .Select(pq => new PortServiceModel
                {
                    Id = pq.Id,
                    DataCenterName = pq.Slot.Device.DataCenter.Name,
                    DeviceName = pq.Slot.Device.Name,
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

        }


        public string GetDeviceFullName(int deviceId)
        {
            var device = this.data
                .Devices
                .FirstOrDefault(d => d.Id == deviceId);                

            return device.DeviceFullName;
        }

        private Destination GetDestinationByCoremapId(int coremapNumber)
            => this.data.Destinations
            .FirstOrDefault(d => d.MapNumber == coremapNumber);

        private int GetUsedPortsCount(int slotId)
            => this.data.Ports
            .Where(p => p.SlotId == slotId && p.IsUsed == true)
            .Count();

        private Slot GetSlotById(int slotId)
            => this.data.Slots
            .FirstOrDefault(s => s.Id == slotId);       
            
    }
}
