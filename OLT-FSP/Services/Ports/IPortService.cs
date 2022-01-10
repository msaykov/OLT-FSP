﻿namespace OLT_FSP.Services.Ports
{
    using OLT_FSP.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPortService
    {
        void Add(
            string path, 
            //string zone, 
            //string destinationAddress, 
            string description, 
            //int coremapNumber, 
            string notes, 
            int slotId
            );

        ICollection<PortServiceModel> All(string destinationAddress, string coremapNumber);
    }
}
