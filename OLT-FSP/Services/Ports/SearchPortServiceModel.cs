﻿namespace OLT_FSP.Services.Ports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchPortServiceModel
    {
        public int Id { get; set; }

        public ICollection<PortServiceModel> Ports { get; set; }
    }
}
