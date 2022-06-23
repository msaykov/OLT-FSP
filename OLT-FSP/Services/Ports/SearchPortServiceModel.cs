namespace OLT_FSP.Services.Ports
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SearchPortServiceModel
    {
        public int Id { get; set; }

        public string DeviceFullName { get; set; }

        public ICollection<PortServiceModel> Ports { get; set; }

        [Display(Name = "Search by Address:")]
        public string Address { get; set; }

        [Display(Name = "Search by Coremap ID:")]
        public string CoremapId { get; set; }
    }
}
