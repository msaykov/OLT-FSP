namespace OLT_FSP.Services.Targets
{
    using OLT_FSP.Data.Models;

    public interface ITargetService
    {
        void Add(string address, int mapNumber, string zone, int portId);
    }
}
