namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Splitter
    {
        public int Id { get; set; }

        public int OutputsCount { get; set; }

        public ICollection<Path> Paths { get; set; }


    }
}
