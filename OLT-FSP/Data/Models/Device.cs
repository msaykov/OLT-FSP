namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Device
    {
        public Device()
        {
            this.Slots = new List<Slot>();
        }
        public int Id { get; set; }

        public string Name { get; set; }  // OLT-1 , automathicly given
        
        public string Manifacturer { get; set; }  // ZTE , HUAWEI

        public int DataCenterId { get; set; }

        public DataCenter DataCenter { get; set; }

        public ICollection<Slot> Slots { get; set; }


    }
}
