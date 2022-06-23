﻿namespace OLT_FSP.Services.Ports
{
    using OLT_FSP.Data.Models;
    using System.Collections.Generic;

    public class PortServiceModel
    {
        public int Id { get; set; }
        public string DataCenterName { get; set; }

        public string DeviceName { get; set; } // OLT-3

        public string PortFullName { get; set; } //   0/5/4

        public string DataCenterSplit { get; set; }   // Direct Port , Splitter 1/2 ... 

        public string DataCenterOdfOut { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        public string SecondDataCenterName { get; set; }    
        public string SecondDataCenterOdfIn { get; set; }   
        public string SecondDataCenterSplit { get; set; }    
        public string SecondDataCenterOdfOut { get; set; }

        public ICollection<Destination> Targets { get; set; }
        
        public string Description { get; set; } // Residential customers , Business customers ... 




        //public int Id { get; set; }

        //public int Number { get; set; }

        //public string PortFullName { get; set; }

        //[Required]
        //[MaxLength(PathMaxLength)]
        //public string Path { get; set; }   // Rack-1 , ODF-1 , port 5 ....  

        //[Required]
        //[MaxLength(DescriptionMaxLength)]
        //public string Description { get; set; } // Residential customers , Business customers ... 

        ////public int DestinationId { get; set; }

        ////public Destination Destination { get; set; }

        //public ICollection<Destination> Targets { get; set; }

        //[MaxLength(NotesMaxLength)]
        //public string Notes { get; set; }  // 1/2 in Cabinet , ....

        //public int SlotId { get; set; }

        //public Slot Slot { get; set; }

        //public bool IsUsed { get; set; } = false;




    }
}
