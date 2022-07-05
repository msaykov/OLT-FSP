namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Position
    {
        public int Id { get; set; }

        [Required]
        public string OdfInfo { get; set; }

        //[Required]
        //public string OdfOutPosition { get; set; }

        public int SplitterId { get; set; }

        public Splitter Splitter { get; set; }

        
    }
}
