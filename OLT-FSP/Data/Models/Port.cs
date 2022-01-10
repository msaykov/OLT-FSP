namespace OLT_FSP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static OLT_FSP.Data.DataConstants;

    public class Port
    {
        public Port()
        {
            this.Targets = new List<Destination>();
        }
        public int Id { get; set; }

        public int Number { get; set; }

        public string PortFullName { get; set; }
        
        [Required]
        [MaxLength(PathMaxLength)]
        public string Path { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        [Required]
        [MaxLength(DescriptionMaxLength)]     
        public string Description { get; set; } // Residential customers , Business customers ... 

        //public int DestinationId { get; set; }

        //public Destination Destination { get; set; }
        
        public ICollection<Destination> Targets { get; set; }

        [MaxLength(NotesMaxLength)]
        public string Notes { get; set; }  // 1/2 in Cabinet , ....

        public int SlotId { get; set; }

        public Slot Slot { get; set; }


    }
}
