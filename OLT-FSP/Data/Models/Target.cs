namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class Target
    {
        public Target()
        {
            this.Positions = new List<Position>();
            this.Ports = new List<Port>();
        }
        public int Id { get; set; }

        public int MapNumber { get; set; }   // Coremap Id

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(ZoneMaxLength)]
        public string Zone { get; set; }

        //public int PathId { get; set; }

        //public Path Path { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<Port> Ports { get; set; }

        //public int PortId { get; set; }

        //public Port Port { get; set; }


    }
}
