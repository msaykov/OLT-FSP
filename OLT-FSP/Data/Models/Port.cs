namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Port
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Zone { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }
    }
}
