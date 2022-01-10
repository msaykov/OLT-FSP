namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Path
    {
        public int Id { get; set; }

        public string OdfInPosition { get; set; }

        [Required]
        public string OdfOutPosition { get; set; }

        public int SplitterId { get; set; }

        public Splitter Splitter { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}
