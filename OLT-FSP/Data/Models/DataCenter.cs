namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class DataCenter
    {
        public DataCenter()
        {
            this.Devices = new List<Device>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(DataCenterNameMaxLength)]
        public string Name { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Device> Devices { get; set; }


    }
}
