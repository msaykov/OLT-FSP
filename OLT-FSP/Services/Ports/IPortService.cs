namespace OLT_FSP.Services.Ports
{
    using OLT_FSP.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPortService
    {
        void Add(
            string splitterOutputs,
            string path,
            string destinationAddress,
            int coremapNumber,
            string zone,
            string description, 
            string notes, 
            int slotId
            );

        EditPortServiceModel Edit(int portId);

        void Edit(
            string splitterOutputs,
            string odfPort,
            string destinationAddress,
            int coremapNumber,
            string zone,
            string notes,
            int portId
            );

        ICollection<PortServiceModel> All(string coremapId, string address, string port, int deviceId);

        string GetDeviceFullName(int id);
    }
}
