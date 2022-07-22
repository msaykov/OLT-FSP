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
                destinationEntity = new Target
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

        public EditPortServiceModel Edit(int portId)
        {
            var target = this.data
                .Targets
                .FirstOrDefault(d => d.Ports.Any(p => p.Id == portId));

            return this.data
                .Ports
                .Where(p => p.Id == portId)
                .Select(p => new EditPortServiceModel
                {
                    SplitterOutputs = "???",
                    Path = p.Path,
                    CoremapNumber = target != null ? target.MapNumber : 0,
                    Destination = target != null ? target.Address : "N/A",
                    Zone = target != null ? target.Zone : "N/A",
                    Notes = p.Notes,
                })
                .FirstOrDefault();
        }

        public void Edit(
            string splitterOutputs,     // direct = "1" , 1/2 = "2" , 1/16 = "16" ...
            string odfPort,             // ODF-5 , port 45 ...
            string destinationAddress,  // Mladost , bl.222 ...
            int coremapNumber,          // 123456
            string zone,                // zone name or empty
            string notes,               
            int portId
            )
        {
            var portEntity = this.GetPortById(portId);
            var targetEntity = this.GetDestinationByCoremapId(coremapNumber);

            if (targetEntity == null)
            {
                targetEntity = new Target
                {
                    MapNumber = coremapNumber,
                    Address = destinationAddress,
                    Zone = zone,
                };
            }

            var portEntityTarget = this.data
                .Targets
                .FirstOrDefault(t => t.Ports.Any(p => p.Id == portId));

            if (portEntityTarget == null)
            {
                portEntity.Targets.Add(targetEntity);
            }
            else
            {
                portEntityTarget.MapNumber = targetEntity.MapNumber;
                portEntityTarget.Address = targetEntity.Address;
                portEntityTarget.Zone = targetEntity.Zone;
            }

            portEntity.Path = odfPort;
            portEntity.Notes = notes;
            portEntity.IsUsed = true;            

            //if (splitterOutputs == "1")
            //{
            //    portEntity.Path = odfPort;
            //}
            //else
            //{
                
            //    //// TO DO Create new port for each splitter output-1

            //    //// create splitter Input position
            //    //var positionEntity = new Position
            //    //{
            //    //    OdfInfo = "Splitter Input Position",
            //    //    IsInputPosition = true
            //    //};

            //    //var splitterEntity = new Splitter()
            //    //{
            //    //    OutputsCount = int.Parse(splitterOutputs),
            //    //    PortId = portId,

            //    //};

            //    //splitterEntity.Positions.Add(positionEntity);

            //    //// first output gets the direct port info
            //    //positionEntity.IsInputPosition = false;
            //    //positionEntity.OdfInfo = odfPort;
            //    //splitterEntity.Positions.Add(positionEntity);

            //    //// add info to other splitter outputs
            //    //for (int i = 2; i <= splitterEntity.OutputsCount; i++)
            //    //{
            //    //    if (i == 2)
            //    //    {
            //    //        positionEntity.OdfInfo = "Splitter Output Position";
            //    //    }
            //    //    else
            //    //    {
            //    //        positionEntity.OdfInfo = "FREE";
            //    //    }
            //    //    splitterEntity.Positions.Add(positionEntity);
            //    //}

            //}
            this.data.SaveChanges();
        }


        public ICollection<PortServiceModel> All(string coremapId, string address, string port, int deviceId)
        {

            var portsQuery = this.data
                .Ports
                .AsQueryable();

            if (deviceId != 0)
            {
                portsQuery = portsQuery
                    .Where(p => p.Slot.Device.Id == deviceId)
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
                    Notes = pq.Notes,
                    Targets = pq.Targets,
                    //DestinationId = pq.Destination.MapNumber,
                    //DestinationAddress = pq.Destination.Address,
                    //Zone = pq.Destination.Zone,

                })
                .ToList();

        }

        private Port GetPortById(int portId)
        => this.data
            .Ports
            .FirstOrDefault(p => p.Id == portId);

        //private ICollection<Port> GetPortByTargetAddress(string address)
        //=> this.data
        //    .Ports
        //    .Where(p => p.Targets.Select(t => t.Address == address))

        public string GetDeviceFullName(int deviceId)
        {
            var device = this.data
                .Devices
                .FirstOrDefault(d => d.Id == deviceId);

            return device.DeviceFullName;
        }

        private Target GetDestinationByCoremapId(int coremapNumber)
            => this.data.Targets
            .FirstOrDefault(d => d.MapNumber == coremapNumber);

        private int GetUsedPortsCount(int slotId)
            => this.data.Ports
            .Where(p => p.SlotId == slotId && p.IsUsed == true)
            .Count();

        private Slot GetSlotById(int slotId)
            => this.data.Slots
            .FirstOrDefault(s => s.Id == slotId);

        private int GetDeviceId(int portId)
            => this.data
            .Devices
            .FirstOrDefault(d => d.Slots.Any(s => s.Ports.Any(p => p.Id == portId)))
            .Id;

    }
}
