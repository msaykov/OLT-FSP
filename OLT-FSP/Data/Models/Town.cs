namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class Town
    {
        public Town()
        {
            this.DataCenters = new List<DataCenter>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(TownNameMaxLength)]
        public string Name { get; set; }

        public ICollection<DataCenter> DataCenters { get; set; }
    }
}
