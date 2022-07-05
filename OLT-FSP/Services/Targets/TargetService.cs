namespace OLT_FSP.Services.Targets
{
    using OLT_FSP.Data;
    using OLT_FSP.Data.Models;
    using System.Linq;

    public class TargetService : ITargetService
    {
        private readonly OltDbContext data;
        public TargetService(OltDbContext data)
        {
            this.data = data;
        }

        public void Add(string address, int mapNumber, string zone, int portId)
        {
            var targetEntity = this.data
                .Targets
                .FirstOrDefault(d => d.MapNumber == mapNumber);
            if (targetEntity == null)
            {
                targetEntity = new Target
                {
                    Address = address,
                    MapNumber = mapNumber,
                    Zone = zone,
                    //PortId = portId,
                };
            }
            this.data.Targets.Add(targetEntity);
            this.data.SaveChanges();
        }
    }
}
