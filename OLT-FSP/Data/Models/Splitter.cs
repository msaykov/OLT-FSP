namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Splitter
    {
        public Splitter()
        {
            this.OutputPositions = new List<Position>();
        }
        public int Id { get; set; }

        public int OutputsCount { get; set; }

        public string InputPosition { get; set; }

        public ICollection<Position> OutputPositions { get; set; }

        public int PortId { get; set; }

        //public Port Port { get; set; }


    }
}
