namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class Destination
    {
        public int Id { get; set; }

        public int MapNumber { get; set; }   // Coremap Id

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        [MaxLength(ZoneMaxLength)]
        public string Zone { get; set; }
    }
}
