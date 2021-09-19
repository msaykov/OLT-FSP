namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Slot
    {
        public Slot()
        {
            this.Ports = new List<Port>();
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }

        public ICollection<Port> Ports { get; set; }
    }
}
