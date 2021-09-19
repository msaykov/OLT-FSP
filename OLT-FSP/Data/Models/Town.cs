namespace OLT_FSP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Town
    {
        public Town()
        {
            this.DataCenters = new List<DataCenter>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DataCenter> DataCenters { get; set; }
    }
}
