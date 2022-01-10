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

        public void Add(string address, int mapNumber, string zone, int slotId)
        {
            var targetEntity = this.data
                .Destinations
                .FirstOrDefault(d => d.MapNumber == mapNumber);
            if (targetEntity == null)
            {
                targetEntity = new Destination
                {
                    Address = address,
                    MapNumber = mapNumber,
                    Zone = zone,
                };
            }
            this.data.Destinations.Add(targetEntity);
            this.data.SaveChanges();
        }
    }
}
