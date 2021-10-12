namespace OLT_FSP.Services.Slots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ISlotService
    {
        void Add(int ports, int deviceId);
    }
}
