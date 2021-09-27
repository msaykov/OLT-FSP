namespace OLT_FSP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class Device
    {
        public Device()
        {
            this.Slots = new List<Slot>();
        }
        public int Id { get; set; }

        [MaxLength(DeviceNameMaxLength)]
        public string Name { get; set; }  // OLT-1 , automatically given

        [Required]
        [MaxLength(ManifacturerNameMaxLength)]
        public string Manifacturer { get; set; }  // ZTE , HUAWEI

        public int DataCenterId { get; set; }

        public DataCenter DataCenter { get; set; }

        public ICollection<Slot> Slots { get; set; }


    }
}
