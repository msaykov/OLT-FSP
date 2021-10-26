namespace OLT_FSP.Services.Slots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AllSlotsServiceModel
    {
        public int Id { get; set; }
        public ICollection<SlotServiceModel> Slots{ get; set; }
    }
}
